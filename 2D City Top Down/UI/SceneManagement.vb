Public Class SceneManagement
    Public mainMenue As Boolean = False
    Public game As Boolean = False
    Public pauseMenue As Boolean = False
    Public introScreen As Boolean = False
    Public creditsScreen As Boolean = False
    Public loadScreen As Boolean = False
    Public Sub setIntro()
        introScreen = True
        mainMenue = False
        game = False
        pauseMenue = False
        creditsScreen = False
        loadScreen = False
    End Sub
    Public Sub setMainMenue()
        introScreen = False
        mainMenue = True
        game = False
        pauseMenue = False
        creditsScreen = False
        loadScreen = False
    End Sub
    Public Sub setGame()
        introScreen = False
        mainMenue = False
        game = True
        pauseMenue = False
        creditsScreen = False
        loadScreen = False
    End Sub
    Public Sub setPauseMenue()
        introScreen = False
        mainMenue = False
        game = True
        pauseMenue = True
        creditsScreen = False
        loadScreen = False
    End Sub
    Public Sub setCreditsScreen()
        introScreen = False
        mainMenue = False
        game = False
        pauseMenue = False
        creditsScreen = True
        loadScreen = False
    End Sub
    Public Sub setLoadScreen()
        introScreen = False
        mainMenue = False
        game = False
        pauseMenue = False
        creditsScreen = False
        loadScreen = True
    End Sub
End Class
