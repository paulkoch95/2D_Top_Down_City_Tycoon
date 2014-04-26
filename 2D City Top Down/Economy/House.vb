Public Class House
    Dim rand As System.Random = New System.Random

    Public pos As New Point
    Public price As Integer = 500
    Public inhabitants As Integer = rand.Next(1, 5)
End Class
