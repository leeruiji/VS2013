Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F30200_CPZL
    Dim dtProduce As DataTable
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.TZPB, Cmd_TZPB)
    End Sub

    Private Sub SCPB_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        FG1.IniFormat()
        FG1.IniColsSize()
        FG1.FG_ColResize()
        DP_Start.Value = Today.AddDays(-7)
        DP_End.Value = Today
        'CB_ConditionName1.ComboBox.DisplayMember = "Field"
        'CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        ''CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        ''CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        'CB_ConditionName1.ComboBox.DataSource = Dao.SCPB_GetConditionNames()
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
        T.Start(GetFindOtions)
        If Nohide = False Then Me.ShowLoading(MeIsLoad)
        FG1.Visible = False
    End Sub


    Sub SetData(ByVal msg As DtReturnMsg)
        If msg.IsOk Then
            Me.dtProduce = msg.Dt
            Me.dtProduce.Columns.Add("StateName", GetType(String))
            ConvertState()
            Dim sumQty As Integer = 0
            Dim sumPB As Double = 0
            For Each dr In Me.dtProduce.Rows
                Dim _state As Integer = IsNull(dr("State"), 0)
                dr("StateName") = BaseClass.ComFun.GetProduceStateName(_state)
                sumQty += IsNull(dr("CP_CountSum"), 0)
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
            Next
            LB_Qty.Text = sumQty
            LB_PB.Text = sumPB

            FG1.DtToFG(dtProduce)
            FG1.RowSetForce("GH", ReturnId)
        Else
            FG1.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
        Nohide = False
    End Sub


    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.CPZL_GetByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)
#End Region


    Protected Sub ConvertState()
        If Me.dtProduce Is Nothing OrElse Me.dtProduce.Rows.Count <= 0 Then
            Exit Sub
        End If

        For Each dr In Me.dtProduce.Rows
            dr("StateName") = BaseClass.ComFun.GetProduceStateName(IsNull(dr("State"), Enum_ProduceState.AddNew))
        Next
    End Sub
    Private Sub F40000_SCPB_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                If TB_GH.Focused = False AndAlso TSC_BZ.Focused = False AndAlso TSC_Client.Focused = False Then
                    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
                        If TB_GH.Text.Length > 0 Then TB_GH.Text = TB_GH.Text.Substring(0, TB_GH.Text.Length - 1)
                        TB_GH.Focus()
                    Else
                        TB_GH.Text = e.KeyChar
                        TB_GH.Focus()
                    End If
                    'If CB_ConditionName1.SelectedIndex = 0 AndAlso CB_ConditionName1.Items.Count > 1 Then
                    '    CB_ConditionName1.SelectedIndex = 1
                    'End If
                End If
        End Select
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
        Dim F As New F30201_CPZL_Msg("")
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
        ModifyProduce(FG1.SelectItem("GH"))
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
        ModifyProduce(FG1.SelectItem("GH"))
    End Sub

    Sub ModifyProduce(ByVal GH As String)

        Dim F As New F30201_CPZL_Msg(GH)
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
        '   oList.Sql = SQL_SCPB_Get_Sel
        Dim sqlbuider As New StringBuilder(Dao.SQL_PBRK_Get_Sel)
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "Date_KaiDan"
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
            fo.DB_Field = "p.BZ_ID"
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            goodsCount = 1
            oList.FoList.Add(fo)
        End If


        If CB_State.SelectedIndex = 0 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_Between
            fo.Value = Enum_ProduceState.DingXing
            fo.Value2 = Enum_ProduceState.ChengJianZhong
            oList.FoList.Add(fo)

        ElseIf CB_State.SelectedIndex = 1 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_Between
            fo.Value = Enum_ProduceState.RanSe
            fo.Value2 = Enum_ProduceState.ChengJianZhong
            oList.FoList.Add(fo)
        ElseIf CB_State.SelectedIndex = 2 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            fo.Value = Enum_ProduceState.ChengJianZhong
            oList.FoList.Add(fo)
        End If


        'If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
        '    fo = New FindOption
        '    fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue


        '    fo.Value = TB_ConditionValue1.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like_Both
        '    oList.FoList.Add(fo)
        'End If

        'If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
        '    fo = New FindOption
        '    fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
        '    If fo.DB_Field = "BZ_ID" Then
        '        goodsCount = 1
        '    ElseIf fo.DB_Field = "BZ_Name" Then
        '        goodsCount = 2
        '    End If
        '    fo.Value = CB_ConditionValue2.ComboBox.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like
        '    oList.FoList.Add(fo)
        'End If

        'If goodsCount = 1 Then
        '    sqlbuider.Append(", List.BZ_ID ")
        '    sqlbuider.Append(SQL_SCPB_Get_Body)
        '    sqlbuider.Append(SQL_SCPB_Get_leftJoin_GoodsNo)
        'ElseIf goodsCount = 2 Then
        '    sqlbuider.Append(", List.BZ_ID,List.BZ_Name ")
        '    sqlbuider.Append(SQL_SCPB_Get_Body)
        '    sqlbuider.Append(SQL_SCPB_Get_leftJoin_GoodsName)
        'Else

        '    sqlbuider.Append(SQL_SCPB_Get_Body)

        'End If
        '   sqlbuider.Append(SQL_SCPB_OrderBy)
        '  oList.Sql = sqlbuider.ToString
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
        Dim R As New R30200_CPZL
        R.Start(FG1.Item(FG1.RowSel, "GH"), "", DoOperator)
    End Sub

#End Region



    Private Sub TB_ConditionValue1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Dim R As MsgReturn = ComFun.GetGHForTM(TB_GH.TextBox.Text)
            If R.IsOk Then
                ModifyProduce(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        End If
    End Sub

    Private Sub Cmd_ModifyPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_TZPB.Click
        If FG1.RowSel < 0 Then
            ModifyPB("")
        Else
            ModifyPB(FG1.SelectItem("GH"))
        End If

    End Sub

    Sub ModifyPB(ByVal GH As String)

        Dim F As New F30205_TZPB_Msg(GH)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub

    Private Sub Cmd_DZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DZ.Click
        If FG1.RowSel < 0 Then
            ModifyDZ("")
        Else
            ModifyDZ(FG1.SelectItem("GH"))
        End If
    End Sub
    Sub ModifyDZ(ByVal GH As String)
        Dim F As New F30202_CPZL_Input(GH)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()

    End Sub
    
End Class

Partial Friend Class Dao
    Public Const SQL_SCPB_Get_WithName As String = ""

    Public Const SQL_SCPB_GetPBRK_Table_ByID = "select top 1 ID,sDate,Client_ID,BZ_ID,Notice,Remark,ShaPi,State from T40100_PBRK_Table where ID=@ID"
    Public Const SQL_SCPB_GetCPZL_Table_ByID = "select * from T30001_CPZL where GH=@GH order by GH,CP_GH"
    Public Const SQL_SCPB_GetPBRK_List_ByID = "select * from T40101_PBRK_List where ID=@ID"
    Public Const SQL_SCPB_GetGH_ByID = "select G.*,C.Client_No,C.Client_Name,isnull(BZ.CP_No,BZ.BZ_No) BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)BZ_Name,BZC.BZC_No,BZC.BZC_Name,BZ_Spec from(select top 1 * from T30000_Produce_Gd where GH=@GH)G left join T10110_Client C On C.id=G.Client_id  left join T10002_BZ BZ On BZ.id=G.BZ_id   left join T10003_BZC BZC On BZC.id=G.BZC_id "
    Public Const SQL_PBRK_GetListByGH = "select ID,Line,ZL,PB,CP,StoreNo,isnull(CP_GH,'')CP_GH,isnull(Old_PB,0)Old_PB,CP_Line from T40101_PBRK_List where GH=@GH order by CP_GH,CP_Line"

    Public Const SQL_PBRK_Get_Sel As String = "select  P.*,S.Client_Name "
#Region "生产配布"

    ''' <summary>
    ''' 获取对胚布入库单列表信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetListByGH(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetListByGH, "@GH", GH)
    End Function

    Public Shared Function CPZL_GetPBRK_Table_ByID(ByVal ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_SCPB_GetPBRK_Table_ByID, "@ID", ID)
    End Function

    Public Shared Function CPZL_GetCPZL_Table_ByID(ByVal GH As String) As DtReturnMsg
        Return SqlStrToDt(SQL_SCPB_GetCPZL_Table_ByID, "@GH", GH)
    End Function



    Public Shared Function CPZL_GetGH_ByID(ByVal ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_SCPB_GetGH_ByID, "@GH", ID)
    End Function
    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPZL_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("select P.GH,Date_CPLR,Date_KaiDan,Client_No,state,PB_CountSum,ClientBzc,IsFD,BzcMsg, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,E.Employee_name as GenDanName,(select Count(*) from T40101_PBRK_List where GH = p.GH  and CP<>0 )CP_CountSum from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T15001_Employee E on  P.GengDan=E.ID")
        sqlBuider.Append("  WHERE state>0  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" order by GH ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPZL_GetConditionNames() As List(Of FindOption)
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
    ''' 
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <param name="Date_CPLR"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPZL_Save(ByVal GH As String, ByVal CP_GH As String, ByVal Date_CPLR As Date, ByVal dtList As DataTable, ByVal IsOk As Boolean) As MsgReturn

        Dim S As New StringBuilder("")
        Dim SumCP As Double = 0
        Dim SumPB As Double = 0
        Dim SumQty As Integer = 0
        Dim PBRK_ID As String = ""
        Dim P As New Dictionary(Of String, Object)
        S.AppendLine("declare @State int")

        S.AppendLine("declare @Err Varchar(8000)")
        S.AppendLine("set @State=(select top 1 isnull(State,'-1')State from T30000_Produce_Gd where GH=@GH)")
        S.AppendLine("set @Err=''")
        S.AppendLine("if Not(@State>=@RanSe and @State<=@Next_State)")
        S.AppendLine("select N'Error=state;缸号当前状态不能输入成品重量'")
        S.AppendLine("else")
        S.AppendLine("begin")
        S.AppendLine("begin tran T")
        ' S.AppendLine("ALTER  TABLE  T40101_PBRK_List  DISABLE  TRIGGER  T40101_PBRK_List_Update   ")
        S.AppendLine("if not exists(select top 1 * from T30001_CPZL where GH=@GH and CP_GH=@CP_GH )")
        S.AppendLine("insert into T30001_CPZL (GH,CP_GH)values(@GH,@CP_GH) ")
        S.AppendLine("update T40101_PBRK_List set CP=0 where GH=@GH and CP_GH=@CP_GH")
        For Each R As DataRow In dtList.Rows
            S.AppendLine("update T40101_PBRK_List set CP=" & IsNull(R("CP"), 0) & ",CP_GH=@CP_GH,CP_Line=" & IsNull(R("CP_Line"), 0))
            S.AppendLine(" where GH=@GH and Line=" & R("Line"))
            S.AppendLine("if @@Rowcount=0 set @Err=@Err + '" & R("Line") & "' + ','")
            SumCP = SumCP + R("CP")
            SumPB = SumPB + R("PB")
            SumQty = SumQty + 1
        Next

        S.AppendLine("Update T30000_Produce_Gd set Date_CPLR=@Date_CPLR,ChengJian_User=@ChengJian_User")
        S.AppendLine(",CP_ZLSum=isnull((select sum(CP) from T40101_PBRK_List where GH=@GH),0) ")
        S.AppendLine(",State=@Next_State,UPD_User=@ChengJian_User,UPD_Date=GetDate()")
        If IsOk Then
            P.Add("@Next_State", Enum_ProduceState.ChengJian)
        Else
            P.Add("@Next_State", Enum_ProduceState.ChengJianZhong)
        End If
        S.AppendLine("where GH=@GH")

        S.AppendLine("Update T30001_CPZL set SumQty=@SumQty,SumCP=@SumCP,SumPB=@SumPB,sDate=@Date_CPLR where GH=@GH and CP_GH=@CP_GH")


        S.AppendLine("if @Err<>''")
        S.AppendLine("begin")
        S.AppendLine("rollback")
        ' S.AppendLine("ALTER  TABLE  T40101_PBRK_List  ENABLE   TRIGGER  T40101_PBRK_List_Update   ")
        S.AppendLine("set @Err=N'Error=gh;' + @Err")
        S.AppendLine("select @Err")
        S.AppendLine("end")
        S.AppendLine("else")
        S.AppendLine("begin")
        S.AppendLine("commit")
        '  S.AppendLine("ALTER  TABLE  T40101_PBRK_List  ENABLE  TRIGGER  T40101_PBRK_List_Update   ")
        S.AppendLine("select N'Error=no;'")
        S.AppendLine("end")
        S.AppendLine("end")

        P.Add("@GH", GH)
        P.Add("@CP_GH", CP_GH)
        P.Add("@Date_CPLR", Date_CPLR.ToString("yyyy-MM-dd"))
        P.Add("@RanSe", Enum_ProduceState.RanSe)
        P.Add("@ChengJian_User", User_Name)

        P.Add("SumQty", SumQty)
        P.Add("SumCP", SumCP)
        P.Add("SumPB", SumPB)
        Dim Rm As MsgReturn = SqlStrToOneStr(S.ToString, P)
        If Rm.IsOk Then
            Dim Sp() As String = Rm.Msg.Split("=")
            If Sp(1).StartsWith("no") Then
                Rm.Msg = "保存成品重量录入成功!"
                Rm.IsOk = True
            Else
                Rm.IsOk = False
                If Sp(1).StartsWith("state") Then
                    Rm.Msg = "1保存成品重量录入失败,原因:" & "缸号[" & GH & "]缸号当前状态不能输入成品重量"
                Else
                    If Sp(1).StartsWith("gh") Then
                        Sp = Rm.Msg.Split(";")
                        Rm.Msg = "2保存成品重量录入失败;" & Sp(1)
                    Else
                        Rm.Msg = "9保存成品重量录入失败,原因:未知"
                    End If
                End If
            End If
        Else
            Rm.Msg = "9保存成品重量录入失败,原因:" & Rm.Msg
        End If
        Return Rm
    End Function

#End Region
End Class