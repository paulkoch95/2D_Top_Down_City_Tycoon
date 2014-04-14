Option Strict On

Public Class Economy
    Public money As Integer = 25000
    Public cost_street As Integer = 250
    Public cost_railway As Integer = 250


    Public Sub BuildStreet()
        money -= cost_street
    End Sub
    Public Sub BuildRailway()
        money -= cost_railway
    End Sub
    Public Sub regainMoney(ByVal amount As Integer)
        money += amount
    End Sub
    Public Function ByteToAmount(ByVal b As Byte) As Integer
        Select Case b
            Case Is > 3
                Return 29999
            Case 15
                Return 0
            Case Is > 15
                Return 250
        End Select
        Return vbNull
    End Function

End Class
