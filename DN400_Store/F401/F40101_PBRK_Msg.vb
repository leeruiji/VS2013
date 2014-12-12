Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40101_PBRK_Msg

    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim Bill_ID_Date As Date
    Dim DtChePai As DataTable
    Dim State As Enum_PBRK = Enum_PBRK.New_PBRK
    Dim StoreNoList As New List(Of String)
    Dim LastID As String = ""
    Dim dtStore As DataTable

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

    Private Sub F20001_PBRK_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.ActiveControl.Name <> SP1.Name AndAlso ActiveControl.Parent.Name <> GB_List.Name Then
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
        ID = 40100
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.CWAudited, Cmd_Comfirm)
        Control_CheckRight(ID, ClassMain.CWUnAudit, Cmd_UnComfirm)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
        Control_CheckRight(ID, ClassMain.ZJ, Cmd_ZJ)
        Control_CheckRight(ID, ClassMain.ModifyZL, Cmd_ModifyZL)
        Control_CheckRight(ID, ClassMain.Miss, CB_Miss)
    End Sub

    Private Sub F40001_BZSH_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.PBRK, Bill_ID)
        ReturnId = TB_ID.Text
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        Fg2.FG_ColResize()
        SumFg3.AddSum()
    End Sub


    Private Sub F10101_PBRK_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Fg1.IniFormat()
        Fg2.IniFormat()
        Fg1.IniColsSize()
        Dim R As DtReturnMsg = Dao.PBRK_Get_Driver
        If R.IsOk Then
            CB_License.DataSource = R.Dt
            CB_driver.DataSource = R.Dt
        End If
        CB_driver.SelectedIndex = -1
        CB_License.SelectedIndex = -1


        Fg1.Cols("ShaPi").Editor = CB_ShaPi
        Fg1.Cols("Machine").Editor = CB_Machine
        Fg1.Cols("Color").Editor = CB_Color
        Me_Refresh()
        Select Case Mode
            Case Mode_Enum.Add
                DP_Date.Value = GetTime().AddHours(-8).Date
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                'Dim msg As RetrunNewIdMsg = Dao.PBRK_GetNewId(Me.DP_Date.Value)
                'If msg.IsOk Then
                '    TB_ID.Text = msg.NewID
                'End If
                'TB_ZhiDan.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                TB_ZhiDan.Text = PClass.PClass.User_Display
                GetNewID()
                Fg3.Rows.Count = 1
            Case Mode_Enum.Modify
                TB_ID.ReadOnly = True
                LabelTitle.Text = "修改" & Me.Ch_Name

                Dim msg As DtReturnMsg = Dao.PBRK_GetDetail(TB_ID.Text)
                If msg.IsOk Then
                    Fg3.DtToFG(msg.Dt)
                Else
                    Fg3.Rows.Count = 1
                End If
        End Select
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.PBRK_GetById(Bill_ID)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            'If msgTable.Dt.Rows.Count = 0 OrElse IsNull(msgTable.Dt.Rows(0)("State"), Enum_PBRK.New_PBRK) >= Enum_PBRK.ShenHe Then
            '    Cmd_Audit.Enabled = False
            'End If
            SetForm(msgTable.Dt)
        End If
        If Mode = Mode_Enum.Add Then
            Cmd_ZJ.Enabled = False
            Dim msg As DtReturnMsg = Dao.PBRK_GetListById(0)
            If msg.IsOk Then
                dtList = msg.Dt
            End If
            Fg1.Rows.Count = 1

            Dim StoreMsg As DtReturnMsg = Dao.PBRK_GetStoreNoById_AddNew(0)
            If StoreMsg.IsOk Then
                dtStore = StoreMsg.Dt
            End If

        Else
            TB_ID.ReadOnly = True
            Cmd_ZJ.Enabled = True
            If State = Enum_PBRK.New_PBRK Then
                Cmd_YTS.Visible = False


                Dim msg As DtReturnMsg = Dao.PBRK_GetListById(Bill_ID)
                If msg.IsOk Then
                    dtList = msg.Dt
                    'DtListToFg(msg.Dt)
                End If
            Else
                Cmd_YTS.Visible = True


                Dim msg As DtReturnMsg = Dao.PBRK_GetListById_Audit(Bill_ID)
                If msg.IsOk Then
                    msg.Dt.Columns.Add("State_Name")
                    For Each Row As DataRow In msg.Dt.Rows
                        If IsNull(Row("GHState"), -1) > 0 Then
                            Row("State_Name") = BaseClass.ComFun.GetProduceStateName(IsNull(Row("GHState"), Enum_ProduceState.AddNew))
                        Else
                            Row("State_Name") = "未配布"
                        End If
                    Next
                    dtList = msg.Dt
                End If
            End If
            Dim Storemsg As DtReturnMsg = Dao.PBRK_GetStoreNoById_Audited(Bill_ID)
            If Storemsg.IsOk Then
                dtStore = Storemsg.Dt
                Fg2.DtToFG(dtStore)
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
            ComFun.DelBillNewID(BillType.PBRK, Bill_ID)
            Bill_ID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DP_Date.Value <> Bill_ID_Date Then
                'Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.PBRK, DP_Date.Value, Bill_ID)
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
    ''' 获取仓位出仓数
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetRKQty() As Integer
        Dim Qty As Integer = 0
        For i As Integer = 1 To Fg2.Rows.Count - 1
            Qty += Val(Fg2.Item(i, "InQty"))
        Next
        Return Qty
    End Function

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
            dr("Client_ID") = Val(CB_Client.IDValue)
            dr("ZhiChang_ID") = Val(CB_ZhiChange.IDValue)
            dr("BZ_ID") = (CB_BZ.IDValue)

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
            GetControlValue(dr, TB_ShaPi)
            GetControlValue(dr, TB_Machine)
            GetControlValue(dr, TB_ClientBill)
            GetControlValue(dr, TB_Notice)
            GetControlValue(dr, TB_Remark)
            GetControlValue(dr, TB_State_User)
            GetControlValue(dr, TB_XiaoZhang)
            GetControlValue(dr, TB_ZhiDan)
            GetControlValue(dr, CK_IsFG)
            GetControlValue(dr, CK_IsBooked)
            GetControlValue(dr, CK_IsXM)

            dr("State") = State
            dt.Rows.Add(dr)
            dtTable = dt
            'For Each R As DataRow In dtList.Rows
            '    R.Item("PBRK_ID") = TB_ID.Text
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
                row("PB") = 0
                row("CP") = 0
                row("GH") = ""
                row("FG") = ""
                'row("StoreNo") = Fg1.Item(i, "StoreNo")
                row("ShaPi") = Fg1.Item(i, "ShaPi")
                row("Machine") = Fg1.Item(i, "Machine")
                row("Color") = Fg1.Item(i, "Color")
                row("ID") = TB_ID.Text
                _dtList.Rows.Add(row)
                '刷新仓位列表
            Next
            dtList = _dtList
        End If

        Dim CangWei As String = ""
        Dim drt As DataRow
        If dtStore.Columns.Contains("sDate") = False Then dtStore.Columns.Add("sDate", GetType(Date))
        Dim _dtStore As DataTable = dtStore.Clone

        If Not _dtStore.Columns.Contains("BillType") Then
            _dtStore.Columns.Add("BillType", GetType(String))
        End If
        If Not _dtStore.Columns.Contains("BillName") Then
            _dtStore.Columns.Add("BillName", GetType(String))
        End If
        For i As Integer = 1 To Fg2.Rows.Count - 1
            drt = _dtStore.NewRow
            drt("BillType") = 40100
            drt("BillName") = "胚布入库单"
            drt("ID") = TB_ID.Text
            drt("StoreNo") = Fg2.Item(i, "StoreNo")
            CangWei = CangWei & drt("StoreNo") & "|"
            drt("InQty") = Fg2.Item(i, "InQty")
            drt("sDate") = GetTime()
            _dtStore.Rows.Add(drt)
        Next
        dtStore = _dtStore
        dt.Rows(0)("CangWei") = CangWei.Remove(CangWei.Length - 1, 1)

        Return dt

    End Function


    Sub SetAddState()
        LabelState.Text = "新建"
        LabelState.ForeColor = Color.Black
        Cmd_Modify.Enabled = Cmd_Modify.Tag

        Cmd_UnComfirm.Visible = False
        Cmd_UnComfirm.Enabled = False
        Cmd_Comfirm.Visible = False
        Cmd_Comfirm.Enabled = False
        Cmd_Audit.Visible = True
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
            State = Enum_BZSHState.AddNew
        Else
            State = dt.Rows(0)("State")
        End If


        Cmd_Del.Visible = False
        Select Case State
            Case Enum_BZSHState.AddNew '新建
                SetAddState()

            Case Enum_BZSHState.Invoid '作废
                LabelState.Text = "已作废"
                LabelState.ForeColor = Color.Red
                Cmd_Modify.Enabled = False

                Cmd_Audit.Visible = Cmd_Audit.Tag
                Cmd_Audit.Enabled = False
                Cmd_UnAudit.Visible = False
                Cmd_UnAudit.Enabled = False
                Cmd_AddStoreNo.Enabled = False
                Cmd_SetValid.Visible = Cmd_SetValid.Tag
                Cmd_SetValid.Enabled = True
                Cmd_SetInValid.Visible = False
                Cmd_SetInValid.Enabled = False
                Cmd_ZJ.Enabled = False
                LockForm(True)

            Case Enum_BZSHState.Store_Comfirm  '确认

                LabelState.Text = "已确认"
                LabelState.ForeColor = Color.Blue
                Cmd_Modify.Enabled = False
                Cmd_AddStoreNo.Enabled = False
                Cmd_UnComfirm.Visible = False
                Cmd_UnComfirm.Enabled = False
                Cmd_Comfirm.Visible = Cmd_Comfirm.Tag
                Cmd_Comfirm.Enabled = True
                Cmd_Audit.Visible = False
                Cmd_Audit.Enabled = False
                Cmd_UnAudit.Visible = Cmd_UnAudit.Tag
                Cmd_UnAudit.Enabled = True
                Cmd_ZJ.Visible = Cmd_ZJ.Tag
                Cmd_ZJ.Enabled = True
                Cmd_ModifyZL.Visible = Cmd_ModifyZL.Tag
                Cmd_ModifyZL.Enabled = True

                Cmd_SetValid.Visible = False
                Cmd_SetValid.Enabled = False
                Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                Cmd_SetInValid.Enabled = False

                LockForm(True)
            Case Enum_BZSHState.Audited '审核

                LabelState.Text = "已审核"
                LabelState.ForeColor = Color.Blue
                Cmd_Modify.Enabled = False
                Cmd_AddStoreNo.Enabled = False
                Cmd_UnComfirm.Visible = Cmd_UnComfirm.Tag
                Cmd_UnComfirm.Enabled = True
                Cmd_Comfirm.Visible = False
                Cmd_Comfirm.Enabled = False
                Cmd_Audit.Visible = False
                Cmd_Audit.Enabled = False
                Cmd_UnAudit.Visible = False
                Cmd_UnAudit.Enabled = False
                Cmd_ZJ.Visible = False
                Cmd_ZJ.Enabled = False
                Cmd_ModifyZL.Visible = False
                Cmd_ModifyZL.Enabled = False

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
            CB_Client.IDValue = IsNull(Dr("Client_ID"), "0")
            CB_Client.Text = CB_Client.GetByTextBoxTag()
            TB_ClientName.Text = CB_Client.NameValue

            CB_BZ.IDValue = IsNull(Dr("BZ_ID"), "0")
            CB_BZ.Text = CB_BZ.GetByTextBoxTag()
            TB_BZName.Text = CB_BZ.NameValue


            CB_ZhiChange.IDValue = IsNull(Dr("ZhiChang_ID"), "0")
            CB_ZhiChange.Text = CB_ZhiChange.GetByTextBoxTag()

            TB_SumQty.Text = FormatNum(IsNull(Dr("SumQty"), 0))
            TB_PWeight.Text = FormatZL(IsNull(Dr("SumPWeight"), 0))

            CB_driver.SelectedValue = IsNull(Dr("driver"), "")
            CB_License.SelectedValue = IsNull(Dr("License"), "")
            SetControlValue(Dr, TB_ShaPi)
            SetControlValue(Dr, TB_ClientBill)

            SetControlValue(Dr, TB_Machine)

            SetControlValue(Dr, CK_IsFG)
            SetControlValue(Dr, CK_IsBooked)
            SetControlValue(Dr, CK_IsXM)

            SetControlValue(Dr, TB_Notice)
            SetControlValue(Dr, TB_Remark)

            SetControlValue(Dr, TB_State_User)
            SetControlValue(Dr, TB_XiaoZhang)
            SetControlValue(Dr, TB_ZhiDan)

            LB_AllQty.Tag = IsNull(Dr("SumQty"), 0)

            LastID = IsNull(Dr("LastID"), "")
            If LastID = "" Then
                Pane_LastID.Visible = False
                SetAllQty(IsNull(Dr("AllQty"), 0))
            Else
                Panel_All.Visible = True
                Pane_LastID.Visible = True
                LB_LastID.Text = LastID
                LB_AllQty.Text = "计算中..."
                Dim T As New Threading.Thread(AddressOf LoadAllQty)
                T.Start()
            End If
            Cmd_ModifyZL.Visible = Cmd_ModifyZL.Tag AndAlso (Cmd_Modify.Visible = False)
        Else
            Pane_LastID.Visible = False
            Panel_All.Visible = False
        End If
    End Sub

    Sub LoadAllQty()
        Dim R As MsgReturn = Dao.PBRK_GetAllQty(LastID)
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
                Pane_LastID.Visible = False
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

        Fg2.CanEditing = Not Lock
        Fg2.IsClickStartEdit = Not Lock



        Btn_AddRow.Enabled = Not Lock
        Btn_RemoveRow.Enabled = Not Lock

        CB_ZhiChange.Enabled = Not Lock
        CB_BZ.Enabled = Not Lock
        CB_Client.Enabled = Not Lock
        TB_Notice.ReadOnly = Lock
        'TB_ShaPi.ReadOnly = Lock
        'TB_StoreNo.ReadOnly = Lock
        TB_ClientBill.ReadOnly = Lock
        TB_Remark.ReadOnly = Lock
        Fg1.Cols("GH").Visible = Lock
        Fg1.Cols("CP").Visible = Lock
        Fg1.Cols("PB").Visible = Lock
        Fg1.Cols("State_Name").Visible = Lock
        Fg1.Cols("Date_PeiBu").Visible = Lock
        Fg1.Cols("CK_Date").Visible = Lock

        Cmd_SaveCar.Visible = Lock AndAlso Cmd_Modify.Tag

        If Lock Then
            Fg1.Cols("ZL").Width = 79
            'Fg1.Cols("StoreNo").Width = 79
            Fg1.Cols("ShaPi").Width = 79
            Fg1.Cols("Machine").Width = 79
        End If

        Fg1.IniColsSize()
        Fg1.FG_ColResize()

        '   Fg2.Cols("SumQty").Visible = Not Lock
        '   Fg2.Cols("OQty").Visible = Lock
        '   Fg2.Cols("Qty").Visible = Lock

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
        CB_ShaPi.Items.Clear()
        CB_Machine.Items.Clear()
        Dim IsAddStore As Boolean = False
        For R As Integer = 1 To Fg1.Rows.Count - 1

            If Val(Fg1.Item(R, "ZL")) > 0 Then
                SumQty = SumQty + 1
                SumPWeight = SumPWeight + Val(Fg1.Item(R, "ZL"))
                If Fg1.Item(R, "GH") = "" Then
                    ReMainQty = ReMainQty + 1
                    ReMainZl = ReMainZl + Val(Fg1.Item(R, "ZL"))
                End If
            End If
            'If Fg1.Item(R, "GH") = "" Then
            '    Dim _StoreNo As String = Fg1.Item(R, "StoreNo")
            '    If _StoreNo IsNot Nothing AndAlso _StoreNo <> "" AndAlso Not StoreNoList.Contains(_StoreNo) Then
            '        StoreNoList.Add(_StoreNo)
            '        IsAddStore = True
            '    End If
            'End If

            Dim _ShaPi As String = Fg1.Item(R, "ShaPi")
            If _ShaPi <> "" AndAlso Not CB_ShaPi.Items.Contains(_ShaPi) Then
                If R > 1 Then
                    ShaPi.Append("|")
                End If
                CB_ShaPi.Items.Add(_ShaPi)
                ShaPi.Append(_ShaPi)
            End If

            Dim _Machine As String = Fg1.Item(R, "Machine")
            If _Machine <> "" AndAlso Not CB_Machine.Items.Contains(_Machine) Then
                If R > 1 Then
                    Machine.Append("|")
                End If
                CB_Machine.Items.Add(_Machine)
                Machine.Append(_Machine)
            End If
        Next
        'If IsAddStore Then ReFresh_StoreNo() Else SumStoreNo()
        TB_Machine.Text = Machine.ToString
        TB_ShaPi.Text = ShaPi.ToString
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
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SavePBRK)
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
        ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SavePBRK)
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SavePBRK(Optional ByVal Audit As Boolean = False)
        'ReFresh_StoreNo(True)
        dtList.AcceptChanges()

        Dim R As MsgReturn
        '    dtList = FGToDtList()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.PBRK_Add(GetForm(), dtList, dtStore)
        Else
            R = Dao.PBRK_Save(GetForm(), dtList, dtStore)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            If Audit Then
                Dim msg As MsgReturn = Dao.PBRK_Audit(TB_ID.Text, True)
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
        TB_ID.Focus()
        TB_ID.Text = TB_ID.Text.Trim
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If

        TB_ID.Text = ComFun.FixRK(TB_ID.Text)
        Dim R As MsgReturn = ComFun.CheckRK(TB_ID.Text, LastID <> "")
        If R.IsOk = False Then
            ShowErrMsg(R.Msg, AddressOf TB_ID.Focus)
            Return False
        End If

        If Mode = Mode_Enum.Add AndAlso Dao.PBRK_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
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
        If CB_Miss.Checked = False Then
            For i As Integer = 1 To Fg1.Rows.Count - 1
                'If IsNull(Fg1.Item(i, "StoreNo"), "") = "" Then
                '    ShowErrMsg("仓位不能为空!")
                '    Return False
                'End If
                If Val(Fg1.Item(i, "ZL")) > MaxZL Then
                    ShowErrMsg("列表第" & i & "行入库重量大于" & MaxZL & "!     ")
                    Return False
                End If

                If Val(Fg1.Item(i, "ZL")) < MinZL Then
                    ShowErrMsg("列表第" & i & "入库重量小于" & MinZL & "!     ")
                    Return False
                End If

            Next
        End If

        For I As Integer = Fg2.Rows.Count - 1 To 1 Step -1
            If IsNull(Fg2.Item(I, "StoreNo"), "") = "" Then
                Fg2.RemoveItem(I)
            End If
        Next




        Dim Qty = GetRKQty()
        If TB_SumQty.Text <> Qty Then
            ShowErrMsg("入库条数［" & TB_SumQty.Text & "］与仓位入库总和［" & Qty & "］不一致")
            Return False
        End If

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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelPBRK)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelPBRK()
        Dim msg As MsgReturn = Dao.PBRK_Del(TB_ID.Text)
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
            'Fg1.Item(Fg1.Rows.Count - 1, "StoreNo") = Fg1.Item(Fg1.Rows.Count - 2, "StoreNo")
            Fg1.Item(Fg1.Rows.Count - 1, "ShaPi") = Fg1.Item(Fg1.Rows.Count - 2, "ShaPi")
            Fg1.Item(Fg1.Rows.Count - 1, "Color") = Fg1.Item(Fg1.Rows.Count - 2, "Color")
            Fg1.Item(Fg1.Rows.Count - 1, "Machine") = Fg1.Item(Fg1.Rows.Count - 2, "Machine")
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
        ShowConfirm("是否取消确认" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.PBRK_Audit(TB_ID.Text, False)
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
                If Not Fg1.Item(e.Row, "ShaPi") Is Nothing AndAlso Fg1.Item(e.Row, "ShaPi") <> "" Then
                    If e.Row + 2 > Fg1.Rows.Count Then
                        AddRow()
                    End If
                    e.ToRow = e.Row + 1
                    e.ToCol = 1
                Else
                    e.ToCol = Fg1.Cols("ShaPi").Index
                End If
                'Case "storeno"
                '    e.ToCol = Fg1.Cols("ShaPi").Index
            Case "shapi"
                e.ToCol = Fg1.Cols("Machine").Index
            Case "machine"
                e.ToCol = Fg1.Cols("Color").Index
            Case "color"
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
        If e.Col = Fg1.Cols("ZL").Index And CB_Miss.Checked = False Then
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

        If Fg1.LastKey = Keys.Enter Then
            If e.Col = Fg1.Cols("ShaPi").Index Then
                Fg1.Item(Fg1.RowSel, "ShaPi") = CB_ShaPi.Text
            End If
            Fg1.GotoNextCell()
        End If
        CaculateSumAmount()
    End Sub


#End Region

#Region "FG2事件"

    Private Sub Fg2_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg2.NextCell

        Select Case e.Col
            Case "StoreNo"
                e.ToCol = Fg2.Cols("InQty").Index

            Case "InQty"
                If e.Row + 2 > Fg2.Rows.Count Then
                    Fg2AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = 1
        End Select
    End Sub

    Private Sub Fg2_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg2.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg2.LastKey = Keys.Enter Then
            Fg2.LastKey = 0
            Select Case Fg2.Cols(e.Col).Name
                Case "StoreNo"
                    Fg2.Item(e.Row, "StoreNo") = Fg2.Item(e.Row, "StoreNo").ToString.ToUpper
                    If SetStoreCheck(Fg2.Item(e.Row, "StoreNo")) = False Then
                        Fg2.Item(e.Row, "StoreNo") = ""
                    Else
                        Fg2.Item(e.Row, "SumQty") = Dao.GetStoreQty(Fg2.Item(e.Row, "StoreNo"))
                        Fg2.GotoNextCell(e.Col)
                    End If
                Case "InQty"
                    '  Fg2.Item(e.Row, "OQty") = 0
                    ' Fg2.Item(e.Row, "Qty") = Val(Fg2.Item(e.Row, "InQty")) - Val(Fg2.Item(e.Row, "OQty"))
                    SumFg3.ReSum()
                    Fg2.GotoNextCell(e.Col)
                Case Else
                    Fg2.GotoNextCell(e.Col)
            End Select
        End If


        Select Case Fg2.Cols(e.Col).Name
            Case "InQty"
                '  Fg2.Item(e.Row, "OQty") = 0
                ' Fg2.Item(e.Row, "Qty") = Val(Fg2.Item(e.Row, "InQty")) - Val(Fg2.Item(e.Row, "OQty"))
                SumFg3.ReSum()
            Case Else
        End Select

    End Sub

    Private Sub Fg2AddRow()
        Fg2.AddRow()
    End Sub


    Private Function SetStoreCheck(ByVal StorNo As String) As Boolean
        Dim T As Integer = 0
        For i As Integer = 1 To Fg2.Rows.Count - 1
            If StorNo = Fg2.Item(i, "StoreNo") Then
                T += 1
            End If
        Next
        If T > 1 Then
            T = 0
            ShowErrMsg("仓位［" & StorNo & "］已被选择")
            Return False
        End If

        If CheckStoreNo(StorNo) = False Then
            ShowErrMsg("找不到仓位［" & StorNo & "］")
            Return False
        End If
        Return True
    End Function

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
        'Dim R As New R40001_PBRK
        'R.Start(TB_ID.Text, DoOperator)
    End Sub

#End Region

#Region "客户和布种"
    Private Sub CB_Client_SetEmpty() Handles CB_Client.SetEmpty
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
    Private Sub CB_BZ_SetEmpty() Handles CB_BZ.SetEmpty
        TB_BZName.Text = ""
    End Sub
#End Region


#Region "确认状态"
    ''' <summary>
    ''' 确认状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click
        Fg1.FinishEditing()
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                Dim D As Date = GetTime.AddHours(-8).Date
                If DP_Date.Value.Date <> D Then
                    ShowConfirm("你选择的入库日期是[" & DP_Date.Value.Date.ToString("yyyy-MM-dd") & "]和单前日期[" & D.Date.ToString("yyyy-MM-dd") & "]不相同,是否继续保存" & Ch_Name & "?", "继续保存", "改为当天", "取消", AddressOf ShenheConfirm, AddressOf ShenheAsDate, AddressOf Me.NoSave)
                Else
                    ShenheConfirm()
                End If
            Else
                ShowConfirm("是否保存并确认" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf QueRen)
            End If
        End If

    End Sub



    Sub ShenheAsDate()
        DP_Date.Value = GetTime.AddHours(-8).Date
        ShenheConfirm()
    End Sub


    Sub ShenheConfirm()
        ShowConfirm("是否保存并确认新" & Ch_Name & "?", AddressOf QueRen)
    End Sub


    Protected Sub QueRen()
        SavePBRK(True)
    End Sub
#End Region

    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        If Me.Mode = Mode_Enum.Add Then
            ShowErrMsg("入库单没有保存，不能作废！")
            Exit Sub
        End If
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf PBRKInValid)
    End Sub
    Sub PBRKInValid()
        Dim msg As MsgReturn = Dao.PBRK_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf PBRKValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub PBRKValid()
        Dim msg As MsgReturn = Dao.PBRK_InValid(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

#Region "选择仓位"
    '''' <summary>
    '''' 选择仓位
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub Cmd_StoreNoSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim L As New List(Of String)
    '    For Each X As String In CB_StoreNo.Items
    '        L.Add(X)
    '    Next
    '    Dim F As New F40500_Store_Map(cStore_Area.Enum_SelType.Cell, L)
    '    With F
    '        .Mode = Mode_Enum.Add
    '        .IsSel = True
    '        .P_F_RS_ID = ""
    '        .P_F_RS_ID2 = ""
    '    End With
    '    F_RS_ID = ""
    '    Me.ReturnId = ""
    '    Me.ReturnObj = Nothing
    '    Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
    '    VF.MaximizeBox = True

    '    AddHandler VF.ClosedX, AddressOf GetStoreNo

    '    VF.Show()
    'End Sub
    '''' <summary>
    '''' 
    '''' </summary>
    '''' <remarks></remarks>
    'Protected Sub GetStoreNo()
    '    If Not Me.ReturnObj Is Nothing Then
    '        Try
    '            Dim sNoList As List(Of String) = Me.ReturnObj
    '            For Each _sNo As String In sNoList
    '                _sNo = _sNo.ToUpper
    '                If Not CB_StoreNo.Items.Contains(_sNo) Then
    '                    CB_StoreNo.Items.Add(_sNo)
    '                End If
    '            Next
    '            CaculateSumAmount()
    '            SetStoreNoList()
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    'Private Sub SetStoreNoList(Optional ByVal isSave As Boolean = False)
    '    Dim sNoBuider As New StringBuilder()
    '    Dim i As Integer = 0
    '    If isSave Then
    '        For Each _sNo As String In StoreNoList
    '            If i > 0 Then
    '                sNoBuider.Append("|")
    '            End If
    '            sNoBuider.Append(_sNo)
    '            i = i + 1
    '        Next
    '    Else

    '        For Each _sNo As String In CB_StoreNo.Items
    '            If i > 0 Then
    '                sNoBuider.Append("|")
    '            End If
    '            sNoBuider.Append(_sNo)
    '            i = i + 1
    '        Next
    '    End If


    '    TB_CangWei.Text = sNoBuider.ToString
    '    'CB_StoreNo.DataSource = Nothing
    '    'CB_StoreNo.DataSource = Me.StoreNoList
    'End Sub







    '''' <summary>
    '''' 把手动改的仓位值刷新到列表
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub TB_StoreNo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If TB_CangWei.Text <> "" AndAlso TB_CangWei.Text <> TB_CangWei.Tag Then
    '        Dim snos As String() = TB_CangWei.Text.Split("|")
    '        CB_StoreNo.Items.Clear()
    '        For Each s As String In snos
    '            CB_StoreNo.Items.Add(s)
    '        Next
    '    End If
    'End Sub


    '''' <summary>
    '''' 记住原始的值
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub TB_StoreNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    TB_CangWei.Tag = TB_CangWei.Text

    'End Sub



#End Region

#Region "选择仓位"


#End Region


    Private Sub Cmd_ZJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ZJ.Click

        Dim R As MsgReturn = Dao.PBRK_GetZJ(TB_ID.Text.Substring(0, 6))
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
            Cmd_ZJ.Enabled = False
            TB_ID.ReadOnly = True

            CaculateSumAmount()

        Else
            ShowErrMsg("入库单追加失败" & R.Msg)
        End If
    End Sub

    Private Sub Cmd_YTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_YTS.Click
        Dim R As MsgReturn = Dao.PBRK_ReSum(TB_ID.Text)
        If R.IsOk Then
            ShowOk("重新计算余条数成功!")
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg("重新计算余条数失败!" & R.Msg)
        End If
    End Sub


    Private Sub TB_ID_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ID.DoubleClick
        If TB_ID.ReadOnly AndAlso State = Enum_PBRK.New_PBRK Then
            ShowInput("你要把单号[" & TB_ID.Text & "]修改成:", AddressOf ReName, TB_ID.Text)
        End If
    End Sub
    Sub ReName(ByVal S As String)
        If S = "" Then
            ShowErrMsg("单号不能为空")
            Exit Sub
        End If
        S = ComFun.FixRK(S)
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

    Private Sub Cmd_SaveCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SaveCar.Click
        Dim R As MsgReturn = Dao.PBRK_SaveCar(Bill_ID, CB_License.Text, CB_driver.Text)
        If R.IsOk Then
            ShowOk("保存车牌成功成功!")
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg("保存车牌成功失败!" & R.Msg)
        End If
    End Sub

    Private Sub Cmd_ModifyZL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ModifyZL.Click
        If Fg1.RowSel < 1 Then
            ShowErrMsg("请选择要改重的行?")
            Exit Sub
        End If
        If Fg1.Item(Fg1.RowSel, "GH") <> "" Then
            ShowErrMsg("本行已经被配布,不能改重量?")
            Exit Sub
        End If
        Line = Fg1.Item(Fg1.RowSel, "Line")
        ShowInput("你要把重量[" & Fg1.Item(Fg1.RowSel, "ZL").ToString & "]改成:", AddressOf SaveZL, Fg1.Item(Fg1.RowSel, "ZL").ToString)

    End Sub

    Dim Line As Long
    Sub SaveZL(ByVal ZL As String)
        ZL = StrConv(ZL, vbNarrow)
        If Val(ZL) = 0 Then
            ShowErrMsg("重量不能为零?")
            Exit Sub
        End If
        If ZL > MaxZL Then
            ShowErrMsg("入库重量不能大于" & MaxZL & "!  ")
            Exit Sub
        End If
        If ZL < MinZL Then
            ShowErrMsg("入库重量不能小于" & MinZL & "!  ")
            Exit Sub
        End If
        Dim R As MsgReturn = Dao.PBRK_SaveZL(Bill_ID, Line, Val(ZL))
        If R.IsOk Then
            Fg1.Item(Fg1.RowSel, "ZL") = ZL
            CaculateSumAmount()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg("保存车牌成功失败!" & R.Msg)
        End If
    End Sub







    Private Sub TSIAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSIAdd.Click
        Fg2.AddRow()
    End Sub

    Private Sub TsiRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsiRemove.Click
        Fg2.FinishEditing(True)
        Dim i As Integer = Fg2.RowSel
        If i > 0 AndAlso Fg2.Rows.Count > 1 Then
            Try
                Fg2.Rows.Remove(i)
            Catch ex As Exception
            End Try
            If Fg2.Rows.Count < 2 Then

            Else
                Fg2.ReAddIndex()
            End If
        End If
    End Sub



    Private Sub Cmd_AddStoreNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddStoreNo.Click

        Dim Li As New List(Of String)
        For i As Integer = 1 To Fg2.Rows.Count - 1
            If IsNull(Fg2.Item(i, "StoreNo"), "") <> "" Then
                Li.Add(Fg2.Item(i, "StoreNo"))
            End If
        Next


        Dim F As New F40500_Store_Map(cStore_Area.Enum_SelType.Cell, Li)
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
        AddHandler VF.ClosedX, AddressOf GetOldStoreNo
        VF.Show()
    End Sub


    Protected Sub GetOldStoreNo()
        If Not Me.ReturnObj Is Nothing Then
            Try
                Fg2.FinishEditing()
                Fg2.CanEditing = False
                Dim sNoList As List(Of String) = Me.ReturnObj
                For i As Integer = Fg2.Rows.Count - 1 To 1 Step -1
                    If sNoList.Contains(Fg2.Item(i, "StoreNo")) Then
                        sNoList.Remove(Fg2.Item(i, "StoreNo"))
                    Else
                        Fg2.Rows.Remove(i)
                    End If
                Next

                For Each S As String In sNoList
                    Fg2.Rows.Add()
                    Fg2.Item(Fg2.Rows.Count - 1, "StoreNo") = S
                    Fg2.Item(Fg2.Rows.Count - 1, "SumQty") = Dao.GetStoreQty(S)
                Next
                Fg2.CanEditing = True
                SumFg3.ReSum()
                Fg2.ReAddIndex()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Cmd_Comfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Comfirm.Click
        'ShowConfirm("是否要财务审核?", AddressOf TB_ID.Focus)
        If State = Enum_BZSHState.Store_Comfirm Then
            Dim P As New Dictionary(Of String, Object)
            P.Add("ID", TB_ID.Text)
            SqlStrToDt("update T40100_PBRK_Table set State=2 where ID=@ID", P)
            ShowOk("财务审核成功!")
        Else
            ShowOk("财务审核失败!")
        End If
        Me_Refresh()
        LastForm.ReturnId = TB_ID.Text
    End Sub

    Private Sub Cmd_UnComfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnComfirm.Click
        'ShowConfirm("是否要反审?", AddressOf TB_ID.Focus)
        If State = Enum_BZSHState.Audited Then
            Dim P As New Dictionary(Of String, Object)
            P.Add("ID", TB_ID.Text)
            SqlStrToDt("update T40100_PBRK_Table set State=1 where ID=@ID", P)
            ShowOk("财务反审成功!")
        Else
            ShowOk("财务反审失败!")
        End If
        Me_Refresh()
        LastForm.ReturnId = TB_ID.Text
    End Sub

    Private Sub CK_IsBooked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_IsBooked.Click
        If LabelState.Text = "已确认" Or LabelState.Text = "已审核" Then
            Dim check As String
            If CK_IsBooked.Checked = False Then
                check = 0
            Else
                check = 1
            End If
            Dim P As New Dictionary(Of String, Object)
            P.Add("ID", TB_ID.Text)
            RunSQL("update T40100_PBRK_Table set IsBooked= " & check & "  where ID=@ID", P)
        End If
    End Sub

    Private Sub CK_IsXM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_IsXM.Click
        If LabelState.Text = "已确认" Or LabelState.Text = "已审核" Then
            Dim check As String
            If CK_IsXM.Checked = False Then
                check = 0
            Else
                check = 1
            End If
            Dim P As New Dictionary(Of String, Object)
            P.Add("ID", TB_ID.Text)
            RunSQL("update T40100_PBRK_Table set IsXM= " & check & "  where ID=@ID", P)
        End If
    End Sub
End Class







Public Enum Enum_PBRK
    New_PBRK = 0
    ShenHe = 1
    XiaoZhang = 2
End Enum
Partial Class Dao

    ''' <summary>
    ''' 改重量
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Line"></param>
    ''' <param name="ZL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_SaveZL(ByVal ID As String, ByVal Line As Long, ByVal ZL As Double) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        P.Add("ZL", ZL)
        Dim sqlBuider As New StringBuilder()
        '  sqlBuider.AppendLine("ALTER  TABLE  T40101_PBRK_List  DISABLE  TRIGGER  T40101_PBRK_List_Update ")
        sqlBuider.AppendLine("update T40101_PBRK_List set ZL=@ZL")
        sqlBuider.AppendLine("where ID=@ID and Line=@Line ")
        'sqlBuider.AppendLine("update T40510_PB_Stock set ZL=@ZL")
        'sqlBuider.AppendLine("where ID=@ID and Line=@Line")
        sqlBuider.AppendLine("update T40100_PBRK_Table")
        sqlBuider.AppendLine("set SumPWeight=isnull((select sum(ZL) from T40101_PBRK_List where ID=@ID ) ,0),")
        sqlBuider.AppendLine("RemainWeight=isnull((select sum(ZL) from T40101_PBRK_List where ID=@ID and GH='') ,0)")
        sqlBuider.AppendLine("where id=@ID")
        '   sqlBuider.AppendLine("ALTER  TABLE  T40101_PBRK_List  ENABLE  TRIGGER  T40101_PBRK_List_Update")
        Return SqlStrToOneStr(sqlBuider.ToString, P)
    End Function

    Public Shared Function PBRK_SaveCar(ByVal ID As String, ByVal License As String, ByVal driver As String) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("License", License)
        P.Add("driver", driver)
        Return SqlStrToOneStr("update T40100_PBRK_Table set License=@License,driver=@driver where ID=@ID", P)
    End Function
#Region "胚布入库单"


#Region "胚布入库单信息"


    '===================胚布入库单信息==============
    Public Const SQL_PBRK_Get_WithName = "select  P.*,Client_No,S.Client_Name,BZ_No,BZ_Name,Z.ZhiChang_Name as ZhiChang  from T40100_PBRK_Table P WITH(NOLOCK)   left join T10120_ZhiChang Z on  Z.id=P.ZhiChang_ID left join T10110_Client S on  P.Client_ID=S.ID left join T10002_BZ BZ on BZ.ID =P.BZ_ID "


    Public Const SQL_PBRK_Get_Body As String = " from T40100_PBRK_Table P left join T10110_Client S on  P.Client_ID=S.ID  "

    Public Const SQL_PBRK_Get_leftJoin_GoodsNo As String = " left join (  select distinct ID, Bz_ID from T40101_PBRK_List    ) List on List.ID=p.ID"
    Public Const SQL_PBRK_Get_leftJoin_GoodsName As String = "   left join (  select distinct ID, G.Bz_No,G.Bz_Name from T40101_PBRK_List PL left join T10002_BZ G on PL.BZ_ID=G.id ) List on List.ID=p.ID"

    Public Const SQL_PBRK_GetPBRKByid As String = "select top 1 * from T40100_PBRK_Table  where ID=@ID"

    Public Const SQL_PBRK_GetPBRKListByid_Audit As String = "select L.*,G.Date_PeiBu,G.State as GHState,Isnull((select top 1 StoreNo from T40151_PBTC_List where sLine=L.Line order by Line),StoreNo) as StoreNo_Old from T40101_PBRK_List L left join T30000_Produce_Gd G ON G.GH=L.GH where l.ID=@ID"

    Public Const SQL_PBRK_GetPBRKByidWhithClientName As String = SQL_PBRK_Get_WithName & "  where ID=@ID"

    Public Const SQL_PBRK_GetPBRKListByid As String = "select * from T40101_PBRK_List  where ID=@ID"

    Public Const SQL_PBRK_GetPBRKListByid_ForReport As String = "select P.* ,P.BZ_ID + '#' +BZ.BZ_Name as BZ_Name ,isNull( Client_Bzc,'') +'#'+BZC.BZC_Name+' GY-' + right('00000' + P.BZC_ID,6) as BZC_Name  from T40101_PBRK_List  P left join T10002_BZ BZ on BZ.BZ_ID=P.BZ_ID  left join T10003_BZC BZC on BZC.BZC_ID=P.BZC_ID  where ID=@ID order by ID"

    Public Const SQL_PBRK_CheckID As String = "select count(*) from T40100_PBRK_Table  where ID=@ID"
    Public Const SQL_GET_BZ_BYGH As String = " SELECT G.BZ_ID, B.BZ_Name, G.Client_ID, C.Client_Name FROM T30000_Produce_Gd G LEFT OUTER JOIN  T10110_Client C ON G.Client_ID = C.ID LEFT OUTER JOIN T10002_BZ B ON B.ID = G.BZ_ID WHERE G.GH =@GH"

    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBRK_SelByid As String = "select top 1 * from T40100_PBRK_Table  where ID=@ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBRK_SelListByid As String = "select  * from T40101_PBRK_List  where ID=@ID"

    Public Const SQL_PBRK_SelStoreNobyID As String = "select S.ID,S.StoreNo,S.InQty as InQty,(select Sum(Qty)  from  T40520_PB_StoreNo where   StoreNO=S.StoreNo ) SumQty,sDate from T40521_PB_Detail S where   S.ID=@ID and Billtype=40100 "
    Public Const SQL_PBRK_SelStoreNobyID_Audite As String = "select S.ID,S.StoreNo,s.InQty" & vbCrLf & _
   ",(select Sum(Qty)  from  T40520_PB_StoreNo where ID=@ID and   StoreNO=S.StoreNo   ) dQty " & vbCrLf & _
   ",(select Sum(Qty)  from  T40520_PB_StoreNo where   StoreNO=S.StoreNo ) SumQty " & vbCrLf & _
   "from (select ID, StoreNo,SUM(InQty) as InQty from T40521_PB_Detail where ID=@ID and Billtype=40100 group by ID ,StoreNo)  S " & vbCrLf & _
   "union all" & vbCrLf & _
   "select ID,StoreNO,0,Qty" & vbCrLf & _
   ",(select Sum(Qty)  from  T40520_PB_StoreNo where   StoreNO=S.StoreNo ) SumQty " & vbCrLf & _
   "from T40520_PB_StoreNo S where   S.ID=@ID  " & vbCrLf & _
   "and not exists(select * from T40521_PB_Detail " & vbCrLf & _
   "where ID=@ID and Billtype=40100 and StoreNO =S.StoreNO)"
    '" SELECT D.ID,D.StoreNo, SumQty=(Select ISNULL(Sum(ISNULL(Qty,0)),0) as SumQty From T40520_PB_StoreNo Where StoreNo=D.StoreNo) , D.InQty,-isnull(S.InQty,0) as OQty ,D.BillType,D.BillName ,ISNULL(Sn.Qty,0)As Qty  From  " & _
    '                                                   "  (select BillType,BillName, ID,StoreNo,Sum(InQty) As InQty FROM T40521_PB_Detail Where ID=@ID And BillType=40100 Group by BillType,BillName, ID,StoreNo )D Left join  " & _
    '                                                  "   (select ID,StoreNo,Sum(InQty) As InQty FROM T40521_PB_Detail Where ID=@ID And BillType=40200 Group by ID,StoreNo )S oN D.ID=S.ID AND " & _
    '                                                   "  D.StoreNo=S.StoreNo Left join  T40520_PB_StoreNo Sn On Sn.ID=D.ID And Sn.StoreNo=D.StoreNo "


    Public Const SQL_Store_ByID As String = "Select * from T40521_PB_Detail Where ID=@ID And BillType=40100"


    ''' <summary> 
    ''' 删除
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBRK_DelPBRKByid As String = "Delete from  T40100_PBRK_Table where ID=@ID delete from T40521_PB_Detail where ID=@ID "
    Public Const SQL_PBRK_OrderBy As String = " order by sDate "

    Public Const SQL_PBRK_SetListById As String = "select p.*,G.Date_PeiBu,G.State as GH_State from (select ZL,GH,CK_Date,L.State,Line,T.StoreNo,T.Machine from T40100_PBRK_Table T, T40101_PBRK_List L where T.ID=L.ID and  T.ID=@ID) P left join T30000_Produce_Gd G on P.GH=G.GH"
#End Region
    Public Const SQL_PBRK_GetStateByID As String = "select top 1 ID,State,State_User from T40100_PBRK_Table  where ID=@ID"
    Private Const SQL_PBRK_GET As String = "Select Remark,Remark2 from T10200_Remark  where Remark_Type=2"
    Private Const SQL_GetStoreQty As String = "Select Sum(Qty) as SumQty From T40520_PB_StoreNo  Where StoreNo=@StoreNo Group by StoreNo"

    Private Const PBRK_DB_NAME As String = "胚布入库单"



    ''' <summary>
    ''' 修改单号
    ''' </summary>
    ''' <param name="ID_Old"></param>
    ''' <param name="ID_New"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReName(ByVal ID_Old As String, ByVal ID_New As String) As MsgReturn
        Dim R As New MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID_New", ID_New)
        P.Add("ID_Old", ID_Old)
        If Val(SqlStrToOneStr("select COUNT(*) from T40100_PBRK_Table where ID=@ID_New", P).Msg) > 0 Then
            R.IsOk = False
            R.Msg = "修改失败,新单号[" & ID_New & "]已存在!"
            Return R
        Else
            R = RunSQL("update T40100_PBRK_Table set id=@ID_New where id=@ID_Old ; update T40521_PB_Detail set id=@ID_New where id=@ID_Old ; update T40520_PB_StoreNo set id=@ID_New where id=@ID_Old", P)
            If R.IsOk Then
                R.Msg = "修改成功!"
            End If
        End If
        Return R
    End Function


    ''' <summary>
    ''' 获取车牌号码和司机
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_Get_Driver() As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GET)
    End Function

    ''' <summary>
    ''' 获取对胚布入库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetPBRKByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对胚布入库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetListById_Audit(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetPBRKListByid_Audit, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对胚布入库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_GetPBRKListByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对胚布入库仓位信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetStoreNoById_AddNew(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_SelStoreNobyID, "@ID", sId)
    End Function


    ''' <summary>
    ''' 获取对胚布入库仓位信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetStoreNoById_Audited(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBRK_SelStoreNobyID_Audite, "@ID", sId)
    End Function





    ''' <summary>
    ''' 获取胚布入库单 连接到缸号的明细信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_SetListById(ByVal sId As String) As DtReturnMsg
        Dim R As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_PBRK_SetListById, "@ID", sId)
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
    '''' 获取所有胚布入库单
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function PBRK_GetByOption(ByVal oList As List(Of BaseClass.FindOption)) As DtReturnMsg
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    Dim sql As String = SQL_PBRK_Get & BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMap) & SQL_PBRK_OrderBy
    '    Return PClass.PClass.SqlStrToDt(SQL_PBRK_Get)
    'End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "胚布入库单号"
        fo.DB_Field = "P.ID"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "纱批"
        fo.DB_Field = "ShaPi"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "织厂"
        fo.DB_Field = "Z.ZhiChang_Name"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "机台"
        fo.DB_Field = "Machine"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "仓位"
        fo.DB_Field = "CangWei"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "车牌"
        fo.DB_Field = "License"
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
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_PBRK_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_PBRK_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    Public Shared Function PBRK_CheckID(ByVal PBRK_ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_PBRK_CheckID, "@ID", PBRK_ID)
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
    Public Shared Function PBRK_GetNewId(ByVal D As Date) As RetrunNewIdMsg
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
                R.RetrunMsg = "获取" & PBRK_DB_NAME & "单号成功!"
            End If
            Dim paraMap As New Dictionary(Of String, Object)
            paraMap.Add("@DB_Str", "T40100_PBRK_Table")
            paraMap.Add("@Id_Str", "PBRK")
            paraMap.Add("@Field", "ID")
            paraMap.Add("@Zero", "3")
            paraMap.Add("@Date", D.ToString("yyyy-MM-dd"))
            Dim MR As MsgReturn = SqlStrToOneStr("GetTableID_NoSave_Date", paraMap, True)
            If MR.IsOk Then
                R.NewID = MR.Msg
                R.IsOk = True
            Else
                R.RetrunMsg = "获取" & PBRK_DB_NAME & "单号失败!"
                R.IsOk = False
            End If
            Return R
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.RetrunMsg = "获取" & PBRK_DB_NAME & "单号失败!" & ex.Message
            Return R
        End Try
    End Function






    ''' <summary>
    ''' 胚布入库单添加
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable, ByVal dtStore As DataTable, Optional ByVal Supplier_Name_New As String = "") As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Bill_ID As String = dtTable.Rows(0)("ID")
        paraMap.Add("ID", Bill_ID)
        sqlMap.Add("Table", SQL_PBRK_SelByid)
        sqlMap.Add("List", SQL_PBRK_SelListByid)
        sqlMap.Add("Store", SQL_Store_ByID)
        Try
            Using DTH As New DtHelper(sqlMap, paraMap)
                If DTH.IsOk = False Then
                    Throw New Exception(DTH.Msg)
                Else
                    If DTH.DtList("Table").Rows.Count = 0 Then
                        DvToDt(dtTable, DTH.DtList("Table"), New List(Of String), True)
                        DvToDt(dtList, DTH.DtList("List"), New List(Of String), True)
                        DvToDt(dtStore, DTH.DtList("Store"), New List(Of String), True)
                        Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values(@ID," & BillType.PBRK & ")"
                        R = DTH.UpdateAll(True, TmSQL, "ID", Bill_ID)
                        If R.IsOk Then R.Msg = PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                    Else
                        R.IsOk = False
                        R.Msg = PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "[已经存在!,请双击编号文本框,获取新编号!"
                    End If
                End If
            End Using
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        End Try
    End Function

    ''' <summary>
    ''' 胚布入库单修改
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable, ByVal dtStore As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Bill_ID As String = dtTable.Rows(0)("ID")
        paraMap.Add("ID", Bill_ID)
        sqlMap.Add("Table", SQL_PBRK_SelByid)
        sqlMap.Add("List", SQL_PBRK_SelListByid)
        sqlMap.Add("Store", SQL_Store_ByID)
        Try
            Using DTH As New DtHelper(sqlMap, paraMap)
                If DTH.IsOk = False Then
                    Throw New Exception(DTH.Msg)
                Else
                    If DTH.DtList("Table").Rows.Count = 1 Then
                        If DTH.DtList("Table").Rows(0)("State") <> Enum_PBRK.New_PBRK Then
                            R.IsOk = False
                            R.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                            Return R
                        End If
                        DvUpdateToDt(dtTable, DTH.DtList("Table"), New List(Of String))
                        DvToDt(dtList, DTH.DtList("List"), New List(Of String))
                        DvToDt(dtStore, DTH.DtList("Store"), New List(Of String))
                        R = DTH.UpdateAll()
                        If R.IsOk Then R.Msg = PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
                    Else
                        R.IsOk = False
                        R.Msg = PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]不存在"
                    End If
                End If
            End Using
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改错误!"
            DebugToLog(ex)
            Return R
        End Try


        ''Dim msg As New DtListReturnMsg
        ''Dim sqlMap As New Dictionary(Of String, String)
        ''Dim paraMap As New Dictionary(Of String, Object)
        ''Dim Bill_ID As String = dtTable.Rows(0)("ID")
        'paraMap.Add("ID", Bill_ID)
        'Try
        '    sqlMap.Add("Table", SQL_PBRK_SelByid)
        '    sqlMap.Add("List", SQL_PBRK_SelListByid)
        '    msg = SqlStrToDt(sqlMap, paraMap)
        '    If msg.DtList("Table").Rows.Count = 1 Then
        '        If msg.DtList("Table").Rows(0)("State") <> Enum_PBRK.New_PBRK Then
        '            msg.DaList("Table").Dispose()
        '            msg.DaList("List").Dispose()
        '            msg.Cnn.Dispose()
        '            msg.IsOk = False
        '            msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
        '        End If
        '        DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
        '        DvToDt(dtList, msg.DtList("List"), New List(Of String))
        '        DtToUpDate(msg)
        '        msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
        '        msg.IsOk = True
        '    Else
        '        msg.IsOk = False
        '        msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]不存在"
        '    End If
        '    Return msg
        'Catch ex As Exception
        '    msg.IsOk = False
        '    msg.Msg = "" & PBRK_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改错误"
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
    Public Shared Function PBRK_Del(ByVal Bill_ID As String)
        Return RunSQL(SQL_PBRK_DelPBRKByid, "@ID", Bill_ID)
    End Function

    ''' <summary>
    ''' 审核采购单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_Audit(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P40100_PBRK_Audited", paraMap, True)
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
    ''' 确认采购单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">确认还是反确认</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBRK_Comfirm(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P40100_PBRK_Audited", paraMap, True)
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
    Public Shared Function PBRK_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_BZSHState = Enum_BZSHState.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_BZSHState.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_PBRK_GetStateByID)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_BZSHState.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & PBRK_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & PBRK_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & PBRK_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & PBRK_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & PBRK_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function



#End Region

    Public Shared Function PBRK_GetDetail(ByVal ID As String) As DtReturnMsg
        Return SqlStrToDt("select * from T40521_PB_Detail where ID=@ID order by line", "ID", ID)
    End Function

    Public Shared Function PBRK_GetAllQty(ByVal ID As String) As MsgReturn
        Return SqlStrToOneStr("select top 1 AllQty from T40100_PBRK_Table where ID=@ID", "ID", ID)
    End Function

    Public Shared Function GetStoreQty(ByVal StoreNo As String) As Integer
        Dim MSG As DtReturnMsg = PClass.PClass.SqlStrToDt(SQL_GetStoreQty, "StoreNo", StoreNo)
        If MSG.IsOk AndAlso MSG.Dt.Rows.Count > 0 Then
            Return MSG.Dt.Rows(0)("SumQty")
        Else
            Return 0
        End If
    End Function






    Public Shared Function PBRK_GetZJ(ByVal ID As String) As MsgReturn
        Dim R As DtReturnMsg = SqlStrToDt("Select Top 1  ID from T40100_PBRK_Table where ID Like @ID order by ID Desc", "ID", ID & "%")
        PBRK_GetZJ = New MsgReturn
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Dim s As String = R.Dt.Rows(0)("ID").ToString.ToUpper
            If IsNumeric(s.Substring(s.Length - 1)) OrElse s.Substring(s.Length - 1) = "R" Then
                s = s & "B"
            Else
                s = s.Substring(0, s.Length - 1) & Chr(Asc(s.Substring(s.Length - 1)) + 1)
            End If
            PBRK_GetZJ.IsOk = True
            PBRK_GetZJ.Msg = s
        Else
            PBRK_GetZJ.IsOk = False
            PBRK_GetZJ.Msg = "入库单号[" & ID & "]不存在!"
        End If
    End Function

    Public Shared Function PBRK_ReSum(ByVal ID As String) As MsgReturn
        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("declare @Store varchar(20)")
        sqlBuider.AppendLine("declare @LastID varchar(20)")
        sqlBuider.AppendLine("declare @sID varchar(20)")
        sqlBuider.AppendLine("declare @MsgTmp varchar(200)")
        sqlBuider.AppendLine("declare @GH varchar(20)")
        sqlBuider.AppendLine("set @LastID=''")
        sqlBuider.AppendLine("set @MsgTmp=''")
        sqlBuider.AppendLine("declare my_cursor cursor for  ")
        sqlBuider.AppendLine("select distinct ID,StoreNo,GH from T40101_PBRK_List where id=@id ")
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
        Return RunSQL(sqlBuider.ToString(), "id", ID)
    End Function

    ''' <summary>
    ''' 按缸号获取客户同布种
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function BZ_GetByGH(ByVal GH As String) As DtReturnMsg

        Return PClass.PClass.SqlStrToDt(SQL_GET_BZ_BYGH, "@GH", GH)
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

