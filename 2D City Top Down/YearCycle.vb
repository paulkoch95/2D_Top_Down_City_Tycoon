Public Class YearCycle
    Public OneyearDuration As Integer = 360
    Public day As Integer = 0
    Public year As Integer = 0
    Public yearString As String = ""
    Public Sub evaluate()

        If day <= OneyearDuration Then
            day += 1
        End If
        If day > OneyearDuration Then
            day = 0
            year += 1
        End If
        yearString = day.ToString + ". day in year " + year.ToString
    End Sub
End Class
