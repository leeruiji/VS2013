Imports System.Reflection
Imports PClass.PClass
Imports System.Drawing




Module ModuleMain
    Public LonIn As Boolean = False
    Public DllName_Head As String = "DN*"
    Public ShowWait As Boolean = True
    Public DB_Set As Boolean = False
    Public DB_Select As String = ""
    Public IsBarCode As Boolean = False
    Public IsNoLoadMenu As Boolean = False
    Sub Ini_Value()
        AppKey = "JMJ"
        AppDes = EnDes(AppKey, "MSATN")
        DB_Select = "DB_" & AppKey & "_Select"
    End Sub


#Region "获取数据库连接"

    '加载配置文件
    Public Function LoadCXml(ByRef x As CSaveXml) As Boolean
        ShowLoadWaitMsg("连接数据库....")
        x = New CSaveXml

        Try
            Using fStream As New IO.FileStream(AppPath & "Csx.dat", IO.FileMode.Open)
                Dim sfFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                x = sfFormatter.Deserialize(fStream)

                SetCxtDefault(x)
                fStream.Close()
            End Using
            Return True
        Catch ex As Exception
            '序列号失败
            If Command.ToLower.StartsWith("ip=") Then
                Try
                    Dim sp() As String = Command.Split(";")
                    x.MIP = sp(0).Split("=")(1)
                    x.MDB = sp(1).Split("=")(1)
                    x.MPassword = EnDes("vv", AppDes)
                    x.MUserId = "vv"
                    SetCxtDefault(x)
                    Dim sfFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    Using fStream As New IO.FileStream(AppPath & "Csx.dat", IO.FileMode.Create)
                        sfFormatter.Serialize(fStream, x)
                        fStream.Close()
                    End Using
                    Return True
                Catch ex1 As Exception

                End Try
            Else
                x = LoadIni()
                If x Is Nothing Then
                    Return False
                Else
                    Return True
                End If
            End If
            Return False
        End Try
    End Function

    Sub SetCxtDefault(ByVal x As CSaveXml)

        Printer_A4 = IsNothing(x.Printer_A4, "默认打印机")
        Printer_SaleNo = IsNothing(x.Printer_SaleNo, "默认打印机")
        Printer_SalePrepare = IsNothing(x.Printer_SalePrepare, "默认打印机")
        Printer_Tm = IsNothing(x.Printer_Tm, "默认打印机")
        WCom = IsNothing(x.WCom, "com1")
        WBaudRate = IsNothing(x.WBaudRate, "2400")


        Tm_PrintOffsetX = IsNothing(x.Tm_PrintOffsetX, 0)
        Tm_PrintOffsetY = IsNothing(x.Tm_PrintOffsetY, 0)

        SalePrepare_PrintOffsetX = IsNothing(x.SalePrepare_PrintOffsetX, 0)
        SalePrepare_PrintOffsetY = IsNothing(x.SalePrepare_PrintOffsetY, 0)

        SaleNo_PrintOffsetX = IsNothing(x.SaleNo_PrintOffsetX, 0)
        SaleNo_PrintOffsetY = IsNothing(x.SaleNo_PrintOffsetY, 0)

        A4_PrintOffsetX = IsNothing(x.A4_PrintOffsetX, 0)
        A4_PrintOffsetY = IsNothing(x.A4_PrintOffsetY, 0)
    End Sub

    Function LoadIni() As CSaveXml
        If My.Computer.FileSystem.FileExists("Setting.ini") Then
            Dim Cxt As New CSaveXml
            Dim sp() As String = IO.File.ReadAllLines("Setting.ini")
            Dim Session As String = ""
            For Each s As String In sp
                If s.StartsWith("[") AndAlso s.EndsWith("]") Then
                    Session = s.ToLower
                Else
                    Dim SP_One() As String = s.Split("=")
                    Select Case SP_One(0).ToUpper
                        Case "IP"
                            If Session = "[setting]" AndAlso SP_One.Length > 1 Then
                                Cxt.MIP = SP_One(1)
                                Cxt.MIP = IIf(Cxt.MIP.Trim = "192.168.19.240", "192.168.16.10", Cxt.MIP)
                            End If
                        Case "PWD"
                            If Session = "[setting]" AndAlso SP_One.Length > 1 Then
                                Cxt.MPassword = SP_One(1)
                            End If
                        Case "USER"
                            If Session = "[setting]" AndAlso SP_One.Length > 1 Then
                                Cxt.MUserId = SP_One(1)
                            End If
                    End Select
                End If
            Next
            Cxt.MDB = "V3_DB"
            Cxt.MPassword = EnDes("vv", AppKey)
            Cxt.MUserId = "vv"
            SetCxtDefault(Cxt)
            Return Cxt
        Else
            Return Nothing
        End If
    End Function


    Sub WriteSetting(ByVal Cxt As CSaveXml)
        Dim s As New System.Text.StringBuilder("")
        s.AppendLine("[setting]")
        s.Append("IP=")
        s.AppendLine(Cxt.MIP)
        s.Append("AppKey=")
        s.AppendLine(AppKey)
        IO.File.WriteAllText("setting.ini", s.ToString)
    End Sub


    Private Sub LoadCnn()
        Dim Cx As New CSaveXml
        If LoadCXml(Cx) = False Then

            ShowLoadWaitMsg("设置数据库....")
            DB_Set = False
            FormLogon.TopMost = False
            FormDB.ShowDialog()
            FormLogon.TopMost = True
            If DB_Set = False Then
                End
            Else
                LoadCnn()
                Exit Sub
            End If
        Else
            If Cx.MIP.Trim = "192.168.19.240" Then Cx.MIP = "192.168.16.10"
        End If

        If GetCnn(Cx) Then
            Exit Sub
        Else
            ShowLoadWaitMsg("设置数据库....")
            DB_Set = False
            FormLogon.TopMost = False
            FormDB.ShowDialog()
            FormLogon.TopMost = True
            If DB_Set = False Then
                End
            Else
                LoadCnn()
                Exit Sub
            End If
        End If

    End Sub

    Private Function GetCnn(ByRef Cx As CSaveXml) As Boolean
        Dim Cxt As New CSaveXml
        CnnStrAdd(Cx) '生成连接字符串
        Dim IP As String = ""
        Try
            If My.Computer.Network.IsAvailable = False Then
                If Not MsgBox("计算机网线没有插好,是否尝试连接到数据库?)", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Return False
                End If
            End If
            If Cx.MIP.Split("\")(0) = "." Then
                IP = My.Computer.Name
                Cx.MIP = Cx.MIP.Replace(".", IP)
            Else
                IP = Cx.MIP.Split("\")(0)
            End If
            Do Until My.Computer.Network.Ping(IP, 300) OrElse My.Computer.Network.Ping(IP, 300)
                Dim MR As MsgBoxResult = MsgBox("连接服务器Ping不通是否继续连接?", MsgBoxStyle.Exclamation + MsgBoxStyle.AbortRetryIgnore, AppName)
                Select Case MR
                    Case MsgBoxResult.Abort
                        End
                    Case MsgBoxResult.Retry

                    Case MsgBoxResult.Ignore
                        Exit Do
                End Select
            Loop
            Dim T As New Threading.Thread(AddressOf GetActiveDB)
            RunOk = False
            T.Start()
            Do Until RunOk = True
                Application.DoEvents()
            Loop
            If IsEx Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        If RADt.IsOk AndAlso RADt.Dt.Rows.Count > 0 Then
            Cxt.MDB = RADt.Dt.Rows(0).Item("DB_Name")
            Cxt.MIP = RADt.Dt.Rows(0).Item("DB_IP")
            Cxt.MPassword = RADt.Dt.Rows(0).Item("DB_Pwd")
            Cxt.MUserId = RADt.Dt.Rows(0).Item("DB_User")
            CnnStrAdd(Cxt)
            CnnChatStrAdd(Cx)
            WriteSetting(Cx)
            If Cxt.MIP.Split("\")(0) = "." Then
                IP = My.Computer.Name
                Cxt.MIP = Cxt.MIP.Replace(".", IP)
            Else
                IP = Cxt.MIP.Split("\")(0)
            End If
            Do Until My.Computer.Network.Ping(IP, 300) OrElse My.Computer.Network.Ping(IP, 300)
                Dim MR As MsgBoxResult = MsgBox("数据服务器Ping不通是否继续连接?", MsgBoxStyle.Exclamation + MsgBoxStyle.AbortRetryIgnore, AppName)
                Select Case MR
                    Case MsgBoxResult.Abort
                        End
                    Case MsgBoxResult.Retry

                    Case MsgBoxResult.Ignore
                        Exit Do
                End Select
            Loop

            RADt.Dt.Dispose()
            Return True
        Else
            If RADt.Msg = "在与 SQL Server 建立连接时出现与网络相关的或特定于实例的错误。未找到或无法访问服务器。请验证实例名称是否正确并且 SQL Server 已配置为允许远程连接。 (provider: 命名管道提供程序, error: 40 - 无法打开到 SQL Server 的连接)" Then
                Dim MR As MsgBoxResult = MsgBox("连接服务器失败!", MsgBoxStyle.Exclamation + MsgBoxStyle.AbortRetryIgnore, AppName)
                Select Case MR
                    Case MsgBoxResult.Abort
                        End
                    Case MsgBoxResult.Retry
                        Return GetCnn(Cx)
                End Select
            End If
            RADt.Dt.Dispose()
            Return False
        End If
    End Function
#End Region

    Dim RADt As New DtReturnMsg
    Dim AEx As Exception
    Dim IsEx As Boolean
    Dim RunOk As Boolean = False
    Sub GetActiveDB()
        Try
            IsEx = False
            RunOk = False

            RADt = SqlStrToDt("select * from " & DB_Select & " where DB_Active=1")
        Catch ex As Exception
            IsEx = True
            AEx = ex
        Finally
            RunOk = True
        End Try
    End Sub


    Public Sub Load_App()
        Err_App = "DeskTop_App"
        AppName = My.Application.Info.Title
        MDDir(ReportPath) '创建报表目录
        'FormLogon.P_Logon.Visible = False
        'FormLogon.P_Logon.Refresh()
        ShowLoadWaitMsg("初始化数据..")
        Ini_Value() '初始化数据
        LoadDll()   '加载DLL
        ShowLoadWaitMsg("加载DLL完毕..")
        LoadCnn() '加载数据库连接

        Using Cnn As New SqlClient.SqlConnection(CnnStr)
            Try
                CnnOpen(Cnn)
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 4060
                        MsgBox("数据连接没有权限登录!", MsgBoxStyle.Exclamation)
                        End
                    Case 53
                        MsgBox("数据连接到服务器连接超时或服务器不存在!", MsgBoxStyle.Exclamation)
                    Case Else
                        MsgBox(ex.Message & ex.Number)
                        End
                End Select
            End Try
        End Using


        If Ide = False Then
            ShowLoadWaitMsg("获取DLL的更新..")
            If UpdateDLL() Then '获取DLL的更新
                ShowLoadWaitMsg("检查更新器和基本文件!")
                CheckFile()
                ShowLoadWaitMsg("更新完毕,正在重新本程序!")
                DownLoadComplete()
                Exit Sub
            End If
        End If
        Ini_Format()
        LonIn = True
    End Sub




    '加载DLL
    Sub LoadDll()
        AssClear()
        If IsBarCode Then
            DllName_Head = "DN300_Produce.dll"
        End If
        Dim Filenames As String = Dir(DllPath & DllName_Head, vbHidden)
        Do While Filenames <> ""
            If LCase(Right(Filenames, 4)) = ".dll" Then
                ShowLoadWaitMsg("正在加载DLL组件.." & Filenames)
                GetDLlame(DllPath & Filenames)
            End If
            Filenames = Dir()
        Loop
        DllSort()
        ShowLoadWaitMsg("加载DLL完毕.." & Filenames)
    End Sub



    Sub ShowLoadWaitMsg(ByVal Msg As String)
        If ShowWait Then
            FormLogon.LabelMsg.Text = Msg
            FormLogon.LabelMsg.Refresh()
        End If
    End Sub









    '判断是否在ID环境中
    Public Function IsDebugMode() As Boolean
        Dim s As String = PClass.PClass.FileToMD5(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 3) & "vshost.exe")
        If s = "99F9B3AB8971E77B5C93864EE0A7B97D" Then
            Return True
        Else
            If Application.StartupPath.EndsWith("Debug", StringComparison.CurrentCultureIgnoreCase) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function


    '获得许可ID
    Public ServerID As Integer = 0
    Public Function GetServerID() As Integer
        Dim R As MsgReturn = SqlStrToOneStr("[GetID]" & ServerID & ",'" & User_ID & "'")
        If R.IsOk = True Then
            Return R.Msg
        Else
            Return 0
        End If
    End Function
    Public Function DelServerID() As Integer
        Dim R As MsgReturn = SqlStrToOneStr("[DelID]" & ServerID & ",'" & User_ID & "'")
        If R.IsOk = True Then
            Return R.Msg
        Else
            Return 0
        End If
    End Function


    Dim T2Stop As Boolean = False

    Public LastUpdateID As Integer = 0
    Public Function CheckUpdate() As Boolean
        Dim R As MsgReturn = SqlStrToOneStr("Select top 1 [Format] from FormatSet where Id='LastUpdateID'")
        Dim C As Integer
        If R.IsOk Then
            C = Val(R.Msg)
            If LastUpdateID = 0 Then
                LastUpdateID = C
            Else
                If LastUpdateID < C Then
                    If MsgBox("发现系统有新内容更新,是否显示更新" & vbCrLf & "按否会在2分钟之后再提示一次!", MsgBoxStyle.YesNo + MsgBoxStyle.Question, AppName) = MsgBoxResult.Yes Then
                        LastUpdateID = 0
                        MainForm.ReLoad = True
                        MainForm.IsClosing_NotCheck = True
                        MainForm.Invoke(New MainWindow.DCloseWindows(AddressOf MainForm.Close))
                        Return True
                    Else
                        Return False
                    End If
                Else
                    LastUpdateID = C
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function

End Module
