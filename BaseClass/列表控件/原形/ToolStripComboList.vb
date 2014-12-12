Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<ToolboxBitmap(GetType(ComboBox))> _
<DefaultProperty("IDValue")> _
<ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip Or ToolStripItemDesignerAvailability.MenuStrip Or ToolStripItemDesignerAvailability.StatusStrip Or ToolStripItemDesignerAvailability.ToolStrip)> _
Public Class ToolStripComboList
    Inherits ToolStripControlHost
    Public Sub New()
        MyBase.New(New ComBoList() With {.Width = 100})
        Me.Text = ""
        AddHandler Me.ComBoList.Col_Sel, AddressOf RE_Col_Sel
        AddHandler Me.ComBoList.GetSearchEvent, AddressOf RE_GetSearchEvent
        AddHandler Me.ComBoList.Col_SelRow, AddressOf RE_Col_SelRow
        AddHandler Me.ComBoList.SetEmpty, AddressOf RE_SetEmpty
    End Sub

    <Description("ComBoList属性设置"), Browsable(False), Category("N8")> _
    Public ReadOnly Property ComBoList() As ComBoList
        Get
            Return CType(Control, ComBoList)
        End Get
    End Property




#Region "公开属性"
    ''' <summary>
    ''' ID值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("ID值"), Browsable(False), Category("N8"), DefaultValue("")> _
    Public Property IDValue()
        Get
            Return ComBoList.IDValue
        End Get
        Set(ByVal value)
            ComBoList.IDValue = value
        End Set
    End Property

    ''' <summary>
    ''' Int型IDValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Int型IDValue"), Browsable(False)> _
    Public Property IDAsInt() As Integer
        Get
            Return Val(ComBoList.IDAsInt)
        End Get
        Set(ByVal value As Integer)
            ComBoList.IDAsInt = value
        End Set
    End Property


    ''' <summary>
    ''' 本控件下拉的时候显示 子控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("本控件下拉的时候显示 子控件"), EditorAttribute(GetType(ColListDialogEditor), GetType(Drawing.Design.UITypeEditor)), Localizable(True)> _
     Public Property Child() As String
        Get
            Return ComBoList.Child
        End Get
        Set(ByVal value As String)
            ComBoList.Child = value
        End Set
    End Property



    ''' <summary>
    ''' 选择的是名字还是编号
    ''' </summary>
    ''' <remarks></remarks>
    <Description("选择的是名字还是编号"), Browsable(True), Category("N8"), DefaultValue(True)> _
    Public Property IsSelectName() As Boolean
        Get
            Return ComBoList.IsSelectName
        End Get
        Set(ByVal value As Boolean)
            ComBoList.IsSelectName = value
        End Set
    End Property

    ''' <summary>
    ''' 是否已经下拉了
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsDropDowned() As Boolean
        Get
            Return Me.ComBoList.IsDropDown
        End Get
    End Property


    ''' <summary>
    ''' 是否当有按键事件时候自动搜索
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否当有按键事件时候自动搜索"), Browsable(True), Category("N8")> _
    Public Property IsKeyDownAutoSearch() As Boolean
        Get
            Return ComBoList.IsKeyDownAutoSearch
        End Get
        Set(ByVal value As Boolean)
            ComBoList.IsKeyDownAutoSearch = value
        End Set
    End Property

#Region "子控件的属性"

#Region "   按钮属性"

    ''' <summary>
    ''' 显示新增按钮
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示新增按钮"), Browsable(True), Category("N8"), DefaultValue(False)> _
    Public Property IsShowAdd() As Boolean
        Get
            Return ComBoList.IsShowAdd
        End Get
        Set(ByVal value As Boolean)
            ComBoList.IsShowAdd = value
        End Set
    End Property


    ''' <summary>
    ''' 显示修改按钮
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示修改按钮"), Browsable(True), Category("N8"), DefaultValue(False)> _
    Public Property IsShowModify() As Boolean
        Get
            Return ComBoList.IsShowModify
        End Get
        Set(ByVal value As Boolean)
            ComBoList.IsShowModify = value
        End Set
    End Property



#End Region


    ''' <summary>
    ''' 是否没有输入字符串时候,显示初始列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否没有输入字符串时候,显示初始列表"), Browsable(True), Category("N8"), DefaultValue(True)> _
    Public Property IsShowAll() As Boolean
        Get
            Return ComBoList.IsShowAll
        End Get
        Set(ByVal value As Boolean)
            ComBoList.IsShowAll = value
        End Set
    End Property




    ''' <summary>
    ''' 是否可清空
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否可清空"), Browsable(True), Category("N8"), DefaultValue(False)> _
    Public Property IsTBLostFocusSelOne() As Boolean
        Get
            Return ComBoList.IsTBLostFocusSelOne
        End Get
        Set(ByVal value As Boolean)
            ComBoList.IsTBLostFocusSelOne = value
        End Set
    End Property

    ''' <summary>
    ''' 搜索ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("搜索ID"), Browsable(True), Category("N8"), DefaultValue("")> _
    Public Property SearchID() As String
        Get
            Return ComBoList.SearchID
        End Get
        Set(ByVal value As String)
            ComBoList.SearchID = value
        End Set
    End Property

    ''' <summary>
    ''' 搜索类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("搜索类型"), Browsable(True), Category("N8"), DefaultValue(0)> _
    Public Property SearchType() As cSearchType.ENum_SearchType
        Get
            Return ComBoList.SearchType
        End Get
        Set(ByVal value As cSearchType.ENum_SearchType)
            ComBoList.SearchType = value
        End Set
    End Property



    ''' <summary>
    ''' 被选择的名字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("被选择的名字"), Browsable(False), DefaultValue("")> _
    Public ReadOnly Property NameValue() As String
        Get
            Return ComBoList.NameValue
        End Get
    End Property


    ''' <summary>
    ''' 被选择的
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("被选择的No"), Browsable(False), DefaultValue("")> _
    Public ReadOnly Property NoValue() As String
        Get
            Return ComBoList.NoValue
        End Get
    End Property


#End Region
#End Region


#Region "公开事件"
    ''' <summary>
    ''' 被选择的事件
    ''' </summary>
    ''' <param name="Col_No"></param>
    ''' <param name="Col_Name"></param>
    ''' <param name="ID"></param>
    ''' <remarks></remarks>
    <Description("被选择的事件"), Browsable(True)> _
    Public Event Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
    ''' <summary>
    ''' 被选择行的事件
    ''' </summary>
    ''' <param name="Dr"></param>
    ''' <remarks></remarks>
    <Description("被选择行的事件"), Browsable(True)> _
    Public Event Col_SelRow(ByVal Dr As System.Data.DataRow)

    ''' <summary>
    ''' 开始搜索
    ''' </summary>
    ''' <param name="Col_No"></param>
    ''' <param name="ID"></param>
    ''' <param name="Cancel"></param>
    ''' <remarks></remarks>
    <Description("开始搜索"), Browsable(True)> _
    Public Event GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)

    ''' <summary>
    ''' 关闭下来列表时候 并且 清空搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    <Description("关闭下来列表时候并且清空搜索条件"), Browsable(True)> _
    Public Event SetEmpty()
#End Region


#Region "公开函数"

    ''' <summary>
    ''' 选择第一个
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Col_SelOne()
        ComBoList.Col_SelOne()
    End Sub

    ''' <summary>
    ''' 根据ID输出名字
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetByTextBoxTag(Optional ByVal ID As String = "") As String
        Return ComBoList.GetByTextBoxTag(ID)
    End Function


    ''' <summary>
    ''' 根据ID输出DataRow
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIDToDataRow(Optional ByVal ID As String = "") As System.Data.DataRow
        Return ComBoList.GetIDToDataRow(ID)
    End Function

    ''' <summary>
    ''' 开始 搜索,并刷新
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartSearch()
        ComBoList.StartSearch()
    End Sub

    ''' <summary>
    ''' 置空所有值
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetSearchEmpty()
        ComBoList.SetSearchEmpty()
    End Sub


   
#End Region

#Region "事件实现"

    Sub RE_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String)
        RaiseEvent Col_Sel(NoValue, Col_Name, ID)
    End Sub
    Sub RE_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)
        RaiseEvent GetSearchEvent(Col_No, ID, Cancel)
    End Sub
    Sub RE_Col_SelRow(ByVal Row As DataRow)
        RaiseEvent Col_SelRow(Row)
    End Sub
    Sub RE_SetEmpty()
        RaiseEvent SetEmpty()
    End Sub
#End Region
End Class
