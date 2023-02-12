
Imports System.IO
Imports System.IO.Compression

Namespace FileSystem
    Public Class FileCompress
        Public Shared Function ExtractToDirectory(archive As ZipArchive, destinationDirPath As String, overwrite As Boolean) As Boolean
            Try
                If Not overwrite Then
                    archive.ExtractToDirectory(destinationDirPath)
                    Return True
                End If

                For Each entry As ZipArchiveEntry In archive.Entries
                    Dim fullPath As String = Path.Combine(destinationDirPath, entry.FullName)
                    If String.IsNullOrEmpty(entry.Name) Then
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath))
                    Else
                        entry.ExtractToFile(fullPath, True)
                    End If
                Next entry
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Public Shared Function Compress(ByVal dirToCompress As String, ByVal fileZippathSave As String, ByVal level As CompressionLevel, ByVal includeBaseDir As Boolean) As Boolean
            ZipFile.CreateFromDirectory(dirToCompress, fileZippathSave, CompressionLevel.Optimal, includeBaseDir)
            Return True
        End Function
    End Class

End Namespace
