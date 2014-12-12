Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15611_Attendance_Msg
    Dim AtID As Integer = 0
    Dim dtSignCard As DataTable
    Dim isloaded As Boolean = False

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Bill_ID = 0
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal jID As Integer)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        AtID = jID
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15510
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
    End Sub

    Private Sub F15611_Attendance_Msg_AfterLoad() Handles Me.AfterLoad
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        TB_Employee_No.TextBox.Tag = F_RS_ID 'user_id
        TB_Employee_No.TextBox.Text = F_RS_ID2 'No
        TB_Employee_Name.TextBox.Text = F_RS_ID3 '姓名
        TB_Depart.TextBox.Text = F_RS_ID5
        MonthPicker.Value = F_RS_ID4 '月份

        StartDate = New Date(MonthPicker.Value.Year, MonthPicker.Value.Month, 1)

        'FP_Month.Visible = False
        Date_Ini()
        Me_Refresh()
        'FP_Month.Visible = True
        isloaded = True
    End Sub

    Private Sub Me_From_Load() Handles Me.Me_Load
        
    End Sub

#Region "日期生成"
    Public StartDate As Date
    Public EndDate As Date
    ''' <summary>
    ''' 本月有几日
    ''' </summary>
    ''' <remarks></remarks>
    Dim MDays As Integer
    Sub Date_Ini()
        MDays = Date.DaysInMonth(StartDate.Year, StartDate.Month)
        EndDate = New Date(StartDate.Year, StartDate.Month, MDays)

        Dim LDFW As Integer = Date.DaysInMonth(StartDate.AddMonths(-1).Year, StartDate.AddMonths(-1).Month)
        Dim DFW As Integer = StartDate.DayOfWeek
        If DFW = 0 Then DFW = 7
        For i As Integer = 1 To DFW
            Dim P As New Panel
            P.Name = "PL_LastMonth" & i
            Dim L As New Label
            L.Name = "LB_LastMonth" & i

            P.BackColor = System.Drawing.Color.Transparent
            P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            P.Controls.Add(L)
            P.Size = New System.Drawing.Size(120, 84)

            L.AutoSize = True
            L.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            L.ForeColor = System.Drawing.Color.Olive
            L.Location = New System.Drawing.Point(15, 9)
            L.Size = New System.Drawing.Size(34, 16)
            L.Text = LDFW - DFW + i & "号"
            FP_Month.Controls.Add(P)
        Next

        For i As Integer = 1 To MDays
            Dim U As New UserDay
            U.Name = "UserDay" & i
            U.PF = Me
            U.SetDate(New Date(StartDate.Year, StartDate.Month, i))
            FP_Month.Controls.Add(U)
        Next


        DFW = 42 - MDays - DFW

        For i As Integer = 1 To DFW
            Dim P As New Panel
            P.Name = "PL_ThisMonth" & i
            Dim L As New Label
            L.Name = "LB_ThisMonth" & i

            P.BackColor = System.Drawing.Color.Transparent
            P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            P.Controls.Add(L)
            P.Size = New System.Drawing.Size(120, 84)

            L.AutoSize = True
            L.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
            L.ForeColor = System.Drawing.Color.Olive
            L.Location = New System.Drawing.Point(15, 9)
            L.Size = New System.Drawing.Size(34, 16)
            L.Text = i & "号"
            FP_Month.Controls.Add(P)
        Next
    End Sub
#End Region
  



    Sub Set_AT_Shifts()
        For i As Integer = 1 To MDays
            Dim U As UserDay = FP_Month.Controls("UserDay" & i)
            Dim Rows() As DataRow = Dt_Attendance_Data.Select("User_Date='" & New Date(StartDate.Year, StartDate.Month, i).ToString("yyyy-MM-dd") & "'")
            If Rows.Length > 0 Then
                Dim Dr As DataRow = Rows(0)
                U.Is_Auto = False
                If IsNull(Dr("IsLock"), False) Then
                    U.IsLock = True
                    U.LabelBC.Visible = True
                    U.LabelBC.Text = "班次:" & Dr("BC")
                    U.ComboBox_Data.Enabled = False
                    U.ComboBox_Data.Visible = False
                    U.Is_Auto = Dr("Is_Auto")
                Else
                    U.ComboBox_Data.ValueMember = "Line"
                    U.ComboBox_Data.DisplayMember = "shift_name"
                    U.ComboBox_Data.DataSource = Dt_Shift.Copy
                    U.ComboBox_Data.ValueMember = "Line"
                    U.ComboBox_Data.DisplayMember = "shift_name"
                    U.Is_Auto = Dr("Is_Auto")
                    U.ComboBox_Data.SelectedValue = Dr("Shift_Line")
                End If
                U.Up_Time = Dr("Up_Time")
                U.Down_Time = Dr("Down_Time")
                U.CD = Dr("CD")
                U.ZT = Dr("ZT")
                U.QQ = Dr("QQ")
                U.XX = Dr("XX")
                U.BC = Dr("BC")
                U.CQ = Dr("CQ")
                U.BC = Dr("BC")
                U.Shift_Line = Dr("Shift_Line")
                U.Remark = IsNull(Dr("Remark"), "")
                U.Remark_Mx = IsNull(Dr("Remark_Mx"), "")
                U.ShowRemark()
            Else
                U.IsNew = True
                U.ComboBox_Data.ValueMember = "Line"
                U.ComboBox_Data.DisplayMember = "shift_name"
                U.ComboBox_Data.DataSource = Dt_Shift.Copy
                U.ComboBox_Data.ValueMember = "Line"
                U.ComboBox_Data.DisplayMember = "shift_name"
                U.IsNew = False


            End If
        Next
    End Sub

    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "Employee_Date"
        fo.Value = StartDate
        fo.Value2 = StartDate.AddMonths(1).AddMilliseconds(-1)
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)


        fo = New FindOption
        fo.DB_Field = "Employee_ID"
        fo.Value = TB_Employee_No.TextBox.Tag

        fo.Field_Operator = Enum_Operator.Operator_Equal
        oList.FoList.Add(fo)

        Return oList
    End Function

    ''' <summary>
    ''' 打卡表
    ''' </summary>
    ''' <remarks></remarks>
    Public Dt_At_Data As DataTable '打卡表
    ''' <summary>
    ''' 请假表
    ''' </summary>
    ''' <remarks></remarks>
    Public Dt_At_Leave As DataTable '请假表

    Public Dt_Attendance_Data As DataTable '考勤表

    Public Dt_Shift As DataTable '班次表

    Public Dt_Real_Shift As DataTable '实际排班模板

    Public Dt_Personal_Shift As DataTable '特殊排班

    Protected Sub Me_Refresh()

        Dim DL As List(Of DataTable) = Dao.Attendance_DateGeList(StartDate, TB_Employee_No.TextBox.Tag)
        If DL Is Nothing Then
            ShowErrMsg("加载数据失败!", True)
            Exit Sub
        End If
        Dt_At_Data = DL(0)
        Dt_Attendance_Data = DL(1)
        Dt_At_Leave = DL(2)
        Dt_Shift = DL(3)
        Set_AT_Shifts()


    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = Dt_Attendance_Data.Clone
        For i As Integer = 1 To MDays
            Dim Dr As DataRow = dt.NewRow

            dt.Rows.Add(Dr)
            Dim U As UserDay = FP_Month.Controls("UserDay" & i)
            Dr("User_Date") = U.User_Date
            Dr("User_ID") = TB_Employee_No.TextBox.Tag
            Dr("Up_Time") = U.Up_Time
            Dr("Down_Time") = U.Down_Time
            Dr("CD") = U.CD
            Dr("ZT") = U.ZT
            Dr("QQ") = U.QQ
            Dr("XX") = U.XX
            Dr("JB") = 0
            Dr("BC") = U.BC
            Dr("Shift_Line") = U.Shift_Line
            Dr("CQ") = U.CQ
            Dr("Is_Auto") = U.Is_Auto
            Dr("Remark") = U.Remark
            Dr("Remark_Mx") = U.Remark_Mx
            Dr("IsLock") = False
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            'TB_SD_Cause.Text = IsNull(dr("SD_Cause"), "")
            'TB_Employee_ID.Tag = dr("Employee_ID")
            'TB_Card.Text = IsNull(dr("Card"), "")
            'TB_Employee_Name.Text = IsNull(dr("Employee_Name"), "")
            'TB_Employee_ID.Text = IsNull(dr("Employee_No"), "")
            ''dr("Employee_Date") = New Date(d.Year, d.Month, d.Day, DP_SignTime.Value.Hour, DP_SignTime.Value.Minute, DP_SignTime.Value.Second)
            'DP_StartDate.Value = dr("Employee_Date")
            'DP_EndDate.Value = dr("Employee_Date")
            'DP_SignTime.Value = dr("Employee_Date")

            'dr("SD_Date") = GetDate()
            ' dr("SD_User") = PClass.PClass.User_Name
            ' dr("IsHandle") = 1
        End If

    End Sub


#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then ShowConfirm("是否保存签卡记录 [" & TB_Employee_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()

        Dim R As MsgReturn
        R = Dao.Attendance_Data_Save(GetForm(), StartDate, TB_Employee_No.TextBox.Tag)

        If R.IsOk Then
            LastForm.ReturnId = TB_Employee_No.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        'If TB_Employee_ID.Tag Is Nothing OrElse TB_Employee_ID.Text = "" OrElse TB_Employee_Name.Text = "" Then
        '    ShowErrMsg("请选择一个员工！", AddressOf TB_Employee_ID.Focus)
        '    Return False
        'End If


        'If TB_Card.Text = "" Then
        '    ShowErrMsg("卡号不能为空", AddressOf TB_Card.Focus)
        '    Return False
        'End If

        'If TB_SD_Cause.Text = "" Then
        '    ShowErrMsg("签卡原因不能为空", AddressOf TB_SD_Cause.Focus)
        '    Return False
        'End If




        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowConfirm("是否删除签卡记录 [" & TB_Employee_Name.Text & "]?", AddressOf DelSignCard)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelSignCard()
        Dim msg As MsgReturn = Dao.SignCard_Del(dtSignCard.Rows(0)("SD_ID"), dtSignCard.Rows(0)("Card"), dtSignCard.Rows(0)("Employee_Date"))
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "控件点击"
    Dim ClickUserDateList As New List(Of Integer)

    Public Sub UserDayClick(ByVal LU As UserDay, ByVal Key As Keys)
        If Key = Keys.Shift Then
            If ClickUserDateList.Count > 0 Then
                Dim E As Integer = ClickUserDateList(ClickUserDateList.Count - 1)
                If E < LU.NowDay Then '如果当前选择 大于 最后一个
                    If ClickUserDateList.Count <> 1 Then '如果当前不止一个会将回来的删除
                        For i As Integer = ClickUserDateList.IndexOf(E) - 1 To 0 Step -1
                            Dim U As UserDay = FP_Month.Controls("UserDay" & ClickUserDateList(i))
                            ClickUserDateList.RemoveAt(i)
                            U.IsSel = False
                            U.ShowSelColor()
                        Next
                    End If
                    For i As Integer = E + 1 To LU.NowDay
                        Dim U As UserDay = FP_Month.Controls("UserDay" & i)
                        ClickUserDateList.Add(i)
                        U.IsSel = True
                        U.ShowSelColor()
                    Next
                ElseIf E = LU.NowDay Then '如果当前选择 等于 最后一个
                    For i As Integer = ClickUserDateList.IndexOf(E) - 1 To 0 Step -1
                        Dim U As UserDay = FP_Month.Controls("UserDay" & ClickUserDateList(i))
                        ClickUserDateList.RemoveAt(i)
                        U.IsSel = False
                        U.ShowSelColor()
                    Next
                Else
                    Dim S As Integer = ClickUserDateList(0)
                    If S = LU.NowDay Then '如果当前选择 等于 第一个
                        For i As Integer = ClickUserDateList.Count - 1 To 1 Step -1
                            Dim U As UserDay = FP_Month.Controls("UserDay" & ClickUserDateList(i))
                            ClickUserDateList.RemoveAt(i)
                            U.IsSel = False
                            U.ShowSelColor()
                        Next
                    ElseIf S > LU.NowDay Then '如果当前选择 小于 第一个
                        If ClickUserDateList.Count <> 1 Then '如果当前不止一个会将回来的删除
                            For i As Integer = ClickUserDateList.Count - 1 To 1 Step -1
                                Dim U As UserDay = FP_Month.Controls("UserDay" & ClickUserDateList(i))
                                ClickUserDateList.RemoveAt(i)
                                U.IsSel = False
                                U.ShowSelColor()
                            Next
                        End If
                        For i As Integer = LU.NowDay To S - 1
                            Dim U As UserDay = FP_Month.Controls("UserDay" & i)
                            ClickUserDateList.Add(i)
                            U.IsSel = True
                            U.ShowSelColor()
                        Next

                    Else '如果当前选择 大于 第一个 而且小于最后一个
                        For i As Integer = ClickUserDateList.IndexOf(E) To ClickUserDateList.IndexOf(LU.NowDay) + 1 Step -1
                            Dim U As UserDay = FP_Month.Controls("UserDay" & ClickUserDateList(i))
                            ClickUserDateList.RemoveAt(i)
                            U.IsSel = False
                            U.ShowSelColor()
                        Next
                    End If
                End If
                ClickUserDateList.Sort()
            Else '第一次点击
                ClickUserDateList.Add(LU.NowDay)
                LU.IsSel = True
                LU.ShowSelColor()
            End If
        ElseIf Key = Keys.Control Then
            ClickUserDateList.Add(LU.NowDay)
            LU.IsSel = True
            LU.ShowSelColor()
            ClickUserDateList.Sort()
        Else
            For i As Integer = ClickUserDateList.Count - 1 To 0 Step -1
                Dim U As UserDay = FP_Month.Controls("UserDay" & ClickUserDateList(i))
                ClickUserDateList.RemoveAt(i)
                U.IsSel = False
                U.ShowSelColor()
            Next
        End If
    End Sub


    Public IsChange As Boolean = False
    Public Sub ComboxSel(ByVal U As UserDay)
        If IsChange = False Then
            IsChange = True
            For Each Index As Integer In ClickUserDateList
                Dim SU As UserDay = FP_Month.Controls("UserDay" & Index)
                SU.ComboBox_Data.SelectedValue = U.ComboBox_Data.SelectedValue
            Next
            IsChange = False
        End If
    End Sub
#End Region




End Class


Partial Class Dao

    Private Const SQL_Attendance_Data_Get As String = "select * from T15610_Attendance_Data with(index(PK_T15610_Attendance_Data)) where User_Date between @StartDate and @EndDate and User_ID=@Employee_Id"

    Public Shared Function Attendance_Data_Get(ByVal StartDate As Date, ByVal Employee_Id As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("StartDate", StartDate)
        P.Add("EndDate", StartDate.AddMonths(1).AddMilliseconds(-1))
        P.Add("Employee_Id", Employee_Id)
        Dim R As DtReturnMsg = SqlStrToDt(SQL_Attendance_Data_Get, P)
        Return R
    End Function



    Public Shared Function At_Data_Get(ByVal StartDate As Date, ByVal Employee_Id As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("StartDate", StartDate)
        P.Add("EndDate", StartDate.AddMonths(1).AddMilliseconds(-1))
        P.Add("Employee_Id", Employee_Id)
        Dim R As DtReturnMsg = SqlStrToDt("select Card_ID,Card_Date from T15502_At_Data with(index(IX_T15502_At_Data)) where Card_Date between @StartDate and @EndDate and User_ID=@Employee_Id", P)

        Return R
    End Function


    ''' <summary>
    ''' 添加签卡记录
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Attendance_Data_Save(ByVal dtSource As DataTable, ByVal StartDate As Date, ByVal Employee_Id As Integer) As MsgReturn

    Dim msg As New DtListReturnMsg
    Dim R As New MsgReturn
    Dim sqlMap As New Dictionary(Of String, String)
    Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("StartDate", StartDate)
        paraMap.Add("EndDate", StartDate.AddMonths(1).AddMilliseconds(-1))
        paraMap.Add("Employee_Id", Employee_Id)
        Try
            sqlMap.Add("Attendance_Data", SQL_Attendance_Data_Get)
            msg = SqlStrToDt(sqlMap, paraMap)
            DvToDt(dtSource, msg.DtList("Attendance_Data"), New List(Of String))
            DtToUpDate(msg)
            R.Msg = "考勤记录保存成功!"
            R.IsOk = True
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = ex.Message
            Return R
        End Try
    End Function



    Public Shared Function Attendance_DateGeList(ByVal StartDate As Date, ByVal Employee_Id As Integer) As List(Of DataTable)
        Dim P As New Dictionary(Of String, Object)
        P.Add("StartDate", StartDate)
        P.Add("EndDate", StartDate.AddMonths(1).AddMilliseconds(-1))
        P.Add("Employee_Id", Employee_Id)
        Dim DL As List(Of DataTable)
        Dim SQL As New List(Of String)
        '   Dao.Shift_GetEmployeeShifts()
        SQL.Add("select Card_ID,Card_Date from T15502_At_Data with(index(IX_T15502_At_Data)) where Card_Date between @StartDate and @EndDate and User_ID=@Employee_Id")
        SQL.Add(SQL_Attendance_Data_Get)
        SQL.Add(Dao.SQL_Leave_GetAll & " with(index(IX_AT_Leave)) where Employee_Date between @StartDate and @EndDate and Employee_Id=@Employee_Id")
        SQL.Add(Dao.SQL_Shift_GetEmployeeShifts)
        Try
            DL = SqlStrToDtList(SQL, P)
            Return DL
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class