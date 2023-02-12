Imports System.IO
Imports System.Windows.Forms
''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="OO"/>.
''' </summary>
Public Class OO

    ''' <summary>
    ''' Le chemin source de oo.
    ''' </summary>
    Const basePathOo = "C:\xDoof\xDoofSystem\__oo"
    ''' <summary>
    ''' Exécute la source saisie.
    ''' </summary>
    Shared Sub ExecuteSource(src As String, from As String)

    End Sub
    ''' <summary>
    ''' Exécute une source selon le fichier source saisie.
    ''' </summary>
    Shared Sub ExecuteFileSource(filePath As String)

    End Sub
    ''' <summary>
    ''' Exécute une source selon le fichier source saisie provenant d'internet.
    ''' </summary>
    Shared Sub ExecuteWebFileSourceSync(webFilePath As String)

    End Sub
    ''' <summary>
    ''' Vérifie si le support oo est installer sur l'ordinateur
    ''' <para><paramref name="cLevel"/> = Le niveau de vérification</para>
    ''' </summary>
    Shared Function IsOoInstalled(cLevel As CheckLevel) As Boolean
        If cLevel = CheckLevel.Minimum Then
            If Directory.Exists(basePathOo) = False Then
                Return False
            End If
            If File.Exists(basePathOo & "\oo.exe") = False Then
                Return False
            End If
            If File.Exists(basePathOo & "\xDoofSDK.dll") = False Then
                Return False
            End If
            Return True
        ElseIf cLevel = CheckLevel.TreeSystem Then
            If File.Exists(basePathOo & "\base\tree.inf") = False Then
                Return False
            End If
            Dim rchtxt As New RichTextBox
            Try
                rchtxt.Text = File.ReadAllText(basePathOo & "\base\tree.inf")
            Catch ex As Exception
                Return False
            End Try
            Dim oType = ""
            For i = 0 To rchtxt.Lines.Count - 1
                If rchtxt.Lines(i).StartsWith("#com#") Then

                ElseIf rchtxt.Lines(i) = "" Then

                ElseIf rchtxt.Lines(i) = "folder;" Then
                    oType = "fld"
                ElseIf rchtxt.Lines(i) = "file;" Then
                    oType = "fl"
                Else
                    If oType = "fld" Then
                        If Directory.Exists(basePathOo & "\" & rchtxt.Lines(i)) = False Then
                            Return False
                        End If
                    ElseIf oType = "fl" Then
                        If File.Exists(basePathOo & "\" & rchtxt.Lines(i)) = False Then
                            Return False
                        End If
                    End If
                End If
            Next
            Return True
        End If
        Return False
    End Function

    Public Enum CheckLevel
        ''' <summary>
        ''' Vérifie seulement la base.
        ''' </summary>
        Minimum
        ''' <summary>
        ''' Lie et vérifie selon le fichier d'arbre installer.
        ''' </summary>
        TreeSystem
    End Enum
End Class
