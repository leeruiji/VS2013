Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Windows.Forms
Imports System.Drawing

<ToolboxBitmap(GetType(MonthCalendar))> _
<DefaultProperty("Value")> _
<ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip Or ToolStripItemDesignerAvailability.MenuStrip Or ToolStripItemDesignerAvailability.StatusStrip Or ToolStripItemDesignerAvailability.ToolStrip)> _
Public Class ToolStripMonthPicker
    Inherits ToolStripControlHost



    Public Sub New()
        MyBase.New(New MonthPicker() With {.AutoFixSize = False, .Format = "yyyy年MM月", .Width = 110, .BorderStyle = BorderStyle.None})
        Me.AutoSize = False
        Me.Width = 110
    End Sub

#Region "属性"


    Overrides Property Text() As String
        Get
            Return MonthPickerControl.Text
        End Get
        Set(ByVal value As String)
            MonthPickerControl.Text = value
        End Set
    End Property


    ''' <summary>
    ''' 是否显示 月份 两个字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否显示 月份 两个字"), Browsable(True)> _
    Public Property IsShowTitle() As Boolean
        Get
            Return MonthPickerControl.IsShowTitle
        End Get
        Set(ByVal value As Boolean)
            MonthPickerControl.IsShowTitle = value
        End Set
    End Property




    ''' <summary>
    ''' 是否只读
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否只读"), Browsable(True)> _
    Public Property IsReadOnly() As String
        Get
            Return MonthPickerControl.IsReadOnly
        End Get
        Set(ByVal value As String)
            MonthPickerControl.IsReadOnly = value
        End Set
    End Property



    ''' <summary>
    ''' 显示日期的格式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示日期的格式"), Browsable(True)> _
    Public Property Format() As String
        Get
            Return MonthPickerControl.Format
        End Get
        Set(ByVal value As String)
            MonthPickerControl.Format = value
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
            Return MonthPickerControl.IsShow
        End Get
    End Property



    ''' <summary>
    ''' 直至在最前,可能会挡住输入法,如果设置False会导致失去输入焦点
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("直至在最前,可能会挡住输入法,如果设置False会导致失去输入焦点"), Browsable(True), Category("N8")> _
    Public Property TopMost() As Boolean
        Get
            Return MonthPickerControl.TopMost
        End Get
        Set(ByVal value As Boolean)
            MonthPickerControl.TopMost = value
        End Set
    End Property



    <Description("Tooptip优先显示在原控件的相对位置。"), Browsable(True), Category("N8")> _
    Public Property ShowDirection() As MonthPicker.Enum_ShowDirection
        Get
            Return MonthPickerControl.ShowDirection
        End Get
        Set(ByVal value As MonthPicker.Enum_ShowDirection)
            MonthPickerControl.ShowDirection = value
        End Set
    End Property

    <Description("Tooptip优先显示在原控件的相对距离。"), Browsable(True), Category("N8")> _
    Public Property ShowDistince() As Integer
        Get
            Return MonthPickerControl.ShowDistince
        End Get
        Set(ByVal value As Integer)
            MonthPickerControl.ShowDistince = value
        End Set
    End Property

    <Description("MonthPicker属性设置"), Browsable(True), Category("N8")> _
   Public ReadOnly Property MonthPickerControl() As MonthPicker
        Get
            Return CType(Control, MonthPicker)
        End Get
    End Property


    <Description("标题"), Browsable(True), Category("N8")> _
    Public Property Title() As String
        Get
            Return MonthPickerControl.Title
        End Get
        Set(ByVal value As String)
            MonthPickerControl.Title = value
        End Set
    End Property


    <Description("选择的日期"), Browsable(True), Category("N8")> _
    Public Property Value() As Date
        Get
            Return MonthPickerControl.Value
        End Get
        Set(ByVal value As Date)
            MonthPickerControl.Value = value.ToString("yyyy-MM-dd")
        End Set
    End Property
#End Region
   


    Protected Overrides Sub OnSubscribeControlEvents(ByVal control As System.Windows.Forms.Control)
        MyBase.OnSubscribeControlEvents(control)
        Dim MonthPickerControl As MonthPicker = CType(control, MonthPicker)
        AddHandler MonthPickerControl.ValueChange, AddressOf ValueChangedHandler
    End Sub

    Protected Overrides Sub OnUnsubscribeControlEvents(ByVal control As System.Windows.Forms.Control)
        MyBase.OnUnsubscribeControlEvents(control)
        Dim MonthPickerControl As MonthPicker = CType(control, MonthPicker)
        RemoveHandler MonthPickerControl.ValueChange, AddressOf ValueChangedHandler
    End Sub

    <Description("月份选择")> _
    Public Event ValueChange(ByVal Value As Date)

    Private Sub ValueChangedHandler(ByVal Value As Date)
        RaiseEvent ValueChange(Value)
    End Sub

End Class
