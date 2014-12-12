Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F10336_SGGY_Msg
    Dim ImagArray As Byte()
    Dim SGGY_Id As Long = 0

    Dim dtTable As DataTable
    Dim dtList As DataTable
    Dim dtBList As DataTable
    Dim dtZList As DataTable
    Dim dtHList As DataTable
    Dim State As Enum_SGGY = Enum_SGGY.New_Enum_SGGY
    Public Enum Enum_SGGY
        New_Enum_SGGY = 0
        ShenHe = 1
    End Enum
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal goodsID As Long)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()


        Me.SGGY_Id = goodsID
        Me.Mode = Mode

    End Sub

    Private Sub F10036_BZ_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try

                If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name Then
                    SendKeys.SendWait("{TAB}")
                End If
                If Me.ActiveControl.Name <> Fg2.Name AndAlso ActiveControl.Parent.Name <> Fg2.Name Then
                    SendKeys.SendWait("{TAB}")
                End If
                If Me.ActiveControl.Name <> Fg4.Name AndAlso ActiveControl.Parent.Name <> Fg4.Name Then
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
        ID = 10335
        Control_CheckRight(10335, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(10335, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name


        Fg1.Cols("WL_No").Editor = CB_WL_FG1
        Fg2.Cols("WL_No").Editor = CB_WL_FG2
        Fg4.Cols("WL_No").Editor = CB_WL_FG4
        CB_WL_FG1.SearchType = cSearchType.ENum_SearchType.Add_SQL
        CB_WL_FG1.SearchID = " and IsSGL=1"
        CB_WL_FG2.SearchType = cSearchType.ENum_SearchType.Add_SQL
        CB_WL_FG2.SearchID = " and IsSGL=1"
        CB_WL_FG4.SearchType = cSearchType.ENum_SearchType.Add_SQL
        CB_WL_FG4.SearchID = " and IsSGL=1"
        Fg1.IniColsSize()
        Fg2.IniColsSize()
        Fg4.IniColsSize()

        '  GetSupplierList()
        Me_Refresh()

        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            SGGY_Id = BaseClass.ComFun.GetLineID
            TB_NO.Text = Dao.SGGY_GetNewID()

        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.SGGY_GetById(SGGY_Id)
        If msg.IsOk Then
            dtTable = msg.Dt
            SetForm(msg.Dt)
        End If
        Dim msgBList As DtReturnMsg = ComFun.SGGY_GetList(SGGY_Id, "白色")
        If msgBList.IsOk Then
            dtBList = msgBList.Dt
            Fg1.DtToSetFG(dtBList)
        End If
        Dim msgZList As DtReturnMsg = ComFun.SGGY_GetList(SGGY_Id, "杂色")
        If msgZList.IsOk Then
            dtBList = msgZList.Dt
            Fg2.DtToSetFG(dtBList)
        End If
        Dim msgHList As DtReturnMsg = ComFun.SGGY_GetList(SGGY_Id, "黑色")
        If msgHList.IsOk Then
            dtBList = msgHList.Dt
            Fg4.DtToSetFG(dtBList)
        End If
    End Sub

    '#Region "Combobox"

    '    Protected Sub GetSupplierList()
    '        Dim msg As DtReturnMsg = Supplier_GetAll()
    '        If msg.IsOk Then
    '            CB_Supplier.DataSource = msg.Dt
    '        End If
    '    End Sub

    '#End Region

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable

        dt = dtTable
        dt.AcceptChanges()
        Dim dr As DataRow
        If dt.Rows.Count <= 0 Then
            dr = dt.NewRow
            dt.Rows.Add(dr)
        Else
            dr = dt.Rows(0)
        End If
        dr("SGGY_No") = TB_NO.Text
        dr("SGGY_Name") = TB_Name.Text
        dr("SGGY_Client") = CB_Client.Text
        dr("Client_id") = CB_Client.IDAsInt
        'dr("SGGY_Color") = CB_Color.Text
        dr("SGGY_GSD") = CB_GSD.text
        dr("SGGY_JS") = TB_JS.Text
        dr("SGGY_WD") = TB_WD.Text
        dr("SGGY_ZCYL") = TB_ZCYL.Text
        dr("SGGY_FS") = TB_FS.Text

        dr("BZ_ID") = CB_BZ.IDValue
        dr("Client_Bzc") = StrConv(TB_Client_Bzc.Text, vbNarrow)

        dr("SGGY_Feel") = TB_SGGY_Feel.Text

        dr("SGGY_Remark") = TB_Remark.Text
        dr("Founder") = TB_Founder.Tag
        dr("Found_Date") = DP_Found_Date.Value
        dr("UPD_USER") = PClass.PClass.User_ID
        dr("UPD_DATE") = Today

        dr("ID") = SGGY_Id
        dr("State") = State

        dtList = dtBList.Clone


        For i = 1 To Fg1.Rows.Count - 1

            dr = dtList.NewRow
            dr("ID") = SGGY_Id
            dr("Qty") = Val(Fg1.Item(i, "Qty"))
            dr("WL_ID") = Val(Fg1.Item(i, "WL_ID"))
            dr("Color") = "白色"
            dtList.Rows.Add(dr)
        Next

        For i = 1 To Fg2.Rows.Count - 1

            dr = dtList.NewRow
            dr("ID") = SGGY_Id
            dr("Qty") = Val(Fg2.Item(i, "Qty"))
            dr("WL_ID") = Val(Fg2.Item(i, "WL_ID"))
            dr("Color") = "杂色"
            dtList.Rows.Add(dr)
        Next

        For i = 1 To Fg4.Rows.Count - 1

            dr = dtList.NewRow
            dr("ID") = SGGY_Id
            dr("Qty") = Val(Fg4.Item(i, "Qty"))
            dr("WL_ID") = Val(Fg4.Item(i, "WL_ID"))
            dr("Color") = "黑色"
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
        If dt.Rows.Count <= 0 Then
            State = Enum_SGGY.New_Enum_SGGY
        Else
            State = IsNull(dt.Rows(0)("State"), "")
        End If
        'State = IsNull(dt.Rows(0)("State"), "")
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_FS.Text = IsNull(dt.Rows(0)("SGGY_FS"), "")
            TB_NO.Text = IsNull(dt.Rows(0)("SGGY_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("SGGY_Name"), "")
            CB_Client.Text = IsNull(dt.Rows(0)("SGGY_Client"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("SGGY_Remark"), "")
            TB_SGGY_Feel.Text = IsNull(dt.Rows(0)("SGGY_Feel"), "")
            CB_GSD.Text = IsNull(dt.Rows(0)("SGGY_GSD"), "")
            TB_JS.Text = IsNull(dt.Rows(0)("SGGY_JS"), "")
            TB_WD.Text = IsNull(dt.Rows(0)("SGGY_WD"), "")
            TB_ZCYL.Text = IsNull(dt.Rows(0)("SGGY_ZCYL"), "")
            CB_Client.IDAsInt = IsNull(dt.Rows(0)("Client_id"), "")

            'CB_Color.Text = IsNull(dt.Rows(0)("SGGY_Color"), "")
            TB_UPD_USER.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))

            CB_BZ.SearchID = IsNull(dt.Rows(0)("Client_id"), 0)
            CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
            TB_Client_Bzc.Text = IsNull(dt.Rows(0)("Client_Bzc"), "")

            CB_BZ.IDValue = IsNull(dt.Rows(0)("BZ_Id"), "0")
            CB_BZ.Text = CB_BZ.GetByTextBoxTag()
            TB_BZ_Name.Text = CB_BZ.NameValue

            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Value = dt.Rows(0)("UPD_DATE")
            End If

        Else
            TB_NO.Text = Me.SGGY_Id
            TB_Name.Text = ""
            TB_UPD_USER.Text = ""
            TB_Founder.Tag = PClass.PClass.User_ID
            TB_Founder.Text = PClass.PClass.User_Name
        End If
        Select Case State
            Case Enum_SGGY.New_Enum_SGGY
                LabelState.Text = "新建"
                Cmd_UnAudit.Visible = False
                Cmd_UnAudit.Enabled = False
                Cmd_Audit.Visible = True
                Cmd_Audit.Enabled = True
            Case Enum_SGGY.ShenHe
                LabelState.Text = "已审核"
                Cmd_Audit.Visible = False
                Cmd_Audit.Enabled = False
                Cmd_UnAudit.Visible = True
                Cmd_UnAudit.Enabled = True
        End Select

    End Sub


    '''' <summary>
    '''' 获取表单内容
    '''' </summary>
    '''' <remarks></remarks>
    'Protected Sub GetList()
    '    Dim dt As DataTable
    '    Dim dr As DataRow
    '    dt.AcceptChanges()
    '    dtBList = dtBList.Clone
    '    dtZList = dtZList.Clone
    '    dtHList = dtHList.Clone

    '    For i = 1 To Fg1.Rows.Count - 1

    '        dr = dtBList.NewRow
    '        dr("ID") = SGGY_Id
    '        dr("Qty") = Val(Fg1.Item(i, "Qty"))
    '        dr("WL_ID") = Val(Fg1.Item(i, "WL_ID"))

    '        dtBList.Rows.Add(dr)
    '    Next

    '    For i = 1 To Fg2.Rows.Count - 1

    '        dr = dtZList.NewRow
    '        dr("ID") = SGGY_Id
    '        dr("Qty") = Val(Fg2.Item(i, "Qty"))
    '        dr("WL_ID") = Val(Fg2.Item(i, "WL_ID"))

    '        dtZList.Rows.Add(dr)
    '    Next

    '    For i = 1 To Fg4.Rows.Count - 1

    '        dr = dtHList.NewRow
    '        dr("ID") = SGGY_Id
    '        dr("Qty") = Val(Fg4.Item(i, "Qty"))
    '        dr("WL_ID") = Val(Fg4.Item(i, "WL_ID"))

    '        dtHList.Rows.Add(dr)
    '    Next

    '    dtBList.AcceptChanges()
    '    dtZList.AcceptChanges()
    '    dtHList.AcceptChanges()
    'End Sub
#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存工艺[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.SGGY_Add(Dt, dtList)
        Else
            R = Dao.SGGY_Save(Dt, dtList)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_NO.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        Fg1.FinishEditing(False)
        Fg2.FinishEditing(False)
        Fg4.FinishEditing(False)
        If TB_NO.Text = "" Then
            ShowErrMsg("工艺编号不能为空")
            TB_NO.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("工艺名称不能为空")
            TB_Name.Focus()
            Return False
        End If

        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg1.Item(i, "Qty")) < 0 Then
                    Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
                End If
                If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
                    Fg1.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next
        For i As Integer = Fg2.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg2.Item(i, "Qty")) < 0 Then
                    Fg2.Item(i, "Qty") = -Val(Fg2.Item(i, "Qty"))
                End If
                If Val(Fg2.Item(i, "Qty")) = 0 OrElse Val(Fg2.Item(i, "WL_ID")) = 0 Then
                    Fg2.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next
        For i As Integer = Fg4.Rows.Count - 1 To 1 Step -1
            Try
                If Val(Fg4.Item(i, "Qty")) < 0 Then
                    Fg4.Item(i, "Qty") = -Val(Fg4.Item(i, "Qty"))
                End If
                If Val(Fg4.Item(i, "Qty")) = 0 OrElse Val(Fg4.Item(i, "WL_ID")) = 0 Then
                    Fg4.RemoveItem(i)
                End If
            Catch ex As Exception
            End Try
        Next
        Me.Refresh()
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除工艺[" & TB_NO.Text & "]?", AddressOf DelGoods)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()
        Dim msg As MsgReturn = Dao.SGGY_Del(SGGY_Id)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub





#End Region


#Region "FG事件"

#Region "WL选择"

    Dim IsWLSelect As Boolean
    Private Sub CB_WL_FG1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_WL_FG1.Col_Sel
        IsWLSelect = True
        Fg1.Item(Fg1.RowSel, "WL_Name") = Col_Name
        Fg1.Item(Fg1.RowSel, "WL_ID") = ID
        Fg1.GotoNextCell("WL_No")
    End Sub
    Private Sub CB_WL_FG2_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal _ID As String) Handles CB_WL_FG2.Col_Sel
        IsWLSelect = True
        Fg2.Item(Fg2.RowSel, "WL_Name") = Col_Name
        Fg2.Item(Fg2.RowSel, "WL_ID") = _ID
        Fg2.GotoNextCell("WL_No")
    End Sub
    Private Sub CB_WL_FG4_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal __ID As String) Handles CB_WL_FG4.Col_Sel
        IsWLSelect = True
        Fg4.Item(Fg4.RowSel, "WL_Name") = Col_Name
        Fg4.Item(Fg4.RowSel, "WL_ID") = __ID
        Fg4.GotoNextCell("WL_No")
    End Sub

    Private Sub CB_WL_FG1_SetEmpty() Handles CB_WL_FG1.SetEmpty
        Fg1.Item(Fg1.RowSel, "WL_ID") = 0
        Fg1.Item(Fg1.RowSel, "WL_No") = ""
        Fg1.Item(Fg1.RowSel, "WL_Name") = ""
        Fg1.Item(Fg1.RowSel, "Qty") = 0
    End Sub
    Private Sub CB_WL_FG2_SetEmpty() Handles CB_WL_FG2.SetEmpty
        Fg2.Item(Fg2.RowSel, "WL_ID") = 0
        Fg2.Item(Fg2.RowSel, "WL_No") = ""
        Fg2.Item(Fg2.RowSel, "WL_Name") = ""
        Fg2.Item(Fg2.RowSel, "Qty") = 0
    End Sub
    Private Sub CB_WL_FG4_SetEmpty() Handles CB_WL_FG4.SetEmpty
        Fg4.Item(Fg4.RowSel, "WL_ID") = 0
        Fg4.Item(Fg4.RowSel, "WL_No") = ""
        Fg4.Item(Fg4.RowSel, "WL_Name") = ""
        Fg4.Item(Fg4.RowSel, "Qty") = 0
    End Sub
    Private Sub CB_WL_FG1_Col_SelRow(ByVal Dr As System.Data.DataRow) Handles CB_WL_FG1.Col_SelRow
        Fg1.Item(Fg1.RowSel, "WL_Spec") = Dr("WL_Spec")
    End Sub
    Private Sub CB_WL_FG2_Col_SelRow(ByVal Dr As System.Data.DataRow) Handles CB_WL_FG2.Col_SelRow
        Fg2.Item(Fg2.RowSel, "WL_Spec") = Dr("WL_Spec")
    End Sub
    Private Sub CB_WL_FG4_Col_SelRow(ByVal Dr As System.Data.DataRow) Handles CB_WL_FG4.Col_SelRow
        Fg4.Item(Fg4.RowSel, "WL_Spec") = Dr("WL_Spec")
    End Sub
    Private Sub CB_WL_FG1_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_WL_FG1.GetSearchEvent
        CB_WL_FG1.IDValue = Fg1.Item(Fg1.RowSel, "WL_ID")
    End Sub
    Private Sub CB_WL_FG2_GetSearchEvent(ByRef Col_No As String, ByRef _ID As String, ByVal Cancel As Boolean) Handles CB_WL_FG2.GetSearchEvent
        CB_WL_FG2.IDValue = Fg2.Item(Fg2.RowSel, "WL_ID")
    End Sub
    Private Sub CB_WL_FG_GetSearchEvent(ByRef Col_No As String, ByRef __ID As String, ByVal Cancel As Boolean) Handles CB_WL_FG4.GetSearchEvent
        CB_WL_FG4.IDValue = Fg4.Item(Fg4.RowSel, "WL_ID")
    End Sub

    Sub FG_WL_No1()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("WL_No").Index)
    End Sub
    Sub FG_WL_No2()
        Fg2.StartEditing(Fg2.RowSel, Fg2.Cols("WL_No").Index)
    End Sub
    Sub FG_WL_No4()
        Fg4.StartEditing(Fg4.RowSel, Fg4.Cols("WL_No").Index)
    End Sub
#End Region

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Col = Fg1.Cols("WL_No").Index Then
            If Fg1.LastKey = Keys.Enter Then
                CB_WL_FG1.Col_SelOne()
                If Fg1.Item(e.Row, "WL_Name") = "" Then
                    ShowErrMsg("请输入一个物料编号!", AddressOf FG_WL_No1)
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
    Private Sub Fg2_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg2.AfterEdit
        If e.Col = Fg2.Cols("WL_No").Index Then
            If Fg2.LastKey = Keys.Enter Then
                CB_WL_FG1.Col_SelOne()
                If Fg2.Item(e.Row, "WL_Name") = "" Then
                    ShowErrMsg("请输入一个物料编号!", AddressOf FG_WL_No2)
                End If
            Else
                If Fg2.LastText <> IsNull(Fg2.Item(e.Row, "WL_No"), "") AndAlso IsWLSelect = False Then
                    Fg2.Item(Fg2.RowSel, "WL_ID") = 0
                    Fg2.Item(Fg2.RowSel, "WL_Name") = ""
                    Fg2.Item(Fg2.RowSel, "WL_Spec") = ""
                End If
                IsWLSelect = False
            End If
        Else
            If Fg2.LastKey = Keys.Enter Then Fg2.GotoNextCell()
        End If
    End Sub

    Private Sub Fg4_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg4.AfterEdit
        If e.Col = Fg4.Cols("WL_No").Index Then
            If Fg4.LastKey = Keys.Enter Then
                CB_WL_FG1.Col_SelOne()
                If Fg4.Item(e.Row, "WL_Name") = "" Then
                    ShowErrMsg("请输入一个物料编号!", AddressOf FG_WL_No4)
                End If
            Else
                If Fg4.LastText <> IsNull(Fg4.Item(e.Row, "WL_No"), "") AndAlso IsWLSelect = False Then
                    Fg4.Item(Fg4.RowSel, "WL_ID") = 0
                    Fg4.Item(Fg4.RowSel, "WL_Name") = ""
                    Fg4.Item(Fg4.RowSel, "WL_Spec") = ""
                End If
                IsWLSelect = False
            End If
        Else
            If Fg4.LastKey = Keys.Enter Then Fg4.GotoNextCell()
        End If
    End Sub

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        If e.Col = "Qty" Then
            If e.Row + 2 > Fg1.Rows.Count And Cmd_AddRow.Enabled Then
                Fg1.Rows.Add()
                Fg1.ReAddIndex()
            End If
            If e.Row + 2 > Fg1.Rows.Count Then
                e.ToCol = Fg1.Cols("Qty").Index
            Else
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("WL_No").Index
            End If
        ElseIf e.Col = "WL_No" Then
            e.ToCol = Fg1.Cols("Qty").Index

        End If
    End Sub

    Private Sub Fg2_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg2.NextCell
        If e.Col = "Qty" Then
            If e.Row + 2 > Fg2.Rows.Count And Cmd_AddRow.Enabled Then
                Fg2.Rows.Add()
                Fg2.ReAddIndex()
            End If
            If e.Row + 2 > Fg2.Rows.Count Then
                e.ToCol = Fg2.Cols("Qty").Index
            Else
                e.ToRow = e.Row + 1
                e.ToCol = Fg2.Cols("WL_No").Index
            End If
        ElseIf e.Col = "WL_No" Then
            e.ToCol = Fg2.Cols("Qty").Index

        End If
    End Sub

    Private Sub Fg4_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg4.NextCell
        If e.Col = "Qty" Then
            If e.Row + 2 > Fg4.Rows.Count And Cmd_AddRow.Enabled Then
                Fg4.Rows.Add()
                Fg4.ReAddIndex()
            End If
            If e.Row + 2 > Fg4.Rows.Count Then
                e.ToCol = Fg4.Cols("Qty").Index
            Else
                e.ToRow = e.Row + 1
                e.ToCol = Fg4.Cols("WL_No").Index
            End If
        ElseIf e.Col = "WL_No" Then
            e.ToCol = Fg4.Cols("Qty").Index

        End If
    End Sub
#End Region




    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        Fg1.AddRow()
        Fg2.AddRow()
        Fg4.AddRow()
    End Sub


    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click
        If State = Enum_SGGY.New_Enum_SGGY Then
            Dim P As New Dictionary(Of String, Object)
            P.Add("ID", SGGY_Id)
            SqlStrToDt("update T10035_SGGY set State=1 where ID=@ID", P)
            ShowOk("审核成功!")
        Else
            ShowOk("审核失败!")
        End If
        Me_Refresh()
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        If State = Enum_SGGY.ShenHe Then
            Dim P As New Dictionary(Of String, Object)
            P.Add("ID", SGGY_Id)
            SqlStrToDt("update T10035_SGGY set State=0 where ID=@ID", P)
            ShowOk("反审成功!")
        Else
            ShowOk("反审失败!")
        End If
        Me_Refresh()
    End Sub

    Private Sub CB_BZ_Col_Sel(ByVal Col_No As System.String, ByVal Col_Name As System.String, ByVal ID As System.String) Handles CB_BZ.Col_Sel
        TB_BZ_Name.Text = Col_Name
    End Sub

    Private Sub CB_Client_Col_Sel(ByVal Col_No As System.String, ByVal Col_Name As System.String, ByVal ID As System.String) Handles CB_Client.Col_Sel
        If CB_BZ.SearchID <> ID Then
            CB_BZ.Text = ""
            CB_BZ.SetSearchEmpty()
            TB_BZ_Name.Text = ""
        End If
        CB_BZ.Enabled = True
        CB_BZ.SearchID = ID
        CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
    End Sub
End Class


Partial Class Dao
    Public Const SGGY_Bill_NAME As String = "手感工艺"

#Region "工艺"
    Public Const SQL_SGGY_NameCheckDuplicate = "select count(*) from  " & OptionClass.Table_SGGY & " where SGGY_No=@SGGY_No and id<>@id"


    Public Const SQL_SGGY_Get As String = "select State,ID,SGGY_Client,SGGY_No,SGGY_Name,SGGY_Remark,SGGY_Color,SGGY_Feel,SGGY_JS,SGGY_WD,SGGY_ZCYL,SGGY_FS,SGGY_GSD from " & OptionClass.Table_SGGY & " "

    Public Const SQL_SGGY_GetByID As String = "select top 1 * from " & OptionClass.Table_SGGY & " where ID=@ID"
    Public Const SQL_SGGY_GetListByID As String = "select * from " & OptionClass.Table_SGGYList & " where ID=@ID "
    Public Const SQL_SGGY_GetBListByID As String = "select * from " & OptionClass.Table_SGGYList & " where ID=@ID and Color='白色'"
    Public Const SQL_SGGY_GetZListByID As String = "select * from " & OptionClass.Table_SGGYList & " where ID=@ID and Color='杂色'"
    Public Const SQL_SGGY_GetHListByID As String = "select * from " & OptionClass.Table_SGGYList & " where ID=@ID and Color='白黑色'"

    Public Const SQL_SGGY_GetByNo As String = "select * from " & OptionClass.Table_SGGY & " where SGGY_No=@SGGY_No"

    Public Const SQL_SGGY_GetByID_ExceptImage As String = "select ID,SGGY_No,SGGY_Name,SGGY_Remark,Founder,Found_Date,Upd_User,Upd_Date,SGGY_Color,SGGY_Feel from " & OptionClass.Table_SGGY & " where ID=@ID"

    Public Const SQL_SGGY_DelByid As String = "Delete from  " & OptionClass.Table_SGGY & " where ID=@ID "

    Public Const SQL_SGGY_OrderBy As String = " order by  SGGY_No "

    '  Public Const SQL_SGGY_GeList_ByIDWithName = "select P.*,WL_Name,WL_No,WL_Spec from " & OptionClass.Table_SGGYList & "  P left join T10036_WL W on P.WL_ID=W.ID where  P.ID=@ID "


    Public Const SQL_SGGY_InsertNewID = "if exists (select * from " & OptionClass.Table_SGGY & " where SGGY_No= @SGGY_No)" & vbCrLf & _
                                            "select -1" & vbCrLf & _
                                            "else" & vbCrLf & _
                                            "begin" & vbCrLf & _
                                            "insert into " & OptionClass.Table_SGGY & "(SGGY_No)Values(@SGGY_No)" & vbCrLf & _
                                            "select @@IDENTITY" & vbCrLf & _
                                            "end"
#End Region

    ''' <summary>
    ''' 获取所有工艺信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_SGGY_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "工艺编号"
        fo.DB_Field = "SGGY_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "工艺名称"
        fo.DB_Field = "SGGY_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "颜色"
        fo.DB_Field = "SGGY_Color"

        fo = New FindOption
        fo.Field = "手感"
        fo.DB_Field = "SGGY_Feel"
        foList.Add(fo)


        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取工艺信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_SGGY_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_SGGY_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取工艺信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_GetById(ByVal sId As Double) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_SGGY_GetByID, "@Id", sId)
    End Function


    ''' <summary>
    ''' 增加一个工艺
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_Add(ByVal dtTable As DataTable, ByVal DtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim _No As String = dtTable.Rows(0)("SGGY_No")
        Dim IsInsert As Boolean = False
        Dim ID As Integer = 0

        paraMap.Add("ID", ID)
        sqlMap.Add("Table", SQL_SGGY_GetByID)
        sqlMap.Add("List", SQL_SGGY_GetListByID)
        'sqlMap.Add("ZList", SQL_SGGY_GetZListByID)
        'sqlMap.Add("HList", SQL_SGGY_GetHListByID)
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 0 Then
                    DvToDt(dtTable, H.DtList("Table"), New List(Of String), True)
                    DvToDt(DtList, H.DtList("List"), New List(Of String), True)

                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "]添加失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using

        'Try
        '    Dim newIdMsg As MsgReturn = SqlStrToOneStr(SQL_SGGY_InsertNewID, "@SGGY_No", _No)
        '    If newIdMsg.IsOk Then
        '        If Val(newIdMsg.Msg) = -1 Then
        '            R.IsOk = False
        '            R.Msg = SGGY_Bill_NAME & "编号[" & dtTable.Rows(0)("SGGY_No") & "]已经存在!"
        '            Return R
        '        Else
        '            ID = Val(newIdMsg.Msg)
        '            dtTable.Rows(0)("ID") = ID
        '            For Each dr As DataRow In DtList.Rows
        '                dr("ID") = ID
        '            Next
        '        End If
        '    End If
        '    paraMap.Add("ID", ID)
        '    sqlMap.Add("Table", SQL_SGGY_GetByID)
        '    sqlMap.Add("List", SQL_SGGY_GetListByID)

        '    msg = SqlStrToDt(sqlMap, paraMap)
        '    If msg.DtList("Table").Rows.Count = 1 Then
        '        DvToDt(DtList, msg.DtList("List"), New List(Of String))
        '        DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
        '        '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
        '        DtToUpDate(msg)
        '        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("SGGY_Name") & "]添加成功!"
        '        R.IsOk = True
        '    Else
        '        R.IsOk = False
        '        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("SGGY_Name") & "]已经存在!"
        '    End If
        '    Return R
        'Catch ex As Exception
        '    R.IsOk = False
        '    R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("SGGY_Name") & "]添加错误!"
        '    DebugToLog(ex)
        '    Return R
        'Finally
        'End Try
    End Function



    ''' <summary>
    '''修改一个工艺
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_Save(ByVal dtTable As DataTable, ByVal DtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ID As Long = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ID)

        sqlMap.Add("Table", SQL_SGGY_GetByID)
        sqlMap.Add("List", SQL_SGGY_GetListByID)
        'sqlMap.Add("ZList", SQL_SGGY_GetZListByID)
        'sqlMap.Add("HList", SQL_SGGY_GetHListByID)

        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 1 Then
                    DvUpdateToDt(dtTable, H.DtList("Table"), New List(Of String))
                    DvToDt(DtList, H.DtList("List"), New List(Of String))
                    'DvToDt(DtZList, H.DtList("ZList"), New List(Of String))
                    'DvToDt(DtHList, H.DtList("HList"), New List(Of String))
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "修改失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("ID") & "]修改错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using

        'Try
        '    sqlMap.Add("Table", SQL_SGGY_GetByID)
        '    sqlMap.Add("List", SQL_SGGY_GetBListByID)

        '    msg = SqlStrToDt(sqlMap, paraMap)
        '    If msg.DtList("Table").Rows.Count = 1 Then
        '        DvToDt(dtList, msg.DtList("List"), New List(Of String))
        '        DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))

        '        '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
        '        DtToUpDate(msg)
        '        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("SGGY_Name") & "]修改成功!"
        '        R.IsOk = True
        '    Else
        '        R.IsOk = False
        '        R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("SGGY_Name") & "]不存在!"
        '    End If
        '    Return R
        'Catch ex As Exception
        '    R.IsOk = False
        '    R.Msg = "" & SGGY_Bill_NAME & "[" & dtTable.Rows(0)("SGGY_Name") & "]修改错误!"
        '    DebugToLog(ex)
        '    Return R
        'Finally
        'End Try
    End Function


    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="SGGY_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_NameCheckDuplicate(ByVal SGGY_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("SGGY_No", SGGY_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_SGGY_NameCheckDuplicate, P)
        If r.IsOk Then
            If Val(r.Msg) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_Del(ByVal BZId As String)
        Return RunSQL(SQL_SGGY_DelByid, "@ID", BZId)
    End Function

    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SGGY_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", OptionClass.Table_SGGY)
        paraMap.Add("@Id_Str", "")
        paraMap.Add("@Field", "SGGY_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return Format(Val(msgID.Msg), "000")
        Else
            Return ""
        End If
    End Function



    'Public Shared Function SGGY_GetList_ByID(ByVal _ID As Integer) As DtReturnMsg
    '    Dim R As New DtReturnMsg
    '    Dim sql As String = SQL_SGGY_GeList_ByIDWithName
    '    Dim para As New Dictionary(Of String, Object)
    '    para.Add("@ID", _ID)
    '    R = PClass.PClass.SqlStrToDt(sql, para)
    '    Return R
    'End Function






End Class