Imports PClass.PClass
Imports System.Windows.Forms
<System.ComponentModel.ToolboxItem(False)> _
Public Class Col_List

    Public Event Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
    Public Event GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)
    Public Event GetFocusState(ByRef HasFocused As Boolean)
    Protected NotTop As Boolean = False
    Public SQL_Col_GetSearch_Order As String
    Public SQL_Col_GetSearch_Where As String
    Public SQL_Col_GetSearch As String
    Public SQL_Col_GetSearch_GetByID As String
    Private _IsTBLostFocusSelOne As Boolean = True

    ''' <summary>
    ''' 是否可清空
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsTBLostFocusSelOne() As Boolean
        Get
            Return _IsTBLostFocusSelOne
        End Get
        Set(ByVal value As Boolean)
            _IsTBLostFocusSelOne = value
        End Set
    End Property
    Private _IsShowAll As Boolean = True
    ''' <summary>
    ''' 是否没有输入字符串时候,显示初始列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsShowAll() As Boolean
        Get
            Return _IsShowAll
        End Get
        Set(ByVal value As Boolean)
            _IsShowAll = value
        End Set
    End Property

    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Left = -2000
        Me.Top = -2000
        Me.Visible = False
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Col_Ini()
    End Sub

    Public Loaded As Boolean = False
    Protected Overridable Sub Col_Ini()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Fg1.Focus()
        NotTop = True
        GetSearch()
    End Sub
    Public Sub StartSearch()
        TimerEdit.Enabled = True
    End Sub

    Public Sub StartHide()
        TimerVisable.Enabled = True
    End Sub

    Public Search As String = ""
    Protected StartEdit As Boolean = False
    Protected ID As String = ""

    Sub FG_Refresh(Optional ByVal StartEdit As Boolean = False)
        Dim Cancel As Boolean = False
        Dim ID As String = ""
        RaiseEvent GetSearchEvent(Search, ID, Cancel)
        If Search Is Nothing Then Search = ""
        If ID Is Nothing Then ID = ""
        If Cancel = True Then Exit Sub
        Search = Search.Replace("'", "")
        Me.StartEdit = StartEdit
        Me.ID = ID
        If _IsShowAll = False AndAlso Search = "" Then
            Exit Sub
        End If
        Dim T As New Threading.Thread(AddressOf GetSearch)
        T.Start()

    End Sub


    Overridable Sub GetSearch()
        Dim S As String = StrConv(Search, vbNarrow)
        Search = S
        Dim Parameters As New Dictionary(Of String, Object)
        Parameters.Add("@No", "%" & Search & "%")
        Parameters.Add("@Name", "%" & Search & "%")
        Parameters.Add("@FindHelper", "%" & Search & "%")
        Dim Dtr As DtReturnMsg
        Dim GS As String = SQL_Col_GetSearch
        If NotTop Then
            NotTop = False
            GS = SQL_Col_GetSearch.Replace("top 10", "")
        End If
        If Search = "" Then
            Dtr = SqlStrToDt(GS & SQL_Col_GetSearch_Order, Parameters)
        Else
            Dtr = SqlStrToDt(GS & SQL_Col_GetSearch_Where & SQL_Col_GetSearch_Order, Parameters)
        End If
        If S = Search AndAlso Dtr.IsOk Then
            Fg1.Invoke(New DDtSetFG(AddressOf DtSetFG), Dtr.Dt)
        End If
    End Sub

    Delegate Sub DDtSetFG(ByVal Dt As DataTable)
    Sub DtSetFG(ByVal Dt As DataTable)
        Fg1.DataSource = Dt
        If Dt.Rows.Count = 0 Then
            Me.Visible = False
            Exit Sub
        End If
        If Dt.Rows.Count = 1 And StartEdit = True Then
            If Fg1.Item(1, "ID") = Val(ID) Then
                Me.Visible = False
                Exit Sub
            End If
        End If
        If Not TB_No Is Nothing Then
            If TB_No.Focused Then Me.Visible = True
        ElseIf Not FGX Is Nothing Then
            If FGX.Focused Then
                Me.Visible = True
            ElseIf Not FGX.Editor Is Nothing Then
                If FGX.Editor.Focused Then
                    Me.Visible = True

                End If
                Debug.Print(FGX.Editor.Focused)
            End If

        End If
    End Sub

    ''' <summary>
    ''' 获取选择的那一行的某个字段的值,最好在Col_sel事件中使用
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetSelectRow(ByVal Field As String) As Object
        If Fg1.RowSel > 0 Then
            Return Fg1.SelectItem(Field)
        Else
            Return Nothing
        End If
    End Function


    Private Sub Col_List_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Fg1.Focus()
    End Sub


    Sub FG_KeyDown(ByVal Key As Keys)
        Select Case Key
            Case Keys.Down
                If Fg1.RowSel < Fg1.Rows.Count - 1 Then
                    Fg1.RowSel = Fg1.RowSel + 1
                    Fg1.Row = Fg1.Row + 1
                End If
                Fg1.Focus()
            Case Keys.Up
                If Fg1.RowSel > 1 Then
                    Fg1.RowSel = Fg1.RowSel - 1
                    Fg1.Row = Fg1.Row - 1
                End If
                Fg1.Focus()
        End Select
    End Sub

    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
        Fg1.Focus()
    End Sub

    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            IsFG1MouseEnter = False
            FG1_Click(sender, New System.EventArgs)
        End If
    End Sub

    Private Sub Fg1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Fg1.KeyPress
        If TB_No IsNot Nothing Then
            If Asc(e.KeyChar) = 8 Then
                If TB_No.Text <> "" Then
                    TB_No.Text = TB_No.Text.Substring(0, TB_No.Text.Length - 1)
                    FG_Refresh()
                End If
            Else
                TB_No.Text = TB_No.Text + e.KeyChar
                FG_Refresh()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 强制选择一行
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Col_SelOne()
        If Fg1.RowSel > 0 And Me.Fg1.Focused = False Then
            RaiseEvent Col_Sel(Fg1.Item(Fg1.RowSel, Col_Col_No), Fg1.Item(Fg1.RowSel, Col_Col_Name), Fg1.Item(Fg1.RowSel, "ID"))
        End If
    End Sub


    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Click
        If Fg1.RowSel > 0 Then
            RaiseEvent SetKeyEnter()
            RaiseEvent Col_Sel(Fg1.Item(Fg1.RowSel, Col_Col_No), Fg1.Item(Fg1.RowSel, Col_Col_Name), Fg1.Item(Fg1.RowSel, "ID"))
            IsFG1MouseEnter = False
            StartHide()
        End If
        IsFG1MouseEnter = False
    End Sub

    Private Sub TimerEdit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerEdit.Tick
        TimerEdit.Enabled = False
        FG_Refresh()
    End Sub

    Private Sub TimerVisable_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerVisable.Tick
        TimerVisable.Enabled = False
        If Me.Visible = False Then Exit Sub
        Dim F As Boolean = False
        If Fg1.Focused = False Then
            RaiseEvent GetFocusState(F)
            Me.Visible = F
        End If
    End Sub

    Private Sub Panel1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.GotFocus
        Fg1.Focus()
    End Sub

    Private Sub Fg1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.LostFocus
        IsFG1MouseEnter = False
        StartHide()
    End Sub
    Private IsFG1MouseEnter As Boolean = False


    Private Sub Col_List_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            Me.BringToFront()
        End If
    End Sub
    Private Sub Fg1_MouseCaptureChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.MouseCaptureChanged
        IsFG1MouseEnter = Not IsFG1MouseEnter
    End Sub
    Private Event SetKeyEnter()
#Region "绑定到TextBox上"
    Sub Clear_Set()
        Try
            RemoveHandler Me.Col_Sel, AddressOf Col_List2_Col_Sel
            RemoveHandler Me.GetFocusState, AddressOf Col_List2_GetFocusState
            RemoveHandler Me.GetSearchEvent, AddressOf Col_List2_GetSearchEvent
            RemoveHandler Me.SetKeyEnter, AddressOf TB_SetKeyEnter
        Catch ex As Exception

        End Try
        Me.TB_No = Nothing
        Me.TB_Name = Nothing
        Me.NextControl = Nothing
        Me.FGX = Nothing
    End Sub

    Dim TB_LastKeys As Keys = 0
    Sub TB_SetKeyEnter()
        TB_LastKeys = Keys.Enter
    End Sub
    Private WithEvents TB_No As TextBox
    Private TB_Name As Windows.Forms.Control
    Private NextControl As Windows.Forms.Control


    ''' <summary>
    ''' 把控件事件绑定到TextBox上
    ''' </summary>
    ''' <param name="TB_Col_No"></param>
    ''' <remarks></remarks>
    Public Sub Set_TextBox(ByVal TB_Col_No As ToolStripTextBox, ByVal Top As Long, ByVal NextControl As Windows.Forms.Control)
        Me.TB_No = TB_Col_No.TextBox
        Me.TB_Name = Nothing
        Me.NextControl = NextControl
        Dim L As Integer = 0
        Dim T As Integer = 0
        T = Top
        Col_Top = T
        Col_Left = L

        AddHandler Me.Col_Sel, AddressOf Col_List2_Col_Sel
        AddHandler Me.GetFocusState, AddressOf Col_List2_GetFocusState
        AddHandler Me.GetSearchEvent, AddressOf Col_List2_GetSearchEvent
        AddHandler Me.SetKeyEnter, AddressOf TB_SetKeyEnter
    End Sub




    ''' <summary>
    ''' 把控件事件绑定到TextBox上
    ''' </summary>
    ''' <param name="TB_Col_No"></param>
    ''' <param name="NextControl">下一个控件</param>
    ''' <remarks></remarks>
    Public Sub Set_TextBox(ByVal TB_Col_No As TextBox, ByVal NextControl As Windows.Forms.Control)
        Me.TB_No = TB_Col_No
        Me.TB_Name = Nothing
        Me.NextControl = NextControl
        Dim L As Integer = 0
        Dim T As Integer = 0
        If TryCast(TB_No.Parent, System.Windows.Forms.ToolStripOverflow) IsNot Nothing Then
            T = 5
        Else
            Dim O As Windows.Forms.Control = TB_No.Parent
            Do While O IsNot Nothing AndAlso Me.Parent.Name <> O.Name
                L = L + O.Left
                T = T + O.Top
                O = O.Parent
            Loop
        End If
        Col_Top = T
        Col_Left = L

        AddHandler Me.Col_Sel, AddressOf Col_List2_Col_Sel
        AddHandler Me.GetFocusState, AddressOf Col_List2_GetFocusState
        AddHandler Me.GetSearchEvent, AddressOf Col_List2_GetSearchEvent
        AddHandler Me.SetKeyEnter, AddressOf TB_SetKeyEnter
    End Sub

    ''' <summary>
    ''' 把控件事件绑定到TextBox上
    ''' </summary>
    ''' <param name="TB_Col_No"></param>
    ''' <param name="TB_Col_Name"></param>
    ''' <param name="NextControl">下一个控件</param>
    ''' <remarks></remarks>
    Public Sub Set_TextBox(ByVal TB_Col_No As TextBox, ByVal TB_Col_Name As Windows.Forms.Control, ByVal NextControl As Windows.Forms.Control)
        Me.TB_No = TB_Col_No
        Me.TB_Name = TB_Col_Name
        Me.NextControl = NextControl

        Dim L As Integer = 0
        Dim T As Integer = 0
        If TryCast(TB_No.Parent, System.Windows.Forms.ToolStripOverflow) IsNot Nothing Then
            T = 5
        Else
            Dim O As Windows.Forms.Control = TB_No.Parent
            Do While O IsNot Nothing AndAlso Me.Parent.Name <> O.Name
                L = L + O.Left
                T = T + O.Top
                O = O.Parent
            Loop
        End If
        Col_Top = T
        Col_Left = L

        AddHandler Me.Col_Sel, AddressOf Col_List2_Col_Sel
        AddHandler Me.GetFocusState, AddressOf Col_List2_GetFocusState
        AddHandler Me.GetSearchEvent, AddressOf Col_List2_GetSearchEvent
        AddHandler Me.SetKeyEnter, AddressOf TB_SetKeyEnter
    End Sub


    ''' <summary>
    ''' 根据TAG获取名称
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetByTextBoxTag(Optional ByVal ID As String = "") As String
        If TB_No Is Nothing Then
            Return ""
            Exit Function
        Else
            If ID = "" Then ID = TB_No.Tag
            Dim Dtr As DtReturnMsg = SqlStrToDt(SQL_Col_GetSearch_GetByID, "@ID", ID)
            If Dtr.IsOk Then
                If Dtr.Dt.Rows.Count > 0 Then
                    Value_Set_TB(Dtr.Dt.Rows(0)(Col_Col_No), Dtr.Dt.Rows(0)("ID"), Dtr.Dt.Rows(0)(Col_Col_Name))
                    DtSetFG(Dtr.Dt)
                    Return Dtr.Dt.Rows(0)(Col_Col_Name)
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        End If
    End Function


    Private Sub Value_Set_TB(ByVal Col_No As String, ByVal Col_ID As String, ByVal Col_Name As String)
        If Not TB_Name Is Nothing Then
            TB_No.Text = Col_No
            TB_No.Tag = Col_ID
            TB_Name.Text = Col_Name
        Else
            TB_No.Text = Col_Name
            TB_No.Tag = Col_ID
        End If
    End Sub

    Private Sub TB_Col_No_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_No.GotFocus
        TB_LastKeys = 0
        If TB_No.ReadOnly = False Then
            TextBox_Show_Col_List2()
        End If
    End Sub

    Private Sub TB_Col_No_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_No.KeyDown
        If TB_No.ReadOnly = True OrElse TB_No.Enabled = False Then
            Me.Visible = False
            Exit Sub
        End If
        TB_LastKeys = e.KeyCode
        If e.KeyCode = Keys.Down Then
            Me.FG_KeyDown(e.KeyCode)
            e.Handled = True
        End If
    End Sub

    Private Sub TB_Col_No_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_No.KeyPress
        If TB_No.ReadOnly = True OrElse TB_No.Enabled = False Then
            Me.Visible = False
            Exit Sub
        End If
        If e.KeyChar = vbCr Then
            If Not NextControl Is Nothing Then NextControl.Focus()
        Else
            Me.StartSearch()
        End If
    End Sub

    Private Sub TB_Col_No_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_No.LostFocus
        If TB_No.ReadOnly = True OrElse TB_No.Enabled = False Then
            Me.Visible = False
            Exit Sub
        End If
        If _IsTBLostFocusSelOne = False Then
            If TB_No.Text <> "" Then
                Me.Col_SelOne()
            Else
                TB_No.Tag = "0"
                RaiseEvent Col_Sel("", "", "0")
            End If
        Else
            Me.Col_SelOne()
        End If
        Me.StartHide()
    End Sub

    Sub TextBox_Show_Col_List2()
        Dim IsCancel As Boolean = False
        RaiseEvent BeforeShow(IsCancel)
        If IsCancel Then
            Exit Sub
        End If
        Dim T As Integer = Col_Top + TB_No.Top + TB_No.Height + 2
        Dim L As Integer = Col_Left + TB_No.Left
        If T + Me.Height > Me.Parent.Height Then
            T = T - Me.Height - TB_No.Height - 4
        End If
        If L + Me.Width > Me.Parent.Width Then
            L = L - Me.Width - 4 + TB_No.Width
        End If
        Me.Top = T
        Me.Left = L
        Me.FG_Refresh(True)
    End Sub

    Private Sub Col_List2_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
        Value_Set_TB(Col_No, ID, Col_Name)
        If Col_Name <> "" Then
            If Not NextControl Is Nothing AndAlso TB_LastKeys = Keys.Enter Then NextControl.Focus()
        End If
    End Sub

    Private Sub Col_List2_GetFocusState(ByRef HasFocused As Boolean)
        If TB_No.Focused = False And IsFG1MouseEnter = False Then
            HasFocused = False
        Else
            HasFocused = True
        End If
    End Sub

    Private Sub Col_List2_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)
        Col_No = TB_No.Text
        ID = TB_No.Tag
    End Sub
#End Region


#Region "绑定到FG上"
    Protected WithEvents FGX As PClass.FG
    Protected Col_Col_No As String = "Col_No"
    Protected Col_Col_Name As String = "Col_Name"
    Public Col_Col_Spec As String = ""
    Public Event BeforeShow(ByRef IsCancel As Boolean)
    Protected Col_Col_ID As String = "Col_ID"

    Protected Col_Left As Integer = 0
    Protected Col_Top As Integer = 0

    ''' <summary>
    ''' 把控件事件绑定到FG上
    ''' </summary>
    ''' <param name="FGX"></param>
    ''' <param name="Col_Col_No">FG上的字段</param>
    ''' <param name="Col_Col_Name">FG上的字段</param>
    ''' <remarks></remarks>
    Public Sub Set_FG(ByVal FGX As PClass.FG, Optional ByVal Col_Col_No As String = "", Optional ByVal Col_Col_Name As String = "", Optional ByVal Col_Col_ID As String = "")
        If Col_Col_No <> "" Then Me.Col_Col_No = Col_Col_No
        If Col_Col_Name <> "" Then Me.Col_Col_Name = Col_Col_Name
        If Col_Col_ID <> "" Then Me.Col_Col_ID = Col_Col_ID
        Me.FGX = FGX
        Dim O As Windows.Forms.Control = FGX.Parent
        Dim L As Integer = 0
        Dim T As Integer = 0
        Do While Me.Parent.Name <> O.Name
            L = L + O.Left
            T = T + O.Top
            O = O.Parent
        Loop
        Col_Left = L
        Col_Top = T
        AddHandler Me.Col_Sel, AddressOf Me_Col_Sel
        AddHandler Me.GetFocusState, AddressOf Me_GetFocusState
        AddHandler Me.GetSearchEvent, AddressOf Me_GetSearchEvent
        AddHandler Me.SetKeyEnter, AddressOf FG_SetKeyEnter
    End Sub

    Private Sub FGX_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles FGX.KeyDownEdit
        If e.Col = FGX.Cols(Col_Col_No).Index Then
            If (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) AndAlso FGX.CanEditing Then
                Me.FG_KeyDown(e.KeyCode)
                e.Handled = True
            End If
            FGX.Item(e.Row, Col_Col_Name) = ""
        End If
    End Sub

    Private Sub FGX_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FGX.LostFocus
        Me.StartHide()
    End Sub

    Private Sub FGX_LeaveEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FGX.LeaveEdit
        Me.StartHide()
    End Sub

    Private Sub FGX_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles FGX.AfterScroll
        If FGX.CanEditing Then ReMove()
    End Sub
    Private Sub FGX_CheckEditing(ByVal sender As Object, ByRef e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FGX.CheckEditing
        If e.Cancel = False Then
            Show_Col_List()
        End If
    End Sub
    Private Sub FGX_KeyPressEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyPressEditEventArgs) Handles FGX.KeyPressEdit
        If e.Col = FGX.Cols(Col_Col_No).Index Then
            Me.StartSearch()
            If FGX.LastText <> IsNull(FGX.Editor.Text, "") Then FGX.Item(e.Row, Col_Col_Name) = ""
        End If
    End Sub
    Sub Show_Col_List()
        If FGX.ColSel = FGX.Cols(Col_Col_No).Index Then
            Dim IsCancel As Boolean = False
            RaiseEvent BeforeShow(IsCancel)
            If IsCancel Then
                Exit Sub
            End If
            ReMove()
            Me.FG_Refresh(True)
        End If
    End Sub

    Public Sub ReMove()
        Dim C As C1.Win.C1FlexGrid.Column = FGX.Cols(FGX.ColSel)
        Dim R As C1.Win.C1FlexGrid.Row = FGX.Rows(FGX.RowSel)
        Dim L As Integer = Col_Left + FGX.Left + C.Left + FGX.ScrollPosition.X
        Dim T As Integer = Col_Top + FGX.Top + R.Top + R.HeightDisplay + FGX.ScrollPosition.Y + 2
        If T + Me.Height > Me.Parent.Height Then
            T = T - Me.Height - R.HeightDisplay - 4
        End If
        Me.Top = T
        Me.Left = L
    End Sub

    Sub FG_SetKeyEnter()
        FGX.LastKey = Keys.Enter
    End Sub

    Private Sub Me_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal Id As String)
        FGX.Item(FGX.RowSel, Col_Col_No) = Col_No
        FGX.Item(FGX.RowSel, Col_Col_Name) = Col_Name
        FGX.Item(FGX.RowSel, Col_Col_ID) = Id
        If Col_Col_Spec <> "" Then
            FGX.Item(FGX.RowSel, Col_Col_Spec) = Fg1.SelectItem("WL_Spec")
        End If
        If Col_Name <> "" Then
            FGX.GotoNextCell(Col_Col_No)
        End If
    End Sub

    Private Sub Me_GetFocusState(ByRef HasFocused As Boolean)
        If (FGX.Editor Is Nothing OrElse FGX.Editor.Focused = False) Then
            HasFocused = False
        Else
            If FGX.ColSel = FGX.Cols(Col_Col_No).Index Then
                HasFocused = True
            Else
                HasFocused = False
            End If
        End If
    End Sub

    Private Sub Me_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)
        If FGX.RowSel > 0 Then
            If FGX.Editor Is Nothing Then
                Col_No = IsNull(FGX.Item(FGX.RowSel, Col_Col_No), "")
            Else
                Col_No = FGX.Editor.Text
            End If
            ID = IsNull(FGX.Item(FGX.RowSel, Col_Col_ID), "")
        Else
            Cancel = True
        End If
    End Sub


#End Region





End Class

