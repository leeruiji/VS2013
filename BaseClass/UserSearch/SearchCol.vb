Imports System.ComponentModel
Imports PClass.PClass
Imports System.Windows.Forms

<System.ComponentModel.ToolboxItem(False)> _
Public Class SearchCol

    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        CB_Operator.DisplayMember = "OperatorName"
        CB_Operator.ValueMember = "OperatorValue"
        CB_Operator.DataSource = GetOperatorDt()
        CB_Operator.SelectedIndex = 0

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


#Region "自定义类"
    Public Shared Function GetOperatorDt() As DataTable
        Static Dt As DataTable = Nothing
        If Dt Is Nothing Then
            Dt = New DataTable("Operator")
            Dt.Columns.Add("OperatorName")
            Dt.Columns.Add("OperatorValue", GetType(Integer))
            AddOperatorRow(Dt, "包含(like)", BaseClass.Enum_Operator.Operator_Like_Both)
            AddOperatorRow(Dt, "等于(=)", BaseClass.Enum_Operator.Operator_Equal)
            AddOperatorRow(Dt, "不等于(<>)", BaseClass.Enum_Operator.Operator_UnEqual)
            AddOperatorRow(Dt, "大于(>)", BaseClass.Enum_Operator.Operator_More)
            AddOperatorRow(Dt, "大于等于(>=)", BaseClass.Enum_Operator.Operator_MoreOrEqual)
            AddOperatorRow(Dt, "小于(<)", BaseClass.Enum_Operator.Operator_Less)
            AddOperatorRow(Dt, "小于等于(<=)", BaseClass.Enum_Operator.Operator_LessOrEqual)
            AddOperatorRow(Dt, "在两者之间(1,2)", BaseClass.Enum_Operator.Operator_Between)
            AddOperatorRow(Dt, "前匹配(Word%)", BaseClass.Enum_Operator.Operator_Like)
            AddOperatorRow(Dt, "后匹配(%Word)", BaseClass.Enum_Operator.Operator_Like_Before)
            AddOperatorRow(Dt, "包括多个(1,2,3)", BaseClass.Enum_Operator.Operator_In)
        End If
        Return Dt.Copy
    End Function



    Private Shared Sub AddOperatorRow(ByVal Dt As DataTable, ByVal Name As String, ByVal Value As Integer)
        Dim Dr As DataRow
        Dr = Dt.NewRow
        Dr("OperatorName") = Name
        Dr("OperatorValue") = Value
        Dt.Rows.Add(Dr)
    End Sub


#End Region


#Region "属性"
    ''' <summary>
    ''' 父控件
    ''' </summary>
    ''' <remarks></remarks>
    Public ParentCol As SearchItem
    ''' <summary>
    ''' 没有被点击过的
    ''' </summary>
    ''' <remarks></remarks>
    Public IsNoChick As Boolean = False
    Public IsShow As Boolean

    Public Setting As New SearchSetting



    Public Property Value() As String
        Get
            If Setting.OperatorValue = BaseClass.Enum_Operator.Operator_Between Then
                Return TB_Value1.Text()
            Else
                If CK_PreView.Checked Then
                    Return CB_ConditionValue.Text
                Else
                    Return TB_Value.Text
                End If
            End If
        End Get
        Set(ByVal value As String)
            If Setting.OperatorValue = BaseClass.Enum_Operator.Operator_Between Then
                TB_Value1.Text = value
            Else
                If CK_PreView.Checked Then
                    Try
                        CB_ConditionValue.Text = value
                    Catch ex As Exception
                    End Try
                Else
                    TB_Value.Text = value
                End If
            End If
        End Set
    End Property

#End Region




#Region "控件事件定义"
    ''' <summary>
    ''' 保存的时候
    ''' </summary>
    ''' <param name="C">父容器</param>
    ''' <remarks></remarks>
    Public Event Save_Me(ByVal C As SearchItem)


    ''' <summary>
    ''' 当删除按钮点击的时候
    ''' </summary>
    ''' <param name="C">父容器</param>
    ''' <remarks></remarks>
    Public Event Del_Me(ByVal C As SearchItem)

    ''' <summary>
    ''' 当搜索条件名称被点击的时候
    ''' </summary>
    ''' <param name="C">父容器</param>
    ''' <remarks></remarks>
    Public Event CB_ConditionName_Change(ByVal C As SearchItem)

    ''' <summary>
    ''' 添加一个新的的
    ''' </summary>
    ''' <remarks></remarks>
    Public Event Add_Me()
#End Region


#Region "本控件事件实现"


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        RaiseEvent Del_Me(ParentCol)
    End Sub


    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        SetValue()
        RaiseEvent Add_Me()
    End Sub
    Private Sub Cmd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_OK.Click
        SetValue()
    End Sub

    Sub SetValue()
        Setting.IsPreView = CK_PreView.Checked
        Setting.IsOr = RadioOr.Checked
        Setting.SearchName = CB_ConditionName.Text

        Setting.IgnoreTime = CK_IgnoreTime.Checked
        Setting.IsSaveValue = CK_SaveValue.Checked


        Setting.OperatorValue = CB_Operator.SelectedValue
        If Setting.OperatorValue = BaseClass.Enum_Operator.Operator_Between Then
            Setting.SearchValue = TB_Value1.Text
            Setting.SearchValue2 = TB_Value2.Text
        Else
            If CK_PreView.Checked Then
                Setting.SearchValue = CB_ConditionValue.Text
            Else
                Setting.SearchValue = TB_Value.Text
            End If
            Setting.SearchValue2 = ""
        End If
        IsNoChick = True
        ReSetTitle()
        IsShow = False
        ParentCol.HideDropDown()

        RaiseEvent Save_Me(Me.ParentCol)

    End Sub


    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        ParentCol.HideDropDown()
    End Sub


    Private Sub CK_IgnoreTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_IgnoreTime.CheckedChanged
        ParentCol.IsIgnoreTime = CK_IgnoreTime.Checked
    End Sub

    ''' <summary>
    ''' 重新设置 父控件的标题
    ''' </summary>
    ''' <remarks></remarks>
    Sub ReSetTitle()
        If Setting.SearchName <> "" AndAlso Setting.SearchName <> "请选择" Then
            Dim S As String = ""
            Select Case Setting.OperatorValue
                Case Enum_Operator.Operator_Equal
                    S = ":[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_UnEqual
                    S = "不等于[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_More
                    S = "大于[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_MoreOrEqual
                    S = "大于等于[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_Less
                    S = "小于[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_LessOrEqual
                    S = "小于等于[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_Between
                    S = "在[" & Setting.SearchValue & "]和[" & Setting.SearchValue2 & "]之间"
                Case Enum_Operator.Operator_Like_Both
                    S = "包含[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_Like
                    S = "前匹配[" & Setting.SearchValue & "]"
                Case Enum_Operator.Operator_Like_Before
                    S = "后匹配[" & Setting.SearchValue & "]"

                Case Enum_Operator.Operator_In
                    S = "包括[" & Setting.SearchValue & "]"
            End Select
            ParentCol.Text = Setting.SearchName & S
            ParentCol.ToolTipText = ParentCol.Text
            If Setting.SearchValue = "" AndAlso Setting.OperatorValue <> Enum_Operator.Operator_Between Then
                ParentCol.ForeColor = Drawing.Color.Black
                ParentCol.SearchOK = False
            Else
                ParentCol.ForeColor = Drawing.Color.Blue
                ParentCol.SearchOK = True
            End If

        Else
            ParentCol.Text = ParentCol.LastText
            ParentCol.ToolTipText = ParentCol.Text
            ParentCol.ForeColor = Drawing.Color.Black
            ParentCol.SearchOK = False
        End If
    End Sub
    Private Sub CB_Operator_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Operator.SelectedIndexChanged
        If CB_Operator.SelectedValue = BaseClass.Enum_Operator.Operator_Between Then
            SC_Between.Visible = True
            SC_Between.BringToFront()
            CK_PreView.Enabled = False
        Else
            SC_Between.Visible = False
            SC_Between.SendToBack()
            CK_PreView.Enabled = True
        End If
    End Sub
    Private Sub CB_ConditionValue_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionValue.DropDown
        If ParentCol.IsNameChangeToData = False Then
            Dim B As Boolean = Me.ParentCol.SearchOK
            Me.ParentCol.SearchOK = False
            RaiseEvent CB_ConditionName_Change(ParentCol)
            Me.ParentCol.SearchOK = B
        End If
    End Sub
    Private Sub CB_ConditionName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionName.SelectedIndexChanged
        If IsNoChick = False Then
            Try
                CB_Operator.SelectedValue = DirectCast(DirectCast(CB_ConditionName.SelectedItem, System.Object), BaseClass.FindOption).Field_Operator
            Catch ex As Exception
            End Try
        End If
        If CK_PreView.Checked AndAlso ParentCol.IsNameChangeToData Then
            Dim B As Boolean = Me.ParentCol.SearchOK
            Me.ParentCol.SearchOK = False
            RaiseEvent CB_ConditionName_Change(ParentCol)
            Me.ParentCol.SearchOK = B
        End If
    End Sub

    Private Sub CK_PreView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_PreView.CheckedChanged
        If CK_PreView.Checked = False Then
            CB_ConditionValue.Visible = False
            TB_Value.Visible = True
            TB_Value.BringToFront()
            TB_Value.Text = CB_ConditionValue.Text
        Else
            CB_ConditionValue.Visible = True
            TB_Value.Visible = False
            CB_ConditionValue.BringToFront()
            CB_ConditionValue.Text = TB_Value.Text
        End If
    End Sub

    Sub RollBack()
        CK_PreView.Checked = Setting.IsPreView
        CK_IgnoreTime.Checked = Setting.IgnoreTime

        CK_SaveValue.Checked = Setting.IsSaveValue

        If Setting.IsOr Then
            RadioOr.Checked = True
            RadioAnd.Checked = False
        Else
            RadioAnd.Checked = True
            RadioOr.Checked = False
        End If

        If Setting.SearchName <> "" AndAlso Setting.SearchName <> "请选择" Then
            Try
                CB_ConditionName.Text = Setting.SearchName
            Catch ex As Exception
            End Try
        End If
        CB_Operator.SelectedValue = Setting.OperatorValue
        If Setting.SearchValue IsNot Nothing AndAlso Setting.SearchValue <> "" Then
            If Setting.OperatorValue = BaseClass.Enum_Operator.Operator_Between Then
                TB_Value1.Text = Setting.SearchValue
                TB_Value2.Text = Setting.SearchValue2
            Else
                If CK_PreView.Checked Then
                    Try
                        CB_ConditionValue.Text = Setting.SearchValue
                    Catch ex As Exception
                    End Try
                Else
                    TB_Value.Text = Setting.SearchValue
                End If
            End If
        End If

    End Sub



    Sub WhileShowMe()
        IsShow = True
    End Sub


    Sub WhileHideMe()
        If IsShow = True Then
            RollBack()
        Else
            Exit Sub
        End If
        IsShow = False
    End Sub




#End Region


    Public Class SearchSetting
        Public SearchName As String = ""
        Public SearchValue As String = ""
        Public SearchValue2 As String = ""
        Public OperatorValue As BaseClass.Enum_Operator = Enum_Operator.Operator_Equal
        Public IsOr As Boolean
        Public IsPreView As Boolean
        Public IgnoreTime As Boolean = False
        Public IsSaveSearch As Boolean = False
        Public IsSaveValue As Boolean = False

        Public Shared Function GetNullDt() As DataTable
            Dim Dt As New DataTable("T")
            Dt.Columns.Add("ID")
            Dt.Columns.Add("Name")
            Dt.Columns.Add("Line", GetType(Long))
            Dt.Columns.Add("SearchName")
            Dt.Columns.Add("IsPreView", GetType(Boolean))
            Dt.Columns.Add("IsOr", GetType(Boolean))
            Dt.Columns.Add("IgnoreTime", GetType(Boolean))
            Dt.Columns.Add("IsSaveValue", GetType(Boolean))
            Dt.Columns.Add("OperatorValue", GetType(Long))
            Dt.Columns.Add("SearchValue")
            Dt.Columns.Add("SearchValue2")
            Return Dt
        End Function

        Sub LoadFromDr(ByVal Row As DataRow, Optional ByVal MustSaveValue As Boolean = False)
            SearchName = Row("SearchName")
            IsPreView = IsNull(Row("IsPreView"), False)
            IsOr = Row("IsOr")
            IgnoreTime = Row("IgnoreTime")
            IsSaveValue = Row("IsSaveValue")
            OperatorValue = Row("OperatorValue")
            If IsSaveValue OrElse MustSaveValue Then
                SearchValue = IsNull(Row("SearchValue"), "")
                SearchValue2 = IsNull(Row("SearchValue2"), "")
            End If
        End Sub

        Sub SetToDr(ByVal Dr As DataRow, Optional ByVal MustSetValue As Boolean = False)
            Dr("SearchName") = SearchName
            Dr("IsPreView") = IsPreView
            Dr("IsOr") = IsOr
            Dr("IgnoreTime") = IgnoreTime
            Dr("IsSaveValue") = IsSaveValue
            Dr("OperatorValue") = OperatorValue
            If IsSaveValue OrElse MustSetValue Then
                Dr("SearchValue") = SearchValue
                Dr("SearchValue2") = SearchValue2
            Else
                Dr("SearchValue") = ""
                Dr("SearchValue2") = ""
            End If
        End Sub
    End Class

End Class
