Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport


Public Class F40000_BZSH
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)

        If CheckRight(ID, ClassMain.Price) Then
            Fg2.Cols("Price").Visible = True
            Fg2.Cols("Amount").Visible = True

            Fg2.Cols("Price_ZhiTong").Visible = True
            Fg2.Cols("Price_JiaoDai").Visible = True

            Fg2.Cols("Amount_ZhiTong").Visible = True
            Fg2.Cols("Amount_JiaoDai").Visible = True

            Fg2.Cols("Amount_GH").Visible = True


        Else
            Fg2.Cols("Price").Visible = False
            Fg2.Cols("Amount").Visible = False

            Fg2.Cols("Price_ZhiTong").Visible = False
            Fg2.Cols("Price_JiaoDai").Visible = False

            Fg2.Cols("Amount_ZhiTong").Visible = False
            Fg2.Cols("Amount_JiaoDai").Visible = False
            Fg2.Cols("Amount_GH").Visible = False
        End If
    End Sub

    Private Sub F40000_BZSH_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        Fg2.FG_ColResize()
        SumFG1.AddSum()
        SumFG2.AddSum()
    End Sub
    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        Me.MeIsLoad = False
        isRowChang = False
    End Sub
    Private Sub F10100_BZSH_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"



        Cmd_ShowList.Checked = My.Settings.ShowMx
        Cmd_ShowList_Click(Cmd_ShowList, New EventArgs)

        FG1.IniFormat()
        FG1.IniColsSize()
        DP_Start.Value = Today
        Dp_End.Value = Today
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.BZSH_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.BZSH_GetConditionNames()

        CB_Condition3.ComboBox.DisplayMember = "Field"
        CB_Condition3.ComboBox.ValueMember = "DB_Field"
        CB_Condition3.ComboBox.DataSource = Dao.BZSH_GetCondition3
        If Val(Me.P_F_RS_ID) <> 0 And Me.P_F_RS_ID2 <> "" Then
            DP_Start.Value = New Date(1999, 1, 1)
            TSC_Client.IDValue = Val(Me.P_F_RS_ID)
            TSC_Client.Text = P_F_RS_ID2
        End If
        Me_Refresh()
        isLoaded = True
    End Sub

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
            '   msg.Dt.Columns.Add("State_User", GetType(String))
            msg.Dt.Columns.Add("StateName", GetType(String))
            msg.Dt.Columns.Add("IsChecked", GetType(Boolean))
            Dim Dt As DataTable

            If SelectRetrun Then
                Dt = TryCast(FG1.DataSource, DataTable)
                If Dt Is Nothing Then
                    Dt = msg.Dt
                Else
                    BaseClass.ComFun.DtReFreshRow(Dt, msg.Dt, "BZSH_ID", ReturnId)
                End If
            Else
                Dt = msg.Dt
            End If

            If SelectRetrun Then
                SelectRetrun = False
            Else
                FG1.DtToFG(Dt)
            End If
            SumFG1.ReSum()
            FG1.SortByLastOrder()
            Dim sumQty As Integer = 0
            Dim sumZL As Double = 0
            For Each dr As DataRow In msg.Dt.Rows
                sumQty += IsNull(dr("SumQty"), 0)
                sumZL += IsNull(dr("SumCWeight"), 0)
                dr("Printed") = IsNull(dr("Printed"), False)
                Dim _state As Integer = IsNull(dr("State"), 0)
                dr("StateName") = BaseClass.ComFun.GetBZSH_StateName(_state)

                dr("IsChecked") = False
            Next

            LB_Luose_Qty.Text = FormatNum(sumQty)
            LB_LuoSe_ZL.Text = FormatZL(sumZL)
            FG1.RowSetForce("BZSH_ID", ReturnId)
            If msg.IsOk = False OrElse msg.Dt.Rows.Count = 0 Then
                '  Fg2.Rows.Count = 1
                Fg2.DtToFG(New DataTable("T"))
            End If
        Else
            FG1.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
        Nohide = False
    End Sub

    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.BZSH_GetByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)

#End Region
    Public SelectRetrun As Boolean = False

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            SelectRetrun = True
            Me_Refresh()
        End If
    End Sub


    Private Sub F40000_BZSH_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        'Select Case e.KeyChar
        '    Case vbCr
        '    Case Else
        '        If TB_ConditionValue1.Focused = False AndAlso CB_ConditionValue2.Focused = False AndAlso TB_BZ_ID.TextBox.Focused = False AndAlso TB_Client.TextBox.Focused Then
        '            If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
        '                If TB_ConditionValue1.Text.Length > 0 Then TB_ConditionValue1.Text = TB_ConditionValue1.Text.Substring(0, TB_ConditionValue1.Text.Length - 1)
        '                TB_ConditionValue1.Focus()
        '            Else
        '                TB_ConditionValue1.Text = e.KeyChar
        '                TB_ConditionValue1.Focus()
        '            End If
        '            If CB_ConditionName1.SelectedIndex = 0 AndAlso CB_ConditionName1.Items.Count > 1 Then
        '                CB_ConditionName1.SelectedIndex = 1
        '            End If
        '        End If
        'End Select
    End Sub


#Region "控件事件"
    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If TSC_BZ.SearchID <> ID Then
            TSC_BZ.Text = ""
            TSC_BZ.IDValue = 0
        End If
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZ.SearchID = ID
    End Sub

    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0
    End Sub



    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim F As New F40001_BZSH_Msg("")
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
        ShowModify()
    End Sub

    Sub ShowModify()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的送货单")
            Exit Sub
        End If
        Dim F As New F40001_BZSH_Msg(FG1.SelectItem("BZSH_ID"))
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
        Cmd_Modify_Click(FG1, e)
    End Sub


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的送货单")
            Exit Sub
        End If
        ShowConfirm("是否删除送货单 [" & FG1.SelectItem("BZSH_ID") & "]?", AddressOf DelBZSH)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelBZSH()
        Dim msg As MsgReturn = Dao.BZSH_Del(FG1.SelectItem("BZSH_ID"))
        If msg.IsOk Then
            ReturnId = FG1.SelectItem("BZSH_ID")
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
    'Private Sub CB_ConditionName1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName1.SelectedIndexChanged
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName1.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue1.ComboBox.DataSource = msg.Dt

    '    End If
    'End Sub

    Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged
        If isLoaded Then
            If CB_ConditionName2.ComboBox.SelectedIndex = 0 Then
                CB_ConditionValue2.SelectedIndex = -1
                Exit Sub
            End If
            Dim oList As OptionList = GetFindOtions()
            Dim SQLstr As String
            If CB_ConditionName2.SelectedIndex <> 1 Then
                SQLstr = "(" & oList.Sql & ")Con left join T40001_BZSH_List li on  Con.BZSH_ID=li.BZSH_ID"
            Else
                SQLstr = "(" & oList.Sql & ")Con"
            End If
            Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues(SQLstr, CB_ConditionName2.ComboBox.SelectedValue, "")
            If msg.IsOk Then
                CB_ConditionValue2.ComboBox.DataSource = msg.Dt
            End If
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


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        '   oList.Sql = SQL_BZSH_Get_Sel
        Dim sqlbuider As New StringBuilder(SQL_BZSH_Get_Sel)
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "BZSH_Date"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)



        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "P.Client_ID"
            fo.Value = TSC_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If



        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "BZ_ID"
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            goodsCount = 1
            oList.FoList.Add(fo)
        End If



        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue
            If fo.DB_Field = "BZ_ID" Then
                goodsCount = 1

            ElseIf fo.DB_Field = "BZ_Name" OrElse fo.DB_Field = "BZ_No" Then
                goodsCount = 2

            End If
            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = Enum_Operator.Operator_Like_Both

            If fo.DB_Field = "GH" Then

                fo.SQL = " exists(SELECT * FROM T40001_BZSH_List where  %Like% and P.BZSH_ID=BZSH_ID) "
                fo.Sign = "%Like%"
            End If

            oList.FoList.Add(fo)
        End If



        If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
            If fo.DB_Field = "BZ_ID" Then
                goodsCount = 1
            ElseIf fo.DB_Field = "BZ_Name" OrElse fo.DB_Field = "BZ_No" Then
                goodsCount = 2
            End If
            fo.Value = CB_ConditionValue2.ComboBox.Text
            fo.Field_Operator = Enum_Operator.Operator_Like

            If fo.DB_Field = "GH" Then
                fo.Field_Operator = Enum_Operator.Operator_Like_Both
                fo.SQL = " exists(SELECT * FROM T40001_BZSH_List where  %Like% and P.BZSH_ID=BZSH_ID) "
                fo.Sign = "%Like%"
            End If



            oList.FoList.Add(fo)
        End If

        If goodsCount = 1 Then
            sqlbuider.Append(", List.BZ_ID ")
            sqlbuider.Append(SQL_BZSH_Get_Body)
            sqlbuider.Append(SQL_BZSH_Get_leftJoin_BZID)
        ElseIf goodsCount = 2 Then
            sqlbuider.Append(", List.BZ_No,List.BZ_Name ")
            sqlbuider.Append(SQL_BZSH_Get_Body)
            sqlbuider.Append(SQL_BZSH_Get_leftJoin_GoodsName)
        Else

            sqlbuider.Append(SQL_BZSH_Get_Body)

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
            fo.DB_Field = "BZSH_ID"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If



        '   sqlbuider.Append(SQL_BZSH_OrderBy)
        oList.Sql = sqlbuider.ToString
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
        Dim R As New R40001_BZSH(CheckRight(ID, ClassMain.CanExcelOut))
        R.Start(FG1.Item(FG1.RowSel, "BZSH_ID"), DoOperator)
    End Sub

#End Region


#Region "显示明细"
    Dim isRowChang = True
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
        Dim msg As DtReturnMsg = Dao.BZSH_GetListById(IsNull(FG1.SelectItem("BZSH_ID"), ""))
        If msg.IsOk Then
            For Each R As DataRow In msg.Dt.Rows
                If IsNull(R("BZC_Name"), "") = "" Then
                    R("BZC_Name") = IsNull(R("BzcMsg"), "").ToString.Split(vbCrLf)(0)
                End If
            Next
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

    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If FG1.SelectItem Is Nothing OrElse IsNull(FG1.SelectItem("BZSH_ID"), "") = "" Then
            Exit Sub
        End If
        If SplitContainer1.Panel2Collapsed = False Then
            Mx_ReFresh()
        End If

    End Sub
End Class

Partial Class Dao

#Region "送货单"
    Private Const BZSH_DB_NAME As String = "送货单"

    ''' <summary>
    ''' 获取对送货单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZSH_GetBZSHByidWhithClientName, "@BZSH_ID", sId)
    End Function

    ''' <summary>
    ''' 获取对送货单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZSH_GetBZSHListByid, "@BZSH_ID", sId)
    End Function

    '''' <summary>
    '''' 获取所有送货单
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function BZSH_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_BZSH_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_BZSH_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_BZSH_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "送货单号"
        fo.DB_Field = "P.BZSH_ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户编号"
        fo.DB_Field = "P.Client_ID"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "车牌"
        fo.DB_Field = "P.ChePai"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "司机"
        fo.DB_Field = "P.SiJi"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "布种名称"
        fo.DB_Field = "BZ_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "布种编号"
        fo.DB_Field = "BZ_No"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "GH"

        foList.Add(fo)





        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取送货单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(oList.Sql)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_BZSH_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetNewId(ByVal D As Date) As RetrunNewIdMsg
        Dim R As New RetrunNewIdMsg
        R.MaxDate = Maxdate.AddDays(1)
        Try
            If D.Date <= Maxdate Then
                R.NewIdDate = Maxdate.AddDays(1)
                R.IsTheDate = False
                R.RetrunMsg = "你选择的日期小于或等于日结日期!"
            Else
                R.NewIdDate = D
                R.IsTheDate = True
                R.RetrunMsg = "获取" & BZSH_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T40000_BZSH_Table")
            paraMap.Add("@Id_Str", "SH")
            paraMap.Add("@Field", "BZSH_ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & BZSH_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & BZSH_DB_NAME & "单号失败!" & ex.Message
            Return R
        End Try
    End Function




    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable, Optional ByVal Supplier_Name_New As String = "") As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BZSHId As String = dtTable.Rows(0)("BZSH_ID")
        paraMap.Add("BZSH_ID", BZSHId)
        Try
            sqlMap.Add("Table", SQL_BZSH_SelByid)
            sqlMap.Add("List", SQL_BZSH_SelListByid)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then

                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As New System.Text.StringBuilder("insert into Bill_Barcode (No_ID,NO_Type)values('" & BZSHId & "'," & BillType.BZSH & ")" & vbCrLf)
                TmSQL.AppendLine(ComFun.SQL_Log)
                paraMap.Add("ID", BZSHId)
                paraMap.Add("BillType", BillType.BZSH)
                paraMap.Add("State", dtTable.Rows(0)("State"))
                paraMap.Add("StateName", ComFun.GetStateName(dtTable.Rows(0)("State")))
                paraMap.Add("ChagneUser", User_Display)
                DtToUpDate(msg, TmSQL.ToString, paraMap)
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]添加成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]已经存在!,请双击编号文本框,获取新编号!"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]添加错误!"
            DebugToLog(ex)
            Return msg
        Finally
        End Try
    End Function





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BZSHId As String = dtTable.Rows(0)("BZSH_ID")
        paraMap.Add("BZSH_ID", BZSHId)
        Try
            sqlMap.Add("Table", SQL_BZSH_SelByid)
            sqlMap.Add("List", SQL_BZSH_SelListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                Dim TmSQL As New System.Text.StringBuilder("")
                TmSQL.AppendLine(ComFun.SQL_Log)
                paraMap.Add("ID", BZSHId)
                paraMap.Add("BillType", BillType.BZSH)
                paraMap.Add("State", dtTable.Rows(0)("State"))
                paraMap.Add("StateName", "修改")
                paraMap.Add("ChagneUser", User_Display)
                DtToUpDate(msg, TmSQL.ToString, paraMap)
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]修改成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]不存在"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & BZSH_DB_NAME & "[" & dtTable.Rows(0)("BZSH_ID") & "]修改错误"
            DebugToLog(ex)
            Return msg
        Finally

        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZSHId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_Del(ByVal BZSHId As String)
        Dim P As New Dictionary(Of String, Object)
        P.Add("@BZSH_ID", BZSHId)
        P.Add("BillType", BillType.BZSH)
        P.Add("State", -1)
        P.Add("StateName", "删除")
        P.Add("ChagneUser", User_Display)
        Return RunSQL(SQL_BZSH_DelBZSHByid & vbCrLf & "insert into T10080_BillStateLog (BillType,ID,State,StateName,ChangeTime,ChagneUser)values(@BillType,@BZSH_ID,@State,@StateName,Getdate(),@ChagneUser) ", P)
    End Function

    ''' <summary>
    ''' 获取运转单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_GetByID_WithName, "@GH", sId)
    End Function
    ''' <summary>
    ''' 检查成品入库
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_RGetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_RGetByID_WithName, "@GH", sId)
    End Function
    ''' <summary>
    ''' 检查成品库存
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_RSGetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Produce_RSGetByID_WithName, "@GH", sId)
    End Function
#End Region

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetCondition3() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "新建"
        fo.DB_Field = Enum_BZSHState.AddNew
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已确认"
        fo.DB_Field = Enum_BZSHState.Store_Comfirm
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已审核"
        fo.DB_Field = Enum_BZSHState.Audited
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "已作废"
        fo.DB_Field = Enum_BZSHState.Invoid
        foList.Add(fo)

        Return foList
    End Function
End Class