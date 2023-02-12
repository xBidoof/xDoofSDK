
Namespace Expressions
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="Strex"/>, il s'agit de la classe d'expression formé en <see cref="String"/>.
    ''' </summary>
    Public Class Strex

        Private Shared ReadOnly CharMin As String() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        Private Shared ReadOnly CharMaj As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        Private _pattern As String = ""

        Public Sub New()

        End Sub

        Public Sub New(pattern As String)
            _pattern = pattern
        End Sub
        ''' <summary>
        ''' Retourne le patterne déjà saisie.
        ''' </summary>
        Public ReadOnly Property GetPattern As String
            Get
                Return _pattern
            End Get
        End Property
        ''' <summary>
        ''' Vérifie si le patterne saisie contient du contenu.
        ''' </summary>
        Public ReadOnly Property isContainsPattern As Boolean
            Get
                If _pattern = "" Then
                    Return False
                Else
                    Return True
                End If
            End Get
        End Property
        ''' <summary>
        ''' Ajoute et remplace le patterne saisie par un nouveau.
        ''' </summary>
        Public WriteOnly Property Pattern As String
            Set(value As String)
                _pattern = value
            End Set
        End Property
        ''' <summary>
        ''' Ajoute et remplace le patterne saisie par un nouveau.
        ''' </summary>
        Public Sub SetPattern(ByVal pattern As String)
            _pattern = pattern
        End Sub
        ''' <summary>
        ''' Exécute le <see cref="Strex"/> avec le patterne prédéfini et retourne le résultat.
        ''' </summary>
        Public ReadOnly Property Execute As Object
            Get
                Return ExecutePattern()
            End Get
        End Property
        ''' <summary>
        ''' Exécute le <see cref="Strex"/> avec le patterne prédéfini et retourne le résultat.
        ''' </summary>
        Public Function ExecuteStrex() As Object
            Return ExecutePattern()
        End Function

        Private Function ExecutePattern() As Object
            Dim ReTT As String = ""
            Dim GetSplitted As String() = Split(_pattern, "::")
            Dim getLines As String = ""
            For i As Integer = 0 To GetSplitted.Length - 1
                If GetSplitted(i).Contains("RN(") Then ' exemple: "RN(0/9999)"
                    getLines = GetSplitted(i) : getLines = Replace(getLines, "RN(", "") : getLines = Replace(getLines, ")", "")
                    Try
                        Dim getStartEnd As String() = Split(getLines, "/")
                        ReTT = ReTT & RandomInt.NextInt(getStartEnd(0), getStartEnd(1))
                    Catch : End Try
                ElseIf GetSplitted(i).Contains("RS(") Then ' exemple: "RS(A/Z)" | "RS(a/z)" | "RS(Aa/zZ)" | "RS(Aa/zZ)/P*50"
                    getLines = GetSplitted(i)
                    getLines = Replace(getLines, "RS(", "") : getLines = Replace(getLines, ")", "") : getLines = Replace(getLines, "P*", "")
                    Try
                        Dim getStartEnd As String() = Split(getLines, "/")
                        Dim genNumb As Integer = 1
                        If getStartEnd.Length = 3 Then
                            genNumb = CInt(getStartEnd(2))
                            If genNumb < 0 Or genNumb > 99999999 Then
                                genNumb = 1
                            End If
                        End If
                        If getStartEnd(0).Length = 1 Then
                            If getStartEnd(0).Contains("A") And getStartEnd(1).Contains("Z") Then
                                ReTT += RandomString.NextString(CharMaj, genNumb)
                            ElseIf getStartEnd(0).Contains("a") And getStartEnd(1).Contains("z") Then
                                ReTT += RandomString.NextString(CharMin, genNumb)
                            End If
                        End If
                        If getStartEnd(0).Contains("Aa") And getStartEnd(1).Contains("zZ") Then
                            ReTT += RandomString.NextString(genNumb)
                        ElseIf getStartEnd(0).Contains("Aa") And getStartEnd(1).Contains("Zz") Then
                            ReTT += RandomString.NextString(genNumb)
                        ElseIf getStartEnd(0).Contains("aA") And getStartEnd(1).Contains("zZ") Then
                            ReTT += RandomString.NextString(genNumb)
                        ElseIf getStartEnd(0).Contains("aA") And getStartEnd(1).Contains("Zz") Then
                            ReTT += RandomString.NextString(genNumb)
                        End If
                    Catch : End Try
                ElseIf GetSplitted(i).Contains("ADD{") Then ' exemple: "ADD{Salut 0 !}"
                    getLines = GetSplitted(i) : getLines = Replace(getLines, "ADD{", "") : getLines = Replace(getLines, "}", "")
                    Try
                        ReTT += getLines
                    Catch : End Try
                ElseIf GetSplitted(i).Contains("\PS") Or GetSplitted(i).Contains("\ps") Then ' exemple: "\ps/P*3"
                    Try
                        getLines = GetSplitted(i)
                        Dim getStartEnd As String() = Split(getLines, "/")
                        If getStartEnd.Length = 2 Then
                            Dim GetParameter As String = getStartEnd(1)
                            GetParameter = Replace(GetParameter, "P*", "")
                            For ii As Integer = 0 To CInt(GetParameter)
                                ReTT = ReTT & vbNewLine
                            Next
                        Else
                            ReTT = ReTT & vbNewLine
                        End If
                    Catch : End Try
                ElseIf GetSplitted(i).Contains("^CPS") Or GetSplitted(i).Contains("^cps") Then ' exemple: "^CPS<mach_name>" | "^CPS<mach_name>+<user_name>"
                    getLines = GetSplitted(i) : getLines = Replace(getLines, "^CPS", "") : getLines = Replace(getLines, "^cps", "")
                    If getLines.StartsWith("<mach_name>") Or getLines.Contains("+<mach_name>") Then
                        ReTT += Environment.MachineName
                    End If
                    If getLines.StartsWith("<user_name>") Or getLines.Contains("+<user_name>") Then
                        ReTT += Environment.UserName
                    End If
                    If getLines.StartsWith("<user_dom_name>") Or getLines.Contains("+<user_dom_name>") Then
                        ReTT += Environment.UserDomainName
                    End If
                    If getLines.StartsWith("<dir_sys>") Or getLines.Contains("+<dir_sys>") Then
                        ReTT += Environment.SystemDirectory
                    End If
                    If getLines.StartsWith("<dir_current>") Or getLines.Contains("+<dir_current>") Then
                        ReTT += Environment.CurrentDirectory
                    End If
                End If
            Next
            Return ReTT
        End Function
    End Class
End Namespace
