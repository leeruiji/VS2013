Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30113_KF_Msg
    Dim line As Integer
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim state As Enum_ProduceState
    Dim stateSave As Enum_ProduceState
    Dim cz As String = ""

#Region "窗口定义"

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String, ByVal Line As Integer)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = initID
        Me.line = Line
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
    End Sub


    Private Sub Me_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
        End If
    End Sub


    'Private Sub F30201_CPZL_Msg_AfterLoad() Handles Me.AfterLoad
    '    TB_GH_Input.Focus()
    '    TB_Dqkg.Focus()
    'End Sub

    Private Sub F30202_CPZL_Input_Me_Closed() Handles Me.Me_Closed
        If F_RS_ID5 = "AutoClose" Then
            MainForm.CloseWindows()
        End If
    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        ID = 30112
        FormCheckRight()
        ShowGHInput()
        Ch_Name = GetBillTypeName(ID)

        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        Me_Refresh(0, 0)


        TB_Client_No.Tag = "0"
        'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                ' TB_ZhiDan.Text = User_Display
                LabelTitle.Text = Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                BenSet()
                TB_GH_Input.Focus()
            Case Mode_Enum.Modify
                Get_GH(Bill_ID)
                Me_Refresh(Bill_ID, line)
                LabelTitle.Text = Me.Ch_Name

        End Select


    End Sub

    Protected Sub Me_Refresh(ByVal GH As String, ByVal Line As String)
        Dim msg As DtReturnMsg = Dao.Get_KF(GH, Line)
        If msg.IsOk Then
            dtList = msg.Dt
            SetForm(msg.Dt)
        End If
    End Sub
    ''' <summary>
    ''' 缸号状态
    ''' </summary>
    ''' <remarks></remarks>
    'Private Sub GHState()
    '    RB_Dongchen.Checked = True
    '    RB_DingXing.Checked = False
    '    RB_YuDing.Checked = False
    'End Sub



#End Region

#Region "表单信息"

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)

        If dt Is Nothing Then
            Exit Sub
        End If
        If dt.Rows.Count = 1 Then
            Dim Dr As DataRow = dt.Rows(0)
            If Not Dr("sDate") Is DBNull.Value Then
                DTP_Date.Value = Dr("sDate")
            End If
            TB_Request.Text = Dr("Request")
            TB_Remark.Text = Dr("Remark")
            CB_Operator.Text = Dr("Operator")
            TB_Amount.Text = FormatNum(IsNull(Dr("Amount"), 0))
            TB_Quantity.Text = FormatNum(IsNull(Dr("Quantity"), ""))
            TB_CarNo.Text = Dr("CarNo")
            If IsNull(Dr("OrClass"), False) = True Then
                RB_morning.Checked = True
            Else
                RB_even.Checked = True
            End If

            If IsNull(Dr("isInvoid"), False) Then
                LabelState.Visible = True
            Else
                LabelState.Visible = False
            End If

        Else
            SetNull()
        End If
    End Sub

    ''' <summary>
    ''' 清空表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetNull()
        TB_Request.Text = ""
        TB_Remark.Text = ""
        CB_Operator.Text = ""
    End Sub


    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtList.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("GH") = TB_GH2.Text
            dr("Request") = TB_Request.Text
            dr("Remark") = TB_Remark.Text
            dr("sDate") = DTP_Date.Text
            dr("Operator") = CB_Operator.Text
            dr("OrClass") = RB_morning.Checked
            dr("Request") = TB_Request.Text
            dr("Amount") = Val(TB_Amount.Text)
            dr("isInvoid") = LabelState.Visible
            dr("Quantity") = Val(TB_Quantity.Text)
            dr("CarNo") = TB_CarNo.Text
            dt.Rows.Add(dr)
        End If
        Return dt
    End Function




    Private JZ As Double = 0
#End Region

#Region "工具栏按钮"



    Sub DoNothing()

    End Sub

    Dim isPrint As Boolean = False



    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' 

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click ' 关闭
        Me.Close()
    End Sub

    ''' <summary>
    '''设置当前缸号状态
    ''' </summary>
    ''' <remarks></remarks>
    'Private Function SetGhState() As Enum_ProduceState
    '    Dim stat As Enum_ProduceState
    '    If RB_Dongchen.Checked = False Then
    '        If RB_YuDing.Checked = True Then
    '            stat = Enum_ProduceState.YuDing
    '        ElseIf RB_DingXing.Checked = True Then
    '            stat = Enum_ProduceState.DingXing
    '        End If
    '    Else
    '        stat = 0
    '    End If
    '    Return stat
    'End Function


    Private Sub Save(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click  '保存退出
        If Mode = Mode_Enum.Add Then
            ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf saveDprocessE)
        Else

            ShowConfirm("是否保存" & Ch_Name & " 的修改?", AddressOf saveDprocessE)
        End If

    End Sub

    Private Sub Cmd_sAndr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_sAndr.Click '保存返回
        If Mode = Mode_Enum.Add Then
            ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf saveDprocessR)
        Else
            ShowConfirm("是否保存" & Ch_Name & " 的修改?", AddressOf saveDprocessR)
        End If
    End Sub


    Private Sub saveDprocessE() '保存退出
        SaveDProcess()
    End Sub

    Private Sub saveDprocessR() '保存返回
        SaveDProcess(True)
    End Sub

    Protected Sub SaveDProcess(Optional ByVal Retrun As Boolean = False)
        'Dim stat As Enum_ProduceState = SetGhState()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.KF_Add(Dt)
        Else
            R = Dao.KF_Save(Dt, line)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_GH2.Text
            LastForm.ReturnObj = Dt
            If Retrun = False Then
                ShowOk(R.Msg, True)
            Else
                'ShowOk(R.Msg, False)
                Me.Mode = Mode_Enum.Add
                SetNull()
                ShowGHInput()

            End If
        Else
            ShowErrMsg(R.Msg)
        End If

    End Sub

    Private Sub Cmd_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Return.Click '返回按钮
        ShowGHInput()

    End Sub

    'Private Sub CB_Remark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)  '备注选中预定时状态选中预定
    '    If TB_Remark.Text = "预定" AndAlso RB_YuDing.Enabled = True Then
    '        RB_YuDing.Checked = True
    '    End If
    'End Sub

    Private Sub TB_GH_Input_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH_Input.KeyPress
        If e.KeyChar = vbCr Then
            e.KeyChar = ""
            Get_GH(TB_GH_Input.Text)
        ElseIf e.KeyChar = "+" Then
            e.KeyChar = ""
            Get_GH(TB_GH_Input.Text)
        ElseIf e.KeyChar = "-" Then
            e.KeyChar = Chr(Keys.Back)
        ElseIf e.KeyChar = "*" Then
            e.KeyChar = ""
            Me.Close()
        End If
    End Sub

    Private Sub Cmd_Input_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Input_OK.Click  '
        Get_GH(TB_GH_Input.Text)
    End Sub

    Private Sub Cmd_Input_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Input_Exit.Click
        Me.Close()
    End Sub


#End Region

#Region "报表事件"








#End Region

#Region "选缸号"

    Sub Get_GH(ByVal id As String)
        LabelErr.Text = ""
        id = ComFun.FixGH(id)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(id)
        If Mr.IsOk = False Then
            ShowErrMsg(Mr.Msg)
            Exit Sub
        End If
        id = Mr.Msg

        Dim R As DtReturnMsg = Dao.CPZL_GetGH_ByID(id)
        If R.IsOk = False Then
            LabelErr.Text = "查询缸号失败!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            LabelErr.Text = "缸号[" & id & "不存在]!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If

        Dim Dr As DataRow = R.Dt.Rows(0)
        If IsNull(Dr("IsTP"), False) Then
            LabelErr.Text = "缸号[" & id & "]是退胚缸不能操作!"
            TB_GH_Input.Focus()
            TB_GH_Input.SelectAll()
            Exit Sub
        End If
        'state = IsNull(Dr("State"), 0)
        'If IsNull(Dr("State"), 0) > Enum_ProduceState.RanSe AndAlso IsNull(Dr("State"), 0) < Enum_ProduceState.ChengJian Then
        '    If IsNull(Dr("CR_LuoSeBzCount"), 0) <> IsNull(Dr("PB_CountSum"), 0) Then
        '        LabelErr.Text = "缸号[" & id & "]胚布条数和落色条数不一致,不能录入成品重量!"
        '        TB_GH_Input.Focus()
        '        TB_GH_Input.SelectAll()
        '        Exit Sub
        '    Else
        '        SetReadOnly(True)
        '    End If
        '    Btn_Preview.Enabled = False
        '    Btn_Print.Enabled = False
        'Else
        '    LabelErr.Text = "缸号[" & id & "]状态是" & BaseClass.ComFun.GetProduceStateName(IsNull(Dr("State"), 0)) & ",不能录入成品重量!"
        '    TB_GH_Input.Focus()
        '    TB_GH_Input.SelectAll()
        '    Exit Sub
        '    'ShowErrMsg("缸号[" & ID & "]当前状态不能录入成品重量!", AddressOf TB_GH.Focus)
        '    Btn_Preview.Enabled = True
        '    Btn_Print.Enabled = True
        '    SetReadOnly(False)
        'End If
        '赋值
        TB_Client_No.Text = IsNull(Dr("Client_No"), "")
        TB_Client_No.Tag = IsNull(Dr("Client_Id"), 0)
        TB_Client_Name.Text = IsNull(Dr("Client_Name"), "")
        TB_Contract.Text = IsNull(Dr("Contract"), "")
        TB_CR_LuoSeBzCount.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)
        TB_Amount.Text = TB_CR_LuoSeBzCount.Text
        'TB_ZhiDan.Text = IsNull(Dr("KaiDan"), "")

        TB_BZ_No.Text = IsNull(Dr("BZ_No"), "")
        TB_BZ_No.Tag = IsNull(Dr("BZ_Id"), 0)
        TB_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
        TB_TextileFatory.Text = IsNull(Dr("TextileFatory"), "")
        TB_ProcessType.Text = IsNull(Dr("ProcessType"), "")
        TB_PWeight.Text = IsNull(Dr("PB_ZLSum"), 0)
        TB_Quantity.Text = IsNull(Dr("PB_ZLSum"), 0)
        BZC_No.Text = IsNull(Dr("BZC_No"), "")
        BZC_Name.Text = IsNull(Dr("BZC_Name"), "")
        'TB_Request.Text = getYckg(IsNull(Dr("CR_ShiYong"), ""), IsNull(Dr("CR_BianDuiBian"), ""), IsNull(Dr("CR_KeZhong"), ""))
        'DTP_Date_LuoSe.Value = IsNull(Dr("Date_LuoSe"), "1999-1-1")
        'DTP_Date_KaiDan.Value = IsNull(Dr("Date_KaiDan"), "1999-1-1")
        'DTP_Date_JiaoHuo.Value = IsNull(Dr("Date_JiaoHuo"), "1999-1-1")
        TB_Date_LuoSe.Text = IsNull(Dr("Date_LuoSe"), "1999-1-1")
        TB_Date_KaiDan.Text = IsNull(Dr("Date_KaiDan"), "1999-1-1")
        TB_Date_JiaoHuo.Text = IsNull(Dr("Date_JiaoHuo"), "1999-1-1")

        LB_Stat.Text = ComFun.GetProduceStateName(IsNull(Dr("State"), 0))
        JZ = IsNull(Dr("JiaZhong"), 0) + IsNull(Dr("ZhiTong"), 0)
        dtTable = R.Dt
        dtTable.Columns.Add("CP", GetType(Double))
        dtTable.Columns.Add("CP_Line", GetType(Integer))
        TB_GH2.Text = IsNull(Dr("GH"), "")
        ShowKF()
        'RB_YuDing.Enabled = RB_YuDingState()

        Dim Workmsg As DtReturnMsg = Dao.Work_Get(IsNull(Dr("GH"), ""))
        'If Workmsg.IsOk = True Then
        '    CB_Remark.DataSource = Workmsg.Dt
        'End If
        'GHState()
        CB_Operator.DataSource = Dao.Get_GetOperator.Dt

    End Sub
#End Region

#Region "获取要求规格"
    Private Function getYckg(ByVal ShiYong As String, ByVal BianDuiBian As String, ByVal KeZhong As String) As String
        Dim ytext As String
        Dim Yckg As New StringBuilder
        If Not ShiYong = "" Then
            Yckg.Append(ShiYong & "*")
        End If

        If Not BianDuiBian = "" Then
            Yckg.Append(BianDuiBian & "*")
        End If

        If Not KeZhong = "" Then
            Yckg.Append(KeZhong)
        End If
        ytext = Yckg.ToString
        If Yckg.ToString.EndsWith("*") Then
            ytext = Yckg.ToString.Remove(Yckg.ToString.Length - 1, 1)
        End If
        Return ytext
    End Function
#End Region

#Region "状态选择"

    Protected Sub BenSet()
        Dim time As DateTime
        time = Format(GetTime(), "HH:mm:ss")
        If time > #8:00:00 AM# AndAlso time < #8:00:00 PM# Then
            RB_morning.Checked = True
        Else
            RB_even.Checked = True
        End If
    End Sub

    Sub ShowGHInput()
        LabelOK.Text = ""
        Panel_Input.Visible = True
        Panel_KF.Visible = False
        Panel_Input.BringToFront()
        TB_GH_Input.Focus()
        TB_GH_Input.SelectAll()
    End Sub

    Sub ShowKF()
        Panel_Input.Visible = False
        Panel_KF.Visible = True
    End Sub

    Private Function RB_YuDingState() As Boolean
        If state > 10 AndAlso state < 80 Then
            Return True
        Else
            Return False
        End If

    End Function


#End Region



End Class
Partial Friend Class Dao

    Private Const SQL_KF_GetGH As String = "select top 1 * from T30112_KF where GH=@GH"
    Private Const SQL_KF_GetGHID As String = "select top 1 * from T30112_KF where GH=@GH and Line=@Line"
    Private Const SQL_KF_GetOperator As String = " SELECT Employee_No,Employee_Name FROM T15001_Employee WHERE (Employee_FileType = '正式') AND (Employee_Dept = 'D006003') "

    Public Shared Function Get_KF(ByVal GH As String, ByVal Line As Integer) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("GH", GH)
        p.Add("Line", Line)
        'Dim r As DtReturnMsg = SqlStrToDt("select D.*,W.Work_Name from T30110_DProcess D left join T10022_Work W ON D.Remark=W.Work_No where GH=@GH and Line=@Line ", p)
        Dim r As DtReturnMsg = SqlStrToDt("select * from T30112_KF  where GH=@GH and Line=@Line ", p)
        If r.IsOk = True Then
            Return r
        End If
        Return Nothing
    End Function

    Public Shared Function Get_GetOperator() As DtReturnMsg
        Return SqlStrToDt(SQL_KF_GetOperator)
    End Function

    Public Shared Function KF_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim GH As String = ""

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "开幅工艺添加失败!"
            Return returnMsg
        End If
        GH = dt.Rows(0)("GH")

        Dim SQL As New Dictionary(Of String, String)
        SQL.Add("T", SQL_KF_GetGH)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@GH", GH)
        'p.Add("UPD_User", User_Name)
        Using H As New DtHelper(SQL, p)
            DvToDt(dt, H.DtList("T"), New List(Of String), True)
            'If stat = 0 Then
            returnMsg = H.UpdateAll(True)
            'Else
            '    Dim SQLlist As New Dictionary(Of String, String)
            '    SQLlist.Add("1", "update T30000_Produce_Gd set state=@state,UPD_User=@UPD_User,UPD_Date=GetDate() where gh=@GH")
            '    returnMsg = H.UpdateAll(True, SQLlist, p)
            'End If
            If returnMsg.IsOk = True Then
                returnMsg.Msg = "开幅工艺[" & dt.Rows(0)("GH") & "]添加成功!"
            ElseIf returnMsg.IsOk = False Then
                returnMsg.Msg = "添加失败," & returnMsg.Msg
            End If
        End Using

        Return returnMsg
    End Function

    Public Shared Function KF_Save(ByVal dt As DataTable, ByVal id As Integer) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim GH As String = ""

        Dim returnMsg As New MsgReturn
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "开幅工艺添加失败!"
            Return returnMsg
        End If
        GH = dt.Rows(0)("GH")
        Dim P As New Dictionary(Of String, Object)
        P.Add("GH", GH)
        P.Add("line", id)
        'P.Add("UPD_User", User_Name)
        Dim SQL As New Dictionary(Of String, String)
        SQL.Add("T", SQL_KF_GetGHID)
        Using H As New DtHelper(SQL, P)

            If H.IsOk AndAlso H.DtList("T").Rows.Count = 1 Then
                DvUpdateToDt(dt, H.DtList("T"), New List(Of String))
                'If stat = 0 Then
                returnMsg = H.UpdateAll(True)
                'Else
                '    Dim SQLlist As New Dictionary(Of String, String)
                '    P.Add("State", stat)
                '    SQLlist.Add("1", "update T30000_Produce_Gd set state=@state,UPD_User=@UPD_User,UPD_Date=GetDate() where gh=@GH")
                '    returnMsg = H.UpdateAll(True, SQLlist, P)
                'End If
                If returnMsg.IsOk = True Then
                    returnMsg.Msg = "开幅工艺[" & dt.Rows(0)("GH") & "]修改成功!"

                    'ElseIf returnMsg.IsOk = True And stat > 0 Then
                    '    returnMsg.Msg = "定型工艺[" & dt.Rows(0)("GH") & "]修改成功!缸号状态设置为" & ComFun.GetProduceStateName(stat)

                ElseIf returnMsg.IsOk = False Then
                    returnMsg.Msg = "修改失败," & returnMsg.Msg
                End If
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "开幅工艺[" & dt.Rows(0)("GH") & "已经存在!"
            End If
        End Using
        Return returnMsg
    End Function
End Class