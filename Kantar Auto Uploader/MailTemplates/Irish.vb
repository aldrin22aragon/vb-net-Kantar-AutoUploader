Imports System.Net.Mail
Public Class Irish
   Shared Function MailMessage(em As Class_Email_Settings.Email_Settings, files As String(), dt As String) As MailMessage

      Dim res As New MailMessage() With {
          .From = New MailAddress(em.Username),
          .Subject = em.Subject,
          .Body = em.Body
      }
      res.IsBodyHtml = True
      Dim Tmp_body As String = em.Body
      Tmp_body = Tmp_body.Replace(vbLf, "</br>")
      Tmp_body = Tmp_body.Replace(AttachmentValue, "
         <table>
            <thead>
               <tr>
                     <th>Output Filename</th> 
                     <th>Counts</th>
                     <th>File Size</th>
               </tr>
            </thead>
            <tbody>
               <tr>
                     <td>&nbsp</td>
                     <td>&nbsp</td>
                     <td>&nbsp</td>
               </tr>
               {filesTobePlaced}
               <!-- Add more rows as needed -->
            </tbody>
         </table>
      ")
      Dim attach As String = ""
      Dim total As Integer = 0
      For Each i As String In files
         Dim fsc As New FileSettingsCreator2(Of UploadFile.ForEmail)(i, New UploadFile.ForEmail)
         Dim aa As UploadFile.ForEmail = fsc.GetSettings
         Dim cnt As Integer = IIf(aa.ZipFile_FilesCount > 0, aa.ZipFile_FilesCount, aa.FileRecordCount)
         If attach = "" Then
            attach = "
                <tr>
                     <td>" & aa.FileName & "</td>
                     <td>" & cnt & "</td>
                     <td>" & Val(aa.FileSize).ToString("#,##0") & "</td>
               </tr>
            "
         Else
            attach &= "
                <tr>
                     <td>" & aa.FileName & "</td>
                     <td>" & cnt & "</td>
                     <td>" & Val(aa.FileSize).ToString("#,##0") & "</td>
               </tr>
            "
         End If
         total += cnt
      Next
      attach &= "
         <tr>
            <th>&nbsp</th>
            <th>&nbsp</th>
            <th>&nbsp</th>
         </tr>
         <tr>
            <td>Total Records</td>
            <td>" & total & "</td>
            <td></td>
         </tr>
      "
      Tmp_body = Tmp_body.Replace("{filesTobePlaced}", attach)
      res.Body = "
         <!DOCTYPE html>
         <html lang='en'>
         <head>
             <meta charset='UTF-8'>
             <meta name='viewport' content='width=device-width, initial-scale=1.0'>
             <title>Three Column Table</title>
             <style>
                 table {
                     border-collapse: collapse;
                     font-size: 12px;
                     border: 1px solid black;
                     table-layout: auto; /* Set table layout to auto */
                     border-spacing: 0; /* Remove empty spaces between cells */
                 }
                 th, td {
                     border: 1px solid black;
                     padding: 1px;
                     text-align: left;
                     white-space: nowrap; /* Prevent wrapping of text */
                 }
             </style>
         </head>
         <body>
             " & Tmp_body & "             
         </body>
         </html>

      "
      If em.IsTestIndicator Then
         res.To.Add(em.TestIndicatorEmailReceiver)
      Else
         For Each t As String In em.To_
            res.To.Add(t)
         Next
         For Each t As String In em.CC
            res.CC.Add(t)
         Next
         For Each t As String In em.BCC
            res.Bcc.Add(t)
         Next
      End If
      Return res
   End Function
End Class
