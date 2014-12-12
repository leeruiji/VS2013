Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40920_PBDay
    Private WithEvents R As New R40920_PBDay
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
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Cmd_Preview.Enabled = False

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
        R.Start(Excelout)
        Cmd_Preview.Enabled = Cmd_Preview.Tag
        Label_ZL.Text = R.SumZL
        Label_Num.Text = R.SumNum
        GR.Visible = True
        Me.HideLoading()
    End Sub

    Protected Sub GetData()
        R.SetOption(DP_Start.Value.Date, DP_End.Value.Date, Me.Title, GetFindOtions)
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


    Private Sub CBL_Client_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If Val(ID) <> 0 Then
            If TSC_BZ.SearchID <> ID Then
                TSC_BZ.SetSearchEmpty()
            End If
            TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
            TSC_BZ.SearchID = ID
        Else
            TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
            TSC_BZ.SearchID = 0
        End If
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
        Dim sqlbuider As New StringBuilder("")


        fo = New FindOption
        fo.DB_Field = "Date_PeiBu"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Insert(0, fo)

        fo = New FindOption
        fo.DB_Field = "State"
        fo.Value = Enum_ProduceState.PeiBu
        fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
        oList.FoList.Insert(0, fo)

        If CK_CP.Checked Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Value = Enum_ProduceState.SongHuo
            fo.Field_Operator = Enum_Operator.Operator_Less
            oList.FoList.Insert(0, fo)
        End If


        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "P.Client_ID"
            fo.Value = TSC_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "p.BZ_ID"
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If
        Return oList
    End Function








#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim BZSH_ID As String = GR.GetSelRowCellText(2)
        If BZSH_ID <> "" Then
            Dim F As New F40001_BZSH_Msg(BZSH_ID)
            With F
                .Mode = Mode_Enum.Modify
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            AddHandler VF.ClosedX, AddressOf Edit_Retrun
            VF.Show()
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




    Private Sub CK_CP_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CK_CP.CheckStateChanged
        If CK_CP.Checked Then
            Me.Title = "成品明细"
        Else
            Me.Title = "配布明细"
        End If

        Me_Refresh()
    End Sub


End Class