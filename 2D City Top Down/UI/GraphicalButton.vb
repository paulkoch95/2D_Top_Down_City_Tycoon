Public Class GraphicalButton
    Public srcImage As Image
    Public excerpt As Rectangle
    Public position As Point
    Public id As Byte
    Public Sub New(ByVal srcImg As Image, ByVal pos As Point, ByVal excerpt As Rectangle, ByVal id As Byte)
        Me.srcImage = srcImg
        position = pos
        Me.excerpt = excerpt
        Me.id = id
    End Sub
    Public Sub draw(ByVal g As Graphics)
        With g
            .DrawImage(srcImage, position.X, position.Y, excerpt, GraphicsUnit.Pixel)
            '.FillRectangle(color, rect)
            '.DrawString(content, New System.Drawing.Font("Segoe UI Light", 20), Brushes.Black, New Point(rect.X, rect.Y))
        End With
    End Sub
End Class
