Imports PClass.PClass
Imports System.IO
Imports System.ComponentModel
Imports System.Data

Module ModuleAT
#Region "管理卡设置"
    '设置管理卡
    Private Declare Function SetManagerCard Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal CardNo As String) As Boolean
#End Region
#Region "设备设置"
    '读取机具资料 
    Private Declare Function ReadClockModeEx Lib "EastRiver.Dll" (ByVal hPort As Integer, ByRef Mode As Integer, ByRef ExtraMode As Integer, ByRef SystemMode As Integer, ByRef RingMode As Integer) As Boolean
    '读取机具资料 
    Private Declare Function SetClockModeEx Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal Mode As Integer, ByVal ExtraMode As Integer, ByVal SystemMode As Integer, ByVal RingMode As Integer) As Boolean


    '读取设备每张卡打卡间隔
    Private Declare Function ReadRepeatClockerTime Lib "EastRiver.Dll" (ByVal hPort As Integer, ByRef timeLen As Integer) As Boolean

    '设置设备每张卡打卡间隔
    Private Declare Function SetRepeatClockerTime Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal timeLen As Integer) As Boolean
#End Region
#Region "显示界面"
    '设置机具常态显示内容
    Private Declare Function SetClockNormalMessage Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal Msg As String) As Boolean


    '设置机具开机显示内容
    Private Declare Function SetFirstWindowDispString Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal Msg As String) As Boolean



#End Region



#Region "原有的API函数"
    '打开套接字
    Private Declare Function OpenClientSocket Lib "EastRiver.Dll" (ByVal RemoteAddr As String, ByVal Port As Integer) As Integer
    '关闭套接字
    Private Declare Function CloseClientSocket Lib "EastRiver.Dll" (ByVal hSocket As Integer) As Boolean
    Private Declare Sub SetCmdVerify Lib "EastRiver.Dll" (ByVal Value As Boolean)
    '  连接指定的机器
    Private Declare Function CallClock Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal clock_id As Integer) As Boolean
    '选择联机方式，=0串口联接，=1TCP/IP联接
    '一定要在打开套接字之后或之前设置，如果是串口操作，不用设置，默认是串口
    Private Declare Function SelectCommStyle Lib "EastRiver.Dll" (ByVal CommStyle As Integer) As Boolean

    '      读取设备时间, 以字符串格式返回
    Private Declare Function ReadClockTimeString Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal TimeString_Renamed As String) As Boolean
    '      设置设备时间
    Private Declare Function SetClockTime Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal SetTime As Double) As Boolean
    '批量读数据(880 1.28以上版本)
    Private Declare Function BatchReadRecord Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal Records As String, ByVal arraysize As Integer) As Integer

    '      删除设备的所有允许考勤卡(白名单卡)
    Private Declare Function DeleteAllAllowedCard Lib "EastRiver.Dll" (ByVal hPort As Integer) As Boolean

    '      设置设备的允许考勤卡(白名单卡带6个字符工号或姓名)
    Private Declare Function SetAllowedCard Lib "EastRiver.Dll" (ByVal hPort As Integer, ByVal card As String, ByVal EmpId As String, ByVal EmpName As String) As Boolean
    Private hPort As Integer
#End Region

#Region "管理卡设置"
    ''' <summary>
    ''' 设置管理卡
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="card">显示内容8个中文16个英文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetManagerCard(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal card As String) As MsgReturn
        Dim R As New MsgReturn
        If OpenPort(ipAddr, ipPort, clock_id) Then

            If SetManagerCard(hPort, card) Then
                ClosePort()
                R.IsOk = True
                R.Msg = "设置成功"
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function



#End Region

#Region "显示界面函数"
    ''' <summary>
    ''' 设置机具常态显示内容
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Msg">显示内容8个中文16个英文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetClockNormalMessage(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal Msg As String) As MsgReturn
        Dim R As New MsgReturn
        If OpenPort(ipAddr, ipPort, clock_id) Then

            If SetClockNormalMessage(hPort, Msg) Then
                ClosePort()
                R.IsOk = True
                R.Msg = "设置成功"
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function


    ''' <summary>
    ''' 设置机具开机显示内容
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Msg">显示内容8个中文16个英文</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetFirstWindowDispString(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal Msg As String) As MsgReturn
        Dim R As New MsgReturn
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If SetFirstWindowDispString(hPort, Msg) Then
                ClosePort()
                R.IsOk = True
                R.Msg = "设置成功"
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function

#End Region




#Region "设备设置"

    ''' <summary>
    ''' 设置设备每张卡打卡间隔
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="min">1-999分钟</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetRepeatClockerTime(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal min As Integer) As MsgReturn
        Dim R As New MsgReturn
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If SetRepeatClockerTime(hPort, min) Then
                ClosePort()
                R.IsOk = True
                R.Msg = "设置打卡间隔成功"
            Else
                ClosePort()
                R.Msg = "设置打卡间隔失败"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function


    ''' <summary>
    ''' 获取设备每张卡打卡间隔
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="min">1-999分钟</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadRepeatClockerTime(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal min As Integer) As MsgReturn
        Dim R As New MsgReturn
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If ReadRepeatClockerTime(hPort, min) Then
                ClosePort()
                R.IsOk = True
                R.Msg = min
            Else
                ClosePort()
                R.Msg = "读取打卡间隔失败"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function




    ''' <summary>
    ''' 读取机具资料
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Mode"></param>
    ''' <param name="ExtraMode"></param>
    ''' <param name="SystemMode"></param>
    ''' <param name="RingMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadClockMode(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByRef Mode As Integer, ByRef ExtraMode As Integer, ByRef SystemMode As Integer, ByRef RingMode As Integer) As MsgReturn
        Dim R As New MsgReturn
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If ReadClockModeEx(hPort, Mode, ExtraMode, SystemMode, RingMode) Then
                ClosePort()
                R.IsOk = True
                R.Msg = "获取成功"
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function

    ''' <summary>
    ''' 设置机具资料
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Mode"></param>
    ''' <param name="ExtraMode"></param>
    ''' <param name="SystemMode"></param>
    ''' <param name="RingMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetClockMode(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal Mode As Integer, ByVal ExtraMode As Integer, ByVal SystemMode As Integer, ByVal RingMode As Integer) As MsgReturn
        Dim R As New MsgReturn
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If SetClockModeEx(hPort, Mode, ExtraMode, SystemMode, RingMode) Then
                ClosePort()
                R.IsOk = True
                R.Msg = "设置成功"
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function



    ''' <summary>
    ''' 设置机具资料Mode
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetClockMode(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal Value As Integer) As MsgReturn
        Dim R As New MsgReturn
        Dim Mode As Integer
        Dim ExtraMode As Integer
        Dim SystemMode As Integer
        Dim RingMode As Integer
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If ReadClockModeEx(hPort, Mode, ExtraMode, SystemMode, RingMode) Then
                If SetClockModeEx(hPort, Value, ExtraMode, SystemMode, RingMode) Then
                    R.IsOk = True
                    R.Msg = "设置成功"
                Else
                    R.Msg = "设置失败"
                End If
                ClosePort()
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function

    ''' <summary>
    ''' 设置机具资料ExtraMode
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetClockExtraMode(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal Value As Integer) As MsgReturn
        Dim R As New MsgReturn
        Dim Mode As Integer
        Dim ExtraMode As Integer
        Dim SystemMode As Integer
        Dim RingMode As Integer
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If ReadClockModeEx(hPort, Mode, ExtraMode, SystemMode, RingMode) Then
                If SetClockModeEx(hPort, Mode, Value, SystemMode, RingMode) Then
                    R.IsOk = True
                    R.Msg = "设置成功"
                Else
                    R.Msg = "设置失败"
                End If
                ClosePort()
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function


    ''' <summary>
    ''' 设置机具资料SystemMode
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetClockSystemMode(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal Value As Integer) As MsgReturn
        Dim R As New MsgReturn
        Dim Mode As Integer
        Dim ExtraMode As Integer
        Dim SystemMode As Integer
        Dim RingMode As Integer
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If ReadClockModeEx(hPort, Mode, ExtraMode, SystemMode, RingMode) Then
                If SetClockModeEx(hPort, Mode, ExtraMode, Value, RingMode) Then
                    R.IsOk = True
                    R.Msg = "设置成功"
                Else
                    R.Msg = "设置失败"
                End If
                ClosePort()
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function

    ''' <summary>
    ''' 设置机具资料RingMode
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <param name="ipPort"></param>
    ''' <param name="clock_id"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SetClockRingMode(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal Value As Integer) As MsgReturn
        Dim R As New MsgReturn
        Dim Mode As Integer
        Dim ExtraMode As Integer
        Dim SystemMode As Integer
        Dim RingMode As Integer
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If ReadClockModeEx(hPort, Mode, ExtraMode, SystemMode, RingMode) Then
                If SetClockModeEx(hPort, Mode, ExtraMode, SystemMode, Value) Then
                    R.IsOk = True
                    R.Msg = "设置成功"
                Else
                    R.Msg = "设置失败"
                End If
                ClosePort()
            Else
                ClosePort()
                R.Msg = "不能读出设备设置"
            End If
        Else
            R.Msg = "不能联接设备"
        End If
        Return R
    End Function

    Public Class ModeChange

#Region "Mode枚举"
        Public Enum Enum_Mode_210
            机具无界面 = 0
            独立考勤机 = 1
            独立门禁机 = 2
            门禁考勤二合一机 = 3
            消费机 = 4
            读卡器 = 5
            出门读卡器 = 6
            备用 = 7
        End Enum

        'Public Enum Enum_Mode_3
        '    非允许时段刷卡不记录存贮记录 = 0
        '    非允许时段刷卡记录存贮记录 = 1
        'End Enum

        Public Enum Enum_Mode_54
            无铃声输出不打铃 = 0
            铃声输出外接电铃接继电器1 = 16
            铃声输出外接电铃接继电器2 = 32
            内置蜂鸣器打铃 = 48
        End Enum

        'Public Enum Enum_Mode_6
        '    允许重复刷卡 = 0
        '    禁止重复刷卡 = 1
        'End Enum

        'Public Enum Enum_Mode_7
        '    记录存贮满后停止存贮 = 0
        '    记录存贮满后循环存贮 = 1
        'End Enum
#End Region

#Region "Mode属性"

        Private _Mode As Integer
        Public Property Mode() As Integer
            Get
                Return _Mode
            End Get
            Set(ByVal value As Integer)
                _Mode = value
            End Set
        End Property



        Public Property Mode_210() As Enum_Mode_210
            Get
                Return Mode And 7
            End Get
            Set(ByVal value As Enum_Mode_210)
                Mode = Mode Or value
            End Set
        End Property


        ''' <summary>
        '''  非允许时段刷卡不记录存贮记录 = 0
        '''  非允许时段刷卡记录存贮记录 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Mode_3() As Boolean
            Get
                Return Mode And 8
            End Get
            Set(ByVal value As Boolean)
                Mode = IIf(value, Mode Or 8, IIf(Mode And 8, Mode - 8, Mode))
            End Set
        End Property


        Public Property Mode_54() As Enum_Mode_54
            Get
                Return Mode And 48
            End Get
            Set(ByVal value As Enum_Mode_54)
                Mode = Mode Or value
            End Set
        End Property
        ''' <summary>
        ''' 允许重复刷卡 = 0
        ''' 禁止重复刷卡 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Mode_6() As Boolean
            Get
                Return Mode And 64
            End Get
            Set(ByVal value As Boolean)
                Mode = IIf(value, Mode Or 64, IIf(Mode And 64, Mode - 64, Mode))
            End Set
        End Property
        ''' <summary>
        '''  记录存贮满后停止存贮 = 0
        '''  记录存贮满后循环存贮 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Mode_7() As Boolean
            Get
                Return Mode And 128
            End Get
            Set(ByVal value As Boolean)
                Mode = IIf(value, Mode Or 128, IIf(Mode And 128, Mode - 128, Mode))
            End Set
        End Property

#End Region

#Region "ExtraMode枚举"
        'Public Enum Enum_ExtraMode_0
        '    不进行考勤白名单检查 = 0
        '    检查刷卡卡号是否在考勤白名单中不是则报警 = 1
        'End Enum

        'Public Enum Enum_ExtraMode_1
        '    考勤时不进行考勤黑名单检查 = 0
        '    考勤时检查刷卡卡号是否在考勤黑名单中是则报警 = 1
        'End Enum

        'Public Enum Enum_ExtraMode_2
        '    门禁通行判断时不进行黑名单检查 = 0
        '    门禁通行判断时检查刷卡卡号是否为黑名单是则报警 = 1
        'End Enum

        'Public Enum Enum_ExtraMode_3
        '    刷卡时不进行组别比较 = 0
        '    IC卡刷卡时检查卡片上的组别信息是否与机具组别匹配不匹配则报警 = 1
        'End Enum


        'Public Enum Enum_ExtraMode_4
        '    门禁通行时不进行通行名单检查任何卡都可通行 = 0
        '    门禁通行时需要检查刷卡卡号是否在门禁通行名单中不是则报警 = 1
        'End Enum

        Public Enum Enum_ExtraMode_765
            电锁外接继电器1报警外接继电器2 = 0
            电锁外接继电器2报警外接继电器1 = 96
            正确指示灯外接继电器1错误指示灯外接继电器2 = 128
            控制器启动门禁通行反潜回检查 = 160
        End Enum

#End Region

#Region "ExtraMode属性"

        Private _ExtraMode As Integer
        Public Property ExtraMode() As Integer
            Get
                Return _ExtraMode
            End Get
            Set(ByVal value As Integer)
                _ExtraMode = value
            End Set
        End Property

        ''' <summary>
        '''  不进行考勤白名单检查 = 0 = 0
        '''  检查刷卡卡号是否在考勤白名单中不是则报警 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Property ExtraMode_0() As Boolean
            Get
                Return ExtraMode And 1
            End Get
            Set(ByVal value As Boolean)
                ExtraMode = IIf(value, ExtraMode Or 1, IIf(ExtraMode And 1, ExtraMode - 1, ExtraMode))
            End Set
        End Property
        ''' <summary>
        '''  考勤时不进行考勤黑名单检查 = 0
        ''' 考勤时检查刷卡卡号是否在考勤黑名单中是则报警 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ExtraMode_1() As Boolean
            Get
                Return ExtraMode And 2
            End Get
            Set(ByVal value As Boolean)
                ExtraMode = IIf(value, ExtraMode Or 2, IIf(ExtraMode And 2, ExtraMode - 2, ExtraMode))
            End Set
        End Property
        ''' <summary>
        '''  门禁通行判断时不进行黑名单检查 = 0
        '''   门禁通行判断时检查刷卡卡号是否为黑名单是则报警 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ExtraMode_2() As Boolean
            Get
                Return ExtraMode And 4
            End Get
            Set(ByVal value As Boolean)
                ExtraMode = IIf(value, ExtraMode Or 4, IIf(ExtraMode And 4, Mode - 4, ExtraMode))
            End Set
        End Property
        ''' <summary>
        '''   刷卡时不进行组别比较 = 0
        '''  IC卡刷卡时检查卡片上的组别信息是否与机具组别匹配不匹配则报警 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>


        Public Property ExtraMode_3() As Boolean
            Get
                Return ExtraMode And 8
            End Get
            Set(ByVal value As Boolean)
                ExtraMode = IIf(value, ExtraMode Or 8, IIf(ExtraMode And 8, ExtraMode - 8, ExtraMode))
            End Set
        End Property

        ''' <summary>
        '''  门禁通行时不进行通行名单检查任何卡都可通行 = 0
        '''   门禁通行时需要检查刷卡卡号是否在门禁通行名单中不是则报警 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ExtraMode_4() As Boolean
            Get
                Return ExtraMode And 16
            End Get
            Set(ByVal value As Boolean)
                ExtraMode = IIf(value, ExtraMode Or 16, IIf(ExtraMode And 16, ExtraMode - 16, ExtraMode))
            End Set
        End Property


        Public Property ExtraMode_765() As Enum_ExtraMode_765
            Get
                Return ExtraMode And 224
            End Get
            Set(ByVal value As Enum_ExtraMode_765)
                ExtraMode = ExtraMode Or value
            End Set
        End Property


#End Region


#Region "SystemMode枚举"
        'Public Enum Enum_SystemMode_0
        '    不存贮考勤记录 = 0
        '    存贮员工正常考勤记录 = 1
        'End Enum

        'Public Enum Enum_SystemMode_1
        '    黑名单刷卡时不存贮记录 = 0
        '    黑名单刷卡时存贮记录 = 1
        'End Enum

        'Public Enum Enum_SystemMode_2
        '    非法卡刷卡不存贮记录 = 0
        '    非法卡刷卡存贮记录 = 1
        'End Enum

        'Public Enum Enum_SystemMode_3
        '    通讯时使用客户自定义设置的机号作为设备号用于联机 = 0
        '    通讯时使用机具产品序列号的最后2位数字作为设备号用于联机 = 1
        'End Enum


        'Public Enum Enum_SystemMode_4
        '    不进行门打开超时检查 = 0
        '    门禁开门时检查门打开是否超时是则报警 = 1
        'End Enum

        'Public Enum Enum_SystemMode_5
        '    门禁无法通行时不存贮刷卡信息 = 0
        '    门禁刷卡后检测到该卡无法通行时存贮记录以备查验 = 1
        'End Enum

        'Public Enum Enum_SystemMode_6
        '    门禁通行后不存贮刷卡信息可用于简单通行控制场合 = 0
        '    门禁通行后存贮该卡的通行记录 = 1
        'End Enum

        'Public Enum Enum_SystemMode_7
        '    考勤时任何时段都可以刷卡 = 0
        '    考勤时分时段刷卡非允许时段刷卡报警 = 1
        'End Enum


#End Region

#Region "SystemMode属性"


        Private _SystemMode As Integer
        Public Property SystemMode() As Integer
            Get
                Return _SystemMode
            End Get
            Set(ByVal value As Integer)
                _SystemMode = value
            End Set
        End Property

        ''' <summary>
        ''' 不存贮考勤记录 = 0
        ''' 存贮员工正常考勤记录 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_0() As Boolean
            Get
                Return SystemMode And 1
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 1, IIf(SystemMode And 1, SystemMode - 1, SystemMode))
            End Set
        End Property
        ''' <summary>
        ''' 黑名单刷卡时不存贮记录=0
        ''' 黑名单刷卡时存贮记录 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_1() As Boolean
            Get
                Return SystemMode And 2
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 2, IIf(SystemMode And 2, SystemMode - 2, SystemMode))
            End Set
        End Property
        ''' <summary>
        ''' 非法卡刷卡不存贮记录 = 0
        ''' 非法卡刷卡存贮记录 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_2() As Boolean
            Get
                Return SystemMode And 4
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 4, IIf(SystemMode And 4, SystemMode - 4, SystemMode))
            End Set
        End Property

        ''' <summary>
        ''' 通讯时使用客户自定义设置的机号作为设备号用于联机 = 0
        ''' 通讯时使用机具产品序列号的最后2位数字作为设备号用于联机 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_3() As Boolean
            Get
                Return SystemMode And 8
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 8, IIf(SystemMode And 8, SystemMode - 8, SystemMode))
            End Set
        End Property

        ''' <summary>
        '''   不进行门打开超时检查 = 0
        '''   门禁开门时检查门打开是否超时是则报警 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_4() As Boolean
            Get
                Return SystemMode And 16
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 16, IIf(SystemMode And 16, SystemMode - 16, SystemMode))
            End Set
        End Property
        ''' <summary>
        '''  门禁无法通行时不存贮刷卡信息 = 0
        '''   门禁刷卡后检测到该卡无法通行时存贮记录以备查验 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_5() As Boolean
            Get
                Return SystemMode And 32
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 32, IIf(SystemMode And 32, SystemMode - 32, SystemMode))
            End Set
        End Property
        ''' <summary>
        '''   门禁通行后不存贮刷卡信息可用于简单通行控制场合 = 0
        '''   门禁通行后存贮该卡的通行记录 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_6() As Boolean
            Get
                Return Mode And 64
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 64, IIf(SystemMode And 64, SystemMode - 64, SystemMode))
            End Set
        End Property
        ''' <summary>
        '''考勤时任何时段都可以刷卡 = 0
        '''考勤时分时段刷卡非允许时段刷卡报警 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SystemMode_7() As Boolean
            Get
                Return SystemMode And 128
            End Get
            Set(ByVal value As Boolean)
                SystemMode = IIf(value, SystemMode Or 128, IIf(SystemMode And 128, SystemMode - 128, SystemMode))
            End Set
        End Property

#End Region

#Region "RingMode枚举"


        'Public Enum Enum_RingMode_1
        '    黑名单卡非法卡刷卡时静音只显示刷卡错误提示信息 = 0
        '    黑名单卡非法卡刷卡时响铃发出刷卡错误提示音 = 1
        'End Enum

        'Public Enum Enum_RingMode_2
        '    非允许刷卡时段刷卡静音只显示相关提示信息 = 0
        '    非允许刷卡时段刷卡响铃发出相对应的提示音 = 1
        'End Enum

        'Public Enum Enum_RingMode_3
        '    刷卡无法通行时静音只显示无法通行提示信息 = 0
        '    刷卡无法通行时响铃发出无法通行提示音 = 1
        'End Enum


        'Public Enum Enum_RingMode_4
        '    使用常闭门磁门关闭时门磁闭合开关断路 = 0
        '    使用常开门磁门关闭时门磁闭合开关短路 = 1
        'End Enum

        'Public Enum Enum_RingMode_5
        '    外部输入联动警报为防盗等警报生效时应能自动关门防盗 = 0
        '    外部输入联动警报为火灾消防警报生效时应能自动开门逃生 = 1
        'End Enum

        Public Enum Enum_RingMode_76
            未使用外接读头 = 0
            Wiegand通讯格式外接读头 = 64
            ABA通讯格式外接读头 = 128
            ABA通讯格式Wiegand数据格式读头 = 192
        End Enum
#End Region

#Region "RingMode属性"

        Private _RingMode As Integer
        Public Property RingMode() As Integer
            Get
                Return _RingMode
            End Get
            Set(ByVal value As Integer)
                _RingMode = value
            End Set
        End Property

        ''' <summary>
        ''' 正常刷卡时静音只显示刷卡信息 = 0
        ''' 正常刷卡时响铃发出正常刷卡提示音 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RingMode_0() As Boolean
            Get
                Return RingMode And 1
            End Get
            Set(ByVal value As Boolean)
                RingMode = IIf(value, RingMode Or 1, IIf(RingMode And 1, RingMode - 1, RingMode))
            End Set
        End Property

        ''' <summary>
        ''' 黑名单卡非法卡刷卡时静音只显示刷卡错误提示信息 = 0
        ''' 黑名单卡非法卡刷卡时响铃发出刷卡错误提示音 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RingMode_1() As Boolean
            Get
                Return RingMode And 2
            End Get
            Set(ByVal value As Boolean)
                RingMode = IIf(value, RingMode Or 2, IIf(RingMode And 2, RingMode - 2, RingMode))
            End Set
        End Property
        ''' <summary>
        '''非允许刷卡时段刷卡静音只显示相关提示信息 = 0
        '''非允许刷卡时段刷卡响铃发出相对应的提示音= 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RingMode_2() As Boolean
            Get
                Return RingMode And 4
            End Get
            Set(ByVal value As Boolean)
                RingMode = IIf(value, RingMode Or 4, IIf(RingMode And 4, RingMode - 4, RingMode))
            End Set
        End Property

        ''' <summary>
        ''' 刷卡无法通行时静音只显示无法通行提示信息 = 0
        ''' 刷卡无法通行时响铃发出无法通行提示音= 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Property RingMode_3() As Boolean
            Get
                Return RingMode And 8
            End Get
            Set(ByVal value As Boolean)
                RingMode = IIf(value, RingMode Or 8, IIf(RingMode And 8, RingMode - 8, RingMode))
            End Set
        End Property

        ''' <summary>
        ''' 使用常闭门磁门关闭时门磁闭合开关断路 = 0
        '''  使用常开门磁门关闭时门磁闭合开关短路 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RingMode_4() As Boolean
            Get
                Return RingMode And 16
            End Get
            Set(ByVal value As Boolean)
                RingMode = IIf(value, RingMode Or 16, IIf(RingMode And 16, RingMode - 16, RingMode))
            End Set
        End Property

        ''' <summary>
        '''  外部输入联动警报为防盗等警报生效时应能自动关门防盗 = 0
        '''  外部输入联动警报为火灾消防警报生效时应能自动开门逃生 = 1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RingMode_5() As Boolean
            Get
                Return RingMode And 32
            End Get
            Set(ByVal value As Boolean)
                RingMode = IIf(value, RingMode Or 32, IIf(RingMode And 32, RingMode - 32, RingMode))
            End Set
        End Property

        Public Property RingMode_76() As Enum_RingMode_76
            Get
                Return Mode And 192
            End Get
            Set(ByVal value As Enum_RingMode_76)
                RingMode = RingMode Or value
            End Set
        End Property


#End Region

    End Class
#End Region



#Region "原来的函数"


    Public Function GetAtMachineTime(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As String
        Dim strDateTime As String = Space(30)
        If OpenPort(ipAddr, ipPort, clock_id) Then
            If ReadClockTimeString(hPort, strDateTime) Then
                ClosePort()
                Return "20" + strDateTime
            Else
                ClosePort()
                Return "不能读出设备的时间"
            End If
        Else
            Return "不能联接设备"
        End If
    End Function

    Public Function SetAtMachineTime(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As String
        If OpenPort(ipAddr, ipPort, clock_id) Then

            If SetClockTime(hPort, GetTime.ToOADate()) Then
                Return "设置时间成功"
            Else
                Return "设置时间失败"
            End If
            ClosePort()
        Else
            Return "不能联接设备"
        End If
    End Function




    Public FileName As String = AppPath + "\" + Format(Now, "yyyy-MM-dd") + ".txt"
    Public Function LoadAtMachineCard(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker) As String
        Dim flag As Boolean
        Dim K As Integer
        Dim nLine As Integer
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer
        Count = 0
        flag = True

        Dim strLine As String = ""
        Dim Ds As String = ""
        Dim Id As String = ""
        Dim L As Integer = 0
        Dim x As Integer = x
        BW.ReportProgress(1, "开始下载数据!")
        If OpenPort(ipAddr, ipPort, clock_id) Then
            Try
                Do While flag = True
                    nLine = BatchReadRecord(hPort, DataBuff, 1100)
                    'If nLine = 0 Or nLine = -1 Then flag = Flase
                    If nLine > 0 Then
                        For K = 0 To nLine - 1 '原66，现修改后为114 格式：机号+卡号+时间+标志
                            'strLine = CStr(clock_id) + vbTab + Format(Mid(DataBuff, K * 114 + 1, 10), "0000000000") + vbTab + Mid(DataBuff, K * 114 + 21, 14) + vbTab + Str(Asc(Mid(DataBuff, K * 114 + 55, 1)) And 63)+ vbTab + Str(Asc(Mid(DataBuff, K * 114 + 55, 1)) shr 6)
                            Try
                                Id = CLng(Mid(DataBuff, K * 114 + 1, 10)).ToString("0000000000")
                                Ds = CLng(Mid(DataBuff, K * 114 + 21, 14)).ToString("0000-00-00 00:00:00")
                                strLine = strLine & "if not(exists(select top 1*from T15502_At_Data where card_id='" & Id & "' and Card_date='" & Ds & "' and at_id=" & clock_id & "))insert into T15502_At_Data(card_id,Card_date,at_id,ishandle,User_ID)Values('" & Id & "','" & Ds & "'," & clock_id & ",0,0)"
                                Count = Count + 1
                                L = L + 1
                            Catch ex As Exception
                            End Try
                        Next K
                    Else
                        flag = False
                    End If
                    BW.ReportProgress(10, "下载记录总数:" & Count)
                    If L >= 160 Then
                        x = UploadCard(strLine)
                        strLine = ""
                        L = 0
                    End If
                Loop
                If L > 0 Then
                    x = UploadCard(strLine)
                End If
            Catch ex As Exception
                ClosePort()
                Return "下载记录总数:" & Count
            End Try
            BW.ReportProgress(10, "下载完成,共" & Count)
            ClosePort()
            If Count > 0 Then
                BW.ReportProgress(11, "下载完成,共" & Count & "开始识别记录!")
                Dim RR As MsgReturn = SqlStrToOneStr("P15500_At_Data_Check")
                If RR.IsOk Then
                    If Val(RR.Msg) > 0 Then
                        Return "下载记录总数:" & Count & RR.Msg & "条记录没有识别!"
                    Else
                        Return "下载记录总数:" & Count & "全部记录都已经识别!"
                    End If
                Else
                    Return "下载记录总数:" & Count & "识别记录失败!"
                End If
            Else
                Return CStr(clock_id) & " 号机内没有数据" & IIf(x = -1, ",打开数据库失败,数据已下载到文件,但没有保存到数据库!", "")
            End If
            ClosePort()
        Else
            Return CStr(clock_id) & "号机联机失败"
        End If
    End Function

    Function UploadCard(ByVal Str As String) As Integer
        Dim Sqlstr As String

        Try
            RunSQL(Str)
            If My.Computer.FileSystem.FileExists(FileName) Then
                Using Fs As New FileStream(FileName, FileMode.Open, FileAccess.Read)
                    Using Br As New StreamReader(Fs)
                        Sqlstr = Br.ReadToEnd
                        Br.Close()
                    End Using
                    Fs.Close()
                End Using
                If Sqlstr.Length > 0 Then RunSQL(Sqlstr)
                If My.Computer.FileSystem.FileExists(FileName) Then My.Computer.FileSystem.DeleteFile(FileName)
            End If
            Return 1
        Catch ex As Exception
            Using Fs As New FileStream(FileName, FileMode.Append, FileAccess.Write)
                Using Br As New StreamWriter(Fs)
                    Br.WriteLine(Str)
                End Using
            End Using
            Return -1
        End Try

    End Function


    Private Function OpenPort(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As Boolean
        SelectCommStyle(1)
        hPort = OpenClientSocket(ipAddr, ipPort)
        SetCmdVerify(True)
        If CallClock(hPort, clock_id) Then
            OpenPort = True
        Else
            OpenPort = False
        End If
    End Function

    Private Function ClosePort() As Boolean
        CloseClientSocket(hPort)
    End Function

    Public Function DelAtAllUser(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short) As Boolean
        For i As Integer = 1 To 3
            If OpenPort(ipAddr, ipPort, clock_id) Then
                Try
                    DeleteAllAllowedCard(hPort)
                    ClosePort()
                    Return True
                Catch ex As Exception
                    ClosePort()
                End Try
            End If
        Next
        Return False
    End Function

    'Public M As New System.Text.StringBuilder
    Public Function SendAtMachineOneUser(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal sName As String, ByVal ER_ID As String) As Boolean
        '   M.AppendLine(hPort & vbTab & ER_ID & vbTab & sName)
        For i As Integer = 1 To 5
            Try
                If OpenPort(ipAddr, ipPort, clock_id) Then
                    If sName.Length > 4 Then
                        sName = sName.Substring(0, 4)
                    End If
                    If SetAllowedCard(hPort, ER_ID, "", sName) Then
                        ClosePort()
                        Return True
                    End If
                    ClosePort()
                End If
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(10)
        Next
        Return False
    End Function



    Public Function SendAtMachineName(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker) As String
        '   M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0

        BW.ReportProgress(1, "删除原有的名单!")
        If DelAtAllUser(ipAddr, ipPort, clock_id) = False Then
            Return CStr(clock_id) & "号机联机失败"
        End If

        BW.ReportProgress(1, "开始发送名单!")
        Try
            Dim R As DtReturnMsg = SqlStrToDt("select ID,Employee_No,Employee_Name,isnull(Employee_Card,'') as Employee_Card from T15001_Employee where isnull(Employee_Card,'')<>'' and Employee_CardEndDate is null")
            ErrList = R.Dt.Clone

            For i As Integer = 0 To R.Dt.Rows.Count - 1
                If SendAtMachineOneUser(ipAddr, ipPort, clock_id, R.Dt.Rows(i).Item("Employee_Name").ToString, R.Dt.Rows(i).Item("Employee_Card").ToString) Then
                    Count += 1
                Else
                    ErrList.ImportRow(R.Dt.Rows(i))
                    ECount += 1
                End If
                BW.ReportProgress(10, "发送记录总数:" & Count & ",失败数:" & ECount)
            Next

            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        Catch ex As Exception
            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        End Try

    End Function

    Public Function SendAtMachineName_Part(ByVal ipAddr As String, ByVal ipPort As Integer, ByVal clock_id As Short, ByVal BW As BackgroundWorker, ByVal Dt As DataTable) As String
        '  M = New System.Text.StringBuilder
        Dim DataBuff As String = Space(2000)
        Dim Count As Integer = 0
        Dim ECount As Integer = 0
        ErrList = Dt.Clone

        BW.ReportProgress(1, "开始发送名单!")
        Try
            'Dim R As DtReturnMsg = SqlStrToDt("select ID,Employee_No,Employee_Name,isnull(Employee_Card,'') as Employee_Card from T15001_Employee where isnull(Employee_Card,'')<>'' and Employee_CardEndDate is null")


            For i As Integer = 0 To Dt.Rows.Count - 1
                If SendAtMachineOneUser(ipAddr, ipPort, clock_id, Dt.Rows(i).Item("Employee_Name").ToString, Dt.Rows(i).Item("Employee_Card").ToString) Then
                    Count += 1
                Else
                    ErrList.ImportRow(Dt.Rows(i))
                    ECount += 1
                End If
                BW.ReportProgress(10, "发送记录总数:" & Count & ",失败数:" & ECount)
            Next

            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        Catch ex As Exception
            Return "总数:" + CStr(Count) + "/已发送:" + CStr(Count) + "/失败:" + CStr(ECount)
        End Try

    End Function


    Public ErrList As DataTable
#End Region
End Module
