Option Strict On

Public Class Main
    Public widthX, heightY As Integer
    Public xOffset, yOffset As Integer
    Public traffic As New Traffic
    Public perlin As Bitmap = My.Resources.Perlin
    Public tilemap As Bitmap = My.Resources.tilemap
    Public cars As New List(Of Rectangle)
    Public carspeeds As New List(Of Point)
    Public tileSize As Integer = 32
    Public map(500, 500) As Byte
    Public d As New Random
    Public UI As New IngameUI
    Public selectedIndex As Integer

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
    End Enum

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UI.setup()
        traffic.AddCar(100, 100, 23, 23)
        widthX = 31
        heightY = 18
        setup()
        'readimage()
        Me.DoubleBuffered = True
    End Sub

    Public Sub render(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

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

            Next
        Next
        ' e.Graphics.DrawRectangles(Pens.Blue, traffic.cars.ToArray)
        UI.draw(e.Graphics, New Point(10, 640), selectedIndex, tileSize)
    End Sub

    Private Sub GameLoop_Tick(sender As Object, e As EventArgs) Handles GameLoop.Tick
        'evaluateCars()
        'Me.Invalidate()
        'traffic.TrafficFlow()
    End Sub

    Public Sub readimage()
        Dim sw As New Stopwatch
        sw.Start()
        For x As Integer = 0 To perlin.Width - 1
            For y As Integer = 0 To perlin.Height - 1
                If GetPixel(x, y).R > 49 Then 'Das sind die Levels der Map, bzw die Intensität des Schwarzwertes. Je höher der Wert je weißer das Bild
                    map(x, y) = Convert.ToByte(Blocks.Red)
                End If
                If GetPixel(x, y).R > 50 Then
                    map(x, y) = Convert.ToByte(Blocks.Grass)
                End If
                If GetPixel(x, y).R > 100 Then
                    map(x, y) = Convert.ToByte(Blocks.Black)
                End If
                If GetPixel(x, y).R > 128 Then
                    map(x, y) = Convert.ToByte(Blocks.Gray)
                End If
                'If GetPixel(x, y) > 150 Then
                '    map(x - xOffset, y - yOffset) = Convert.ToByte(Bloecke.Gray)
                'End If

            Next
        Next
        sw.Stop()
        'MsgBox(sw.ElapsedMilliseconds)
    End Sub
    Public Function GetPixel(ByVal x As Integer, ByVal y As Integer) As Color
        Return perlin.GetPixel(x, y)
    End Function
    Public Sub SetBrick(ByVal x As Integer, ByVal y As Integer, ByVal brick As Byte)
        If Math.Floor(x / tileSize) < map.GetUpperBound(0) And Math.Floor(y / tileSize) < map.GetUpperBound(1) Then
            map(Convert.ToInt16(Math.Floor((x + (xOffset * tileSize)) / tileSize)), Convert.ToInt16(Math.Floor((y + (yOffset * tileSize)) / tileSize))) = brick
        End If
    End Sub
    Public Function GetBrick(ByVal x As Integer, ByVal y As Integer) As Byte
        Return map(Convert.ToInt16(Math.Floor((x + (xOffset * tileSize)) / tileSize)), Convert.ToInt16(Math.Floor((y + (yOffset * tileSize)) / tileSize)))
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
        'SetBrick(e.X, e.Y, CByte(Blocks.IntersectionUp))
        'Select Case ListBox1.SelectedIndex
        '    Case 0

        '    Case 1
        '        SetBrick(e.X, e.Y, CByte(Blocks.Grass))
        '    Case 2

        'End Select
        'SetBrick(e.X, e.Y, CByte(Blocks.RailHorizontal))
        'Me.Text = GetBrick(e.X, e.Y).ToString
        Me.Invalidate()


    End Sub
    Public Sub MouseWheelMoving(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        'Select Case e.Delta
        '    Case Is < 0
        '        tileSize -= 1
        '    Case Is > 0
        '        tileSize += 1

        'End Select
    End Sub
    Public Sub MouseMoving(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'Select Case MousePosition.X
        '    Case Is < 2
        '        xOffset -= 1
        '    Case Is > Me.Width
        '        xOffset += 1
        'End Select

    End Sub
    Public Sub setup()
        For i As Integer = 0 To map.GetUpperBound(0)
            For y As Integer = 0 To map.GetUpperBound(1)
                map(i, y) = CByte(Blocks.Grass)
                'If i * d.Next(2, 20) > y + d.Next(2, 6) Then
                '    map(i, y) = Convert.ToByte(Blocks.Blue)
                'Else
                '    map(i, y) = Convert.ToByte(Blocks.Red)
                'End If
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
                map(xx, yy) = CByte(Blocks.StreetHorizontal)
            Case 1
                map(xx, yy) = CByte(Blocks.RailHorizontal)
            Case 2

        End Select
        CheckStreets(xx, yy)



    End Sub
    Public Sub RemoveBlock(ByVal x As Integer, ByVal y As Integer)

        Dim xx As Integer = Convert.ToInt16(Math.Floor((x + (xOffset * tileSize)) / tileSize))
        Dim yy As Integer = Convert.ToInt16(Math.Floor((y + (yOffset * tileSize)) / tileSize))
        If xx < 1 Or yy < 1 Or yy > 498 Or xx > 498 Then
            Exit Sub
        End If
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

        If map(xx, yy - 1) = Blocks.RailHorizontal Or map(xx, yy - 1) = Blocks.RailVertical Then
            map(xx, yy - 1) = CByte(Blocks.RailVertical)
            map(xx, yy) = CByte(Blocks.RailVertical)
        End If
        If map(xx, yy + 1) = Blocks.RailHorizontal Or map(xx, yy + 1) = Blocks.RailVertical Then
            map(xx, yy + 1) = CByte(Blocks.RailVertical)
            map(xx, yy) = CByte(Blocks.RailVertical)
        End If
    End Sub
End Class