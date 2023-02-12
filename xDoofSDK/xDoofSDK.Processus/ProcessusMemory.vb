Namespace Processus

    ''' <summary>
    ''' Initialise une nouvelle instance de la classe <see cref="ProcessusMemory"/>.
    ''' </summary>
    Public Class ProcessusMemory
        Private Declare Function WriteProcessMemory1 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Integer, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
        Private Declare Function WriteProcessMemory2 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Single
        Private Declare Function WriteProcessMemory3 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Long, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Long

        Private Declare Function ReadProcessMemory1 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Integer, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
        Private Declare Function ReadProcessMemory2 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Single
        Private Declare Function ReadProcessMemory3 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByRef lpBuffer As Long, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Long

        Public Shared Function WriteDMAInteger(ByVal processName As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Value As Integer, ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Boolean
            Try
                Dim lvl As Integer = Address
                For i As Integer = 1 To Level
                    lvl = ReadInteger(processName, lvl, nsize) + Offsets(i - 1)
                Next
                WriteInteger(processName, lvl, Value, nsize)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function ReadDMAInteger(ByVal processName As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Integer
            Try
                Dim lvl As Integer = Address
                For i As Integer = 1 To Level
                    lvl = ReadInteger(processName, lvl, nsize) + Offsets(i - 1)
                Next
                Dim vBuffer As Integer
                vBuffer = ReadInteger(processName, lvl, nsize)
                Return vBuffer
            Catch ex As Exception
                Return -1
            End Try
        End Function

        Public Shared Function WriteDMAFloat(ByVal processName As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Value As Single, ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Boolean
            Try
                Dim lvl As Integer = Address
                For i As Integer = 1 To Level
                    lvl = ReadFloat(processName, lvl, nsize) + Offsets(i - 1)
                Next
                WriteFloat(processName, lvl, Value, nsize)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function ReadDMAFloat(ByVal processName As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Single
            Try
                Dim lvl As Integer = Address
                For i As Integer = 1 To Level
                    lvl = ReadFloat(processName, lvl, nsize) + Offsets(i - 1)
                Next
                Dim vBuffer As Single
                vBuffer = ReadFloat(processName, lvl, nsize)
                Return vBuffer
            Catch ex As Exception
                Return -1
            End Try
        End Function

        Public Shared Function WriteDMALong(ByVal processName As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Value As Long, ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Boolean
            Try
                Dim lvl As Integer = Address
                For i As Integer = 1 To Level
                    lvl = ReadLong(processName, lvl, nsize) + Offsets(i - 1)
                Next
                WriteLong(processName, lvl, Value, nsize)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function ReadDMALong(ByVal processName As String, ByVal Address As Integer, ByVal Offsets As Integer(), ByVal Level As Integer, Optional ByVal nsize As Integer = 4) As Long
            Try
                Dim lvl As Integer = Address
                For i As Integer = 1 To Level
                    lvl = ReadLong(processName, lvl, nsize) + Offsets(i - 1)
                Next
                Dim vBuffer As Long
                vBuffer = ReadLong(processName, lvl, nsize)
                Return vBuffer
            Catch ex As Exception
                Return -1
            End Try
        End Function

        Public Shared Sub WriteNOPs(ByVal processName As String, ByVal Address As Long, ByVal NOPNum As Integer)
            Dim C As Integer
            Dim B As Integer
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Exit Sub
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Exit Sub
            End If

            B = 0
            For C = 1 To NOPNum
                Call WriteProcessMemory1(hProcess, Address + B, &H90, 1, 0&)
                B = B + 1
            Next C
        End Sub

        Public Shared Sub WriteXBytes(ByVal processName As String, ByVal Address As Long, ByVal Value As String)
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Exit Sub
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Exit Sub
            End If

            Dim C As Integer
            Dim B As Integer
            Dim D As Integer
            Dim V As Byte

            B = 0
            D = 1
            For C = 1 To Math.Round((Len(Value) / 2))
                V = Val("&H" & Mid$(Value, D, 2))
                Call WriteProcessMemory1(hProcess, Address + B, V, 1, 0&)
                B = B + 1
                D = D + 2
            Next C

        End Sub

        Public Shared Sub WriteInteger(ByVal processName As String, ByVal Address As Integer, ByVal Value As Integer, Optional ByVal nsize As Integer = 4)
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Exit Sub
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Exit Sub
            End If

            Dim hAddress, vBuffer As Integer
            hAddress = Address
            vBuffer = Value
            WriteProcessMemory1(hProcess, hAddress, CInt(vBuffer), nsize, 0)
        End Sub

        Public Shared Sub WriteFloat(ByVal processName As String, ByVal Address As Integer, ByVal Value As Single, Optional ByVal nsize As Integer = 4)
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Exit Sub
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Exit Sub
            End If

            Dim hAddress As Integer
            Dim vBuffer As Single

            hAddress = Address
            vBuffer = Value
            WriteProcessMemory2(hProcess, hAddress, vBuffer, nsize, 0)
        End Sub

        Public Shared Sub WriteLong(ByVal processName As String, ByVal Address As Integer, ByVal Value As Long, Optional ByVal nsize As Integer = 4)
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Exit Sub
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Exit Sub
            End If

            Dim hAddress As Integer
            Dim vBuffer As Long

            hAddress = Address
            vBuffer = Value
            WriteProcessMemory3(hProcess, hAddress, vBuffer, nsize, 0)
        End Sub

        Public Shared Function ReadInteger(ByVal processName As String, ByVal Address As Integer, Optional ByVal nsize As Integer = 4) As Integer
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Return -1
                Exit Function
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Return -1
                Exit Function
            End If

            Dim hAddress, vBuffer As Integer
            hAddress = Address
            ReadProcessMemory1(hProcess, hAddress, vBuffer, nsize, 0)
            Return vBuffer
        End Function

        Public Shared Function ReadFloat(ByVal processName As String, ByVal Address As Integer, Optional ByVal nsize As Integer = 4) As Single
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Return -1
                Exit Function
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Return -1
                Exit Function
            End If

            Dim hAddress As Integer
            Dim vBuffer As Single

            hAddress = Address
            ReadProcessMemory2(hProcess, hAddress, vBuffer, nsize, 0)
            Return vBuffer
        End Function

        Public Shared Function ReadLong(ByVal processName As String, ByVal Address As Integer, Optional ByVal nsize As Integer = 4) As Long
            If processName.EndsWith(".exe") Then
                processName = processName.Replace(".exe", "")
            End If
            Dim MyP As Process() = Process.GetProcessesByName(processName)
            If MyP.Length = 0 Then
                Return -1
                Exit Function
            End If
            Dim hProcess As IntPtr = Processus.ProcessusOpen(processName)
            If hProcess = IntPtr.Zero Then
                Return -1
                Exit Function
            End If

            Dim hAddress As Integer
            Dim vBuffer As Long

            hAddress = Address
            ReadProcessMemory3(hProcess, hAddress, vBuffer, nsize, 0)
            Return vBuffer
        End Function
    End Class
End Namespace
