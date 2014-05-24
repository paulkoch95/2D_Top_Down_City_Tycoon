Public Class YearCycle
    Public OneyearDuration As Integer = 360
    Public months() As String = {"Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec"}
    Public day As Integer = 0
    Public year As Integer = 1980
    Public yearString As String = ""
    Public Sub evaluate()

        If day <= OneyearDuration Then
            day += 1
        End If
        If day > OneyearDuration Then
            day = 0
            year += 1
        End If
        yearString = (day Mod 30).ToString + ". " + months(Math.Floor(day / 30)) + " " + year.ToString("0000") 'TODO!
    End Sub
End Class
