Imports System.Net.Mail
Public Class SendEmail
   Friend Property TYPE As FileTypeEnum = FileTypeEnum.NONE
   Public uploadedFolderPath As String = ""
   Private settings As Class_Email_Settings = Nothing
   Public SelectedDate As DateTime = Nothing
   '
   Dim th As Threading.Thread
   '
   Public EmailCredentials As Credentials = Nothing
   Public MailMessageProperty As MailMessage = Nothing
   '
   Property Status As EStatus = EStatus.NONE
   Property Exception As Exception = Nothing
   '
   Public currentEmail_Settings As Class_Email_Settings.Email_Settings = Nothing
   '
   Sub StartSend()
      settings = fscEmailSettings.GetSettings
      th = New System.Threading.Thread(AddressOf RunThread)
      th.Start()
      Status = EStatus.Running
   End Sub

   Function SetupCredentials_and_MailMessage(em As Class_Email_Settings.Email_Settings) As Credentials
      Return New Credentials With {
         .DeliveryFormat = SmtpDeliveryFormat.SevenBit,
         .EnableSsl = False,
         .Host = em.Host,
         .Port = em.Port,
         ._Domain = "",
         ._Password = em.Password,
         ._UserName = em.Username
      }
   End Function

   Sub SetupCredetialsAndMailMessage()
      Dim dt As String = Format(SelectedDate, "(MM.dd.yy)")
      Select Case TYPE
         Case FileTypeEnum.BabyFood
            EmailCredentials = SetupCredentials_and_MailMessage(settings.BABY_FOOD)
            MailMessageProperty = BabyFood.MailMessage(settings.BABY_FOOD, Files, dt)
            currentEmail_Settings = settings.BABY_FOOD
         Case FileTypeEnum.BrandBank
            EmailCredentials = SetupCredentials_and_MailMessage(settings.BRANDBANK)
            MailMessageProperty = Brandbank.MailMessage(settings.BRANDBANK, Files, dt)
            currentEmail_Settings = settings.BRANDBANK
         Case FileTypeEnum.Irish
            EmailCredentials = SetupCredentials_and_MailMessage(settings.IRISH)
            MailMessageProperty = Irish.MailMessage(settings.IRISH, Files, dt)
            currentEmail_Settings = settings.IRISH
         Case FileTypeEnum.ProductLibrary
            EmailCredentials = SetupCredentials_and_MailMessage(settings.PRODUCT_LIBRARY)
            MailMessageProperty = ProductLibrary.MailMessage(settings.PRODUCT_LIBRARY, Files, dt)
            currentEmail_Settings = settings.PRODUCT_LIBRARY
         Case FileTypeEnum.RequestNutrition
            EmailCredentials = SetupCredentials_and_MailMessage(settings.REQUEST_NUTRITION)
            MailMessageProperty = RequestNutrition.MailMessage(settings.REQUEST_NUTRITION, Files, dt)
            currentEmail_Settings = settings.REQUEST_NUTRITION
         Case FileTypeEnum.TnsSs
            EmailCredentials = SetupCredentials_and_MailMessage(settings.TNS_SS)
            MailMessageProperty = TN_SS.MailMessage(settings.TNS_SS, Files, dt)
            currentEmail_Settings = settings.TNS_SS
      End Select
   End Sub
   Private Sub RunThread()
      Try
         SetupCredetialsAndMailMessage()
         Status = EStatus.SettingUpCredentials
         Dim client As New SmtpClient() With {
            .Host = EmailCredentials.Host,
            .Port = EmailCredentials.Port,
            .DeliveryFormat = EmailCredentials.DeliveryFormat, ' default SmtpDeliveryFormat.International
            .EnableSsl = EmailCredentials.EnableSsl ' default  false
         }
         client.Credentials = New Net.NetworkCredential() With {
            .UserName = EmailCredentials._UserName, 'email
            .Password = EmailCredentials._Password,
            .Domain = EmailCredentials._Domain 'default blank
         }
         Try
            Status = EStatus.Sending
            client.Send(MailMessageProperty)
            If TYPE <> FileTypeEnum.NONE Then '  kapag none kase ginagamit lang sya for test send
               If currentEmail_Settings.IsTestIndicator Then
                  'just dont move th files
               Else
                  For Each file As String In Files ' make sure na ang Files ay di ginagamit as attachement kase mag error once move
                     Dim emailedPath As String = IO.Path.Combine(uploadedFolderPath, EmailedStr)
                     If Not IO.Directory.Exists(emailedPath) Then IO.Directory.CreateDirectory(emailedPath)
                     Dim dest As String = IO.Path.Combine(emailedPath, IO.Path.GetFileName(file))
                     My.Computer.FileSystem.MoveFile(file, dest)
                  Next
               End If
            End If
            Status = EStatus.EmailSent
         Catch ex As Exception
            Exception = ex
            Status = EStatus.Error
         Finally
            MailMessageProperty.Attachments.Dispose()
            If MailMessageProperty.Attachments.Count > 0 Then MailMessageProperty.Attachments.Clear()
            MailMessageProperty.Dispose()
            client.Dispose()
            GC.Collect()
            GC.WaitForPendingFinalizers()
         End Try
      Catch ex As Exception
         Exception = ex
         Status = EStatus.Error
      End Try

   End Sub
   Public Property Files As String()
   Public Sub RefreshFiles()
      Try
         Files = IO.Directory.GetFiles(uploadedFolderPath, "*.foremail")
      Catch ex As Exception
         Files = {}
      End Try
   End Sub

   Class Credentials
      Public Host As String = ""
      Public Port As String = ""
      ''' <summary>
      ''' default is SevenBit
      ''' </summary>
      Public DeliveryFormat As SmtpDeliveryFormat = SmtpDeliveryFormat.SevenBit
      ''' <summary>
      ''' default is false
      ''' </summary>
      Public EnableSsl As Boolean = False '
      Public _UserName As String = ""
      Public _Password As String = ""
      ''' <summary>
      ''' Defaul Blank
      ''' </summary>
      Public _Domain As String = ""
   End Class

   Enum EStatus As Integer
      NONE = 0
      Running = 1
      Sending = 2
      EmailSent = 3
      [Error] = 4
      SettingUpCredentials = 5
   End Enum

End Class
