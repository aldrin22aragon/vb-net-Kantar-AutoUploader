Public Class Class_Email_Settings
   'Public AllSettings As Email_Settings() = {
   '         New Email_Settings(Email_Settings.Types.BABY_FOOD),
   '         New Email_Settings(Email_Settings.Types.BRANDBANK),
   '         New Email_Settings(Email_Settings.Types.IRISH),
   '         New Email_Settings(Email_Settings.Types.PRODUCT_LIBRARY),
   '         New Email_Settings(Email_Settings.Types.REQUEST_NUTRITION),
   '         New Email_Settings(Email_Settings.Types.TNS_SS)
   '      }

   Public BABY_FOOD As New Email_Settings(Email_Settings.Types.BABY_FOOD)
   Public BRANDBANK As New Email_Settings(Email_Settings.Types.BRANDBANK)
   Public IRISH As New Email_Settings(Email_Settings.Types.IRISH)
   Public PRODUCT_LIBRARY As New Email_Settings(Email_Settings.Types.PRODUCT_LIBRARY)
   Public REQUEST_NUTRITION As New Email_Settings(Email_Settings.Types.REQUEST_NUTRITION)
   Public TNS_SS As New Email_Settings(Email_Settings.Types.TNS_SS)

   '
   Public Class Email_Settings
      Public Name As String = ""
      Public Email_Type As Types = Types.NONE
      ' credentials
      Public Host As String = ""
      Public Port As String = ""
      Public Username As String = ""
      Public Password As String = ""
      ' email
      Public Subject As String = ""
      Public To_ As String() = {}
      Public CC As String() = {}
      Public BCC As String() = {}
      Public Body As String = ""
      '
      Public IsTestIndicator As Boolean = True
      Public TestIndicatorEmailReceiver As String = ""
      '
      Public Overrides Function ToString() As String
         Return Name
      End Function

      Sub New(type As Types)
         Email_Type = type
         Select Case Email_Type
            Case Types.BABY_FOOD
               Me.Name = "Baby food"
            Case Types.BRANDBANK
               Me.Name = "BrandBank"
            Case Types.IRISH
               Me.Name = "Irish"
            Case Types.PRODUCT_LIBRARY
               Me.Name = "Product Library"
            Case Types.REQUEST_NUTRITION
               Me.Name = "Request Nutrition"
            Case Types.TNS_SS
               Me.Name = "TNS SS"
         End Select
      End Sub

      Enum Types As Integer
         NONE = 0
         BABY_FOOD = 1
         BRANDBANK = 2
         IRISH = 3
         PRODUCT_LIBRARY = 4
         REQUEST_NUTRITION = 5
         TNS_SS = 6
      End Enum

   End Class
End Class
