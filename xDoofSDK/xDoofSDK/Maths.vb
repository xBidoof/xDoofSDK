''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="Maths"/>.
''' </summary>
Public Class Maths
    Public Const PI As Double = 3.14159265358979
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Integer"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As Integer, ByVal Value2 As Integer) As Integer
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value2
        Else
            Return Value1
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur non signée <see cref="Integer"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As UInteger, ByVal Value2 As UInteger) As UInteger
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value2
        Else
            Return Value1
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Decimal"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As Decimal, ByVal Value2 As Decimal) As Decimal
        If CInt(Value1) = CInt(Value2) Then
            Return CDec(0)
        ElseIf CInt(Value1) > CInt(Value2) Then
            Return CInt(Value2)
        Else
            Return CInt(Value1)
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Byte"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As Byte, ByVal Value2 As Byte) As Byte
        If CInt(Value1) = CInt(Value2) Then
            Return CByte(0)
        ElseIf CInt(Value1) > CInt(Value2) Then
            Return CInt(Value2)
        Else
            Return CInt(Value1)
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur signée <see cref="Byte"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As SByte, ByVal Value2 As SByte) As SByte
        If CInt(Value1) = CInt(Value2) Then
            Return CByte(0)
        ElseIf CInt(Value1) > CInt(Value2) Then
            Return CInt(Value2)
        Else
            Return CInt(Value1)
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Long"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As Long, ByVal Value2 As Long) As Long
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value2
        Else
            Return Value1
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur non signée <see cref="Long"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As ULong, ByVal Value2 As ULong) As ULong
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value2
        Else
            Return Value1
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Short"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As Short, ByVal Value2 As Short) As Short
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value2
        Else
            Return Value1
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur non signée <see cref="Short"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As UShort, ByVal Value2 As UShort) As UShort
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value2
        Else
            Return Value1
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Double"/> la plus petite, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Small](ByVal Value1 As Double, ByVal Value2 As Double) As Double
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value2
        Else
            Return Value1
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Integer"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As Integer, ByVal Value2 As Integer) As Integer
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value1
        Else
            Return Value2
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur non signée <see cref="Integer"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As UInteger, ByVal Value2 As UInteger) As UInteger
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value1
        Else
            Return Value2
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus petite des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Decimal"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As Decimal, ByVal Value2 As Decimal) As Decimal
        If CInt(Value1) = CInt(Value2) Then
            Return CDec(0)
        ElseIf CInt(Value1) > CInt(Value2) Then
            Return CInt(Value1)
        Else
            Return CInt(Value2)
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Byte"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As Byte, ByVal Value2 As Byte) As Byte
        If CInt(Value1) = CInt(Value2) Then
            Return CDec(0)
        ElseIf CInt(Value1) > CInt(Value2) Then
            Return CInt(Value1)
        Else
            Return CInt(Value2)
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur signée <see cref="Byte"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As SByte, ByVal Value2 As SByte) As SByte
        If CInt(Value1) = CInt(Value2) Then
            Return CDec(0)
        ElseIf CInt(Value1) > CInt(Value2) Then
            Return CInt(Value1)
        Else
            Return CInt(Value2)
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Long"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As Long, ByVal Value2 As Long) As Long
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value1
        Else
            Return Value2
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur non signée <see cref="Long"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As ULong, ByVal Value2 As ULong) As ULong
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value1
        Else
            Return Value2
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Short"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As Short, ByVal Value2 As Short) As Short
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value1
        Else
            Return Value2
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur non signée <see cref="Short"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As UShort, ByVal Value2 As UShort) As UShort
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value1
        Else
            Return Value2
        End If
    End Function
    ''' <summary>
    ''' Compare et retourne la valeur la plus grande des deux valeurs spécifié.
    ''' </summary><returns>Retourne la valeur <see cref="Double"/> la plus grande, retourne 0 en cas d'égalité.</returns>
    Public Shared Function [Big](ByVal Value1 As Double, ByVal Value2 As Double) As Double
        If Value1 = Value2 Then
            Return 0
        ElseIf Value1 > Value2 Then
            Return Value1
        Else
            Return Value2
        End If
    End Function
    ''' <summary>
    ''' Multiplie le nombre spécifé par le même nombre.
    ''' </summary><returns>Retourne la valeur <see cref="Long"/> multipliée par lui-même.</returns>
    Public Shared Function MultiplyNumber(ByVal value As Long) As Long
        Return value * value
    End Function
    ''' <summary>
    ''' Calcul la moyenne d'une liste spécifié.
    ''' </summary><returns>Retourne la moyenne en <see cref="Long"/>.</returns>
    Public Shared Function CalcMoyenne(ByVal value As Integer()) As Long
        Dim addValues As Long = 0
        For i As Integer = 0 To value.Length - 1
            addValues += value(i)
        Next
        Return addValues / value.Length
    End Function
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="Metrique"/>, accessible depuis la classe <see cref="Maths"/>.
    ''' </summary>
    Public Class Metrique
        ''' <summary>
        ''' Convertie des kilomètres en mètres.
        ''' </summary><returns>Retourne la valeur convertie en <see cref="Double"/>.</returns>
        Public Shared Function KMtoM(ByVal value As Integer) As Double
            Return value * 1000
        End Function
        ''' <summary>
        ''' Convertie des kilomètres en centimètres.
        ''' </summary><returns>Retourne la valeur convertie en <see cref="Double"/>.</returns>
        Public Shared Function KMtoCM(ByVal value As Integer) As Double
            Return value * 100000
        End Function
        ''' <summary>
        ''' Convertie des kilomètres en milimètres.
        ''' </summary><returns>Retourne la valeur convertie en <see cref="Double"/>.</returns>
        Public Shared Function KMtoMM(ByVal value As Integer) As Double
            Return value * 1000000
        End Function
        ''' <summary>
        ''' Convertie des mètres en kilomètres.
        ''' </summary><returns>Retourne la valeur convertie en <see cref="Double"/>.</returns>
        Public Shared Function MtoKM(ByVal value As Integer) As Double
            Return value * 0.001
        End Function
        ''' <summary>
        ''' Convertie des mètres en milimètres.
        ''' </summary><returns>Retourne la valeur convertie en <see cref="Double"/>.</returns>
        Public Shared Function MtoMM(ByVal value As Integer) As Double
            Return value * 1000
        End Function
        ''' <summary>
        ''' Convertie des milimètres en kilomètres.
        ''' </summary><returns>Retourne la valeur convertie en <see cref="Double"/>.</returns>
        Public Shared Function MMtoKM(ByVal value As Integer) As Double
            Return value * 0.000001
        End Function
        ''' <summary>
        ''' Convertie des milimètres en mètres.
        ''' </summary><returns>Retourne la valeur convertie en <see cref="Double"/>.</returns>
        Public Shared Function MMtoM(ByVal value As Integer) As Double
            Return value * 0.001
        End Function
    End Class
End Class
