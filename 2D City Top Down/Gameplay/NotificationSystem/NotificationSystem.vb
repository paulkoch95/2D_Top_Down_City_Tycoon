Public Class NotificationSystem
    Public notes As New List(Of Notification)
    Public index As Integer = 0
    Public graphics As Graphics
    Public startPosition As Point
    Public Sub drawNotes()
        For Each n As Notification In notes
            n.draw(graphics)
        Next
    End Sub
    Public Sub addNote(ByVal s As String)
        index += 1
        Dim note As New Notification(New Point(startPosition.X, startPosition.Y + (index * 60)), s, 2)
        notes.Add(note)
    End Sub
    Public Sub removeNote()
        index -= 1
        If notes.Count >= 1 Then
            notes.Remove(notes.Last)
        Else
            index = 0
        End If

    End Sub
    Public Sub removeNote(ByVal index As Integer)
        For i As Integer = index To notes.Count - 1
            notes(i).pos.Y -= 60
        Next
    End Sub
End Class
