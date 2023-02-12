Imports System.Windows.Forms

Namespace MessageBoxSystem
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="MessageBoxBuilder"/>.
    ''' </summary>
    Public Class MessageBoxBuilder

        Private _message As String
        Private _title As String
        Private _Icon As IconMessageBox
        Private _button As ButtonMessageBox
        Public Sub New()

        End Sub
        Public Sub New(ByVal message As String)
            _message = message
        End Sub

        Public Sub New(ByVal message As String, ByVal title As String)
            _message = message
            _title = title
        End Sub

        Public Sub New(ByVal message As String, ByVal title As String, ByVal icon As IconMessageBox, ByVal button As ButtonMessageBox)
            _message = message
            _title = title
            _Icon = icon
            _button = button
        End Sub
        ''' <summary>
        ''' Affiche le message construit.
        ''' </summary>
        Public Sub Show()
            Dim mBoxButt As MessageBoxButtons
            Dim mBoxicon As MessageBoxIcon
            If _Icon = &HF00A Then
                mBoxicon = MessageBoxIcon.Error
            ElseIf _Icon = &HF00B Then
                mBoxicon = MessageBoxIcon.Warning
            ElseIf _Icon = &HF00C Then
                mBoxicon = MessageBoxIcon.Question
            ElseIf _Icon = &HF00D Then
                mBoxicon = MessageBoxIcon.Information
            Else
                mBoxicon = MessageBoxIcon.Error
            End If

            If _button = &HFB00A Then
                mBoxButt = MessageBoxButtons.OK
            ElseIf _button = &HFB00B Then
                mBoxButt = MessageBoxButtons.OKCancel
            ElseIf _button = &HFB00C Then
                mBoxButt = MessageBoxButtons.YesNo
            Else
                mBoxButt = MessageBoxButtons.OK
            End If
            MessageBox.Show(_message, _title, mBoxButt, mBoxicon)
        End Sub
        ''' <summary>
        ''' Spécifie la construction à <see cref="MessageBoxBuilder"/> et créé le message.
        ''' </summary>
        Public Sub CreateMessage(ByVal message As String, ByVal title As String, ByVal icon As IconMessageBox, ByVal button As ButtonMessageBox)
            _message = message
            _title = title
            _Icon = icon
            _button = button
        End Sub
    End Class
End Namespace

Public Enum IconMessageBox
    [Error] = &HF00A
    [Warning] = &HF00B
    [Question] = &HF00C
    [Information] = &HF00D
End Enum

Public Enum ButtonMessageBox
    [Ok] = &HFB00A
    [OkCancel] = &HFB00B
    [YesNo] = &HFB00C
End Enum
