Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F27131_AssembleOrder_Msg
    Dim LId As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim StoreDt As DataTable
    Dim State As Enum_State = Enum_State.AddNew
    Dim IsBidings As Boolean = False
    Dim StoreInType As Enum_StoreIn_Type

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_Id = initID
        Me.Mode = Mode
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        If Fg1.Rows.Count > 1 Then
            Fg1.RowSel = 1
            Fg1.Row = 1
            Fg1.Select(1, Fg1.Cols("WL_No").Index, 1, Fg1.Cols("WL_No").Index)
        End If
        TB_ID.Focus()
    End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name Then
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
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.AssembleOrder, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        If Bill_Id = "" AndAlso P_F_RS_ID <> "" Then
            Bill_Id = P_F_RS_ID
        End If

        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name & "列表"

        Fg1.IniFormat()
        Fg2.IniFormat()
        If Me.Mode = Mode_Enum.Modify AndAlso P_F_RS_ID <> "" Then
            Me.Bill_Id = P_F_RS_ID
        End If
        Me_Refresh()

    End Sub


    Private LastWL_No As String = ""
    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.AssembleOrder_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsSel Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If

            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Ch_Name & "[" & Bill_Id & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
                Dim msg As DtReturnMsg = Dao.AssembleOrder_SelListById(0)
                If msg.IsOk Then dtList = msg.Dt
                Fg1.Rows.Count = 2
                Fg1.ReAddIndex()
                TB_Upd_User.Text = User_Display
                DTP_sDate.Value = GetDate()

                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                GetNewID()

                If Me.P_F_RS_ID4 = "[ClientOrder]" Then
                    TB_ClientOrderID.Text = Me.F_RS_ID5
                    CB_Client_ID.IDAsInt = Val(Me.F_RS_ID3)
                    CB_Client_ID.Text = CB_Client_ID.GetByTextBoxTag(CB_Client_ID.IDAsInt)
                    TB_Client_Name.Text = CB_Client_ID.GetIDToDataRow(CB_Client_ID.IDAsInt)("Client_Name")
                    DTP_eDate.Value = Me.F_RS_ID2
                    DTP_eDate.Enabled = False
                    Fg1.DtToSetFG(DirectCast(Me.F_RS_Obj, DataTable))
                    LastWL_No = Fg1.Item(Fg1.RowSel, "WL_No")
                End If

            Case Mode_Enum.Modify
                Dim msg As DtReturnMsg = Dao.AssembleOrder_SelListById(Bill_ID)
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim dtList2 As DataTable
                If msg.IsOk Then
                    dtList = msg.Dt
                    dtList2 = msg.Dt
                    LastLine = msg.Dt.Rows(0)("Line")
                    LastWL_No = msg.Dt.Rows(0)("WL_No")
                    dtList2.AcceptChanges()
                    Fg1.DtToSetFG(dtList2)
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        'CaculateSumAmount()
        dtTable.AcceptChanges()
        dtList.AcceptChanges()
        SelRow(LastWL_No)
    End Sub

    'Sub GetDtMsg()
    '    StoreDt = ComFun.GetStoreDt()
    '    CB_Store.DataSource = StoreDt
    'End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        Dim ID As String = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt = dtTable
        Dim dr As DataRow = dt.Rows(0)
        dr("State") = State
        dr("ClientOrderID") = TB_ClientOrderID.Text
        dr("Client_ID") = CB_Client_ID.IDAsInt
        dr("Client_Name") = TB_Client_Name.Text
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID
            dr("WL_ID") = Fg1.Item(i, "WL_ID")
            dr("WL_Spec") = Fg1.Item(i, "WL_Spec")
            dr("Qty") = Val(Fg1.Item(i, "Qty"))
            dr("LRemark") = Fg1.Item(i, "LRemark")
            dr("isFinish") = IsNothing(Fg1.Item(i, "isFinish"), 0)
            dtList.Rows.Add(dr)
        Next
        dtList.AcceptChanges()
        Return dt
    End Function

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
            Dr("State_User") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("eDate") = ServerTime.Date
            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = True
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False
            DTP_eDate.Enabled = True

            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Cmd_Del.Visible = False
            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag
                    Cmd_Del.Enabled = True

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
                Case Enum_State.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False
                    Cmd_Del.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False

                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False
                    LockForm(True)
                Case Enum_State.Audited '审核
                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False
                    Cmd_Del.Enabled = False

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
        End If
        If IsBidings = False Then
            TB_ID.DataBindings.Add("Text", dtTable, TB_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            'CB_Client_No.DataBindings.Add("Text", dtTable, CB_Client_No.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            TB_Client_Name.DataBindings.Add("Text", dtTable, TB_Client_Name.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            DTP_eDate.DataBindings.Add("Value", dtTable, DTP_eDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            TB_Remark.DataBindings.Add("Text", dtTable, TB_Remark.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Upd_User.DataBindings.Add("Text", dtTable, TB_Upd_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            IsBidings = True
        End If

        CB_Client_ID.IDAsInt = IsNull(dtTable.Rows(0)("Client_ID"), 0)
        CB_Client_ID.Text = CB_Client_ID.GetByTextBoxTag(CB_Client_ID.IDAsInt)
        TB_ClientOrderID.Text = IsNull(dtTable.Rows(0)("ClientOrderID"), "")
        TB_Client_Name.Text = IsNull(dtTable.Rows(0)("Client_Name"), "")
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
        TB_Remark.ReadOnly = Lock
    End Sub


    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            TB_SumQty.Text = 0

            Exit Sub
        End If
        Dim SumQty As Double = 0
        Dim SumAmount As Double = 0
        For R As Integer = 1 To Fg1.Rows.Count - 1
            'Fg1.Item(R, "Amount") = Val(Fg1.Item(R, "Qty")) * Val(Fg1.Item(R, "Price"))
            'SumAmount = SumAmount + Val(Fg1.Item(R, "Amount"))
            SumQty = SumQty + Val(Fg1.Item(R, "Qty"))
        Next
        TB_SumQty.Text = FormatNum(SumQty)

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
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveAssembleOrder)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveAssembleOrder)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveAssembleOrder)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveAssembleOrder(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Audit Then
            Dt.Rows(0).Item("State_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.AssembleOrder_Add(Dt, dtList)
        Else
            R = Dao.AssembleOrder_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If Audit Then
                Dim msg As MsgReturn = Dao.AssembleOrder_Audited(TB_ID.Text, True)
                If msg.IsOk Then
                    Bill_ID = TB_ID.Text
                    Me_Refresh()
                    ShowOk(msg.Msg)
                Else
                    ShowErrMsg("保存成功,但" & msg.Msg)
                End If
                Exit Sub
            End If
            If TB_ID.Text = Bill_ID.Replace("-", "") Then Bill_ID = ""
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
        'CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.AssembleOrder_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If

        'For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
        '    Try
        '        If Fg1.Item(i, "IsAssemble") = False AndAlso Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
        '            Fg1.RemoveItem(i)
        '        End If
        '        If Val(Fg1.Item(i, "Qty")) < 0 Then
        '            Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
        '        End If
        '        'If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "Amount")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then

        '    Catch ex As Exception
        '    End Try
        'Next

        If Fg1.Rows.Count <= 1 Then
            Cmd_GoodsSel.Visible = False
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

    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
        ShowGoodsSelCmd()
    End Sub

    'Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click
    '    If Fg1.CanEditing = False Then Exit Sub
    '    If Fg1.Editor Is Nothing Then
    '        If Fg1.RowSel < 0 Then
    '            Exit Sub
    '        End If
    '        If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
    '            Fg1.LastKey = 0
    '            Fg1.StartEditing()
    '        End If
    '    End If
    'End Sub
    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Row <= 0 Then
            Exit Sub
        End If
        Try

            If Fg1.LastKey = Keys.Enter Then
                Fg1.LastKey = 0
                Select Case Fg1.Cols(e.Col).Name
                    Case "WL_No"
                        GetWLByNo(Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index))
                    Case "Qty"
                        Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))
                        Fg1.GotoNextCell("Qty")
                    Case Else
                        Fg1.GotoNextCell(e.Col)
                End Select
                'Else
                '    If Fg1.Cols(e.Col).Name = "WL_No" Then
                '        If Fg1.LastText <> Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index) Then
                '            Fg1.Item(Fg1.RowSel, "WL_ID") = 0
                '            Fg1.Item(Fg1.RowSel, "WL_Name") = ""
                '            Fg1.Item(Fg1.RowSel, "WL_Unit") = ""
                '            Fg1.Item(Fg1.RowSel, "WL_Spec") = ""
                '        End If
                '    Else
                '        Select Case Fg1.Cols(e.Col).Name

                '            Case "Price"
                '                '修改当前单价时，当修改后单价不等于成本价时，修改成本价
                '                Dim p As Double = Fg1.Item(Fg1.RowSel, "Price") / ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))
                '                If p <> Val(Fg1.Item(Fg1.RowSel, "Cost")) Then
                '                    Fg1.Item(Fg1.RowSel, "Cost") = p
                '                End If

                '                CaculateSumAmount()

                '            Case "WL_Unit_LL"
                '                '转换单位是，也转换单价
                '                Fg1.Item(Fg1.RowSel, "Price") = Val(Fg1.Item(Fg1.RowSel, "Cost")) * ComFun.Unit_Convert(Fg1.Item(Fg1.RowSel, "WL_Unit_LL"), Fg1.Item(Fg1.RowSel, "WL_Unit_LL2"))

                '        End Select
                'End If
            End If

        Catch ex As Exception

        End Try
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

    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow()
        Fg1.AddRow()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub
    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "WL_No"
                e.ToCol = Fg1.Cols("Qty").Index
            Case "Qty", "LRemark"
                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("WL_No").Index

            Case Else
                e.ToCol = Fg1.Cols("Qty").Index
        End Select
    End Sub



    Private Sub Fg1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Enter
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.EnterCell
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing = False Then
            If e.KeyCode = Keys.Enter Then
                If Fg1.ColSel < Fg1.Cols("Qty").Index Then
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Qty").Index)
                Else
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Remark").Index)
                End If
            ElseIf e.KeyCode = Keys.Add AndAlso Fg1.Cols(Fg1.ColSel).Name = "WL_No" Then
                ShowGoodsSel()
            End If
        End If
    End Sub

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles Fg1.KeyDownEdit
        If e.KeyCode = Keys.Add AndAlso Fg1.Cols("WL_No").Index = e.Col AndAlso Fg1.CanEditing Then
            ShowGoodsSel()
        End If
    End Sub


    Private Sub Fg1_SelectRowChange(Row As Integer) Handles Fg1.SelectRowChange
        SelRow(Fg1.Item(Fg1.RowSel, "WL_No"))
    End Sub


#End Region

#Region "物料选择"
    Dim gType As String = ""
    Protected Sub ShowGoodsSelCmd()
        If Fg1.ColSel > 0 AndAlso Fg1.RowSel > 0 Then
            If Fg1.CanEditing Then
                Dim C As C1.Win.C1FlexGrid.Column = Fg1.Cols(Fg1.ColSel)
                Dim R As C1.Win.C1FlexGrid.Row = Fg1.Rows(Fg1.RowSel)
                Select Case Fg1.Cols(Fg1.ColSel).Name
                    Case "WL_No"
                        Cmd_GoodsSel.Left = Fg1.Left + C.Left + C.WidthDisplay - Cmd_GoodsSel.Width + Fg1.ScrollPosition.X + 1
                        Cmd_GoodsSel.Top = Fg1.Top + R.Top + Fg1.ScrollPosition.Y + 1
                        Cmd_GoodsSel.Height = R.HeightDisplay
                        Cmd_GoodsSel.Visible = True
                    Case Else
                        Cmd_GoodsSel.Visible = False
                End Select
            Else
                Cmd_GoodsSel.Visible = False
            End If
        Else
            Cmd_GoodsSel.Visible = False
        End If
    End Sub

    Private Sub Cmd_GoodsSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GoodsSel.Click
        ShowGoodsSel()
    End Sub
    Protected Sub ShowGoodsSel(Optional ByVal _no As String = "")
        If _no Is Nothing Then _no = ""
        If _no = "" Then _no = Fg1.Item(Fg1.RowSel, "WL_No")
        Dim F As BaseForm = LoadFormIDToChild(10004, Me)
        If F Is Nothing Then Exit Sub
        Fg1.RowSel = Fg1.RowSel
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = _no
            .P_F_RS_ID4 = gType
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoods
        VF.Show()
    End Sub

    Protected Sub SetGoods()
        If Not Me.ReturnObj Is Nothing AndAlso Fg1.CanEditing AndAlso Fg1.RowSel > 0 Then
            Dim dr As DataRow = ReturnObj
            Dim IsAssemble As Boolean = dr("IsAssemble")
            Fg1.FinishEditing(True)
            If IsAssemble Then
                For i As Integer = 1 To Fg1.Rows.Count - 1
                    If CStr(dr("ID")) = Fg1.Item(i, "WL_ID") And Fg1.RowSel <> i Then
                        ShowErrMsg("物料[" & IsNull(dr("WL_Name"), "") & "]已经存在!", AddressOf Fg1.Focus)
                        Exit Sub
                    End If
                Next
                Dim dt_Assemble As DtReturnMsg = Dao.AO_Assemble_SelListById(IsNull(dr("WL_No"), ""))
                If dt_Assemble.IsOk AndAlso dt_Assemble.Dt.Rows.Count > 0 Then
                    Fg1.Item(Fg1.RowSel, "WL_ID") = IsNull(dr("ID"), "")
                    Fg1.Item(Fg1.RowSel, "WL_No") = IsNull(dr("WL_No"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Name") = IsNull(dr("WL_Name"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Spec") = IsNull(dr("WL_Spec"), "")
                    Fg1.Item(Fg1.RowSel, "WL_Unit") = IsNull(dr("WL_Unit"), "")
                    Fg1.GotoNextCell("WL_No")
                Else
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("WL_No").Index)
                End If
            Else
                Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("WL_No").Index)
            End If
        Else
            Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("WL_No").Index)
        End If
        Me.ReturnObj = Nothing
    End Sub

    Protected Sub GetWLByNo(ByVal _No As String)
        Dim msg As DtReturnMsg = ComFun.WL_GetByNo(_No)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
            Me.ReturnObj = msg.Dt.Rows(0)
            SetGoods()
        Else
            ShowGoodsSel(_No)
        End If

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
            ComFun.DelBillNewID(BillType.PurchaseReturn, Bill_Id)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.AssembleOrder_DB_NAME = Ch_Name
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.AssembleOrder, DTP_sDate.Value, Bill_ID)
                If R.IsOk Then
                    Bill_Id_Date = R.NewIdDate
                    DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                    DTP_sDate.Value = R.NewIdDate
                    Bill_Id = R.NewID
                    TB_ID.Text = Bill_Id.Replace("-", "")
                    If R.IsTheDate = False Then
                        ShowErrMsg(R.RetrunMsg)
                    End If
                Else
                    ShowErrMsg(R.RetrunMsg)
                End If
            End If
        End If
    End Sub

    Private Sub DTP_sDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_sDate.Validated
        GetNewID()
    End Sub

#End Region

#Region "报表事件"

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Dim R As New R27000_ClientOrder
        R.Start(TB_ID.Text, DoOperator)
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
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Shenhe)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改并且审核?", AddressOf Shenhe)
                Else
                    ShowConfirm("是否保存并审核" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Shenhe)
                End If
            End If
        End If
    End Sub
    Protected Sub Shenhe()
        SaveAssembleOrder(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dao.AssembleOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.AssembleOrder_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf AssembleOrder)
    End Sub

    ''' <summary>
    ''' 删除装配单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AssembleOrder()
        Dao.AssembleOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.AssembleOrder_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf AssembleOrderInValid)
    End Sub


    Sub AssembleOrderInValid()
        Dao.AssembleOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.AssembleOrder_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf AssembleOrderValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub AssembleOrderValid()
        Dao.AssembleOrder_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.AssembleOrder_InValid(TB_ID.Text, False)
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
            Return Dao.AssembleOrder_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

    ''' <summary>
    ''' 客户编号
    ''' </summary>
    ''' <param name="Col_No"></param>
    ''' <param name="Col_Name"></param>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    Private Sub CB_Client_No_Col_Sel(Col_No As String, Col_Name As String, ID As String) Handles CB_Client_ID.Col_Sel
        TB_Client_Name.Text = Col_Name
    End Sub


    ''' <summary>
    ''' 显示组装信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <remarks></remarks>
    Private Sub SelRow(ByVal WL_No As String)
        Try
            Dim msg As DtReturnMsg = Dao.Get_AssembleWL(WL_No)
            If msg.IsOk Then
                msg.Dt.Columns.Add("Amount", GetType(Decimal))
                For Each dr As DataRow In msg.Dt.Rows
                    dr("Amount") = Val(dr("Assemble_Amount")) * Val(Fg1.Item(Fg1.RowSel, "Qty"))
                Next
                msg.Dt.AcceptChanges()
                Fg2.DtToSetFG(msg.Dt)
            End If
        Catch ex As Exception
            Fg2.Rows.Count = 1
        End Try
    End Sub
End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Shared AssembleOrder_DB_NAME As String = "装配单"

    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_DelByid As String = "Delete from T27130_AssembleOrder_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_GetByid As String = "select top 1 * from T27130_AssembleOrder_Table  where ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_SelByid As String = "select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T20200_StoreIn_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_GetStateByid As String = "select top 1 ID,State,State_User from T27130_AssembleOrder_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_GetListByid As String = "select * from T27131_AssembleOrder_List  where ID=@ID "


    'Private Const SQL_ClientOrder_SelListByid As String = "select  L.*,WL_No,WL_Name,WL_Unit_LL from T27111_AssembleOrder_List L left join T10001_WL WL on WL.ID=L.WL_ID where L.ID=@ID"
    Private Const SQL_AssembleOrder_SelListByid As String = "select  L.*,WL_No,WL_Name,WL_Unit from T27131_AssembleOrder_List L left join T10001_WL WL on WL.ID=L.WL_ID  where L.ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_CheckID As String = "select count(*) from T27130_AssembleOrder_Table  where ID=@ID"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_CheckIsModify As String = "select count(*) from T20201_StoreIn_list  where ID=@ID and Line=@Line"



    ''' <summary>
    ''' 获取加工单列表,用于显示
    ''' </summary>
    ''' <remarks></remarks>0

    Private Const SQL_Assemble_Order_SelListById As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

    ''' <summary>
    ''' 获取装配组件信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AO_Assemble_SelListById As String = "  select * from  T10001_WL  where WL_No=@WL_No"

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AssembleOrder_WL_GetByID As String = "select Top 1 WL.*,GT.IsAssemble  from T10001_WL WL left join  T10000_GoodsType GT on WL.WL_Type_ID =GT.GoodsType_ID where ID=@WL_ID"


    Private Const SQL_AssembleWL_ByNo As String = " select Assemble_No ,W.WL_Name as Assemble_Name ,Assemble_Amount,ISNULL(W.WL_Qty, 0) - ISNULL(W.WL_BeiQty, 0) AS WL_ApproveQty  from T10001_WL_Assemble A left join T10001_WL W on A.Assemble_No  =W.WL_No where A.WL_No =@WL_No "
    ''' <summary>
    ''' 获取装配组件信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_AO_Assemble_SelListByNo As String = "  select * from T10001_WL_Assemble where WL_No=@WL_No"

#Region "装配单"

    ''' <summary>
    ''' 获取对装配列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Assemble_Order_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Assemble_Order_SelListById, "@ID", sId)
    End Function
#End Region

    ''' <summary>
    ''' 获取装配组件信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AO_Assemble_SelListById(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_AO_Assemble_SelListById, "@WL_No", WL_No)
    End Function

#End Region

#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取装配单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_AssembleOrder_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取装配单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_AssembleOrder_SelListByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_WL_GetByID(ByVal ID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_AssembleOrder_WL_GetByID, "@WL_ID", ID)
    End Function

    ''' <summary>
    ''' 获取物料组件信息
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AO_Assemble_SelListByNo(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_AO_Assemble_SelListByNo, "@WL_No", WL_No)
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
    Public Shared Function AssembleOrder_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_AssembleOrder_CheckIsModify, P)
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
    Public Shared Function AssembleOrder_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_AssembleOrder_CheckID, "@ID", ID)
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

    Public Shared Function Get_AssembleWL(ByVal WL_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_AssembleWL_ByNo, "@WL_No", WL_No)
    End Function


    ''' <summary>
    ''' 添加装配单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim AssembleOrderId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", AssembleOrderId)
        Try
            sqlMap.Add("Table", SQL_AssembleOrder_GetByid)
            sqlMap.Add("List", SQL_AssembleOrder_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & AssembleOrderId & "'," & BillType.AssembleOrder & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & AssembleOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & AssembleOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & AssembleOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改装配单单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim AssembleOrderId As String = dtTable.Rows(0)("ID")
        If LID <> AssembleOrderId AndAlso AssembleOrder_CheckID(AssembleOrderId) Then
            R.IsOk = False
            R.Msg = "" & AssembleOrder_DB_NAME & "[" & AssembleOrderId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)

        Try
            sqlMap.Add("Table", SQL_AssembleOrder_GetByid)
            sqlMap.Add("List", SQL_AssembleOrder_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & AssembleOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & AssembleOrder_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & AssembleOrderId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.StoreIn
                If LID <> AssembleOrderId Then
                    DtToUpDate(msg, "Update T27130_AssembleOrder_Table set id='" & AssembleOrderId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = AssembleOrderId
                    R.Msg = "" & AssembleOrder_DB_NAME & "[" & LID & "]已经修改为[" & AssembleOrderId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & AssembleOrder_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ClientOrder_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & AssembleOrder_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除装配
    ''' </summary>
    ''' <param name="AssembleOrderId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_Del(ByVal AssembleOrderId As String)
        Return RunSQL(SQL_AssembleOrder_DelByid, "@ID", AssembleOrderId)
    End Function


    ''' <summary>
    ''' 作废装配
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
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
            sqlMap.Add("Table", SQL_AssembleOrder_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    '检查装配单状态
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 审核装配单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AssembleOrder_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn

        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_State = Enum_State.AddNew
        If IsAudited Then
            OStr = "审核"
            State = Enum_State.Audited
        Else
            OStr = "反审核"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_AssembleOrder_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Invoid Then
                    '检查装配单状态
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]已经被作废,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & AssembleOrder_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function
#End Region
End Class