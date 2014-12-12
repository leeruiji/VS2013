Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F15605_PBB_Mx
    Private WithEvents R As New R15605_PBB_Mx
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()


    End Sub
    Dim SeledtNo As Integer
    Private Sub Form_Me_Load() Handles MyBase.Me_Load
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




        Dim D As Date = GetDate()
        MonthPicker1.Value = New Date(D.Year, D.Month, 1)
        '  DP_End.Value = DP_Start.Value.AddMonths(1).AddDays(-1)

        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        Me_Refresh()
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


        Dim D As Date = New Date(MonthPicker1.Value.Date.Year, MonthPicker1.Value.Date.Month, 1)
        Dim JobLeve As String = ""
        Select Case DropDown_Leven.Text
            Case Cmd_Leven1.Text
                JobLeve = Cmd_Leven1.Tag
            Case Cmd_Leven2.Text
                JobLeve = Cmd_Leven2.Tag
            Case Cmd_Leven3.Text
                JobLeve = Cmd_Leven3.Tag
            Case Cmd_Leven4.Text
                JobLeve = Cmd_Leven4.Tag
            Case Cmd_Leven5.Text
                JobLeve = Cmd_Leven5.Tag
            Case Cmd_Leven6.Text
                JobLeve = Cmd_Leven6.Tag
            Case Cmd_Leven1to3.Text
                JobLeve = Cmd_Leven1to3.Tag
            Case Cmd_Leven4to6.Text
                JobLeve = Cmd_Leven4to6.Tag
            Case Else
                JobLeve = ""
        End Select
        R.SetOption(D, D.AddMonths(1).AddDays(-1), Employee, Dept_No, JobLeve)
        R.Start()
        GR.SelRowNo = SeledtNo
    End Sub




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









#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        If GR.SelRowNo >= 0 AndAlso GR.GetSelRowCellText(6) <> "" Then
            SeledtNo = GR.SelRowNo
            Dim F As New F15606_PBB_Mx_Msg
            With F
                .Mode = Mode_Enum.Add
                .P_F_RS_ID = GR.GetSelRowCellText(6) 'Employee_ShiftMoudel'实际班次模板ID
                .P_F_RS_ID2 = GR.GetSelRowCellText(1) 'user_id
                .P_F_RS_ID3 = GR.GetSelRowCellText(5) '姓名
                .P_F_RS_ID4 = MonthPicker1.Value.ToString("yyyy-MM-dd") '日期
                .P_F_RS_ID5 = GR.GetSelRowCellText(3) & "." & GR.GetSelRowCellText(4) '部门
                .P_F_RS_Obj = GR.GetSelRowCellText(7) 'Employee_ShiftMoudel_Name'实际班次模板名称

            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            'GR.Visible = False
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            'GR.Visible = True
            AddHandler VF.ClosedX, AddressOf Me_Refresh
            VF.Show()
        End If
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

            Me_Refresh()
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
        R.Start(OperatorType.Preview)
    End Sub
#End Region


    Private Sub Cmd_Leven1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Leven1.Click, Cmd_Leven1to3.Click, Cmd_Leven2.Click, Cmd_Leven3.Click, Cmd_Leven4.Click, Cmd_Leven4to6.Click, Cmd_Leven5.Click, Cmd_Leven6.Click, Cmd_LevenAll.Click
        DropDown_Leven.Text = sender.Text
        Me_Refresh()
    End Sub

    Private Sub MonthPicker1_ValueChange(ByVal Value As System.DateTime) Handles MonthPicker1.ValueChange
        Me_Refresh()
    End Sub

   
End Class

Partial Friend Class Dao




End Class