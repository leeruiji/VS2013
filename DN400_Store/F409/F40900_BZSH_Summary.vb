Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40900_BZSH_Summary
    Private WithEvents R As New R40900_BZSH_Summary(CheckRight(40900, ClassMain.RpCanExcelOut))
    Dim isLoaded As Boolean = False
    Dim Excelout As Boolean
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        Control_CheckRight(ID, ClassMain.RpCanExcelOut, Cmd_Excel)
        'Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
        Excelout = CheckRight(ID, ClassMain.RpCanExcelOut)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load

        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Cmd_Preview.Enabled = False
        Cmd_Excel.Enabled = False

        'CB_ConditionName1.ComboBox.DisplayMember = "Field"
        'CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionName1.ComboBox.DataSource = Dao.BZSH_Summary_GetConditionNames()
        'CB_ConditionName2.ComboBox.DisplayMember = "Field"
        'CB_ConditionName2.ComboBox.ValueMember = "DB_Field"
        'CB_ConditionName2.ComboBox.DataSource = Dao.BZSH_Summary_GetConditionNames()
        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = Today
        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        CB_State.ComboBox.DisplayMember = "Field"
        CB_State.ComboBox.ValueMember = "DB_Field"
        CB_State.ComboBox.DataSource = Dao.State_GetCondition3
        CB_State.ComboBox.SelectedIndex = 1
        '  Me_Refresh()
        isLoaded = True
        LoadButton()
        ' Dim T As New Threading.Thread(AddressOf Get_Goods)
        '  T.Start()
    End Sub


    Sub SetDateValue()
        TSC_Client.SearchType = cSearchType.ENum_SearchType.Add_SQL
        TSC_Client.SearchID = "exists(select 1 from T40000_BZSH_Table where State>=0 and  BZSH_Date between '" & DP_Start.Value.ToString("yyyy-MM-dd") & "' and  '" & DP_End.Value.ToString("yyyy-MM-dd") & "' and  Client_ID=id)"
    End Sub


#Region "刷新报表"


    Protected Sub Me_Refresh()
        If Val(TSC_Client.IDValue) = 0 Then
            ShowErrMsg("请选择一个客户。")
            Exit Sub
        End If
        Cmd_Preview.Enabled = False
        Cmd_Excel.Enabled = False
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
        T.Start(TSC_Client.Text)
    End Sub


    Sub SetData()
        R.Start(Excelout)
        Cmd_Preview.Enabled = Cmd_Preview.Tag
        Cmd_Excel.Enabled = Cmd_Preview.Tag
        Label_ZL.Text = R.SumZL
        Label_Num.Text = R.SumNum
        GR.Visible = True
        Me.HideLoading()
    End Sub

    Protected Sub GetData(ByVal ClientName As String)
        Form.CheckForIllegalCrossThreadCalls = False
        R.SetOption(DP_Start.Value.Date, DP_End.Value.Date, TSC_Client.IDValue, ClientName, GetFindOtions.FoList, CB_State.Text)
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

     
        'If CB_ConditionName2.ComboBox.SelectedIndex > 0 AndAlso Not Cb_ConditionValue2.Text = "" Then
        '    fo = New FindOption
        '    fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
        '    fo.Value = Cb_ConditionValue2.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like_Both
        '    oList.FoList.Add(fo)
        'End If
        Return oList
    End Function








#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim BZSH_ID As String = GR.GetSelRowCellText(1)
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

    Private Sub Cmd_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Excel.Click
        R.Start(Excelout, OperatorType.ExportDirect)
    End Sub
#End Region


#Region "颜色选择"


    Sub LoadButton()
        Dim R As DtReturnMsg = Dao.BZSH_ColorGet
        If R.IsOk Then
            Me.R.ColorDt = R.Dt.Clone

            SetColor(R.Dt, Cmd_TP, "退胚颜色", R40900_BZSH_Summary.CTP_Sift, Dao.SiftType.TuiPei, R40900_BZSH_Summary.CTP_Color)
            SetColor(R.Dt, Cmd_FG, "返工不收费", R40900_BZSH_Summary.CFG_Sift, Dao.SiftType.FanGong, R40900_BZSH_Summary.CFG_Color)
            SetColor(R.Dt, Cmd_FK, "复刻收费", R40900_BZSH_Summary.CFK_Sift, Dao.SiftType.Normal, R40900_BZSH_Summary.CFK_Color)
            SetColor(R.Dt, Cmd_QT, "返定收费", R40900_BZSH_Summary.CQT_Sift, Dao.SiftType.Normal, R40900_BZSH_Summary.CQT_Color)
        Else

            ShowErrMsg("加载颜色失败!", True)
        End If
    End Sub

    Private Sub SetColor(ByVal DT As DataTable, ByVal C As ToolStripMenuItem, ByVal Name As String, ByVal Sift As String, ByVal T As Dao.SiftType, ByVal Color As Integer)
        Dim i As Integer
        i = Val(C.AccessibleName)
        Dim DR() As DataRow
        DR = DT.Select("ID=" & i)
        If DR.Length > 0 Then
            C.Text = IsNull(DR(0)("Name"), Name)
            C.BackColor = ColorTranslator.FromOle(IsNull(DR(0)("Color"), Color))
            Sift = IsNull(DR(0)("Sift"), Sift)
            T = IsNull(DR(0)("Type"), T)
            Color = IsNull(DR(0)("Color"), Color)
        Else
            C.Text = Name
            C.BackColor = ColorTranslator.FromOle(Color)
        End If

        DR = Me.R.ColorDt.Select("ID=" & i)
        Dim Row As DataRow
        If DR.Length > 0 Then
            Row = DR(0)
        Else
            Row = Me.R.ColorDt.NewRow
            Me.R.ColorDt.Rows.Add(Row)
            Row("ID") = i
        End If
        Row("Name") = C.Text
        Row("Sift") = Sift
        Row("Type") = T
        Row("Color") = Color
    End Sub




    Private Sub Cmd_TP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_QT.Click, Cmd_FG.Click, Cmd_TP.Click, Cmd_FK.Click
        ShowColor(sender)
    End Sub


    Sub ShowColor(ByVal C As ToolStripMenuItem)
        Color_ID = Val(C.AccessibleName)
        Dim DR() As DataRow
        DR = Me.R.ColorDt.Select("ID=" & Color_ID)
        Dim Row As DataRow
        If DR.Length > 0 Then
            Row = DR(0)
            TB_Name.Text = Row("Name")
            TB_Sift.Text = Row("Sift")
            CB_Type.SelectedIndex = Row("Type")
            Cmd_Color.BackColor = ColorTranslator.FromOle(IsNull(Row("Color"), 16777215))
        Else
            Row = Me.R.ColorDt.NewRow
            Me.R.ColorDt.Rows.Add(Row)
            Row("ID") = Color_ID
        End If
        ShowGroup()
    End Sub

    Private Sub Cme_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cme_Cancel.Click
        Panel_Color.Visible = False
        PanelMain.Enabled = True
    End Sub

    Sub ShowGroup()
        If CB_Type.SelectedIndex = -1 Then CB_Type.SelectedIndex = 0

        CaptureFromImageToPicture(Me, Panel_Color)
        Panel_Color.BringToFront()
        GroupBox_Color.Height = 268
        GroupBox_Color.Left = Panel_Color.Width / 2 - GroupBox_Color.Width / 2
        GroupBox_Color.Top = Panel_Color.Height / 2 - GroupBox_Color.Height / 2
        GroupBox_Color.Visible = True
        GroupBox_Color.BringToFront()
        Panel_Color.Visible = True
        PanelMain.Enabled = False

    End Sub


    Private Sub Cmd_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Color.Click
        ColorDialog1.Color = Cmd_Color.BackColor
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            Cmd_Color.BackColor = ColorDialog1.Color
        End If
    End Sub


    Dim Color_ID As Integer
    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        Dim r As MsgReturn = Dao.BZSH_ColorSave(Color_ID, TB_Name.Text, TB_Sift.Text, CB_Type.SelectedIndex, Cmd_Color.BackColor)
        If r.IsOk Then
            LoadButton()
            Panel_Color.Visible = False
            PanelMain.Enabled = True
        Else
            ShowErrMsg(r.Msg)
        End If
    End Sub


#End Region




   

    Private Sub Cmd_ShowHead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowHead.Click
        GR.ShowHeader = Cmd_ShowHead.Checked
    End Sub

    Private Sub Cmd_ShowFooter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowFooter.Click
        GR.ShowFooter = Cmd_ShowFooter.Checked
    End Sub

    Private Sub DP_Start_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DP_Start.ValueChanged
        SetDateValue()
    End Sub

    Private Sub DP_End_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DP_End.ValueChanged
        SetDateValue()
    End Sub
End Class

Partial Friend Class Dao

    Public Enum SiftType
        ''' <summary>
        ''' 正常
        ''' </summary>
        ''' <remarks></remarks>
        Normal = 0
        ''' <summary>
        ''' 退胚
        ''' </summary>
        ''' <remarks></remarks>
        TuiPei = 1
        ''' <summary>
        ''' 返工
        ''' </summary>
        ''' <remarks></remarks>
        FanGong = 2
    End Enum
    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function State_GetCondition3() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "送货汇总"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "外发加工汇总"
        fo.DB_Field = 0
        foList.Add(fo)


        'fo = New FindOption
        'fo.Field = "外发加工汇总"
        'fo.DB_Field = 1
        'foList.Add(fo)

        Return foList
    End Function


    Shared Function BZSH_ColorGet() As DtReturnMsg
        Return SqlStrToDt("select  * from T40900_ColorSave ")
    End Function

    Shared Function BZSH_ColorSave(ByVal ID As Integer, ByVal Name As String, ByVal Sift As String, ByVal Type As SiftType, ByVal Color As Color) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", ID)
        sqlMap.Add("T", "select top 1 * from T40900_ColorSave where Id=@ID")
        msg = SqlStrToDt(sqlMap, paraMap)
        If msg.IsOk Then
            Dim R As DataRow
            If msg.DtList("T").Rows.Count > 0 Then
                R = msg.DtList("T").Rows(0)
            Else
                R = msg.DtList("T").NewRow
                msg.DtList("T").Rows.Add(R)
                R("ID") = ID
            End If
            R("ID") = ID
            R("Name") = Name
            R("Sift") = Sift
            R("Type") = Type
            R("Color") = ColorTranslator.ToOle(Color)
            Try
                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = "保存成功"
            Catch ex As Exception
                returnMsg.IsOk = False
                returnMsg.Msg = ex.ToString
            End Try
        Else
            returnMsg.Msg = msg.Msg
        End If
        Return returnMsg
    End Function


End Class