Namespace Colors
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="ColorRandomizer"/>.
    ''' </summary>
    Public Class ColorRandomizer

        ''' <summary>
        ''' Retourne un <see cref="System.Drawing.Color"/> aléatoire selon une valeur RGB générer aléatoirement.
        ''' </summary>
        Shared Function GetRandomColor() As System.Drawing.Color
            Dim colorRGB As System.Drawing.Color = System.Drawing.Color.FromArgb(xDoofSDK.RandomInt.NextInt(0, 255), xDoofSDK.RandomInt.NextInt(0, 255), xDoofSDK.RandomInt.NextInt(0, 255))
            Return colorRGB
        End Function
        ''' <summary>
        ''' Retourne un Integer Array aléatoire.
        ''' </summary><remarks>0 = R | 1 = G | 2 = B</remarks>
        Shared Function GetRandomRGB() As Integer()
            Dim colorRGB As Integer() = {xDoofSDK.RandomInt.NextInt(0, 255), xDoofSDK.RandomInt.NextInt(0, 255), xDoofSDK.RandomInt.NextInt(0, 255)}
            Return colorRGB
        End Function
        ''' <summary>
        ''' Retourne un <see cref="Integer"/> aléatoire entre 0 et 255.
        ''' </summary>
        Shared Function GetRandomRGBValue() As Integer
            Return xDoofSDK.RandomInt.NextInt(0, 255)
        End Function
    End Class
End Namespace
