Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class LoadSaveManager
    Public Sub Save(ByVal name As String)
        Dim savedMap(500, 500) As Byte

        Dim Economy() As Integer = {Main.economy.money, Main.economy.population, Main.yearCylce.day, Main.yearCylce.year, Main.xOffset, Main.yOffset}
        For i As Integer = 0 To savedMap.GetUpperBound(0)
            For y As Integer = 0 To savedMap.GetUpperBound(1)
                savedMap(i, y) = Main.map(i, y)
            Next
        Next
        Dim bf As New BinaryFormatter()
        Dim fs As New FileStream(name + ".array", FileMode.Create)
        bf.Serialize(fs, savedMap)
        fs.Close()

        Dim fs2 As New FileStream(name + ".additional", FileMode.Create)
        bf.Serialize(fs2, Economy)
        fs2.Close()
    End Sub
    Public Sub Load(ByVal name As String)
        Dim fs As New FileStream(name + ".array", FileMode.Open)
        Dim fs2 As New FileStream(name + ".additional", FileMode.Open)

        Dim bf As New BinaryFormatter()
        Dim loadedMap(,) As Byte = DirectCast(bf.Deserialize(fs), Byte(,))
        fs.Close()
        Dim loadedEconomy() As Integer = DirectCast(bf.Deserialize(fs2), Integer())
        fs2.Close()
        Main.economy.money = loadedEconomy(0)
        Main.economy.population = loadedEconomy(1)
        Main.yearCylce.day = loadedEconomy(2)
        Main.yearCylce.year = loadedEconomy(3)
        Main.xOffset = loadedEconomy(4)
        Main.yOffset = loadedEconomy(5)
        Main.yearCylce.yearString = "Loading Date"
        For i As Integer = 0 To loadedMap.GetUpperBound(0)
            For y As Integer = 0 To loadedMap.GetUpperBound(1)
                Main.map(i, y) = loadedMap(i, y)
            Next
        Next
        For Each b As Byte In Main.map
            Select Case b
                Case 21 To 24
                    Main.economy.houses.Add(New House)
                Case 25
                    Main.economy.industry.Add(New Industry)
            End Select
        Next
    End Sub
    Public Sub newGame()
        Main.setup()
        Main.economy.init()
        Main.yearCylce.day = 0
        Main.yearCylce.year = 1980
        Main.yearCylce.yearString = "New Game"
    End Sub
    Public Function getAllFiles() As List(Of FileInfo)
        Dim DIRECTORY As String = My.Application.Info.DirectoryPath.ToString
        Dim info As DirectoryInfo
        info = New DirectoryInfo(DIRECTORY)
        Dim data As New List(Of FileInfo)
        Dim d As FileInfo
        For Each d In info.GetFiles("*.array")
            data.Add(d)
        Next
        Return data

    End Function
End Class
