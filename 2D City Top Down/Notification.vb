
Public Class Notification
    Public pos As Point
    Public content As String
    Public opacity As Integer = 100
    Public notecolor As Color
    Public Sub draw(ByVal g As Graphics)
        With g
            .FillRectangle(New SolidBrush(Color.FromArgb(opacity, 0, 255, 0)), New Rectangle(New Point(pos.X - 20, pos.Y - 20), New Size(32, 32)))
            .DrawString(content, New System.Drawing.Font("Segoe UI Light", 12), New SolidBrush(Color.FromArgb(opacity, 0, 255, 0)), New Point(pos.X - 20, pos.Y - 20))
        End With
        Main.Invalidate(New Rectangle(pos, New Size(32, 32)))
    End Sub
    Public Sub setup(ByVal position As Point, ByVal text As String, ByVal newcolor As Color)
        pos = position
        content = text
        notecolor = newcolor
    End Sub
    Public Sub evaluate()
        If opacity >= 5 Then
            opacity -= 5
        End If


        Main.Invalidate(New Rectangle(pos.X - 32, pos.Y - 32, 128, 128))
    End Sub
End Class
