Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Namespace FileSystem
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="FileSystem"/>.
    ''' </summary>
    Public Class FileSystem
        ''' <summary>
        ''' Lit tout le contenu du fichier spécifié.
        ''' </summary>
        Public Shared Function ReadFileAllText(ByVal path As String) As String
            Try
                Return File.ReadAllText(path)
            Catch : Return "" : End Try
        End Function
        ''' <summary>
        ''' Lit tout les lignes du fichier spécifié.
        ''' </summary>
        Public Shared Function ReadFileAllLines(ByVal path As String) As String()
            Try
                Return File.ReadAllLines(path)
            Catch : Return Nothing : End Try
        End Function
        ''' <summary>
        ''' Lit tout le contenu du fichier dans un tableau d'octets.
        ''' </summary>
        Public Shared Function ReadFileAllBytes(ByVal path As String) As Byte()
            Try
                Return File.ReadAllBytes(path)
            Catch : Return Nothing : End Try
        End Function
        ''' <summary>
        ''' Créé un fichier et ajoute le contenu dans ce fichier.
        ''' </summary>
        Public Shared Sub WriteFileAllText(ByVal path As String, ByVal contents As String)
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            ElseIf contents.Length = Nothing Then
            ElseIf contents.Length = 0 Then
            Else
                Try
                    File.WriteAllText(path, contents)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Créé un fichier et ajoute le contenu dans ce fichier.
        ''' </summary>
        Public Shared Sub WriteFileAllLines(ByVal path As String, ByVal contents As String())
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            ElseIf contents.Length = Nothing Then
            ElseIf contents.Length = 0 Then
            Else
                Try
                    File.WriteAllLines(path, contents)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Créé un fichier et ajoute le tableau d'octets dans ce fichier.
        ''' </summary>
        Public Shared Sub WriteFileAllBytes(ByVal path As String, ByVal contents As Byte())
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            ElseIf contents.Length = Nothing Then
            ElseIf contents.Length = 0 Then
            Else
                Try
                    File.WriteAllBytes(path, contents)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Lit et ajoute des lignes dans le fichier spécifié.
        ''' </summary>
        Public Shared Sub AddFileLines(ByVal path As String, ByVal contents As String())
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            ElseIf contents.Length = Nothing Then
            ElseIf contents.Length = 0 Then
            Else
                Try
                    Dim ReadFile As String = ReadFileAllText(path)
                    For i As Integer = 0 To contents.Length - 1
                        If i = contents.Length - 1 Then
                            ReadFile += contents(i)
                        Else
                            ReadFile += contents(i) & vbNewLine
                        End If
                    Next
                    File.WriteAllText(path, ReadFile)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Lit et ajoute le contenu dans le fichier spécifié.
        ''' </summary>
        Public Shared Sub AddFileText(ByVal path As String, ByVal contents As String)
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            ElseIf contents.Length = Nothing Then
            ElseIf contents.Length = 0 Then
            Else
                Try
                    Dim ReadFile As String = ReadFileAllText(path)
                    ReadFile += contents
                    File.WriteAllText(path, ReadFile)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Supprime le fichier spécifié si possible.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si supprimé, False dans le cas contraire.</returns>
        Public Shared Function [DeleteFile](ByVal path As String) As Boolean
            If path = Nothing Then : Return False
            ElseIf path.Length = 0 Then : Return False
            Else
                Try
                    File.Delete(path) : Return True
                Catch : Return False : End Try
            End If
        End Function
        ''' <summary>
        ''' Supprime une liste de fichiers spécifié si possible.
        ''' </summary>
        Public Shared Sub DeleteFileList(ByVal path As List(Of String))
            If path Is Nothing Then
            Else
                Try
                    For i As Integer = 0 To path.Count - 1
                        Try
                            DeleteFile(path(i))
                        Catch : End Try
                    Next
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Supprime une liste String() de fichiers spécifié si possible.
        ''' </summary>
        Public Shared Sub DeleteFileArray(ByVal path As String())
            If path Is Nothing Then
            Else
                Try
                    For i As Integer = 0 To path.Length - 1
                        Try
                            DeleteFile(path(i))
                        Catch : End Try
                    Next
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Permet d'échanger un fichier d'emplacement contre un autre fichier ainsi que son contenu.
        ''' </summary>
        Public Shared Sub ExchangeFile(ByVal pathFileOne As String, ByVal pathFileTwo As String)
            If pathFileOne = Nothing Then
            ElseIf pathFileOne.Length = 0 Then
            ElseIf pathFileTwo = Nothing Then
            ElseIf pathFileTwo.Length = 0 Then
            ElseIf FileExists(pathFileOne) = False Then
            ElseIf FileExists(pathFileTwo) = False Then
            Else
                Try
                    Dim GetFileOne As String = ReadFileAllText(pathFileOne)
                    Dim GetFileTwo As String = ReadFileAllText(pathFileTwo)
                    Dim BuildPath As String = pathFileOne
                    BuildPath = Replace(BuildPath, Path.GetFileName(pathFileOne), "")
                    BuildPath += Path.GetFileName(pathFileTwo)
                    WriteFileAllText(BuildPath, GetFileTwo)
                    BuildPath = pathFileTwo
                    BuildPath = Replace(BuildPath, Path.GetFileName(pathFileTwo), "")
                    BuildPath += Path.GetFileName(pathFileOne)
                    WriteFileAllText(BuildPath, GetFileOne)
                    DeleteFileArray({pathFileOne, pathFileTwo})
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Permet d'échanger le contenu du premier fichier spécifié avec le deuxième fichier spécifié.
        ''' </summary>
        Public Shared Sub ExchangeFileContents(ByVal pathFileOne As String, ByVal pathFileTwo As String)
            If pathFileOne = Nothing Then
            ElseIf pathFileOne.Length = 0 Then
            ElseIf pathFileTwo = Nothing Then
            ElseIf pathFileTwo.Length = 0 Then
            ElseIf FileExists(pathFileOne) = False Then
            ElseIf FileExists(pathFileTwo) = False Then
            Else
                Try
                    Dim GetFileOne As String = ReadFileAllText(pathFileOne)
                    Dim GetFileTwo As String = ReadFileAllText(pathFileTwo)
                    WriteFileAllText(pathFileOne, GetFileTwo)
                    WriteFileAllText(pathFileTwo, GetFileOne)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Vérifie si le fichier spécifié existe.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si existant, False dans le cas contraire.</returns>
        Public Shared Function FileExists(ByVal path As String) As Boolean
            If path = Nothing Then : Return False
            ElseIf path.Length = 0 Then : Return False
            Else
                Try
                    If File.Exists(path) Then Return True
                    Return False
                Catch : Return False : End Try
            End If
        End Function
        ''' <summary>
        ''' Copie le fichier vers un nouveau chemin.
        ''' </summary>
        Public Shared Sub CopyFile(ByVal path As String, ByVal newPath As String)
            If path = Nothing Then
            ElseIf path.Length = 0 Then
            ElseIf newPath.Length = Nothing Then
            ElseIf newPath.Length = 0 Then
            ElseIf FileExists(path) = False Then
            Else
                Try
                    WriteFileAllText(newPath, ReadFileAllText(path))
                Catch : End Try
            End If
        End Sub

        Public Enum FileToDelete
            [First]
            [Second]
            [All]
            [Nothing]
        End Enum
        ''' <summary>
        ''' Assemble deux fichiers et créé le fichier assembler dans le chemin d'accès spécifié.
        ''' </summary>
        Public Shared Sub AssemblingFile(ByVal pathFileOne As String, ByVal pathFileTwo As String, ByVal newPath As String, ByVal deleteFileOptions As FileToDelete)
            If pathFileOne = Nothing Then
            ElseIf pathFileOne.Length = 0 Then
            ElseIf pathFileTwo.Length = Nothing Then
            ElseIf pathFileTwo.Length = 0 Then
            ElseIf newPath.Length = Nothing Then
            ElseIf newPath.Length = 0 Then
            ElseIf FileExists(pathFileOne) = False Then
            ElseIf FileExists(pathFileTwo) = False Then
            Else
                Try
                    WriteFileAllText(newPath, ReadFileAllText(pathFileOne) & ReadFileAllText(pathFileTwo))
                    If deleteFileOptions = FileToDelete.First Then
                        DeleteFile(pathFileOne)
                    ElseIf deleteFileOptions = FileToDelete.Second Then
                        DeleteFile(pathFileTwo)
                    ElseIf deleteFileOptions = FileToDelete.All Then
                        DeleteFile(pathFileOne) : DeleteFile(pathFileTwo)
                    ElseIf deleteFileOptions = FileToDelete.Nothing Then

                    End If
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Lit et ajoute le contenu dans le fichier spécifié et retourne le <see cref="String"/> des deux fichiers assemblé.
        ''' </summary>
        Public Shared Function AssemblingFileWithReturn(ByVal pathFileOne As String, ByVal pathFileTwo As String, ByVal newPath As String, ByVal deleteFileOptions As FileToDelete) As String
            If pathFileOne = Nothing Then
                Return False
            ElseIf pathFileOne.Length = 0 Then
                Return False
            ElseIf pathFileTwo.Length = Nothing Then
                Return False
            ElseIf pathFileTwo.Length = 0 Then
                Return False
            ElseIf newPath.Length = Nothing Then
                Return False
            ElseIf newPath.Length = 0 Then
                Return False
            ElseIf FileExists(pathFileOne) = False Then
                Return False
            ElseIf FileExists(pathFileTwo) = False Then
                Return False
            Else
                Try
                    WriteFileAllText(newPath, ReadFileAllText(pathFileOne) & ReadFileAllText(pathFileTwo))
                    If deleteFileOptions = FileToDelete.First Then
                        DeleteFile(pathFileOne)
                    ElseIf deleteFileOptions = FileToDelete.Second Then
                        DeleteFile(pathFileTwo)
                    ElseIf deleteFileOptions = FileToDelete.All Then
                        DeleteFile(pathFileOne) : DeleteFile(pathFileTwo)
                    ElseIf deleteFileOptions = FileToDelete.Nothing Then

                    End If
                    Return True
                Catch : Return False : End Try
            End If
        End Function
        ''' <summary>
        ''' Renomme le fichier spécifié par un nouveau nom.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si renommer, False dans le cas contraire.</returns>
        Public Shared Function RenameFile(ByVal pathFile As String, ByVal newName As String) As Boolean
            If pathFile = Nothing Then : Return False
            ElseIf pathFile.Length = 0 Then : Return False
            ElseIf newName.Length = Nothing Then : Return False
            ElseIf newName.Length = 0 Then : Return False
            ElseIf FileExists(pathFile) = False Then : Return False
            Else
                Try
                    Dim GetExt As String = Path.GetExtension(pathFile)
                    pathFile = Replace(pathFile, Path.GetFileName(pathFile), "")
                    pathFile += newName + GetExt
                    My.Computer.FileSystem.RenameFile(pathFile, pathFile)
                    Return True
                Catch : Return False : End Try
            End If
        End Function
        ''' <summary>
        ''' Récupère et retourne l'icône associé au fichier.
        ''' </summary><returns>Retourne Nothing en cas d'erreur</returns>
        Public Shared Function GetAssociedIcon(ByVal pathFile As String) As Icon
            Try
                Return Icon.ExtractAssociatedIcon(pathFile)
            Catch
                Return Nothing
            End Try
        End Function
        ''' <summary>
        ''' Récupère et sauvegarde l'icône associé au fichier dans un fichier ".ico".
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si sauvegarder, False dans le cas contraire.</returns>
        Public Shared Function SaveAssociedIcon(ByVal pathFile As String, ByVal outPathFolder As String, ByVal nameFile As String, Optional dispose As Boolean = True) As Boolean
            Try
                Dim getIcon As Icon = Icon.ExtractAssociatedIcon(pathFile)
                Dim ms As New MemoryStream()
                getIcon.Save(ms)
                File.WriteAllBytes(outPathFolder & "\" & nameFile & ".ico", ms.ToArray())
                If dispose Then
                    ms.Dispose()
                    getIcon.Dispose()
                End If
                Return True
            Catch
                Return False
            End Try
        End Function
    End Class
End Namespace
