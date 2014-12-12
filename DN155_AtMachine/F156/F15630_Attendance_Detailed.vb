Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F15630_Attendance_Detailed
    Private WithEvents R As New R15630_Attendance_Detailed
    Dim isLoaded As Boolean = False
    Dim dtlist As DataTable
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        'Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        'Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        ID = 15630
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        '  Dim msg As DtReturnMsg = Dao.JXC_GetBillTypeList
        'If msg.IsOk Then
        '    msg.Dt.Rows.InsertAt(msg.Dt.NewRow, 0)
        '    msg.Dt.Rows(0)("BillName") = "请选择单据类型"
        '    msg.Dt.Rows(0)("BillType") = 0
        '    CB_ConditionName1.ComboBox.DisplayMember = "BillName"
        '    CB_ConditionName1.ComboBox.ValueMember = "BillType"
        '    CB_ConditionName1.ComboBox.DataSource = msg.Dt

        'End If
        Dim D As Date
        If P_F_RS_ID = "" Then
            D = GetDate()
            DP_Start.Value = D.AddDays(-1)
            Dp_End.Value = D.AddDays(-1)
        Else
            CB_Employee.IDAsInt = F_RS_ID
            CB_Employee.GetByTextBoxTag()
            CB_Employee.Text = CB_Employee.NameValue

            CB_State.Text = "全部"
            D = P_F_RS_ID4
            DP_Start.Value = D
            Dp_End.Value = D.AddMonths(1).AddDays(-1)

        End If

        Me.Title = GetBillTypeName(ID)



        MonthPicker1.Value = New Date(D.Year, D.Month, 1)
        '  DP_End.Value = DP_Start.Value.AddMonths(1).AddDays(-1)

        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        If P_F_RS_ID <> "" Then Me_Refresh()
        R.Start()
        isLoaded = True
        ' Dim T As New Threading.Thread(AddressOf Get_Goods)
        '  T.Start()
    End Sub

    Protected Sub Me_Refresh()

        Dim Dept_No As String = ""
        Dim Employee As Integer = 0
        If Me.DeptID <> "" Then
            Dept_No = Me.DeptID
        End If

      
        Employee = CB_Employee.IDAsInt

        Dim msg As DtReturnMsg = Dao.Purchase_GetByOption(GetFindOtions)
        dtlist = msg.Dt
        R.SetOption(msg.Dt)
        R.Start()
        If LastSelectNo <> -1 Then
            GR.SelRowNo = LastSelectNo
            LastSelectNo = -1
        End If

    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim D As Date = New Date(MonthPicker1.Value.Date.Year, MonthPicker1.Value.Date.Month, 1)
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
 

        If CK_Date.Checked Then
            fo = New FindOption
            fo.DB_Field = "User_Date"
            fo.Value = D
            fo.Value2 = D.AddMonths(1).AddDays(-1)
            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)
        Else
            fo = New FindOption
            fo.DB_Field = "User_Date"
            fo.Value = DP_Start.Value.Date
            fo.Value2 = Dp_End.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)
        End If



        If CB_Employee.IDAsInt <> 0 AndAlso CB_Employee.Text <> "" Then
            fo = New FindOption
            fo.DB_Field = "User_ID"
            fo.Value = CB_Employee.IDAsInt
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If DropDown_Leven.Text <> "全部等级" Then
            fo = New FindOption
            Select Case DropDown_Leven.Text
                Case Cmd_Leven1.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven1.Tag
                    fo.Field_Operator = Enum_Operator.Operator_Equal
                Case Cmd_Leven2.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven2.Tag
                    fo.Field_Operator = Enum_Operator.Operator_Equal
                Case Cmd_Leven3.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven3.Tag
                    fo.Field_Operator = Enum_Operator.Operator_Equal
                Case Cmd_Leven4.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven4.Tag
                    fo.Field_Operator = Enum_Operator.Operator_Equal
                Case Cmd_Leven5.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven5.Tag
                    fo.Field_Operator = Enum_Operator.Operator_Equal
                Case Cmd_Leven6.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven6.Tag
                    fo.Field_Operator = Enum_Operator.Operator_Equal
                Case Cmd_Leven1to3.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven1to3.Tag
                    fo.Field_Operator = Enum_Operator.Operator_LessOrEqual
                Case Cmd_Leven4to6.Text
                    fo.DB_Field = "Job_Grade"
                    fo.Value = Cmd_Leven4to6.Tag
                    fo.Field_Operator = Enum_Operator.Operator_More
                Case Else
            End Select
            oList.FoList.Add(fo)
        End If



        If Cmd_ChooseDept.Text <> "选择部门" Then
            fo = New FindOption
            fo.DB_Field = "Employee_Dept"
            fo.Value = DeptID
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If CB_State.Text <> "全部" Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Value = CB_State.Text
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        Return oList
    End Function







#Region "控件事件"
    'Private Sub Btn_ExcelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExcelOut.Click
    '    R.ExportXLS()
    'End Sub
    'Private Sub Btn_PrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PrePrint.Click
    '    R.PrintPreview()
    'End Sub
    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub

    'Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
    '    Me_Refresh()
    'End Sub
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"



    'Private Sub CB_ConditionName2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged

    'End Sub


    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me_Refresh()
    End Sub






#Region "审核反审"

    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ShowConfirm("审核" & MonthPicker1.Text & "的所有考勤卡?", AddressOf Shenhe)

    End Sub

    Sub Shenhe()
        If Dao.Attendance_Audit(MonthPicker1.Value.Date, True) Then
            ShowOk("审核成功!")
        Else
            ShowErrMsg("审核失败!")
        End If
    End Sub


    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ShowConfirm("反审" & MonthPicker1.Text & "的所有考勤卡?", AddressOf Fanshen)

    End Sub


    Sub Fanshen()
        If Dao.Attendance_Audit(MonthPicker1.Value.Date, False) Then
            ShowOk("反审成功!")
        Else
            ShowErrMsg("反审失败!")
        End If

    End Sub
#End Region



#End Region

#Region "双击行,调出单的明细"

    Dim LastSelectNo As Integer = -1
    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        'If GR.SelRowNo >= 0 Then
        '    Dim F As New F15611_Attendance_Msg()
        '    With F
        '        .Mode = Mode_Enum.Add
        '        .P_F_RS_ID = GR.GetSelRowCellText(1) 'user_id
        '        .P_F_RS_ID2 = GR.GetSelRowCellText(2) 'No
        '        .P_F_RS_ID3 = GR.GetSelRowCellText(5) '姓名
        '        .P_F_RS_ID4 = CDate(GR.GetSelRowCellText(0) & "-1") '日期
        '        .P_F_RS_ID5 = GR.GetSelRowCellText(3) & "." & GR.GetSelRowCellText(4) '部门
        '    End With
        '    F_RS_ID = ""
        '    Me.ReturnId = ""
        '    Me.ReturnObj = Nothing
        '    'GR.Visible = False
        '    Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        '    'GR.Visible = True
        '    AddHandler VF.ClosedX, AddressOf Me_Refresh
        '    LastSelectNo = GR.SelRowNo
        '    VF.Show()
        'End If
    End Sub
#End Region

#Region "选择部门"
    Dim DeptID As String = ""
    Dim DeptName As String = ""
    Protected Sub ShowDeptSel()
        Dim F As BaseForm = LoadFormIDToChild(99004, Me)
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


    Private Sub Cmd_ChooseType_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_ChooseDept.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Cmd_ChooseDept.Text = "选择部门"
            DeptID = ""
            DeptName = ""
            Cmd_ChooseDept.Checked = False
            CB_Employee.SearchID = ""
            CB_Employee.SearchType = cSearchType.ENum_SearchType.ALL


        Else
            ShowDeptSel()
        End If
    End Sub

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
#End Region


#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Dim rt As New R15630_Attendance_Detailed
        rt.SetOption(dtlist)
        rt.Start(OperatorType.Preview, True)
    End Sub

    Private Sub Cmd_Preview2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview2.Click

        Dim rt As New R15630_Attendance_Detailed
        rt.SetOption(dtlist)
        rt.Start(OperatorType.Preview, False)
      

    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Dim rt As New R15630_Attendance_Detailed
        rt.SetOption(dtlist)
        rt.Start(OperatorType.Print, False)
    End Sub



#End Region


    Private Sub Cmd_Leven1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Leven1.Click, Cmd_Leven1to3.Click, Cmd_Leven2.Click, Cmd_Leven3.Click, Cmd_Leven4.Click, Cmd_Leven4to6.Click, Cmd_Leven5.Click, Cmd_Leven6.Click, Cmd_LevenAll.Click
        DropDown_Leven.Text = sender.Text
        Me_Refresh()
    End Sub

    Private Sub MonthPicker1_ValueChange(ByVal Value As System.DateTime) Handles MonthPicker1.ValueChange
        Me_Refresh()
    End Sub

    Private Sub TS_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS_All.Click, Ts_YC.Click, Ts_ZC.Click
        CB_State.Text = sender.text
    End Sub

    Private Sub CK_Date_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CK_Date.CheckedChanged
        MonthPicker1.Visible = CK_Date.Checked

        Label_C.Visible = Not CK_Date.Checked
        Label_D.Visible = Not CK_Date.Checked
        DP_Start.Visible = Not CK_Date.Checked
        Dp_End.Visible = Not CK_Date.Checked
    End Sub


    
    
End Class

Partial Friend Class Dao

    Public Const SQL_Attendance_Date As String = "select D.*,E.Employee_Name,E.Employee_Dept,T.Dept_Name,J.Job_Grade from T15610_Attendance_Data D left join T15001_Employee E on D.User_ID=E.ID left join T15003_Job J ON E.Employee_Job=J.ID left join T15000_Department T on T.Dept_No=E.Employee_Dept "
    Public Const SQL_Attendance_Date_Orderby As String = " Order by E.Employee_Dept,User_ID,D.User_Date"
    'Public Shared Function Attendance_Audit(ByVal D As Date, ByVal IsAudit As Boolean) As Boolean
    '    Dim StartDate As Date = New Date(D.Year, D.Month, 1)
    '    Dim EndDate As Date = StartDate.AddMonths(1).AddDays(-1)
    '    Dim p As New Dictionary(Of String, Object)
    '    p.Add("StartDate", StartDate)
    '    p.Add("EndDate", EndDate)
    '    p.Add("IsAudit", IsAudit)
    '    Try
    '        Return RunSQL("Update T15610_Attendance_Data set IsLock=@IsAudit where User_Date between @StartDate and @EndDate", p).IsOk
    '    Catch ex As Exception
    '        Return False
    '    End Try

    'End Function

    ''' <summary>
    ''' 按条件获取采购单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Attendance_Date)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Attendance_Date_Orderby)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function


End Class