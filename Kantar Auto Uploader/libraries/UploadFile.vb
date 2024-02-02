
' please add WinSCP.exe startup Path 5.17.8.10803
' add reference WinSCPnet.dll 5.17.8.0
Imports WinSCP
Imports System.IO
'Imports ICSharpCode.SharpZipLib.Zip
'Imports ICSharpCode.SharpZipLib.Core

Imports System.IO.Compression

Public Class UploadFile
   ReadOnly sesOptions As SessionOptions
   Public filePath As String
   ReadOnly ftpDestinationFolder As String
   '
   Public status As New STAT_INFO()
   Public th As System.Threading.Thread
   Public setup As New SetupProp

   Sub New(filePath As String, ftpDestinationFolder As String, sesOption As WinSCP.SessionOptions)
      Me.filePath = filePath
      Me.sesOptions = sesOption
      Me.ftpDestinationFolder = ftpDestinationFolder

   End Sub

   Class SetupProp
      Public toZip As Boolean = False
      Public jobType As JobTypeEnum
      Public fileType As FileType_
      Enum JobTypeEnum As Integer
         NONE = 0
         BabyFood = 1
         BrandBank = 2
         Irish = 3
         ProductLibrary = 4
         RequestNutrition = 5
         TnsSs = 6
      End Enum
      Enum FileType_
         NONE = 0
         FOLDER = 1
         FILE = 2
      End Enum
   End Class

   Sub StartUpload()
      status = New STAT_INFO() With {
         .isErr = False,
         .errMsg = "",
         .isRunning = True,
         .isUploaded = False,
         .isDoneRunning = False
      }
      th = New System.Threading.Thread(AddressOf RunThread)
      th.Start()
   End Sub
   Private Sub RunThread()
      Try
         Dim ses As New Session
         AddHandler ses.FileTransferProgress, Sub(sender As Object, e As FileTransferProgressEventArgs)
                                                 status.uploadPercentage = String.Concat((e.FileProgress * 100).ToString, "%")
                                              End Sub
         ses.Open(Me.sesOptions)
         Try
            Dim transferOpt As New WinSCP.TransferOptions With {
               .TransferMode = TransferMode.Binary
            }
            Dim flNameWOext1 As String = IO.Path.GetFileNameWithoutExtension(Me.filePath)
            Dim extWithDot1 As String = IO.Path.GetExtension(Me.filePath)
            Dim dest1 As String = RemotePath.Combine(Me.ftpDestinationFolder, String.Concat(flNameWOext1, extWithDot1))
            If setup.toZip Then
               dest1 = RemotePath.Combine(Me.ftpDestinationFolder, String.Concat(flNameWOext1, ".zip"))
            End If
            'Possible error FileExists
            If ses.FileExists(dest1) Then
               status = New STAT_INFO() With {
                  .isErr = False,
                  .errMsg = "File already uploaded.",
                  .isRunning = False,
                  .isUploaded = False,
                  .isDoneRunning = True
               }
            Else
               If setup.toZip Then
                  status.compressingStatus = STAT_INFO.CompresStatus.Compressing
                  If setup.fileType = SetupProp.FileType_.FOLDER Then
                     Dim compress = ICSharpCode_Zip.CompressFolder(Me.filePath)
                     If compress.Succes Then
                        filePath = compress.CompressedPath
                        status.compressingStatus = STAT_INFO.CompresStatus.CompressDone
                     Else
                        status = New STAT_INFO() With {
                                    .isErr = True,
                                    .errMsg = compress.ErrorInfo.Message,
                                    .isRunning = False,
                                    .isUploaded = False,
                                    .isDoneRunning = True,
                                    .compressingStatus = STAT_INFO.CompresStatus.CompressError
                                 }
                        Exit Sub
                     End If
                  ElseIf setup.fileType = SetupProp.FileType_.FILE Then
                     Dim compress = ICSharpCode_Zip.CompressFile(Me.filePath)
                     If compress.Succes Then
                        filePath = compress.CompressedPath
                        status.compressingStatus = STAT_INFO.CompresStatus.CompressDone
                     Else
                        status = New STAT_INFO() With {
                                    .isErr = True,
                                    .errMsg = compress.ErrorInfo.Message,
                                    .isRunning = False,
                                    .isUploaded = False,
                                    .isDoneRunning = True,
                                    .compressingStatus = STAT_INFO.CompresStatus.CompressError
                                 }
                        Exit Sub
                     End If
                  Else
                     Throw New Exception("Path is not defined of what type")
                     Exit Sub
                  End If
               End If
               '
               Dim transferResult As TransferOperationResult
               Dim flNameWOext As String = IO.Path.GetFileNameWithoutExtension(Me.filePath)
               Dim extWithDot As String = IO.Path.GetExtension(Me.filePath)
               Dim tmpDest As String = RemotePath.Combine(Me.ftpDestinationFolder, String.Concat(flNameWOext, extWithDot, ".uploading"))
               Dim dest As String = RemotePath.Combine(Me.ftpDestinationFolder, String.Concat(flNameWOext, extWithDot))
               'Possible error FileExists
               If ses.FileExists(tmpDest) Then
                  'Possible error RemoveFile
                  ses.RemoveFile(tmpDest)
               End If
               'Possible error PutFiles
               transferResult = ses.PutFiles(Me.filePath, tmpDest, False, transferOpt)
               transferResult.Check()
               While Not transferResult.IsSuccess
                  Application.DoEvents()
               End While
               'Possible error MoveFile
               ses.MoveFile(tmpDest, dest)
               status = New STAT_INFO() With {
                  .isErr = False,
                  .errMsg = "Uploaded",
                  .isRunning = False,
                  .isUploaded = True,
                  .isDoneRunning = True
               }
            End If
         Catch ex As Exception
            status = New STAT_INFO() With {
               .isErr = True,
               .errMsg = "Uploading error => " & ex.Message,
               .isRunning = False,
               .isUploaded = False,
               .isDoneRunning = True
            }
         End Try
      Catch ex As Exception
         status = New STAT_INFO() With {
            .isErr = True,
            .errMsg = "Open session error => " & ex.Message,
            .isRunning = False,
            .isUploaded = False,
            .isDoneRunning = True
         }
      End Try
   End Sub


#Region "Utensils"
   Class STAT_INFO
      Public compressingStatus As CompresStatus
      Public isErr As Boolean = False
      Public errMsg As String = ""
      Public isRunning As Boolean = False
      Public isUploaded As Boolean = False
      Public isDoneRunning As Boolean = False
      Public uploadPercentage As String = ""
      Enum CompresStatus As Integer
         ToCompress = 0
         Compressing = 1
         CompressDone = 2
         CompressError = 3
      End Enum
   End Class
#End Region
End Class
