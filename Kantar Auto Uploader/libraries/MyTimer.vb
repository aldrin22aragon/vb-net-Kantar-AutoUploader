Public Class MyTimer
   Friend WithEvents Timer As New Timer
   Event Tick(e As TickEventInfo)
   Dim SW As New Stopwatch

   Public Property Enabled As Boolean = False
   Public Property IntervalSeconds As Integer = 30


   Sub StartTimer(Optional overWriteSeconds As Integer = 0)
      If overWriteSeconds > 0 Then IntervalSeconds = overWriteSeconds
      SW = New Stopwatch
      SW.Start()
      Timer.Start()
   End Sub
   Sub RestartTimer(Optional overWriteSeconds As Integer = 0)
      If overWriteSeconds > 0 Then IntervalSeconds = overWriteSeconds
      SW = New Stopwatch
      SW.Start()
      Timer.Start()
   End Sub
   Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
      If IsTimeReached() Then
         SW.Stop()
         Timer.Stop()
         RaiseEvent Tick(New TickEventInfo() With {
                    .IsTimeReached = True,
                    .Span = RemainingTime(),
                    .secondsRemaining = RemainingSeconds()
         })
      Else
         RaiseEvent Tick(New TickEventInfo() With {
                    .IsTimeReached = False,
                    .Span = RemainingTime(),
                    .secondsRemaining = RemainingSeconds()
         })
      End If
   End Sub

   Public Function IsTimeReached() As Boolean
      Return SW.Elapsed.TotalSeconds >= IntervalSeconds
   End Function
   Function RemainingTime() As TimeSpan
      Dim res As Integer = IntervalSeconds - SW.Elapsed.TotalSeconds
      Dim span As TimeSpan = TimeSpan.FromSeconds(res)
      Return span
   End Function
   Function RemainingSeconds() As Integer
      Return IntervalSeconds - SW.Elapsed.TotalSeconds
   End Function

   Class TickEventInfo
      Public IsTimeReached As Boolean
      Public secondsRemaining As Integer
      Public Span As TimeSpan
      Public debug As String
   End Class
End Class
