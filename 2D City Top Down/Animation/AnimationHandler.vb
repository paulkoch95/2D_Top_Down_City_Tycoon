Public Class AnimationHandler
    Public animations As New List(Of Animation)
    Public Sub debug()
        animations.Add(New Animation(New Point(10, 10), My.Resources.anim_001, 4, 32, 1, 2))
        'animations.Add(New Animation(New Point(40, 40), My.Resources.anim_003, 8, 64, 2, 8))
        'animations.Add(New Animation(New Point(40, 40), My.Resources.anim_004, 9, 100, 1, 9))
    End Sub
    Public Sub drawAnimations(ByVal g As Graphics)
        Select Case animations.Count
            Case 0
                Exit Sub
            Case Is > 0
                For Each anim As Animation In animations
                    If anim.health < anim.animDuration Then
                        anim.draw(g)
                        'animations.Remove(anim)
                    End If
                Next
        End Select
        
    End Sub
    Public Sub calcAnimations()
        Select Case animations.Count
            Case 0
                Exit Sub
            Case Is > 0
                For Each anim As Animation In animations
                    anim.calcAnim()
                Next
        End Select
        
    End Sub
End Class
