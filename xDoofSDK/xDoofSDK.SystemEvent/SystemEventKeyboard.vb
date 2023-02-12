Imports xDoofSDK.Hooking
Imports System.Windows.Forms

Namespace SystemEvent
    Public Class SystemEventKeyboard

        Private WithEvents kbHook As New KeyboardHook

        Public Shared Event OnKeyDown(position As Keys)
        Public Shared Event OnKeyUp(position As Keys)

        Sub New()

        End Sub

        Private Sub khbook_OnKeyDown(ByVal Key As Keys) Handles kbHook.KeyDown
            RaiseEvent OnKeyDown(Key)
        End Sub

        Private Sub khbook_OnKeyUp(ByVal Key As Keys) Handles kbHook.KeyUp
            RaiseEvent OnKeyUp(Key)
        End Sub

    End Class
End Namespace
