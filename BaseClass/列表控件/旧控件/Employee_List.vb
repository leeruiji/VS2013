Option Compare Text
Imports PClass.PClass

Public Class Employee_List

    Protected Overrides Sub Col_Ini()
        Me.Col_Col_ID = "Employee_ID"
        Dim Employee_Name As String = "Employee_Name"
        Dim Employee_No As String = "Employee_No"

        Fg1.Cols(Me.Col_Col_Name).Name = Employee_Name
        Fg1.Cols(Me.Col_Col_No).Name = Employee_No

        Col_Col_Name = Employee_Name
        Col_Col_No = Employee_No
        Me.SQL_Col_GetSearch = SQL_Employee_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_Employee_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_Employee_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_Employee_GetSearch_Where
        Loaded = True
    End Sub

    Public Enum ENum_SearchType
        ''' <summary>
        ''' 所有人员
        ''' </summary>
        ''' <remarks></remarks>
        ALL = 0
        ''' <summary>
        ''' 按照FormatSet中对应的部门
        ''' </summary>
        ''' <remarks></remarks>
        FormatSet = 1
        ''' <summary>
        ''' 按照指定的部门
        ''' </summary>
        ''' <remarks></remarks>
        Department = 2
    End Enum
    Private _SearchType As ENum_SearchType = ENum_SearchType.ALL
    Public Property SearchType() As ENum_SearchType
        Get
            Return _SearchType
        End Get
        Set(ByVal value As ENum_SearchType)
            _SearchType = value
        End Set
    End Property
    Private _SearchID As String = ""
    Public Property SearchId() As String
        Get
            Return _SearchID
        End Get
        Set(ByVal value As String)
            _SearchID = value
        End Set
    End Property

    Overrides Sub GetSearch()
        Dim S As String = Search
        Dim Parameters As New Dictionary(Of String, Object)
        Parameters.Add("@No", "%" & Search & "%")
        Parameters.Add("@Name", "%" & Search & "%")
        Parameters.Add("@FindHelper", "%" & Search & "%")
        Dim Dtr As DtReturnMsg
        Dim GS As String = ""
        Dim OrderStr As String = ""
        Dim WhereStr As String = ""
        Dim SType As ENum_SearchType = _SearchType
        If _SearchID = "0" Or _SearchID = "" Then
            SType = ENum_SearchType.ALL
        End If

        Select Case _SearchType
            Case ENum_SearchType.ALL '全部模式
                GS = SQL_Employee_GetSearch
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                End If
                OrderStr = SQL_Employee_GetSearch_Order
                WhereStr = SQL_Employee_GetSearch_Where
            Case ENum_SearchType.Department
                GS = SQL_Employee_GetSearch_Client & SQL_Employee_GetSearch_Department_Where
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                End If
                OrderStr = SQL_Employee_GetSearch_Department_Order
                WhereStr = SQL_Employee_GetSearch_Department_Where1
                Parameters.Add("@Employee_Dept", _SearchID)
            Case ENum_SearchType.FormatSet
                GS = SQL_Employee_GetSearch_Client & SQL_Employee_GetSearch_Department_Where
                If NotTop Then
                    NotTop = False
                    GS = GS.Replace("top 10", "")
                End If
                OrderStr = SQL_Employee_GetSearch_Department_Order
                WhereStr = SQL_Employee_GetSearch_Department_Where1

                Dim ss As String = FormatSharp(SearchId)
                If ss = "0.00" Then
                    ss = ""
                End If
                Parameters.Add("@Employee_Dept", ss)
        End Select
        If Search = "" Then
            Dtr = SqlStrToDt(GS & IIf(GS.Contains("where"), "", " where 1=1 ") & OrderStr, Parameters)
        Else
            Dtr = SqlStrToDt(GS & WhereStr & OrderStr, Parameters)
        End If
        If S = Search AndAlso Dtr.IsOk Then
            Fg1.Invoke(New DDtSetFG(AddressOf DtSetFG), Dtr.Dt)
        End If
    End Sub


    '    Public Event Employee_Sel(ByVal Employee_No As String, ByVal Employee_Name As String, ByVal ID As String)
    '    Public Event GetSearchEvent(ByRef Employee_Name As String, ByRef ID As String, ByVal Cancel As Boolean)
    '    Public Event GetFocusState(ByRef HasFocused As Boolean)
    '    Private NotTop As Boolean = False

    '    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
    '        Fg1.Focus()
    '        NotTop = True
    '        GetSearch()
    '    End Sub
    '    Public Sub StartSearch()
    '        TimerEdit.Enabled = True
    '    End Sub


    '    Public Sub StartHide()
    '        TimerVisable.Enabled = True
    '    End Sub

    '    Public Search As String = ""
    '    Private StartEdit As Boolean = False
    '    Private ID As String = ""
    '    Sub FG_Refresh(Optional ByVal StartEdit As Boolean = False)
    '        Dim Cancel As Boolean = False
    '        Dim ID As String = ""
    '        RaiseEvent GetSearchEvent(Search, ID, Cancel)
    '        If Search Is Nothing Then Search = ""
    '        If ID Is Nothing Then ID = ""
    '        If Cancel = True Then Exit Sub
    '        Search = Search.Replace("'", "")
    '        Me.StartEdit = StartEdit
    '        Me.ID = ID
    '        Dim T As New Threading.Thread(AddressOf GetSearch)
    '        T.Start()

    '    End Sub


    '    Sub GetSearch()
    '        Dim S As String = Search
    '        Dim Parameters As New Dictionary(Of String, Object)
    '        Parameters.Add("@No", Search & "%")
    '        Parameters.Add("@Name", Search & "%")
    '        Parameters.Add("@FindHelper", Search & "%")
    '        Dim Dtr As DtReturnMsg
    '        Dim GS As String = SQL_Employee_GetSearch
    '        If NotTop Then
    '            NotTop = False
    '            GS = SQL_Employee_GetSearch.Replace("top 10", "")
    '        End If
    '        If Search = "" Then
    '            Dtr = SqlStrToDt(GS & SQL_Employee_GetSearch_Order, Parameters)
    '        Else
    '            Dtr = SqlStrToDt(GS & SQL_Employee_GetSearch_Where & SQL_Employee_GetSearch_Order, Parameters)
    '        End If
    '        If S = Search AndAlso Dtr.IsOk Then
    '            Try
    '                Fg1.Invoke(New DDtSetFG(AddressOf DtSetFG), Dtr.Dt)
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    End Sub
    '    Delegate Sub DDtSetFG(ByVal Dt As DataTable)
    '    Sub DtSetFG(ByVal Dt As DataTable)
    '        Fg1.DataSource = Dt
    '        If Dt.Rows.Count = 0 Then
    '            Me.Visible = False
    '            Exit Sub
    '        End If
    '        If Dt.Rows.Count = 1 And StartEdit = True Then
    '            If Fg1.Item(1, "ID") = Val(ID) Then
    '                Me.Visible = False
    '                Exit Sub
    '            End If
    '        End If
    '        If Not TB_Name Is Nothing Then
    '            If TB_Name.Focused Then Me.Visible = True
    '        ElseIf Not FGX Is Nothing Then
    '            If FGX.Focused Then
    '                Me.Visible = True
    '            ElseIf Not FGX.Editor Is Nothing Then
    '                If FGX.Editor.Focused Then
    '                    Me.Visible = True
    '                End If
    '            End If
    '        End If
    '    End Sub



    '    Private Sub Employee_List_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
    '        Fg1.Focus()
    '    End Sub


    '    Sub FG_KeyDown(ByVal Key As Keys)
    '        Select Case Key
    '            Case Keys.Down
    '                If Fg1.RowSel < Fg1.Rows.Count - 1 Then
    '                    Fg1.RowSel = Fg1.RowSel + 1
    '                    Fg1.Row = Fg1.Row + 1
    '                End If
    '                Fg1.Focus()
    '            Case Keys.Up
    '                If Fg1.RowSel > 1 Then
    '                    Fg1.RowSel = Fg1.RowSel - 1
    '                    Fg1.Row = Fg1.Row - 1
    '                End If
    '                Fg1.Focus()
    '        End Select
    '    End Sub

    '    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
    '        If e.KeyCode = Keys.Enter Then
    '            FG1_Click(sender, New System.EventArgs)
    '        End If
    '    End Sub

    '    Public Sub Employee_SelOne()
    '        If Fg1.RowSel > 0 And Me.Fg1.Focused = False Then
    '            RaiseEvent Employee_Sel(Fg1.Item(Fg1.RowSel, "Employee_No"), Fg1.Item(Fg1.RowSel, "Employee_Name"), Fg1.Item(Fg1.RowSel, "ID"))
    '        End If
    '    End Sub


    '    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Click
    '        If Fg1.RowSel > 0 Then
    '            RaiseEvent SetKeyEnter()
    '            RaiseEvent Employee_Sel(Fg1.Item(Fg1.RowSel, "Employee_No"), Fg1.Item(Fg1.RowSel, "Employee_Name"), Fg1.Item(Fg1.RowSel, "ID"))
    '            StartHide()
    '        End If
    '    End Sub

    '    Private Sub TimerEdit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerEdit.Tick
    '        TimerEdit.Enabled = False
    '        FG_Refresh()
    '    End Sub

    '    Private Sub TimerVisable_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerVisable.Tick
    '        TimerVisable.Enabled = False
    '        If Me.Visible = False Then Exit Sub
    '        Dim F As Boolean = False
    '        If Fg1.Focused = False Then
    '            RaiseEvent GetFocusState(F)
    '            Me.Visible = F
    '        End If
    '    End Sub

    '    Private Sub Panel1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.GotFocus
    '        Fg1.Focus()
    '    End Sub

    '    Private Sub Fg1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.LostFocus
    '        StartHide()
    '    End Sub





    '    Private Event SetKeyEnter()
    '#Region "绑定到TextBox上"
    '    Dim TB_LastKeys As Keys = 0
    '    Sub TB_SetKeyEnter()
    '        TB_LastKeys = Keys.Enter
    '    End Sub
    '    Private WithEvents TB_Name As TextBox
    '    Private NextControl As Windows.Forms.Control
    '    ''' <summary>
    '    ''' 把控件事件绑定到TextBox上
    '    ''' </summary>
    '    ''' <param name="TB_Employee_Name"></param>
    '    ''' <param name="NextControl">下一个控件</param>
    '    ''' <remarks></remarks>
    '    Public Sub Set_TextBox(ByVal TB_Employee_Name As TextBox, ByVal NextControl As Windows.Forms.Control)
    '        Me.TB_Name = TB_Employee_Name
    '        Me.NextControl = NextControl
    '        AddHandler Me.Employee_Sel, AddressOf Employee_List2_Employee_Sel
    '        AddHandler Me.GetFocusState, AddressOf Employee_List2_GetFocusState
    '        AddHandler Me.GetSearchEvent, AddressOf Employee_List2_GetSearchEvent
    '        AddHandler Me.SetKeyEnter, AddressOf TB_SetKeyEnter
    '    End Sub



    '    ''' <summary>
    '    ''' 根据TAG获取名称
    '    ''' </summary>
    '    ''' <param name="ID"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function GetByTextBoxTag(Optional ByVal ID As String = "") As String
    '        If TB_Name Is Nothing Then
    '            Return ""
    '            Exit Function
    '        Else
    '            If ID = "" Then ID = TB_Name.Tag
    '            Dim Dtr As DtReturnMsg = SqlStrToDt(SQL_Employee_GetSearch_GetByID, "@ID", ID)
    '            If Dtr.IsOk Then
    '                If Dtr.Dt.Rows.Count > 0 Then
    '                    TB_Name.Text = Dtr.Dt.Rows(0)("Employee_Name")
    '                    TB_Name.Tag = Dtr.Dt.Rows(0)("ID")
    '                    DtSetFG(Dtr.Dt)
    '                    Return Dtr.Dt.Rows(0)("Employee_Name")
    '                Else
    '                    Return ""
    '                End If
    '            Else
    '                Return ""
    '            End If
    '        End If
    '    End Function

    '    Private Sub Employee_Name_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Name.GotFocus
    '        TB_LastKeys = 0
    '        If TB_Name.ReadOnly = False Then
    '            TextBox_Show_Employee_List2()
    '        End If
    '    End Sub

    '    Private Sub TB_Employee_No_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_Name.KeyDown
    '        If TB_Name.ReadOnly = True OrElse TB_Name.Enabled = False Then
    '            Me.Visible = False
    '            Exit Sub
    '        End If
    '        TB_LastKeys = e.KeyCode
    '        If e.KeyCode = Keys.Down Then
    '            Me.FG_KeyDown(e.KeyCode)
    '            e.Handled = True
    '        End If
    '    End Sub

    '    Private Sub TB_Employee_No_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Name.KeyPress
    '        If TB_Name.ReadOnly = True OrElse TB_Name.Enabled = False Then
    '            Me.Visible = False
    '            Exit Sub
    '        End If
    '        If e.KeyChar = vbCr Then
    '            If Not NextControl Is Nothing Then NextControl.Focus()
    '        Else
    '            Me.StartSearch()
    '        End If
    '    End Sub

    '    Private Sub TB_Employee_No_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Name.LostFocus
    '        Me.Employee_SelOne()
    '        Me.StartHide()
    '    End Sub

    '    Sub TextBox_Show_Employee_List2()
    '        Dim O As Windows.Forms.Control = TB_Name.Parent
    '        Dim L As Integer = TB_Name.Left
    '        Dim T As Integer = TB_Name.Top + TB_Name.Height + 2
    '        Do While Me.Parent.Name <> O.Name
    '            L = L + O.Left
    '            T = T + O.Top
    '            O = O.Parent
    '        Loop
    '        If T + Me.Height > Me.Parent.Height Then
    '            T = T - Me.Height - TB_Name.Height - 4
    '        End If
    '        Me.Top = T
    '        Me.Left = L
    '        Me.FG_Refresh(True)
    '    End Sub

    '    Private Sub Employee_List2_Employee_Sel(ByVal Employee_No As String, ByVal Employee_Name As String, ByVal ID As String)
    '        TB_Name.Text = Employee_Name
    '        TB_Name.Tag = ID
    '        If Employee_Name <> "" Then
    '            If Not NextControl Is Nothing AndAlso TB_LastKeys = Keys.Enter Then NextControl.Focus()
    '        End If
    '    End Sub

    '    Private Sub Employee_List2_GetFocusState(ByRef HasFocused As Boolean)
    '        If TB_Name.Focused = False Then
    '            HasFocused = False
    '        Else
    '            HasFocused = True
    '        End If
    '    End Sub

    '    Private Sub Employee_List2_GetSearchEvent(ByRef Employee_Name As String, ByRef ID As String, ByVal Cancel As Boolean)
    '        Employee_Name = TB_Name.Text
    '        ID = TB_Name.Tag
    '    End Sub
    '#End Region


    '#Region "绑定到FG上"
    '    Private WithEvents FGX As PClass.FG
    '    Private Col_Employee_No As String = "Employee_No"
    '    Private Col_Employee_Name As String = "Employee_Name"
    '    Private Col_Employee_ID As String = "Employee_ID"
    '    ''' <summary>
    '    ''' 把控件事件绑定到FG上
    '    ''' </summary>
    '    ''' <param name="FGX"></param>
    '    ''' <param name="Col_Employee_No">FG上的字段</param>
    '    ''' <param name="Col_Employee_Name">FG上的字段</param>
    '    ''' <remarks></remarks>
    '    Public Sub Set_FG(ByVal FGX As PClass.FG, Optional ByVal Col_Employee_No As String = "Employee_No", Optional ByVal Col_Employee_Name As String = "Employee_Name", Optional ByVal Col_Employee_ID As String = "Employee_ID")
    '        Me.Col_Employee_No = Col_Employee_No
    '        Me.Col_Employee_Name = Col_Employee_Name
    '        Me.Col_Employee_ID = Col_Employee_ID
    '        Me.FGX = FGX
    '        AddHandler Me.Employee_Sel, AddressOf Me_Employee_Sel
    '        AddHandler Me.GetFocusState, AddressOf Me_GetFocusState
    '        AddHandler Me.GetSearchEvent, AddressOf Me_GetSearchEvent
    '        AddHandler Me.SetKeyEnter, AddressOf FG_SetKeyEnter
    '    End Sub

    '    Private Sub FGX_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles FGX.KeyDownEdit
    '        If e.Col = FGX.Cols(Col_Employee_No).Index Then
    '            If (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) AndAlso FGX.CanEditing Then
    '                Me.FG_KeyDown(e.KeyCode)
    '                e.Handled = True
    '            End If
    '            FGX.Item(e.Row, Col_Employee_Name) = ""
    '        End If
    '    End Sub

    '    Private Sub FGX_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FGX.LostFocus
    '        Me.StartHide()
    '    End Sub

    '    Private Sub FGX_LeaveEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FGX.LeaveEdit
    '        Me.StartHide()
    '    End Sub

    '    Private Sub FGX_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles FGX.AfterScroll
    '        Show_Employee_List()
    '    End Sub
    '    Private Sub FGX_CheckEditing(ByVal sender As Object, ByRef e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FGX.CheckEditing
    '        Show_Employee_List()
    '    End Sub
    '    Private Sub FGX_KeyPressEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyPressEditEventArgs) Handles FGX.KeyPressEdit
    '        If e.Col = FGX.Cols(Col_Employee_No).Index Then
    '            Me.StartSearch()
    '            If FGX.LastText <> IsNull(FGX.Editor.Text, "") Then FGX.Item(e.Row, Col_Employee_Name) = ""
    '        End If
    '    End Sub
    '    Sub Show_Employee_List()
    '        If FGX.ColSel = FGX.Cols(Col_Employee_No).Index Then
    '            Dim C As C1.Win.C1FlexGrid.Column = FGX.Cols(FGX.ColSel)
    '            Dim R As C1.Win.C1FlexGrid.Row = FGX.Rows(FGX.RowSel)
    '            Dim O As Windows.Forms.Control = FGX.Parent
    '            Dim L As Integer = FGX.Left + C.Left + FGX.ScrollPosition.X
    '            Dim T As Integer = FGX.Top + R.Top + R.HeightDisplay + FGX.ScrollPosition.Y + 2
    '            Do While Me.Parent.Name <> O.Name
    '                L = L + O.Left
    '                T = T + O.Top
    '                O = O.Parent
    '            Loop
    '            If T + Me.Height > Me.Parent.Height Then
    '                T = T - Me.Height - R.HeightDisplay - 4
    '            End If
    '            Me.Top = T
    '            Me.Left = L
    '            Me.FG_Refresh(True)
    '        End If
    '    End Sub
    '    Sub FG_SetKeyEnter()
    '        FGX.LastKey = Keys.Enter
    '    End Sub

    '    Private Sub Me_Employee_Sel(ByVal Employee_No As String, ByVal Employee_Name As String, ByVal Id As String)
    '        FGX.Item(FGX.RowSel, Col_Employee_No) = Employee_No
    '        FGX.Item(FGX.RowSel, Col_Employee_Name) = Employee_Name
    '        FGX.Item(FGX.RowSel, Col_Employee_ID) = Id
    '        If Employee_Name <> "" Then
    '            FGX.GotoNextCell(Col_Employee_No)
    '        End If
    '    End Sub

    '    Private Sub Me_GetFocusState(ByRef HasFocused As Boolean)
    '        If (FGX.Editor Is Nothing OrElse FGX.Editor.Focused = False) Then
    '            HasFocused = False
    '        Else
    '            If FGX.ColSel = FGX.Cols(Col_Employee_No).Index Then
    '                HasFocused = True
    '            Else
    '                HasFocused = False
    '            End If
    '        End If
    '    End Sub

    '    Private Sub Me_GetSearchEvent(ByRef Employee_No As String, ByRef ID As String, ByVal Cancel As Boolean)
    '        If FGX.RowSel > 0 Then
    '            If FGX.Editor Is Nothing Then
    '                Employee_No = IsNull(FGX.Item(FGX.RowSel, Col_Employee_No), "")
    '            Else
    '                Employee_No = FGX.Editor.Text
    '            End If
    '            ID = IsNull(FGX.Item(FGX.RowSel, Col_Employee_ID), "")
    '        Else
    '            Cancel = True
    '        End If
    '    End Sub


    '#End Region
End Class

