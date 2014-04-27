﻿Public Class IngameUI
    Public gr As Graphics
    Public tileMap As Bitmap = My.Resources.tilemap
    Public selectionWidth As Integer = 64
    Public helper As New UIHelper
    Public mainMenueSelectedIndex = 0
    Public buttons As New List(Of Button)
    Public mouseClicked As Boolean = False
    Public Sub setup()
        buttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 50, 150, 40), Brushes.White, "New Game"))
        buttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 100, 150, 40), Brushes.White, "Options"))
        buttons.Add(New Button(New Rectangle(Main.Width / 2 - 50, 150, 150, 40), Brushes.White, "Exit"))
    End Sub
    Public Sub drawGame(ByVal g As Graphics, ByVal start As Point, ByVal index As Integer, ByVal tileSize As Integer)

        With gr
            '.DrawString("Inventory", New System.Drawing.Font("Segoe UI Light", 12), Brushes.Blue, start)
            .DrawImage(tileMap, start.X, start.Y + 22, New Rectangle(0, 3 * tileSize, 8 * tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawString(index.ToString, New System.Drawing.Font("Segoe UI Light", 12), Brushes.Blue, start)
            .DrawRectangle(Pens.Black, New Rectangle(New Point(start.X + index * selectionWidth, start.Y - selectionWidth), New Size(selectionWidth, selectionWidth)))
            .DrawImage(tileMap, start.X, start.Y - selectionWidth, New Rectangle(11 * tileSize, 0, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawString(Main.IndexToString(Main.selectedIndex), New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(start.X + Main.selectedIndex * selectionWidth, start.Y))
            .DrawString("Cost: " + Main.economy.IndexToPrice(Main.selectedIndex).ToString, New System.Drawing.Font("Segoe UI Light", 12), Brushes.Black, New Point(start.X + Main.selectedIndex * selectionWidth, start.Y - selectionWidth / 2))
            .DrawImage(tileMap, start.X + selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 2 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 2 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 4 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 3 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 5 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 4 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 1 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawImage(tileMap, start.X + 5 * selectionWidth, start.Y - selectionWidth, New Rectangle(11 * tileSize, 6 * tileSize, tileSize, tileSize), GraphicsUnit.Pixel)
            .DrawString("Money: " + Main.economy.money.ToString + " Population: " + Main.economy.population.ToString + " Datum: " + Main.yearCylce.yearString, New System.Drawing.Font("Segoe UI Light", 15), Brushes.Yellow, New Point(10, 10))
        End With

    End Sub
    Public Sub drawMainMenue()
        mouseClicked = False
        With gr
            .FillRectangle(Brushes.LightGray, New Rectangle(0, 0, Main.Width, Main.Height))
            .DrawString("Main Menue", New System.Drawing.Font("Segoe UI Light", 24), Brushes.White, New Point(Main.Width / 2 - 50, 10))
            For Each b As Button In buttons
                b.draw(gr)
            Next
        End With
    End Sub
    Public Sub drawPauseMenue()
        With gr
            .FillRectangle(New SolidBrush(Color.FromArgb(90, 127, 127, 127)), New Rectangle(0, 0, Main.Width, Main.Height))
            .DrawString("Pause Menue", New System.Drawing.Font("Segoe UI Light", 24), Brushes.White, New Point(Main.Width / 2 - 50, 10))
            
        End With
    End Sub
    Public Sub Mouse(ByVal e As System.Windows.Forms.MouseEventArgs)

        'MsgBox(buttons.Count.ToString)
        If helper.ButtonHovered(e.Location, buttons.First.rect) Then
            buttons(0).color = Brushes.DarkGray
            If mouseClicked = True Then
                Main.sceneManager.setGame()
            End If
        ElseIf helper.ButtonHovered(e.Location, buttons(1).rect) Then
            buttons(1).color = Brushes.DarkGray
        ElseIf helper.ButtonHovered(e.Location, buttons(2).rect) Then
            buttons(2).color = Brushes.DarkGray
            If mouseClicked = True Then
                Application.Exit()
            End If
        Else
            buttons(0).color = Brushes.White
            buttons(1).color = Brushes.White
            buttons(2).color = Brushes.White
        End If

        Main.Text = mouseClicked.ToString
    End Sub
    Public Sub Control(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.A
                MsgBox("Hi")
        End Select
    End Sub
End Class