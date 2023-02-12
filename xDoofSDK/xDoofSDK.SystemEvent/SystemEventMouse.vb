Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports xDoofSDK.Hooking
Imports xDoofSDK.Hooking.MouseHook

Namespace SystemEvent

    Public Class SystemEventMouse

        Private WithEvents mshook As MouseHook

        Public Event OnMouseMove(position As Point)
        Public Event OnLeftClickDown(position As Point)
        Public Event OnLeftClickUp(position As Point)
        Public Event OnLeftDoubleClick(position As Point)
        Public Event OnRightClickDown(position As Point)
        Public Event OnRightClickUp(position As Point)
        Public Event OnRightDoubleClick(position As Point)
        Public Event OnMiddleClickDown(position As Point)
        Public Event OnMiddleClickUp(position As Point)
        Public Event OnMiddleDoubleClick(position As Point)
        Public Event OnWheel(position As Point, direction As MouseWheelType)

        Sub New()
            mshook = New MouseHook
        End Sub

        Private Sub msHook_MouseMove(pt As Point) Handles mshook.MouseMove
            RaiseEvent OnMouseMove(pt)
        End Sub

        Private Sub msHook_MouseLeftClickDown(pt As Point) Handles mshook.MouseLeftClickDown
            RaiseEvent OnLeftClickDown(pt)
        End Sub

        Private Sub msHook_MouseLeftClickUp(pt As Point) Handles mshook.MouseLeftClickUp
            RaiseEvent OnLeftClickUp(pt)
        End Sub

        Private Sub msHook_MouseLeftDoubleClick(pt As Point) Handles mshook.MouseLeftDoubleClick
            RaiseEvent OnLeftDoubleClick(pt)
        End Sub

        Private Sub msHook_MouseRightClickDown(pt As Point) Handles mshook.MouseRightClickDown
            RaiseEvent OnRightClickDown(pt)
        End Sub

        Private Sub msHook_MouseRightClickUp(pt As Point) Handles mshook.MouseRightClickUp
            RaiseEvent OnRightClickUp(pt)
        End Sub

        Private Sub msHook_MouseRightDoubleClick(pt As Point) Handles mshook.MouseRightDoubleClick
            RaiseEvent OnRightDoubleClick(pt)
        End Sub

        Private Sub msHook_MouseMiddleClickDown(pt As Point) Handles mshook.MouseMiddleClickDown
            RaiseEvent OnMiddleClickDown(pt)
        End Sub

        Private Sub msHook_MouseMiddleClickUp(pt As Point) Handles mshook.MouseMiddleClickUp
            RaiseEvent OnMiddleClickUp(pt)
        End Sub

        Private Sub msHook_MouseMiddleDoubleClick(pt As Point) Handles mshook.MouseMiddleDoubleClick
            RaiseEvent OnMiddleDoubleClick(pt)
        End Sub

        Private Sub msHook_MouseWheel(pt As Point, direction As MouseWheelType) Handles mshook.MouseWheel
            RaiseEvent OnWheel(pt, direction)
        End Sub

    End Class
End Namespace