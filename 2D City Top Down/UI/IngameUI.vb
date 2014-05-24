Public Class IngameUI
    Public gr As Graphics
    Public tileMap As Bitmap = My.Resources.tilemap
    Public menu_bg As Image = My.Resources.menubg
    Public money_bg As Image = My.Resources.money_
    Public cal_bg As Image = My.Resources.cal_
    Public pop_bg As Image = My.Resources.population_
    Public selection_bg As Image = My.Resources.tilebar
    Public selection_tile As Image = My.Resources.tileselection
    Public selectionWidth As Integer = 64
    Public helper As New UIHelper
    Public mainMenueSelectedIndex = 0
    Public mainbuttons As New List(Of Button)
    Public pausebuttons As New List(Of Button)
    Public mouseClicked As Boolean = False
    Public drawDebug As Boolean = True
    Public debugCore As New DebugCore
    Public Sub setup()
        mainbuttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 50, 150, 40), Brushes.White, "New Game"))
        mainbuttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 100, 150, 40), Brushes.White, "Options"))
        mainbuttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 150, 150, 40), Brushes.White, "Exit"))

        pausebuttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 50, 150, 40), Brushes.White, "Resume"))
        pausebuttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 100, 150, 40), Brushes.White, "Load/Save"))
        pausebuttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 150, 150, 40), Brushes.White, "Back to Menu"))
    End Sub
    Public Sub drawGame(ByVal g As Graphics, ByVal start As Point, ByVal index As Integer, ByVal tileSize As Integer)

        With gr
            .DrawImageUnscaledAndClipped(selection_bg, New Rectangle(0, start.Y - 80, 983, 175))
            .DrawImage(tileMap, start.X, start.Y + 22, New Rectangle(0, 3 * tileSize, 8 * tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImageUnscaledAndClipped(selection_tile, New Rectangle(start.X + index * selectionWidth - 3, start.Y - selectionWidth - 3, 70, 70))
            .DrawImage(tileMap, start.X, start.Y - selectionWidth, New Rectangle(11 * tileSize, 0, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawString(Main.IndexToString(Main.selectedIndex), New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(start.X + Main.selectedIndex * selectionWidth, start.Y))
            .DrawString("Cost: " + Main.economy.IndexToPrice(Main.selectedIndex).ToString, New System.Drawing.Font("Segoe UI Light", 10), Brushes.White, New Point(start.X + Main.selectedIndex * selectionWidth, start.Y - selectionWidth / 2))
            .DrawImage(tileMap, start.X + selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 2 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 2 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 4 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 3 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 5 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 4 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 1 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 5 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 6 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 6 * selectionWidth, start.Y - selectionWidth, New Rectangle(13 * tileSize, 1 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)

            .DrawImageUnscaledAndClipped(money_bg, New Rectangle(120, 0, 152, 60))
            .DrawString("Money", New System.Drawing.Font("Segoe UI Light", 8), Brushes.DarkGray, New Point(170, 12))
            .DrawString(Main.economy.money.ToString, New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(170, 22))

            .DrawImageUnscaledAndClipped(pop_bg, New Rectangle(272, 0, 152, 60))
            .DrawString("Population", New System.Drawing.Font("Segoe UI Light", 8), Brushes.DarkGray, New Point(322, 12))
            .DrawString(Main.economy.population.ToString, New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(322, 22))

            .DrawImageUnscaledAndClipped(cal_bg, New Rectangle(424, 0, 152, 60))
            .DrawString("Date", New System.Drawing.Font("Segoe UI Light", 8), Brushes.DarkGray, New Point(474, 12))
            .DrawString(Main.yearCylce.yearString, New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(474, 22))
        End With
        
    End Sub
    Public Sub drawMainMenue()
        mouseClicked = False
        With gr
            .FillRectangle(Brushes.LightGray, New Rectangle(0, 0, Main.Width, Main.Height))
            .DrawImageUnscaledAndClipped(menu_bg, New Rectangle(50, 0, 400, 660))
            .DrawString("Main Menue", New System.Drawing.Font("Segoe UI Light", 24), Brushes.White, New Point(Main.Width / 2 - 50, 10))
            .DrawString("Developed by Paul Koch and all Github contributors! | Some images are mady by Jannis Becker | Version: " + Main.ProductVersion.ToString, New System.Drawing.Font("Segoe UI Light", 6), Brushes.Black, New Point(Main.Width - 400, 0))
            For Each b As Button In mainbuttons
                b.draw(gr)
            Next
        End With
    End Sub
    Public Sub drawPauseMenue()
        mouseClicked = False
        With gr
            .FillRectangle(New SolidBrush(Color.FromArgb(90, 127, 127, 127)), New Rectangle(0, 0, Main.Width, Main.Height))
            .DrawString("Pause Menue", New System.Drawing.Font("Segoe UI Light", 24), Brushes.White, New Point(Main.Width / 2 - 50, 10))
            For Each b As Button In pausebuttons
                b.draw(gr)
            Next
        End With
    End Sub
    Public Sub Mouse(ByVal e As System.Windows.Forms.MouseEventArgs)

        'MsgBox(buttons.Count.ToString)
        If Main.sceneManager.mainMenue = True Then 'Haupt Menü BUtton Hovering
            If helper.ButtonHovered(e.Location, mainbuttons.First.rect) Then
                mainbuttons(0).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Main.sceneManager.setGame()
                End If
            ElseIf helper.ButtonHovered(e.Location, mainbuttons(1).rect) Then
                mainbuttons(1).color = Brushes.DarkGray

                If mouseClicked = True Then
                    'Optionen.Show()
                    MsgBox(" Used Cups of Coffee during programming: " + Main.usedCoffees.ToString)
                End If
            ElseIf helper.ButtonHovered(e.Location, mainbuttons(2).rect) Then
                mainbuttons(2).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Application.Exit()
                End If
            Else
                mainbuttons(0).color = Brushes.White
                mainbuttons(1).color = Brushes.White
                mainbuttons(2).color = Brushes.White
            End If
        ElseIf Main.sceneManager.pauseMenue = True Then 'Pause Menü BUtton Hovering
            If helper.ButtonHovered(e.Location, pausebuttons(0).rect) Then
                pausebuttons(0).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Main.sceneManager.setGame()
                End If
            ElseIf helper.ButtonHovered(e.Location, pausebuttons(1).rect) Then
                pausebuttons(1).color = Brushes.DarkGray
            ElseIf helper.ButtonHovered(e.Location, pausebuttons(2).rect) Then
                pausebuttons(2).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Main.sceneManager.setMainMenue()
                End If
            Else
                pausebuttons(0).color = Brushes.White
                pausebuttons(1).color = Brushes.White
                pausebuttons(2).color = Brushes.White
            End If
        End If


        Main.Text = mouseClicked.ToString
        mouseClicked = False
    End Sub
    Public Sub Control(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.D
                If drawDebug Then
                    drawDebug = False
                Else
                    drawDebug = True
                End If
        End Select
    End Sub
End Class
