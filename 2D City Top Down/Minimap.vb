Public Class Minimap
    Public Sub DrawMiniMap(ByVal g As Graphics, ByVal map(,) As Byte)
        For x As Integer = 0 To 50
            For y As Integer = 0 To 50
                With g
                    If map(x, y) >= 4 And map(x, y) <= 14 Then
                        .FillRectangle(Brushes.Black, New Rectangle(x, y, 1, 1))
                    ElseIf map(x, y) = Main.Blocks.Grass Then
                        .FillRectangle(Brushes.Blue, New Rectangle(x, y, 1, 1))
                    ElseIf map(x, y) >= 16 And map(x, y) <= 17 Then
                        .FillRectangle(Brushes.Brown, New Rectangle(x, y, 1, 1))
                    ElseIf map(x, y) >= 30 And map(x, y) <= 31 Then
                        .FillRectangle(Brushes.Yellow, New Rectangle(x, y, 1, 1))
                    End If
                    .DrawRectangle(Pens.Black, New Rectangle(Main.xOffset, Main.yOffset, Main.widthX - 1, Main.heightY - 1))


                End With
            Next
        Next
    End Sub
End Class
