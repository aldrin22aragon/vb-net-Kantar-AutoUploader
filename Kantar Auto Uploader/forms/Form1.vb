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
      If programmersMode Then
         Button2.Visible = True
      Else
         Button2.Visible = False
      End If
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
         For Each i As DataGridViewRow In Dgv.Rows
            Dim forUp As UploadFile = i.Tag
            files.Add(forUp.originalFilePath)
         Next
         files.Add(IO.Path.Combine(IO.Path.GetDirectoryName(path), "Uploaded"))
         Return Not files.Contains(path)
      Else
         Return False
      End If
   End Function
   Function GetDateFolder() As String
      Dim res = Format(DtCurrentDate.Value, "yyyyMMdd")
      If programmersMode Then
         res = "20240126"
      End If
      Return res
   End Function
   Private Sub Timer_Tick(e As AOA_Timer.TickEventInfo) Handles Timer.Tick
      If e.IsTimeReached Then
         Dim p = fscProcessSettings.GetSettings
         Dim c = fscSessionOptions.GetSettings
         If p IsNot Nothing AndAlso p.checkIntervalMins > 0 Then
            Dim dateFolder As String = GetDateFolder()

            Dim types As New List(Of FileTypeEnum) From {
               FileTypeEnum.BabyFood,
               FileTypeEnum.BrandBank,
               FileTypeEnum.Irish,
               FileTypeEnum.ProductLibrary,
               FileTypeEnum.RequestNutrition,
               FileTypeEnum.TnsSs
            }

            Dim func = Function(folder As String) As String
                          Return String.Concat(p.destinationDirectory, "/", folder, "/Output/", dateFolder)
                       End Function

            For Each type As FileTypeEnum In types
               Dim dest As String = String.Concat(p.destinationDirectory, "/", dateFolder)
               Select Case type
                  Case FileTypeEnum.BabyFood
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Baby Food", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Baby food"), c)
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                           upload.setup.toZip = True
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "Baby Food", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Baby food"), c)
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                           upload.setup.toZip = True
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "Baby Food", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload

                        End If
                     Next
                  Case FileTypeEnum.BrandBank
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Brandbank", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Brandbank"), c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "BrandBank", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Brandbank"), c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "BrandBank", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.ProductLibrary
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Product Library", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Product Library"), c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "Product Library", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Product Library"), c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "Product Library", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.RequestNutrition
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Request Nutrition", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Request Nutrition"), c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "Request Nutrition", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each i As String In MyGetDirectories(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Request Nutrition"), c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "Request Nutrition", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.Irish
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Irish", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Irish"), c)
                           upload.setup.toZip = False
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.Irish
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "Irish", "---", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.TnsSs
                     Dim path As String = IO.Path.Combine(p.sourceDirectory, "Tns SS", "Output", dateFolder)
                     For Each i As String In MyGetFiles(path).ToList
                        If IsAddable(i) Then
                           Dim upload As New UploadFile(i, func("Tns SS"), c)
                           upload.setup.toZip = False
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.TnsSs
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(i), "TNS SS", "---", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
               End Select
            Next
         Else
            LblStatus.Text = "Please setup Upload Settings"
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
      For Each i As DataGridViewRow In Dgv.Rows
         Dim cnt = GetCountProcessing()
         If p.simultaneousUpload > cnt Then
            Dim u As UploadFile = i.Tag
            If Not u.status.isDoneRunning And Not u.status.isRunning And u.status.error Is Nothing Then
               u.StartUpload()
            End If
         End If
      Next
      TimerUploaderStarter.Enabled = True
   End Sub

   Private Sub TimerUploadStatus_Tick(sender As Object, e As EventArgs) Handles TimerUploadStatus.Tick
      For Each i As DataGridViewRow In Dgv.Rows
         Dim u As UploadFile = i.Tag
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

         If u.status.error IsNot Nothing Then
            i.Cells(3).Value = u.status.error.Message
         Else
            If u.status.isDoneRunning Then
               If u.status.isUploaded Then
                  If u.status.error IsNot Nothing Then
                     i.Cells(3).Value = u.status.error.Message
                  Else
                     i.Cells(3).Value = "Uploaded"
                  End If
               Else
                  i.Cells(3).Value = u.status.message
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
      For Each i As DataGridViewRow In Dgv.Rows
         Dim u As UploadFile = i.Tag
         If u.status.isRunning Then
            res += 1
         End If
      Next
      Return res
   End Function

   Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
      Dim p = fscProcessSettings.GetSettings
      Dim types As New List(Of FileTypeEnum) From {
         FileTypeEnum.BabyFood,
         FileTypeEnum.BrandBank,
         FileTypeEnum.Irish,
         FileTypeEnum.ProductLibrary,
         FileTypeEnum.RequestNutrition,
         FileTypeEnum.TnsSs
      }
      For Each i As FileTypeEnum In types
         Dim pathUploaded As String = ""
         Select Case i
            Case FileTypeEnum.BabyFood
               pathUploaded = IO.Path.Combine(p.sourceDirectory, "Baby Food", "output", GetDateFolder, "Uploaded")
            Case FileTypeEnum.BrandBank
               pathUploaded = IO.Path.Combine(p.sourceDirectory, "Brandbank", "output", GetDateFolder, "Uploaded")
            Case FileTypeEnum.Irish
               pathUploaded = IO.Path.Combine(p.sourceDirectory, "Irish", "output", GetDateFolder, "Uploaded")
            Case FileTypeEnum.ProductLibrary
               pathUploaded = IO.Path.Combine(p.sourceDirectory, "Product Library", "output", GetDateFolder, "Uploaded")
            Case FileTypeEnum.RequestNutrition
               pathUploaded = IO.Path.Combine(p.sourceDirectory, "Request Nutrition", "output", GetDateFolder, "Uploaded")
            Case FileTypeEnum.TnsSs
               pathUploaded = IO.Path.Combine(p.sourceDirectory, "TNS SS", "output", GetDateFolder, "Uploaded")
         End Select
         If pathUploaded <> "" Then
            Dim a As String = IO.Path.GetDirectoryName(pathUploaded)
            MoveAll(pathUploaded, a)
         End If
      Next
   End Sub

   Sub MoveAll(sourse As String, destination As String)

      Try
         ' Check if the source folder exists
         If Directory.Exists(sourse) Then
            ' Check if the destination folder exists
            If Not Directory.Exists(destination) Then
               ' If it doesn't, create the destination folder
               Directory.CreateDirectory(destination)
            End If

            ' Move files
            For Each filePath As String In Directory.GetFiles(sourse)
               Dim fileName As String = Path.GetFileName(filePath)
               Dim destinationPath As String = Path.Combine(destination, fileName)

               ' If the file already exists in the destination, you might want to handle it accordingly (e.g., overwrite, skip)
               If File.Exists(destinationPath) Then
                  ' Handle the situation (e.g., overwrite, skip)
                  ' For now, let's just print a message
                  Console.WriteLine($"File '{fileName}' already exists in the destination.")
               Else
                  ' Move the file
                  File.Move(filePath, destinationPath)
                  Console.WriteLine($"File '{fileName}' moved successfully.")
               End If
            Next

            ' Move sub-folders
            For Each subFolder As String In Directory.GetDirectories(sourse)
               Dim folderName As String = Path.GetFileName(subFolder)
               Dim destinationPath As String = Path.Combine(destination, folderName)

               ' If the folder already exists in the destination, you might want to handle it accordingly (e.g., overwrite, skip)
               If Directory.Exists(destinationPath) Then
                  ' Handle the situation (e.g., overwrite, skip)
                  ' For now, let's just print a message
                  Console.WriteLine($"Folder '{folderName}' already exists in the destination.")
               Else
                  ' Move the folder
                  Directory.Move(subFolder, destinationPath)
                  Console.WriteLine($"Folder '{folderName}' moved successfully.")
               End If
            Next

            Console.WriteLine("All files and folders moved successfully.")
         Else
            Console.WriteLine("Source folder does not exist.")
         End If
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

   Private Sub Dgv_CurrentCellChanged(sender As Object, e As EventArgs) Handles Dgv.CurrentCellChanged
      If Dgv.CurrentCell IsNot Nothing Then
         Dim rowIndex As Integer = Dgv.CurrentCell.RowIndex
         Dim row As DataGridViewRow = Dgv.Rows(rowIndex)
         Dim u As UploadFile = row.Tag
         If u IsNot Nothing AndAlso u.status.error IsNot Nothing Then
            RichTextBox1.Text = String.Concat(IO.Path.GetFileName(u.filePath), vbNewLine, u.status.error.Message)
         End If
      End If
   End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      For Each i As DataGridViewRow In Dgv.Rows
         Dim up As UploadFile = i.Tag
         If up.status.isUploaded Then
            Dgv.Rows.Remove(i)
         End If
      Next
   End Sub
End Class
