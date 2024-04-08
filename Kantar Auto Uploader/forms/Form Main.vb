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

   Friend WithEvents TimerUploderFileChecker As New AOA_Timer(8)
   Friend WithEvents TimerEmailFileChecker As New AOA_Timer(180)

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
      'ChkClearUploaded.Checked = fscProcessSettings.GetSettings.clearUploaded
      TimerUploderFileChecker.StartRunning()
      TimerEmailFileChecker.StartRunning()
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
      Return res
   End Function

   Property DgvSendEmailProp(rowIndex As Integer) As SendEmail
      Get
         Dim tag = Nothing
         Try
            tag = Dgv.Rows(rowIndex).Cells(EmailColumnIndex).Tag '
         Catch ex As Exception
            Throw New Exception("Row index is not found in DGV. [GET]")
         End Try
         If tag IsNot Nothing Then
            Return DirectCast(tag, SendEmail)
         Else
            Return Nothing
         End If
      End Get
      Set(value As SendEmail)
         Try
            Dgv.Rows(rowIndex).Cells(EmailColumnIndex).Tag = value
         Catch ex As Exception
            Throw New Exception("Row index is not found in DGV. [SET]")
         End Try
      End Set
   End Property

   Private Sub Timer_Tick(e As AOA_Timer.TickEventInfo) Handles TimerUploderFileChecker.Tick
      If e.IsTimeReached Then
         Dim p = fscProcessSettings.GetSettings
         Dim c = fscSessionOptions.GetSettings
         If p IsNot Nothing AndAlso p.checkIntervalMins > 0 Then
            Dim dateFolder As String = GetDateFolder()
            'Dim func = Function(folder As String) As String
            '              Return String.Concat(p.destinationDirectory, "/", folder, "/Output/", dateFolder)
            '           End Function
            RichTextBox2.Text = "Scan files from: " & p.sourceDirectory
            For Each type As FileTypeEnum In Types
               Dim dest As String = String.Concat(p.FtpDestinationDirectory, "/", dateFolder)
               Dim folderOutputWithDate As String = GetOutputFolder(type, dateFolder)
               Dim path As String = IO.Path.Combine(p.sourceDirectory, folderOutputWithDate)
               RichTextBox2.Text = RichTextBox2.Text & vbNewLine & vbTab & folderOutputWithDate
               Select Case type
                  Case FileTypeEnum.BabyFood
                     Dim FtpDestinationDirectory = p.FtpDestinationDirectory & "/receipts/BABYFOODS/ddc output"
                     For Each File_ As String In MyGetFiles(path).ToList
                        If IsAddable(File_) Then
                           Dim upload As New UploadFile(File_, FtpDestinationDirectory, c)
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                           upload.setup.toZip = True
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Baby Food", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each Directory_ As String In MyGetDirectories(path).ToList
                        If IsAddable(Directory_) Then
                           Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, c)
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                           upload.setup.toZip = True
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "Baby Food", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.BrandBank
                     Dim FtpDestinationDirectory = p.FtpDestinationDirectory & "/receipts/INGREDIENTS/Brandbank"
                     For Each File_ As String In MyGetFiles(path).ToList
                        If IsAddable(File_) Then
                           Dim upload As New UploadFile(File_, FtpDestinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "BrandBank", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each Directory_ As String In MyGetDirectories(path).ToList
                        If IsAddable(Directory_) Then
                           Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "BrandBank", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.ProductLibrary
                     Dim FtpDestinationDirectory = p.FtpDestinationDirectory & "/receipts/NUTRITION_IMAGES/Request_Output"
                     For Each File_ As String In MyGetFiles(path).ToList
                        If IsAddable(File_) Then
                           Dim upload As New UploadFile(File_, FtpDestinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Product Library", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each Directory_ As String In MyGetDirectories(path).ToList
                        If IsAddable(Directory_) Then
                           Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "Product Library", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.RequestNutrition
                     Dim FtpDestinationDirectory = p.FtpDestinationDirectory & "/receipts/NUTRITION_IMAGES/Request_Output"
                     For Each File_ As String In MyGetFiles(path).ToList
                        If IsAddable(File_) Then
                           Dim upload As New UploadFile(File_, FtpDestinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Request Nutrition", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                     For Each Directory_ As String In MyGetDirectories(path).ToList
                        If IsAddable(Directory_) Then
                           Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, c)
                           upload.setup.toZip = True
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "Request Nutrition", "to zip", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.Irish
                     Dim FtpDestinationDirectory = p.FtpDestinationDirectory & "/receipts/receiptsIE"
                     For Each File_ As String In MyGetFiles(path).ToList
                        If IsAddable(File_) Then
                           Dim upload As New UploadFile(File_, FtpDestinationDirectory, c)
                           upload.setup.toZip = False
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.Irish
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Irish", "---", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
                  Case FileTypeEnum.TnsSs
                     Dim FtpDestinationDirectory = p.FtpDestinationDirectory & "/receipts"
                     For Each File_ As String In MyGetFiles(path).ToList
                        If IsAddable(File_) Then
                           Dim upload As New UploadFile(File_, FtpDestinationDirectory, c)
                           upload.setup.toZip = False
                           upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                           upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.TnsSs
                           Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "TNS SS", "---", "For Upload")
                           Dgv.Rows(indx).Tag = upload
                        End If
                     Next
               End Select
            Next
         Else
            LblStatus.Text = "Please setup Upload Settings"
         End If
         TimerUploderFileChecker.maximumSeconds = (p.checkIntervalMins * 60)
         TimerUploderFileChecker.RestartTimer()
         If Not TimerUploaderStarter.Enabled Then TimerUploaderStarter.Enabled = True
         If Not TimerUploadStatus.Enabled Then TimerUploadStatus.Enabled = True
         If Not TimerEmailStarter_And_Status.Enabled Then TimerEmailStarter_And_Status.Enabled = True
      Else
         LblStatus.Text = GetDateFolder() & ". Scan files in (" & e.secondsRemaining & ") seconds. "
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
      Dim uploadingCount As Integer = 0
      For Each i As DataGridViewRow In Dgv.Rows
         Dim u As UploadFile = i.Tag
         If u.setup.toZip Then
            Select Case u.status.compressingStatus
               Case UploadFile.STAT_INFO.CompresStatus.ToCompress
                  i.Cells(IndexZipStatus).Value = "To be compressed"
               Case UploadFile.STAT_INFO.CompresStatus.Compressing
                  i.Cells(IndexZipStatus).Value = "Compressing..."
               Case UploadFile.STAT_INFO.CompresStatus.CompressDone
                  i.Cells(IndexZipStatus).Value = ".ZIP"
            End Select
         Else
            i.Cells(IndexZipStatus).Value = IO.Path.GetExtension(u.filePath)
         End If

         If u.status.error IsNot Nothing Then
            i.Cells(IndexUploadStatus).Value = u.status.error.Message
         Else
            If u.status.isDoneRunning Then
               If u.status.isUploaded Then
                  If u.status.error IsNot Nothing Then
                     i.Cells(IndexUploadStatus).Value = u.status.error.Message
                  Else
                     i.Cells(IndexUploadStatus).Value = "Done!"
                  End If
               Else
                  i.Cells(IndexUploadStatus).Value = u.status.message
               End If
            ElseIf Not u.status.isDoneRunning Then
               If u.status.isRunning Then
                  If u.status.compressingStatus = UploadFile.STAT_INFO.CompresStatus.Compressing Then
                     i.Cells(IndexUploadStatus).Value = "..."
                  Else
                     i.Cells(IndexUploadStatus).Value = "....Uploading " & u.status.uploadPercentage
                     uploadingCount += 1
                  End If
               Else
                  i.Cells(IndexUploadStatus).Value = "QUE"
               End If
            End If
         End If
      Next
      Dim p As ProcessSettings = fscProcessSettings.GetSettings
      'If p IsNot Nothing AndAlso p.clearUploaded Then
      '   For Each i As DataGridViewRow In Dgv.Rows
      '      Dim up As UploadFile = i.Tag
      '      If up.status.isUploaded Then
      '         Dgv.Rows.Remove(i)
      '      End If
      '   Next
      'End If
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

   Private Sub ChkClearUploaded_CheckedChanged(sender As Object, e As EventArgs) Handles ChkClearUploaded.CheckedChanged
      'Dim aa As ProcessSettings = fscProcessSettings.GetSettings
      'aa.clearUploaded = ChkClearUploaded.Checked
      'fscProcessSettings.SetSettings(aa)
   End Sub

   Private Sub BtnRetry_Click(sender As Object, e As EventArgs) Handles BtnRetry.Click
      If Dgv.SelectedRows IsNot Nothing Then
         For Each i As DataGridViewRow In Dgv.SelectedRows
            Dim upload As UploadFile = i.Tag
            If upload.status.error IsNot Nothing Then
               upload.StartUpload()
            End If
         Next
      End If
   End Sub

   Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
      Dim ses = fscSessionOptions.GetSettings
      Dim pro = fscProcessSettings.GetSettings
      Dim b As New FtpBrowser(ses, FtpBrowser.Mode_.file, pro.FtpDestinationDirectory)
      b.ShowDialog()
   End Sub

   Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
      Form_Email_Settings.ShowDialog()
   End Sub

   Private Sub TimerEmailFileChecker_Tick(e As AOA_Timer.TickEventInfo) Handles TimerEmailFileChecker.Tick
      If e.IsTimeReached Then
         Dim aa As ProcessSettings = fscProcessSettings.GetSettings
         Dim bb As Class_Email_Settings = fscEmailSettings.GetSettings
         For Each type As FileTypeEnum In Types
            Dim dt As String = GetDateFolder()
            Dim folderOutputWithDate As String = GetOutputFolder(type, dt)
            Dim folderOutputWithDate_uploaded As String = IO.Path.Combine(aa.sourceDirectory, folderOutputWithDate, UplodedFolder)
            If Not IsExistInEmaiTbl(folderOutputWithDate_uploaded) Then
               If Not IO.Directory.Exists(folderOutputWithDate_uploaded) Then IO.Directory.CreateDirectory(folderOutputWithDate_uploaded)
               Dim FE As New SendEmail() With {
                     .uploadedFolderPath = folderOutputWithDate_uploaded,
                     .TYPE = type,
                     .SelectedDate = DtCurrentDate.Value
                  }
               Dim n = DataGridView1.Rows.Add(type.ToString, dt, "")
               DataGridView1.Rows(n).Tag = FE
            End If
         Next
         TimerEmailFileChecker.RestartTimer()
      Else
         RichTextBox3.Text = GetDateFolder() & ".  Check for emails in (" & e.secondsRemaining & ") seconds. "
      End If
   End Sub

   Function IsExistInEmaiTbl(path As String) As Boolean
      Dim list As New List(Of String)
      For Each i As DataGridViewRow In DataGridView1.Rows
         Dim forE As SendEmail = i.Tag
         list.Add(forE.uploadedFolderPath)
      Next
      Return list.Contains(path)
   End Function


   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      If programmersMode Then
         DtCurrentDate.Value = "#1/26/2024 03:37:09 AM#"
         TimerEmailFileChecker.maximumSeconds = 10
      End If
   End Sub

   Private Sub TimerEmailStarter_Tick(sender As Object, e As EventArgs) Handles TimerEmailStarter_And_Status.Tick
      TimerEmailStarter_And_Status.Enabled = False
      For Each i As DataGridViewRow In DataGridView1.Rows
         Dim se As SendEmail = i.Tag
         If se IsNot Nothing Then
            If se.Status = SendEmail.EStatus.NONE Then
               se.RefreshFiles()
               If se.Files.Length > 0 Then
                  i.Cells(2).Value = "Ready to email. File count: " & se.Files.Length
               Else
                  i.Cells(2).Value = "No email files found in: " & se.uploadedFolderPath
               End If
            Else
               i.Cells(2).Value = se.Status.ToString
            End If
         End If
      Next
      TimerEmailStarter_And_Status.Enabled = True
   End Sub

   Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
      If DataGridView1.SelectedRows IsNot Nothing Then
         For Each row As DataGridViewRow In DataGridView1.SelectedRows
            Dim send As SendEmail = row.Tag
            If (send.Status = SendEmail.EStatus.NONE Or send.Status = SendEmail.EStatus.Error Or programmersMode) And send.Files.Length > 0 Then
               send.StartSend()
            End If
         Next
      End If
   End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      For Each row As DataGridViewRow In DataGridView1.Rows
         Dim send As SendEmail = row.Tag
         If (send.Status = SendEmail.EStatus.NONE Or send.Status = SendEmail.EStatus.Error Or programmersMode) And send.Files.Length > 0 Then
            send.StartSend()
         End If
      Next
   End Sub

End Class