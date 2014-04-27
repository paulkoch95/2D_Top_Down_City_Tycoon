Public Class UIHelper
    Public Function ButtonHovered(ByVal Mousepos As Point, ByVal Button As Rectangle) As Boolean
        Dim d As Boolean = False
        If Mousepos.X > Button.X Then
            If Mousepos.X < (Button.X + Button.Width) Then
                If Mousepos.Y > Button.Y Then
                    If Mousepos.Y < (Button.Y + Button.Height) Then
                        d = True
                    End If
                End If
            End If
        End If
        Return d
    End Function
End Class
