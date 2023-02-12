Namespace FileSystem

    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="FileSystemInfo"/>.
    ''' </summary>
    Public Class FileSystemInfo

        ''' <summary>
        ''' Fournit le séparateur de gauche '\'.
        ''' </summary>
        Public Shared ReadOnly SeperatorLeft As String = "\"
        ''' <summary>
        ''' Fournit le séparateur de droite '/'.
        ''' </summary>
        Public Shared ReadOnly SeperatorRight As String = "/"
        ''' <summary>
        ''' Fournit la liste des caractères interdit d'un nom de fichier.
        ''' </summary>
        Public Shared ReadOnly InvalidCharacterFile As String = "/\:*?""<>|"
        ''' <summary>
        ''' Fournit la liste en Char() des caractères interdit d'un nom de fichier.
        ''' </summary>
        Public Shared ReadOnly InvalidCharacterFileChar As Char() = {"/", "\", ":", "*", "?", """", "<", ">", "|"}
        ''' <summary>
        ''' Fournit la liste des caractères interdit d'un nom de dossier.
        ''' </summary>
        Public Shared ReadOnly InvalidCharacterDirectory As String = "/\:*?""<>|"
        ''' <summary>
        ''' Fournit la liste en Char() des caractères interdit d'un nom de dossier.
        ''' </summary>
        Public Shared ReadOnly InvalidCharacterDirectoryChar As Char() = {"/", "\", ":", "*", "?", """", "<", ">", "|"}
        ''' <summary>
        ''' Récupère le nom et l'extension du fichier spécifié.
        ''' </summary>
        Public Shared Function GetFileName(ByVal pathFile As String) As String
            If pathFile = Nothing Then : Return ""
            ElseIf pathFile.Length = 0 Then : Return ""
            Else
                Try
                    Dim BuildFileName As String = ""
                    For i As Integer = pathFile.Length - 1 To 0 Step -1
                        If pathFile(i) = "\" Or pathFile(i) = "/" Then
                            Exit For
                        Else
                            BuildFileName += pathFile(i)
                        End If
                    Next
                    Dim RetStr As String = ""
                    Dim StrCh As Char() = BuildFileName.ToCharArray()
                    For i As Integer = StrCh.Length - 1 To 0 Step -1
                        RetStr += StrCh(i)
                    Next
                    Return RetStr
                Catch : Return "" : End Try
            End If
        End Function
        ''' <summary>
        ''' Récupère le nom sans l'extension du fichier spécifié.
        ''' </summary>
        Public Shared Function GetFileNameWithoutExtension(ByVal pathFile As String) As String
            If pathFile = Nothing Then : Return ""
            ElseIf pathFile.Length = 0 Then : Return ""
            Else
                Try
                    Dim BuildFileName As String = ""
                    Dim isAlreadyDelete As Boolean = False
                    For i As Integer = pathFile.Length - 1 To 0 Step -1
                        If pathFile.Chars(i) = "." Then
                            If isAlreadyDelete = False Then
                                isAlreadyDelete = True
                                BuildFileName = ""
                            Else
                                BuildFileName += pathFile.Chars(i)
                            End If
                        Else
                            If pathFile.Chars(i) = "\" Or pathFile.Chars(i) = "/" Then
                                Exit For
                            Else
                                BuildFileName += pathFile.Chars(i)
                            End If
                        End If
                    Next
                    Dim RetStr As String = ""
                    Dim StrCh As Char() = BuildFileName.ToCharArray()
                    For i As Integer = StrCh.Length - 1 To 0 Step -1
                        RetStr += StrCh(i)
                    Next
                    Return RetStr
                Catch : Return "" : End Try
            End If
        End Function
        ''' <summary>
        ''' Récupère l'extension du fichier spécifié.
        ''' </summary>
        Public Shared Function GetFileExtension(ByVal pathFile As String) As String
            If pathFile = Nothing Then : Return ""
            ElseIf pathFile.Length = 0 Then : Return ""
            Else
                Try
                    Dim BuildFileExtension As String = ""
                    For i As Integer = pathFile.Length - 1 To 0 Step -1
                        If pathFile.Chars(i) = "." Then
                            BuildFileExtension += pathFile.Chars(i) : Exit For
                        Else
                            BuildFileExtension += pathFile.Chars(i)
                        End If
                    Next
                    Dim RetStr As String = ""
                    Dim StrCh As Char() = BuildFileExtension.ToCharArray()
                    For i As Integer = StrCh.Length - 1 To 0 Step -1
                        RetStr += StrCh(i)
                    Next
                    Return RetStr
                Catch : Return "" : End Try
            End If
        End Function
        ''' <summary>
        ''' Récupère le nom ainsi que le chemin complet d'un fichier spécifié.
        ''' </summary>
        Public Shared Function GetFilePathDirectoryLocalisation(ByVal pathFile As String) As String
            If pathFile = Nothing Then : Return ""
            ElseIf pathFile.Length = 0 Then : Return ""
            Else
                Try
                    Dim BuildFileName As String = "" : Dim RetStr As String = ""
                    For i As Integer = pathFile.Length - 1 To 0 Step -1
                        If pathFile.Chars(i) = "\" Or pathFile.Chars(i) = "/" Then
                            BuildFileName += pathFile.Chars(i) : Exit For
                        Else
                            BuildFileName += pathFile.Chars(i)
                        End If
                    Next
                    Dim StrCh As Char() = BuildFileName.ToCharArray()
                    For i As Integer = StrCh.Length - 1 To 0 Step -1
                        RetStr += StrCh(i)
                    Next
                    pathFile = Replace(pathFile, RetStr, "")
                    Return pathFile
                Catch : Return "" : End Try
            End If
        End Function
        ''' <summary>
        ''' Récupère seulement le nom du dossier ou le fichier spécifié est entreposer.
        ''' </summary>
        Public Shared Function GetFilePathDirectoryNameLocalisation(ByVal pathFile As String) As String
            If pathFile = Nothing Then : Return ""
            ElseIf pathFile.Length = 0 Then : Return ""
            Else
                Try
                    Dim BuildFileName As String = ""
                    For i As Integer = pathFile.Length - 1 To 0 Step -1
                        If pathFile.Chars(i) = "\" Or pathFile.Chars(i) = "/" Then
                            BuildFileName += pathFile.Chars(i) : Exit For
                        Else
                            BuildFileName += pathFile.Chars(i)
                        End If
                    Next
                    Dim RetStr As String = ""
                    Dim StrCh As Char() = BuildFileName.ToCharArray()
                    For i As Integer = StrCh.Length - 1 To 0 Step -1
                        RetStr += StrCh(i)
                    Next
                    pathFile = Replace(pathFile, RetStr, "")
                    BuildFileName = ""
                    For i As Integer = pathFile.Length - 1 To 0 Step -1
                        If pathFile.Chars(i) = "\" Or pathFile.Chars(i) = "/" Then
                            Exit For
                        Else
                            BuildFileName += pathFile.Chars(i)
                        End If
                    Next
                    Dim RetStr2 As String = ""
                    Dim StrCh2 As Char() = BuildFileName.ToCharArray()
                    For i As Integer = StrCh2.Length - 1 To 0 Step -1
                        RetStr2 += StrCh2(i)
                    Next
                    Return RetStr2
                Catch : Return "" : End Try
            End If
        End Function
        ''' <summary>
        ''' Analyse si le nom du fichier saisie est un nom valide
        ''' </summary><returns>Retourne True si valide, False dans le cas contraire</returns>
        Public Shared Function IsValidFileName(name As String, Optional ByVal ignoreExtension As Boolean = False) As Boolean
            If ignoreExtension Then
                For i = 0 To InvalidCharacterFileChar.Length - 1
                    If name.Contains(InvalidCharacterFileChar(i)) Then
                        Return False
                    End If
                Next
                Return True
            Else
                name = name.Replace(GetFileExtension(name), "")
                For i = 0 To InvalidCharacterFileChar.Length - 1
                    If name.Contains(InvalidCharacterFileChar(i)) Then
                        Return False
                    End If
                Next
                Return True
            End If
        End Function
    End Class
End Namespace
