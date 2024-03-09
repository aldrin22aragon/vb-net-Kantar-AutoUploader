Imports System.Net.Mail
Public Class SendEmail
   Dim th As Threading.Thread
   ReadOnly EmailProperty As Props = Nothing
   ReadOnly MailMessageProperty As MailMessage = Nothing
   Public Status As SendInfo
   Sub New(EmailProp As Props, Mail As MailMessage)
      Me.EmailProperty = EmailProp
      Me.MailMessageProperty = Mail
      Status = New SendInfo() With {
         .running = False,
         .success = False,
         ._error = False
      }
   End Sub

   Sub StartUpload()
      th = New System.Threading.Thread(AddressOf RunThread)
      th.Start()
   End Sub
   Private Sub RunThread()
      Dim client As New SmtpClient() With {
         .Host = EmailProperty.Host,
         .Port = EmailProperty.Port,
         .DeliveryFormat = EmailProperty.DeliveryFormat, ' default SmtpDeliveryFormat.International
         .EnableSsl = EmailProperty.EnableSsl ' default  false
      }
      client.Credentials = New Net.NetworkCredential() With {
         .UserName = EmailProperty._UserName, 'email
         .Password = EmailProperty._Password,
         .Domain = EmailProperty._Domain 'default blank
      }
      Try
         client.Send(MailMessageProperty)
      Catch ex As Exception

      Finally
         MailMessageProperty.Attachments.Dispose()
         MailMessageProperty.Attachments.Clear()
         MailMessageProperty.Dispose()
         client.Dispose()
         GC.Collect()
         GC.WaitForPendingFinalizers()
      End Try

   End Sub

   Class Props
      Public Host As String = ""
      Public Port As String = ""
      Public DeliveryFormat As SmtpDeliveryFormat = SmtpDeliveryFormat.SevenBit
      Public EnableSsl As Boolean = False
      Public _UserName As String = ""
      Public _Password As String = ""
      Public _Domain As String = ""
   End Class
   Class SendInfo
      Public running As Boolean = False
      Public success As Boolean = False
      Public message As String = ""
      Public _error As Boolean = False
      Public RetryCount As Integer = 0
      Public innextException As String = ""
      Public stackTrace As String = ""
   End Class
End Class
