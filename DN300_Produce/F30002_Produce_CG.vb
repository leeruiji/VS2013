Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F30002_Produce_CG

    Dim isloaded As Boolean = False
    Dim ZL As Double
    Dim Num As Double
    Dim CG As Boolean = False
    Dim DtoldStore As DataTable
    Dim DtNewStore As DataTable
    Dim dtList As DataTable
    Public Sub New(ByVal LF As F30001_Produce_Gd_Msg, Optional ByVal _CG As Boolean = True, Optional ByVal ZYGH As String = "")
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        TB_BZCID.Text = LF.Cb_BZC.Text
        TB_BZCName.Text = LF.TB_BZCName.Text
        TB_BZID.Text = LF.CB_BZ.Text
        TB_BZName.Text = LF.TB_BZName.Text
        TB_ClientBZC.Text = LF.TB_ClientBZC.Text
        TB_ClientName.Text = LF.TB_ClientName.Text
        TB_GenDan.Text = LF.TB_GenDan.Text
        TB_GH.Text = LF.TB_ID.Text
        TB_KaiDan.Text = User_Display


        TB_NewGH.Text = ""
        TB_New_PB_CountSum.Text = 0
        TB_New_PB_ZLSum.Text = 0

        TB_PB_CountSum.Text = LF.TB_PB_CountSum.Text
        TB_PB_ZLSum.Text = LF.TB_PB_ZLSum.Text
        TB_Remark.Text = LF.TB_Remark.Text
        ZL = TB_PB_ZLSum.Text
        Num = TB_PB_CountSum.Text
        Me.LastForm = LF
        CG = _CG
        If CG = False Then
            TB_NewGH.Text = ZYGH

            If ZYGH = "" Then
                Close()
            End If
        End If


        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub


    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 30000
    End Sub


    Private Sub Form_Msg_Load() Handles Me.Me_Load

        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        If CG Then
            Me.Title = Ch_Name & "拆缸"
        Else
            Me.Title = Ch_Name & "转移"
        End If


        AddAutoGoNext()
        FormCheckRight()
        isloaded = True
        Employee_List1.Set_TextBox(TB_GenDan, TB_Remark)
        Employee_List1.SearchType = Employee_List.ENum_SearchType.FormatSet
        Employee_List1.SearchId = "E_CK"


        Fg3.IniFormat()
        If CG Then
            Dim RS As DtReturnMsg = Dao.Produce_GetCPList(TB_GH.Text)
            If RS.IsOk Then
                Fg3.DtToFG(RS.Dt)
                RS.Dt = DtoldStore
                'LockForm(True)
            End If
            Dim R As MsgReturn = Dao.Produce_GetCGGH(TB_GH.Text)
            If R.IsOk = True Then
                TB_NewGH.Text = R.Msg
                Dim Rt As DtReturnMsg = Dao.Produce_GetPBList(TB_GH.Text)
                If Rt.IsOk Then
                    Fg1.DtToFG(Rt.Dt)
                    SumZL()
                End If
            Else
                Close()
            End If
        Else

            Dim Rt As DtReturnMsg = Dao.Produce_GetPBList(TB_GH.Text)
            If Rt.IsOk Then
                Fg1.DtToFG(Rt.Dt)
                SumZL()
            End If

            Dim RGH As DtReturnMsg = Dao.Produce_GetGH(TB_NewGH.Text)

            If RGH.IsOk AndAlso RGH.Dt.Rows.Count > 0 Then
                If RGH.Dt.Rows(0)("State") < Enum_ProduceState.PeiBu Then
                    ShowErrMsg("缸号[" & TB_NewGH.Text & "]没有配布,不能转移!", True)
                    Exit Sub
                End If
                ZL = RGH.Dt.Rows(0)("PB_ZLSum") + ZL
                Num = RGH.Dt.Rows(0)("PB_CountSum") + Num
                TB_New_PB_CountSum.Text = RGH.Dt.Rows(0)("PB_CountSum")
                TB_New_PB_ZLSum.Text = RGH.Dt.Rows(0)("PB_ZLSum")
                TB_Remark.Text = IsNull(RGH.Dt.Rows(0)("Remark"), "")
                TB_KaiDan.Text = IsNull(RGH.Dt.Rows(0)("KaiDan"), "")
                TB_CGRemark.Text = IsNull(RGH.Dt.Rows(0)("CGRemark"), "")
            Else
                ShowErrMsg("没有找到缸号[" & TB_NewGH.Text & "]", True)
                Exit Sub
            End If


            Dim Rt2 As DtReturnMsg = Dao.Produce_GetPBList(TB_NewGH.Text)
            If Rt2.IsOk Then
                Fg2.DtToFG(Rt2.Dt)
                SumZL()
            End If
        End If
    End Sub
    'Sub LockForm(ByVal Lock As Boolean)
    '    Fg3.CanEditing = Not Lock
    '    Fg3.IsClickStartEdit = Not Lock
    'End Sub

#Region "自动跳格"

    Sub AddAutoGoNext()
        AddHandler TB_New_PB_CountSum.KeyDown, AddressOf AutoGoNext_KeyDown
        AddHandler TB_New_PB_ZLSum.KeyDown, AddressOf AutoGoNext_KeyDown

    End Sub


    Private Sub AutoGoNext_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = Keys.Down OrElse e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = False
            SendKeys.Send("{tab}")
        ElseIf e.KeyData = Keys.Up Then
            e.SuppressKeyPress = False
            SendKeys.Send("+{tab}")
        End If
    End Sub


#End Region


    Protected Function GetForm() As DataTable
        Fg3.FinishEditing()
        TB_GH.Focus()

        'DtNewStore = dtList.Clone
        Dim RS As DtReturnMsg = Dao.Produce_GetCPList(TB_GH.Text)

        DtoldStore = RS.Dt
        If Not DtNewStore Is Nothing Then
            DtNewStore.Clear()
        End If
        DtNewStore = DtoldStore.Clone
        Dim dr As DataRow
        For i As Integer = 1 To Fg3.Rows.Count - 1
            dr = DtNewStore.NewRow()
            dr("GH") = Fg3.Item(i, "GH")
            dr("StoreNo") = Fg3.Item(i, "StoreNo")
            dr("Qty") = Fg3.Item(i, "Qty")
            DtNewStore.Rows.Add(dr)
        Next

        Return DtNewStore
    End Function
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() = False Then
            Exit Sub
        End If

        Dim D As New Dictionary(Of Integer, String)
        For i As Integer = 1 To Fg1.Rows.Count - 1
            D.Add(Fg1.Item(i, "Line"), TB_GH.Text)
        Next
        For i As Integer = 1 To Fg2.Rows.Count - 1
            D.Add(Fg2.Item(i, "Line"), TB_NewGH.Text)
        Next
        If CG Then

            Dim R As MsgReturn = Dao.ProduceGd_CG(TB_GH.Text, TB_NewGH.Text, Val(TB_New_PB_ZLSum.Text), Val(TB_New_PB_CountSum.Text), TB_Remark.Text, TB_KaiDan.Text, TB_GenDan.Tag, D, TB_CGRemark.Text, DtNewStore)
            If R.IsOk Then
                LastForm.ReturnId = TB_NewGH.Text
                ShowOk(R.Msg, True)
            Else
                ShowErrMsg(R.Msg)
            End If
        Else
            Dim R As MsgReturn = Dao.ProduceGd_ZY(TB_GH.Text, TB_NewGH.Text, Val(TB_PB_ZLSum.Text), Val(TB_PB_CountSum.Text), Val(TB_New_PB_ZLSum.Text), Val(TB_New_PB_CountSum.Text), TB_Remark.Text, TB_GenDan.Tag, D, TB_CGRemark.Text)
            If R.IsOk Then
                LastForm.ReturnId = TB_GH.Text
                ShowOk(R.Msg, True)
            Else
                ShowErrMsg(R.Msg)
            End If
        End If
    End Sub

    Private Sub TB_New_PB_CountSum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_New_PB_CountSum.TextChanged
        TB_PB_CountSum.Text = Num - Val(TB_New_PB_CountSum.Text)
    End Sub



    Private Sub TB_New_PB_ZLSum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_New_PB_ZLSum.TextChanged
        TB_PB_ZLSum.Text = ZL - Val(TB_New_PB_ZLSum.Text)
    End Sub



    Function CheckForm() As Boolean
        GetForm()
        Dim RS As DtReturnMsg = Dao.Produce_GetCPList(TB_GH.Text)
        If RS.IsOk AndAlso RS.Dt.Rows.Count > 0 Then
            DtoldStore = RS.Dt
            If BaseClass.ComFun.CompareDt(DtoldStore, DtNewStore) = True Then
                ShowErrMsg("拆缸之后没有填写仓位信息", AddressOf TB_New_PB_ZLSum.Focus)
                Return False
            ElseIf Val(DtoldStore.Compute("Sum(Qty)", "")) <> Val(DtNewStore.Compute("Sum(Qty)", "")) Then
                ShowErrMsg("拆缸后库存总数[" & Val(DtNewStore.Compute("Sum(Qty)", "")) & "]不等于拆缸前总数[" & Val(DtoldStore.Compute("Sum(Qty)", "")) & "]", AddressOf TB_New_PB_ZLSum.Focus)
                Return False
            End If

        End If

        If Val(TB_New_PB_ZLSum.Text) <= 0 Then
            ShowErrMsg("拆缸之后的重量不能小于等于0!", AddressOf TB_New_PB_ZLSum.Focus)
            Return False
        End If

        If Val(TB_PB_CountSum.Text) <= 0 Then
            ShowErrMsg("拆缸之后的条数不能小于等于0!", AddressOf TB_PB_CountSum.Focus)
            Return False
        End If


        If TB_CGRemark.Text = "" Then
            ShowErrMsg("拆缸原因不能为空!", AddressOf TB_CGRemark.Focus)
            Return False
        End If




        Return True
    End Function

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Close()
    End Sub

#Region "增加减少"
    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        If Fg1.RowSel > 0 Then
            Dim R As C1.Win.C1FlexGrid.Row = Fg2.Rows.Add()
            R("ID") = Fg1.Item(Fg1.RowSel, "ID")
            R("PB") = Fg1.Item(Fg1.RowSel, "PB")
            R("Line") = Fg1.Item(Fg1.RowSel, "Line")
            Fg2.ReAddIndex()
            Try
                Fg1.RemoveRow()
            Catch ex As Exception
            End Try
            SumZL()
        End If
    End Sub

    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        If Fg2.RowSel > 0 Then
            Dim R As C1.Win.C1FlexGrid.Row = Fg1.Rows.Add()
            R("ID") = Fg2.Item(Fg2.RowSel, "ID")
            R("PB") = Fg2.Item(Fg2.RowSel, "PB")
            R("Line") = Fg2.Item(Fg2.RowSel, "Line")
            Fg1.ReAddIndex()
            Try
                Fg2.RemoveRow()
            Catch ex As Exception
            End Try
            SumZL()
        End If
    End Sub
    Private Sub Cmd_FGAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FGAdd.Click
        Fg1_DoubleClick(Fg1, New EventArgs)
    End Sub

    Private Sub Cmd_FGDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FGDel.Click
        Fg2_DoubleClick(Fg2, New EventArgs)
    End Sub
    Private Sub TB_New_PB_CountSum_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_New_PB_CountSum.Click
        Cmd_QtyChange_Click(Cmd_QtyChange, New EventArgs)
    End Sub


    Private Sub Cmd_QtyChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_QtyChange.Click
        ShowInput("请输入新缸的条数(0-" & Num & "):", AddressOf InputReturn, TB_New_PB_CountSum.Text)
    End Sub

    Sub InputReturn(ByVal Str As String)
        Dim Q As Integer = Math.Abs(Val(Str))
        If Q > Num Then
            ShowErrMsg("你输入的数量[" & Q & "]大于原缸条数[" & Num & "]")
        Else
            Fg1.Redraw = False
            Fg2.Redraw = False
            Try
                Do Until Fg2.Rows.Count > Q
                    Fg1_DoubleClick(Fg1, New EventArgs)
                Loop
                Do Until Fg2.Rows.Count <= Q + 1
                    Fg2_DoubleClick(Fg2, New EventArgs)
                Loop
            Catch ex As Exception
            End Try
            Fg1.Redraw = True
            Fg2.Redraw = True
        End If
    End Sub

    Sub SumZL()
        TB_New_PB_CountSum.Text = Fg2.Rows.Count - 1
        Dim ZL_New As Double = 0
        For i As Integer = 1 To Fg2.Rows.Count - 1
            ZL_New = ZL_New + Fg2.Item(i, "PB")
        Next
        TB_New_PB_ZLSum.Text = ZL_New
    End Sub
#End Region

    Private Sub Fg3_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg3.NextCell

        Select Case e.Col
            Case "GH"
                e.ToCol = Fg3.Cols("StoreNo").Index

            Case "StoreNo"
                e.ToCol = Fg3.Cols("Qty").Index
            Case "Qty"
                If e.Row + 2 > Fg3.Rows.Count Then
                    Fg3AddRow()
                    Fg3.Item(e.Row + 1, "GH") = TB_NewGH.Text
                End If
                e.ToRow = e.Row + 1
                e.ToCol = 1
        End Select
    End Sub
    Private Sub Fg3AddRow()
        Fg3.AddRow()
    End Sub
    Private Sub Fg3_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg3.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg3.LastKey = Keys.Enter Then
            Fg3.LastKey = 0
            Select Case Fg3.Cols(e.Col).Name

                Case "GH"
                   Fg3.GotoNextCell(e.Col)
                Case "StoreNo"
                    Fg3.GotoNextCell(e.Col)
                Case "Qty"
                    Fg3.GotoNextCell(e.Col)

            End Select
        End If

    End Sub

    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Fg3.RemoveRow()
    End Sub
End Class


Partial Class Dao
 
    ''' <summary>
    ''' 获取某个缸号的配布信息
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Produce_GetGH(ByVal GH As String) As DtReturnMsg
        Return SqlStrToDt("select KaiDan,GH,Remark,PB_ZLSum,PB_CountSum,State,CR_LuoSeBzCount,CGRemark from T30000_Produce_Gd where GH=@GH", "GH", GH)
    End Function


    ''' <summary>
    ''' 增加拆缸 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_CG(ByVal GH As String, ByVal GH_New As String, ByVal PB_ZLSum As Double, ByVal PB_CountSum As Double, ByVal Remark_New As String, ByVal KaiDan_New As String, ByVal GenDan_New As Integer, ByVal D As Dictionary(Of Integer, String), ByVal CGRemark As String, ByVal dtStore As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)

        paraMap.Add("@GH", GH)
        sqlMap.Add("CG", SQL_ProduceGd_GetCGByID)
        sqlMap.Add("Produce", SQL_ProduceGd_GetByID)
        paraMap.Add("@CG", GH_New)

        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("Produce").Rows.Count = 1 Then
                If msg.DtList("CG").Rows.Count = 1 Then
                    returnMsg.IsOk = False
                    returnMsg.Msg = "运转单[" & GH_New & "]已经存在!,请退出再重新拆缸!"
                    Return returnMsg
                End If
                Dim TmSQL As New System.Text.StringBuilder("")
                ' TmSQL.AppendLine("ALTER  TABLE  T40101_PBRK_List  DISABLE  TRIGGER  T40101_PBRK_List_Update ")
                TmSQL.Append("insert into Bill_Barcode (No_ID,NO_Type)values('")
                TmSQL.Append(GH_New)
                TmSQL.Append("',")
                TmSQL.Append(BillType.Produce)
                TmSQL.AppendLine(")")
                ''已领料后拆缸的吧新缸号设置为IsChongRa=1
                TmSQL.AppendLine("declare @LingLiaoCount int")
                TmSQL.AppendLine("Select @LingLiaoCount= Count(ID) from T20310_LingLiao_Table where Produce_ID=@GH and State=1")
                TmSQL.AppendLine("if @LingLiaoCount>0")
                TmSQL.AppendLine("update T30000_Produce_Gd set IsChongRan=1 where GH=@GH")

                If dtStore IsNot Nothing AndAlso dtStore.Rows.Count > 0 Then
                    TmSQL.AppendLine("insert into T40521_PB_Detail  (StoreNo,ID,GH,InQty,BillType,BillName) select StoreNo,GH,GH,Qty*-1,30000,'拆缸'from T30002_CPRK  where GH=@GH ")
                    TmSQL.AppendLine("delete T30002_CPRK   where GH=@GH")
                    TmSQL.AppendLine("delete T40520_PB_StoreNo   where ID=@GH")
                    For Each drStore As DataRow In dtStore.Rows
                        TmSQL.AppendLine("insert into T40520_PB_StoreNo  (StoreNo,ID,Qty,BZType) values ('" & drStore("StoreNo") & "','" & drStore("GH") & "','" & drStore("Qty") & "',1) ")
                        TmSQL.AppendLine("insert into T30002_CPRK  (StoreNo,GH,Qty) values ('" & drStore("StoreNo") & "','" & drStore("GH") & "','" & drStore("Qty") & "') ")
                        TmSQL.AppendLine("insert into T40521_PB_Detail  (StoreNo,ID,GH,InQty,BillType,BillName) values ('" & drStore("StoreNo") & "','" & drStore("GH") & "','" & drStore("GH") & "','" & drStore("Qty") & "','" & "30000" & "','" & "拆缸" & "') ")

                    Next

                End If

                'TmSQL.AppendLine("update T30002_CPRK set GH=@GH  where GH=@GH")
                'TmSQL.AppendLine("update T40520_PB_StoreNo  set ID=@GH where ID=@GH")
                'TmSQL.AppendLine("insert into T40520_PB_StoreNo  (StoreNo,ID,Qty) select StoreNo,GH,Qty from T30002_CPRK  where GH=@CG ")
                'TmSQL.AppendLine("insert into T40521_PB_Detail  (StoreNo,ID,GH,InQty,BillType,BillName) select StoreNo,GH,GH,Qty,30000,'拆缸' from T30002_CPRK  where GH=@CG ")


                ''  TmSQL.AppendLine("update T30000_Produce_Gd set IsChongRan=2 where GH=@CG")
                Dim P As New Dictionary(Of String, Object)
                P.Add("@GH", GH)

                P.Add("@CG", GH_New)
                Dim I As Integer = 1
                For Each K As KeyValuePair(Of Integer, String) In D
                    TmSQL.Append("Update T40101_PBRK_List set GH=@GH")
                    TmSQL.Append(I)
                    P.Add("GH" & I, K.Value)
                    TmSQL.Append(" where Line=@Line")
                    TmSQL.AppendLine(I)
                    P.Add("Line" & I, K.Key)
                    I = I + 1
                Next

                DvToDt(msg.DtList("Produce"), msg.DtList("CG"), New List(Of String), False)
                Dim Dr As DataRow = msg.DtList("Produce").Rows(0)
                Dr("PB_CountSum") = Dr("PB_CountSum") - PB_CountSum
                Dr("CR_LuoSeBzCount") = Dr("CR_LuoSeBzCount") - PB_CountSum
                Dr("PB_ZLSum") = Dr("PB_ZLSum") - PB_ZLSum
                If Dr("PB_CountSum") < 0 OrElse Dr("PB_ZLSum") < 0 Then
                    returnMsg.IsOk = False
                    returnMsg.Msg = "运转单[" & GH & "]拆缸之后,条数或重量为零,拆缸失败!"
                    Return returnMsg
                End If
                Dr("UPD_User") = User_Name
                Dr("UPD_Date") = GetDate()

                Dr = msg.DtList("CG").Rows(0)
                Dr("PB_CountSum") = PB_CountSum
                Dr("CR_LuoSeBzCount") = PB_CountSum
                Dr("PB_ZLSum") = PB_ZLSum
                Dr("Remark") = Remark_New
                Dr("CGRemark") = CGRemark
                Dr("KaiDan") = KaiDan_New
                Dr("GengDan") = GenDan_New
                Dr("GH") = GH_New
                Dr("UPD_User") = User_Name
                Dr("UPD_Date") = GetDate()

                '  TmSQL.AppendLine("ALTER  TABLE  T40101_PBRK_List  ENABLE    TRIGGER  T40101_PBRK_List_Update ")
                DtToUpDate(msg, TmSQL.ToString, P)
                returnMsg.IsOk = True
                returnMsg.Msg = "运转单[" & GH_New & "]添加成功!"
            ElseIf msg.DtList("Produce").Rows.Count = 0 Then
                returnMsg.IsOk = False
                returnMsg.Msg = "运转单[" & GH & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "添加" & Produce_Gd_Name & "失败!"
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 增加转移
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_ZY(ByVal GH As String, ByVal GH_New As String, ByVal PB_ZLSum As Double, ByVal PB_CountSum As Double, ByVal PB_New_ZLSum As Double, ByVal PB_New_CountSum As Double, ByVal Remark_New As String, ByVal GenDan_New As Integer, ByVal D As Dictionary(Of Integer, String), ByVal CGRemark As String) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)

        paraMap.Add("@GH", GH)
        sqlMap.Add("CG", SQL_ProduceGd_GetCGByID)
        sqlMap.Add("Produce", SQL_ProduceGd_GetByID)
        paraMap.Add("@CG", GH_New)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("Produce").Rows.Count = 1 Then
                If msg.DtList("CG").Rows.Count = 0 Then
                    returnMsg.IsOk = False
                    returnMsg.Msg = "运转单[" & GH_New & "]不存在,请退出再转移!"
                    Return returnMsg
                End If
                Dim TmSQL As New System.Text.StringBuilder("")
                Dim P As New Dictionary(Of String, Object)
                Dim I As Integer = 1
                '   TmSQL.AppendLine("ALTER  TABLE  T40101_PBRK_List  DISABLE  TRIGGER  T40101_PBRK_List_Update   ")
                For Each K As KeyValuePair(Of Integer, String) In D
                    TmSQL.Append("Update T40101_PBRK_List set GH=@GH")
                    TmSQL.Append(I)
                    P.Add("GH" & I, K.Value)
                    TmSQL.Append(" where Line=@Line")
                    TmSQL.AppendLine(I)
                    P.Add("Line" & I, K.Key)
                    I = I + 1
                Next
                '   TmSQL.AppendLine("ALTER  TABLE  T40101_PBRK_List  ENABLE  TRIGGER  T40101_PBRK_List_Update   ")
                Dim Dr As DataRow = msg.DtList("Produce").Rows(0)
                Dr("PB_CountSum") = PB_CountSum
                Dr("CR_LuoSeBzCount") = PB_CountSum
                Dr("PB_ZLSum") = PB_ZLSum
                If Dr("PB_CountSum") < 0 OrElse Dr("PB_ZLSum") < 0 Then
                    returnMsg.IsOk = False
                    returnMsg.Msg = "运转单[" & GH & "]转移之后,条数或重量为零,转移失败!"
                    Return returnMsg
                End If
                Dr("UPD_User") = User_Name
                Dr("UPD_Date") = GetDate()
                Dr = msg.DtList("CG").Rows(0)
                Dr("PB_CountSum") = PB_New_CountSum
                Dr("CR_LuoSeBzCount") = PB_New_CountSum
                Dr("PB_ZLSum") = PB_New_ZLSum
                Dr("Remark") = Remark_New
                Dr("CGRemark") = CGRemark
                Dr("GengDan") = GenDan_New
                Dr("GH") = GH_New
                Dr("UPD_User") = User_Name
                Dr("UPD_Date") = GetDate()
                DtToUpDate(msg, TmSQL.ToString, P)
                returnMsg.IsOk = True
                returnMsg.Msg = "运转单[" & GH_New & "]转移成功!"
            ElseIf msg.DtList("Produce").Rows.Count = 0 Then
                returnMsg.IsOk = False
                returnMsg.Msg = "运转单[" & GH & "]不存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "添加" & Produce_Gd_Name & "失败!"
        End Try
        Return returnMsg
    End Function
End Class