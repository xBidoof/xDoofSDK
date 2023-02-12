

Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Windows.Input
Imports Microsoft.VisualBasic.Devices

Namespace SystemC
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="KeyboardController"/>.
    ''' </summary>
    Public Class KeyboardController ' A TEST | https://www.vbforums.com/showthread.php?668773-SendInput

        Public Const EVENT_KEYDOWN As Integer = &H0
        Public Const EVENT_KEYUP As Integer = &H2

        Declare Function keybd_event Lib "user32" Alias "keybd_event" _
              (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer) As Integer

        ''' <summary>
        ''' Simule un appuie de touche sans relâcher l'appuie.
        ''' </summary>
        Sub SetKeyDown(ByVal key As Keys)
            keybd_event(CByte(key), 0, EVENT_KEYDOWN, 0)
        End Sub
        ''' <summary>
        ''' Simule un relâchement de touche.
        ''' </summary>
        Sub SetKeyUp(ByVal key As Keys)
            keybd_event(CByte(key), 0, EVENT_KEYUP, 0)
        End Sub
        ''' <summary>
        ''' Simule un appuie de touche avec un relâchement.
        ''' </summary><remarks>Un délai peut être spécifié entre l'appuie et la relâche.</remarks>
        Async Sub SetKeyDownUp(ByVal key As Keys, Optional ByVal delay As Integer = 0)
            If delay = 0 Then
                keybd_event(CByte(key), 0, EVENT_KEYDOWN, 0)
                keybd_event(CByte(key), 0, EVENT_KEYUP, 0)
            Else
                keybd_event(CByte(key), 0, EVENT_KEYDOWN, 0)
                Await Task.Delay(delay)
                keybd_event(CByte(key), 0, EVENT_KEYUP, 0)
            End If
        End Sub
        ''' <summary>
        ''' Simule un appuie de touche avec un relâchement sur une liste de <see cref="Keys"/> spécifié.
        ''' </summary><remarks>Un délai peut être spécifié entre l'appuie et la relâche.</remarks>
        Async Sub SetKeyDownUpList(ByVal key As List(Of Keys), Optional ByVal delay As Integer = 0)
            If delay = 0 Then
                For i = 0 To key.Count - 1
                    keybd_event(CByte(key(i)), 0, EVENT_KEYDOWN, 0)
                    keybd_event(CByte(key(i)), 0, EVENT_KEYUP, 0)
                Next
            Else
                For i = 0 To key.Count - 1
                    keybd_event(CByte(key(i)), 0, EVENT_KEYDOWN, 0)
                    Await Task.Delay(delay)
                    keybd_event(CByte(key(i)), 0, EVENT_KEYUP, 0)
                Next
            End If
        End Sub
        ''' <summary>
        ''' Utilisation avancé pour créer son propre événement.
        ''' </summary><remarks>Lib appelé user32 | Alias: keybd_event | Un délai peut être spécifié avant ou après l'exécution | exAB = 0 avant, exAB = 1 après.</remarks>
        Async Sub SetKeyboardEventCustom(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer, Optional exAB As Short = 0, Optional ByVal tDelay As Integer = 0)
            If tDelay = 0 Then
                keybd_event(bVk, bScan, dwFlags, dwExtraInfo)
            Else
                If exAB = 0 Then
                    Await Task.Delay(tDelay)
                    keybd_event(bVk, bScan, dwFlags, dwExtraInfo)
                ElseIf exAB = 1 Then
                    keybd_event(bVk, bScan, dwFlags, dwExtraInfo)
                    Await Task.Delay(tDelay)
                Else
                    Throw New Exception("param exAB exceeds the limit")
                End If
            End If
        End Sub

        Public Enum KeyEvent
            EVENT_KEYDOWN = &H0
            EVENT_KEYUP = &H2
        End Enum
    End Class
End Namespace
