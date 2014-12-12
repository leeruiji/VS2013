Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F40502_Store_Sel


    Dim dtWL As DataTable
    Dim dtList As DataTable
    Dim SelType As cStore_Area.Enum_SelType
    Dim selectedCellList As New List(Of String)
    Dim CBLock As Boolean = False
    Dim GH As String = ""
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal _SelType As cStore_Area.Enum_SelType, ByVal _selectedCellList As List(Of String))

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.SelType = _SelType
        Me.selectedCellList = _selectedCellList
        Me.Mode = Mode
        Me.Title = "仓位选择"
    End Sub

    Private Sub F40502_Store_Sel_AfterLoad() Handles Me.AfterLoad
        If CBLock Then
            TabControl1.SelectedIndex = 1
            Find()
        End If
    End Sub



    Private Sub F10201_Quality_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub F40500_Store_Map_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If P_F_RS_ID5 = 1 Then
            CBLock = True
            TB_ClientID.ReadOnly = True
            TB_BZ_ID.ReadOnly = True
        Else
            CBLock = False
        End If

        Fg_CheckedCell.Rows.Count = 1
        Bz_List2.Set_TextBox(TB_BZ_ID, TB_BZ_Name, Cmd_Find)
        Client_List1.Set_TextBox(TB_ClientID, TB_ClientName, TB_BZ_ID)

        If F_RS_ID <> "" AndAlso Val(F_RS_ID) > 0 Then
            Client_List1.GetByTextBoxTag(F_RS_ID)
        End If
        If F_RS_ID2 <> "" AndAlso Val(F_RS_ID2) > 0 Then
            Bz_List2.GetByTextBoxTag(F_RS_ID2)
        End If
        If F_RS_Obj IsNot Nothing Then
            Fg2.DtToSetFG(F_RS_Obj)
            NowDt2 = F_RS_Obj
            Label_Sel2 = 0
            Label_SelNo2 = ""
            StoreListShow2(SearchStore2(NowDt2))
            SetLabelColor(LabelShow2_0, 2)
        End If
        If F_RS_ID3 <> "" Then
            GH = F_RS_ID3
        End If

        LabelNormal.ForeColor = Cs.Color_Normal
        LabelSel.ForeColor = Cs.Color_Sel
        LabelEmpty.ForeColor = Cs.Color_Empty
        LabelCell.ForeColor = Cs.Color_Cell
        LabelCellA.ForeColor = Cs.Color_CellA
        LabelPost.ForeColor = Cs.Color_Post
        LabelDisable.ForeColor = Cs.Color_Disable
        LabelPassage.ForeColor = Cs.Color_Passage


        CB_Floor.DataSource = cStore_Area.Get_Area_Dt
        CB_Floor.DisplayMember = "FloorName"
        CB_Floor.ValueMember = "Floor"

    End Sub


#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtWL.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)

            'dt.Rows(0)("Remark_ID") = TB_ID.Text

            'dt.Rows(0)("Remark") = TB_Remark.Text
            'dt.Rows(0)("Remark2") = TB_Remark2.Text
            'dt.Rows(0)("Remark_Type") = RemarkType

        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            'TB_ID.Text = IsNull(dt.Rows(0)("Remark_ID"), "")

            'TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
            'TB_Remark2.Text = IsNull(dt.Rows(0)("Remark2"), "")
        End If
    End Sub




#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' If CheckForm() Then ShowConfirm("是否保存备注[" & TB_ID.Text & "] 的修改?", AddressOf Save)
    End Sub


    Protected Function CheckForm() As Boolean
        'If TB_ID.Text = "" Then
        '    ShowErrMsg("备注编号不能为空")
        '    TB_ID.Focus()
        '    Return False
        'End If


        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  ShowConfirm("是否删除备注[" & TB_ID.Text & "]?", AddressOf DelWL)
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cs.Save()
    End Sub


#End Region


#Region "控件事件"
    Dim Cs As New cStore_Area



    Private Sub DG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        Dim dr As DataRow = Cs.GetCellRow(e.ColumnIndex, e.RowIndex)
        CB_State.SelectedIndex = dr("State")
        TB_Qty.Text = dr("Qty")
        TB_MaxQty.Text = dr("MaxQty")
        TB_No.Text = dr("sNo")
        LabelXY.Text = e.ColumnIndex & "," & e.RowIndex
    End Sub




    Private Sub Cmd_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LabelXY.Text = "" Then Exit Sub
        Dim S() As String = LabelXY.Text.Split(",")
        Dim dr As DataRow = Cs.GetCellRow(S(0), S(1))
        dr("State") = CB_State.SelectedIndex
        dr("Qty") = TB_Qty.Text
        dr("MaxQty") = TB_MaxQty.Text
        dr("sNo") = TB_No.Text
        Cs.DG_ReFresh(DG)
    End Sub


    Private Sub LabelEmpty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    LabelNormal.Click, LabelSel.Click, LabelEmpty.Click, LabelCell.Click, LabelCellA.Click, LabelPost.Click, LabelDisable.Click, LabelPassage.Click
        Dim L As Label = TryCast(sender, Label)
        Using C As New ColorDialog
            C.Color = L.ForeColor
            If C.ShowDialog = Windows.Forms.DialogResult.OK Then
                L.ForeColor = C.Color
                Select Case L.Name
                    Case LabelNormal.Name
                        Cs.Color_Normal = L.ForeColor
                    Case LabelSel.Name
                        Cs.Color_Sel = L.ForeColor
                    Case LabelEmpty.Name
                        Cs.Color_Empty = L.ForeColor
                    Case LabelCell.Name
                        Cs.Color_Cell = L.ForeColor
                    Case LabelCellA.Name
                        Cs.Color_CellA = L.ForeColor
                    Case LabelPost.Name
                        Cs.Color_Post = L.ForeColor
                    Case LabelDisable.Name
                        Cs.Color_Disable = L.ForeColor
                    Case LabelPassage.Name
                        Cs.Color_Passage = L.ForeColor
                End Select
                Cs.DG_ReFresh(DG)
            End If
        End Using
    End Sub
#End Region
#Region "选择仓位"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DG_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellDoubleClick
        Dim dr As DataRow = Cs.GetCellRow(e.ColumnIndex, e.RowIndex)
        If dr("State") = cStore_Area.Enum_State.Normal Then
            Dim _sNo As String = dr("sNo")
            For i As Integer = 1 To Label_N
                Dim L As Label = TryCast(FlowLayoutPanel1.Controls("LabelShow_" & i), Label)
                If L.Text <> "" Then
                    If L.Text = _sNo Then
                        If Label_Sel = 0 Then
                            SetLabelColor(LabelShow_0, 0)
                        Else
                            SetLabelColor(FlowLayoutPanel1.Controls("LabelShow_" & Label_Sel), 0)
                        End If
                        Label_Sel = Val(L.Name.Split("_")(1))
                        Label_SelNo = _sNo
                        SetLabelColor(L, 2)
                        If Label_Sel = 0 Then
                            FindStore("")
                        Else
                            FindStore(L.Text)
                        End If
                        Label_MouseDown2(LabelShow2_0, New Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                        TabControl1.SelectedIndex = 1
                        Exit Sub
                    End If
                Else
                    Exit For
                End If
            Next
            For i As Integer = 1 To Label_N2
                Dim L2 As Label = TryCast(FlowLayoutPanel2.Controls("LabelShow2_" & i), Label)
                If L2.Text <> "" Then
                    If L2.Text = _sNo Then
                        If Label_Sel2 = 0 Then
                            SetLabelColor(LabelShow2_0, 0)
                        Else
                            SetLabelColor(FlowLayoutPanel2.Controls("LabelShow2_" & Label_Sel2), 0)
                        End If
                        Label_Sel2 = Val(L2.Name.Split("_")(1))
                        Label_SelNo2 = _sNo
                        SetLabelColor(L2, 2)
                        If Label_Sel2 = 0 Then
                            FindStore2("")
                        Else
                            FindStore2(L2.Text)
                        End If
                        Label_MouseDown(LabelShow_0, New Windows.Forms.MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                        TabControl1.SelectedIndex = 1
                        Exit Sub
                    End If
                Else
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub




#End Region




    Private Sub CB_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Floor.SelectedIndexChanged
        If CB_Floor.Text.Length <> 1 Then Exit Sub
        Cs.Floor = CB_Floor.SelectedValue
        Cs.GetFormDt()
        If Cs.Cell.Rows.Count = 0 Then

        Else
            Cs.DG_Show(DG)
        End If


    End Sub

 



    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles Client_List1.Col_Sel
        If CBLock = False Then
            TB_BZ_ID.Text = ""
            TB_BZ_Name.Text = ""
            TB_BZ_ID.ReadOnly = False
            Bz_List2.SearchID = ID
            Bz_List2.SearchType = BaseClass.Bz_List.ENum_SearchType.Client
        End If
    End Sub





    Private Sub Cmd_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Find.Click
        Find()
    End Sub

#Region "搜索布"
    Dim ReturnDt As DataTable
    Dim NowDt As DataTable
    Dim NowDt2 As DataTable
    Sub Find()
        Find_Store = ""
        Dim R As New DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("Client_ID", TB_ClientID.Tag)
        R = Dao.Store_GetByOption(GetFindOtions)
        If R.IsOk Then
            Dim dt As DataTable = DtRunSQLtoDt(R.Dt, "GH='' or GH ='" & GH & "'")
            NowDt = dt.Copy
            If NowDt2 Is Nothing Then
                NowDt2 = NowDt.Clone
            End If
            ReturnDt = R.Dt.Clone
            For Each Row As DataRow In NowDt2.Rows
                Dim Rows() As DataRow = dt.Select("Line=" & Row("Line"))
                If Rows.Length > 0 Then
                    Rows(0).Delete()
                End If
            Next
            dt.AcceptChanges()
            Fg1.DtToSetFG(dt)
            Label_Sel = 0
            StoreListShow(SearchStore(dt))
            SetLabelColor(LabelShow_0, 2)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub



    Dim Find_BZ_ID As Integer
    Dim Find_Client_ID As Integer
    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        If Not TB_ClientID.Tag Is Nothing AndAlso Not Val(TB_ClientID.Tag) = 0 Then
            fo = New FindOption
            fo.DB_Field = "Client_ID"
            fo.Value = TB_ClientID.Tag
            fo.Field_Operator = Enum_Operator.Operator_Equal
            Find_Client_ID = TB_ClientID.Tag
            oList.FoList.Add(fo)
            If Not TB_BZ_ID.Tag Is Nothing AndAlso Not Val(TB_BZ_ID.Tag) = 0 Then
                fo = New FindOption
                fo.DB_Field = "BZ_ID"
                fo.Value = TB_BZ_ID.Tag
                Find_BZ_ID = TB_BZ_ID.Tag
                fo.Field_Operator = Enum_Operator.Operator_Equal
                oList.FoList.Add(fo)
            Else
                Find_BZ_ID = 0
            End If
        Else
            Find_Client_ID = 0
            Find_BZ_ID = 0
        End If
        oList.FoList.Add(fo)
        Return oList
    End Function
#End Region




    Private Sub Cmd_Sel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Sel.Click
        If ReturnDt Is Nothing OrElse Fg2.Rows.Count <= 1 Then '没有选择任何东西
            LastForm.ReturnId = "0"
            LastForm.ReturnObj = Nothing
        Else
            ReturnDt.Rows.Clear()
            For Each Row As DataRow In NowDt2.Rows
                Dim R As DataRow = ReturnDt.NewRow
                For j As Integer = 1 To Fg2.Cols.Count - 1
                    R(Fg2.Cols(j).Name) = Row(Fg2.Cols(j).Name)
                Next
                ReturnDt.Rows.Add(R)
            Next
            LastForm.ReturnObj = ReturnDt
            LastForm.ReturnId = ReturnDt.Rows.Count
        End If
        Me.Close()
    End Sub



#Region "仓库控件2"

    Dim Find_Store2 As String = ""
    Sub FindStore2(ByVal Store2 As String)
        Dim Dt As DataTable = NowDt2.Copy
        Dt.AcceptChanges()
        Find_Store2 = Store2
        If Store2 = "" Then
            Fg2.DtToSetFG(Dt)
        Else
            Fg2.DtToSetFG(DtRunSQLtoDt(Dt, "StoreNo='" & Store2 & "'"))
        End If
    End Sub
    Function SearchStore2(ByVal Dtx2 As DataTable) As List(Of String)
        Dim Dt As DataTable = Dtx2.Copy
        Dim R As New List(Of String)
        Dt.AcceptChanges()
        For Each Row As DataRow In Dt.Rows
            If R.Contains(Row("StoreNo")) = False Then
                R.Add(Row("StoreNo"))
            End If
        Next
        If R.Count > Label_N2 Then
            For i As Integer = Label_N2 + 1 To R.Count
                Dim L2 As New Label With {.Name = "LabelShow2_" & i, _
                        .BorderStyle = Windows.Forms.BorderStyle.FixedSingle, _
                        .TextAlign = ContentAlignment.MiddleCenter, _
                        .FlatStyle = System.Windows.Forms.FlatStyle.Flat, _
                        .AutoSize = False, _
                        .Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte)), _
                        .ForeColor = System.Drawing.Color.Blue, _
                        .Location = New System.Drawing.Point(1, 1), _
                        .Margin = New System.Windows.Forms.Padding(1, 1, 0, 0), _
                        .Size = New System.Drawing.Size(42, 22), _
                        .TabIndex = i}
                FlowLayoutPanel2.Controls.Add(L2)
                AddHandler L2.MouseEnter, AddressOf Label_MouseEnter2
                AddHandler L2.MouseLeave, AddressOf Label_MouseLeave2
                AddHandler L2.MouseDown, AddressOf Label_MouseDown2
                Label_N2 = i
            Next
        End If
        StoreList2 = R
        Return R
    End Function
    Private StoreList2 As New List(Of String)
    Public Sub StoreListShow2(ByVal L As List(Of String))
        For i As Integer = 0 To L.Count - 1
            Dim LabelX As Label = FlowLayoutPanel2.Controls("LabelShow2_" & i + 1)
            LabelX.Text = L(i)
            LabelX.Visible = True
            If LabelX.Text = Find_Store2 Then
                Label_Sel2 = i + 1
                SetLabelColor(LabelX, 2)
            Else
                SetLabelColor(LabelX, 0)
            End If
        Next
        If L.Count > 0 Then
            Dim LabelX As Label = FlowLayoutPanel2.Controls("LabelShow2_" & L.Count)
            Dim H As Integer = LabelX.Top + LabelX.Height
            If H > 49 Then
                FTop2 = H + 3
            Else
                FTop2 = 49
            End If
        Else
            FTop2 = 49
        End If
        For i As Integer = L.Count To Label_N2 - 1
            Dim LabelX As Label = FlowLayoutPanel2.Controls("LabelShow2_" & i + 1)
            LabelX.Visible = False
            LabelX.Text = ""
        Next
    End Sub


    Private Sub FlowLayoutPanel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel2.Resize
        If StoreList2.Count > 0 Then
            Dim LabelX As Label = FlowLayoutPanel2.Controls("LabelShow2_" & StoreList2.Count)
            Dim H As Integer = LabelX.Top + LabelX.Height
            If H > 49 Then
                FTop2 = H + 3
            Else
                FTop2 = 49
            End If
        Else
            FTop2 = 49
        End If
    End Sub



    Dim L2 As Boolean = False
    Dim Label_N2 As Integer = 0
    Private Label_Sel2 As Integer = 0
    Private Label_SelNo2 As String = ""
    Private FTop2 As Integer = 49
    Private Sub FlowLayoutPanel2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel2.MouseEnter
        L2 = True
        FlowLayoutPanel2.Height = FTop2
        FlowLayoutPanel2.Top = SplitContainer1.Height - FlowLayoutPanel2.Height - 1
    End Sub


    Private Sub FlowLayoutPanel2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel2.MouseLeave
        L2 = False
        TimerLeave2.Start()
    End Sub
    Private Sub Label_MouseDown2(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LabelShow2_0.MouseDown
        Dim L As Label = TryCast(sender, Label)
        If Label_Sel2 = 0 Then
            SetLabelColor(LabelShow2_0, 0)
        Else
            SetLabelColor(FlowLayoutPanel2.Controls("LabelShow2_" & Label_Sel2), 0)
        End If
        Label_Sel2 = Val(L.Name.Split("_")(1))
        Label_SelNo2 = L.Text
        SetLabelColor(L, 2)
        If Label_Sel2 = 0 Then
            FindStore2("")
        Else
            FindStore2(L.Text)
        End If
    End Sub

    Private Sub SetLabelColor(ByVal L As Label, ByVal Mode As Integer)
        Select Case Mode
            Case 0
                L.BackColor = Color.White
                L.ForeColor = Color.Blue
            Case 1
                L.BackColor = Color.Blue
                L.ForeColor = Color.White
            Case 2
                L.BackColor = Color.Orange
                L.ForeColor = Color.Black
            Case 3
                L.BackColor = Color.Orange
                L.ForeColor = Color.LightGreen
        End Select
    End Sub


    Private Sub Label_MouseEnter2(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelShow2_0.MouseEnter
        Dim i As Integer = Val(TryCast(sender, Label).Name.Split("_")(1))
        If i = Label_Sel2 AndAlso TryCast(sender, Label).Text = Label_SelNo2 Then
            SetLabelColor(TryCast(sender, Label), 3)
        Else
            SetLabelColor(TryCast(sender, Label), 1)
        End If
        If i > 0 Then
            FlowLayoutPanel2_MouseEnter(sender, e)
        End If
    End Sub

    Private Sub Label_MouseLeave2(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelShow2_0.MouseLeave
        Dim i As Integer = Val(TryCast(sender, Label).Name.Split("_")(1))
        If i = Label_Sel2 AndAlso TryCast(sender, Label).Text = Label_SelNo2 Then
            SetLabelColor(TryCast(sender, Label), 2)
        Else
            SetLabelColor(TryCast(sender, Label), 0)
        End If
        If i > 0 Then
            FlowLayoutPanel2_MouseLeave(sender, e)
        End If
    End Sub

    Private Sub TimerLeave2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLeave2.Tick
        TimerLeave2.Stop()
        If L2 = False Then
            FlowLayoutPanel2.Height = 49
            FlowLayoutPanel2.Top = SplitContainer1.Height - FlowLayoutPanel2.Height - 1
        End If
    End Sub
#End Region

#Region "仓库控件"
    Dim Find_Store As String = ""
    Sub FindStore(ByVal Store As String)
        Dim Dt As DataTable = NowDt.Copy
        For Each Row As DataRow In NowDt2.Rows
            Dim Rows() As DataRow = Dt.Select("Line=" & Row("Line"))
            If Rows.Length > 0 Then
                Rows(0).Delete()
            End If
        Next
        Dt.AcceptChanges()
        Find_Store = Store
        If Store = "" Then
            Fg1.DtToSetFG(Dt)
        Else
            Fg1.DtToSetFG(DtRunSQLtoDt(Dt, "StoreNo='" & Store & "'"))
        End If
    End Sub
    Function SearchStore(ByVal Dtx As DataTable, Optional ByVal IsCutFg2 As Boolean = False) As List(Of String)
        Dim Dt As DataTable = Dtx.Copy
        Dim R As New List(Of String)
        Cs.Select_List.Clear()
        Fg_CheckedCell.Rows.Count = 1
        For Each Row As DataRow In Dt.Rows
            If Cs.Select_List.Contains(Row("StoreNo")) = False Then
                Cs.Select_List.Add(Row("StoreNo"))
                Fg_CheckedCell.AddRow()
                Fg_CheckedCell.Item(Fg_CheckedCell.Rows.Count - 1, "sNo") = Row("StoreNo")
            End If
        Next
        Cs.ShowSelList()
        If IsCutFg2 Then
            For Each Row As DataRow In NowDt2.Rows
                Dim Rows() As DataRow = Dt.Select("Line=" & Row("Line"))
                If Rows.Length > 0 Then
                    Rows(0).Delete()
                End If
            Next
        End If
        Dt.AcceptChanges()
        For Each Row As DataRow In Dt.Rows
            If R.Contains(Row("StoreNo")) = False Then
                R.Add(Row("StoreNo"))
            End If
        Next
        If R.Count > Label_N Then
            For i As Integer = Label_N + 1 To R.Count
                Dim L As New Label With {.Name = "LabelShow_" & i, _
                        .BorderStyle = Windows.Forms.BorderStyle.FixedSingle, _
                        .TextAlign = ContentAlignment.MiddleCenter, _
                        .FlatStyle = System.Windows.Forms.FlatStyle.Flat, _
                        .AutoSize = False, _
                        .Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte)), _
                        .ForeColor = System.Drawing.Color.Blue, _
                        .Location = New System.Drawing.Point(1, 1), _
                        .Margin = New System.Windows.Forms.Padding(1, 1, 0, 0), _
                        .Size = New System.Drawing.Size(42, 22), _
                        .TabIndex = i}
                FlowLayoutPanel1.Controls.Add(L)
                AddHandler L.MouseEnter, AddressOf Label_MouseEnter
                AddHandler L.MouseLeave, AddressOf Label_MouseLeave
                AddHandler L.MouseDown, AddressOf Label_MouseDown
                Label_N = i
            Next
        End If
        StoreList = R
        Return R
    End Function

    Private StoreList As New List(Of String)
    Private FTop As Integer = 49
    Public Sub StoreListShow(ByVal L As List(Of String))
        For i As Integer = 0 To L.Count - 1
            Dim LabelX As Label = FlowLayoutPanel1.Controls("LabelShow_" & i + 1)
            LabelX.Text = L(i)
            LabelX.Visible = True
            If LabelX.Text = Find_Store Then
                Label_Sel = i + 1
                SetLabelColor(LabelX, 2)
            Else
                SetLabelColor(LabelX, 0)
            End If
        Next
        If L.Count > 0 Then
            Dim LabelX As Label = FlowLayoutPanel1.Controls("LabelShow_" & L.Count)
            Dim H As Integer = LabelX.Top + LabelX.Height
            If H > 49 Then
                FTop = H + 3
            Else
                FTop = 49
            End If
        Else
            FTop = 49
        End If
        For i As Integer = L.Count To Label_N - 1
            Dim LabelX As Label = FlowLayoutPanel1.Controls("LabelShow_" & i + 1)
            LabelX.Visible = False
            LabelX.Text = ""
        Next
    End Sub


    Private Sub FlowLayoutPanel1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel1.Resize
        If StoreList.Count > 0 Then
            Dim LabelX As Label = FlowLayoutPanel1.Controls("LabelShow_" & StoreList.Count)
            Dim H As Integer = LabelX.Top + LabelX.Height
            If H > 49 Then
                FTop = H + 3
            Else
                FTop = 49
            End If
        Else
            FTop = 49
        End If
    End Sub



    Dim L As Boolean = False
    Dim Label_N As Integer = 0
    Private Label_Sel As Integer = 0
    Private Label_SelNo As String = ""
    Private Sub FlowLayoutPanel1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel1.MouseEnter
        L = True
        FlowLayoutPanel1.Height = FTop
        FlowLayoutPanel1.Top = SplitContainer1.Height - FlowLayoutPanel1.Height - 1
    End Sub


    Private Sub FlowLayoutPanel1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel1.MouseLeave
        L = False
        TimerLeave.Start()
    End Sub
    Private Sub Label_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LabelShow_0.MouseDown
        Dim L As Label = TryCast(sender, Label)
        If Label_Sel = 0 Then
            SetLabelColor(LabelShow_0, 0)
        Else
            SetLabelColor(FlowLayoutPanel1.Controls("LabelShow_" & Label_Sel), 0)
        End If
        Label_Sel = Val(L.Name.Split("_")(1))
        Label_SelNo = L.Text
        SetLabelColor(L, 2)
        If Label_Sel = 0 Then
            FindStore("")
        Else
            FindStore(L.Text)
        End If
    End Sub




    Private Sub Label_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelShow_0.MouseEnter
        Dim i As Integer = Val(TryCast(sender, Label).Name.Split("_")(1))
        If i = Label_Sel AndAlso TryCast(sender, Label).Text = Label_SelNo Then
            SetLabelColor(TryCast(sender, Label), 3)
        Else
            SetLabelColor(TryCast(sender, Label), 1)
        End If

        If i > 0 Then
            FlowLayoutPanel1_MouseEnter(sender, e)
        End If
    End Sub

    Private Sub Label_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelShow_0.MouseLeave
        Dim i As Integer = Val(TryCast(sender, Label).Name.Split("_")(1))
        If i = Label_Sel AndAlso TryCast(sender, Label).Text = Label_SelNo Then
            SetLabelColor(TryCast(sender, Label), 2)
        Else
            SetLabelColor(TryCast(sender, Label), 0)
        End If
        If i > 0 Then
            FlowLayoutPanel1_MouseLeave(sender, e)
        End If
    End Sub

    Private Sub TimerLeave_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerLeave.Tick
        TimerLeave.Stop()
        If L = False Then
            FlowLayoutPanel1.Height = 49
            FlowLayoutPanel1.Top = SplitContainer1.Height - FlowLayoutPanel1.Height - 1
        End If
    End Sub
#End Region




#Region "FG1"

    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        FG1_Del(Fg1.RowSel)
        StoreListShow(SearchStore(NowDt, True))
        StoreListShow2(SearchStore2(NowDt2))
    End Sub
#Region "选择按钮"
    Sub FG1_Del(ByVal Row As Integer)
        If Row > 0 Then
            Fg2.AddRow()
            Dim N As Integer = Fg2.Rows.Count - 1
            Dim Dr As DataRow = NowDt2.NewRow
            For j As Integer = 1 To Fg2.Cols.Count - 1
                Fg2.Item(N, j) = Fg1.Item(Row, j)
                Dr.Item(Fg2.Cols(j).Name) = Fg1.Item(Row, j)
            Next
            NowDt2.Rows.Add(Dr)
            NowDt2.AcceptChanges()
            Try
                Fg1.RemoveItem(Row)
            Catch ex As Exception
            End Try
        End If
    End Sub


    Private Sub Cmd_FGSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FGSel.Click
        Dim CS As Integer = Fg1.RowSel
        Dim CE As Integer = Fg1.Row
        Dim I As Integer = 0
        If CS <= 0 Then CS = 0
        If CE <= 0 Then CE = 0
        If CE < CS Then
            I = CE
            CE = CS
            CS = I
        End If
        For I = CS To CE
            FG1_Del(CS)
        Next
        StoreListShow(SearchStore(NowDt, True))
        StoreListShow2(SearchStore2(NowDt2))
    End Sub

    Private Sub Cmd_FGSelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FGSelAll.Click
        Dim CS As Integer = 1
        Dim CE As Integer = Fg1.Rows.Count - 1
        Dim I As Integer = 0
        If CE < CS Then
            I = CE
            CE = CS
            CS = I
        End If
        For I = CS To CE
            FG1_Del(CS)
        Next
        StoreListShow(SearchStore(NowDt, True))
        StoreListShow2(SearchStore2(NowDt2))
    End Sub
#End Region




#End Region

#Region "FG2"
    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        FG2_Del(Fg2.RowSel)
        StoreListShow(SearchStore(NowDt, True))
        StoreListShow2(SearchStore2(NowDt2))
    End Sub



#Region "删除按钮"

    Sub FG2_Del(ByVal Row As Integer)
        If Row > 0 Then
            If Fg2.Item(Row, "BZ_ID") = Find_BZ_ID AndAlso (Find_Store = "" OrElse Fg2.Item(Row, "StoreNo") = Find_Store) Then
                Fg1.AddRow()
                Dim N As Integer = Fg1.Rows.Count - 1
                For j As Integer = 1 To Fg1.Cols.Count - 1
                    Fg1.Item(N, j) = Fg2.Item(Row, j)
                Next
            End If
            Dim Dr() As DataRow = NowDt2.Select("Line='" & Fg2.Item(Row, "Line") & "'")
            For Each R As DataRow In Dr
                R.Delete()
            Next
            NowDt2.AcceptChanges()
            Try
                Fg2.RemoveItem(Row)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Cmd_FGDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FGDel.Click
        Dim CS As Integer = Fg2.RowSel
        Dim CE As Integer = Fg2.Row
        Dim I As Integer = 0
        If CS <= 0 Then CS = 0
        If CE <= 0 Then CE = 0
        If CE < CS Then
            I = CE
            CE = CS
            CS = I
        End If
        For I = CS To CE
            FG2_Del(CS)
        Next
        StoreListShow(SearchStore(NowDt, True))
        StoreListShow2(SearchStore2(NowDt2))
    End Sub

    Private Sub Cmd_FGDelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FGDelAll.Click
        Dim CS As Integer = 1
        Dim CE As Integer = Fg2.Rows.Count - 1
        Dim I As Integer = 0
        If CE < CS Then
            I = CE
            CE = CS
            CS = I
        End If
        For I = CS To CE
            FG2_Del(CS)
        Next
        StoreListShow(SearchStore(NowDt, True))
        StoreListShow2(SearchStore2(NowDt2))
    End Sub
#End Region

#End Region

   




End Class

Partial Friend Class Dao
#Region "常量"
    Private Const SQL_Store_Get As String = " select S.*,ZhiChang_Name from T40510_PB_Stock S left join T10120_ZhiChang Z on Z.ID=S.ZhiChang_ID "
    Private Const SQL_Store_OrderBy As String = " order by RK_Date,S.ID,ShaPi "
#End Region



    ''' <summary>
    ''' 按条件获取坯布
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Store_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Store_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Store_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function





End Class