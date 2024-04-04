Imports System.IO
Imports WinSCP
Module Gloabals
   Public settingFolder As String = IO.Path.Combine(Application.StartupPath, "Settings")
   Public logFolder As String = IO.Path.Combine(Application.StartupPath, "Log Files")
   '
   ReadOnly fscSessionOptionsFilePath As String = IO.Path.Combine(settingFolder, "session-options.drihnz")
   ReadOnly fscProcessSettingsFilePath As String = IO.Path.Combine(settingFolder, "process-settings.drihnz")
   ReadOnly fscEmailSettingsFilePath As String = IO.Path.Combine(settingFolder, "email-settings.drihnz")
   '
   Public fscSessionOptions As New FileSettingsCreator2(Of SessionOptions)(fscSessionOptionsFilePath, New SessionOptions)
   Public fscProcessSettings As New FileSettingsCreator2(Of ProcessSettings)(fscProcessSettingsFilePath, New ProcessSettings)
   Public fscEmailSettings As New FileSettingsCreator2(Of Class_Email_Settings)(fscEmailSettingsFilePath, New Class_Email_Settings)

   Public programmersMode As Boolean = IO.Directory.Exists("C:\Users\soft10\source\repos\Kantar Auto Uploader\Kantar Auto Uploader\bin\Debug\Files\Test Files\4FTP\Baby Food\Output")
   '
   Public Const EmailColumnIndex As Integer = 0 ' dito ilalagay ysa cell yung sender
   Public Const IndexZipStatus As Integer = 2
   Public Const IndexUploadStatus As Integer = 3
   Public Const IndexEmailStatus As Integer = 4
   '
   Public Types As New List(Of FileTypeEnum) From {
               FileTypeEnum.BabyFood,
               FileTypeEnum.BrandBank,
               FileTypeEnum.Irish,
               FileTypeEnum.ProductLibrary,
               FileTypeEnum.RequestNutrition,
               FileTypeEnum.TnsSs
            }
   '
   Public Const AttachmentValue As String = "{Attachement}"
   Public Const UplodedFolder As String = "Uploaded"
   Public Const EmailedStr As String = "Emailed"
   Public Const DateAttachment As String = "{Date}"
   '
   Enum FileTypeEnum As Integer
      NONE = 0
      BabyFood = 1
      BrandBank = 2
      Irish = 3
      ProductLibrary = 4
      RequestNutrition = 5
      TnsSs = 6
   End Enum
   '
   Public Function GetOutputFolder(type_ As FileTypeEnum, dateFolder As String) As String
      Dim res As String
      Select Case type_
         Case FileTypeEnum.BabyFood
            res = IO.Path.Combine("Baby Food", "Output", dateFolder)
         Case FileTypeEnum.BrandBank
            res = IO.Path.Combine("Brandbank", "Output", dateFolder)
         Case FileTypeEnum.Irish
            res = IO.Path.Combine("Irish", "Output", dateFolder)
         Case FileTypeEnum.NONE
            Throw New Exception("Invalid type parameter of none.")
         Case FileTypeEnum.ProductLibrary
            res = IO.Path.Combine("Product Library", "Output", dateFolder)
         Case FileTypeEnum.RequestNutrition
            res = IO.Path.Combine("Request Nutrition", "Output", dateFolder)
         Case FileTypeEnum.TnsSs
            res = IO.Path.Combine("Tns SS", "Output", dateFolder)
         Case Else
            Throw New Exception("Invalid type parameter")
      End Select
      Return res
   End Function
   '
   Sub ErrMsg(msg As String)
      MessageBox.Show(msg, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error)
   End Sub
   Sub SuccessMsg(msg As String)
      MessageBox.Show(msg, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
   End Sub
   Public Function YesNo(msg As String, Optional header As String = "????", Optional icon As Windows.Forms.MessageBoxIcon = MessageBoxIcon.Question) As DialogResult
      Dim res As DialogResult = DialogResult.Cancel
      res = MessageBox.Show(msg, header, MessageBoxButtons.YesNo, icon, MessageBoxDefaultButton.Button2)
      Return res
   End Function
   Public Function YesNoCancel(msg As String, Optional header As String = "????", Optional icon As Windows.Forms.MessageBoxIcon = MessageBoxIcon.Question) As DialogResult
      Dim res As DialogResult = DialogResult.Cancel
      res = MessageBox.Show(msg, header, MessageBoxButtons.YesNoCancel, icon, MessageBoxDefaultButton.Button2)
      Return res
   End Function
   Public Function okCancel(msg As String) As DialogResult
      Dim res As DialogResult = DialogResult.Cancel
      res = MessageBox.Show(msg, "!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
      Return res
   End Function
   Public Function IsFileOpen(ByVal file As String)
      Dim res As Boolean = False

      Try
         If IO.File.Exists(file) Then
            Dim flInfo As New IO.FileInfo(file)
            Dim stream As FileStream = flInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
            stream.Dispose()
            res = False
         End If
      Catch ex As Exception
         res = True
      End Try
      Return res
   End Function


End Module
