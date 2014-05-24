Imports System.IO

Public Class LoadSaveManager
    Public Sub WriteCsv(Of T)(data As T(,), path As String)
        Dim specialChars As Char() = {","c, """"c, ControlChars.Lf, ControlChars.Cr}
        Using file__1 = File.CreateText(path)
            Dim height As Integer = data.GetLength(0), width As Integer = data.GetLength(1)
            For i As Integer = 0 To height - 1
                If i > 0 Then
                    file__1.WriteLine()
                End If
                For j As Integer = 0 To width - 1
                    Dim value As String = Convert.ToString(data(i, j))
                    If value.IndexOfAny(specialChars) >= 0 Then
                        value = """" & value.Replace("""", """""") & """"
                    End If
                    If j > 0 Then
                        file__1.Write(","c)
                    End If
                    file__1.Write(value)
                Next
            Next
        End Using
    End Sub
End Class
