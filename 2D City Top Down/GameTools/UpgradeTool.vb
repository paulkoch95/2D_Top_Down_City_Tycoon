Public Class UpgradeTool
    Public enable As Boolean = False
    Public tilemap As Image = My.Resources.tilemap
    Public bg As Image = My.Resources.editbg
    Public selection_img As Image = My.Resources.editselection
    Public tilesize As Integer = 32
    Public type As Byte
    Public pos As Point
    Public buildPos As Point
    Public g As Graphics
    Public helper As New UIHelper
    Public currentButtons As New List(Of Button)
    Public currentImageButtons As New List(Of GraphicalButton)
    Public selectRect As New Rectangle
    Public Sub initiate(ByVal gettingType As Byte, ByVal getPos As Point)
        currentButtons = New List(Of Button)
        currentImageButtons = New List(Of GraphicalButton)
        type = gettingType
        buildPos = New Point(getPos.X + 128, getPos.Y + 128)
        pos = getPos

        'pos = New Point(pos.X, pos.Y - 40)
        Select Case type
            Case 4 To 14

                currentButtons.Add(New Button(New Rectangle(New Point(pos.X, pos.Y), New Size(32, 32)), Brushes.Red, "X"))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (1 * tilesize), pos.Y), New Rectangle(0, 0, tilesize, tilesize), 4))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (2 * tilesize), pos.Y), New Rectangle(1 * tilesize, 0, tilesize, tilesize), 5))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (3 * tilesize), pos.Y), New Rectangle(2 * tilesize, 0, tilesize, tilesize), 6))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (4 * tilesize), pos.Y), New Rectangle(3 * tilesize, 0, tilesize, tilesize), 7))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (5 * tilesize), pos.Y), New Rectangle(4 * tilesize, 0, tilesize, tilesize), 9))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (6 * tilesize), pos.Y), New Rectangle(5 * tilesize, 0, tilesize, tilesize), 8))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (7 * tilesize), pos.Y), New Rectangle(6 * tilesize, 0, tilesize, tilesize), 10))

                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (1 * tilesize), pos.Y + (tilesize)), New Rectangle(7 * tilesize, 0, tilesize, tilesize), 11))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (2 * tilesize), pos.Y + (tilesize)), New Rectangle(8 * tilesize, 0, tilesize, tilesize), 12))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (3 * tilesize), pos.Y + (tilesize)), New Rectangle(9 * tilesize, 0, tilesize, tilesize), 13))
                currentImageButtons.Add(New GraphicalButton(tilemap, New Point(pos.X + (4 * tilesize), pos.Y + (tilesize)), New Rectangle(10 * tilesize, 0, tilesize, tilesize), 14))
            Case Is <> 25
                currentButtons.Add(New Button(New Rectangle(New Point(pos.X, pos.Y), New Size(32, 32)), Brushes.Red, "X"))
                'Exit Sub
        End Select
    End Sub
    Public Sub checkBtn(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Main.UI.mouseClicked = True Then 'lazy as fuck....using useless object instantiation from other another class...bad style...but hey...who cares?
            enable = False
        End If
        For Each btn As Button In currentButtons
            If helper.ButtonHovered(e.Location, btn.rect) Then
                updateHighlighter(e.Location)
                btn.color = Brushes.DarkGray

            Else
                btn.color = Brushes.Red
            End If
        Next
        Select Case type
            Case 4 To 14
                For Each btn As GraphicalButton In currentImageButtons

                    If helper.ButtonHovered(e.Location, New Rectangle(btn.position, New Size(tilesize, tilesize))) Then
                        updateHighlighter(e.Location)
                        Main.Text = Main.ByteToString(btn.id)
                        Main.BuildBlock(buildPos.X, buildPos.Y, btn.id)
                        'If Windows.Forms.MouseButtons.Middle = True Then 'lazy as fuck....using useless object instantiation from other another class...bad style...but hey...who cares?
                        '    MsgBox(Main.ByteToString(btn.id))
                        '    Main.BuildBlock(pos.X, pos.Y, btn.id)
                        'End If
                    End If
                Next
        End Select

    End Sub
    Public Sub drawToUI(ByVal g As Graphics)
        Me.g = g
        Select Case enable
            Case True
                Select Case type
                    Case Is <> 0
                        Main.UI.mouseClicked = False
                        renderUpdateContent()
                End Select
            Case False
                Main.Text = "exiting"
                Exit Sub
        End Select
    End Sub
    Public Sub renderUpdateContent()

        With g
            .DrawImageUnscaledAndClipped(bg, New Rectangle(pos.X - 10, pos.Y - 25, 274, 149))
            '.FillRectangle(Brushes.Black, New Rectangle(New Point(pos.X - 2, pos.Y - 20), New Size(260, 104)))
            .DrawString("Change UI | " + Main.ByteToString(type), New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(pos.X, pos.Y - 20))
            For Each b As Button In currentButtons
                b.draw(g)
            Next
            For Each i As GraphicalButton In currentImageButtons
                i.draw(g)
            Next
            .DrawImageUnscaledAndClipped(selection_img, selectRect)
            '.DrawRectangle(Pens.White, selectRect)
        End With
    End Sub
    Public Sub updateHighlighter(ByVal pos As Point)
        selectRect = New Rectangle(Math.Floor(pos.X / 32) * 32, Math.Floor(pos.Y / 32) * 32, 32, 32)
    End Sub
End Class
