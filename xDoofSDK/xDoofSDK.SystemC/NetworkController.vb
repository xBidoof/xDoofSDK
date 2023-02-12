Imports System.Management
Imports System.Net
Imports System.Runtime.InteropServices

Namespace SystemC
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="NetworkController"/>.
    ''' </summary>
    ''' <remarks>Utiliser les fonctions avec parcimonie.</remarks>
    Public Class NetworkController
        ''' <summary>
        ''' Active l'adaptateur.
        ''' </summary>
        ''' <remarks>Un accès du programme en administrateur est requis pour utiliser cette fonction.</remarks>
        Shared Sub EnableAdapter(ByVal awaitTerminated As Boolean)
            Dim mm As New Process
            mm.StartInfo.FileName = "wmic"
            mm.StartInfo.Arguments = "path win32_networkadapter where PhysicalAdapter=True call enable"
            mm.StartInfo.CreateNoWindow = True
            mm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            mm.StartInfo.UseShellExecute = False
            mm.StartInfo.ErrorDialog = True
            If awaitTerminated Then
                mm.Start()
                Do Until mm.HasExited
                Loop
            Else
                mm.Start()
            End If
        End Sub
        ''' <summary>
        ''' Désactive l'adaptateur.
        ''' </summary>
        ''' ''' <remarks>Un accès du programme en administrateur est requis pour utiliser cette fonction.</remarks>
        Shared Sub DisableAdapter(ByVal awaitTerminated As Boolean)
            Dim mm As New Process
            mm.StartInfo.FileName = "wmic"
            mm.StartInfo.Arguments = "path win32_networkadapter where PhysicalAdapter=True call disable"
            mm.StartInfo.CreateNoWindow = True
            mm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            mm.StartInfo.UseShellExecute = False
            mm.StartInfo.ErrorDialog = True
            If awaitTerminated Then
                mm.Start()
                Do Until mm.HasExited
                Loop
            Else
                mm.Start()
            End If
        End Sub
        ''' <summary>
        ''' Vérifie si une connectivité est disponible
        ''' </summary>
        Shared Function HasConnectivity() As Boolean
            Dim iHost As IPHostEntry
            Try
                Dim sServ As String = Environment.GetEnvironmentVariable("logonserver")
                iHost = System.Net.Dns.GetHostEntry(sServ.Remove(0, 2))
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace