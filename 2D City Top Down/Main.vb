Option Strict On

Imports System.Threading

Public Class Main
    Public widthX, heightY As Integer
    Public xOffset, yOffset As Integer
    Public traffic As New Traffic
    Public tilemap As Bitmap = My.Resources.tilemap
    Public cars As New List(Of Rectangle)
    Public carspeeds As New List(Of Point)
    Public tileSize As Integer = 32
    Public map(500, 500) As Byte
    Public d As New Random
    Public UI As New IngameUI
    Public selectedIndex As Integer

    Public notes As New List(Of Notification)

    Public mousePos As New Point
    Public economy As Economy = New Economy
    Public minMap As New Minimap
    Public yearCylce As New YearCycle



    Public Enum Blocks
        Red = 0
        Blue = 1
        Black = 2
        Gray = 3
        StreetVertical = 4
        StreetHorizontal = 5
        StreetUpRight = 6
        StreetUpLeft = 7
        StreetDownLeft = 8
        StreetDownRight = 9

        IntersectionLeft = 10
        IntersectionDown = 11
        IntersectionRight = 12
        IntersectionUp = 13
        Intersection = 14

        Grass = 15

        RailHorizontal = 16
        RailVertical = 17
        RailIntersectionOne = 18
        RailIntersectionTwo = 19
        RailRailIntersection = 20

        House = 22

        Industry = 25

        ElectricWireHorizontal = 30
        ElectricWireVertical = 31

    End Enum

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UI.setup()
        traffic.AddCar(100, 100, 23, 23)
        economy.init()
        widthX = 31
        heightY = 18
        setup()
        'readimage()
        Me.DoubleBuffered = True
        'InterpolateBetweenTwoPoints(New Point(5, 5), New Point(2, 2))
    End Sub
    Public Sub render(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed

        For x As Integer = xOffset To xOffset + widthX - 1
            For y As Integer = yOffset To yOffset + heightY - 1
                If map(x, y) = Blocks.Red Then
                    With e.Graphics
                        .FillRectangle(Brushes.Red, New Rectangle(x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), tileSize, tileSize))
                    End With
                End If
                If map(x, y) = Blocks.Blue Then
                    With e.Graphics
                        .FillRectangle(Brushes.Blue, New Rectangle(x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), tileSize, tileSize))
                    End With
                End If
                If map(x, y) = Blocks.Black Then
                    With e.Graphics
                        .FillRectangle(Brushes.Black, New Rectangle(x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), tileSize, tileSize))
                    End With
                End If
                If map(x, y) = Blocks.Gray Then
                    With e.Graphics
                        .FillRectangle(Brushes.Gray, New Rectangle(x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), tileSize, tileSize))
                    End With
                End If
                'Ab hier Straßen und Kurven----------------
                If map(x, y) = Blocks.StreetVertical Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(0, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.StreetHorizontal Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(32, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If

                If map(x, y) = Blocks.StreetUpRight Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(2 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.StreetUpLeft Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(3 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.StreetDownRight Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(4 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.StreetDownLeft Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(5 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                'Ab hier Kreuzungen------------
                If map(x, y) = Blocks.IntersectionLeft Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(6 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.IntersectionDown Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(7 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.IntersectionRight Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(8 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.IntersectionUp Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(9 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.Intersection Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(10 * tileSize, 0, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If

                If map(x, y) = Blocks.Grass Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(0, 1 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)

                    End With
                End If

                If map(x, y) = Blocks.RailHorizontal Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(0, 2 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)

                    End With
                End If
                If map(x, y) = Blocks.RailVertical Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(1 * tileSize, 2 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)

                    End With
                End If
                If map(x, y) = Blocks.House Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(0, 4 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.Industry Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(0, 5 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.RailIntersectionOne Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(2 * tileSize, 2 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.RailIntersectionTwo Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(3 * tileSize, 2 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.RailRailIntersection Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(4 * tileSize, 2 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.ElectricWireHorizontal Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(0 * tileSize, 6 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If
                If map(x, y) = Blocks.ElectricWireVertical Then
                    With e.Graphics
                        .DrawImage(tilemap, x * tileSize - (xOffset * tileSize), y * tileSize - (yOffset * tileSize), New Rectangle(1 * tileSize, 6 * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
                    End With
                End If

            Next
        Next
        ' e.Graphics.DrawRectangles(Pens.Blue, traffic.cars.ToArray)

        With e.Graphics
            Select Case map(mousePos.X, mousePos.Y)
                Case 15
                    .FillRectangle(New SolidBrush(Color.FromArgb(100, 0, 255, 0)), New Rectangle(mousePos.X * tileSize, mousePos.Y * tileSize, tileSize, tileSize))
                Case Is <> 15
                    .FillRectangle(New SolidBrush(Color.FromArgb(100, 255, 0, 0)), New Rectangle(mousePos.X * tileSize, mousePos.Y * tileSize, tileSize, tileSize))
            End Select

        End With
        minMap.DrawMiniMap(e.Graphics, map)
        UI.draw(e.Graphics, New Point(10, 640), selectedIndex, tileSize)
        'For Each n In notes
        'n.draw(e.Graphics)
        'n.evaluate()
        'Next

    End Sub

    Private Sub GameLoop_Tick(sender As Object, e As EventArgs) Handles GameLoop.Tick
        'evaluateCars()
        Me.Invalidate()
        
        'traffic.TrafficFlow()
    End Sub
    Private Sub EconomyEvaluation_Tick(sender As Object, e As EventArgs) Handles EconomyEvaluation.Tick
        economy.evaluate()
        yearCylce.evaluate()
        'Me.Text = "Year: " + yearCylce.year.ToString + " |Day: " + yearCylce.day.ToString
    End Sub
    Public Function MousePointToMapPoint(ByVal mousePoint As Point) As Point
        Return New Point(Convert.ToInt16(Math.Floor((mousePoint.X + (xOffset * tileSize)) / tileSize)), Convert.ToInt16(Math.Floor((mousePoint.Y + (xOffset * tileSize)) / tileSize)))
    End Function
    Public Function GetBrick(ByVal x As Integer, ByVal y As Integer) As Byte
        Return map(Convert.ToInt16(Math.Floor((x + (xOffset * tileSize)) / tileSize)), Convert.ToInt16(Math.Floor((y + (yOffset * tileSize)) / tileSize)))
    End Function
    Public Function GetBrickRaw(ByVal x As Integer, ByVal y As Integer) As Byte
        Return map(Convert.ToInt32(x / tileSize), Convert.ToInt32(y / tileSize))
    End Function
    Public Function GetFromIndex(ByVal mapX As Integer, ByVal mapY As Integer) As Byte
        Return map(mapX, mapY)
    End Function
    Public Sub InterpolateBetweenTwoPoints(ByVal StartPoint As Point, ByVal EndPoint As Point)
        If EndPoint.X > StartPoint.X And EndPoint.Y > StartPoint.Y Then
            For xx As Integer = StartPoint.X To EndPoint.X
                map(xx, StartPoint.Y) = CByte(Blocks.ElectricWireHorizontal)
            Next
            For yy As Integer = StartPoint.Y To EndPoint.Y
                map(EndPoint.X, yy) = CByte(Blocks.ElectricWireHorizontal)
            Next
        End If

        If EndPoint.X < StartPoint.X And EndPoint.Y > StartPoint.Y Then
            For xx As Integer = EndPoint.X To StartPoint.X
                map(xx, StartPoint.Y) = CByte(Blocks.ElectricWireHorizontal)
            Next
            For yy As Integer = StartPoint.Y To EndPoint.Y
                map(EndPoint.X, yy) = CByte(Blocks.ElectricWireHorizontal)
            Next
        End If
        If EndPoint.X < StartPoint.X And EndPoint.Y < StartPoint.Y Then
            For xx As Integer = EndPoint.X To StartPoint.X
                map(xx, StartPoint.Y) = CByte(Blocks.ElectricWireHorizontal)
            Next
            For yy As Integer = EndPoint.Y To StartPoint.Y
                map(EndPoint.X, yy) = CByte(Blocks.ElectricWireHorizontal)
            Next
        End If
        If EndPoint.X > StartPoint.X And EndPoint.Y < StartPoint.Y Then
            For xx As Integer = StartPoint.X To EndPoint.X
                map(xx, StartPoint.Y) = CByte(Blocks.ElectricWireHorizontal)
            Next
            For yy As Integer = EndPoint.Y To StartPoint.Y
                map(EndPoint.X, yy) = CByte(Blocks.ElectricWireHorizontal)
            Next
        End If
    End Sub
    Public Function ByteToString(ByVal b As Byte) As String
        If b >= 4 And b <= 14 Then
            Return "Street"
        ElseIf b = 15 Then
            Return "Grass"
        ElseIf b >= 16 And b <= 20 Then
            Return "Rail"
        ElseIf b = 22 Then
            Return "House"
        ElseIf b = 25 Then
            Return "Industry"
        ElseIf b >= 30 And b <= 31 Then
            Return "Electric"
        End If
        Return "Nothing"
    End Function
    Public Function IndexToString(ByVal index As Integer) As String
        If index = 0 Then
            Return "Street"
        ElseIf index = 1 Then
            Return "Rail"
        ElseIf index = 2 Then
            Return "House"
        ElseIf index = 3 Then
            Return "Industry"
        ElseIf index = 4 Then
            Return "Help"
        ElseIf index = 5 Then
            Return "Electric"
        End If
        Return "EmptySlot"
    End Function
    Private Sub SelectIndex(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseWheel
        If e.Delta > 0 Then
            selectedIndex += 1
            If selectedIndex >= 9 Then
                selectedIndex = 0
            End If
            Me.Invalidate()

        ElseIf e.Delta < 0 Then
            selectedIndex -= 1
            If selectedIndex <= -1 Then
                selectedIndex = 8
            End If
            Me.Invalidate()
        End If
    End Sub
    Public Sub MouseClicking(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        'readimage()
        If e.Button = Windows.Forms.MouseButtons.Left Then
            BuildBlock(e.X, e.Y)
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            RemoveBlock(e.X, e.Y)
        End If
        'Me.Text = GetBrick(e.X, e.Y).ToString
        Me.Invalidate()


    End Sub
    Public Sub MouseMoving(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        mousePos.X = Convert.ToInt32(Math.Floor(e.X / tileSize))
        mousePos.Y = Convert.ToInt32(Math.Floor(e.Y / tileSize))
        Dim rectSize As Int16 = 9 'The invalidated Rect around Mouse. Only odd values! The bigger, the less artifacts, but worse performance.
        Me.Invalidate(New Rectangle(CInt(mousePos.X * tileSize - tileSize * Math.Floor(rectSize / 2)), CInt(mousePos.Y * tileSize - tileSize * Math.Floor(rectSize / 2)), tileSize * rectSize, tileSize * rectSize))
        'Me.Text = Convert.ToString(GetBrick(mousePos.X, mousePos.Y))
        'Me.Text = Convert.ToString(MousePointToMapPoint(New Point(e.X, e.Y)))
        'InterpolateBetweenTwoPoints(New Point(10, 10), mousePos)
    End Sub
    Public Sub setup()
        For i As Integer = 0 To map.GetUpperBound(0)
            For y As Integer = 0 To map.GetUpperBound(1)
                map(i, y) = CByte(Blocks.Grass)
            Next
        Next
    End Sub
    Public Sub KeyboardControls(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.Invalidate()
        Select Case e.KeyCode
            Case Keys.Up
                If yOffset - 1 <= 0 Then
                    yOffset = 0
                Else
                    yOffset -= 1
                End If
                'readimage()
            Case Keys.Down

                If yOffset + 1 >= map.GetUpperBound(1) Then
                    yOffset = map.GetUpperBound(1)
                Else
                    yOffset += 1
                End If
                'readimage()
            Case Keys.Left

                If xOffset - 1 <= 0 Then
                    xOffset = 0
                Else
                    xOffset -= 1
                End If
                'readimage()
            Case Keys.Right
                If xOffset + 1 >= map.GetUpperBound(0) Then
                    xOffset = map.GetUpperBound(0)
                Else
                    xOffset += 1
                End If
                'readimage()
        End Select
        UI.Control(e)
    End Sub

    Public Sub BuildBlock(ByVal x As Integer, ByVal y As Integer)

        Dim xx As Integer = Convert.ToInt16(Math.Floor((x + (xOffset * tileSize)) / tileSize))
        Dim yy As Integer = Convert.ToInt16(Math.Floor((y + (yOffset * tileSize)) / tileSize))
        If xx < 1 Or yy < 1 Or yy > 498 Or xx > 498 Then
            Exit Sub
        End If

        Select Case selectedIndex
            Case 0
                If map(xx, yy) = CByte(Blocks.Grass) And economy.money >= economy.cost_street Then
                    map(xx, yy) = CByte(Blocks.StreetHorizontal)
                    economy.BuildStreet()

                End If
                CheckStreets(xx, yy)
            Case 1
                If map(xx, yy) = CByte(Blocks.Grass) And economy.money >= economy.cost_railway Then
                    map(xx, yy) = CByte(Blocks.RailHorizontal)
                    economy.BuildRailway()
                End If
                CheckRails(xx, yy)
            Case 2
                If map(xx, yy) = CByte(Blocks.Grass) And economy.money >= economy.cost_house Then
                    map(xx, yy) = CByte(Blocks.House)
                    economy.BuildHouse(New Point(xx, yy))
                End If
            Case 3
                If map(xx, yy) = CByte(Blocks.Grass) And economy.money >= economy.cost_industry Then
                    map(xx, yy) = CByte(Blocks.Industry)
                    economy.BuildIndustry(New Point(xx, yy))
                End If
            Case 4
                Me.Text = "Checking!"
                economy.checkForBuildings(New Point(xx, yy))
            Case 5
                If map(xx, yy) = CByte(Blocks.Grass) And economy.money >= economy.cost_electricwire Then
                    map(xx, yy) = CByte(Blocks.ElectricWireHorizontal)
                    economy.BuildElectricWire()

                End If
                CheckWires(xx, yy)
        End Select




    End Sub

    Public Sub RemoveBlock(ByVal x As Integer, ByVal y As Integer)

        Dim xx As Integer = Convert.ToInt16(Math.Floor((x + (xOffset * tileSize)) / tileSize))
        Dim yy As Integer = Convert.ToInt16(Math.Floor((y + (yOffset * tileSize)) / tileSize))
        If selectedIndex = 4 Then
            Exit Sub 'Wenn man die Hilfe auswählt soll man nichts abreissen können
        End If
        If xx < 1 Or yy < 1 Or yy > 498 Or xx > 498 Then
            Exit Sub
        End If
        Me.Text = xx.ToString
        economy.regainMoney(economy.ByteToAmount(GetFromIndex(xx, yy)), GetFromIndex(xx, yy))
        map(xx, yy) = CByte(Blocks.Grass)



    End Sub
    Public Sub CheckStreets(ByVal xx As Integer, ByVal yy As Integer)
        'Streets
        If map(xx, yy - 1) = Blocks.StreetHorizontal Or map(xx, yy - 1) = Blocks.StreetVertical Then
            map(xx, yy - 1) = CByte(Blocks.StreetVertical)
            map(xx, yy) = CByte(Blocks.StreetVertical)
        End If
        If map(xx, yy + 1) = Blocks.StreetHorizontal Or map(xx, yy + 1) = Blocks.StreetVertical Then
            map(xx, yy + 1) = CByte(Blocks.StreetVertical)
            map(xx, yy) = CByte(Blocks.StreetVertical)
        End If
        'Curves
        If map(xx - 1, yy) = Blocks.StreetHorizontal And map(xx, yy - 1) = Blocks.StreetVertical Then
            map(xx, yy) = CByte(Blocks.StreetUpLeft)
        End If
        If map(xx - 1, yy) = Blocks.StreetHorizontal And map(xx, yy + 1) = Blocks.StreetVertical Then
            map(xx, yy) = CByte(Blocks.StreetDownLeft)
        End If
        If map(xx + 1, yy) = Blocks.StreetHorizontal And map(xx, yy - 1) = Blocks.StreetVertical Then
            map(xx, yy) = CByte(Blocks.StreetUpRight)
        End If
        If map(xx + 1, yy) = Blocks.StreetHorizontal And map(xx, yy + 1) = Blocks.StreetVertical Then
            map(xx, yy) = CByte(Blocks.StreetDownRight)
        End If
        'intersections
        If map(xx, yy + 1) = Blocks.StreetVertical And map(xx, yy - 1) = Blocks.StreetVertical And map(xx - 1, yy) = Blocks.StreetHorizontal Then
            map(xx, yy) = CByte(Blocks.IntersectionLeft)
        End If

        If map(xx - 1, yy) = Blocks.StreetHorizontal And map(xx + 1, yy) = Blocks.StreetHorizontal And map(xx, yy + 1) = Blocks.StreetVertical Then
            map(xx, yy) = CByte(Blocks.IntersectionDown)
        End If

        If map(xx, yy + 1) = Blocks.StreetVertical And map(xx, yy - 1) = Blocks.StreetVertical And map(xx + 1, yy) = Blocks.StreetHorizontal Then
            map(xx, yy) = CByte(Blocks.IntersectionRight)
        End If

        If map(xx - 1, yy) = Blocks.StreetHorizontal And map(xx + 1, yy) = Blocks.StreetHorizontal And map(xx, yy - 1) = Blocks.StreetVertical Then
            map(xx, yy) = CByte(Blocks.IntersectionUp)
        End If

        If map(xx - 1, yy) = Blocks.StreetHorizontal And map(xx + 1, yy) = Blocks.StreetHorizontal And map(xx, yy - 1) = Blocks.StreetVertical And map(xx, yy + 1) = Blocks.StreetVertical Then
            map(xx, yy) = CByte(Blocks.Intersection)
        End If

        If map(xx, yy) = Blocks.StreetVertical And map(xx - 1, yy) = Blocks.RailHorizontal And map(xx + 1, yy) = Blocks.RailHorizontal Then
            map(xx, yy) = CByte(Blocks.RailIntersectionOne)
        End If
        If map(xx, yy) = Blocks.StreetHorizontal And map(xx, yy - 1) = Blocks.RailVertical And map(xx, yy + 1) = Blocks.RailVertical Then
            map(xx, yy) = CByte(Blocks.RailIntersectionTwo)
        End If
        
        

    End Sub
    Public Sub CheckRails(ByVal xx As Integer, ByVal yy As Integer)
        If map(xx, yy - 1) = Blocks.RailHorizontal Or map(xx, yy - 1) = Blocks.RailVertical Then
            map(xx, yy - 1) = CByte(Blocks.RailVertical)
            map(xx, yy) = CByte(Blocks.RailVertical)
        End If
        If map(xx, yy + 1) = Blocks.RailHorizontal Or map(xx, yy + 1) = Blocks.RailVertical Then
            map(xx, yy + 1) = CByte(Blocks.RailVertical)
            map(xx, yy) = CByte(Blocks.RailVertical)
        End If

        If map(xx, yy) = Blocks.StreetVertical And map(xx - 1, yy) = Blocks.RailHorizontal And map(xx + 1, yy) = Blocks.RailHorizontal Then
            map(xx, yy) = CByte(Blocks.RailIntersectionOne)
        End If
        If map(xx, yy) = Blocks.StreetHorizontal And map(xx, yy - 1) = Blocks.RailVertical And map(xx, yy + 1) = Blocks.RailVertical Then
            map(xx, yy) = CByte(Blocks.RailIntersectionTwo)
        End If
        If map(xx - 1, yy) = Blocks.RailHorizontal And map(xx + 1, yy) = Blocks.RailHorizontal And map(xx, yy - 1) = Blocks.RailVertical And map(xx, yy + 1) = Blocks.RailVertical Then
            map(xx, yy) = CByte(Blocks.RailRailIntersection)
            Me.Text = "CheckRails"
        End If
    End Sub
    Public Sub CheckWires(ByVal xx As Integer, ByVal yy As Integer)
        If map(xx, yy - 1) = Blocks.ElectricWireHorizontal Or map(xx, yy - 1) = Blocks.ElectricWireVertical Then
            map(xx, yy - 1) = CByte(Blocks.ElectricWireVertical)
            map(xx, yy) = CByte(Blocks.ElectricWireVertical)
        End If
        If map(xx, yy + 1) = Blocks.ElectricWireHorizontal Or map(xx, yy + 1) = Blocks.ElectricWireVertical Then
            map(xx, yy + 1) = CByte(Blocks.ElectricWireVertical)
            map(xx, yy) = CByte(Blocks.ElectricWireVertical)
        End If
    End Sub


End Class