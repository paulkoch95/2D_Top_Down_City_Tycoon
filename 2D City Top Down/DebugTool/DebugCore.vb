Public Class DebugCore
    Public textcol As New SolidBrush(Color.White)
    Public points As New List(Of Point)
    Public year As Integer = 0
    Public Sub renderDebug(ByVal g As Graphics)
        With g
            .FillRectangle(New SolidBrush(Color.FromArgb(100, 127, 127, 127)), New Rectangle(0, 0, 400, 200))
            .DrawString("FieldCount: " + Main.map.Length.ToString, New System.Drawing.Font("Segoe UI Light", 10), textcol, New Point(0, 0))
            .DrawString("xOffset/yOffset" + Main.xOffset.ToString + " | " + Main.yOffset.ToString, New System.Drawing.Font("Segoe UI Light", 10), textcol, New Point(0, 20))
            .DrawString("SceneManager: [main Menue][Pause Menue][Game]" + "[" + Main.sceneManager.mainMenue.ToString + "]" + "[" + Main.sceneManager.pauseMenue.ToString + "]" + "[" + Main.sceneManager.game.ToString + "]", New System.Drawing.Font("Segoe UI Light", 10), textcol, New Point(0, 40))
            .DrawString("Used Cups of Coffee: " + Main.usedCoffees.ToString, New System.Drawing.Font("Segoe UI Light", 10), textcol, New Point(0, 100))
            .DrawLines(Pens.Black, points.ToArray)
            .DrawString("Bevölkerungswachstum", New System.Drawing.Font("Segoe UI Light", 10), textcol, points.Last)
            .DrawString("MousePos: " + Main.MousePosition.ToString, New System.Drawing.Font("Segoe UI Light", 10), textcol, New Point(0, 160))

        End With
    End Sub
    Public Sub evaluatePopulationGraph()
        points.Add(New Point(year, 80 + Main.economy.population))
        year += 20
        If year > 400 Then
            points = New List(Of Point)
            points.Add(New Point(0, 80))
            points.Add(New Point(0, 80))
            year = 0
        End If
    End Sub

End Class
