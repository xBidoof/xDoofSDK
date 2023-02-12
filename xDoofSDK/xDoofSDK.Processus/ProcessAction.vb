

Namespace Processus
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="ProcessusAction"/>.
    ''' </summary>
    Public Class ProcessusAction

        Private Shared currProcess As Process()
        Public Sub New(ByVal processName As String)
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                currProcess = Nothing
            Else
                currProcess = MyP
            End If
        End Sub

        Public Sub New(ByVal process As Process())
            currProcess = process
        End Sub
        ''' <summary>
        ''' Arrête immédiatement le processus si il est en cours d'exécution.
        ''' </summary>
        Public Sub KillProcessus()
            Try
                currProcess(0).Kill()
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Démarre (ou démarre une nouvelle instance) du processus spécifié.
        ''' </summary>
        Public Sub Start()
            Try
                currProcess(0).Start()
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Libères toutes les ressources associé à ce composant.
        ''' </summary>
        Public Sub ReleaseResources()
            Try
                currProcess(0).Close()
            Catch : End Try
        End Sub
    End Class
End Namespace
