Public Class WireCore
    Dim d As Integer = 0
    Public Sub analyseWire(ByVal map(,) As Byte, ByVal mapX As Integer, ByVal mapY As Integer)
        If map(mapX, mapY) >= 4 Then
            d += 1
            analyseWire(map, mapX + 1, mapY)
        End If
    End Sub
End Class
