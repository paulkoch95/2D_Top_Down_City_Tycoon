Public Class IngameUI
    Public gr As Graphics
    Public tileMap As Bitmap = My.Resources.tilemap
    Public Sub draw(ByVal g As Graphics, ByVal start As Point, ByVal index As Integer)
        gr = g

        With g
            '.DrawString("Inventory", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Blue, start)
            .DrawImage(tileMap, start.X, start.Y + 22, New Rectangle(0, 3 * 32, 8 * 32, 32), GraphicsUnit.Pixel)
            .DrawString(index.ToString, New System.Drawing.Font("Segoe UI Light", 12), Brushes.Blue, start)
            .DrawRectangle(Pens.Black, New Rectangle(New Point(start.X + index * 64, start.Y - 64), New Size(64, 64)))
        End With

    End Sub
    Public Sub Control(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.A
                MsgBox("Hi")
        End Select
    End Sub
End Class
