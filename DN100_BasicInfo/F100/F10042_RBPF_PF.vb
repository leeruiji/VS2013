Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport
Imports C1.Win.C1FlexGrid

Public Class F10042_RBPF_PF
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
        ID = 10040
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Invoid, Cmd_Invoid)
        Control_CheckRight(ID, ClassMain.UnInvoid, Cmd_UnInvoid)
    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        Fg1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Fg1.Rows.Count = 1
        Fg1.Cols("WL_No").Editor = CB_WL_FG

        CB_FounderName.Text = User_Name

        Fg1.IniColsSize()
        FormCheckRight()
        Ch_Name = "染部配方明细"

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
                '      If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub

                Btn_Preview.Enabled = False
                Btn_Print.Enabled = False
                If Me.isCopy = False Then
                    Fg1.Rows.Count = 1
                Else
                    Me.Title = Ch_Name & " - 复制"
                End If
                ' Fg1.Rows.Count = 1
                '   Fg1.Cols("UpdQty").Visible = False
                Fg1.Cols("Qty").AllowEditing = True
                CaculateSumAmount()
                
            Case Mode_Enum.Modify
                CB_FounderName.Enabled = True
        End Select
        Me_Refresh()
    End Sub


    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.RBPF_PF_GetTable(BZC_ID, Me.PF_ID)
        dtTable = msg.Dt
        Dim msgList As DtReturnMsg = Dao.RBPF_PF_GetList(Me.BZC_ID, Me.PF_ID)
        If msgList.IsOk Then
            dtList = msgList.Dt
            CreateTreeiew(dtList, Fg1, MapGY, Me, "DyingStep")
        End If
        msg = Dao.BZC_GetById(BZC_ID)
        If msg.IsOk Then
            If msg.Dt.Rows.Count > 0 Then
                TB_Bzc_No.Tag = msg.Dt.Rows(0)("ID")
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



        GetControlValue(dtTable.Rows(0), TB_PF_Name)

        GetControlValue(dtTable.Rows(0), TB_AdjusterName)
        GetControlValue(dtTable.Rows(0), DP_FoundDate)

        dtTable.Rows(0)("GY_ID1") = LabelGY1.Tag
        dtTable.Rows(0)("GY_ID2") = LabelGY2.Tag

        Me.dtTable.Rows(0)("FounderName") = CB_FounderName.Text
        dtTable.Rows(0)("Adjuster") = CB_FounderName.IDAsInt
        dtTable.Rows(0)("State") = Enum_State.AddNew

        Dim dt As DataTable = dtList.Clone
        Dim dr As DataRow
        For i = 1 To Fg1.Rows.Count - 1
            If Val(Fg1.Item(i, "WL_ID")) = 0 AndAlso Fg1.Item(i, "DyingStep") = "" Then
                Continue For
            End If
            dr = dt.NewRow
            dr("BZC_ID") = BZC_ID
            dr("ID") = PF_ID
            If Fg1.Item(i, "IsGY") Then
                dr("DyingStep") = ""
                dr("Qty") = 1
            Else
                dr("DyingStep") = Fg1.Item(i, "DyingStep")
                dr("Qty") = Val(Fg1.Item(i, "Qty"))
            End If
            dr("GYSetID") = Val(Fg1.Item(i, "GYSetID"))
            dr("WL_ID") = Val(Fg1.Item(i, "WL_ID"))
            dr("IsPageTwo") = Fg1.Item(i, "IsPageTwo")
            dr("IsGY") = IIf(Fg1.Item(i, "IsGY") Is Nothing, False, Fg1.Item(i, "IsGY"))
            dr("Gy_Name") = IIf(Fg1.Item(i, "GY_Name") Is Nothing, "", Fg1.Item(i, "GY_Name"))
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
            Cmd_Invoid.Visible = False
            Cmd_UnInvoid.Visible = False

        Else

            If IsNull(dtTable.Rows(0)("State"), 0) = Enum_State.AddNew Then
                LB_Invoid.Visible = False
                Cmd_Invoid.Visible = True
                Cmd_UnInvoid.Visible = False
                Cmd_Modify.Visible = True
            Else
                LB_Invoid.Visible = True
                Cmd_Invoid.Visible = False
                Cmd_UnInvoid.Visible = True
                Cmd_Modify.Visible = False
            End If

        End If


        CB_FounderName.Text = IsNull(dtTable.Rows(0)("FounderName"), "")
        CB_FounderName.Col_SelOne()


        SetControlValue(dtTable.Rows(0), TB_PF_Name, "A")

        SetControlValue(dtTable.Rows(0), TB_AdjusterName)
        SetControlValue(dtTable.Rows(0), DP_FoundDate)

        SetControlValue(dtTable.Rows(0), TB_UpdName)

        LabelGY1.Tag = IsNull(dtTable.Rows(0)("GY_ID1"), 0)
        LabelGY2.Tag = IsNull(dtTable.Rows(0)("GY_ID2"), 0)
        If LabelGY1.Tag <> 0 Then
            Dim T As New Threading.Thread(AddressOf LoadGyImg1)
            T.Start(LabelGY1.Tag)
        End If
        If LabelGY2.Tag <> 0 Then
            Dim T As New Threading.Thread(AddressOf LoadGyImg2)
            T.Start(LabelGY2.Tag)
        End If

        If Me.isCopy Then
            Me.TB_UpdName.Text = ""
            For Each dr As DataRow In dtList.Rows
                ' dr("UpdQty") = 0
                dr("ID") = Me.PF_ID
            Next
        End If


 



        '    Fg1.DtToSetFG(dtList)
    End Sub

    Sub LockForm(ByVal Lock As Boolean)

        TB_PF_Name.ReadOnly = Lock
        CB_FounderName.Enabled = Not Lock
        TB_AdjusterName.Enabled = Not Lock

        Fg1.Cols("Qty").AllowEditing = Lock
        Fg1.Cols("DyingStep").AllowEditing = Not Lock
        Fg1.Cols("WL_No").AllowEditing = Not Lock
        Fg1.Cols("WL_Spec").AllowEditing = Not Lock
        ' Fg1.Cols("UpdQty").Visible = Lock

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
            ShowConfirm("是否保存" & Ch_Name & " 的修改?", AddressOf SaveRBPF)
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveRBPF(Optional ByVal Audit As Boolean = False)
        Dim R As New MsgReturn
        GetList()
        If Audit Then
            dtTable.Rows(0).Item("Check_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.RBPF_PF_Add(dtTable, dtList)
        ElseIf Me.Mode = Mode_Enum.Modify Then
            R = Dao.RBPF_PF_Save(dtTable, dtList)
        End If

        If R.IsOk Then
            PF_ID = dtTable.Rows(0).Item("ID")
            LastForm.ReturnId = TB_PF_Name.Text
            Mode = Mode_Enum.Modify
            'If Audit Then
            '    Dim msg As MsgReturn = Dao.RBPF_PFAudited(BZC_ID, PF_ID, True)
            '    If msg.IsOk Then
            '        Me_Refresh()
            '        ShowOk(msg.Msg)
            '    Else
            '        ShowErrMsg(msg.Msg)
            '    End If
            '    Exit Sub
            'End If
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
        'Dim msg As MsgReturn = Dao.RBPF_PF_CheckName(Me.PF_ID, Me.BZC_ID, TB_PF_Name.Text)
        'If msg.IsOk = False Then
        '    ShowErrMsg(msg.Msg, AddressOf TB_PF_Name.Focus)
        '    Return False
        'End If
        If CB_FounderName.Text = "" Then
            ShowErrMsg(Label21.Text.Replace(":", "") & "不能为空！", AddressOf CB_FounderName.Focus)
            Return False
        End If
        CaculateSumAmount()
        ReSetPageTwo()
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

    Private Sub Cmd_AddWL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddWL.Click
        AddChildRow()
    End Sub

    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        AddRow()
    End Sub

    Sub AddRow()
        Dim C As Integer = Fg1.RowSel
        If Fg1.RowSel > 0 Then
            Dim nd As Node = Fg1.Rows(C).Node
            If nd Is Nothing Then
                Exit Sub
            End If
            Dim isGy As Boolean = IIf(Fg1.Item(Fg1.RowSel, "IsGy") Is Nothing, False, Fg1.Item(Fg1.RowSel, "IsGy"))
            Dim rowIndex As Integer = nd.AddNode(NodeTypeEnum.NextSibling, "", 0, Nothing).Row.Index
            Fg1.Item(rowIndex, "IsGY") = False
            If isGy Then
                Fg1.Item(rowIndex, "GYSetID") = 0

            Else
                Fg1.Item(rowIndex, "GYSetID") = Fg1.Item(C, "GYSetID")
            End If
            C = rowIndex
        Else
            Fg1.Rows.InsertNode(Fg1.Rows.Count, 0)
            C = Fg1.Rows.Count - 1
            Fg1.Item(C, "GYSetID") = 0
            Fg1.Item(C, "IsGY") = False
        End If
        Fg1.ReAddIndex()
        Fg1.RowSel = C
        Fg1.Row = C
        Fg1.StartEditing(C, Fg1.Cols("WL_No").Index)
        ReSetPageTwo()
    End Sub


    Sub AddChildRow()
        Dim C As Integer = Fg1.RowSel
        If Fg1.RowSel > 0 Then
            Dim isGy As Boolean = IIf(Fg1.Item(Fg1.RowSel, "IsGy") Is Nothing, False, Fg1.Item(Fg1.RowSel, "IsGy"))
            If isGy = False Then
                Exit Sub
            End If
            Dim nd As Node = Fg1.Rows(C).Node
            If nd Is Nothing Then
                Exit Sub
            End If
            Dim rowIndex As Integer = nd.AddNode(NodeTypeEnum.LastChild, "", 0, Nothing).Row.Index
            Fg1.Item(rowIndex, "IsGY") = False
            If Fg1.Item(rowIndex, "IsGY") = False Then
                Fg1.Item(rowIndex, "GYSetID") = Fg1.Item(C, "GYSetID")
            Else
                Fg1.Item(rowIndex, "GYSetID") = 0
            End If
            C = rowIndex
        Else
            Exit Sub
        End If
        Fg1.ReAddIndex()
        Fg1.RowSel = C
        Fg1.Row = C
        Fg1.StartEditing(C, Fg1.Cols("WL_No").Index)
    End Sub
    'Sub AddRow(Optional ByVal isRoot As Boolean = False)
    '    Dim C As Integer = Fg1.RowSel
    '    If Fg1.RowSel > 0 Then
    '        Dim nd As Node = Fg1.Rows(C).Node
    '        If nd Is Nothing Then
    '            Exit Sub
    '        End If
    '        Dim rowIndex As Integer
    '        If isRoot = False Then
    '            If nd.Level = 0 AndAlso IIf(Fg1.Item(Fg1.RowSel, "IsGY").GetType Is GetType(String), False, Fg1.Item(rowIndex, "IsGY")) Then
    '                rowIndex = nd.AddNode(NodeTypeEnum.LastChild, "", 0, Nothing).Row.Index
    '            Else
    '                rowIndex = nd.AddNode(NodeTypeEnum.NextSibling, "", 0, Nothing).Row.Index
    '            End If

    '            Fg1.Item(rowIndex, "GYSetID") = Fg1.Item(C, "GYSetID")

    '        Else
    '            If nd.Level = 0 Then
    '                rowIndex = nd.AddNode(NodeTypeEnum.NextSibling, "", 0, Nothing).Row.Index

    '            Else

    '                Fg1.Rows.InsertNode(Fg1.Rows.Count, 0)
    '                rowIndex = Fg1.Rows.Count - 1
    '            End If
    '            Fg1.Item(rowIndex, "GYSetID") = 0
    '        End If

    '        Fg1.Item(rowIndex, "IsGY") = False
    '        'If Fg1.Item(rowIndex, "IsGY") = False Then

    '        'Else

    '        'End If
    '        C = rowIndex
    '    Else
    '        Fg1.Rows.InsertNode(Fg1.Rows.Count, 0)
    '        C = Fg1.Rows.Count - 1
    '        Fg1.Item(C, "GYSetID") = 0
    '        Fg1.Item(C, "IsGY") = False
    '    End If
    '    Fg1.ReAddIndex()
    '    Fg1.RowSel = C
    '    Fg1.Row = C
    '    Fg1.StartEditing(C, Fg1.Cols("WL_No").Index)
    'End Sub

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
                Dim gySetID = Val(Fg1.Item(Fg1.RowSel, "GYSetID"))
                If Fg1.Item(Fg1.RowSel, "IsGy") = False Then
                    Fg1.Rows.Remove(i)
                    '      MapGY.Remove(gySetID)
                Else

                    For k As Integer = Fg1.Rows.Count - 1 To 1 Step -1
                        If Val(Fg1.Item(k, "GYSetID")) = gySetID Then
                            Fg1.Rows.Remove(k)
                        End If

                    Next
                    '  MapGY.Remove(gySetID)
                End If

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

    Private Sub Fg1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Fg1.MouseClick
        If Fg1.CanEditing = True Then
            If Fg1.MouseCol > 0 AndAlso Fg1.MouseRow > 0 Then
                If Fg1.Cols(Fg1.MouseCol).Name = "IsPageTwo" Then
                    Dim C As Boolean = Fg1.CanEditing
                    Fg1.CanEditing = False
                    Dim B As Boolean = Not Fg1.Item(Fg1.MouseRow, Fg1.MouseCol) = True
                    Fg1.Item(Fg1.MouseRow, Fg1.MouseCol) = B
                    If Fg1.Rows(Fg1.MouseRow).Node.Level = 0 Then
                        Dim i As Integer = Fg1.MouseRow + 1
                        Do While i < Fg1.Rows.Count
                            Fg1.Item(i, "IsPageTwo") = B
                            i = i + 1
                        Loop
                    Else
                        Dim i As Integer = Fg1.MouseRow + 1
                        Do While i < Fg1.Rows.Count

                            Fg1.Item(i, "IsPageTwo") = B
                            i = i + 1
                        Loop
                        i = Fg1.MouseRow - 1
                        Do While i > 0
                            If Fg1.Rows(i).Node.Level = 0 Then
                                Fg1.Item(i, "IsPageTwo") = B
                                Exit Do
                            End If
                            Fg1.Item(i, "IsPageTwo") = B
                            i = i - 1
                        Loop
                    End If
                    Fg1.CanEditing = C
                End If
            End If
        End If
    End Sub
    Sub ReSetPageTwo()
        Dim C As Boolean = Fg1.CanEditing
        Fg1.CanEditing = False
        Dim B As Boolean = False
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If B = False Then
                If Fg1.Item(i, "IsPageTwo") Then
                    B = True
                Else
                    Fg1.Item(i, "IsPageTwo") = False
                End If
            Else
                Fg1.Item(i, "IsPageTwo") = True
            End If
        Next
        Fg1.CanEditing = C
    End Sub

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
            End If
        Else
            If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell()
        End If
    End Sub


    Private Sub Fg1_CheckEditing(ByVal sender As Object, ByRef e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.CheckEditing
        If Fg1.Item(Fg1.RowSel, "IsGY") = True Then
            e.Cancel = True
        End If
    End Sub


    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        If e.Col = "Qty" Then
            If e.Row + 2 > Fg1.Rows.Count And Cmd_AddRow.Enabled Then
                Fg1.Cols("DyingStep").AllowEditing = False
                AddRow()
                Fg1.Cols("DyingStep").AllowEditing = True
            End If
            If e.Row + 2 > Fg1.Rows.Count Then
                e.ToCol = Fg1.Cols("Qty").Index
            Else
                e.ToRow = e.Row + 1
                If Fg1.Item(e.ToRow, "IsGY") = True Then
                    If e.Row + 3 > Fg1.Rows.Count Then
                        Fg1.Cols("DyingStep").AllowEditing = False
                        AddRow()
                        Fg1.Cols("DyingStep").AllowEditing = True
                    Else
                        e.ToRow = e.ToRow + 1
                    End If
                End If
                e.ToCol = Fg1.Cols("WL_No").Index
            End If
        ElseIf e.Col = "WL_No" Then
            e.ToCol = Fg1.Cols("Qty").Index
        ElseIf e.Col = "Qty" Then
            If e.Row + 2 > Fg1.Rows.Count Then
                Exit Sub
            Else
                e.ToRow = e.Row + 1
                If Fg1.Item(e.ToRow, "IsGY") = True Then
                    If e.Row + 3 > Fg1.Rows.Count Then
                        Fg1.Cols("DyingStep").AllowEditing = False
                        AddRow()
                        Fg1.Cols("DyingStep").AllowEditing = True
                    Else
                        e.ToRow = e.ToRow + 1
                    End If
                End If
                e.ToCol = Fg1.Cols("Qty").Index
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


#Region "作废状态"
    ''' <summary>
    ''' 作废状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnInvoid.Click
        ShowConfirm("是否反作废" & Ch_Name & "[" & TB_PF_Name.Text & "] ?", AddressOf UnInvoid)
    End Sub
    Protected Sub Shenhe()
        SaveRBPF(True)
    End Sub

    Private Sub Cmd_Fei_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Invoid.Click
        Dim BZ_li As List(Of String) = TryCast(Me.P_F_RS_Obj, List(Of String))
        If BZ_li.Count > 0 Then
            Dim BZ_Name As New StringBuilder
            BZ_Name.Append("该配方已被:")
            For Each ds As String In BZ_li
                BZ_Name.Append(ds & ",")
            Next
            BZ_Name.AppendLine("引用是否删除？")
            BZ_Name.AppendLine("(注：作废的配方不会再被布种引用)")
            ShowConfirm(BZ_Name.ToString, AddressOf InvoidAndSet)
        Else
            ShowConfirm("是否作废" & Ch_Name & " [" & TB_PF_Name.Text & "]?", AddressOf Invoid)
        End If

    End Sub

    Protected Sub Invoid()
        Dim msg As MsgReturn = Dao.RBPF_PFInvoid(Enum_State.Invoid, BZC_ID, PF_ID)
        If msg.IsOk Then
            ShowOk("［" & TB_PF_Name.Text & "］作废成功")
            Me_Refresh()
            Me.LastForm.ReturnId = TB_PF_Name.Text
        Else
            ShowErrMsg("［" & TB_PF_Name.Text & "］作废失败")
        End If
    End Sub


    Private Sub InvoidAndSet()

        Dim msg As MsgReturn = Dao.RBPF_SetInvoid(Enum_State.Invoid, BZC_ID, PF_ID)
        If msg.IsOk Then
            ShowOk("［" & TB_PF_Name.Text & "］作废成功")
            Me_Refresh()
            Me.LastForm.ReturnId = TB_PF_Name.Text
        Else
            ShowErrMsg("［" & TB_PF_Name.Text & "］作废失败")
        End If

    End Sub





    Protected Sub UnInvoid()
        Dim msg As MsgReturn = Dao.RBPF_PFInvoid(Enum_State.AddNew, BZC_ID, PF_ID)
        If msg.IsOk Then
            ShowOk("［" & TB_PF_Name.Text & "］反作废成功")
            Me_Refresh()
            Me.LastForm.ReturnId = TB_PF_Name.Text
        Else
            ShowErrMsg("［" & TB_PF_Name.Text & "］反作废失败")
        End If
    End Sub

#End Region

    Private Sub TB_PF_Name_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_PF_Name.KeyDown
        If e.KeyCode = Keys.Enter Then
            CB_FounderName.Focus()
        End If
    End Sub

#Region "生成树形菜单"
    Dim MapGY As New Dictionary(Of String, Node)

    Dim selectedDept As String = ""
    Dim selectNode As C1.Win.C1FlexGrid.Node
    Dim DtUser As DataTable
    Dim DtDept As DataTable

#End Region

#Region "选择工艺"
    Private Sub Cmd_SelGy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SelGy.Click
        Dim VF As ViewForm = SelectGY()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf SetGy
            VF.Show()
        End If
    End Sub

    Private Sub Cmd_AddGy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddGy.Click
        Dim VF As ViewForm = SelectGY()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf AddGy
            VF.Show()
        End If
    End Sub
    Private Function SelectGY() As ViewForm
        Dim f As New F10030_GY()
        If f Is Nothing Then Return Nothing
        With f
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        Return VF
    End Function

    ''' <summary>
    ''' 添加到当前节点
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddGy()
        Dim index As Integer = 1
        If Fg1.Rows.Count > 1 Then
            index = Fg1.Rows.Count
        End If
        SetFGGY(index)
    End Sub


    ''' <summary>
    ''' 添加到当前节点
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetGy()
        SetFGGY(GetInsertRowIndex())
    End Sub

    Protected Sub SetFGGY(ByVal StartRow As Integer)
        Try
            If ReturnObj Is Nothing Then
                Exit Sub
            End If
            Dim dr As DataRow = ReturnObj
            Fg1.FinishEditing(True)
            Dim E As Boolean = Fg1.CanEditing
            Dim msg As DtReturnMsg = ComFun.GY_GetList_ByID(IsNull(dr("ID"), 0))
            If msg.Dt.Rows.Count = 0 Then
                ShowErrMsg("你所选的工艺[" & dr("Gy_Name") & "]没有对应的配方不能选择?")
                Exit Sub
            End If
            Dim GYSetID As Integer = GetNewGYSetID()
            Dim node As C1.Win.C1FlexGrid.Node = Fg1.Rows.InsertNode(StartRow, 0)
            Dim B As Boolean
            DrToGoodsNode(dr("Gy_Name"), GYSetID, B, node) '复制
            Me.MapGY.Add(GYSetID, node)

            If msg.IsOk Then
                msg.Dt.Columns.Add("GYSetID", GetType(Integer))
                msg.Dt.Columns.Add("GY_Name", GetType(String))
                msg.Dt.Columns.Add("IsPageTwo", GetType(Boolean))
                Dim i As Integer = 0
                For Each row As DataRow In msg.Dt.Rows
                    row("GYSetID") = GYSetID
                    row("GY_Name") = IsNull(dr("GY_Name"), "")
                    InsertGoodsNode(row, IsNull(row("GYSetID"), 0), node, Fg1, Me, False)
                Next
            End If
            CaculateSumAmount()
            Fg1.ReAddIndex()
            ReSetPageTwo()
            Fg1.CanEditing = E
            Me.ReturnObj = Nothing
        Catch ex As Exception
        End Try
    End Sub


    ''' <summary>
    ''' 计算要插入的位置
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetInsertRowIndex() As Int16
        Dim startRow As Integer = 1
        If Fg1.RowSel > 1 Then
            Dim isGy As Boolean = Fg1.Item(Fg1.RowSel, "IsGy")
            If isGy OrElse Fg1.Rows(Fg1.RowSel).Node.Level = 0 Then
                startRow = Fg1.RowSel
            ElseIf Fg1.Rows(Fg1.RowSel).Node.Level > 0 Then
                For i = Fg1.RowSel To 1 Step -1
                    If Fg1.Rows(i).Node.Level = 0 Then
                        startRow = i
                    End If
                Next
            End If
        End If
        Return startRow
    End Function

    Protected Function GetNewGYSetID() As Integer
        Dim key As Integer = 0
        For Each _Id As Integer In MapGY.Keys
            If key < _Id Then
                key = _Id
            End If
        Next
        Return key + 1
    End Function

    Private Sub LabelGY1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelGY1.DoubleClick
        ShowConfirm("是否删除第一个工艺图?", AddressOf DelGY1)
    End Sub

    Private Sub LabelGY2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelGY2.DoubleClick
        ShowConfirm("是否删除第二个工艺图?", AddressOf DelGY2)
    End Sub



    Sub DelGY1()
        If LabelGY1.Tag IsNot Nothing AndAlso LabelGY1.Tag <> 0 Then
            LabelGY1.Tag = LabelGY2.Tag
            LabelGY1.Text = LabelGY2.Text
            PicGY1.Image = PicGY2.Image
        Else
            LabelGY1.Tag = 0
            LabelGY1.Text = ""
            PicGY1.Image = Nothing
        End If
        LabelGY2.Tag = 0
        LabelGY2.Text = ""
        PicGY2.Image = Nothing
    End Sub
    Sub DelGY2()
        LabelGY2.Tag = 0
        LabelGY2.Text = ""
        PicGY1.Image = Nothing
    End Sub

    Private Sub PicGY1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicGY1.DoubleClick
        Dim VF As ViewForm = SelectGY()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf SetGyImg1
            VF.Show()
        End If
    End Sub


    Private Sub PicGY2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicGY2.DoubleClick
        Dim VF As ViewForm = SelectGY()
        If VF IsNot Nothing Then
            AddHandler VF.ClosedX, AddressOf SetGyImg2
            VF.Show()
        End If
    End Sub
    Private Sub SetGyImg1()
        If ReturnId = "" Then
            Exit Sub
        End If

        LabelGY1.Text = "加载工艺图中..."
        PicGY1.Image = My.Resources.loading
        Dim T As New Threading.Thread(AddressOf LoadGyImg1)
        T.Start(ReturnId)

    End Sub
    Private Sub SetGyImg2()
        If ReturnId = "" Then
            Exit Sub
        End If

        LabelGY2.Text = "加载工艺图中..."
        PicGY2.Image = My.Resources.loading
        Dim T As New Threading.Thread(AddressOf LoadGyImg2)
        T.Start(ReturnId)
    End Sub
#End Region

#Region "异步加载图片"

    Sub LoadGyImg1(ByVal GY_ID As Integer)
        LoadGyImg(1, GY_ID)
    End Sub

    Sub LoadGyImg2(ByVal GY_ID As Integer)
        LoadGyImg(2, GY_ID)
    End Sub

    Sub LoadGyImg(ByVal N As Integer, ByVal GY_ID As Integer)
        If GY_ID = 0 Then
            Exit Sub
        End If
        Dim I As Image = Nothing
        Dim T As String = ""
        Try
            Dim R As DtReturnMsg = Dao.GY_GetById(GY_ID)
            If R.IsOk = True AndAlso R.Dt.Rows.Count > 0 Then
                T = IsNull(R.Dt.Rows(0)("GY_No"), "") & "." & IsNull(R.Dt.Rows(0)("GY_Name"), "")
                If Not R.Dt.Rows(0)("GY_Image") Is DBNull.Value Then
                    Dim ImagArray() As Byte = R.Dt.Rows(0)("GY_Image")
                    Using io As New IO.MemoryStream(ImagArray)
                        Dim bmp As New Bitmap(io)
                        I = bmp
                    End Using
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Me.Invoke(New DSetImg(AddressOf SetImg), N, GY_ID, T, I)
        Catch ex As Exception
        End Try
    End Sub



    Delegate Sub DSetImg(ByVal N As Integer, ByVal Gy_ID As Integer, ByVal T As String, ByVal Img As Image)
    Sub SetImg(ByVal N As Integer, ByVal Gy_ID As Integer, ByVal T As String, ByVal Img As Image)
        If N = 1 Then
            LabelGY1.Tag = Gy_ID
            LabelGY1.Text = T
            PicGY1.Image = Img
            If T = "" Then
                LabelGY1.Text = "请选择工艺图一"
            End If
        Else
            LabelGY2.Tag = Gy_ID
            LabelGY2.Text = T
            PicGY2.Image = Img
            If T = "" Then
                LabelGY1.Text = "请选择工艺图二"
            End If
        End If
    End Sub

#End Region

#Region "工艺图片"
    Private Sub PicGY1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicGY1.MouseEnter
        If PicGY1.Image IsNot Nothing Then
            PicGY1.Width = 480
            PicGY1.Height = 220
            PicGY1.BringToFront()
        End If
    End Sub

    Private Sub PicGY1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicGY1.MouseLeave
        PicGY1.Width = 240
        PicGY1.Height = 110
    End Sub

    Private Sub PicGY2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicGY2.MouseEnter
        If PicGY2.Image IsNot Nothing Then
            PicGY2.Left = 230
            PicGY2.Width = 480
            PicGY2.Height = 220
            PicGY2.BringToFront()
        End If
    End Sub

    Private Sub PicGY2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicGY2.MouseLeave
        PicGY2.Left = 472
        PicGY2.Width = 240
        PicGY2.Height = 110
    End Sub

#End Region

#Region "获取色板配方"
    Private Sub Cmd_SetBZCPF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetBZCPF.Click
        If TB_Bzc_No.Tag Is Nothing Then
            Exit Sub
        End If

        OpenSelBZCPF()


    End Sub


    Private Sub OpenSelBZCPF()
        Dim F As New F10043_RBPF_Sel(TB_Bzc_No.Tag)
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetBZCPF
        VF.Show()
    End Sub


    ''' <summary>
    ''' 获取工艺信息
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetBZCPF()
        Try
            If Me.ReturnId Is Nothing OrElse Val(ReturnId) = 0 Then
                Exit Sub
                'ElseIf Val(ReturnId) = -1 Then
                '    Dim GYSetID As String = GetNewGYSetID()
                '    Dim node As C1.Win.C1FlexGrid.Node = Fg1.Rows.InsertNode(Fg1.Rows.Count, 0)
                '    SetFGTreeRow(node)
                '    DrToGoodsNode(TB_Bzc_No.Text, GYSetID, node) '复制

                '    Me.MapGY.Add(GYSetID, node)

            Else
                Fg1.FinishEditing(True)

                Dim GYSetID As String = GetNewGYSetID()
                'If Me.MapGoodsSet.ContainsKey(GoodsSetSaleID) Then

                '    Exit Sub
                'End If
                Dim msg As DtReturnMsg = Dao.BZCPF_GetPF_List_ByBZCID(Val(ReturnId))
                If msg.IsOk Then
                    Dim E As Boolean = Fg1.CanEditing
                    ''计算要插入的位置
                    Dim startRow As Integer = GetInsertRowIndex()
                    Dim B As Boolean
                    If startRow > 1 Then
                        B = Fg1.Item(startRow, "IsPageTwo")
                    End If
                    Dim node As C1.Win.C1FlexGrid.Node = Fg1.Rows.InsertNode(startRow, 0)
                    SetFGTreeRow(node)
                    DrToGoodsNode(TB_Bzc_No.Text, GYSetID, B, node) '复制

                    Me.MapGY.Add(GYSetID, node)

                    msg.Dt.Columns.Add("GYSetID", GetType(Integer))
                    msg.Dt.Columns.Add("GY_Name", GetType(String))
                    msg.Dt.Columns.Add("IsPageTwo", GetType(Boolean))
                    Dim i As Integer = 0
                    For Each row As DataRow In msg.Dt.Rows
                        row("GYSetID") = GYSetID
                        row("GY_Name") = TB_Bzc_No.Text
                        InsertGoodsNode(row, IsNull(row("GYSetID"), 0), node, Fg1, Me, False)
                    Next
                    'If Val(ReturnId) = -1 AndAlso msg.Dt.Rows.Count = 0 Then
                    '    Dim Row As DataRow = msg.Dt.NewRow
                    '    Row("GYSetID") = GYSetID
                    '    Row("GY_Name") = TB_Bzc_No.Text
                    '    InsertGoodsNode(Row, IsNull(Row("GYSetID"), 0), node, Fg1, Me, False)
                    'End If
                    ReSetPageTwo()
                    Fg1.CanEditing = E
                Else
                    ShowErrMsg("没有找到【" & TB_Bzc_No.Text & "】的配方！")
                    Exit Sub
                End If
                CaculateSumAmount()
                Fg1.ReAddIndex()
                Me.ReturnObj = Nothing
            End If
        Catch ex As Exception

        End Try

    End Sub
#End Region


    Private Sub Fg1_SelectRowChange(ByVal Row As Integer) Handles Fg1.SelectRowChange
        If Fg1.RowSel <= 0 Then
            Exit Sub
        End If
        Try


            Dim isGy As Boolean = IIf(Fg1.Item(Fg1.RowSel, "IsGY") Is Nothing, False, Fg1.Item(Fg1.RowSel, "IsGY"))
            If Fg1.RowSel > 0 AndAlso isGy Then
                Cmd_AddWL.Enabled = True
            Else
                Cmd_AddWL.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub









End Class

Partial Class Dao

#Region "常量"
    ''' <summary>
    ''' 获取编号
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_RBPF_GetPFID = "declare @A Varchar(20)" & vbCrLf & _
       "if exists (select * from  T10012_RB_PF where BZC_ID=@BZC_ID and PF_Name=@PF_Name)" & vbCrLf & _
       "set @A=0" & vbCrLf & _
       "else" & vbCrLf & _
       "begin" & vbCrLf & _
       "insert into T10012_RB_PF (BZC_ID,PF_Name)values(@BZC_ID,@PF_Name)" & vbCrLf & _
       "set @A=@@identity" & vbCrLf & _
       "end" & vbCrLf & _
       "select @A"


    Private Const SQL_RBPF_GetPF = "select * from T10012_RB_PF where  BZC_ID= @BZC_ID and ID=@ID  "

    Private Const SQL_RBPF_SetSate = "UpDate T10012_RB_PF SET State=@State Where BZC_ID=@BZC_ID and ID=@ID "

    Private Const SQL_BZC_SetPF_ID = " UpDate T10003_BZC SET PF_ID='' Where ID=@BZC_ID and PF_ID=@PF_ID  "
    Private Const SQL_UpDate_RB_PF_Count = " UpDate T10003_BZC set RB_PF_Count=(select Count(*) from T10012_RB_PF P where BZC_ID=@BZC_ID and isnull(State,0)=0)Where ID=@BZC_ID"
    Private Const SQL_BzcLink_SetPF_ID = " UpDate T10009_BzcLinkBz  SET PF_ID='' Where BZC_ID=@BZC_ID and PF_ID=@PF_ID  "

    Private Const SQL_RBPF_PF_GeList = "select * from T10013_RB_PFList where  BZC_ID= @BZC_ID and ID=@ID  "


    Public Const SQL_RBPF_PF_GeList_WithName = "select P.*,WL_Name,WL_No,WL_Spec from T10013_RB_PFList  P left join T10001_WL W on P.WL_ID=W.ID where BZC_ID= @BZC_ID and P.ID=@ID order by P.Line"


#End Region

#Region "查询"
    Public Shared Function RBPF_PF_GetTable(ByVal _BzcID As Integer, ByVal _PFID As Integer) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("BZC_ID", _BzcID)
        p.Add("ID", _PFID)
        Return PClass.PClass.SqlStrToDt(SQL_RBPF_GetPF, p)
    End Function

    Public Shared Function RBPF_PF_GetList(ByVal _BzcID As Integer, ByVal _PFID As Integer) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("BZC_ID", _BzcID)
        p.Add("ID", _PFID)
        Return PClass.PClass.SqlStrToDt(SQL_RBPF_PF_GeList_WithName, p)
    End Function

    Public Shared Function RBPF_PFInvoid(ByVal State As Enum_State, ByVal Bzc_id As Integer, ByVal id As Integer) As MsgReturn     
        Dim SQL As New StringBuilder
        SQL.AppendLine(SQL_RBPF_SetSate)
        SQL.AppendLine(SQL_UpDate_RB_PF_Count)

        Dim p As New Dictionary(Of String, Object)
        p.Add("State", State)
        p.Add("BZC_ID", Bzc_id)
        p.Add("ID", id)
        Return PClass.PClass.RunSQL(SQL.ToString, p)
    End Function

    Public Shared Function RBPF_SetInvoid(ByVal State As Enum_State, ByVal Bzc_id As Integer, ByVal id As Integer) As MsgReturn
        Dim SQL As New StringBuilder
        SQL.AppendLine(SQL_BZC_SetPF_ID)
        SQL.AppendLine(SQL_BzcLink_SetPF_ID)
        SQL.AppendLine(SQL_RBPF_SetSate)
        SQL.AppendLine(SQL_UpDate_RB_PF_Count)
        Dim p As New Dictionary(Of String, Object)
        p.Add("State", State)
        p.Add("BZC_ID", Bzc_id)
        p.Add("ID", id)
        p.Add("PF_ID", id)
        Return PClass.PClass.RunSQL(SQL.ToString, p)
    End Function





#End Region

#Region "修改"

    Public Shared Function RBPF_GetPFID(ByVal BZC_ID As String, ByVal PF_Name As String) As Integer
        Dim R As New MsgReturn
        Dim para As New Dictionary(Of String, Object)
        para.Add("@BZC_ID", BZC_ID)
        para.Add("@PF_Name", PF_Name)
        R = PClass.PClass.SqlStrToOneStr(SQL_RBPF_GetPFID, para)
        If R.IsOk Then
            Return Val(R.Msg)
        Else
            Return 0
        End If
    End Function

    Public Shared Function RBPF_PF_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)


        Dim BZCID As String = Val(dtTable.Rows(0)("BZC_ID"))
        Dim PFID As String = RBPF_GetPFID(BZCID, dtTable.Rows(0)("PF_Name"))
        If PFID = 0 Then
            R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]已经存在!请检查后重新保存"
            Return R
        Else
            dtTable.Rows(0)("ID") = PFID
            For Each row As DataRow In dtList.Rows
                row("ID") = PFID
            Next
        End If
        paraMap.Add("ID", PFID)
        paraMap.Add("BZC_ID", BZCID)
        Try
            sqlMap.Add("Table", SQL_RBPF_GetPF)
            sqlMap.Add("List", SQL_RBPF_GeList_ByID)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                DtToUpDate(msg)
                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加错误!"
            End If
            Return R
        Catch ex As Exception
            Try
                RunSQL(SQL_BZCPF_Del, paraMap)
            Catch ex1 As Exception
            End Try
            R.IsOk = False
            R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    Public Shared Function RBPF_PF_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim R As New MsgReturn


        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim PFID As String = Val(dtTable.Rows(0)("ID"))
        Dim BZCID As String = Val(dtTable.Rows(0)("BZC_ID"))
        paraMap.Add("ID", PFID)
        paraMap.Add("BZC_ID", BZCID)
        Try
            sqlMap.Add("Table", SQL_RBPF_GetByID)
            sqlMap.Add("List", SQL_RBPF_GeList_ByID)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then

                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]不存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try

    End Function
#End Region


End Class
