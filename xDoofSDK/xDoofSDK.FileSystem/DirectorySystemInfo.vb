Namespace FileSystem
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="DirectorySystemInfo"/>.
    ''' </summary>
    Public Class DirectorySystemInfo

        Private mPath As String
        Public Sub New(ByVal path As String)
            Me.mPath = path
        End Sub

        Public ReadOnly Property GetFullPath As String
            Get
                Return mPath
            End Get
        End Property
        Public ReadOnly Property GetName As String
            Get
                Dim SplitPath As String() = Split(mPath, "\")
                Return SplitPath(SplitPath.Length - 1)
            End Get
        End Property

        Public ReadOnly Property Exist As Boolean
            Get
                If DirectorySystem.DirectoryExists(mPath) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public ReadOnly Property SplitPath(ByVal SeperatorSens As String) As String()
            Get
                Return Split(mPath, SeperatorSens)
            End Get
        End Property
    End Class
End Namespace