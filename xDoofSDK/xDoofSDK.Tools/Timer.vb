Imports xDoofSDK

Namespace Tools
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="Timer"/>.
    ''' </summary>
    Public Class Timer

        Private _stWtch As New Stopwatch

        Public Sub New()

        End Sub

        Public Sub New(directStart As Boolean)
            If directStart = True Then
                StartTimer()
            End If
        End Sub
        ''' <summary>
        ''' Lance le chronomètre.
        ''' </summary>
        Public Sub StartTimer()
            _stWtch.Start()
        End Sub
        ''' <summary>
        ''' Stop le chronomètre.
        ''' </summary>
        Public Sub StopTimer()
            _stWtch.Stop()
        End Sub
        ''' <summary>
        ''' Redémarre le chronomètre.
        ''' </summary>
        Public Sub RestartTimer()
            _stWtch.Restart()
        End Sub
        ''' <summary>
        ''' Retourne le temps écoulé en millisecondes.
        ''' </summary>
        ReadOnly Property GetResult As Long
            Get
                Return _stWtch.ElapsedMilliseconds
            End Get
        End Property
    End Class
End Namespace
