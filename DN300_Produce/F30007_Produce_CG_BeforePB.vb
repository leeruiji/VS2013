Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F30007_Produce_CG_BeforePB

    Dim isloaded As Boolean = False
    Dim Num As Double
    Dim CG As Boolean = False
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
        TB_New_CR_LuoSeBzCount.Text = 0
        TB_CR_LuoSeBzCount.Text = LF.TB_CR_LuoSeBzCount.Text
        TB_Remark.Text = LF.TB_Remark.Text

        Num = TB_CR_LuoSeBzCount.Text
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

      
        If CG Then
            Dim R As MsgReturn = Dao.Produce_GetCGGH(TB_GH.Text)
            If R.IsOk = True Then
                TB_NewGH.Text = R.Msg
            Else
                Close()
            End If
        Else


            Dim RGH As DtReturnMsg = Dao.Produce_GetGH(TB_NewGH.Text)

            If RGH.IsOk AndAlso RGH.Dt.Rows.Count > 0 Then
                If RGH.Dt.Rows(0)("State") >= Enum_ProduceState.PeiBu Then
                    ShowErrMsg("缸号[" & TB_NewGH.Text & "]已经配布,不能转移!", True)
                    Exit Sub
                End If
                Num = RGH.Dt.Rows(0)("CR_LuoSeBzCount") + Num
                TB_New_CR_LuoSeBzCount.Text = RGH.Dt.Rows(0)("CR_LuoSeBzCount")
                TB_Remark.Text = IsNull(RGH.Dt.Rows(0)("Remark"), "")
                TB_KaiDan.Text = IsNull(RGH.Dt.Rows(0)("KaiDan"), "")
                TB_CGRemark.Text = IsNull(RGH.Dt.Rows(0)("CGRemark"), "")
            Else
                ShowErrMsg("没有找到缸号[" & TB_NewGH.Text & "]", True)
                Exit Sub
            End If
        End If
    End Sub

#Region "自动跳格"

    Sub AddAutoGoNext()
        AddHandler TB_New_CR_LuoSeBzCount.KeyDown, AddressOf AutoGoNext_KeyDown


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

    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() = False Then
            Exit Sub
        End If
        If CG Then
            Dim R As MsgReturn = Dao.ProduceGd_CG_BeforePB(TB_GH.Text, TB_NewGH.Text, Val(TB_New_CR_LuoSeBzCount.Text), TB_Remark.Text, TB_KaiDan.Text, TB_GenDan.Tag, TB_CGRemark.Text)
            If R.IsOk Then
                LastForm.ReturnId = TB_NewGH.Text
                ShowOk(R.Msg, True)
            Else
                ShowErrMsg(R.IsOk)
            End If
        Else
            Dim R As MsgReturn = Dao.ProduceGd_ZY_BeforePB(TB_GH.Text, TB_NewGH.Text, Val(TB_CR_LuoSeBzCount.Text), Val(TB_New_CR_LuoSeBzCount.Text), TB_Remark.Text, TB_GenDan.Tag, TB_CGRemark.Text)
            If R.IsOk Then
                LastForm.ReturnId = TB_GH.Text
                ShowOk(R.Msg, True)
            Else
                ShowErrMsg(R.Msg)
            End If
        End If


    End Sub

    Private Sub TB_New_PB_CountSum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_New_CR_LuoSeBzCount.TextChanged
        TB_CR_LuoSeBzCount.Text = Num - Val(TB_New_CR_LuoSeBzCount.Text)
    End Sub






    Function CheckForm() As Boolean
        'If Val(TB_New_PB_ZLSum.Text) <= 0 Then
        '    ShowErrMsg("拆缸之后的重量不能小于等于0!", AddressOf TB_New_PB_ZLSum.Focus)
        '    Return False
        'End If
        If Val(TB_New_CR_LuoSeBzCount.Text) <= 0 Then
            ShowErrMsg("拆缸的条数不能小于等于0!", AddressOf TB_New_CR_LuoSeBzCount.Focus)
            Return False
        End If
        If Val(TB_CR_LuoSeBzCount.Text) <= 0 Then
            ShowErrMsg("拆缸之后的条数不能小于等于0!", AddressOf TB_New_CR_LuoSeBzCount.Focus)
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





End Class


Partial Class Dao

    ''' <summary>
    ''' 增加配布前拆缸 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_CG_BeforePB(ByVal GH As String, ByVal GH_New As String, ByVal PB_CountSum As Double, ByVal Remark_New As String, ByVal KaiDan_New As String, ByVal GenDan_New As Integer, ByVal CGRemark As String) As MsgReturn
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
                Dim TmSQL As New System.Text.StringBuilder("insert into Bill_Barcode (No_ID,NO_Type)values('")
                TmSQL.Append(GH_New)
                TmSQL.Append("',")
                TmSQL.Append(BillType.Produce)
                TmSQL.AppendLine(")")


                DvToDt(msg.DtList("Produce"), msg.DtList("CG"), New List(Of String), False)
                Dim Dr As DataRow = msg.DtList("Produce").Rows(0)

                If msg.DtList("Produce").Rows(0)("State") >= BaseClass.Enum_ProduceState.PeiBu Then
                    returnMsg.IsOk = False
                    returnMsg.Msg = "运转单[" & GH & "]已经被配布,请退出重新拆缸!"
                End If

                Dr("PB_CountSum") = 0
                Dr("PB_ZLSum") = 0
                Dr("CR_LuoSeBzCount") = Dr("CR_LuoSeBzCount") - PB_CountSum
                Dr("UPD_User") = User_Name
                Dr("UPD_Date") = GetDate()
                If Dr("CR_LuoSeBzCount") < 0 Then
                    returnMsg.IsOk = False
                    returnMsg.Msg = "运转单[" & GH & "]拆缸之后,条数为零,拆缸失败!"
                    Return returnMsg
                End If
                Dr = msg.DtList("CG").Rows(0)
                Dr("CR_LuoSeBzCount") = PB_CountSum
                Dr("PB_CountSum") = 0
                Dr("PB_ZLSum") = 0
                Dr("Remark") = Remark_New
                Dr("CGRemark") = CGRemark
                Dr("KaiDan") = KaiDan_New
                Dr("GengDan") = GenDan_New
                Dr("GH") = GH_New
                Dr("UPD_User") = User_Name
                Dr("UPD_Date") = GetDate()

                DtToUpDate(msg, TmSQL.ToString)
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
    Public Shared Function ProduceGd_ZY_BeforePB(ByVal GH As String, ByVal GH_New As String, ByVal PB_CountSum As Double, ByVal PB_New_CountSum As Double, ByVal Remark_New As String, ByVal GenDan_New As Integer, ByVal CGRemark As String) As MsgReturn
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

                Dim Dr As DataRow = msg.DtList("Produce").Rows(0)
                Dr("CR_LuoSeBzCount") = PB_CountSum
                If Dr("CR_LuoSeBzCount") < 0 Then
                    returnMsg.IsOk = False
                    returnMsg.Msg = "运转单[" & GH & "]转移之后,条数或重量为零,转移失败!"
                    Return returnMsg
                End If
                Dr = msg.DtList("CG").Rows(0)
                Dr("CR_LuoSeBzCount") = PB_New_CountSum
                Dr("Remark") = Remark_New
                Dr("CGRemark") = CGRemark
                Dr("GengDan") = GenDan_New
                Dr("GH") = GH_New
                DtToUpDate(msg)
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