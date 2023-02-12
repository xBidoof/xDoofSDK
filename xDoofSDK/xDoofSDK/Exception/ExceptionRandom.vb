''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="ExceptionRandom"/>.
''' </summary>
Public Class ExceptionRandom
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
    Public Sub New(ByVal message As String, ByVal e As Exception)
        MyBase.New(message, e)
    End Sub
End Class