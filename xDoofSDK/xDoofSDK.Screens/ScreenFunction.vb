Imports System.Drawing
Imports System.Windows.Forms

Namespace Screens
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="ScreenFunction"/>.
    ''' </summary>
    Public Class ScreenFunction
        ''' <summary>
        ''' Récupère tout les <see cref="Screen"/> lié a cet ordinateur.
        ''' </summary>
        Shared Function GetAllScreens() As Screen()
            Return Screen.AllScreens()
        End Function
        ''' <summary>
        ''' Créer et retourne une capture d'écran du <see cref="Screen"/> principal.
        ''' </summary>
        Shared Function TakeMainScreenshot() As Bitmap
            Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            Dim g As Graphics = Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
            Return screenGrab
        End Function
        ''' <summary>
        ''' Créer et retourne une capture d'écran du <see cref="Screen"/> spécifié.
        ''' </summary>
        Shared Function TakeScreenshot(targetScreen As Screen) As Bitmap
            Dim screenSize As Size = New Size(targetScreen.Bounds.Width, targetScreen.Bounds.Height)
            Dim screenGrab As New Bitmap(targetScreen.Bounds.Width, targetScreen.Bounds.Height)
            Dim g As Graphics = Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
            Return screenGrab
        End Function
        ''' <summary>
        ''' Retourne l'écran par rapport a la position d'un <see cref="Control"/>.
        ''' </summary>
        Shared Function GetScreenFromControl(control As Control) As Screen
            Return Screen.FromControl(control)
        End Function
        ''' <summary>
        ''' Retourne l'écran par rapport a la position d'un handle (<see cref="IntPtr"/>).
        ''' </summary>
        Shared Function GetScreenFromHandle(hwnd As IntPtr) As Screen
            Return Screen.FromHandle(hwnd)
        End Function
        ''' <summary>
        ''' Retourne l'écran par rapport a la position d'un <see cref="Point"/>.
        ''' </summary>
        Shared Function GetScreenFromPoint(point As Point) As Screen
            Return Screen.FromPoint(point)
        End Function
        ''' <summary>
        ''' Retourne l'écran par rapport a la position d'un <see cref="Rectangle"/>.
        ''' </summary>
        Shared Function GetScreenFromRectangle(rectangle As Rectangle) As Screen
            Return Screen.FromRectangle(rectangle)
        End Function
        ''' <summary>
        ''' Retourne l'écran par rapport a la position du <see cref="Cursor"/>.
        ''' </summary>
        Shared Function GetScreenFromCursor(mouse As Cursor) As Screen
            Return Screen.FromPoint(Cursor.Position)
        End Function
        ''' <summary>
        ''' Retourne les limites d'affichage du <see cref="Screen"/> spécifié.
        ''' </summary>
        Shared Function GetBounds(defScreen As Screen) As Rectangle
            Return defScreen.Bounds
        End Function
        ''' <summary>
        ''' Retourne le nom du périphérique associé du <see cref="Screen"/> spécifié.
        ''' </summary>
        Shared Function GetDeviceName(defScreen As Screen) As String
            Return defScreen.DeviceName
        End Function
        ''' <summary>
        ''' Retourne la couleur <see cref="Color"/> du pixel <paramref name="x"/> et <paramref name="y"/> spécifié.
        ''' </summary>
        Shared Function GetColorByPixel(defScreen As Screen, x As Integer, y As Integer) As System.Drawing.Color
            Dim screenSize As Size = New Size(defScreen.Bounds.Width, defScreen.Bounds.Height)
            Dim screenGrab As New Bitmap(defScreen.Bounds.Width, defScreen.Bounds.Height)
            Dim g As Graphics = Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
            Dim pc As Color = screenGrab.GetPixel(x, y)
            Return pc
        End Function
    End Class

End Namespace
