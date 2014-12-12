Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports PClass.PClass
<Description("有标题的Label"), Designer(GetType(BenHeightDesigner)), Drawing.ToolboxBitmap(GetType(Label))> _
Public Class TitleTextBox

#Region "事件定义"

#Region "点击"
    Public Event Value_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Value被双击时发生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("Value被双击时发生"), Browsable(True)> _
   Private Sub TB_Value_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Value.DoubleClick
        RaiseEvent Value_DoubleClick(sender, e)
    End Sub


    Public Event Value_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Value被点击时发生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("Value被点击时发生"), Browsable(True)> _
    Private Sub TB_Value_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Value.Click
        RaiseEvent Value_Click(sender, e)
    End Sub

    Public Event Title_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Title被双击时发生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("Title被双击时发生"), Browsable(True)> _
    Private Sub Label_Title_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_Title.DoubleClick
        RaiseEvent Title_DoubleClick(sender, e)
    End Sub


    Public Event Title_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Title被点击时发生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("Title被点击时发生"), Browsable(True)> _
    Private Sub Label_Title_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_Title.Click
        RaiseEvent Title_Click(sender, e)
    End Sub
#End Region

#Region "Key"
    Shadows Event KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    ''' <summary>
    ''' 在控件有焦点的情况下按下键时发生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("在控件有焦点的情况下按下键时发生"), Browsable(True)> _
    Private Sub TB_Value_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Value.KeyPress
        RaiseEvent KeyPress(sender, e)
    End Sub


    Shadows Event KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' 在控件有焦点的情况下按下键时发生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("在控件有焦点的情况下按下键时发生"), Browsable(True)> _
    Private Sub TB_Value_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_Value.KeyDown
        RaiseEvent KeyDown(sender, e)
    End Sub


    Shadows Event KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' 在控件有焦点的情况下释放键时发生
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("在控件有焦点的情况下释放键时发生"), Browsable(True)> _
    Private Sub TB_Value_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_Value.KeyUp
        RaiseEvent KeyUp(sender, e)
    End Sub

#End Region


    Shadows Event TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Text发生改变时
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("Text发生改变时"), Browsable(True)> _
    Private Sub TB_Value_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Value.TextChanged
        RaiseEvent TextChanged(sender, e)
    End Sub
#End Region

#Region "变量和属性"

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
            Label1.Text = value
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






    Private _Format As String = ""
    ''' <summary>
    ''' 格式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("格式"), Browsable(True)> _
    Public Property FormatStr() As String
        Get
            Return _Format
        End Get
        Set(ByVal value As String)
            _Format = value
        End Set
    End Property




    Private Sub TitleLabel_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        Me.Font_Text = New Font(Me.Font, Me.Font_Text.Style)
        Label_Title_Resize(Me, New EventArgs)
    End Sub




#End Region

    ''' <summary>
    ''' 设置Text会自动format
    ''' </summary>
    ''' <param name="Text"></param>
    ''' <remarks></remarks>
    Public Sub SetText(ByVal Text As String)
        If FormatStr = "" Then
            Me.Text = Text
        Else
            Me.Text = Format(Text, Me.FormatStr)
        End If
    End Sub


#Region "调整大小的问题"


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
    End Sub

#End Region



End Class
