<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Email_Settings
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Email_Settings))
      Me.CmbType = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.LabelInformation = New System.Windows.Forms.Label()
        Me.BtnTestSendToSelf = New System.Windows.Forms.Button()
        Me.CbCopyFrom = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.LbBCC = New System.Windows.Forms.ListBox()
        Me.LbCC = New System.Windows.Forms.ListBox()
        Me.LbTo = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Costum_Textbox1 = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtBCC = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtCC = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtTo = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtSubject = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtPassword = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtUsername = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtPort = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.CtHost = New Kantar_Auto_Uploader_And_Auto_Email.Costum_Textbox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbType
        '
        Me.CmbType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbType.Font = New System.Drawing.Font("Segoe UI Semibold", 16.25!, System.Drawing.FontStyle.Bold)
        Me.CmbType.FormattingEnabled = True
        Me.CmbType.Location = New System.Drawing.Point(530, 8)
        Me.CmbType.Name = "CmbType"
        Me.CmbType.Size = New System.Drawing.Size(278, 38)
        Me.CmbType.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(489, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel1.Controls.Add(Me.LabelInformation)
        Me.Panel1.Controls.Add(Me.CtPassword)
        Me.Panel1.Controls.Add(Me.BtnTestSendToSelf)
        Me.Panel1.Controls.Add(Me.CtUsername)
        Me.Panel1.Controls.Add(Me.CbCopyFrom)
        Me.Panel1.Controls.Add(Me.CtPort)
        Me.Panel1.Controls.Add(Me.CtHost)
        Me.Panel1.Location = New System.Drawing.Point(16, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(203, 270)
        Me.Panel1.TabIndex = 3
        '
        'LabelInformation
        '
        Me.LabelInformation.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.LabelInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelInformation.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelInformation.ForeColor = System.Drawing.Color.Black
        Me.LabelInformation.Location = New System.Drawing.Point(8, 185)
        Me.LabelInformation.Name = "LabelInformation"
        Me.LabelInformation.Padding = New System.Windows.Forms.Padding(3)
        Me.LabelInformation.Size = New System.Drawing.Size(185, 51)
        Me.LabelInformation.TabIndex = 11
        Me.LabelInformation.Text = "Info"
        Me.LabelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTestSendToSelf
        '
        Me.BtnTestSendToSelf.Location = New System.Drawing.Point(48, 239)
        Me.BtnTestSendToSelf.Name = "BtnTestSendToSelf"
        Me.BtnTestSendToSelf.Size = New System.Drawing.Size(145, 23)
        Me.BtnTestSendToSelf.TabIndex = 10
        Me.BtnTestSendToSelf.Text = "Test send email to self"
        Me.BtnTestSendToSelf.UseVisualStyleBackColor = True
        '
        'CbCopyFrom
        '
        Me.CbCopyFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbCopyFrom.FormattingEnabled = True
        Me.CbCopyFrom.Location = New System.Drawing.Point(78, 8)
        Me.CbCopyFrom.Name = "CbCopyFrom"
        Me.CbCopyFrom.Size = New System.Drawing.Size(115, 21)
        Me.CbCopyFrom.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Thistle
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.RichTextBox1)
        Me.Panel2.Controls.Add(Me.LbBCC)
        Me.Panel2.Controls.Add(Me.LbCC)
        Me.Panel2.Controls.Add(Me.LbTo)
        Me.Panel2.Controls.Add(Me.CtBCC)
        Me.Panel2.Controls.Add(Me.CtCC)
        Me.Panel2.Controls.Add(Me.CtTo)
        Me.Panel2.Controls.Add(Me.CtSubject)
        Me.Panel2.Location = New System.Drawing.Point(238, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(568, 391)
        Me.Panel2.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(500, 359)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 22)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Mins."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.Location = New System.Drawing.Point(436, 359)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(64, 22)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(315, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Extend Schedule For:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 365)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Schedule:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Body"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Checked = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(71, 356)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(117, 29)
        Me.DateTimePicker1.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(405, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Ctrl+k [to place attachments]"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(8, 156)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(553, 194)
        Me.RichTextBox1.TabIndex = 11
        Me.RichTextBox1.Text = ""
        '
        'LbBCC
        '
        Me.LbBCC.BackColor = System.Drawing.SystemColors.Control
        Me.LbBCC.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LbBCC.FormattingEnabled = True
        Me.LbBCC.Location = New System.Drawing.Point(381, 87)
        Me.LbBCC.Name = "LbBCC"
        Me.LbBCC.Size = New System.Drawing.Size(180, 43)
        Me.LbBCC.TabIndex = 10
        '
        'LbCC
        '
        Me.LbCC.BackColor = System.Drawing.SystemColors.Control
        Me.LbCC.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LbCC.FormattingEnabled = True
        Me.LbCC.Location = New System.Drawing.Point(195, 86)
        Me.LbCC.Name = "LbCC"
        Me.LbCC.Size = New System.Drawing.Size(180, 43)
        Me.LbCC.TabIndex = 9
        '
        'LbTo
        '
        Me.LbTo.BackColor = System.Drawing.SystemColors.Control
        Me.LbTo.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LbTo.FormattingEnabled = True
        Me.LbTo.Location = New System.Drawing.Point(8, 86)
        Me.LbTo.Name = "LbTo"
        Me.LbTo.Size = New System.Drawing.Size(180, 43)
        Me.LbTo.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 26)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Credentials"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Thistle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(238, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 26)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = " Email"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.LightGreen
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(687, 452)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(121, 31)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "Saved"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(560, 452)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(121, 31)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(16, 347)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(95, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Test Indicator"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Costum_Textbox1
        '
        Me.Costum_Textbox1._LabelText = "Specify email address to recieve"
        Me.Costum_Textbox1._PanelColor = System.Drawing.Color.Transparent
        Me.Costum_Textbox1._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Costum_Textbox1._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Costum_Textbox1._TextBoxValue = " "
        Me.Costum_Textbox1.BackColor = System.Drawing.Color.Transparent
        Me.Costum_Textbox1.Location = New System.Drawing.Point(16, 370)
        Me.Costum_Textbox1.Name = "Costum_Textbox1"
        Me.Costum_Textbox1.Size = New System.Drawing.Size(203, 35)
        Me.Costum_Textbox1.TabIndex = 10
        Me.Costum_Textbox1.Visible = False
        '
        'CtBCC
        '
        Me.CtBCC._LabelText = "BCC"
        Me.CtBCC._PanelColor = System.Drawing.Color.Transparent
        Me.CtBCC._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtBCC._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtBCC._TextBoxValue = ""
        Me.CtBCC.BackColor = System.Drawing.Color.Transparent
        Me.CtBCC.Location = New System.Drawing.Point(381, 45)
        Me.CtBCC.Name = "CtBCC"
        Me.CtBCC.Size = New System.Drawing.Size(180, 35)
        Me.CtBCC.TabIndex = 7
        '
        'CtCC
        '
        Me.CtCC._LabelText = "CC"
        Me.CtCC._PanelColor = System.Drawing.Color.Transparent
        Me.CtCC._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtCC._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtCC._TextBoxValue = ""
        Me.CtCC.BackColor = System.Drawing.Color.Transparent
        Me.CtCC.Location = New System.Drawing.Point(195, 45)
        Me.CtCC.Name = "CtCC"
        Me.CtCC.Size = New System.Drawing.Size(180, 35)
        Me.CtCC.TabIndex = 6
        '
        'CtTo
        '
        Me.CtTo._LabelText = "To"
        Me.CtTo._PanelColor = System.Drawing.Color.Transparent
        Me.CtTo._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtTo._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtTo._TextBoxValue = ""
        Me.CtTo.BackColor = System.Drawing.Color.Transparent
        Me.CtTo.Location = New System.Drawing.Point(8, 45)
        Me.CtTo.Name = "CtTo"
        Me.CtTo.Size = New System.Drawing.Size(180, 35)
        Me.CtTo.TabIndex = 5
        '
        'CtSubject
        '
        Me.CtSubject._LabelText = "Subject / Ctrl + D [to place date attachment]"
        Me.CtSubject._PanelColor = System.Drawing.Color.Transparent
        Me.CtSubject._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtSubject._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtSubject._TextBoxValue = ""
        Me.CtSubject.BackColor = System.Drawing.Color.Transparent
        Me.CtSubject.Location = New System.Drawing.Point(8, 4)
        Me.CtSubject.Name = "CtSubject"
        Me.CtSubject.Size = New System.Drawing.Size(553, 35)
        Me.CtSubject.TabIndex = 4
        '
        'CtPassword
        '
        Me.CtPassword._LabelText = "Password"
        Me.CtPassword._PanelColor = System.Drawing.Color.Transparent
        Me.CtPassword._PasswordCharacter = "*"
        Me.CtPassword._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtPassword._TextBoxValue = ""
        Me.CtPassword.BackColor = System.Drawing.Color.Transparent
        Me.CtPassword.Location = New System.Drawing.Point(8, 142)
        Me.CtPassword.Name = "CtPassword"
        Me.CtPassword.Size = New System.Drawing.Size(185, 35)
        Me.CtPassword.TabIndex = 3
        '
        'CtUsername
        '
        Me.CtUsername._LabelText = "Username"
        Me.CtUsername._PanelColor = System.Drawing.Color.Transparent
        Me.CtUsername._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtUsername._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtUsername._TextBoxValue = ""
        Me.CtUsername.BackColor = System.Drawing.Color.Transparent
        Me.CtUsername.Location = New System.Drawing.Point(8, 107)
        Me.CtUsername.Name = "CtUsername"
        Me.CtUsername.Size = New System.Drawing.Size(185, 35)
        Me.CtUsername.TabIndex = 2
        '
        'CtPort
        '
        Me.CtPort._LabelText = "Port"
        Me.CtPort._PanelColor = System.Drawing.Color.Transparent
        Me.CtPort._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtPort._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtPort._TextBoxValue = ""
        Me.CtPort.BackColor = System.Drawing.Color.Transparent
        Me.CtPort.Location = New System.Drawing.Point(8, 72)
        Me.CtPort.Name = "CtPort"
        Me.CtPort.Size = New System.Drawing.Size(185, 35)
        Me.CtPort.TabIndex = 1
        '
        'CtHost
        '
        Me.CtHost._LabelText = "Host"
        Me.CtHost._PanelColor = System.Drawing.Color.Transparent
        Me.CtHost._PasswordCharacter = "" & Global.Microsoft.VisualBasic.ChrW(0)
        Me.CtHost._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtHost._TextBoxValue = ""
        Me.CtHost.BackColor = System.Drawing.Color.Transparent
        Me.CtHost.Location = New System.Drawing.Point(8, 37)
        Me.CtHost.Name = "CtHost"
        Me.CtHost.Size = New System.Drawing.Size(185, 35)
        Me.CtHost.TabIndex = 0
        '
        'Form_Email_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(820, 492)
        Me.Controls.Add(Me.Costum_Textbox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbType)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Email_Settings"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email_Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmbType As ComboBox
   Friend WithEvents Label2 As Label
   Friend WithEvents Panel1 As Panel
   Friend WithEvents Panel2 As Panel
   Friend WithEvents Label1 As Label
   Friend WithEvents CtPassword As Costum_Textbox
   Friend WithEvents CtUsername As Costum_Textbox
   Friend WithEvents CtPort As Costum_Textbox
   Friend WithEvents CtHost As Costum_Textbox
   Friend WithEvents Label3 As Label
   Friend WithEvents CtSubject As Costum_Textbox
   Friend WithEvents CtTo As Costum_Textbox
   Friend WithEvents CtBCC As Costum_Textbox
   Friend WithEvents CtCC As Costum_Textbox
   Friend WithEvents LbBCC As ListBox
   Friend WithEvents LbCC As ListBox
   Friend WithEvents LbTo As ListBox
   Friend WithEvents BtnSave As Button
   Friend WithEvents BtnCancel As Button
   Friend WithEvents CbCopyFrom As ComboBox
    Friend WithEvents BtnTestSendToSelf As Button
    Friend WithEvents LabelInformation As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
   Friend WithEvents CheckBox1 As CheckBox
   Friend WithEvents Costum_Textbox1 As Costum_Textbox
    Friend WithEvents Label6 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
