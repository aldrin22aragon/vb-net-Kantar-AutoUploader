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
      Me.CmbType = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CtPassword = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.CtUsername = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.CtPort = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.CtHost = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LbBCC = New System.Windows.Forms.ListBox()
        Me.LbCC = New System.Windows.Forms.ListBox()
        Me.LbTo = New System.Windows.Forms.ListBox()
        Me.CtBCC = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.CtCC = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.CtTo = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.CtSubject = New Kantar_Auto_Uploader.Costum_Textbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.CbCopyFrom = New System.Windows.Forms.ComboBox()
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
        Me.Panel1.Controls.Add(Me.CtPassword)
        Me.Panel1.Controls.Add(Me.CtUsername)
        Me.Panel1.Controls.Add(Me.CtPort)
        Me.Panel1.Controls.Add(Me.CtHost)
        Me.Panel1.Location = New System.Drawing.Point(12, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(203, 164)
        Me.Panel1.TabIndex = 3
        '
        'CtPassword
        '
        Me.CtPassword._LabelText = "Password"
        Me.CtPassword._PanelColor = System.Drawing.Color.Transparent
        Me.CtPassword._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtPassword._TextBoxValue = ""
        Me.CtPassword.BackColor = System.Drawing.Color.Transparent
        Me.CtPassword.Location = New System.Drawing.Point(8, 111)
        Me.CtPassword.Name = "CtPassword"
        Me.CtPassword.Size = New System.Drawing.Size(185, 35)
        Me.CtPassword.TabIndex = 3
        '
        'CtUsername
        '
        Me.CtUsername._LabelText = "Username"
        Me.CtUsername._PanelColor = System.Drawing.Color.Transparent
        Me.CtUsername._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtUsername._TextBoxValue = ""
        Me.CtUsername.BackColor = System.Drawing.Color.Transparent
        Me.CtUsername.Location = New System.Drawing.Point(8, 76)
        Me.CtUsername.Name = "CtUsername"
        Me.CtUsername.Size = New System.Drawing.Size(185, 35)
        Me.CtUsername.TabIndex = 2
        '
        'CtPort
        '
        Me.CtPort._LabelText = "Port"
        Me.CtPort._PanelColor = System.Drawing.Color.Transparent
        Me.CtPort._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtPort._TextBoxValue = ""
        Me.CtPort.BackColor = System.Drawing.Color.Transparent
        Me.CtPort.Location = New System.Drawing.Point(8, 41)
        Me.CtPort.Name = "CtPort"
        Me.CtPort.Size = New System.Drawing.Size(185, 35)
        Me.CtPort.TabIndex = 1
        '
        'CtHost
        '
        Me.CtHost._LabelText = "Host"
        Me.CtHost._PanelColor = System.Drawing.Color.Transparent
        Me.CtHost._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtHost._TextBoxValue = ""
        Me.CtHost.BackColor = System.Drawing.Color.Transparent
        Me.CtHost.Location = New System.Drawing.Point(8, 6)
        Me.CtHost.Name = "CtHost"
        Me.CtHost.Size = New System.Drawing.Size(185, 35)
        Me.CtHost.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Thistle
        Me.Panel2.Controls.Add(Me.LbBCC)
        Me.Panel2.Controls.Add(Me.LbCC)
        Me.Panel2.Controls.Add(Me.LbTo)
        Me.Panel2.Controls.Add(Me.CtBCC)
        Me.Panel2.Controls.Add(Me.CtCC)
        Me.Panel2.Controls.Add(Me.CtTo)
        Me.Panel2.Controls.Add(Me.CtSubject)
        Me.Panel2.Location = New System.Drawing.Point(238, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(568, 164)
        Me.Panel2.TabIndex = 4
        '
        'LbBCC
        '
        Me.LbBCC.BackColor = System.Drawing.SystemColors.Control
        Me.LbBCC.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LbBCC.FormattingEnabled = True
        Me.LbBCC.Location = New System.Drawing.Point(381, 87)
        Me.LbBCC.Name = "LbBCC"
        Me.LbBCC.Size = New System.Drawing.Size(180, 69)
        Me.LbBCC.TabIndex = 10
        '
        'LbCC
        '
        Me.LbCC.BackColor = System.Drawing.SystemColors.Control
        Me.LbCC.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LbCC.FormattingEnabled = True
        Me.LbCC.Location = New System.Drawing.Point(195, 86)
        Me.LbCC.Name = "LbCC"
        Me.LbCC.Size = New System.Drawing.Size(180, 69)
        Me.LbCC.TabIndex = 9
        '
        'LbTo
        '
        Me.LbTo.BackColor = System.Drawing.SystemColors.Control
        Me.LbTo.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LbTo.FormattingEnabled = True
        Me.LbTo.Location = New System.Drawing.Point(8, 86)
        Me.LbTo.Name = "LbTo"
        Me.LbTo.Size = New System.Drawing.Size(180, 69)
        Me.LbTo.TabIndex = 8
        '
        'CtBCC
        '
        Me.CtBCC._LabelText = "BCC"
        Me.CtBCC._PanelColor = System.Drawing.Color.Transparent
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
        Me.CtSubject._LabelText = "Subject"
        Me.CtSubject._PanelColor = System.Drawing.Color.Transparent
        Me.CtSubject._TextboxFont = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtSubject._TextBoxValue = ""
        Me.CtSubject.BackColor = System.Drawing.Color.Transparent
        Me.CtSubject.Location = New System.Drawing.Point(8, 4)
        Me.CtSubject.Name = "CtSubject"
        Me.CtSubject.Size = New System.Drawing.Size(553, 35)
        Me.CtSubject.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 26)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Credentials"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Thistle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(238, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 26)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Email"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.LightGreen
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(559, 225)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(121, 23)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(687, 225)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(121, 23)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'CbCopyFrom
        '
        Me.CbCopyFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbCopyFrom.FormattingEnabled = True
        Me.CbCopyFrom.Location = New System.Drawing.Point(100, 29)
        Me.CbCopyFrom.Name = "CbCopyFrom"
        Me.CbCopyFrom.Size = New System.Drawing.Size(115, 21)
        Me.CbCopyFrom.TabIndex = 9
        '
        'Form_Email_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Info
        Me.ClientSize = New System.Drawing.Size(820, 256)
        Me.Controls.Add(Me.CbCopyFrom)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbType)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Email_Settings"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email_Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
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
End Class
