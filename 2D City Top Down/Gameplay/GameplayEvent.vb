Public Class GameplayEvent
    Public finished As Boolean = False
    Public type As Integer
    Public goal As Integer
    Public msg As String
    Public Sub New(ByVal variable As Integer, ByVal goals As Integer, ByVal content As String)
        type = variable
        goal = goals
        msg = content
    End Sub
    Public Sub check()
        Select Case type
            Case 0
                If Main.economy.population >= goal And finished = False Then
                    Main.campaignCore.triggerEvent(msg)
                    finished = True
                End If
            Case 1
                If Main.economy.money >= goal And finished = False Then
                    Main.campaignCore.triggerEvent(msg)
                    finished = True
                End If
        End Select

    End Sub
End Class
