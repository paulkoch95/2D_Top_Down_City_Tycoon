Option Strict On

Public Class Economy
    Public money As Integer = 25000
    Public population As Integer = 0
    Public cost_house As Integer = 500
    Public cost_street As Integer = 250
    Public cost_railway As Integer = 250
    Public cost_industry As Integer = 750
    Public tax As Integer = 15
    Public economy_tax As Integer = 30

    Public houses As New List(Of House)
    Public industry As New List(Of Industry)


    Public Sub BuildStreet()
        money -= cost_street
    End Sub
    Public Sub BuildRailway()
        money -= cost_railway
    End Sub
    Public Sub regainMoney(ByVal amount As Integer, ByVal index As Integer)
        Select Case index
            Case 22
                houses.Remove(houses.Last)
                money += houses.Last.price
                Exit Sub
            Case 25
                industry.Remove(industry.Last)
                money += industry.Last.price
                Exit Sub
        End Select
        money += amount
    End Sub
    Public Sub BuildHouse()
        Dim tempHouse As New House()
        houses.Add(tempHouse)
        population += tempHouse.inhabitants
        money -= tempHouse.price
    End Sub
    Public Sub BuildIndustry()
        Dim tempInd As New Industry()
        industry.Add(tempInd)
        money -= tempInd.price
    End Sub
    Public Function ByteToAmount(ByVal b As Byte) As Integer
        If b > 3 And b <= 14 Then
            Return cost_street
        ElseIf b = 15 Then
            Return 0
        ElseIf b > 15 And b <= 20 Then
            Return cost_railway
        ElseIf b = 22 Then
            Return cost_house
        ElseIf b = 25 Then
            Return cost_industry
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
        ElseIf index = 3 Then
            Return cost_industry
        End If
        Return 0
    End Function
    Public Sub evaluate()
        For Each h In houses
            money += (tax * h.inhabitants)
        Next
        For Each i In industry
            money += (economy_tax * i.power)
        Next
    End Sub
End Class
