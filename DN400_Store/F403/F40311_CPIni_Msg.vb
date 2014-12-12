Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40311_CPIni_Msg

    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim Bill_ID_Date As Date
    Dim DtChePai As DataTable
    Dim State As Enum_CPRK = Enum_CPRK.New_CPIni
    Dim StoreNoList As New List(Of String)
    Dim LastID As String = ""
    Dim isLoaded As Boolean = False

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = initID
        Me.Mode = Mode
    End Sub

    Private Sub F20001_CPIni_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> ToolStrip_StoreNo_Old.Name Then
                    SendKeys.SendWait("{TAB}")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub


    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 40310
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
        '   Control_CheckRight(ID, ClassMain.ZJ, Cmd_ZJ)
    End Sub

    Private Sub F40001_BZSH_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.CPIni, Bill_ID)
        ReturnId = TB_ID.Text
    End Sub

    Private Sub F10101_CPIni_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Fg1.IniFormat()
        Fg1.IniColsSize()
        Dim R As DtReturnMsg = Dao.CPIni_Get_Driver
        If R.IsOk Then
            CB_License.DataSource = R.Dt
            CB_driver.DataSource = R.Dt
        End If
        CB_driver.SelectedIndex = -1
        CB_License.SelectedIndex = -1


        'Fg1.Cols("ShaPi").Editor = CB_ShaPi
        'Fg1.Cols("Machine").Editor = CB_Machine
        '    Fg1.Cols("Color").Editor = CB_Color
        Fg1.Cols("StoreNo").Editor = CB_StoreNo
        Me_Refresh()
        Select Case Mode
            Case Mode_Enum.Add
                DP_Date.Value = GetTime().AddHours(-8).Date
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                'Dim msg As RetrunNewIdMsg = Dao.CPIni_GetNewId(Me.DP_Date.Value)
                'If msg.IsOk Then
                '    TB_ID.Text = msg.NewID
                'End If
                'TB_ZhiDan.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                TB_ZhiDan.Text = PClass.PClass.User_Display
                GetNewID()
            Case Mode_Enum.Modify
                '     TB_ID.ReadOnly = True
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.CPIni_GetById(Bill_ID)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            'If msgTable.Dt.Rows.Count = 0 OrElse IsNull(msgTable.Dt.Rows(0)("State"), Enum_CPIni.New_CPIni) >= Enum_CPIni.ShenHe Then
            '    Cmd_Audit.Enabled = False
            'End If
            SetForm(msgTable.Dt)
        End If
        If Mode = Mode_Enum.Add Then
            '     Cmd_ZJ.Enabled = False
            Dim msg As DtReturnMsg = Dao.CPIni_GetListById(0)
            If msg.IsOk Then
                dtList = msg.Dt
            End If
            Fg1.Rows.Count = 1

        Else
            ' TB_ID.ReadOnly = True
            '   Cmd_ZJ.Enabled = True
            If State = Enum_CPRK.New_CPIni Then
                Cmd_YTS.Visible = False
                Cmd_StoreNo.Text = "添加仓位"
                TB_StoreNo.Visible = True
                Cmd_StoreNo.Image = My.Resources.ADD
                '        Fg1.Cols("StoreNo_Old").Visible = False
                Dim msg As DtReturnMsg = Dao.CPIni_GetListById(Bill_ID)
                If msg.IsOk Then
                    dtList = msg.Dt
                    'DtListToFg(msg.Dt)
                End If
            Else
                '   Cmd_YTS.Visible = True
                Cmd_StoreNo.Text = "显示位置"
                Cmd_StoreNo.Image = My.Resources.Search
                TB_StoreNo.Visible = False
                '    Fg1.Cols("StoreNo_Old").Visible = True
                Dim msg As DtReturnMsg = Dao.CPIni_GetListById(Bill_ID)
                If msg.IsOk Then
                    dtList = msg.Dt
                    'DtListToFg(msg.Dt)
                End If
            End If
            Fg1.DtToSetFG(dtList)
        End If
        CaculateSumAmount()
    End Sub


#Region "获取新单号"
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If TB_ID.ReadOnly OrElse TB_ID.Enabled = False Then
            ShowErrMsg("非新增状态不能修改单号!")
        Else
            ShowConfirm("是否获取新单号?", AddressOf ReGetNewID)
        End If
    End Sub

    Sub ReGetNewID()
        If TB_ID.Text <> Bill_ID OrElse Bill_ID = "" Then
            ComFun.DelBillNewID(BillType.CPIni, Bill_ID)
            Bill_ID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DP_Date.Value <> Bill_ID_Date Then
                'Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.CPIni, DP_Date.Value, Bill_ID)
                'If R.IsOk Then
                '    Bill_ID_Date = GetTime().AddHours(-8).Date
                '    DP_Date.MinDate = R.MaxDate.AddDays(1)
                '    DP_Date.Value = GetTime().AddHours(-8).Date
                '    Bill_ID = R.NewID
                '    TB_ID.Text = Bill_ID.Replace("-", "")
                '    If R.IsTheDate = False Then
                '        ShowErrMsg(R.RetrunMsg)
                '    End If
                'Else
                '    ShowErrMsg(R.RetrunMsg)
                'End If
                DP_Date.Value = GetTime().AddHours(-8).Date
                ' Bill_ID_Date = DP_Date.Value
            End If
        End If
    End Sub

    Private Sub DTP_sDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DP_Date.Validated
        ' GetNewID()
    End Sub


#End Region


#Region "表单信息"




    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtTable.Clone
        If Not dt Is Nothing AndAlso Not TB_ID.Text = "" Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("ID") = TB_ID.Text
            dr("sDate") = DP_Date.Value.ToString("yyyy-MM-dd")
            dr("RKDate") = DP_Date.Value.ToString("yyyy-MM-dd")
            dr("Client_ID") = Val(CB_Client.IDValue)

            dr("BZ_ID") = (CB_BZ.IDValue)
            dr("BZC_ID") = (CB_BZC.IDValue)

            dr("BZC_MSg") = TB_BZcName.Text
            dr("GH") = TB_GH.Text
            dr("SumQty") = Val(TB_SumQty.Text)
            dr("SumPWeight") = Val(TB_PWeight.Text)
            dr("RemainCount") = dr("SumQty")
            dr("RemainWeight") = dr("SumPWeight")
            If LastID <> "" Then
                dr("LastID") = LastID
            End If
            dr("driver") = CB_driver.SelectedValue
            dr("License") = CB_License.SelectedValue

            'GetControlValue(dr, TB_CangWei)
            dr("Cangwei") = BaseClass.ComFun.ListToString(StoreNoList, "|")

            GetControlValue(dr, TB_Remark)
            GetControlValue(dr, TB_State_User)
            GetControlValue(dr, TB_XiaoZhang)
            GetControlValue(dr, TB_ZhiDan)
            '   GetControlValue(dr, CK_IsFG)

            dr("State") = State
            dt.Rows.Add(dr)
            dtTable = dt
            'For Each R As DataRow In dtList.Rows
            '    R.Item("CPIni_ID") = TB_ID.Text
            'Next
            '列表内容
            Dim row As DataRow
            Dim _dtList As DataTable = dtList.Clone
            Dim _storeNoList As New List(Of String)
            For i = 1 To Fg1.Rows.Count - 1
                If Val(Fg1.Item(i, "ZL")) = 0 Then
                    Continue For
                End If
                row = _dtList.NewRow
                row("ZL") = Val(Fg1.Item(i, "ZL"))
                row("StoreNo") = Fg1.Item(i, "StoreNo")
                row("ID") = TB_ID.Text
                _dtList.Rows.Add(row)
                '刷新仓位列表
                Dim _StoreNo As String = Fg1.Item(i, "StoreNo")
                If _StoreNo <> "" AndAlso Not CB_StoreNo.Items.Contains(_StoreNo) Then
                    CB_StoreNo.Items.Add(_StoreNo)
                End If
            Next
            dtList = _dtList
        End If

        Return dt
    End Function


    Sub SetAddState()
        LabelState.Text = "新建"
        LabelState.ForeColor = Color.Black
        Cmd_Modify.Enabled = Cmd_Modify.Tag

        Cmd_Audit.Visible = Cmd_Audit.Tag
        Cmd_Audit.Enabled = True
        Cmd_UnAudit.Visible = False
        Cmd_UnAudit.Enabled = False

        Cmd_SetValid.Visible = False
        Cmd_SetValid.Enabled = False
        Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
        Cmd_SetInValid.Enabled = True
        Cmd_Del.Visible = Cmd_Del.Tag
        LockForm(False)
        CB_BZ.Enabled = False
    End Sub


    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If

        If dt.Rows.Count <= 0 Then
            State = Enum_State.AddNew
        Else
            State = dt.Rows(0)("State")
        End If


        Cmd_Del.Visible = False
        Select Case State
            Case Enum_State.AddNew '新建
                SetAddState()
            Case Enum_State.Invoid '作废
                LabelState.Text = "已作废"
                LabelState.ForeColor = Color.Red
                Cmd_Modify.Enabled = False

                Cmd_Audit.Visible = Cmd_Audit.Tag
                Cmd_Audit.Enabled = False
                Cmd_UnAudit.Visible = False
                Cmd_UnAudit.Enabled = False

                Cmd_SetValid.Visible = Cmd_SetValid.Tag
                Cmd_SetValid.Enabled = True
                Cmd_SetInValid.Visible = False
                Cmd_SetInValid.Enabled = False
                'Cmd_ZJ.Enabled = False
                LockForm(True)
            Case Enum_State.Audited '审核

                LabelState.Text = "已审核"
                LabelState.ForeColor = Color.Blue
                Cmd_Modify.Enabled = False

                Cmd_Audit.Visible = False
                Cmd_Audit.Enabled = False
                Cmd_UnAudit.Visible = Cmd_UnAudit.Tag
                Cmd_UnAudit.Enabled = True

                Cmd_SetValid.Visible = False
                Cmd_SetValid.Enabled = False
                Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                Cmd_SetInValid.Enabled = False

                LockForm(True)
        End Select

        If dt.Rows.Count = 1 Then
            Dim Dr As DataRow = dt.Rows(0)

            TB_ID.Text = IsNull(Dr("ID"), "")
            If Not Dr("sDate") Is DBNull.Value Then
                DP_Date.Value = Dr("sDate")

            End If
            If Not Dr("RKDate") Is DBNull.Value Then
                DP_RKDate.Value = Dr("RKDate")

            End If
            CB_Client.IDValue = IsNull(Dr("Client_ID"), "0")
            CB_Client.Text = CB_Client.GetByTextBoxTag()
            TB_ClientName.Text = CB_Client.NameValue

            CB_BZ.IDValue = IsNull(Dr("BZ_ID"), "0")
            CB_BZ.Text = CB_BZ.GetByTextBoxTag()
            TB_BZName.Text = CB_BZ.NameValue


            CB_BZC.IDValue = IsNull(Dr("BZC_ID"), "0")
            CB_BZC.Text = CB_BZC.GetByTextBoxTag()
            TB_BZcName.Text = IsNull(Dr("BZC_MSg"), "")
            TB_GH.Text = IsNull(Dr("GH"), "")
            TB_SumQty.Text = FormatNum(IsNull(Dr("SumQty"), 0))
            TB_PWeight.Text = FormatZL(IsNull(Dr("SumPWeight"), 0))

            CB_driver.SelectedValue = IsNull(Dr("driver"), "")
            CB_License.SelectedValue = IsNull(Dr("License"), "")


            '      SetControlValue(Dr, CK_IsFG)


            SetControlValue(Dr, TB_Remark)

            SetControlValue(Dr, TB_State_User)
            SetControlValue(Dr, TB_XiaoZhang)
            SetControlValue(Dr, TB_ZhiDan)

            LB_AllQty.Tag = IsNull(Dr("SumQty"), 0)

            LastID = IsNull(Dr("LastID"), "")


        Else

            Panel_All.Visible = False
        End If
    End Sub

    Sub LoadAllQty()
        Dim R As MsgReturn = Dao.CPIni_GetAllQty(LastID)
        If R.IsOk Then
            Me.Invoke(New DSetAllQty(AddressOf SetAllQty), R.Msg)
        Else
            Me.Invoke(New DSetAllQty(AddressOf SetAllQty), "0")
        End If

    End Sub

    Delegate Sub DSetAllQty(ByVal Qty As String)

    Sub SetAllQty(ByVal Qty As String)
        If Qty = "" Then
            Panel_All.Visible = False
        Else
            If Qty = LB_AllQty.Tag Then

                Panel_All.Visible = False
            Else
                Panel_All.Visible = True
                LB_AllQty.Text = Qty
            End If
        End If
    End Sub


    Sub LockForm(ByVal Lock As Boolean)

        DP_Date.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock

        Btn_AddRow.Enabled = Not Lock
        Btn_RemoveRow.Enabled = Not Lock


        CB_BZ.Enabled = Not Lock
        CB_Client.Enabled = Not Lock
        CB_BZC.Enabled = Not Lock
        TB_BZcName.ReadOnly = Lock

        TB_GH.ReadOnly = Lock
        DP_RKDate.Enabled = Not Lock
        TB_Remark.ReadOnly = Lock
        'Fg1.Cols("GH").Visible = Lock
        'Fg1.Cols("CP").Visible = Lock
        'Fg1.Cols("PB").Visible = Lock
        '   Fg1.Cols("State_Name").Visible = Lock
        '    Fg1.Cols("Date_PeiBu").Visible = Lock
        '     Fg1.Cols("CK_Date").Visible = Lock

        'If Lock Then
        '    Fg1.Cols("ZL").Width = 79
        '    Fg1.Cols("StoreNo").Width = 79
        '    '  Fg1.Cols("ShaPi").Width = 79
        '    '   Fg1.Cols("Machine").Width = 79
        'End If

        Fg1.IniColsSize()
        Fg1.FG_ColResize()
    End Sub

    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0
            TB_PWeight.Text = 0
            TB_RemainQty.Text = 0
            TB_RemainZl.Text = 0
            Exit Sub
        End If
        Dim SumQty As Double = 0
        Dim SumPWeight As Double = 0
        Dim ReMainQty As Double = 0
        Dim ReMainZl As Double = 0
        Dim StoreNo As New StringBuilder
        Dim ShaPi As New StringBuilder
        Dim Machine As New StringBuilder
        'StoreNoList.Clear()

        Dim IsAddStore As Boolean = False
        For R As Integer = 1 To Fg1.Rows.Count - 1

            If Val(Fg1.Item(R, "ZL")) > 0 Then
                SumQty = SumQty + 1
                SumPWeight = SumPWeight + Val(Fg1.Item(R, "ZL"))

            End If



        Next
        If IsAddStore OrElse isLoaded = False Then ReFresh_StoreNo()

        TB_SumQty.Text = FormatNum(SumQty)
        TB_PWeight.Text = FormatZL(SumPWeight)
        TB_RemainQty.Text = FormatNum(ReMainQty)
        TB_RemainZl.Text = FormatZL(ReMainZl)
    End Sub


#End Region



#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        Fg1.FinishEditing()
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                Dim D As Date = GetTime.AddHours(-8).Date
                If DP_Date.Value.Date <> D Then
                    ShowConfirm("你选择的入库日期是[" & DP_Date.Value.Date.ToString("yyyy-MM-dd") & "]和单前日期[" & D.Date.ToString("yyyy-MM-dd") & "]不相同,是否继续保存" & Ch_Name & "?", "继续保存", "改为当天", "取消", AddressOf SaveConfirm, AddressOf SaveConfirmAsDate, AddressOf Me.NoSave)
                Else
                    SaveConfirm()
                End If
            Else
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveCPIni)
            End If
        End If
    End Sub



    Sub NoSave()

    End Sub

    Sub SaveConfirmAsDate()
        DP_Date.Value = GetTime.AddHours(-8).Date
        SaveConfirm()
    End Sub


    Sub SaveConfirm()
        ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveCPIni)
    End Sub


    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveCPIni(Optional ByVal Audit As Boolean = False)
        ReFresh_StoreNo(True)
        dtList.AcceptChanges()
        Dim R As MsgReturn
        '    dtList = FGToDtList()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.CPIni_Add(GetForm(), dtList)
        Else
            R = Dao.CPIni_Save(GetForm(), dtList, Bill_ID)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            If Audit Then
                Dim msg As MsgReturn = Dao.CPIni_Audit(TB_ID.Text, True)
                If msg.IsOk Then
                    Bill_ID = TB_ID.Text
                    Me.Mode = Mode_Enum.Modify
                    Me_Refresh()
                    ShowOk(msg.Msg)
                Else
                    ShowErrMsg(msg.Msg)
                End If
                Exit Sub
            End If
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        'FG_Adjust()
        CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If TB_GH.Text.Trim = "" Then
            ShowErrMsg(Ch_Name & "缸号不能为空!", AddressOf TB_GH.Focus)
            Return False
        End If
        If TB_GH.Text.Trim.Length <= 8 Then
            ShowErrMsg(Ch_Name & "缸号长度不能少于8位!", AddressOf TB_GH.Focus)
            Return False
        End If
        If TB_GH.Text.Trim.ToUpper.StartsWith("GY") = False Then
            ShowErrMsg(Ch_Name & "缸号必须GY以开始!", AddressOf TB_GH.Focus)
            Return False
        End If
        TB_ID.Text = ComFun.FixRK(TB_ID.Text)
        Dim R As MsgReturn = ComFun.CheckRK(TB_ID.Text, LastID <> "")
        If R.IsOk = False Then
            ShowErrMsg(R.Msg, AddressOf TB_ID.Focus)
            Return False
        End If

        If Mode = Mode_Enum.Add AndAlso Dao.CPIni_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If
        If Mode = Mode_Enum.Add AndAlso Dao.CPIni_CheckGH(TB_GH.Text) Then
            ShowErrMsg(Ch_Name & "缸号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If
        If Val(CB_Client.IDValue) = 0 Then
            ShowErrMsg("客户商编号或名称不能为空!", AddressOf CB_Client.Focus)
            Return False
        End If
        If Val(CB_BZ.IDValue) = 0 Then
            ShowErrMsg("请选择一种胚布!", AddressOf CB_BZ.Focus)
            Return False
        End If


        If Fg1.Rows.Count <= 1 Then
            ShowErrMsg("列表不能为空!")
            Return False
        End If

        If Val(Fg1.Item(Fg1.Rows.Count - 1, "ZL")) = 0 Then
            Try
                Fg1.RemoveItem(Fg1.Rows.Count - 1)
            Catch ex As Exception
            End Try
        End If
        If Fg1.Rows.Count <= 1 Then
            ShowErrMsg("列表不能为空!")
            Return False
        End If

        For i As Integer = 1 To Fg1.Rows.Count - 1
            If IsNull(Fg1.Item(i, "StoreNo"), "") = "" Then
                ShowErrMsg("仓位不能为空!")
                Return False
            End If
            If Val(Fg1.Item(i, "ZL")) > MaxZL Then
                ShowErrMsg("列表第" & i & "行入库重量大于" & MaxZL & "!     ")
                Return False
            End If

            If Val(Fg1.Item(i, "ZL")) < MinZL Then
                ShowErrMsg("列表第" & i & "入库重量小于" & MinZL & "!     ")
                Return False
            End If

        Next

        Me.Refresh()
        Return True
    End Function


    'Sub FG_Adjust()
    '    DtListToFg(FGToDtList())
    'End Sub


    'Private Sub Cmd_Adjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Adjust.Click
    '    FG_Adjust()
    'End Sub


    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelCPIni)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelCPIni()
        Dim msg As MsgReturn = Dao.CPIni_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub
    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddRow.Click

        AddRow()
    End Sub

    Private Sub AddRow()
        Fg1.AddRow()
        If Fg1.Rows.Count > 2 Then
            Fg1.Item(Fg1.Rows.Count - 1, "StoreNo") = Fg1.Item(Fg1.Rows.Count - 2, "StoreNo")
            '   Fg1.Item(Fg1.Rows.Count - 1, "ShaPi") = Fg1.Item(Fg1.Rows.Count - 2, "ShaPi")
            '   Fg1.Item(Fg1.Rows.Count - 1, "Color") = Fg1.Item(Fg1.Rows.Count - 2, "Color")
            '   Fg1.Item(Fg1.Rows.Count - 1, "Machine") = Fg1.Item(Fg1.Rows.Count - 2, "Machine")
            'Fg1.Item(Fg1.Rows.Count - 1, "ZL") = Fg1.Item(Fg1.Rows.Count - 2, "ZL")
        End If
    End Sub


    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Fg1.FinishEditing(True)
        Dim i As Integer = Fg1.RowSel
        If i > 0 AndAlso Fg1.Rows.Count > 1 Then
            Try
                Fg1.Rows.Remove(i)
            Catch ex As Exception
            End Try
            If Fg1.Rows.Count < 2 Then

            Else
                Fg1.ReAddIndex()
            End If
        End If
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.CPIni_Audit(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub
#End Region

#Region "FG1事件"

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col.ToLower
            Case "zl"




                If Not Fg1.Item(e.Row, "StoreNo") Is Nothing AndAlso Fg1.Item(e.Row, "StoreNo") <> "" Then
                    If e.Row + 2 > Fg1.Rows.Count Then
                        AddRow()
                    End If
                    e.ToRow = e.Row + 1
                    e.ToCol = 1
                Else
                    e.ToCol = Fg1.Cols("StoreNo").Index
                End If
            Case "StoreNo"
                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = 1

        End Select
    End Sub

    Private MinZL As Double = Val(FormatSharp("MinZL"))
    Private MaxZL As Double = Val(FormatSharp("MaxZL"))
    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Col = Fg1.Cols("ZL").Index Then
            If Val(Fg1.Item(e.Row, e.Col)) <> 0 Then
                If Fg1.Item(e.Row, e.Col) > MaxZL Then
                    ShowErrMsg("入库重量不能大于" & MaxZL & "!  ")
                    Exit Sub
                End If

                If Fg1.Item(e.Row, e.Col) < MinZL Then
                    ShowErrMsg("入库重量不能小于" & MinZL & "!  ")
                    Exit Sub
                End If

            End If

        End If



        If e.Col = Fg1.Cols("StoreNo").Index Then
            If CheckStoreNo(Fg1.Item(Fg1.RowSel, "StoreNo")) = False Then
                Fg1.Item(Fg1.RowSel, "StoreNo") = ""
                If Fg1.LastKey = Keys.Enter Then ShowErrMsg("没有找到对应的仓位！", AddressOf StartEditingStoreNo)
            Else
                Fg1.Item(Fg1.RowSel, "StoreNo") = Fg1.Item(Fg1.RowSel, "StoreNo").ToString.ToUpper

            End If
            CaculateSumAmount()
            Exit Sub
        End If
        If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell()
        CaculateSumAmount()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartEditingStoreNo()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("StoreNo").Index)
    End Sub


    Protected Function CheckStoreNo(ByVal _storeNO) As Boolean
        Dim msg As DtReturnMsg = ComFun.StoreMap_CheckStoreNo(_storeNO)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region


#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        'If Me.Mode = Mode_Enum.Add Then
        '    Exit Sub
        'End If
        'Dim R As New R40001_CPIni
        'R.Start(TB_ID.Text, DoOperator)
    End Sub

#End Region

#Region "客户和布种,色号"
    Private Sub CB_Client_SetEmpty()
        CB_BZ.Enabled = False
        TB_ClientName.Text = ""
    End Sub
    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel
        TB_ClientName.Text = Col_Name
        If CB_BZ.SearchID <> ID Then
            CB_BZ.Text = ""
            CB_BZ.SetSearchEmpty()
            TB_BZName.Text = ""
        End If
        CB_BZ.Enabled = True
        CB_BZ.SearchID = ID
        CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
    End Sub
    Private Sub CB_BZ_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ.Col_Sel
        TB_BZName.Text = Col_Name
    End Sub
    Private Sub CB_BZ_SetEmpty()
        TB_BZName.Text = ""
    End Sub

    Private Sub CB_BZC_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZC.Col_Sel
        TB_BZcName.Text = (Col_No & "#" & Col_Name).ToString.Replace("##", "#")
    End Sub
    Private Sub CB_BZC_SetEmpty()
        TB_BZcName.Text = ""
    End Sub
#End Region


#Region "审核状态"
    ''' <summary>
    ''' 审核状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click
        Fg1.FinishEditing()
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                'Dim D As Date = GetTime.AddHours(-8).Date
                'If DP_Date.Value.Date <> D Then
                '    ShowConfirm("你选择的入库日期是[" & DP_Date.Value.Date.ToString("yyyy-MM-dd") & "]和单前日期[" & D.Date.ToString("yyyy-MM-dd") & "]不相同,是否继续保存" & Ch_Name & "?", "继续保存", "改为当天", "取消", AddressOf ShenheConfirm, AddressOf ShenheAsDate, AddressOf Me.NoSave)
                'Else
                ShenheConfirm()
                '  End If
            Else
                ShowConfirm("是否保存并审核" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Shenhe)
            End If
        End If

    End Sub



    Sub ShenheAsDate()
        DP_Date.Value = GetTime.AddHours(-8).Date
        ShenheConfirm()
    End Sub


    Sub ShenheConfirm()
        ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Shenhe)
    End Sub


    Protected Sub Shenhe()
        SaveCPIni(True)
    End Sub
#End Region

    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        If Me.Mode = Mode_Enum.Add Then
            ShowErrMsg("入库单没有保存，不能作废！")
            Exit Sub
        End If
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf CPIniInValid)
    End Sub
    Sub CPIniInValid()
        Dim msg As MsgReturn = Dao.CPIni_InValid(TB_ID.Text, True)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub
    ''' <summary>
    ''' 反作废
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetValid.Click
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf CPIniValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub CPIniValid()
        Dim msg As MsgReturn = Dao.CPIni_InValid(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub



#Region "选择仓位"
    Dim OldStore As String
    Private Sub Cmd_StoreNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_StoreNo.Click
        Dim F As New F40500_Store_Map(cStore_Area.Enum_SelType.Cell, StoreNoList)
        With F
            .Mode = Mode_Enum.Add
            .IsSel = True
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.MaximizeBox = True
        AddHandler VF.ClosedX, AddressOf GetStoreNo
        VF.Show()
    End Sub

    Private Sub Cmd_StoreNo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TB_StoreNo.Visible = False Then
            Exit Sub
        End If
        OldStore = sender.Text
        ShowConfirm("是否删除仓位[" & sender.Text & "]", AddressOf OldStore_Del)
    End Sub

    Sub OldStore_Del()
        StoreNoList.Remove(OldStore)
        ReFresh_StoreNo()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetStoreNo()
        If TB_StoreNo.Visible = False Then
            Exit Sub
        End If
        If Not Me.ReturnObj Is Nothing Then
            Try
                Dim sNoList As List(Of String) = Me.ReturnObj
                StoreNoList = sNoList
                'CaculateSumAmount()
                ReFresh_StoreNo()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub ReFresh_StoreNo(Optional ByVal isSave As Boolean = False)
        If isSave Then
            StoreNoList.Clear()
            For J As Integer = 1 To Fg1.Rows.Count - 1
                If Fg1.Item(J, "StoreNo") <> "" AndAlso StoreNoList.Contains(Fg1.Item(J, "StoreNo")) = False Then
                    StoreNoList.Add(Fg1.Item(J, "StoreNo"))
                End If
            Next
        Else
            For J As Integer = 1 To Fg1.Rows.Count - 1
                If Fg1.Item(J, "StoreNo") <> "" AndAlso StoreNoList.Contains(Fg1.Item(J, "StoreNo")) = False Then
                    StoreNoList.Add(Fg1.Item(J, "StoreNo"))
                End If
            Next
            CB_StoreNo.DataSource = Nothing
            CB_StoreNo.DataSource = Me.StoreNoList
        End If

        StoreNoList.Sort()
        Dim i As Integer = 1
        For Each _sNo As String In StoreNoList
            If ToolStrip_StoreNo_Old.Items.ContainsKey("StoreNo" & i) = False Then
                Dim T As New System.Windows.Forms.ToolStripButton
                T.DisplayStyle = ToolStripItemDisplayStyle.Text
                T.Name = "StoreNo" & i
                T.ForeColor = Color.Blue
                T.ToolTipText = "双击移除仓位" & _sNo
                T.DoubleClickEnabled = True
                ToolStrip_StoreNo_Old.Items.Add(T)
                ToolStrip_StoreNo_Old.Tag = i
                AddHandler T.DoubleClick, AddressOf Cmd_StoreNo_DoubleClick
            End If
            ToolStrip_StoreNo_Old.Items("StoreNo" & i).Visible = True
            ToolStrip_StoreNo_Old.Items("StoreNo" & i).Text = _sNo
            i = i + 1
        Next
        For j As Integer = ToolStrip_StoreNo_Old.Tag To i Step -1
            RemoveHandler ToolStrip_StoreNo_Old.Items("StoreNo" & j).DoubleClick, AddressOf Cmd_StoreNo_DoubleClick
            ToolStrip_StoreNo_Old.Items.RemoveByKey("StoreNo" & j)
        Next
        ToolStrip_StoreNo_Old.Tag = i - 1
    End Sub



    Private Sub TB_StoreNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_StoreNo.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True

            If StoreNoList.Contains(TB_StoreNo.Text) Then
                TB_StoreNo.Text = ""
                Exit Sub
            End If
            If CheckStoreNo(TB_StoreNo.Text) Then
                StoreNoList.Add(TB_StoreNo.Text.ToUpper)
                ReFresh_StoreNo()
                TB_StoreNo.Text = ""
            Else
                ShowErrMsg("没有找到仓位" & TB_StoreNo.Text, AddressOf TB_StoreNo.Focus)
                TB_StoreNo.SelectAll()
            End If
        End If
    End Sub



#End Region



    Private Sub Cmd_ZJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim R As MsgReturn = Dao.CPIni_GetZJ(TB_ID.Text.Substring(0, 6))
        If R.IsOk Then
            Mode = Mode_Enum.Add
            LastID = TB_ID.Text.Substring(0, 6)
            TB_ID.Text = R.Msg
            Bill_ID = TB_ID.Text

            LabelTitle.Text = "新建追加" & Me.Ch_Name
            Btn_Preview.Enabled = False
            Btn_Print.Enabled = False
            TB_ZhiDan.Text = PClass.PClass.User_Display
            Fg1.Rows.Count = 1
            SetAddState()
            Cmd_Del.Visible = False
            Cmd_SetInValid.Visible = False
            '  Cmd_ZJ.Enabled = False
            TB_ID.ReadOnly = True
            Cmd_StoreNo.Image = My.Resources.ADD
            Cmd_StoreNo.Text = "添加仓位"
            TB_StoreNo.Visible = True
            Fg1.Cols("StoreNo_Old").Visible = False
            CaculateSumAmount()

        Else
            ShowErrMsg("入库单追加失败" & R.Msg)
        End If
    End Sub

    Private Sub Cmd_YTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_YTS.Click
        Dim R As MsgReturn = Dao.CPIni_ReSum(TB_ID.Text)
        If R.IsOk Then
            ShowOk("重新计算余条数成功!")
        Else
            ShowErrMsg("重新计算余条数失败!" & R.Msg)
        End If
    End Sub


    Private Sub TB_ID_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ID.DoubleClick
        If TB_ID.ReadOnly AndAlso State = Enum_CPRK.New_CPIni Then
            ShowInput("你要把单号[" & TB_ID.Text & "]修改成:", AddressOf ReName, TB_ID.Text)
        End If
    End Sub
    Sub ReName(ByVal S As String)
        Dim R As MsgReturn = Dao.ReName(Bill_ID, S)
        If R.IsOk Then
            ShowOk(R.Msg)
            Bill_ID = S
            Me_Refresh()
            LastForm.ReturnId = "ALL"
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub

End Class

Public Enum Enum_CPRK
    New_CPIni = 0
    ShenHe = 1
    XiaoZhang = 2
End Enum
Partial Class Dao




#Region "成品期初库存"


#Region "成品期初库存信息"


    '===================成品期初库存信息==============
    Public Const SQL_CPIni_Get_WithName = "select  P.*,Client_No,S.Client_Name,BZ_No,BZ_Name from T40310_CPIni_Table P left join T10110_Client S on  P.Client_ID=S.ID left join T10002_BZ BZ on BZ.ID =P.BZ_ID "


    Public Const SQL_CPIni_Get_Body As String = " from T40310_CPIni_Table P left join T10110_Client S on  P.Client_ID=S.ID  "

    Public Const SQL_CPIni_Get_leftJoin_GoodsNo As String = " left join (  select distinct ID, Bz_ID from T40311_CPIni_List    ) List on List.ID=p.ID"
    Public Const SQL_CPIni_Get_leftJoin_GoodsName As String = "   left join (  select distinct ID, G.Bz_No,G.Bz_Name from T40311_CPIni_List PL left join T10002_BZ G on PL.BZ_ID=G.id ) List on List.ID=p.ID"

    Public Const SQL_CPIni_GetCPIniByid As String = "select top 1 * from T40310_CPIni_Table  where ID=@ID"

    Public Const SQL_CPIni_GetCPIniListByid_Audit As String = "select L.*,G.Date_PeiBu,G.State as GHState,Isnull((select top 1 StoreNo from T40151_PBTC_List where sLine=L.Line order by Line),StoreNo) as StoreNo_Old from T40311_CPIni_List L left join T30000_Produce_Gd G ON G.GH=L.GH where l.ID=@ID"

    Public Const SQL_CPIni_GetCPIniByidWhithClientName As String = SQL_CPIni_Get_WithName & "  where ID=@ID"

    Public Const SQL_CPIni_GetCPIniListByid As String = "select * from T40311_CPIni_List  where ID=@ID"

    Public Const SQL_CPIni_GetCPIniListByid_ForReport As String = "select P.* ,P.BZ_ID + '#' +BZ.BZ_Name as BZ_Name ,isNull( Client_Bzc,'') +'#'+BZC.BZC_Name+' GY-' + right('00000' + P.BZC_ID,6) as BZC_Name  from T40311_CPIni_List  P left join T10002_BZ BZ on BZ.BZ_ID=P.BZ_ID  left join T10003_BZC BZC on BZC.BZC_ID=P.BZC_ID  where ID=@ID order by ID"

    Public Const SQL_CPIni_CheckID As String = "select count(*) from ((select ID from  T40310_CPIni_Table ) union all (select ID from  T40100_PBRK_Table)) T  where ID=@ID"
    ' Public Const SQL_GET_BZ_BYGH As String = " SELECT G.BZ_ID, B.BZ_Name, G.Client_ID, C.Client_Name FROM T30000_Produce_Gd G LEFT OUTER JOIN  T10110_Client C ON G.Client_ID = C.ID LEFT OUTER JOIN T10002_BZ B ON B.ID = G.BZ_ID WHERE G.GH =@GH"
    Public Const SQL_CPIni_CheckGH As String = "select count(*) from T30000_Produce_Gd  where GH=@GH"

    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_CPIni_SelByid As String = "select top 1 * from T40310_CPIni_Table  where ID=@ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_CPIni_SelListByid As String = "select  * from T40311_CPIni_List  where ID=@ID"
    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_CPIni_DelCPIniByid As String = "Delete from  T40310_CPIni_Table where ID=@ID "
    Public Const SQL_CPIni_OrderBy As String = " order by sDate "

    Public Const SQL_CPIni_SetListById As String = "select p.*,G.Date_PeiBu,G.State as GH_State from (select ZL,GH,CK_Date,State,Line,StoreNo from T40311_CPIni_List where ID=@ID) P left join T30000_Produce_Gd G on P.GH=G.GH"
#End Region
    Public Const SQL_CPIni_GetStateByID As String = "select top 1 ID,State,State_User from T40310_CPIni_Table  where ID=@ID"
    Private Const SQL_CPIni_GET As String = "Select Remark,Remark2 from T10200_Remark  where Remark_Type=2"
    Private Const CPIni_DB_NAME As String = "成品期初库存"



    '''' <summary>
    '''' 修改单号
    '''' </summary>
    '''' <param name="ID_Old"></param>
    '''' <param name="ID_New"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function ReName(ByVal ID_Old As String, ByVal ID_New As String) As MsgReturn
    '    Dim R As MsgReturn
    '    Dim P As New Dictionary(Of String, Object)
    '    P.Add("ID_New", ID_New)
    '    P.Add("ID_Old", ID_Old)
    '    If Val(SqlStrToOneStr("select COUNT(*) from T40310_CPIni_Table where ID=@ID_New", P).Msg) > 0 Then
    '        R.IsOk = False
    '        R.Msg = "修改失败,新单号[" & ID_New & "]已存在!"
    '        Return R
    '    Else
    '        R = RunSQL("update T40310_CPIni_Table set id=@ID_New where id=@ID_Old ; update T40510_PB_Stock set id=@ID_New where id=@ID_Old ", P)
    '        If R.IsOk Then
    '            R.Msg = "修改成功!"
    '        End If
    '    End If
    '    Return R
    'End Function


    ''' <summary>
    ''' 获取车牌号码和司机
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_Get_Driver() As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_CPIni_GET)
    End Function

    ''' <summary>
    ''' 获取对成品期初库存信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_CPIni_GetCPIniByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对成品期初库存列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_GetListById_Audit(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_CPIni_GetCPIniListByid_Audit, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对成品期初库存列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_CPIni_GetCPIniListByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取成品期初库存 连接到缸号的明细信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_SetListById(ByVal sId As String) As DtReturnMsg
        Dim R As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_CPIni_SetListById, "@ID", sId)
        If R.IsOk Then
            R.Dt.Columns.Add("State_Name")
            For Each Row As DataRow In R.Dt.Rows
                '   If Row("State") = 0 Then
                Row("State_Name") = ComFun.GetProduceStateName(IsNull(Row("GH_State"), 0))
                '   Else
                '   Row("State_Name") = "已出货"
                '   End If
            Next
        End If
        Return R
    End Function

    '''' <summary>
    '''' 获取所有成品期初库存
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function CPIni_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_CPIni_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_CPIni_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_CPIni_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "成品期初库存号"
        fo.DB_Field = "P.ID"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)



        fo = New FindOption
        fo.Field = "备注"
        fo.DB_Field = "Remark"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)


        Return foList
    End Function
    ''' <summary>
    ''' 按条件获取成品期初库存列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_CPIni_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_CPIni_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    Public Shared Function CPIni_CheckID(ByVal CPIni_ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_CPIni_CheckID, "@ID", CPIni_ID)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Function CPIni_CheckGH(ByVal GH As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_CPIni_CheckGH, "@GH", GH)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function


    ''' <summary>
    ''' 获取一个新ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_GetNewId(ByVal D As Date) As RetrunNewIdMsg
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
                R.RetrunMsg = "获取" & CPIni_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T40310_CPIni_Table")
            paraMap.Add("@Id_Str", "CPIni")
            paraMap.Add("@Field", "ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & CPIni_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & CPIni_DB_NAME & "单号失败!" & ex.Message
            Return R
        End Try
    End Function






    ''' <summary>
    ''' 成品期初库存添加
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable, Optional ByVal Supplier_Name_New As String = "") As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Bill_ID As String = dtTable.Rows(0)("ID")
        paraMap.Add("ID", Bill_ID)
        sqlMap.Add("Table", SQL_CPIni_SelByid)
        sqlMap.Add("List", SQL_CPIni_SelListByid)
        Try
            Using DTH As New DtHelper(sqlMap, paraMap)
                If DTH.IsOk = False Then
                    Throw New Exception(DTH.Msg)
                Else
                    If DTH.DtList("Table").Rows.Count = 0 Then
                        DvToDt(dtTable, DTH.DtList("Table"), New List(Of String), True)
                        DvToDt(dtList, DTH.DtList("List"), New List(Of String), True)
                        Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values(@ID," & BillType.CPIni & ")"
                        R = DTH.UpdateAll(True, TmSQL, "ID", Bill_ID)
                        If R.IsOk Then R.Msg = CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                    Else
                        R.IsOk = False
                        R.Msg = CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "[已经存在!,请双击编号文本框,获取新编号!"
                    End If
                End If
            End Using
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        End Try
    End Function

    ''' <summary>
    ''' 成品期初库存修改
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable, ByVal Bill_ID As String) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim newID As String = dtTable.Rows(0)("ID")

        paraMap.Add("ID", Bill_ID)
        sqlMap.Add("Table", SQL_CPIni_SelByid)
        sqlMap.Add("List", SQL_CPIni_SelListByid)
        Try
            Using DTH As New DtHelper(sqlMap, paraMap)
                If DTH.IsOk = False Then
                    Throw New Exception(DTH.Msg)
                Else
                    If DTH.DtList("Table").Rows.Count = 1 Then
                        If DTH.DtList("Table").Rows(0)("State") <> Enum_CPRK.New_CPIni Then
                            R.IsOk = False
                            R.Msg = "" & CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                            Return R
                        End If
                        dtTable.Rows(0)("ID") = Bill_ID
                        For Each dr As DataRow In dtList.Rows
                            dr("ID") = Bill_ID
                        Next
                        DvUpdateToDt(dtTable, DTH.DtList("Table"), New List(Of String))
                        DvToDt(dtList, DTH.DtList("List"), New List(Of String))


                        R = DTH.UpdateAll(True, "update T40310_CPIni_Table set ID='" & newID & "' where ID='" & Bill_ID & "' ")
                        If R.IsOk Then R.Msg = CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
                    Else
                        R.IsOk = False
                        R.Msg = CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]不存在"
                    End If
                End If
            End Using
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改错误!"
            DebugToLog(ex)
            Return R
        End Try


        ''Dim msg As New DtListReturnMsg
        ''Dim sqlMap As New Dictionary(Of String, String)
        ''Dim paraMap As New Dictionary(Of String, Object)
        ''Dim Bill_ID As String = dtTable.Rows(0)("ID")
        'paraMap.Add("ID", Bill_ID)
        'Try
        '    sqlMap.Add("Table", SQL_CPIni_SelByid)
        '    sqlMap.Add("List", SQL_CPIni_SelListByid)
        '    msg = SqlStrToDt(sqlMap, paraMap)
        '    If msg.DtList("Table").Rows.Count = 1 Then
        '        If msg.DtList("Table").Rows(0)("State") <> Enum_CPIni.New_CPIni Then
        '            msg.DaList("Table").Dispose()
        '            msg.DaList("List").Dispose()
        '            msg.Cnn.Dispose()
        '            msg.IsOk = False
        '            msg.Msg = "" & CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
        '        End If
        '        DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
        '        DvToDt(dtList, msg.DtList("List"), New List(Of String))
        '        DtToUpDate(msg)
        '        msg.Msg = "" & CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
        '        msg.IsOk = True
        '    Else
        '        msg.IsOk = False
        '        msg.Msg = "" & CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]不存在"
        '    End If
        '    Return msg
        'Catch ex As Exception
        '    msg.IsOk = False
        '    msg.Msg = "" & CPIni_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改错误"
        '    DebugToLog(ex)
        '    Return msg
        'Finally

        'End Try
    End Function





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Bill_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_Del(ByVal Bill_ID As String)
        Return RunSQL(SQL_CPIni_DelCPIniByid, "@ID", Bill_ID)
    End Function

    ''' <summary>
    ''' 审核采购单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_Audit(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P40310_CPIni_Audited", paraMap, True)
        If R.IsOk Then
            If R.Msg.StartsWith("1") Then
                R.IsOk = True
            Else
                R.IsOk = False
            End If
            R.Msg = R.Msg.Substring(1)
        End If
        Return R
    End Function

    ''' <summary>
    ''' 作废采购单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPIni_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_State = Enum_State.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_State.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_CPIni_GetStateByID)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & CPIni_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & CPIni_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & CPIni_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & CPIni_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & CPIni_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function



#End Region

    Public Shared Function CPIni_GetAllQty(ByVal ID As String) As MsgReturn
        Return SqlStrToOneStr("select top 1 AllQty from T40310_CPIni_Table where ID=@ID", "ID", ID)
    End Function


    Public Shared Function CPIni_GetZJ(ByVal ID As String) As MsgReturn
        Dim R As DtReturnMsg = SqlStrToDt("Select Top 1  ID from T40310_CPIni_Table where ID Like @ID order by ID Desc", "ID", ID & "%")
        CPIni_GetZJ = New MsgReturn
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Dim s As String = R.Dt.Rows(0)("ID").ToString.ToUpper
            If IsNumeric(s.Substring(s.Length - 1)) OrElse s.Substring(s.Length - 1) = "R" Then
                s = s & "B"
            Else
                s = s.Substring(0, s.Length - 1) & Chr(Asc(s.Substring(s.Length - 1)) + 1)
            End If
            CPIni_GetZJ.IsOk = True
            CPIni_GetZJ.Msg = s
        Else
            CPIni_GetZJ.IsOk = False
            CPIni_GetZJ.Msg = "入库单号[" & ID & "]不存在!"
        End If
    End Function


    Public Shared Function CPIni_ReSum(ByVal ID As String) As MsgReturn
        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("declare @Store varchar(20)")
        sqlBuider.AppendLine("declare @LastID varchar(20)")
        sqlBuider.AppendLine("declare @sID varchar(20)")
        sqlBuider.AppendLine("declare @MsgTmp varchar(200)")
        sqlBuider.AppendLine("declare @GH varchar(20)")
        sqlBuider.AppendLine("set @LastID=''")
        sqlBuider.AppendLine("set @MsgTmp=''")
        sqlBuider.AppendLine("declare my_cursor cursor for  ")
        sqlBuider.AppendLine("select distinct ID,StoreNo,GH from T40311_CPIni_List where id=@id ")
        sqlBuider.AppendLine("order by id,StoreNo")
        sqlBuider.AppendLine("Open my_cursor")
        sqlBuider.AppendLine("fetch my_cursor into @sID,@Store,@GH")
        sqlBuider.AppendLine("while @@fetch_status=0")
        sqlBuider.AppendLine("begin")
        sqlBuider.AppendLine("	if( @GH='') set @MsgTmp=@MsgTmp+@Store +'|'")
        sqlBuider.AppendLine("        set @LastID=@sID")
        sqlBuider.AppendLine("        fetch my_cursor into @sID,@Store,@GH")
        sqlBuider.AppendLine("        if @LastID<>@sID or @@fetch_status<>0")
        sqlBuider.AppendLine("        begin")
        sqlBuider.AppendLine("        	if len(@MsgTmp)>0 set @MsgTmp=left(@MsgTmp,len(@MsgTmp)-1)")
        sqlBuider.AppendLine("            	update T40310_CPIni_Table ")
        sqlBuider.AppendLine("		set CangWei=@MsgTmp,")
        sqlBuider.AppendLine("		RemainCount=(select count(*) from T40311_CPIni_List where ID=@LastID and GH=''),")
        sqlBuider.AppendLine("		RemainWeight=isnull((select sum(ZL) from T40311_CPIni_List where ID=@LastID and GH='') ,0)")
        sqlBuider.AppendLine("            	where id=@LastID")
        sqlBuider.AppendLine("            	set @MsgTmp=''")
        sqlBuider.AppendLine("        end")
        sqlBuider.AppendLine("end")
        sqlBuider.AppendLine("close my_cursor")
        sqlBuider.AppendLine("deallocate my_cursor")
        Return RunSQL(sqlBuider.ToString(), "id", ID)
    End Function


    '''' <summary>
    '''' 按缸号获取客户同布种
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>

    'Public Shared Function BZ_GetByGH(ByVal GH As String) As DtReturnMsg

    '    Return PClass.PClass.SqlStrToDt(SQL_GET_BZ_BYGH, "@GH", GH)
    'End Function






End Class

