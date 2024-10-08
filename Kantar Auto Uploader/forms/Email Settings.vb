﻿Imports System.Net.Mail

Public Class Form_Email_Settings

   Private Sub Email_Settings_Class_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim aa = fscEmailSettings.GetSettings
      If aa IsNot Nothing Then
         ComboboxTypes = aa
      Else
         ComboboxTypes = New Class_Email_Settings
      End If
      CmbType.SelectedIndex = 0
   End Sub

   Property ComboboxTypes As Class_Email_Settings
      Get
         If CmbType.Items.Count > 0 Then
            Dim res As New Class_Email_Settings
            For Each i As Object In CmbType.Items
               Dim c As Class_Email_Settings.Email_Settings = i
               Select Case c.Email_Type
                  Case Class_Email_Settings.Email_Settings.Types.BABY_FOOD
                     res.BABY_FOOD = c
                  Case Class_Email_Settings.Email_Settings.Types.BRANDBANK
                     res.BRANDBANK = c
                  Case Class_Email_Settings.Email_Settings.Types.IRISH
                     res.IRISH = c
                  Case Class_Email_Settings.Email_Settings.Types.PRODUCT_LIBRARY
                     res.PRODUCT_LIBRARY = c
                  Case Class_Email_Settings.Email_Settings.Types.REQUEST_NUTRITION
                     res.REQUEST_NUTRITION = c
                  Case Class_Email_Settings.Email_Settings.Types.TNS_SS
                     res.TNS_SS = c
               End Select
            Next
            Return res
         Else
            Return Nothing
         End If
      End Get
      Set(value As Class_Email_Settings)
         If value IsNot Nothing Then
            'clear
            CmbType.Items.Clear()
            CbCopyFrom.Items.Clear()
            CbCopyFrom.Items.Add("Copy From")
            '
            CmbType.Items.Add(value.BABY_FOOD)
            CmbType.Items.Add(value.BRANDBANK)
            CmbType.Items.Add(value.IRISH)
            CmbType.Items.Add(value.PRODUCT_LIBRARY)
            CmbType.Items.Add(value.REQUEST_NUTRITION)
            CmbType.Items.Add(value.TNS_SS)
            '
            CbCopyFrom.Items.Add(value.BABY_FOOD)
            CbCopyFrom.Items.Add(value.BRANDBANK)
            CbCopyFrom.Items.Add(value.IRISH)
            CbCopyFrom.Items.Add(value.PRODUCT_LIBRARY)
            CbCopyFrom.Items.Add(value.REQUEST_NUTRITION)
            CbCopyFrom.Items.Add(value.TNS_SS)
            '
            CbCopyFrom.SelectedIndex = 0
            CmbType.SelectedIndex = 0
         End If
      End Set
   End Property

   Private Sub CtTo__KeyKeyUp(sender As Object, e As KeyEventArgs) Handles CtTo._KeyKeyDown
      If e.KeyCode = Keys.Enter Then
         Dim vl As String = CtTo._TextBox.Text.Trim
         If IsValidEmaila(vl) Then
            Dim r = AddEmailToListBox(CtTo._TextBox, LbTo)
            If r <> "" Then
               MyMessageBox.ErrMsg(r)
            End If
         Else
            MyMessageBox.ErrMsg("Please check invalid email.")
         End If
      End If
   End Sub
   Function AddEmailToListBox(email As TextBox, lb As ListBox) As String
      Dim res As String = ""
      If lb.Items.Contains(email.Text.Trim) Then
         res = "Email is already added"
      Else
         lb.Items.Add(email.Text.Trim)
      End If
      email.Text = ""
      BtnSave.Enabled = True
      Return res
   End Function

   Function IsValidEmaila(email As String) As Boolean
      Try
         Dim a As New Net.Mail.MailAddress(email)
         Return True
      Catch ex As Exception
         Return False
      End Try
   End Function

   Private Sub CtCC__KeyKeyUp(sender As Object, e As KeyEventArgs) Handles CtCC._KeyKeyDown
      If e.KeyCode = Keys.Enter Then
         Dim vl As String = CtCC._TextBox.Text.Trim
         If IsValidEmaila(vl) Then
            Dim r = AddEmailToListBox(CtCC._TextBox, LbCC)
            If r <> "" Then
               MyMessageBox.ErrMsg(r)
            End If
         Else
            MyMessageBox.ErrMsg("Please check invalid email.")
         End If
      End If
   End Sub

   Private Sub CtBCC__KeyKeyUp(sender As Object, e As KeyEventArgs) Handles CtBCC._KeyKeyDown
      If e.KeyCode = Keys.Enter Then
         Dim vl As String = CtBCC._TextBox.Text.Trim
         If IsValidEmaila(vl) Then
            Dim r = AddEmailToListBox(CtBCC._TextBox, LbBCC)
            If r <> "" Then
               MyMessageBox.ErrMsg(r)
            End If
         Else
            MyMessageBox.ErrMsg("Please check invalid email.")
         End If
      End If
   End Sub

   Private Sub LbTo_DoubleClick(sender As Object, e As EventArgs) Handles LbTo.DoubleClick, LbCC.DoubleClick, LbBCC.DoubleClick
      Dim lb As ListBox = sender
      If lb.SelectedItem IsNot Nothing Then
         Dim sel As String = lb.SelectedItem.ToString
         lb.Items.Remove(sel)
      End If
      BtnSave.Enabled = True
   End Sub

   Private Sub CmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbType.SelectedIndexChanged
      If CmbType.SelectedItem IsNot Nothing Then
         Dim aa As Class_Email_Settings.Email_Settings = CmbType.SelectedItem
         FormSetingValues = aa
         BtnSave.Enabled = False
      End If
   End Sub

   Property FormSetingValues As Class_Email_Settings.Email_Settings
      Get
         Dim getEmails = Function(lb As ListBox) As String()
                            Dim res As New List(Of String)
                            For Each i As Object In lb.Items
                               res.Add(i.ToString)
                            Next
                            Return res.ToArray
                         End Function
         If CmbType.SelectedItem IsNot Nothing Then
            Dim res As Class_Email_Settings.Email_Settings = CmbType.SelectedItem
            res.BCC = getEmails(LbBCC)
            res.Body = RichTextBox1.Text
            res.CC = getEmails(LbCC)
            res.Email_Type = res.Email_Type
            res.Host = CtHost._TextBoxValue
            res.Name = res.Name
            res.Password = CtPassword._TextBoxValue
            res.Port = CtPort._TextBoxValue
            res.Subject = CtSubject._TextBoxValue
            res.To_ = getEmails(LbTo)
            res.Username = CtUsername._TextBoxValue
            res.IsTestIndicator = CheckBox1.Checked
            res.TestIndicatorEmailReceiver = Costum_Textbox1._TextBoxValue
            res.SendSchedule = DateTimePicker1.Value
            res.SendScheduleExtensionMinutes = Val(TextBox1.Text)
            res.EnableSSL = ChkEnableSSL.Checked
            Return res
         Else
            Throw New Exception("NO selected type in Combobox")
         End If
      End Get
      Set(value As Class_Email_Settings.Email_Settings)
         If CmbType.SelectedItem IsNot Nothing Then
            Dim setEmails = Sub(lb As ListBox, lists As String())
                               lb.Items.Clear()
                               For Each i As String In lists
                                  lb.Items.Add(i)
                               Next
                            End Sub
            setEmails(LbBCC, value.BCC)
            setEmails(LbCC, value.CC)
            RichTextBox1.Text = value.Body
            value.Email_Type = value.Email_Type ' no changes
            CtHost._TextBoxValue = value.Host
            value.Name = value.Name ' no changes
            CtPassword._TextBoxValue = value.Password
            CtPort._TextBoxValue = value.Port
            CtSubject._TextBoxValue = value.Subject
            setEmails(LbTo, value.To_)
            CtUsername._TextBoxValue = value.Username
            CheckBox1.Checked = value.IsTestIndicator
            Costum_Textbox1._TextBoxValue = value.TestIndicatorEmailReceiver
            ChkEnableSSL.Checked = value.EnableSSL
            Try
               DateTimePicker1.Value = value.SendSchedule
            Catch ex As Exception
               DateTimePicker1.Value = Class_Email_Settings.Email_Settings.defaultDate
            End Try
            TextBox1.Text = value.SendScheduleExtensionMinutes
         Else
            Throw New Exception("NO selected type in Combobox")
         End If
      End Set
   End Property

   Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
      If CmbType.SelectedItem IsNot Nothing Then
         CmbType.SelectedItem = FormSetingValues
         fscEmailSettings.SetSettings(ComboboxTypes)
         MyMessageBox.SuccessMsg("Saved")
         BtnSave.Enabled = False
      Else
         MyMessageBox.ErrMsg("No Selected Types")
      End If
   End Sub

   Private Sub CtHost__KeyPress(sender As Object, e As KeyPressEventArgs) Handles CtUsername._KeyPress, CtSubject._KeyPress, CtPort._KeyPress, CtPassword._KeyPress, CtHost._KeyPress, RichTextBox1.KeyPress, Costum_Textbox1._KeyPress
      BtnSave.Enabled = True
   End Sub

   Private Sub CbCopyFrom_SelectedValueChanged(sender As Object, e As EventArgs) Handles CbCopyFrom.SelectedValueChanged
      If CbCopyFrom.SelectedItem IsNot Nothing Then
         Dim a As Class_Email_Settings.Email_Settings = Nothing
         Try
            a = CbCopyFrom.SelectedItem
         Catch ex As Exception
         End Try
         If a IsNot Nothing Then
            CtHost._TextBoxValue = a.Host
            CtPort._TextBoxValue = a.Port
            CtUsername._TextBoxValue = a.Username
            CtPassword._TextBoxValue = a.Password
            BtnSave.Enabled = True
         End If
      End If
   End Sub

   Private Sub BtnSave_EnabledChanged(sender As Object, e As EventArgs) Handles BtnSave.EnabledChanged
      If BtnSave.Enabled Then
         BtnSave.BackColor = Color.LightCoral
         BtnSave.Text = "Save ...."
      Else
         BtnSave.BackColor = Color.LightGreen
         BtnSave.Text = "Saved"
      End If
   End Sub

   Private Sub BtnTestSendToSelf_Click(sender As Object, e As EventArgs) Handles BtnTestSendToSelf.Click
      Me.Enabled = False
      LabelInformation.Text = "Sending...."
      Dim aa = FormSetingValues
      Dim props As New SendEmail.Credentials With {
         .Host = aa.Host,
         .Port = aa.Port,
         ._Password = aa.Password,
         ._UserName = aa.Username,
         .EnableSsl = aa.EnableSSL
      }
      Dim exeName As String = System.Reflection.Assembly.GetExecutingAssembly.GetName.Name
      Dim message As New MailMessage() With {
         .From = New MailAddress(aa.Username),
         .Subject = "Test send email to self",
         .IsBodyHtml = True,
         .Body = "Test Email. " & exeName
      }
      message.To.Add(aa.Username)
      Dim email As New SendEmail With {
         .EmailCredentials = props,
         .MailMessageProperty = message,
         .TYPE = FileTypeEnum.NONE
      }
      email.StartSend()
      While (email.Status <> SendEmail.EStatus.Error) And (email.Status <> SendEmail.EStatus.EmailSent)
         Threading.Thread.Sleep(200)
         Application.DoEvents()
      End While
      Me.Enabled = True
      LabelInformation.Text = "Info"
      If email.Status = SendEmail.EStatus.EmailSent Then
         MyMessageBox.SuccessMsg("Test success.")
      ElseIf email.Status = SendEmail.EStatus.Error Then
         ErrorLogsCreator.CreateLog(ErrorLogsCreator.LogFor.SendTestToSelf, email.Exception, "Send test to self")
         Dim innerMessage As String = ""
         If email.Exception.InnerException IsNot Nothing Then innerMessage = email.Exception.InnerException.Message
         MyMessageBox.ErrMsg(email.Exception.Message & vbNewLine & innerMessage)
      Else
         MyMessageBox.ErrMsg("Unknown error. Please try again.")
      End If
   End Sub

   Private Sub RichTextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyUp
      If e.KeyCode = Keys.K And e.Control Then
         Dim prev As String = Clipboard.GetText
         Clipboard.SetText(AttachmentValue)
         RichTextBox1.Paste()
         Clipboard.SetText(prev)
      End If
   End Sub

   Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
      If CheckBox1.Checked Then
         Costum_Textbox1.Visible = True
      Else
         Costum_Textbox1.Visible = False
      End If
      BtnSave.Enabled = True
   End Sub

   Private Sub CtSubject__KeyKeyUp(sender As Object, e As KeyEventArgs) Handles CtSubject._KeyKeyUp
      If e.KeyCode = Keys.D And e.Control Then
         Dim prev As String = Clipboard.GetText
         Clipboard.SetText(DateAttachment)
         CtSubject._TextBox.Paste()
         Clipboard.SetText(prev)
      End If
   End Sub

   Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
      Me.Close()
   End Sub

   Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged, TextBox1.TextChanged
      BtnSave.Enabled = True
   End Sub

   Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
      Dim chr As String = e.KeyChar.ToString
      If Not ("1234567890" & vbBack).Contains(chr) Then
         e.Handled = True
      End If
   End Sub

   Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
      Select Case e.KeyCode
         Case Keys.Up
            TextBox1.Text = Val(TextBox1.Text) + 1
         Case Keys.Down
            If Val(TextBox1.Text) > 0 Then
               TextBox1.Text = Val(TextBox1.Text) - 1
            End If
      End Select
   End Sub
   Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEnableSSL.CheckedChanged
      BtnSave.Enabled = True
   End Sub

   Private Sub CtPassword__KeyKeyDown(sender As Object, e As KeyEventArgs) Handles CtPassword._KeyKeyDown
      If e.Control And e.KeyCode = Keys.P Then
         If CtPassword._PasswordCharacter = Nothing Then
            CtPassword._PasswordCharacter = "*"
         Else
            CtPassword._PasswordCharacter = Nothing
         End If
      End If
   End Sub
End Class