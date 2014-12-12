Imports System.Windows.Forms
Imports System.ComponentModel

<Drawing.ToolboxBitmap(GetType(ToolStrip))> _
Public Class ToolStripSearch
    Protected Friend WithEvents Menu_Search As New System.Windows.Forms.ContextMenuStrip

    Protected Friend WithEvents Menu_LoadSearch As New System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents Menu_DelSearch As New System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents Menu_SaveSearch As New System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents Menu_SaveAsSearch As New System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents Menu_SetDefalut As New System.Windows.Forms.ToolStripMenuItem

    Protected Friend WithEvents Menu_ClearSearchValue As New System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents Menu_RemoveAllSearch As New System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents Menu_AddSearch As New System.Windows.Forms.ToolStripMenuItem

    Protected Friend WithEvents Menu_ShowSearchForm As New System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents Menu_ShowSearchForm2 As New System.Windows.Forms.ToolStripMenuItem
    Sub New()
        MyBase.New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Menu_Search.SuspendLayout()
        Menu_Ini()
        If _ToolStrip IsNot Nothing AndAlso _ToolStrip.ContextMenuStrip IsNot Nothing AndAlso Me.DesignMode = False Then
            _ToolStrip.ContextMenuStrip.Items.Add("-")
            AddSaveMenu(_ToolStrip.ContextMenuStrip.Items)
        Else
            AddSaveMenu(Me.Menu_Search.Items)
        End If





        ReSetToolStripStyle()
        Me.Menu_Search.ResumeLayout(False)
    End Sub

    Protected Sub Menu_Ini()
        Menu_Search.ImageScalingSize = New Drawing.Size(18, 18)
        Me.Menu_Search.Name = "Menu_Search"
        Me.Menu_Search.Size = New System.Drawing.Size(155, 26)
        '
        'Menu_LoadSearch
        '
        Me.Menu_LoadSearch.Name = "Menu_LoadSearch"
        Me.Menu_LoadSearch.Size = New System.Drawing.Size(154, 22)
        Me.Menu_LoadSearch.Text = "加载搜索方案"
        Me.Menu_LoadSearch.Image = My.Resources.export
        Me.Menu_LoadSearch.Tag = ""
        '
        'Menu_DelSearch
        '
        Me.Menu_DelSearch.Name = "Menu_DelSearch"
        Me.Menu_DelSearch.Size = New System.Drawing.Size(154, 22)
        Me.Menu_DelSearch.Text = "删除搜索方案"
        Me.Menu_DelSearch.Image = My.Resources.remove
        '
        'Menu_SaveSearch
        '
        Me.Menu_SaveSearch.Name = "Menu_SaveSearch"
        Me.Menu_SaveSearch.Size = New System.Drawing.Size(154, 22)
        Me.Menu_SaveSearch.Text = "保存搜索方案"
        Me.Menu_SaveSearch.Image = My.Resources.save
        '
        'Menu_SaveAsSearch
        '
        Me.Menu_SaveAsSearch.Name = "Menu_SaveAsSearch"
        Me.Menu_SaveAsSearch.Size = New System.Drawing.Size(154, 22)
        Me.Menu_SaveAsSearch.Text = "搜索方案另存为"
        Me.Menu_SaveAsSearch.Image = My.Resources.save_as2
        '
        'Menu_SetDefalut
        '
        Me.Menu_SetDefalut.Name = "Menu_SetDefalut"
        Me.Menu_SetDefalut.Size = New System.Drawing.Size(154, 22)
        Me.Menu_SetDefalut.Text = "当前方案设置默认"
        Me.Menu_SetDefalut.Image = My.Resources.favorits
        '
        'Menu_ClearSearchValue
        '
        Me.Menu_ClearSearchValue.Name = "Menu_ClearSearchValue"
        Me.Menu_ClearSearchValue.Size = New System.Drawing.Size(154, 22)
        Me.Menu_ClearSearchValue.Text = "清空所有搜索值"
        Me.Menu_ClearSearchValue.Image = My.Resources.trash
        '
        'Menu_DeleteAllSearch
        '
        Me.Menu_RemoveAllSearch.Name = "Menu_RemoveAllSearch"
        Me.Menu_RemoveAllSearch.Size = New System.Drawing.Size(154, 22)
        Me.Menu_RemoveAllSearch.Text = "删除所有搜索"
        Me.Menu_RemoveAllSearch.Image = My.Resources.remove
        '
        'Menu_AddSearch
        '
        Me.Menu_AddSearch.Name = "Menu_AddSearch"
        Me.Menu_AddSearch.Size = New System.Drawing.Size(154, 22)
        Me.Menu_AddSearch.Text = "添加搜索条件"
        Me.Menu_AddSearch.Image = My.Resources.ADD
        '
        'Menu_AddSearch
        '
        Me.Menu_ShowSearchForm.Name = "Menu_ShowSearchForm"
        Me.Menu_ShowSearchForm.Size = New System.Drawing.Size(154, 22)
        Me.Menu_ShowSearchForm.Text = "显示搜索窗口"
        Me.Menu_ShowSearchForm.Image = My.Resources.search
        '
        'Menu_AddSearch
        '
        Me.Menu_ShowSearchForm2.Name = "Menu_ShowSearchForm"
        Me.Menu_ShowSearchForm2.Size = New System.Drawing.Size(154, 22)
        Me.Menu_ShowSearchForm2.Text = "高级搜索"
        Me.Menu_ShowSearchForm2.Image = My.Resources._5
        Me.Menu_ShowSearchForm2.MergeIndex = 8

    End Sub



#Region "显示SearchForm"
    Dim SBF As PClass.BaseForm
    ''' <summary>
    ''' 显示搜索窗口
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowSearchForm()
        Dim Cancel As Boolean
        RaiseEvent BeforeShowSearchForm(Cancel)
        If Cancel = True Then Exit Sub

        Dim P As New Dictionary(Of String, Object)
        SBF = GetMeBaseForm()
        If SBF Is Nothing Then
            ShowToWinForm()
        Else
            If SBF.VForm Is Nothing Then
                ShowToWinForm()
            Else
                SBF.Update()
                SBF.VForm.ShowShadow()
                SBF.Shadow_Form = New SearchForm(Me, SBF.Title & "筛选", AddressOf ResultReturn, AddressOf HideShadow)
                SBF.Shadow_Form.Active()
            End If
        End If
    End Sub

    Sub HideShadow()
        SBF.HideShadow()
    End Sub


    ''' <summary>
    ''' 用winform的方法显示窗口
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowToWinForm()

    End Sub

    Sub DoNothing()
    End Sub

    ''' <summary>
    ''' 搜索返回
    ''' </summary>
    ''' <remarks></remarks>
    Sub ResultReturn(ByVal Result As MsgBoxResult)
        RaiseEvent AfterShowSearchForm(True)
        If Result = MsgBoxResult.Ok Then
            RaiseEvent StartSearch(Me, Nothing)
        End If
    End Sub

    Public Event BeforeShowSearchForm(ByRef Cancel As Boolean)
    Public Event AfterShowSearchForm(ByRef IsChange As Boolean)
#End Region



#Region "属性和变量"
    Protected Friend _HideItemOnToolStrip As Boolean = False

    ''' <summary>
    ''' 隐藏ToolStrip上自动添加的Item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("隐藏ToolStrip上自动添加的Item"), Browsable(True), Category("N8")> _
    Public Property HideItemOnToolStrip() As Boolean
        Get
            Return _HideItemOnToolStrip
        End Get
        Set(ByVal value As Boolean)
            _HideItemOnToolStrip = value
            If _SearchItem IsNot Nothing Then
                For Each K As KeyValuePair(Of String, SearchItem) In _SearchItem
                    K.Value.Visible = _HideItemOnToolStrip
                Next
            End If
        End Set
    End Property


    ''' <summary>
    ''' 要绑定ToolStrip
    ''' </summary>
    ''' <remarks></remarks>
    Private _ToolStrip As ToolStrip

    ''' <summary>
    ''' 要绑定ToolStrip
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("要绑定ToolStrip"), Browsable(True), Category("N8")> _
    Public Property ToolStrip() As ToolStrip
        Get
            Return _ToolStrip
        End Get
        Set(ByVal value As ToolStrip)
            If Me.DesignMode Then
                _ToolStrip = value
            Else
                If _ToolStrip IsNot Nothing AndAlso Object.ReferenceEquals(_ToolStrip.ContextMenuStrip, Menu_Search) Then
                    _ToolStrip.Items.Remove(Menu_LoadSearch)
                    _ToolStrip.Items.Remove(Menu_DelSearch)
                    _ToolStrip.Items.Remove(Menu_SaveSearch)
                    _ToolStrip.Items.Remove(Menu_SaveAsSearch)
                    _ToolStrip.Items.Remove(Menu_SetDefalut)
                    _ToolStrip.Items.Remove(Menu_ClearSearchValue)
                    _ToolStrip.Items.Remove(Menu_RemoveAllSearch)
                    _ToolStrip.Items.Remove(Menu_AddSearch)
                End If
                _ToolStrip = value
                If _ToolStrip IsNot Nothing Then
                    If _ToolStrip.ContextMenuStrip Is Nothing Then
                        If Menu_Search.Items.Count = 0 Then
                            AddSaveMenu(Me.Menu_Search.Items)
                        End If
                        _ToolStrip.ContextMenuStrip = Menu_Search
                    Else
                        _ToolStrip.ContextMenuStrip.Items.Add("-")
                        AddSaveMenu(_ToolStrip.ContextMenuStrip.Items)
                    End If
                End If
                ReSetToolStripStyle()
            End If
        End Set
    End Property

    ''' <summary>
    ''' 是否忽略时间
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否忽略时间"), Browsable(False), Category("N8")> _
    Public ReadOnly Property IsIgnoreTime() As Boolean
        Get
            For i As Integer = 0 To Me.ToolStrip.Items.Count - 1
                If TypeOf (Me.ToolStrip.Items(i)) Is SearchItem Then
                    Dim C As SearchItem = TryCast(Me.ToolStrip.Items(i), SearchItem)
                    If C.SearchOK AndAlso C.IsIgnoreTime Then
                        Return True
                    End If
                End If
            Next
            Return False
        End Get
    End Property


    ''' <summary>
    ''' 如果是是条件名称Combobox点击时候获取数据,如果否条件值Combobox下拉时候才获取数据
    ''' </summary>
    ''' <remarks></remarks>
    Private _IsNameChangeToData As Boolean = False

    ''' <summary>
    ''' 如果是是条件名称Combobox点击时候获取数据,如果否条件值Combobox下拉时候才获取数据
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks> 
    <Description("如果是是条件名称Combobox点击时候获取数据,如果否条件值Combobox下拉时候才获取数据"), Browsable(True), Category("N8")> _
    Public Property IsNameChangeToData() As Boolean
        Get
            Return _IsNameChangeToData
        End Get
        Set(ByVal value As Boolean)
            _IsNameChangeToData = value
            For Each K As KeyValuePair(Of String, SearchItem) In _SearchItem
                K.Value.IsNameChangeToData = value
            Next
        End Set
    End Property


    Protected _IsAddSearchBottom As Boolean = True
    ''' <summary>
    ''' 是否在最后添加一个筛选按钮
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks> 
    <Description("是否在最后添加一个筛选按钮"), Browsable(True), Category("N8")> _
    Public Property IsAddSearchBottom() As Boolean
        Get
            Return _IsAddSearchBottom
        End Get
        Set(ByVal value As Boolean)
            _IsAddSearchBottom = value
        End Set
    End Property

    ''' <summary>
    ''' 条件控件集合的个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("条件控件集合的个数"), Browsable(False)> _
    Public ReadOnly Property SearchItems() As Dictionary(Of String, SearchItem)
        Get
            Return _SearchItem
        End Get
    End Property

    ''' <summary>
    ''' 条件控件集合的个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("条件控件集合的个数"), Browsable(False)> _
    Public ReadOnly Property SearchItemCount() As Integer
        Get
            Return _SearchItem.Count
        End Get
    End Property



    ''' <summary>
    ''' 最后一次或当前被修改搜索条件名称的ComboBox
    ''' </summary>
    ''' <remarks></remarks>
    Public CB_ConditionValue2 As ComboBox


    ''' <summary>
    ''' 最后一次或当前被修改搜索条件名称的ComboBox
    ''' </summary>
    ''' <remarks></remarks>
    Public CB_ConditionName2 As ComboBox

    ''' <summary>
    ''' 最后插入的条件的Index 不代表个数 Index不连续
    ''' </summary>
    ''' <remarks></remarks>
    Private LastInsertSearchItemIndex As Integer = 0

    ''' <summary>
    ''' 条件名称集合 请使用 List(Of FindOption)
    ''' </summary>
    ''' <remarks></remarks>
    Public ConditionName_DataSource As Object
    ''' <summary>
    ''' 条件名称Combox的显示字段
    ''' </summary>
    ''' <remarks></remarks>
    Public ConditionName_DisplayMember As String = "Field"
    ''' <summary>
    ''' 条件名称Combox的值字段
    ''' </summary>
    ''' <remarks></remarks>
    Public ConditionName_ValueMember As String = "DB_Field"

    ''' <summary>
    ''' 搜索条件控件集合
    ''' </summary>
    ''' <remarks></remarks>
    Private _SearchItem As New Dictionary(Of String, SearchItem)

    ''' <summary>
    ''' 条件菜单集合
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend MenuList As New List(Of ToolStripMenuItem)
#End Region


#Region "方法"
    ''' <summary>
    ''' 改变Combox ,Label,datatimepacker的 样式
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ReSetToolStripStyle()
        If _ToolStrip IsNot Nothing AndAlso _ToolStrip.LayoutStyle = ToolStripLayoutStyle.Flow Then
            _ToolStrip.SuspendLayout()
            For Each i As ToolStripItem In _ToolStrip.Items
                If TypeOf (i) Is ToolStripLabel Then
                    i.Padding = New Padding(i.Padding.Left, 4, i.Padding.Right, 5)
                ElseIf TypeOf (i) Is ToolStripDropDownButton Then
                    i.Padding = New Padding(i.Padding.Left, 3, i.Padding.Right, 2)
                ElseIf TypeOf (i) Is ToolStripComboBox Then
                    i.Margin = New Padding(i.Margin.Left, -2, i.Margin.Right, 0)
                    i.Padding = New Padding(i.Padding.Left, 0, i.Padding.Right, 7)
                ElseIf TypeOf (i) Is PClass.ToolStripDateTimePicker Then
                    i.Margin = New Padding(i.Margin.Left, 0, i.Margin.Right, 2)

                End If
            Next
            _ToolStrip.ResumeLayout()
        End If
    End Sub

    ''' <summary>
    ''' 设置 搜索条件名称的 数据源,请在Load时候调用
    ''' </summary>
    ''' <param name="DataSource"></param>
    ''' <param name="ValueMember"></param>
    ''' <param name="DisplayMember"></param>
    ''' <remarks></remarks>
    Public Sub SetConditionNameDataSource(ByVal DataSource As Object, Optional ByVal ValueMember As String = Nothing, Optional ByVal DisplayMember As String = Nothing)
        ConditionName_DataSource = DataSource
        ConditionName_ValueMember = ValueMember
        ConditionName_DisplayMember = DisplayMember
    End Sub

    ''' <summary>
    ''' 添加菜单
    ''' </summary>
    ''' <param name="M"></param>
    ''' <remarks></remarks>
    Protected Sub AddSaveMenu(ByVal M As ToolStripItemCollection)
        M.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_LoadSearch, Me.Menu_DelSearch, Me.Menu_SaveSearch, Me.Menu_SaveAsSearch, Me.Menu_SetDefalut})
        M.Add("-")
        M.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_ClearSearchValue, Me.Menu_RemoveAllSearch, Me.Menu_AddSearch})
        M.Add("-")
        M.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_ShowSearchForm})
    End Sub






#End Region

#Region "事件定义"
    ''' <summary>
    ''' 当搜索条件名称被点击的时候
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event CB_ConditionName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ''' <summary>
    ''' 启动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event StartSearch(ByVal sender As System.Object, ByVal e As System.EventArgs)


    ''' <summary>
    ''' 加载默认的时候,当默认方案没有被保存过,加载一组自定义的
    ''' </summary>
    ''' <remarks></remarks>
    Public Event LoadDefaultMenu(ByVal SettingList As List(Of SearchCol.SearchSetting))
#End Region

#Region "子控件事件"




#Region "   菜单事件    "

    Private Sub Menu_DelSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_DelSearch.Click
        Dim P As New Dictionary(Of String, Object)
        Dim BF As PClass.BaseForm = GetMeBaseForm()
        If BF Is Nothing Then Exit Sub
        Dim LName As String = Menu_LoadSearch.Tag
        BF.ShowConfirm("是否" & Menu_DelSearch.Text, AddressOf SearchItem_Del)
    End Sub


    ''' <summary>
    ''' 方案保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_SaveSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_SaveSearch.Click
        Dim LName As String = Menu_LoadSearch.Tag
        If LName = "" Then LName = "默认方案"
        SearchItem_Save(LName)
    End Sub

    ''' <summary>
    ''' 方案另存为
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_SaveAsSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_SaveAsSearch.Click
        Dim P As New Dictionary(Of String, Object)
        Dim BF As PClass.BaseForm = GetMeBaseForm()
        If BF Is Nothing Then Exit Sub
        Dim LName As String = Menu_LoadSearch.Tag
        Dim i As Integer = 0
        For Each M As ToolStripMenuItem In Menu_LoadSearch.DropDownItems
            M.Checked = False
            If M.Text.StartsWith("搜索方案") Then
                Dim j As Integer = PClass.PClass.Val(M.Text.Substring(4))
                If j > i Then
                    i = j
                End If
            End If
        Next
        i = i + 1
        LName = "搜索方案" & i
        BF.Update()
        BF.ShowInput("请输入一个搜索方案名称?", AddressOf SearchItem_Save, LName, "请输入搜索方案的名字")
    End Sub


    ''' <summary>
    ''' 设置默认值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_SetDefalut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_SetDefalut.Click
        SetDefalut()
    End Sub

    Protected Friend Sub SetDefalut()
        Dim ID As String = GetID()
        Dim LName As String = Menu_LoadSearch.Tag
        SearchItem_Save(LName)
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Name", LName)
        PClass.PClass.RunSQL("update SearchSettingList set IsDefault=0 where ID=@ID;update SearchSettingList set IsDefault=1 where ID=@ID and Name=@Name", P)
        LoadSearchMenu(LName, True)
    End Sub


    ''' <summary>
    ''' 加载搜索项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_LoadSearch_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Menu_LoadSearch.DropDownItemClicked
        LoadSearchItem(e.ClickedItem.Text)
    End Sub

    ''' <summary>
    ''' 添加搜索条件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_AddSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_AddSearch.Click
        SearchItem_Insert()
    End Sub

    ''' <summary>
    ''' 删除所有搜索条件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_RemoveAllSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_RemoveAllSearch.Click
        SearchItem_RemoveAll()
    End Sub

    ''' <summary>
    ''' 清空搜索条件的值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_ClearSearchValue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_ClearSearchValue.Click
        SearchItem_ClearValue()
    End Sub

    ''' <summary>
    ''' 显示searchform
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_ShowSearchForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_ShowSearchForm.Click, Menu_ShowSearchForm2.Click
        ShowSearchForm()
    End Sub

#End Region



#End Region


#Region "函数定义"
    Protected Friend Sub SearchItem_Del()
        Dim SQL As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        Dim ID As String = GetID()
        P.Add("ID", ID)
        P.Add("Name", Menu_LoadSearch.Tag)
        PClass.PClass.RunSQL("delete from SearchSettingList where id=@ID and Name=@Name;if ((select Count(*) from SearchSettingList where isDefault=1)=0)  update SearchSettingList set IsDefault =1 where ID=@ID and Name=(Select top 1 name from SearchSettingList  where id=@ID)", P)
        LoadSearchMenu()
    End Sub


    ''' <summary>
    ''' 获得ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetID() As String
        Dim BF As PClass.BaseForm = GetMeBaseForm()
        If BF Is Nothing Then
            Return BF.Name & "." & Me.ToolStrip.Name
        Else
            Return BF.ID & BF.Name & "." & Me.ToolStrip.Name
        End If
    End Function



    ''' <summary>
    ''' 获得Name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetName() As String
        Return Menu_LoadSearch.Tag
    End Function


    ''' <summary>
    ''' 保存搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub SearchItem_Save(ByVal Name As String)
        Dim SQL As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        Dim ID As String = GetID()
        P.Add("ID", ID)
        P.Add("Name", Name)
        SQL.Add("L", "select * from SearchSettingList where id=@ID and Name=@Name")
        SQL.Add("V", "select * from SearchSettingValue where id=@ID and Name=@Name")
        Using H As New PClass.PClass.DtHelper(SQL, P)
            If H.IsOk Then
                If H.DtList("L").Rows.Count = 0 Then
                    Dim Dr As DataRow = H.DtList("L").NewRow
                    Dr("ID") = ID
                    Dr("Name") = Name
                    Dr("IsDefault") = False
                    H.DtList("L").Rows.Add(Dr)
                End If
                For Each R As DataRow In H.DtList("V").Rows
                    R.Delete()
                Next
                For i As Integer = 0 To Me.ToolStrip.Items.Count - 1
                    If TypeOf (Me.ToolStrip.Items(i)) Is SearchItem Then
                        Dim S As SearchItem = TryCast(Me.ToolStrip.Items(i), SearchItem)

                        Dim Dr As DataRow = H.DtList("V").NewRow
                        Dr("ID") = ID
                        Dr("Name") = Name
                        S.Child.Setting.SetToDr(Dr)
                        H.DtList("V").Rows.Add(Dr)

                    End If
                Next
            End If
            H.UpdateAll(True)
        End Using
        Menu_LoadSearch.Tag = Name
        LoadSearchMenu(Name, True)

    End Sub



    ''' <summary>
    ''' 加载搜索菜单
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadSearchMenu(Optional ByVal Name As String = "", Optional ByVal UnLoadItem As Boolean = False)
        If IsAddSearchBottom Then AddSearchBottom()
        Dim IsLoad As Boolean = False
        For Each M As ToolStripMenuItem In MenuList
            M.Visible = False
        Next
        Dim ID As String = GetID()
        Dim R As PClass.PClass.DtReturnMsg = PClass.PClass.SqlStrToDt("select * from SearchSettingList where ID=@ID ", "ID", ID)
        If R.IsOk Then
            If R.Dt.Rows.Count > 0 Then
                For i As Integer = 0 To R.Dt.Rows.Count - 1
                    Dim M As New ToolStripMenuItem
                    If i > MenuList.Count - 1 Then
                        M = New ToolStripMenuItem
                        M.Size = New System.Drawing.Size(154, 22)
                        M.ImageScaling = ToolStripItemImageScaling.SizeToFit
                        MenuList.Add(M)
                        Menu_LoadSearch.DropDownItems.Add(M)
                    Else
                        M = MenuList(i)
                    End If
                    M.Image = Nothing
                    M.Checked = False
                    M.Visible = True
                    M.Text = R.Dt.Rows(i)("Name")
                    If R.Dt.Rows(i)("IsDefault") Then
                        IsLoad = True
                        M.Image = My.Resources.favorits
                        If Name = "" AndAlso UnLoadItem = False Then
                            LoadSearchItem(M.Text)
                        End If
                    End If
                Next
            End If
        End If
        If UnLoadItem = False Then
            If Name = "" Then
                If IsLoad = False Then
                    If Menu_LoadSearch.DropDownItems.Count > 0 Then
                        LoadSearchItem(Menu_LoadSearch.DropDownItems(0).Text)
                    Else
                        Dim SettingList As New List(Of SearchCol.SearchSetting)
                        RaiseEvent LoadDefaultMenu(SettingList)
                        Dim M As New ToolStripMenuItem
                        Dim i As Integer = 0
                        If i > MenuList.Count - 1 Then
                            M = New ToolStripMenuItem
                            M.Size = New System.Drawing.Size(154, 22)
                            M.ImageScaling = ToolStripItemImageScaling.SizeToFit
                            MenuList.Add(M)
                            Menu_LoadSearch.DropDownItems.Add(M)
                        Else
                            M = MenuList(i)
                        End If
                        M.Visible = True
                        M.Text = "默认方案"
                        SearchItem_RemoveAll()
                        Menu_LoadSearch.Tag = "默认方案"
                        For Each s As SearchCol.SearchSetting In SettingList
                            Dim C As SearchItem = SearchItem_Insert()
                            C.Child.Setting = s
                            C.Child.RollBack()
                            C.Child.ReSetTitle()
                        Next
                    End If
                End If
            Else
                LoadSearchItem(Name)
            End If
        End If
        SelectCheck()
    End Sub

    ''' <summary>
    ''' 加载搜索项目
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadSearchItem(ByVal Name As String)
        Menu_LoadSearch.Tag = Name
        SelectCheck()
        Dim ID As String = GetID()
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Name", Name)
        SearchItem_RemoveAll()
        If Name = "" Then Exit Sub
        Dim R As PClass.PClass.DtReturnMsg = PClass.PClass.SqlStrToDt("select * from SearchSettingValue where ID=@ID and Name=@Name order by Line", P)
        If R.IsOk Then
            DtToSetSearchItem(R.Dt, False)
        End If
    End Sub

    ''' <summary>
    ''' Dt加载回搜索项目
    ''' </summary>
    ''' <param name="Dt"></param>
    ''' <param name="IsRemoveAll"></param>
    ''' <remarks></remarks>
    Friend Sub DtToSetSearchItem(ByVal Dt As DataTable, ByVal IsRemoveAll As Boolean)
        If IsRemoveAll Then SearchItem_RemoveAll()
        If Dt.Rows.Count > 0 Then
            For Each Row As DataRow In Dt.Rows
                Dim C As SearchItem = SearchItem_Insert()
                C.Child.Setting.LoadFromDr(Row, True)
                C.Child.RollBack()
                C.Child.ReSetTitle()
            Next
        End If
    End Sub

    ''' <summary>
    ''' 设置当前选择项
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SelectCheck()
        For Each M As ToolStripMenuItem In Menu_LoadSearch.DropDownItems
            If M.Text = Menu_LoadSearch.Tag Then
                M.Checked = True
                Menu_SaveSearch.Text = "保存[" & M.Text & "]"
                Menu_DelSearch.Text = "删除[" & M.Text & "]"
                Menu_SetDefalut.Text = "设置[" & M.Text & "]为默认"
            Else
                M.Checked = False
            End If
        Next
    End Sub



    ''' <summary>
    ''' 获取自己的BaseForm
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMeBaseForm() As PClass.BaseForm
        Dim C As Control = Me.ToolStrip
        If C Is Nothing Then Return Nothing
        Do Until TypeOf (C.Parent) Is PClass.BaseForm
            If C.Parent Is Nothing Then
                Return Nothing
            End If
            C = C.Parent
        Loop
        Return C.Parent
    End Function


    ''' <summary>
    ''' 插入搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Function SearchItem_Insert() As SearchItem
        Dim i As Integer
        For i = 0 To Me.ToolStrip.Items.Count - 1
            If Me.ToolStrip.Items(i).MergeIndex <> -1 Then
                Exit For
            End If
        Next
        LastInsertSearchItemIndex = LastInsertSearchItemIndex + 1
        Dim C As New SearchItem With {.Name = "SearchItem" & LastInsertSearchItemIndex, .Text = "搜索条件" & LastInsertSearchItemIndex}
        C.Index = LastInsertSearchItemIndex
        C.LastText = C.Text
        C.IsNameChangeToData = _IsNameChangeToData
        C.Child.CB_ConditionName.DisplayMember = ConditionName_DisplayMember
        C.Child.CB_ConditionName.ValueMember = ConditionName_ValueMember
        C.Child.CB_ConditionName.DataSource = ConditionName_DataSource
        C.Child.CB_ConditionName.SelectedIndex = 0
        C.Visible = Not HideItemOnToolStrip
        AddHandler C.Child.Del_Me, AddressOf SearchItem_Delete
        AddHandler C.Child.CB_ConditionName_Change, AddressOf CB_ConditionName_Change
        AddHandler C.Child.Add_Me, AddressOf AddAndShow
        AddHandler C.Child.Save_Me, AddressOf Save_Me
        'AddHandler C.Child.Save_Me, AddressOf SearchItem_Save
        Me.ToolStrip.Items.Insert(i, C)
        _SearchItem.Add(C.Name, C)
        Return C
    End Function

    Public Sub AddAndShow()
        SearchItem_Insert.ShowDropDown()
    End Sub

    Protected Sub Save_Me(ByVal C As SearchItem)
        RaiseEvent StartSearch(Me, Nothing)
    End Sub



    ''' <summary>
    ''' 删除某个搜索条件
    ''' </summary>
    ''' <param name="C"></param>
    ''' <remarks></remarks>
    Public Sub SearchItem_Delete(ByVal C As SearchItem)
        If ToolStrip.Items.Contains(C) Then
            ToolStrip.Items.Remove(C)
        End If
        If _SearchItem.ContainsKey(C.Name) Then
            _SearchItem.Remove(C.Name)
        End If
        Try
            RemoveHandler C.Child.Del_Me, AddressOf SearchItem_Delete
            RemoveHandler C.Child.CB_ConditionName_Change, AddressOf CB_ConditionName_Change
            'RemoveHandler C.Child.Save_Me, AddressOf SearchItem_Save
        Catch ex As Exception
        End Try
        C.HideDropDown()
        C.Child = Nothing
        C = Nothing
    End Sub

    ''' <summary>
    ''' 清空所有搜索值
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SearchItem_ClearValue()
        For Each K As KeyValuePair(Of String, SearchItem) In SearchItems
            If K.Value.SearchOK AndAlso K.Value.Child.Setting.IsSaveValue = False Then
                K.Value.Child.Value = ""
                K.Value.Child.SetValue()
            End If
        Next
    End Sub

    ''' <summary>
    ''' 清空所有搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SearchItem_RemoveAll()
        For i As Integer = Me.ToolStrip.Items.Count - 1 To 0 Step -1
            If TypeOf (Me.ToolStrip.Items(i)) Is SearchItem Then
                SearchItem_Delete(TryCast(Me.ToolStrip.Items(i), SearchItem))
            End If
        Next
        LastInsertSearchItemIndex = 0
    End Sub


    ''' <summary>
    ''' 当某个搜索条件名称改变的时候
    ''' </summary>
    ''' <param name="C"></param>
    ''' <remarks></remarks>
    Protected Sub CB_ConditionName_Change(ByVal C As SearchItem)
        CB_ConditionValue2 = C.Child.CB_ConditionValue
        CB_ConditionName2 = C.Child.CB_ConditionName

        RaiseEvent CB_ConditionName_Click(C.Child.CB_ConditionName, New EventArgs)
    End Sub

    ''' <summary>
    ''' 当某个搜索条件名称改变的时候
    ''' </summary>
    ''' <param name="C"></param>
    ''' <remarks></remarks>
    Protected Friend Sub CB_ConditionName_Change(ByVal C As SearchForm)
        CB_ConditionValue2 = C.CB_ConditionValue
        CB_ConditionName2 = C.CB_ConditionName

        RaiseEvent CB_ConditionName_Click(C.CB_ConditionName, New EventArgs)
    End Sub


    ''' <summary>
    ''' 合并搜索条件
    ''' </summary>
    ''' <param name="oList"></param>
    ''' <remarks></remarks>
    Public Sub GetSearch(ByRef oList As OptionList)

        For i As Integer = 0 To Me.ToolStrip.Items.Count - 1
            If TypeOf (Me.ToolStrip.Items(i)) Is SearchItem Then
                Dim C As SearchItem = TryCast(Me.ToolStrip.Items(i), SearchItem)
                If C.SearchOK Then
                    Try
                        Dim Item As FindOption = TryCast(C.Child.CB_ConditionName.SelectedItem, FindOption)
                        If Item IsNot Nothing Then
                            Dim fo As FindOption = Item.Copy
                            fo.Field_Operator = C.Child.Setting.OperatorValue
                            fo.Value = C.Child.Setting.SearchValue
                            If C.Child.Setting.OperatorValue = Enum_Operator.Operator_Between Then
                                fo.Value2 = C.Child.Setting.SearchValue2
                            End If
                            fo.IsOr = C.Child.Setting.IsOr
                            oList.FoList.Add(fo)
                        End If


                    Catch ex As Exception
                    End Try
                End If
            End If
        Next
    End Sub

    Friend Function GetNowSearch() As DataTable
        Dim Dt As DataTable = SearchCol.SearchSetting.GetNullDt
        For i As Integer = 0 To Me.ToolStrip.Items.Count - 1
            If TypeOf (Me.ToolStrip.Items(i)) Is SearchItem Then
                Dim C As SearchItem = TryCast(Me.ToolStrip.Items(i), SearchItem)
                Try
                    Dim Dr As DataRow = Dt.NewRow
                    C.Child.Setting.SetToDr(Dr, True)
                    Dt.Rows.Add(Dr)
                Catch ex As Exception
                End Try
            End If
        Next
        Dt.AcceptChanges()
        Return Dt
    End Function



    ''' <summary>
    ''' 获取组合条件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSearchToOptionList() As OptionList
        Dim fo As New OptionList
        GetSearch(fo)
        Return fo
    End Function


    ''' <summary>
    ''' 添加筛选按钮
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddSearchBottom()
        Static IsAdd As Boolean = False
        If IsAdd Then
            Exit Sub
        End If
        IsAdd = True
        Try
            If Me.ToolStrip.ImageScalingSize.Width < 18 Then
                Me.ToolStrip.ImageScalingSize = New Drawing.Size(18, 18)
            End If
            Dim i As Integer
            For i = 0 To Me.ToolStrip.Items.Count - 1
                If Me.ToolStrip.Items(i).MergeIndex <> -1 Then
                    Exit For
                End If
            Next
            Me.ToolStrip.Items.Insert(i, Menu_ShowSearchForm2)
        Catch ex As Exception
        End Try
    End Sub
#End Region




End Class
