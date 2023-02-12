
Namespace Processus
    Public Class ProcessStart
        Friend Shared Sub StartProcess(ByVal pathExecutable As String, ByVal args As String)
            Dim Proc As New Process
            Proc.StartInfo.FileName = pathExecutable
            Proc.StartInfo.Arguments = args
            Proc.Start()
            Do Until Proc.HasExited
            Loop
            Proc.Dispose()
        End Sub
    End Class
End Namespace
