Public Class Notification
    Public pos As Point
    Public content As String
    Public bg As Image = My.Resources.notification
    Public ID As Integer = 0
    Public d As Button
    Public help As New UIHelper
    Public Sub New(ByVal position As Point, ByVal text As String, ByVal ID As Integer)
        pos = position
        content = text
        Me.ID = ID
        d = New Button(New Rectangle(New Point(position.X - 32, position.Y), New Size(32, 32)), Brushes.Red, "X")
    End Sub
    Public Sub draw(ByVal g As Graphics)
        With g
            .DrawImageUnscaledAndClipped(bg, New Rectangle(pos, New Size(250, 60)))
            .DrawString(content, New System.Drawing.Font("Segoe UI Light", 10), Brushes.White, New Point(pos.X + 30, pos.Y + 4))

        End With
        d.draw(g)
        If help.ButtonHovered(Main.mousePos, d.rect) Then
            Me.d.color = Brushes.Black
        End If
    End Sub
End Class
