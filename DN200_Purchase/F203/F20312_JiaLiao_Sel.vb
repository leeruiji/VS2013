Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F20312_JiaLiao_Sel
    Dim BType As BillType = BillType.LingLiao
    Dim isLoaded As Boolean = False
    Dim mainbill As String = ""



    Public Sub New(ByVal _mainBill As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        mainbill = _mainBill
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 20310
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)

        Dim isShowPrice As Boolean = PClass.PClass.CheckRight(ID, ClassMain.ShowPrice)
        FG1.Cols("SumAmount").Visible = isShowPrice
        Fg2.Cols("Price").Visible = isShowPrice
        Fg2.Cols("Amount").Visible = isShowPrice
    End Sub

    Private Sub F20310_LingLiao_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        Fg2.FG_ColResize()
        SumFG1.AddSum()
        SumFG2.AddSum()
    End Sub

    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Dao.LingLiao_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "选择"




        Cmd_ShowList.Checked = My.Settings.ShowMx
        Cmd_ShowList_Click(Cmd_ShowList, New EventArgs)
        '默认时间不可选
        'CB_SearchByDate.Checked = False
        FG1.IniFormat()
        FG1.IniColsSize()
        Fg2.IniFormat()
        Fg2.IniColsSize()
        DP_Start.Value = Today
        DP_End.Value = Today

        Me_Refresh()
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        If mainbill = "" Then
            FG1.Rows.Count = 1
            Exit Sub
        End If
        Dim msg As DtReturnMsg = Dao.JiaLiao_GetByMailBill(mainbill, BillType.LingLiao)
        If msg.IsOk Then
            msg.Dt.Columns.Add("AuditedName", GetType(String))
            msg.Dt.Columns.Add("StateName", GetType(String))
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))
            For Each dr In msg.Dt.Rows
                Dim _state As Integer = IsNull(dr("State"), 0)
                dr("StateName") = BaseClass.ComFun.GetStateName(_state)

                dr("IsChecked") = False
            Next
            FG1.DtToFG(msg.Dt)
            SumFG1.ReSum()
            FG1.RowSetForce("ID", ReturnId)
            If msg.Dt.Rows.Count = 0 Then
                Fg2.DtToFG(New DataTable("T"))
            End If
        End If
    End Sub




#Region "控件事件"

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub
    Private Sub Cmd_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Refresh.Click
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click

        Dim F As New F20311_LingLiao_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        ShowModify()
    End Sub

    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Click
        If FG1.ColSel = FG1.Cols("IsChecked").Index Then
            FG1.Item(FG1.RowSel, "IsChecked") = Not FG1.Item(FG1.RowSel, "IsChecked")
        End If
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        ShowModify()
    End Sub

    Protected Sub ShowModify()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的" & Dao.LingLiao_DB_NAME)
            Exit Sub
        End If
        Dim F As New F20311_LingLiao_Msg(FG1.Item(FG1.RowSel, "ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .ID = Me.ID
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的" & Dao.LingLiao_DB_NAME)
            Exit Sub
        End If
        ShowConfirm("是否删除" & Dao.LingLiao_DB_NAME & "[" & FG1.Item(FG1.RowSel, "ID") & "]?", AddressOf DelLingLiao)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelLingLiao()
        Dim msg As MsgReturn = Dao.LingLiao_Del(FG1.Item(FG1.RowSel, "ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        isRowChang = False
        Me.Close()
    End Sub
#End Region



#Region "报表事件"


    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print)
    End Sub


    Private Sub Cmd_Preview2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview2.Click
        Print(OperatorType.Preview, False)
    End Sub

    Private Sub Cmd_Print2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print2.Click
        Print(OperatorType.Print, False)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType, Optional ByVal isFirst As Boolean = True)
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一张" & Ch_Name & "!")
            Exit Sub
        End If

        Dim R As New R20310_LingLiao
        R.Start(FG1.Item(FG1.RowSel, "ID"), DoOperator, isFirst)
    End Sub


    'Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Print(OperatorType.Preview)
    'End Sub

    'Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Print(OperatorType.Print)
    'End Sub

    'Protected Sub Print(ByVal DoOperator As OperatorType)
    '    If FG1.RowSel < 0 Then
    '        ShowErrMsg("请选择一张" & Ch_Name & "!")
    '        Exit Sub
    '    End If
    '    Dim R As New R20310_LingLiao
    '    R.Start(FG1.Item(FG1.RowSel, "ID"), DoOperator)
    'End Sub

#End Region

#Region "选择日期"



    'Private Sub CB_SearchByDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If CB_SearchByDate.Checked Then
    '        DP_End.Enabled = True
    '        DP_Start.Enabled = True
    '    Else
    '        DP_End.Enabled = False
    '        DP_Start.Enabled = False
    '    End If
    'End Sub
#End Region

#Region "审核状态"
    Dim idList As List(Of String)
    ''' <summary>
    ''' 审核
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        idList = New List(Of String)
        For i = 1 To FG1.Rows.Count - 1
            If IsNull(FG1.Item(i, "IsChecked"), False) = True Then
                idList.Add(FG1.Item(i, "ID"))
            End If
        Next
        If idList.Count > 0 Then
            ShowConfirm("是否要审核" & Ch_Name & "? ", AddressOf ShenHe)
        Else
            ShowErrMsg("你没有选择" & Ch_Name & "!")
        End If
    End Sub
    Protected Sub ShenHe()
        Dim msg As MsgReturn
        Dim msgBudder As New StringBuilder
        Dim okCount As Integer = 0
        Dim failedCount As Integer = 0
        msgBudder.AppendLine("")
        Dao.LingLiao_DB_NAME = Ch_Name
        For Each _ID As String In idList
            msg = Dao.LingLiao_Audited(_ID, True)
            If msg.IsOk Then
                okCount = okCount + 1
            Else
                failedCount = failedCount + 1
                msgBudder.AppendLine(msg.Msg)
            End If
        Next
        msgBudder.Insert(0, Ch_Name & "批量审核,共" & okCount & "张单审核成功," & failedCount & "张单审核失败!")
        If failedCount > 0 Then
            ShowErrMsg(msgBudder.ToString)
        Else
            ShowOk(msgBudder.ToString, False)
        End If
        Me_Refresh()
    End Sub



#End Region
#Region "FG1事件"
    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If FG1.SelectItem Is Nothing OrElse IsNull(FG1.Item(FG1.RowSel, "ID"), "") = "" Then
            Exit Sub
        End If
        If IsNull(FG1.SelectItem("State"), Enum_State.AddNew) = Enum_State.AddNew Then
            Cmd_Del.Enabled = Cmd_Del.Tag
        Else
            Cmd_Del.Enabled = False
        End If
        If SplitContainer1.Panel2Collapsed = False Then
            Mx_ReFresh()
        End If

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_ChooseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChooseAll.Click
        If FG1.Rows.Count > 1 Then
            For i = 1 To FG1.Rows.Count - 1
                FG1.Item(i, "IsChecked") = True
            Next
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_UnChooseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnChooseAll.Click
        If FG1.Rows.Count > 1 Then
            For i = 1 To FG1.Rows.Count - 1
                FG1.Item(i, "IsChecked") = False
            Next
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_UnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnChoose.Click
        If FG1.Rows.Count > 1 Then
            For i = 1 To FG1.Rows.Count - 1
                FG1.Item(i, "IsChecked") = Not FG1.Item(i, "IsChecked")
            Next
        End If
    End Sub
#End Region

#Region "显示明细"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_ShowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowList.Click
        If Cmd_ShowList.Checked Then
            If isLoaded Then
                Dim x As Integer = My.Settings.MxDistance
                SplitContainer1.Panel2Collapsed = False
                SplitContainer1.SplitterDistance = x
                Mx_ReFresh()
            End If
        Else
            SplitContainer1.Panel2Collapsed = True
        End If
        My.Settings.ShowMx = Cmd_ShowList.Checked
        My.Settings.Save()
    End Sub
    '标示行切换
    Dim isRowChang = True
    Private Sub Mx_ReFresh()
        If FG1.RowSel < 1 Then Exit Sub
        If isRowChang = False Then
            isRowChang = True
            Exit Sub
        End If
        Dim msg As DtReturnMsg = Dao.LingLiao_SelListById(IsNull(FG1.Item(FG1.RowSel, "ID"), ""))
        If msg.IsOk Then
            Fg2.DtToFG(msg.Dt)
            SumFG2.ReSum()
        Else
        End If
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If Me.isLoaded = True Then
            My.Settings.MxDistance = SplitContainer1.SplitterDistance
            My.Settings.Save()
        End If
    End Sub
#End Region


#Region "FG2事件"
    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        ShowModify()
    End Sub
#End Region




End Class

Partial Friend Class Dao

    '===================出库单信息==============
    ' Public Const SQL_LingLiao_Get_WithName = "select T.*,C.Client_Name from T20310_LingLiao_Table T left join T10110_Client C on T.Client_ID=C.ID  "

    ' Public Const SQL_LingLiao_OrderBy As String = " order by sDate "

    ''' <summary>
    ''' 按条件获取出库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JiaLiao_GetByMailBill(ByVal mainBill As String, ByVal Type As BillType) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("mainBill", mainBill)
        paraMap.Add("Type", Type)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_LingLiao_Get_WithName)
        sqlBuider.Append("  WHERE   Produce_ID  =@mainBill and isnull(IsJiaLiao,0)=1 and Type=@Type and state >-1")
        sqlBuider.Append(SQL_LingLiao_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function




End Class