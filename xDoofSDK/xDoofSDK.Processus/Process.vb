
Namespace Processus
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="Processus"/>.
    ''' </summary>
    Public Class Processus
        Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer

        Private Const PROCESS_ALL_ACCESS = &H1F0FF
        ''' <summary>
        ''' Ouvre un processus en cours d'exécution sur l'ordinateur.
        ''' </summary>
        Public Shared Function ProcessusOpen(ByVal processName As String) As Integer
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Return -1
            End If
            Return OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        End Function
        ''' <summary>
        ''' Récupère un <see cref="Process"/> selon le nom du processus spécifié.
        ''' </summary><returns>Retourne Nothing si non trouvé</returns>
        Public Shared Function GetProcessusByName(ByVal processName As String, Optional ByVal removeExeExtension As Boolean = True) As Process
            If removeExeExtension = True Then
                If processName.EndsWith(".exe") Then
                    processName = processName.Replace(".exe", "")
                End If
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Return Nothing
            End If
            Return MyP(0)
        End Function
        ''' <summary>
        ''' Récupère un <see cref="Process"/> selon l'identificateur du processus.
        ''' </summary>
        Public Shared Function GetProcessusByID(ByVal processID As Integer, ByVal machineName As String) As Process
            Dim MyP As Process = Process.GetProcessById(processID, machineName)
            Return MyP
        End Function
        ''' <summary>
        ''' Lance un processus demandé.
        ''' </summary>
        Public Shared Sub StartProcessus(ByVal processName As String, Optional ByVal argument As String = "")
            Try
                Process.Start(processName, argument)
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Arrête un processus demandé.
        ''' </summary>
        Public Shared Sub ProcessusClose(ByVal processName As String)
            Try
                Dim psi As ProcessStartInfo = New ProcessStartInfo
                psi.Arguments = "/im " & processName & " /f"
                psi.FileName = "taskkill"
                Dim p As Process = New Process()
                p.StartInfo = psi
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.Start()
            Catch : End Try
        End Sub
        ''' <summary>
        ''' Arrête un processus spécifié avec le nom et extension avec la méthode execquery.
        ''' </summary>
        Public Shared Sub ProcessusCloseQuery(ByVal processName As String)
            Try
                Dim svc As Object
                Dim sQuery As String
                Dim oproc
                svc = GetObject("winmgmts:root\cimv2")
                sQuery = "select * from win32_process where name='" & processName & "'"
                For Each oproc In svc.execquery(sQuery)
                    Try
                        oproc.Terminate()
                    Catch ex As Exception

                    End Try
                Next
                svc = Nothing
            Catch : End Try
        End Sub
    End Class
End Namespace