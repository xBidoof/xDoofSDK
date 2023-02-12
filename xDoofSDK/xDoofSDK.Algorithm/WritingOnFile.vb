Imports System.Windows.Forms
Imports xDoofSDK

Namespace Algorithm
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="WritingOnFile"/>.
    ''' </summary>
    Public Class WritingOnFile

        Private _pathFile As String = ""
        Private rdContent As New RichTextBox

        Private _state As WOFState

        Public Sub New(pathFile As String)
            _pathFile = pathFile
        End Sub

        Public Sub New(pathFile As String, directStart As Boolean)
            _pathFile = pathFile
            If directStart = True Then
                StartWOF()
            End If
        End Sub

        ''' <summary>
        ''' Démarre le Read/Write.
        ''' </summary>
        Public Function StartWOF() As WOFState
            If FileSystem.FileSystem.FileExists(_pathFile) = False Then
                _state = WOFState.Stopped
            Else
                Try
                    rdContent.Text = FileSystem.FileSystem.ReadFileAllText(_pathFile)
                    _state = WOFState.Started
                Catch ex As Exception
                    _state = WOFState.Stopped
                End Try
            End If
            Return WOFState.Stopped
        End Function
        ''' <summary>
        ''' Stop le Read/Write.
        ''' </summary>
        Public Sub StopWOF()
            _state = WOFState.Stopped
        End Sub
        ''' <summary>
        ''' Retourne le status du WritingOnFile
        ''' </summary>
        Public ReadOnly Property WOFstatus As WOFState
            Get
                Return _state
            End Get
        End Property

        Private Sub WriteFile()
            Try
                FileSystem.FileSystem.WriteFileAllText(_pathFile, rdContent.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Écris du texte dans le fichier.
        ''' </summary>
        Public Sub Write(ByVal text As String)
            If _state = WOFState.Stopped Then Return
            rdContent.AppendText(text)
            WriteFile()
        End Sub
        ''' <summary>
        ''' Écris une nouvelle ligne avec du texte dans le fichier.
        ''' </summary>
        Public Sub WriteNewLine(ByVal text As String)
            If _state = WOFState.Stopped Then Return
            rdContent.AppendText(vbNewLine & text)
            WriteFile()
        End Sub
        ''' <summary>
        ''' Lis et retourne tout le contenu du fichier.
        ''' </summary>
        Public Function Read() As String
            If _state = WOFState.Stopped Then Return ""
            Return rdContent.Text
        End Function
        ''' <summary>
        ''' Lis et retourne le contenu de la ligne spécifié.
        ''' </summary>
        Public Function ReadLine(ByVal index As Integer) As String
            If _state = WOFState.Stopped Then Return ""
            Dim GetLine As String = ""
            Try
                GetLine = rdContent.Lines(index)
            Catch : End Try
            Return GetLine
        End Function
        ''' <summary>
        ''' Supprime la ligne spécifié.
        ''' </summary>
        Public Sub EraseLine(ByVal line As Integer)
            If _state = WOFState.Stopped Then Return
            Dim ReComplete As New RichTextBox
            For i As Integer = 0 To rdContent.Lines.Count - 1
                If line = i Then

                Else
                    ReComplete.AppendText(rdContent.Lines(i) & vbNewLine)
                End If
            Next
            rdContent.Text = ReComplete.Text
            WriteFile()
        End Sub
        ''' <summary>
        ''' Supprime l'ensemble du contenu du fichier.
        ''' </summary>
        Public Sub EraseAll()
            If _state = WOFState.Stopped Then Return
            rdContent.Text = ""
            WriteFile()
        End Sub
        ''' <summary>
        ''' Remplace le texte spécifié par le nouveau texte souhaiter.
        ''' </summary>
        Public Sub ReplaceTo(ByVal textToReplace As String, ByVal newText As String)
            If _state = WOFState.Stopped Then Return
            rdContent.Text = Replace(rdContent.Text, textToReplace, newText)
            WriteFile()
        End Sub
        ''' <summary>
        ''' Inverse toute les lignes du fichier.
        ''' </summary>
        Public Sub ReverseLines()
            If _state = WOFState.Stopped Then Return
            Dim ReComplete As New RichTextBox
            For i As Integer = rdContent.Lines.Count - 1 To 0 Step -1
                If i = 0 Then
                    ReComplete.AppendText(rdContent.Lines(i))
                Else
                    ReComplete.AppendText(rdContent.Lines(i) & vbNewLine)
                End If
            Next
            rdContent.Text = ReComplete.Text
            WriteFile()
        End Sub
        ''' <summary>
        ''' Récupère et retourne toute les lignes.
        ''' </summary>
        Public Function GetAllLines() As String()
            If _state = WOFState.Stopped Then Return Nothing
            Return rdContent.Lines
        End Function
    End Class
End Namespace
