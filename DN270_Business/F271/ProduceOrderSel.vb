Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport
Imports PClass.BaseForm

Public Class ProduceOrderSel
    Dim isLoaded As Boolean = False

    Dim StoreInType As Enum_StoreIn_Type
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Choose)

    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        SumFG2.AddSum()
    End Sub




    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"
        Dao.ProduceOrder_DB_NAME = Ch_Name
        '默认时间不可选
        'CB_SearchByDate.Checked = False
        FG1.IniFormat()
        FG1.IniColsSize()
        DP_Start.Value = Today
        DP_End.Value = Today
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        CB_ConditionName1.ComboBox.DataSource = Dao.ProduceOrder_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = "Field"
        CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.ProduceOrder_GetConditionNames()
        CB_Condition3.ComboBox.DisplayMember = "Field"
        CB_Condition3.ComboBox.ValueMember = "DB_Field"
        CB_Condition3.ComboBox.DataSource = Dao.ProduceOrder_GetCondition3
        Me_Refresh()
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.ProduceOrderSel_GetByOption(GetFindOtions)
        If msg.IsOk Then
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))
            For Each dr In msg.Dt.Rows
                dr("IsChecked") = False
            Next
            Dim dt As DataTable = TryCast(Me.F_RS_Obj, DataTable)
            Fg1.DtToFG(DtDelDV(dt, msg.Dt))
            SumFG2.AddSum()
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
    Public SelectReturn As Boolean = False

#Region "控件事件"
    Private Sub Edit_Return()
        If ReturnId <> "" Then
            SelectReturn = True
            Me_Refresh()
        End If
    End Sub
    Private Sub Cmd_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Refresh.Click
        Me_Refresh()
    End Sub


    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Click
        If Fg1.ColSel = Fg1.Cols("IsChecked").Index Then
            Fg1.Item(Fg1.RowSel, "IsChecked") = Not Fg1.Item(Fg1.RowSel, "IsChecked")
        End If
    End Sub

    ''' <summary>
    ''' 删除相同内容
    ''' </summary>
    ''' <param name="DT"></param>
    ''' <param name="DV"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function DtDelDV(ByVal DT As DataTable, ByVal DV As DataTable) As DataTable
        DT.AcceptChanges()
        For i As Integer = 0 To DT.Rows.Count - 1
            For m As Integer = DV.Rows.Count - 1 To 0 Step -1
                If DT.Rows(i)("ProduceOrderID") = DV.Rows(m)("ProduceOrderID") AndAlso DT.Rows(i)("WL_ID") = DV.Rows(m)("WL_ID") Then
                    DV.Rows.RemoveAt(m)
                    Continue For
                End If
            Next
        Next
        Return DV
    End Function



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    ''' <summary>
    ''' 获取生产单号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetProID(ByVal dates As String) As String
        Dim ReID As String = ""
        Return ReID
    End Function

#End Region

#Region "搜索工具栏"


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
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "T.sDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)

        fo = New FindOption
        fo.DB_Field = "isFinish"
        fo.Value = 0
        fo.Field_Operator = Enum_Operator.Operator_Equal
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

    Private Sub Cmd_Choose_Click(sender As Object, e As EventArgs) Handles Cmd_Choose.Click

        CB_Condition3.Focus()
        Dim FGdt As DataTable = TryCast(Fg1.DataSource, DataTable)
        Dim drs() As DataRow = FGdt.Select("IsChecked=True")
        Dim dt As DataTable = FGdt.Clone
        For Each dr As DataRow In drs
            dt.ImportRow(dr)
        Next
        Me.LastForm.ReturnObj = dt
        Me.Close()
    End Sub


End Class

Partial Friend Class Dao

    '===================入库单信息==============
    Public Const SQL_ProduceOrderSel_GetByOption = "  SELECT L.ID As ProduceOrderID ,T.ClientOrderID, T.Client_ID,T.Client_Name,C.Client_No,T.UPD_USER, L.WL_ID,WL.WL_No,WL.WL_Name,L.WL_Center,L.WL_Spec,L.WL_material,L.WL_side,WL.RWL_No,WL.RWL_Spec,CT.eDate ,   " & _
                                                   "  ISNULL(L.Produce_Qty ,0)-ISNULL(L.s_Qty,0 )As Qty , ISNULL(L.Produce_Qty ,0)-ISNULL(L.s_Qty,0 )As Produce_Qty" & _
                                                  "  FROM T27111_ProduceOrder_List L Left join T27110_ProduceOrder_Table T ON L.ID=T.ID Left join T10001_WL WL ON WL.ID=L.WL_ID Left join  T10110_Client C On C.ID=T.Client_ID left join T27000_ClientOrder_Table CT On CT.ID=T.ClientOrderID  "

    Public Const SQL_ProduceOrderSel_OrderBy As String = " order by CT.eDate,ProduceOrderID "



    



    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceOrderSel_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "单据编号"
        fo.DB_Field = "ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料名称"
        fo.DB_Field = "WL_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T10001_WL TW,T20201_StoreIn_List TL where %WL_Name% and TL.wl_id=TW.ID and T20200_StoreIn_Table.id=TL.id)"
        fo.Sign = "%WL_Name%"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "模糊搜索"
        fo.DB_Field = " "
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "(ID %Like% or SumQty %Like% or SumAmount %Like% or Remark %Like%  )"
        fo.Sign = "%Like%"
        foList.Add(fo)

        Return foList
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceOrderSel_GetCondition3() As List(Of FindOption)
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
    ''' 按条件获取入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceOrderSel_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_ProduceOrderSel_GetByOption)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_ProduceOrderSel_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



End Class