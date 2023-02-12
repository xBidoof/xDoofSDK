Imports System.IO
Imports System.Windows.Forms

Namespace Storage
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="StringStorage"/>.
    ''' </summary>
    Public Class StringStorage
        Dim StoreStr As List(Of String) = New List(Of String)
        Dim StoreStrValue As List(Of String) = New List(Of String)

        Public Sub New()

        End Sub
        ''' <summary>
        ''' Ajoute un item dans le stockage de <see cref="String"/> ainsi que ca valeur spécifié.
        ''' </summary>
        Public Sub PushItem(ByVal item As String, ByVal value As String)
            Try
                StoreStr.Add(item)
                StoreStrValue.Add(value)
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Ajoute une <see cref="List(Of String)"/> dans le stockage de <see cref="String"/> ainsi que les valeurs spécifiés.
        ''' </summary>
        Public Sub PushItemList(ByVal item As String(), ByVal value As String())
            Try
                StoreStr.AddRange(item)
                StoreStrValue.AddRange(value)
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Inverse l'ordre des éléments des item(s) du stockage.
        ''' </summary>
        Public Sub ReverseItems()
            Try
                StoreStr.Reverse()
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Inverse l'ordre des éléments des valeur(s) du stockage.
        ''' </summary>
        Public Sub ReverseValues()
            Try
                StoreStrValue.Reverse()
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Inverse l'ordre des éléments des item(s) et des valeur(s) du stockage.
        ''' </summary>
        Public Sub ReverseItemsWithValues()
            Try
                StoreStr.Reverse()
                StoreStrValue.Reverse()
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Sauvegarde le stockage dans un fichier de stockage de xDoofSystem.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si sauvegarder, False dans le cas contraire.</returns>
        ''' <remarks>REMARQUE: Le fichier est adapté pour le format de stockage pour le système xDoofSystem.</remarks>
        Public Function SaveToFileStorage(ByVal pathFileWithoutExtension As String, ByVal saveValue As Boolean) As Boolean
            Try
                Dim GetStorage As String = "ITEMS=>"
                For i As Integer = 0 To StoreStr.Count - 1
                    If i = StoreStr.Count - 1 Then
                        GetStorage += StoreStr(i)
                    Else
                        GetStorage += StoreStr(i) & ":@:"
                    End If
                Next
                GetStorage += vbNewLine & "VALUES=>"
                For i As Integer = 0 To StoreStrValue.Count - 1
                    If i = StoreStrValue.Count - 1 Then
                        GetStorage += StoreStrValue(i)
                    Else
                        GetStorage += StoreStrValue(i) & ":@:"
                    End If
                Next
                File.WriteAllText(pathFileWithoutExtension & ".xstorstr", GetStorage)
                Return True
            Catch : Return False : End Try
        End Function
        ''' <summary>
        ''' Lis un fichier de stockage de xDoofSystem.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si lu et correctement ajouter, False dans le cas contraire.</returns>
        ''' <remarks>REMARQUE: Le fichier lui doit être adapté du format de stockage pour le système xDoofSystem.</remarks>
        Public Function ReadFileStorage(ByVal pathFile As String) As Boolean
            Try
                Dim GetStorage As New RichTextBox : GetStorage.Text = File.ReadAllText(pathFile)
                For i As Integer = 0 To GetStorage.Lines.Count - 1
                    If GetStorage.Lines(i).Contains("ITEMS=>") Then
                        Dim GetLines As String = GetStorage.Lines(i).Replace("ITEMS=>", "")
                        Dim GetItm As String() = Split(GetLines, ":@:")
                        For ii As Integer = 0 To GetItm.Length - 1
                            StoreStr.Add(GetItm(ii))
                        Next
                    ElseIf GetStorage.Lines(i).Contains("VALUES=>") Then
                        Dim GetLines As String = GetStorage.Lines(i).Replace("VALUES=>", "")
                        Dim GetItm As String() = Split(GetLines, ":@:")
                        For ii As Integer = 0 To GetItm.Length - 1
                            StoreStrValue.Add(GetItm(ii))
                        Next
                    End If
                Next
                Return True
            Catch : Return False : End Try
        End Function
        ''' <summary>
        ''' Remplace l'item spécifié par le nouvelle item spécifié.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si remplacer, False dans le cas contraire.</returns>
        Public Function ReplaceItem(ByVal oldItem As String, ByVal newItem As String) As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = oldItem Then
                        StoreStr(i) = newItem : Return True
                    End If
                Next
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Remplace la liste d'item(s) spécifié par les nouveaux item(s) spécifié.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si remplacer, False dans le cas contraire.</returns>
        Public Function ReplaceItemList(ByVal oldItem As String(), ByVal newItem As String()) As Boolean
            Dim RetBool As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    For ii As Integer = 0 To oldItem.Length - 1
                        If StoreStr(i) = oldItem(ii) Then
                            StoreStr(i) = newItem(ii) : RetBool = True
                        End If
                    Next
                Next
                Return RetBool
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Remplace la valeur de l'item spécifié par une nouvelle valeur.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si remplacer, False dans le cas contraire.</returns>
        Public Function ReplaceItemValue(ByVal item As String, ByVal newValue As String) As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = item Then
                        StoreStrValue(i) = newValue : Return True
                    End If
                Next
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Remplace la liste de valeur(s) des item(s) spécifié par les nouvelles valeur(s).
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si remplacer, False dans le cas contraire.</returns>
        Public Function ReplaceItemValueList(ByVal item As String(), ByVal newValue As String()) As Boolean
            Dim RetBool As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    For ii As Integer = 0 To item.Length - 1
                        If StoreStr(i) = item(ii) Then
                            StoreStrValue(i) = newValue(ii) : RetBool = True
                        End If
                    Next
                Next
                Return RetBool
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Remplace l'item spécifié par une nouvelle item ainsi que ca valeur par une nouvelle valeur spécifié.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si remplacer, False dans le cas contraire.</returns>
        Public Function ReplaceItemWithValue(ByVal oldItem As String, ByVal newItem As String, ByVal newValue As String) As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = oldItem Then
                        StoreStr(i) = newItem
                        StoreStrValue(i) = newValue : Return True
                    End If
                Next
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Remplace les item(s) spécifié par les nouvelles item(s) ainsi que ces valeur(s) par les nouvelles valeur(s) spécifié.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si remplacer, False dans le cas contraire.</returns>
        Public Function ReplaceItemWithValueList(ByVal oldItem As String(), ByVal newItem As String(), ByVal newValue As String()) As Boolean
            Dim RetBool As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    For ii As Integer = 0 To oldItem.Length - 1
                        If StoreStr(i) = oldItem(ii) Then
                            StoreStr(i) = newItem(ii)
                            StoreStrValue(i) = newValue(ii) : RetBool = True
                        End If
                    Next
                Next
                Return RetBool
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Supprime un item dans le stockage de <see cref="String"/> ainsi que ca valeur.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si trouvé et supprimé, False dans le cas contraire.</returns>
        Public Function DeleteItem(ByVal item As String) As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = item Then
                        StoreStr.RemoveAt(i)
                        StoreStrValue.RemoveAt(i)
                        Return True
                    End If
                Next
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Supprime tout les items dans le stockage de <see cref="String"/> ainsi que toutes ces valeurs associés.
        ''' </summary>
        Public Sub DeleteAll()
            Try
                StoreStr.Clear()
                StoreStrValue.Clear()
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Recherche un item dans le stockage de <see cref="String"/>.
        ''' </summary><returns>Retourne un <see cref="Boolean"/>, True si trouvé, False dans le cas contraire.</returns>
        Public Function FindItem(ByVal item As String) As Boolean
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = item Then
                        Return True
                    End If
                Next
            Catch : Return False : End Try
            Return False
        End Function
        ''' <summary>
        ''' Recherche un item dans le stockage de <see cref="String"/> et retourne ça valeur associé.
        ''' </summary><returns>Retourne la valeur <see cref="String"/> associé si trouvé.</returns>
        Public Function FindItemWithReturnValue(ByVal item As String) As String
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = item Then
                        Return StoreStrValue(i)
                    End If
                Next
            Catch : Return "" : End Try
            Return ""
        End Function
        ''' <summary>
        ''' Recherche un item dans le stockage de <see cref="String"/> et retourne l'index.
        ''' </summary><returns>Retourne l'index <see cref="Integer"/> associé si trouvé, retourne -1 dans le cas contraire.</returns>
        Public Function FindItemWithReturnIndex(ByVal item As String) As Integer
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = item Then
                        Return i
                    End If
                Next
            Catch : Return -1 : End Try
            Return -1
        End Function
        ''' <summary>
        ''' Recherche un item dans le stockage de <see cref="String"/> et retourne ça valeur associé.
        ''' </summary><returns>Retourne une <see cref="List(Of String)"/> des valeurs <see cref="String"/> associé trouvés.</returns>
        Public Function FindItemWithReturnValueList(ByVal item As String) As List(Of String)
            Dim RetList As List(Of String) = New List(Of String)
            Try
                For i As Integer = 0 To StoreStr.Count - 1
                    If StoreStr(i) = item Then
                        RetList.Add(StoreStrValue(i))
                    End If
                Next
            Catch : Return Nothing : End Try
            Return RetList
        End Function
        ''' <summary>
        ''' Compte le nombre total d'éléments dans le stockage de <see cref="String"/>.
        ''' </summary><returns>Retourne le nombre total d'éléments en <see cref="Integer"/>.</returns>
        Public Function CountItems() As Integer
            Return StoreStr.Count
        End Function
        ''' <summary>
        ''' Retourne le stockage de <see cref="String"/>.
        ''' </summary><returns>Retourne une <see cref="List(Of String)"/> du stockage.</returns>
        Public Function GetStorage() As List(Of String)
            Return StoreStr
        End Function
        ''' <summary>
        ''' Retourne les valeurs du stockage de <see cref="String"/>.
        ''' </summary><returns>Retourne une <see cref="List(Of String)"/> des valeurs du stockage.</returns>
        Public Function GetStorageValue() As List(Of String)
            Return StoreStrValue
        End Function
        ''' <summary>
        ''' Supprime et remplace le stockage par une liste d'item(s) spécifié.
        ''' </summary>
        Public Sub SetStorage(ByVal itemsList As String())
            Try
                StoreStr.Clear()
                StoreStr.AddRange(itemsList)
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Supprime et remplace les valeurs du stockage par une liste de valeur(s) spécifié.
        ''' </summary>
        Public Sub SetStorageValue(ByVal itemsValue As String())
            Try
                StoreStrValue.Clear()
                StoreStrValue.AddRange(itemsValue)
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Supprime et remplace le stockage par une liste de valeur(s) spécifié.
        ''' </summary>
        Public Sub SetStorageWithValue(ByVal itemsList As String(), ByVal itemsValue As String())
            Try
                StoreStr.Clear()
                StoreStr.AddRange(itemsList)
                StoreStrValue.Clear()
                StoreStrValue.AddRange(itemsValue)
            Catch : End Try
        End Sub
    End Class
End Namespace
