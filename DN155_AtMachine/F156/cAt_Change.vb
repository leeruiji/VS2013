Imports System.Data
Imports PClass.PClass



Public Class cAttendance
    Public Shared Tomorrow As String = FormatSharp("Tomorrow")
    Public Shared AddTimeFormat As String = FormatSharp("AddTimeFormat")
    Public Shared TimeSplit As String = FormatSharp("TimeSplit")


#Region "辅助属性"
    ''' <summary>
    ''' 迟到超时
    ''' </summary>
    ''' <remarks></remarks>
    Public CD_TimeOut As Boolean = False
    ''' <summary>
    ''' 早退超时
    ''' </summary>
    ''' <remarks></remarks>
    Public ZT_TimeOut As Boolean = False
#End Region

#Region "变量属性"

    ''' <summary>
    ''' 日期
    ''' </summary>
    ''' <remarks></remarks>
    Public User_Date As Date
    Public User_ID As Integer
    ''' <summary>
    ''' 上班时间
    ''' </summary>
    ''' <remarks></remarks>
    Public Up_Time As String = ""
    Public Sub SetUp_time(ByVal T As Date)
        If Up_Time = "" Then
            If T.Date <> User_Date Then
                Up_Time = Tomorrow & T.ToString("HH:mm")
            Else
                Up_Time = T.ToString("HH:mm")
            End If
        End If
    End Sub


    ''' <summary>
    ''' 下班时间
    ''' </summary>
    ''' <remarks></remarks>
    Public Down_Time As String = ""
    Public Sub SetDown_Time(ByVal T As Date)
        If T.Date <> User_Date Then
            Down_Time = Tomorrow & T.ToString("HH:mm")
        Else
            Down_Time = T.ToString("HH:mm")
        End If
    End Sub


    ''' <summary>
    ''' 迟到
    ''' </summary>
    ''' <remarks></remarks>
    Public CD As Integer
    ''' <summary>
    ''' 早退
    ''' </summary>
    ''' <remarks></remarks>
    Public ZT As Integer
    ''' <summary>
    ''' 缺勤
    ''' </summary>
    ''' <remarks></remarks>
    Public QQ As Integer
    ''' <summary>
    ''' 休息
    ''' </summary>
    ''' <remarks></remarks>
    Public XX As Integer
    ''' <summary>
    ''' 加班
    ''' </summary>
    ''' <remarks></remarks>
    Public JB As Integer
    ''' <summary>
    ''' 班次
    ''' </summary>
    ''' <remarks></remarks>
    Public BC As String = ""
    ''' <summary>
    ''' 出勤
    ''' </summary>
    ''' <remarks></remarks>
    Public CQ As Integer
    ''' <summary>
    ''' 系统自动分析
    ''' </summary>
    ''' <remarks></remarks>
    Public Is_Auto As Boolean = 1
    ''' <summary>
    ''' 图示
    ''' </summary>
    ''' <remarks></remarks>
    Public Remark As String = ""
    ''' <summary>
    ''' 备注
    ''' </summary>
    ''' <remarks></remarks>
    Public Remark_Mx As String = ""


    Public Sub AddRemark_Mx(ByVal Str As String)
        If Remark_Mx <> "" Then
            Remark_Mx = Remark_Mx & "," & Str
        Else
            Remark_Mx = Str
        End If
    End Sub

    ''' <summary>
    ''' 班次ID
    ''' </summary>
    ''' <remarks></remarks>
    Public Shift_Line As Integer
    ''' <summary>
    ''' 状态
    ''' </summary>
    ''' <remarks></remarks>
    Public State As String
    ''' <summary>
    ''' 多次打卡情况
    ''' </summary>
    ''' <remarks></remarks>
    Public TimeStr As String = ""

    Public Sub AddTime(ByVal T As Date, ByVal sDate As Date)
        If TimeStr <> "" Then
            If T.Date = sDate.Date Then
                TimeStr = TimeStr & TimeSplit & T.ToString(AddTimeFormat)
            Else
                TimeStr = TimeStr & TimeSplit & Tomorrow & T.ToString(AddTimeFormat)
            End If
        Else
            If T.Date = sDate.Date Then
                TimeStr = T.ToString(AddTimeFormat)
            Else
                TimeStr = Tomorrow & T.ToString(AddTimeFormat)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 上班说明
    ''' </summary>
    ''' <remarks></remarks>
    Public ShiftStr As String = ""

#End Region
#Region "方法"
    ''' <summary>
    ''' 把自己复制到DataRow中
    ''' </summary>
    ''' <param name="Dr"></param>
    ''' <remarks></remarks>
    Public Sub SetDr(ByVal Dr As DataRow)
        Dr("User_Date") = User_Date
        Dr("User_ID") = User_ID
        Dr("Up_Time") = Up_Time
        Dr("Down_Time") = Down_Time
        Dr("CD") = CD
        Dr("ZT") = ZT
        Dr("QQ") = QQ
        Dr("XX") = XX
        Dr("JB") = JB
        Dr("BC") = BC
        Dr("CQ") = CQ
        Dr("Is_Auto") = Is_Auto
        Dr("Remark") = Remark
        Dr("Remark_Mx") = Remark_Mx
        Dr("IsLock") = 0
        Dr("Shift_Line") = Shift_Line
        Dr("State") = State

        If TimeStr.Length <= 200 Then
            Dr("TimeStr") = TimeStr
        Else
            Dr("TimeStr") = TimeStr.Substring(0, 200)
        End If
        If ShiftStr.Length <= 500 Then
            Dr("ShiftStr") = ShiftStr
        Else
            Dr("ShiftStr") = ShiftStr.Substring(0, 500)
        End If

    End Sub

    Public Sub New()

    End Sub
    Public Sub New(ByVal Dr As DataRow)
        User_Date = Dr("User_Date")
        User_ID = Dr("User_ID")
        Up_Time = Dr("Up_Time")
        Down_Time = Dr("Down_Time")
        CD = Dr("CD")
        ZT = Dr("ZT")
        QQ = Dr("QQ")
        XX = Dr("XX")
        JB = Dr("JB")
        BC = Dr("BC")
        CQ = Dr("CQ")
        Is_Auto = Dr("Is_Auto")
        Remark = Dr("Remark")
        Shift_Line = Dr("Shift_Line")
        State = Dr("State")
        TimeStr = Dr("TimeStr")
        ShiftStr = Dr("ShiftStr")
    End Sub
#End Region
End Class

''' <summary>
''' 分析结果类
''' </summary>
''' <remarks></remarks>
Public Class cAt_Change
    Private Data As cAt_Data
    Private EData As cAt_Data
    ''' <summary>
    ''' 是否清除旧记录
    ''' </summary>
    ''' <remarks></remarks>
    Public ClearOldRecord As Boolean = False
    ''' <summary>
    ''' 分析进度事件 只对多个人分析才会发生
    ''' </summary>
    ''' <param name="I"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Public Event ProgressEvent(ByVal I As Integer, ByVal Msg As String)
    Sub New(ByVal Data As cAt_Data)
        Me.Data = Data
    End Sub

    ''' <summary>
    ''' 开始分析
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function StartChange() As Boolean
        If Data Is Nothing Then
            Return False
        End If
        If Data.Employee_ID = 0 Then
            Return True
        Else
            Return SaveAtList(ChangeEmployee).IsOk
        End If
    End Function

    ''' <summary>
    ''' 开始分析 多天
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ChangeEmployee() As List(Of cAttendance)
        Dim D As Date = Data.StartDate
        EData = Data
        Dim AtList As New List(Of cAttendance)
        Dim DC As Integer = DateDiff(DateInterval.Day, Data.StartDate, Data.EndDate) + 1
        Dim i As Integer = 0
        Dim N As String = EData.Dt_Emplyee.Rows(0)("Employee_Name")
        RaiseEvent ProgressEvent(i * 100 / DC, "正在分析[" & N & "]的考勤记录")
        Do Until D > Data.EndDate
            'RaiseEvent ProgressEvent(i * 100 / DC, "正在分析[" & N & "]的" & D.ToString("yyyy年MM月dd日") & "的考勤记录")
            AtList.Add(ChangeOneDate(D))
            D = D.AddDays(1)
            i = i + 1
            'RaiseEvent ProgressEvent(i * 100 / DC, "分析完[" & N & "]的" & D.ToString("yyyy年MM月dd日") & "的考勤记录")
        Loop
        Return AtList
    End Function

    ''' <summary>
    ''' 保存数据多天
    ''' </summary>
    ''' <param name="AtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SaveAtList(ByVal AtList As List(Of cAttendance)) As MsgReturn
        Dim R As New MsgReturn
        Dim SQL As New Dictionary(Of String, String)
        SQL.Add("A", "select * from T15610_Attendance_Data where User_Date between @StartDate and @EndDate and User_ID=@Employee_ID")
        Dim P As New Dictionary(Of String, Object)
        P.Add("StartDate", Data.StartDate)
        P.Add("EndDate", Data.EndDate)
        P.Add("Employee_ID", Data.Employee_ID)

        Using H As New DtHelper(SQL, P)
            If H.IsOk Then
                Dim Dr As DataRow
                If ClearOldRecord Then
                    For Each Dr In H.DtList("A").Rows
                        Dr.Delete()
                    Next
                End If
                For Each c As cAttendance In AtList
                    If ClearOldRecord Then
                        Dr = H.DtList("A").NewRow
                        H.DtList("A").Rows.Add(Dr)
                    Else
                        Dim Rows() As DataRow = H.DtList("A").Select("User_Date='" & c.User_Date.ToString("yyyy-MM-dd") & "'")
                        If Rows.Length > 0 Then
                            Dr = Rows(0)
                        Else
                            Dr = H.DtList("A").NewRow
                            H.DtList("A").Rows.Add(Dr)
                        End If
                    End If
                    c.SetDr(Dr)
                Next
                Return H.UpdateAll(True)
            Else
                R.IsOk = False
                R.Msg = H.Msg
                Return R
            End If
        End Using
    End Function

    ''' <summary>
    ''' 保存数据 某一天
    ''' </summary>
    ''' <param name="C"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveAtOneDate(ByVal C As cAttendance) As MsgReturn
        Dim R As New MsgReturn
        Dim SQL As New Dictionary(Of String, String)
        SQL.Add("A", "select * from T15610_Attendance_Data where User_Date between @User_Date  and User_ID=@Employee_ID")
        Dim P As New Dictionary(Of String, Object)
        P.Add("User_Date", C.User_Date)
        P.Add("Employee_ID", C.User_ID)
        Using H As New DtHelper(SQL, P)
            If H.IsOk Then
                Dim Dr As DataRow
                If H.DtList("A").Rows.Count > 0 Then
                    Dr = H.DtList("A").Rows(0)
                Else
                    Dr = H.DtList("A").NewRow
                    H.DtList("A").Rows.Add(Dr)
                End If
                C.SetDr(Dr)
                Return H.UpdateAll(True)
            Else
                R.IsOk = False
                R.Msg = H.Msg
                Return R
            End If
        End Using
    End Function

    ''' <summary>
    ''' 分析某一日
    ''' </summary>
    ''' <param name="sDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ChangeOneDate(ByVal sDate As Date) As cAttendance
        Dim R As New cAttendance
        R.User_Date = sDate
        R.User_ID = EData.Dt_Emplyee.Rows(0)("ID")

        If EData.Dt_Emplyee.Rows(0)("Employee_FirstDate") > sDate Then
            R.Remark_Mx = "未入职"
            R.State = "正常"
            Return R
        End If
        If EData.Dt_Emplyee.Rows(0)("Employee_QuitDate") IsNot DBNull.Value AndAlso EData.Dt_Emplyee.Rows(0)("Employee_QuitDate") < sDate Then
            R.Remark_Mx = "已离职"
            R.State = "正常"
            Return R
        End If

        Dim Employee_ShiftMoudel As Integer
        Dim DateStr As String = sDate.ToString("yyyy-MM-dd")
        R.User_Date = sDate
        '实际班次模板ＩＤ
        Dim Employee_Shift_StartDate As Date = IsNull(EData.Dt_Emplyee.Rows(0)("Employee_Shift_StartDate"), New Date(2010, 1, 1))
        Employee_ShiftMoudel = IsNull(EData.Dt_Emplyee.Rows(0)("Employee_ShiftMoudel"), 0)
        If sDate < Employee_Shift_StartDate Then
            For Each row As DataRow In EData.DT_EmployeeShift_History.Rows
                If sDate > row("sDate") Then
                    Employee_Shift_StartDate = row("sDate")
                    Employee_ShiftMoudel = IsNull(EData.Dt_Emplyee.Rows(0)("Employee_ShiftMoudel"), 0)
                    Exit For
                Else
                    Employee_ShiftMoudel = IsNull(row("ShangShift_Id"), 0)
                End If
            Next
        End If
        If Employee_ShiftMoudel = 0 Then
            Employee_ShiftMoudel = IsNull(EData.Dt_Emplyee.Rows(0)("Employee_ShiftMoudel"), 0)
        End If

        '搜索是否有个人排班
        Dim Rows() As DataRow = EData.Dt_Personal_Shift.Select("sDate='" & DateStr & "'")
        If Rows.Length > 0 Then
            R.Shift_Line = Rows(0)("Shift_ID") '个人排班优先
        Else '没有个人排班,使用实际班次模板
            Rows = EData.Dt_Real_Shift_Day.Select("sDate ='" & DateStr & "' and ID=" & Employee_ShiftMoudel)
            If Rows.Length > 0 Then
                R.Shift_Line = Rows(0)("Shift_ID")
            Else '都没有的
                R.Remark_Mx = "没有排班"
                R.State = "异常"
                Return R
            End If
        End If
        Rows = EData.Dt_AT_Shift.Select("Line=" & R.Shift_Line)
        If Rows.Length = 0 Then '没有找到这个班次
            R.Remark_Mx = "班次被删除"
            R.State = "异常"
            R.User_Date = sDate
            R.User_ID = EData.Dt_Emplyee.Rows(0)("ID")
            Return R
        End If
        Dim Dr_Shift As DataRow = Rows(0) '班次
        R.BC = Dr_Shift("shift_name")
        R.State = "正常"

        '开始分析
        If Dr_Shift("IsRest") Then '如果是休息
            R.XX = 1
            R.Remark = "★"
            Return R
        End If


        Rows = EData.DT_AT_Leave.Select("Le_StartDate<='" & DateStr & "' and '" & DateStr & "'<= Le_EndDate and IsDay=1")
        If Rows.Length > 0 Then '有按日请假单
            If Rows(0)("IS_CQ") Then
                R.CQ = 1
                R.Remark = "◆"
                R.Remark_Mx = "请假(带薪)"
            Else
                R.Remark = "▲"
                R.Remark_Mx = "请假"
            End If
            R.XX = 1
            Return R
        End If
        Dim TimeStart As Date
        Dim TimeSearchStart As Date


        Dim TimeEnd As Date
        Dim TimeSearchEnd As Date
        Dim Drs_At() As DataRow
        Dim C As New cTimeRange
        Dim CR As New cArgument(Dr_Shift)

        '取时间
        If Dr_Shift("TwoTime") Then '2次上班的
            Dim TimeStart2 As Date
            Dim TimeEnd2 As Date
            Dim LD As Date

            TimeStart = CDate(DateStr & " " & Dr_Shift("UP_Time"))
            TimeSearchStart = TimeStart.AddMinutes(-CR.ZD_Max)

            TimeEnd = CDate(DateStr & " " & Dr_Shift("Down_Time"))
            If TimeEnd < TimeStart Then
                TimeEnd = TimeEnd.AddDays(1)
            End If
            TimeSearchEnd = TimeEnd.AddMinutes(CR.CZ_Max)
            C.InsertAndDelTime(TimeStart, TimeEnd, True, sDate, "上班")

            TimeStart2 = CDate(DateStr & " " & Dr_Shift("UP_Time2"))
            If TimeStart2 < TimeEnd Then
                TimeStart2 = TimeStart2.AddDays(1)
            End If


            TimeEnd2 = CDate(DateStr & " " & Dr_Shift("Down_Time2"))
            If TimeEnd2 < TimeStart2 Then
                TimeEnd2 = TimeEnd2.AddDays(1)
            End If
            TimeSearchEnd = TimeEnd2.AddMinutes(CR.CZ_Max)
            C.InsertAndDelTime(TimeStart2, TimeEnd2, True, sDate, "")


            LD = TimeEnd2
            Dim Str As String = IsNull(Dr_Shift("ShiftStr"), "")
            If Str <> "" Then
                Dim SP() As String = Str.Split("|")
                For Each S As String In SP
                    If S <> "" Then
                        Dim sp2() As String = S.Split("-")
                        If sp2.Length = 2 Then
                            Try
                                C.InsertAndDelTime(CDate(Today.ToString("yyyy-MM-dd") & " " & sp2(0)), TimeEnd2, True, sDate, "")

                                TimeStart2 = CDate(DateStr & " " & sp2(0))
                                TimeEnd2 = CDate(DateStr & " " & sp2(1))
                                If TimeStart2 < LD Then
                                    TimeStart2 = TimeStart2.AddDays(1)
                                End If

                                If TimeEnd2 < TimeStart2 Then
                                    TimeEnd2 = TimeEnd2.AddDays(1)
                                End If
                                TimeSearchEnd = TimeEnd2.AddMinutes(CR.CZ_Max)
                                C.InsertAndDelTime(TimeStart2, TimeEnd2, True, sDate, "")
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                Next
            End If


        Else '当天下班
            TimeStart = CDate(DateStr & " " & Dr_Shift("UP_Time"))
            TimeSearchStart = TimeStart.AddMinutes(-CR.ZD_Max)
            TimeEnd = CDate(DateStr & " " & Dr_Shift("Down_Time"))
            If TimeEnd < TimeStart Then
                TimeEnd = TimeEnd.AddDays(1)
            End If
            TimeSearchEnd = TimeEnd.AddMinutes(CR.CZ_Max)

            C.InsertAndDelTime(TimeStart, TimeEnd, True, sDate, "上班")

        End If
        Dim TimeSearchStartStr As String = DateToTimeStr(TimeSearchStart)
        Dim TimeSearchEndStr As String = DateToTimeStr(TimeSearchEnd)

        '放行
        Rows = EData.DT_AT_ReleasePass.Select("(StartTime<='" & TimeSearchEndStr & "' and EndTime>='" & TimeSearchStartStr & "')")
        For Each Dr As DataRow In Rows
            C.InsertAndDelTime(Dr("StartTime"), Dr("EndTime"), False, sDate, "放行")
        Next

        '请假
        Rows = EData.DT_AT_Leave.Select("(Le_StartDate<='" & TimeSearchEndStr & "' and Le_EndDate>='" & TimeSearchStartStr & "') and IsDay=0")
        For Each Dr As DataRow In Rows
            C.InsertAndDelTime(Dr("Le_StartDate"), Dr("Le_EndDate"), False, sDate, "请假")
        Next

        R.ShiftStr = C.ShiftStr

        If IsNull(Dr_Shift("No_CheckTime"), 0) = False Then
            For Each Dr As DataRow In C.Dt.Rows
                Dim InTime As Date = Dr("InTime")
                Dim OutTime As Date = Dr("OutTime")
                Drs_At = EData.Dt_At_Data.Select("Card_Date >= '" & DateToTimeStr(InTime.AddMinutes(-CR.ZD_Max)) & "' and Card_Date<='" & DateToTimeStr(OutTime.AddMinutes(CR.CZ_Max)) & "' and IsHandle=0 ", "Card_Date")
                CheckTime(Drs_At, sDate, InTime, OutTime, CR, R)
            Next
        Else
            R.CQ = 1
            R.QQ = 0
            Try
                R.SetUp_time(C.Dt.Rows(0)("InTime"))
                R.SetDown_Time(C.Dt.Rows(C.Dt.Rows.Count - 1)("OutTime"))
            Catch ex As Exception
            End Try
        End If


        '图例:√正常出勤,▲请假,★带薪假期,●迟到,■早退,×旷工
        If R.QQ = 1 Then
            R.CD = 0
            R.ZT = 0
            R.Remark = "×"
            R.Remark_Mx = "旷工"
            R.State = "异常"
        Else
            R.CQ = 1
            If R.CD > 0 Then
                R.Remark = R.Remark & "●"
                R.AddRemark_Mx("迟到" & R.CD & "分钟")
                R.State = "异常"
            End If
            If R.ZT > 0 Then
                R.Remark = R.Remark & "■"
                R.AddRemark_Mx("早退" & R.ZT & "分钟")
                R.State = "异常"
            End If
            If R.State <> "异常" Then
                R.Remark = "√"
                R.Remark_Mx = "正常出勤"
                R.State = "正常"
            End If
        End If
        Return R
    End Function

    Shared Function DateToTimeStr(ByVal sDate As Date) As String
        Return sDate.ToString("yyyy-MM-dd HH:mm")
    End Function


    ''' <summary>
    ''' 检查打卡在改时间段的有效性
    ''' </summary>
    ''' <param name="Rows"></param>
    ''' <param name="sDate"></param>
    ''' <param name="InTime"></param>
    ''' <param name="OutTime"></param>
    ''' <param name="Cr"></param>
    ''' <param name="R"></param>
    ''' <remarks></remarks>
    Private Sub CheckTime(ByVal Rows() As DataRow, ByVal sDate As Date, ByVal InTime As Date, ByVal OutTime As Date, ByVal Cr As cArgument, ByVal R As cAttendance)
        Dim HasInTime As Boolean = False
        Dim HasOutTime As Boolean = False
        Dim IsZT As Boolean = False
        Dim IsCD As Boolean = False
        For Each Dr As DataRow In Rows
            Dim D As Date = Dr("Card_Date")
            D = CDate(D.ToString("yyyy-MM-dd HH:mm"))
            If D <= InTime.AddMinutes(Cr.CD_Min) Then '打卡时间小于上班标准时间
                If HasInTime = False Then
                    HasInTime = True
                    R.AddTime(D, sDate)
                    Dr("IsHandle") = True
                    R.SetUp_time(D)
                End If
                Continue For
            End If
            If D <= InTime.AddMinutes(Cr.CD_Max) Then '打卡时间在迟到范围内
                If HasInTime = False Then
                    HasInTime = True
                    R.CD += DateDiff(DateInterval.Minute, InTime, D)
                    IsCD = True
                    R.AddTime(D, sDate)
                    Dr("IsHandle") = True
                    R.SetUp_time(D)
                    Continue For
                End If
            End If
            If D >= OutTime.AddMinutes(-Cr.ZT_Max) AndAlso D <= OutTime.AddMinutes(-Cr.ZT_Min) Then '打卡时间在早退范围内
                If HasOutTime = False Then
                    HasOutTime = True
                    IsZT = True
                    R.ZT += DateDiff(DateInterval.Minute, D, OutTime)
                    R.AddTime(D, sDate)
                    Dr("IsHandle") = True
                    R.SetDown_Time(D)
                    Continue For
                End If
            End If
            If D >= OutTime.AddMinutes(-Cr.ZT_Min) AndAlso D <= OutTime.AddMinutes(Cr.CZ_Max) Then '打卡时间在下班范围内
                If HasOutTime = False Then
                    HasOutTime = True
                    R.AddTime(D, sDate)
                    Dr("IsHandle") = True
                    R.SetDown_Time(D)
                End If
                Continue For
            End If
            If HasInTime = False Then
                R.SetUp_time(D)
            ElseIf HasOutTime = False Then
                R.SetDown_Time(D)
            End If
            R.QQ = 1
            R.AddTime(D, sDate)
            Dr("IsHandle") = True
        Next
        If HasInTime = False OrElse HasOutTime = False Then '是但有次没有打卡当矿工
            R.QQ = 1
        End If
    End Sub


    Public Class cArgument
        ''' <summary>
        ''' 早到时间
        ''' </summary>
        ''' <remarks></remarks>
        Public ZD_Max As Integer
        ''' <summary>
        ''' 迟退时间
        ''' </summary>
        ''' <remarks></remarks>
        Public CZ_Max As Integer
        ''' <summary>
        ''' 迟到多少分钟忽略
        ''' </summary>
        ''' <remarks></remarks>
        Public CD_Min As Integer
        ''' <summary>
        ''' 早退多少分钟忽略
        ''' </summary>
        ''' <remarks></remarks>
        Public ZT_Min As Integer
        ''' <summary>
        ''' 允许最大迟到时间
        ''' </summary>
        ''' <remarks></remarks>
        Public CD_Max As Integer
        ''' <summary>
        ''' 允许最大早退时间
        ''' </summary>
        ''' <remarks></remarks>
        Public ZT_Max As Integer
        Sub New(ByVal Dr_Shift As DataRow)
            ZD_Max = Dr_Shift("ZD_Max")
            CZ_Max = Dr_Shift("CZ_Max")
            CD_Min = Dr_Shift("CD_Min")
            ZT_Min = Dr_Shift("ZT_Min")
            CD_Max = Dr_Shift("CD_Max")
            ZT_Max = Dr_Shift("ZT_Max")
        End Sub
    End Class

    ''' <summary>
    ''' 时间范围分析
    ''' </summary>
    ''' <remarks></remarks>
    Public Class cTimeRange
        Public Dt As DataTable
        ''' <summary>
        ''' 上班说明
        ''' </summary>
        ''' <remarks></remarks>
        Public ShiftStr As String = ""

        Public Sub AddShiftStr(ByVal Str As String)
            If ShiftStr <> "" Then
                ShiftStr = ShiftStr & "," & Str
            Else
                ShiftStr = Str
            End If
        End Sub

        Public Sub InsertShiftStr(ByVal InTime As Date, ByVal OutTime As Date, ByVal sDate As Date, ByVal Remark As String)
            Dim Str As String = Remark & "从"
            If InTime.Date = sDate.Date Then
                Str = Str & InTime.ToString("HH:mm")
            Else
                Str = Str & cAttendance.Tomorrow & InTime.ToString("HH:mm")
            End If
            Str = Str & "到"
            If OutTime.Date = sDate.Date Then
                Str = Str & OutTime.ToString("HH:mm")
            Else
                Str = Str & cAttendance.Tomorrow & OutTime.ToString("HH:mm")
            End If
            AddShiftStr(Str)
        End Sub

        ''' <summary>
        ''' 上班时间范围插入和扣减
        ''' </summary>
        ''' <param name="InTime">时间开始</param>
        ''' <param name="OutTime">时间结束</param>
        ''' <param name="IsInsert">插入或扣减</param>
        ''' <param name="sDate">当哪天考勤</param>
        ''' <param name="Remark">时间段的标识</param>
        ''' <remarks></remarks>
        Sub InsertAndDelTime(ByVal InTime As Date, ByVal OutTime As Date, ByVal IsInsert As Boolean, ByVal sDate As String, ByVal Remark As String)
            If InTime = OutTime Then Exit Sub
            If InTime > OutTime Then
                Dim T As Date = InTime
                InTime = OutTime
                OutTime = T
            End If
            Dim Dr As DataRow
            Dim DrOld As DataRow
            InsertShiftStr(InTime, OutTime, sDate, Remark)
            Select Case Dt.Rows.Count
                Case 0
                    If IsInsert Then
                        Dr = Dt.NewRow
                        Dr("InTime") = InTime
                        Dr("OutTime") = OutTime
                        Dr("sDate") = sDate
                        Dr("eDate") = sDate
                        Dt.Rows.Add(Dr)
                        Exit Select
                    End If
                Case Else
                    If IsInsert Then
                        For i As Integer = 0 To Dt.Rows.Count - 1
                            DrOld = Dt.Rows(i)
                            If DrOld("InTime") >= InTime Then '原进入时间 大于插入的 进入时间
                                If DrOld("InTime") > OutTime Then '插入时间 比原时间早 并且无交集
                                    Dr = Dt.NewRow
                                    Dr("InTime") = InTime
                                    Dr("OutTime") = OutTime
                                    Dr("sDate") = sDate
                                    Dr("eDate") = sDate
                                    Dt.Rows.InsertAt(Dr, i)
                                    Exit Select
                                Else
                                    If DrOld("OutTime") >= OutTime Then '插入时间 和原时间有交集
                                        DrOld("InTime") = InTime
                                        If DrOld("sDate") > sDate Then
                                            DrOld("sDate") = sDate
                                        End If
                                        If DrOld("eDate") < sDate Then
                                            DrOld("eDate") = sDate
                                        End If
                                        Exit Select
                                    Else '插入时间完全包围原时间
                                        DrOld("InTime") = InTime
                                        If DrOld("sDate") > sDate Then
                                            DrOld("sDate") = sDate
                                        End If
                                        If DrOld("eDate") < sDate Then
                                            DrOld("eDate") = sDate
                                        End If
                                        InTime = DrOld("OutTime")
                                    End If
                                End If
                            Else '原进入时间 小于 插入的 进入时间
                                If DrOld("OutTime") >= OutTime Then '原来的时间 包含了 插入的时间
                                    '不处理
                                    If DrOld("sDate") > sDate Then
                                        DrOld("sDate") = sDate
                                    End If
                                    If DrOld("eDate") < sDate Then
                                        DrOld("eDate") = sDate
                                    End If
                                    Exit Select
                                Else '原进入时间 小于插入的 进入时间
                                    If DrOld("OutTime") < InTime Then '插入时间 比原时间晚 并且无交集
                                        '进入到下一个循环
                                    Else '插入时间 和原时间有交集
                                        InTime = DrOld("OutTime")
                                    End If
                                End If
                            End If
                        Next
                        Dr = Dt.NewRow
                        Dr("InTime") = InTime
                        Dr("OutTime") = OutTime
                        Dr("sDate") = sDate
                        Dr("eDate") = sDate
                        Dt.Rows.Add(Dr)
                    Else
                        For i As Integer = 0 To Dt.Rows.Count - 1
                            DrOld = Dt.Rows(i)
                            If DrOld("InTime") >= InTime Then '原进入时间 大于插入的 进入时间
                                If DrOld("OutTime") >= OutTime Then '插入时间 和原时间有交集
                                    If DrOld("InTime") < OutTime Then
                                        DrOld("InTime") = OutTime
                                    End If
                                    Exit Select
                                Else '插入的时间包含 原来的时间
                                    InTime = DrOld("OutTime")
                                    DrOld("InTime") = DrOld("OutTime")
                                End If
                            Else '原进入时间 小于 插入的 进入时间
                                If DrOld("OutTime") > OutTime Then '原来的时间 包含了 插入的时间
                                    Dr = Dt.NewRow
                                    Dr("InTime") = OutTime
                                    Dr("OutTime") = DrOld("OutTime")
                                    DrOld("OutTime") = InTime
                                    Dr("sDate") = DrOld("sDate")
                                    Dr("eDate") = DrOld("eDate")
                                    Dt.Rows.InsertAt(Dr, i + 1)
                                    Exit Select
                                Else '原进入时间 小于插入的 进入时间
                                    If DrOld("OutTime") > InTime Then
                                        Dim D As Date = DrOld("OutTime")
                                        DrOld("OutTime") = InTime
                                        InTime = D
                                    End If
                                End If
                            End If
                        Next
                    End If


                    Exit Select
            End Select
            If IsInsert Then
                For i As Integer = Dt.Rows.Count - 2 To 0 Step -1
                    If Dt.Rows(i + 1)("InTime") <= Dt.Rows(i)("OutTime") Then
                        Dt.Rows(i)("OutTime") = Dt.Rows(i + 1)("OutTime")
                        If Dt.Rows(i)("sDate") > Dt.Rows(i + 1)("sDate") Then
                            Dt.Rows(i)("sDate") = Dt.Rows(i + 1)("sDate")
                        End If
                        If Dt.Rows(i)("eDate") < Dt.Rows(i + 1)("eDate") Then
                            Dt.Rows(i)("eDate") = Dt.Rows(i + 1)("eDate")
                        End If
                        Dt.Rows(i + 1).Delete()
                    End If
                Next

            Else
                For i As Integer = Dt.Rows.Count - 1 To 0 Step -1
                    If Dt.Rows(i)("InTime") = Dt.Rows(i)("OutTime") Then
                        Dt.Rows(i).Delete()
                    End If
                Next
            End If

            Dt.AcceptChanges()
        End Sub

        Sub New()
            Dt = New DataTable
            ShiftStr = ""
            Dt.Columns.Add("sDate", GetType(Date))
            Dt.Columns.Add("eDate", GetType(Date))
            Dt.Columns.Add("InTime", GetType(Date))
            Dt.Columns.Add("OutTime", GetType(Date))
        End Sub
    End Class
End Class

''' <summary>
''' 查询结果类
''' </summary>
''' <remarks></remarks>
Public Class cAt_Data
#Region "属性 和 变量"
    Public ReadOnly Property StartDate() As Date
        Get
            Return _StartDate
        End Get
    End Property
    Private _StartDate As Date
    Public ReadOnly Property EndDate() As Date
        Get
            Return _EndDate
        End Get
    End Property
    Private _EndDate As Date
    Public ReadOnly Property Employee_ID() As Integer
        Get
            Return _Employee_ID
        End Get
    End Property
    Private _Employee_ID As Integer = 0


    Private _IsOk As Boolean = False
    Public ReadOnly Property IsOk() As Boolean
        Get
            Return _IsOk
        End Get
    End Property


    ''' <summary>
    ''' 班次
    ''' </summary>
    ''' <remarks></remarks>
    Public Dt_AT_Shift As DataTable
    ''' <summary>
    ''' 实际模板
    ''' </summary>
    ''' <remarks></remarks>
    Public Dt_Real_Shift_Day As DataTable
    ''' <summary>
    ''' 个人打卡记录
    ''' </summary>
    ''' <remarks></remarks>
    Public Dt_At_Data As DataTable

    ''' <summary>
    ''' 放行条
    ''' </summary>
    ''' <remarks></remarks>
    Public DT_AT_ReleasePass As DataTable

    ''' <summary>
    ''' 请假表
    ''' </summary>
    ''' <remarks></remarks>
    Public DT_AT_Leave As DataTable
    ''' <summary>
    ''' 个人考勤表
    ''' </summary>
    ''' <remarks></remarks>
    Public Dt_Personal_Shift As DataTable
    ''' <summary>
    ''' 换班记录
    ''' </summary>
    ''' <remarks></remarks>
    Public DT_EmployeeShift_History As DataTable
    ''' <summary>
    ''' 个人列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Dt_Emplyee As DataTable
#End Region



    ''' <summary>
    ''' 搜索某人记录
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Search_Employee() As Boolean
        Dim SqlList As New List(Of String)
        SqlList.Add("select sDate,ID,Shift_ID from T15519_Real_Shift_Day where sDate between @StartDate and @EndDate order by sDate,ID")
        SqlList.Add("select Card_Date,User_ID,0 as IsHandle from T15502_At_Data where Card_Date between @StartDateAdd and @EndDateAdd and User_ID=@Employee_ID  " & _
                    "union all  select Employee_Date,Employee_ID,0 as IsHandle from T15520_AT_SignCard where Employee_Date between @StartDateAdd and @EndDateAdd and Employee_ID=@Employee_ID  order by Card_Date")
        SqlList.Add("select * from T15541_AT_ReleasePass_List where Employee_ID=@Employee_ID and  (StartTime <= @EndDateAdd and EndTime>=@StartDateAdd ) ")
        SqlList.Add("select Employee_ID,Le_StartDate,Le_EndDate,IsDay,IS_CQ from T15530_AT_Leave where Employee_ID=@Employee_ID and (Le_StartDate <= @EndDateAdd and Le_EndDate>=@StartDateAdd ) order by Employee_ID,Le_StartDate,Le_EndDate")

        SqlList.Add("select sDate,Employee_ID,sDate,Shift_ID from T15605_Personal_Shift where Employee_ID=@Employee_ID and  sDate between @StartDate and @EndDate order by sDate")
        SqlList.Add("select sDate,Employee_ID,Shift_Id,ShangShift_Id from T15004_EmployeeShift_History where   sDate between @StartDate and @EndDate and Employee_ID=@Employee_ID  order by Employee_ID,sDate desc")
        SqlList.Add("select ID,Employee_Name,Employee_ShiftMoudel,Employee_Shift_StartDate,Employee_FirstDate,Employee_QuitDate from T15001_Employee where id=@Employee_ID")
        SqlList.Add("select * from T15510_AT_Shifts")
        Dim P As New Dictionary(Of String, Object)

        P.Add("StartDate", _StartDate)
        P.Add("EndDate", _EndDate)

        P.Add("StartDateAdd", _StartDate.AddDays(-1))
        P.Add("EndDateAdd", _EndDate.AddDays(2).AddSeconds(-1))

        P.Add("Employee_ID", _Employee_ID)
        Try
            Dim Dt As List(Of DataTable) = PClass.PClass.SqlStrToDtList(SqlList, P)
            If Dt IsNot Nothing Then
                Dt_Real_Shift_Day = Dt(0)
                Dt_At_Data = Dt(1)
                DT_AT_ReleasePass = Dt(2)
                DT_AT_Leave = Dt(3)

                Dt_Personal_Shift = Dt(4)
                DT_EmployeeShift_History = Dt(5)
                Dt_Emplyee = Dt(6)
                Dt_AT_Shift = Dt(7)
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try




    End Function

    Sub New(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Employee_ID As Integer)
        Me._StartDate = StartDate
        Me._EndDate = EndDate
        Me._Employee_ID = Employee_ID
    End Sub


End Class

''' <summary>
''' 个人类
''' </summary>
''' <remarks></remarks>
Public Class cAt_One
    Private StartDate As Date
    Private EndDate As Date
    Private Employee_ID As Integer
    Private Data As cAt_Data
    Private WithEvents C As cAt_Change
    Public Event ProgressEvent(ByVal I As Integer, ByVal Msg As String)

    Sub New(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Employee_ID As Integer)
        Me.StartDate = StartDate
        Me.EndDate = EndDate
        Me.Employee_ID = Employee_ID
    End Sub


    ''' <summary>
    ''' 初始化数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function StartSearch() As Boolean
        Data = New cAt_Data(StartDate, EndDate, Employee_ID)
        Return Data.Search_Employee
    End Function

    ''' <summary>
    ''' 开始分析
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function StartChange() As Boolean
        C = New cAt_Change(Data)
        Try
            Return C.StartChange
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub C_ProgressEvent(ByVal I As Integer, ByVal Msg As String) Handles C.ProgressEvent
        RaiseEvent ProgressEvent(I, Msg)
    End Sub
End Class

''' <summary>
''' 集体类
''' </summary>
''' <remarks></remarks>
Public Class cAt_All
    Private StartDate As Date
    Private EndDate As Date
    Private EmployeeList As DataTable
    Public IsStop As Boolean = False

    Public ProgressMsg As String
    Public ProgressValue As Integer
    Public progressEValue As Integer

    Public Ni As Integer = 0
    Public C As Integer
    Private WithEvents One As cAt_One
    Public Event ProgressEvent(ByVal ProgressValue As Integer, ByVal progressEValue As Integer, ByVal Msg As String)

    Sub New(ByVal StartDate As Date, ByVal EndDate As Date, ByVal EmployeeList As DataTable)
        Me.StartDate = StartDate
        Me.EndDate = EndDate
        Me.EmployeeList = EmployeeList
    End Sub


    Function Start() As Boolean
        IsStop = False
        Dim Dt As New DataTable("T")
        C = EmployeeList.Rows.Count
        ProgressValue = 0
        Ni = 0
        Dim DP As Double
        For Each E As DataRow In EmployeeList.Rows
            ProgressValue = Ni * 100 / C
            One = New cAt_One(StartDate, EndDate, E("Employee_ID"))
            One.StartSearch()
            DP = Ni + 0.2
            ProgressValue = DP * 100 / C
            One.StartChange()
            Ni = Ni + 1
            ProgressValue = Ni * 100 / C
            E("IsOk") = True
            If IsStop Then Return False
        Next
        Return True
    End Function

    Private Sub One_ProgressEvent(ByVal I As Integer, ByVal Msg As String) Handles One.ProgressEvent
        progressEValue = I
        ProgressMsg = Msg
        Dim DP As Double = progressEValue * 0.008 + 0.2
        DP = DP + Ni
        ProgressValue = DP * 100 / C
        RaiseEvent ProgressEvent(ProgressValue, progressEValue, Msg)
    End Sub
End Class