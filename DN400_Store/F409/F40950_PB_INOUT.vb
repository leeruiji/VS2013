Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40950_PB_INOUT
    Private WithEvents R As New R40950_PB_INOUT
    Dim startDate As Date
    Dim endDate As Date
    Dim isloaded As Boolean = False
    Dim Excelout As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()


        Excelout = CheckRight(ID, ClassMain.RpCanExcelOut)

    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name



        'CB_ConditionName1.ComboBox.DisplayMember = "Field"
        'CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionName1.ComboBox.DataSource = Dao.BZSH_Summary_GetConditionNames()
        'CB_ConditionName2.ComboBox.DisplayMember = "Field"
        'CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionName2.ComboBox.DataSource = Dao.BZSH_Summary_GetConditionNames()
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = GetTime.AddHours(-8).Date
        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        Me_Refresh()
        isLoaded = True
    End Sub



#Region "刷新报表"


    Protected Sub Me_Refresh()
        Static T As Threading.Thread
        If T IsNot Nothing Then
            If T.IsAlive Then
                Try
                    T.Abort()
                Catch ex As Exception
                End Try
            End If
        End If
        T = New Threading.Thread(AddressOf GetData)
        Me.ShowLoading(MeIsLoad)
        GR.Visible = False
        T.Start()
    End Sub


    Sub SetData()
        R.Start()
        'Cmd_Preview.Enabled = Cmd_Preview.Tag
       
        GR.Visible = True
        Me.HideLoading()
    End Sub

    Protected Sub GetData()
        startDate = DP_Start.Value.Date
        endDate = DP_End.Value.Date
        R.SetOption(DP_Start.Value.Date, DP_End.Value.Date, GetFindOtions)
        Me.Invoke(New DRunSub(AddressOf SetData))
    End Sub

#End Region


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

    'Private Sub CB_ConditionName2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim ValueList As New List(Of Object)
    '    Dim o As Object
    '    If Not R.dtGoods Is Nothing AndAlso R.dtGoods.Rows.Count > 0 AndAlso CB_ConditionName2.ComboBox.SelectedIndex > 0 Then
    '        For Each dr As DataRow In R.dtGoods.Select("", CB_ConditionName2.ComboBox.SelectedValue)
    '            o = dr(CB_ConditionName2.ComboBox.SelectedValue)
    '            If Not ValueList.Contains(o) AndAlso o IsNot Nothing AndAlso o IsNot DBNull.Value AndAlso o <> "" Then
    '                ValueList.Add(o)
    '            End If
    '        Next
    '        Cb_ConditionValue2.ComboBox.DataSource = ValueList
    '    End If
    'End Sub


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

        fo = New FindOption
        fo.DB_Field = "Disable"
        fo.Value = False
        fo.Field_Operator = Enum_Operator.Operator_Equal
        oList.FoList.Add(fo)

        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "Client_ID"
            fo.Value = TSC_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        Return oList
    End Function



#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim Client_ID As String = GR.GetSelRowCellText(1)
        If Client_ID <> "" Then
            If GR.SelRowNo >= 0 Then
                Dim F As New F40951_PB_INOUT_Msg(Client_ID, startDate, endDate)
                F.ID = 40951
                F.Mode = Mode_Enum.Modify
                Dim tabItem As TabItem = PClass.PClass.LoadChildTab(F)
                tabItem.Text = F.Title
            End If
        End If
    End Sub

    Sub Edit_Retrun()

    End Sub
#End Region




#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        R.Start(Excelout, OperatorType.Preview)
    End Sub
#End Region



End Class