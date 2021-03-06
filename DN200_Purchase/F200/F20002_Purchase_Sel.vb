﻿Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F20002_Purchase_Sel
    Dim isLoaded As Boolean = False
    Dim dtLines As DataTable
    Dim Supplier_ID As Integer

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal _Supplier_ID As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Supplier_ID = _Supplier_ID
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()



    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        'FG2.FG_ColResize()
        SumFG1.AddSum()
        'SumFG2.AddSum()
    End Sub





    Private Sub Form_Me_Load() Handles Me.Me_Load
        'FormCheckRight()
        ID = 20002
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        '默认时间不可选
        'CB_SearchByDate.Checked = False
        FG1.IniFormat()
        FG1.IniColsSize()
        'Fg2.IniFormat()
        'Fg2.IniColsSize()
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = Today
        'CB_ConditionName1.ComboBox.DisplayMember = "Field"
        'CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        ''CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        ''CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        'CB_ConditionName1.ComboBox.DataSource = Dao.Purchase_GetConditionNames()
        'CB_ConditionName2.ComboBox.DisplayMember = "Field"
        'CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        'CB_ConditionName2.ComboBox.DataSource = Dao.Purchase_GetConditionNames()
        'CB_Condition3.ComboBox.DisplayMember = "Field"
        'CB_Condition3.ComboBox.ValueMember = "DB_Field"

        'CB_Condition3.ComboBox.DataSource = Dao.Purchase_GetCondition3
        Me_Refresh()
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.PurchaseAsk_GetPurchase(GetFindOtions)
        If msg.IsOk Then
            'msg.Dt.Columns.Add("AuditedName", GetType(String))
            'msg.Dt.Columns.Add("StateName", GetType(String))
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))
            For Each dr In msg.Dt.Rows
                'Dim _state As Integer = IsNull(dr("State"), 0)
                'dr("StateName") = BaseClass.ComFun.GetStateName_Upgrade(_state)
                dr("IsChecked") = False
            Next
            dtLines = msg.Dt
            FG1.DtToFG(msg.Dt)
            SumFG1.ReSum()
            FG1.RowSetForce("SG_ID", ReturnId)
            'If msg.Dt.Rows.Count = 0 Then
            '    Fg2.DtToFG(New DataTable("T"))
            'End If
        End If
    End Sub

    Private Sub Form_Me_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                'If TB_ConditionValue1.Focused = False AndAlso CB_ConditionValue2.Focused = False Then
                '    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
                '        If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
                '        TB_ConditionValue1.Focus()
                '    Else
                '        TB_ConditionValue1.Text = e.KeyChar
                '        TB_ConditionValue1.Focus()
                '    End If
                '    If CB_ConditionName1.SelectedIndex = 0 AndAlso CB_ConditionName1.Items.Count > 1 Then
                '        CB_ConditionName1.SelectedIndex = 1
                '    End If
                ' End If
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


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"


    'Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If CB_ConditionName2.ComboBox.SelectedIndex = 0 Then
    '        CB_ConditionValue2.SelectedIndex = -1
    '        Exit Sub
    '    End If
    '    CB_ConditionValue2.ComboBox.Text = ""
    '    CB_ConditionValue2.ComboBox.SelectedIndex = -1
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & Dao.SQL_Purchase_Get_WithName & "where 1=1 " & OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap) & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "", paraMap)
    '    If msg.IsOk Then
    '        CB_ConditionValue2.ComboBox.DataSource = msg.Dt
    '    End If
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
        Dim goodsCount As Integer = 0

        fo = New FindOption
        fo.DB_Field = "PL.Supplier_ID"
        fo.Value = Supplier_ID
        fo.Field_Operator = Enum_Operator.Operator_Equal
        oList.FoList.Add(fo)

        fo = New FindOption
        fo.DB_Field = "PT.sDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)
        'If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not TB_ConditionValue1.Text = "" Then
        '    fo = New FindOption
        '    fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue
        '    fo.Value = TB_ConditionValue1.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like_Both
        '    oList.FoList.Add(fo)
        'End If

        'If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
        '    fo = New FindOption
        '    fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
        '    fo.Value = CB_ConditionValue2.ComboBox.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like
        '    oList.FoList.Add(fo)
        'End If
        'If CB_Condition3.SelectedIndex > 0 Then
        '    fo = New FindOption
        '    fo.DB_Field = "State"
        '    fo.Value = CB_Condition3.ComboBox.SelectedValue
        '    fo.Field_Operator = Enum_Operator.Operator_Equal
        '    oList.FoList.Add(fo)
        'End If
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
    Private Sub CB_Condition3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If isLoaded = True Then
            Me_Refresh()
        End If
    End Sub

#End Region


#Region "显示明细"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCheckPurchaseId() As List(Of String)
        Dim idList As New List(Of String)
        For i = 1 To FG1.Rows.Count - 1
            If IsNull(FG1.Item(i, "IsChecked"), False) = True Then
                idList.Add(FG1.Item(i, "ID"))
            End If
        Next
        Return idList
    End Function

    Private Sub Mx_ReFresh()
        If FG1.RowSel < 1 Then Exit Sub
        Dim msg As DtReturnMsg = Dao.Purchase_SelListByIdList(GetCheckPurchaseId)
        If msg.IsOk Then

            msg.Dt.Columns.Add("StateName", GetType(String))
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))
            For Each dr In msg.Dt.Rows


                dr("IsChecked") = True
            Next
            dtLines = msg.Dt
            ' Fg2.DtToFG(dtLines)
            'SumFG2.ReSum()
        Else
        End If
    End Sub


    Private Function GetCheckPurchaseLine() As DataTable
        If dtLines Is Nothing Then
            Return New DataTable
        End If

        Dim dt As DataTable = dtLines.Clone
        Dim newDr As DataRow
        For i = 1 To FG1.Rows.Count - 1
            If IsNull(FG1.Item(i, "IsChecked"), False) = True Then
                newDr = dt.NewRow
                newDr("SG_ID") = FG1.Item(i, "SG_ID")
                newDr("Line") = FG1.Item(i, "Line")
                newDr("WL_ID") = FG1.Item(i, "WL_ID")
                newDr("WL_No") = FG1.Item(i, "WL_No")
                newDr("WL_Name") = FG1.Item(i, "WL_Name")
                newDr("WL_Spec") = FG1.Item(i, "WL_Spec")
                newDr("WL_Unit") = FG1.Item(i, "WL_Unit")
                newDr("Price") = FG1.Item(i, "Price")
                newDr("Qty") = FG1.Item(i, "Qty")
                newDr("Amount") = FG1.Item(i, "Amount")
                dt.Rows.Add(newDr)
            End If
        Next
        Return dt
    End Function

    Private Sub Cmd_Sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Sel.Click
        Me.LastForm.ReturnObj = GetCheckPurchaseLine()
        Me.Close()
    End Sub
#End Region
#Region "FG1事件"
    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Click
        If FG1.ColSel = FG1.Cols("IsChecked").Index AndAlso FG1.RowSel > 0 Then
            FG1.Item(FG1.RowSel, "IsChecked") = Not FG1.Item(FG1.RowSel, "IsChecked")
            '    Mx_ReFresh()
        End If
    End Sub

    '''' <summary>
    '''' 双击行.进入修改页面
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
    '    ShowModify()
    'End Sub

    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If FG1.SelectItem Is Nothing OrElse IsNull(FG1.SelectItem("WL_ID"), 0) = 0 Then
            Exit Sub
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



#Region "FG2事件"
    'Private Sub FG2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Fg2.ColSel = FG1.Cols("IsChecked").Index Then
    '        Fg2.Item(Fg2.RowSel, "IsChecked") = Not Fg2.Item(Fg2.RowSel, "IsChecked")
    '    End If
    'End Sub
    'Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
    '    ShowModify()
    'End Sub
#End Region




End Class

Partial Friend Class Dao
#Region "SQL"
    'Public Const SQL_PurchaseReturn_GetPurchase As String = "Select P.*,isnull(RL.SumRLQty,0) as SumRLQty,Supplier_No,S.Supplier_Name from  T20000_Puchase_Table P left join (Select Purchase_ID,  sum(isnull(Qty,0)) as SumRLQty from  T20011_PurchaseReturn_List  group  by Purchase_ID) RL on P.ID=RL.Purchase_ID left join T10100_Supplier S on  P.Supplier_ID=S.ID where P.State=1 and  P.SumQty>isnull(RL.SumRLQty,0) "
    Public Const SQL_PurchaseAsk_GetPurchase As String = " select PL.ID as SG_ID,PL.Line ,PL.WL_ID ,W.WL_No ,W.WL_Name,W.WL_Spec,W.WL_Unit ,PL.Price ,PL.Qty,PL.Amount from T20001_Puchase_List PL left join T10001_WL W on PL.WL_ID =W.ID left join T20000_Puchase_Table PT on PL.ID =PT.ID where PT.State =1" & _
                                                         " and not exists (select * from T20011_PurchaseAsk_List L where PL.ID =L.SG_ID and PL.WL_ID =L.WL_ID  ) "
    ' " and PL.ID not in (select SG_ID from dbo.T20011_APurchase_link_Purchase) and PL.WL_ID not in (select WL_ID from dbo.T20011_APurchase_link_Purchase) "
    '    Public Const SQL_PurchaseReturn_GetLines As String = "Select P.*,isnull(RL.SumRLQty,0) as SumRLQty ,L.Qty-isnull(SumRLQty,0) as CanReturn  from  T20001_Puchase_List P left join (Select Purchase_ID, WL_ID, sum(isnull(Qty,0)) as SumRLQty from  T20011_PurchaseReturn_List  group  by Purchase_ID,WL_ID) RL on P.ID=RL.Purchase_ID and P.WL_ID=RL.WL_ID where  p.Qty>isnull(RL.SumRLQty,0) "
#End Region

    ''' <summary>
    ''' 获取采购明细
    ''' </summary>
    ''' <param name="idList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_SelListByIdList(ByVal idList As List(Of String)) As DtReturnMsg

        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(" select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit, L.Qty-isnull(SumRLQty,0) as CanReturn  from (select * from T20001_Puchase_List ")

        sqlBuider.Append("where ID in (")
        For Each id In idList
            sqlBuider.Append("'")
            sqlBuider.Append(id)
            sqlBuider.Append("', ")
        Next
        sqlBuider.Append("'') ")
        sqlBuider.Append(")L left join (Select Purchase_ID, WL_ID, sum(isnull(Qty,0)) as SumRLQty from  T20011_PurchaseReturn_List  group  by Purchase_ID,WL_ID) RL on L.ID=RL.Purchase_ID and L.WL_ID=RL.WL_ID ")
        sqlBuider.Append(" left join T10001_WL WL on WL.id=l.WL_ID  order by L.ID")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString)
    End Function

    ''' <summary>
    ''' 获取申购单
    ''' </summary>
    ''' <param name="oList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PurchaseAsk_GetPurchase(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_PurchaseAsk_GetPurchase)
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Purchase_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

End Class