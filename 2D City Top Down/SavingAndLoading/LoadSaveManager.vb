Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class LoadSaveManager
    Public Sub Save()
        Dim savedMap(500, 500) As Byte ' = {1.0, 1.2, 1.3}
        For i As Integer = 0 To savedMap.GetUpperBound(0)
            For y As Integer = 0 To savedMap.GetUpperBound(1)
                savedMap(i, y) = Main.map(i, y)
            Next
        Next
        Dim fs As New FileStream("array.savegame", FileMode.Create)
        Dim bf As New BinaryFormatter()

        bf.Serialize(fs, savedMap)
        fs.Close()
    End Sub
    Public Sub Load()
        Dim fs As New FileStream("array.savegame", FileMode.Open)
        Dim bf As New BinaryFormatter()
        Dim loadedMap(,) As Byte = DirectCast(bf.Deserialize(fs), Byte(,))
        fs.Close()
        For i As Integer = 0 To loadedMap.GetUpperBound(0)
            For y As Integer = 0 To loadedMap.GetUpperBound(1)
                Main.map(i, y) = loadedMap(i, y)
            Next
        Next

    End Sub
End Class
