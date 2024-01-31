Imports WinSCP
Public Class Form1
   ' to zip
   '  Baby food
   '  Brandbank
   '  Product Library
   '  Request Nutrition
   ' as is
   '  Irish
   '  Tns SS

   Friend WithEvents Timer As New AOA_Timer(5, AOA_Timer.Mode_enum.PabalikBalik)

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

   Private Sub Timer_Tick(e As AOA_Timer.TickEventInfo) Handles Timer.Tick
      If e.IsTimeReached Then
         Dim s = fscProcessSettings.GetSettings
         If s IsNot Nothing AndAlso s.checkIntervalMins > 0 Then
            Timer.maximumSeconds = (s.checkIntervalMins * 60)
         End If
      Else
         LblStatus.Text = e.RemainingSeconds
      End If
   End Sub
End Class
