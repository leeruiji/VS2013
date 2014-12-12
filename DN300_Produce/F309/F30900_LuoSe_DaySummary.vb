Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30900_LuoSe_DaySummary
    Private WithEvents R As New R30900_LuoSe_DaySummary
    Dim isLoaded As Boolean = False
    Dim Excelout As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        'Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
        Excelout = CheckRight(ID, ClassMain.RpCanExcelOut)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        'CB_ConditionName1.ComboBox.DisplayMember = "Field"
        'CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionName1.ComboBox.DataSource = Dao.StoreSummary_GetConditionNames()
        'CB_ConditionName2.ComboBox.DisplayMember = "Field"
        'CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionName2.ComboBox.DataSource = Dao.StoreSummary_GetConditionNames()
        DP_Start.Value = New Date(Now.Year, Now.Month, 1).Date
        Dp_End.Value = Today
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
        If CK_Date.Checked = False Then
            R.Start(Excelout, DP_Start.Value.Date, Dp_End.Value.Date, TSC_Client.IDAsInt, TSC_BZ.IDAsInt)
        Else
            R.Start(Excelout, Dp_End.Value.Date, Dp_End.Value.Date, TSC_Client.IDAsInt, TSC_BZ.IDAsInt)
        End If

    End Sub

    Private Sub CK_Month_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CK_Date.CheckStateChanged
        If CK_Date.Checked Then
            Label_C.Visible = False
            Label_D.Visible = False
            DP_Start.Visible = False
        Else
            Label_C.Visible = True
            Label_D.Visible = True
            DP_Start.Visible = True
        End If
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
        Return oList
    End Function

    Private Sub TSC_Client_Col_Sel(ByVal Col_No As System.String, ByVal Col_Name As System.String, ByVal ID As System.String) Handles TSC_Client.Col_Sel
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZ.SearchID = ID
        Me_Refresh()
    End Sub


    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0
    End Sub

    Private Sub TSC_BZ_Col_Sel(ByVal Col_No As System.String, ByVal Col_Name As System.String, ByVal ID As System.String) Handles TSC_BZ.Col_Sel
        Me_Refresh()
    End Sub

#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        'Dim Goods_no As String = GR.GetSelRowCellText(1)
        'If GR.SelRowNo >= 0 Then
        '    Dim F As New F40220_JXC(Me.DP_Start.Value.Date, Me.DP_End.Value.Date, Goods_no)
        '    F.ID = 40220
        '    Dim tabItem As TabItem = PClass.PClass.LoadChildTab(F)
        '    tabItem.Text = F.Title
        'End If
    End Sub
#End Region





#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        If CK_Date.Checked = False Then
            R.Start(Excelout, DP_Start.Value.Date, Dp_End.Value.Date, TSC_Client.IDAsInt, TSC_BZ.IDAsInt, OperatorType.Preview)
        Else
            R.Start(Excelout, Dp_End.Value.Date, Dp_End.Value.Date, TSC_Client.IDAsInt, TSC_BZ.IDAsInt, OperatorType.Preview)
        End If
    End Sub
#End Region



End Class