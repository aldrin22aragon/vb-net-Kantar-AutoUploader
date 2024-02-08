<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.TbFtpSettings = New System.Windows.Forms.ToolStripButton()
      Me.TbUploadSettins = New System.Windows.Forms.ToolStripButton()
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
      Me.Button2 = New System.Windows.Forms.Button()
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
      Me.ChkClearUploaded = New System.Windows.Forms.CheckBox()
      Me.LblRunningStats = New System.Windows.Forms.Label()
      Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
      Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.Button3 = New System.Windows.Forms.Button()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStrip1.SuspendLayout()
      CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ToolStrip1
      '
      Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFtpSettings, Me.TbUploadSettins, Me.ToolStripButton2, Me.ToolStripButton1})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(718, 25)
      Me.ToolStrip1.TabIndex = 0
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'TbFtpSettings
      '
      Me.TbFtpSettings.Image = CType(resources.GetObject("TbFtpSettings.Image"), System.Drawing.Image)
      Me.TbFtpSettings.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.TbFtpSettings.Name = "TbFtpSettings"
      Me.TbFtpSettings.Size = New System.Drawing.Size(92, 22)
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
      'BtnRetry
      '
      Me.BtnRetry.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.BtnRetry.Location = New System.Drawing.Point(631, 228)
      Me.BtnRetry.Name = "BtnRetry"
      Me.BtnRetry.Size = New System.Drawing.Size(75, 23)
      Me.BtnRetry.TabIndex = 3
      Me.BtnRetry.Text = "Retry"
      Me.BtnRetry.UseVisualStyleBackColor = True
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
      Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.Dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column2, Me.Column3})
      Me.Dgv.Location = New System.Drawing.Point(12, 63)
      Me.Dgv.Name = "Dgv"
      Me.Dgv.ReadOnly = True
      Me.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.Dgv.Size = New System.Drawing.Size(694, 114)
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
      Me.LblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.LblStatus.AutoSize = True
      Me.LblStatus.Location = New System.Drawing.Point(12, 233)
      Me.LblStatus.Name = "LblStatus"
      Me.LblStatus.Size = New System.Drawing.Size(38, 13)
      Me.LblStatus.TabIndex = 5
      Me.LblStatus.Text = "Status"
      '
      'DtCurrentDate
      '
      Me.DtCurrentDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DtCurrentDate.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DtCurrentDate.Location = New System.Drawing.Point(438, 28)
      Me.DtCurrentDate.Name = "DtCurrentDate"
      Me.DtCurrentDate.Size = New System.Drawing.Size(268, 29)
      Me.DtCurrentDate.TabIndex = 7
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
      Me.Label1.Location = New System.Drawing.Point(325, 31)
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
      'Button2
      '
      Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button2.Location = New System.Drawing.Point(253, 226)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(196, 23)
      Me.Button2.TabIndex = 9
      Me.Button2.Text = "Ilabas yung mga na upload"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.RichTextBox1.Location = New System.Drawing.Point(12, 181)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.ReadOnly = True
      Me.RichTextBox1.Size = New System.Drawing.Size(694, 40)
      Me.RichTextBox1.TabIndex = 10
      Me.RichTextBox1.Text = ""
      '
      'ChkClearUploaded
      '
      Me.ChkClearUploaded.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ChkClearUploaded.AutoSize = True
      Me.ChkClearUploaded.Location = New System.Drawing.Point(467, 232)
      Me.ChkClearUploaded.Name = "ChkClearUploaded"
      Me.ChkClearUploaded.Size = New System.Drawing.Size(158, 17)
      Me.ChkClearUploaded.TabIndex = 11
      Me.ChkClearUploaded.Text = "Auto clear when uploaded"
      Me.ChkClearUploaded.UseVisualStyleBackColor = True
      '
      'LblRunningStats
      '
      Me.LblRunningStats.AutoSize = True
      Me.LblRunningStats.Location = New System.Drawing.Point(12, 35)
      Me.LblRunningStats.Name = "LblRunningStats"
      Me.LblRunningStats.Size = New System.Drawing.Size(38, 13)
      Me.LblRunningStats.TabIndex = 12
      Me.LblRunningStats.Text = "Status"
      '
      'RichTextBox2
      '
      Me.RichTextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.RichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.RichTextBox2.Font = New System.Drawing.Font("Courier Prime", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.RichTextBox2.Location = New System.Drawing.Point(12, 257)
      Me.RichTextBox2.Name = "RichTextBox2"
      Me.RichTextBox2.ReadOnly = True
      Me.RichTextBox2.Size = New System.Drawing.Size(694, 133)
      Me.RichTextBox2.TabIndex = 13
      Me.RichTextBox2.Text = ""
      Me.RichTextBox2.WordWrap = False
      '
      'ToolStripButton1
      '
      Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton1.Name = "ToolStripButton1"
      Me.ToolStripButton1.Size = New System.Drawing.Size(67, 22)
      Me.ToolStripButton1.Text = "Browse ftp"
      '
      'DataGridView1
      '
      Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(12, 409)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.Size = New System.Drawing.Size(694, 150)
      Me.DataGridView1.TabIndex = 14
      '
      'Button1
      '
      Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button1.Location = New System.Drawing.Point(631, 564)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 15
      Me.Button1.Text = "Retry"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'Button3
      '
      Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button3.Location = New System.Drawing.Point(550, 564)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(75, 23)
      Me.Button3.TabIndex = 16
      Me.Button3.Text = "Retry"
      Me.Button3.UseVisualStyleBackColor = True
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.BackColor = System.Drawing.Color.Crimson
      Me.Panel1.Location = New System.Drawing.Point(-5, 398)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(769, 5)
      Me.Panel1.TabIndex = 17
      '
      'ToolStripButton2
      '
      Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
      Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton2.Name = "ToolStripButton2"
      Me.ToolStripButton2.Size = New System.Drawing.Size(101, 22)
      Me.ToolStripButton2.Text = "Email Settings"
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(718, 595)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.Button3)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.RichTextBox2)
      Me.Controls.Add(Me.LblRunningStats)
      Me.Controls.Add(Me.ChkClearUploaded)
      Me.Controls.Add(Me.RichTextBox1)
      Me.Controls.Add(Me.Button2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.DtCurrentDate)
      Me.Controls.Add(Me.LblStatus)
      Me.Controls.Add(Me.Dgv)
      Me.Controls.Add(Me.BtnRetry)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "Form1"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Kantar Auto Uploader"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
   Friend WithEvents Column1 As DataGridViewTextBoxColumn
   Friend WithEvents Column4 As DataGridViewTextBoxColumn
   Friend WithEvents Column2 As DataGridViewTextBoxColumn
   Friend WithEvents Column3 As DataGridViewTextBoxColumn
   Friend WithEvents TimerUploaderStarter As Timer
   Friend WithEvents TimerUploadStatus As Timer
   Friend WithEvents Button2 As Button
   Friend WithEvents RichTextBox1 As RichTextBox
   Friend WithEvents ChkClearUploaded As CheckBox
   Friend WithEvents LblRunningStats As Label
   Friend WithEvents RichTextBox2 As RichTextBox
   Friend WithEvents ToolStripButton1 As ToolStripButton
   Friend WithEvents DataGridView1 As DataGridView
   Friend WithEvents Button1 As Button
   Friend WithEvents Button3 As Button
   Friend WithEvents Panel1 As Panel
   Friend WithEvents ToolStripButton2 As ToolStripButton
End Class
