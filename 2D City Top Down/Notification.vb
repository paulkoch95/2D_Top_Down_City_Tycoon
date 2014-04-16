Public Class Notification
    Public pos As Point
    Public content As String
    Public opacity As Integer = 100
    Public notecolor As Color
    Public Sub draw(ByVal g As Graphics)
        With g
            .FillRectangle(Brushes.Red, New Rectangle(New Point(pos.X - 20, pos.Y - 20), New Size(32, 32)))
            .DrawString(content, New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(pos.X - 20, pos.Y - 20))
        End With
        Main.Invalidate(New Rectangle(pos, New Size(32, 32)))
    End Sub
    Public Sub setup(ByVal position As Point, ByVal text As String, ByVal newcolor As Color)
        pos = position
        content = text
        notecolor = newcolor
    End Sub
    Public Sub evaluate()
        If opacity >= 3 Then
            opacity -= 1
        End If

    End Sub
End Class
