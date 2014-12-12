Imports System.ComponentModel
Imports PClass.PClass
Imports System.Windows.Forms

<System.ComponentModel.ToolboxItem(False)> _
  Public Class ComBoListCtrl
    Public Const ComboName As String = "默认"
    Protected _Col_Parent As ICol_Parent
    Protected FormID As Integer = 0

#Region "变量"
    Public Const Add As String = "Add"
    Public Const Modify As String = "Modify"
    Public Const Del As String = "Del"
    Protected NotTop As Boolean = False
    Public Search As String = ""

    Protected StartEdit As Boolean = False
    Protected ID As String = ""
    Friend IsSelectAll As Boolean = False
    Protected LastSearch As String
    Protected LastParameters As Dictionary(Of String, Object)
    Protected LastDt As DataTable
    Public SQL_Col_GetSearch_Order As String
    Public SQL_Col_GetSearch_Where As String
    Public SQL_Col_GetSearch As String
    Public SQL_Col_GetSearch_GetByID As String


    Protected Col_Col_No As String = "Col_No"
    Protected Col_Col_Name As String = "Col_Name"
    Protected Col_Col_ID As String = "Col_ID"


    Public SearchCount As Long = 0
    Public SearchTimeCount As Long = 0
    Public ShowRowCount As Integer = 0
#End Region

#Region "属性"
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
            If Col_Parent Is Nothing Then
                Return False
            Else
                Return Col_Parent.IsShowAdd
            End If
        End Get
        Set(ByVal value As Boolean)
            Cmd_Add.Visible = value
            If Col_Parent IsNot Nothing AndAlso Col_Parent.IsShowAdd <> value Then
                Col_Parent.IsShowAdd = value
            End If
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
            If Col_Parent Is Nothing Then
                Return False
            Else
                Return Col_Parent.IsShowModify
            End If
        End Get
        Set(ByVal value As Boolean)
            Cmd_Modify.Visible = value
            If Col_Parent IsNot Nothing AndAlso Col_Parent.IsShowModify <> value Then
                Col_Parent.IsShowModify = value
            End If
        End Set
    End Property


#End Region

    ''' <summary>
    ''' 编号字段
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_Col_No_Field()
        Get
            Return Col_Col_No
        End Get
    End Property
    ''' <summary>
    ''' ID字段
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_Col_ID_Field()
        Get
            Return Col_Col_ID
        End Get
    End Property
    ''' <summary>
    ''' 名称字段
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Get_Col_Name_Field()
        Get
            Return Col_Col_Name
        End Get
    End Property


    ''' <summary>
    ''' 父控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("父控件"), Browsable(False), Category("N8"), DefaultValue(True)> _
    Public Property Col_Parent() As ICol_Parent
        Get
            Return _Col_Parent
        End Get
        Set(ByVal value As ICol_Parent)
            _Col_Parent = value
            SetConfig()
        End Set
    End Property

    ''' <summary>
    ''' 是否没有输入字符串时候,显示初始列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否没有输入字符串时候,显示初始列表"), Browsable(True), Category("N8"), DefaultValue(True)> _
    Public Property IsShowAll() As Boolean
        Get
            If Col_Parent Is Nothing Then
                Return True
            Else
                Return Col_Parent.IsShowAll
            End If
        End Get
        Set(ByVal value As Boolean)
            If Col_Parent IsNot Nothing AndAlso Col_Parent.IsShowAll <> value Then
                Col_Parent.IsShowAll = value
            End If
        End Set
    End Property


    ''' <summary>
    ''' 是否可清空
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("是否可清空"), Browsable(True), Category("N8"), DefaultValue(True)> _
    Public Property IsTBLostFocusSelOne() As Boolean
        Get
            If Col_Parent Is Nothing Then
                Return True
            Else
                Return Col_Parent.IsTBLostFocusSelOne
            End If
        End Get
        Set(ByVal value As Boolean)
            If Col_Parent IsNot Nothing AndAlso Col_Parent.IsTBLostFocusSelOne <> value Then
                Col_Parent.IsTBLostFocusSelOne = value
            End If
            Cmd_Del.Visible = Not value
        End Set
    End Property



    ''' <summary>
    ''' 搜索ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchID() As String
        Get
            If Col_Parent Is Nothing Then
                Return ""
            Else
                Return Col_Parent.SearchID
            End If
        End Get
        Set(ByVal value As String)
            If Col_Parent IsNot Nothing AndAlso Col_Parent.SearchID <> value Then
                Col_Parent.SearchID = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' 搜索BZID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchBZID() As String
        Get
            If Col_Parent Is Nothing Then
                Return ""
            Else
                Return Col_Parent.SearchBZID
            End If
        End Get
        Set(ByVal value As String)
            If Col_Parent IsNot Nothing AndAlso Col_Parent.SearchBZID <> value Then
                Col_Parent.SearchBZID = value
            End If
        End Set
    End Property


    ''' <summary>
    ''' 搜索类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchType() As cSearchType.ENum_SearchType
        Get
            If Col_Parent Is Nothing Then
                Return cSearchType.ENum_SearchType.ALL
            Else
                Return Col_Parent.SearchType
            End If
        End Get
        Set(ByVal value As cSearchType.ENum_SearchType)
            If Col_Parent IsNot Nothing AndAlso Col_Parent.SearchType <> value Then
                Col_Parent.SearchType = value
            End If
        End Set
    End Property


    Public ReadOnly Property GetFGHandle() As IntPtr
        Get
            Return FG1.Handle
        End Get
    End Property

#End Region



#Region "函数"

    Sub SetConfig()
        Cmd_Add.Visible = Col_Parent.IsShowAdd
        Cmd_Del.Visible = Not Col_Parent.IsTBLostFocusSelOne
        Cmd_Modify.Visible = Col_Parent.IsShowModify
    End Sub
#Region "父控件会有相应的函数"
    ''' <summary>
    ''' 选择第一个
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Col_SelOne()
        If FG1.RowSel > 0 Then
            RaiseEvent Col_Sel(FG1.Item(FG1.RowSel, Col_Col_No), FG1.Item(FG1.RowSel, Col_Col_Name), FG1.Item(FG1.RowSel, Col_Col_ID))
            RaiseEvent Col_SelRow(FG1.SelectItem)
        End If
    End Sub



    ''' <summary>
    ''' 根据ID输出DataRow
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetIDToDataRow(Optional ByVal ID As String = "") As DataRow
        If ID = "" Then Return Nothing
        Dim Dtr As DtReturnMsg = SqlStrToDt(SQL_Col_GetSearch_GetByID, "@ID", ID)
        If Dtr.IsOk Then
            If Dtr.Dt.Rows.Count > 0 Then
                Return Dtr.Dt.Rows(0)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function


#End Region


    ''' <summary>
    ''' f2-f8
    ''' </summary>
    ''' <param name="KeyCode"></param>
    ''' <remarks></remarks>
    Overridable Sub QuickKey(ByVal KeyCode As Keys)

    End Sub


    Public Sub StartSearch()
        SearchCount = SearchCount + 1
        TimerEdit.Enabled = True
    End Sub



    Private Sub FG_Refresh(Optional ByVal StartEdit As Boolean = False)
        Dim Cancel As Boolean = False
        Dim ID As String = ""
        RaiseEvent GetSearchEvent(Search, ID, Cancel)
        If Search Is Nothing Then Search = ""
        If ID Is Nothing Then ID = ""
        If Cancel = True Then Exit Sub
        Search = Search.Replace("'", "")
        Me.StartEdit = StartEdit
        Me.ID = ID
        If IsShowAll = False AndAlso Search = "" Then
            Exit Sub
        End If
        SearchTimeCount = SearchCount
        Dim T As New Threading.Thread(AddressOf GetSearch)
        T.Start()
    End Sub

    Overridable Sub GetSearch()
        Dim S As String = StrConv(Search, vbNarrow)
        Dim GS As String = SQL_Col_GetSearch
        If Not GS.Contains("top 10") AndAlso IsSelectAll Then
            Search = ""
        Else
            Search = S
        End If
        Dim Parameters As New Dictionary(Of String, Object)
        Parameters.Add("@No", "%" & Search & "%")
        Parameters.Add("@Name", "%" & Search & "%")
        Parameters.Add("@FindHelper", "%" & Search & "%")
        If NotTop Then
            GS = SQL_Col_GetSearch.Replace("top 10", "")
        Else
            GS = SQL_Col_GetSearch.Replace("top 10", "top " & ShowRowCount)
        End If
        SQLtoSearch(GS, Parameters)
    End Sub

    Protected Sub SQLtoSearch(ByVal GS As String, ByVal Parameters As Dictionary(Of String, Object), Optional ByVal NoAddWhere As Boolean = False)
        If CompareLastSearch(GS, Parameters) Then
            FG1.Invoke(New DDtSetFG(AddressOf DtSetFG), LastDt)
            Exit Sub
        End If
        Dim Dtr As DtReturnMsg
        If Search = "" OrElse NoAddWhere Then
            Dtr = SqlStrToDt(GS & SQL_Col_GetSearch_Order, Parameters)
        Else
            Dtr = SqlStrToDt(GS & SQL_Col_GetSearch_Where & SQL_Col_GetSearch_Order, Parameters)
        End If
        If Dtr.IsOk Then
            LastSearch = GS
            LastParameters = Parameters
            LastDt = Dtr.Dt
            FG1.Invoke(New DDtSetFG(AddressOf DtSetFG), Dtr.Dt)
        ElseIf SearchTimeCount <> SearchCount Then
            FG_Refresh()
        End If
    End Sub

    Private Function CompareLastSearch(ByVal GS As String, ByVal Parameters As Dictionary(Of String, Object)) As Boolean
        If LastParameters Is Nothing OrElse LastSearch Is Nothing OrElse LastParameters.Keys.Count <> Parameters.Keys.Count OrElse LastDt Is Nothing OrElse LastSearch <> GS Then
            Return False
        Else
            For Each K As String In Parameters.Keys
                If Parameters(K) <> LastParameters(K) Then
                    Return False
                End If
            Next
            Return True
        End If
    End Function



    Delegate Sub DDtSetFG(ByVal Dt As DataTable)
    Sub DtSetFG(ByVal Dt As DataTable)
        If SearchTimeCount <> SearchCount Then
            FG_Refresh()
            Exit Sub
        End If
        FG1.DataSource = Dt
        If Dt.Rows.Count = 0 Then
            'Col_Parent.Close()
            IsSelectAll = False
            Exit Sub
        End If
        If Dt.Rows.Count = 1 And StartEdit = True Then
            If FG1.Item(1, Col_Col_ID) = Val(ID) Then
                Col_Parent.Close()
                IsSelectAll = False
                Exit Sub
            End If
        End If
        If Col_Parent.IsDropDown = False Then
            Col_Parent.ShowDropDown()
        End If
        If Val(Col_Parent.ShowID) <> 0 AndAlso IsSelectAll Then
            Try
                FG1.RowSetForce(FG1.Cols(Col_Col_ID).Index, CInt(Col_Parent.ShowID))
            Catch ex As Exception
            End Try
        End If
        IsSelectAll = False
    End Sub

    ''' <summary>
    ''' 获取选择的那一行的某个字段的值,最好在Col_sel事件中使用
    ''' </summary>
    ''' <param name="Field"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetSelectRow(ByVal Field As String) As Object
        If FG1.RowSel > 0 Then
            Return FG1.SelectItem(Field)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 清空查询记录
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetLastDtEmpty()
        LastDt = Nothing
    End Sub



    Sub FG_KeyDown(ByVal Key As Keys)
        Select Case Key
            Case Keys.Down
                If FG1.RowSel < FG1.Rows.Count - 1 Then
                    FG1.RowSel = FG1.RowSel + 1
                    FG1.Row = FG1.Row + 1
                End If

            Case Keys.Up
                If FG1.RowSel > 1 Then
                    FG1.RowSel = FG1.RowSel - 1
                    FG1.Row = FG1.Row - 1
                End If

        End Select
    End Sub



#End Region


#Region "事件定义"
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
    ''' <param name="Row"></param>
    ''' <remarks></remarks>
    <Description("被选择行的事件"), Browsable(True)> _
    Public Event Col_SelRow(ByVal Row As DataRow)



    ''' <summary>
    ''' 当获得焦点时
    ''' </summary>
    ''' <param name="HasFocused"></param>
    ''' <remarks></remarks>
    <Description("当获得焦点时"), Browsable(True)> _
    Public Event GetFocusState(ByRef HasFocused As Boolean)
    ''' <summary>
    ''' 开始搜索
    ''' </summary>
    ''' <param name="Col_No"></param>
    ''' <param name="ID"></param>
    ''' <param name="Cancel"></param>
    ''' <remarks></remarks>
    <Description("开始搜索"), Browsable(True)> _
    Public Event GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean)

    Public Event BeforeShow(ByRef IsCancel As Boolean)
#End Region


#Region "事件实现"
    Private Sub ComBoListCtrl_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles Me.Col_Sel
        If Col_Parent IsNot Nothing Then
            Col_Parent.RE_Col_Sel(Col_No, Col_Name, ID)
        End If
    End Sub

    Private Sub ComBoListCtrl_Col_SelRow(ByVal Row As System.Data.DataRow) Handles Me.Col_SelRow
        If Col_Parent IsNot Nothing Then
            Col_Parent.RE_Col_SelRow(Row)
        End If
    End Sub



    Private Sub ComBoListCtrl_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles Me.GetSearchEvent
        If Col_Parent IsNot Nothing Then
            Col_Parent.RE_GetSearchEvent(Col_No, ID, Cancel)
        End If
    End Sub
#End Region

#Region "控件事件"


    Private Sub Cmd_ShowAll_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_ShowAll.MouseDown
        NotTop = True
        IsSelectAll = True
        GetSearch()
    End Sub



    Private Sub TimerEdit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerEdit.Tick
        TimerEdit.Enabled = False
        If SearchTimeCount = SearchCount Then
            Exit Sub
        End If
        FG_Refresh()
    End Sub

    Private Sub Cmd_Close_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_Close.MouseDown
        Col_Parent.Close()
    End Sub



#Region "按钮"
    Private Sub Cmd_Add_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_Add.MouseDown
        On_Add_ButtonClick()
    End Sub

    Private Sub Cmd_Add_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Add.VisibleChanged
        If Cmd_Add.Visible AndAlso Me.DesignMode = False AndAlso CheckRight(FormID, Add) = False Then
            Cmd_Add.Visible = False
        End If
    End Sub

    Private Sub Cmd_Del_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_Del.MouseDown
        On_Del_ButtonClick()
    End Sub


    Private Sub Cmd_Modify_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_Modify.MouseDown
        On_Modify_ButtonClick()
    End Sub

    Private Sub Cmd_Modify_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Modify.VisibleChanged
        If Cmd_Modify.Visible AndAlso Me.DesignMode = False AndAlso CheckRight(FormID, Modify) = False Then
            Cmd_Modify.Visible = False
        End If
    End Sub
#End Region



#Region "控件自己的FG"



    Private Sub Fg1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Resize
        If FG1.Rows(0).HeightDisplay = 0 Then
            ShowRowCount = 0
        Else
            ShowRowCount = Fix(FG1.Height / FG1.Rows(0).HeightDisplay) - 1
        End If
    End Sub


    Sub Fg1_ClickRow(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.ClickRow
        If FG1.RowSel > 0 Then
            Col_SelOne()
            Col_Parent.Close()
        End If
    End Sub



#End Region

#End Region

#Region "加载事件"
    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub




#End Region

#Region "添加修改按钮"
    Protected LF As PClass.BaseForm

    ''' <summary>
    ''' 添加按钮
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub On_Add_ButtonClick()
        Dim O As Windows.Forms.Control = Col_Parent
        Dim P As PClass.BaseForm
        Do Until O.Parent Is Nothing
            O = O.Parent
            If TypeOf O Is PClass.BaseForm Then
                P = O
                LF = P
                LF.ReturnId = ""
                Exit Do
            End If
        Loop
        Dim F As PClass.BaseForm = PClass.PClass.LoadModifyFormByID(FormID)
        If F IsNot Nothing Then
            With F
                .Mode = PClass.BaseForm.Mode_Enum.Add
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
            End With
            Dim VF As PClass.ViewForm
            If P IsNot Nothing Then
                VF = PClass.PClass.LoadChildForm(F, P)
            Else
                VF = PClass.PClass.LoadChildForm(F)
            End If
            AddHandler VF.ClosedX, AddressOf EditRetrun
            VF.Show()
        Else
            If LF IsNot Nothing Then
                LF.ShowErrMsg("加载窗口失败,不能添加")
            Else
                MsgBox("加载窗口失败,不能添加", MsgBoxStyle.Exclamation, MainForm.text)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 修改按钮
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub On_Modify_ButtonClick()
        If FG1.RowSel <= 0 Then Exit Sub
        Dim O As Windows.Forms.Control = Col_Parent
        Dim P As PClass.BaseForm
        Do Until O.Parent Is Nothing
            O = O.Parent
            If TypeOf O Is PClass.BaseForm Then
                P = O
                LF = P
                LF.ReturnId = ""
                Exit Do
            End If
        Loop
        Dim F As PClass.BaseForm = PClass.PClass.LoadFormIDToChild(FormID + 1, P)
        If F Is Nothing Then
            F = PClass.PClass.LoadModifyFormByID(FormID)
        End If
        If F IsNot Nothing Then
            With F
                .Mode = PClass.BaseForm.Mode_Enum.Modify
                .P_F_RS_ID = FG1.SelectItem(Col_Col_ID)
                .P_F_RS_ID2 = ""
            End With
            Dim VF As PClass.ViewForm
            If P IsNot Nothing Then
                VF = PClass.PClass.LoadChildForm(F, P)
            Else
                VF = PClass.PClass.LoadChildForm(F)
            End If
            AddHandler VF.ClosedX, AddressOf EditRetrun
            VF.Show()
        Else
            If LF IsNot Nothing Then
                LF.ShowErrMsg("加载窗口失败,不能添加")
            Else
                MsgBox("加载窗口失败,不能添加", MsgBoxStyle.Exclamation, MainForm.text)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 置空
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub On_Del_ButtonClick()
        Col_Parent.SetSearchEmpty()
        StartSearch()
    End Sub

    Protected Overridable Sub EditRetrun()
        If LF IsNot Nothing Then
            If LF.ReturnId <> "" Then
                Search = LF.ReturnId
                GetSearch()
            End If
        End If

    End Sub
#End Region








End Class
