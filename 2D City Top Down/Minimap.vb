Public Class Minimap
    Public minMapImage As Image = My.Resources.minimap
    Public large As Image = My.Resources.text_360
    Public Sub DrawMiniMap(ByVal g As Graphics, ByVal map(,) As Byte)
        g.DrawImageUnscaled(minMapImage, New Point(0, 0))
        g.DrawImageUnscaled(large, New Point(160, 0))
        For x As Integer = 0 To 50
            For y As Integer = 0 To 50
                With g
                    If map(x, y) >= 4 And map(x, y) <= 14 Then
                        .FillRectangle(Brushes.Blue, New Rectangle((x + 10) * 2, (y + 10) * 2, 2, 2))
                    ElseIf map(x, y) >= 16 And map(x, y) <= 17 Then
                        .FillRectangle(Brushes.Brown, New Rectangle((x + 10) * 2, (y + 10) * 2, 2, 2))
                    ElseIf map(x, y) >= 30 And map(x, y) <= 31 Then
                        .FillRectangle(Brushes.Yellow, New Rectangle((x + 10) * 2, (y + 10) * 2, 2, 2))
                    End If
                    .DrawRectangle(Pens.Black, New Rectangle(Main.xOffset * 2 + 10, Main.yOffset * 2 + 10, (Main.widthX - 1) * 2, (Main.heightY - 1) * 2))


                End With
            Next
        Next
    End Sub
End Class
