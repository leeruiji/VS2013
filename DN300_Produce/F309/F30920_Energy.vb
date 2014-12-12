Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30920_Energy
    Private WithEvents R As New R30920_Energy()
    Private WithEvents R2 As New R30921_EnergyDate()
    Dim isLoaded As Boolean = False
    Dim Excelout As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audited)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Excelout = CheckRight(ID, ClassMain.RpCanExcelOut)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        Panel1.Visible = False
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
        Try
            GR2.Report = R2.Report
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
        '   If CK_Date.Checked = False Then
        R.Start(Excelout, DP_Start.Value.Date, Dp_End.Value.Date)
        ' Else
        ' R.Start(Dp_End.Value.Date, Dp_End.Value.Date)
        ' End If

    End Sub

    'Private Sub CK_Month_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If CK_Date.Checked Then
    '        Label_C.Visible = False
    '        Label_D.Visible = False
    '        DP_Start.Visible = False
    '    Else
    '        Label_C.Visible = True
    '        Label_D.Visible = True
    '        DP_Start.Visible = True
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

    'Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
    '    Me_Refresh()
    'End Sub
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me_Refresh()
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








#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim Goods_no As String = GR.GetSelRowCellText(0)
        If GR.SelRowNo >= 0 Then
            Date_Refresh(Goods_no)
        End If
    End Sub
#End Region





#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        'If CK_Date.Checked = False Then
        R.Start(Excelout, DP_Start.Value.Date, Dp_End.Value.Date, OperatorType.Preview)
        'Else
        '    R.Start(Dp_End.Value.Date, Dp_End.Value.Date, OperatorType.Preview)
        'End If
    End Sub
#End Region

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable = dtTable.Clone
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow)
        End If
        Dim Dr As DataRow = dt.Rows(0)
        Dim Lock As Boolean

        If ND <> DTP_sDate.Value.Date Then
            GetCL()
        End If
        ComFun.GetColValue(Dr, TB_DX_CL, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_DX_Coal, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_DX_Elec, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_RB_CL, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_RB_Gas, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_RB_RL, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_RB_Water, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_RB_ZJ, 0, "", Lock, "0.###")
        ComFun.GetColValue(Dr, TB_LuoSe, 0, "", Lock, "0")
        Dr("sDate") = DTP_sDate.Value.Date



        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow)
        End If
        Dim Dr As DataRow = dt.Rows(0)
        Dim Lock As Boolean
        ComFun.SetColValue(Dr, TB_DX_CL, 0, "", Lock, "0.###")
        ComFun.SetColValue(Dr, TB_DX_Coal, 0, "", Lock, "0.###")
        ComFun.SetColValue(Dr, TB_DX_Elec, 0, "", Lock, "0.###")
        ComFun.SetColValue(Dr, TB_RB_CL, 0, "", Lock, "0.###")
        ComFun.SetColValue(Dr, TB_RB_Gas, 0, "", Lock, "0.###")
        ComFun.SetColValue(Dr, TB_RB_RL, 0, "", True, "0.###")
        ComFun.SetColValue(Dr, TB_RB_Water, 0, "", Lock, "0.###")
        ComFun.SetColValue(Dr, TB_RB_ZJ, 0, "", True, "0.###")
        ComFun.SetColValue(Dr, TB_LuoSe, 0, "", True, "0")
        If IsDBNull(Dr("sDate")) Then
            DTP_sDate.Value = Today.AddDays(-1)
        Else
            DTP_sDate.Value = CDate(Dr("sDate")).Date
        End If
    End Sub

    Sub GetCL()

        Dim R As DtReturnMsg = Dao.CL_GetBydate(ND)
        If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
            TB_RB_ZJ.Text = FormatMoney(R.Dt.Rows(0)("SumZJ"))
            TB_RB_RL.Text = FormatMoney(R.Dt.Rows(0)("SumRL"))
            TB_LuoSe.Text = R.Dt.Rows(0)("LuoSe")
        End If
    End Sub


#Region "控件事件2"
    'Private Sub Btn_ExcelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExcelOut.Click
    '    R.ExportXLS()
    'End Sub
    'Private Sub Btn_PrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PrePrint.Click
    '    R.PrintPreview()
    'End Sub
    Private Sub R2_LoadFileCompleted() Handles R2.LoadFileCompleted
        GR2.Refresh()
    End Sub

    'Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
    '    Me_Refresh()
    'End Sub
    Private Sub Btn_Search2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search2.Click
        Me.Date_Refresh(ND)
    End Sub

    Private Sub Cmd_Close2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close2.Click
        ShowMainPanel()
    End Sub
#End Region

#Region "打印预览报表2"
    Private Sub Cmd_Preview2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview2.Click
        'If CK_Date.Checked = False Then
        R2.Start(Excelout, dtTable, OperatorType.Preview)
        'Else
        '    R.Start(Dp_End.Value.Date, Dp_End.Value.Date, OperatorType.Preview)
        'End If
    End Sub
#End Region
#End Region




    Dim dtTable As DataTable
    Dim ND As Date
    Protected Sub Date_Refresh(ByVal D As Date, Optional ByVal IsNew As Boolean = False)
        ND = D
        Dim msgTable As DtReturnMsg = Dao.Energy_GetBydate(D)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            If dtTable.Rows.Count = False OrElse IsNew Then
                Cmd_Modify2.Enabled = True
                Cmd_Audited.Enabled = False
                Cmd_UnAudit.Enabled = False
                ShowModify()
            Else
                ShowDate()
                If IsNull(dtTable.Rows(0)("IsAudited"), False) Then
                    Cmd_Modify2.Enabled = False
                    Cmd_Audited.Enabled = False
                    Cmd_UnAudit.Enabled = True
                Else
                    Cmd_Modify2.Enabled = True
                    Cmd_Audited.Enabled = True
                    Cmd_UnAudit.Enabled = False
                End If

            End If
        End If
    End Sub

    Sub ShowModify()
        CaptureFromImageToPicture(Me, Panel1)
        PanelMain.Visible = False
        Panel1.BringToFront()
        SetForm(dtTable)
        GroupBox1.Visible = False
        GroupBox2.BringToFront()
        GroupBox2.Top = (Me.Height - GroupBox2.Height) / 2
        GroupBox2.Left = (Me.Width - GroupBox2.Width) / 2
        GroupBox2.Visible = True
        Panel1.Visible = True
        GetCL()
    End Sub

    Sub ShowMainPanel()
        PanelMain.Visible = True
        Panel1.Visible = False
        Me.Me_Refresh()
    End Sub
    Sub ShowDate()
        CaptureFromImageToPicture(Me, Panel1)
        PanelMain.Visible = False
        Panel1.BringToFront()
        SetForm(dtTable)
        GroupBox2.Visible = False
        GroupBox1.BringToFront()
        GroupBox1.Top = (Me.Height - GroupBox1.Height) / 2
        GroupBox1.Left = (Me.Width - GroupBox1.Width) / 2
        GroupBox1.Visible = True
        Panel1.Visible = True
        R2.Start(Excelout, dtTable)
        GR2.Refresh()
    End Sub

    Private Sub Cmd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_OK.Click
        Dim Dt As DataTable = GetForm()
        Dim R As MsgReturn = Dao.Energy_Save(Dt)
        If R.IsOk Then
            Date_Refresh(DTP_sDate.Value.Date)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub

    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        ShowMainPanel()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Date_Refresh(Today.AddDays(-1), True)
    End Sub


    Private Sub Cmd_Modify2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify2.Click
        ShowModify()
    End Sub

    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        GR_DblClick(sender, e)
    End Sub

    Private Sub Cmd_CL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CL.Click
        ND = DTP_sDate.Value
        GetCL()
    End Sub

#Region "审核"
    Private Sub Cmd_Audited_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audited.Click
        'RunSQL("update T30920_Energy set IsAudited =1 where sDate=@sDate", "sDate", ND)
        If MsgBox("是否审核能耗表", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.Yes Then
            Dim Msg As MsgReturn = Dao.Energy_Audited(DTP_sDate.Value, 1)
            Date_Refresh(DTP_sDate.Value)
        End If
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        'RunSQL("update T30920_Energy set IsAudited =0 where sDate=@sDate", "sDate", ND)
        If MsgBox("是否反审能耗表", MsgBoxStyle.YesNo, "提示") = MsgBoxResult.Yes Then
            Dim Msg As MsgReturn = Dao.Energy_Audited(Format(DTP_sDate.Value, "yyyyMMdd"), 0)
            Date_Refresh(DTP_sDate.Value)
        End If
    End Sub
#End Region

End Class

Partial Class Dao
    Public Shared Function CL_GetBydate(ByVal D As Date) As DtReturnMsg
        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("select Isnull(sum(")
        sqlBuider.AppendLine("case when WL_Type_ID like 'GT003003%'")
        sqlBuider.AppendLine("then isnull(Cost,0)*isnull(Qty,0) else 0 end ),0) as SumZJ,")
        sqlBuider.AppendLine("Isnull(sum(")
        sqlBuider.AppendLine("case when WL_Type_ID like 'GT003003%'")
        sqlBuider.AppendLine("then 0 else isnull(Cost,0)*isnull(Qty,0) end ),0) as SumRL,isnull((select sum(CR_LuoSeBzCount) from T30000_Produce_Gd where State>0 and Date_LuoSe=@sDate),0) as LuoSe")
        sqlBuider.AppendLine("from T10050_Store_Detail D")
        sqlBuider.AppendLine("left join T10001_WL W on D.wl_ID=w.id")
        sqlBuider.AppendLine("where BillType between 20310 and 20320 and sDate=@sDate")
        Return SqlStrToDt(sqlBuider.ToString, "sDate", D)
    End Function

    Public Shared Function Energy_GetBydate(ByVal D As Date) As DtReturnMsg
        Return SqlStrToDt("select top 1 * from T30920_Energy where sDate=@sDate", "sDate", D)
    End Function

    Public Shared Function Energy_Save(ByVal Dt As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim SQL As New Dictionary(Of String, String)
        Dim P As New Dictionary(Of String, Object)
        Dim D As Date = Dt.Rows(0)("sDate")
        SQL.Add("P", "select top 1 * from T30920_Energy where sDate=@sDate")
        P.Add("sDate", D)
        Using H As New DtHelper(SQL, P)
            If H.IsOk Then
                If H.DtList("P").Rows.Count = 0 Then
                    H.DtList("P").Rows.Add(H.DtList("P").NewRow)
                    H.DtList("P").Rows(0)("sDate") = Dt.Rows(0)("sDate")
                    H.DtList("P").Rows(0)("YM") = Format(H.DtList("P").Rows(0)("sDate"), "yyyyMM")
                Else
                    If IsNull(H.DtList("P").Rows(0)("IsAudited"), False) = True Then
                        R.Msg = "日期[" & D & "]已审核反审后再修改"
                        R.IsOk = False
                        Return R
                    End If
                End If
                Dim L As New List(Of String)
                L.Add("sDate")
                L.Add("YM")
                DvUpdateToDt(Dt, H.DtList("P"), L)
                If H.UpdateAll(True).IsOk Then
                    R.IsOk = True
                Else
                    R.Msg = H.Msg
                End If
            Else
                R.Msg = H.Msg
            End If
        End Using
        Return R
    End Function


    ''' <summary>
    ''' 审核采购单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Energy_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P30920_Energy_Audited", paraMap, True)
        If R.IsOk Then
            If R.Msg.StartsWith("1") Then
                R.IsOk = True
            Else
                R.IsOk = False
            End If
            R.Msg = R.Msg.Substring(1)
        End If
        Return R
    End Function
End Class