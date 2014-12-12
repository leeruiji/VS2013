Imports System.Windows.Forms
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class ChooseReNew_WL
    Dim goodsTypeID As String = ""
    Dim goodsTypeName As String = ""
    Dim goodsID As String
    Dim goodsName As String = ""
    Dim WLOld_No As String
    Dim WLNew_No As String
    Dim dtGoods As DataTable

    Public Sub New(ByVal goodsTypeID As String, ByVal goodsTypeName As String, ByVal goodsID As String, ByVal goodsName As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.goodsTypeID = goodsTypeID
        Me.goodsTypeName = goodsTypeName
        Me.goodsID = goodsID
        Me.goodsName = goodsName
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    Private Sub ChooseNew_WL_Load() Handles Me.Load
        FG1.IniFormat()
        FG1.IniColsSize()
        'TB_WL_OName.Text = "[" & Me.goodsID & "]  " & Me.goodsName
        CB_ConditionName.ComboBox.DisplayMember = "Field"
        CB_ConditionName.ComboBox.ValueMember = "DB_Field"
        CB_ConditionName.ComboBox.DataSource = WL_GetConditionNames()
        TB_ConditionValue.Text = ""
        TB_ConditionValue.Focus()
        LB_WLO.Text = "[" & Me.goodsID & "]  " & Me.goodsName
        Search()
        'If IsSel Then
        '    CB_ConditionName.ComboBox.SelectedIndex = 1
        'End If
    End Sub



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        ReNew()
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


#Region "搜索工具栏"


    ''' <summary>
    ''' 查询
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Search(Optional ByVal isGetByType As Boolean = False)
        Dim MsgView As DataTable
        Dim msg As DtReturnMsg = WL_GetByOption(GetFindOption(isGetByType))
        If msg.IsOk Then
            MsgView = msg.Dt
            FG1.IniColsSize()
            FG1.FG_ColResize()
            'dtGoods = MsgView
            FG1.DtToFG(MsgView)
            'FG1.SortByLastOrder()
            'FG1.RowSetForce("WL_No", ReturnId)
        End If
    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function GetFindOption(Optional ByVal isGetByType As Boolean = False) As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        fo = New FindOption
        'fo.Value = Me.goodsTypeID
        'fo.DB_Field = "WL_Type_ID"
        fo.Value = Me.goodsTypeName
        fo.DB_Field = "GoodsType_Name"
        'fo.Field_Operator = Enum_Operator.Operator_Like
        fo.Field_Operator = Enum_Operator.Operator_Equal
        oList.FoList.Add(fo)
        If CB_ConditionName.ComboBox.SelectedItem IsNot Nothing AndAlso TB_ConditionValue.Text <> "" Then
            fo = CB_ConditionName.ComboBox.SelectedItem
            fo.Value = TB_ConditionValue.Text
            If fo.Field_Operator <> Enum_Operator.Operator_In Then fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If
        Return oList
    End Function

#End Region


    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ConditionValue.TextChanged
        Try

            If CB_ConditionName.SelectedIndex <= 0 Then
                CB_ConditionName.SelectedIndex = 1
            End If
            Search()

        Catch ex As Exception
            DebugToLog(ex)
        End Try


    End Sub

    ''' <summary>
    ''' 选择替换物料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        'TB_WL_NName.Text = FG1.SelectItem("WL_Name")
        LB_WLN.Text = "[" & FG1.SelectItem("WL_No") & "]  " & FG1.SelectItem("WL_Name")
        WLNew_No = FG1.SelectItem("WL_No")
        WLOld_No = Me.goodsID
    End Sub

    Private Sub ReNew()
        If LB_WLN.Text <> "" Then
            If MessageBox.Show("是否把[" & Me.goodsName & "]更改新化工材料[" & FG1.SelectItem("WL_Name") & "]", "确认是否替换", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim R As MsgReturn = WL_ReNew(WLOld_No, WLNew_No)
                If R.IsOk = True Then
                    'goodsID = R.Msg
                    MessageBox.Show("更改成功!", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    MessageBox.Show(R.Msg & "更改失败!", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            End If

        Else
            MessageBox.Show("请选择一个新化工材料来替换原来的化工材料！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ''' <summary>
    ''' 替换物料
    ''' </summary>
    ''' <param name="WLOld_No"></param>
    ''' <param name="WLNew_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_ReNew(ByVal WLOld_No As String, ByVal WLNew_No As String) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        Dim R As New MsgReturn
        P.Add("WL_No", WLOld_No)
        Dim S As New Dictionary(Of String, String)
        S.Add("T", "select top 1 * from T10001_WL where WL_No=@WL_No")
        Using H As New DtHelper(S, P)
            If H.IsOk Then
                If H.DtList("T").Rows.Count > 0 Then
                    If IsNull(H.DtList("T").Rows(0)("Wl_Qty"), 0) < 10 Then
                        'Dim Row As DataRow = H.DtList("T").NewRow
                        'For Each C As DataColumn In H.DtList("T").Columns
                        '    If C.ColumnName <> "ID" Then
                        '        Row(C) = H.DtList("T").Rows(0)(C)
                        '    End If
                        'Next
                        'Row("WL_No") = WLNew_No
                        'Row("WL_Cost") = 0
                        'Row("WL_Qty") = 0
                        'Row("WL_Disable") = 0
                        'H.DtList("T").Rows.Add(Row)
                        'H.Update("T", False)
                        Dim Rt As MsgReturn = H.SelectOneValue("select top 1 ID from T10001_WL where WL_No=@New_No order by ID desc", "New_No", WLNew_No)
                        Dim Rt2 As MsgReturn = H.SelectOneValue("select top 1 ID from T10001_WL where WL_No=@Old_No order by ID desc", "Old_No", WLOld_No)
                        If Rt.IsOk And Rt2.IsOk Then
                            Dim New_Id As Long = Val(Rt.Msg)
                            Dim Old_Id As Long = Val(Rt2.Msg)
                            Dim SQL As New System.Text.StringBuilder("")
                            Dim DS As New Dictionary(Of String, String)

                            P.Add("New_Id", New_Id)
                            P.Add("Old_Id", Old_Id)
                            'SQL.AppendLine("update T10001_WL set WL_NewID=@New_Id,WL_Disable=1 where id=@Old_id")

                            SQL.AppendLine("update T10005_GYList set WL_ID=@New_Id where WL_ID=@Old_Id")
                            SQL.AppendLine("update T10008_GXJ_WL set WL_ID=@New_Id where WL_ID=@Old_Id")
                            SQL.AppendLine("update T10011_BZC_PFList set WL_ID=@New_Id where WL_ID=@Old_Id")
                            SQL.AppendLine("update T10013_RB_PFList set WL_ID=@New_Id where WL_ID=@Old_Id")
                            SQL.AppendLine("update T10015_DXGYList set WL_ID=@New_Id where WL_ID=@Old_Id")
                            DS.Add("1", SQL.ToString)

                            R = H.UpdateAll(True, DS, P)
                            If R.IsOk Then
                                R.Msg = New_Id
                            End If
                        Else
                            R.IsOk = False
                            R.Msg = "物料[" & H.DtList("T").Rows(0)("WL_Name") & "]转换失败!"
                        End If
                    Else
                        R.IsOk = False
                        R.Msg = "物料[" & H.DtList("T").Rows(0)("WL_Name") & "]库存大于10,不能进行转换!"
                        'R.Msg = "物料[" & Me.goodsName & "]库存大于10,不能进行转换!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "物料已经不存在!"
                End If
            Else
                R.IsOk = False
                R.Msg = "转换失败!" & H.Msg
            End If
        End Using
        'R.IsOk = True
        'R.Msg = "已把[" & Me.goodsName & "]更改新化工材料[" & FG1.SelectItem("WL_Name") & "]"
        Return R
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function WL_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料编号"
        fo.DB_Field = "WL_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "物料名称"
        fo.DB_Field = "WL_Name"
        foList.Add(fo)

        'fo = New FindOption
        'fo.Field = "供应商"
        'fo.DB_Field = "Supplier_Name"
        'foList.Add(fo)

        'fo = New FindOption
        'fo.Field = "物料规格"
        'fo.DB_Field = "WL_Spec"
        'foList.Add(fo)

        fo = New FindOption
        fo.Field = "模糊搜索"
        fo.DB_Field = " "
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.SQL = "(WL_No %Like% or WL_Name %Like% )"
        fo.Sign = "%Like%"
        foList.Add(fo)

        Return foList
    End Function


End Class
