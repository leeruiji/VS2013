Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

<Drawing.ToolboxBitmap(GetType(ToolTip))> _
<Description("可以放自定义控件的ToolTip")> _
<DefaultEvent("BeforeShow")> _
Public Class ToolTipCtrl
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
    ''' <summary>
    ''' 显示他的控件
    ''' </summary>
    ''' <remarks></remarks>
    Private _Col As Control
    ''' <summary>
    ''' 显示他的控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示他的控件"), Browsable(False), Category("N8")> _
    Public ReadOnly Property Col() As Control
        Get
            Return _Col
        End Get
    End Property


    Private _Child As iTooltipChild
    ''' <summary>
    ''' 子控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("子控件"), Browsable(False), Category("N8")> _
    Public Property Child() As iTooltipChild
        Get
            Return _Child
        End Get
        Set(ByVal value As iTooltipChild)
            _Child = value
        End Set
    End Property

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

    Private _AutoSize As Boolean = True
    ''' <summary>
    ''' 自动控制大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("自动控制大小"), Browsable(True), Category("N8")> _
    Public Property AutoSize() As Boolean
        Get
            Return _AutoSize
        End Get
        Set(ByVal value As Boolean)
            _AutoSize = value
        End Set
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


    Private _AllowReSize As Boolean = False
    ''' <summary>
    ''' 运行用户控制控件大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("自动控制大小"), Browsable(True), Category("N8")> _
    Public Property AllowReSize() As Boolean
        Get
            Return _AllowReSize
        End Get
        Set(ByVal value As Boolean)
            _AllowReSize = value
        End Set
    End Property

    Private _Size As Size
    ''' <summary>
    ''' 显示的大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示的大小"), Browsable(True), Category("N8")> _
    Public Property Size() As Size
        Get
            Return _Size
        End Get
        Set(ByVal value As Size)
            _Size = value
        End Set
    End Property

    Private _ShowDelay As Integer = 500
    ''' <summary>
    ''' 显示的时候延时多少毫秒。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示的时候延时多少毫秒。"), Browsable(True), Category("N8")> _
    Public Property ShowDelay() As Integer
        Get
            Return _ShowDelay
        End Get
        Set(ByVal value As Integer)
            _ShowDelay = value
        End Set
    End Property

    Private _HidDelay As Integer = 500
    ''' <summary>
    ''' 获取或设置工具提示的自动延迟。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("隐藏的时候延时多少毫秒。"), Browsable(True), Category("N8")> _
    Public Property HidDelay() As Integer
        Get
            Return _HidDelay
        End Get
        Set(ByVal value As Integer)
            _HidDelay = value
        End Set
    End Property


    Private _Delay As Integer = 5000
    ''' <summary>
    ''' Tooptip显示后多少毫秒之后自动隐藏,0为不隐藏。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Tooptip显示后多少毫秒之后自动隐藏,0为不隐藏。"), Browsable(True), Category("N8")> _
    Public Property Delay() As Integer
        Get
            Return _Delay
        End Get
        Set(ByVal value As Integer)
            _Delay = value
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


    Private _DropDownItem As ToolStripDropDown
    Private _ToolStripControlHost As ToolStripControlHost
    Private WithEvents TimerShow As New Timer
    Private WithEvents TimerHide As New Timer
    Private WithEvents TimerDelay As New Timer
    Private WithEvents TimerCheck As New Timer
#End Region


#Region "方法"

    ''' <summary>
    ''' 设置控件
    ''' </summary>
    ''' <param name="Col"></param>
    ''' <remarks></remarks>
    Public Sub SetCol(ByVal Col As Control)
        If _Col IsNot Nothing Then
            RemoveHandler _Col.MouseEnter, AddressOf Col_MouseEnter
            RemoveHandler _Col.MouseLeave, AddressOf Col_MouseLeave
            _Col = Nothing
        End If
        Me._Col = Col
        AddHandler _Col.MouseEnter, AddressOf Col_MouseEnter
        AddHandler _Col.MouseLeave, AddressOf Col_MouseLeave
    End Sub

#Region "鼠标 进入 退出 "
    'Private Sub Child_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TimerHide.Stop()
    '    StartShowTooltrip()
    'End Sub

    'Private Sub Child_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    StartCloseToolTrip()
    'End Sub

    Sub StartCheck()
        TimerHide.Stop()
        TimerCheck.Interval = 10
        TimerCheck.Start()
    End Sub

    Private Sub TimerCheck_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerCheck.Tick
        If _DropDownItem IsNot Nothing AndAlso _DropDownItem.Bounds.Contains(Cursor.Position) = False Then
            TimerCheck.Stop()
            StartCloseToolTrip()
        End If
    End Sub

    Private Sub Col_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        TimerCheck.Stop()
        TimerHide.Stop()
        StartShowTooltrip()
    End Sub

    Private Sub Col_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        StartCloseToolTrip()
    End Sub
#End Region


    ''' <summary>
    ''' 开始显示Tooltrip,会延时ShowDelay毫秒
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartShowTooltrip()
        TimerShow.Interval = ShowDelay
        TimerShow.Start()
    End Sub

    ''' <summary>
    ''' 显示Tooltrip
    ''' </summary>
    ''' <remarks></remarks>
    Sub ShowTooltrip()
        TimerShow.Stop()
        If _DropDownItem IsNot Nothing AndAlso _DropDownItem.Visible Then
            Exit Sub
        End If
        TimerHide.Stop()

        Dim IsCancel As Boolean = False
        Dim ShowSize As Size = Me.Size
        Dim c As Boolean = False
        RaiseEvent BeforeShow(_Child, ShowSize, IsCancel)
        If IsCancel = True OrElse _Col Is Nothing OrElse _Child Is Nothing Then
            Exit Sub
        Else
            _Child.ToolTip = Me
        End If
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
        End If
        If AutoSize Then
            ShowSize = _Child.Size
            Size = New Size(ShowSize.Width + 10, ShowSize.Height + 10)
            _DropDownItem.Size = Size
        Else
            Size = ShowSize
            _DropDownItem.Size = Size
        End If
        If c Then
            _ToolStripControlHost = New ToolStripControlHost(_Child)
            _ToolStripControlHost.AutoSize = False
            _ToolStripControlHost.Margin = New Padding(1)
            _Child.Dock = DockStyle.Fill
            _DropDownItem.Padding = New Padding(0)
            _DropDownItem.Items.Add(_ToolStripControlHost)
            _DropDownItem.AutoClose = False
            'AddHandler _ToolStripControlHost.MouseEnter, AddressOf Child_MouseEnter
            ' AddHandler _ToolStripControlHost.MouseLeave, AddressOf Child_MouseLeave
            AddHandler _DropDownItem.Opened, AddressOf dropDown_Opened
            If AllowReSize Then
                DrawMoveControl(_Child)
            End If
        End If
        ShowItem()
        TimerDelay.Interval = Delay
        TimerDelay.Start()
    End Sub

    Protected Overridable Sub ShowItem()
        Dim x As Integer
        Dim y As Integer
        Dim i As Integer = 7
        Dim Size As Size
        If _DropDownItem.Size.Width < 10 Then
            If AutoSize Then
                Size = _Child.Size
            Else
                Size = Me.Size
            End If
        Else
            Size = _DropDownItem.Size
        End If
        Select Case _ShowDirection
            Case Enum_ShowDirection.Below '下边
                If _Col.Parent.PointToScreen(_Col.Location).X + Size.Width > Screen.FromControl(_Col).Bounds.Width Then
                    x = _Col.Width
                    i = ToolStripDropDownDirection.Left
                Else
                    x = 0
                End If
                If _Col.Parent.PointToScreen(_Col.Location).Y + Size.Height + _Col.Height > Screen.FromControl(_Col).Bounds.Height Then
                    y = -_ShowDistince
                    If i = ToolStripDropDownDirection.Left Then
                        i = ToolStripDropDownDirection.AboveLeft
                    Else
                        i = ToolStripDropDownDirection.AboveRight
                    End If
                Else
                    y = _Col.Height + _ShowDistince
                End If
            Case Enum_ShowDirection.Left
                If _Col.Parent.PointToScreen(_Col.Location).X - Size.Width - _ShowDistince - 2 > 0 Then
                    x = -Size.Width - 2 - _ShowDistince
                    i = ToolStripDropDownDirection.Right
                Else
                    x = _Col.Width + Size.Width + _ShowDistince
                    i = ToolStripDropDownDirection.Left
                End If

            Case Enum_ShowDirection.Right
                If _Col.Parent.PointToScreen(_Col.Location).X + Size.Width + _Col.Width + _ShowDistince > Screen.FromControl(_Col).Bounds.Width Then
                    x = -Size.Width - 2 - _ShowDistince
                    i = ToolStripDropDownDirection.Right
                Else
                    x = _Col.Width + Size.Width + _ShowDistince
                    i = ToolStripDropDownDirection.Left
                End If
            Case Enum_ShowDirection.Top
                i = 1
                If _Col.Parent.PointToScreen(_Col.Location).Y - Size.Height - _ShowDistince < 0 Then
                    y = _Col.Height + _ShowDistince
                    i = ToolStripDropDownDirection.BelowRight
                Else
                    y = -_ShowDistince
                End If
        End Select
        _DropDownItem.Show(_Col, New Point(x, y), i)
    End Sub

    ''' <summary>
    ''' 开始关闭Tooltrip,会延时HideDelay毫秒
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartCloseToolTrip()
        TimerShow.Stop()
        TimerHide.Stop()
        TimerHide.Interval = HidDelay
        TimerHide.Start()
    End Sub

    ''' <summary>
    ''' 关闭Tooltrip
    ''' </summary>
    ''' <param name="MustClose">强制关闭</param>
    ''' <remarks></remarks>
    Sub CloseToolTrip(Optional ByVal MustClose As Boolean = True)
        TimerShow.Stop()
        TimerHide.Stop()
        TimerDelay.Stop()
        If _DropDownItem IsNot Nothing AndAlso (_DropDownItem.Bounds.Contains(Cursor.Position) = False OrElse MustClose) Then
            _DropDownItem.Close()
        Else
            StartCheck()
        End If
    End Sub

#Region "重新绘画控件"
    ''' <summary>
    ''' 清除控件
    ''' </summary>
    ''' <param name="C"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub DelMoveControl(ByVal C As Control)
        Dim P_Move As PictureBox = C.Controls("P_Move")
        C.Controls.Remove(P_Move)
        RemoveHandler P_Move.MouseMove, AddressOf P_Move_MouseMove
        P_Move.Dispose()
        C.Dispose()
    End Sub

    ''' <summary>
    ''' 右下角的三角形
    ''' </summary>
    ''' <param name="C"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub DrawMoveControl(ByVal C As Control)
        _Size.Height = C.Height + 2
        _Size.Width = C.Width + 2

        Dim P_Move As New PictureBox
        CType(P_Move, System.ComponentModel.ISupportInitialize).BeginInit()
        C.SuspendLayout()
        P_Move.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        P_Move.BackColor = System.Drawing.Color.Blue
        P_Move.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        P_Move.Location = New System.Drawing.Point(C.Width - 12, C.Height - 12)
        P_Move.Margin = New System.Windows.Forms.Padding(0)
        P_Move.Name = "P_Move"
        P_Move.Size = New System.Drawing.Size(12, 12)
        P_Move.TabIndex = 6
        P_Move.TabStop = False
        C.Controls.Add(P_Move)
        P_Move.BringToFront()
        Dim myGraphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
        myGraphicsPath.AddLine(12, 0, 0, 12)
        myGraphicsPath.AddLine(0, 12, 12, 12)
        P_Move.Region = New Region(myGraphicsPath)
        C.Margin = New System.Windows.Forms.Padding(0)
        CType(P_Move, System.ComponentModel.ISupportInitialize).EndInit()
        C.ResumeLayout(False)

        AddHandler P_Move.MouseMove, AddressOf P_Move_MouseMove
    End Sub

    Private Sub P_Move_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If sender IsNot Nothing Then
                Dim W As Integer = e.X + sender.left
                Dim H As Integer = e.Y + sender.top
                Dim C As Control = CType(sender, PictureBox).Parent
                C.Width = W
                C.Height = H
                _Size.Height = H
                _Size.Width = W
                C.Refresh()
            End If
        End If
    End Sub




#End Region
#End Region




#Region "事件"
    Public Event BeforeShow(ByRef Child As iTooltipChild, ByRef ShowSize As Size, ByRef isCancel As Boolean)

    Private Sub TimerDelay_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerDelay.Tick
        TimerDelay.Stop()
        StartCloseToolTrip()
    End Sub

    Private Sub TimerShow_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerShow.Tick
        ShowTooltrip()
    End Sub

    Private Sub TimerHide_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerHide.Tick
        CloseToolTrip(False)
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



End Class
