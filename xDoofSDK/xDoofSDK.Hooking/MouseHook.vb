Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Threading
Imports System.Drawing
Imports System.Windows.Forms

Namespace Hooking

    Public Class MouseHook
        Private HookProc As CallBack
        Private hHook As IntPtr = 0

        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As CallBack, ByVal hmod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
        End Function
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Shared Function CallNextHookEx(ByVal hHook As IntPtr, ByVal nCode As Integer, <[Out]()> ByVal wParam As WindowsMessageType, <[In]()> ByRef lParam As MSLLHOOKSTRUCT) As IntPtr
        End Function
        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Shared Function UnhookWindowsHookEx(ByVal hHook As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Shared Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
        End Function
        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Private Shared Function GetModuleHandleW(ByVal fakezero As IntPtr) As IntPtr
        End Function
        Private Function GetCurrentThreadId() As Integer
            Return Process.GetCurrentProcess.Threads(0).Id
        End Function
        Private Function GetCurrentHandleModule() As IntPtr
            Return GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName)
        End Function
        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
        Public Overloads Shared Function GetDoubleClickTime() As Integer
        End Function

        <StructLayout(LayoutKind.Sequential)>
        Structure MSLLHOOKSTRUCT
            Public pt As Point
            Public mouseData As Int32
            Public flags As LLMHFlags
            Public time As Int32
            Public dwExtraInfo As UIntPtr
        End Structure
        <Flags()>
        Enum LLMHFlags As Int32
            LLMHF_INJECTED = 1
            LLMHF_LOWER_IL_INJECTED = 2
        End Enum
        Enum HookType As Integer
            WH_JOURNALRECORD = 0
            WH_JOURNALPLAYBACK = 1
            WH_KEYBOARD = 2
            WH_GETMESSAGE = 3
            WH_CALLWNDPROC = 4
            WH_CBT = 5
            WH_SYSMSGFILTER = 6
            WH_MOUSE = 7
            WH_HARDWARE = 8
            WH_DEBUG = 9
            WH_SHELL = 10
            WH_FOREGROUNDIDLE = 11
            WH_CALLWNDPROCRET = 12
            WH_KEYBOARD_LL = 13
            WH_MOUSE_LL = 14
        End Enum
        Enum MouseType As Integer
            WM_MOUSEMOVE = &H200
            WM_LBUTTONDOWN = &H201
            WM_LBUTTONUP = &H202
            WM_LBUTTONDBLCLK = &H203    'Message non traduit (voir fonction: DoubleClick)
            WM_RBUTTONDOWN = &H204
            WM_RBUTTONUP = &H205
            WM_RBUTTONDBLCLK = &H206    'Message non traduit (voir fonction: DoubleClick)
            WM_MBUTTONDOWN = &H207
            WM_MBUTTONUP = &H208
            WM_MBUTTONDBLCLK = &H209    'Message non traduit (voir fonction: DoubleClick)
            WM_MOUSEWHEEL = &H20A
        End Enum
        Public Enum MouseWheelType As Integer
            HAUT = 0
            BAS = 1
        End Enum
        Enum WindowsMessageType As UInteger
            WM_ACTIVATE = &H6

            WM_ACTIVATEAPP = &H1C

            WM_AFXFIRST = &H360

            WM_AFXLAST = &H37F

            WM_APP = &H8000

            WM_ASKCBFORMATNAME = &H30C

            WM_CANCELJOURNAL = &H4B

            WM_CANCELMODE = &H1F

            WM_CAPTURECHANGED = &H215

            WM_CHANGECBCHAIN = &H30D

            WM_CHANGEUISTATE = &H127

            WM_CHAR = &H102

            WM_CHARTOITEM = &H2F

            WM_CHILDACTIVATE = &H22

            WM_CLEAR = &H303

            WM_CLOSE = &H10

            WM_COMMAND = &H111

            WM_COMPACTING = &H41

            WM_COMPAREITEM = &H39

            WM_CONTEXTMENU = &H7B

            WM_COPY = &H301

            WM_COPYDATA = &H4A

            WM_CREATE = &H1

            WM_CTLCOLORBTN = &H135

            WM_CTLCOLORDLG = &H136

            WM_CTLCOLOREDIT = &H133

            WM_CTLCOLORLISTBOX = &H134

            WM_CTLCOLORMSGBOX = &H132

            WM_CTLCOLORSCROLLBAR = &H137

            WM_CTLCOLORSTATIC = &H138

            WM_CUT = &H300

            WM_DEADCHAR = &H103

            WM_DELETEITEM = &H2D

            WM_DESTROY = &H2

            WM_DESTROYCLIPBOARD = &H307

            WM_DEVICECHANGE = &H219

            WM_DEVMODECHANGE = &H1B

            WM_DISPLAYCHANGE = &H7E

            WM_DRAWCLIPBOARD = &H308

            WM_DRAWITEM = &H2B

            WM_DROPFILES = &H233

            WM_ENABLE = &HA

            WM_ENDSESSION = &H16

            WM_ENTERIDLE = &H121

            WM_ENTERMENULOOP = &H211

            WM_ENTERSIZEMOVE = &H231

            WM_ERASEBKGND = &H14

            WM_EXITMENULOOP = &H212

            WM_EXITSIZEMOVE = &H232

            WM_FONTCHANGE = &H1D

            WM_GETDLGCODE = &H87

            WM_GETFONT = &H31

            WM_GETHOTKEY = &H33

            WM_GETICON = &H7F

            WM_GETMINMAXINFO = &H24

            WM_GETOBJECT = &H3D

            WM_GETTEXT = &HD

            WM_GETTEXTLENGTH = &HE

            WM_HANDHELDFIRST = &H358

            WM_HANDHELDLAST = &H35F

            WM_HELP = &H53

            WM_HOTKEY = &H312

            WM_HSCROLL = &H114

            WM_HSCROLLCLIPBOARD = &H30E

            WM_ICONERASEBKGND = &H27

            WM_IME_CHAR = &H286

            WM_IME_COMPOSITION = &H10F

            WM_IME_COMPOSITIONFULL = &H284

            WM_IME_CONTROL = &H283

            WM_IME_ENDCOMPOSITION = &H10E

            WM_IME_KEYDOWN = &H290

            WM_IME_KEYLAST = &H10F

            WM_IME_KEYUP = &H291

            WM_IME_NOTIFY = &H282

            WM_IME_REQUEST = &H288

            WM_IME_SELECT = &H285

            WM_IME_SETCONTEXT = &H281

            WM_IME_STARTCOMPOSITION = &H10D

            WM_INITDIALOG = &H110

            WM_INITMENU = &H116

            WM_INITMENUPOPUP = &H117

            WM_INPUTLANGCHANGE = &H51

            WM_INPUTLANGCHANGEREQUEST = &H50

            WM_KEYDOWN = &H100

            WM_KEYFIRST = &H100

            WM_KEYLAST = &H108

            WM_KEYUP = &H101

            WM_KILLFOCUS = &H8

            WM_LBUTTONDBLCLK = &H203

            WM_LBUTTONDOWN = &H201

            WM_LBUTTONUP = &H202

            WM_MBUTTONDBLCLK = &H209

            WM_MBUTTONDOWN = &H207

            WM_MBUTTONUP = &H208

            WM_MDIACTIVATE = &H222

            WM_MDICASCADE = &H227

            WM_MDICREATE = &H220

            WM_MDIDESTROY = &H221

            WM_MDIGETACTIVE = &H229

            WM_MDIICONARRANGE = &H228

            WM_MDIMAXIMIZE = &H225

            WM_MDINEXT = &H224

            WM_MDIREFRESHMENU = &H234

            WM_MDIRESTORE = &H223

            WM_MDISETMENU = &H230

            WM_MDITILE = &H226

            WM_MEASUREITEM = &H2C

            WM_MENUCHAR = &H120

            WM_MENUCOMMAND = &H126

            WM_MENUDRAG = &H123

            WM_MENUGETOBJECT = &H124

            WM_MENURBUTTONUP = &H122

            WM_MENUSELECT = &H11F

            WM_MOUSEACTIVATE = &H21

            WM_MOUSEFIRST = &H200

            WM_MOUSEHOVER = &H2A1

            WM_MOUSELAST = &H20D

            WM_MOUSELEAVE = &H2A3

            WM_MOUSEMOVE = &H200

            WM_MOUSEWHEEL = &H20A

            WM_MOUSEHWHEEL = &H20E

            WM_MOVE = &H3

            WM_MOVING = &H216

            WM_NCACTIVATE = &H86

            WM_NCCALCSIZE = &H83

            WM_NCCREATE = &H81

            WM_NCDESTROY = &H82

            WM_NCHITTEST = &H84

            WM_NCLBUTTONDBLCLK = &HA3

            WM_NCLBUTTONDOWN = &HA1

            WM_NCLBUTTONUP = &HA2

            WM_NCMBUTTONDBLCLK = &HA9

            WM_NCMBUTTONDOWN = &HA7

            WM_NCMBUTTONUP = &HA8

            WM_NCMOUSELEAVE = &H2A2

            WM_NCMOUSEMOVE = &HA0

            WM_NCPAINT = &H85

            WM_NCRBUTTONDBLCLK = &HA6

            WM_NCRBUTTONDOWN = &HA4

            WM_NCRBUTTONUP = &HA5

            WM_NEXTDLGCTL = &H28

            WM_NEXTMENU = &H213

            WM_NOTIFY = &H4E

            WM_NOTIFYFORMAT = &H55

            WM_NULL = &H0

            WM_PAINT = &HF

            WM_PAINTCLIPBOARD = &H309

            WM_PAINTICON = &H26

            WM_PALETTECHANGED = &H311

            WM_PALETTEISCHANGING = &H310

            WM_PARENTNOTIFY = &H210

            WM_PASTE = &H302

            WM_PENWINFIRST = &H380

            WM_PENWINLAST = &H38F

            WM_POWER = &H48

            WM_POWERBROADCAST = &H218

            WM_PRINT = &H317

            WM_PRINTCLIENT = &H318

            WM_QUERYDRAGICON = &H37

            WM_QUERYENDSESSION = &H11

            WM_QUERYNEWPALETTE = &H30F

            WM_QUERYOPEN = &H13

            WM_QUEUESYNC = &H23

            WM_QUIT = &H12

            WM_RBUTTONDBLCLK = &H206

            WM_RBUTTONDOWN = &H204

            WM_RBUTTONUP = &H205

            WM_RENDERALLFORMATS = &H306

            WM_RENDERFORMAT = &H305

            WM_SETCURSOR = &H20

            WM_SETFOCUS = &H7

            WM_SETFONT = &H30

            WM_SETHOTKEY = &H32

            WM_SETICON = &H80

            WM_SETREDRAW = &HB

            WM_SETTEXT = &HC

            WM_SETTINGCHANGE = &H1A

            WM_SHOWWINDOW = &H18

            WM_SIZE = &H5

            WM_SIZECLIPBOARD = &H30B

            WM_SIZING = &H214

            WM_SPOOLERSTATUS = &H2A

            WM_STYLECHANGED = &H7D

            WM_STYLECHANGING = &H7C

            WM_SYNCPAINT = &H88

            WM_SYSCHAR = &H106

            WM_SYSCOLORCHANGE = &H15

            WM_SYSCOMMAND = &H112

            WM_SYSDEADCHAR = &H107

            WM_SYSKEYDOWN = &H104

            WM_SYSKEYUP = &H105

            WM_TCARD = &H52

            WM_TIMECHANGE = &H1E

            WM_TIMER = &H113

            WM_UNDO = &H304

            WM_UNINITMENUPOPUP = &H125

            WM_USER = &H400

            WM_USERCHANGED = &H54

            WM_VKEYTOITEM = &H2E

            WM_VSCROLL = &H115

            WM_VSCROLLCLIPBOARD = &H30A

            WM_WINDOWPOSCHANGED = &H47

            WM_WINDOWPOSCHANGING = &H46

            WM_WININICHANGE = &H1A

            WM_XBUTTONDBLCLK = &H20D

            WM_XBUTTONDOWN = &H20B

            WM_XBUTTONUP = &H20C
        End Enum

        Public Event MouseMove(ByVal pt As Point)
        Public Event MouseLeftClickDown(ByVal pt As Point)
        Public Event MouseLeftClickUp(ByVal pt As Point)
        Public Event MouseLeftDoubleClick(ByVal pt As Point)
        Public Event MouseRightClickDown(ByVal pt As Point)
        Public Event MouseRightClickUp(ByVal pt As Point)
        Public Event MouseRightDoubleClick(ByVal pt As Point)
        Public Event MouseMiddleClickDown(ByVal pt As Point)
        Public Event MouseMiddleClickUp(ByVal pt As Point)
        Public Event MouseMiddleDoubleClick(ByVal pt As Point)
        Public Event MouseWheel(ByVal pt As Point, ByVal Direction As MouseWheelType)

        Public Sub New()
            Dim SelectedHookType As HookType = HookType.WH_MOUSE_LL

            HookProc = New CallBack(AddressOf MouseHookProc)
            Select Case SelectedHookType
                Case HookType.WH_MOUSE_LL
                    hHook = SetWindowsHookEx(SelectedHookType, HookProc, GetModuleHandleW(IntPtr.Zero), 0)
                Case Else
                    Me.UnMouseHook()
                    Exit Sub
            End Select
            If hHook = 0 Then

            End If
        End Sub

        Dim PushClick As Integer = 1
        Dim PushStack() As Integer = {-1, 0, 0, 0, 0}
        Dim PushInterval As Integer = GetDoubleClickTime()
        Private Function DoubleClick(ByVal lTimer As Integer) As Boolean
            Select Case PushClick
                Case 1
                    PushStack(1) = lTimer
                    PushClick = 2
                Case 2
                    PushStack(2) = lTimer
                    PushClick = 3
                    If PushStack(3) = 0 Then Return False
                    If PushInterval >= (PushStack(2) - PushStack(3)) Then Return True
                Case 3
                    PushStack(3) = lTimer
                    PushClick = 4
                Case 4
                    PushStack(4) = lTimer
                    PushClick = 1
                    If PushStack(1) = 0 Then Return False
                    If PushInterval >= (PushStack(4) - PushStack(1)) Then Return True
            End Select
            Return False
        End Function

        Private Delegate Function CallBack(ByVal nCode As Integer, ByVal wParam As WindowsMessageType, ByRef lParam As MSLLHOOKSTRUCT) As Int32
        Private Function MouseHookProc(ByVal nCode As Integer, ByVal wParam As WindowsMessageType, ByRef lParam As MSLLHOOKSTRUCT) As Int32
            If nCode = 0 Then
                Select Case wParam
                    Case MouseType.WM_MOUSEMOVE
                        RaiseEvent MouseMove(lParam.pt)
                    Case MouseType.WM_LBUTTONDOWN
                        If DoubleClick(lParam.time) = True Then
                            RaiseEvent MouseLeftDoubleClick(lParam.pt)
                        Else
                            RaiseEvent MouseLeftClickDown(lParam.pt)
                        End If
                    Case MouseType.WM_LBUTTONUP
                        If DoubleClick(lParam.time) = True Then
                            RaiseEvent MouseLeftDoubleClick(lParam.pt)
                        Else
                            RaiseEvent MouseLeftClickUp(lParam.pt)
                        End If
                    Case MouseType.WM_RBUTTONDOWN
                        If DoubleClick(lParam.time) = True Then
                            RaiseEvent MouseRightDoubleClick(lParam.pt)
                        Else
                            RaiseEvent MouseRightClickDown(lParam.pt)
                        End If
                    Case MouseType.WM_RBUTTONUP
                        If DoubleClick(lParam.time) = True Then
                            RaiseEvent MouseRightDoubleClick(lParam.pt)
                        Else
                            RaiseEvent MouseRightClickUp(lParam.pt)
                        End If
                    Case MouseType.WM_MBUTTONDOWN
                        If DoubleClick(lParam.time) = True Then
                            RaiseEvent MouseMiddleDoubleClick(lParam.pt)
                        Else
                            RaiseEvent MouseMiddleClickDown(lParam.pt)
                        End If
                    Case MouseType.WM_MBUTTONUP
                        If DoubleClick(lParam.time) = True Then
                            RaiseEvent MouseMiddleDoubleClick(lParam.pt)
                        Else
                            RaiseEvent MouseMiddleClickUp(lParam.pt)
                        End If
                    Case MouseType.WM_MOUSEWHEEL
                        Dim wDirection As MouseWheelType
                        If lParam.mouseData < 0 Then
                            wDirection = MouseWheelType.BAS
                        Else
                            wDirection = MouseWheelType.HAUT
                        End If
                        RaiseEvent MouseWheel(lParam.pt, wDirection)
                End Select
            End If
            Return CallNextHookEx(hHook, nCode, wParam, lParam)
        End Function

        Public Sub UnMouseHook()
            Dim rt As Boolean = UnhookWindowsHookEx(hHook)
            If rt = False Then

            Else
                Me.HookProc = Nothing
                MyBase.Finalize()
            End If
        End Sub
    End Class

End Namespace