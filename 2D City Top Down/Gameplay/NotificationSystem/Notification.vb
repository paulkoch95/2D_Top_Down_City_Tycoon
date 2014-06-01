Public Class Notification
    Public pos As Point
    Public content As String
    Public bg As Image = My.Resources.notification
    Public Sub draw(ByVal g As Graphics)
        With g
            .DrawImageUnscaledAndClipped(bg, New Rectangle(pos, New Size(150, 35)))
            .DrawString(content, New System.Drawing.Font("Segoe UI Light", 10), Brushes.White, New Point(pos.X + 30, pos.Y + 4))

        End With
    End Sub
End Class
