Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F50013_IniTouch_Msg
    Dim LId As String = ""
    Dim Bill_ID_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim StoreDt As DataTable
    Dim State As Enum_State = Enum_State.AddNew
    Dim IsBidings As Boolean = False
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

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        If FG1.Rows.Count > 1 Then
            FG1.RowSel = 1
            FG1.Row = 1

        End If

    End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.ActiveControl.Name <> TB_Remark.Name AndAlso Me.ActiveControl.Name <> FG1.Name AndAlso ActiveControl.Parent.Name <> FG1.Name Then
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
        ID = 50200
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Price)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)


    End Sub



    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.IniTouch, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Dao.ProcessiTouch_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        If Bill_ID = "" AndAlso P_F_RS_ID2 <> "" Then
            Bill_ID = P_F_RS_ID
        End If
        FG1.Cols("SGGY_No").Editor = CB_SG_FG
        FG1.Cols("BZC_No").Editor = CB_BZC_FG
        ' FG1.Cols("SGGY_GSD").Editor = CB_Sort
        ' CB_Sort.DataSource = Dao.ProcessiTouch_GetSort.Dt
        ''业务员
        'Employee_List1.Set_TextBox(TB_Operator, TB_Upd_User)
        'TB_Operator.Tag = "0"

        FG1.IniFormat()
        If Me.Mode = Mode_Enum.Modify AndAlso P_F_RS_ID <> "" Then
            Me.Bill_ID = P_F_RS_ID
        End If
        Me_Refresh()


        isLoaded = True



    End Sub

    Sub CopyMe()

        LId = ""
        TB_ID.Text = ""
        Mode = Mode_Enum.Add
        If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
        TB_Upd_User.Text = User_Display
        LabelTitle.Text = "新建" & Me.Ch_Name
        ToolSPreview.Enabled = False
        ToolSPrint.Enabled = False
        dtTable.Rows(0)("State") = Enum_State.AddNew
        SetForm(dtTable)
        GetNewID()
        Cmd_Copy.Visible = False

    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.ProcessiTouch_GetById(Bill_ID)
        If msgTable.IsOk Then

            dtTable = msgTable.Dt
        End If

        If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
            ShowErrMsg("没有找到" & Ch_Name & "[" & Bill_ID & "]", True)
            Exit Sub
        End If
        SetForm(dtTable)

        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
                Dim msg As DtReturnMsg = Dao.ProcessiTouch_SelListById_All(0)
                If msg.IsOk Then dtList = msg.Dt
                FG1.Rows.Count = 1
                FG1.ReAddIndex()
                TB_Upd_User.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                ToolSPreview.Enabled = False
                ToolSPrint.Enabled = False

                GetNewID()
            Case Mode_Enum.Modify
                CB_Client.Enabled = False
                Dim msg As DtReturnMsg = Dao.ProcessiTouch_SelListById_All(Bill_ID)
                ToolSPreview.Enabled = True
                ToolSPrint.Enabled = True
                If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                    dtList = msg.Dt
                    LastLine = msg.Dt.Rows(0)("Line")

                    FG1.DtToSetFG(msg.Dt)
                Else
                    FG1.Rows.Count = 1
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select


        CB_ShowComfirm.SelectedIndex = 0
        CaculateSumAmount()
        '  dtTable.AcceptChanges()
        ' dtList.AcceptChanges()
        SetFg1Show()
    End Sub

    Private Sub SetFg1Show()
        Select Case CB_ShowComfirm.SelectedIndex

            Case 0
                Cmd_Modify.Enabled = True
                Cmd_Price.Enabled = True
                Cmd_AddRow.Enabled = True
                Cmd_RemoveRow.Enabled = True

                FG1.CanEditing = True
                FG1.Cols("IsLastPrice").Visible = False
                FG1.Cols("Price_Time").Visible = False
                For i As Integer = 1 To FG1.Rows.Count - 1
                    If FG1.Item(i, "IsComfirm") = False AndAlso FG1.Item(i, "IsLastPrice") = True Then
                        If dtList.Select("SG_ID=" & FG1.Item(i, "SG_ID") & " and IsComfirm=1").Length = 0 Then
                            FG1.Rows(i).Visible = True
                        Else
                            FG1.Rows(i).Visible = False
                        End If

                    Else
                        FG1.Rows(i).Visible = False
                    End If
                Next
            Case 1
                Cmd_Modify.Enabled = True
                Cmd_Price.Enabled = False
                Cmd_AddRow.Enabled = False
                Cmd_RemoveRow.Enabled = True

                FG1.CanEditing = False
                FG1.Cols("Price_Time").Visible = False
                FG1.Cols("IsLastPrice").Visible = False
                For i As Integer = 1 To FG1.Rows.Count - 1
                    If FG1.Item(i, "IsComfirm") = True Then
                        FG1.Rows(i).Visible = True
                    Else
                        FG1.Rows(i).Visible = False
                    End If
                Next
            Case 2
                FG1.Cols("Price_Time").Visible = True
                FG1.Cols("IsLastPrice").Visible = True
                For i As Integer = 1 To FG1.Rows.Count - 1
                    FG1.Rows(i).Visible = True

                Next
                Cmd_Modify.Enabled = True
                Cmd_Price.Enabled = False
                Cmd_AddRow.Enabled = False
                Cmd_RemoveRow.Enabled = False

                FG1.CanEditing = False
        End Select
        CaculateSumAmount()
    End Sub


#Region "表单控件事件"

#End Region

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm(Optional ByVal isPrice As Boolean = False) As DataTable
        Dim dt As DataTable
        Dim ID As String = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt = dtTable
        Dim dr As DataRow = dt.Rows(0)
        Dim serverTiume As Date = GetTime()
        If Mode = Mode_Enum.Add Then

            dr("Founder") = PClass.PClass.User_Name

        End If
        dr("Upd_User") = PClass.PClass.User_Name
        dr("Upd_Date") = serverTiume
        dr("ID") = TB_ID.Text
        dr("sDate") = DTP_sDate.Value.Date
        dr("Client_ID") = Val(CB_Client.IDValue)

        dr("State") = 0
        dr("State_User") = PClass.PClass.User_Name
        dr("Remark") = TB_Remark.Text
        dr("SumComfirm") = TB_Qty_Comfirm.Text
        dr("SumUnComfirm") = TB_Qty_UnComfirm.Text
        Dim _dtList As DataTable = dtList.Clone
        Dim bzcID As Integer = 0
        Dim sgID As Long = 0
        For i As Integer = 1 To FG1.Rows.Count - 1
            'bzcID = Val(FG1.Item(i, FG1.Cols("BZC_ID").Index))
            sgID = FG1.Item(i, FG1.Cols("SG_ID").Index)
            If Val(sgID) = 0 Then
                Continue For
            End If
            ''如果是报价，且该行未客户确定的，且该行为最后一次报价，新增一行，否则修改该行
            'Dim drs As DataRow() = dtList.Select("BZC_ID=" & bzcID & " and BZ_ID =" & bzID)
            'If Mode = Mode_Enum.Add OrElse (Mode = Mode_Enum.Modify And isPrice _
            '             AndAlso FG1.Item(i, FG1.Cols("IsComfirm").Index) = False AndAlso FG1.Item(i, FG1.Cols("IsLastPrice").Index) = True) Then
            '    dr = dtList.NewRow
            '    dr("Price_Time") = serverTiume
            '    '把最新的行设置为最后报价，其他的非最后报价

            '    'For Each d As DataRow In drs
            '    '    d("IsLastPrice") = False
            '    'Next
            '    'dr("IsLastPrice") = True
            '    dtList.Rows.Add(dr)
            'Else
            '    If drs.Length = 0 Then
            '        dr = dtList.NewRow
            '        '   dr("Price_Time") = GetTime()
            '        dtList.Rows.Add(dr)
            '    Else
            '        Try
            '            dr = dtList.Select(FG1.Item(FG1.RowSel, "Line"))(0)
            '        Catch ex As Exception
            '            dr = dtList.NewRow
            '            '   dr("Price_Time") = GetTime()
            '            dtList.Rows.Add(dr)
            '        End Try

            '        '如果客户确认被修改时，自动修改最后报价的值为true,其他为false
            '        'If dr("IsComfirm") <> FG1.Item(i, FG1.Cols("IsComfirm").Index) Then
            '        '    For Each d As DataRow In drs
            '        '        d("IsLastPrice") = False
            '        '    Next
            '        'End If
            '    End If

            'End If
            dr = _dtList.NewRow

            '将当前显示的设为最后报价
            'If FG1.Rows(FG1.RowSel).Visible = True Then
            '    'For Each d As DataRow In drs
            '    '    d("IsLastPrice") = False
            '    'Next
            '    dr("IsLastPrice") = True
            'Else
            '    dr("Price_Time") = serverTiume
            '    dr("IsLastPrice") = False
            'End If
            dr("ID") = TB_ID.Text

            dr("SG_ID") = sgID
            dr("IsComfirm") = IIf(FG1.Item(i, "IsComfirm") Is Nothing, False, FG1.Item(i, "IsComfirm"))
            'If FG1.Item(i, FG1.Cols("IsComfirm").Index) AndAlso dr("Price_Time") Is DBNull.Value Then
            '    dr("Price_Time") = serverTiume
            'End If
            dr("Price") = Val(FG1.Item(i, FG1.Cols("Price").Index))
            'dr("Ds_Ding") = FG1.Item(i, FG1.Cols("Ds_Ding").Index)
            'dr("Ds_Ran") = FG1.Item(i, FG1.Cols("Ds_Ran").Index)
            '  dr("PB_Cost") = Val(FG1.Item(i, FG1.Cols("PB_Cost").Index))
            dr("Cost") = Val(FG1.Item(i, FG1.Cols("Cost").Index))
            dr("LRemark") = FG1.Item(i, "LRemark")
            dr("ProcessSort") = FG1.Item(i, "SGGY_GSD")
            If Mode = Mode_Enum.Add Then
                dr("IsLastPrice") = True
                dr("Price_Time") = serverTiume
            ElseIf Mode = Mode_Enum.Modify Then
                If FG1.Rows(i).Visible = True Then
                    If isPrice Then
                        '如果修改状态，点击报价，将当前（显示）的行新增，并且保存旧的行为历史记录
                        Try
                            Dim sDr As DataRow = dtList.Select("Line =" & FG1.Item(FG1.RowSel, "Line"))(0)
                            '如果单价改变，则保存旧的记录，并新增
                            If sDr("Price") <> dr("Price") Then
                                Dim oldRow As DataRow = _dtList.NewRow
                                CopyDataRow(sDr, oldRow)
                                oldRow("IsLastPrice") = False
                                _dtList.Rows.Add(oldRow)
                            End If

                        Catch ex As Exception

                        End Try

                    End If
                    '把当前显示的行设为最后报价
                    dr("IsLastPrice") = True
                    dr("Price_Time") = serverTiume
                Else

                    dr("IsLastPrice") = FG1.Item(i, FG1.Cols("IsLastPrice").Index)
                    dr("Price_Time") = FG1.Item(i, FG1.Cols("Price_Time").Index)
                End If


            End If
            _dtList.Rows.Add(dr)
        Next

        _dtList.AcceptChanges()
        dtList = _dtList
        Return dt
    End Function

    Private Sub CopyDataRow(ByVal dr As DataRow, ByVal newDr As DataRow)


        For Each col As DataColumn In dtList.Columns
            newDr(col.ColumnName) = dr(col.ColumnName)
        Next

    End Sub

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If

        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow
            ' Dr("UnPayed") = 0
            Dr("State_User") = ""
            ' Dr("ClientBill") = ""
            'Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            ' Dr("Sum_Amount") = 0
            '   Dr("Payed") = Dr("SumAmount") - Dr("UnPayed")

            Cmd_Audit.Visible = False
            Cmd_UnAudit.Visible = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False

            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            Cmd_Copy.Visible = False
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Cmd_Copy.Visible = False
            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_UnAudit.Visible = False


                    Cmd_AddRow.Enabled = True
                    Cmd_Del.Enabled = Cmd_Del.Tag
                    Cmd_RemoveRow.Enabled = True

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Enabled = True

                    Cmd_Modify.Visible = Cmd_Modify.Tag
                    Cmd_Price.Visible = Cmd_Price.Tag
                    Cmd_AddRow.Visible = True
                    Cmd_RemoveRow.Visible = True
                    CB_Client.Enabled = True

                    LockForm(False)
                Case Enum_State.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False

                    Cmd_Audit.Visible = False
                    Cmd_UnAudit.Visible = False


                    Cmd_AddRow.Enabled = False

                    Cmd_Del.Enabled = True
                    Cmd_RemoveRow.Enabled = False

                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False

                    Cmd_Modify.Visible = False
                    Cmd_Price.Visible = False
                    Cmd_AddRow.Visible = False
                    Cmd_RemoveRow.Visible = False
                    CB_Client.Enabled = False
                    LockForm(True)
                Case Enum_State.Audited '审核
                    TB_ID.ReadOnly = True

                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue


                    Cmd_RemoveRow.Enabled = False
                    Cmd_AddRow.Enabled = False
                    Cmd_Del.Enabled = False

                    Cmd_Audit.Visible = False

                    Cmd_UnAudit.Visible = Cmd_UnAudit.Tag
                    Cmd_UnAudit.Enabled = True

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False


                    Cmd_Modify.Visible = False
                    Cmd_Price.Visible = False
                    Cmd_AddRow.Visible = False
                    Cmd_RemoveRow.Visible = False
                    CB_Client.Enabled = False
                    LockForm(True)
            End Select
        End If
        If Mode = Mode_Enum.Modify Then
            TB_ID.Text = Dr("ID")
            DTP_sDate.Value = Dr("sDate")
            CB_Client.IDValue = Dr("Client_ID")
            CB_Client.Text = Dr("Client_No")
            TB_Client_Name.Text = Dr("Client_Name")

            TB_Upd_User.Text = IsNull(Dr("Upd_User"), "")
            TB_State_User.Text = IsNull(Dr("State_User"), "")
            TB_Remark.Text = IsNull(Dr("Remark"), "")
        End If


    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        'TB_BZ_ZL.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock

        '   TB_BZ_Qty.ReadOnly = Lock
        DTP_sDate.Enabled = False
        FG1.CanEditing = Not Lock
        FG1.IsClickStartEdit = Not Lock
        '    TB_Operator.ReadOnly = Lock

        TB_Remark.ReadOnly = Lock

        'TB_BZC_Name.ReadOnly = Lock
    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        Dim sumComfirm As Integer = 0
        Dim sumUnComfirm As Integer = 0
        For i As Int16 = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "IsComfirm") = True Then
                sumComfirm += 1
            ElseIf FG1.Item(i, "IsLastPrice") = True Then
                sumUnComfirm += 1
            End If
        Next
        TB_Qty_Comfirm.Text = sumComfirm
        TB_Qty_UnComfirm.Text = sumUnComfirm


    End Sub

    '''' <summary>
    ''''计算预计成本
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub CaculatCost()
    '    Dim _BZcID As Integer = Val(FG1.Item(FG1.RowSel, "BZC_ID"))
    '    Dim _BZID As Integer = Val(FG1.Item(FG1.RowSel, "BZ_ID"))
    '    FG1.Item(FG1.RowSel, "Amount") = GetRBPFCost(_BZcID, _BZID) * 10 * Val(FG1.Item(FG1.RowSel, "BZ_ZL"))

    'End Sub


#End Region

#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        FG1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveProcess)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveProcess)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveProcess)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveProcess(Optional ByVal IsProcess As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm(IsProcess)
        '     Dt.Rows(0).Item("ProcessType") = Me.ProcessType
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.ProcessiTouch_Add(Dt, dtList)
        Else
            R = Dao.ProcessiTouch_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If IsProcess Then
                'Dim msg As MsgReturn = Dao.Process_Audited(TB_ID.Text, True)
                'If msg.IsOk Then
                '    Bill_ID = TB_ID.Text
                '    Mode = Mode_Enum.Modify
                '    Me_Refresh()
                '    ShowOk(msg.Msg)
                'Else
                '    ShowErrMsg("保存成功,但" & msg.Msg)
                'End If
                Print(OperatorType.Preview, False)
                Bill_ID = TB_ID.Text
                Me_Refresh()
                Exit Sub
            End If
            If TB_ID.Text = Bill_ID.Replace("-", "") Then
                Bill_ID = ""
            Else
                Bill_ID = TB_ID.Text
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
        CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If

        If Val(CB_Client.IDValue) = 0 Then
            ShowErrMsg(Ch_Name & "客户不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If

        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.Process_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If



        If FG1.Rows.Count <= 1 Then

            ShowErrMsg("列表不能为空!")
            Return False
        End If



        Me.Refresh()
        Return True
    End Function

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


#End Region


#Region "FG 事件"
    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.Click
        If FG1.CanEditing = False Then Exit Sub
        If FG1.ColSel = FG1.Cols("IsComfirm").Index Then
            Try
                FG1.Item(FG1.RowSel, "IsComfirm") = Not FG1.Item(FG1.RowSel, "IsComfirm")
            Catch ex As Exception
                FG1.Item(FG1.RowSel, "IsComfirm") = True
            End Try

        End If
    End Sub


#Region "SG选择"
    Dim IsBZSelect As Boolean
    Private Sub CB_SG_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_SG_FG.Col_Sel
   
        IsBZSelect = True
        FG1.Item(FG1.RowSel, "SGGY_Name") = Col_Name
        FG1.Item(FG1.RowSel, "SG_ID") = ID
        'FG1.Item(FG1.RowSel, "SGGY_GSD") = Col_Name
        FG1.Item(FG1.RowSel, "IsLastPrice") = True
        Dim SumCost As Double = 0

        Dim R As DtReturnMsg = Dao.SG_GetById(FG1.Item(FG1.RowSel, "SG_ID"))
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
        
            FG1.Item(FG1.RowSel, "SGGY_GSD") = R.Dt.Rows(0)("SGGY_GSD")
        Else
            ShowErrMsg("该手感没有杂色配方！")
        End If
        Dim msg As DtReturnMsg = Dao.Price_GetSGCost_ByID(FG1.Item(FG1.RowSel, "SG_ID"))
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            SumCost = IsNull(msg.Dt.Rows(0)("Cost"), 0)
            FG1.Item(FG1.RowSel, "Cost") = SumCost * 10
            FG1.Item(FG1.RowSel, "Price") = SumCost * 10.5
        Else
            ShowErrMsg("该手感没有杂色配方！")
        End If
        FG1.GotoNextCell("SGGY_No")
    End Sub
    Private Sub CB_SG_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_SG_FG.GetSearchEvent
        If CB_Client.IDAsInt <> 0 Then
            CB_SG_FG.SearchType = cSearchType.ENum_SearchType.Client
            CB_SG_FG.SearchID = CB_Client.IDAsInt
        Else
            CB_SG_FG.SearchType = cSearchType.ENum_SearchType.ALL
            CB_SG_FG.SearchID = CB_Client.IDAsInt
        End If

        CB_SG_FG.IDValue = FG1.Item(FG1.RowSel, "SG_ID")
    End Sub
    Sub FG_BZ_No()
        FG1.StartEditing(FG1.RowSel, FG1.Cols("BZ_No").Index)
    End Sub

#End Region

#Region "BZC选择"

    Dim IsBZCSelect As Boolean
    Private Sub CB_BZC_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZC_FG.Col_Sel
        IsBZCSelect = True

        FG1.Item(FG1.RowSel, "BZC_Name") = Col_Name
        FG1.Item(FG1.RowSel, "BZC_ID") = ID
        FG1.GotoNextCell("BZC_No")
    End Sub
    Private Sub CB_BZC_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_BZC_FG.GetSearchEvent
        CB_BZC_FG.IDValue = FG1.Item(FG1.RowSel, "BZC_ID")
        If CB_Client.IDAsInt <> 0 Then
            CB_SG_FG.SearchType = cSearchType.ENum_SearchType.Client
            CB_SG_FG.SearchID = CB_Client.IDAsInt
        Else
            CB_SG_FG.SearchType = cSearchType.ENum_SearchType.ALL
            CB_SG_FG.SearchID = CB_Client.IDAsInt
        End If
    End Sub
    Sub FG_BZC_No()
        FG1.StartEditing(FG1.RowSel, FG1.Cols("BZC_No").Index)
    End Sub

#End Region

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FG1.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If

        '     FG1.GotoNextCell(e.Col)
        Select Case FG1.Cols(e.Col).Name
            Case "IsComfirm"
            Case FG1.Cols("SGGY_No").Index
                If FG1.LastKey = Keys.Enter Then
                    CB_SG_FG.Col_SelOne()
                    If FG1.Item(e.Row, "BZ_Name") = "" Then
                        ShowErrMsg("请输入一个布种编号!", AddressOf FG_BZ_No)
                    End If
                Else
                    '非正当离开时候清空
                    If FG1.LastText <> IsNull(FG1.Item(e.Row, "BZ_No"), "") AndAlso IsBZSelect = False Then FG1.Item(e.Row, "BZ_Name") = ""
                    IsBZSelect = False
                End If
            Case FG1.Cols("BZC_No").Index
                If FG1.LastKey = Keys.Enter Then
                    CB_BZC_FG.Col_SelOne()
                    If FG1.Item(e.Row, "BZC_Name") = "" Then
                        ShowErrMsg("请输入一个色号!", AddressOf FG_BZC_No)
                    End If
                Else
                    '非正当离开时候清空
                    If FG1.LastText <> IsNull(FG1.Item(e.Row, "BZC_No"), "") AndAlso IsBZCSelect = False Then FG1.Item(e.Row, "BZC_Name") = ""
                    IsBZCSelect = False
                End If
                'Case "Ds_Ran"
                '    If FG1.LastKey = Keys.Enter Then FG1.GotoNextCell(FG1.Cols("Ds_Ran").Index)
                '     FG1.StartEditing(FG1.RowSel, FG1.Cols("Ds_Ding").Index)
            Case "SGGY_GSD"
                If FG1.LastKey = Keys.Enter Then FG1.GotoNextCell(e.Col)

            Case "Price"
                If FG1.LastKey = Keys.Enter Then FG1.GotoNextCell(e.Col)
                '   Case Else
                '  FG1.GotoNextCell(e.Col)
        End Select
        If FG1.LastKey = Keys.Enter Then
            FG1.LastKey = 0



        End If
    End Sub

    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        AddRow()
    End Sub


    Protected Sub AddRow()
        FG1.AddRow()
        FG1.Item(FG1.Rows.Count - 1, "IsComfirm") = False
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        If FG1.RowSel < 1 Then
            Exit Sub
        End If
        If FG1.Item(FG1.RowSel, "IsComfirm") Then
            FG1.Item(FG1.RowSel, "IsComfirm") = False
            SetFg1Show()
        Else
            FG1.RemoveRow()
        End If

    End Sub
    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles FG1.NextCell
        Select Case e.Col
            Case "SGGY_No"
                e.ToCol = FG1.Cols("Price").Index


            Case "SGGY_GSD"
                e.ToCol = FG1.Cols("Price").Index
            Case "Price"

                If e.Row + 2 > FG1.Rows.Count Then
                    FG1.Cols("SGGY_No").AllowEditing = False
                    AddRow()
                    FG1.Cols("SGGY_No").AllowEditing = True
                End If
                e.ToRow = e.Row + 1
                e.ToCol = FG1.Cols("SGGY_No").Index
            Case Else
                '   If FG1.Cols("Price").AllowEditing Then
                'e.ToCol = FG1.Cols("Price").Index
                '   Else
                '   e.ToCol = FG1.Cols("sPercent").Index
                '    End If
        End Select
    End Sub







#End Region



#Region "获取新单号"
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If TB_ID.ReadOnly OrElse TB_ID.Enabled = False Then
            ShowErrMsg("非新增状态不能修改单号!")
        Else
            ShowConfirm("是否获取新单号?", AddressOf ReGetNewID)
        End If
    End Sub

    Sub ReGetNewID()
        If TB_ID.Text <> LId OrElse LId = "" Then
            ComFun.DelBillNewID(BillType.IniTouch, Bill_ID)
            Bill_ID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.ProcessiTouch_DB_NAME = Ch_Name
        If TB_ID.ReadOnly = False Then
            '  If DTP_sDate.Value <> Bill_ID_Date Then
            Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.IniTouch, DTP_sDate.Value, Bill_ID)
            If R.IsOk Then
                Bill_ID_Date = R.NewIdDate
                DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                DTP_sDate.Value = R.NewIdDate
                Bill_ID = R.NewID
                TB_ID.Text = Bill_ID.Replace("-", "")
                If R.IsTheDate = False Then
                    ShowErrMsg(R.RetrunMsg)
                End If
            Else
                ShowErrMsg(R.RetrunMsg)
            End If
            'End If
        End If
    End Sub

    Private Sub DTP_sDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_sDate.Validated
        GetNewID()
    End Sub

#End Region

#Region "报表事件"

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Preview, False)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Print, False)
    End Sub
    Private Sub Cmd_Preview_Un_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Preview, True)
    End Sub

    Private Sub Cmd_Print_Un_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Print(OperatorType.Print, True)
    End Sub





    Protected Sub Print(ByVal DoOperator As OperatorType, ByVal UComfirm As Boolean)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If

        Dim R As New R50012_ProcessiTouch
        R.StartList(TB_ID.Text, DoOperator, UComfirm)
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
        FG1.FinishEditing(False)
        'If CheckForm() Then
        '    If Mode = Mode_Enum.Add Then
        '        ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Price)
        '    Else
        '        If CheckIsModify() Then
        '            ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改并且审核?", AddressOf Price)
        '        Else
        '            ShowConfirm("是否保存并审核" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Price)
        '        End If
        '    End If
        'End If
        Dim msg As MsgReturn = Dao.ProcessiTouch_Audited(TB_ID.Text, True)
        If msg.IsOk Then
            LastForm.ReturnId = Me.TB_ID.Text
            Bill_ID = TB_ID.Text
            Mode = Mode_Enum.Modify
            Me_Refresh()
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub
    Protected Sub Shenhe()
        SaveProcess(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dao.Price_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProcessiTouch_Audited(TB_ID.Text, False)
        If msg.IsOk Then
            ShowOk(msg.Msg)
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelProcess)
    End Sub

    ''' <summary>
    ''' 删除出库单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelProcess()
        Dao.Price_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProcessiTouch_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ProcessInValid)
    End Sub


    Sub ProcessInValid()
        Dao.Price_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProcessiTouch_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ProcessValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub ProcessValid()
        Dao.Price_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProcessiTouch_InValid(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


#End Region

#Region "检查其他人有没有修改过"
    Private LastLine As Integer = 0
    Private Function CheckIsModify() As Boolean
        If Mode <> Mode_Enum.Add Then
            Return Dao.Price_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

    Private Sub Cmd_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Copy.Click
        CopyMe()
    End Sub



#Region "根据手感获取染部配方"
    Private Function GetRBPFCost(ByVal _SGID As Long) As Double
        'For i As Int16 = 1 To FG1.Rows.Count - 1
        '    If _SGID = Val(FG1.Item(i, "BZC_ID")) AndAlso _BZID = Val(FG1.Item(i, "BZ_ID")) Then
        '        ShowErrMsg("列表中已经存在相同的项：色号【" & FG1.Item(i, "BZC_Name") & "】,布类【" & FG1.Item(i, "BZ_Name") & "】")
        '        FG1.Item(FG1.RowSel, "BZ_ID") = 0
        '        FG1.Item(FG1.RowSel, "BZ_No") = ""
        '        FG1.Item(FG1.RowSel, "BZ_Name") = ""
        '        FG1.GotoNextCell("BZC_No")
        '        Timer1.Interval = 500
        '        FG1.CanEditing = False
        '        Timer1.Enabled = True


        '        Exit For
        '    End If
        'Next


        Dim SumCost As Double = 0
        Dim msg As DtReturnMsg = Dao.Price_GetSGCost_ByID(_SGID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            SumCost = IsNull(msg.Dt.Rows(0)("Cost"), 0) * IsNull(msg.Dt.Rows(0)("Qty"), 0)
        End If

        Return SumCost
    End Function


    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        FG1.Item(FG1.RowSel, "BZ_ID") = 0
        FG1.Item(FG1.RowSel, "BZ_No") = ""
        FG1.Item(FG1.RowSel, "BZ_Name") = ""
        FG1.CanEditing = True
        FG1.GotoNextCell("BZC_No")
        Timer1.Enabled = False
    End Sub

#End Region

#Region "显示内容"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CB_ShowComfirm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ShowComfirm.SelectedIndexChanged
        If isLoaded Then
            SetFg1Show()


        End If

    End Sub
#End Region

#Region "报价"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Price_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Price.Click
        FG1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并打印新" & Ch_Name & "?", AddressOf Price)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改并且报价?", AddressOf Price)
                Else
                    ShowConfirm("是否保存并打印" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Price)
                End If
            End If
        End If
    End Sub
    Protected Sub Price()
        SaveProcess(True)
    End Sub

#End Region

    Private Sub CB_Client_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel
        TB_Client_Name.Text = Col_Name
        CB_BZC_FG.SearchID = ID
        CB_BZC_FG.SearchType = cSearchType.ENum_SearchType.Client
        Dim R As DtReturnMsg = ComFun.Clinet_GetBy_ID(ID)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            TB_Client_Name.Tag = IsNull(R.Dt.Rows(0)("Client_FindHelper"), "BJ")
        End If
        GetNewID()
    End Sub

    Private Sub CB_Sort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Sort.SelectedIndexChanged
        ' FG1.Item(FG1.RowSel, "Price") = CB_Sort.SelectedValue
        Dim SumCost As Double = 0
        Dim msg As DtReturnMsg = Dao.Price_GetSGCost_ByID(FG1.Item(FG1.RowSel, "SG_ID"))
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            SumCost = IsNull(msg.Dt.Rows(0)("Cost"), 0) * IsNull(msg.Dt.Rows(0)("Qty"), 0)
            FG1.Item(FG1.RowSel, "Cost") = SumCost * 10
            FG1.Item(FG1.RowSel, "Price") = SumCost * 1.05
        Else
            ShowErrMsg("该手感没有杂色！")
        End If

    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InnerPrint("IsComfirm = 1 And  ", OperatorType.Preview)
    End Sub
    Protected Sub InnerPrint(ByVal Confirm As String, ByVal DoOperator As OperatorType)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If

        Dim R As New R50012_ProcessiTouch
        R.Start(TB_ID.Text, Confirm, DoOperator)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        InnerPrint("IsComfirm = 1 And  ", OperatorType.Print)
    End Sub

    Private Sub TMI_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Preview.Click
        Print(OperatorType.Preview, False)
    End Sub

    Private Sub TMI_Preview_Un_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Preview_Un.Click
        Print(OperatorType.Preview, True)
    End Sub

    Private Sub TMI_Preview_Inner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Preview_Inner.Click
        InnerPrint("IsComfirm = 1 And  ", OperatorType.Preview)
    End Sub

    Private Sub TMI_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Print.Click
        Print(OperatorType.Print, False)
    End Sub

    Private Sub TMI_Print_Un_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Print_Un.Click
        Print(OperatorType.Print, True)
    End Sub

    Private Sub TMI_Print_Inner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Print_Inner.Click
        InnerPrint("IsComfirm = 1 And  ", OperatorType.Print)
    End Sub
End Class

Partial Friend Class Dao

    Private Const SQL_ProcessiTouch_GetSort As String = "Select ProcessSort,Price from T50020_ProcessSort "
    Public Shared Function ProcessiTouch_GetSort() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProcessiTouch_GetSort)
    End Function






#Region "常量"
    Protected Friend Shared ProcessiTouch_DB_NAME As String = "报价单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_DelByid As String = "Delete from T50012_SGPrice_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_GetByid As String = "select top 1 * from T50012_SGPrice_Table  where ID=@ID "

    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_GetByid_WithName As String = "select top 1 T. * ,C.Client_No,C.Client_Name from T50012_SGPrice_Table T Left join T10110_Client C on T.Client_ID=C.ID  where T.ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_SelByid As String = " select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name ,C.Client_Name ,C.Client_No" & _
                                                   " from T50012_SGPrice_Table S " & _
                                                    " left join T15001_Employee E on S.Operator=E.ID " & _
                                                    "left join T15000_Department W on S.Dept_No=W.Dept_No " & _
                                                    "left join T10110_Client C on S.Client_ID=C.ID " & _
                                                     "where S.ID=@ID "
    'select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T50010_ProcessPrice_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_GetStateByid As String = "select top 1 ID,State,State_User,Produce_ID from T50012_SGPrice_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_GetListByid As String = "select * from T50013_SGPrice_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_ProcessiTouch_SelListByid As String = " select L.*,SGGY_No,SGGY_Name,SGGY_GSD  " & _
                                                            "  from  T50013_SGPrice_List L   " & _
                                                            "   left join T10035_SGGY SG on L.SG_ID=SG.ID  " & _
                                                            " where L.ID=@ID  order by L.ID,L.Line  "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    ''' 
    Private Const SQL_ProcessiTouch_SelListByid_ShowComfirm As String = " select L.*,SGGY_No,SGGY_Name,WL.WL_Spec ,WL.WL_Name +'/'+WL.WL_No AS WL,YL.Qty     " & _
                                                          "  from  T50013_SGPrice_List L   left join T10035_SGGY SG on L.SG_ID=SG.ID  " & _
                                                          "  left join T10036_SGGYList YL ON YL.ID =SG .ID AND YL.Color ='杂色'  LEFT JOIN T10001_WL WL ON WL.ID =YL.WL_ID " & _
                                                          " where L.ID=@ID and L.IsComfirm=0 and IsLastPrice=1 order by L.ID ,L.Line "



    Private Const SQL_ProcessiTouch_SelListByid_ALL As String = " select L.*,SGGY_No,SGGY_Name,WL.WL_Spec ,WL.WL_Name +'/'+WL.WL_No AS WL ,YL.Qty    " & _
                                                          "  from  T50013_SGPrice_List L   left join T10035_SGGY SG on L.SG_ID=SG.ID  " & _
                                                          "  left join T10036_SGGYList YL ON YL.ID =SG .ID  AND YL.Color ='杂色'  LEFT JOIN T10001_WL WL ON WL.ID =YL.WL_ID " & _
                                                         " where L.ID=@ID and IsLastPrice=1 order by L.ID ,L.Line "







    'Private Const SQL_Process_SelListByid_ShowComfirm As String = " select L.*,BZC_No,BZC_Name,Client_Bzc,BZC_Name+'/'+CAST(BZC_No as Varchar(20))  as BZC, BZ_No,BZ_Name " & _
    '                                                        "  from  T50001_Process_List L left join T10003_BZC BZC on L.BZC_ID=BZC.ID  " & _
    '                                                        "   left join T10002_BZ BZ on L.BZ_ID=BZ.ID " & _
    '                                                        " where L.ID=@ID and L.IsComfirm=@IsComfirm and IsLastProcess=1 order by L.ID ,L.Line "


    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_CheckID As String = "select count(*) from T50012_SGPrice_Table  where ID=@ID"

    '''' <summary>
    '''' 获取加工单列表,用于显示
    '''' </summary>
    '''' <remarks></remarks>0

    '  Private Const SQL_Produce_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProcessiTouch_CheckIsModify As String = "select count(*) from T50013_SGPrice_List where ID=@ID and Line=@Line"






#End Region

#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对出库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProcessiTouch_GetByid_WithName, "@ID", sId)
    End Function


    ''' <summary>
    ''' 获取对出库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SG_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt("select * from T10035_SGGY where ID=@ID", "@ID", sId)
    End Function
    ''' <summary>
    ''' 获取对出库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_SelListById(ByVal sId As String, ByVal UnComfirm As Boolean) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", sId)

        If UnComfirm Then
            Return PClass.PClass.SqlStrToDt(SQL_ProcessiTouch_SelListByid_ShowComfirm, p)
        Else
            Return PClass.PClass.SqlStrToDt(SQL_ProcessiTouch_SelListByid_ALL, p)
        End If

    End Function


#End Region

#Region "添加修改删除"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_ProcessiTouch_CheckIsModify, P)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function


    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_ProcessiTouch_CheckID, "@ID", ID)
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
    ''' 添加出库单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProcessId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ProcessId)
        Try

            'If IsNull(dtTable.Rows(0)("Produce_ID"), "") <> "" Then
            '    Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", dtTable.Rows(0)("Produce_ID"))
            '    If Rx.IsOk = False Then
            '        R.IsOk = False
            '        R.Msg = Process_DB_NAME & "[" & ProcessId & "]添加失败!" & vbCrLf & Rx.Msg
            '        Return R
            '    End If
            'End If

            sqlMap.Add("Table", SQL_ProcessiTouch_GetByid)
            sqlMap.Add("List", SQL_ProcessiTouch_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & ProcessId & "'," & BillType.IniTouch & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & ProcessiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ProcessiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ProcessiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改出库单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProcessId As String = dtTable.Rows(0)("ID")
        If LID <> ProcessId AndAlso ProcessiTouch_CheckID(ProcessId) Then
            R.IsOk = False
            R.Msg = "" & ProcessiTouch_DB_NAME & "[" & ProcessId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)

        'If IsNull(dtTable.Rows(0)("Produce_ID"), "") <> "" Then
        '    Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", dtTable.Rows(0)("Produce_ID"))
        '    If Rx.IsOk = False Then
        '        R.IsOk = False
        '        R.Msg = Process_DB_NAME & "[" & ProcessId & "]添加失败!" & vbCrLf & Rx.Msg
        '        Return R
        '    End If
        'End If

        Try
            sqlMap.Add("Table", SQL_ProcessiTouch_GetByid)
            sqlMap.Add("List", SQL_ProcessiTouch_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then


                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & ProcessiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & ProcessiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & ProcessId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.IniTouch
                If LID <> ProcessId Then
                    DtToUpDate(msg, "Update T50012_SGPrice_Table set id='" & ProcessId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = ProcessId
                    R.Msg = "" & ProcessiTouch_DB_NAME & "[" & LID & "]已经修改为[" & ProcessId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & ProcessiTouch_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ProcessiTouch_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ProcessiTouch_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除出库单
    ''' </summary>
    ''' <param name="ProcessId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_Del(ByVal ProcessId As String)
        Return RunSQL(SQL_ProcessiTouch_DelByid, "@ID", ProcessId)
    End Function

    ''' <summary>
    ''' 作废出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("State", IIf(IsFei, -1, 0))
        paraMap.Add("State_User", User_Display)

        Dim R As MsgReturn = SqlStrToOneStr("Update T50012_SGPrice_Table set State=@State,State_User=@State_User where ID=@ID  ", paraMap)
        Dim s As String = IIf(IsFei, "作废", "还原")
        If R.IsOk Then
            R.Msg = ProcessiTouch_DB_NAME & s & "成功！"
        Else
            R.Msg = ProcessiTouch_DB_NAME & s & "失败！" & R.Msg

        End If
        Return R
    End Function

    ''' <summary>
    ''' 审核手感报价单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim R As MsgReturn
        Dim s As String = IIf(IsAudited, "审核", "反审核")
        Dim state As Integer = IIf(IsAudited, 1, 0)

        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)

        '判断状态
        Dim msg As DtReturnMsg = SqlStrToDt("select state from  T50012_SGPrice_Table where ID=@ID  ", "ID", _ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso IsNull(msg.Dt.Rows(0)("State"), False) = state Then
            R = New MsgReturn
            R.Msg = ProcessiTouch_DB_NAME & s & "失败！[" & _ID & "]已被" & s
            Return R
        End If

        R = SqlStrToOneStr("Update T50012_SGPrice_Table set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)

        If R.IsOk Then
            R.Msg = ProcessiTouch_DB_NAME & s & "成功！"
        Else
            R.Msg = ProcessiTouch_DB_NAME & s & "失败！" & R.Msg

        End If

        Return R
    End Function
#End Region
    ''' <summary>
    ''' 根据色号获取颜色布类
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_SelListById_All(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProcessiTouch_SelListByid, "@ID", sId)
    End Function

#Region "根据色号获取染部配方成本"
    ''' <summary>
    ''' 根据色号获取染部配方成本
    ''' </summary>
    ''' <param name="BZC_ID"></param>
    ''' <param name="BZ_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_GetPFCost_ByBZC(ByVal BZC_ID As Integer, ByVal BZ_ID As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZC_ID", BZC_ID)
        P.Add("BZ_ID", BZ_ID)
        Return SqlStrToDt(SQL_RBPF_PF_GeList_WithName, P)
    End Function
#End Region
End Class