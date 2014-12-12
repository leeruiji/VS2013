Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F40200_SCPB
    Dim dtProduce As DataTable

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub






    Private Sub F10100_SCPB_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"

        FG1.IniFormat()
        DP_End.Value = GetTime.AddHours(-8).Date
        DP_Start.Value = DP_End.Value.AddDays(-7)

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
            ConvertState()


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
        Dim msg As DtReturnMsg = Dao.SCPB_GetByOption(oList)
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

        Next
        LB_Qty.Text = sumQty
        LB_PB.Text = sumPB
    End Sub
    Private Sub F40000_SCPB_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
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
                ModifySCPB(R.Msg)
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
        Dim F As New F40201_SCPB_Msg("")
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
        Dim F As New F40201_SCPB_Msg(FG1.SelectItem("GH"))
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

        ModifySCPB(FG1.SelectItem("GH"))
    End Sub

    Sub ModifySCPB(ByVal GH As String)
        Dim F As New F40201_SCPB_Msg(GH)
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


        If CB_State.SelectedIndex = 0 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = Enum_ProduceState.XiaDan
            oList.FoList.Add(fo)
        ElseIf CB_State.SelectedIndex = 1 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            fo.Value = Enum_ProduceState.PeiBu
            oList.FoList.Add(fo)


            fo = New FindOption
            fo.DB_Field = "PB_CountSum"
            fo.Field_Operator = Enum_Operator.Operator_UnEqual
            fo.Value = 0
            oList.FoList.Add(fo)


        ElseIf CB_State.SelectedIndex = 2 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            fo.Value = Enum_ProduceState.PeiBu
            oList.FoList.Add(fo)


            fo = New FindOption
            fo.DB_Field = "Isnull(PB_CountSum,0)"
            fo.Field_Operator = Enum_Operator.Operator_Equal
            fo.Value = 0
            oList.FoList.Add(fo)

        ElseIf CB_State.SelectedIndex = 3 Then
            For Each fo In oList.FoList
                If fo.DB_Field = "Date_KaiDan" Then
                    fo.DB_Field = "Date_PeiBu"
                    Exit For
                End If
            Next


            fo = New FindOption
            fo.DB_Field = "State"
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            fo.Value = Enum_ProduceState.PeiBu
            oList.FoList.Add(fo)

            fo = New FindOption
            fo.DB_Field = "PB_CountSum"
            fo.Field_Operator = Enum_Operator.Operator_UnEqual
            fo.Value = 0
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
        ' Dim R As New R40001_SCPB
        ' R.Start(FG1.Item(FG1.RowSel, "SCPB_ID"), DoOperator)
    End Sub

#End Region



End Class


Partial Friend Class Dao
    Public Const WNGH As String = "GY110110110"

    Public Const SQL_ProduceGd_Get_SCPB As String = "select p.GH,p.BZC_PF,isFD,BzcMsg,p.State,p.PB_User,ClientBzc,p.Date_KaiDan,p.Date_PeiBu,CR_LuoSeBzCount,PB_CountSum,KaiDan,Client_No, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,E.Employee_name as GenDanName from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T15001_Employee E on  P.GengDan=E.ID"

    Public Const SQL_SCPB_Get_WithName = "select distinct( L.GH), P.*,Client_No,S.Client_Name,BZ_No,BZ_Name from T40100_PBRK_Table P left join T10110_Client S on  P.Client_ID=S.ID left join T10002_BZ BZ on BZ.ID =P.BZ_ID left Join T40101_PBRK_List L on P.ID=L.ID"
    Public Const SQL_SCPB_GetPBRK_Table_ByID = "select top 1 p.ID,sDate,P.Client_ID,BZ_ID,Notice,Remark,ShaPi,Machine,State,BZ_No,BZ_Name from T40100_PBRK_Table P left join T10002_BZ B on B.ID=P.BZ_ID where P.ID=@ID"
    Public Const SQL_SCPB_GetPBRK_List_ByID = "select * from T40101_PBRK_List where ID=@ID"
    Public Const SQL_SCPB_GetGH_ByID = "select G.*,C.Client_No,C.Client_Name,BZ.Bz_No,Bz.Bz_Name,BZC.BZC_No,BZC.BZC_Name from(select top 1 * from T30000_Produce_Gd where GH=@GH)G left join T10110_Client C On C.id=G.Client_id  left join T10002_BZ BZ On BZ.id=G.BZ_id   left join T10003_BZC BZC On BZC.id=G.BZC_id "
    Public Const SQL_PBRK_GetListByGH = "select ID,Line,ZL,PB,StoreNo from T40101_PBRK_List where GH=@GH"
    Public Const SQL_PBRK_Get_Sel As String = "select  P.*,S.Client_Name "
    Public Const SQL_GetStore As String = " Select ID,StoreNo,Qty As InQty,0 as OQty,( Qty-0) as Qty from T40520_PB_StoreNo Where ID=@ID And Qty>0 "


    Public Const SQL_UpdateStore As String = " Update T40520_PB_StoreNo  Set Qty= Qty + (select Top 1 InQty From T40521_PB_Detail P Where T40520_PB_StoreNo.StoreNo=P.StoreNo and T40520_PB_StoreNo.id=p.id " & _
                                           "  And P.BillType=40200 And P.GH=@GH)  Where exists (Select * from T40521_PB_Detail P Where GH=@GH And  T40520_PB_StoreNo.StoreNo=P.StoreNo and T40520_PB_StoreNo.id=p.id  And P.BillType=40200    )  "




    Public Const SQL_GetStoreNo_ByID As String = " Select BillType,BillName,InQty as OQty,ID,StoreNo from   T40521_PB_Detail Where ID=@ID And BillType=40200           "

    Public Const SQL_Update_byClear As String = "  Update T40520_PB_StoreNo  Set Qty= Qty - ( select  Sum(InQty) From T40521_PB_Detail   P " & _
                                               "  Where T40520_PB_StoreNo.StoreNo=P.StoreNo and T40520_PB_StoreNo.id=p.id  And P.BillType=40200 And P.GH=@GH) Where exists (Select * from T40521_PB_Detail P Where GH=@GH And  T40520_PB_StoreNo.StoreNo=P.StoreNo and T40520_PB_StoreNo.id=p.id  And P.BillType=40200    )      "

    Public Const SQL_DEL_Store As String = " Delete from T40521_PB_Detail Where GH=@GH  "

    Public Const SQL_GetPBStore As String = "SELECT StoreNo,-InQty as OQty ,ID,0 AS Qty,0 AS InQty FROM T40521_PB_Detail WHERE GH = @GH AND BillType = 40200 Order by ID"

#Region "生产配布"

    ''' <summary>
    ''' 获取对胚布入库单列表信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetListByGH(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetListByGH, "@GH", GH)
    End Function

    Public Shared Function SCPB_GetPBRK_Table_ByID(ByVal ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_SCPB_GetPBRK_Table_ByID, "@ID", ID)
    End Function

    Public Shared Function SCPB_GetStoreNo_ByID(ByVal ID As String) As DtReturnMsg

        Return SqlStrToDt(SQL_GetStore, "@ID", ID)
    End Function


    ''' <summary>
    ''' 获取配布条数
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SCPB_GetStore_ByGH(ByVal GH As String) As DtReturnMsg
        Return SqlStrToDt(SQL_GetPBStore, "GH", GH)
    End Function



    ''' <summary>
    ''' 取消配布
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SCPB_Cancel(ByVal GH As String, ByVal reason As String, ByVal BZText As String, ByVal dtTable As DataTable) As MsgReturn
        Dim R As New MsgReturn
        '  Dim S As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        '  S.Add("G", "Select top 1 GH,State,UPD_User,UPD_Date from T30000_Produce_Gd where GH=@GH")
        P.Add("GH", GH)
        P.Add("reason", reason)
        P.Add("BZText", BZText)
        P.Add("@Upd_User", User_Name)
        P.Add("NewState", Enum_ProduceState.XiaDan)
        'R = SqlStrToOneStr("P3006_GHStateChange", P, True)
        'If R.IsOk AndAlso R.Msg.Length > 0 AndAlso Val(R.Msg.Substring(0, 1)) = 1 Then
        '    R.IsOk = True
        '    R.Msg = "取消配布成功!"
        'Else
        '    R.IsOk = False
        '    R.Msg = R.Msg.Substring(1)
        'End If

        Dim TmSQL As New System.Text.StringBuilder("")
        TmSQL.AppendLine("declare @LuoSeCount  Decimal(9,2)")
        TmSQL.AppendLine("declare @LuoseZL  Decimal(9,2)")
        TmSQL.AppendLine("declare @BZ_No varchar(20)")
        TmSQL.AppendLine("declare @BZ_Name  varchar(20)")
        TmSQL.AppendLine("declare @BZC_No  varchar(20)")
        TmSQL.AppendLine("declare @BZC_Name  varchar(20)")
        TmSQL.AppendLine("declare @BZName varchar(50)")
        TmSQL.AppendLine("declare @BZCName varchar(50)")
        TmSQL.AppendLine("declare @oldState int")
        TmSQL.AppendLine("	select @LuoSeCount=CR_LuoSeBzCount ,@LuoseZL=CR_LuoSeBzZl,@BZ_No=BZ.BZ_No, @BZ_Name=BZ.BZ_Name,@BZC_No=BZC.BZC_No, @BZC_Name=BZC.BZC_Name,@oldState=G.State from  T30000_Produce_Gd G left join T10002_BZ BZ on G.BZ_ID=BZ.ID left join T10003_BZC BZC on G.BZC_ID=BZC.ID where GH=@gh	set @BZName=@BZ_No+'#'+@BZ_Name set @BZCName=@BZC_No+'#'+@BZC_Name")
        TmSQL.AppendLine("insert into T30006_GHStateLog(GH,BZName,BZCName,LuoSeCount,LuoseZL,Reason,BZText,OldState,newState,Upd_User)")
        TmSQL.AppendLine("values(@GH,@BZName,@BZCName,@LuoSeCount,@LuoseZL,@Reason,@BZText,@OldState,@newState,@Upd_User)")
        TmSQL.AppendLine("update  T30000_Produce_Gd set UPD_User=@Upd_User ,UPD_Date=getDate(),State=@NewState where GH=@GH")
        For Each drStore As DataRow In dtTable.Rows
            TmSQL.AppendLine(" if (select count(*) from T40520_PB_StoreNo where ID='" & drStore("ID") & "' and StoreNo='" & drStore("StoreNo") & "')>0")
            TmSQL.AppendLine(" update T40520_PB_StoreNo set qty=qty+" & drStore("InQty") & " where  ID='" & drStore("ID") & "' and StoreNo='" & drStore("StoreNo") & "'")
            TmSQL.AppendLine(" else ")
            TmSQL.AppendLine("insert into T40520_PB_StoreNo  (StoreNo,ID,Qty,BZType) values ('" & drStore("StoreNo") & "','" & drStore("ID") & "'," & drStore("InQty") & ",0) ")
            TmSQL.AppendLine("insert into T40521_PB_Detail  (StoreNo,ID,GH,InQty,BillType,BillName) values ('" & drStore("StoreNo") & "','" & drStore("ID") & "','" & drStore("GH") & "','" & drStore("InQty") & "','" & "40200" & "','" & "取消配布" & "') ")

        Next

        Return RunSQL(TmSQL.ToString, P)
    End Function

    ''' <summary>
    ''' 清除配布
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SCPB_Clear(ByVal GH As String) As MsgReturn
        Dim R As New MsgReturn
        Dim S As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        S.Add("G", "Select top 1 GH,State,PB_ZLSum,PB_CountSum,Date_PeiBu,PB_User,UPD_User,UPD_Date from T30000_Produce_Gd where GH=@GH")
        P.Add("GH", GH)
        Using H As New DtHelper(S, P)
            If H.IsOk = True Then
                If H.DtList("G").Rows.Count > 0 Then
                    If H.DtList("G").Rows(0)("State") = Enum_ProduceState.XiaDan Then
                        H.DtList("G").Rows(0)("PB_ZLSum") = 0
                        H.DtList("G").Rows(0)("PB_CountSum") = 0
                        H.DtList("G").Rows(0)("Date_PeiBu") = DBNull.Value
                        H.DtList("G").Rows(0)("PB_User") = ""
                        H.DtList("G").Rows(0)("UPD_User") = User_Name
                        H.DtList("G").Rows(0)("UPD_Date") = GetTime()
                        Dim sqlBuider As New StringBuilder()
                        sqlBuider.AppendLine("declare @ID  Varchar(20)")
                        sqlBuider.AppendLine("declare @Store varchar(20)")
                        sqlBuider.AppendLine("declare @LastID varchar(20)")
                        sqlBuider.AppendLine("declare @sID varchar(20)")
                        sqlBuider.AppendLine("declare @MsgTmp varchar(200)")
                        sqlBuider.AppendLine("declare @GHX varchar(20)")
                        sqlBuider.AppendLine("set @LastID=''")
                        sqlBuider.AppendLine("set @MsgTmp=''")
                        sqlBuider.AppendLine("select ID as PID into #L from T40101_PBRK_List where GH=@GH")
                        sqlBuider.AppendLine("update T40101_PBRK_List set GH='',PB=0,Old_PB=null,cp=0 where GH=@GH")
                        sqlBuider.AppendLine("declare my_cursor cursor for  select distinct ID,StoreNo,GH from #L,T40101_PBRK_List  where PID=ID")
                        sqlBuider.AppendLine("order by id,StoreNo")
                        sqlBuider.AppendLine("Open my_cursor")
                        sqlBuider.AppendLine("fetch my_cursor into @sID,@Store,@GHX")
                        sqlBuider.AppendLine("while @@fetch_status=0")
                        sqlBuider.AppendLine("begin")
                        sqlBuider.AppendLine("	if( @GHX='') set @MsgTmp=@MsgTmp+@Store +'|'")
                        sqlBuider.AppendLine("        set @LastID=@sID")
                        sqlBuider.AppendLine("        fetch my_cursor into @sID,@Store,@GHX")
                        sqlBuider.AppendLine("        if @LastID<>@sID or @@fetch_status<>0")
                        sqlBuider.AppendLine("        begin")
                        sqlBuider.AppendLine("        	if len(@MsgTmp)>0 set @MsgTmp=left(@MsgTmp,len(@MsgTmp)-1)")
                        sqlBuider.AppendLine("            	update T40100_PBRK_Table ")
                        sqlBuider.AppendLine("		set CangWei=@MsgTmp,")
                        sqlBuider.AppendLine("		RemainCount=(select count(*) from T40101_PBRK_List where ID=@LastID and GH=''),")
                        sqlBuider.AppendLine("		RemainWeight=isnull((select sum(ZL) from T40101_PBRK_List where ID=@LastID and GH='') ,0)")
                        sqlBuider.AppendLine("            	where id=@LastID")
                        sqlBuider.AppendLine("            	set @MsgTmp=''")
                        sqlBuider.AppendLine("        end")
                        sqlBuider.AppendLine("end")
                        sqlBuider.AppendLine("close my_cursor")
                        sqlBuider.AppendLine("deallocate my_cursor")
                        'sqlBuider.AppendLine(SQL_Update_byClear)
                        'sqlBuider.AppendLine(SQL_DEL_Store)



                        If H.UpdateAll(True, sqlBuider.ToString, "GH", GH).IsOk Then
                            R.IsOk = True
                            R.Msg = "清除配布成功!"
                        Else
                            R.IsOk = False
                            R.Msg = "清除配布失败," & H.Msg
                        End If
                    Else
                        R.IsOk = False
                        R.Msg = "清除配布失败,缸号[" & GH & "]当前状态是[" & ComFun.GetProduceStateName(H.DtList("G").Rows(0)("State")) & "],不能清除配布!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "清除配布失败,缸号[" & GH & "]不存在!"
                End If
            Else
                R.IsOk = False
                R.Msg = "清除配布失败," & R.Msg
            End If
        End Using
        Return R
    End Function


    Public Shared Function SCPB_GetGH_ByID(ByVal ID As String) As DtReturnMsg
        Return SqlStrToDt(SQL_SCPB_GetGH_ByID, "@GH", ID)
    End Function

    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SCPB_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_ProduceGd_Get_SCPB)
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
    Public Shared Function SCPB_GetConditionNames() As List(Of FindOption)
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



    Public Shared IsInsert As Boolean = True

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <param name="PB_Date"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SCPB_Save(ByVal GH As String, ByVal PB_Date As Date, ByVal dtList As DataTable, ByVal InsterSql As String, ByVal IsNum As Boolean) As MsgReturn
        Dim S As New StringBuilder("")
        Dim PB As Double = 0
        Dim C As Integer = 0
        Dim PBRK_ID As String = ""


        S.AppendLine("declare @State int")
        S.AppendLine("declare @Err Varchar(8000)")
        S.AppendLine("set @State=(select top 1 isnull(State,'-1')State from T30000_Produce_Gd where GH=@GH)")
        S.AppendLine("set @Err=''")
        If WNGH = GH Then
            S.AppendLine("if 1=0")
            S.AppendLine("select N'Error=state;缸号不是待配布状态'")
            S.AppendLine("else")
            S.AppendLine("begin")
            S.AppendLine("begin tran T")

            If IsInsert Then
                S.AppendLine("Update T30000_Produce_Gd set PB_ZLSum=@PB_ZLSum+PB_ZLSum,PB_CountSum=@PB_CountSum+PB_CountSum")
                S.AppendLine("where GH=@GH")
            Else
                S.AppendLine("Update T30000_Produce_Gd set PB_ZLSum=@PB_ZLSum,PB_CountSum=@PB_CountSum")
                S.AppendLine("where GH=@GH")
                S.AppendLine("update T40101_PBRK_List set GH='',PB=0,CP=0 where GH=@GH")
            End If

            If dtList.Rows.Count > 0 Then '取第一个入库单的收坯时间
                PBRK_ID = dtList.Rows(0)("ID")
            End If
            For Each R As DataRow In dtList.Rows
                S.AppendLine("update T40101_PBRK_List set GH=@GH,PB=" & R("PB") & ",CK_Date=@Date_PeiBu where GH='' and Line=" & R("Line"))
                S.AppendLine("if @@Rowcount=0 set @Err=@Err + '" & R("Line") & "' + ','")
                PB = PB + R("PB")
                C = C + 1
            Next


        Else
            S.AppendLine("if @State<>@PB_State")
            S.AppendLine("select N'Error=state;缸号不是待配布状态'")
            S.AppendLine("else")
            S.AppendLine("begin")
            S.AppendLine("begin tran T")
            S.AppendLine("Update T30000_Produce_Gd set PB_ZLSum=@PB_ZLSum,PB_CountSum=@PB_CountSum")
            S.AppendLine(",Date_PeiBu=@Date_PeiBu,PB_User=@PB_User")
            If IsNum Then
                S.AppendLine(",CR_LuoSeBzCount=@PB_CountSum,UPD_User=@PB_User,UPD_Date=GetDate()")
                S.AppendLine(",State=@Next_State,Date_ShouPei=(select top 1 sDate from T40100_PBRK_Table where ID=@ID)")
                S.AppendLine(",ShaPi=(select  top 1 ShaPi from T40100_PBRK_Table where ID=@ID)")
            End If
            S.AppendLine("where GH=@GH")
            S.AppendLine("update T40101_PBRK_List set GH='',PB=0,CP=0 where GH=@GH")

            If dtList.Rows.Count > 0 Then '取第一个入库单的收坯时间
                PBRK_ID = dtList.Rows(0)("ID")
            End If
            For Each R As DataRow In dtList.Rows
                S.AppendLine("update T40101_PBRK_List set GH=@GH,PB=" & R("PB") & " where GH='' and Line=" & R("Line"))
                S.AppendLine("if @@Rowcount=0 set @Err=@Err + '" & R("Line") & "' + ','")
                PB = PB + R("PB")
                C = C + 1
            Next

        End If

        S.AppendLine("declare @PID  Varchar(20)")
        S.AppendLine("declare @Store varchar(20)")
        S.AppendLine("declare @LastID varchar(20)")
        S.AppendLine("declare @sID varchar(20)")
        S.AppendLine("declare @MsgTmp varchar(200)")
        S.AppendLine("declare @GHX varchar(20)")
        S.AppendLine("set @LastID=''")
        S.AppendLine("set @MsgTmp=''")
        S.AppendLine("select distinct ID as PID into #L from T40101_PBRK_List where GH=@GH")
        S.AppendLine("declare my_cursor cursor for  select distinct ID,StoreNo,GH from #L,T40101_PBRK_List  where PID=ID")
        S.AppendLine("order by id,StoreNo")
        S.AppendLine("Open my_cursor")
        S.AppendLine("fetch my_cursor into @sID,@Store,@GHX")
        S.AppendLine("while @@fetch_status=0")
        S.AppendLine("begin")
        S.AppendLine("	if( @GHX='') set @MsgTmp=@MsgTmp+@Store +'|'")
        S.AppendLine("        set @LastID=@sID")
        S.AppendLine("        fetch my_cursor into @sID,@Store,@GHX")
        S.AppendLine("        if @LastID<>@sID or @@fetch_status<>0")
        S.AppendLine("        begin")
        S.AppendLine("        	if len(@MsgTmp)>0 set @MsgTmp=left(@MsgTmp,len(@MsgTmp)-1)")
        S.AppendLine("            	update T40100_PBRK_Table ")
        S.AppendLine("		set CangWei=@MsgTmp,")
        S.AppendLine("		RemainCount=(select count(*) from T40101_PBRK_List where ID=@LastID and GH=''),")
        S.AppendLine("		RemainWeight=isnull((select sum(ZL) from T40101_PBRK_List where ID=@LastID and GH='') ,0)")
        S.AppendLine("            	where id=@LastID")
        S.AppendLine("            	set @MsgTmp=''")
        S.AppendLine("        end")
        S.AppendLine("end")
        S.AppendLine("close my_cursor")
        S.AppendLine("deallocate my_cursor")



        S.AppendLine("if @Err<>''")
        S.AppendLine("begin")
        S.AppendLine("rollback")
        S.AppendLine("set @Err=N'Error=gh;' + @Err")
        S.AppendLine("select @Err")
        S.AppendLine("end")
        S.AppendLine("else")
        S.AppendLine("begin")
        S.AppendLine("commit")
        S.AppendLine("select N'Error=no;'")
        S.AppendLine("end")
        S.AppendLine("end")
        S.AppendLine(InsterSql)
        S.AppendLine(SQL_UpdateStore)
        Dim P As New Dictionary(Of String, Object)
        P.Add("@GH", GH)
        P.Add("@Date_PeiBu", PB_Date.ToString("yyyy-MM-dd"))
        P.Add("@PB_State", Enum_ProduceState.XiaDan)
        P.Add("@PB_ZLSum", PB)
        P.Add("@PB_CountSum", C)
        P.Add("@ID", PBRK_ID)
        P.Add("@PB_User", User_Name)
        P.Add("@Next_State", Enum_ProduceState.PeiBu)

        Dim Rm As MsgReturn = SqlStrToOneStr(S.ToString, P)
        If Rm.IsOk Then
            Dim Sp() As String = Rm.Msg.Split("=")
            If Sp(1).StartsWith("no") Then
                Rm.Msg = "保存配布单成功!"
                Rm.IsOk = True
            Else
                Rm.IsOk = False
                If Sp(1).StartsWith("state") Then
                    Rm.Msg = "1保存配布单失败,原因:" & "缸号[" & GH & "]不在代配布状态"
                Else
                    If Sp(1).StartsWith("gh") Then
                        Sp = Rm.Msg.Split(";")
                        Rm.Msg = "2保存配布单失败;" & Sp(1)
                    Else

                        Rm.Msg = "9保存配布单失败,原因:未知"
                    End If
                End If
            End If
        Else
            Rm.Msg = "9保存配布单失败,原因:" & Rm.Msg
        End If
        Return Rm

    End Function


#End Region




    ''' <summary>
    ''' 配布出库单添加
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PB_Add_Store(ByVal Bill_ID As String, ByVal dtStore As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", Bill_ID)
        sqlMap.Add("Store", SQL_GetStoreNo_ByID)
        Try
            Using DTH As New DtHelper(sqlMap, paraMap)
                If DTH.IsOk = False Then
                    Throw New Exception(DTH.Msg)
                Else
                    DvToDt(dtStore, DTH.DtList("Store"), New List(Of String))
                    Dim TmSQL As String = SQL_UpdateStore
                    R = DTH.UpdateAll(True, TmSQL, "ID", Bill_ID)               
                End If
            End Using
            Return R
        Catch ex As Exception
            R.IsOk = False
            DebugToLog(ex)
            Return R
        End Try
    End Function








End Class

