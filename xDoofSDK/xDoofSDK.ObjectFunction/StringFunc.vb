Imports System.Net
Imports System.Windows.Forms
''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="StringFunc"/>, utilisation de cette classe avec <see cref="String"/>.
''' </summary>
Public Class StringFunc

    ''' <summary>
    ''' Liste des caractères de l'alphabet en minuscule.
    ''' </summary>
    Public Shared ReadOnly CharMin As String() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
    ''' <summary>
    ''' Liste des caractères de l'alphabet en majuscule.
    ''' </summary>
    Public Shared ReadOnly CharMaj As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

    ''' <summary>
    ''' Liste des caractères de l'alphabet en minuscule, accent y compris.
    ''' </summary>
    Public Shared ReadOnly CharMinSpecialChars As String() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "é", "è", "à"}
    ''' <summary>
    ''' Liste des caractères de l'alphabet en majuscule, accent y compris.
    ''' </summary>
    Public Shared ReadOnly CharMajSpecialChars As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "É", "È", "À"}

    ''' <summary>
    ''' Remplace les majuscules dans le texte en minuscule.
    ''' </summary>
    Public Shared Function ToUpper(ByVal text As String) As String
        Dim FinalText As String = text
        For ii As Integer = 0 To CharMaj.Length - 1
            FinalText = Replace(FinalText, CharMin(ii), CharMaj(ii))
        Next
        Return FinalText
    End Function
    ''' <summary>
    ''' Remplace les majuscules dans le texte en minuscule.
    ''' </summary>
    Public Shared Function ToLower(ByVal text As String) As String
        Dim FinalText As String = text
        For ii As Integer = 0 To CharMaj.Length - 1
            FinalText = Replace(FinalText, CharMaj(ii), CharMin(ii))
        Next
        Return FinalText
    End Function
    ''' <summary>
    ''' Remplace les majuscules dans le texte en minuscule ainsi que les caractères spéciaux tels que é / è / à.
    ''' </summary>
    Public Shared Function ToUpperSpecialsChars(ByVal text As String) As String
        Dim FinalText As String = text
        For ii As Integer = 0 To CharMajSpecialChars.Length - 1
            FinalText = Replace(FinalText, CharMinSpecialChars(ii), CharMajSpecialChars(ii))
        Next
        Return FinalText
    End Function
    ''' <summary>
    ''' Remplace les majuscules dans le texte en minuscule ainsi que les caractères spéciaux tels que É / È / À.
    ''' </summary>
    Public Shared Function ToLowerSpecialsChars(ByVal text As String) As String
        Dim FinalText As String = text
        For ii As Integer = 0 To CharMajSpecialChars.Length - 1
            FinalText = Replace(FinalText, CharMajSpecialChars(ii), CharMinSpecialChars(ii))
        Next
        Return FinalText
    End Function
    ''' <summary>
    ''' Inverse le texte spécifié.
    ''' </summary>
    Public Shared Function ReverseText(ByVal text As String) As String
        Dim FinalText As String = ""
        For i As Integer = text.Length - 1 To 0 Step -1
            FinalText += text(i)
        Next
        Return FinalText
    End Function
    ''' <summary>
    ''' Recherche du texte dans le texte saisie, retourne True si trouvé, False si non trouvé.
    ''' </summary>
    Public Shared Function Find(ByVal text As String, ByVal textToFind As String) As Boolean
        Dim RetFind As Integer = text.IndexOf(textToFind)
        If RetFind = -1 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Recherche le premier caractère en ignorant les espaces et retourne le caractère.
    ''' </summary>
    Public Shared Function FindFirstChar(ByVal stringText As String) As Char
        For Each c As Char In stringText
            If c = " " Then

            Else
                Return c
            End If
        Next
        Return ""
    End Function
    ''' <summary>
    ''' Recherche le dernier caractère en ignorant les espaces et retourne le caractère.
    ''' </summary>
    Public Shared Function FindLastChar(ByVal stringText As String) As Char
        For Each c As Char In stringText.Reverse
            If c = " " Then

            Else
                Return c
            End If
        Next
        Return ""
    End Function
    ''' <summary>
    ''' Recherche et retourne le texte trouver entre le <see cref="Char"/> du début et le <see cref="Char"/> de fin.
    ''' </summary>
    Public Shared Function FindPattern(ByVal stringText As String, ByVal startChar As Char, ByVal endChar As String) As String
        Dim retPattern As String = ""
        Dim started = False
        For Each ctr As Char In stringText
            If ctr = endChar And started = True Then
                started = False
                Exit For
            End If
            If started Then
                retPattern += ctr
            End If
            If ctr = startChar Then
                started = True
            End If
        Next
        Return retPattern
    End Function
    ''' <summary>
    ''' Retire les espaces blanc du début d'une ligne.
    ''' </summary>
    Public Shared Function RemoveStartBlankSpaces(ByVal stringText As String) As String
        Dim alreadyFound As Boolean = False
        Dim reBuild As String = ""
        For Each c As Char In stringText
            If c = " " Then
                If alreadyFound = True Then
                    reBuild += c
                End If
            Else
                alreadyFound = True
                reBuild += c
            End If
        Next
        Return reBuild
    End Function

    ''' <summary>
    ''' Retire les espaces blanc de la fin d'une ligne.
    ''' </summary>
    Public Shared Function RemoveEndBlankSpaces(ByVal stringText As String) As String
        Dim alreadyFound As Boolean = False
        Dim reBuild As String = ""
        For Each c As Char In stringText.Reverse
            If c = " " Then
                If alreadyFound = True Then
                    reBuild += c
                End If
            Else
                alreadyFound = True
                reBuild += c
            End If
        Next
        Return ReverseText(reBuild)
    End Function

    ''' <summary>
    ''' Retire les espaces blanc du début d'une ligne et de la fin.
    ''' </summary>
    Public Shared Function RemoveStartEndBlankSpaces(ByVal stringText As String) As String
        Dim alreadyFound As Boolean = False
        Dim reBuild As String = ""
        For Each c As Char In stringText
            If c = " " Then
                If alreadyFound = True Then
                    reBuild += c
                End If
            Else
                alreadyFound = True
                reBuild += c
            End If
        Next

        Dim alreadyFound2 As Boolean = False
        Dim reBuild2 As String = ""
        For Each c As Char In reBuild.Reverse
            If c = " " Then
                If alreadyFound2 = True Then
                    reBuild2 += c
                End If
            Else
                alreadyFound2 = True
                reBuild2 += c
            End If
        Next
        Return ReverseText(reBuild2)
    End Function
    ''' <summary>
    ''' Récupère le contenu positioner entre les lignes spécifié.
    ''' </summary>
    Public Shared Function GetTextBetweenLine(ByVal stringText As String, ByVal lineStart As Integer, ByVal lineEnd As Integer)
        Try
            Dim tmpRCH As New RichTextBox, buildString As String = "" : tmpRCH.Text = stringText
            For i As Integer = lineStart To lineEnd
                If i = lineEnd Then
                    buildString += tmpRCH.Lines(i)
                Else
                    buildString += tmpRCH.Lines(i) & vbNewLine
                End If
            Next
            Return buildString
        Catch
            Return ""
        End Try
    End Function
    ''' <summary>
    ''' Récupère les caractères positioner entre les <see cref="Char"/> spécifié.
    ''' </summary>
    Public Shared Function GetTextBetweenChar(ByVal stringText As String, ByVal startc As String, ByVal endc As String) As String
        Dim reBuild As String = ""
        Dim foundStartChar = False
        For Each itm As String In stringText
            If itm = startc And foundStartChar = False Then
                foundStartChar = True
                itm = ""
            End If
            If foundStartChar = True Then
                reBuild = reBuild & itm
            End If
            If itm = endc Then
                Exit For
            End If
        Next
        Return RemoveSpecifiedChar(reBuild, endc)
    End Function
    ''' <summary>
    ''' Récupère les caractères positioner entre les positions spécifié.
    ''' </summary>
    Public Shared Function GetTextBetweenCharPosition(ByVal stringText As String, ByVal startc As Integer, ByVal endc As Integer)
        Dim buildString As String = ""
        For i As Integer = startc To endc
            Try
                buildString += stringText(i)
            Catch : End Try
        Next
        Return buildString
    End Function
    ''' <summary>
    ''' Recherche du texte dans le texte spécifié, retourne le nombre de fois ou le texte a été trouvé.
    ''' </summary>
    Public Shared Function FindStringCount(ByVal stringText As String, ByVal findText As String) As Integer
        Dim textf As String = findText
        Dim cnt As Integer = 0
        For Each cm As Char In textf
            If cm = findText Then
                cnt += 1
            End If
        Next
        Return cnt
    End Function
    ''' <summary>
    ''' Recherche sur le texte saisie si le texte commence par la valeur demandé, retourne True si trouvé, False si non trouvé.
    ''' </summary>
    Public Shared Function WithStart(ByVal stringText As String, StartValue As String) As Boolean
        Dim GetLText As String = ""
        Try
            If stringText.Length - 1 < StartValue.Length - 1 Then
                Return False
            Else
                For i As Integer = 0 To StartValue.Length - 1
                    GetLText += stringText(i)
                Next
                If GetLText = StartValue Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Recherche sur le texte saisie si le texte commence par l'une des valeurs demandées, retourne True si trouvé, False si non trouvé.
    ''' </summary>
    Public Shared Function WithStartMultiOne(ByVal stringText As String, StartValue As String()) As Boolean
        For i = 0 To StartValue.Length - 1
            If stringText.StartsWith(StartValue(i)) Then
                Return True
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' Retourne tout les caractères d'un <see cref="String"/> dans un String().
    ''' </summary>
    Public Shared Function StringToStringArray(ByVal stringText As String) As String()
        Dim buildArray As String() = {}
        For Each c As Char In stringText
            buildArray(buildArray.Length) = c
        Next
        Return buildArray
    End Function
    ''' <summary>
    ''' Retourne tout les caractères d'un <see cref="String"/> en <see cref="List(Of String)"/>.
    ''' </summary>
    Public Shared Function StringToStringList(ByVal stringText As String) As List(Of String)
        Dim buildList As New List(Of String)
        For Each c As Char In stringText
            buildList.Add(c)
        Next
        Return buildList
    End Function
    ''' <summary>
    ''' Convertie un <see cref="String"/> en <see cref="Int16"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function StringToInt16(ByVal stringText As String) As Int16
        Try
            Return Convert.ToInt32(stringText)
        Catch
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' Convertie un <see cref="String"/> en <see cref="Int32"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function StringToInt32(ByVal stringText As String) As Int32
        Try
            Return Convert.ToInt32(stringText)
        Catch
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' Convertie un <see cref="String"/> en <see cref="Int64"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function StringToInt64(ByVal stringText As String) As Int64
        Try
            Return Convert.ToInt64(stringText)
        Catch
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' Convertie un <see cref="String"/> en <see cref="Boolean"/>.
    ''' </summary><returns>Nothing si la conversion est impossible</returns>
    Public Shared Function StringToBoolean(ByVal stringText As String) As Boolean
        Try
            Return Convert.ToBoolean(stringText)
        Catch
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Convertie un <see cref="String"/> en <see cref="Decimal"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function StringToDecimal(ByVal stringText As String) As Decimal
        Try
            Return Convert.ToDecimal(stringText)
        Catch
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' Convertie un <see cref="String"/> en <see cref="Double"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function StringToDouble(ByVal stringText As String) As Double
        Try
            Return Convert.ToDouble(stringText)
        Catch
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' Recherche sur le texte saisie si le texte fini par la valeur demandé, retourne True si trouvé, False si non trouvé.
    ''' </summary>
    Public Shared Function WithEnds(ByVal stringText As String, EndValue As String) As Boolean
        Dim GetLText As String = ""
        Try
            If stringText.Length - 1 < EndValue.Length - 1 Then
                Return False
            Else
                For i As Integer = stringText.Length - 1 - EndValue.Length - 1 + 2 To stringText.Length - 1
                    GetLText += stringText(i)
                Next
                If GetLText = EndValue Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Recherche dans le texte saisie si il contient la valeur demandée, retourne True si trouvé, False si non trouvé.
    ''' </summary>
    Public Shared Function Contains(ByVal stringText As String, ByVal value As String) As Boolean
        If stringText.Contains(value) Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Recherche dans le texte saisie si il contient les valeurs demandées, retourne True si toute les valeurs sont trouvé, False si non trouvé.
    ''' </summary>
    Public Shared Function ContainsMulti(ByVal stringText As String, ByVal values As String()) As Boolean
        For i = 0 To values.Count - 1
            If stringText.Contains(values(i)) Then

            Else
                Return False
            End If
        Next
        Return True
    End Function
    ''' <summary>
    ''' Recherche dans le texte saisie si il contient l'une des valeurs demandée, retourne True si une des valeurs ont été trouvé, False si non trouvé.
    ''' </summary>
    Public Shared Function ContainsMultiOne(ByVal stringText As String, ByVal values As String()) As Boolean
        For i = 0 To values.Count - 1
            If stringText.Contains(values(i)) Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    ''' <summary>
    ''' Retire les espaces blanc du début d'une ligne.
    ''' </summary>
    Public Shared Function CountCharacter(ByVal stringText As String, ByVal carac As Char) As Integer
        Dim count As Integer = 0
        For Each c As Char In stringText
            If c = carac Then
                count += 1
            End If
        Next
        Return count
    End Function
    ''' <summary>
    ''' Retourne un tableau de la séparation d'un string.
    ''' </summary>
    Public Shared Function SplitString(ByVal stringText As String, ByVal delimiter As String, Optional ByVal limit As Integer = -1) As String()
        Return Split(stringText, delimiter, limit)
    End Function
    ''' <summary>
    ''' Recherche et retourne le premier caractère.
    ''' </summary>
    Public Shared Function FirstChar(ByVal stringText As String) As String
        If stringText = "" Then Return ""
        Return stringText.First()
    End Function
    ''' <summary>
    ''' Recherche et retourne le deuxième caractère.
    ''' </summary>
    Public Shared Function SecondChar(ByVal stringText As String) As String
        If stringText.Length < 1 Then Return ""
        Return stringText(1)
    End Function
    ''' <summary>
    ''' Recherche et retourne le troisième caractère.
    ''' </summary>
    Public Shared Function ThirdChar(ByVal stringText As String) As String
        If stringText.Length < 2 Then Return ""
        Return stringText(2)
    End Function
    ''' <summary>
    ''' Recherche et retourne le dernier caractère.
    ''' </summary>
    Public Shared Function LastChar(ByVal stringText As String) As String
        If stringText = "" Then Return ""
        Return stringText.Last()
    End Function
    ''' <summary>
    ''' Retire les espaces blanc.
    ''' </summary>
    Public Shared Function RemoveBlankSpaces(ByVal stringText As String) As String
        Dim FinalText As String = ""
        For i As Integer = 0 To stringText.Length - 1
            If stringText(i) = " " Then
                FinalText += ""
            Else
                FinalText += stringText(i)
            End If
        Next
        Return FinalText
    End Function
    ''' <summary>
    ''' Retire le texte spécifié si trouvé.
    ''' </summary>
    Public Shared Function RemoveSpecifiedText(ByVal stringText As String, ByVal strToRemove As String) As String
        Return Replace(stringText, strToRemove, "")
    End Function
    ''' <summary>
    ''' Retire la ligne spécifié, si la ligne est introuvable, retourne le texte spécifié de base.
    ''' </summary>
    Public Shared Function RemoveSpecifiedLine(ByVal stringText As String, ByVal lineToRemove As Integer) As String
        Dim tmpRCH As New RichTextBox, RetStr As String = "" : tmpRCH.Text = stringText
        If tmpRCH.Lines.Count - 1 < lineToRemove Then
            Return stringText
        Else
            For i As Integer = 0 To tmpRCH.Lines.Count - 1
                If lineToRemove = i Then
                Else
                    If tmpRCH.Lines.Count - 1 = i Then
                        RetStr += tmpRCH.Lines(i)
                    Else
                        RetStr += tmpRCH.Lines(i) & vbNewLine
                    End If
                End If
            Next
            Return RetStr
        End If
    End Function
    ''' <summary>
    ''' Retire le caractère spécifié.
    ''' </summary>
    Public Shared Function RemoveSpecifiedChar(ByVal stringText As String, ByVal charToRemove As Char) As String
        Return Replace(stringText, charToRemove, "")
    End Function
    ''' <summary>
    ''' Retourne le nombre de caractères total.
    ''' </summary>
    Public Shared Function CountTotalLength(ByVal stringText As String, Optional ByVal lengthCountTotalRemover As Integer = 0) As Integer
        Return stringText.Length - lengthCountTotalRemover
    End Function
    ''' <summary>
    ''' Ajoute du texte tiré du contenu du fichier spécifié.
    ''' </summary>
    Public Shared Function AddTextByContentFile(ByVal stringText As String, ByVal pathFile As String, Optional ByVal addTextBetweenText As String = " ") As String
        If FileSystem.FileSystem.FileExists(pathFile) Then
            Return stringText & addTextBetweenText & FileSystem.FileSystem.ReadFileAllText(pathFile)
        Else
            Return stringText
        End If
    End Function
    ''' <summary>
    ''' Ajoute du texte tiré du contenu du ou des fichier(s) spécifié(s).
    ''' </summary>
    Public Shared Function AddTextByMultipleContentFile(ByVal stringText As String, ByVal pathFile As String(), Optional ByVal addTextBetweenText As String = " ") As String
        Dim Finaltext As String = stringText
        For i As Integer = 0 To pathFile.Length - 1
            If FileSystem.FileSystem.FileExists(pathFile(i)) Then
                Try
                    Finaltext += FileSystem.FileSystem.ReadFileAllText(pathFile(i))
                Catch : End Try
            End If
        Next
        Return Finaltext
    End Function
    ''' <summary>
    ''' Ajoute du texte tiré de l'URL spécifié.
    ''' </summary>
    Public Shared Function [AddTextByURL](ByVal stringText As String, ByVal url As String) As String
        Dim Finaltext As String = stringText
        Dim wc As New WebClient
        Try
            Finaltext += wc.DownloadString(url)
        Catch : End Try
        Return stringText
    End Function
    ''' <summary>
    ''' Ajoute du texte tiré d'une URL spécifié convertie en <see cref="Uri"/>.
    ''' </summary>
    Public Shared Function [AddTextByURL](ByVal stringText As String, ByVal url As Uri) As String
        Dim Finaltext As String = stringText
        Dim wc As New WebClient
        Try
            Finaltext += wc.DownloadString(url)
        Catch : End Try
        Return stringText
    End Function
    ''' <summary>
    ''' Sauvegarde le contenu du <see cref="String"/> dans un fichier.
    ''' </summary>
    Public Shared Function SaveStringToFile(ByVal stringText As String, ByVal pathFile As String) As Boolean
        Try
            FileSystem.FileSystem.WriteFileAllText(pathFile, stringText) : Return True
        Catch
            Return False
        End Try
    End Function
End Class
