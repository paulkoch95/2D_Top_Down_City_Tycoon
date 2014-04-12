Public Class Traffic

    Public cars As New List(Of Rectangle)
    Public carspeeds As New List(Of Point)
    Public Sub TrafficFlow()
        For i As Integer = 0 To cars.Count - 1
            Select Case Form1.GetBrick(cars(i).X, cars(i).Y)
                Case Form1.Blocks.StreetHorizontal
                    Speed(i, 1, 0)
                Case Form1.Blocks.Grass
                    Speed(i, 0, 0)
                Case Form1.Blocks.StreetVertical
                    Speed(i, 0, 1)
                Case Form1.Blocks.StreetDownLeft
                    Speed(i, 0, 0)
            End Select
        Next
        addingTraffic()
    End Sub
    Public Sub addingTraffic()
        For i As Integer = 0 To cars.Count - 1
            For j As Integer = 0 To carspeeds.Count - 1
                cars(i) = New Rectangle(cars(i).X + carspeeds(j).X, cars(i).Y + carspeeds(j).Y, 23, 23)
            Next
        Next
    End Sub
    Public Sub AddCar(ByVal x As Integer, ByVal Y As Integer, ByVal width As Integer, ByVal height As Integer)
        cars.Add(New Rectangle(x, Y, width, height))
        carspeeds.Add(New Point(0, 0))
    End Sub
    Public Sub Speed(ByVal index As Integer, ByVal x As Integer, ByVal y As Integer)
        carspeeds(index) = New Point(x, y)
    End Sub
End Class
