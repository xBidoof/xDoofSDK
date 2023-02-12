
Namespace Processus
    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="ProcessusInfo"/>.
    ''' </summary>
    Public Class ProcessusInfo

        Private Shared currProcess As Process()

        Public Sub New()

        End Sub
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
        ''' <summary>
        ''' Spécifie un processus a travaillé dans <see cref="ProcessusInfo"/>.
        ''' </summary>
        Public Function SetProcess(ByVal processName As String) As Boolean
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Return False
            End If
            currProcess = MyP
            Return True
        End Function
        ''' <summary>
        ''' Récupère l'identifiant unique du processus.
        ''' </summary>
        Public ReadOnly Property GetID As Integer
            Get
                If currProcess Is Nothing Then
                    Return -1
                Else
                    Return currProcess(0).Id
                End If
            End Get
        End Property
        ''' <summary>
        ''' Récupère le nom du processus.
        ''' </summary>
        Public ReadOnly Property ProcessusName As String
            Get
                If currProcess Is Nothing Then
                    Return "unknow"
                Else
                    Return currProcess(0).ProcessName
                End If
            End Get
        End Property
        ''' <summary>
        ''' Récupère l'identificateur du processus de session Terminal Server du processus associé.
        ''' </summary>
        Public ReadOnly Property GetSessionID As Integer
            Get
                If currProcess Is Nothing Then
                    Return -1
                Else
                    Return currProcess(0).SessionId
                End If
            End Get
        End Property
        ''' <summary>
        ''' Récupère le <see cref="Process"/> spécifié.
        ''' </summary>
        Public ReadOnly Property GetProcess As Process()
            Get
                If currProcess Is Nothing Then
                    Return Nothing
                Else
                    Return currProcess
                End If
            End Get
        End Property
    End Class
End Namespace
