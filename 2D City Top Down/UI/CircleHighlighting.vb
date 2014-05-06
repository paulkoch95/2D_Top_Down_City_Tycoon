Public Class CircleHighlighting
    Public radius As Integer = 30
    Public midPoint As Point = New Point(50, 50)
    Public Sub fillCirc()
        'MsgBox("Filling")
        For y As Integer = -radius To y <= radius
            For x As Integer = -radius To x <= radius
                If x * x + y * y <= radius * radius Then
                    Main.SetBrick(midPoint.X + x, midPoint.Y + y)
                    Main.SetBrick(midPoint.X - x - 1, midPoint.Y + y)
                    Main.SetBrick(midPoint.X + x, midPoint.Y - y - 1)
                    Main.SetBrick(midPoint.X - x - 1, midPoint.Y - y - 1)

                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X + x, midPoint.Y + y, 1, 1))
                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X - x, midPoint.Y + y, 1, 1))
                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X + x, midPoint.Y - y, 1, 1))
                    'g.FillRectangle(Brushes.Black, New Rectangle(midPoint.X - x, midPoint.Y - y, 1, 1))
                End If
            Next
        Next
    End Sub
End Class
