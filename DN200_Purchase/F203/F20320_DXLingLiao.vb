Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F20320_DXLingLiao
    Dim BType As BillType = BillType.DXLingLiao
    Dim isLoaded As Boolean = False

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Dim isShowPrice As Boolean = PClass.PClass.CheckRight(ID, ClassMain.ShowPrice)
        FG1.Cols("SumAmount").Visible = isShowPrice
        Fg2.Cols("Price_LL").Visible = isShowPrice
        Fg2.Cols("Amount").Visible = isShowPrice
        LB_Amount.Visible = isShowPrice
        LabelZJE.Visible = isShowPrice
    End Sub

    Private Sub F20310_DXLingLiao_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        Fg2.FG_ColResize()
        SumFG1.AddSum()
        SumFG2.AddSum()

    End Sub

    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()

        Ch_Name = GetBillTypeName(ID)
        Dao.DXLingLiao_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

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
        TSP_Autited.Value = BaseClass.ComFun.Autitedtime

        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.DXLingLiao_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = "Field"
        CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.DXLingLiao_GetConditionNames()
        CB_Condition3.ComboBox.DisplayMember = "Field"
        CB_Condition3.ComboBox.ValueMember = "DB_Field"

        CB_Condition3.ComboBox.DataSource = Dao.DXLingLiao_GetCondition3
        Me_Refresh()
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.DXLingLiao_GetByOption(GetFindOtions)
        If msg.IsOk Then
            msg.Dt.Columns.Add("AuditedName", GetType(String))
            msg.Dt.Columns.Add("StateName", GetType(String))
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))
           
            For Each dr In msg.Dt.Rows
                Dim _state As Integer = IsNull(dr("State"), 0)
                dr("StateName") = BaseClass.ComFun.GetStateName(_state)

                dr("IsChecked") = False
              
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
            Dim ZL As Double = 0
            Dim Qty As Integer = 0
            Dim M As Double = 0

            For Each dr As DataRow In Dt.Rows

                ZL = ZL + dr("BZ_ZL")
                Qty = Qty + Val(dr("BZ_Qty"))
                M = M + Val(dr("SumAmount"))
            Next
            LB_Qty.Text = FormatNum(Qty)
            LB_ZL.Text = FormatZL(ZL)
            LB_Amount.Text = FormatMoney(M)
            If SelectRetrun Then
                SelectRetrun = False
            Else
                FG1.DtToFG(Dt)
            End If
            SumFG1.ReSum()
            FG1.RowSetForce("ID", ReturnId)
            If msg.Dt.Rows.Count = 0 Then
                Fg2.DtToFG(New DataTable("T"))
            End If
        End If
    End Sub

    Private Sub Form_Me_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr, Chr(27) 'esc
            Case Else
                If TB_ConditionValue1.Focused = False AndAlso CB_ConditionValue2.Focused = False AndAlso DP_Start.Focused = False AndAlso DP_End.Focused = False Then
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
            SelectRetrun = True
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
        Dim F As New F20321_DXLingLiao_Msg("")
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
            ShowErrMsg("请选择一个要修改的" & Dao.DXLingLiao_DB_NAME)
            Exit Sub
        End If
        Dim F As New F20321_DXLingLiao_Msg(FG1.Item(FG1.RowSel, "ID"))
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
            ShowErrMsg("请选择一个要修改的" & Dao.DXLingLiao_DB_NAME)
            Exit Sub
        End If
        ShowConfirm("是否删除" & Dao.DXLingLiao_DB_NAME & "[" & FG1.Item(FG1.RowSel, "ID") & "]?", AddressOf DelDXLingLiao)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelDXLingLiao()
        Dim msg As MsgReturn = Dao.LingLiao_Del(FG1.Item(FG1.RowSel, "ID"))
        If msg.IsOk Then
            ReturnId = FG1.SelectItem("ID")
            Edit_Retrun()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        isRowChang = False
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
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & Dao.SQL_DXLingLiao_Get_WithName & "where 1=1 " & OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap) & " and Type=" & BType & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "", paraMap)
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
    Public SelectRetrun As Boolean = False

    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
        If TSD_Date.Tag = "sDate" Then
            fo = New FindOption
            fo.DB_Field = "sDate"
            fo.Value = DP_Start.Value.Date
            fo.Value2 = DP_End.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)
        Else
            fo = New FindOption
            fo.DB_Field = "Audited_Date"
            fo.Value = DP_Start.Value.Date
            fo.Value2 = DP_End.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)

        End If

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

        If SelectRetrun Then
            fo = New FindOption
            fo.DB_Field = "T.ID"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If







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

    Private Sub TSM_sDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_sDate.Click
        TSD_Date.Text = TSM_sDate.Text
        TSD_Date.Tag = "sDate"
    End Sub

    Private Sub TSM_Audited_Date_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_Audited_Date.Click
        TSD_Date.Text = TSM_Audited_Date.Text
        TSD_Date.Tag = "Audited_Date"
    End Sub





#End Region

#Region "报表事件"


    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview, True)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print, True)
    End Sub


    Private Sub Cmd_Preview2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview2.Click
        Print(OperatorType.Preview, False)
    End Sub

    Private Sub Cmd_Print2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print2.Click
        Print(OperatorType.Print, False)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType, Optional ByVal isFirst As Boolean = True)
        Dim check As Integer = 0
        For i As Integer = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "IsChecked") Then
                check += 1
            End If
        Next
        If check < 2 Then
            If FG1.RowSel < 0 Then
                ShowErrMsg("请选择一张" & Ch_Name & "!")
                Exit Sub
            End If

            If CheckRight(ID, ClassMain.PrintMore) Then
                Dim Rr As New R20320_DXLingLiao
                Rr.Start(FG1.Item(FG1.RowSel, "ID"), DoOperator)
            Else
                Dim dtPrint As DtReturnMsg = Dao.GetPrintState(FG1.Item(FG1.RowSel, "ID"))
                If dtPrint.IsOk AndAlso IsNull(dtPrint.Dt.Rows(0)(IIf(isFirst, "PrintOne", "PrintTwo")), False) = True Then
                    ShowErrMsg("单号［" & FG1.Item(FG1.RowSel, "ID") & "］已打印")
                    Exit Sub
                Else
                    Dim Rr As New R20320_DXLingLiao
                    Rr.Start(FG1.Item(FG1.RowSel, "ID"), DoOperator)
                End If
            End If
            Exit Sub
        Else
            Dim R As New R20321_DXLingLiao
            R.Start(Get_id(), DoOperator, isFirst)
        End If
    End Sub

    Private Function Get_id() As DataTable
        Dim IdList As New List(Of String)
        Dim ProduceList As New Dictionary(Of String, Object)
        Dim BZ_Qty As Double = 0
        Dim BZ_ZL As Double = 0
        Dim StrId As String
        Dim StrIds As String
        Dim StrProduce As String
        Dim dtTable As New DataTable
        Dim dr As DataRow
        For i As Integer = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "IsChecked") Then
                IdList.Add(FG1.Item(i, "ID"))
                If Not ProduceList.ContainsKey(FG1.Item(i, "Produce_ID")) Then
                    ProduceList.Add(FG1.Item(i, "Produce_ID"), "")
                End If
                BZ_Qty = BZ_Qty + Val(FG1.Item(i, "BZ_Qty"))
                BZ_ZL = BZ_ZL + Val(FG1.Item(i, "BZ_ZL"))
            End If
        Next

        Dim SBID As New StringBuilder
        Dim SBProduce As New StringBuilder
        For Each StrId In IdList
            SBID.Append("'" & StrId & "',")
        Next

        For Each StrProduce In ProduceList.Keys
            SBProduce.Append(StrProduce & ",")
        Next

        StrId = SBID.Remove(SBID.Length - 1, 1).ToString
        StrIds = StrId.Replace("'", "")
        StrProduce = SBProduce.Remove(SBProduce.Length - 1, 1).ToString
        Dim DtMsg As DtReturnMsg = Dao.DXLingLiao_SelById("0")
        If DtMsg.IsOk Then
            DtMsg.Dt.Columns.Add("Title", GetType(String))
            DtMsg.Dt.Columns.Add("StrId", GetType(String))
            dr = DtMsg.Dt.NewRow
            dr("ID") = StrIds
            dr("Produce_ID") = StrProduce
            dr("BZ_Qty") = Val(BZ_Qty)
            dr("BZ_ZL") = Val(BZ_ZL)
            dr("Reason") = "定型领料"
            dr("sDate") = Today
            dr("RanSeShenPi") = ""
            dr("UPD_USER") = PClass.PClass.User_Name
            dr("Title") = "领料单"
            dr("StrId") = IsNull(StrId, "")
            DtMsg.Dt.Rows.Add(dr)
        End If
        Return DtMsg.Dt
    End Function
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
    '    Dim R As New R20310_DXLingLiao
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
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click
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
        Dao.DXLingLiao_DB_NAME = Ch_Name
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
    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ShowModify()
    End Sub
#End Region




    Private Sub TSP_Autited_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSP_Autited.ValueChanged
        If MeIsLoad Then BaseClass.ComFun.Autitedtime = TSP_Autited.Value.Date
    End Sub

 
End Class

Partial Friend Class Dao

    '===================出库单信息==============
    Public Const SQL_DXLingLiao_Get_WithName = "select T.*,C.Client_Name,BZ_Name from T20310_LingLiao_Table T left join T10110_Client C on T.Client_ID=C.ID  left join T10002_BZ BZ on BZ.ID=T.BZ_ID "

    Public Const SQL_DXLingLiao_OrderBy As String = " order by sDate "

    Private Const SQL_DXLingLiao_SelByid As String = " select top 1 S.*,E.Employee_Name as OperatorName " & _
                                                " from T20310_LingLiao_Table S " & _
                                                 " left join T15001_Employee E on S.Operator=E.ID " & _
                                                "where S.ID=@ID "

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DXLingLiao_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "单号编号"
        fo.DB_Field = "T.ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料名称"
        fo.DB_Field = "WL_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T10001_WL TW,T20311_LingLiao_List TL where %WL_Name% and TL.wl_id=TW.ID and t.id=TL.id)"
        fo.Sign = "%WL_Name%"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "Produce_ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户"
        fo.DB_Field = "Client_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "模糊搜索"
        fo.DB_Field = " "
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "(T.ID %Like% or  BZ_ZL %Like% or BZ_Qty %Like% or Produce_ID %Like% or Remark %Like%  )"
        fo.Sign = "%Like%"
        foList.Add(fo)


        Return foList
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DXLingLiao_GetCondition3() As List(Of FindOption)
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
    ''' 按条件获取出库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DXLingLiao_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_DXLingLiao_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" and Type=20320 ")
        sqlBuider.Append(SQL_DXLingLiao_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    Public Shared Function DXLingLiao_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_DXLingLiao_SelByid, "@ID", sId)
    End Function



End Class