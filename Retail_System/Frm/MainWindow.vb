'Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports PClass.PClass
Imports System.IO
Imports System.Reflection
Imports PClass


Public Class MainWindow
    Implements IReturnObj

#Region "快捷键"
    Public Const WM_HOTKEY = &H312
    Public Const MOD_ALT = &H1
    Public Const MOD_CONTROL = &H2
    Public Const MOD_SHIFT = &H4
    Public Const GWL_WNDPROC = (-4)
    Public Declare Auto Function RegisterHotKey Lib "user32.dll" Alias _
        "RegisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Boolean
    Public Declare Auto Function UnRegisterHotKey Lib "user32.dll" Alias _
        "UnregisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer) As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RegisterHotKey(Handle, 0, MOD_CONTROL, Asc("Q")) '注册Ctrl+T的组合键
        RegisterHotKey(Handle, 1, MOD_CONTROL, Asc("W")) '注册Ctrl+T的组合键
        RegisterHotKey(Handle, 2, MOD_CONTROL, Asc("E")) '注册Ctrl+T的组合键
    End Sub
    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        UnRegisterHotKey(Handle, 0)
        UnRegisterHotKey(Handle, 1)
        UnRegisterHotKey(Handle, 2)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HOTKEY Then
            Select Case m.LParam.ToString("X")
                Case CASAndCapToString(MOD_CONTROL, "Q")
                    ChatClient.StartCutPic()
                Case CASAndCapToString(MOD_CONTROL, "W") '隐藏显示
                    If Visible Then
                        Hide()
                    Else
                        Show()
                    End If
                Case CASAndCapToString(MOD_CONTROL, "E") '显示为阅读的信息
                    ChatClient.ShowUnReadMsg()
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Public Shared Function CASAndCapToString(ByVal fsModifiers As Integer, ByVal C As Char) As String
        Return Asc(C).ToString("X") & fsModifiers.ToString("0000")
    End Function


#End Region


    Dim MenuLoadOK As Boolean = False
    Dim ControlFile As XtremeCommandBars.CommandBarPopup = Nothing
    Dim ControlAbout As XtremeCommandBars.CommandBarControl = Nothing
    Public ReLoad As Boolean = False
    Public IsLoad As Boolean = False

    Public IsClosing_NotCheck As Boolean = False
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If IsClosing_NotCheck = False AndAlso Not MsgBox("是否关闭本系统?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            e.Cancel = True
            Exit Sub
        End If
        CloseWindows()
    End Sub

    Delegate Sub DCloseWindows()
    Sub CloseWindows()
        LastUpdateID = 0
        IsClosing_NotCheck = False
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
        Me.Refresh()
        ChatClient.CloseAllDialog()
        Me.Timer1.Enabled = False
        If ReLoad Then
            ReLoad = False
            FormLogon.Show()
            FormLogon.Activate()
            FormLogon.WindowState = FormWindowState.Normal
        Else
            End
        End If
    End Sub


    Public Const ID_INDICATOR_CAPS = 59137
    Public Const ID_INDICATOR_NUM = 59138
    Public Const ID_INDICATOR_SCRL = 59139

    Public Const ID_User_ID = 888888801
    Public Const ID_Time = 888888803
    Public Const ID_Net = 888888805
    Public Pand_Time As XtremeCommandBars.StatusBarPane
    Public Pand_Net As XtremeCommandBars.StatusBarPane


    Private Sub SetFont(ByVal RibbonBar As XtremeCommandBars.RibbonBar)
        CommandBars.Options.Font.Name = "宋体"
        CommandBars.Options.Font.Size = 9.75
        CommandBars.Options.Font.Italic = False
        CommandBars.Options.Font.Bold = False
        CommandBars.Options.Font.Strikethrough = False
        CommandBars.Options.Font.Underline = False
        RibbonBar.FontHeight = 9.75
    End Sub


    '主窗口加载
    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IsLoad = False
        MainForm = Me
        IMainForm = Me
        RunningTime = 0
        If My.Application.Info.Title <> "" Then
            Me.Text = My.Application.Info.Title & Format(GetAppVer, "0.00")
        Else
            '若应用程序标题丢失，则使用不带扩展名的应用程序名
            Me.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName) & Format(GetAppVer, "0.00")
        End If


        ' Get_Dt_Right() '加载权限
        Try
            CreateRibbonBar()
        Catch ex As Exception
            MsgBox("主窗口加载错误" & e.ToString, MsgBoxStyle.Exclamation)

        End Try
        Dim StatusBar As XtremeCommandBars.StatusBar
        StatusBar = CommandBars.StatusBar
        StatusBar.Visible = True
        StatusBar.AddPane(0)
        StatusBar.AddPane(ID_User_ID - 1).Text = IIf(User_Id = "Admin", "PClass的版本[" & FormatN(GetPClassVer(), 2) & "]  " & " 数据库:" & DBMsg & " 帐号:", "帐号:")
        Dim P As XtremeCommandBars.StatusBarPane
        P = StatusBar.AddPane(ID_User_ID)
        P.Text = User_Display
        P.TextColor = &HFFFF
        StatusBar.AddPane(ID_Time - 1).Text = "服务器时间:"
        Pand_Time = StatusBar.AddPane(ID_Time)
        Pand_Time.TextColor = &HFFFF


        Pand_Net = StatusBar.AddPane(ID_Net)
        Pand_Net.TextColor = &HFF
        Pand_Net.Visible = False

        ChangeTime()


        StatusBar.AddPane(0)
        StatusBar.AddPane(ID_INDICATOR_CAPS).Alignment = XTPTextAlignment.xtpAlignmentRight
        StatusBar.AddPane(ID_INDICATOR_NUM).Alignment = XTPTextAlignment.xtpAlignmentRight
        StatusBar.AddPane(ID_INDICATOR_SCRL).Alignment = XTPTextAlignment.xtpAlignmentRight
        '检查屏幕尺寸 自动缩小菜单

        If Screen.PrimaryScreen.Bounds.Height < 600 Then
            CommandBars.ActiveMenuBar.Minimized = True
        End If


        CType(CommandBars.ActiveMenuBar, XtremeCommandBars.RibbonBar).EnableFrameTheme()
        CommandBars.Options.KeyboardCuesShow = XtremeCommandBars.XTPKeyboardCuesShow.xtpKeyboardCuesShowWindowsDefault
        CommandBars.VisualTheme = XTPVisualTheme.xtpThemeVisualStudio2008
        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is MdiClient Then
                CommandBars.SetMDIClient(ctrl.Handle.ToInt32())
            End If
        Next ctrl

        'StatusBar.AddPane(ID_User_ID - 1).Text = IIf(User_Id = "Admin", "数据库:" & DBMsg & " 帐号:", "帐号:")

        Timer1.Enabled = True
        MainTab = New FormTab
        MainTab.MdiParent = Me
        MainTab.Show()
        MainTab.WindowState = FormWindowState.Minimized
        Get_Form_RightAsync()
        CheckTime()
        CommandBars.ActiveMenuBar.Minimized = My.Settings.Last_MenuState
        IsLoad = True

        If IsNoLoadMenu Then

        Else
            ChatClient.StartChat()
        End If


    End Sub

#Region "弹出信息"
    Public Const IDOK As Integer = 1
    Public Const IDCLOSE As Integer = 2
    Public Const IDSITE As Integer = 3
    Public IsOutDate As Boolean = False
    Dim ShowText As String = ""
    Sub PopupShowMsg(ByVal CurrentPopupControl As AxXtremeSuiteControls.AxPopupControl, ByVal StrTitle As String, ByVal StrMsg As String, Optional ByVal ShowDelay As Integer = 4000)

        CurrentPopupControl.Animation = CType(2, XtremeSuiteControls.XTPPopupAnimation)
        CurrentPopupControl.AnimateDelay = 256
        CurrentPopupControl.ShowDelay = Convert.ToInt32(ShowDelay)
        CurrentPopupControl.Transparency = 255


        Dim Item As XtremeSuiteControls.PopupControlItem
        CurrentPopupControl.RemoveAllItems()
        CurrentPopupControl.Icons.RemoveAll()
        Dim W As Integer = 240
        Dim H As Integer = 130


        Item = CurrentPopupControl.AddItem(10, 5, W - 20, 50, StrTitle, -1, -1)
        Item.TextAlignment = XtremeSuiteControls.XTPItemAlignment.DT_LEFT
        Item.CalculateHeight()
        Item.CalculateWidth()

        Item = CurrentPopupControl.AddItem(15, 50, W - 5, 100, StrMsg, -1, -1)
        Item.TextAlignment = XtremeSuiteControls.XTPItemAlignment.DT_CENTER Or XtremeSuiteControls.XTPItemAlignment.DT_WORDBREAK
        Item.Font.Size = 20
        Item.TextColor = 255
        Item.Bold = True
        Item.CalculateHeight()
        Item.Id = IDSITE


        Item = CurrentPopupControl.AddItem(W - 15, 6, W - 2, 19, "", -1, -1)
        Item.SetIcons(My.Resources.CloseMSN.GetHbitmap.ToInt32, System.Convert.ToUInt32(0), XtremeSuiteControls.XTPPopupItemIcon.xtpPopupItemIconNormal Or XtremeSuiteControls.XTPPopupItemIcon.xtpPopupItemIconSelected Or XtremeSuiteControls.XTPPopupItemIcon.xtpPopupItemIconPressed)
        Item.Id = IDCLOSE


        CurrentPopupControl.VisualTheme = XtremeSuiteControls.XTPPopupPaintTheme.xtpPopupThemeMSN
        CurrentPopupControl.SetSize(W, H)
        CurrentPopupControl.Show()

    End Sub

    Sub PopupShowOutDate()
        IsOutDate = True
        Dim N As Integer = DateDiff(DateInterval.Day, GetDate, #10/31/2011#)
        If N > 0 Then
            PopupShowMsg(PopupControl, "友情提示:软件即将在" & N & "天后到期", "试用版即将到期,请购买正版!", 10000)
            ShowText = Space(100) & "友情提示:软件即将在" & N & "天后到期,请购买正版!"
        Else
            End
        End If

    End Sub

    Private Sub PopupControl_ItemClick(ByVal sender As Object, ByVal e As AxXtremeSuiteControls._DPopupControlEvents_ItemClickEvent) Handles PopupControl.ItemClick
        If e.item.Id = IDCLOSE Or e.item.Id = IDOK Then
            CType(IIf(TypeOf sender Is AxXtremeSuiteControls.AxPopupControl, sender, Nothing), AxXtremeSuiteControls.AxPopupControl).Close()
            IsOutDate = False


        End If

        If e.item.Id = IDSITE And IsOutDate Then
            CType(IIf(TypeOf sender Is AxXtremeSuiteControls.AxPopupControl, sender, Nothing), AxXtremeSuiteControls.AxPopupControl).Close()
            MsgBox("请联系嘉米基IT部,电话:XXXXXXX")
            IsOutDate = False
        End If
    End Sub

    Private Sub PopupControl_StateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PopupControl.StateChanged
        If sender.Ctlstate = XtremeSuiteControls.XTPPopupState.xtpPopupStateClosed Then
            If IsOutDate Then

            End If
        End If
    End Sub
#End Region


    '菜单创建
    Private Sub CreateRibbonBar()


        Dim TabView As XtremeCommandBars.RibbonTab = Nothing
        Dim TabHome As XtremeCommandBars.RibbonTab = Nothing
        Dim TabEdit As XtremeCommandBars.RibbonTab = Nothing
        Dim TabPrintPreview As XtremeCommandBars.RibbonTab = Nothing
        Dim GroupFile As XtremeCommandBars.RibbonGroup = Nothing

        Dim ControlSaveAs As XtremeCommandBars.CommandBarPopup = Nothing
        Dim ControlPrint As XtremeCommandBars.CommandBarPopup = Nothing
        Dim Control As XtremeCommandBars.CommandBarControl = Nothing
        Dim ControlPaste As XtremeCommandBars.CommandBarPopup = Nothing
        Dim ControlSelect As XtremeCommandBars.CommandBarPopup = Nothing
        Dim ControlPopup As XtremeCommandBars.CommandBarPopup = Nothing
        Dim ControlMargins As XtremeCommandBars.CommandBarPopup = Nothing
        Dim ControlOrientation As XtremeCommandBars.CommandBarPopup = Nothing
        Dim ControlSize As XtremeCommandBars.CommandBarPopup = Nothing

        Dim RibbonBar As XtremeCommandBars.RibbonBar = Nothing
        RibbonBar = CommandBars.AddRibbonBar("The Ribbon")
        RibbonBar.EnableDocking(XtremeCommandBars.XTPToolBarFlags.xtpFlagStretched)

        Try
            SetFont(RibbonBar) '为win 7和vista设置字体
        Catch ex As Exception

        End Try


        '生成左边圆形按钮

        ControlFile = RibbonBar.AddSystemButton()
        ControlFile.IconId = 999999 '原形按钮
        '加载图片
        Randomize()
        Dim FP As String = System.IO.Path.GetTempPath & "\" & "999999" & CLng(Rnd() * 100000000000)
        Pic_Refresh.Image.Save(FP, Drawing.Imaging.ImageFormat.Png)
        CommandBars.Icons.LoadBitmap(FP, 999999, XtremeCommandBars.XTPImageState.xtpImageNormal)
        Try
            Kill(FP)
        Catch
        End Try



        ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999991, "返回登录界面", False, False)
        Randomize()
        FP = System.IO.Path.GetTempPath & "\" & "99999991" & CLng(Rnd() * 100000000000)
        My.Resources.Image_99999991.Save(FP, Drawing.Imaging.ImageFormat.Png)
        CommandBars.Icons.LoadBitmap(FP, 99999991, XTPImageState.xtpImageNormal)
        Try
            Kill(FP)
        Catch
        End Try




        ' If User_Update Then '上传更新
        Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999992, "(&U)" & IIf(User_Update, "上传更新", "DLL列表") & "", False, False)
        Control.BeginGroup = True
        '加载图片
        Randomize()
        FP = System.IO.Path.GetTempPath & "\" & "99999992" & CLng(Rnd() * 100000000000)
        My.Resources.Image_99999992.Save(FP, Drawing.Imaging.ImageFormat.Png)
        CommandBars.Icons.LoadBitmap(FP, 99999992, XTPImageState.xtpImageNormal)
        Try
            Kill(FP)
        Catch
        End Try
        ' End If
        'If User_Id = "Admin" Then
        '    Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999996, "(&T)套帐管理", False, False)
        '    Control.BeginGroup = True
        '    '加载图片
        '    Randomize()
        '    FP = System.IO.Path.GetTempPath & "\" & "99999996" & CLng(Rnd() * 100000000000)
        '    My.Resources.Image_99999996.Save(FP, Drawing.Imaging.ImageFormat.Png)
        '    CommandBars.Icons.LoadBitmap(FP, 99999996, XTPImageState.xtpImageNormal)
        '    Try
        '        Kill(FP)
        '    Catch
        '    End Try
        'End If





        Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999995, "(&G)更改数据库", False, False)
        Control.BeginGroup = True
        '加载图片
        Randomize()
        FP = System.IO.Path.GetTempPath & "\" & "99999995" & CLng(Rnd() * 100000000000)
        My.Resources.Image_99999995.Save(FP, Drawing.Imaging.ImageFormat.Png)
        CommandBars.Icons.LoadBitmap(FP, 99999995, XTPImageState.xtpImageNormal)
        Try
            Kill(FP)
        Catch
        End Try

        If IsNoLoadMenu = False Then
            Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999997, "(&C)修改密码", False, False)
            Control.BeginGroup = True
            '加载图片
            Randomize()
            FP = System.IO.Path.GetTempPath & "\" & "99999997" & CLng(Rnd() * 100000000000)
            My.Resources.Image_99999997.Save(FP, Drawing.Imaging.ImageFormat.Png)
            CommandBars.Icons.LoadBitmap(FP, 99999997, XTPImageState.xtpImageNormal)
            Try
                Kill(FP)
            Catch
            End Try
        End If


        Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999993, "(&U)隐藏式菜单", False, False)
        Control.BeginGroup = True
        '加载图片
        Randomize()
        FP = System.IO.Path.GetTempPath & "\" & "99999993" & CLng(Rnd() * 100000000000)
        My.Resources.Image_99999993.Save(FP, Drawing.Imaging.ImageFormat.Png)
        CommandBars.Icons.LoadBitmap(FP, 99999993, XTPImageState.xtpImageNormal)
        Try
            Kill(FP)
        Catch
        End Try


        Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999994, "(&S)固定式菜单", False, False)
        Control.BeginGroup = True
        '加载图片
        Randomize()
        FP = System.IO.Path.GetTempPath & "\" & "99999994" & CLng(Rnd() * 100000000000)
        My.Resources.Image_99999994.Save(FP, Drawing.Imaging.ImageFormat.Png)
        CommandBars.Icons.LoadBitmap(FP, 99999994, XTPImageState.xtpImageNormal)
        Try
            Kill(FP)
        Catch
        End Try

        If IsNoLoadMenu = False Then
            Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999998, "创建桌面快捷方式", False, False)
            Control.BeginGroup = True
            '加载图片
            Randomize()
            FP = System.IO.Path.GetTempPath & "\" & "99999998" & CLng(Rnd() * 100000000000)
            My.Resources.Image_99999998.Save(FP, Drawing.Imaging.ImageFormat.Png)
            CommandBars.Icons.LoadBitmap(FP, 99999998, XTPImageState.xtpImageNormal)
            Try
                Kill(FP)
            Catch
            End Try



            Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999990, "安装全角补丁", False, False)
            Control.BeginGroup = True
            '加载图片
            Randomize()
            FP = System.IO.Path.GetTempPath & "\" & "99999990" & CLng(Rnd() * 100000000000)
            My.Resources.Image_99999996.Save(FP, Drawing.Imaging.ImageFormat.Png)
            CommandBars.Icons.LoadBitmap(FP, 99999990, XTPImageState.xtpImageNormal)
            Try
                Kill(FP)
            Catch
            End Try

            'Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999989, "在线列表", False, False)
            'Control.BeginGroup = True
            ''加载图片
            'Randomize()
            'FP = System.IO.Path.GetTempPath & "\" & "99999989" & CLng(Rnd() * 100000000000)
            'My.Resources.Image_99999993.Save(FP, Drawing.Imaging.ImageFormat.Png)
            'CommandBars.Icons.LoadBitmap(FP, 99999989, XTPImageState.xtpImageNormal)
            'Try
            '    Kill(FP)
            'Catch
            'End Try
        End If




        'Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999994, "Recent File", False, False)
        'Control.BeginGroup = True
        'Control.Enabled = False

        Control = ControlFile.CommandBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999999, "(&E)关闭系统", False, False)
        Control.BeginGroup = True
        ControlFile.CommandBar.SetIconSize(32, 32)
        '加载图片
        Randomize()
        FP = System.IO.Path.GetTempPath & "\" & "99999999" & CLng(Rnd() * 100000000000)
        My.Resources._End.Save(FP, Drawing.Imaging.ImageFormat.Png)
        CommandBars.Icons.LoadBitmap(FP, 99999999, XTPImageState.xtpImageNormal)
        Try
            Kill(FP)
        Catch
        End Try
        'ControlAbout = RibbonBar.Controls.Add(XtremeCommandBars.XTPControlType.xtpControlButton, 99999996, "&About", False, False)
        'ControlAbout.Flags = XtremeCommandBars.XTPControlFlags.xtpFlagRightAlign





        If IsNoLoadMenu = False Then
            Dim MEnadle As Boolean
            Dim OEnadle As Boolean
            For Each MenuId As String In HashMenu.Keys
                If CheckRight(HashMenu(MenuId).ID) Then
                    Dim Menu As MainMenuXTpye = HashMenu(MenuId)
                    Dim M As XtremeCommandBars.RibbonTab
                    M = RibbonBar.InsertTab(RibbonBar.TabCount, Menu.Caption)
                    M.Id = Menu.ID
                    MEnadle = False
                    For Each ModuleId As String In HashModule.Keys
                        If ModuleId.Substring(0, 2) = MenuId Then
                            If CheckRight(HashModule(ModuleId).ID) Then
                                Dim ModuleX As MainModuleTpye = HashModule(ModuleId)
                                Dim G As XtremeCommandBars.RibbonGroup
                                G = M.Groups.AddGroup(ModuleX.Caption, ModuleX.ID)
                                'OId = ReadRights(MainModule(j).ID.ToString)
                                OEnadle = False
                                ' If GetRValue(OId, 4) Then
                                For Each DllId As String In HashDll.Keys
                                    If CheckRight(DllId) Then
                                        isShowCount = isShowCount + 1
                                        isShowID = DllId
                                        If DllId.Substring(0, 3) = ModuleId Then
                                            Dim DllX As DLLTpye = HashDll(DllId)
                                            If DllX.IsShow Then
                                                '加载权限
                                                G.Add(XtremeCommandBars.XTPControlType.xtpControlButton, DllX.ID, DllX.Caption, False, False).Enabled = True
                                                OEnadle = True
                                                If Not DllX.Img Is Nothing Then
                                                    Randomize()
                                                    My.Resources._End.GetHicon()
                                                    Dim F As String = System.IO.Path.GetTempPath & "\" & DllX.ID & CLng(Rnd() * 100000000000)
                                                    DllX.Img.Save(F, Drawing.Imaging.ImageFormat.Png)
                                                    CommandBars.Icons.LoadBitmap(F, DllX.ID, XTPImageState.xtpImageNormal)
                                                    Try
                                                        Kill(F)
                                                    Catch
                                                    End Try
                                                End If
                                            End If
                                        End If
                                    End If
                                Next
                                If OEnadle = False Then G.Visible = False Else MEnadle = True
                            End If
                        End If
                    Next
                    If MEnadle = False Then M.Visible = False
                End If
            Next
            AddMainRight()
            Dim i As Integer
            Try
                For i = 0 To RibbonBar.TabCount - 1
                    If RibbonBar.Tab(i).Visible = True Then
                        RibbonBar.SelectedTab = RibbonBar.Tab(i)
                        Exit For
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
        MenuLoadOK = True
    End Sub
    Dim isShowCount As Integer = 0
    Dim isShowID As Integer = 0


    Private Sub CommandBars_ResizeClient(ByVal sender As Object, ByVal e As AxXtremeCommandBars._DCommandBarsEvents_ResizeClientEvent) Handles CommandBars.ResizeClient
        If IsLoad Then
            If CommandBars.ActiveMenuBar.Minimized <> My.Settings.Last_MenuState Then
                My.Settings.Last_MenuState = CommandBars.ActiveMenuBar.Minimized
                My.Settings.Save()
            End If
        End If
    End Sub

    '菜单运行
    Private Sub CommandBars_Execute(ByVal sender As System.Object, ByVal e As AxXtremeCommandBars._DCommandBarsEvents_ExecuteEvent) Handles CommandBars.Execute
        If MenuLoadOK = False Then Exit Sub

        Dim Id As Integer = e.control.Id
        Dim i As Integer

        If Id > 9999 And Id < 100000 Then
            i = CheckFormLoad(Id)
            If i = -1 Then
                LoadFormID(Id)
            Else
                MainTab.TAB.SelectedIndex = i
            End If
        Else
            Select Case Id
                Case 99999990
                    Dim s As String = "NDP20-KB925488-X86.msp"

                    Shell("explorer.exe NDP20-KB925488-X86.msp")
                Case 99999991
                    ReLoad = True
                    Me.Close()
                Case 99999992
                    FormUpdate.ShowDialog()
                Case 99999993
                    CommandBars.ActiveMenuBar.Minimized = True
                Case 99999994
                    CommandBars.ActiveMenuBar.Minimized = False
                Case 99999995
                    DB_Set = False
                    FormDB.ShowDialog()
                    If DB_Set = True Then
                        ReLoad = True
                        Me.Close()
                    End If
                Case 99999996
                    FormDBSelect.ShowDialog()
                    If ReLoad = True Then Me.Close()
                Case 99999997
                    FormPwd.ShowDialog()
                    If ReLoad = True Then Me.Close()
                Case 99999998
                    Shell(AppPath & "CLnk.exe " & My.Application.Info.Title & ";" & "Retail_System")
                Case 99999999
                    Close()
                Case 99999989
                    ChatClient.OpenUserList()
            End Select
        End If
    End Sub



    Function CheckFormLoad(ByVal Id As Integer) As Integer
        Dim i As Integer
        For i = 1 To MainTab.TAB.TabPages.Count - 1
            Dim BF As TabItem
            Try
                BF = TryCast(MainTab.TAB.TabPages(i), TabItem)
                If Not BF Is Nothing Then
                    If BF.ChObj.ID = Id Then
                        BF.ChObj.xSecondOpen()
                        Return i
                    End If
                End If
            Catch ex As Exception
            Finally
                BF = Nothing
            End Try
        Next
        Return -1
    End Function

    ''' <summary>
    ''' 系统运行时间'毫秒
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared RunningTime As Long
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RunningTime = RunningTime + Timer1.Interval
        ChangeTime()
    End Sub
    Dim Ix As Integer = 121
    Dim IxStop As Boolean = False
    Sub ChangeTime()
        Dim NTime As Date = DateAdd(DateInterval.Second, TimeDiff, Now)
        If Math.Abs(DateDiff(DateInterval.Second, LTime, NTime)) > 60 Then
            NTime = GetTime()
        End If
        Try
            Pand_Time.Text = Format(NTime, "yyyy年MM月dd日 HH:mm:ss")
            LTime = NTime
        Catch ex As Exception
        End Try
        Try
            If My.Computer.Network.IsAvailable = False Then
                Pand_Net.Text = "网络断开"
                Pand_Net.Visible = True
            Else
                Pand_Net.Visible = False
            End If
        Catch ex As Exception
        End Try
        If IxStop Then
            Exit Sub
        End If
        Ix = Ix + 1
        If Ix > 120 AndAlso IsBarCode = False Then
            Ix = 0
            IxStop = True
            IxStop = CheckUpdate()
        End If
    End Sub


    Sub CheckTime()
        Dim D As DateTime = GetTime()
        If Math.Abs(DateDiff(DateInterval.Second, D, Now)) > 1800 Then
            If MsgBox("你的计算机时间同服务器时间相差[" & Math.Abs(DateDiff(DateInterval.Second, D, Now)) & "]秒,这样会导致系统单据日期不正确,是否更新本机时间?", MsgBoxStyle.YesNo, Me.Text) <> MsgBoxResult.No Then
                D = GetTime()
                Today = d
                TimeOfDay = d
            ElseIf MsgBox("你是否真的不更新时间,所产生问题是不是都由你负责?", MsgBoxStyle.YesNo) <> MsgBoxResult.No Then
                D = GetTime()
                Today = D
                TimeOfDay = D
            End If
        End If
    End Sub


    Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If User_Touch Then
            Me.Visible = False
            End
            Exit Sub
        End If
        If IsBarCode Then
            Me.WindowState = FormWindowState.Minimized
            'CommandBars.ActiveMenuBar.Minimized = True
            LoadFormID(30202)
            TryCast(MainTab.TAB.TabPages(1), TabItem).ChObj.F_RS_ID5 = "AutoClose"
            Me.Hide()
            Exit Sub
        End If
        If isShowCount = 1 Then
            CommandBars.ActiveMenuBar.Minimized = True
            LoadFormID(isShowID)
            TryCast(MainTab.TAB.TabPages(1), TabItem).ChObj.F_RS_ID5 = "AutoClose"
            Exit Sub
        End If
    End Sub





    Private _ReturnId As String = ""
    Private _ReturnObj As Object
    Private _ReturnMsg As String = ""
    Public Property ReturnId() As String Implements PClass.IReturnObj.ReturnId
        Get
            Return _ReturnId
        End Get
        Set(ByVal value As String)
            _ReturnId = value
        End Set
    End Property

    Public Property ReturnObj() As Object Implements PClass.IReturnObj.ReturnObj
        Get
            Return _ReturnObj
        End Get
        Set(ByVal value As Object)
            _ReturnObj = value
        End Set
    End Property

    Public Property ReturnMsg() As String Implements PClass.IReturnObj.ReturnMsg
        Get
            Return _ReturnMsg
        End Get
        Set(ByVal value As String)
            _ReturnMsg = value
        End Set
    End Property
End Class
