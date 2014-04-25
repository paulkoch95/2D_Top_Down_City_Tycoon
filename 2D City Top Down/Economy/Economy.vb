Option Strict On

Public Class Economy
    Public money As Integer = 25000
    Public population As Integer = 0
    Public cost_house As Integer = 500
    Public cost_street As Integer = 250
    Public cost_railway As Integer = 250
    Public cost_industry As Integer = 750
    Public tax As Integer = 15
    Public industry_tax As Integer = 80

    Public houses As New List(Of House)
    Public industry As New List(Of Industry)

    Public Sub init()
        houses.Add(New House)
        industry.Add(New Industry)
    End Sub
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
                population -= houses.Last.inhabitants
                Exit Sub
            Case 25
                industry.Remove(industry.Last)
                money += industry.Last.price
                Exit Sub
        End Select
        money += amount
    End Sub
    Public Sub BuildHouse(ByVal position As Point)
        Dim tempHouse As New House()
        tempHouse.pos = position
        houses.Add(tempHouse)
        population += tempHouse.inhabitants
        money -= tempHouse.price
        Main.Text = tempHouse.pos.ToString
    End Sub
    Public Sub BuildIndustry(ByVal position As Point)
        Dim tempInd As New Industry()
        tempInd.pos = position
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
        Return 0
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
            money += (industry_tax * i.power)
        Next
    End Sub
    Public Sub checkForBuildings(ByVal index As Point)
        For Each h As House In houses
            If index = h.pos Then
                MsgBox("Haus mit " + h.inhabitants.ToString + "Einwohnern. Steuereinnahmen: " + (tax * h.inhabitants).ToString)
                Exit Sub
            End If
        Next
        For Each ind As Industry In industry
            If index = ind.pos Then
                MsgBox("Industry mit einer Wirtschaftlichen Kraft von: " + ind.power.ToString + " Steuereinnahmen: " + (industry_tax * ind.power).ToString)
                Exit Sub
            End If
        Next
    End Sub
End Class
