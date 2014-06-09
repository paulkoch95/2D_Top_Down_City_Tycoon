Public Class Campaign
    Public ns As New NotificationSystem
    Public gr As Graphics
    Public events As New List(Of GameplayEvent)
    Public Sub setup()
        ns.startPosition = New Point(Main.ClientSize.Width - 250, 150)
        events.Add(New GameplayEvent(0, 50, "Sie haben 50 Einwohner erreicht!"))
        events.Add(New GameplayEvent(1, 25001, "Sie machen Gewinn!"))
    End Sub
    Public Sub evaluate()
        For Each e As GameplayEvent In events
            e.check()
        Next
    End Sub
    Public Sub triggerEvent(ByVal content As String)
        ns.addNote(content)
    End Sub

End Class
