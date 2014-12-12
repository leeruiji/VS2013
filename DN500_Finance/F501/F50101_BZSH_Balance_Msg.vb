Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F50101_BZSH_Balance_Msg
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

    Public Sub New(ByVal initID As String, ByVal _Client_ID As Int16, ByVal _sDate As Date, ByVal state As Integer)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = initID
        CB_Client.IDValue = _Client_ID
        DTP_sDate.Value = _sDate
        state = state
        Me.Mode = Mode
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
        If Fg1.Rows.Count > 1 Then
            Fg1.RowSel = 1
            Fg1.Row = 1

            Fg1.Select(1, 1, 1, 1)
        End If
        Fg1.ColSel = 1
        Fg1.Col = 1
        CB_Client.Focus()

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
        ID = 50100
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.Lock, Cmd_Lock)
        Control_CheckRight(ID, ClassMain.UnLock, Cmd_UnLock)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.BZSH_Balance, Bill_ID)
        ReturnId = TB_ID.Text
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        If Bill_ID = "" AndAlso P_F_RS_ID <> "" Then
            Bill_ID = P_F_RS_ID
            CB_Client.IDValue = P_F_RS_ID4
            Me.Mode = Mode_Enum.Modify
        End If
        Fg1.IniColsSize()



        '业务员
        Employee_List1.Set_TextBox(TB_Operator, TB_Upd_User)

        TB_Operator.Tag = "0"
        Fg1.IniFormat()
        If Me.Mode = Mode_Enum.Modify AndAlso P_F_RS_ID <> "" Then
            Me.Bill_ID = P_F_RS_ID
        End If
        Me_Refresh()
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.Balance_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If

            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Ch_Name & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Ch_Name & "!", True) : Exit Sub
                'Dim msg As DtReturnMsg = Dao.Balance_SelListById(0)
                'If msg.IsOk Then dtList = msg.Dt
                Fg1.Rows.Count = 1
                Fg1.ReAddIndex()
                TB_Upd_User.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                GetNewID()
            Case Mode_Enum.Modify
                If State = Enum_State.AddNew OrElse State = Enum_State.Invoid Then
                    Dim msg As DtReturnMsg = Dao.Balance_SelListById(Val(CB_Client.IDValue), DTP_Balance_Date.Value)
                    If msg.IsOk Then
                        dtList = msg.Dt
                        '  DtToFg(msg.Dt)
                    End If
                Else
                    Dim msg As DtReturnMsg = Dao.Balance_SelListById_AfterLock(Bill_ID)
                    If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                        dtList = msg.Dt
                        LastLine = msg.Dt.Rows(0)("Line")
                        '  DtToFg(msg.Dt)
                    End If
                End If
                DtToFg(dtList)

                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        CaculateSumAmount()
        dtTable.AcceptChanges()


    End Sub
    Private LastClient As Integer = 0
#Region "获取新的对账单内容"

    Private Sub CB_Client_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel
        If ID <> 0 Then
            If LastClient <> ID Then
                GetList(Val(ID), DTP_Balance_Date.Value.Date)
                LastClient = ID
                TB_Client_Name.Text = Col_Name
            End If
        End If
    End Sub


    Private Sub DTP_Balance_Date_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_Balance_Date.ValueChanged

        If isLoaded = False Then
            Exit Sub
        End If
        GetList(Val(CB_Client.IDValue), DTP_Balance_Date.Value.Date)


    End Sub

    Private Sub GetList(ByVal Client_ID As Integer, ByVal bDate As Date)
        If State = Enum_State.AddNew Then
            Dim msg As DtReturnMsg = Dao.Balance_SelListById(Client_ID, bDate)
            If msg.IsOk Then
                DtToFg(msg.Dt)
                CaculateSumAmount()
            End If

        End If

    End Sub
#End Region


    Private Sub DtToFg(ByVal Dt As DataTable)
        dtList = Dt
        If dtList Is Nothing OrElse dtList.Rows.Count = 0 Then
            Fg1.Rows.Count = 1
        Else

            ' LastLine = msg.Dt.Rows(0)("Line")
            ComFun.Balance_HideCells(dtList)
            'Dim C_Date As New DataColumn("C_Date", GetType(Date))
            'Dim C_ID As New DataColumn("C_ID")

            'If Not dtList.Columns.Contains("C_Date") Then dtList.Columns.Add(C_Date)

            'If Not dtList.Columns.Contains("C_ID") Then dtList.Columns.Add(C_ID)
            'If Not dtList.Columns.Contains("C_BillName") Then dtList.Columns.Add(C_BillName)
            'Dim ListID As String = ""
            'For Each Row As DataRow In dtList.Rows
            '    If ListID <> Row("BZSH_ID") Then
            '        ListID = Row("BZSH_ID")
            '        Row("C_ID") = Row("BZSH_ID")
            '        Row("C_Date") = Row("sDate")
            '        Row("C_BillName") = Row("BillName")
            '    End If
            'Next
            Fg1.DtToSetFG(dtList)

        End If
    End Sub

#Region "表单控件事件"

#End Region

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
        dr("Operator") = Val(TB_Operator.Tag)
        dr("State") = State
        dr("Client_ID") = Val(CB_Client.IDValue)
        dt.Rows(0).Item("Balance_Date") = DTP_Balance_Date.Value
        dt.AcceptChanges()

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
            ' Dr("UnPayed") = 0
            Dr("State_User") = ""
            ' Dr("ClientBill") = ""
            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("Add_Amount") = 0
            '   Dr("Payed") = Dr("SumAmount") - Dr("UnPayed")
            Cmd_Audit.Visible = False

            Cmd_UnAudit.Visible = False

            Cmd_Lock.Visible = Cmd_Lock.Tag
            Cmd_UnLock.Visible = False

            Cmd_SetValid.Visible = False

            Cmd_SetInValid.Visible = False
            Cmd_Del.Visible = False

            Cmd_Preview.Enabled = False
            Cmd_Print.Enabled = False

            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Cmd_Del.Visible = False
            CB_Client.Enabled = False
            Select Case State
                Case Enum_State.AddNew '新建


                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag
                    Cmd_Del.Visible = Cmd_Del.Tag

                    Cmd_Audit.Visible = False
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False

                    Cmd_Lock.Visible = Cmd_Lock.Tag
                    Cmd_UnLock.Visible = False

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True

                    Cmd_Preview.Enabled = False
                    Cmd_Print.Enabled = False

                    LockForm(False)
                Case Enum_State.Invoid '作废


                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False
                    Cmd_Del.Visible = Cmd_Del.Tag

                    Cmd_Audit.Visible = False

                    Cmd_UnAudit.Visible = False

                    Cmd_Lock.Visible = False
                    Cmd_UnLock.Visible = False

                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False

                    Cmd_Preview.Enabled = False
                    Cmd_Print.Enabled = False

                    LockForm(True)
                Case 1 '锁定


                    LabelState.Text = "锁定"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False
                    Cmd_Del.Visible = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_UnAudit.Visible = False
                    Cmd_Lock.Visible = False
                    Cmd_UnLock.Visible = Cmd_UnLock.Tag

                    Cmd_SetValid.Visible = False
                    Cmd_SetInValid.Visible = False

                    Cmd_Preview.Enabled = True
                    Cmd_Print.Enabled = True


                    LockForm(True)
                Case 2 '审核


                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False
                    Cmd_Del.Visible = False

                    Cmd_Audit.Visible = False
                    Cmd_UnAudit.Visible = Cmd_UnAudit.Tag

                    Cmd_Lock.Visible = False
                    Cmd_UnLock.Visible = False

                    Cmd_SetValid.Visible = False
                    Cmd_SetInValid.Visible = False

                    Cmd_Preview.Enabled = True
                    Cmd_Print.Enabled = True



                    LockForm(True)
            End Select

        End If
        If IsBidings = False Then
            TB_ID.DataBindings.Add("Text", dtTable, TB_ID.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged)
            DTP_sDate.DataBindings.Add("Value", dtTable, DTP_sDate.Name.Substring(4), False, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")
            DTP_Balance_Date.DataBindings.Add("Value", dtTable, DTP_Balance_Date.Name.Substring(4), True, DataSourceUpdateMode.OnPropertyChanged, ServerTime.Date, "yyyy-MM-dd")


            TB_Remark.DataBindings.Add("Text", dtTable, TB_Remark.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Last_Amount.DataBindings.Add("Text", dtTable, TB_Last_Amount.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_Add_Amount.DataBindings.Add("Text", dtTable, TB_Add_Amount.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_SumPayed.DataBindings.Add("Text", dtTable, TB_SumPayed.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))
            TB_Balance_Amount.DataBindings.Add("Text", dtTable, TB_Balance_Amount.Name.Substring(3), True, DataSourceUpdateMode.OnPropertyChanged, 0, FormatSharp("money"))


            TB_State_User.DataBindings.Add("Text", dtTable, TB_State_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            TB_Upd_User.DataBindings.Add("Text", dtTable, TB_Upd_User.Name.Substring(3), False, DataSourceUpdateMode.OnPropertyChanged, "")
            IsBidings = True
        End If
        Employee_List1.GetByTextBoxTag(IsNull(dtTable.Rows(0)("Operator"), "0"))
        CB_Client.IDValue = IsNull(dtTable.Rows(0)("Client_ID"), "0")
        CB_Client.Text = CB_Client.GetByTextBoxTag(IsNull(dtTable.Rows(0)("Client_ID"), "0"))
        TB_Client_Name.Text = CB_Client.NameValue
    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock

        DTP_sDate.Enabled = Not Lock
        CB_Client.Enabled = Not Lock
        TB_Operator.ReadOnly = Lock
        TB_Remark.ReadOnly = Lock
        DTP_Balance_Date.Enabled = Not Lock


    End Sub




    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then

            TB_SumPayed.Text = 0
            Exit Sub
        End If
        Dim SumAmount As Double = 0

        Dim Paid As Double = 0

        For R As Integer = 1 To Fg1.Rows.Count - 1


            SumAmount = SumAmount + Val(Fg1.Item(R, "Amount"))
            ' Paid = Paid + Val(Fg1.Item(R, "Payed"))

        Next
        TB_SumPayed.Text = FormatMoney(Paid)
        TB_Add_Amount.Text = FormatMoney(SumAmount)
        TB_Balance_Amount.Text = FormatMoney(Val(TB_Last_Amount.Text) + SumAmount - Paid)

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
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveBalance)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveBalance)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveBalance)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveBalance(Optional ByVal lock As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If lock Then
            Dt.Rows(0).Item("State_User") = User_Display

        End If

        'Dim bMsg As DtReturnMsg = Dao.Account_CheckBalanceDate(Dt.Rows(0)("Client_ID"), Dt.Rows(0)("Balance_date"))

        'If bMsg.IsOk AndAlso bMsg.Dt.Rows.Count > 0 Then
        '    If IsNull(Dt.Rows(0)("State"), 0) = 0 Then
        '        ShowErrMsg(Me.Ch_Name & "保存失败！错误：对账日期[" & dtTable.Rows(0)("sDate") & "]必须大于客户[" & bMsg.Dt.Rows(0)("Client_name") & "]的最近对账日期[" & bMsg.Dt.Rows(0)("Balance_Date") & "]")
        '        Exit Sub          
        '    End If
        'End If
        Dim bMsg As MsgReturn = Dao.Balance_CheckSave(TB_ID.Text, Val(CB_Client.IDValue), DTP_Balance_Date.Value)
        If bMsg.IsOk Then
            If Not bMsg.Msg.StartsWith("1") Then
                ShowErrMsg(bMsg.Msg.Substring(1))
                Exit Sub
            End If
        End If


        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Balance_Add(Dt)
        Else
            R = Dao.Balance_Save(LId, Dt)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If lock Then
                Dim uACount As Integer = Dao.CBalance_CountUnAudited(Val(CB_Client.IDValue), DTP_Balance_Date.Value.Date)
                If uACount = -1 Then

                    ShowErrMsg("保存成功,但由于检查未审核对账单时发生错误，无法锁定对账单。")
                ElseIf uACount > 0 Then
                    ' ShowConfirm ("截止【" & DTP_Balance_Date .Value .Date &"】 前还有【"& uACount&“】张送货单未审核.","现在去查看","现在去查看”,"什么都不做",AddressOf ShowBZSH,AddressOf LockBalance,AddressOf doNothing)
                    ShowConfirm("截止【" & DTP_Balance_Date.Value.Date & "】 前还有【" & uACount & "】张送货单未审核.", "现在去查看", "锁定对账单", "取消", AddressOf ShowBZSH, AddressOf LockBalance, AddressOf doNothing)
                End If
                'Dim msg As MsgReturn = Dao.Balance_Lock(TB_ID.Text, True, PClass.PClass.User_Name)
                'If msg.IsOk Then
                '    If msg.Msg.StartsWith("1") Then
                '        Bill_ID = TB_ID.Text
                '        Me_Refresh()
                '        ShowOk(msg.Msg.Substring(1))
                '    Else
                '        ShowErrMsg(msg.Msg.Substring(1))
                '    End If
                'Else

                '    ShowErrMsg("保存成功,但" & msg.Msg.Substring(1))
                'End If
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
        CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.Balance_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
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

    Private Sub doNothing()

    End Sub
#End Region


#Region "FG 事件"

    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        If Fg1.RowSel <= 0 Then
            Exit Sub
        End If
        ShowOneBill()
    End Sub


    Sub ShowOneBill()
        If Fg1.RowSel <= 0 Then
            Exit Sub
        End If
        Try

            Dim BillType As Integer = Fg1.Item(Fg1.RowSel, "BillType")
            Dim _Id As String = Fg1.Item(Fg1.RowSel, "sID")
            Dim f As PClass.BaseForm = BaseClass.ComFun.ShowBill(BillType, _Id, Me)
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
            AddHandler VF.ClosedX, AddressOf CaculateSumAmount
            VF.Show()
        Catch ex As Exception
            DebugToLog(ex)
        End Try
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
            ComFun.DelBillNewID(BillType.BZSH_Balance, Bill_ID)
            Bill_ID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_ID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.BZSH_Balance, DTP_sDate.Value, Bill_ID)
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
        Dim R As New R50100_BZSH_Balance
        R.SetOption(Dao.CBalance_GetLast_BalanceDate(TB_ID.Text), DTP_Balance_Date.Value.Date, CB_Client.IDValue, TB_Client_Name.Text)
        R.Start(GetPrintDt, DoOperator)
    End Sub

    Private Function GetPrintDt() As DataTable
        Dim dt As DataTable = Dao.CBalance_GetEmpty_PrintDt()

        Dim dr As DataRow
        For i As Int16 = 1 To Fg1.Rows.Count - 1
            dr = dt.NewRow
            FGRowToDr(dr, i)

            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


    Private Sub FGRowToDr(ByRef dr As DataRow, ByVal i As Integer)
        dr("sDate") = Fg1.Item(i, "sDate")
        ' dr("Client_Name") = TB_Client_Name.Text
        dr("sID") = Fg1.Item(i, "sID")
        dr("BZ") = Fg1.Item(i, "BZ")
        dr("BZC") = Fg1.Item(i, "BZC")
        dr("GH") = Fg1.Item(i, "GH")
        dr("JiaGongNeiRong") = Fg1.Item(i, "JiaGongNeiRong")
        dr("Qty") = Fg1.Item(i, "Qty")
        dr("PWeight") = Fg1.Item(i, "PWeight")
        dr("Price") = Fg1.Item(i, "Price")
        dr("Amount") = Fg1.Item(i, "Amount")
        dr("JiaoDai") = Fg1.Item(i, "JiaoDai")
        dr("Amount_JiaoDai") = Fg1.Item(i, "Amount_JiaoDai")
        dr("ZhiTong") = Fg1.Item(i, "ZhiTong")
        dr("Amount_ZhiTong") = Fg1.Item(i, "Amount_ZhiTong")
        dr("Amount_GH") = Fg1.Item(i, "Amount_GH")
        dr("Price_ZhiTong") = Fg1.Item(i, "Price_ZhiTong")

        'dr("StartDate") = Dao.CBalance_GetLast_BalanceDate(TB_ID.Text)
        'dr("EndDate") = DTP_Balance_Date.Value.Date
        'dr("User_Name") = TB_Upd_User.Text
        'dr("MadeDate") = DTP_Balance_Date.Value.Date.AddDays(1)
        'Dim FirstDate As Date = dr("StartDate")
        'Dim LastDate As Date = dr("EndDate")
        'If FirstDate.Month = LastDate.Month AndAlso FirstDate.Year = LastDate.Year Then
        '    dr("DateStr") = FirstDate.ToString("yyyy年MM月")
        'ElseIf FirstDate.Month <> LastDate.Month AndAlso FirstDate.Year = LastDate.Year Then
        '    dr("DateStr") = FirstDate.ToString("yyyy年MM") & LastDate.ToString("-MM月")
        'Else
        '    dr("DateStr") = FirstDate.ToString("yyyy年MM月") & LastDate.ToString("yyyy年MM月")
        'End If


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



        ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Shenhe)


    End Sub
    Protected Sub Shenhe()
        Dao.Balance_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.Balance_Audited(TB_ID.Text, True)
        If msg.IsOk Then
            ShowOk(msg.Msg)
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dao.Balance_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.Balance_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelBalance)
    End Sub

    ''' <summary>
    ''' 删除入库单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelBalance()
        Dao.Balance_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.Balance_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf BalanceInValid)
    End Sub


    Sub BalanceInValid()
        Fg1.FinishEditing(False)
        Dao.Balance_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.Balance_InValid(TB_ID.Text, True, TB_Remark.Text)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf BalanceValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub BalanceValid()
        Fg1.FinishEditing(False)
        Dao.Balance_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.Balance_InValid(TB_ID.Text, False, TB_Remark.Text)
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
            Return Dao.Balance_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region

#Region "锁定，解锁"
    ''' <summary>
    ''' 锁定对账单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Lock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Lock.Click
        If CheckForm() Then
            SaveBalance(True)
        End If

    End Sub

    ''' <summary>
    ''' 锁定对账单
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LockBalance()


        Dim msg As MsgReturn = Dao.Balance_Lock(TB_ID.Text, True, PClass.PClass.User_Name)
        If msg.IsOk Then
            If msg.Msg.StartsWith("1") Then
                Bill_ID = TB_ID.Text
                Me_Refresh()
                ShowOk(msg.Msg.Substring(1))
            Else
                ShowErrMsg(msg.Msg.Substring(1))
            End If
        Else
            ShowErrMsg("解锁失败，错误：" & msg.Msg.Substring(1))
        End If
        Exit Sub


    End Sub

    Private Sub ShowBZSH()
        Dim F As BaseForm = LoadFormIDToChild(40000, Me)
        If F Is Nothing Then Exit Sub
        Fg1.RowSel = Fg1.RowSel
        With F
            .P_F_RS_ID = CB_Client.IDValue
            .P_F_RS_ID2 = TB_Client_Name.Text

            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub
    ''' <summary>
    ''' 解锁对账单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_UnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnLock.Click


        Dim msg As MsgReturn = Dao.Balance_Lock(TB_ID.Text, False, PClass.PClass.User_Name)
        If msg.IsOk Then
            If msg.Msg.StartsWith("1") Then
                Bill_ID = TB_ID.Text
                Me_Refresh()
                ShowOk(msg.Msg.Substring(1))
            Else
                ShowErrMsg(msg.Msg.Substring(1))
            End If
        Else
            ShowErrMsg("解锁失败，错误：" & msg.Msg.Substring(1))
        End If
        Exit Sub


    End Sub
#End Region





End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Shared Balance_DB_NAME As String = "送货对账单"

    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Balance_DelByid As String = "Delete from T50100_CBalance_Table  where ID=@ID and State<1"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Balance_GetByid As String = "select top 1 * from T50100_CBalance_Table  where ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Balance_SelByid As String = "select top 1 S.*,E.Employee_Name as OperatorName  from T50100_CBalance_Table S  left join T15001_Employee E on S.Operator=E.ID  where S.ID=@ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Balance_GetStateByid As String = "select top 1 ID,State,State_User,Client_ID,Remark from T50100_CBalance_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Balance_GetListByid As String = "select * from T50101_CBalance_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_Balance_SelListByid As String = "select L.*,SumAmount,UnPayed from T50101_CBalance_List L left join T50201_Accounts_Summary m on m.id=l.BillID and m.BillType=l.BillType  where L.ID=@ID "
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Balance_CheckID As String = "select count(*) from T50100_CBalance_Table  where ID=@ID"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_Balance_CheckIsModify As String = "select count(*) from T50101_CBalance_List  where ID=@ID and Line=@Line"

    Private Const SQL_Balance_GetAccounts_State As String = "select top 1 BillType,Settle_ID,UnPayed from T50201_Accounts_Summary where BillType=@BillType and ID=@ID"
#End Region

#Region "检查对账日期前未审核的送货单"
    ''' <summary>
    ''' 检查对账日期前未审核的送货单,出错则返回-1
    ''' </summary>
    ''' <param name="Client_ID"></param>
    ''' <param name="bDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CBalance_CountUnAudited(ByVal Client_ID As Integer, ByVal bDate As Date) As Integer
        Dim sql As String = "select count(*) as UnAudited from T40000_BZSH_Table where Client_ID=@Client_ID and state>=0 and  State <2 and BZSH_Date<@Balance_Date and isnull(Balance_ID,'')=''"
        Dim p As New Dictionary(Of String, Object)
        p.Add("Client_ID", Client_ID)
        p.Add("Balance_Date", bDate)
        Dim R As DtReturnMsg = SqlStrToDt(sql, p)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Return R.Dt.Rows(0)("UnAudited")
        Else
            Return -1
        End If


    End Function
#End Region

#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取结算单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Balance_GetByid, "@ID", sId)
    End Function
    ''' <summary>
    ''' 获取对账单的明细
    ''' </summary>
    ''' <param name="Client_ID"></param>
    ''' <param name="sDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_SelListById(ByVal Client_ID As String, ByVal sDate As Date) As DtReturnMsg
        Dim para As New Dictionary(Of String, Object)
        para.Add("@Client_ID", Client_ID)
        para.Add("@Balance_Date", sDate)
        Dim msg As DtReturnMsg = PClass.PClass.SqlStrToDt("select * from  F50100_GetCBalanceList(@Balance_Date,@Client_ID) order by  sDate,sID,Line ", para)
        If msg.IsOk Then
            msg.Dt.Columns.Add("BZ", GetType(String))
            msg.Dt.Columns.Add("BZC", GetType(String))
            For Each R As DataRow In msg.Dt.Rows
                If IsNull(R("Client_Bzc"), "") <> "" Then
                    R("Client_Bzc") = R("Client_Bzc") & "#"
                End If
                If IsNull(R("BZ_No"), "").ToString.Contains("#") = False Then
                    R("BZ_No") = ""
                End If
            
                R("BZ") = R("BZ_No") & R("BZ_Name")

                R("BZC") = R("Client_BZC") & R("BZC_Name") & "GY" & Format(R("BZC_No"), "000000") & R("BZC_PF")
            Next
        End If
        Return msg
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_SelListById_AfterLock(ByVal _ID As String) As DtReturnMsg
        Dim para As New Dictionary(Of String, Object)
        para.Add("ID", _ID)

        Dim msg As DtReturnMsg = PClass.PClass.SqlStrToDt("select * from  T50101_CBalance_List where ID=@ID order by ID,Line ", para)
        If msg.IsOk Then
            msg.Dt.Columns.Add("BZ", GetType(String))
            msg.Dt.Columns.Add("BZC", GetType(String))
            For Each R As DataRow In msg.Dt.Rows
                If IsNull(R("Client_Bzc"), "") <> "" Then
                    R("Client_Bzc") = R("Client_Bzc") & "#"
                End If
                If IsNull(R("BZ_No"), "").ToString.Contains("#") = False Then
                    R("BZ_No") = ""
                End If

                R("BZ") = R("BZ_No") & R("BZ_Name")

                R("BZC") = R("Client_BZC") & R("BZC_Name") & "GY" & R("BZC_No") & R("BZC_PF")
            Next
        End If
        Return msg
    End Function
#End Region

#Region "获取上次对账"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CBalance_GetLast_BalanceDate(ByVal _ID As String) As Date
        Dim sql As String = "select  top 1 Balance_Date from T50100_CBalance_Table where Client_ID=3 and State=1 ID<>@ID order by Balance_Date desc"
        Dim R As DtReturnMsg = SqlStrToDt(sql, "ID", _ID)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            Return R.Dt.Rows(0)("Balance_Date")
        Else
            Return New Date(1999, 1, 1)

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
    Public Shared Function Balance_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_Balance_CheckIsModify, P)
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
    Public Shared Function Balance_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_Balance_CheckID, "@ID", ID)
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
    ''' 检查是否可以保存
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_CheckSave(ByVal ID As String, ByVal client_ID As String, ByVal Balance_Date As Date) As MsgReturn
        Dim sqlBuider As New StringBuilder
        sqlBuider.AppendLine(" declare @sID varchar(20) ")
        sqlBuider.AppendLine(" declare @bDate varchar(20) ")
        sqlBuider.AppendLine(" declare @Rstr varchar(2000) ")
        sqlBuider.AppendLine(" set  @Rstr ='' ")
        sqlBuider.AppendLine(" set @sID=isnull((Select top 1 ID from T50100_CBalance_Table where ID<>@ID and Client_ID=@Client_ID and State between 0 and 1 order by sdate desc),'') ")
        sqlBuider.AppendLine(" (select top 1 @bDate= Balance_Date   from T10110_Client where ID=@Client_ID and isnull(Balance_Date,'1999-1-1')>= @Balance_Date) ")
        sqlBuider.AppendLine(" if  @sID <>'' ")
        sqlBuider.AppendLine(" set  @Rstr=@Rstr+ '新单号['+@ID+']前有旧的对账单['+@sID+']还没审核，故新的对账单不能保存！'+Char(13) ")
        sqlBuider.AppendLine(" if isnull(@bDate,'')<>'' ")
        sqlBuider.AppendLine(" set  @Rstr=@Rstr+ '新单号['+@ID+']对账日期小于客户最近的对账日期['+isnull(@bDate,'')+']，故新的对账单不能保存！' ")
        sqlBuider.AppendLine(" if @Rstr='' ")
        sqlBuider.AppendLine(" set @Rstr='1对账单保存成功！' ")
        sqlBuider.AppendLine(" else  ")
        sqlBuider.AppendLine("  set @Rstr='2对账单保存失败！错误：'+Char(13)+@Rstr ")
        sqlBuider.AppendLine(" select @Rstr ")

        Dim p As New Dictionary(Of String, Object)
        p.Add("@ID", ID)
        p.Add("@Client_ID", client_ID)
        p.Add("@Balance_Date", Balance_Date)
        Dim R As MsgReturn = SqlStrToOneStr(sqlBuider.ToString, p)
        Return R
    End Function


    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_Lock(ByVal ID As String, ByVal isLock As Boolean, ByVal stateUser As String) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("isLock", isLock)
        P.Add("State_User", stateUser)
        Return SqlStrToOneStr("P50100_Balance_Lock", P, True)

    End Function

    ''' <summary>
    ''' 添加送货对账单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_Add(ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BalanceId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", BalanceId)
        Try
            sqlMap.Add("Table", SQL_Balance_GetByid)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)

                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & BalanceId & "'," & BillType.BZSH_Balance & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & Balance_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Balance_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Balance_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改入库单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_Save(ByVal LID As String, ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BalanceId As String = dtTable.Rows(0)("ID")
        If LID <> BalanceId AndAlso Balance_CheckID(BalanceId) Then
            R.IsOk = False
            R.Msg = "" & Balance_DB_NAME & "[" & BalanceId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)
        Try
            sqlMap.Add("Table", SQL_Balance_GetByid)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = 2 Then
                    msg.DaList("Table").Dispose()

                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & Balance_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()

                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & Balance_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If

                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & BalanceId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.BZSH_Balance
                If LID <> BalanceId Then
                    DtToUpDate(msg, "Update T50100_CBalance_Table set id='" & BalanceId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = BalanceId
                    R.Msg = "" & Balance_DB_NAME & "[" & LID & "]已经修改为[" & BalanceId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & Balance_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Balance_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Balance_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除入库单
    ''' </summary>
    ''' <param name="BalanceId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_Del(ByVal BalanceId As String)
        Return RunSQL(SQL_Balance_DelByid, "@ID", BalanceId)
    End Function


    ''' <summary>
    ''' 作废入库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_InValid(ByVal _ID As String, ByVal IsFei As Boolean, ByVal remark As String) As MsgReturn
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

            sqlMap.Add("Table", SQL_Balance_GetStateByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        If remark = "" Then
                            paraMap.Add("Remark", msg.DtList("Table").Rows(0)("Remark"))
                        Else
                            paraMap.Add("Remark", remark)
                        End If
                        If IsFei = False Then
                            'paraMap = New Dictionary(Of String, Object)
                            ' paraMap.Add("@ID", msg.Dt.Rows(0)("ID"))
                            paraMap.Add("@Client_ID", msg.DtList("Table").Rows(0)("Client_ID"))
                            paraMap.Add("@State_User", User_Display)
                            Dim sqlBuider As New StringBuilder
                            sqlBuider.Append("declare @sID varchar(20)")
                            sqlBuider.AppendLine("set @sID=(Select top 1 ID from T50100_CBalance_Table where (Client_ID=@Client_ID and state>=0) or (id=@ID and state=-1) order by sdate desc)")
                            sqlBuider.AppendLine(" if @sID=@ID ")
                            sqlBuider.AppendLine(" Begin ")
                            sqlBuider.AppendLine(" Update T50100_CBalance_Table set State=0 ,State_User=@State_User,Remark=@Remark where ID =@ID ")
                            sqlBuider.AppendLine("select '1反作废成功！' end ")
                            sqlBuider.AppendLine(" else ")
                            sqlBuider.AppendLine(" select '0反作废失败！错误：单号['+@ID+']后有新的对账单['+@sID+']，故旧的对账单不能反作废！' ")
                            R = SqlStrToOneStr(sqlBuider.ToString, paraMap)
                            If R.IsOk Then
                                If R.Msg.StartsWith(1) Then
                                    R.Msg = R.Msg.Substring(1)
                                Else
                                    R.IsOk = False
                                    R.Msg = R.Msg.Substring(1)
                                End If

                            End If

                        Else

                            msg.DtList("Table").Rows(0)("State") = State
                            msg.DtList("Table").Rows(0)("State_User") = User_Display
                            msg.DtList("Table").Rows(0)("Remark") = remark
                            DtToUpDate(msg)
                            R.IsOk = True
                            R.Msg = "" & Balance_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                        End If
                    Else
                        R.IsOk = False
                        R.Msg = "" & Balance_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & Balance_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & Balance_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Balance_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function




    ''' <summary>
    ''' 审核对账单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核和反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Balance_Audited(ByVal _ID As String, ByVal IsAudited As Boolean, Optional ByVal remark As String = "") As MsgReturn
        Dim R As New MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)

        Dim msg As DtReturnMsg = Balance_GetById(_ID)
        If msg.IsOk Then
            Dim _State As Integer = msg.Dt.Rows(0)("State")
            If remark = "" Then
                paraMap.Add("Remark", msg.Dt.Rows(0)("Remark"))
            Else
                paraMap.Add("Remark", remark)
            End If
            If _State = 1 AndAlso IsAudited = True Then
                R = SqlStrToOneStr("Update T50100_CBalance_Table set State=2 ,State_User=@State_User,Remark=@Remark where ID =@ID", paraMap)
                R.Msg = "审核成功！"
            ElseIf _State = 2 AndAlso IsAudited = False Then
                'paraMap = New Dictionary(Of String, Object)
                'paraMap.Add("@ID", msg.Dt.Rows(0)("ID"))
                paraMap.Add("@Client_ID", msg.Dt.Rows(0)("Client_ID"))
                Dim sqlBuider As New StringBuilder
                sqlBuider.Append("declare @sID varchar(20)")
                sqlBuider.AppendLine("set @sID=(Select top 1 ID from T50100_CBalance_Table where Client_ID=@Client_ID and state>=0 order by sdate desc)")
                sqlBuider.AppendLine(" if @sID=@ID ")
                sqlBuider.AppendLine(" Begin ")
                sqlBuider.AppendLine(" Update T50100_CBalance_Table set State=1 ,State_User=@State_User,Remark=@Remark  where ID =@ID ")
                sqlBuider.AppendLine("select '1反审核成功！' end ")
                sqlBuider.AppendLine(" else ")
                sqlBuider.AppendLine(" select '0反审核失败！错误：单号['+@ID+']后有新的对账单['+@sID+']，故旧的对账单不能反审核！' ")
                R = SqlStrToOneStr(sqlBuider.ToString, paraMap)
                If R.IsOk Then
                    If R.Msg.StartsWith(1) Then
                        R.Msg = R.Msg.Substring(1)
                    Else
                        R.IsOk = False
                        R.Msg = R.Msg.Substring(1)
                    End If
                End If
            Else
                R.Msg = IIf(IsAudited, "审核", "反审") & "失败！单据没有被锁定！"
            End If
        End If

        Return R
    End Function




#End Region

End Class