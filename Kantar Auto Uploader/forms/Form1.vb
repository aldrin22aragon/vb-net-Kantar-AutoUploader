Imports WinSCP
Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Public Class Form1
   ' to zip
   '  Baby food
   '  Brandbank
   '  Product Library
   '  Request Nutrition
   ' as is
   '  Irish
   '  Tns SS

   Friend WithEvents Timer As New AOA_Timer(3)

   Enum FileTypeEnum As Integer
      NONE = 0
      BabyFood = 1
      BrandBank = 2
      Irish = 3
      ProductLibrary = 4
      RequestNutrition = 5
      TnsSs = 6
   End Enum



   Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      If Not IO.Directory.Exists(settingFolder) Then MkDir(settingFolder)
      Dim a As SessionOptions = fscSessionOptions.GetSettings
      While fscSessionOptions.GetSettings Is Nothing
         MsgBox("Please setup FTP connection.")
         Dim ftpSetting As New FtpSettings(fscSessionOptions.GetSettings)
         Dim result As DialogResult = ftpSetting.ShowDialog()
         If result <> DialogResult.OK Then
            Application.Exit()
            End
         End If
         fscSessionOptions.SetSettings(ftpSetting.ReturnSessionOptions)
      End While
      While fscProcessSettings.GetSettings Is Nothing
         MsgBox("Please setup Process settings.")
         Dim p As New Form_Process_Settings(fscSessionOptions.GetSettings, fscProcessSettings.GetSettings)
         If p.ShowDialog() <> DialogResult.OK Then
            Application.Exit()
            End
         End If
         fscProcessSettings.SetSettings(p.returnValueProcessSettings)
      End While
      Timer.StartTimer()
   End Sub

   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

   End Sub

   Private Sub TbFtpSettings_Click(sender As Object, e As EventArgs) Handles TbFtpSettings.Click
      Dim ftpSetting As New FtpSettings(fscSessionOptions.GetSettings)
      Dim result As DialogResult = ftpSetting.ShowDialog()
      If result = DialogResult.OK Then
         fscSessionOptions.SetSettings(ftpSetting.ReturnSessionOptions)
      End If
   End Sub

   Private Sub TbUploadSettins_Click(sender As Object, e As EventArgs) Handles TbUploadSettins.Click
      Dim p As New Form_Process_Settings(fscSessionOptions.GetSettings, fscProcessSettings.GetSettings)
      If p.ShowDialog() = DialogResult.OK Then
         fscProcessSettings.SetSettings(p.returnValueProcessSettings)
      End If
   End Sub

   Function MyGetDirectories(path) As String()
      Try
         Return IO.Directory.GetDirectories(path)
      Catch ex As Exception
         Return {}
      End Try
   End Function

   Function MyGetFiles(path) As String()
      Try
         Return IO.Directory.GetFiles(path)
      Catch ex As Exception
         Return {}
      End Try
   End Function

   Function IsAddable(path As String) As Boolean
      Dim ext As String = IO.Path.GetExtension(path).ToUpper
      If ext <> ".ZIP" Then
         Dim files As New List(Of String)
         For Each i As DataGridViewRow In dgv.Rows
            Dim forUp As UploadFile = i.Tag
            files.Add(forUp.filePath)
         Next
         Return Not files.Contains(path)
      Else
         Return False
      End If
   End Function
   Private Sub Timer_Tick(e As AOA_Timer.TickEventInfo) Handles Timer.Tick
      If e.IsTimeReached Then
         Dim p = fscProcessSettings.GetSettings
         Dim c = fscSessionOptions.GetSettings
         If p IsNot Nothing AndAlso p.checkIntervalMins > 0 Then
            Dim dateFolder As String = Format(DtCurrentDate.Value, "yyyyMMdd")
            If programmersMode Then
               dateFolder = "20240126"
            End If

            Dim types As New List(Of FileTypeEnum) From {
               FileTypeEnum.BabyFood,
               FileTypeEnum.BrandBank,
               FileTypeEnum.Irish,
               FileTypeEnum.ProductLibrary,
               FileTypeEnum.RequestNutrition,
               FileTypeEnum.TnsSs
            }

            For Each type As FileTypeEnum In types
               Select Case type
                  Case FileTypeEnum.BabyFood
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Baby Food", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                           upload.setup.toZip = True
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "Baby Food", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                           upload.setup.toZip = True
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "Baby Food", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.BrandBank
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Brandbank", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "BrandBank", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "BrandBank", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.ProductLibrary
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Product Library", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "Product Library", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "Product Library", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.RequestNutrition
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Request Nutrition", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "Request Nutrition", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "Request Nutrition", "to zip", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.Irish
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Irish", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = False
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.Irish
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "Irish", "---", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.TnsSs
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Tns SS", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, p.destinationDirectory, c)
                           upload.setup.toZip = False
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.TnsSs
                           Dim indx = dgv.Rows.Add(IO.Path.GetFileName(i), "TNS SS", "---", "For Upload")
                           dgv.Rows(indx).Tag = upload
                        End If
                     Next
               End Select
            Next
         Else
            ToolStatus.Text = "Please setup Upload Settings"
         End If
         Timer.maximumSeconds = (p.checkIntervalMins * 60)
         Timer.RestartTimer()
         TimerUploaderStarter.Enabled = True
         TimerUploadStatus.Enabled = True
      Else
         LblStatus.Text = "Scan files in (" & e.secondsRemaining & ") seconds"
      End If
   End Sub

   Private Sub TimerUploaderStarter_Tick(sender As Object, e As EventArgs) Handles TimerUploaderStarter.Tick
      TimerUploaderStarter.Enabled = False
      Dim p = fscProcessSettings.GetSettings
      For Each i As DataGridViewRow In dgv.Rows
         Dim cnt = GetCountProcessing()
         If p.simultaneousUpload > cnt Then
            Dim u As UploadFile = i.Tag
            If Not u.status.isDoneRunning And Not u.status.isRunning And Not u.status.isErr Then
               u.StartUpload()
            End If
         End If
      Next
      TimerUploaderStarter.Enabled = True
   End Sub

   Private Sub TimerUploadStatus_Tick(sender As Object, e As EventArgs) Handles TimerUploadStatus.Tick
      For Each i As DataGridViewRow In dgv.Rows
         Dim u As UploadFile = i.Tag
         If u.status.isErr Then
            u = u
         Else
            If u.setup.toZip Then
               Select Case u.status.compressingStatus
                  Case UploadFile.STAT_INFO.CompresStatus.ToCompress
                     i.Cells(2).Value = "To be compressed"
                  Case UploadFile.STAT_INFO.CompresStatus.Compressing
                     i.Cells(2).Value = "Compressing..."
                  Case UploadFile.STAT_INFO.CompresStatus.CompressDone
                     i.Cells(2).Value = ".ZIP"
               End Select
            Else
               i.Cells(2).Value = IO.Path.GetExtension(u.filePath)
            End If
            If u.status.isDoneRunning Then
               If u.status.isUploaded Then
                  i.Cells(3).Value = "Uploaded"
               Else
                  i.Cells(3).Value = u.status.errMsg
               End If
            ElseIf Not u.status.isDoneRunning Then
               If u.status.isRunning Then
                  If u.status.compressingStatus = UploadFile.STAT_INFO.CompresStatus.Compressing Then
                     i.Cells(3).Value = "..."
                  Else
                     i.Cells(3).Value = "Uploading " & u.status.uploadPercentage
                  End If
               Else
                  i.Cells(3).Value = "QUE"
               End If
            End If
         End If
      Next
   End Sub

   Function GetCountProcessing() As Integer
      Dim res As Integer = 0
      For Each i As DataGridViewRow In dgv.Rows
         Dim u As UploadFile = i.Tag
         If u.status.isRunning Then
            res += 1
         End If
      Next
      Return res
   End Function

   Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
      Dim sourceFolderPath As String = "C:\Users\soft10\source\repos\Kantar Auto Uploader\Kantar Auto Uploader\bin\Debug\Test Files\4FTP\Baby Food\Output\20240126\Reject Images 20240126_1\New folder"
      Dim gzipFilePath As String = "C:\Users\soft10\source\repos\Kantar Auto Uploader\Kantar Auto Uploader\bin\Debug\Test Files\4FTP\Baby Food\Output\20240126\Reject Images 20240126_1\New folder.zip"
      Try
         Using zipStream As FileStream = New FileStream(gzipFilePath, FileMode.Create)
            Using zipOutput As ZipOutputStream = New ZipOutputStream(zipStream)
               zipOutput.SetLevel(5) ' Compression level (0-9)

               CompressFolder(sourceFolderPath, "", zipOutput)
            End Using
         End Using
         Console.WriteLine("Folder compressed successfully.")
      Catch ex As Exception
         Console.WriteLine($"Error: {ex.Message}")
      End Try
   End Sub

   Sub CompressFolder(folderPath As String, relativePath As String, zipOutput As ZipOutputStream)
      Dim files As String() = Directory.GetFiles(folderPath)
      Dim subFolders As String() = Directory.GetDirectories(folderPath)

      ' Compress files
      For Each filePath As String In files
         Dim entryName As String = Path.Combine(relativePath, Path.GetFileName(filePath))
         Dim newEntry As ZipEntry = New ZipEntry(entryName)
         newEntry.DateTime = DateTime.Now
         newEntry.Size = New FileInfo(filePath).Length

         zipOutput.PutNextEntry(newEntry)

         Using fileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim buffer As Byte() = New Byte(4096) {}
            Dim bytesRead As Integer

            Do
               bytesRead = fileStream.Read(buffer, 0, buffer.Length)
               zipOutput.Write(buffer, 0, bytesRead)
            Loop While bytesRead > 0
         End Using

         zipOutput.CloseEntry()
      Next

      ' Recursively compress sub-folders
      For Each subFolder As String In subFolders
         Dim entryName As String = Path.Combine(relativePath, Path.GetFileName(subFolder) + Path.DirectorySeparatorChar)
         zipOutput.PutNextEntry(New ZipEntry(entryName))
         CompressFolder(subFolder, entryName, zipOutput)
      Next
   End Sub
End Class
