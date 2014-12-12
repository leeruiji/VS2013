Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F26900_Store_Summary
    Private WithEvents R As New R26900_Store_Summary
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        'Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name

        CB_ConditionName2.ComboBox.DisplayMember = "Field"
        CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        CB_ConditionName2.ComboBox.DataSource = Dao.StoreSummary_GetConditionNames()
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
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
        R.SetOption(DP_Start.Value.Date, DP_End.Value.Date, GetFindOtions.FoList)
        R.Start()
    End Sub




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

    'Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
    '    Me_Refresh()
    'End Sub
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
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

    'Private Sub CB_ConditionName2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged

    'End Sub
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

    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me_Refresh()
    End Sub


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

        'fo.DB_Field = "StartDate"
        'fo.Value = DP_Start.Value.Date

        'fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
        'oList.FoList.Add(fo)

        'fo.DB_Field = "EndDate"
        'fo.Value = DP_Start.Value.Date
        'fo.Field_Operator = Enum_Operator.Operator_LessOrEqual
        'oList.FoList.Add(fo)

        If CB_ConditionName1.ComboBox.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "BillType"
            fo.Value = CB_ConditionName1.ComboBox.SelectedValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Me.TypeID <> "" Then
            fo.DB_Field = "WL_Type_ID"
            fo.Value = TypeID
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If Me.WL_NO <> "" Then
            fo.DB_Field = "WL_NO"
            fo.Value = WL_NO
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








        If CB_ConditionName2.ComboBox.SelectedIndex > 0 AndAlso Not Cb_ConditionValue2.Text = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
            fo.Value = Cb_ConditionValue2.Text
            fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If

        Return oList
    End Function








#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim Goods_no As String = GR.GetSelRowCellText(1)
        Dim Goods_Name As String = GR.GetSelRowCellText(2)
        If GR.SelRowNo >= 0 Then
            Dim F As New F26910_JXC(Me.DP_Start.Value.Date, Me.DP_End.Value.Date, Goods_no, Goods_Name)
            F.ID = 20910
            Dim tabItem As TabItem = PClass.PClass.LoadChildTab(F)
            tabItem.Text = F.Title
        End If
    End Sub
#End Region

#Region "选择分类"
    Dim TypeID As String = ""
    Dim TypeName As String = ""
    Protected Sub ShowGoodsTypeSel()

        Dim F As BaseForm = LoadFormIDToChild(26010, Me)

        With F
            .P_F_RS_ID = "MT001"
            .P_F_RS_ID2 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoodsType
        VF.Show()
    End Sub


    Private Sub Cmd_ChooseType_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cmd_ChooseType.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Cmd_ChooseType.Text = "选择分类"
            TypeID = ""
            TypeName = ""
            Cmd_ChooseType.Checked = False
            Me_Refresh()
        Else
            ShowGoodsTypeSel()
        End If
    End Sub

    Protected Sub SetGoodsType()
        If Not Me.ReturnObj Is Nothing AndAlso Me.ReturnId <> "" Then
            Cmd_ChooseType.Checked = True
            Me.TypeID = Me.ReturnId
            Me.TypeName = Me.ReturnObj
            Cmd_ChooseType.Text = TypeName
            Me_Refresh()
        Else
            Cmd_ChooseWL.Checked = False
        End If
        Me.ReturnObj = Nothing
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
        Dim F As BaseForm = LoadFormIDToChild(26002, Me)
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

#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        R.Start(OperatorType.Preview)
    End Sub
#End Region



End Class

