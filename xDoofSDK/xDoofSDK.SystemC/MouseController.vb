Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace SystemC
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="MouseController"/>.
    ''' </summary>
    Public Class MouseController

        Public Const MOUSE_LEFT_DOWN As Integer = &H2
        Public Const MOUSE_LEFT_UP As Integer = &H4
        Public Const MOUSE_MIDDLE_DOWN As Integer = &H20
        Public Const MOUSE_MIDDLE_UP As Integer = &H40
        Public Const MOUSE_RIGHT_DOWN As Integer = &H8
        Public Const MOUSE_RIGHT_UP As Integer = &H10
        Public Const MOUSE_WHEEL As Integer = &H2048
        Public Const MOUSE_WHEEL_DOWN As Integer = -120
        Public Const MOUSE_WHEEL_UP As Integer = 120
        Public Const MOUSE_NEXT_BACK_DOWN As Integer = &H128
        Public Const MOUSE_NEXT_BACK_UP As Integer = &H256
        Public Const MOUSE_ABSOLUTE As Integer = &H8000
        Public Const MOUSE_MOVE As Integer = &H1

        <DllImport("user32.dll")>
        Private Shared Sub mouse_event(ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal dwData As Integer, ByVal dwExtraInfo As Integer)

        End Sub
        ''' <summary>
        ''' Modifie la position du curseur.
        ''' </summary>
        Sub [SetPosition](mPos As MousePos)
            Cursor.Position = New Drawing.Point(mPos.X, mPos.Y)
        End Sub
        ''' <summary>
        ''' Modifie la position du curseur.
        ''' </summary>
        Sub [SetPosition](ByVal x As Integer, ByVal y As Integer)
            Cursor.Position = New Drawing.Point(x, y)
        End Sub
        ''' <summary>
        ''' Modifie la position du curseur suivi d'une liste <see cref="List(Of MousePos)"/>.
        ''' </summary>
        Sub [SetPositionList](mPos As List(Of MousePos))
            For i = 0 To mPos.Count - 1
                Cursor.Position = New Drawing.Point(mPos(i).X, mPos(i).Y)
            Next
        End Sub
        ''' <summary>
        ''' Modifie la position du curseur suivi d'une <see cref="List(Of Integer)"/> de position X et d'une <see cref="List(Of Integer)"/> de position Y.
        ''' </summary>
        Sub [SetPositionList](listX As List(Of Integer), listY As List(Of Integer))
            For i = 0 To listX.Count - 1
                Cursor.Position = New Drawing.Point(listX(i), listY(i))
            Next
        End Sub
        ''' <summary>
        ''' Récupère la position du curseur et le retourne en <see cref="MousePos"/>.
        ''' </summary>
        ''' <remarks>Vous pouvez convertir un <see cref="MousePos"/> en d'autres types.</remarks>
        Function [GetPosition]() As MousePos
            Dim buildMP As MousePos
            Dim GetX = Cursor.Position.X
            Dim GetY = Cursor.Position.Y
            buildMP.X = GetX
            buildMP.X = GetY
            Return buildMP
        End Function
        ''' <summary>
        ''' Simule un clique gauche.
        ''' </summary>
        Sub SetLeftClick(mode As ModeClick)
            If mode = ModeClick.Down Then
                mouse_event(MOUSE_LEFT_DOWN, 0, 0, 0, 0)
            ElseIf mode = ModeClick.Up Then
                mouse_event(MOUSE_LEFT_UP, 0, 0, 0, 0)
            End If
        End Sub
        ''' <summary>
        ''' Simule un clique du milieu.
        ''' </summary>
        Sub SetMiddleClick(mode As ModeClick)
            If mode = ModeClick.Down Then
                mouse_event(MOUSE_MIDDLE_DOWN, 0, 0, 0, 0)
            ElseIf mode = ModeClick.Up Then
                mouse_event(MOUSE_MIDDLE_UP, 0, 0, 0, 0)
            End If
        End Sub
        ''' <summary>
        ''' Simule un clique droit.
        ''' </summary>
        Sub SetRightClick(mode As ModeClick)
            If mode = ModeClick.Down Then
                mouse_event(MOUSE_RIGHT_DOWN, 0, 0, 0, 0)
            ElseIf mode = ModeClick.Up Then
                mouse_event(MOUSE_RIGHT_UP, 0, 0, 0, 0)
            End If
        End Sub
        ''' <summary>
        ''' Simule une roulette.
        ''' </summary>
        Sub SetWheel(mode As ModeClick)
            If mode = ModeClick.Down Then
                mouse_event(MOUSE_WHEEL_DOWN, 0, 0, 0, 0)
            ElseIf mode = ModeClick.Up Then
                mouse_event(MOUSE_WHEEL_UP, 0, 0, 0, 0)
            End If
        End Sub

        Public Enum ModeClick
            Down
            Up
        End Enum
        ''' <summary>
        ''' Utilisation avancé pour créer son propre événement.
        ''' </summary><remarks>Lib appelé: user32</remarks>
        Sub MouseEventCustom(ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal dwData As Integer, ByVal dwExtraInfo As Integer)
            mouse_event(dwFlags, dx, dy, dwData, dwExtraInfo)
        End Sub
        ''' <summary>
        ''' Structure qui stocke les deux points X et Y, conversion en d'autres types possible.
        ''' </summary>
        Public Structure MousePos
            ''' <summary>
            ''' Point X.
            ''' </summary>
            Public X As Integer
            ''' <summary>
            ''' Point Y.
            ''' </summary>
            Public Y As Integer
            ''' <summary>
            ''' Convertie <see cref="MousePos"/> en <see cref="Point"/>.
            ''' </summary>
            Public Function ToPoint() As Point
                Dim newP As New Drawing.Point(X, Y)
                Return newP
            End Function
            ''' <summary>
            ''' Convertie <see cref="MousePos"/> en <see cref="Size"/>.
            ''' </summary>
            Public Function ToSize() As Size
                Dim newP As New Size(X, Y)
                Return newP
            End Function
            ''' <summary>
            ''' Convertie <see cref="MousePos"/> en <see cref="String"/>.
            ''' </summary>
            Public Overrides Function ToString() As String
                Dim buildStr As String = "{ X: " & X & ", Y: " & Y & " }"
                Return buildStr
            End Function
        End Structure
    End Class
End Namespace
