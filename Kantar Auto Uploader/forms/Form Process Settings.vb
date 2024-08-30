Imports WinSCP
Public Class Form_Process_Settings
   Private sessionOptions As SessionOptions = Nothing
   Public returnValueProcessSettings As ProcessSettings = Nothing
   Sub New(_sesOptions As SessionOptions, _processSett As ProcessSettings)
      ' This call is required by the designer.
      InitializeComponent()
      sessionOptions = _sesOptions
      returnValueProcessSettings = _processSett
      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Private Sub Form_Process_Settings_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      FormValue = returnValueProcessSettings
   End Sub

   Property FormValue As ProcessSettings
      Get
         Return New ProcessSettings() With {
            .FtpDestinationDirectory = TxDestionationFolderFTP.Text,
            .sourceDirectory = TxSourceLocal.Text,
            .checkIntervalMins = NCheckInterval.Value,
            .simultaneousUpload = NumSimultaneousUpload.Value
         }
      End Get
      Set(value As ProcessSettings)
         If value IsNot Nothing Then
            TxDestionationFolderFTP.Text = value.FtpDestinationDirectory
            TxSourceLocal.Text = value.sourceDirectory
            NCheckInterval.Value = value.checkIntervalMins
            NumSimultaneousUpload.Value = value.simultaneousUpload
         Else
            TxDestionationFolderFTP.Text = ""
            TxSourceLocal.Text = ""
            NCheckInterval.Value = 1
            NumSimultaneousUpload.Value = 1
         End If

      End Set
   End Property

    Private Sub TxSourceLocal_Click(sender As Object, e As EventArgs) Handles TxSourceLocal.Click
        Dim fl As New MyFolderBrowser(TxSourceLocal.Text)
        If fl.ShowDialog = DialogResult.OK Then
            TxSourceLocal.Text = fl.SelectedPath
        End If
    End Sub

    Private Sub TxDestionationFolderFTP_Click(sender As Object, e As EventArgs) Handles TxDestionationFolderFTP.Click
      Dim startPath As String = IIf(TxDestionationFolderFTP.Text <> "", TxDestionationFolderFTP.Text, "/")
      Dim ftpB As New FtpBrowser(sessionOptions, FtpBrowser.Mode_.folder, startPath)
      If ftpB.ShowDialog = DialogResult.OK Then
         TxDestionationFolderFTP.Text = ftpB.ReturnString
      End If
   End Sub

   Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
      returnValueProcessSettings = FormValue
      DialogResult = DialogResult.OK
   End Sub

   Private Sub Form_Process_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

   End Sub
End Class