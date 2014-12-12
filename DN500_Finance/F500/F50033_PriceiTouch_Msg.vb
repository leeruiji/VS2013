Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F50033_PriceiTouch_Msg
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
        ID = 50201
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Price)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID_Prefix(BillType.Price, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Dao.Price_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        If Bill_ID = "" AndAlso P_F_RS_ID2 <> "" Then
            Bill_ID = P_F_RS_ID
        End If
     FG1.Cols("SGGY_No").Editor = CB_SG_FG

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
        Cmd_Preview.Enabled = False
        Cmd_Preview_CK.Enabled = False
        Cmd_Print.Enabled = False
        Cmd_Print_CK.Enabled = False
        dtTable.Rows(0)("State") = Enum_State.AddNew
        SetForm(dtTable)
        GetNewID()
        Cmd_Copy.Visible = False

    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.InneriTouch_GetById(Bill_ID)
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
                Dim msg As DtReturnMsg = Dao.InneriTouch_SelListById_All(0)
                If msg.IsOk Then dtList = msg.Dt
                FG1.Rows.Count = 1
                FG1.ReAddIndex()
                TB_Upd_User.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Preview_CK.Enabled = False
                Cmd_Print.Enabled = False
                Cmd_Preview_CK.Enabled = False
                GetNewID()
            Case Mode_Enum.Modify
                CB_Client.Enabled = False
                Dim msg As DtReturnMsg = Dao.InneriTouch_SelListById_All(Bill_ID)
                Cmd_Preview.Enabled = True
                Cmd_Preview_CK.Enabled = True
                Cmd_Print.Enabled = True
                Cmd_Preview_CK.Enabled = True
                TB_ID.ReadOnly = True
                If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                    dtList = msg.Dt
                    LastLine = msg.Dt.Rows(0)("Line")

                    Fg1.DtToSetFG(msg.Dt)
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
                Cmd_paste.Enabled = True
                FG1.CanEditing = True
                FG1.Cols("IsLastPrice").Visible = False
                FG1.Cols("Price_Time").Visible = False
                For i As Integer = 1 To FG1.Rows.Count - 1
                    'If FG1.Item(i, "IsComfirm") = False AndAlso FG1.Item(i, "IsLastPrice") = True Then
                    '    'If dtList.Select("BZc_ID=" & FG1.Item(i, "BZc_ID") & " and  BZ_ID=" & FG1.Item(i, "BZ_ID") & " and IsComfirm=1").Length = 0 Then
                    '    '    FG1.Rows(i).Visible = True
                    '    'Else
                    '    '    FG1.Rows(i).Visible = False
                    '    'End If

                    'Else
                    '    FG1.Rows(i).Visible = False
                    'End If
                Next
            Case 1
                Cmd_Modify.Enabled = True
                Cmd_Price.Enabled = False
                Cmd_AddRow.Enabled = False
                Cmd_RemoveRow.Enabled = True
                Cmd_paste.Enabled = False
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
                Cmd_paste.Enabled = False
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
        For i As Integer = 1 To Fg1.Rows.Count - 1
            'bzcID = Val(FG1.Item(i, FG1.Cols("BZC_ID").Index))
            sgID = Fg1.Item(i, Fg1.Cols("SG_ID").Index)
            If Val(sgID) = 0 Then
                Continue For
            End If
          
            dr = _dtList.NewRow

           
            dr("ID") = TB_ID.Text

            dr("SG_ID") = sgID
            dr("IsComfirm") = IIf(Fg1.Item(i, "IsComfirm") Is Nothing, False, Fg1.Item(i, "IsComfirm"))
          
            dr("Price") = Val(Fg1.Item(i, Fg1.Cols("Price").Index))
          
            dr("Cost") = Val(Fg1.Item(i, Fg1.Cols("Cost").Index))
            dr("LRemark") = Fg1.Item(i, "LRemark")
            dr("ProcessSort") = Fg1.Item(i, "SGGY_GSD")
            If Mode = Mode_Enum.Add Then
                dr("IsLastPrice") = True
                dr("Price_Time") = serverTiume
            ElseIf Mode = Mode_Enum.Modify Then
                If Fg1.Rows(i).Visible = True Then
                    If isPrice Then
                        Try
                            Dim sDr As DataRow = dtList.Select("Line =" & Fg1.Item(Fg1.RowSel, "Line"))(0)
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

                    dr("IsLastPrice") = Fg1.Item(i, Fg1.Cols("IsLastPrice").Index)
                    dr("Price_Time") = Fg1.Item(i, Fg1.Cols("Price_Time").Index)
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
                    Cmd_paste.Visible = True
                    Cmd_paste.Enabled = True
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

                    Cmd_paste.Visible = False
                    Cmd_paste.Enabled = False
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
        Fg1.CanEditing = Not Lock
        Fg1.IsClickStartEdit = Not Lock
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
        For i As Int16 = 1 To Fg1.Rows.Count - 1
            If Fg1.Item(i, "IsComfirm") = True Then
                sumComfirm += 1
            ElseIf Fg1.Item(i, "IsLastPrice") = True Then
                sumUnComfirm += 1
            End If
        Next
        TB_Qty_Comfirm.Text = sumComfirm
        TB_Qty_UnComfirm.Text = sumUnComfirm


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
            R = Dao.InneriTouch_Add(Dt, dtList)
        Else
            R = Dao.InneriTouch_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If IsProcess Then
                Print(OperatorType.Preview, False, False)
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

        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.Price_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If




        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg1.Item(i, "SGGY_No")) = 0 Then
                    Fg1.RemoveItem(i)
                End If

            Catch ex As Exception
            End Try
        Next

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
        If e.Row < 0 Then
            Exit Sub
        End If

        Select Case Fg1.Cols(e.Col).Name
            Case "IsComfirm"

            Case "Ds_Ding"
                If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell(Fg1.Cols("Ds_Ding").Index)
            Case "Price"
                If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell(Fg1.Cols("Price").Index)

        End Select
        If Fg1.LastKey = Keys.Enter Then
            Fg1.LastKey = 0
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
        Fg1.AddRow()
        Fg1.Item(Fg1.Rows.Count - 1, "IsComfirm") = False
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        If Fg1.RowSel < 1 Then
            Exit Sub
        End If
        If Fg1.Item(Fg1.RowSel, "IsComfirm") Then
            Fg1.Item(Fg1.RowSel, "IsComfirm") = False
            SetFg1Show()
        Else
            Fg1.RemoveRow()
        End If

    End Sub

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell

        Select Case e.Col


            Case "SGGY_Name"
                e.ToCol = Fg1.Cols("Ds_Ding").Index

            Case "Ds_Ding"
                e.ToCol = Fg1.Cols("Price").Index

            Case "Price"
                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("SGGY_No").Index
            Case Else

        End Select
    End Sub

    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs)
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If

    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing = False Then

        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Click
        Try
            If Fg1.ColSel = Fg1.Cols("IsComfirm").Index Then
                Fg1.Item(Fg1.RowSel, "IsComfirm") = Not Fg1.Item(Fg1.RowSel, "IsComfirm")
            End If
        Catch ex As Exception
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
            ComFun.DelBillNewID(BillType.PurchaseReturn, Bill_ID)
            Bill_ID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        Dao.Price_DB_NAME = Ch_Name
        If TB_ID.ReadOnly = False Then
            '  If DTP_sDate.Value <> Bill_ID_Date Then
            Dim prefix As String = IIf(TB_Client_Name.Tag Is Nothing, "BJ", TB_Client_Name.Tag)
            Dim R As RetrunNewIdMsg = ComFun.GetBillNewID_Prefix(BillType.Price, DTP_sDate.Value, Bill_ID, prefix, 4)
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

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview, False, False)
    End Sub

    Private Sub Cmd_Preview_Un_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview_Un.Click
        Print(OperatorType.Preview, False, True)
    End Sub

    Private Sub Cmd_Preview_CK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview_CK.Click
        Print(OperatorType.Preview, True, False)
    End Sub

    Private Sub Cmd_Preview_Un_Ck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview_Un_Ck.Click
        Print(OperatorType.Preview, True, True)
    End Sub



    Private Sub Cmd_print_Un_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print_Un.Click
        Print(OperatorType.Print, False, True)
    End Sub


    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print, False, False)
    End Sub

    Private Sub Cmd_Print_CK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print_CK.Click
        Print(OperatorType.Print, True, False)
    End Sub

    Private Sub Cmd_Print_Un_CK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print_Un_CK.Click
        Print(OperatorType.Print, True, True)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType, ByVal CK As Boolean, ByVal UComfirm As Boolean)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If

        Dim R As New R50032_SGiTouch
        R.StartList(TB_ID.Text, DoOperator, CK, UComfirm)
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
        Dim msg As MsgReturn = Dao.InneriTouch_Audited(TB_ID.Text, True)
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
        Dim msg As MsgReturn = Dao.InneriTouch_Audited(TB_ID.Text, False)
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
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelPrice)
    End Sub

    ''' <summary>
    ''' 删除出库单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelPrice()
        Dao.Price_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.InneriTouch_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf PriceInValid)
    End Sub


    Sub PriceInValid()
        Dao.Price_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.InneriTouch_InValid(TB_ID.Text, True)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf PriceValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub PriceValid()
        Dao.Price_DB_NAME = Ch_Name
        Dim msg As MsgReturn = Dao.InneriTouch_InValid(TB_ID.Text, False)
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


#Region "SG选择"
    Dim IsBZSelect As Boolean

    Private Sub CB_SG_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_SG_FG.Col_Sel
        IsBZSelect = True
        Fg1.Item(Fg1.RowSel, "SGGY_Name") = Col_Name
        Fg1.Item(Fg1.RowSel, "SG_ID") = ID
        Fg1.Item(Fg1.RowSel, "IsLastPrice") = True
        Dim SumCost As Double = 0
        Dim R As DtReturnMsg = Dao.SG_GetById(Fg1.Item(Fg1.RowSel, "SG_ID"))
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then

            Fg1.Item(Fg1.RowSel, "SGGY_GSD") = R.Dt.Rows(0)("SGGY_GSD")
        Else
            ShowErrMsg("该手感没有杂色配方！")
        End If
        Dim msg As DtReturnMsg = Dao.Price_GetSGCost_ByID(Fg1.Item(Fg1.RowSel, "SG_ID"))
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            SumCost = IsNull(msg.Dt.Rows(0)("Cost"), 0)
            Fg1.Item(Fg1.RowSel, "Cost") = SumCost * 10
            Fg1.Item(Fg1.RowSel, "Price") = SumCost * 10.5
        Else
            ShowErrMsg("该手感没有杂色配方！")
        End If
        Fg1.GotoNextCell("Cost")
    End Sub

    Private Sub CB_SG_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_SG_FG.GetSearchEvent
        If CB_Client.IDAsInt <> 0 Then
            CB_SG_FG.SearchType = cSearchType.ENum_SearchType.Client
            CB_SG_FG.SearchID = CB_Client.IDAsInt
        Else
            CB_SG_FG.SearchType = cSearchType.ENum_SearchType.ALL
            CB_SG_FG.SearchID = CB_Client.IDAsInt
        End If

        CB_SG_FG.IDValue = Fg1.Item(Fg1.RowSel, "SG_ID")
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
        Fg1.FinishEditing(False)
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
        Dim R As DtReturnMsg = ComFun.Clinet_GetBy_ID(ID)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            TB_Client_Name.Tag = IsNull(R.Dt.Rows(0)("Client_FindHelper"), "BJ")
        End If
        GetNewID()
    End Sub

    Private Sub Cmd_paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_paste.Click
        Dim T As String
        Dim Errmsg As New StringBuilder
        Dim list As Integer = 0
        Dim DT As New DataTable
        Dim C_Error As New DataColumn("Error", GetType(String))
        DT.Columns.Add(C_Error)
        Dim C_index As New DataColumn("index", GetType(Integer))
        DT.Columns.Add(C_index)
        T = Clipboard.GetText
        If T = "" Then
            ShowErrMsg("剪切板中没有内容!")
            Exit Sub
        End If

        Fg1.CanEditing = False
        Fg1.FinishEditing()
        Try
            Fg1.Rows.Count = 1


        Catch ex As Exception
        End Try

        Dim SP() As String = T.Split(vbLf & vbCr)
        Try
            For Each S As String In SP

                If S <> "" Then
                    Dim Sx() As String = S.Split(vbTab)
                    list += 1
                    'FG1.AddRow()
                    'For i As Integer = 1 To Sx.Length
                    '    Fg1.Item(Fg1.Rows.Count - 1, i) = Sx(i - 1).Replace(Chr(13), "").Replace(Chr(10), "")
                    'Next



                    'FG1.Item(FG1.Rows.Count - 1, "BZC_No") = IsNull(Sx(0), "") '色号
                    Dim BZC_No() As String = Sx(1).Split("-")
                    If Not BZC_No(1) Is Nothing And Val(BZC_No(1)) > 0 Then

                        Fg1.AddRow()

                    End If



                    Dim BzcMsg As DtReturnMsg = Dao.BZC_With_BZBYBZ_No(Val(BZC_No(1).ToString))
                    Fg1.Item(Fg1.Rows.Count - 1, "IsComfirm") = True
                    If BzcMsg.IsOk = True Then
                        Select Case BzcMsg.Dt.Rows.Count
                            Case 0
                                Dim dr As DataRow = DT.NewRow

                                ''FG1.RemoveItem(FG1.Rows.Count - 1)
                                ''Errmsg.Append(Val(BZC_No(1).ToString) & vbLf & vbCr)
                                dr("Error") = BZC_No(1).ToString & ":数据库没有这个色号"
                                dr("index") = list
                                DT.Rows.Add(dr)
                                Continue For

                            Case 1

                                Fg1.Item(Fg1.Rows.Count - 1, "BZC_No") = Val(BZC_No(1).ToString)
                                Fg1.Item(Fg1.Rows.Count - 1, "BZC_Name") = BzcMsg.Dt.Rows(0)("BZC_Name")
                                Fg1.Item(Fg1.Rows.Count - 1, "BZC_ID") = BzcMsg.Dt.Rows(0)("BZC_ID")
                                Fg1.Item(Fg1.Rows.Count - 1, "BZ_ID") = BzcMsg.Dt.Rows(0)("BZ_ID")
                                Fg1.Item(Fg1.Rows.Count - 1, "BZ_No") = BzcMsg.Dt.Rows(0)("BZ_No")
                                Fg1.Item(Fg1.Rows.Count - 1, "BZ_Name") = BzcMsg.Dt.Rows(0)("BZ_Name")

                        End Select

                    End If

                    Fg1.Item(Fg1.Rows.Count - 1, "Client_Bzc") = IsNull(Sx(2), "") '客户色号
                    Fg1.Item(Fg1.Rows.Count - 1, "Ds_Ding") = IsNull(Sx(4), "")     '单定/双定
                    Fg1.Item(Fg1.Rows.Count - 1, "Price") = FormatMoney(Val(Sx(5)))  '报价
                    Fg1.Item(Fg1.Rows.Count - 1, "LRemark") = IsNull(Sx(6), "") '备注




                    'S = FG1.Rows.Count & vbTab & Sx(0) & vbTab & Sx(1) & vbTab & Sx(2).Replace(Chr(13), "").Replace(Chr(10), "")
                End If
            Next
        Catch ex As Exception

        End Try
        Fg1.ReAddIndex()
        Fg1.CanEditing = True
        If DT.Rows.Count > 0 Then
            Dim F As wrong = New wrong(DT)
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F)
            VF.Show()
        End If
    End Sub



End Class

Partial Friend Class Dao

    Private Const SQL_InneriTouch_GetSort As String = "Select ProcessSort,Price from T50020_ProcessSort "

    Public Shared Function InneriTouch_GetSort() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_InneriTouch_GetSort)
    End Function

#Region "常量"
    Protected Friend Shared InneriTouch_DB_NAME As String = "手感报价单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InneriTouch_DelByid As String = "Delete from T50012_SGPrice_Table  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InneriTouch_GetByid As String = "select top 1 * from T50012_SGPrice_Table  where ID=@ID "

    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InneriTouch_GetByid_WithName As String = "select top 1 T. * ,C.Client_No,C.Client_Name from T50012_SGPrice_Table T Left join T10110_Client C on T.Client_ID=C.ID  where T.ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InneriTouch_SelByid As String = " select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name ,C.Client_Name ,C.Client_No" & _
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
    Private Const SQL_InneriTouch_GetStateByid As String = "select top 1 ID,State,State_User,Produce_ID from T50012_SGPrice_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InneriTouch_GetListByid As String = "select * from T50013_SGPrice_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_InneriTouch_SelListByid As String = " select L.*,SGGY_No,SGGY_Name ,SGGY_GSD " & _
                                                            "  from  T50013_SGPrice_List L   " & _
                                                            "   left join T10035_SGGY SG on L.SG_ID=SG.ID  " & _
                                                            " where L.ID=@ID  order by L.ID,L.Line  "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    ''' 
    Private Const SQL_InneriTouch_SelListByid_ShowComfirm As String = " select L.ID,L.LRemark ,L.Price ,L.ProcessSort ,L.Price_Time ,SGGY_No,SGGY_Name,WL.WL_Spec ,WL.WL_Name +'/'+WL.WL_No AS WL,YL.Qty,SUM(WL.WL_Price * YL.Qty*1000 ) AS Amount " & _
                                                          "  from  T50013_SGPrice_List L   left join T10035_SGGY SG on L.SG_ID=SG.ID  " & _
                                                          "  left join T10036_SGGYList YL ON YL.ID =SG .ID AND YL.Color ='杂色'  LEFT JOIN T10001_WL WL ON WL.ID =YL.WL_ID " & _
                                                          " where L.ID=@ID and L.IsComfirm=0 and IsLastPrice=1 GROUP BY L.Line ,L.ID,L.LRemark ,L.Price ,L.ProcessSort ,L.Price_Time ,SG.SGGY_No,SG.SGGY_Name,YL.Qty ,WL_Spec,WL.WL_Name ,WL.WL_No order by L.ID ,L.Line "



    Private Const SQL_InneriTouch_SelListByid_ALL As String = "select L.ID,L.LRemark ,L.Price ,L.ProcessSort ,L.Price_Time ,SGGY_No,SGGY_Name,WL.WL_Spec ,WL.WL_Name +'/'+WL.WL_No AS WL,YL.Qty,SUM(WL.WL_Price * YL.Qty*1000 ) AS Amount   " & _
                                                          "  from  T50013_SGPrice_List L   left join T10035_SGGY SG on L.SG_ID=SG.ID  " & _
                                                          "  left join T10036_SGGYList YL ON YL.ID =SG .ID  AND YL.Color ='杂色'  LEFT JOIN T10001_WL WL ON WL.ID =YL.WL_ID " & _
                                                         " where L.ID=@ID and IsLastPrice=1 GROUP BY L.Line ,L.ID,L.LRemark ,L.Price ,L.ProcessSort ,L.Price_Time ,SG.SGGY_No,SG.SGGY_Name,YL.Qty ,WL_Spec,WL.WL_Name ,WL.WL_No order by L.ID ,L.Line "







    'Private Const SQL_Process_SelListByid_ShowComfirm As String = " select L.*,BZC_No,BZC_Name,Client_Bzc,BZC_Name+'/'+CAST(BZC_No as Varchar(20))  as BZC, BZ_No,BZ_Name " & _
    '                                                        "  from  T50001_Process_List L left join T10003_BZC BZC on L.BZC_ID=BZC.ID  " & _
    '                                                        "   left join T10002_BZ BZ on L.BZ_ID=BZ.ID " & _
    '                                                        " where L.ID=@ID and L.IsComfirm=@IsComfirm and IsLastProcess=1 order by L.ID ,L.Line "


    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InneriTouch_CheckID As String = "select count(*) from T50012_SGPrice_Table  where ID=@ID"

    '''' <summary>
    '''' 获取加工单列表,用于显示
    '''' </summary>
    '''' <remarks></remarks>0

    '  Private Const SQL_Produce_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InneriTouch_CheckIsModify As String = "select count(*) from T50013_SGPrice_List where ID=@ID and Line=@Line"






#End Region

#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对出库单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InneriTouch_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_InneriTouch_GetByid_WithName, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对出库单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InneriTouch_SelListById(ByVal sId As String, ByVal UnComfirm As Boolean) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", sId)

        If UnComfirm Then
            Return PClass.PClass.SqlStrToDt(SQL_InneriTouch_SelListByid_ShowComfirm, p)
        Else
            Return PClass.PClass.SqlStrToDt(SQL_InneriTouch_SelListByid_ALL, p)
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
    Public Shared Function InneriTouch_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_InneriTouch_CheckIsModify, P)
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
    Public Shared Function InneriTouch_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_Process_CheckID, "@ID", ID)
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
    Public Shared Function InneriTouch_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProcessId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ProcessId)
        Try

            sqlMap.Add("Table", SQL_InneriTouch_GetByid)
            sqlMap.Add("List", SQL_InneriTouch_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & ProcessId & "'," & BillType.IniTouch & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & InneriTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & InneriTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & InneriTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
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
    Public Shared Function InneriTouch_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ProcessId As String = dtTable.Rows(0)("ID")
        If LID <> ProcessId AndAlso Process_CheckID(ProcessId) Then
            R.IsOk = False
            R.Msg = "" & InneriTouch_DB_NAME & "[" & ProcessId & "]已经存在!请双击编号文本框,获取新编号!"
            Return R
        End If
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)
        Try
            sqlMap.Add("Table", SQL_InneriTouch_GetByid)
            sqlMap.Add("List", SQL_InneriTouch_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then


                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & InneriTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & InneriTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & ProcessId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.IniTouch
                If LID <> ProcessId Then
                    DtToUpDate(msg, "Update T50012_SGPrice_Table set id='" & ProcessId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = ProcessId
                    R.Msg = "" & InneriTouch_DB_NAME & "[" & LID & "]已经修改为[" & ProcessId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & InneriTouch_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & InneriTouch_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & InneriTouch_DB_NAME & "[" & LID & "]修改错误"
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
    Public Shared Function InneriTouch_Del(ByVal ProcessId As String)
        Return RunSQL(SQL_InneriTouch_DelByid, "@ID", ProcessId)
    End Function

    ''' <summary>
    ''' 作废出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InneriTouch_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("State", IIf(IsFei, -1, 0))
        paraMap.Add("State_User", User_Display)

        Dim R As MsgReturn = SqlStrToOneStr("Update T50012_SGPrice_Table set State=@State,State_User=@State_User where ID=@ID  ", paraMap)
        Dim s As String = IIf(IsFei, "作废", "还原")
        If R.IsOk Then
            R.Msg = InneriTouch_DB_NAME & s & "成功！"
        Else
            R.Msg = InneriTouch_DB_NAME & s & "失败！" & R.Msg

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
    Public Shared Function InneriTouch_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
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
            R.Msg = InneriTouch_DB_NAME & s & "失败！[" & _ID & "]已被" & s
            Return R
        End If

        R = SqlStrToOneStr("Update T50012_SGPrice_Table set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)

        If R.IsOk Then
            R.Msg = InneriTouch_DB_NAME & s & "成功！"
        Else
            R.Msg = InneriTouch_DB_NAME & s & "失败！" & R.Msg

        End If

        Return R
    End Function
#End Region

    ''' <summary>
    ''' 根据色号获取颜色布类
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Shared Function InneriTouch_SelListById_All(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_InneriTouch_SelListByid, "@ID", sId)
    End Function

#Region "根据色号获取染部配方成本"
    ''' <summary>
    ''' 根据色号获取染部配方成本
    ''' </summary>
    ''' <param name="BZC_ID"></param>
    ''' <param name="BZ_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InneriTouch_GetPFCost_ByBZC(ByVal BZC_ID As Integer, ByVal BZ_ID As Integer) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZC_ID", BZC_ID)
        P.Add("BZ_ID", BZ_ID)
        Return SqlStrToDt(SQL_RBPF_PF_GeList_WithName, P)
    End Function
#End Region

End Class


'Partial Friend Class Dao
'#Region "常量"
'    Protected Friend Shared PriceiTouch_DB_NAME As String = "报价单"
'    ''' <summary>
'    ''' 删除单据
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_DelByid As String = "Delete from T50000_PriceiTouch_Table  where ID=@ID and State=0"
'    ''' <summary>
'    ''' 获取单头
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_GetByid As String = "select top 1 * from T50000_PriceiTouch_Table  where ID=@ID "

'    ''' <summary>
'    ''' 获取单头
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_GetByid_WithName As String = "select top 1 T. * ,C.Client_No,C.Client_Name from T50000_PriceiTouch_Table T Left join T10110_Client C on T.Client_ID=C.ID  where T.ID=@ID "
'    ''' <summary>
'    ''' 获取单头
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_SelByid As String = " select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name ,C.Client_Name ,C.Client_No" & _
'                                                   " from T50000_PriceiTouch_Table S " & _
'                                                    " left join T15001_Employee E on S.Operator=E.ID " & _
'                                                    "left join T15000_Department W on S.Dept_No=W.Dept_No " & _
'                                                    "left join T10110_Client C on S.Client_ID=C.ID " & _
'                                                     "where S.ID=@ID "
'    'select top 1 S.*,E.Employee_Name as OperatorName ,W.Dept_Name as Dept_Name from T50000_PriceiTouch_Table S  left join T15001_Employee E on S.Operator=E.ID left join T15000_Department W on S.Dept_No=W.Dept_No where S.ID=@ID"


'    ''' <summary>
'    ''' 获取单头 用于作废和审核
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_GetStateByid As String = "select top 1 ID,State,State_User,Produce_ID from T50000_PriceiTouch_Table  where ID=@ID"
'    ''' <summary>
'    ''' 获取单体
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_GetListByid As String = "select * from T50001_PriceiTouch_List  where ID=@ID "
'    ''' <summary>
'    ''' 获取单体,用于显示
'    ''' </summary>
'    ''' <remarks></remarks>0
'    Private Const SQL_PriceiTouch_SelListByid As String = " select L.*,BZC_No,BZC_Name,BZ_No,Client_Bzc,BZ_Name " & _
'                                                            "  from  T50001_PriceiTouch_List L left join T10003_BZC BZC on L.BZC_ID=BZC.ID  " & _
'                                                            "   left join T10002_BZ BZ on L.BZ_ID=BZ.ID " & _
'                                                            " where L.ID=@ID  order by L.ID,L.Line "
'    ''' <summary>
'    ''' 获取单体,用于显示
'    ''' </summary>
'    ''' <remarks></remarks>0
'    ''' 
'    Private Const SQL_PriceiTouch_SelListByid_ShowComfirm As String = " select L.*,BZC_No,BZC_Name,Client_Bzc,BZC_Name+'/GY-'+right('000000'+CAST(BZC_No as Varchar(20)),6)  as BZC, BZ_No,BZ_Name " & _
'                                                          "  from  T50001_PriceiTouch_List L left join T10003_BZC BZC on L.BZC_ID=BZC.ID  " & _
'                                                          "   left join T10002_BZ BZ on L.BZ_ID=BZ.ID " & _
'                                                          " where L.ID=@ID and IsLastPriceiTouch=1 order by L.ID ,L.Line "










'    'Private Const SQL_PriceiTouch_SelListByid_ShowComfirm As String = " select L.*,BZC_No,BZC_Name,Client_Bzc,BZC_Name+'/'+CAST(BZC_No as Varchar(20))  as BZC, BZ_No,BZ_Name " & _
'    '                                                        "  from  T50001_PriceiTouch_List L left join T10003_BZC BZC on L.BZC_ID=BZC.ID  " & _
'    '                                                        "   left join T10002_BZ BZ on L.BZ_ID=BZ.ID " & _
'    '                                                        " where L.ID=@ID and L.IsComfirm=@IsComfirm and IsLastPriceiTouch=1 order by L.ID ,L.Line "


'    ''' <summary>
'    ''' 检查ID的重复性
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_CheckID As String = "select count(*) from T50000_PriceiTouch_Table  where ID=@ID"

'    '''' <summary>
'    '''' 获取加工单列表,用于显示
'    '''' </summary>
'    '''' <remarks></remarks>0

'    '  Private Const SQL_Produce_SelListByid As String = "select L.*,WL.WL_No,WL.WL_Name,WL.WL_Spec,WL.WL_Unit,WL.WL_Store_ID from (select * from T30011_Produce_List  where ID=@ID)L left join T10001_WL WL on WL.id=l.WL_id  where isnull(WL_Ignore,0)=0 order by WL.WL_Type_ID,WL.WL_Name"

'    ''' <summary>
'    ''' 检查ID的重复性
'    ''' </summary>
'    ''' <remarks></remarks>
'    Private Const SQL_PriceiTouch_CheckIsModify As String = "select count(*) from T50001_PriceiTouch_List  where ID=@ID and Line=@Line"

'    '''' <summary>
'    '''' 根据色号获取染部配方
'    '''' </summary>
'    '''' <remarks></remarks>
'    'Public Const SQL_RBPF_PF_GeList_WithName = "select Sum(W.WL_Cost) as Cost   from T10013_RB_PFList P  " & _
'    '         "left join T10001_WL W on P.WL_ID=W.ID where IsGY=0 and  BZC_ID=@BZC_ID and P.ID =(select top 1 PF_ID from ( " & _
'    '         " select PF_ID from T10003_BZC where  BZC_ID=@BZC_ID and BZ_ID=@BZ_ID and not  PF_ID is null " & _
'    '         " union all " & _
'    '         "select PF_ID from T10009_BzcLinkBz where BZC_ID=@BZC_ID and BZ_ID=@BZ_ID)T ) "

'    '''' <summary>
'    '''' 根据色号获取颜色布类
'    '''' </summary>
'    '''' <remarks></remarks>
'    'Public Const SQL_BZC_With_BZ = "  SELECT C.ID AS BZC_ID,C.BZC_No, C.BZC_Name, C.BZ_ID, Z.BZ_No, Z.BZ_Name " & _
'    '                                 "FROM T10003_BZC C LEFT OUTER JOIN " & _
'    '                                  " T10002_BZ Z ON C.BZ_ID = Z.ID " & _
'    '                                   " WHERE(C.BZC_No = @BZC_No)"






'#End Region

'#Region "单一张单内容查询"
'    ''' <summary>
'    ''' 获取对出库单信息
'    ''' </summary>
'    ''' <param name="sId"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_GetById(ByVal sId As String) As DtReturnMsg
'        Return PClass.PClass.SqlStrToDt(SQL_PriceiTouch_GetByid_WithName, "@ID", sId)
'    End Function

'    ''' <summary>
'    ''' 获取对出库单列表信息
'    ''' </summary>
'    ''' <param name="sId"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_SelListById(ByVal sId As String) As DtReturnMsg
'        Dim p As New Dictionary(Of String, Object)
'        p.Add("ID", sId)
'        Return PClass.PClass.SqlStrToDt(SQL_PriceiTouch_SelListByid_ShowComfirm, p)
'    End Function

'    '''' <summary>
'    '''' 获取对出库单列表信息
'    '''' </summary>
'    '''' <param name="sId"></param>
'    '''' <returns></returns>
'    '''' <remarks></remarks>
'    'Public Shared Function BZC_With_BZBYBZ_No(ByVal sId As String) As DtReturnMsg
'    '    Return PClass.PClass.SqlStrToDt(SQL_BZC_With_BZ, "@BZC_No", sId)
'    'End Function
'#End Region

'#Region "添加修改删除"

'    ''' <summary>
'    ''' 检查其他人有没有修改过
'    ''' </summary>
'    ''' <param name="ID"></param>
'    ''' <param name="Line"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
'        Dim P As New Dictionary(Of String, Object)
'        P.Add("ID", ID)
'        P.Add("Line", Line)
'        Dim R As MsgReturn = SqlStrToOneStr(SQL_PriceiTouch_CheckIsModify, P)
'        If R.IsOk Then
'            If Val(R.Msg) = 0 Then
'                Return True
'            Else
'                Return False
'            End If
'        Else
'            Return True
'        End If
'    End Function


'    ''' <summary>
'    ''' 检查ID的重复性
'    ''' </summary>
'    ''' <param name="ID"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_CheckID(ByVal ID As String) As Boolean
'        Dim R As MsgReturn = SqlStrToOneStr(SQL_PriceiTouch_CheckID, "@ID", ID)
'        If R.IsOk Then
'            If Val(R.Msg) = 0 Then
'                Return False
'            Else
'                Return True
'            End If
'        Else
'            Return False
'        End If
'    End Function





'    ''' <summary>
'    ''' 添加出库单
'    ''' </summary>
'    ''' <param name="dtTable"></param>
'    ''' <param name="dtList"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
'        Dim msg As New DtListReturnMsg
'        Dim R As New MsgReturn
'        Dim sqlMap As New Dictionary(Of String, String)
'        Dim paraMap As New Dictionary(Of String, Object)
'        Dim PriceiTouchId As String = dtTable.Rows(0)("ID")
'        Dim IsInsert As Boolean = False
'        paraMap.Add("ID", PriceiTouchId)
'        Try

'            'If IsNull(dtTable.Rows(0)("Produce_ID"), "") <> "" Then
'            '    Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", dtTable.Rows(0)("Produce_ID"))
'            '    If Rx.IsOk = False Then
'            '        R.IsOk = False
'            '        R.Msg = PriceiTouch_DB_NAME & "[" & PriceiTouchId & "]添加失败!" & vbCrLf & Rx.Msg
'            '        Return R
'            '    End If
'            'End If

'            sqlMap.Add("Table", SQL_PriceiTouch_GetByid)
'            sqlMap.Add("List", SQL_PriceiTouch_GetListByid)
'            msg = SqlStrToDt(sqlMap, paraMap)
'            If msg.DtList("Table").Rows.Count = 0 Then
'                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
'                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
'                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PriceiTouchId & "'," & BillType.IniTouch & ")"
'                DtToUpDate(msg, TmSQL)
'                R.Msg = "" & PriceiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
'                R.IsOk = True
'            Else
'                R.IsOk = False
'                R.Msg = "" & PriceiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
'            End If
'            Return R
'        Catch ex As Exception
'            R.IsOk = False
'            R.Msg = "" & PriceiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
'            DebugToLog(ex)
'            Return R
'        Finally
'        End Try
'    End Function

'    ''' <summary>
'    ''' 修改出库单
'    ''' </summary>
'    ''' <param name="dtTable"></param>
'    ''' <param name="dtList"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
'        Dim msg As New DtListReturnMsg
'        Dim R As New MsgReturn
'        Dim sqlMap As New Dictionary(Of String, String)
'        Dim paraMap As New Dictionary(Of String, Object)
'        Dim PriceiTouchId As String = dtTable.Rows(0)("ID")
'        If LID <> PriceiTouchId AndAlso PriceiTouch_CheckID(PriceiTouchId) Then
'            R.IsOk = False
'            R.Msg = "" & PriceiTouch_DB_NAME & "[" & PriceiTouchId & "]已经存在!请双击编号文本框,获取新编号!"
'            Return R
'        End If
'        dtTable.Rows(0)("ID") = LID
'        paraMap.Add("ID", LID)

'        'If IsNull(dtTable.Rows(0)("Produce_ID"), "") <> "" Then
'        '    Dim Rx As MsgReturn = CallByID(30010, "Produce_CheckCanRef", dtTable.Rows(0)("Produce_ID"))
'        '    If Rx.IsOk = False Then
'        '        R.IsOk = False
'        '        R.Msg = PriceiTouch_DB_NAME & "[" & PriceiTouchId & "]添加失败!" & vbCrLf & Rx.Msg
'        '        Return R
'        '    End If
'        'End If

'        Try
'            sqlMap.Add("Table", SQL_PriceiTouch_GetByid)
'            sqlMap.Add("List", SQL_PriceiTouch_GetListByid)
'            msg = SqlStrToDt(sqlMap, paraMap)
'            If msg.DtList("Table").Rows.Count = 1 Then


'                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
'                    msg.DaList("Table").Dispose()
'                    msg.DaList("List").Dispose()
'                    msg.Cnn.Dispose()
'                    R.IsOk = False
'                    R.Msg = "" & PriceiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
'                    Return R
'                End If
'                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
'                    msg.DaList("Table").Dispose()
'                    msg.DaList("List").Dispose()
'                    msg.Cnn.Dispose()
'                    R.IsOk = False
'                    R.Msg = "" & PriceiTouch_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
'                    Return R
'                End If
'                DvToDt(dtList, msg.DtList("List"), New List(Of String))
'                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
'                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & PriceiTouchId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.IniTouch
'                If LID <> PriceiTouchId Then
'                    DtToUpDate(msg, "Update T50000_PriceiTouch_Table set id='" & PriceiTouchId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
'                    dtTable.Rows(0)("ID") = PriceiTouchId
'                    R.Msg = "" & PriceiTouch_DB_NAME & "[" & LID & "]已经修改为[" & PriceiTouchId & "]!"
'                Else
'                    DtToUpDate(msg)
'                    R.Msg = "" & PriceiTouch_DB_NAME & "[" & LID & "]修改成功!"
'                End If
'                R.IsOk = True
'            Else
'                R.IsOk = False
'                R.Msg = "" & PriceiTouch_DB_NAME & "[" & LID & "]不存在"
'            End If
'            Return R
'        Catch ex As Exception
'            R.IsOk = False
'            R.Msg = "" & PriceiTouch_DB_NAME & "[" & LID & "]修改错误"
'            DebugToLog(ex)
'            Return R
'        Finally
'        End Try
'    End Function

'    ''' <summary>
'    ''' 删除出库单
'    ''' </summary>
'    ''' <param name="PriceiTouchId"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_Del(ByVal PriceiTouchId As String)
'        Return RunSQL(SQL_PriceiTouch_DelByid, "@ID", PriceiTouchId)
'    End Function

'    ''' <summary>
'    ''' 作废出库单
'    ''' </summary>
'    ''' <param name="_ID"></param>
'    ''' <param name="IsFei">作废还是反作废</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
'        Dim paraMap As New Dictionary(Of String, Object)
'        paraMap.Add("ID", _ID)
'        paraMap.Add("State", IIf(IsFei, -1, 0))
'        paraMap.Add("State_User", User_Display)

'        Dim R As MsgReturn = SqlStrToOneStr("Update T50000_PriceiTouch_Table set State=@State,State_User=@State_User where ID=@ID  ", paraMap)
'        Dim s As String = IIf(IsFei, "作废", "还原")
'        If R.IsOk Then
'            R.Msg = PriceiTouch_DB_NAME & s & "成功！"
'        Else
'            R.Msg = PriceiTouch_DB_NAME & s & "失败！" & R.Msg

'        End If
'        Return R
'    End Function

'    ''' <summary>
'    ''' 审核出库单
'    ''' </summary>
'    ''' <param name="_ID"></param>
'    ''' <param name="IsAudited">审核还是反审核</param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
'        Dim paraMap As New Dictionary(Of String, Object)
'        paraMap.Add("ID", _ID)
'        paraMap.Add("IsAudited", IsAudited)
'        paraMap.Add("State_User", User_Display)

'        Dim R As MsgReturn = SqlStrToOneStr("Update T50000_PriceiTouch_Table set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)
'        Dim s As String = IIf(IsAudited, "审核", "反审核")
'        If R.IsOk Then
'            R.Msg = PriceiTouch_DB_NAME & s & "成功！"
'        Else
'            R.Msg = PriceiTouch_DB_NAME & s & "失败！" & R.Msg

'        End If

'        Return R
'    End Function
'#End Region
'    ''' <summary>
'    ''' 根据色号获取颜色布类
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_SelListById_All(ByVal sId As String) As DtReturnMsg
'        Return PClass.PClass.SqlStrToDt(SQL_PriceiTouch_SelListByid, "@ID", sId)
'    End Function

'#Region "根据色号获取染部配方成本"
'    ''' <summary>
'    ''' 根据色号获取染部配方成本
'    ''' </summary>
'    ''' <param name="BZC_ID"></param>
'    ''' <param name="BZ_ID"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function PriceiTouch_GetPFCost_ByBZC(ByVal BZC_ID As Integer, ByVal BZ_ID As Integer) As DtReturnMsg
'        Dim P As New Dictionary(Of String, Object)
'        P.Add("BZC_ID", BZC_ID)
'        P.Add("BZ_ID", BZ_ID)
'        Return SqlStrToDt(SQL_RBPF_PF_GeList_WithName, P)
'    End Function
'#End Region
'End Class