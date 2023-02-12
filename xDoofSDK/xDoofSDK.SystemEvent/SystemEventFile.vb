Imports System.IO

Namespace SystemEvent
    Public Class SystemEventFile

        Private Shared fileinitlz As New FileSystemWatcher

        Public Shared Event OnFileCreated(FullPath As String, NameFile As String)
        Public Shared Event OnFileDeleted(FullPath As String, NameFile As String)
        Public Shared Event OnFileRenamed(OldFullPath As String, NewFullPath As String, OldName As String, NewName As String)

        Sub New(path As String)
            fileinitlz.Path = path
            fileinitlz.IncludeSubdirectories = True
            fileinitlz.BeginInit()
            AddHandler fileinitlz.Created, AddressOf OnCreatedFile
            AddHandler fileinitlz.Deleted, AddressOf OnDeletedFile
            AddHandler fileinitlz.Renamed, AddressOf OnRenamedFile
        End Sub

        Shared Sub ForceDisable()
            RemoveHandler fileinitlz.Created, AddressOf OnCreatedFile
            RemoveHandler fileinitlz.Deleted, AddressOf OnDeletedFile
            RemoveHandler fileinitlz.Renamed, AddressOf OnRenamedFile
        End Sub

        Private Shared Sub OnCreatedFile(sender As Object, e As FileSystemEventArgs)
            RaiseEvent OnFileCreated(e.FullPath, e.Name)
        End Sub

        Private Shared Sub OnDeletedFile(sender As Object, e As FileSystemEventArgs)
            RaiseEvent OnFileDeleted(e.FullPath, e.Name)
        End Sub

        Private Shared Sub OnRenamedFile(sender As Object, e As RenamedEventArgs)
            RaiseEvent OnFileRenamed(e.OldFullPath, e.FullPath, e.OldName, e.Name)
        End Sub

    End Class
End Namespace
