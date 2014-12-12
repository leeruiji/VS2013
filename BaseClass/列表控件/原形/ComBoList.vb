Imports System.ComponentModel
Imports System.Windows.Forms

<Drawing.ToolboxBitmap(GetType(ComboBox))> _
<DefaultProperty("IDValue")> _
Public Class ComBoList
    Inherits PClass.ComboBoxBase
    Implements ICol_Parent
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32


#Region "公开属性"
    Protected Child_Name As String = ""
    <EditorAttribute(GetType(ColListDialogEditor), GetType(Drawing.Design.UITypeEditor)), Localizable(True)> _
     Public Property Child() As String
        Get
            If Child_Name = "" Then
                Dim Types As Type() = Reflection.Assembly.GetAssembly(GetType(ComBoListCtrl)).GetTypes
                For Each oType As Type In Types
                    If oType.BaseType Is GetType(ComBoListCtrl) Then
                        Return oType.Name.ToString()
                    End If
                Next oType
            End If
            Return Child_Name
        End Get
        Set(ByVal value As String)
            Dim Types As Type() = Reflection.Assembly.GetAssembly(GetType(ComBoListCtrl)).GetTypes
            For Each oType As Type In Types
                If oType.BaseType Is GetType(ComBoListCtrl) And value = oType.Name.ToString() Then
                    Child_Name = value
                    If Me.DesignMode = False Then
                        Me.DrawComBoBox()
                        TryCast(Me.m_Child, ComBoListCtrl).Col_Parent = Me
                    End If
                    Exit Property
                End If
            Next oType
            MsgBox("没有找到控件界面[" & value & "]", MsgBoxStyle.Exclamation, "请选择正确控件界面")
        End Set
    End Property


    Private _IsSelectName As Boolean = True
    ''' <summary>
    ''' 选择的是名字还是编号
    ''' </summary>
    ''' <remarks></remarks>
    <Description("选择的是名字还是编号"), Browsable(True), Category("N8"), DefaultValue(True)> _
    Public Property IsSelectName() As Boolean Implements ICol_Parent.IsSelectName
        Get
            Return _IsSelectName
        End Get
        Set(ByVal value As Boolean)
            _IsSelectName = value
        End Set
    End Property

    ''' <summary>
    ''' 是否已经下拉了
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否已经下拉了"), Browsable(False)> _
    Public ReadOnly Property IsDropDowned() As Boolean Implements ICol_Parent.IsDropDown
        Get
            Return Me.IsDropDown
        End Get
    End Property

    Private _IsKeyDownAutoSearch As Boolean = True
    ''' <summary>
    ''' 是否当有按键事件时候自动搜索
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否当有按键事件时候自动搜索"), Browsable(True), Category("N8")> _
    Public Property IsKeyDownAutoSearch() As Boolean
        Get
            Return _IsKeyDownAutoSearch
        End Get
        Set(ByVal value As Boolean)
            _IsKeyDownAutoSearch = value
        End Set
    End Property

    ''' <summary>
    ''' 控件Text
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("控件Text"), Browsable(False)> _
      Private ReadOnly Property ShowId() As String Implements ICol_Parent.ShowValue
        Get
            Return Me.Text
        End Get
    End Property

    ''' <summary>
    ''' 已经选择的ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("已经选择的ID"), Browsable(False)> _
    Public ReadOnly Property ShowID1() As String Implements ICol_Parent.ShowID
        Get
            Return Me.IDValue
        End Get
    End Property


#Region "子控件的属性"

#Region "   按钮属性"
    Private _IsShowAdd As Boolean = False
    ''' <summary>
    ''' 显示新增按钮
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示新增按钮"), Browsable(True), Category("N8"), DefaultValue(False)> _
    Public Property IsShowAdd() As Boolean Implements ICol_Parent.IsShowAdd
        Get
            Return _IsShowAdd
        End Get
        Set(ByVal value As Boolean)
            _IsShowAdd = value
            If m_Child IsNot Nothing Then
                'If TryCast(m_Child, ComBoListCtrl).IsShowAdd <> value Then
                TryCast(m_Child, ComBoListCtrl).IsShowAdd = value
                'End If
            End If
        End Set
    End Property

    Private _IsShowModify As Boolean = False
    ''' <summary>
    ''' 显示修改按钮
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("显示修改按钮"), Browsable(True), Category("N8"), DefaultValue(False)> _
    Public Property IsShowModify() As Boolean Implements ICol_Parent.IsShowModify
        Get
            Return _IsShowModify
        End Get
        Set(ByVal value As Boolean)
            _IsShowModify = value
            If m_Child IsNot Nothing Then
                ' If TryCast(m_Child, ComBoListCtrl).IsShowModify <> value Then
                TryCast(m_Child, ComBoListCtrl).IsShowModify = value
                'End If
            End If
        End Set
    End Property


#End Region

    Private _IsShowAll As Boolean = True
    ''' <summary>
    ''' 是否没有输入字符串时候,显示初始列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否没有输入字符串时候,显示初始列表"), Browsable(True), Category("N8"), DefaultValue(True)> _
    Public Property IsShowAll() As Boolean Implements ICol_Parent.IsShowAll
        Get
            Return _IsShowAll
        End Get
        Set(ByVal value As Boolean)
            _IsShowAll = value
            If m_Child IsNot Nothing Then
                'If TryCast(m_Child, ComBoListCtrl).IsShowAll <> value Then
                TryCast(m_Child, ComBoListCtrl).IsShowAll = value
                'End If
            End If
        End Set
    End Property



    Private _IsTBLostFocusSelOne As Boolean = False
    ''' <summary>
    ''' 是否可清空
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否可清空"), Browsable(True), Category("N8"), DefaultValue(False)> _
    Public Property IsTBLostFocusSelOne() As Boolean Implements ICol_Parent.IsTBLostFocusSelOne
        Get
            Return _IsTBLostFocusSelOne
        End Get
        Set(ByVal value As Boolean)
            _IsTBLostFocusSelOne = value
            If m_Child IsNot Nothing Then
                'If TryCast(m_Child, ComBoListCtrl).IsTBLostFocusSelOne <> value Then
                TryCast(m_Child, ComBoListCtrl).IsTBLostFocusSelOne = value
                'End If
            End If
        End Set
    End Property

    Private _SearchID As String = ""
    ''' <summary>
    ''' 搜索ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("搜索ID"), Browsable(True), Category("N8"), DefaultValue("")> _
    Public Property SearchID() As String Implements ICol_Parent.SearchID
        Get
            Return _SearchID
        End Get
        Set(ByVal value As String)
            _SearchID = value
            If m_Child IsNot Nothing Then
                'If TryCast(m_Child, ComBoListCtrl).SearchID <> value Then
                TryCast(m_Child, ComBoListCtrl).SearchID = value
                'End If
            End If
        End Set
    End Property

    Private _SearchBZID As String = ""
    ''' <summary>
    ''' 搜索ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("搜索ID"), Browsable(True), Category("N8"), DefaultValue("")> _
    Public Property SearchBZID() As String Implements ICol_Parent.SearchBZID
        Get
            Return _SearchBZID
        End Get
        Set(ByVal value As String)
            _SearchBZID = value
            If m_Child IsNot Nothing Then
                'If TryCast(m_Child, ComBoListCtrl).SearchID <> value Then
                TryCast(m_Child, ComBoListCtrl).SearchBZID = value
                'End If
            End If
        End Set
    End Property

    Private _SearchType As cSearchType.ENum_SearchType = cSearchType.ENum_SearchType.ALL
    ''' <summary>
    ''' 搜索类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("搜索类型"), Browsable(True), Category("N8"), DefaultValue(0)> _
    Public Property SearchType() As cSearchType.ENum_SearchType Implements ICol_Parent.SearchType
        Get
            Return _SearchType
        End Get
        Set(ByVal value As cSearchType.ENum_SearchType)
            _SearchType = value
            If m_Child IsNot Nothing Then
                'If TryCast(m_Child, ComBoListCtrl).SearchType <> value Then
                TryCast(m_Child, ComBoListCtrl).SearchType = value
                'End If
            End If
        End Set
    End Property

    Private _NameValue As String = ""

    ''' <summary>
    ''' 被选择的名字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("被选择的名字"), Browsable(False), DefaultValue("")> _
    Public ReadOnly Property NameValue() As String
        Get
            Return _NameValue
        End Get
    End Property

    Private _NoValue As String = ""
    ''' <summary>
    ''' 被选择的
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("被选择的No"), Browsable(False), DefaultValue("")> _
    Public ReadOnly Property NoValue() As String
        Get
            Return _NoValue
        End Get
    End Property

    ''' <summary>
    ''' Int型IDValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Long型IDValue"), Browsable(False)> _
    Public Property IDAsInt() As Long
        Get

            Try

                Return Long.Parse(_IDValue)
            Catch ex As Exception
                Return 0
            End Try
        End Get
        Set(ByVal value As Long)
            _IDValue = value
        End Set
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
    Public Event Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Implements ICol_Parent.Col_Sel
    ''' <summary>
    ''' 被选择行的事件
    ''' </summary>
    ''' <param name="Dr"></param>
    ''' <remarks></remarks>
    <Description("被选择行的事件"), Browsable(True)> _
    Public Event Col_SelRow(ByVal Dr As System.Data.DataRow) Implements ICol_Parent.Col_SelRow

    ''' <summary>
    ''' 开始搜索
    ''' </summary>
    ''' <param name="Col_No"></param>
    ''' <param name="ID"></param>
    ''' <param name="Cancel"></param>
    ''' <remarks></remarks>
    <Description("开始搜索"), Browsable(True)> _
    Public Event GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Implements ICol_Parent.GetSearchEvent

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
    Public Sub Col_SelOne() Implements ICol_Parent.Col_SelOne
        If m_Child IsNot Nothing Then
            TryCast(Me.m_Child, ComBoListCtrl).Col_SelOne()
        End If
    End Sub

    ''' <summary>
    ''' 根据ID输出名字
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetByTextBoxTag(Optional ByVal ID As String = "") As String Implements ICol_Parent.GetByTextBoxTag
        If m_Child IsNot Nothing Then
            Dim s As String = ""
            If ID = "" Then
                ID = _IDValue
            End If
            Dim Dr As DataRow = TryCast(Me.m_Child, ComBoListCtrl).GetIDToDataRow(ID)
            If Dr IsNot Nothing Then
                If ID = _IDValue Then
                    _NameValue = Dr(TryCast(Me.m_Child, ComBoListCtrl).Get_Col_Name_Field)
                    _NoValue = Dr(TryCast(Me.m_Child, ComBoListCtrl).Get_Col_No_Field)
                End If
                If IsSelectName Then
                    Return Dr(TryCast(Me.m_Child, ComBoListCtrl).Get_Col_Name_Field)
                Else
                    Return Dr(TryCast(Me.m_Child, ComBoListCtrl).Get_Col_No_Field)
                End If
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function


    ''' <summary>
    ''' 根据ID输出DataRow
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIDToDataRow(Optional ByVal ID As String = "") As System.Data.DataRow Implements ICol_Parent.GetIDToDataRow
        If m_Child IsNot Nothing Then
            Return TryCast(Me.m_Child, ComBoListCtrl).GetIDToDataRow(ID)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 开始 搜索,并刷新
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartSearch() Implements ICol_Parent.StartSearch
        If m_Child IsNot Nothing Then
            TryCast(m_Child, ComBoListCtrl).StartSearch()
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetSearchEmpty() Implements ICol_Parent.SetSearchEmpty
        Me._IDValue = ""
        Me.Text = ""
        Me._NameValue = ""
        Me._NoValue = ""
        Try

            TryCast(m_Child, ComBoListCtrl).SetLastDtEmpty()

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "私有函数"

    Private Sub Close1() Implements ICol_Parent.Close
        Me.Close()
    End Sub


    ''' <summary>
    ''' 显示下拉列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowDropDown1() Implements ICol_Parent.ShowDropDown
        Me.ShowDropDown()
    End Sub


    Private Sub RE_Col_SelRow(ByVal Row As System.Data.DataRow) Implements ICol_Parent.RE_Col_SelRow
        RaiseEvent Col_SelRow(Row)
    End Sub


    Private Sub RE_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Implements ICol_Parent.RE_Col_Sel
        _NoValue = Col_No
        _NameValue = Col_Name
        If _IsSelectName Then
            Me.Text = Col_Name
            Me._IDValue = ID
        Else

            Me.Text = Col_No
            Me._IDValue = ID
        End If
        RaiseEvent Col_Sel(Col_No, Col_Name, ID)
        Me.SelectAll()
    End Sub

    Private Sub RE_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Implements ICol_Parent.RE_GetSearchEvent
        Col_No = Me.Text
        ID = Me._IDValue
        RaiseEvent GetSearchEvent(Col_No, ID, Cancel)
    End Sub




#End Region

#Region "重写父类的函数"

    Protected Overrides Function GetNewChild() As System.Windows.Forms.Control
        Dim Ass As Reflection.Assembly = Reflection.Assembly.GetAssembly(GetType(ComBoListCtrl))
        If Child <> "" Then
            Dim Cmt As Type = Ass.GetType(Ass.GetName.Name & "." & Child)
            If Cmt Is Nothing Then
                Return New ComBoListCtrl
            Else
                Return System.Activator.CreateInstance(Cmt)
            End If
        End If
        Return New ComBoListCtrl
    End Function


    Protected Overrides Sub WndProc(ByRef m As Windows.Forms.Message)
        If m.Msg = 522 Then '滚轮事件
            If m_Child IsNot Nothing Then
                Try
                    SendMessage(TryCast(m_Child, ComBoListCtrl).GetFGHandle, 522, m.WParam, m.LParam)
                Catch ex As Exception
                    MyBase.WndProc(m)
                End Try
            End If
            Return
        End If
        MyBase.WndProc(m)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Down OrElse e.KeyCode = Windows.Forms.Keys.Up Then
            If m_Child IsNot Nothing Then
                Try
                    If Me.IsDropDown = False Then
                        Me.StartSearch()
                    End If
                    TryCast(m_Child, ComBoListCtrl).FG_KeyDown(e.KeyCode)
                Catch ex As Exception
                    MyBase.OnKeyDown(e)
                End Try
            End If
            Return
        ElseIf e.KeyCode = Windows.Forms.Keys.Enter Then
            Try
                If Me.IsDropDown Then
                    TryCast(m_Child, ComBoListCtrl).Fg1_ClickRow(Me, New System.EventArgs)
                End If
            Catch ex As Exception
                MyBase.OnKeyDown(e)
            End Try
            Return
        End If
        MyBase.OnKeyDown(e)
    End Sub

#End Region

#Region "事件实现"

    Private Sub ComBoList_DropDownClosed() Handles Me.DropDownClosed
        If Me.Text = "" AndAlso Val(IDValue) <> 0 Then
            If _IsTBLostFocusSelOne = False Then
                _IDValue = ""
                _NoValue = ""
                _NameValue = ""
            End If
            RaiseEvent SetEmpty()
        End If
    End Sub
    Private Sub ComBoList_MeLostLostFocus() Handles Me.MeLostFocus
        If Me.Text <> "" OrElse _IsTBLostFocusSelOne Then
            Me.Col_SelOne()
        End If
    End Sub
    Private Sub ComBoList_DropDowning(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.BeforeDropDown
        If m_Child IsNot Nothing Then
            If (IsSelectName AndAlso NameValue = Text) OrElse (IsSelectName = False AndAlso NoValue = Text) Then
                TryCast(m_Child, ComBoListCtrl).IsSelectAll = True
            End If
        End If
        StartSearch()
    End Sub


    Private Sub ComBoList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = vbCr Then
            Me.Col_SelOne()
        ElseIf _IsKeyDownAutoSearch Then
            StartSearch()
        End If
    End Sub


    Private Sub ComBoList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode >= Keys.F2 AndAlso e.KeyCode <= Keys.F12 Then
            TryCast(m_Child, ComBoListCtrl).QuickKey(e.KeyCode)
        End If
    End Sub
#End Region












End Class
