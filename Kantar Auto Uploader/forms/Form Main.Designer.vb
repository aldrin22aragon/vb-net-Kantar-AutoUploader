<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TbFtpSettings = New System.Windows.Forms.ToolStripButton()
        Me.TbUploadSettins = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.BtnRetry = New System.Windows.Forms.Button()
        Me.Dgv = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.DtCurrentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimerUploaderStarter = New System.Windows.Forms.Timer(Me.components)
        Me.TimerUploadStatus = New System.Windows.Forms.Timer(Me.components)
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ChkClearUploaded = New System.Windows.Forms.CheckBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TimerEmailStarter_And_Status = New System.Windows.Forms.Timer(Me.components)
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFtpSettings, Me.TbUploadSettins, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(835, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbFtpSettings
        '
        Me.TbFtpSettings.Image = CType(resources.GetObject("TbFtpSettings.Image"), System.Drawing.Image)
        Me.TbFtpSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFtpSettings.Name = "TbFtpSettings"
        Me.TbFtpSettings.Size = New System.Drawing.Size(91, 22)
        Me.TbFtpSettings.Text = "FTP Settings"
        '
        'TbUploadSettins
        '
        Me.TbUploadSettins.Image = CType(resources.GetObject("TbUploadSettins.Image"), System.Drawing.Image)
        Me.TbUploadSettins.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbUploadSettins.Name = "TbUploadSettins"
        Me.TbUploadSettins.Size = New System.Drawing.Size(110, 22)
        Me.TbUploadSettins.Text = "Upload Settings"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(101, 22)
        Me.ToolStripButton2.Text = "Email Settings"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButton1.Text = "Browse ftp"
        '
        'BtnRetry
        '
        Me.BtnRetry.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRetry.BackColor = System.Drawing.SystemColors.Info
        Me.BtnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRetry.Location = New System.Drawing.Point(748, 223)
        Me.BtnRetry.Name = "BtnRetry"
        Me.BtnRetry.Size = New System.Drawing.Size(75, 37)
        Me.BtnRetry.TabIndex = 3
        Me.BtnRetry.Text = "Re Upload"
        Me.BtnRetry.UseVisualStyleBackColor = False
        '
        'Dgv
        '
        Me.Dgv.AllowUserToAddRows = False
        Me.Dgv.AllowUserToDeleteRows = False
        Me.Dgv.AllowUserToResizeColumns = False
        Me.Dgv.AllowUserToResizeRows = False
        Me.Dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.Dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column2, Me.Column3})
        Me.Dgv.Location = New System.Drawing.Point(12, 63)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.ReadOnly = True
        Me.Dgv.RowHeadersVisible = False
        Me.Dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv.Size = New System.Drawing.Size(811, 153)
        Me.Dgv.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "File / Folder"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Type"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Zip Status"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Upload Status"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.LblStatus.Location = New System.Drawing.Point(12, 41)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(38, 13)
        Me.LblStatus.TabIndex = 5
        Me.LblStatus.Text = "Status"
        '
        'DtCurrentDate
        '
        Me.DtCurrentDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtCurrentDate.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtCurrentDate.Location = New System.Drawing.Point(502, 29)
        Me.DtCurrentDate.Name = "DtCurrentDate"
        Me.DtCurrentDate.Size = New System.Drawing.Size(321, 29)
        Me.DtCurrentDate.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(389, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Current Date:"
        '
        'TimerUploaderStarter
        '
        Me.TimerUploaderStarter.Interval = 1000
        '
        'TimerUploadStatus
        '
        Me.TimerUploadStatus.Interval = 1000
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Black
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 221)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(730, 40)
        Me.RichTextBox1.TabIndex = 10
        Me.RichTextBox1.Text = "Error Info:"
        '
        'ChkClearUploaded
        '
        Me.ChkClearUploaded.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkClearUploaded.AutoSize = True
        Me.ChkClearUploaded.Location = New System.Drawing.Point(552, 167)
        Me.ChkClearUploaded.Name = "ChkClearUploaded"
        Me.ChkClearUploaded.Size = New System.Drawing.Size(158, 17)
        Me.ChkClearUploaded.TabIndex = 11
        Me.ChkClearUploaded.Text = "Auto clear when uploaded"
        Me.ChkClearUploaded.UseVisualStyleBackColor = True
        Me.ChkClearUploaded.Visible = False
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.RichTextBox2.Location = New System.Drawing.Point(12, 264)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(811, 127)
        Me.RichTextBox2.TabIndex = 13
        Me.RichTextBox2.Text = ""
        Me.RichTextBox2.WordWrap = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ListView1)
        Me.Panel1.Location = New System.Drawing.Point(-13, 408)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1035, 250)
        Me.Panel1.TabIndex = 15
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(24, 5)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(811, 174)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 20
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Email"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Date"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Status"
        Me.ColumnHeader3.Width = 537
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "hourglass.png")
        Me.ImageList1.Images.SetKeyName(1, "warning.png")
        Me.ImageList1.Images.SetKeyName(2, "success-icon-7.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-upload-64.png")
        Me.ImageList1.Images.SetKeyName(4, "gmail.png")
        Me.ImageList1.Images.SetKeyName(5, "more.png")
        Me.ImageList1.Images.SetKeyName(6, "full-moon.png")
        Me.ImageList1.Images.SetKeyName(7, "dot.png")
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Info
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(748, 593)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 32)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Send all"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.Info
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(650, 593)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 32)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Send Email"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TimerEmailStarter_And_Status
        '
        Me.TimerEmailStarter_And_Status.Interval = 1000
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox3.ForeColor = System.Drawing.Color.Black
        Me.RichTextBox3.Location = New System.Drawing.Point(12, 592)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.ReadOnly = True
        Me.RichTextBox3.Size = New System.Drawing.Size(617, 37)
        Me.RichTextBox3.TabIndex = 19
        Me.RichTextBox3.Text = "Error Info:"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Location = New System.Drawing.Point(-13, 20)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1035, 382)
        Me.Panel2.TabIndex = 16
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(835, 633)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtnRetry)
        Me.Controls.Add(Me.Dgv)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ChkClearUploaded)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtCurrentDate)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kantar Auto Uploader - Auto Email"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
   Friend WithEvents TbUploadSettins As ToolStripButton
   Friend WithEvents BtnRetry As Button
   Friend WithEvents Dgv As DataGridView
   Friend WithEvents TbFtpSettings As ToolStripButton
   Friend WithEvents LblStatus As Label
   Friend WithEvents DtCurrentDate As DateTimePicker
   Friend WithEvents Label1 As Label
   Friend WithEvents TimerUploaderStarter As Timer
   Friend WithEvents TimerUploadStatus As Timer
   Friend WithEvents RichTextBox1 As RichTextBox
   Friend WithEvents ChkClearUploaded As CheckBox
   Friend WithEvents RichTextBox2 As RichTextBox
   Friend WithEvents ToolStripButton1 As ToolStripButton
   Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TimerEmailStarter_And_Status As Timer
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ImageList1 As ImageList
End Class
