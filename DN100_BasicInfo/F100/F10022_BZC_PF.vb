Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F10022_BZC_PF
    Dim PF_ID As Integer = 0
    Dim BZC_ID As Integer = 0
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim isCopy As Boolean = False
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal _BZC_ID As Integer)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Me.BZC_ID = _BZC_ID
        Me.Mode = Mode
    End Sub

    Public Sub New(ByVal _PF_ID As Integer, ByVal _BZC_ID As Integer, Optional ByVal _IsCopy As Boolean = False)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        PF_ID = _PF_ID
        Me.BZC_ID = _BZC_ID
        Me.Mode = Mode
        Me.isCopy = _IsCopy
    End Sub




    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 10020
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        Fg1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Fg1.Rows.Count = 1



        Fg1.Cols("WL_No").Editor = CB_WL_FG
        Fg1.IniColsSize()
        FormCheckRight()
        Ch_Name = "色板明细"

        Fg1.IniFormat()
        TB_PF_Name.Tag = "0"

        Dim msgStep As DtReturnMsg = BaseClass.ComFun.Remark_GetList(Enum_RemarkType.Dying_Step)
        If msgStep.IsOk Then
            CB_DyingStep.DataSource = msgStep.Dt
            CB_DyingStep.DisplayMember = "Remark"
            CB_DyingStep.ValueMember = "Remark"

        End If
        Fg1.Cols("DyingStep").Editor = CB_DyingStep

        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub

                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                If Me.isCopy = False Then
                    Fg1.Rows.Count = 1
                Else
                    Me.Title = Ch_Name & " - 复制"
                End If
                ' Fg1.Rows.Count = 1
                Fg1.Cols("UpdQty").Visible = False
                Fg1.Cols("Qty").AllowEditing = True
                CaculateSumAmount()
                CKB_IsCheck.Checked = False
            Case Mode_Enum.Modify

        End Select
        Me_Refresh()
    End Sub


    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.BZCPF_GetTable_ByID(Me.PF_ID, BZC_ID)
        dtTable = msg.Dt
        Dim msgList As DtReturnMsg = Dao.BZCPF_GeList_ByID(Me.PF_ID, Me.BZC_ID)
        If msgList.IsOk Then
            dtList = msgList.Dt
        End If
        msg = Dao.BZC_GetById(BZC_ID)
        If msg.IsOk Then
            If msg.Dt.Rows.Count > 0 Then
                TB_Bzc_No.Text = Dao.BZC_NoToText(msg.Dt.Rows(0)("BZC_No")) & "." & msg.Dt.Rows(0)("BZC_Name")
            Else
                Me.Close(False)
            End If
        End If
        SetForm()
    End Sub

#Region "表单信息"


    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetList()
        Me.dtTable.Rows(0)("BZC_ID") = Me.BZC_ID
        Me.dtTable.Rows(0)("ID") = Me.PF_ID

        If CKB_IsCheck.Checked Then TB_UpdName.Text = User_Display

        GetControlValue(dtTable.Rows(0), TB_PF_Name)




        GetControlValue(dtTable.Rows(0), DP_FoundDate)
        GetControlValue(dtTable.Rows(0), CKB_IsOK)
        GetControlValue(dtTable.Rows(0), CKB_IsCheck)
        Me.dtTable.Rows(0)("FounderName") = CB_FounderName.Text
        dtTable.Rows(0)("Founder") = CB_FounderName.IDAsInt
        Me.dtTable.Rows(0)("AdjusterName") = CB_AdjusterName.Text
        dtTable.Rows(0)("Adjuster") = CB_AdjusterName.IDAsInt


        If CKB_IsCheck.Checked Then
            GetControlValue(dtTable.Rows(0), TB_UpdName)
        End If

        Dim dt As DataTable = dtList.Clone
        Dim dr As DataRow
        For i = 1 To Fg1.Rows.Count - 1
            If Val(Fg1.Item(i, "WL_ID")) = 0 AndAlso Fg1.Item(i, "DyingStep") = "" Then
                Continue For
            End If
            dr = dt.NewRow
            dr("BZC_ID") = BZC_ID
            dr("ID") = PF_ID
            dr("Qty") = Val(Fg1.Item(i, "Qty"))
            dr("UpdQty") = Val(Fg1.Item(i, "UpdQty"))
            dr("WL_ID") = Val(Fg1.Item(i, "WL_ID"))
            dr("DyingStep") = Fg1.Item(i, "DyingStep")
            dt.Rows.Add(dr)
        Next
        dtList = dt


    End Sub



    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm()
        If Me.dtTable Is Nothing OrElse Me.dtList Is Nothing Then
            Exit Sub
        End If
        If dtTable.Rows.Count = 0 OrElse (Me.Mode = Mode_Enum.Add AndAlso Me.isCopy = False) Then
            dtTable.Clear()
            dtTable.Rows.Add(dtTable.NewRow)
        End If

        CB_FounderName.IDAsInt = IsNull(dtTable.Rows(0)("Founder"), 0)
        CB_FounderName.Text = CB_FounderName.GetByTextBoxTag()

        CB_AdjusterName.IDAsInt = IsNull(dtTable.Rows(0)("Adjuster"), 0)
        CB_AdjusterName.Text = CB_AdjusterName.GetByTextBoxTag()

        SetControlValue(dtTable.Rows(0), TB_PF_Name)


        SetControlValue(dtTable.Rows(0), DP_FoundDate)
        SetControlValue(dtTable.Rows(0), CKB_IsOK)
        SetControlValue(dtTable.Rows(0), CKB_IsCheck)
        SetControlValue(dtTable.Rows(0), TB_UpdName)





        If Me.isCopy Then
            Me.CKB_IsOK.Checked = False
            Me.CKB_IsCheck.Checked = False
            Me.TB_UpdName.Text = ""
            For Each dr As DataRow In dtList.Rows
                dr("UpdQty") = 0
                dr("ID") = Me.PF_ID
            Next
        End If
        If CKB_IsCheck.Checked = False Then
            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_UnAudit.Visible = False
        Else
            Cmd_UnAudit.Visible = Cmd_UnAudit.Tag
            Cmd_Audit.Visible = False
        End If
        LockForm(CKB_IsCheck.Checked)
        Fg1.DtToSetFG(dtList)
    End Sub

    Sub LockForm(ByVal Lock As Boolean)

        TB_PF_Name.ReadOnly = Lock
        CB_FounderName.Enabled = Not Lock
        CB_AdjusterName.Enabled = Not Lock

        Fg1.Cols("Qty").AllowEditing = Lock
        Fg1.Cols("DyingStep").AllowEditing = Not Lock
        Fg1.Cols("WL_No").AllowEditing = Not Lock
        Fg1.Cols("WL_Spec").AllowEditing = Not Lock
        Fg1.Cols("UpdQty").Visible = Lock

        DP_FoundDate.Enabled = Lock
        Fg1.Cols("Qty").AllowEditing = Not Lock
        Cmd_AddRow.Enabled = Not Lock
        Cmd_RemoveRow.Enabled = Not Lock
    End Sub

    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()

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
        If CheckForm() Then
            ShowConfirm("是否保存" & Ch_Name & " 的修改?", AddressOf SaveBZCPF)
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveBZCPF(Optional ByVal Audit As Boolean = False)
        Dim R As New MsgReturn
        GetList()
        If Audit Then
            dtTable.Rows(0).Item("Check_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.BZCPF_Add(dtTable, dtList)
        ElseIf Me.Mode = Mode_Enum.Modify Then
            R = Dao.BZCPF_Save(dtTable, dtList)
        End If

        If R.IsOk Then
            PF_ID = dtTable.Rows(0).Item("ID")
            LastForm.ReturnId = TB_PF_Name.Text
            Mode = Mode_Enum.Modify
            If Audit Then
                Dim msg As MsgReturn = Dao.BZCPF_Audited(BZC_ID, PF_ID, True)
                If msg.IsOk Then
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
        If TB_PF_Name.Text = "" Then
            ShowErrMsg("色板名称不能为空！", AddressOf TB_PF_Name.Focus)
            Return False
        End If
        Dim msg As MsgReturn = Dao.BZCPF_CheckName(Me.PF_ID, Me.BZC_ID, TB_PF_Name.Text)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg, AddressOf TB_PF_Name.Focus)
            Return False
        End If
        If CB_FounderName.IDAsInt = 0 Then
            ShowErrMsg("打板人不能为空！", AddressOf CB_FounderName.Focus)
            Return False
        End If
        CaculateSumAmount()
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


    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        Fg1.AddRow()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
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
#End Region



#Region "FG事件"
#Region "WL选择"

    Dim IsWLSelect As Boolean
    Private Sub CB_WL_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_WL_FG.Col_Sel
        IsWLSelect = True
        FG1.Item(FG1.RowSel, "WL_Name") = Col_Name
        FG1.Item(FG1.RowSel, "WL_ID") = ID
        FG1.GotoNextCell("WL_No")
    End Sub
    Private Sub CB_WL_FG_SetEmpty() Handles CB_WL_FG.SetEmpty
        FG1.Item(FG1.RowSel, "WL_ID") = 0
        FG1.Item(FG1.RowSel, "WL_No") = ""
        FG1.Item(FG1.RowSel, "WL_Name") = ""
        FG1.Item(FG1.RowSel, "Qty") = 0
    End Sub
    Private Sub CB_WL_FG_Col_SelRow(ByVal Dr As System.Data.DataRow) Handles CB_WL_FG.Col_SelRow
        FG1.Item(FG1.RowSel, "WL_Spec") = Dr("WL_Spec")

    End Sub
    Private Sub CB_WL_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_WL_FG.GetSearchEvent
        CB_WL_FG.IDValue = FG1.Item(FG1.RowSel, "WL_ID")
    End Sub

    Sub FG_WL_No()
        FG1.StartEditing(FG1.RowSel, FG1.Cols("WL_No").Index)
    End Sub
#End Region

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Col = Fg1.Cols("WL_No").Index Then
            If Fg1.LastKey = Keys.Enter Then
                CB_WL_FG.Col_SelOne()
                If Fg1.Item(e.Row, "WL_Name") = "" Then
                    ShowErrMsg("请输入一个物料编号!", AddressOf FG_WL_No)
                End If
            Else
                If Fg1.LastText <> IsNull(Fg1.Item(e.Row, "WL_No"), "") AndAlso IsWLSelect = False Then
                    Fg1.Item(Fg1.RowSel, "WL_ID") = 0
                    Fg1.Item(Fg1.RowSel, "WL_Name") = ""
                    Fg1.Item(Fg1.RowSel, "WL_Spec") = ""
                End If
                IsWLSelect = False
            End If
        Else
            If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell()
        End If
    End Sub


    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        If e.Col = "Qty" Then
            If e.Row + 2 > Fg1.Rows.Count And Cmd_AddRow.Enabled Then
                Fg1.Cols("DyingStep").AllowEditing = False
                Fg1.Rows.Add()
                Fg1.ReAddIndex()
                Fg1.Cols("DyingStep").AllowEditing = True
            End If
            If e.Row + 2 > Fg1.Rows.Count Then
                e.ToCol = Fg1.Cols("UpdQty").Index
            Else
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("WL_No").Index
            End If
        ElseIf e.Col = "WL_No" Then
            e.ToCol = Fg1.Cols("Qty").Index
        ElseIf e.Col = "UpdQty" Then
            If e.Row + 2 > Fg1.Rows.Count Then
                Exit Sub
            Else
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("UpdQty").Index
            End If
        End If
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
        'If Me.Mode = Mode_Enum.Add Then
        '    Exit Sub
        'End If
        'Dim R As New R40001_PBRK
        'R.Start(TB_ID.Text, DoOperator)
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
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Shenhe)
            Else
                ShowConfirm("是否保存并审核" & Ch_Name & "[" & TB_PF_Name.Text & "] ?", AddressOf Shenhe)
            End If
        End If
    End Sub
    Protected Sub Shenhe()
        SaveBZCPF(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_PF_Name.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.BZCPF_Audited(BZC_ID, PF_ID, False)
        If msg.IsOk Then
            ShowOk(msg.Msg)
            Me_Refresh()
            Me.LastForm.ReturnId = TB_PF_Name.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

#End Region

    Private Sub TB_PF_Name_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_PF_Name.KeyDown
        If e.KeyCode = Keys.Enter Then
            CB_FounderName.Focus()
        End If
    End Sub

End Class
