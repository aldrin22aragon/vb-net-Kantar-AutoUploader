Public Class Email_Settings_Class
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
            Dim tmp As New List(Of Class_Email_Settings.Email_Settings)
            For Each i As Object In CmbType.Items
               Dim c As Class_Email_Settings.Email_Settings = i
               tmp.Add(c)
            Next
            res.AllSettings = tmp.ToArray
            Return res
         Else
            Return Nothing
         End If
      End Get
      Set(value As Class_Email_Settings)
         If value IsNot Nothing Then
            'clear
            CmbType.Items.Clear()
            '
            For Each i As Class_Email_Settings.Email_Settings In value.AllSettings
               CmbType.Items.Add(i)
            Next
         End If
      End Set
   End Property

   Private Sub CtTo__KeyKeyUp(sender As Object, e As KeyEventArgs) Handles CtTo._KeyKeyDown
      If e.KeyCode = Keys.Enter Then
         Dim vl As String = CtTo._TextBox.Text.Trim
         If IsValidEmaila(vl) Then
            Dim r = AddEmailToListBox(CtTo._TextBox, LbTo)
            If r <> "" Then
               ErrMsg(r)
            End If
         Else
            ErrMsg("Please check invalid email.")
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
               ErrMsg(r)
            End If
         Else
            ErrMsg("Please check invalid email.")
         End If
      End If
   End Sub

   Private Sub CtBCC__KeyKeyUp(sender As Object, e As KeyEventArgs) Handles CtBCC._KeyKeyDown
      If e.KeyCode = Keys.Enter Then
         Dim vl As String = CtBCC._TextBox.Text.Trim
         If IsValidEmaila(vl) Then
            Dim r = AddEmailToListBox(CtBCC._TextBox, LbBCC)
            If r <> "" Then
               ErrMsg(r)
            End If
         Else
            ErrMsg("Please check invalid email.")
         End If
      End If
   End Sub

   Private Sub LbTo_DoubleClick(sender As Object, e As EventArgs) Handles LbTo.DoubleClick, LbCC.DoubleClick, LbBCC.DoubleClick
      Dim lb As ListBox = sender
      If lb.SelectedItem IsNot Nothing Then
         Dim sel As String = lb.SelectedItem.ToString
         lb.Items.Remove(sel)
      End If
   End Sub

   Private Sub CmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbType.SelectedIndexChanged
      If CmbType.SelectedItem IsNot Nothing Then
         Dim aa As Class_Email_Settings.Email_Settings = CmbType.SelectedItem
         FormSettings = aa
      End If
   End Sub

   Property FormSettings As Class_Email_Settings.Email_Settings
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
            res.CC = getEmails(LbCC)
            res.Email_Type = res.Email_Type
            res.Host = CtHost._TextBoxValue
            res.Name = res.Name
            res.Password = CtPassword._TextBoxValue
            res.Port = CtPort._TextBoxValue
            res.Subject = CtSubject._TextBoxValue
            res.To_ = getEmails(LbTo)
            res.Username = CtUsername._TextBoxValue
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
            value.Email_Type = value.Email_Type ' no changes
            CtHost._TextBoxValue = value.Host
            value.Name = value.Name ' no changes
            CtPassword._TextBoxValue = value.Password
            CtPort._TextBoxValue = value.Port
            CtSubject._TextBoxValue = value.Subject
            setEmails(LbTo, value.To_)
            CtUsername._TextBoxValue = value.Username
         Else
            Throw New Exception("NO selected type in Combobox")
         End If
      End Set
   End Property

   Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
      If CmbType.SelectedItem IsNot Nothing Then
         CmbType.SelectedItem = FormSettings
         fscEmailSettings.SetSettings(ComboboxTypes)
         SuccessMsg("Saved")
      Else
         ErrMsg("No Selected Types")
      End If
   End Sub
End Class