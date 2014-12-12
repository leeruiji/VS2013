Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F28000_Employees_JT
    Dim isLoaded As Boolean = False
    Dim isColse As Boolean = False
    Dim dtList As DataTable
    Dim dtState As DataTable


    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
    End Sub


    Private Sub F30100_Process_AfterLoad() Handles Me.AfterLoad
        TB_ID.Focus()
    End Sub

    Private Sub F30940_Employees_JT_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If (e.KeyCode = Keys.Enter And e.Control) Then
            Save()
        End If
    End Sub

    Private Sub F30940_Employees_JT_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        isColse = True
    End Sub


    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Dim serDay As Date = GetDate()
        DP_Start.Value = New Date(serDay.Year, serDay.Month, 1)
        Dp_End.Value = serDay
        TB_eDate.Value = GetDate().AddDays(-1)
        CB_State.ComboBox.DisplayMember = "Field"
        CB_State.ComboBox.ValueMember = "DB_Field"
        CB_State.ComboBox.DataSource = Dao.Process_GetEm_State
        Cb_Gx.ComboBox.DisplayMember = "GxName"
        Cb_Gx.ComboBox.ValueMember = "ID"
        Cb_Gx.ComboBox.DataSource = Dao.GetDefauleGx.Dt
        Fg_Spec.Cols("EmployeesID").Editor = CB_UserID
        Me_Refresh()
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.ProcessUser_GetByOption(GetFindOtions)
        If msg.IsOk Then          
            Fg1.DtToFG(msg.Dt)
        End If
    End Sub


#Region "Fg事件"

#End Region

    ''' <summary>
    ''' 获取员工指令单数量
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetFrom() As DataTable
        Dim dr As DataRow
        Dim Dt As DataTable = dtList.Clone
        For i As Integer = 1 To Fg_Spec.Rows.Count - 1
            dr = Dt.NewRow
            dr("Produce_No") = Fg1.Item(Fg1.RowSel, "Produce_No")
            dr("GX") = Cb_Gx.ComboBox.SelectedValue
            dr("EmployeesID") = Fg_Spec.Item(i, "EmployeesID")
            dr("ZhengPin") = Val(Fg_Spec.Item(i, "ZhengPin"))
            dr("FeiPin") = Val(Fg_Spec.Item(i, "FeiPin"))
            dr("Date") = Fg_Spec.Item(i, "Date")
            Dt.Rows.Add(dr)
        Next
        Return Dt
    End Function




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

    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
    End Sub

#Region "搜索工具栏"

    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "T.SDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = Dp_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)

        If TB_ID.Text <> "" Then
            fo = New FindOption
            fo.DB_Field = "L.ID"
            fo.Value = TB_ID.Text
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "Client_ID"
            fo.Value = Val(TSC_Client.IDValue)
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If CB_State.ComboBox.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = CB_State.SelectedItem.DB_Field
            fo.Value = CB_State.SelectedItem.Value
            fo.Field_Operator = CB_State.SelectedItem.Field_Operator
            oList.FoList.Add(fo)
        End If
        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Search.Click
        Me.Me_Refresh()
    End Sub

    Private Sub Fg_Spec_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg_Spec.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg_Spec.LastKey = Keys.Enter Then
            Fg_Spec.LastKey = 0
            Select Case Fg_Spec.Cols(e.Col).Name
                Case "EmployeesID"
                    Fg_Spec.GotoNextCell(e.Col)

                Case "ZhengPin"
                    Fg_Spec.GotoNextCell(e.Col)
                Case "FeiPin"
                    Fg_Spec.GotoNextCell(e.Col)
                Case "Date"
                    Fg_Spec.GotoNextCell(e.Col)
                Case Else
                    Fg_Spec.GotoNextCell(e.Col)
            End Select
            Fg_Spec.LastKey = 0
        End If

    End Sub

    Private Sub Fg_Spec_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg_Spec.NextCell
        Select Case e.Col
            Case "EmployeesID"
                Fg_Spec.Item(e.Row, "Date") = TB_eDate.Value
                e.ToCol = Fg_Spec.Cols("ZhengPin").Index
            Case "ZhengPin"
                e.ToCol = Fg_Spec.Cols("FeiPin").Index
            Case "FeiPin"
                e.ToCol = Fg_Spec.Cols("Date").Index
            Case "Date"
                If e.Row + 2 > Fg_Spec.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg_Spec.Cols("EmployeesID").Index
            Case Else
                e.ToCol = Fg_Spec.Cols("EmployeesID").Index
        End Select
    End Sub


    Private Sub Fg_Spec_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg_Spec.EnterCell
        If Fg_Spec.RowSel < 0 Then
            Exit Sub
        End If
        If Fg_Spec.Cols(Fg_Spec.ColSel).AllowEditing AndAlso Fg_Spec.CanEditing Then
            Fg_Spec.LastKey = 0
            Fg_Spec.StartEditing()
        End If
    End Sub

#End Region

#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PreView_All.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_ButtonDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Print.ButtonDoubleClick

    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print_All.Click
        Print(OperatorType.Print)
    End Sub


    Protected Sub Print(ByVal DoOperator As OperatorType, Optional ByVal IsSel As Boolean = False)

    End Sub


    '打印选择项
    Private Sub Cmd_Print_Sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print_Sel.Click
        Print(OperatorType.Print, True)
    End Sub
    Private Sub Cmd_Preview_Sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview_Sel.Click
        Print(OperatorType.Preview, True)
    End Sub


#End Region

    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow()
        Fg_Spec.AddRow()
    End Sub

    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        Fg1.Focus()

        For i As Integer = Fg_Spec.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg_Spec.Item(i, "EmployeesID")) = 0 Then
                    Fg_Spec.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next

        If TB_GZ.Text = "" Then
            ShowErrMsg("工价不能为空")
            Return False
        End If
        Return True
    End Function

    Private Sub Save()
        If CheckForm() = True Then
            Dim dt As DataTable = GetFrom()
            Dim R As MsgReturn = Dao.ProcessUser_Save(dt)
            If R.IsOk Then
                TB_ID.Focus()
            End If
        End If
    End Sub

    Private Sub Fg1_SelectRowChange(ByVal Row As Integer) Handles Fg1.SelectRowChange
        dtList = Dao.GetJT(Fg1.Item(Row, "Produce_No"), Cb_Gx.ComboBox.SelectedValue).Dt
        Fg_Spec.DtToFG(dtList)
    End Sub

    Private Sub TSM_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_Add.Click
        AddRow()
    End Sub

    Private Sub TSM_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_Del.Click
        Fg_Spec.RemoveRow()
    End Sub

    Private Sub TSM_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_Save.Click
        Save()
    End Sub

    Private Sub TSM_CanSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_CanSel.Click
        ShowConfirm("是否取消指令单状态", AddressOf CanSelDan, AddressOf Donothing)
    End Sub

    Private Sub CanSelDan()
        Save()
    End Sub

    Private Sub DoNothing()

    End Sub



    Private Sub Cb_Gx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Gx.SelectedIndexChanged
        'If Cb_Gx.ComboBox.SelectedValue <> 0 Then
        '    If CB_UserID.SearchID <> Cb_Gx.ComboBox.SelectedValue.ToString Then
        '        CB_UserID.SetSearchEmpty()
        '    End If
        '    CB_UserID.SearchType = cSearchType.ENum_SearchType.Department
        '    CB_UserID.SearchID = Cb_Gx.ComboBox.SelectedValue
        'End If
        'Me_Refresh()
    End Sub


    Private Sub CB_UserID_Col_SelRow(ByVal Dr As System.Data.DataRow) Handles CB_UserID.Col_SelRow
        Fg_Spec.Item(Fg_Spec.RowSel, "Employee_ID") = Dr("ID")
        Fg_Spec.GotoNextCell("EmployeesID")
    End Sub

    Private Sub TB_ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me_Refresh()
            TB_GZ.Focus()
            TB_GZ.SelectAll()
        End If
    End Sub

    Private Sub TB_GZ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_GZ.KeyDown
        If e.KeyCode = Keys.Enter Then
            Fg_Spec.Focus()
            Fg_Spec.StartEditing()
        End If
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        Save()
    End Sub

   
End Class

Partial Friend Class Dao


    Public Const SQL_Process_Set_User = "Select L.Produce_No,L.UPD_USER ,L.Produce_Qty, Client_ID,C.Client_Name,WL_ID,WL.WL_No,WL.WL_Name,WL.WL_material,WL.WL_Center,WL.WL_side,WL.WL_Spec,ClientOrderID From T27121_Schedule_List L Left join  T10110_Client  C ON L.Client_ID=C.ID  Left join  T10001_WL WL ON L.WL_ID=WL.ID Left join T27120_Schedule_Table T On T.ID=L.ID  "

    Public Const SQL_Process_OrderByJT As String = " order by  L.ID"

    Private Const Produce_GetUser As String = "Select * from T28000_Employees_JT Where Produce_No=@Produce_No And GX=@GX "


    ''' <summary>
    ''' 获取员工细单录入状态
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Process_GetEm_State() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption

        fo = New FindOption
        fo.Field = "全部"
        fo.Value = -2
        fo.DB_Field = -1
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "未录入"
        fo.Value = 1
        fo.DB_Field = 1
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已录入"
        fo.Value = 2
        fo.DB_Field = 2
        foList.Add(fo)

        Return foList
    End Function


    ''' <summary>
    ''' 按条件获取进度表列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessUser_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Process_Set_User)
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Process_OrderByJT)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function


    ''' <summary>
    ''' 加载工序
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDefauleGx() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt("Select ID, GxName from GongXu  Order by GX_No")
    End Function


    ''' <summary>
    ''' 获取计提
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="GX"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetJT(ByVal id As String, ByVal GX As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("Produce_No", id)
        P.Add("GX", GX)
        Return PClass.PClass.SqlStrToDt(Produce_GetUser, P)

    End Function




    ''' <summary>
    '''修改一个备注
    ''' </summary>
    ''' <returns></returns>
    ''' <LCProjects></LCProjects>
    Public Shared Function ProcessUser_Save(ByVal dtTable As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BillTypeName As String = ""
        sqlMap.Add("List", Produce_GetUser)
        paraMap.Add("Produce_No", dtTable.Rows(0)("Produce_No"))
        paraMap.Add("GX", dtTable.Rows(0)("GX"))
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                DvToDt(dtTable, H.DtList("List"), New List(Of String), False)
                Dim TimSQL As New Dictionary(Of String, String)
                If H.UpdateAll(True, TimSQL, paraMap).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                    R.IsOk = True
                    R.Msg = "修改成功!"
                Else
                    R.IsOk = False
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "修改错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using
    End Function



End Class