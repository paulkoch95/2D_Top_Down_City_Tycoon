Public Class UpgradeTool
    Public enable As Boolean = False
    Public type As Byte
    Public pos As Point
    Public g As Graphics
    Public helper As New UIHelper
    Public currentButtons As New List(Of Button)
    Public Sub initiate(ByVal type As Byte, ByVal pos As Point)
        currentButtons = New List(Of Button)
        Me.type = type
        Me.pos = pos
        Select Case type
            Case 4 To 14
                currentButtons.Add(New Button(New Rectangle(New Point(pos.X, pos.Y), New Size(32, 32)), Brushes.Blue, "Exit"))
                currentButtons.Add(New Button(New Rectangle(New Point(pos.X + 32, pos.Y), New Size(32, 32)), Brushes.Blue, "Btn2"))
                currentButtons.Add(New Button(New Rectangle(New Point(pos.X + 64, pos.Y), New Size(32, 32)), Brushes.Blue, "Btn3"))
                currentButtons.Add(New Button(New Rectangle(New Point(pos.X + 96, pos.Y), New Size(32, 32)), Brushes.Blue, "Btn4"))
            Case Is <> 25
                currentButtons.Add(New Button(New Rectangle(New Point(pos.X, pos.Y), New Size(32, 32)), Brushes.Blue, "Exit"))
                'Exit Sub
        End Select
    End Sub
    Public Sub checkBtn(ByVal e As System.Windows.Forms.MouseEventArgs)
        If helper.ButtonHovered(e.Location, currentButtons.First.rect) Then
            currentButtons(0).color = Brushes.DarkGray
            If Main.UI.mouseClicked = True Then 'lazy as fuck....using useless object instantiation from other another class...bad style...but hey...who cares?
                enable = False
            End If
        Else
            currentButtons(0).color = Brushes.Blue
        End If
    End Sub
    Public Sub drawToUI(ByVal g As Graphics)
        Me.g = g
        Select Case enable
            Case True
                Select Case type
                    Case Is <> 0
                        renderUpdateContent()
                End Select
            Case False
                Main.Text = "exiting"
                Exit Sub
        End Select
    End Sub
    Public Sub renderUpdateContent()

        With g
            .FillRectangle(Brushes.Black, New Rectangle(New Point(pos.X - 2, pos.Y - 20), New Size(180, 64)))
            .DrawString("Upgrade UI | " + Main.ByteToString(type), New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(pos.X, pos.Y - 20))
            For Each b As Button In currentButtons
                b.draw(g)
            Next

        End With
    End Sub
End Class
