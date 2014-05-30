Public Class NotificationSystem
    Public notes As New List(Of Notification)
    Public index As Integer = 0
    Public graphics As Graphics
    Public Sub drawNotes()
        For Each n As Notification In notes
            n.draw(graphics)
        Next
    End Sub
    Public Sub addNote(ByVal s As String)
        index += 1
        Dim note As New Notification
        note.pos = New Point(250, 250 + (index * 35))
        note.content = s
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
End Class
