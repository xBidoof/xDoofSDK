Imports System.Drawing
Imports System.IO

Namespace Imaging
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="ImageConverter"/>.
    ''' </summary>
    Public Class ImageConverter

        Private Const SPI_SETDESKWALLPAPER As Integer = &H14
        Private Const SPIF_UPDATEINIFILE As Integer = &H1
        Private Const SPIF_SENDWININICHANGE As Integer = &H2

        ''' <summary>
        ''' Convertie une <see cref="Image"/> en Byte Array.
        ''' </summary>
        Shared Function ImageToByteArray(image As Image) As Byte()
            Dim SigBase64 As Byte()
            Dim ms As New MemoryStream()
            Dim btp As New Bitmap(image)
            btp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            SigBase64 = ms.GetBuffer()
            ms.Dispose()
            btp.Dispose()
            Return SigBase64
        End Function
        ''' <summary>
        ''' Convertie une <see cref="Image"/> en Byte Array.
        ''' </summary>
        Shared Function ImageToByteArray(image As Image, format As System.Drawing.Imaging.ImageFormat) As Byte()
            Dim SigBase64 As Byte()
            Dim ms As New MemoryStream()
            Dim btp As New Bitmap(image)
            btp.Save(ms, format)
            SigBase64 = ms.GetBuffer()
            ms.Dispose()
            btp.Dispose()
            Return SigBase64
        End Function
        ''' <summary>
        ''' Convertie un Byte Array en <see cref="Image"/> si la conversion est possible.
        ''' </summary>
        Shared Function ByteArrayToImage(imagebyte As Byte()) As Image
            Dim ms As New IO.MemoryStream(CType(imagebyte, Byte()))
            Dim returnImage As Image = Image.FromStream(ms)
            ms.Dispose()
            Return returnImage
        End Function
        ''' <summary>
        ''' Convertie une <see cref="Image"/> en <see cref="String"/>.
        ''' </summary>
        Shared Function ImageToString(image As Image) As String
            Dim SigBase64 As String = ""
            Dim ms As New MemoryStream()
            Dim btp As New Bitmap(image)
            btp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            SigBase64 = Convert.ToBase64String(ms.GetBuffer())
            ms.Dispose()
            btp.Dispose()
            Return SigBase64
        End Function
        ''' <summary>
        ''' Convertie <see cref="String"/> en <see cref="Image"/> si la conversion est possible.
        ''' </summary>
        Shared Function StringToImage(imageString As String) As Image
            Dim memory As New System.IO.MemoryStream(Convert.FromBase64String(imageString))
            Dim returnImage As Image = Image.FromStream(memory)
            memory.Dispose()
            Return returnImage
        End Function
        ''' <summary>
        ''' Créer un nouveau fond d'écran Windows.
        ''' </summary>
        Shared Sub SetWallpaperByImage(image As Image, clearCreatedFile As Boolean)
            Dim imageLoc As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\xDoofSDK\wallpaper_.bmp"
            Try
                image.Save(imageLoc, System.Drawing.Imaging.ImageFormat.Bmp)
                Win32.User32Function.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLoc, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
            Catch : End Try
            If clearCreatedFile Then
                Try
                    File.Delete(imageLoc)
                Catch : End Try
            End If
        End Sub
        ''' <summary>
        ''' Créer un nouveau fond d'écran Windows.
        ''' </summary>
        Shared Sub SetWallpaperByFile(imageLocation As String)
            If imageLocation.EndsWith(".bmp") Then
                If xDoofSDK.FileSystem.FileSystem.FileExists(imageLocation) Then
                    Try
                        Win32.User32Function.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
                    Catch : End Try
                Else
                    Throw New System.Exception("File " & imageLocation & " not found")
                End If
            Else
                Throw New System.Exception("Only .bmp file supported")
            End If
        End Sub
    End Class
End Namespace
