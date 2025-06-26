Public Class Info
	Const info As String = "FTP Settings, about sa key file or PPK file, kapag yung error sa test connection ay may something (too new) ang ppk file, 
need natin mag generate ng bagong ppk gamit yung PuTTYgen app.
  1. open Putygen app at i load yung ppk file na for convert, 
  2. open 'key/parameters for saving key file', set the PPK file version to 2 then OK.
  3. then Save private key"
	Private Sub Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		RichTextBox1.Text = info
	End Sub
End Class