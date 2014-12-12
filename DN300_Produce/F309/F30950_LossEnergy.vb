Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30950_LossEnergy
    Private WithEvents R As New R30950_LossEnergy()
    Dim isLoaded As Boolean = False
    Dim Excelout As Boolean = False
    Dim dtTable As DataTable
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)


        Excelout = CheckRight(ID, ClassMain.RpCanExcelOut)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        Panel1.Visible = False
        FormCheckRight()
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

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.LossEnergy_GetByOption(GetFindOtions)
        If msg.IsOk Then
            msg.Dt.Columns.Add("StateName", GetType(String))
            dtTable = msg.Dt
            For Each dr As DataRow In Me.dtTable.Rows
                dr("StateName") = BaseClass.ComFun.GetProduceStateName(IsNull(dr("State"), Enum_ProduceState.AddNew))
            Next
            R.Start(Excelout, DP_Start.Value.Date, Dp_End.Value.Date, dtTable)
        End If
    End Sub



#Region "控件事件"

    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub

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
        fo.DB_Field = "Date_CPLR"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = Dp_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)


        'fo = New FindOption
        'fo.DB_Field = "Old_PB"
        'fo.Value = 0
        'fo.Field_Operator = Enum_Operator.Operator_More
        'oList.FoList.Add(fo)


        If Val(CB_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = " P.Client_ID"
            fo.Value = CB_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If TB_GH.Text <> "" Then
            fo = New FindOption
            fo.DB_Field = "P.GH"
            fo.Value = TB_GH.Text
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = " P.BZ_ID"
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If CB_Compare.ComboBox.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "MAX(ID_Index)"
            fo.Value = TB_Loss.Text
            fo.Field_Operator = CB_Compare.SelectedItem.Field_Operator
            'fo.SQL = "exists (select 1 from T40101_PBRK_List  Where W.List_Line =St.List_Line and W.Work_No =st.Work_No Group by List_Line,Work_No having MAX(ID_Index))"
            'fo.Sign = "MAX(ID_Index)"
            oList.FoList.Add(fo)
        End If

        Return oList
    End Function

#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim Bill_ID As String = GR.GetSelRowCellText(0)
        If GR.SelRowNo >= 0 Then
            Dim F As New F30201_CPZL_Msg(Bill_ID)
            With F
                .Mode = Mode_Enum.Modify
                .P_F_RS_ID = ""
                .P_F_RS_ID2 = ""
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            VF.Show()
        End If
    End Sub
#End Region


#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        R.Start(Excelout, DP_Start.Value.Date, Dp_End.Value.Date, dtTable, OperatorType.Preview)
    End Sub


    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        R.Start(Excelout, DP_Start.Value.Date, Dp_End.Value.Date, dtTable, OperatorType.Print)
    End Sub


#End Region

End Class

Partial Class Dao


    'Public Const SQL_GetGS As String = "SELECT L.GH, C.Client_Name,GD.Client_ID, BZ.BZ_Name, BZC.BZC_Name,BZC.BZC_No, SUM(L.PB) AS PB, SUM(ISNULL(L.Old_PB, L.PB)) AS Old_PB ,Count(*) as Qty  FROM T40101_PBRK_List L LEFT OUTER JOIN  T40100_PBRK_Table T ON T.ID = L.ID LEFT OUTER JOIN  T30000_Produce_Gd GD ON L.GH = GD.GH LEFT OUTER JOIN T10110_Client C ON C.ID = GD.Client_ID LEFT OUTER JOIN T10002_BZ BZ ON T.BZ_ID = BZ.ID LEFT OUTER JOIN T10003_BZC BZC ON BZC.ID = GD.BZC_ID "
    Public Const SQL_GetLossEnergy As String = "select P.ZhiTong,P.JiaZhong,SG.SGGY_Name,SG.SGGY_GSD,P.GH,Date_CPLR,P.state,PB_CountSum,BzcMsg, C.Client_Name,BZ_Name ,BZ_No ,BZC_No,BZC_Name,Count(L.ID) AS CP_CountSum ,P.PB_ZLSum ,sum (L.CP) as CPZL  from T30000_Produce_Gd P LEFT JOIN T40101_PBRK_List L ON L. GH = p.GH  and CP<>0  and ISNULL(P .Date_CPLR,0) <>0 left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T10035_SGGY SG on SG.ID =P . SG_ID     "
    'Public Shared Function PB_Get(ByVal StartDate As Date, ByVal EndDate As Date) As DtReturnMsg
    '    Dim r As New DtReturnMsg
    '    Dim para As New Dictionary(Of String, Object)
    '    para.Add("@sDate", StartDate)
    '    para.Add("@eDate", EndDate)

    '    Dim sqlBuider As New StringBuilder()
    '    sqlBuider.Append(SQL_GetPB)

    '    sqlBuider.Append(" Group  BY L.GH, C.Client_Name, BZ.BZ_Name, BZC.BZC_Name,BZC.BZC_No")
    '    Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    'End Function
    ''' <summary>
    ''' 按条件获取进度表列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LossEnergy_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_GetLossEnergy)
        sqlBuider.Append("  WHERE  1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append("GROUP BY P.ZhiTong,P.JiaZhong,P.GH ,P.Date_CPLR ,C.Client_Name ,P.State ,P.PB_CountSum ,P.BzcMsg ,BZ.BZ_Name ,BZC.BZC_Name,BZ.BZ_No ,BZC.BZC_No,SG.SGGY_Name,SG.SGGY_GSD,P.PB_ZLSum")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function









End Class


