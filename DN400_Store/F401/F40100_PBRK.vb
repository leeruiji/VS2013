Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F40100_PBRK
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        '  Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)


        If CheckRight(ID, ClassMain.CanExcelOut) Then
            FG1.SetCanExcelOut()
        Else
            FG1.SetCanNotExcelOut()
        End If


    End Sub
    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        SumFG1.AddSum()
    End Sub



    Private Sub F10100_PBRK_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        '默认时间不可选
        CB_SearchByDate.Checked = True
        FG1.IniFormat()
        DP_Start.Value = GetTime.AddHours(-8).Date
        DP_End.Value = DP_Start.Value
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.PBRK_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.PBRK_GetConditionNames()

        CB_Condition.ComboBox.DisplayMember = "Field"
        CB_Condition.ComboBox.ValueMember = "DB_Field"
        CB_Condition.ComboBox.DataSource = BZSH_GetCondition

        Me_Refresh()
    End Sub
    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetCondition() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "未作废"
        fo.DB_Field = Enum_BZSH.UnInvoid
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "新建"
        fo.DB_Field = Enum_BZSH.AddNew
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已确认"
        fo.DB_Field = Enum_BZSH.Store_Comfirm
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已审核"
        fo.DB_Field = Enum_BZSH.Audited
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已作废"
        fo.DB_Field = Enum_BZSH.Invoid
        foList.Add(fo)

 

        Return foList
    End Function
    ''' <summary>
    '''状态枚举
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Enum_BZSH
        AddNew = 0
        ''' <summary>
        ''' 新建
        ''' </summary>
        ''' <remarks></remarks>
        Store_Comfirm = 1
        ''' <summary>
        ''' 确认
        ''' </summary>
        ''' <remarks></remarks>
        Audited = 2
        ''' <summary>
        ''' 审核
        ''' </summary>
        ''' <remarks></remarks>
        Invoid = -1
        ''' <summary>
        ''' 作废
        ''' </summary>
        ''' <remarks></remarks>
        UnInvoid = -2
        ''' <summary>
        ''' 未作废
        ''' </summary>
        ''' <remarks></remarks>

    End Enum
#Region "刷新FG"

    Public Nohide As Boolean = False
    Protected Sub Me_Refresh()
        Static T As Threading.Thread
        If T IsNot Nothing Then
            If T.IsAlive Then
                Try
                    T.Abort()
                Catch ex As Exception
                End Try
            End If
        End If
        T = New Threading.Thread(AddressOf GetData)
        FG1.Visible = False
        T.Start(GetFindOtions)
        If Nohide = False Then Me.ShowLoading(MeIsLoad)
    End Sub


    Sub SetData(ByVal msg As DtReturnMsg)
        If msg.IsOk Then
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))
            msg.Dt.Columns.Add("StateName", GetType(String))
            For Each dr In msg.Dt.Rows
                Dim _state As Integer = IsNull(dr("State"), 0)
                If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
                    dr("BZ_No") = ""
                End If
                dr("BZ_Name") = dr("BZ_No") & dr("BZ_Name")
                dr("IsChecked") = False
                dr("StateName") = BaseClass.ComFun.GetBZSH_StateName(_state)
            Next
            Dim Dt As DataTable

            If SelectRetrun Then
                Dt = TryCast(FG1.DataSource, DataTable)
                If Dt Is Nothing Then
                    Dt = msg.Dt
                Else
                    BaseClass.ComFun.DtReFreshRow(Dt, msg.Dt, "ID", ReturnId)
                End If
            Else
                Dt = msg.Dt
            End If

            Dim sumQty As Integer = 0
            Dim sumZL As Double = 0
            Dim RemainQty As Integer = 0
            Dim RemainZL As Double = 0
            For Each dr As DataRow In Dt.Rows
                sumQty += IsNull(dr("sumQty"), 0)
                sumZL += IsNull(dr("SumPWeight"), 0)
                RemainQty += IsNull(dr("RemainCount"), 0)
                RemainZL += IsNull(dr("RemainWeight"), 0)
            Next
            LB_Qty.Text = sumQty
            LB_RemainCount.Text = RemainQty
            LB_ZL.Text = FormatZL(sumZL)
            LB_RemainZL.Text = FormatZL(RemainZL)
            If SelectRetrun Then
                SelectRetrun = False
            Else
                FG1.DtToFG(Dt)
                dtlist = Dt
            End If
            SumFG1.ReSum()
            FG1.RowSetForce("ID", ReturnId)
        Else
            FG1.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
        Nohide = False
    End Sub


    Dim dtlist As New DataTable

    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.PBRK_GetByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)

#End Region

    Private Sub F40000_PBRK_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                If DP_Start.Focused = False AndAlso DP_End.Focused = False AndAlso TB_ConditionValue1.Focused = False AndAlso CB_ConditionValue2.Focused = False AndAlso TSC_BZ.Focused = False AndAlso TSC_Client.Focused = False AndAlso TB_GH.Focused = False Then
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


    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub


    Private Sub Edit_Retrun()
        If ReturnId.StartsWith("ALL") Then
            Me_Refresh()
        ElseIf ReturnId <> "" Then
            SelectRetrun = True
            Me_Refresh()
        End If


    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim F As New F40101_PBRK_Msg("")
        With F
            .Mode = Mode_Enum.Add
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
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的胚布入库单")
            Exit Sub
        End If
        Dim F As New F40101_PBRK_Msg(FG1.SelectItem("ID"))
        With F
            .Mode = Mode_Enum.Modify
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
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的胚布入库单")
            Exit Sub
        End If
        If FG1.ColSel = FG1.Cols("BZ_Name").Index Then
            TSC_BZ.IDAsInt = FG1.Item(FG1.RowSel, "BZ_ID")
            TSC_BZ.Text = TSC_BZ.GetByTextBoxTag(TSC_BZ.IDAsInt)
        Else
            Cmd_Modify_Click(sender, e)
        End If
    End Sub


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的胚布入库单")
            Exit Sub
        End If
        ShowConfirm("是否删除胚布入库单 [" & FG1.SelectItem("ID") & "]?", AddressOf DelPBRK)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelPBRK()
        Dim msg As MsgReturn = Dao.PBRK_Del(FG1.SelectItem("ID"))
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
    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0
    End Sub


    Private Sub TB_GH_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Dim R As MsgReturn = ComFun.GetGHForTM(TB_GH.TextBox.Text)
            Dim dt As DtReturnMsg
            If R.IsOk Then
                dt = Dao.BZ_GetByGH(R.Msg)
                TSC_Client.IDAsInt = Val(dt.Dt.Rows(0)("Client_ID"))
                TSC_Client.Text = TSC_Client.GetByTextBoxTag
                TSC_BZ.IDAsInt = Val(dt.Dt.Rows(0)("BZ_ID"))
                TSC_BZ.Text = TSC_BZ.GetByTextBoxTag
                CB_SearchByDate.Checked = False
                Me.Me_Refresh()
            Else
                ShowErrMsg(R.Msg)
            End If
        End If
    End Sub

    Private Sub CBL_Client_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If Val(ID) <> 0 Then
            If TSC_BZ.SearchID <> ID Then
                TSC_BZ.SetSearchEmpty()
            End If
            TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
            TSC_BZ.SearchID = ID
        Else
            TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
            TSC_BZ.SearchID = 0
        End If
    End Sub


#Region "搜索工具栏"
    'Private Sub CB_ConditionName1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName1.SelectedIndexChanged
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName1.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue1.ComboBox.DataSource = msg.Dt

    '    End If
    'End Sub

    Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged
        If CB_ConditionName2.ComboBox.SelectedIndex = 0 Then
            CB_ConditionValue2.SelectedIndex = -1
            Exit Sub
        End If
        Dim oList As OptionList = GetFindOtions()
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & Dao.SQL_PBRK_Get_WithName & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "")
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
        Nohide = True
        Me_Refresh()
    End Sub
#Region "返工布"
    Private Sub TSM_ALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_ALL.Click
        TSD_FG.Text = TSM_ALL.Text
        TSD_FG.Tag = TSM_ALL.Tag
    End Sub

    Private Sub TSM_FG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_FG.Click
        TSD_FG.Text = TSM_FG.Text
        TSD_FG.Tag = TSM_FG.Tag
    End Sub

    Private Sub TSM_PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_PB.Click
        TSD_FG.Text = TSM_PB.Text
        TSD_FG.Tag = TSM_PB.Tag
    End Sub
#End Region

    Public SelectRetrun As Boolean = False
    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        '   oList.Sql = SQL_PBRK_Get_Sel
        '    Dim sqlbuider As New StringBuilder(SQL_PBRK_Get_Sel)
        Dim goodsCount As Integer = 0

        'fo = New FindOption
        'fo.DB_Field = "State"
        'fo.Value = -1
        'fo.Field_Operator = Enum_Operator.Operator_More
        'oList.FoList.Add(fo)
        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "P.Client_ID"
            fo.Value = TSC_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        'If CK_FG.Checked Then
        '    fo = New FindOption
        '    fo.DB_Field = "IsFG"
        '    fo.Value = True
        '    fo.Field_Operator = Enum_Operator.Operator_Equal
        '    oList.FoList.Add(fo)
        'End If

        If TSD_FG.Tag <> 1 Then
            If TSD_FG.Tag = 2 Then
                fo = New FindOption
                fo.DB_Field = "IsFG"
                fo.Value = True
                fo.Field_Operator = Enum_Operator.Operator_Equal
                oList.FoList.Add(fo)
            ElseIf TSD_FG.Tag = 3 Then
                fo = New FindOption
                fo.DB_Field = "IsFG"
                fo.Value = False
                fo.Field_Operator = Enum_Operator.Operator_Equal
                oList.FoList.Add(fo)
            End If

        End If

        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption


            Dim R As MsgReturn = SqlStrToOneStr("select top 1 Group_ID from T10002_BZ_Group where BZ_ID=@BZ_ID", "BZ_ID", TSC_BZ.IDValue)
            If R.IsOk AndAlso R.Msg <> "" Then



                fo.DB_Field = " "
                fo.Value = R.Msg
                fo.Field_Operator = Enum_Operator.Operator_Equal
                fo.SQL = " exists(SELECT * FROM T10002_BZ_Group G where Group_ID %Like% and G.BZ_ID=P.BZ_ID) "
                fo.Sign = "%Like%"


            Else
                fo.DB_Field = "BZ_ID"
                fo.Value = TSC_BZ.IDValue
                fo.Field_Operator = Enum_Operator.Operator_Equal
            End If
            goodsCount = 1
            oList.FoList.Add(fo)
        End If

        If CB_SearchByDate.Checked Then
            fo = New FindOption
            fo.DB_Field = "sDate"
            fo.Value = DP_Start.Value.Date
            fo.Value2 = DP_End.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)
        End If

        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedItem.DB_Field
            'If fo.DB_Field = "BZ_ID" Then
            '    goodsCount = 1

            'ElseIf fo.DB_Field = "BZ_Name" Then
            '    goodsCount = 2

            'End If

            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = CB_ConditionName1.ComboBox.SelectedItem.Field_Operator
            oList.FoList.Add(fo)
        End If

        If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName2.ComboBox.SelectedItem.DB_Field
            'If fo.DB_Field = "BZ_ID" Then
            '    goodsCount = 1
            'ElseIf fo.DB_Field = "BZ_Name" Then
            '    goodsCount = 2
            'End If
            fo.Value = CB_ConditionValue2.ComboBox.Text
            fo.Field_Operator = CB_ConditionName2.ComboBox.SelectedItem.Field_Operator
            oList.FoList.Add(fo)
        End If


        If CK_Zero.Checked Then
            fo = New FindOption
            fo.DB_Field = "RemainCount"
            fo.Value = 0
            fo.Field_Operator = Enum_Operator.Operator_More
            oList.FoList.Add(fo)
        End If

        'If goodsCount = 1 Then
        '    sqlbuider.Append(", List.BZ_ID ")
        '    sqlbuider.Append(SQL_PBRK_Get_Body)
        '    sqlbuider.Append(SQL_PBRK_Get_leftJoin_GoodsNo)
        'ElseIf goodsCount = 2 Then
        '    sqlbuider.Append(", List.BZ_ID,List.BZ_Name ")
        '    sqlbuider.Append(SQL_PBRK_Get_Body)
        '    sqlbuider.Append(SQL_PBRK_Get_leftJoin_GoodsName)
        'Else

        '    sqlbuider.Append(SQL_PBRK_Get_Body)

        'End If
        ''   sqlbuider.Append(SQL_PBRK_OrderBy)
        'oList.Sql = sqlbuider.ToString
        If CB_Condition.SelectedIndex = 0 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Value = 0
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            oList.FoList.Add(fo)
        ElseIf CB_Condition.SelectedIndex > 1 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Value = CB_Condition.ComboBox.SelectedValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If SelectRetrun Then
            fo = New FindOption
            fo.DB_Field = "p.id"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub


#End Region
#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一张出货单!")
            Exit Sub
        End If
        Dim R As New R40100_PBRK(CheckRight(ID, ClassMain.RpCanExcelOut))
        R.Start(DoOperator, FG1.DataSource)
    End Sub

#End Region

#Region "选择日期"



    Private Sub CB_SearchByDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_SearchByDate.Click
        If CB_SearchByDate.Checked Then
            DP_End.Enabled = True
            DP_Start.Enabled = True
        Else
            DP_End.Enabled = False
            DP_Start.Enabled = False
        End If
    End Sub
#End Region

#Region "确认状态"
    Dim idList As List(Of String)
    ''' <summary>
    ''' 确认
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
            ShowConfirm("是否要确认入库单? ", AddressOf QueRen)
        Else
            ShowErrMsg("您没有选择入库单!")
        End If
    End Sub
    Protected Sub QueRen()
        Dim msg As MsgReturn

        Dim msgBudder As New StringBuilder

        Dim okCount As Integer = 0
        Dim failedCount As Integer = 0
        msgBudder.AppendLine("")
        For Each _ID As String In idList
            msg = Dao.PBRK_Comfirm(_ID, True)
            If msg.IsOk Then
                okCount = okCount + 1
                '  ShowMsg("入库单[" & FG1.SelectItem("ID") & "]审核成功!", "入库单审核")
                '  Cmd_Audit.Enabled = False
            Else
                failedCount = failedCount + 1
                msgBudder.AppendLine(msg.Msg)
            End If
        Next
        msgBudder.Insert(0, "入库单批量确认,共" & okCount & "张单确认成功," & failedCount & "张单确认失败!")
        If failedCount > 0 Then
            ShowErrMsg(msgBudder.ToString)
        Else
            ShowOk(msgBudder.ToString, False)
        End If
        Me_Refresh()
    End Sub



#End Region


    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Click
        If FG1.ColSel = FG1.Cols("IsChecked").Index Then
            FG1.Item(FG1.RowSel, "IsChecked") = Not FG1.Item(FG1.RowSel, "IsChecked")
        End If
    End Sub


End Class
