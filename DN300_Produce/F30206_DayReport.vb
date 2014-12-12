Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F30206_DayReport
    Dim isLoaded As Boolean = False
    Dim Reson As String
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        Me.MeIsLoad = False
        isRowChang = False
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        FG2.FG_ColResize()
        SumFG1.AddSum()
        SumFG2.AddSum()
    End Sub

    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"


        Cmd_ShowList.Checked = My.Settings.ShowMx
        Cmd_ShowList_Click(Cmd_ShowList, New EventArgs)
        '默认时间不可选
        'CB_SearchByDate.Checked = False
        FG1.IniFormat()
        FG1.IniColsSize()
        Fg2.IniFormat()
        Fg2.IniColsSize()
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = Today
        DP_KD.Value = Today
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.DayRePort_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = "Field"
        CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.DayRePort_GetConditionNames()
        CB_Condition3.ComboBox.DisplayMember = "Field"
        CB_Condition3.ComboBox.ValueMember = "DB_Field"

        CB_Condition3.ComboBox.DataSource = Dao.DayRePort_GetCondition3
        If ID = 30206 Then
            Reson = "染部日报表"
        ElseIf ID = 30208 Then
            Reson = "定型日报表"
        End If
        Me_Refresh()

        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.DayRePort_GetByOption(GetFindOtions)
        If msg.IsOk And msg.Dt.Rows.Count > 0 Then
            msg.Dt.Columns.Add("AuditedName", GetType(String))
            msg.Dt.Columns.Add("StateName", GetType(String))
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))

            For i As Integer = 0 To msg.Dt.Rows.Count - 1
                If i = 0 Then
                    msg.Dt.Rows(i)("SumCrop") = msg.Dt.Rows(i)("DayCrop")
                    msg.Dt.Rows(i)("SumReCrop") = msg.Dt.Rows(i)("DayReCrop")
                Else
                    msg.Dt.Rows(i)("SumCrop") = msg.Dt.Rows(i)("DayCrop") + msg.Dt.Rows(i - 1)("SumCrop")
                    msg.Dt.Rows(i)("SumReCrop") = msg.Dt.Rows(i)("DayReCrop") + msg.Dt.Rows(i - 1)("SumReCrop")
                End If
        If IsNull(msg.Dt.Rows(i)("DayCrop"), 0) <> 0 Then
            msg.Dt.Rows(i)("DayRePercent") = msg.Dt.Rows(i)("DayReCrop") / msg.Dt.Rows(i)("DayCrop") * 100
        End If
                If IsNull(msg.Dt.Rows(i)("DayReCrop"), 0) <> 0 AndAlso IsNull(msg.Dt.Rows(i)("SumCrop"), 0) <> 0 Then

                    msg.Dt.Rows(i)("SumRePercent") = msg.Dt.Rows(i)("SumReCrop") \ msg.Dt.Rows(i)("SumCrop") * 100
                End If

            Next

        For Each dr In msg.Dt.Rows
            Dim _state As Integer = IsNull(dr("State"), 0)
            dr("StateName") = BaseClass.ComFun.GetStateName(_state)
            dr("IsChecked") = False
            Next
        End If
        FG1.DtToFG(msg.Dt)
        SumFG1.ReSum()
        FG1.RowSetForce("ID", ReturnId)
        If msg.Dt.Rows.Count = 0 Then
            Fg2.DtToFG(New DataTable("T"))
        End If

    End Sub

    Private Sub Form_Me_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr, Chr(27) 'esc
            Case Else
                If TB_ConditionValue1.Focused = False AndAlso CB_ConditionValue2.Focused = False Then
                    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
                        If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
                        TB_ConditionValue1.Focus()
                    Else
                        TB_ConditionValue1.Text = e.KeyChar
                        TB_ConditionValue1.Focus()
                    End If
                    If CB_ConditionName1.SelectedIndex = 0 AndAlso CB_ConditionName1.Items.Count > 1 Then
                        CB_ConditionName1.SelectedIndex = 1
                    End If
                End If
        End Select
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
        Dim dtCheck As MsgReturn = Dao.SQL_ChecksDate(DP_KD.Value, Reson)
        If dtCheck.IsOk AndAlso dtCheck.Msg > 0 Then
            ShowConfirm("日期［" & DP_KD.Value & "］已生成日报表是否打开", AddressOf ChengModify)
            Exit Sub
        End If
        Dim F As New F30207_DayReport_Msg(DP_KD.Value)
        With F
            .Mode = Mode_Enum.Add
            .P_ID = ID
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
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
            ShowErrMsg("请选择一个要修改的" & Dao.DayRePort_DB_NAME)
            Exit Sub
        End If
        Modify(FG1.SelectItem("ID"))
    End Sub

    Private Sub Modify(ByVal sID As String)
        Dim F As New F30207_DayReport_Msg(sID)
        With F
            .Mode = Mode_Enum.Modify
            .P_ID = ID
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    Private Sub ChengModify()
        Dim dtID As DtReturnMsg = Dao.SQL_GetIDByDate(DP_KD.Value, Reson)
        If dtID.IsOk AndAlso dtID.Dt.Rows.Count > 0 Then
            Modify(dtID.Dt.Rows(0)("ID"))
        End If
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的" & Dao.DayRePort_DB_NAME)
            Exit Sub
        End If
        ShowConfirm("是否删除" & Dao.DayRePort_DB_NAME & "[" & FG1.SelectItem("ID") & "]?", AddressOf DelDayRePort)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelDayRePort()
        Dim msg As MsgReturn = Dao.DayRePort_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            ReturnId = FG1.SelectItem("ID")
            Edit_Retrun()

        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"


    Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged
        If CB_ConditionName2.ComboBox.SelectedIndex = 0 Then
            CB_ConditionValue2.SelectedIndex = -1
            Exit Sub
        End If
        CB_ConditionValue2.ComboBox.Text = ""
        CB_ConditionValue2.ComboBox.SelectedIndex = -1
        Dim oList As OptionList = GetFindOtions()
        Dim paraMap As New Dictionary(Of String, Object)
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & Dao.SQL_DayRePort_Get_WithName & "where 1=1 " & OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap) & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "", paraMap)
        If msg.IsOk Then
            CB_ConditionValue2.ComboBox.DataSource = msg.Dt
        End If
    End Sub


    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ConditionValue1.TextChanged
        Me_Refresh()
    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        fo = New FindOption
        fo.DB_Field = "sDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)
        If CB_ConditionName1.ComboBox.SelectedItem IsNot Nothing AndAlso TB_ConditionValue1.Text <> "" Then
            fo = CB_ConditionName1.ComboBox.SelectedItem
            fo.Value = TB_ConditionValue1.Text
            If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If

        If CB_ConditionName2.ComboBox.SelectedItem IsNot Nothing AndAlso CB_ConditionName2.ComboBox.SelectedValue <> "" Then
            fo = CB_ConditionName2.ComboBox.SelectedItem
            fo.Value = CB_ConditionValue2.Text
            If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If
        If CB_Condition3.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Value = CB_Condition3.ComboBox.SelectedValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        fo = New FindOption
        fo.DB_Field = "T.Reson"
        fo.Value = Reson
        fo.Field_Operator = Enum_Operator.Operator_Equal
        oList.FoList.Add(fo)

        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CB_Condition3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Condition3.SelectedIndexChanged
        If isLoaded = True Then
            Me_Refresh()
        End If
    End Sub

#End Region

#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一张出货单!")
            Exit Sub
        End If
        Dim R As New R30207_DayReport_Msg(ID)
        R.Start(FG1.Item(FG1.RowSel, "ID"), DoOperator)
    End Sub

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
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click
        idList = New List(Of String)

        For i = 1 To FG1.Rows.Count - 1
            If IsNull(FG1.Item(i, "IsChecked"), False) = True Then
                idList.Add(FG1.Item(i, "ID"))
            End If

        Next
        If idList.Count > 0 Then
            ShowConfirm("是否要审核采购单? ", AddressOf ShenHe)
        Else
            ShowErrMsg("您没有选择采购单采购单!")
        End If
    End Sub
    Protected Sub ShenHe()
        Dim msg As MsgReturn

        Dim msgBudder As New StringBuilder

        Dim okCount As Integer = 0
        Dim failedCount As Integer = 0
        msgBudder.AppendLine("")
        For Each _ID As String In idList
            msg = Dao.DayRePort_Audited(_ID, True)
            If msg.IsOk Then
                okCount = okCount + 1
                '  ShowMsg("入库单[" & FG1.SelectItem("ID") & "]审核成功!", "入库单审核")
                '  Cmd_Audit.Enabled = False
            Else
                failedCount = failedCount + 1
                msgBudder.AppendLine(msg.Msg)
            End If
        Next
        msgBudder.Insert(0, "采购单批量审核,共" & okCount & "张单审核成功," & failedCount & "张单审核失败!")
        If failedCount > 0 Then
            ShowErrMsg(msgBudder.ToString)
        Else
            ShowOk(msgBudder.ToString, False)
        End If
        Me_Refresh()
    End Sub



#End Region

#Region "FG1事件"
    Dim isRowChang = True
    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If FG1.SelectItem Is Nothing OrElse IsNull(FG1.SelectItem("ID"), "") = "" Then
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
    Private Sub Mx_ReFresh()
        If FG1.RowSel < 1 Then Exit Sub
        If isRowChang = False Then
            isRowChang = True
            Exit Sub
        End If
        Dim msg As DtReturnMsg = Dao.DayRePort_GetRe_byid(IsNull(FG1.SelectItem("ID"), ""))
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

    '===================采购单信息==============
    Public Const SQL_DayRePort_Get_WithName = "select T.* from T30207_DayReport_Table T "
    Private Const SQL_DayRePort_OrderBy As String = " order by sDate "
    Private Const SQL_CheckDay As String = "Select Count(*)as Qty from T30207_DayReport_Table Where sDate=@sDate and Reson=@Reson"
    Private Const SQL_GetID As String = "Select ID From T30207_DayReport_Table where sDate=@sDate and Reson=@Reson order by ID"

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "报表单号"
        fo.DB_Field = "T.ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "回修项目"
        fo.DB_Field = "ReProject"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * T30209_DayReport_AnalysisList Al where %ReProject% and T.id=Al.id)"
        fo.Sign = "%ReProject%"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户"
        fo.DB_Field = "Client_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T10110_Client C,T30208_DayReport_ReList RE where %Client_Name% and Re.Client_ID=C.ID and T.id=RE.id)"
        fo.Sign = "%Client_Name%"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "布类"
        fo.DB_Field = "BZ_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T10002_BZ BZ,T30208_DayReport_ReList RE where %BZ_Name% and Re.BZ_ID=BZ.ID and T.id=RE.id)"
        fo.Sign = "%BZ_Name%"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "色号"
        fo.DB_Field = "BZC_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T10003_BZC B,T30208_DayReport_ReList RE where %BZC_Name% and Re.BZC_ID=B.ID and T.id=RE.id)"
        fo.Sign = "%BZC_Name%"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "GH"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T30208_DayReport_ReList RE where %GH% and  T.id=RE.id)"
        fo.Sign = "%GH%"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "模糊搜索"
        fo.DB_Field = " "
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "(T.ID %Like% or Remarks %Like%)"
        fo.Sign = "%Like%"
        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_GetCondition3() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "新建"
        fo.DB_Field = Enum_State.AddNew
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已审核"
        fo.DB_Field = Enum_State.Audited
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已作废"
        fo.DB_Field = Enum_State.Invoid
        foList.Add(fo)

        Return foList
    End Function
    ''' <summary>
    ''' 按条件获取采购单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DayRePort_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_DayRePort_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_DayRePort_OrderBy)
        Return (PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap))
    End Function

    ''' <summary>
    ''' 检查当日是否已生成一次报表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SQL_ChecksDate(ByVal sDate As Date, ByVal Reson As String) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("@sDate", sDate)
        p.Add("@Reson", Reson)
        Return PClass.PClass.SqlStrToOneStr(SQL_CheckDay, p)
    End Function


    ''' <summary>
    ''' 按时间查询单号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SQL_GetIDByDate(ByVal sDate As Date, ByVal Reson As String) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("@sDate", sDate)
        p.Add("@Reson", Reson)
        Return PClass.PClass.SqlStrToDt(SQL_GetID, p)
    End Function





End Class