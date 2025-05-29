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

    Friend WithEvents _TimerUploderFileChecker As New AOA_Timer(8)
    Friend WithEvents _TimerEmailFileChecker As New AOA_Timer(180)

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
        _TimerUploderFileChecker.StartRunning()
        _TimerEmailFileChecker.StartRunning()
    End Sub


    Private Sub TbFtpSettings_Click(sender As Object, e As EventArgs) Handles TbFtpSettings.Click
        Dim ftpSetting As New FtpSettings(fscSessionOptions.GetSettings)
        Dim result As DialogResult = ftpSetting.ShowDialog()
        If result = DialogResult.OK Then
            If ftpSetting.ReturnSessionOptions.SshPrivateKeyPath <> "" Then
                Dim ppk As String = ftpSetting.ReturnSessionOptions.SshPrivateKeyPath
                If IO.File.Exists(ppk) Then
                    IO.File.Copy(ppk, privateKeyPath_TMP, True)
                    ftpSetting.ReturnSessionOptions.SshPrivateKeyPath = privateKeyPath
                Else
                    MyMessageBox.ErrMsg($"File not found:{ppk}")
                End If
            End If
            fscSessionOptions.SetSettings(ftpSetting.ReturnSessionOptions)
            MyMessageBox.SuccessMsg("Upon saving you must restart the program.")
            Application.Exit()
            End
        End If
    End Sub

    Private Sub TbUploadSettins_Click(sender As Object, e As EventArgs) Handles TbUploadSettins.Click
        Dim p As New Form_Process_Settings(fscSessionOptions.GetSettings, fscProcessSettings.GetSettings)
        If p.ShowDialog() = DialogResult.OK Then
            fscProcessSettings.SetSettings(p.returnValueProcessSettings)
        End If
    End Sub

    Class ErrorData(Of T)
        Public Data As T
        Public Err As Exception = Nothing
    End Class

    Function MyGetDirectories(path) As ErrorData(Of String())
        Try
            'Throw New Exception("Test error2")
            Return New ErrorData(Of String()) With {
                .Data = IO.Directory.GetDirectories(path)
            }
        Catch ex As Exception
            Return New ErrorData(Of String()) With {
                .Data = {},
                .Err = ex
            }
        End Try
    End Function

    Function MyGetFiles(path) As ErrorData(Of String())
        Try
            'Throw New Exception("Test error1")
            Return New ErrorData(Of String()) With {
                .Data = IO.Directory.GetFiles(path)
            }
        Catch ex As Exception
            Return New ErrorData(Of String()) With {
                .Data = {},
                .Err = ex
            }
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
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvErrors.CellContentClick
        If e.ColumnIndex = 4 AndAlso e.RowIndex >= 0 Then
            ' Handle the button click
            Dim exView As New Exception_Viewer(DgvErrors.Rows(DgvErrors.CurrentRow.Index))
            exView.ShowDialog()
        End If
    End Sub


    Private Sub Timer_Tick(e As AOA_Timer.TickEventInfo) Handles _TimerUploderFileChecker.Tick
        If e.IsTimeReached Then

            Dim process_Settings = fscProcessSettings.GetSettings
            Dim winscpConnectionOptions = fscSessionOptions.GetSettings
            If process_Settings IsNot Nothing AndAlso process_Settings.checkIntervalMins > 0 Then
                If DgvErrors.RowCount >= 300 Then
                    DgvErrors.Rows.Clear()
                End If
                If DgvErrors.RowCount > 0 Then
                    DgvErrors.Rows.Add("-----------------------------------")
                End If
                Dim dateFolder As String = GetDateFolder()
                'Dim func = Function(folder As String) As String
                '              Return String.Concat(p.destinationDirectory, "/", folder, "/Output/", dateFolder)
                '           End Function
                For Each type As FileTypeEnum In Types
                    Dim dest As String = String.Concat(process_Settings.FtpDestinationDirectory, "/", dateFolder)
                    Dim folderOutputWithDate As String = GetOutputFolder(type, dateFolder)
                    Dim path As String = IO.Path.Combine(process_Settings.sourceDirectory, folderOutputWithDate)
                    Dim addedIndex As Integer = DgvErrors.Rows.Add(type.ToString, path)
                    Dim tmpFiles As ErrorData(Of String()) = MyGetFiles(path)
                    Dim tmpDirectories As ErrorData(Of String()) = MyGetDirectories(path)

                    Dim validateFiles As Action = Sub()
                                                      If tmpFiles.Err IsNot Nothing Then
                                                          Dim vl = DgvErrors.Rows(addedIndex).Cells(3).Value
                                                          DgvErrors.Rows(addedIndex).Cells(3).Value = $"{vl} | Scan files Error"
                                                          DgvErrors.Rows(addedIndex).Cells(0).Tag = tmpFiles.Err
                                                      Else
                                                          If tmpFiles.Data.Length < 1 Then
                                                              DgvErrors.Rows(addedIndex).Cells(2).Value = DgvErrors.Rows(addedIndex).Cells(2).Value & "No Files found"
                                                          End If
                                                      End If
                                                  End Sub
                    Dim validatedirectories As Action = Sub()
                                                            If tmpDirectories.Err IsNot Nothing Then
                                                                Dim vl = DgvErrors.Rows(addedIndex).Cells(3).Value
                                                                DgvErrors.Rows(addedIndex).Cells(3).Value = $"{vl} | Scan directory Error"
                                                                DgvErrors.Rows(addedIndex).Cells(1).Tag = tmpDirectories.Err
                                                            Else
                                                                If tmpDirectories.Data.Length < 1 OrElse (tmpDirectories.Data.Length = 1 AndAlso tmpDirectories.Data(0).ToUpper.EndsWith("UPLOADED")) Then
                                                                    DgvErrors.Rows(addedIndex).Cells(2).Value = DgvErrors.Rows(addedIndex).Cells(2).Value & " | No Directories found"
                                                                End If
                                                            End If
                                                        End Sub
                    DgvErrors.Rows(addedIndex).Cells(4).Value = "View"
                    If Not IO.Directory.Exists(path) Then
                        DgvErrors.Rows(addedIndex).Cells(2).Value = "Directory does not exist."
                    Else
                        Select Case type
                            Case FileTypeEnum.BabyFood
                                Dim FtpDestinationDirectory = process_Settings.FtpDestinationDirectory & "/receipts/BABYFOODS/ddc output"
                                For Each File_ As String In tmpFiles.Data.ToList
                                    If IsAddable(File_) Then
                                        Dim upload As New UploadFile(File_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                                        upload.setup.toZip = True
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Baby Food", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                For Each Directory_ As String In tmpDirectories.Data.ToList
                                    If IsAddable(Directory_) Then
                                        Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BabyFood
                                        upload.setup.toZip = True
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "Baby Food", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                validateFiles()
                                validatedirectories()
                            Case FileTypeEnum.BrandBank
                                Dim FtpDestinationDirectory = process_Settings.FtpDestinationDirectory & "/receipts/INGREDIENTS/Brandbank"
                                For Each File_ As String In tmpFiles.Data.ToList
                                    If IsAddable(File_) Then
                                        Dim upload As New UploadFile(File_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = True
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "BrandBank", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                For Each Directory_ As String In tmpDirectories.Data.ToList
                                    If IsAddable(Directory_) Then
                                        Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = True
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.BrandBank
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "BrandBank", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                validateFiles()
                                validatedirectories()
                            Case FileTypeEnum.ProductLibrary
                                Dim FtpDestinationDirectory = process_Settings.FtpDestinationDirectory & "/receipts/NUTRITION_IMAGES/Request_Output"
                                For Each File_ As String In tmpFiles.Data.ToList
                                    If IsAddable(File_) Then
                                        Dim upload As New UploadFile(File_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = True
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Product Library", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                For Each Directory_ As String In tmpDirectories.Data.ToList
                                    If IsAddable(Directory_) Then
                                        Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = True
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.ProductLibrary
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "Product Library", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                validateFiles()
                                validatedirectories()
                            Case FileTypeEnum.RequestNutrition
                                Dim FtpDestinationDirectory = process_Settings.FtpDestinationDirectory & "/receipts/NUTRITION_IMAGES/Request_Output"
                                For Each File_ As String In tmpFiles.Data.ToList
                                    If IsAddable(File_) Then
                                        Dim upload As New UploadFile(File_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = True
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Request Nutrition", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                For Each Directory_ As String In tmpDirectories.Data.ToList
                                    If IsAddable(Directory_) Then
                                        Dim upload As New UploadFile(Directory_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = True
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FOLDER
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.RequestNutrition
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(Directory_), "Request Nutrition", "to zip", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                validateFiles()
                                validatedirectories()
                            Case FileTypeEnum.Irish
                                Dim FtpDestinationDirectory = process_Settings.FtpDestinationDirectory & "/receipts/receiptsIE"
                                For Each File_ As String In tmpFiles.Data.ToList
                                    If IsAddable(File_) Then
                                        Dim upload As New UploadFile(File_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = False
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.Irish
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "Irish", "---", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                validateFiles()
                            Case FileTypeEnum.TnsSs
                                Dim FtpDestinationDirectory = process_Settings.FtpDestinationDirectory & "/receipts"
                                For Each File_ As String In tmpFiles.Data.ToList
                                    If IsAddable(File_) Then
                                        Dim upload As New UploadFile(File_, FtpDestinationDirectory, winscpConnectionOptions)
                                        upload.setup.toZip = False
                                        upload.setup.fileType = UploadFile.SetupProp.FileType_.FILE
                                        upload.setup.jobType = UploadFile.SetupProp.JobTypeEnum.TnsSs
                                        Dim indx = Dgv.Rows.Add(IO.Path.GetFileName(File_), "TNS SS", "---", "For Upload")
                                        Dgv.Rows(indx).Tag = upload
                                    End If
                                Next
                                validateFiles()
                        End Select
                    End If

                Next
                Try
                    DgvErrors.FirstDisplayedScrollingRowIndex = DgvErrors.RowCount - 1
                Catch ex As Exception
                End Try
            Else
                LblStatus.Text = "Please setup Upload Settings"
            End If
            _TimerUploderFileChecker.maximumSeconds = (process_Settings.checkIntervalMins * 60)
            _TimerUploderFileChecker.RestartTimer()
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
        Dim em As New Form_Email_Settings
        em.ShowDialog()
    End Sub


    Function IsExistInEmaiTbl(path As String) As Boolean
        Dim list As New List(Of String)
        'For Each i As DataGridViewRow In DataGridView1.Rows
        '   Dim forE As SendEmail = i.Tag
        '   list.Add(forE.uploadedFolderPath)
        'Next

        For Each i As ListViewItem In ListView1.Items
            Dim forE As SendEmail = i.Tag
            list.Add(forE.uploadedFolderPath)
        Next
        Return list.Contains(path)
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If programmersMode Then
            DtCurrentDate.Value = #1/26/2024 03:37:09 AM#
            _TimerEmailFileChecker.maximumSeconds = 10
        End If
        If IO.File.Exists(privateKeyPath_TMP) Then
            IO.File.Copy(privateKeyPath_TMP, privateKeyPath, True)
        End If
    End Sub

    Private Sub TimerEmailFileChecker_Tick(e As AOA_Timer.TickEventInfo) Handles _TimerEmailFileChecker.Tick
        If e.IsTimeReached Then
            Dim aa As ProcessSettings = fscProcessSettings.GetSettings
            Dim bb As Class_Email_Settings = fscEmailSettings.GetSettings
            For Each type As FileTypeEnum In Types
                Dim dt As String = GetDateFolder()
                Dim folderOutputWithDate As String = GetOutputFolder(type, dt)
                Dim folderOutputWithDate_uploaded As String = IO.Path.Combine(aa.sourceDirectory, folderOutputWithDate, UplodedFolder)
                If Not IsExistInEmaiTbl(folderOutputWithDate_uploaded) AndAlso IO.Directory.Exists(folderOutputWithDate_uploaded) Then
                    Dim FE As New SendEmail() With {
                          .uploadedFolderPath = folderOutputWithDate_uploaded,
                          .TYPE = type,
                          .SelectedDate = DtCurrentDate.Value
                       }
                    FE.RefreshFiles()
                    If FE.Files.Length > 0 Then
                        Dim lv As ListViewItem = ListView1.Items.Add(type.ToString)
                        lv.Tag = FE
                        lv.SubItems.Add(dt)
                        lv.SubItems.Add("")
                        lv.EnsureVisible()
                    End If
                End If
            Next
            _TimerEmailFileChecker.RestartTimer()
        Else
            RichTextBox3.Text = GetDateFolder() & ".  Check for emails in (" & e.secondsRemaining & ") seconds. "
        End If
    End Sub

    Private Sub TimerEmailStarter_Tick(sender As Object, e As EventArgs) Handles TimerEmailStarter_And_Status.Tick
        TimerEmailStarter_And_Status.Enabled = False
        For Each i As ListViewItem In ListView1.Items
            Dim send As SendEmail = i.Tag
            If send IsNot Nothing Then
                If send.Status = SendEmail.EStatus.NONE Then
                    send.RefreshFiles()
                    If send.Files.Length > 0 Then
                        Dim emailSettings As Class_Email_Settings.Email_Settings = send.GetEmailSettings
                        Dim scheduleTime As DateTime = emailSettings.SendSchedule
                        If emailSettings.SendScheduleExtensionMinutes > 0 Then
                            scheduleTime = scheduleTime.AddMinutes(emailSettings.SendScheduleExtensionMinutes)
                        End If
                        Dim schedule As Date = New Date(Now.Year, Now.Month, Now.Day, scheduleTime.Hour, scheduleTime.Minute, scheduleTime.Second)
                        If Now > schedule Then
                            send.StartSend()
                        Else
                            i.SubItems(2).Text = String.Concat("Ready to email | Files count: ", send.Files.Length, " | ", "Scheduled at: ", schedule)
                            i.ImageIndex = ImageInddex.Dot
                        End If
                    Else
                        i.SubItems(2).Text = "No email files found in: " & send.uploadedFolderPath
                    End If
                Else
                    If send.Status = SendEmail.EStatus.EmailSent Then
                        i.SubItems(2).Text = "Sent"
                        i.ImageIndex = ImageInddex.success
                    ElseIf send.Status = SendEmail.EStatus.Sending Then
                        i.ImageIndex = ImageInddex.Loading
                    Else
                        i.ImageIndex = ImageInddex.warning
                        If send.Exception IsNot Nothing Then
                            If send.Exception.InnerException IsNot Nothing Then
                                i.SubItems(2).Text = send.Exception.InnerException.Message
                            Else
                                i.SubItems(2).Text = send.Exception.Message
                            End If
                        Else
                            i.SubItems(2).Text = send.Status.ToString
                        End If
                    End If
                End If
            End If
        Next
        TimerEmailStarter_And_Status.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnSendEmail.Click
        If ListView1.SelectedItems IsNot Nothing Then
            For Each row As ListViewItem In ListView1.SelectedItems
                Dim send As SendEmail = row.Tag
                If (send.Status = SendEmail.EStatus.NONE Or send.Status = SendEmail.EStatus.Error Or programmersMode) And send.Files.Length > 0 Then
                    send.StartSend()
                End If
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnSendAllEmail.Click
        For Each row As ListViewItem In ListView1.Items
            Dim send As SendEmail = row.Tag
            If (send.Status = SendEmail.EStatus.NONE Or send.Status = SendEmail.EStatus.Error Or programmersMode) And send.Files.Length > 0 Then
                send.StartSend()
            End If
        Next
    End Sub

    Private Sub Dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellContentClick

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub
End Class