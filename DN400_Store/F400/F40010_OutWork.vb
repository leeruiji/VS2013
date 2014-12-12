Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F40010_OutWork
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        FG2.FG_ColResize()
        SumFG1.AddSum()
        SumFG2.AddSum()
    End Sub


    Private Sub F10100_OutWork_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        FG1.IniFormat()
        FG1.IniColsSize()
        Cmd_ShowList.Checked = My.Settings.ShowMx
        Cmd_ShowList_Click(Cmd_ShowList, New EventArgs)
        DP_Start.Value = New Date(Now.Year, Now.Month, 1).Date
        DP_End.Value = Today
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName1.ComboBox.DataSource = Dao.OutWork_GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        CB_ConditionName2.ComboBox.DataSource = Dao.OutWork_GetConditionNames()

        CB_State.ComboBox.DisplayMember = "Field"
        CB_State.ComboBox.ValueMember = "DB_Field"
        CB_State.ComboBox.DataSource = Dao.OutWork_GetCondition3
        CB_State.ComboBox.SelectedIndex = 1


        Me_Refresh()
        isLoaded = True
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles MyBase.Me_Closing
        Me.MeIsLoad = False
        isRowChang = False
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
            msg.Dt.Columns.Add("StateName", GetType(String))
            For Each dr As DataRow In msg.Dt.Rows
                dr("StateName") = ComFun.GetBZSH_StateName(IsNull(dr("State"), 0))
            Next
            FG1.DtToFG(msg.Dt)
            SumFG1.ReSum()
            FG1.SortByLastOrder()
            FG1.RowSetForce("ID", ReturnId)
        Else
            FG1.Rows.Count = 1
            Fg2.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
        Nohide = False
    End Sub

    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.OutWork_GetByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)

#End Region


    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub


    Private Sub F40000_OutWork_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
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
        Dim F As New F40011_OutWork_Msg("")
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
            ShowErrMsg("请选择一个要修改的外发加工单")
            Exit Sub
        End If
        Dim F As New F40011_OutWork_Msg(FG1.SelectItem("ID"))
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
            ShowErrMsg("请选择一个要修改的外发加工单")
            Exit Sub
        End If
        If IsNull(FG1.Item(FG1.RowSel, "State"), 0) >= 0 Then
            ShowErrMsg("外发加工单未作废不能删除")
            Exit Sub
        End If

        ShowConfirm("是否删除外发加工单 [" & FG1.SelectItem("ID") & "]?", AddressOf DelOutWork)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelOutWork()
        Dim msg As MsgReturn = Dao.OutWork_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            Me_Refresh()
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
        If CB_ConditionName2.ComboBox.SelectedIndex = 0 Then
            CB_ConditionValue2.SelectedIndex = -1
            Exit Sub
        End If
        Dim oList As OptionList = GetFindOtions()
        Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & Dao.SQL_OutWork_GetByOption & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "")
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


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption

        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "OutWork_Date"
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

        If CB_State.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Value = CB_State.ComboBox.SelectedValue
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
        Dim R As New R40011_Outwork
        R.Start(FG1.Item(FG1.RowSel, "ID"), DoOperator)
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
        Mx_ReFresh()
    End Sub
    Private Sub Mx_ReFresh()
        If FG1.RowSel < 1 Then
            Fg2.Rows.Count = 1
            Exit Sub
        End If
        If isRowChang = False Then
            isRowChang = True
            Exit Sub
        End If
        Dim msg As DtReturnMsg = Dao.OutWork_GetListById(IsNull(FG1.SelectItem("ID"), ""))
        If msg.IsOk Then
            Fg2.DtToFG(msg.Dt)
            SumFG2.ReSum()
        Else
            Fg2.DtToFG(New DataTable("T"))

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

    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If FG1.SelectItem Is Nothing OrElse IsNull(FG1.SelectItem("ID"), "") = "" Then
            Exit Sub
        End If
        If SplitContainer1.Panel2Collapsed = False Then
            Mx_ReFresh()
        End If

    End Sub
End Class


Partial Class Dao
#Region "外发加工单信息"


    '===================外发加工单信息==============




    Public Const SQL_OutWork_GetOutWorkByid As String = "select top 1 * from T40002_OutWork_Table  where ID=@ID"

    Public Const SQL_OutWork_GetOutWorkListByid As String = "select P.* ,BZ.BZ_No,BZ.BZ_Name,BZC.BZC_No,BZC.BZC_Name,C.Client_No,C.Client_Name from T40003_OutWork_List  P left join T10002_BZ BZ on BZ.ID=P.BZ_ID  left join T10003_BZC BZC on BZC.ID=P.BZC_ID left Join T10110_Client C on P.Client_ID=C.ID  where P.ID=@ID"

    Public Const SQL_OutWork_GetOutWorkListByid_ForReport As String = "select P.* ,C.Client_Name, BZ.BZ_No + '#' +BZ.BZ_Name as BZ_Name ,isNull( Client_Bzc,'') +'#'+BZC.BZC_Name+' GY-' + right('00000' + BZC.BZC_No,6) as BZC_Name ,G.Date_LuoSe from T40003_OutWork_List  P " & _
    " left join T30000_Produce_Gd G on P.GH=G.GH " & _
    " left join T10002_BZ BZ on BZ.ID=G.BZ_ID   " & _
    "left Join T10110_Client C on G.Client_ID=C.ID " & _
    " left join T10003_BZC BZC on BZC.ID=G.BZC_ID  where P.ID=@ID order by P.ID"

    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_OutWork_GetByOption As String = "select T.*,J.JGDW_No as JGDW_No,J.JGDW_Name as JGDW_Name from T40002_OutWork_Table  T left join T10130_JGDW J on T.JGDW_ID=J.ID "
    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_OutWork_SelByid As String = "select top 1 * from T40002_OutWork_Table  where ID=@ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_OutWork_SelListByid As String = "select  * from T40003_OutWork_List  where ID=@ID"
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_OutWork_DelOutWorkByid As String = "Delete from  T40002_OutWork_Table where ID=@ID "

    Public Const SQL_OutWork_OrderBy As String = " order by OutWork_Date "



    Public Const SQL_Produce_GetByID_WithName As String = "select P.*,C.Client_Name,BZ_No,BZ_Name,BZC_No,BZC_Name,BZ_Spec   from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID where GH=@GH "
    Public Const SQL_Produce_RGetByID_WithName As String = "select  *   from T30002_CPRK where GH=@GH "
    Public Const SQL_Produce_RSGetByID_WithName As String = "select  *   from T40520_PB_StoreNo where ID=@GH "

#End Region
#Region "外发加工单"
    Private Const OutWork_DB_NAME As String = "外发加工单"

    ''' <summary>
    ''' 获取对外发加工单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_OutWork_GetByOption & " where T.ID=@ID", "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对外发加工单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_OutWork_GetOutWorkListByid_ForReport, "@ID", sId)
    End Function

    Public Shared Function OutWork_GetDataByID(ByVal sId As String) As List(Of DataTable)
        Dim sqlList As New List(Of String)
        sqlList.Add(SQL_OutWork_GetByOption & " where T.ID=@ID")
        sqlList.Add(SQL_OutWork_GetOutWorkListByid_ForReport)
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", sId)
        Return SqlStrToDtList(sqlList, p)
    End Function
    '''' <summary>
    '''' 获取所有外发加工单
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function OutWork_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_OutWork_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_OutWork_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_OutWork_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "外发加工单号"
        fo.DB_Field = "T.ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "客户编号"
        fo.DB_Field = "P.Client_No"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T10110_Client TW,T40003_OutWork_List TL where %Client_No% and TL.Client_id=TW.ID and P.id=TL.id)"
        foList.Add(fo)



        fo = New FindOption
        fo.Field = "加工单位编号"
        fo.DB_Field = "JGDW_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "加工单位名称"
        fo.DB_Field = "JGDW_Name"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "布类名称"
        fo.DB_Field = "BZ_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "exists(select * from T10002_BZ TW,T40003_OutWork_List TL where %BZ_Name% and TL.BZ_id=TW.ID and P.id=TL.id)"
        fo.Sign = "%BZ_Name%"
        foList.Add(fo)




        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取外发加工单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_OutWork_GetByOption)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_OutWork_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_GetNewId(ByVal D As Date) As RetrunNewIdMsg
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
                R.RetrunMsg = "获取" & OutWork_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T40002_OutWork_Table")
            paraMap.Add("@Id_Str", "OW")
            paraMap.Add("@Field", "ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & OutWork_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & OutWork_DB_NAME & "单号失败!" & ex.Message
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
    Public Shared Function OutWork_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable, Optional ByVal Supplier_Name_New As String = "") As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim OutWorkId As String = dtTable.Rows(0)("ID")
        paraMap.Add("ID", OutWorkId)
        Try
            sqlMap.Add("Table", SQL_OutWork_SelByid)
            sqlMap.Add("List", SQL_OutWork_SelListByid)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then

                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & OutWorkId & "'," & BillType.OutWork & ")"
                DtToUpDate(msg, TmSQL)
                msg.Msg = "" & OutWork_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & OutWork_DB_NAME & "[" & dtTable.Rows(0)("ID") & "[已经存在!,请双击编号文本框,获取新编号!"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & OutWork_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
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
    Public Shared Function OutWork_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim OutWorkId As String = dtTable.Rows(0)("ID")
        paraMap.Add("ID", OutWorkId)
        Try
            sqlMap.Add("Table", SQL_OutWork_SelByid)
            sqlMap.Add("List", SQL_OutWork_SelListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                msg.Msg = "" & OutWork_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & OutWork_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]不存在"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & OutWork_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改错误"
            DebugToLog(ex)
            Return msg
        Finally

        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="OutWorkId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_Del(ByVal OutWorkId As String)
        Return RunSQL(SQL_OutWork_DelOutWorkByid, "@ID", OutWorkId)
    End Function



#End Region

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_GetCondition3() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "新建"
        fo.DB_Field = 0
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "已作废"
        fo.DB_Field = 1
        foList.Add(fo)

        Return foList
    End Function



    ''' <summary>
    ''' 获取半成品入库合集
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BCPRK_GetCondition3() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "未入库"
        fo.DB_Field = 0
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "已入库"
        fo.DB_Field = 1
        foList.Add(fo)

        Return foList
    End Function









End Class