Imports WinSCP
Module Gloabals
   Public settingFolder As String = IO.Path.Combine(Application.StartupPath, "Settings")
   '
   ReadOnly fscSessionOptionsFilePath As String = IO.Path.Combine(settingFolder, "session-options.drihnz")
   ReadOnly fscProcessSettingsFilePath As String = IO.Path.Combine(settingFolder, "process-settings.drihnz")
   '
   Public fscSessionOptions As New FileSettingsCreator2(Of SessionOptions)(fscSessionOptionsFilePath, New SessionOptions)
   Public fscProcessSettings As New FileSettingsCreator2(Of ProcessSettings)(fscProcessSettingsFilePath, New ProcessSettings)

   Public programmersMode As Boolean = False
End Module
