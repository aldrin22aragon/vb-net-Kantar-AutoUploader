<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Process_Settings
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
        Me.TxSourceLocal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxDestionationFolderFTP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NCheckInterval = New System.Windows.Forms.NumericUpDown()
        Me.NumSimultaneousUpload = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.NCheckInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumSimultaneousUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxSourceLocal
        '
        Me.TxSourceLocal.Location = New System.Drawing.Point(101, 17)
        Me.TxSourceLocal.Name = "TxSourceLocal"
        Me.TxSourceLocal.ReadOnly = True
        Me.TxSourceLocal.Size = New System.Drawing.Size(230, 22)
        Me.TxSourceLocal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Local source"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(435, 96)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "FTP Destination"
        '
        'TxDestionationFolderFTP
        '
        Me.TxDestionationFolderFTP.Location = New System.Drawing.Point(101, 48)
        Me.TxDestionationFolderFTP.Name = "TxDestionationFolderFTP"
        Me.TxDestionationFolderFTP.ReadOnly = True
        Me.TxDestionationFolderFTP.Size = New System.Drawing.Size(409, 22)
        Me.TxDestionationFolderFTP.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(347, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Check Interval Mins"
        '
        'NCheckInterval
        '
        Me.NCheckInterval.Location = New System.Drawing.Point(456, 17)
        Me.NCheckInterval.Name = "NCheckInterval"
        Me.NCheckInterval.Size = New System.Drawing.Size(54, 22)
        Me.NCheckInterval.TabIndex = 6
        '
        'NumSimultaneousUpload
        '
        Me.NumSimultaneousUpload.Location = New System.Drawing.Point(220, 75)
        Me.NumSimultaneousUpload.Name = "NumSimultaneousUpload"
        Me.NumSimultaneousUpload.Size = New System.Drawing.Size(54, 22)
        Me.NumSimultaneousUpload.TabIndex = 8
        Me.NumSimultaneousUpload.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(98, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Simultaneous Upload"
        '
        'Form_Process_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 131)
        Me.Controls.Add(Me.NumSimultaneousUpload)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NCheckInterval)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxDestionationFolderFTP)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxSourceLocal)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Process_Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process_Settings"
        CType(Me.NCheckInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumSimultaneousUpload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxSourceLocal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnSave As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TxDestionationFolderFTP As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NCheckInterval As NumericUpDown
    Friend WithEvents NumSimultaneousUpload As NumericUpDown
    Friend WithEvents Label4 As Label
End Class
