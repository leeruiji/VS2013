﻿
Public Class Supplier_List

    Protected Overrides Sub Col_Ini()
        Me.Col_Col_ID = "Supplier_ID"
        Dim Supplier_Name As String = "Supplier_Name"
        Dim Supplier_No As String = "Supplier_No"

        Fg1.Cols(Me.Col_Col_Name).Name = Supplier_Name
        Fg1.Cols(Me.Col_Col_No).Name = Supplier_No

        Col_Col_Name = Supplier_Name
        Col_Col_No = Supplier_No
        Me.SQL_Col_GetSearch = SQL_Supplier_GetSearch
        Me.SQL_Col_GetSearch_GetByID = SQL_Supplier_GetSearch_GetByID
        Me.SQL_Col_GetSearch_Order = SQL_Supplier_GetSearch_Order
        Me.SQL_Col_GetSearch_Where = SQL_Supplier_GetSearch_Where
        Loaded = True
    End Sub



    '    Public Event Supplier_Sel(ByVal Supplier_No As String, ByVal Supplier_Name As String, ByVal ID As String)
    '    Public Event GetSearchEvent(ByRef Supplier_No As String, ByRef ID As String, ByVal Cancel As Boolean)
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
    '        Dim GS As String = SQL_Supplier_GetSearch
    '        If NotTop Then
    '            NotTop = False
    '            GS = SQL_Supplier_GetSearch.Replace("top 10", "")
    '        End If
    '        If Search = "" Then
    '            Dtr = SqlStrToDt(GS & SQL_Supplier_GetSearch_Order, Parameters)
    '        Else
    '            Dtr = SqlStrToDt(GS & SQL_Supplier_GetSearch_Where & SQL_Supplier_GetSearch_Order, Parameters)
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
    '        If Not TB_No Is Nothing Then
    '            If TB_No.Focused Then Me.Visible = True
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




    '    Private Sub Supplier_List_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
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

    '    Public Sub Supplier_SelOne()
    '        If Fg1.RowSel > 0 And Me.Fg1.Focused = False Then
    '            RaiseEvent Supplier_Sel(Fg1.Item(Fg1.RowSel, "Supplier_No"), Fg1.Item(Fg1.RowSel, "Supplier_Name"), Fg1.Item(Fg1.RowSel, "ID"))
    '        End If
    '    End Sub


    '    Private Sub FG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Click
    '        If Fg1.RowSel > 0 Then
    '            RaiseEvent SetKeyEnter()
    '            RaiseEvent Supplier_Sel(Fg1.Item(Fg1.RowSel, "Supplier_No"), Fg1.Item(Fg1.RowSel, "Supplier_Name"), Fg1.Item(Fg1.RowSel, "ID"))
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
    '    Private WithEvents TB_No As TextBox
    '    Private TB_Name As Windows.Forms.Control
    '    Private NextControl As Windows.Forms.Control
    '    ''' <summary>
    '    ''' 把控件事件绑定到TextBox上
    '    ''' </summary>
    '    ''' <param name="TB_Supplier_No"></param>
    '    ''' <param name="TB_Supplier_Name"></param>
    '    ''' <param name="NextControl">下一个控件</param>
    '    ''' <remarks></remarks>
    '    Public Sub Set_TextBox(ByVal TB_Supplier_No As TextBox, ByVal TB_Supplier_Name As Windows.Forms.Control, ByVal NextControl As Windows.Forms.Control)
    '        Me.TB_No = TB_Supplier_No
    '        Me.TB_Name = TB_Supplier_Name
    '        Me.NextControl = NextControl
    '        AddHandler Me.Supplier_Sel, AddressOf Supplier_List2_Supplier_Sel
    '        AddHandler Me.GetFocusState, AddressOf Supplier_List2_GetFocusState
    '        AddHandler Me.GetSearchEvent, AddressOf Supplier_List2_GetSearchEvent
    '        AddHandler Me.SetKeyEnter, AddressOf TB_SetKeyEnter
    '    End Sub


    '    ''' <summary>
    '    ''' 根据TAG获取名称
    '    ''' </summary>
    '    ''' <param name="ID"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function GetByTextBoxTag(Optional ByVal ID As String = "") As String
    '        If TB_No Is Nothing Then
    '            Return ""
    '            Exit Function
    '        Else
    '            If ID = "" Then ID = TB_No.Tag
    '            Dim Dtr As DtReturnMsg = SqlStrToDt(SQL_Supplier_GetSearch_GetByID, "@ID", ID)
    '            If Dtr.IsOk Then
    '                If Dtr.Dt.Rows.Count > 0 Then
    '                    TB_No.Text = Dtr.Dt.Rows(0)("Supplier_No")
    '                    TB_No.Tag = Dtr.Dt.Rows(0)("ID")
    '                    If Not TB_Name Is Nothing Then TB_Name.Text = Dtr.Dt.Rows(0)("Supplier_Name")
    '                    DtSetFG(Dtr.Dt)
    '                    Return Dtr.Dt.Rows(0)("Supplier_Name")
    '                Else
    '                    Return ""
    '                End If
    '            Else
    '                Return ""
    '            End If
    '        End If
    '    End Function

    '    Private Sub TB_Supplier_No_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_No.GotFocus
    '        TB_LastKeys = 0
    '        If TB_No.ReadOnly = False Then
    '            TextBox_Show_Supplier_List2()
    '        End If
    '    End Sub

    '    Private Sub TB_Supplier_No_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_No.KeyDown
    '        If TB_No.ReadOnly = True OrElse TB_No.Enabled = False Then
    '            Me.Visible = False
    '            Exit Sub
    '        End If
    '        TB_LastKeys = e.KeyCode
    '        If e.KeyCode = Keys.Down Then
    '            Me.FG_KeyDown(e.KeyCode)
    '            e.Handled = True
    '        End If
    '    End Sub

    '    Private Sub TB_Supplier_No_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_No.KeyPress
    '        If TB_No.ReadOnly = True OrElse TB_No.Enabled = False Then
    '            Me.Visible = False
    '            Exit Sub
    '        End If
    '        If e.KeyChar = vbCr Then
    '            If Not NextControl Is Nothing Then NextControl.Focus()
    '        Else
    '            Me.StartSearch()
    '        End If
    '    End Sub

    '    Private Sub TB_Supplier_No_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_No.LostFocus
    '        If TB_No.ReadOnly = True OrElse TB_No.Enabled = False Then
    '            Me.Visible = False
    '            Exit Sub
    '        End If
    '        Me.Supplier_SelOne()
    '        Me.StartHide()
    '    End Sub

    '    Sub TextBox_Show_Supplier_List2()
    '        Dim O As Windows.Forms.Control = TB_No.Parent
    '        Dim L As Integer = TB_No.Left
    '        Dim T As Integer = TB_No.Top + TB_No.Height + 2
    '        Do While Me.Parent.Name <> O.Name
    '            L = L + O.Left
    '            T = T + O.Top
    '            O = O.Parent
    '        Loop
    '        If T + Me.Height > Me.Parent.Height Then
    '            T = T - Me.Height - TB_No.Height - 4
    '        End If
    '        Me.Top = T
    '        Me.Left = L
    '        Me.FG_Refresh(True)
    '    End Sub

    '    Private Sub Supplier_List2_Supplier_Sel(ByVal Supplier_No As String, ByVal Supplier_Name As String, ByVal ID As String)
    '        TB_No.Text = Supplier_No
    '        TB_No.Tag = ID
    '        TB_Name.Text = Supplier_Name
    '        If Supplier_Name <> "" Then
    '            If Not NextControl Is Nothing AndAlso TB_LastKeys = Keys.Enter Then NextControl.Focus()
    '        End If
    '    End Sub

    '    Private Sub Supplier_List2_GetFocusState(ByRef HasFocused As Boolean)
    '        If TB_No.Focused = False Then
    '            HasFocused = False
    '        Else
    '            HasFocused = True
    '        End If
    '    End Sub

    '    Private Sub Supplier_List2_GetSearchEvent(ByRef Supplier_No As String, ByRef ID As String, ByVal Cancel As Boolean)
    '        Supplier_No = TB_No.Text
    '        ID = TB_No.Tag
    '    End Sub
    '#End Region


    '#Region "绑定到FG上"
    '    Private WithEvents FGX As PClass.FG
    '    Private Col_Supplier_No As String = "Supplier_No"
    '    Private Col_Supplier_Name As String = "Supplier_Name"
    '    Private Col_Supplier_ID As String = "Supplier_ID"
    '    ''' <summary>
    '    ''' 把控件事件绑定到FG上
    '    ''' </summary>
    '    ''' <param name="FGX"></param>
    '    ''' <param name="Col_Supplier_No">FG上的字段</param>
    '    ''' <param name="Col_Supplier_Name">FG上的字段</param>
    '    ''' <remarks></remarks>
    '    Public Sub Set_FG(ByVal FGX As PClass.FG, Optional ByVal Col_Supplier_No As String = "Supplier_No", Optional ByVal Col_Supplier_Name As String = "Supplier_Name", Optional ByVal Col_Supplier_ID As String = "Supplier_ID")
    '        Me.Col_Supplier_No = Col_Supplier_No
    '        Me.Col_Supplier_Name = Col_Supplier_Name
    '        Me.Col_Supplier_ID = Col_Supplier_ID
    '        Me.FGX = FGX
    '        AddHandler Me.Supplier_Sel, AddressOf Me_Supplier_Sel
    '        AddHandler Me.GetFocusState, AddressOf Me_GetFocusState
    '        AddHandler Me.GetSearchEvent, AddressOf Me_GetSearchEvent
    '        AddHandler Me.SetKeyEnter, AddressOf FG_SetKeyEnter
    '    End Sub

    '    Private Sub FGX_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles FGX.KeyDownEdit
    '        If e.Col = FGX.Cols(Col_Supplier_No).Index Then
    '            If (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) AndAlso FGX.CanEditing Then
    '                Me.FG_KeyDown(e.KeyCode)
    '                e.Handled = True
    '            End If
    '            FGX.Item(e.Row, Col_Supplier_Name) = ""
    '        End If
    '    End Sub

    '    Private Sub FGX_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FGX.LostFocus
    '        Me.StartHide()
    '    End Sub

    '    Private Sub FGX_LeaveEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FGX.LeaveEdit
    '        Me.StartHide()
    '    End Sub

    '    Private Sub FGX_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles FGX.AfterScroll
    '        Show_Supplier_List()
    '    End Sub
    '    Private Sub FGX_CheckEditing(ByVal sender As Object, ByRef e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FGX.CheckEditing
    '        Show_Supplier_List()
    '    End Sub
    '    Private Sub FGX_KeyPressEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyPressEditEventArgs) Handles FGX.KeyPressEdit
    '        If e.Col = FGX.Cols(Col_Supplier_No).Index Then
    '            Me.StartSearch()
    '            If FGX.LastText <> IsNull(FGX.Editor.Text, "") Then FGX.Item(e.Row, Col_Supplier_Name) = ""
    '        End If
    '    End Sub
    '    Sub Show_Supplier_List()
    '        If FGX.ColSel = FGX.Cols(Col_Supplier_No).Index Then
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

    '    Private Sub Me_Supplier_Sel(ByVal Supplier_No As String, ByVal Supplier_Name As String, ByVal Id As String)
    '        FGX.Item(FGX.RowSel, Col_Supplier_No) = Supplier_No
    '        FGX.Item(FGX.RowSel, Col_Supplier_Name) = Supplier_Name
    '        FGX.Item(FGX.RowSel, Col_Supplier_ID) = Id
    '        If Supplier_Name <> "" Then
    '            FGX.GotoNextCell(Col_Supplier_No)
    '        End If
    '    End Sub

    '    Private Sub Me_GetFocusState(ByRef HasFocused As Boolean)
    '        If (FGX.Editor Is Nothing OrElse FGX.Editor.Focused = False) Then
    '            HasFocused = False
    '        Else
    '            If FGX.ColSel = FGX.Cols(Col_Supplier_No).Index Then
    '                HasFocused = True
    '            Else
    '                HasFocused = False
    '            End If
    '        End If
    '    End Sub

    '    Private Sub Me_GetSearchEvent(ByRef Supplier_No As String, ByRef ID As String, ByVal Cancel As Boolean)
    '        If FGX.RowSel > 0 Then
    '            If FGX.Editor Is Nothing Then
    '                Supplier_No = IsNull(FGX.Item(FGX.RowSel, Col_Supplier_No), "")
    '            Else
    '                Supplier_No = FGX.Editor.Text
    '            End If
    '            ID = IsNull(FGX.Item(FGX.RowSel, Col_Supplier_ID), "")
    '        Else
    '            Cancel = True
    '        End If
    '    End Sub


    '#End Region
End Class

