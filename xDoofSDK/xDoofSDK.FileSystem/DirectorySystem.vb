Imports System.IO

Namespace FileSystem
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="DirectorySystem"/>.
    ''' </summary>
    Public Class DirectorySystem
        ''' <summary>
        ''' Créé un dossier.
        ''' </summary>
        Public Shared Sub CreateDirectory(ByVal path As String)
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            Else
                Try
                    Directory.CreateDirectory(path)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Créé une liste de dossier(s) spécifié.
        ''' </summary>
        Public Shared Sub CreateDirectoryList(ByVal path As String())
            If path Is Nothing Then
            ElseIf path.Length = 0 Then
            Else
                Try
                    For i As Integer = 0 To path.Length - 1
                        Try
                            Directory.CreateDirectory(path(i))
                        Catch : End Try
                    Next
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Supprime le dossier spécifié.
        ''' </summary>
        Public Shared Sub [DeleteDirectory](ByVal path As String)
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            Else
                Try
                    Directory.Delete(path)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Supprime une liste de dossier(s) spécifié.
        ''' </summary>
        Public Shared Sub [DeleteDirectoryList](ByVal path As String())
            If path Is Nothing Then
            ElseIf path.Length = 0 Then
            Else
                Try
                    For i As Integer = 0 To path.Length - 1
                        Try
                            Directory.Delete(path(i))
                        Catch : End Try
                    Next
                Catch : End Try
            End If
        End Sub

        ''' <summary>
        ''' Supprime le dossier spécifié et tout les sous-répertoires.
        ''' </summary>
        Public Shared Sub [DeleteDirectory](ByVal path As String, ByVal deleteContent As Boolean)
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            Else
                Try
                    Directory.Delete(path, deleteContent)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Supprime une liste de dossier(s) spécifié et tout les sous-répertoires.
        ''' </summary>
        Public Shared Sub [DeleteDirectoryList](ByVal path As String(), ByVal deleteContent As Boolean())
            If path Is Nothing Then
            ElseIf path.Length = 0 Then
            Else
                Try
                    For i As Integer = 0 To path.Length - 1
                        Try
                            Directory.Delete(path(i), deleteContent(i))
                        Catch : End Try
                    Next
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Vérifie si le dossier spécifié existe.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si existant, False dans le cas contraire.</returns>
        Public Shared Function DirectoryExists(ByVal path As String) As Boolean
            If path = Nothing Then : Return False
            ElseIf path.Length = 0 Then : Return False
            Else
                Try
                    Return Directory.Exists(path)
                Catch : Return False : End Try
            End If
        End Function
        ''' <summary>
        ''' Renomme le dossier spécifié.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si renommer, False dans le cas contraire.</returns>
        Public Shared Function DirectoryRename(ByVal path As String, ByVal newName As String) As Boolean
            If path = Nothing Then : Return False
            ElseIf path.Length = 0 Then : Return False
            ElseIf newName = Nothing Then : Return False
            ElseIf newName.Length = 0 Then : Return False
            ElseIf DirectoryExists(path) = False Then : Return False
            Else
                Try
                    My.Computer.FileSystem.RenameDirectory(path, newName)
                    Return True
                Catch : Return False : End Try
            End If
        End Function
        ''' <summary>
        ''' Renomme une liste de dossier(s) spécifié.
        ''' </summary>
        Public Shared Sub DirectoryRenameList(ByVal path As String(), ByVal newName As String())
            If path Is Nothing Then
            ElseIf path.Length = 0 Then
            ElseIf newName Is Nothing Then
            ElseIf newName.Length = 0 Then
            Else
                Try
                    For i As Integer = 0 To path.Length - 1
                        If DirectoryExists(path(i)) Then
                            Try
                                My.Computer.FileSystem.RenameDirectory(path(i), newName(i))
                            Catch : End Try
                        End If
                    Next
                Catch : End Try
            End If
        End Sub
    End Class

End Namespace