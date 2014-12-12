Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F22910_JXC
    Private WithEvents R As New R22910_JXC
    Dim dateStart As New Date(Today.Year, Today.Month, 1)
    Dim dateEnd As New Date(Today.Year, Today.Month, Today.Day)

    Dim isLoaded As Boolean = False
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal _WL_No As String, ByVal _wlName As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        dateStart = StartDate
        dateEnd = EndDate
        Me.WL_NO = _WL_No
        Me.WL_Name = _wlName
        Me.Cmd_ChooseWL.Text = _wlName
        Me.Cmd_ChooseWL.Checked = True
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        '  Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name


        CB_ConditionName1.ComboBox.DisplayMember = "BillName"
        CB_ConditionName1.ComboBox.ValueMember = "BillType"
        CB_ConditionName1.ComboBox.DataSource = ComFun.JXC_GetBillTypeList_kitchen

        '   End If

        CB_ConditionName2.ComboBox.DisplayMember = "Field"
        CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        CB_ConditionName2.ComboBox.DataSource = Dao.JXC_GetConditionNames()

        DP_Start.Value = dateStart
        DP_End.Value = dateEnd


        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        Me_Refresh()
        isLoaded = True
        ' Dim T As New Threading.Thread(AddressOf Get_Goods)
        '  T.Start()
    End Sub


    Protected Sub Me_Refresh()
        R.SetOption(GetFindOtions)
        R.Start()
    End Sub

    'Protected Sub Me_Refresh()
    '    Dim msg As DtReturnMsg = Dao.JXC_Get(GetFindOtions)
    '    If msg.IsOk Then
    '        If isLoaded = False Then
    '            dtGoods = msg.Dt
    '        End If
    '        dtCurrent = msg.Dt
    '        R.Start(dtCurrent)
    '    End If
    'End Sub




#Region "控件事件"
    'Private Sub Btn_ExcelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExcelOut.Click
    '    R.ExportXLS()
    'End Sub
    'Private Sub Btn_PrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PrePrint.Click
    '    R.PrintPreview()
    'End Sub
    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"


    Private Sub Cb_ConditionValue2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cb_ConditionValue2.DropDown
        Dim ValueList As New List(Of Object)
        Dim o As Object
        If Not R.dtGoods Is Nothing AndAlso R.dtGoods.Rows.Count > 0 AndAlso CB_ConditionName2.ComboBox.SelectedIndex > 0 Then
            For Each dr As DataRow In R.dtGoods.Select("", CB_ConditionName2.ComboBox.SelectedValue)
                o = dr(CB_ConditionName2.ComboBox.SelectedValue)
                If Not ValueList.Contains(o) AndAlso o IsNot Nothing AndAlso o IsNot DBNull.Value AndAlso o <> "" Then
                    ValueList.Add(o)
                End If
            Next
            Cb_ConditionValue2.ComboBox.DataSource = ValueList
        End If
    End Sub

    Private Sub DDC_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDC_All.Click
        DDB_Show.Text = DDC_All.Text
        DDB_Show.Tag = 2
    End Sub

    Private Sub DDC_Enable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDC_Enable.Click
        DDB_Show.Text = DDC_Enable.Text
        DDB_Show.Tag = 0
    End Sub

    Private Sub DDC_Disble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDC_Disble.Click
        DDB_Show.Text = DDC_Disble.Text
        DDB_Show.Tag = 1
    End Sub



    'Private Sub CB_ConditionName2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged

    'End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim sqlbuider As New StringBuilder("")
        Dim goodsCount As Integer = 0
        fo = New FindOption

        fo.DB_Field = "sDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)

        If WL_NO <> "" Then
            fo = New FindOption
            fo.DB_Field = "WL_NO"
            fo.Value = WL_NO
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If CB_ConditionName2.ComboBox.SelectedIndex > 0 AndAlso Not Cb_ConditionValue2.Text = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
            fo.Value = Cb_ConditionValue2.Text
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If



        If CB_ConditionName1.ComboBox.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "BillType"
            fo.Value = CB_ConditionName1.ComboBox.SelectedValue.ToString
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If TSC_Supplier.IDAsInt <> 0 Then
            fo = New FindOption
            fo.DB_Field = "Supplier_Id"
            fo.Value = TSC_Supplier.IDAsInt
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        If Val(DDB_Show.Tag) < 2 Then
            fo = New FindOption
            fo.DB_Field = "WL_Disable"
            fo.Value = DDB_Show.Tag
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If








        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub






#End Region

#Region "商品选择"

    Dim WL_ID As Integer = 0
    Dim WL_NO As String = ""
    Dim WL_Name As String = ""

    Private Sub Cmd_ChooseWL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_ChooseWL.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Cmd_ChooseWL.Text = "选择商品"
            WL_ID = 0
            WL_NO = ""
            WL_Name = ""
            Cmd_ChooseWL.Checked = False
            Me_Refresh()
        Else
            ShowGoodsSel()
        End If
    End Sub
    Protected Sub ShowGoodsSel()
        Dim F As BaseForm = LoadFormIDToChild(22002, Me)
        If F Is Nothing Then ShowErrMsg("加载窗口失败!") : Exit Sub

        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = WL_NO
            .IsSel = True
            Me_Refresh()
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoods
        VF.Show()
    End Sub

    Protected Sub SetGoods()
        If Not Me.ReturnObj Is Nothing Then
            Dim dr As DataRow = ReturnObj
            WL_ID = IsNull(dr("ID"), 0)
            WL_NO = IsNull(dr("WL_No"), "")
            WL_Name = IsNull(dr("WL_Name"), "")
            If WL_ID <> 0 Then
                Cmd_ChooseWL.Checked = True
                Cmd_ChooseWL.Text = WL_NO & "*" & WL_Name
            Else
                Cmd_ChooseWL.Checked = False
            End If
            Me_Refresh()
        End If
        Me.ReturnObj = Nothing
    End Sub

#End Region

#Region "双击行调出单据"
    Private Sub Fg_JXC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim BillTYpe As Integer = GR.GetSelRowCellText(1)
        Dim BillName As String = GR.GetSelRowCellText(3)
        Dim _Id As String = GR.GetSelRowCellText(2)
        '   BaseClass.ComFun.ShowBill(BillName, _Id, Me)
        Dim f As BaseForm = BaseClass.ComFun.ShowBill(BillTYpe, _Id, Me)
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        AddHandler VF.ClosedX, AddressOf ShowBillReturn
        VF.Show()
    End Sub

    Protected Sub ShowBillReturn()
        If Not Me.ReturnId Is Nothing AndAlso Me.ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub

#End Region

#Region "打印预览报表"


    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        R.Start(OperatorType.Preview)
    End Sub
#End Region



End Class

Partial Friend Class Dao

   


End Class