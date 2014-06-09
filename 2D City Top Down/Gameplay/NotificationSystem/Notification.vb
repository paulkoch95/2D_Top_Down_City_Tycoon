Public Class Notification
    Public pos As Point
    Public content As String
    Public bg As Image = My.Resources.notification
    Public ID As Integer = 0
    Public Sub New(ByVal position As Point, ByVal text As String, ByVal ID As Integer)
        pos = position
        content = text
        Me.ID = ID
    End Sub
    Public Sub draw(ByVal g As Graphics)
        With g
            .DrawImageUnscaledAndClipped(bg, New Rectangle(pos, New Size(250, 60)))
            .DrawString(content, New System.Drawing.Font("Segoe UI Light", 10), Brushes.White, New Point(pos.X + 30, pos.Y + 4))

        End With
    End Sub
End Class
