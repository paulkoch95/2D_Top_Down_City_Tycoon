Public Class Animation
    Public image As Image
    Public animLength As Integer 'Number of Frames in Animation
    Public health As Integer 'How long the animation already last's
    Public animDuration As Integer 'In Frames per duration
    Public tileSize As Integer
    Public actualFrame As Integer = 0
    Public position As Point
    Public numRow As Integer = 1
    Public yAnim As Integer = 0
    Public Sub New(ByVal pos As Point, ByVal i As Image, ByVal length As Integer, ByVal size As Integer, ByVal duration As Integer, Optional ByVal rows As Integer = 1)
        position = pos
        image = i
        animLength = length
        animDuration = duration
        tileSize = size
        numRow = rows
    End Sub
    Public Sub PlayAnimation(ByVal g As Graphics)
        draw(g)
        calcAnim()
    End Sub
    Public Sub draw(ByVal g As Graphics)
        With g
            .DrawImage(image, position.X, position.Y, New Rectangle(actualFrame * tileSize, yAnim * tileSize, tileSize, tileSize), Drawing.GraphicsUnit.Pixel)
        End With
    End Sub
    Public Sub calcAnim() 'MUCH; MUCH; MUCH TODO!
        If numRow <= 1 Then
            Select Case actualFrame
                Case actualFrame < animLength
                    actualFrame += 1

                Case actualFrame = animLength
                    actualFrame = 0
                    health = health + 1
            End Select
        Else
            If actualFrame < animLength Then
                actualFrame += 1
            End If
            If actualFrame = animLength Then
                actualFrame = 0
                If yAnim < numRow Then
                    yAnim += 1
                End If
                If yAnim = numRow Then
                    yAnim = 0
                    actualFrame = 0
                    health = health + 1
                End If
            End If

        End If
        Main.Text = health 'actualFrame.ToString + " xOffset | " + yAnim.ToString + " yOffset"
    End Sub
End Class
