''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="RandomString"/>.
''' </summary>
Public Class RandomString

    Public Sub New()

    End Sub
    ''' <summary>
    ''' Retourne un caractère aléatoire de <see cref="String"/>.
    ''' </summary>
    Public Shared Function [NextString]() As String
        Dim listString As Char() = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray
        Dim rdm As New Random(), sResult As String = ""
        For i As Integer = 0 To 0
            sResult += listString(rdm.Next(0, listString.Length))
        Next
        Return sResult
    End Function
    ''' <summary>
    ''' Retourne un ou plusieurs caractère aléatoire de <see cref="String"/> selon le nombre de caractères demandée.
    ''' </summary>
    Public Shared Function [NextString](ByVal numberString As Integer) As String
        Dim listString As Char() = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray
        Dim rdm As New Random(), sResult As String = ""
        For i As Integer = 0 To numberString - 1
            sResult += listString(rdm.Next(0, listString.Length))
        Next
        Return sResult
    End Function
    ''' <summary>
    ''' Retourne un ou plusieurs caractère aléatoire de la liste <see cref="String"/> spécifié et retourne un nombre de caractères selon le nombre de caractères demandée.
    ''' </summary>
    Public Shared Function [NextString](ByVal listString As String, ByVal numberString As Integer) As String
        Dim list As Char() = listString.ToCharArray
        Dim rdm As New Random(), sResult As String = ""
        For i As Integer = 0 To numberString - 1
            sResult += list(rdm.Next(0, list.Length))
        Next
        Return sResult
    End Function
    ''' <summary>
    ''' Retourne un ou plusieurs caractère aléatoire de la liste <see cref="String()"/> spécifié et retourne un nombre de caractères selon le nombre de caractères demandée.
    ''' </summary>
    Public Shared Function [NextString](ByVal listString As String(), ByVal numberString As Integer) As String
        Dim rdm As New Random(), sResult As String = ""
        For i As Integer = 0 To numberString - 1
            sResult += listString(rdm.Next(0, listString.Length))
        Next
        Return sResult
    End Function
End Class
