Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15531_AT_Leave_Msg
    Shadows Bill_ID As Integer = 0
    Dim dtLeave As DataTable
    Dim isloaded As Boolean = False
    Dim ismodify As Boolean = False
    Dim dpstart As Date
    Dim dpend As Date


    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = 0
    End Sub

    Public Sub New(ByVal jID As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = jID

        Me.Mode = Mode

    End Sub

    Public Sub New(ByVal jID As Integer, ByVal dpstart As DateTime, ByVal dpend As DateTime, ByVal eid As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = jID
        Me.dpstart = dpstart
        Me.dpend = dpend
        CB_Employee.IDAsInt = eid
        CB_Employee.Text = CB_Employee.GetByTextBoxTag
        Me.Mode = Mode

    End Sub



    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15530
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Save)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try

                SendKeys.SendWait("{TAB}")

            Catch ex As Exception
            End Try
        End If
    End Sub

   

    


#Region "表单信息"
    ''' <summary>
    ''' 获取新增日期
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetDate() As DataTable
        Dim dt As DataTable
        dt = dtLeave

        Dim dr As DataRow
        'If Mode = Mode_Enum.Add Then                
        dr = dt.NewRow
        dr("LE_Cause") = TB_Le_Cause.Text
        dr("LE_User") = PClass.PClass.User_Name
        dr("Employee_ID") = TB_Employee_No.Tag
        dr("Employee_No") = TB_Employee_No.Text
        dr("Employee_Name") = TB_Employee_Name.Text
        dr("IS_CQ") = CB_QC.Checked
        dr("IsDay") = RB_Day.Checked
        If RB_Day.Checked Then
            dr("Le_StartDate") = DTP_Start.Value.Date
            dr("Le_EndDate") = DTP_End.Value.Date
        Else
            dr("Le_StartDate") = CDate(DTP_Day.Value.ToString("yyyy-MM-dd") & " " & DTP_Start_time.Value.ToString("HH:mm"))
            dr("Le_EndDate") = CDate(DTP_Day.Value.ToString("yyyy-MM-dd") & " " & DTP_End_Time.Value.ToString("HH:mm"))
        End If
        dt.Rows.Add(dr)
        'Else
        '    dr = dt.NewRow

        '    '   dr("LE_Cause") = TB_LE_Cause.Text
        '    'dr("Employee_ID") = TB_Employee_ID.Tag
        '    'dr("Card") = TB_Card.Text
        '    'dr("Employee_Name") = TB_Employee_Name.Text
        '    'dr("Employee_No") = TB_Employee_ID.Text
        '    'dr("Employee_Date") = DP_StartDate.Value
        '    dr("LE_Date") = GetDate()
        '    dr("LE_User") = PClass.PClass.User_Name
        '    'dr("IS_CQ") = CB_IS_CQ.Checked
        '    dr("IsHandle") = 1
        '    dt.Rows.Add(dr)
        'End If

        Return dt
    End Function

    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>

    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtLeave.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            Dim dr As DataRow
            'If Mode = Mode_Enum.Add Then                
            dr = dt.NewRow
            dr("LE_Cause") = Fg1.Item(i, "LE_Cause")
            dr("LE_User") = PClass.PClass.User_Name
            dr("Employee_ID") = TB_Employee_No.Tag
            dr("Employee_No") = TB_Employee_No.Text
            dr("Employee_Name") = TB_Employee_Name.Text
            dr("IS_CQ") = Fg1.Item(i, "IS_CQ")
            dr("IsDay") = Fg1.Item(i, "IsDay")
            dr("Le_StartDate") = Fg1.Item(i, "Le_StartDate")
            dr("Le_EndDate") = Fg1.Item(i, "Le_EndDate")
            dt.Rows.Add(dr)
        Next
        'Else
        '    dr = dt.NewRow

        '    '   dr("LE_Cause") = TB_LE_Cause.Text
        '    'dr("Employee_ID") = TB_Employee_ID.Tag
        '    'dr("Card") = TB_Card.Text
        '    'dr("Employee_Name") = TB_Employee_Name.Text
        '    'dr("Employee_No") = TB_Employee_ID.Text
        '    'dr("Employee_Date") = DP_StartDate.Value
        '    dr("LE_Date") = GetDate()
        '    dr("LE_User") = PClass.PClass.User_Name
        '    'dr("IS_CQ") = CB_IS_CQ.Checked
        '    dr("IsHandle") = 1
        '    dt.Rows.Add(dr)
        'End If

        Return dt
    End Function


    Private Sub F15521_AT_Leave_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        'If dtLeave IsNot Nothing AndAlso dtLeave.Rows.Count > 0 Then
        '    Me.LastForm.ReturnId = dtLeave.Rows(0)("LE_Id")
        'End If
        'If ismodify = True Then
        '    ShowConfirm("数据未保存", )
        '    e.Cancel = True
        'End If
    End Sub


    Private Sub F15501_At_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        DP_Start.Value = New DateTime(GetTime.Year, GetTime.Month, 1)
        DP_End.Value = New DateTime(GetTime.Year, GetTime.Month, 1).AddMonths(1).AddDays(-1)
        DTP_Day.Value = GetTime()
        DTP_Start_time.Value = GetTime()
        DTP_End_Time.Value = GetTime()
        RB_Day.Checked = True
        Me.Title = Ch_Name
        Fg1.Rows.Count = 1
        'Fg1.CanEditing = True
        Me_Refresh()
        isloaded = True
    End Sub

    Protected Sub Me_Refresh()

        If Mode = Mode_Enum.Modify Then

            DP_Start.Value = dpstart
            DP_End.Value = dpend
            StartDate = DP_Start.Value
            EndDate = DP_End.Value

            TB_Employee_No.Tag = CB_Employee.IDAsInt
            TB_Employee_No.Text = CB_Employee.NoValue
            TB_Employee_Name.Text = CB_Employee.GetByTextBoxTag
            'TB_Le_User.Text = PClass.PClass.User_Name
            Btn_Inser.Visible = False
            Dim msg As DtReturnMsg = Dao.Leave_GetByOption(GetFindOtions)
            If msg.IsOk Then
                dtLeave = msg.Dt
                Fg1.DtToFG(msg.Dt)
                Fg1.RowSetForce("LE_ID", CLng(Bill_ID))
            End If
            TB_Le_User.Text = msg.Dt.Rows(0)("Le_User")

        Else

            Dim msg As DtReturnMsg = Dao.Leave_GetByOption(GetFindOtions)
            If msg.IsOk Then
                dtLeave = msg.Dt
                Fg1.DtToFG(msg.Dt)

            End If
        End If

    End Sub

















    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            'TB_LE_Cause.Text = IsNull(dr("LE_Cause"), "")
            'TB_Employee_ID.Tag = dr("Employee_ID")
            'TB_Card.Text = IsNull(dr("Card"), "")
            'TB_Employee_Name.Text = IsNull(dr("Employee_Name"), "")
            'TB_Employee_ID.Text = IsNull(dr("Employee_No"), "")

            '' CB_IS_CQ.Checked = IsNull(dr("IS_CQ"), False)

            'DP_StartDate.Value = IsNull(dr("Employee_Date"), Today)
            'DP_EndDate.Value = IsNull(dr("Employee_Date"), Today)

        End If

    End Sub


#End Region


#Region "工具栏按钮"

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        If CheckForm() Then ShowConfirm("是否保存请假记录 [" & TB_Employee_Name.Text & "] 的修改?", AddressOf Save)
    End Sub
  

    Protected Sub Save()

        Dim R As MsgReturn

        'If Me.Mode = Mode_Enum.Add Then
        '    R = Dao.Leave_Add(GetForm())
        'Else
        R = Dao.Leave_Save(GetForm(), StartDate, EndDate, TB_Employee_No.Tag)
        'End If
        If R.IsOk Then
            ismodify = False
            ShowOk(R.Msg)
        End If
      


    End Sub

    Private Sub Btn_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modify.Click
        If TB_Employee_Name.Text = "" AndAlso TB_Employee_No.Text = "" Then
            Exit Sub
        End If

        If DTP_Start.Value > DTP_End.Value Then
            Dim Cache As DateTime = DTP_Start.Value
            DTP_Start.Value = DTP_End.Value
            DTP_End.Value = Cache
        End If



        Dim StartTime As DateTime
        Dim EndTime As DateTime
        Dim isday As Boolean
        If RB_Day.Checked Then
            StartTime = DTP_Start.Value.Date
            EndTime = DTP_End.Value.Date
            isday = True
        Else
            If DTP_Start_time.Value > DTP_End_Time.Value Then
                StartTime = DTP_Day.Value.Date & " " & DTP_Start_time.Value.ToString("HH:mm")
                EndTime = DTP_Day.Value.Date.AddDays(1) & " " & DTP_End_Time.Value.ToString("HH:mm")
            Else
                StartTime = DTP_Day.Value.Date & " " & DTP_Start_time.Value.ToString("HH:mm")
                EndTime = DTP_Day.Value.Date & " " & DTP_End_Time.Value.ToString("HH:mm")
            End If
            isday = False
        End If
        Dim row As Integer = RetrunRowindex(StartTime, EndTime, True)
        If row <> 0 Then
            ShowErrMsg("请假时间与第" & row & "行有冲突请检查")
        Else
            Fg1.Item(Fg1.RowSel, "Le_StartDate") = StartTime
            Fg1.Item(Fg1.RowSel, "Le_EndDate") = EndTime
            Fg1.Item(Fg1.RowSel, "IS_CQ") = CB_QC.Checked
            Fg1.Item(Fg1.RowSel, "Le_Cause") = TB_Le_Cause.Text
            ismodify = True
        End If
    End Sub

    Protected Function CheckForm() As Boolean
        If TB_Employee_No.Tag Is Nothing OrElse TB_Employee_No.Text = "" OrElse TB_Employee_Name.Text = "" Then
            ShowErrMsg("请选择一个员工！", AddressOf TB_Employee_No.Focus)
            Return False
        End If

        Return True
    End Function
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        If CB_Employee.IDAsInt = 0 Then
            ShowErrMsg("请选择一个员工")
            Exit Sub
        End If

        If ismodify = True Then
            ShowConfirm("数据未保存是否继续搜索", AddressOf EmployeeRefresh)
            Exit Sub
        Else
            EmployeeRefresh()
        End If
    End Sub



    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除请假记录 [" & TB_Employee_Name.Text & "]?", AddressOf DelLeave)
    End Sub
    ''' <summary>
    ''' 删除清假记录
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelLeave()
        Fg1.RemoveRow()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub TSP_Employee_No_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim R As DtReturnMsg
        'R = Dao.Leave_GetByEmployee_No(TSP_Employee_No.Text)
        If R.IsOk Then
            'TSP_Employee_No.Tag = R.Dt.Rows(0)("ID")
            'TSP_Employee_Name.Text = R.Dt.Rows(0)("Employee_Name")
            TB_Employee_No.Text = R.Dt.Rows(0)("Employee_No")
            TB_Employee_Name.Text = R.Dt.Rows(0)("Employee_Name")
            TB_Employee_No.Tag = R.Dt.Rows(0)("ID")

        End If
    End Sub

    Private Sub Btn_Inser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Inser.Click

        If TB_Employee_Name.Text = "" AndAlso TB_Employee_No.Text = "" Then
            ShowErrMsg("请选择一个员工", AddressOf CB_Employee.Focus)
            Exit Sub
        End If
        If DTP_Start.Value > DTP_End.Value Then
            Dim Cache As DateTime = DTP_Start.Value
            DTP_Start.Value = DTP_End.Value
            DTP_End.Value = Cache
        End If


        Dim StartTime As DateTime
        Dim EndTime As DateTime
        Dim isday As Boolean
        If RB_Day.Checked Then
            StartTime = DTP_Start.Value.Date
            EndTime = DTP_End.Value.Date
            isday = True
        Else
            If DTP_Start_time.Value > DTP_End_Time.Value Then
                StartTime = DTP_Day.Value.Date & " " & DTP_Start_time.Value.ToString("HH:mm")
                EndTime = DTP_Day.Value.Date.AddDays(1) & " " & DTP_End_Time.Value.ToString("HH:mm")
            Else
                StartTime = DTP_Day.Value.Date & " " & DTP_Start_time.Value.ToString("HH:mm")
                EndTime = DTP_Day.Value.Date & " " & DTP_End_Time.Value.ToString("HH:mm")
            End If
            isday = False
        End If
        Dim row As Integer = RetrunRowindex(StartTime, EndTime)
        If row <> 0 Then
            ShowErrMsg("请假时间与第" & row & "行有冲突请检查")

        Else
            GetDate()
            Fg1.ReAddIndex()
            ismodify = True
        End If


    End Sub
    Private Function RetrunRowindex(ByVal StartTime As DateTime, ByVal endtime As DateTime, Optional ByVal modify As Boolean = False) As Integer

        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Fg1.RowSel = i AndAlso modify Then
                Continue For
            End If

            If Fg1.Item(i, "isDay") <> RB_Day.Checked Then
                If RB_Day.Checked = True AndAlso Fg1.Item(i, "isDay") = False Then
                    Dim Fgtime As DateTime = Fg1(i, "Le_StartDate")
                    If Day_Time(Fgtime.Date, StartTime, endtime) = False Then
                        Return i
                    End If
                ElseIf RB_Day.Checked = False AndAlso Fg1.Item(i, "isDay") = True Then
                    If Day_Time(DTP_Day.Value.Date, Fg1(i, "Le_StartDate"), Fg1.Item(i, "Le_EndDate")) = False Then
                        Return i
                    End If
                End If
                Continue For
            Else
                If isSame(StartTime, endtime, Fg1.Item(i, "Le_StartDate"), Fg1.Item(i, "Le_EndDate")) = False Then
                    Return i
                End If
            End If
        Next
        Return 0
    End Function


    '日期与时间对比
    Private Function Day_Time(ByVal day1 As DateTime, ByVal day2 As DateTime, ByVal day3 As DateTime) As Boolean

        If day1 >= day2 AndAlso day1 <= day3 Then

            Return False
        Else

            Return True
        End If


    End Function


    '相同对比'

    Private Function isSame(ByVal Sday As DateTime, ByVal Eday As DateTime, ByVal FSday As DateTime, ByVal FEday As DateTime) As Boolean
        If Sday >= FSday AndAlso Sday <= FEday Then
            Return False
        ElseIf Eday >= FSday AndAlso Eday <= FEday Then
            Return False
        ElseIf Sday <= FSday AndAlso Eday >= FEday Then
            Return False
        Else
            Return True
        End If
    End Function



#End Region




    Dim StartDate As DateTime
    Dim EndDate As DateTime


    ''' <summary>
    ''' 搜索时刷新员工数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EmployeeRefresh()
        Me_Refresh()
        TB_Employee_No.Tag = CB_Employee.IDAsInt
        TB_Employee_No.Text = CB_Employee.NoValue
        TB_Employee_Name.Text = CB_Employee.GetByTextBoxTag
        TB_Le_User.Text = PClass.PClass.User_Name
        StartDate = DP_Start.Value
        EndDate = DP_End.Value

    End Sub

    ''' <summary>
    ''' 搜索数据获取
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "Le_StartDate"
        fo.Value = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_LessOrEqual
        oList.FoList.Add(fo)
        fo = New FindOption
        fo.DB_Field = "Le_EndDate"
        fo.Value = DP_Start.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
        oList.FoList.Add(fo)


            fo = New FindOption
            fo.DB_Field = "Employee_ID"
            fo.Value = IsNothing(CB_Employee.IDValue, "")
            fo.Field_Operator = Enum_Operator.Operator_Equal
        oList.FoList.Add(fo)
      

        Return oList
    End Function

    ''' <summary>
    ''' 调用部门选择窗体
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ShowDeptSel()
        Dim F As PClass.BaseForm = LoadFormIDToChild(99004, Me)
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetDept
        VF.Show()
    End Sub

    Dim DeptID As String = ""
    Dim DeptName As String = ""



#Region "表单控件事件"
    Protected Sub SetDept()
        If Not Me.ReturnObj Is Nothing AndAlso Me.ReturnId <> "" Then
            Cmd_ChooseDept.Checked = True
            Me.DeptID = Me.ReturnId
            Me.DeptName = Me.ReturnObj
            Cmd_ChooseDept.Text = DeptName

            CB_Employee.SearchType = cSearchType.ENum_SearchType.Department
            CB_Employee.SearchID = DeptID
            Me_Refresh()
        Else
            CB_Employee.SearchID = ""
            CB_Employee.SearchType = cSearchType.ENum_SearchType.ALL
        End If
        Me.ReturnObj = Nothing
    End Sub


    ''' <summary>
    '''选择部门事件
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub Cmd_ChooseType_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_ChooseDept.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Cmd_ChooseDept.Text = "选择部门"
            DeptID = ""
            DeptName = ""
            Cmd_ChooseDept.Checked = False
            CB_Employee.SearchID = ""
            CB_Employee.SearchType = cSearchType.ENum_SearchType.ALL

            Me_Refresh()
        Else
            ShowDeptSel()
        End If
    End Sub


    ''' <summary>
    '''选择按时请假
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RB_Time_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Time.CheckedChanged
        Showtimewindow(RB_Day.Checked)
    End Sub

    ''' <summary>
    ''' 显示按时或按日
    ''' </summary>
    ''' <param name="Rb"></param>
    ''' <remarks></remarks>
    Private Sub Showtimewindow(ByVal Rb As Boolean)
        PL_day.Visible = Rb
        PL_time.Visible = Not Rb

    End Sub

    ''' <summary>
    '''选择按日请假
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RB_Day_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Day.CheckedChanged
        Showtimewindow(RB_Day.Checked)
    End Sub

    'Private Sub Employee_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles Employee_List1.Col_Sel
    '    If isloaded AndAlso ID > 0 Then

    '        'TB_Card.Text = Dao.User_GetCard(ID)
    '    End If


    'End Sub




#End Region
#Region "FG1事件"
    Private Sub Fg1_SelectRowChange(ByVal Row As System.Int32) Handles Fg1.SelectRowChange
        If Fg1.Item(Fg1.RowSel, "IsDay") = True Then
            RB_Day.Checked = True
            RB_Time.Checked = False
            DTP_Start.Value = Fg1.Item(Fg1.RowSel, "Le_StartDate")
            DTP_End.Value = Fg1.Item(Fg1.RowSel, "Le_EndDate")
            CB_QC.Checked = Fg1.Item(Fg1.RowSel, "IS_CQ")

        Else
            RB_Day.Checked = False
            RB_Time.Checked = True
            CB_QC.Checked = Fg1.Item(Fg1.RowSel, "IS_CQ")
            DTP_Day.Value = Fg1.Item(Fg1.RowSel, "Le_StartDate")
            DTP_Start_time.Value = Fg1.Item(Fg1.RowSel, "Le_StartDate")
            DTP_End_Time.Value = Fg1.Item(Fg1.RowSel, "Le_EndDate")
        End If
    End Sub
#End Region
End Class


Partial Class Dao
#Region "常量，SQL"

    ''' <summary>
    ''' 按编号查询请假记录信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Leave_GetAll = " select * from T15530_AT_Leave"
    ''' <summary>
    ''' 按编号查询请假记录信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Leave_GetByID = " select * from T15530_AT_Leave where LE_Id=@LE_Id "
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Leave_DelAtByid = "delete from T15530_AT_Leave where LE_Id=@LE_Id  "

    ''' <summary>
    ''' 按日期查询请假记录信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Leave_GetbyLe_StartDate = "select * from T15530_AT_Leave where Le_StartDate <=  @Le_StartDate2 and Le_EndDate>=@Le_StartDate1 and  Employee_ID=@Employee_ID "


    ''' <summary>
    ''' 查询员工资料
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_Leave_GetEmployee = "Select ID,Employee_No,Employee_Name from T15001_Employee where Employee_No=@Employee_No  "




#End Region
#Region "查询条件"

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Leave_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        
        fo = New FindOption
        fo.Field = "员工编号"
        fo.DB_Field = "Employee_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "员工名称"
        fo.DB_Field = "Employee_Name"
        foList.Add(fo)

        Return foList
    End Function
#End Region
#Region "查询"


    ''' <summary>
    '''查询所有次信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Leave_GetByOption(ByVal oList As OptionList) As DtReturnMsg


        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Leave_GetAll)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" order by Le_StartDate")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 按编号查询请假记录信息
    ''' </summary>
    ''' <param name="_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Leave_GetByID(ByVal _id As Integer) As DtReturnMsg
        Dim rmsg As DtReturnMsg
        rmsg = PClass.PClass.SqlStrToDt(SQL_Leave_GetByID, "@LE_Id", _id)
        Return rmsg
    End Function

    ''' <summary>
    ''' 按用户编号获取用户名
    ''' </summary>
    ''' <param name="Employee_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Leave_GetByEmployee_No(ByVal Employee_No As String) As DtReturnMsg
        Dim rmsg As DtReturnMsg
        rmsg = PClass.PClass.SqlStrToDt(SQL_Leave_GetEmployee, "@Employee_No", Employee_No)
        Return rmsg
    End Function




#End Region

#Region "修改"

    '''' <summary>
    '''' 添加请假记录
    '''' </summary>
    '''' <param name="dtSource"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function Leave_Add(ByVal dtSource As DataTable) As MsgReturn
    '    Dim msg As New DtListReturnMsg
    '    Dim R As New MsgReturn
    '    Dim sqlMap As New Dictionary(Of String, String)
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    '  Dim PurchaseId As String = dtTable.Rows(0)("LE_Id")
    '    Dim IsInsert As Boolean = False
    '    '   paraMap.Add("LE_Id", PurchaseId)
    '    Try
    '        sqlMap.Add("Leave", "select top 0 * from T15530_AT_Leave")
    '        sqlMap.Add("Data", " select top 0 * from T15502_At_Data ")

    '        msg = SqlStrToDt(sqlMap, paraMap)
    '        If msg.DtList("Leave").Rows.Count = 0 Then
    '            DvToDt(dtSource, msg.DtList("Leave"), New List(Of String), True)
    '            Dim dtData As DataTable = msg.DtList("Data").Clone
    '            Dim newDr As DataRow
    '            For Each dr As DataRow In dtSource.Rows
    '                newDr = dtData.NewRow
    '                newDr("Card_ID") = dr("Card")
    '                newDr("Card_Date") = dr("Employee_Date")
    '                newDr("AT_ID") = 999
    '                newDr("User_ID") = dr("Employee_ID")
    '                newDr("Type") = "手工请假"
    '                newDr("IsHandle") = 1
    '                dtData.Rows.Add(newDr)
    '            Next
    '            DvToDt(dtData, msg.DtList("Data"), New List(Of String), True)

    '            DtToUpDate(msg)
    '            R.Msg = "请假记录[" & dtSource.Rows(0)("Employee_Name") & "]添加成功!"
    '            R.IsOk = True
    '        Else
    '            R.IsOk = False
    '            R.Msg = "请假记录[" & dtSource.Rows(0)("Employee_Name") & "]已经存在!请双击编号文本框,获取新编号!"
    '        End If
    '        Return R
    '    Catch ex As Exception
    '        R.IsOk = False
    '        R.Msg = "请假记录[" & dtSource.Rows(0)("Employee_Name") & "]添加错误!"
    '        DebugToLog(ex)
    '        Return R
    '    Finally
    '    End Try
    'End Function

    '''' <summary>
    '''' 添加请假记录
    '''' </summary>
    '''' <param name="dtSource"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function Leave_Save(ByVal dtSource As DataTable, ByVal _dtLeave As DataTable) As MsgReturn
    '    Dim msg As New DtListReturnMsg
    '    Dim R As New MsgReturn
    '    Dim sqlMap As New Dictionary(Of String, String)
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim LE_Id As String = _dtLeave.Rows(0)("LE_Id")
    '    Dim IsInsert As Boolean = False
    '    paraMap.Add("LE_Id", LE_Id)
    '    paraMap.Add("Card_ID", _dtLeave.Rows(0)("Card"))
    '    paraMap.Add("Card_Date", _dtLeave.Rows(0)("Employee_Date"))
    '    Try
    '        sqlMap.Add("Leave", SQL_Leave_GetByID)
    '        sqlMap.Add("Data", " select top 1 * from T15502_At_Data where Card_ID=@Card_ID and Card_Date=@Card_Date and AT_ID=999")

    '        msg = SqlStrToDt(sqlMap, paraMap)
    '        If msg.DtList("Leave").Rows.Count = 1 Then
    '            DvUpdateToDt(dtSource, msg.DtList("Leave"), New List(Of String))
    '            Dim dtData As DataTable = msg.DtList("Data").Clone
    '            Dim newDr As DataRow
    '            For Each dr As DataRow In dtSource.Rows
    '                newDr = dtData.NewRow
    '                newDr("Card_ID") = dr("Card")
    '                newDr("Card_Date") = dr("Employee_Date")
    '                newDr("AT_ID") = 999
    '                newDr("User_ID") = dr("Employee_ID")
    '                newDr("Type") = "手工请假"
    '                newDr("IsHandle") = 1
    '                dtData.Rows.Add(newDr)
    '            Next
    '            DvUpdateToDt(dtData, msg.DtList("Data"), New List(Of String))

    '            DtToUpDate(msg)
    '            R.Msg = "请假记录[" & dtSource.Rows(0)("Employee_Name") & "]添加成功!"
    '            R.IsOk = True
    '        Else
    '            R.IsOk = False
    '            R.Msg = "请假记录[" & dtSource.Rows(0)("Employee_Name") & "]不存在!"
    '        End If
    '        Return R
    '    Catch ex As Exception
    '        R.IsOk = False
    '        R.Msg = "请假记录[" & dtSource.Rows(0)("Employee_Name") & "]添加错误!"
    '        DebugToLog(ex)
    '        Return R
    '    Finally
    '    End Try
    'End Function

    ''' <summary>
    ''' 添加请假记录
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Leave_Add(ByVal dtSource As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim msg As New MsgReturn
        Dim sql As String
        '   Dim AtId As String = dtSource.Rows(0)("LE_Id")
        Try

            sql = "select top 0 * from T15530_AT_Leave"
            dt = SqlStrToDt(sql, Cnn, Da).Dt
            If dt.Rows.Count = 0 Then


                DvToDt(dtSource, dt, New List(Of String), True)
                DtToUpDate(dt, Cnn, Da)
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "请假记录" & dtSource.Rows(0)("Employee_Name") & "已经存在"
            End If

            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "请假记录" & dtSource.Rows(0)("Employee_Name") & "添加错误"
            DebugToLog(ex)
            Return msg
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try

    End Function

    ''' <summary>
    ''' 修改请假记录信息
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Leave_Save(ByVal dtSource As DataTable, ByVal startDate As DateTime, ByVal enddate As DateTime, ByVal id As String) As MsgReturn

        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim msg As New MsgReturn
        Dim sql As String
        Dim p As New Dictionary(Of String, Object)
        p.Add("Le_StartDate1", startDate)
        p.Add("Le_StartDate2", enddate)
        p.Add("Employee_ID", id)
        Try

            sql = SQL_Leave_GetbyLe_StartDate
            dt = SqlStrToDt(sql, Cnn, Da, p).Dt
            If dt.Rows.Count >= 0 Then
                DvToDt(dtSource, dt, New List(Of String))
                DtToUpDate(dt, Cnn, Da)
                msg.IsOk = True
                msg.Msg = "请假记录保存成功"
            Else
                msg.IsOk = False
                msg.Msg = "请假记录不存在"
            End If

            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "请假记录修改错误"
            DebugToLog(ex)
            Return msg
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AtId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Leave_Del(ByVal AtId As Integer) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("LE_Id", AtId)

        Return RunSQL(SQL_Leave_DelAtByid, p)
    End Function







#End Region

End Class