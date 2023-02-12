Imports System.Globalization
''' <summary>
''' Initialise une nouvelle instance de la classe <see cref="Converter"/>.
''' </summary>
Public NotInheritable Class Converter
    Inherits Object
    Public Sub New()

    End Sub

    Public Shared Function ToBool(ByVal value As Object) As Boolean
        Return value IsNot Nothing AndAlso (CType(value, IConvertible)).ToBoolean(CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToBool(ByVal value As Object, ByVal provider As IFormatProvider) As Boolean
        Return value IsNot Nothing AndAlso (CType(value, IConvertible)).ToBoolean(provider)
    End Function

    Public Shared Function ToBool(ByVal value As Boolean) As Boolean
        Return value
    End Function

    <CLSCompliant(False)>
    Public Shared Function ToBool(ByVal value As SByte) As Boolean
        Return CUInt(value) > 0UI
    End Function

    Public Shared Function ToBool(ByVal value As Char) As Boolean
        Return (CType(value, IConvertible)).ToBoolean(CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToBool(ByVal value As Byte) As Boolean
        Return value > CByte(0)
    End Function

    Public Shared Function ToBool(ByVal value As Short) As Boolean
        Return CUInt(value) > 0UI
    End Function

    <CLSCompliant(False)>
    Public Shared Function ToBool(ByVal value As UShort) As Boolean
        Return value > CUShort(0)
    End Function

    Public Shared Function ToBool(ByVal value As Integer) As Boolean
        Return CUInt(value) > 0UI
    End Function

    <CLSCompliant(False)>
    Public Shared Function ToBool(ByVal value As UInteger) As Boolean
        Return value > 0UI
    End Function

    Public Shared Function ToBool(ByVal value As Long) As Boolean
        Return CULng(value) > 0UL
    End Function

    <CLSCompliant(False)>
    Public Shared Function ToBool(ByVal value As ULong) As Boolean
        Return value > 0UL
    End Function

    Public Shared Function ToBool(ByVal value As String) As Boolean
        Return value IsNot Nothing AndAlso Boolean.Parse(value)
    End Function

    Public Shared Function ToBool(ByVal value As String, ByVal provider As IFormatProvider) As Boolean
        Return value IsNot Nothing AndAlso Boolean.Parse(value)
    End Function

    Public Shared Function ToBool(ByVal value As Single) As Boolean
        Return CDbl(value) <> 0.0
    End Function

    Public Shared Function ToBool(ByVal value As Double) As Boolean
        Return value <> 0.0
    End Function

    Public Shared Function ToBool(ByVal value As Decimal) As Boolean
        Return value <> 0D
    End Function

    Public Shared Function ToBool(ByVal value As DateTime) As Boolean
        Return (CType(value, IConvertible)).ToBoolean(CType(Nothing, IFormatProvider))
    End Function


    Public Shared Function ToChar(ByVal value As Object) As Char
        Return If(value IsNot Nothing, (CType(value, IConvertible)).ToChar(CType(Nothing, IFormatProvider)), Char.MinValue)
    End Function


    Public Shared Function ToChar(ByVal value As Object, ByVal provider As IFormatProvider) As Char
        Return If(value IsNot Nothing, (CType(value, IConvertible)).ToChar(provider), Char.MinValue)
    End Function

    Public Shared Function ToChar(ByVal value As Boolean) As Char
        Return (CType(value, IConvertible)).ToChar(CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToChar(ByVal value As Char) As Char
        Return value
    End Function

    Public Shared Function ToChar(ByVal value As SByte) As Char
        Return ChrW(value)
    End Function


    Public Shared Function ToChar(ByVal value As Byte) As Char
        Return ChrW(value)
    End Function


    Public Shared Function ToChar(ByVal value As Short) As Char
        Return ChrW(value)
    End Function


    Public Shared Function ToChar(ByVal value As UShort) As Char
        Return ChrW(value)
    End Function


    Public Shared Function ToChar(ByVal value As Integer) As Char
        Return ChrW(value)
    End Function


    Public Shared Function ToChar(ByVal value As UInteger) As Char
        Return ChrW(value)
    End Function


    Public Shared Function ToChar(ByVal value As Long) As Char
        Return ChrW(value)
    End Function

    Public Shared Function ToChar(ByVal value As ULong) As Char
        Return ChrW(value)
    End Function

    Public Shared Function ToChar(ByVal value As String) As Char
        Return Convert.ToChar(value, CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToChar(ByVal value As Single) As Char
        Return (CType(value, IConvertible)).ToChar(CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToChar(ByVal value As Double) As Char
        Return (CType(value, IConvertible)).ToChar(CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToChar(ByVal value As Decimal) As Char
        Return (CType(value, IConvertible)).ToChar(CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToChar(ByVal value As DateTime) As Char
        Return (CType(value, IConvertible)).ToChar(CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Object) As String
        Return Convert.ToString(value, CType(Nothing, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Boolean) As String
        Return value.ToString()
    End Function

    Public Shared Function ToStr(ByVal value As Boolean, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As Char) As String
        Return Char.ToString(value)
    End Function

    Public Shared Function ToStr(ByVal value As Char, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As SByte) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As SByte, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As Byte) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Byte, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As Short) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Short, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As UShort) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As UShort, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As Integer) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Integer, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As UInteger) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As UInteger, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function


    Public Shared Function ToStr(ByVal value As Long) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function


    Public Shared Function ToStr(ByVal value As Long, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As ULong) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As ULong, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As Single) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Single, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As Double) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Double, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As Decimal) As String
        Return value.ToString(CType(CultureInfo.CurrentCulture, IFormatProvider))
    End Function

    Public Shared Function ToStr(ByVal value As Decimal, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As DateTime) As String
        Return value.ToString()
    End Function

    Public Shared Function ToStr(ByVal value As DateTime, ByVal provider As IFormatProvider) As String
        Return value.ToString(provider)
    End Function

    Public Shared Function ToStr(ByVal value As String) As String
        Return value
    End Function

    Public Shared Function ToStr(ByVal value As String, ByVal provider As IFormatProvider) As String
        Return value
    End Function
End Class
