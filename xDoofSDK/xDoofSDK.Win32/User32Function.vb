Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace Win32
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="User32Function"/>.
    ''' </summary><remarks>Les descriptions pour chaque fonction n'est pas fourni</remarks>
    Public Class User32Function
        Public Structure MSG

            Dim hwnd As IntPtr
            Dim m As Message
            Dim wParam As Integer
            Dim lParam As Integer
            Dim time As Timer
            Dim pt As Point

        End Structure

        <System.Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)>
        Public Structure POINTAPI
            Dim x As Integer
            Dim y As Integer
        End Structure
        Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
        Declare Auto Function GetParent Lib "user32.dll" (ByVal hWnd As Long) As Object
        Declare Auto Function GetWindow Lib "user32.dll" (ByVal hWnd As Long, ByVal wCmd As Long) As Object
        Declare Auto Function GetWindowLong Lib "user32.dll" (ByVal hWnd As Long, ByVal wIndx As Long) As Object
        Declare Auto Function GetWindowLongA Lib "user32.dll" (ByVal hWnd As Long, ByVal wIndx As Long) As Object
        Declare Auto Function GetTopWindow Lib "user32.dll" (ByVal hwnd As Long) As Object
        Declare Auto Function GetActiveWindow Lib "user32.dll" () As Object
        Declare Auto Function GetLastActivePopup Lib "user32.dll" (ByVal hwnd As Long) As Object
        Declare Auto Function GetForegroundWindow Lib "user32.dll" () As Object
        Declare Auto Function GetWindowTextLength Lib "user32.dll" (ByVal hwnd As Long) As Object
        Declare Auto Function GetWindowTextLengthA Lib "user32.dll" (ByVal hwnd As Long) As Object
        Declare Auto Function GetWindowText Lib "user32.dll" (ByVal hwnd As Long, ByVal lpstring As String, ByVal lpstrlen As Long) As Object
        Declare Auto Function GetWindowTextA Lib "user32.dll" (ByVal hwnd As Long, ByVal lpstring As String, ByVal lpstrlen As Long) As Object
        Declare Auto Function GetDesktopWindow Lib "user32.dll" () As Object
        Declare Auto Function GetFocus Lib "user32.dll" () As Object
        Declare Auto Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hWnd As Long, lpdwProcessId As Long) As Object
        Declare Auto Function SetTopWindow Lib "user32.dll" (ByVal Hwnd As Long) As Object
        Declare Auto Function SetForegroundWindow Lib "user32.dll" (ByVal Hwnd As Long) As Object
        Declare Auto Function SetActiveWindow Lib "user32.dll" (ByVal Hwnd As Long) As Object
        Declare Auto Function SetFocusAPI Lib "user32.dll" (ByVal Hwnd As Long) As Object
        Declare Auto Function SetCapture Lib "user32.dll" (ByVal Hwnd As Long) As Object
        Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpclassname As String, ByVal lpwindowname As String) As Object
        Declare Auto Function FindWindowClass Lib "user32.dll" (ByVal lpclassname As String, ByVal dummy As Long) As Object
        Declare Auto Function FindWindowName Lib "user32.dll" (ByVal dummy As Long, ByVal lpwindowname As String) As Object
        Declare Auto Function FindWindowA Lib "user32.dll" (ByVal lpclassname As String, ByVal lpwindowname As String) As Object
        Declare Auto Function AnyPopup Lib "user32.dll" () As Object
        Declare Auto Function ShowWindow Lib "user32.dll" (ByVal Hwnd As Long, ByVal nCmdShow As Long) As Object
        Declare Auto Function IsIcon Lib "user32.dll" (ByVal Hwnd As Long) As Object
        Declare Auto Function IsIconic Lib "user32.dll" (ByVal Hwnd As Long) As Object
        Declare Auto Function UpdateWindow Lib "user32.dll" (ByVal Hwnd As Long) As Object
        <DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)>
        Public Shared Function GetCursorPos(ByRef lpPoint As POINTAPI) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        Declare Auto Function CreatePopupMenu Lib "user32.dll" () As Object
        Declare Auto Function AppendMenu Lib "user32.dll" (ByVal hMenu As Long, ByVal wFlags As Long, ByVal wIDNewItem As Integer, ByVal lpNewItem As Object) As Object
        Declare Auto Function AppendMenuA Lib "user32.dll" (ByVal hMenu As Long, ByVal wFlags As Long, ByVal wIDNewItem As Integer, ByVal lpNewItem As Object) As Object
        Declare Auto Function TrackPopupMenu Lib "user32.dll" (ByVal hMenu As Long, ByVal wFlags As Long, ByVal x As Long, ByVal y As Long, ByVal nReserved As Long, ByVal hwnd As Long, lprc As Rectangle) As Object
        Declare Auto Function DestroyMenu Lib "user32.dll" (ByVal hMenu As Long) As Object
        Declare Auto Function GetMessage Lib "user32.dll" (lpMsg As MSG, ByVal hwnd As Long, ByVal wMsgFilterMin As Long, ByVal wMsgFilterMax As Long) As Object
        Declare Auto Function GetMessageA Lib "user32.dll" (lpMsg As MSG, ByVal hwnd As Long, ByVal wMsgFilterMin As Long, ByVal wMsgFilterMax As Long) As Object
        Declare Auto Function SendMessage Lib "user32.dll" (ByVal Hwnd As Long, ByVal Msg As Long, ByVal wParam As Long, lParam As Long) As Object
        Declare Auto Function SendMessageA Lib "user32.dll" (ByVal Hwnd As Long, ByVal Msg As Long, ByVal wParam As Long, lParam As Long) As Object
        Declare Auto Function SendMessageTimeOut Lib "user32.dll" (ByVal hwnd As Long, ByVal msg As Long, ByVal wparam As Long, ByVal lparam As Long, ByVal fuflags As Long, utimeout As Long, lpresult As Long) As Object
        Declare Auto Function GetClassName Lib "user32.dll" (ByVal hwnd As Long, ByVal lpclassname As String, ByVal nmaxcount As Long) As Object
        Declare Auto Function GetClassNameA Lib "user32.dll" (ByVal hwnd As Long, ByVal lpclassname As String, ByVal nmaxcount As Long) As Object
    End Class
End Namespace
