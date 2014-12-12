
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports PClass.PClass

<Description("单据操作记录控件"), Designer(GetType(BenHeightDesigner)), Drawing.ToolboxBitmap(GetType(Label))> _
Public Class GH_BillLog
    Private _DropDownItem As ToolStripDropDown
    Private _ToolStripControlHost As ToolStripControlHost
    Private WithEvents TimerDelay As New Timer
    Private _Child As New GH_BillLogItem With {.GH_BillLog = Me}




#Region "变量和属性"

    Dim _BillType As Integer
    <Description("单据类型。"), Browsable(True), Category("N8")> _
    Public Property BillType() As BillType
        Get
            Return _BillType
        End Get
        Set(ByVal value As BillType)
            _BillType = value
        End Set
    End Property


    Dim _BillID As String = ""
    <Description("单据ID。"), Browsable(False), Category("N8")> _
    Public Property BillID() As String
        Get
            Return _BillID
        End Get
        Set(ByVal value As String)
            _BillID = value
            If BillID <> "" Then
                GetLastUser()
            End If
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



    ''' <summary>
    ''' 对齐方式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("对齐方式"), Browsable(True)> _
    Public Property TextAlign() As HorizontalAlignment
        Get
            Return TB_Value.TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            TB_Value.TextAlign = value
        End Set
    End Property


    ''' <summary>
    ''' 只读
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("只读"), Browsable(True)> _
    Public Property [Readonly]() As Boolean
        Get
            Return TB_Value.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            TB_Value.ReadOnly = value
            If value = True Then
                TB_Value.BackColor = System.Drawing.SystemColors.Control
            Else
                TB_Value.BackColor = System.Drawing.SystemColors.Window
            End If
        End Set
    End Property


    ''' <summary>
    ''' 内容的字体颜色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("内容的字体颜色"), Browsable(True)> _
    Public Property ForeColor_Text() As Color
        Get
            Return TB_Value.ForeColor
        End Get
        Set(ByVal value As Color)
            TB_Value.ForeColor = value
        End Set
    End Property



    ''' <summary>
    ''' 内容的字体
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("内容的字体"), Browsable(True)> _
    Public Property Font_Text() As Font
        Get
            Return TB_Value.Font
        End Get
        Set(ByVal value As Font)
            TB_Value.Font = value
            Label_Title_Resize(Me, New EventArgs)
        End Set
    End Property



    ''' <summary>
    ''' 要显示的内容
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("要显示的内容"), Browsable(True)> _
    Overrides Property Text() As String
        Get
            Return TB_Value.Text
        End Get
        Set(ByVal value As String)
            TB_Value.Text = value
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
            Label2.Text = value
        End Set
    End Property



    Private _IsShowTitle As Boolean = True
    ''' <summary>
    ''' 是否显示标题
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否显示标题"), Browsable(True)> _
    Public Property IsShowTitle() As Boolean
        Get
            Return _IsShowTitle
        End Get
        Set(ByVal value As Boolean)
            _IsShowTitle = value
            Label_Title.Visible = value
        End Set
    End Property


    Private Sub TitleLabel_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        Me.Font_Text = New Font(Me.Font, Me.Font_Text.Style)
        Label_Title_Resize(Me, New EventArgs)
    End Sub




#End Region




#Region "调整大小的问题"





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
                Return TB_Value.Height + Me.Padding.Top + Me.Padding.Bottom + 4
            Case Windows.Forms.BorderStyle.FixedSingle
                Return TB_Value.Height + Me.Padding.Top + Me.Padding.Bottom + 2
            Case Windows.Forms.BorderStyle.None
                Return TB_Value.Height + Me.Padding.Top + Me.Padding.Bottom
        End Select
    End Function
    Private Sub Label_Title_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_Title.Resize
        If _AutoFixSize Then Me.Height = GetHeight()
        Label_Title.Height = Me.Height
        Label_Title.Width = Me.Width - 20
    End Sub

#End Region


#Region "函数"
    Sub InsertReadLog(ByVal State As Enum_State)
        'ComFun.InserReadLog(Me.BillType, Me.BillID, State)
    End Sub

    Sub SetBillID(ByVal ID As String, ByVal IsRead As Boolean, ByVal State As Enum_State)
        Me.BillID = ID
        If IsRead Then InsertReadLog(State)
    End Sub


    Sub GetLastUser()
        Dim P As New Dictionary(Of String, Object)
        P.Add("BillType", BillType)
        P.Add("BillID", BillID)
        Dim R As PClass.PClass.DtReturnMsg = PClass.PClass.SqlStrToDt("select top 1 ChagneUser from T10080_BillStateLog where BillType=@BillType and ID=@BillID order by ChangeTime desc", P)
        If R.Dt.Rows.Count > 0 Then
            TB_Value.Text = R.Dt.Rows(0)("ChagneUser")
        Else
            TB_Value.Text = ""
        End If
    End Sub


    Sub ShowDropDrown()

        If _DropDownItem IsNot Nothing AndAlso _DropDownItem.Visible Then
            Exit Sub
        End If

        Dim IsCancel As Boolean = False
        Dim ShowSize As Size = Me.Size
        Dim c As Boolean = False
        'If IsCancel = True OrElse Me Is Nothing OrElse _Child Is Nothing Then
        '    Exit Sub
        'Else
        '    _Child.ToolTip = Me
        'End If
        If _DropDownItem IsNot Nothing AndAlso Object.ReferenceEquals(_ToolStripControlHost.Control, _Child) = False Then
            'RemoveHandler _ToolStripControlHost.MouseEnter, AddressOf Child_MouseEnter
            'RemoveHandler _ToolStripControlHost.MouseLeave, AddressOf Child_MouseLeave
            'RemoveHandler _DropDownItem.Opened, AddressOf dropDown_Opened
            _ToolStripControlHost.Dispose()
            _DropDownItem.Dispose()
            _DropDownItem = Nothing
            _ToolStripControlHost = Nothing
        End If
        If _DropDownItem Is Nothing Then
            _DropDownItem = New ToolStripDropDown()
            c = True
        End If
        Size = ShowSize
        _DropDownItem.Size = Size
        If c Then
            _ToolStripControlHost = New ToolStripControlHost(_Child)
            _ToolStripControlHost.AutoSize = False
            _ToolStripControlHost.Margin = New Padding(1)
            _Child.Dock = DockStyle.Fill
            _DropDownItem.Padding = New Padding(0)
            _DropDownItem.Items.Add(_ToolStripControlHost)
            _DropDownItem.AutoClose = True
            'AddHandler _ToolStripControlHost.MouseEnter, AddressOf Child_MouseEnter
            ' AddHandler _ToolStripControlHost.MouseLeave, AddressOf Child_MouseLeave
            'AddHandler _DropDownItem.Opened, AddressOf dropDown_Opened
            'If AllowReSize Then
            '    DrawMoveControl(_Child)
            'End If
        End If
        ShowItem()
        _Child.ShowLog()

    End Sub

    Protected Overridable Sub ShowItem()
        Dim x As Integer
        Dim y As Integer
        Dim i As Integer = 7
        Dim Size As Size

        Size = _Child.Size

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
    ''' 关闭Tooltrip
    ''' </summary>
    ''' <param name="MustClose">强制关闭</param>
    ''' <remarks></remarks>
    Sub CloseToolTrip(Optional ByVal MustClose As Boolean = True)
        TimerDelay.Stop()
        If _DropDownItem IsNot Nothing AndAlso (_DropDownItem.Bounds.Contains(Cursor.Position) = False OrElse MustClose) Then
            _DropDownItem.Close()
        End If
    End Sub


    Private Sub Label3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click
        ShowDropDrown()
    End Sub

    Private Sub Label_Title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_Title.Click
        ShowDropDrown()
    End Sub
#End Region


  
End Class
