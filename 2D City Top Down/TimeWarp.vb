Public Class TimeWarp
    Public enabled As Boolean = False
    Public mode As Integer = 10
    Public warp_bg As Image = My.Resources.warp

    Public warp_1 As Image = My.Resources.x1_0
    Public warp_1_p As Image = My.Resources.x1_1

    Public warp_2 As Image = My.Resources.x2_0
    Public warp_2_p As Image = My.Resources.x2_1

    Public warp_10 As Image = My.Resources.x10_0
    Public warp_10_p As Image = My.Resources.x10_1
    Public helper As New UIHelper

    Public Sub rederTimeWarpScreen(ByVal g As Graphics, ByVal p As Point)
        Select Case enabled
            Case True
                With g
                    .DrawImageUnscaledAndClipped(warp_bg, New Rectangle(424, 60, 90, 33))
                    Select Case mode
                        Case 1
                            .DrawImageUnscaledAndClipped(warp_1_p, New Rectangle(432, 66, 22, 16))
                            .DrawImageUnscaledAndClipped(warp_2, New Rectangle(458, 66, 22, 16))
                            .DrawImageUnscaledAndClipped(warp_10, New Rectangle(484, 66, 22, 16))
                        Case 2
                            .DrawImageUnscaledAndClipped(warp_1, New Rectangle(432, 66, 22, 16))
                            .DrawImageUnscaledAndClipped(warp_2_p, New Rectangle(458, 66, 22, 16))
                            .DrawImageUnscaledAndClipped(warp_10, New Rectangle(484, 66, 22, 16))
                        Case 10
                            .DrawImageUnscaledAndClipped(warp_1, New Rectangle(432, 66, 22, 16))
                            .DrawImageUnscaledAndClipped(warp_2, New Rectangle(458, 66, 22, 16))
                            .DrawImageUnscaledAndClipped(warp_10_p, New Rectangle(484, 66, 22, 16))

                    End Select
                End With
            Case False
                Exit Sub
        End Select
        
    End Sub
    Public Sub performActionWhenClicked(ByVal e As Point)
        If helper.ButtonHovered(e, New Rectangle(432, 66, 22, 16)) Then
            mode = 1
        ElseIf helper.ButtonHovered(e, New Rectangle(458, 66, 22, 16)) Then
            mode = 2
        ElseIf helper.ButtonHovered(e, New Rectangle(484, 66, 22, 16)) Then
            mode = 10
        End If
        If enabled = False Then
            enabled = True
        Else
            enabled = False
        End If
    End Sub
End Class
