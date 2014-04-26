Public Class SceneManagement
    Public mainMenue As Boolean = False
    Public game As Boolean = False
    Public pauseMenue As Boolean = False
    Public Sub setMainMenue()
        mainMenue = True
        game = False
        pauseMenue = False
    End Sub
    Public Sub setGame()
        mainMenue = False
        game = True
        pauseMenue = False
    End Sub
    Public Sub setPauseMenue()
        mainMenue = False
        game = True
        pauseMenue = True
    End Sub
End Class
