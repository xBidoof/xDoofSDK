''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="RandomInt"/>.
''' </summary>
Public Class RandomInt

    Public Sub New()

    End Sub
    ''' <summary>
    ''' Retourne un <see cref="Integer"/> négative.
    ''' </summary>
    Public Shared Function NextIntNegative() As Integer
        Dim isR As New Random
        Return isR.Next(-2147483648, -1)
    End Function
    ''' <summary>
    ''' Retourne un <see cref="Integer"/> positive.
    ''' </summary>
    Public Shared Function NextIntPositive() As Integer
        Dim isR As New Random
        Return isR.Next(1, 2147483647)
    End Function
    ''' <summary>
    ''' Retourne un <see cref="Integer"/> entre le minimum et le maximum d'un <see cref="Int32"/>.
    ''' </summary>
    Public Shared Function [NextInt]() As Integer
        Dim isR As New Random
        Return isR.Next(-2147483648, 2147483647)
    End Function
    ''' <summary>
    ''' Retourne un <see cref="Integer"/> aléatoire entre 0 et la valeur spécifié.
    ''' </summary>
    Public Shared Function [NextInt](ByVal maximumValue As String) As Integer
        Dim isR As New Random
        Return isR.Next(0, maximumValue)
    End Function
    ''' <summary>
    ''' Retourne un <see cref="Integer"/> aléatoire entre la valeur minimum et la valeur maximum spécifié.
    ''' </summary>
    Public Shared Function [NextInt](ByVal minimumValue As Integer, ByVal maximumValue As Integer) As Integer
        Dim isR As New Random
        If minimumValue > maximumValue Then
            Return 0
        End If
        Return isR.Next(minimumValue, maximumValue)
    End Function
End Class
