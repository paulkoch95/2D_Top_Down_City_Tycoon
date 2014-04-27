Public Class Button
    Public rect As Rectangle
    Public color As System.Drawing.Brush
    Public content As String
    Public Sub New(ByVal rectangle As Rectangle, ByVal col As System.Drawing.Brush, ByVal text As String)
        rect = rectangle
        color = col
        content = text
    End Sub
    Public Sub draw(ByVal g As Graphics)
        With g
            .FillRectangle(color, rect)
            .DrawString(content, New System.Drawing.Font("Segoe UI Light", 20), Brushes.Black, New Point(rect.X, rect.Y))
        End With
    End Sub
End Class
