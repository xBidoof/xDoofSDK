''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="stringBuilder"/>.
''' </summary>
Public Class stringBuilder

    Private buildedString As Char()
    
    

    Private property_MaxCapacity As Integer = 10

    Public ReadOnly MaxCapacity As Integer = property_MaxCapacity

    Public Sub New()

    End Sub
    ''' <summary>
    ''' Ajoute du String au String à construire.
    ''' </summary>
    Public Sub Append(ByVal value As String, Optional ByVal startIndex As Integer = 0)
        If startIndex = 0 Then
            buildedString += value.ToCharArray
        Else
            If startIndex > buildedString.Length Then

            Else
                If buildedString = Nothing Then
                    buildedString = value.ToCharArray
                Else
                    buildedString(startIndex) += value.ToCharArray
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Récupère le String construit selon les propriétés données.
    ''' </summary>
    Public Function GetBuildString() As String
        Dim retStr As String = ""
        If buildedString = Nothing Then
            Return ""
        Else
            Try
                For i As Integer = 0 To property_MaxCapacity - 1
                    retStr += buildedString(i)
                Next
            Catch : End Try
        End If
        Return retStr
    End Function
    ''' <summary>
    ''' Récupère le nombre total d'élément du String construit.
    ''' </summary>
    Public Function GetTotalLength() As Integer
        If buildedString = Nothing Then
            Return 0
        Else
            Return buildedString.Length
        End If
    End Function
    ''' <summary>
    ''' Assigne la capacité maximum de length à retourné.
    ''' </summary>
    Public Sub SetMaxCapacity(ByVal int As Integer)
        property_MaxCapacity = int
    End Sub
End Class
