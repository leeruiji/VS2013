Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F20905_Store_Day
    Private WithEvents R As New R20905_Store_Day
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
        CB_ConditionName2.ComboBox.DataSource = Dao.StoreDay_GetConditionNames()
        MP_sDate.Value = New Date(Today.Year, Today.Month, 1).AddMonths(-1)
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
        Dim D As ENum_Disable
        D = TMI_aEnable.Tag
        R.SetOption(MP_sDate.Value, MP_sDate.Value.Date.AddMonths(1).AddSeconds(-1), D, GetFindOtions.FoList)
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

    Private Sub TMI_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_All.Click
        TMI_aEnable.Text = "全部"
        TMI_aEnable.Tag = 2
    End Sub

    Private Sub TMI_Enable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Enable.Click
        TMI_aEnable.Text = "不显示禁用"
        TMI_aEnable.Tag = 0
    End Sub

    Private Sub TMI_Disble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMI_Disble.Click
        TMI_aEnable.Text = "只显示禁用"
        TMI_aEnable.Tag = 1
    End Sub






    'Private Sub CB_ConditionName2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionName2.SelectedIndexChanged

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
            Dim F As New F20910_JXC(MP_sDate.Value, MP_sDate.Value.Date.AddMonths(1).AddSeconds(-1), Goods_no, Goods_Name)
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

        Dim F As BaseForm = LoadFormIDToChild(10003, Me)

        With F
            .P_F_RS_ID = "GT003"
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
        Dim F As BaseForm = LoadFormIDToChild(10004, Me)
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


    Private Sub MP_sDate_ValueChange(ByVal Value As System.DateTime) Handles MP_sDate.ValueChange
        Me.Me_Refresh()
    End Sub
End Class


Public Class R20905_Store_Day

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R20905_Store_Day.grf"



    Dim FirstDate As Date
    Dim LastDate As Date
    Dim Disable As ENum_Disable
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal iDisable As ENum_Disable, ByVal Olist As List(Of FindOption))
        FirstDate = startDate
        LastDate = endDate
        Disable = iDisable
        Me.OList = Olist
        Ln = Ln + 1
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.StoreDay_Get(FirstDate, LastDate, Disable, OList)
            If msg.IsOk Then
                If IsLoaded = False Then
                    dtGoods = msg.Dt
                    IsLoaded = True
                Else
                    If dtGoods.Rows.Count < msg.Dt.Rows.Count Then
                        dtGoods = msg.Dt
                    End If
                End If
                Dt_List = msg.Dt
                LF = Ln
                Dt_Header(1) = New DataTable("T")
                Me.DoOperator = _operator
                If _operator = OperatorType.LoadFile Then
                    Me.LoadReport()
                Else
                    Me.DoWork()
                End If
            Else
                MsgBox(msg.Msg)
            End If
        Else
            Me.DoOperator = _operator
            Me.DoWork()
        End If
    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao


    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StoreDay_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品编号"
        fo.DB_Field = "WL_NO"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品名称"
        fo.DB_Field = "WL_Name"
        foList.Add(fo)



        Return foList
    End Function


    Public Shared Function StoreDay_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal isDisable As ENum_Disable, ByVal Olist As List(Of FindOption)) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)



        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("select wl_id, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN BillType between 20000 and 20010 THEN StoreINorOut*Qty ELSE 0.0 END))) AS PurQty, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN BillType between 20000 and 20010 THEN StoreINorOut*Qty * Cost ELSE 0.0 END))) AS PurAmount,")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN BillType between 20300 and 20320 THEN StoreINorOut*Qty ELSE 0.0 END))) AS LLQty, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN BillType between 20300 and 20320 THEN StoreINorOut*Qty * Cost ELSE 0.0 END))) AS LLAmount,")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN BillType = 20400 THEN Qty ELSE 0.0 END))) AS AdjustQty, ")
        sqlBuider.AppendLine("SUM(Convert(decimal(18,2),(CASE WHEN BillType = 20400 THEN Qty * Cost ELSE 0.0 END))) AS AdjustAmount")
        sqlBuider.AppendLine("INTO #oi FROM dbo.T10050_Store_Detail(NOLOCK) WHERE (BillType > 10013)")
        sqlBuider.AppendLine("and sDate between @StartDate and @EndDate group by wl_id")
        sqlBuider.AppendLine("select wl_id,SUM(Qty*StoreINorOut) AS EndQty   INTO #E  from dbo.T10050_Store_Detail(NOLOCK) ")
        sqlBuider.AppendLine("where (BillType > 10013) and  sDate > @EndDate   group by wl_id")
        sqlBuider.AppendLine("select W.WL_Type_ID, GoodsType_Name,W.WL_Name,WL_Spec,WL_Unit,W.WL_No  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(PurQty,0)-Isnull(LLQty,0)+Isnull(AdjustQty,0) as StartQty  ,")
        sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0)-Isnull(PurQty,0)-Isnull(LLQty,0)+Isnull(AdjustQty,0))*isnull(WL_Cost,0) as StartAmount  ,")
        sqlBuider.AppendLine("Isnull(PurQty,0) as PurQty  ,")
        sqlBuider.AppendLine("Isnull(PurAmount,0) as PurAmount  ,")
        sqlBuider.AppendLine("Isnull(LLQty,0) as LLQty  ,")
        sqlBuider.AppendLine("Isnull(LLAmount,0) as LLAmount  ,")
        sqlBuider.AppendLine("Isnull(LLQty,0)-Isnull(AdjustQty,0) as LLAdjustQty  ,")
        sqlBuider.AppendLine("(Isnull(LLQty,0)-Isnull(AdjustQty,0))*isnull(WL_Cost,0) as LLAdjustAmount  ,")
        sqlBuider.AppendLine("Isnull(AdjustQty,0) as AdjustQty  ,")
        sqlBuider.AppendLine("Isnull(AdjustAmount,0) as AdjustAmount  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0)+Isnull(AdjustQty,0) as EndAdjustQty ,")
        sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0)+Isnull(AdjustQty,0))*isnull(WL_Cost,0) as EndAdjustAmount ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0)-Isnull(EndQty,0) as EndQty ,")
        sqlBuider.AppendLine("(Isnull(WL_Qty,0)-Isnull(EndQty,0))*isnull(WL_Cost,0) as EndAmount ,")
        sqlBuider.AppendLine("isnull(WL_Cost,0) Cost  ,")
        sqlBuider.AppendLine("Isnull(WL_Qty,0) as WL_Qty from  T10001_WL   W (NOLOCK) ")
        sqlBuider.AppendLine("left join #oi  oi On Oi.wl_id=w.id")
        sqlBuider.AppendLine("left join #E E On E.wl_id=w.id")
        sqlBuider.AppendLine("left join V10000_GoodsType T (NOLOCK) on GoodsType_ID=WL_Type_ID ")



        'If Olist.Count > 0 Then
        '  BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para)
        sqlBuider.Append(" where 1=1 ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        Select Case isDisable
            Case ENum_Disable.Disable
                sqlBuider.Append(" and WL_Disable=0 ")
            Case ENum_Disable.Enable
                sqlBuider.Append(" and WL_Disable=1 ")
        End Select

        sqlBuider.Append(" order by w.WL_Type_ID,WL_NO  ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)
        'Else
        '    para.Add("@Disable", isDisable)
        '    Return PClass.PClass.SqlStrToDt("F20900_Store_Summary", para, True)
        'End If
    End Function

End Class


#End Region

