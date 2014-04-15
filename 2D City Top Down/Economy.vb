Option Strict On

Public Class Economy
    Public money As Integer = 25000
    Public cost_street As Integer = 250
    Public cost_railway As Integer = 250
    Public cost_house As Integer = 500


    Public Sub BuildStreet()
        money -= cost_street
    End Sub
    Public Sub BuildRailway()
        money -= cost_railway
    End Sub
    Public Sub regainMoney(ByVal amount As Integer)
        money += amount
    End Sub
    Public Sub BuildHouse()
        money -= cost_house
    End Sub
    Public Function ByteToAmount(ByVal b As Byte) As Integer
        If b > 3 And b <= 14 Then
            Return cost_street
        ElseIf b = 15 Then
            Return 0
        ElseIf b > 15 And b <= 17 Then
            Return cost_railway
        ElseIf b = 20 Then
            Return cost_house
        End If
        Return vbNull
    End Function
    Public Function IndexToPrice(ByVal index As Integer) As Integer
        If index = 0 Then
            Return cost_street
        ElseIf index = 1 Then
            Return cost_railway
        ElseIf index = 2 Then
            Return cost_house
        End If
        Return 0
    End Function

End Class
