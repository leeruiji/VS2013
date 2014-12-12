Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F40300_CPRK
    Dim dtProduce As DataTable







    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub
    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        SumFG1.AddSum()
    End Sub



    Private Sub F10100_CPRK_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        FG1.IniFormat()
        DP_End.Value = GetTime.AddHours(-8).Date
        DP_Start.Value = DP_End.Value.AddDays(-7)
        CPRKState.SelectedIndex = 4
        CB_State.SelectedIndex = 0
        Me_Refresh()
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
            dtProduce = msg.Dt
            Me.dtProduce.Columns.Add("StateName", GetType(String))
            Me.dtProduce.Columns.Add("LabelState", GetType(String))
            ConvertState()


            FG1.DtToFG(dtProduce)
            SumFG1.ReSum()
            FG1.RowSetForce("GH", ReturnId)
        Else
            FG1.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
        Nohide = False
    End Sub

    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.CPRK_GetByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)

#End Region



    Protected Sub ConvertState()
        If Me.dtProduce Is Nothing OrElse Me.dtProduce.Rows.Count <= 0 Then
            Exit Sub
        End If
        Dim sumQty As Integer = 0
        Dim sumPB As Double = 0
        For Each dr In Me.dtProduce.Rows
            dr("StateName") = BaseClass.ComFun.GetProduceStateName(IsNull(dr("State"), Enum_ProduceState.AddNew))
            sumQty += IsNull(dr("CR_LuoSeBzCount"), 0)
            sumPB += IsNull(dr("PB_CountSum"), 0)

            If IsNull(dr("ClientBzc"), "") <> "" Then
                dr("ClientBzc") = dr("ClientBzc") & "#"
            End If
            If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
                dr("BZ_No") = ""
            End If
            dr("BZ_Name") = dr("BZ_No") & dr("BZ_Name")
            If IsNull(dr("IsFD"), False) = True AndAlso IsNull(dr("BzcMsg"), "") = "" Then
                dr("BzcMsg") = "返定"
            Else
                If IsNull(dr("BzcMsg"), "") = "" Then
                    dr("BzcMsg") = dr("ClientBzc") & dr("BZC_Name") & "GY-" & Format(IsNull(dr("BZc_No"), ""), "000000") & dr("BZC_PF")
                Else
                    dr("BzcMsg") = dr("BzcMsg").ToString.Replace(vbCrLf, "")
                End If
            End If

            Select Case IsNull(dr("CPRK_State"), Enum_BZSHState.AddNew)
                Case Enum_BZSHState.AddNew '新建
                    dr("LabelState") = "新建"
                Case Enum_BZSHState.Store_Comfirm  '确认
                    dr("LabelState") = "确认"
                Case Enum_BZSHState.Audited '审核
                    dr("LabelState") = "已审核"
                Case Enum_BZSHState.Invoid '作废
                    dr("LabelState") = "已作废"
            End Select
        Next
        LB_Qty.Text = sumQty
        LB_PB.Text = sumPB
    End Sub
    Private Sub F40000_CPRK_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                If TB_GH.Focused = False AndAlso DP_Start.Focused = False AndAlso DP_End.Focused = False AndAlso TB_GH.Focused = False AndAlso TSC_Client.Focused = False AndAlso TSC_BZ.Focused = False Then
                    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
                        If TB_GH.Text.Length > 0 Then
                            TB_GH.Text = TB_GH.Text.Substring(0, TB_GH.Text.Length - 1)
                        End If
                    Else
                    End If
                    TB_GH.Focus()
                End If
        End Select
    End Sub


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Dim R As MsgReturn = ComFun.GetGHForTM(TB_GH.TextBox.Text)
            If R.IsOk Then
                ModifyCPRK(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        End If
    End Sub





    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0
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
        Dim F As New F40301_CPRK_Msg("")
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
            ShowErrMsg("请选择一个要修改的生产胚布单")
            Exit Sub
        End If
        Dim F As New F40301_CPRK_Msg(FG1.SelectItem("GH"))
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
            ShowErrMsg("请选择一个要修改的生产胚布单")
            Exit Sub
        End If

        ModifyCPRK(FG1.SelectItem("GH"))
    End Sub

    Sub ModifyCPRK(ByVal GH As String)
        Dim F As New F40301_CPRK_Msg(GH)
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

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
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

    'Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue2.ComboBox.DataSource = msg.Dt
    '    End If
    'End Sub




    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        '   oList.Sql = SQL_CPRK_Get_Sel
        Dim sqlbuider As New StringBuilder(Dao.SQL_PBRK_Get_Sel)
        Dim goodsCount As Integer = 0

        fo = New FindOption
        fo.DB_Field = "isnull(Date_CPRK,'1900-1-1')"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)





        '全部()
        If CB_State.SelectedIndex = 0 Then      '已成检()
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = Enum_ProduceState.ChengJian
            oList.FoList.Add(fo)
        ElseIf CB_State.SelectedIndex = 1 Then        '已入库()
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = Enum_ProduceState.RuKu
            oList.FoList.Add(fo)





        ElseIf CB_State.SelectedIndex = 2 Then '未成检()
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_Between
            fo.Value = Enum_ProduceState.PeiBu
            fo.Value2 = Enum_ProduceState.ChengJianZhong
            oList.FoList.Add(fo)



        ElseIf CB_State.SelectedIndex = 3 Then        '按入库日期搜索()
            For Each fo In oList.FoList
                If fo.DB_Field = "Date_KaiDan" Then
                    fo.DB_Field = "Date_CPRK"
                    Exit For
                End If
            Next


            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            fo.Value = Enum_ProduceState.RuKu
            oList.FoList.Add(fo)
        End If
        If CPRKState.SelectedIndex = 0 Then '新建
            fo = New FindOption
            fo.DB_Field = "CPRK_State"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = Enum_BZSHState.AddNew
            oList.FoList.Add(fo)
        ElseIf CPRKState.SelectedIndex = 1 Then '已确认
            fo = New FindOption
            fo.DB_Field = "CPRK_State"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = Enum_BZSHState.Store_Comfirm
            oList.FoList.Add(fo)
        ElseIf CPRKState.SelectedIndex = 2 Then '已审核
            fo = New FindOption
            fo.DB_Field = "CPRK_State"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = Enum_BZSHState.Audited
            oList.FoList.Add(fo)
        ElseIf CPRKState.SelectedIndex = -1 Then '已作废
            fo = New FindOption
            fo.DB_Field = "CPRK_State"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = Enum_BZSHState.Invoid
            oList.FoList.Add(fo)
        End If

        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "P.Client_ID"
            fo.Value = TSC_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If



        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "p.BZ_ID"
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            goodsCount = 1
            oList.FoList.Add(fo)
        End If


        'If TB_GH.Text <> "" Then
        '    fo = New FindOption
        '    fo.DB_Field = "GH"


        '    fo.Value = TB_GH.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like_Both
        '    oList.FoList.Add(fo)
        'End If



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
        Dim R As New R40301_CPRK
        R.Start(FG1.Item(FG1.RowSel, "GH"), DoOperator)
        'R.Start(DoOperator, FG1.DataSource)
    End Sub

#End Region



End Class


Partial Friend Class Dao

    Public Const SQL_ProduceGd_Get_CPRK As String = "select p.CPRK_IsPrinted,p.GH,isFD,BzcMsg,p.State,p.PB_User,CPRK_State,ClientBzc,p.Date_CPRK,p.Date_PeiBu,CR_LuoSeBzCount,PB_CountSum,CPRK_Qty,KaiDan,Client_No,Store_CPRK, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,CPRK_User,BZC_PF from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID "

    Public Const SQL_CPRK_Get_WithName = "select distinct( L.GH), P.*,Client_No,S.Client_Name,BZ_No,BZ_Name from T40100_PBRK_Table P left join T10110_Client S on  P.Client_ID=S.ID left join T10002_BZ BZ on BZ.ID =P.BZ_ID left Join T40101_PBRK_List L on P.ID=L.ID"
    Public Const SQL_CPRK_GetPBRK_Table_ByID = "select top 1 p.ID,sDate,P.Client_ID,BZ_ID,Notice,Remark,ShaPi,State,BZ_No,BZ_Name from T40100_PBRK_Table P left join T10002_BZ B on B.ID=P.BZ_ID where P.ID=@ID"
    Public Const SQL_CPRK_GetPBRK_List_ByID = "select * from T40101_PBRK_List where ID=@ID"
    Public Const SQL_CPRK_GetGH_ByID = "select G.*,C.Client_No,C.Client_Name,BZ.Bz_No,Bz.Bz_Name,BZC.BZC_No,BZC.BZC_Name from(select top 1 * from T30000_Produce_Gd where GH=@GH)G left join T10110_Client C On C.id=G.Client_id  left join T10002_BZ BZ On BZ.id=G.BZ_id   left join T10003_BZC BZC On BZC.id=G.BZC_id "
    Public Const SQL_CPRK_GetDT_ByID = "select G.*,C.Client_No,C.Client_Name,BZ.Bz_No,Bz.Bz_Name,BZC.BZC_No,BZC.BZC_Name from(select top 1 * from T30000_Produce_Gd where GH=@GH)G left join T10110_Client C On C.id=G.Client_id  left join T10002_BZ BZ On BZ.id=G.BZ_id   left join T10003_BZC BZC On BZC.id=G.BZC_id where GH=@GH"
    Public Const SQL_CPRK_GetDL_ByID = "select StoreNo,Qty from T30002_CPRK where GH=@GH"
    Public Const SQL_CPRK_GetListByGH = "select * from T30002_CPRK where GH=@GH"
    Public Const SQL_CPRK_CleanStore = "update T30000_Produce_Gd set Store_CPRK =@Store_CPRK where GH=@GH"

#Region "成品入库"

    ''' <summary>
    ''' 成品入库的内容表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_GetListByGH(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_CPRK_GetListByGH, "@GH", GH)
    End Function
    ''' <summary>
    ''' 成品入库的清空库存
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_CleanStore(ByVal _GH As String, ByVal Store_CPRK As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("@GH", _GH)
        P.Add("@Store_CPRK", Store_CPRK)
        Return PClass.PClass.SqlStrToDt(SQL_CPRK_CleanStore, P)
    End Function


    Public Shared Function CPRK_GetPBRK_Table_ByID(ByVal ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_CPRK_GetPBRK_Table_ByID, "@ID", ID)
    End Function

    ''' <summary>
    ''' 取消入库
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_Cancel(ByVal GH As String) As MsgReturn
        Dim R As New MsgReturn
        Dim S As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        S.Add("G", "Select top 1 GH,State,CR_LuoSeBzCount,Store_CPRK from T30000_Produce_Gd where GH=@GH")
        S.Add("C", "select * from T30002_CPRK where GH=@GH")
        P.Add("GH", GH)
        Using H As New DtHelper(S, P)
            If H.IsOk = True Then
                If H.DtList("G").Rows.Count > 0 Then
                    If H.DtList("G").Rows(0)("State") = Enum_ProduceState.RuKu Then
                        If IsNull(H.DtList("C").Compute("Sum(Qty)", ""), 0) <> H.DtList("G").Rows(0)("CR_LuoSeBzCount") Then
                            R.IsOk = False
                            R.Msg = "取消入库失败,缸号[" & GH & "]已经有一部分被出货,不能取消入库!"
                        Else
                            For Each Row As DataRow In H.DtList("C").Rows
                                Row.Delete()
                            Next
                            H.DtList("G").Rows(0)("State") = Enum_ProduceState.ChengJian
                            H.DtList("G").Rows(0)("Store_CPRK") = DBNull.Value
                            If H.UpdateAll(True).IsOk Then
                                R.IsOk = True
                                R.Msg = "取消入库成功!"
                            Else
                                R.IsOk = False
                                R.Msg = "取消入库失败," & H.Msg
                            End If
                        End If
                       
                    Else
                        R.IsOk = False
                        R.Msg = "取消入库失败,缸号[" & GH & "]当前状态是[" & ComFun.GetProduceStateName(H.DtList("G").Rows(0)("State")) & "],不能取消入库!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "取消入库失败,缸号[" & GH & "]不存在!"
                End If
            Else
                R.IsOk = False
                R.Msg = "取消入库失败," & R.Msg
            End If
        End Using
        Return R
    End Function

 


    Public Shared Function CPRK_GetGH_ByID(ByVal ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_CPRK_GetGH_ByID, "@GH", ID)
    End Function


    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_ProduceGd_Get_CPRK)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        If oList.OrderBy = "" Then
            sqlBuider.Append(" order by GH ")
        Else
            sqlBuider.Append(" order by " & oList.OrderBy)
        End If
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "缸号"
        fo.DB_Field = "GH"
        foList.Add(fo)


        'fo = New FindOption
        'fo.Field = "胚布入库单号"
        'fo.DB_Field = "ID"
        'foList.Add(fo)


        Return foList
    End Function





    ''' <summary>
    ''' 保存
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <param name="PB_Date"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_Save(ByVal GH As String, ByVal PB_Date As Date, ByVal dtList As DataTable, ByVal CPRK_Qty As Integer, ByVal IsNum As Boolean) As MsgReturn
        Dim Rm As New MsgReturn
        Dim Store_CPRK As String = BaseClass.ComFun.DtToString(dtList, "StoreNo", "|")
        Dim SQL As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        SQL.Add("P", "select top 1 GH,CPRK_User,Date_CPRK,State,CPRK_Qty,Store_CPRK from T30000_Produce_Gd where GH=@GH")
        SQL.Add("C", "select * from T30002_CPRK where GH=@GH")

        P.Add("GH", GH)
        Using H As New DtHelper(SQL, P)
            If H.IsOk Then
                If H.DtList("P").Rows.Count > 0 Then
                    If H.DtList("P").Rows(0)("State") >= BaseClass.Enum_ProduceState.ChengJian Then
                        If IsNum Then
                            H.DtList("P").Rows(0)("State") = BaseClass.Enum_ProduceState.RuKu
                            H.DtList("P").Rows(0)("CPRK_User") = User_Display
                            'H.DtList("P").Rows(0)("Date_CPRK") = PB_Date.Date

                        End If
                        H.DtList("P").Rows(0)("Date_CPRK") = PB_Date.Date
                        H.DtList("P").Rows(0)("Store_CPRK") = Store_CPRK
                        H.DtList("P").Rows(0)("CPRK_Qty") = CPRK_Qty
                        Dim S As New List(Of String)
                        S.Add("Msg")
                        DvToDt(dtList, H.DtList("C"), S)
                        Dim sqlbuider As New StringBuilder

                        If H.UpdateAll(True, sqlbuider.ToString).IsOk Then
                            Rm.Msg = "入库成功"
                            Rm.IsOk = True
                            Return Rm
                        Else
                            Rm.Msg = "8更新失败," & H.Msg
                            Rm.IsOk = False
                            Return Rm
                        End If
                    Else
                        Rm.Msg = "8入库失败,缸号[" & GH & "]当前状态是[" & ComFun.GetProduceStateName(H.DtList("P").Rows(0)("State")) & "],不能入库!"
                        Rm.IsOk = False
                        Return Rm
                    End If
                Else
                    Rm.Msg = "9没有找到缸号[" & GH & "]"
                    Rm.IsOk = False
                    Return Rm
                End If
            Else
                Rm.Msg = "8查询失败," & H.Msg
                Rm.IsOk = False
                Return Rm
            End If
        End Using
    End Function
    ''' <summary>
    ''' 更新表单状态
    ''' </summary>
    ''' <param name="_State"></param>
    ''' <param name="_GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_UpdateFormState(ByVal _State As Enum_BZSHState, ByVal _GH As String) As Boolean
        Dim p As New Dictionary(Of String, Object)

        p.Add("GH", _GH)
        Dim sql As New StringBuilder
        Dim R As MsgReturn = SqlStrToOneStr("select CPRK_State from  T30000_Produce_Gd  where GH=@GH ", p)
        If R.IsOk Then

            p.Add("FormState", _State)
            sql.AppendLine("update T30000_Produce_Gd set CPRK_State =@FormState where GH=@GH")
            If _State = Enum_BZSHState.Store_Comfirm AndAlso Val(R.Msg) = Enum_BZSHState.AddNew Then

                sql.AppendLine("insert into T40520_PB_StoreNo  (StoreNo,ID,Qty,BZType) select StoreNo,GH,Qty,1 from T30002_CPRK  where GH=@GH ")
                sql.AppendLine("insert into T40521_PB_Detail  (StoreNo,ID,GH,InQty,BillType,BillName) select StoreNo,GH,GH,Qty,40300,'成品入库单' from T30002_CPRK  where GH=@GH ")

            ElseIf _State = Enum_BZSHState.AddNew AndAlso Val(R.Msg) = Enum_BZSHState.Store_Comfirm Then
                sql.AppendLine("delete from T40520_PB_StoreNo  where ID=@GH ")
                sql.AppendLine("delete from T40521_PB_Detail  where billtype=40300 and ID=@GH ")
            End If
            R = RunSQL(sql.ToString, p)
        End If
        Return R.IsOk
    End Function
#End Region
End Class

