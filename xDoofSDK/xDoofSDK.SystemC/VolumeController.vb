Imports System.Runtime.InteropServices

Namespace SystemC
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="VolumeController"/>.
    ''' </summary><remarks>Pour initialiser la classe, utiliser la fonction <see cref="InitController"/></remarks>
    Public Class VolumeController

        Private Const WM_CMD As UInteger = &H319
        Private Const CMD_VOLUME_UP As UInteger = &HA
        Private Const CMD_VOLUME_DOWN As UInteger = &H9
        Private Const CMD_VOLUME_MUTE As UInteger = &H8

        Private Shared _ptr As IntPtr
        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

        End Function
        ''' <summary>
        ''' Initialise le Controller pour le volume système.
        ''' </summary>
        ''' <remarks>Par défaut: 'Me.Handle'</remarks>
        Shared Sub InitController(ptr As IntPtr)
            _ptr = ptr
        End Sub
        ''' <summary>        ''' Augmente le volume du système.
        ''' </summary>
        Shared Sub UpVolume()
            SendMessage(_ptr, WM_CMD, &H30292, CMD_VOLUME_UP * &H10000)
        End Sub
        ''' <summary>
        ''' Diminue le volume du système.
        ''' </summary>
        Shared Sub DownVolume()
            SendMessage(_ptr, WM_CMD, &H30292, CMD_VOLUME_DOWN * &H10000)
        End Sub
        ''' <summary>
        ''' Coupe le volume du système.
        ''' </summary>
        Shared Sub MuteVolume()
            SendMessage(_ptr, WM_CMD, &H200EB0, CMD_VOLUME_MUTE * &H10000)
        End Sub
    End Class

End Namespace