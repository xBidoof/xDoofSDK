''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="IntFunc"/>, utilisation de cette classe avec <see cref="Integer"/>.
''' </summary>
Public Class IntFunc
    ''' <summary>
    ''' Ajoute une valeur spécifié.
    ''' </summary>
    Public Shared Sub AddValue(ByVal decl As Integer, ByVal valueToAdd As Integer)
        decl += valueToAdd
    End Sub
    ''' <summary>
    ''' Soustrait une valeur spécifié.
    ''' </summary>
    Public Shared Sub RemoveValue(ByVal decl As Integer, ByVal valueToRemove As Integer)
        decl -= valueToRemove
    End Sub
    ''' <summary>
    ''' Multiplie une valeur spécifié.
    ''' </summary>
    Public Shared Sub MultiplyValue(ByVal decl As Integer, ByVal valueToMultiply As Integer)
        decl *= valueToMultiply
    End Sub
    ''' <summary>
    ''' Divise la valeur saisie par la valeur spécifié.
    ''' </summary>
    Public Shared Sub DivideValue(ByVal decl As Integer, ByVal valueToDivide As Integer)
        decl /= valueToDivide
    End Sub
    ''' <summary>
    ''' Convertie un <see cref="Int16"/> en <see cref="String"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function Int16ToString(ByVal value As Int16) As String
        Try
            Return Convert.ToString(value)
        Catch
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' Convertie un <see cref="Int32"/> en <see cref="String"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function Int32ToString(ByVal value As Int32) As String
        Try
            Return Convert.ToString(value)
        Catch
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' Convertie un <see cref="Int64"/> en <see cref="String"/>.
    ''' </summary><returns>-1 si la conversion est impossible</returns>
    Public Shared Function Int64ToString(ByVal value As Int64) As String
        Try
            Return Convert.ToString(value)
        Catch
            Return -1
        End Try
    End Function
End Class
