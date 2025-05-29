Public Class Exception_Viewer
    Dim rw As DataGridViewRow
    Private Sub Exception_Viewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each i As DataGridViewCell In rw.Cells
            If RichTextBox1.Text = "" Then
                RichTextBox1.Text = i.Value.ToString
                Continue For
            End If
            If i.Value IsNot Nothing Then
                RichTextBox1.Text = $"{RichTextBox1.Text}{vbNewLine & vbNewLine} {i.Value.ToString}"
            Else
                RichTextBox1.Text = $"{RichTextBox1.Text}{vbNewLine & vbNewLine} -------------"
            End If

        Next
        RichTextBox1.Text = $"{RichTextBox1.Text}{vbNewLine & vbNewLine}===Errors(s)======{vbNewLine & vbNewLine}"
        For Each i As DataGridViewCell In rw.Cells
            If i.Tag IsNot Nothing Then
                Dim ex As Exception = i.Tag
                RichTextBox1.Text = $"{RichTextBox1.Text}{vbNewLine & vbNewLine}Message: {ex.Message}"
                RichTextBox1.Text = $"{RichTextBox1.Text}{vbNewLine & vbNewLine}Mrace: {ex.StackTrace}"
            End If
        Next
    End Sub
    Sub New(dgvRow As DataGridViewRow)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        rw = dgvRow
    End Sub

    Private Sub Exception_Viewer_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class