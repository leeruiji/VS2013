Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40011_OutWork_Msg

    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim LId As String = ""
    Dim Bill_ID_Date As Date = #1/1/1999#
    Dim Dt_Supplier As DataTable
    Dim emp As BaseClass.Emplyee
    Dim DtChePai As DataTable
    Dim State As Enum_State
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

    Private Sub F20001_outWork_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        ID = 40010

        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInvalid)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Comfirm, Cmd_Store_Comfirm)
        Control_CheckRight(ID, ClassMain.UnComfirm, Cmd_UnComfirm)
        CKB_SetReceipt.Enabled = CheckRight(ID, ClassMain.SetReceipt) AndAlso Mode = Mode_Enum.Modify
    End Sub

    Private Sub F40011_OutWork_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.OutWork, Bill_ID)
        ReturnId = TB_ID.Text
    End Sub

    Private Sub F10101_outWork_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        '  Fg1.Cols("BZ_No").Editor = CB_BZ_FG
        '   Fg1.Cols("BZC_No").Editor = CB_BZC_FG
        Fg1.IniFormat()
        emp = BaseClass.Emplyee.GetInstance
        Dim Dept_BC As DataTable = Emplyee.GetEmployee_ByDept(FormatSharp("Dept_BC"))
        Dim Dept_GD As DataTable = Emplyee.GetEmployee_ByDept(FormatSharp("Dept_GD"))
        If Dept_BC IsNot Nothing Then
            ' TB_SiJi.DataSource = Dept_GD.Copy
            CB_FaHuo.DataSource = Dept_BC.Copy
            CB_ZhiDan.DataSource = Dept_GD.Copy
            'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy
        End If


        Dim msgChePai As DtReturnMsg = BaseClass.ComFun.GetChePaiList
        If msgChePai.IsOk Then
            Dim dt As DataTable = msgChePai.Dt
            CB_ChePai.DataSource = dt.DefaultView
            CB_ChePai.DisplayMember = "Remark"
            CB_ChePai.ValueMember = "Remark2"
            CB_ChePai.SelectedIndex = -1


            CB_SiJi.DataSource = dt.Copy.DefaultView
            CB_SiJi.DisplayMember = "Remark2"
            CB_SiJi.ValueMember = "Remark2"
            CB_SiJi.SelectedIndex = -1
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                GetNewID()
                '   TB_SiJi.SelectedIndex = -1
                CB_FaHuo.SelectedIndex = -1
                CB_ZhiDan.SelectedIndex = -1
                LabelTitle.Text = "新建" & Me.Ch_Name
                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                Cmd_SetInvalid.Visible = False
                Cmd_SetValid.Visible = False
            Case Mode_Enum.Modify
                TB_ID.ReadOnly = True
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select

        Me_Refresh()


        '  Fg1.RowSel = 1
        isLoaded = True
    End Sub

    Protected Sub Me_Refresh()
        'Dim msgTable As DtReturnMsg = Dao.OutWork_GetById(Bill_ID)
        'If msgTable.IsOk Then
        '    dtTable = msgTable.Dt
        '    SetForm(msgTable.Dt)
        'End If
        'Dim msg As DtReturnMsg = Dao.OutWork_GetListById(Bill_ID)
        Dim Datalist As List(Of DataTable) = Dao.OutWork_GetDataByID(Bill_ID)
        If Datalist IsNot Nothing AndAlso Datalist.Count = 2 Then
            dtTable = Datalist(0)
            SetForm(dtTable)
            dtList = Datalist(1)
            For Each dr As DataRow In dtList.Rows
                dr("BZ_Name") = dr("BZ_Name").ToString.Replace("##", "#")
                dr("BZC_Name") = dr("BZ_Name").ToString.Replace("##", "#")
            Next
            Fg1.DtToSetFG(dtlist)

        Else
            Fg1.Rows.Count = 1
        End If
        CaculateSumAmount()

    End Sub

#Region "表单信息"

    'Protected Sub ProcessDtList()
    '    If dtList Is Nothing Then
    '        Exit Sub
    '    End If
    '    For Each dr In dtList.Rows
    '        dr("")

    '    Next
    'End Sub


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
            dr("outWork_Date") = DP_Date.Value.ToString("yyyy-MM-dd")
            dr("JGDW_ID") = Val(CB_JGDW.IDValue)

            dr("SumQty") = Val(TB_SumQty.Text)

            dr("State") = Enum_State.AddNew


            dr("SumPWeight") = Val(TB_PWeight.Text)

            dr("ZhiDan") = CB_ZhiDan.Text
            dr("FaHuo") = CB_FaHuo.Text
            dr("SiJi") = CB_SiJi.Text
            dr("ChePai") = CB_ChePai.Text
            dr("Address") = TB_Address.Text
            dr("Remark") = TB_Remark.Text
            dr("GotReceipt") = CKB_SetReceipt.Checked
            dt.Rows.Add(dr)
            Dim _dtList As DataTable = dtList.Clone
            Dim drList As DataRow
            For i As Integer = 1 To Fg1.Rows.Count - 1
                drList = _dtList.NewRow
                If Fg1.Item(i, "GH") = "" Then
                    Continue For
                End If
                drList("ID") = TB_ID.Text
                drList("PB_CountSum") = Val(Fg1.Item(i, "PB_CountSum"))
                drList("Weight") = Val(Fg1.Item(i, "Weight"))
                drList("GH") = IIf(Fg1.Item(i, "GH") Is Nothing, "", Fg1.Item(i, "GH"))
                drList("JiaGongNeiRong") = IIf(Fg1.Item(i, "JiaGongNeiRong") Is Nothing, "", Fg1.Item(i, "JiaGongNeiRong"))

                _dtList.Rows.Add(drList)
            Next
            dtList = _dtList
        End If

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
        If dt.Rows.Count = 1 Then
            TB_ID.Text = IsNull(dt.Rows(0)("ID"), "")
            If Not dt.Rows(0)("outWork_Date") Is DBNull.Value Then
                DP_Date.Value = dt.Rows(0)("outWork_Date")
            End If
            CB_JGDW.IDValue = IsNull(dt.Rows(0)("JGDW_ID"), "0")
            CB_JGDW.Text = IsNull(dt.Rows(0)("JGDW_No"), "0")
            TB_JGDWName.Text = IsNull(dt.Rows(0)("JGDW_Name"), "")
            TB_SumQty.Text = FormatNum(IsNull(dt.Rows(0)("SumQty"), 0))

            TB_PWeight.Text = FormatZL(IsNull(dt.Rows(0)("SumPWeight"), 0))

            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")

            CB_ZhiDan.Text = IsNull(dt.Rows(0)("ZhiDan"), "")
            CB_FaHuo.Text = IsNull(dt.Rows(0)("FaHuo"), "")
            CB_SiJi.Text = IsNull(dt.Rows(0)("SiJi"), "")
            CB_ChePai.Text = IsNull(dt.Rows(0)("ChePai"), "")
            TB_Address.Text = IsNull(dt.Rows(0)("Address"), "")

            State = IsNull(dt.Rows(0)("State"), Enum_State.AddNew)

            CKB_SetReceipt.Checked = IsNull(dt.Rows(0)("GotReceipt"), False)
            Select Case State

                Case Enum_State.AddNew
                    Cmd_Modify.Enabled = True
                    Cmd_Del.Visible = False
                    Cmd_SetInvalid.Visible = Cmd_SetInvalid.Tag
                    Cmd_SetValid.Visible = False
                    LabelState.Text = "新建"

                    Cmd_Store_Comfirm.Visible = Cmd_Store_Comfirm.Tag
                    Cmd_UnComfirm.Visible = False
                Case Enum_BZSHState.Store_Comfirm  '确认
                    TB_ID.ReadOnly = True

                    LabelState.Text = "已确认"
                    LabelState.ForeColor = Color.Blue

                    Cmd_Modify.Enabled = False

                    Cmd_Del.Enabled = False




                    Cmd_SetValid.Visible = False

                    Cmd_SetInvalid.Visible = False


                    Cmd_Store_Comfirm.Visible = False
                    Cmd_UnComfirm.Visible = Cmd_UnComfirm.Tag


          
                Case Enum_State.Invoid
                    Cmd_Modify.Enabled = False
                    Cmd_Del.Enabled = True
                    Cmd_SetInvalid.Visible = False
                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    LabelState.Text = "已作废"
                    Cmd_Store_Comfirm.Visible = False
                    Cmd_UnComfirm.Visible = False
                Case Else

            End Select


        Else

        End If
    End Sub

    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            Exit Sub
        End If
        Dim SumQty As Double = 0
        Dim SumCWeight As Double = 0
        Dim SumPWeight As Double = 0
        For i = 1 To Fg1.Rows.Count - 1
            SumQty = SumQty + Val(Fg1.Item(i, "PB_CountSum"))
            ' SumCWeight = SumCWeight + Val(Fg1.Item(i, "CWeight"))
            SumPWeight = SumPWeight + Val(Fg1.Item(i, "Weight"))
        Next
        TB_SumQty.Text = FormatNum(SumQty)

        TB_PWeight.Text = FormatZL(SumPWeight)
    End Sub

#End Region

#Region "表单事件"




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
            'If dtList.Rows.Count <= 0 Then
            '    ShowErrMsg("列表不能为空!")
            '    Exit Sub
            'End If

            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveoutWork)
            Else
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveoutWork)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveoutWork(Optional ByVal IsComfirm As Boolean = False)
        dtList.AcceptChanges()
        Dim R As DtListReturnMsg
        If Me.Mode = Mode_Enum.Add Then
            If Bill_ID = TB_ID.Text Then GetNewID()
            R = Dao.OutWork_Add(GetForm(), dtList)
        Else
            R = Dao.OutWork_Save(GetForm(), dtList)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Mode = Mode_Enum.Modify
            If IsComfirm Then
                Comfirm()
                Exit Sub
            End If
            ShowOk("保存成功.")

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
        If TB_ID.Text = "" Then
            TB_ID.Focus()
            ShowErrMsg(Ch_Name & "单号不能为空!")
            Return False
        End If
        If Val(CB_JGDW.IDValue) = 0 Then
            CB_JGDW.Focus()
            ShowErrMsg("客户商编号或名称不能为空!", AddressOf CB_JGDW.Focus)
            Return False
        End If
        'Dim d As Date
        'For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
        '    If Fg1.Item(i, "GH") = "" Then
        '        Continue For
        '    End If
        '    Try
        '        'd = Fg1.Item(i, "LuoSeDate")
        '        'If d.Year < 2000 Then
        '        '    Fg1.RowSel = i
        '        '    ShowErrMsg("落色日期不正确!")
        '        '    Return False
        '        'End If


        '    Catch ex As Exception
        '        Fg1.RowSel = i
        '        ShowErrMsg("落色日期不正确!")
        '        Return False
        '    End Try
        'Next



        Return True
    End Function





    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DeloutWork)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DeloutWork()
        Dim msg As MsgReturn = Dao.OutWork_Del(TB_ID.Text)
        If msg.IsOk Then
            Me.LastForm.ReturnId = -1
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
#End Region

#Region "FG1事件"



    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        'Select Case e.Col
        '    Case "OrderBill"
        '        e.ToCol = Fg1.Cols("GH").Index
        '    Case "GH"
        '        e.ToCol = Fg1.Cols("Qty").Index

        '    Case "LuoSeDate"
        '        e.ToCol = Fg1.Cols("BZC_No").Index
        '    Case "BZC_No"
        '        e.ToCol = Fg1.Cols("BZ_No").Index
        '    Case "BZ_No"
        '        e.ToCol = Fg1.Cols("Qty").Index
        '    Case "Qty"
        '        e.ToCol = Fg1.Cols("PWeight").Index
        '    Case "PWeight"
        '        e.ToCol = Fg1.Cols("JiaGongNeiRong").Index

        '        '     Case "PWeight"
        '        '       e.ToCol = Fg1.Cols("CWeight").Index

        '    Case Else
        '        If Fg1.Cols(e.Col).Index < Fg1.Cols("BZ_ID").Index OrElse (Fg1.Cols(e.Col).Index > Fg1.Cols("BZC_Name").Index AndAlso Fg1.Cols(e.Col).Index < Fg1.Cols.Count - 1) Then
        '            e.ToCol = Fg1.Cols(e.Col).Index + 1
        '        ElseIf Fg1.Cols(e.Col).Index = Fg1.Cols.Count - 1 Then
        '            If e.Row = Fg1.Rows.Count - 1 Then
        '                AddRow()
        '            End If
        '            e.ToRow = e.Row + 1
        '            e.ToCol = 1
        '        End If
        'End Select
    End Sub


    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow()
        Fg1.Rows.Add()
        Fg1.ReAddIndex()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub RemoveRow()
        Fg1.Select(Fg1.RowSel, 0)
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
#Region "BZ选择"
    Dim IsBZSelect As Boolean
    Private Sub CB_BZ_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ_FG.Col_Sel
        IsBZSelect = True
        Fg1.Item(Fg1.RowSel, "BZ_Name") = Col_Name
        Fg1.Item(Fg1.RowSel, "BZ_ID") = ID
        Fg1.GotoNextCell("BZ_No")
    End Sub
    Private Sub CB_BZ_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_BZ_FG.GetSearchEvent
        If Fg1.Item(Fg1.RowSel, "BZC_ID") IsNot Nothing AndAlso Val(Fg1.Item(Fg1.RowSel, "BZC_ID")) <> 0 Then
            CB_BZ_FG.SearchType = cSearchType.ENum_SearchType.BZC
            CB_BZ_FG.SearchID = Fg1.Item(Fg1.RowSel, "BZC_ID")
        Else
            CB_BZ_FG.SearchType = cSearchType.ENum_SearchType.ALL
            CB_BZ_FG.SearchID = 0
        End If

        CB_BZ_FG.IDValue = Fg1.Item(Fg1.RowSel, "BZ_ID")
    End Sub
    Sub FG_BZ_No()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("BZ_No").Index)
    End Sub

#End Region

#Region "BZC选择"

    Dim IsBZCSelect As Boolean
    Private Sub CB_BZC_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZC_FG.Col_Sel
        IsBZCSelect = True

        Fg1.Item(Fg1.RowSel, "BZC_Name") = Col_Name
        Fg1.Item(Fg1.RowSel, "BZC_ID") = ID
        Fg1.GotoNextCell("BZC_No")
    End Sub
    Private Sub CB_BZC_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_BZC_FG.GetSearchEvent
        CB_BZC_FG.IDValue = Fg1.Item(Fg1.RowSel, "BZC_ID")
    End Sub
    Sub FG_BZC_No()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("BZC_No").Index)
    End Sub

#End Region
    Dim lastKey As Keys

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        Select Case e.Col
            Case Fg1.Cols("GH").Index
                If Fg1.LastKey = Keys.Enter Then
                    Dim gh As String = Fg1.Item(Fg1.RowSel, "GH")
                    Dim s As String = ""
                    s = gh.Replace("GY", "")
                    s = s.Replace("-", "")
                    gh = "GY" & s
                    Fg1.Item(Fg1.RowSel, "GH") = gh
                    Dim msg As DtReturnMsg = Dao.Produce_GetById(gh)
                    If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                        SetProduce(msg.Dt.Rows(0))
                    Else

                        ShowErrMsg("没有找到对应的缸号[" & Fg1.Item(Fg1.RowSel, "GH") & "] 信息!", AddressOf FG_NoGH)

                        'Fg1.Focus()
                        'Fg1.StartEditing()
                        'Fg1.StartEditing(e.Row, e.Col)
                    End If
                End If
                'Case Fg1.Cols("BZC_No").Index
                '    If Fg1.LastKey = Keys.Enter Then
                '        CB_BZC_FG.Col_SelOne()
                '        If Fg1.Item(e.Row, "BZC_Name") = "" Then
                '            ShowErrMsg("请输入一个色号!", AddressOf FG_BZC_No)
                '        End If
                '    Else
                '        '非正当离开时候清空
                '        If Fg1.LastText <> IsNull(Fg1.Item(e.Row, "BZC_No"), "") AndAlso IsBZCSelect = False Then Fg1.Item(e.Row, "BZC_Name") = ""
                '        IsBZCSelect = False
                '    End If
                'Case Fg1.Cols("BZ_No").Index
                '    If Fg1.LastKey = Keys.Enter Then
                '        CB_BZ_FG.Col_SelOne()
                '        If Fg1.Item(e.Row, "BZ_Name") = "" Then
                '            ShowErrMsg("请输入一个布种编号!", AddressOf FG_BZ_No)
                '        End If
                '    Else
                '        '非正当离开时候清空
                '        If Fg1.LastText <> IsNull(Fg1.Item(e.Row, "BZ_No"), "") AndAlso IsBZSelect = False Then Fg1.Item(e.Row, "BZ_Name") = ""
                '        IsBZSelect = False
                '    End If
                'Case Fg1.Cols("BZ_ID").Index
                '    If lastKey = Keys.Enter Then

                '        Bz_List1.Col_SelOne()
                '        If Fg1.Item(e.Row, "BZ_ID") = "" Then
                '            ShowErrMsg("请输入一个布种编号!", AddressOf FG_BZ_ID)
                '        End If
                '    Else
                '        '非正当离开时候清空
                '        '   If FgLastText <> IsNull(Fg1.Item(e.Row, "BZ_ID"), "") Then Fg1.Item(e.Row, "BZ_Name") = ""
                '    End If
                'Case Fg1.Cols("BZC_ID").Index
                '    If lastKey = Keys.Enter Then

                '        BzC_List1.Col_SelOne()
                '        If Fg1.Item(e.Row, "BZC_ID") = "" Then
                '            ShowErrMsg("请输入一个布种色号!", AddressOf FG_BZ_ID)
                '        End If
                '    Else
                '        '非正当离开时候清空
                '        '    If FgLastText <> IsNull(Fg1.Item(e.Row, "BZ_ID"), "") Then Fg1.Item(e.Row, "BZC_Name") = ""
                '    End If
            Case Else
                If Fg1.LastKey = Keys.Enter Then
                    Fg1.GotoNextCell()
                End If
        End Select
        CaculateSumAmount()
    End Sub

    Sub FG_NoGH()
        Fg1.Focus()
        Fg1.StartEditing()
        Fg1.StartEditing(Fg1.RowSel, Fg1.ColSel)
    End Sub

    'Sub FG_BZ_ID()
    '    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("BZ_ID").Index)
    'End Sub

    'Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles Fg1.KeyDownEdit
    '    lastKey = e.KeyCode
    '    If e.Col = Fg1.Cols("GH").Index Then
    '        If e.KeyCode = Keys.Add Then
    '            ShowProduce()
    '            e.Handled = True
    '        End If

    '    Else
    '        If e.Col = Fg1.Cols("BZ_ID").Index Then
    '            If (lastKey = Keys.Down OrElse lastKey = Keys.Up) AndAlso Fg1.CanEditing Then
    '                Bz_List1.FG_KeyDown(lastKey)
    '                e.Handled = True
    '            End If
    '        ElseIf e.Col = Fg1.Cols("BZC_ID").Index Then
    '            If (lastKey = Keys.Down OrElse lastKey = Keys.Up) AndAlso Fg1.CanEditing Then
    '                BzC_List1.FG_KeyDown(lastKey)
    '                e.Handled = True

    '            End If
    '        End If
    '    End If


    'End Sub


#End Region
#Region "搜索缸号"


    Sub ShowProduce()
        Try
            Dim f As PClass.BaseForm = LoadFormIDToChild(30000, Me)
            f.IsSel = True
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)

            AddHandler VF.ClosedX, AddressOf SetProduce
            VF.Show()
        Catch ex As Exception
            DebugToLog(ex)
        End Try
    End Sub
    Sub SetProduce()
        Dim dr As DataRow = Me.ReturnObj
        SetProduce(dr)
    End Sub
    Sub SetProduce(ByVal dr As DataRow)
        ' Dim dr As DataRow = Me.ReturnObj
        If Not dr Is Nothing AndAlso Fg1.RowSel > 0 Then
            Fg1.Item(Fg1.RowSel, "GH") = dr("GH")
            '  Fg1.Item(Fg1.RowSel, "OrderBill") = dr("Contract")
            Fg1.Item(Fg1.RowSel, "GH") = dr("GH")
            '    Fg1.Item(Fg1.RowSel, "LuoSeDate") = dr("Date_LuoSe")
            Fg1.Item(Fg1.RowSel, "Client_Name") = dr("Client_Name")
            Fg1.Item(Fg1.RowSel, "Client_Name") = dr("Client_Name")
            '    Fg1.Item(Fg1.RowSel, "BZ_ID") = dr("BZ_ID")
            '   Fg1.Item(Fg1.RowSel, "BZ_No") = dr("BZ_No")
            Fg1.Item(Fg1.RowSel, "BZ_Name") = (dr("BZ_No") & "#" & dr("BZ_Name")).ToString.Replace("##", "#")
            '  Fg1.Item(Fg1.RowSel, "BZC_ID") = dr("BZC_ID")
            '      Fg1.Item(Fg1.RowSel, "BZC_No") = dr("BZC_No")
            Fg1.Item(Fg1.RowSel, "BZC_Name") = (dr("ClientBzc") & "#" & dr("BZC_No") & "#" & ("000000" & dr("BZC_Name")).ToString.Substring(6)).ToString.Replace("##", "#")
            '      Fg1.Item(Fg1.RowSel, "Qty") = dr("CR_LuoSeBzCount")
            '    Fg1.Item(Fg1.RowSel, "PWeight") = dr("PB_ZLSum")
            Fg1.Item(Fg1.RowSel, "Weight") = dr("PB_ZLSum")
            Fg1.Item(Fg1.RowSel, "PB_CountSum") = dr("PB_CountSum")
            '  Fg1.Item(Fg1.RowSel, "JiaGongNeiRong") = dr("ProcessType")
            'Dim jiaDai As Boolean = IsNull(dr("CR_ShuangJiaoDai"), False)
            'If jiaDai Then
            '    Fg1.Item(Fg1.RowSel, "JiaoDai") = "双"
            'Else
            '    Fg1.Item(Fg1.RowSel, "JiaoDai") = "单"
            'End If
            '   Fg1.Item(Fg1.RowSel, "JiaoDai") =IsNull(Fg1.Item(Fg1.RowSel, "CR_ShuangJiaoDai"), False):"单""双"
            '  Fg1.Item(Fg1.RowSel, "CSpec") = IsNull(dr("CR_ShiYong"), "") & " " & IsNull(dr("CR_BianDuiBian"), "") & " " & IsNull(dr("CR_KeZhong"), "")
            '    Fg1.Item(Fg1.RowSel, "ZhiTong") = dr("ZhiTong")
            '    Fg1.Item(Fg1.RowSel, "AddWeight") = dr("JiaZhong")
            Fg1.GotoNextCell()

        End If
    End Sub

#End Region
    '#Region "搜索布种,色号"



    '    'Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
    '    '    ShowList()
    '    'End Sub
    '    'Dim FgLastText As String = ""
    '    'Private Sub Fg1_CheckEditing(ByVal sender As Object, ByRef e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.CheckEditing
    '    '    lastKey = 0
    '    '    ShowList()
    '    '    FgLastText = IsNull(Fg1.Item(e.Row, e.Col), "")
    '    'End Sub

    '    '''' <summary>
    '    '''' 显示布种列表
    '    '''' </summary>
    '    '''' <remarks></remarks>
    '    'Sub ShowList()
    '    '    Dim C As C1.Win.C1FlexGrid.Column = Fg1.Cols(Fg1.ColSel)
    '    '    Dim R As C1.Win.C1FlexGrid.Row = Fg1.Rows(Fg1.RowSel)
    '    '    If Fg1.ColSel = Fg1.Cols("BZ_ID").Index Then


    '    '        Bz_List1.Left = Fg1.Left + C.Left + GB_List.Left + PanelFG.Left + PanelMain.Left
    '    '        Bz_List1.Top = Fg1.Top + R.Top + R.HeightDisplay + Fg1.ScrollPosition.Y + 2 + GB_List.Top + PanelFG.Top + PanelMain.Top
    '    '        If Bz_List1.Top + Bz_List1.Height > Me.Height Then
    '    '            Bz_List1.Top = Bz_List1.Top - Bz_List1.Height - R.HeightDisplay - 4
    '    '        End If
    '    '        Bz_List1.FG_Refresh()
    '    '    ElseIf Fg1.ColSel = Fg1.Cols("BZC_ID").Index Then
    '    '        BzC_List1.Left = Fg1.Left + C.Left + GB_List.Left + PanelFG.Left + PanelMain.Left
    '    '        BzC_List1.Top = Fg1.Top + R.Top + R.HeightDisplay + Fg1.ScrollPosition.Y + 2 + GB_List.Top + PanelFG.Top + PanelMain.Top
    '    '        If BzC_List1.Top + BzC_List1.Height > Me.Height Then
    '    '            BzC_List1.Top = BzC_List1.Top - BzC_List1.Height - R.HeightDisplay - 4
    '    '        End If
    '    '        BzC_List1.FG_Refresh()

    '    '    End If
    '    'End Sub

    '    Private Sub Bz_List1_Bz_Sel(ByVal BZ_ID As String, ByVal Bz_Name As String, ByVal id As String)

    '    End Sub

    '    'Private Sub Bz_List1_GetFocusState(ByRef HasFocused As Boolean) Handles Bz_List1.GetFocusState
    '    '    If (Fg1.Editor Is Nothing OrElse Fg1.Editor.Focused = False) Then
    '    '        HasFocused = False
    '    '    Else
    '    '        If Fg1.ColSel = Fg1.Cols("BZ_ID").Index Then
    '    '            HasFocused = True
    '    '        Else
    '    '            HasFocused = False
    '    '        End If
    '    '    End If
    '    'End Sub


    '    'Private Sub Bz_List1_GetSearchEvent(ByRef BZ_ID As String, ByRef Bz_Name As String, ByVal Cancel As Boolean) Handles Bz_List1.GetSearchEvent
    '    '    If Fg1.RowSel > 0 Then
    '    '        If Fg1.Editor Is Nothing Then
    '    '            BZ_ID = IsNull(Fg1.Item(Fg1.RowSel, "BZ_ID"), "")
    '    '        Else
    '    '            BZ_ID = Fg1.Editor.Text
    '    '        End If
    '    '        Bz_Name = IsNull(Fg1.Item(Fg1.RowSel, "BZ_Name"), "")
    '    '    Else
    '    '        Cancel = True
    '    '    End If
    '    'End Sub



    '    'Private Sub BzC_List1_GetFocusState(ByRef HasFocused As Boolean) Handles BzC_List1.GetFocusState
    '    '    If (Fg1.Editor Is Nothing OrElse Fg1.Editor.Focused = False) Then
    '    '        HasFocused = False
    '    '    Else
    '    '        If Fg1.ColSel = Fg1.Cols("BZC_ID").Index Then
    '    '            HasFocused = True
    '    '        Else
    '    '            HasFocused = False
    '    '        End If
    '    '    End If
    '    'End Sub


    '    'Private Sub BzC_List1_GetSearchEvent(ByRef BZ_ID As String, ByRef Bz_Name As String, ByVal Cancel As Boolean) Handles BzC_List1.GetSearchEvent
    '    '    If Fg1.RowSel > 0 Then
    '    '        If Fg1.Editor Is Nothing Then
    '    '            BZ_ID = IsNull(Fg1.Item(Fg1.RowSel, "BZC_ID"), "")
    '    '        Else
    '    '            BZ_ID = Fg1.Editor.Text
    '    '        End If
    '    '        Bz_Name = IsNull(Fg1.Item(Fg1.RowSel, "BZC_Name"), "")
    '    '    Else
    '    '        Cancel = True
    '    '    End If
    '    'End Sub

    '    'Private Sub Fg1_KeyPressEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyPressEditEventArgs) Handles Fg1.KeyPressEdit
    '    '    If e.Col = Fg1.Cols("BZ_ID").Index Then
    '    '        '    If FgLastText <> IsNull(Fg1.Editor.Text, "") Then Fg1.Item(e.Row, "BZ_Name") = ""
    '    '        Bz_List1.StartSearch()
    '    '    ElseIf e.Col = Fg1.Cols("BZC_ID").Index Then
    '    '        '      If FgLastText <> IsNull(Fg1.Editor.Text, "") Then Fg1.Item(e.Row, "BZC_Name") = ""
    '    '        BzC_List1.StartSearch()
    '    '    End If

    '    'End Sub

    '#End Region


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
            ComFun.DelBillNewID(BillType.OutWork, Bill_ID)
            Bill_ID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DP_Date.Value <> Bill_ID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.OutWork, DP_Date.Value, Bill_ID)
                If R.IsOk Then
                    Bill_ID_Date = R.NewIdDate
                    DP_Date.MinDate = R.MaxDate.AddDays(1)
                    DP_Date.Value = R.NewIdDate
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

    Private Sub DTP_sDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DP_Date.Validated
        GetNewID()
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
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Dim R As New R40011_Outwork
        R.Start(TB_ID.Text, DoOperator)
    End Sub

#End Region

#Region "双击获取新编号"


    Private Sub TB_ID_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_ID.MouseDoubleClick
        If Mode = Mode_Enum.Add Then
            GetNewID()
        End If

    End Sub
#End Region

#Region "选择车牌"
    'Private Sub CB_ChePai_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ChePai.SelectedIndexChanged
    '    'If isLoaded Then
    '    CB_SiJi.Text = CB_ChePai.SelectedValue
    '    ' End If
    'End Sub
#End Region

#Region "已收回单"

    Private Sub CKB_SetReceipt_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CKB_SetReceipt.CheckedChanged
        If Mode = Mode_Enum.Modify And isLoaded Then
            Dao.OutWork_SetReceipt(TB_ID.Text, CKB_SetReceipt.Checked)
        End If
    End Sub
#End Region

#Region "仓库确认"
    Sub SaveOutworkAndComfirm()

        SaveoutWork(True)
    End Sub
    ''' <summary>
    ''' 仓库确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Store_Comfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Store_Comfirm.Click
        Fg1.FinishEditing()
        If CheckForm() Then
            ShowConfirm("是否要仓库确认?", AddressOf SaveOutworkAndComfirm)
            'If Mode = Mode_Enum.Add Then
            '    ShowConfirm("是否保存新[" & Ch_Name & "]单?                         ", "新增" & Ch_Name, "新增并仓库确认", "取消", AddressOf SaveBZSH, AddressOf SaveBZSHAndComfirm, AddressOf DoNothing)
            'Else
            '    ShowConfirm("修改[" & Ch_Name & "]单?                           ", "修改" & Ch_Name, "修改并仓库确认", "取消", AddressOf SaveBZSH, AddressOf SaveBZSHAndComfirm, AddressOf DoNothing)
            'End If
        End If
        '   ShowConfirm("是否要仓库确认?", AddressOf Comfirm)
    End Sub


    Private Sub Comfirm()
        Dim R As MsgReturn = Dao.OutWork_Comfirm(TB_ID.Text, Enum_BZSHState.Store_Comfirm)
        If R.IsOk And R.Msg.StartsWith("1") Then
            ShowOk("确认成功.")
            Me_Refresh()
        Else
            ShowErrMsg(R.Msg.Substring(1))
        End If
    End Sub
    ''' <summary>
    ''' 取消确认
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_UnComfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnComfirm.Click
        ShowConfirm("是否要取消仓库确认?", AddressOf UnComfirm)
    End Sub

    Private Sub UnComfirm()
        Dim R As MsgReturn = Dao.OutWork_Comfirm(TB_ID.Text, Enum_BZSHState.AddNew)
        If R.IsOk Then
            Me_Refresh()
        Else
            Try
                ShowErrMsg(R.Msg.Substring(1))
            Catch ex As Exception

            End Try

        End If
    End Sub
#End Region
#Region "作废"


    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Invoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInvalid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf OutWorkInValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub OutWorkInValid()
        Dim msg As MsgReturn = Dao.OutWork_InValid(TB_ID.Text, Enum_State.Invoid)
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
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf OutWorkUuInValid)
    End Sub

    ''' <summary>
    ''' 反作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub OutWorkUuInValid()
        Dim msg As MsgReturn = Dao.OutWork_InValid(TB_ID.Text, Enum_State.AddNew)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

#End Region
    Private Sub CB_JGDW_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_JGDW.Col_Sel
        TB_JGDWName.Text = Col_Name
    End Sub

    Private Sub CB_JGDW_SetEmpty() Handles CB_JGDW.SetEmpty
        TB_JGDWName.Text = ""
        CB_JGDW.IDValue = 0
    End Sub


End Class
Partial Friend Class Dao


    ''' <summary>
    ''' 作废出库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="State">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_InValid(ByVal _ID As String, ByVal State As Enum_State) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("State", State)
        paraMap.Add("UPD_USER", User_Display)
        paraMap.Add("UPD_DATE", GetTime)

        Dim R As MsgReturn = SqlStrToOneStr("Update T40002_OutWork_Table set State=@State,UPD_USER=@UPD_USER ,UPD_DATE=@UPD_DATE  where ID=@ID  ", paraMap)
        Dim s As String = IIf(State = Enum_State.Invoid, "作废", "还原")
        If R.IsOk Then
            R.Msg = OutWork_DB_NAME & s & "成功！"
        Else
            R.Msg = OutWork_DB_NAME & s & "失败！" & R.Msg

        End If
        Return R
    End Function





    ''' <summary>
    ''' 更新已收回单的状态
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="gotReceipt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_SetReceipt(ByVal _ID As String, Optional ByVal gotReceipt As Boolean = False) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _ID)
        p.Add("GotReceipt", gotReceipt)
        Return RunSQL("Update T40002_OutWork_Table set GotReceipt=@GotReceipt where  ID=@ID", p)
    End Function

    ''' <summary>
    ''' 确认，取消确认
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsComfirm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OutWork_Comfirm(ByVal _ID As String, ByVal IsComfirm As Enum_BZSHState)
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _ID)
        p.Add("State", IsComfirm)
        p.Add("State_User", PClass.PClass.User_Name)
        Return SqlStrToOneStr("P40010_Comfirm", p, True)
    End Function
End Class