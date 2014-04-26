Public Class Industry
    Dim rand As System.Random = New System.Random
    Public pos As New Point
    Public price As Integer = 750
    Public power As Integer = rand.Next(1, 3) 'The same as inhabitants in the class 'House' but power represenst the state of "Developement" of the current indsutry building
End Class
