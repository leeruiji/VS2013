Imports PClass
Imports System.Windows.Forms

Public Class SearchForm
    Implements IViewForm

    Dim ResultReturn As DeReturn
    Dim ResultHideShadow As DeHideShadow

    Public Delegate Sub DeReturn(ByVal Result As MsgBoxResult)
    Public Delegate Sub DeHideShadow()
    Public Delegate Sub DeNoReturn()
    Public Result As MsgBoxResult = MsgBoxResult.Cancel
    Private IsLoad As Boolean = False
    Public ToolBar As ToolStripSearch
    Dim DtValue As DataTable
    Dim searchID As String
    Dim SearchName As String


    Private WithEvents Menu_LoadSearch As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents Menu_DelSearch As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents Menu_SaveSearch As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents Menu_SaveAsSearch As New System.Windows.Forms.ToolStripMenuItem
    Private WithEvents Menu_SetDefalut As New System.Windows.Forms.ToolStripMenuItem

    Public WithEvents GridShadow As New PictureBox With {.Visible = False, .Dock = DockStyle.Fill}

    ''' <summary>
    ''' 当搜索条件名称被点击的时候
    ''' </summary>
    ''' <param name="C">父容器</param>
    ''' <remarks></remarks>
    Public Event CB_ConditionName_Change(ByVal C As SearchForm)

    Sub New(ByVal Tool As ToolStripSearch, ByVal Title As String, ByVal ResultReturn As DeReturn, ByVal HideShadow As DeHideShadow)
        ' 此调用是设计器所必需的。
        InitializeComponent()
        Me.ToolBar = Tool
        Me.Tool_Top.SuspendLayout()
        If Me.DesignMode = False Then
            Me.Controls.Add(GridShadow)
            Menu_Ini()
            AddSaveMenu(Menu_Search.DropDownItems)
            LoadMenuList()
        End If
        Me.Tool_Top.ResumeLayout(False)
        Me.ResultReturn = ResultReturn
        Me.ResultHideShadow = HideShadow
        Me.Text = Title
        AddHandler CB_ConditionName_Change, AddressOf ToolBar.CB_ConditionName_Change
        Me.Show()
    End Sub
    Private Sub ConfirmBox_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        ResultReturn(Result)
        Me.Visible = False
        'Select Case ReturnMode
        '    Case 0
        ResultHideShadow()
        '    Case 1
        '        ResultHideShadow()
        '        ResultReturn(Result)
        '    Case 2
        '        ResultHideShadow()
        '        If Result = MsgBoxResult.Yes Or Result = MsgBoxResult.Ok Then
        '            ResultNoReturn()
        '        Else
        '            NoReturn()
        '        End If
        '    Case 3
        '        ResultHideShadow()
        '        ResultNoReturn()
        'End Select
    End Sub

#Region "Combox"
    Private Sub CB_ConditionValue_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionValue.DropDown
        If ToolBar.IsNameChangeToData = False Then
            'Dim B As Boolean = Me.ParentCol.SearchOK
            'Me.ParentCol.SearchOK = False
            RaiseEvent CB_ConditionName_Change(Me)
            ' Me.ParentCol.SearchOK = B
        End If
    End Sub
    Private Sub CB_ConditionName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionName.SelectedIndexChanged
        'If IsNoChick = False Then
        '    Try
        '        CB_Operator.SelectedValue = DirectCast(DirectCast(CB_ConditionName.SelectedItem, System.Object), BaseClass.FindOption).Field_Operator
        '    Catch ex As Exception
        '    End Try
        'End If
        If CK_PreView.Checked AndAlso ToolBar.IsNameChangeToData Then
            'Dim B As Boolean = Me.ParentCol.SearchOK
            'Me.ParentCol.SearchOK = False
            RaiseEvent CB_ConditionName_Change(Me)
            ' Me.ParentCol.SearchOK = B
        End If
    End Sub
#End Region
#Region "菜单"
    ''' <summary>
    ''' 条件菜单集合
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend MenuList As New List(Of ToolStripMenuItem)

    Protected Sub Menu_Ini()
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
    End Sub


    Protected Sub LoadMenuList()
        For Each M As ToolStripMenuItem In MenuList
            M.Visible = False
        Next
        Dim i As Integer = 0
        For Each PM As ToolStripMenuItem In ToolBar.MenuList
            Dim M As New ToolStripMenuItem
            If i > MenuList.Count - 1 Then
                M = New ToolStripMenuItem
                M.Size = New System.Drawing.Size(154, 22)
                MenuList.Add(M)
                Menu_LoadSearch.DropDownItems.Add(M)
            Else
                M = MenuList(i)
            End If
            M.Image = PM.Image
            M.Checked = PM.Checked
            M.Visible = True
            M.Text = PM.Text
            M.ImageScaling = PM.ImageScaling
            i = i + 1
        Next
        Menu_LoadSearch.Tag = ToolBar.Menu_LoadSearch.Tag
        Menu_DelSearch.Text = ToolBar.Menu_DelSearch.Text
        Menu_SaveSearch.Text = ToolBar.Menu_SaveSearch.Text
        Menu_SetDefalut.Text = ToolBar.Menu_SetDefalut.Text
    End Sub

    ''' <summary>
    ''' 添加菜单
    ''' </summary>
    ''' <param name="M"></param>
    ''' <remarks></remarks>
    Sub AddSaveMenu(ByVal M As ToolStripItemCollection)
        M.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_LoadSearch, Me.Menu_DelSearch, Me.Menu_SaveSearch, Me.Menu_SaveAsSearch, Me.Menu_SetDefalut})
    End Sub



#Region "   菜单事件    "

    Private Sub Menu_DelSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_DelSearch.Click
        Dim P As New Dictionary(Of String, Object)
        Dim BF As PClass.BaseForm = ToolBar.GetMeBaseForm()
        If BF Is Nothing Then Exit Sub
        Dim LName As String = Menu_LoadSearch.Tag
        BF.ShowConfirm("是否" & Menu_DelSearch.Text, AddressOf SearchItem_Del)
    End Sub

    Sub SearchItem_Del()
        ToolBar.SearchItem_Del()
        LoadMenuList()
        Clear()
        SetList()
    End Sub


    ''' <summary>
    ''' 方案保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_SaveSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_SaveSearch.Click
        Dim LName As String = ToolBar.Menu_LoadSearch.Tag
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
        ShowInput("请输入一个搜索方案名称?", AddressOf SearchItem_Save, LName, "请输入搜索方案的名字")
    End Sub
    Sub SearchItem_Save(ByVal S As String)
        ToolBar.DtToSetSearchItem(GetList, True)
        ToolBar.SearchItem_Save(S)
    End Sub


    ''' <summary>
    ''' 设置默认值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_SetDefalut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_SetDefalut.Click
        ToolBar.SetDefalut()
        LoadMenuList()
    End Sub

    ''' <summary>
    ''' 加载搜索项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Menu_LoadSearch_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Menu_LoadSearch.DropDownItemClicked
        ToolBar.LoadSearchItem(e.ClickedItem.Text)
        LoadMenuList()
        Clear()
        SetList()
    End Sub





#End Region
#End Region
#Region "加载"
    Sub SetList()
        Dim OPDt As DataTable = SearchCol.GetOperatorDt()


        DtValue = ToolBar.GetNowSearch()
        DtValue.Columns.Add("OperatorName", GetType(String))
        For Each dr As DataRow In DtValue.Rows
            For Each drop As DataRow In OPDt.Rows
                If dr("OperatorValue") = drop("OperatorValue") Then
                    dr("OperatorName") = drop("OperatorName")
                    Exit For
                End If
            Next
        Next

        FG1.DtToSetFG(DtValue)
        SetForm(FG1.RowSel)
    End Sub
    Sub Clear()
        ResetForm()
        FG1.Rows.Count = 1
    End Sub

    Sub LoadData()
        CB_ConditionName.ValueMember = ToolBar.ConditionName_ValueMember
        CB_ConditionName.DisplayMember = ToolBar.ConditionName_DisplayMember
        CB_ConditionName.DataSource = ToolBar.ConditionName_DataSource

        CB_Operator.DisplayMember = "OperatorName"
        CB_Operator.ValueMember = "OperatorValue"

        CB_Operator.DataSource = SearchCol.GetOperatorDt()

        SetList()

    End Sub
#End Region
#Region "表单信息"

    Private Sub CB_Operator_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Operator.SelectedIndexChanged
        If IsLoad Then


            If CB_Operator.SelectedValue = Enum_Operator.Operator_Between Then
                CB_ConditionValue.Visible = False
                SC_Between.Visible = True
                TB_Value.Visible = False
                CK_PreView.Enabled = False
            Else
                CB_ConditionValue.Visible = CK_PreView.Checked
                SC_Between.Visible = False
                TB_Value.Visible = Not CK_PreView.Checked
                CK_PreView.Enabled = True
            End If
        End If
    End Sub
    Private Sub CK_PreView_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CK_PreView.Click
        ShowPreValue()
    End Sub

    Sub ShowPreValue()
        If CK_PreView.Checked Then
            CB_ConditionValue.Visible = True
            SC_Between.Visible = False
            TB_Value.Visible = False
            CB_ConditionValue.Text = TB_Value.Text
        Else
            CB_ConditionValue.Visible = False
            SC_Between.Visible = False
            TB_Value.Visible = True
            TB_Value.Text = CB_ConditionValue.Text
        End If
    End Sub

    ''' <summary>
    ''' 检查条件值是否为空
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsSearchValueEmpty() As Boolean
        If TB_Value.Visible = True AndAlso TB_Value.Text = "" Then
            Return True
        ElseIf SC_Between.Visible AndAlso TB_Value1.Text = "" AndAlso TB_Value2.Text = "" Then
            Return True
        ElseIf CB_ConditionValue.Visible = True AndAlso CB_ConditionValue.Text = "" Then
            Return True
        Else
            Return False


        End If
    End Function
    Function CheckForm() As Boolean
        If CB_ConditionName.Text = "" OrElse CB_ConditionName.Text = "请选择" Then
            ShowErrMsg("请选择条件。", AddressOf donothing)
            Return False

        End If
        Return True
    End Function
    Sub donothing()

    End Sub
    ''' <summary>
    ''' 重置表单
    ''' </summary>
    ''' <remarks></remarks>
    Sub ResetForm()
        If CB_ConditionName.SelectedIndex > 0 Then
            CB_ConditionName.SelectedIndex = 0
        End If

        If CB_ConditionValue.SelectedIndex > 0 Then
            CB_ConditionValue.SelectedIndex = 0
        End If

        CB_ConditionValue.Text = ""
        TB_Value.Text = ""
        TB_Value1.Text = ""
        TB_Value2.Text = ""
        RadioAnd.Checked = True
        Cmd_IgnoreTime.Checked = False
        CK_SaveValue.Checked = False
    End Sub

    ''' <summary>
    ''' 获取列表内容
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetList() As DataTable
        Dim ID As String = ToolBar.GetID
        Dim Name As String = ToolBar.GetName
        Dim dt As DataTable = DtValue.Clone
        Dim dr As DataRow
        ''保存时，如果列表为空或当前编辑的条件与选择行不一样，添加新行，否则修改当前行
        If IsSearchValueEmpty() Then


        ElseIf FG1.Rows.Count = 1 OrElse FG1.Item(FG1.RowSel, "SearchName") <> CB_ConditionName.Text Then
            AddItem()
        Else
            SetRow(FG1.RowSel)
        End If
        For i As Integer = 1 To FG1.Rows.Count - 1
            If FG1.Item(i, "SearchName") <> "" AndAlso FG1.Item(i, "SearchName") <> "请选择" Then
                dr = dt.NewRow
                dr("SearchName") = FG1.Item(i, "SearchName")
                dr("OperatorValue") = FG1.Item(i, "OperatorValue")
                dr("SearchValue") = FG1.Item(i, "SearchValue")
                dr("SearchValue2") = FG1.Item(i, "SearchValue2")
                dr("IsOr") = FG1.Item(i, "IsOr")
                dr("IgnoreTime") = Cmd_IgnoreTime.Checked
                dr("IsSaveValue") = FG1.Item(i, "IsSaveValue")
                dr("IsPreView") = FG1.Item(i, "IsPreView")
                dr("ID") = ID

                dr("Name") = Name
                dt.Rows.Add(dr)
            End If
        Next
        Return dt
    End Function

    ''' <summary>
    ''' 设置一行的值，送表单到行
    ''' </summary>
    ''' <param name="i"></param>
    ''' <remarks></remarks>
    Sub SetRow(ByVal i As Integer)
        If i < 1 Then
            Exit Sub
        End If
        If CheckForm() = False Then
            Exit Sub
        End If

        Try

            FG1.Item(i, "SearchName") = TryCast(CB_ConditionName.DataSource, List(Of FindOption))(CB_ConditionName.SelectedIndex).Field
            FG1.Item(i, "OperatorValue") = CB_Operator.DataSource.rows(CB_Operator.SelectedIndex)("OperatorValue")
            FG1.Item(i, "OperatorName") = CB_Operator.DataSource.rows(CB_Operator.SelectedIndex)("OperatorName")
        Catch ex As Exception
            DelRow(i)
            Exit Sub
        End Try
        If TB_Value.Visible = True Then
            FG1.Item(i, "SearchValue") = TB_Value.Text
            FG1.Item(i, "SearchValue2") = ""
        ElseIf SC_Between.Visible = True Then

            FG1.Item(i, "SearchValue") = TB_Value1.Text
            FG1.Item(i, "SearchValue2") = TB_Value2.Text
        ElseIf CB_ConditionValue.Visible = True Then
            FG1.Item(i, "SearchValue") = CB_ConditionValue.Text
            FG1.Item(i, "SearchValue2") = ""
        End If

        FG1.Item(i, "IsOr") = RadioOr.Checked
        FG1.Item(i, "IgnoreTime") = Cmd_IgnoreTime.Checked
        FG1.Item(i, "IsSaveValue") = CK_SaveValue.Checked
        FG1.Item(i, "IsPreView") = CK_PreView.Checked
    End Sub
    ''' <summary>
    ''' 从fg行获取数据到表单
    ''' </summary>
    ''' <param name="i"></param>
    ''' <remarks></remarks>
    Sub SetForm(ByVal i As Integer)
        If i < 1 Then
            ResetForm()
            Exit Sub
        End If


        If FG1.Item(i, "OperatorValue") = Enum_Operator.Operator_Between Then
            TB_Value.Visible = False
            SC_Between.Visible = True
            CB_ConditionValue.Visible = False
            CK_PreView.Enabled = False
            TB_Value.Text = ""
            TB_Value1.Text = FG1.Item(i, "SearchValue")
            TB_Value2.Text = FG1.Item(i, "SearchValue2")
            CB_ConditionValue.Text = ""
        ElseIf FG1.Item(i, "IsPreView") Then
            TB_Value.Visible = False
            SC_Between.Visible = False
            CB_ConditionValue.Visible = True
            CK_PreView.Enabled = True
            CB_ConditionValue.Text = FG1.Item(i, "SearchValue")
            TB_Value.Text = ""
            TB_Value1.Text = ""
            TB_Value2.Text = ""
        Else
            TB_Value.Visible = True
            SC_Between.Visible = False
            CB_ConditionValue.Visible = False
            CK_PreView.Enabled = True
            CB_ConditionValue.Text = ""
            TB_Value.Text = FG1.Item(i, "SearchValue")
            TB_Value1.Text = ""
            TB_Value2.Text = ""

        End If

        If FG1.Item(i, "IsOr") Then
            RadioOr.Checked = True
        Else
            RadioAnd.Checked = True
        End If


        Cmd_IgnoreTime.Checked = FG1.Item(i, "IgnoreTime")
        CK_SaveValue.Checked = FG1.Item(i, "IsSaveValue")
        CK_PreView.Checked = FG1.Item(i, "IsPreView")
        CB_ConditionName.Text = FG1.Item(i, "SearchName")
        CB_Operator.SelectedValue = Val(FG1.Item(i, "OperatorValue"))


    End Sub
#End Region
#Region "接口部分"
#Region "ShowInput"
    Private Sub NoReturn()

    End Sub
    Public Sub ShowInput(ByVal Msg As String, ByVal YesReturn As InputBoxs.DYesReturn, Optional ByVal DefaultString As String = "", Optional ByVal Title As String = "")
        Me.Update()
        Me.ShowShadow()
        If Title = "" Then Title = Me.Text
        Shadow_Form = New InputBoxs(Msg, Title, DefaultString, YesReturn, AddressOf NoReturn, AddressOf HideShadow)
        Shadow_Form.Active()
    End Sub

    Public Sub ShowInput(ByVal Msg As String, ByVal YesReturn As InputBoxs.DYesReturn, ByVal NoReturn As InputBoxs.DeNoReturn, Optional ByVal DefaultString As String = "", Optional ByVal Title As String = "")
        Me.Update()
        Me.ShowShadow()
        If Title = "" Then Title = Me.Text
        Shadow_Form = New InputBoxs(Msg, Title, DefaultString, YesReturn, NoReturn, AddressOf HideShadow)
        Shadow_Form.Active()
    End Sub
    Public Sub ShowConfirm(ByVal Msg As String, ByVal YesReturn As ConfirmBox.DeNoReturn)
        Me.Update()
        Me.ShowShadow()
        Shadow_Form = (New ConfirmBox(Msg, Me.Text, YesReturn, AddressOf NoReturn, AddressOf HideShadow))
        Shadow_Form.Active()
    End Sub


    Private Sub ShowMsgReturn(ByVal Result As MsgBoxResult)

    End Sub

    Private Sub ShowMsgReturnClose(ByVal Result As MsgBoxResult)
        Me.Close()
    End Sub


    Public Sub ShowOk(ByVal Msg As String, Optional ByVal Close As Boolean = False)
        If Close Then
            ShowShadow()
            Shadow_Form = (New ConfirmBox(Msg, Text, AddressOf ShowMsgReturnClose, AddressOf HideShadow, MessageBoxButtons.OK, MessageBoxIcon.Information))
        Else
            ShowShadow()
            Shadow_Form = (New ConfirmBox(Msg, Text, AddressOf ShowMsgReturn, AddressOf HideShadow, MessageBoxButtons.OK, MessageBoxIcon.Information))
        End If
        Shadow_Form.Active()
    End Sub

    Public Sub ShowErrMsg(ByVal Msg As String, ByVal ResultReturn As ConfirmBox.DeReturn)
        ShowShadow()
        Shadow_Form = New ConfirmBox(Msg, Text, ResultReturn, AddressOf HideShadow, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Shadow_Form.Active()
    End Sub
#End Region
    Public WithEvents Shadow_Form As IViewForm
    Public Sub Active() Implements IViewForm.Active
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
            Me.Show()
        End If
        Me.Activate()
    End Sub


    Public Sub AddMu() Implements IViewForm.AddMu

    End Sub

    Public Property Child() As BaseForm Implements IViewForm.Child
        Get
            Return Nothing
        End Get
        Set(ByVal value As BaseForm)
        End Set
    End Property

    Public Sub Close1() Implements IViewForm.Close
        Me.Close()
    End Sub

    Public Event Closed1() Implements IViewForm.ClosedX

    Public Sub HideShadow() Implements IViewForm.HideShadow
        GridShadow.Visible = False
        PanelMain.Enabled = True
        Me.Update()
    End Sub

    Public Sub ShowShadow() Implements IViewForm.ShowShadow
        PClass.PClass.CaptureFromImageToPicture(Me, GridShadow)
        GridShadow.Visible = True
        PanelMain.Enabled = False
        GridShadow.Focus()
    End Sub
    Public Sub HideLoading() Implements IViewForm.HideLoading
        GridShadow.Image = Nothing
        HideShadow()
    End Sub

    Private Sub GridShadow_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridShadow.LostFocus
        If GridShadow.Visible = False Then GridShadow.Focus()
    End Sub

    Private Sub GridShadow_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridShadow.MouseDown
        Shadow_Form.Active()
    End Sub

    Public Sub ShowLoading(Optional ByVal ShowShadow As Boolean = True) Implements IViewForm.ShowLoading

    End Sub
    Public Property Text1() As String Implements IViewForm.Text
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            value = Me.Text
        End Set
    End Property

    Public Sub SetFormState(ByVal State As System.Windows.Forms.FormWindowState) Implements IViewForm.SetFormState
        Me.WindowState = State
    End Sub

    Private Sub SearchForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveHandler CB_ConditionName_Change, AddressOf ToolBar.CB_ConditionName_Change
    End Sub

    Private Sub ConfirmBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Icon = PClass.PClass.MainForm.icon
            '  FG1.Cols("").Editor = CB_ConditionName
            ResetForm()
            LoadData()
        Catch ex As Exception
        End Try
        IsLoad = True
    End Sub

    Public ReadOnly Property IsShowShadow() As Boolean Implements IViewForm.IsShowShadow
        Get
            Return GridShadow.Visible
        End Get
    End Property


    Public Sub Form_KeyDownX(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Implements IViewForm.Form_KeyDownX

    End Sub

    Public Sub Form_KeyPressX(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Implements IViewForm.Form_KeyPressX

    End Sub
#End Region
#Region "FG事件"
    Dim isAdding As Boolean = False

    Private Sub FG1_ClickRow(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.ClickRow
        SetForm(FG1.RowSel)
    End Sub
    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange


        If isAdding = True Then
            isAdding = False
        Else
            SetForm(FG1.RowSel)
        End If

    End Sub

    Function AddRow(ByVal i As Integer) As C1.Win.C1FlexGrid.Row
        If i > FG1.Rows.Count OrElse i < 1 Then
            i = FG1.Rows.Count


        End If
        isAdding = True
        Dim r As C1.Win.C1FlexGrid.Row = FG1.Rows.Insert(i)
        FG1.ReAddIndex()
        '  FG1.Rows(FG1.RowSel).Selected = False

        Return r
    End Function

    Sub DelRow(ByVal i As Integer)
        If i < 1 Then
            Exit Sub
        End If
        FG1.RemoveItem(i)
        FG1.ReAddIndex()
        If FG1.Rows.Count > 1 Then
            SetForm(FG1.Rows.Count - 1)
            FG1.Select(FG1.Rows.Count - 1, 1, FG1.Rows.Count - 1, FG1.Cols.Count - 1)
        Else
            ResetForm()
        End If
    End Sub
#End Region
#Region "toolbar事件"

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        ToolBar.DtToSetSearchItem(GetList, True)

        Result = MsgBoxResult.Ok
        Me.Close()
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        If CheckForm() = False Then
            Exit Sub
        End If
        AddItem()
        '   ResetForm()
    End Sub

    Sub AddItem()
        Dim r As C1.Win.C1FlexGrid.Row
        If CKB_AddLast.Checked Then
            r = AddRow(FG1.Rows.Count)
        Else
            r = AddRow(FG1.RowSel)
        End If

        SetRow(r.Index)
        FG1.RowSel = r.Index
        FG1.Row = r.Index
    End Sub


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() = False Then
            Exit Sub
        End If
        If FG1.RowSel < 1 Then
            AddItem()
        Else
            SetRow(FG1.RowSel)
        End If
        '  ResetForm()
    End Sub
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        DelRow(FG1.RowSel)
        ' ResetForm()
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Clear()
    End Sub

    Private Sub Cmd_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Reset.Click
        ResetForm()
    End Sub
    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        Me.Close()
    End Sub
#End Region




End Class