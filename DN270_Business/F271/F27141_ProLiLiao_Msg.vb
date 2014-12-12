Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F27141_ProLiLiao_Msg
    Dim LId As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim StoreDt As DataTable
    Dim State As Enum_State_Upgrade = Enum_State_Upgrade.AddNew
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
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Confirm)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
        Control_CheckRight(ID, ClassMain.Confirm_Qty, Cmd_ConfrimQty)


    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.ProLiLiao, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        If Bill_Id = "" AndAlso P_F_RS_ID <> "" Then
            Bill_Id = P_F_RS_ID
        End If
        ID = 27140
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name & "列表"

        Fg1.IniFormat()
        If Me.Mode = Mode_Enum.Modify AndAlso P_F_RS_ID <> "" Then
            Me.Bill_Id = P_F_RS_ID
        End If
        Me_Refresh()

    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.ProLiLiao_GetById(Bill_ID)
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
                Dim msg As DtReturnMsg = Dao.ProLiLiao_SelListById(0)
                If msg.IsOk Then
                    Fg1.DtToFG(msg.Dt)
                    dtList = msg.Dt
                End If
                Fg1.Rows.Count = 1
                Fg1.ReAddIndex()
            
                TB_Upd_User.Text = User_Display
                DTP_sDate.Value = GetDate()

                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                GetNewID()
                If Me.P_F_RS_ID4 = "[ProLiLiao]" Then
                    Dim dt As DataTable = DirectCast(Me.P_F_RS_Obj, DataTable)
                    TB_ScheduleID.Text = P_F_RS_ID2
                    If dt.Columns.Contains("BeiHao_Qty") = False Then dt.Columns.Add("BeiHao_Qty", GetType(Decimal))
                    Fg1.DtToFG(dt)
                End If

            Case Mode_Enum.Modify
                Dim msg As DtReturnMsg = Dao.ProLiLiao_SelListById(Bill_ID)
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                Dim dtList2 As DataTable
                If msg.IsOk Then
                    dtList = msg.Dt
                    dtList2 = msg.Dt
                    LastLine = msg.Dt.Rows(0)("Line")
                    dtList2.AcceptChanges()
                    Fg1.DtToFG(dtList2)
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        'CaculateSumAmount()
        dtTable.AcceptChanges()
        dtList.AcceptChanges()

    End Sub




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
        dr("ScheduleID") = TB_ScheduleID.Text
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID
            dr("Produce_No") = Fg1.Item(i, "Produce_No")
            dr("LiLiao_Qty") = Fg1.Item(i, "LiLiao_Qty")
            dr("Confirm_Qty") = Fg1.Item(i, "Confirm_Qty")
            dr("UPD_USER") = Fg1.Item(i, "UPD_USER")
            dr("Client_ID") = Fg1.Item(i, "Client_ID")
            dr("ProduceOrderID") = Fg1.Item(i, "ProduceOrderID")
            dr("ClientOrderID") = Fg1.Item(i, "ClientOrderID")
            dr("WL_ID") = Fg1.Item(i, "WL_ID")
            dr("WL_Spec") = Fg1.Item(i, "WL_Spec")
            dr("WL_material") = Fg1.Item(i, "WL_material")
            dr("WL_Center") = Fg1.Item(i, "WL_Center")
            dr("Produce_Qty") = Val(Fg1.Item(i, "Produce_Qty"))
            dr("WL_side") = Fg1.Item(i, "WL_side")
            dr("RWL_No") = Fg1.Item(i, "RWL_No")
            dr("RWL_Spec") = Fg1.Item(i, "RWL_Spec")
            dr("LRemark") = Fg1.Item(i, "LRemark")
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



            Cmd_UnConfirm.Visible = False
            Cmd_UnConfirm.Enabled = False

            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = True
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            Cmd_ConfrimQty.Visible = False
            Cmd_ConfrimQty.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Enabled = False
            Fg1.Cols("Confirm_Qty").Visible = False
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
                Case Enum_State_Upgrade.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Confirm.Enabled = Cmd_Confirm.Tag

                    Cmd_UnConfirm.Visible = False
                    Cmd_UnConfirm.Enabled = False

                    Cmd_UnAudit.Enabled = False
                    Cmd_UnAudit.Visible = False

                    Cmd_ConfrimQty.Visible = False
                    Cmd_ConfrimQty.Enabled = False

                    Cmd_Del.Enabled = True
                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False
                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Visible = Cmd_Del.Tag
                    Fg1.Cols("Confirm_Qty").Visible = False

                    LockForm(False)

                Case Enum_State_Upgrade.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Confirm.Enabled = False


                    Cmd_UnConfirm.Visible = False
                    Cmd_UnConfirm.Enabled = False



                    Cmd_UnAudit.Enabled = False
                    Cmd_UnAudit.Visible = False

                    Cmd_ConfrimQty.Visible = False
                    Cmd_ConfrimQty.Enabled = False

                    Cmd_Del.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False

                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False
                    Fg1.Cols("Confirm_Qty").Visible = True

                    LockForm(True)


                Case Enum_State_Upgrade.Comfirm  '确定
                    LabelState.Text = "已确定"
                    LabelState.ForeColor = Color.Red
                    Cmd_Confirm.Enabled = False

                    Cmd_UnConfirm.Visible = True
                    Cmd_UnConfirm.Enabled = True

                    Cmd_UnAudit.Enabled = True
                    Cmd_UnAudit.Visible = True
                    Cmd_Del.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False

                    Cmd_ConfrimQty.Visible = Cmd_ConfrimQty.Tag
                    Cmd_ConfrimQty.Enabled = True


                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False

                    Fg1.Cols("Confirm_Qty").Visible = True

                    LockForm(True)

                Case Enum_State_Upgrade.Audited '审核
                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Confirm.Enabled = False

                    Cmd_UnConfirm.Visible = False
                    Cmd_UnConfirm.Enabled = False

                    Cmd_UnAudit.Enabled = False
                    Cmd_UnAudit.Visible = False

                    Cmd_Del.Enabled = False

                    Cmd_Audit.Visible = False
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = Cmd_UnAudit.Tag
                    Cmd_UnAudit.Enabled = True

                    Cmd_ConfrimQty.Visible = False
                    Cmd_ConfrimQty.Enabled = False

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False
                    Fg1.Cols("Confirm_Qty").Visible = True
                    LockForm(True)
            End Select
        End If
        If IsBidings = False Then
            TB_ID.DataBindings.Add("Text", dtTable, TB_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            ' DTP_eDate.DataBindings.Add("Value", dtTable, DTP_eDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            TB_Remark.DataBindings.Add("Text", dtTable, TB_Remark.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            'TB_SumQty.DataBindings.Add("Text", dtTable, TB_SumQty.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("num"))
            TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Upd_User.DataBindings.Add("Text", dtTable, TB_Upd_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            IsBidings = True
        End If
        TB_ScheduleID.Text = IsNull(dtTable.Rows(0)("ScheduleID"), "")
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
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Confirm.Click
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveProLiLiao)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveProLiLiao)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveProLiLiao)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveProLiLiao(Optional ByVal Audit As Boolean = True)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Audit Then
            Dt.Rows(0).Item("State_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.ProLiLiao_Add(Dt, dtList)
        Else
            R = Dao.ProLiLiao_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If Audit Then
                Dim msg As MsgReturn = Dao.ProLiLiao_Confirmed(TB_ID.Text, True)
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
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.ProLiLiao_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If

        Dim ProNo As Integer = 0
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If IsNull(Fg1.Item(i, "Produce_No"), "") = "" Then
                ProNo += 1
            End If
        Next
        If ProNo > 0 Then
            ShowErrMsg("有[" & ProNo & "]张指令单没有编号请重新计算")
            Return False
        End If

        If Fg1.Rows.Count <= 1 Then
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


    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Row <= 0 Then
            Exit Sub
        End If
        Try
            If Fg1.LastKey = Keys.Enter Then
                Fg1.LastKey = 0
                Select Case Fg1.Cols(e.Col).Name
                    Case "Confirm_Qty"
                        Fg1.GotoNextCell(e.Col)
                    Case Else
                        Fg1.GotoNextCell(e.Col)
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col       
            Case "BeiHao_Qty"
                If e.ToRow < Fg1.Rows.Count - 1 Then
                    e.ToRow = e.Row + 1
                    e.ToCol = Fg1.Cols("BeiHao_Qty").Index
                Else
                    e.ToRow = e.Row
                    e.ToCol = Fg1.Cols("BeiHao_Qty").Index
                End If
        End Select
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
        'Fg1.AddRow()
        ShowInput("请输入要领料的生产单号", AddressOf GetRWL)
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

#End Region

    Private Sub GetRWL(ByVal id As String)
        Dim Msg As DtReturnMsg = Dao.GetWLByProID(id)
        If Msg.IsOk AndAlso Msg.Dt.Rows.Count = 1 Then
            Dim DR As DataRow = Msg.Dt.Rows(0)
            Dim DT As DataTable = TryCast(Fg1.DataSource, DataTable)
            DT.ImportRow(DR)
        End If
        Fg1.ReAddIndex()
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
        If TB_ID.Text <> LId OrElse LId = "" Then
            ComFun.DelBillNewID(BillType.PurchaseReturn, Bill_Id)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.ProLiLiao_DB_NAME = Ch_Name
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.ProLiLiao, DTP_sDate.Value, Bill_ID)
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
        Dim R As New R27140_ProLiLiao
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
        ShowConfirm("是否审核" & Ch_Name & "[" & TB_ID.Text & "]?", AddressOf Audit)
    End Sub
    Protected Sub Audit()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
            Dt.Rows(0).Item("State_User") = User_Display 
            R = Dao.ProLiLiao_Save(LId, Dt, dtList)
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            Dim msg As MsgReturn = Dao.ProLiLiao_Audited(TB_ID.Text, True)
            If msg.IsOk Then
                Bill_ID = TB_ID.Text
                Me_Refresh()
                ShowOk(msg.Msg)
            Else
                ShowErrMsg("保存成功,但" & msg.Msg)
            End If
            Exit Sub
        If TB_ID.Text = Bill_ID.Replace("-", "") Then Bill_ID = ""
        ShowOk(R.Msg, True)
        Else
        ShowErrMsg(R.Msg)
        End If
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dao.ProLiLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProLiLiao_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ProLiLiao)
    End Sub

    ''' <summary>
    ''' 删除客户单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub ProLiLiao()
        Dao.ProLiLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProLiLiao_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ProLiLiaoInValid)
    End Sub

    Sub ProLiLiaoInValid()
        Dao.ProLiLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProLiLiao_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ProLiLiaoValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub ProLiLiaoValid()
        Dao.ProLiLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProLiLiao_InValid(TB_ID.Text, False)
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
            Return Dao.ProLiLiao_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

    Private Sub Edit_Retrun()
        If Me.ReturnObj Is Nothing Then
            Exit Sub
        End If
        Dim dt As DataTable = TryCast(ReturnObj, DataTable)
        Dim fgdt As DataTable = TryCast(Fg1.DataSource, DataTable)
        DvToDt(dt, fgdt, New List(Of String), True)
        Fg1.DtToFG(fgdt)
        Fg1.ReAddIndex()
    End Sub
    Private Sub Cmd_UnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnConfirm.Click
        ShowConfirm("是否反确认" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnConfirm)
    End Sub
    Protected Sub UnConfirm()
        Dao.ProLiLiao_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.ProLiLiao_Confirmed(TB_ID.Text, False)
        If msg.IsOk Then
            ShowOk(msg.Msg)
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_ConfrimQty_Click(sender As Object, e As EventArgs) Handles Cmd_ConfrimQty.Click
        Fg1.CanEditing = True
        Fg1.IsClickStartEdit = True
        Fg1.Cols("LiLiao_Qty").AllowEditing = False
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Val(Fg1.Item(i, "Confirm_Qty")) = 0 Then
                Fg1.Item(i, "Confirm_Qty") = IsNull(Fg1.Item(i, "LiLiao_Qty"), 0)
            End If
        Next
    End Sub
End Class

Partial Friend Class Dao
    Protected Friend Shared ProLiLiao_DB_NAME As String = "生产领料单"

    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_DelByid As String = "Delete from T27140_ProLiLiao_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_GetByid As String = "select top 1 * from T27140_ProLiLiao_Table  where ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_SelByid As String = "select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T20200_StoreIn_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"

    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_GetStateByid As String = "select top 1 ID,State,State_User from T27140_ProLiLiao_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_GetListByid As String = "select * from T27141_ProLiLiao_List  where ID=@ID "



    Private Const SQL_ProLiLiao_SelListByid As String = "select L.*,C.Client_No,C.Client_Name, WL.WL_No,WL.WL_Name,''As Qty from T27141_ProLiLiao_List L left join T10001_WL WL on WL.ID=L.WL_ID Left join T10110_Client C On C.ID=L.Client_ID  where L.ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_CheckID As String = "select count(*) from T27140_ProLiLiao_Table  where ID=@ID"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_CheckIsModify As String = "select count(*) from T20201_StoreIn_list  where ID=@ID and Line=@Line"


    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ProLiLiao_WL_GetByID As String = "select Top 1 WL.*,GT.IsAssemble  from T10001_WL WL left join  T10000_GoodsType GT on WL.WL_Type_ID =GT.GoodsType_ID where ID=@WL_ID"

    ''' <summary>
    ''' 按生产单号获取毛坯
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_GetWLByProID As String = " Select L.* , Client_Name,WL_No,WL_Name  from  T27121_Schedule_List L Left join T10001_WL WL On L.WL_ID =WL.ID Left join T10110_Client C On L.Client_ID=C.ID  Where Produce_No=@Produce_No"
  


#Region "单一张单内容查询"



    ''' <summary>
    ''' 按ID获取物料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetWLByProID(ByVal Produce_No As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetWLByProID, "Produce_No", Produce_No)
    End Function


    ''' <summary>
    ''' 获取对入库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProLiLiao_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取客户订单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProLiLiao_SelListByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取物料信息
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_WL_GetByID(ByVal ID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProLiLiao_WL_GetByID, "@WL_ID", ID)
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
    Public Shared Function ProLiLiao_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_ProLiLiao_CheckIsModify, P)
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
    Public Shared Function ProLiLiao_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_ProLiLiao_CheckID, "@ID", ID)
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
    ''' 添加客户订单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProLiLiaoId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ProLiLiaoId)
        Try
            sqlMap.Add("Table", SQL_ProLiLiao_GetByid)
            sqlMap.Add("List", SQL_ProLiLiao_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & ProLiLiaoId & "'," & BillType.ProLiLiao & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & ProLiLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ProLiLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ProLiLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改客户订单单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProLiLiaoId As String = dtTable.Rows(0)("ID")
        If LID <> ProLiLiaoId AndAlso ProLiLiao_CheckID(ProLiLiaoId) Then
            R.IsOk = False
            R.Msg = "" & ProLiLiao_DB_NAME & "[" & ProLiLiaoId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)

        Try
            sqlMap.Add("Table", SQL_ProLiLiao_GetByid)
            sqlMap.Add("List", SQL_ProLiLiao_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = Enum_State_Upgrade.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & ProLiLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State_Upgrade.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & ProLiLiao_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & ProLiLiaoId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.StoreIn
                If LID <> ProLiLiaoId Then
                    DtToUpDate(msg, "Update T27140_ProLiLiao_Table set id='" & ProLiLiaoId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = ProLiLiaoId
                    R.Msg = "" & ProLiLiao_DB_NAME & "[" & LID & "]已经修改为[" & ProLiLiaoId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & ProLiLiao_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ClientOrder_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ProLiLiao_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除客户订单
    ''' </summary>
    ''' <param name="ProLiLiaoId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_Del(ByVal ProLiLiaoId As String)
        Return RunSQL(SQL_ProLiLiao_DelByid, "@ID", ProLiLiaoId)
    End Function


    ''' <summary>
    ''' 作废客户订单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_State_Upgrade = Enum_State_Upgrade.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_State_Upgrade.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_ProLiLiao_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State_Upgrade.Audited Then
                    '检查加工单状态
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & ProLiLiao_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & ProLiLiao_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & ProLiLiao_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & ProLiLiao_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ProLiLiao_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 审核客户订单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P27140_ProLiLiao_Audited", paraMap, True)
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
    ''' 确认生产领料
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsConfirmed">确认还是反确认</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiao_Confirmed(ByVal _ID As String, ByVal IsConfirmed As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsConfirmed", IsConfirmed)
        paraMap.Add("State_User", User_Display)

        Dim R As MsgReturn = SqlStrToOneStr("P27140_ProLiLiao_Confirmed", paraMap, True)
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



#End Region



















End Class