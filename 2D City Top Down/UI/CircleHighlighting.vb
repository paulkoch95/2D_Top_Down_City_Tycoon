Public Class CircleHighlighting
    Public finalCircle As New List(Of Rectangle)
    Public Function fillCirc(ByVal radius As Integer, ByVal midpoint As Point) As List(Of Rectangle)
        finalCircle = New List(Of Rectangle)
        For y As Integer = -radius To y <= radius
            For x As Integer = -radius To x <= radius
                If x * x + y * y <= radius * radius Then
                    'Main.SetBrick(midPoint.X + x, midPoint.Y + y)
                    'Main.SetBrick(midPoint.X - x - 1, midPoint.Y + y)
                    'Main.SetBrick(midPoint.X + x, midPoint.Y - y - 1)
                    'Main.SetBrick(midPoint.X - x - 1, midPoint.Y - y - 1)
                    'Return Nothing
                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X + x, midPoint.Y + y, 1, 1))
                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X - x, midPoint.Y + y, 1, 1))
                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X + x, midPoint.Y - y, 1, 1))
                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X - x, midPoint.Y - y, 1, 1))
                    finalCircle.Add(New Rectangle(midpoint.X + x * 32, midpoint.Y + y * 32, 32, 32))
                    finalCircle.Add(New Rectangle(midpoint.X - x * 32 - 32, midpoint.Y + y * 32, 32, 32))
                    finalCircle.Add(New Rectangle(midpoint.X + x * 32, midpoint.Y - y * 32 - 32, 32, 32))
                    finalCircle.Add(New Rectangle(midpoint.X - x * 32 - 32, midpoint.Y - y * 32 - 32, 32, 32))

                End If
            Next
        Next
        Return finalCircle
    End Function
End Class
