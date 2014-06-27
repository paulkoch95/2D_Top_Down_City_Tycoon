Option Strict On

Imports System.IO

Public Class IngameUI
    Public gr As Graphics
    Public tileMap As Bitmap = My.Resources.tilemap
    Public menu_bg As Image = My.Resources.menubg
    Public money_bg As Image = My.Resources.money_
    Public cal_bg As Image = My.Resources.cal_
    Public pop_bg As Image = My.Resources.population_
    Public selection_bg As Image = My.Resources.tilebar
    Public selection_tile As Image = My.Resources.tileselection
    Public banner As Image = My.Resources.banner
    Public selectionWidth As Integer = 64
    Public helper As New UIHelper
    Public mainMenueSelectedIndex As Integer = 0
    Public mainbuttons As New List(Of Button)
    Public pausebuttons As New List(Of Button)
    Public savesButtons As New List(Of Button)
    Public mouseClicked As Boolean = False
    Public drawDebug As Boolean = False 'True
    Public debugCore As New DebugCore
    Public introBg As Double = 0
    Public introVis As Double = 255.0
    Public creditsYaw As Double = 0.0
    Public logo As Image = My.Resources.logo
    Public progress As Integer
    Public ls As New LoadSaveManager
    Public timeWarp As New TimeWarp
    Public Sub setup()
        mainbuttons = New List(Of Button)
        pausebuttons = New List(Of Button)
        savesButtons = New List(Of Button)
        mainbuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 50, 150, 40), Brushes.White, "New Game"))
        mainbuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 100, 150, 40), Brushes.White, "Options"))
        mainbuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 150, 150, 40), Brushes.White, "Credits"))
        mainbuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 200, 150, 40), Brushes.White, "Exit"))

        pausebuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 50, 150, 40), Brushes.White, "Resume"))
        pausebuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 100, 150, 40), Brushes.White, "Load"))
        pausebuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 150, 150, 40), Brushes.White, "Save"))
        pausebuttons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), 200, 150, 40), Brushes.White, "Back to Menu"))

        Dim y As Integer = 50
        For Each d As FileInfo In ls.getAllFiles
            y += 55
            Dim tempTest As String = d.Name.Replace(".array", "") + " | Saved: " + d.LastAccessTime.ToShortDateString

            savesButtons.Add(New Button(New Rectangle(CInt(Main.Width / 2 - 50), y, tempTest.Length * 12, 40), Brushes.White, tempTest))
        Next
    End Sub
    Public Sub drawGame(ByVal g As Graphics, ByVal start As Point, ByVal index As Integer, ByVal tileSize As Integer)
        'gr.Transform.Reset()
        With gr
            .DrawImageUnscaledAndClipped(selection_bg, New Rectangle(0, start.Y - 80, 983, 175))
            .DrawImage(tileMap, start.X, start.Y + 22, New Rectangle(0, 3 * tileSize, 8 * tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImageUnscaledAndClipped(selection_tile, New Rectangle(start.X + index * selectionWidth - 3, start.Y - selectionWidth - 3, 70, 70))
            .DrawImage(tileMap, start.X, start.Y - selectionWidth, New Rectangle(11 * tileSize, 0, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawString(Main.IndexToString(Main.selectedIndex), New System.Drawing.Font("Segoe UI Light", 12), Brushes.White, New Point(start.X + Main.selectedIndex * selectionWidth, start.Y))
            .DrawString("Cost: " + Main.economy.IndexToPrice(Main.selectedIndex).ToString, New System.Drawing.Font("Segoe UI Light", 10), Brushes.White, New Point(start.X + Main.selectedIndex * selectionWidth, CInt(start.Y - selectionWidth / 2)))
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
        timeWarp.rederTimeWarpScreen(gr, New Point(10, 10))
    End Sub
    Public Sub drawCredits()
        Main.Invalidate()
        creditsYaw = creditsYaw - 0.5
        If creditsYaw <= -1200 Then
            Main.sceneManager.setMainMenue()
            creditsYaw = 0.0
        End If
        With gr
            .FillRectangle(Brushes.White, New Rectangle(0, 0, Main.Width, Main.Height))
            'Credits title
            .DrawImageUnscaledAndClipped(banner, New Rectangle(New Point(CInt(Main.Width / 2 - 200), CInt(Main.Height / 2 - 110 + CInt(creditsYaw))), New Size(400, 100)))

            .DrawString("Credits", New System.Drawing.Font("Segoe UI Light", 24), Brushes.Black, New Point(CInt(Main.Width / 2 - 50), CInt(Main.Height / 2 + CInt(creditsYaw))))
            'Starting with Paul
            .DrawString("Lead Game Programmer: ", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 120 + CInt(creditsYaw))))
            .DrawString("Paul Koch", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 145 + CInt(creditsYaw))))
            '.DrawString("@paulkoch95", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 165 + CInt(creditsYaw))))
            'Starting with Jannis
            .DrawString("Additional Programming: ", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 240 + CInt(creditsYaw))))
            .DrawString("Jannis Becker", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 265 + CInt(creditsYaw))))
            '.DrawString("@jmb2624", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 285 + CInt(creditsYaw))))
            'Starting with Jannis
            .DrawString("Lead Game Artist: ", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 360 + CInt(creditsYaw))))
            .DrawString("Paul Koch", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 385 + CInt(creditsYaw))))

            .DrawString("Lead Art / UI Art: ", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 480 + CInt(creditsYaw))))
            .DrawString("Jannis Becker", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 505 + CInt(creditsYaw))))

            .DrawString("Gameplay: ", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 600 + CInt(creditsYaw))))
            .DrawString("Paul Koch", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 625 + CInt(creditsYaw))))
            .DrawString("Jannis Becker", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 650 + CInt(creditsYaw))))

            .DrawString("Special Thanks: ", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 720 + CInt(creditsYaw))))
            .DrawString("Daniel Earwicker and palm3D, Stackoverflow", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 745 + CInt(creditsYaw))))
            .DrawString("(Used fill circle algorithm from them)", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 770 + CInt(creditsYaw))))

            .DrawString("Tools: ", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 840 + CInt(creditsYaw))))
            .DrawString("Visual Studio and GDI+", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 865 + CInt(creditsYaw))))
            .DrawString("Paint.NET", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 890 + CInt(creditsYaw))))
            .DrawString("GIMP", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(CInt(Main.Width / 2 - 60), CInt(Main.Height / 2 + 915 + CInt(creditsYaw))))

            .DrawImageUnscaledAndClipped(logo, New Rectangle(New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 1030 + CInt(creditsYaw))), New Size(400, 100)))
            .DrawString("No Cups of coffee were harmed during the making of this game!", New System.Drawing.Font("Segoe UI Light", 12, FontStyle.Bold), Brushes.Black, New Point(CInt(Main.Width / 2 - 80), CInt(Main.Height / 2 + 1160 + CInt(creditsYaw))))

        End With
    End Sub
    Public Sub drawIntro()
        Main.Invalidate()

        If introVis >= 1 Then
            introVis -= 1.5
        End If
        If introBg <= 254 Then
            introBg += 1.2
        Else
            Main.sceneManager.setMainMenue()
        End If
        With gr
            .FillRectangle(New SolidBrush(Color.FromArgb(255, CInt(introBg), CInt(introBg), CInt(introBg))), New Rectangle(0, 0, Main.Width, Main.Height))
            .DrawImageUnscaledAndClipped(logo, New Rectangle(New Point(CInt(Main.Width / 2 - 200), CInt(Main.Height / 2 - 50)), New Size(400, 100)))
            'Not used Progressbar (Not used because theres not much to load).FillRectangle(Brushes.DarkGray, New Rectangle(CInt(Main.Width / 2 - 128), CInt(Main.Height / 2 + 42), 256, 8))
        End With
    End Sub
    Public Sub drawMainMenue()
        mouseClicked = False
        With gr
            .FillRectangle(Brushes.LightGray, New Rectangle(0, 0, Main.Width, Main.Height))
            .DrawImageUnscaledAndClipped(menu_bg, New Rectangle(50, 0, 400, 660))
            .DrawString("Main Menue", New System.Drawing.Font("Segoe UI Light", 24), Brushes.White, New Point(CInt(Main.Width / 2 - 50), 10))
            .DrawString("Developed by Paul Koch and all Github contributors! | Some images are mady by Jannis Becker | Version: " + Main.ProductVersion.ToString, New System.Drawing.Font("Segoe UI Light", 6), Brushes.Black, New Point(Main.Width - 400, 0))
            For Each b As Button In mainbuttons
                b.draw(gr)
            Next
        End With
    End Sub
    Public Sub drawLoadScreen()
        Dim y As Integer = 10
        With gr
            .DrawString("All available Saves", New System.Drawing.Font("Segoe UI Light", 24), Brushes.White, New Point(CInt(Main.Width / 2 - 50), 10))
            For Each b As Button In savesButtons
                b.draw(gr)
            Next
        End With
    End Sub
    Public Sub drawPauseMenue()
        mouseClicked = False
        With gr
            .FillRectangle(New SolidBrush(Color.FromArgb(90, 127, 127, 127)), New Rectangle(0, 0, Main.Width, Main.Height))
            .DrawString("Pause Menue", New System.Drawing.Font("Segoe UI Light", 24), Brushes.White, New Point(CInt(Main.Width / 2 - 50), 10))
            For Each b As Button In pausebuttons
                b.draw(gr)
            Next
        End With
    End Sub
    Public Sub Mouse(ByVal e As System.Windows.Forms.MouseEventArgs)

        'MsgBox(buttons.Count.ToString)
        Main.Text = "moving"
        If Main.sceneManager.mainMenue = True Then 'Haupt Menü BUtton Hovering
            If helper.ButtonHovered(e.Location, mainbuttons.First.rect) Then
                mainbuttons(0).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Main.sceneManager.setGame()
                    ls.newGame()
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
                    Main.sceneManager.setCreditsScreen()
                End If
            ElseIf helper.ButtonHovered(e.Location, mainbuttons(3).rect) Then
                mainbuttons(3).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Application.Exit()
                End If
            Else
                mainbuttons(0).color = Brushes.White
                mainbuttons(1).color = Brushes.White
                mainbuttons(2).color = Brushes.White
                mainbuttons(3).color = Brushes.White
            End If
        ElseIf Main.sceneManager.pauseMenue = True Then 'Pause Menü BUtton Hovering
            If helper.ButtonHovered(e.Location, pausebuttons(0).rect) Then
                pausebuttons(0).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Main.sceneManager.setGame()
                End If
            ElseIf helper.ButtonHovered(e.Location, pausebuttons(1).rect) Then
                pausebuttons(1).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Main.sceneManager.setLoadScreen()
                    'Main.sceneManager.setGame()
                    'Dim savename As String
                    'savename = InputBox("Geben sie den Namen des zu ladenden Spielstandes ein", "Laden", "save_1")
                    'ls.Load(savename)
                End If
            ElseIf helper.ButtonHovered(e.Location, pausebuttons(2).rect) Then
                pausebuttons(2).color = Brushes.DarkGray
                If mouseClicked = True Then

                    Main.sceneManager.setGame()
                    Dim savename As String
                    savename = InputBox("Geben sie einen Namen für den Spielstand ein", "Speichern", "[Insert your name here]")
                    If savename.Length > 0 Then
                        ls.Save(savename)
                        setup()
                    End If
                    
                End If
            ElseIf helper.ButtonHovered(e.Location, pausebuttons(3).rect) Then
                pausebuttons(3).color = Brushes.DarkGray
                If mouseClicked = True Then
                    Main.sceneManager.setMainMenue()
                End If
            Else
                pausebuttons(0).color = Brushes.White
                pausebuttons(1).color = Brushes.White
                pausebuttons(2).color = Brushes.White
                pausebuttons(3).color = Brushes.White
            End If
        ElseIf Main.sceneManager.loadScreen = True Then
            Main.Text = "inside it"
            For Each i As Button In savesButtons
                If helper.ButtonHovered(e.Location, i.rect) Then
                    Main.Text = "Hovering: " + i.content
                    i.color = Brushes.Blue
                    If mouseClicked Then
                        ls.Load(ls.getAllFiles.ElementAt(savesButtons.IndexOf(i)).Name.Replace(".array", ""))
                        Main.sceneManager.setGame()
                    End If

                End If
            Next
            For Each i As Button In savesButtons
                i.color = Brushes.White
            Next
        End If
        

        'Main.Text = mouseClicked.ToString
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
