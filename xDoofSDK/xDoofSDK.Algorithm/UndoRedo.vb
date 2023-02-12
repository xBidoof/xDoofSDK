Imports System.Windows.Forms

Namespace Algorithm
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="UndoRedo"/>.
    ''' </summary>
    ''' <remarks>Contrôle pris en charge : <see cref="TextBox"/> | <see cref="RichTextBox"/> | <see cref="Label"/>.</remarks>
    Public Class UndoRedo

        Private _ControlType As String = ""

        Private _UndoAldo As List(Of String) = New List(Of String)()
        Private _UndoPosition As Integer = 0
        Public Sub New(ByVal ControlTextBox As TextBox)
            _ControlType = "TextBox"
        End Sub

        Public Sub New(ByVal ControlRichTextBox As RichTextBox)
            _ControlType = "RichTextBox"
        End Sub

        Public Sub New(ByVal ControlLabel As Label)
            _ControlType = "Label"
        End Sub
        ''' <summary>
        ''' Ajoute le texte du <see cref="TextBox"/> à la file de l'algorithme.
        ''' </summary>
        Public Sub [AddUndo](ByVal ControlTextBox As TextBox)
            _UndoAldo.Add(ControlTextBox.Text)
            _UndoPosition = _UndoPosition + 1
        End Sub
        ''' <summary>
        ''' Ajoute le texte du <see cref="RichTextBox"/> à la file de l'algorithme.
        ''' </summary>
        Public Sub [AddUndo](ByVal ControlRichTextBox As RichTextBox)
            _UndoAldo.Add(ControlRichTextBox.Text)
            _UndoPosition = _UndoPosition + 1
        End Sub
        ''' <summary>
        ''' Ajoute le texte du <see cref="Label"/> à la file de l'algorithme.
        ''' </summary>
        Public Sub [AddUndo](ByVal ControlLabel As Label)
            _UndoAldo.Add(ControlLabel.Text)
            _UndoPosition = _UndoPosition + 1
        End Sub
        ''' <summary>
        ''' Reviens en arrière si possible et remplace le texte présent du contrôle <see cref="TextBox"/> par le texte saisie par avant.
        ''' </summary>
        Public Sub [Undo](ByVal ControlTextBox As TextBox)
            If _UndoPosition = 0 Then

            Else
                _UndoPosition -= 1
                ControlTextBox.Text = _UndoAldo(_UndoPosition)
            End If
        End Sub
        ''' <summary>
        ''' Reviens en arrière si possible et remplace le texte présent du contrôle <see cref="RichTextBox"/> par le texte saisie par avant.
        ''' </summary>
        Public Sub [Undo](ByVal ControlTextBox As RichTextBox)
            If _UndoPosition = 0 Then

            Else
                _UndoPosition -= 1
                ControlTextBox.Text = _UndoAldo(_UndoPosition)
            End If
        End Sub
        ''' <summary>
        ''' Reviens en arrière si possible et remplace le texte présent du contrôle <see cref="Label"/> par le texte saisie par avant.
        ''' </summary>
        Public Sub [Undo](ByVal ControlLabel As Label)
            If _UndoPosition = 0 Then

            Else
                _UndoPosition -= 1
                ControlLabel.Text = _UndoAldo(_UndoPosition)
            End If
        End Sub
        ''' <summary>
        ''' Reviens en avant si possible et remplace le texte présent du contrôle <see cref="TextBox"/> par le texte saisie par avant.
        ''' </summary>
        Public Sub [Redo](ByVal ControlTextBox As TextBox)
            If _UndoPosition = _UndoAldo.Count - 1 Then

            Else
                _UndoPosition += 1
                ControlTextBox.Text = _UndoAldo(_UndoPosition)
            End If
        End Sub
        ''' <summary>
        ''' Reviens en avant si possible et remplace le texte présent du contrôle <see cref="RichTextBox"/> par le texte saisie par avant.
        ''' </summary>
        Public Sub [Redo](ByVal ControlTextBox As RichTextBox)
            If _UndoPosition = _UndoAldo.Count - 1 Then

            Else
                _UndoPosition += 1
                ControlTextBox.Text = _UndoAldo(_UndoPosition)
            End If
        End Sub
        ''' <summary>
        ''' Reviens en avant si possible et remplace le texte présent du contrôle <see cref="Label"/> par le texte saisie par avant.
        ''' </summary>
        Public Sub [Redo](ByVal ControlLabel As Label)
            If _UndoPosition = _UndoAldo.Count - 1 Then

            Else
                _UndoPosition += 1
                ControlLabel.Text = _UndoAldo(_UndoPosition)
            End If
        End Sub
        ''' <summary>
        ''' Efface la liste du UndoRedo.
        ''' </summary>
        Public Sub ClearUndoRedo()
            _UndoAldo.Clear() : _UndoPosition = 0
        End Sub
        ''' <summary>
        ''' Efface la liste du UndoRedo et remet à zéro l'initialisation de la classe.
        ''' </summary>
        Public Sub ClearAll()
            _UndoAldo.Clear() : _UndoPosition = 0
            _ControlType = ""
        End Sub
        ''' <summary>
        ''' Récupère toute la liste du UndoRedo.
        ''' </summary>
        Public Function GetAllList(Optional ByVal textBetween As String = " ") As String
            Dim RetList As String = ""
            For i As Integer = 0 To _UndoAldo.Count - 1
                RetList += _UndoAldo(i) & textBetween
            Next
            Return RetList
        End Function
        ''' <summary>
        ''' Récupère toute la liste du UndoRedo avec la position exacte.
        ''' </summary>
        Public Function GetAllListWithPosition(Optional ByVal textBetween As String = " ") As String
            Dim RetList As String = ""
            For i As Integer = 0 To _UndoAldo.Count - 1
                RetList += i & ": " & _UndoAldo(i) & textBetween
            Next
            Return RetList
        End Function
        ''' <summary>
        ''' Récupère la position actuelle du UndoRedo.
        ''' </summary>
        Public ReadOnly Property GetCurrentPosition As Integer
            Get
                Return _UndoPosition
            End Get
        End Property
        ''' <summary>
        ''' Récupère les positions total de la liste du UndoRedo.
        ''' </summary>
        Public ReadOnly Property GetCurrentUndoRedo As Integer
            Get
                Return _UndoPosition
            End Get
        End Property
    End Class
End Namespace