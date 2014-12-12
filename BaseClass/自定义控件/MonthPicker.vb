Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

<Description("月份选择控件"), Designer(GetType(BenHeightDesigner)), Drawing.ToolboxBitmap(GetType(DateTimePicker))> _
Public Class MonthPicker
    Private Sub Label_Month_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_Month.Click
        MonthPicker_Click(sender, e)
    End Sub

    Private Sub Label_Title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_Title.Click
        MonthPicker_Click(sender, e)
    End Sub
    Private Sub MonthPicker_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If _IsReadOnly = False Then
            If (Now - CloseTime).TotalMilliseconds > 500 Then
                Me.ShowTooltrip()
            End If
        End If
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        MonthPicker_Click(sender, e)
    End Sub

#Region "API定义"
    Private Const WM_LBUTTONDOWN As Integer = &H201, WM_LBUTTONDBLCLK As Integer = &H203
    Private Declare Auto Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As IntPtr, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Long
    Private Declare Auto Function GetWindowRect Lib "user32" Alias "GetWindowRect" (ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential, CharSet:=Runtime.InteropServices.CharSet.Auto)> _
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure
#End Region



#Region "变量和属性"
    Overrides Property Text() As String
        Get
            Return Label_Month.Text
        End Get
        Set(ByVal value As String)
            Label_Month.Text = value
        End Set
    End Property



    Private _AutoFixSize As Boolean = True
    ''' <summary>
    ''' 自动调整大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("自动调整大小"), Browsable(True)> _
    Public Property AutoFixSize() As Boolean
        Get
            Return _AutoFixSize
        End Get
        Set(ByVal value As Boolean)

            _AutoFixSize = value
        End Set
    End Property



    ''' <summary>
    ''' 标题
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("标题"), Browsable(True)> _
    Public Property Title() As String
        Get
            Return Label_Title.Text
        End Get
        Set(ByVal value As String)
            Label_Title.Text = value
        End Set
    End Property



    Private _IsShowTitle As Boolean = True

    ''' <summary>
    ''' 是否显示 月份 两个字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否显示 月份 两个字"), Browsable(True)> _
    Public Property IsShowTitle() As Boolean
        Get
            Return _IsShowTitle
        End Get
        Set(ByVal value As Boolean)
            _IsShowTitle = value
            Label_Title.Visible = value
        End Set
    End Property



    Private _IsReadOnly As Boolean

    ''' <summary>
    ''' 是否只读
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否只读"), Browsable(True)> _
    Public Property IsReadOnly() As String
        Get
            Return _IsReadOnly
        End Get
        Set(ByVal value As String)
            _IsReadOnly = value
        End Set
    End Property


    Private _Format As String = "yyyy年MM月"

    ''' <summary>
    ''' 显示日期的格式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示日期的格式"), Browsable(True)> _
    Public Property Format() As String
        Get
            Return _Format
        End Get
        Set(ByVal value As String)
            _Format = value
        End Set
    End Property


    Public _ThisMonth As Date = Nothing
    Public Function ThisMonth() As Date
        If _ThisMonth = Nothing Then
            Return Today
        Else
            Return _ThisMonth
        End If
    End Function

    Public _Value As Date = Today
    ''' <summary>
    ''' 当前选择的日期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("当前选择的日期"), Browsable(True)> _
    Public Property Value() As Date
        Get
            Return New Date(_Value.Year, _Value.Month, 1)
        End Get
        Set(ByVal value As Date)
            Try
                Label_Month.Text = value.ToString(_Format)
            Catch ex As Exception
                Label_Month.Text = value.ToString("yyyy年MM月")
            End Try
            _Value = value
        End Set
    End Property



    Private _Child As YearMonth


    ''' <summary>
    ''' ToolTrip是否显示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("ToolTrip是否显示"), Browsable(False), Category("N8")> _
    Public ReadOnly Property IsShow() As Boolean
        Get
            If _DropDownItem IsNot Nothing Then
                Return _DropDownItem.Visible
            Else
                Return False
            End If
        End Get
    End Property


    Private _TopMost As Boolean = False
    ''' <summary>
    ''' 直至在最前,可能会挡住输入法,如果设置False会导致失去输入焦点
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("直至在最前,可能会挡住输入法,如果设置False会导致失去输入焦点"), Browsable(True), Category("N8")> _
    Public Property TopMost() As Boolean
        Get
            Return _TopMost
        End Get
        Set(ByVal value As Boolean)
            _TopMost = value
        End Set
    End Property

    ''' <summary>
    ''' 优先显示在原控件的相对位置
    ''' </summary>
    ''' <remarks></remarks>
    Enum Enum_ShowDirection
        ''' <summary>
        ''' 下边
        ''' </summary>
        ''' <remarks></remarks>
        Below = 0
        ''' <summary>
        '''  左边
        ''' </summary>
        ''' <remarks></remarks>
        Left = 1
        ''' <summary>
        ''' 右边
        ''' </summary>
        ''' <remarks></remarks>
        Right = 2
        ''' <summary>
        ''' 上边
        ''' </summary>
        ''' <remarks></remarks>
        Top = 3
    End Enum

    Dim _ShowDirection As Enum_ShowDirection = Enum_ShowDirection.Below
    <Description("Tooptip优先显示在原控件的相对位置。"), Browsable(True), Category("N8")> _
    Public Property ShowDirection() As Enum_ShowDirection
        Get
            Return _ShowDirection
        End Get
        Set(ByVal value As Enum_ShowDirection)
            _ShowDirection = value
        End Set
    End Property

    Dim _ShowDistince As Integer = 1
    <Description("Tooptip优先显示在原控件的相对距离。"), Browsable(True), Category("N8")> _
    Public Property ShowDistince() As Integer
        Get
            Return _ShowDistince
        End Get
        Set(ByVal value As Integer)
            _ShowDistince = value
        End Set
    End Property


    Private WithEvents _DropDownItem As ToolStripDropDown
    Private _ToolStripControlHost As ToolStripControlHost
    Private WithEvents TimerShow As New Timer


    Private Sub _DropDownItem_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles _DropDownItem.Closed
        CloseTime = Now
    End Sub
#End Region


#Region "方法"




    ''' <summary>
    ''' 显示Tooltrip
    ''' </summary>
    ''' <remarks></remarks>
    Sub ShowTooltrip()
        TimerShow.Stop()
        If _DropDownItem IsNot Nothing AndAlso _DropDownItem.Visible Then
            Exit Sub
        End If


        Dim IsCancel As Boolean = False

        Dim c As Boolean = False
        _Child = New YearMonth
        _Child._Parent = Me
        If _DropDownItem IsNot Nothing AndAlso Object.ReferenceEquals(_ToolStripControlHost.Control, _Child) = False Then
            'RemoveHandler _ToolStripControlHost.MouseEnter, AddressOf Child_MouseEnter
            'RemoveHandler _ToolStripControlHost.MouseLeave, AddressOf Child_MouseLeave
            RemoveHandler _DropDownItem.Opened, AddressOf dropDown_Opened
            _ToolStripControlHost.Dispose()
            _DropDownItem.Dispose()
            _DropDownItem = Nothing
            _ToolStripControlHost = Nothing
        End If
        If _DropDownItem Is Nothing Then
            _DropDownItem = New ToolStripDropDown()
            c = True
            _DropDownItem.AutoClose = True
        End If


        If c Then
            _ToolStripControlHost = New ToolStripControlHost(_Child)
            _ToolStripControlHost.AutoSize = False
            _ToolStripControlHost.Margin = New Padding(1)
            _Child.Dock = DockStyle.Fill
            _DropDownItem.Padding = New Padding(0)
            _DropDownItem.Items.Add(_ToolStripControlHost)
            '  _DropDownItem.AutoClose = False
            'AddHandler _ToolStripControlHost.MouseEnter, AddressOf Child_MouseEnter
            ' AddHandler _ToolStripControlHost.MouseLeave, AddressOf Child_MouseLeave
            AddHandler _DropDownItem.Opened, AddressOf dropDown_Opened

        End If
        ShowItem()
        _Child.ChangeDate(Value)
    End Sub

    Protected Overridable Sub ShowItem()
        Dim x As Integer
        Dim y As Integer
        Dim i As Integer = 7


        Select Case _ShowDirection
            Case Enum_ShowDirection.Below '下边
                If Me.Parent.PointToScreen(Me.Location).X + Size.Width > Screen.FromControl(Me).Bounds.Width Then
                    x = Me.Width
                    i = ToolStripDropDownDirection.Left
                Else
                    x = 0
                End If
                If Me.Parent.PointToScreen(Me.Location).Y + Size.Height + Me.Height > Screen.FromControl(Me).Bounds.Height Then
                    y = -_ShowDistince
                    If i = ToolStripDropDownDirection.Left Then
                        i = ToolStripDropDownDirection.AboveLeft
                    Else
                        i = ToolStripDropDownDirection.AboveRight
                    End If
                Else
                    y = Me.Height + _ShowDistince
                End If
            Case Enum_ShowDirection.Left
                If Me.Parent.PointToScreen(Me.Location).X - Size.Width - _ShowDistince - 2 > 0 Then
                    x = -Size.Width - 2 - _ShowDistince
                    i = ToolStripDropDownDirection.Right
                Else
                    x = Me.Width + Size.Width + _ShowDistince
                    i = ToolStripDropDownDirection.Left
                End If

            Case Enum_ShowDirection.Right
                If Me.Parent.PointToScreen(Me.Location).X + Size.Width + Me.Width + _ShowDistince > Screen.FromControl(Me).Bounds.Width Then
                    x = -Size.Width - 2 - _ShowDistince
                    i = ToolStripDropDownDirection.Right
                Else
                    x = Me.Width + Size.Width + _ShowDistince
                    i = ToolStripDropDownDirection.Left
                End If
            Case Enum_ShowDirection.Top
                i = 1
                If Me.Parent.PointToScreen(Me.Location).Y - Size.Height - _ShowDistince < 0 Then
                    y = Me.Height + _ShowDistince
                    i = ToolStripDropDownDirection.BelowRight
                Else
                    y = -_ShowDistince
                End If
        End Select
        _DropDownItem.Show(Me, New Point(x, y), i)
    End Sub

    ''' <summary>
    ''' 开始关闭Tooltrip,会延时HideDelay毫秒
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartCloseToolTrip()
        TimerShow.Stop()

    End Sub

    Dim CloseTime As Date


    ''' <summary>
    ''' 关闭Tooltrip
    ''' </summary>
    ''' <param name="MustClose">强制关闭</param>
    ''' <remarks></remarks>
    Sub CloseToolTrip(Optional ByVal MustClose As Boolean = True)
        TimerShow.Stop()
        If _DropDownItem IsNot Nothing AndAlso (_DropDownItem.Bounds.Contains(Cursor.Position) = False OrElse MustClose) Then
            _DropDownItem.Close()
        End If
    End Sub

#Region "重新绘画控件"
    '''' <summary>
    '''' 清除控件
    '''' </summary>
    '''' <param name="C"></param>
    '''' <remarks></remarks>
    'Protected Overridable Sub DelMoveControl(ByVal C As Control)
    '    Dim P_Move As PictureBox = C.Controls("P_Move")
    '    C.Controls.Remove(P_Move)
    '    RemoveHandler P_Move.MouseMove, AddressOf P_Move_MouseMove
    '    P_Move.Dispose()
    '    C.Dispose()
    'End Sub

    '''' <summary>
    '''' 右下角的三角形
    '''' </summary>
    '''' <param name="C"></param>
    '''' <remarks></remarks>
    'Protected Overridable Sub DrawMoveControl(ByVal C As Control)
    '    _Size.Height = C.Height + 2
    '    _Size.Width = C.Width + 2

    '    Dim P_Move As New PictureBox
    '    CType(P_Move, System.ComponentModel.ISupportInitialize).BeginInit()
    '    C.SuspendLayout()
    '    P_Move.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    '    P_Move.BackColor = System.Drawing.Color.Blue
    '    P_Move.Cursor = System.Windows.Forms.Cursors.SizeNWSE
    '    P_Move.Location = New System.Drawing.Point(C.Width - 12, C.Height - 12)
    '    P_Move.Margin = New System.Windows.Forms.Padding(0)
    '    P_Move.Name = "P_Move"
    '    P_Move.Size = New System.Drawing.Size(12, 12)
    '    P_Move.TabIndex = 6
    '    P_Move.TabStop = False
    '    C.Controls.Add(P_Move)
    '    P_Move.BringToFront()
    '    Dim myGraphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
    '    myGraphicsPath.AddLine(12, 0, 0, 12)
    '    myGraphicsPath.AddLine(0, 12, 12, 12)
    '    P_Move.Region = New Region(myGraphicsPath)
    '    C.Margin = New System.Windows.Forms.Padding(0)
    '    CType(P_Move, System.ComponentModel.ISupportInitialize).EndInit()
    '    C.ResumeLayout(False)

    '    AddHandler P_Move.MouseMove, AddressOf P_Move_MouseMove
    'End Sub

    'Private Sub P_Move_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        If sender IsNot Nothing Then
    '            Dim W As Integer = e.X + sender.left
    '            Dim H As Integer = e.Y + sender.top
    '            Dim C As Control = CType(sender, PictureBox).Parent
    '            C.Width = W
    '            C.Height = H
    '            _Size.Height = H
    '            _Size.Width = W
    '            C.Refresh()
    '        End If
    '    End If
    'End Sub




#End Region
#End Region




#Region "事件"
    <Description("月份选择")> _
    Public Event ValueChange(ByVal Value As Date)

    Public Sub RaiseValueChange()
        RaiseEvent ValueChange(_Value)
    End Sub

    Private Sub TimerShow_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerShow.Tick
        ShowTooltrip()
    End Sub



    Private Sub dropDown_Opened(ByVal sender As Object, ByVal e As System.EventArgs)
        If _TopMost Then Exit Sub
        Dim hwnd = DirectCast(_DropDownItem, System.Windows.Forms.ToolStripDropDown).Controls(0).Handle
        Dim rect As RECT
        If GetWindowRect(_DropDownItem.Handle, rect) Then
            SetWindowPos(_DropDownItem.Handle, -2, 0, 0, 0, 0, 3)
        End If
    End Sub
#End Region

#Region "调整大小的问题"
    Dim WithEvents TimerSize As New Timer With {.Interval = 1}


    Sub MeReSize()
        Select Case Me.BorderStyle
            Case Windows.Forms.BorderStyle.Fixed3D
                Me.Height = Label_Title.Height + Me.Padding.Top + Me.Padding.Bottom + 4
            Case Windows.Forms.BorderStyle.FixedSingle
                Me.Height = Label_Title.Height + Me.Padding.Top + Me.Padding.Bottom + 2
            Case Windows.Forms.BorderStyle.None
                Me.Height = Label_Title.Height + Me.Padding.Top + Me.Padding.Bottom
        End Select
    End Sub


    Protected Overrides Sub SetBoundsCore(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal specified As BoundsSpecified)
        If _AutoFixSize Then
            MyBase.SetBoundsCore(x, y, width, GetHeight, specified)
        Else
            MyBase.SetBoundsCore(x, y, width, height, specified)
        End If
    End Sub

    Private Function GetHeight() As Integer
        Select Case Me.BorderStyle
            Case Windows.Forms.BorderStyle.Fixed3D
                Return Label_Title.Height + Me.Padding.Top + Me.Padding.Bottom + 4
            Case Windows.Forms.BorderStyle.FixedSingle
                Return Label_Title.Height + Me.Padding.Top + Me.Padding.Bottom + 2
            Case Windows.Forms.BorderStyle.None
                Return Label_Title.Height + Me.Padding.Top + Me.Padding.Bottom
        End Select
    End Function
    Private Sub Label_Title_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_Title.Resize
        If _AutoFixSize Then Me.Height = GetHeight()
    End Sub
#End Region


End Class
