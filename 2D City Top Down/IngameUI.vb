Public Class IngameUI
    Public gr As Graphics
    Public tileMap As Bitmap = My.Resources.tilemap
    Public selectionWidth As Integer = 64

    Public Sub draw(ByVal g As Graphics, ByVal start As Point, ByVal index As Integer, ByVal tileSize As Integer)
        gr = g

        With g
            '.DrawString("Inventory", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Blue, start)
            .DrawImage(tileMap, start.X, start.Y + 22, New Rectangle(0, 3 * tileSize, 8 * tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawString(index.ToString, New System.Drawing.Font("Segoe UI Light", 12), Brushes.Blue, start)
            .DrawRectangle(Pens.Black, New Rectangle(New Point(start.X + index * selectionWidth, start.Y - selectionWidth), New Size(selectionWidth, selectionWidth)))
            .DrawImage(tileMap, start.X, start.Y - selectionWidth, New Rectangle(11 * tileSize, 0, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 2 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawString("Money: " + Main.economy.money.ToString, New System.Drawing.Font("Segoe UI Light", 15), Brushes.Yellow, New Point(10, 10))
        End With

    End Sub
    Public Sub Control(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.A
                MsgBox("Hi")
        End Select
    End Sub
End Class
