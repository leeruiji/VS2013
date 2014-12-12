Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F15600_At_Data_Mx
    Private WithEvents R As New R15600_At_Data_Mx
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        '  Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        'Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
    End Sub

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
        DP_Start.Value = D.AddDays(-1)
        Dp_End.Value = D.AddDays(-1)
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
        If CK_Date.Checked Then
            R.SetOption(MonthPicker1.Value, MonthPicker1.Value.AddMonths(1).AddMilliseconds(-1), JobLeve, GetFindOtions.FoList, CK_NoCard.Checked)
        Else
            R.SetOption(DP_Start.Value.Date, Dp_End.Value.Date.AddDays(1).AddMilliseconds(-1), JobLeve, GetFindOtions.FoList, CK_NoCard.Checked)
        End If

        R.Start()
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


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim sqlbuider As New StringBuilder("")
        Dim goodsCount As Integer = 0
        fo = New FindOption




        If Me.DeptID <> "" Then
            fo.DB_Field = "Employee_Dept"
            fo.Value = DeptID
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If



        If CB_Employee.IDAsInt <> 0 Then
            fo.DB_Field = "E.ID"
            fo.Value = CB_Employee.IDAsInt
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If




        Return oList
    End Function


#End Region

#Region "双击行,调出单的明细"



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

            CB_Employee.SearchID = ""
            CB_Employee.SearchType = cSearchType.ENum_SearchType.ALL

            '  Me_Refresh()
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

    Private Sub CK_Date_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CK_Date.CheckedChanged
        MonthPicker1.Visible = CK_Date.Checked

        Label_C.Visible = Not CK_Date.Checked
        Label_D.Visible = Not CK_Date.Checked
        DP_Start.Visible = Not CK_Date.Checked
        Dp_End.Visible = Not CK_Date.Checked
    End Sub



End Class



