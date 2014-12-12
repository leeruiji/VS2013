Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R10025_BZC_Report

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R40930_CPDay.grf"


    Dim Client_ID As Integer
    Dim Client_Name As String = ""
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As OptionList
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False
    Public SumZL As Double
    Public SumNum As Integer
    Public SumXiaDan As Integer
    Dim FirstDate As Date
    Dim LastDate As Date
    Public Title As String
    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal Title As String, ByVal Olist As OptionList)
        Me.FirstDate = startDate
        Me.LastDate = endDate
        Me.Title = Title
        Me.OList = Olist
        Ln = Ln + 1
        Dim msg As DtReturnMsg = Dao.CPRK_Report_GetByOption(Olist)
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
            Dt_List.Columns.Add("StateName")
            Dim sumQty As Integer = 0
            Dim sumPB As Double = 0
            Dim sumXD As Integer = 0
            For Each dr As DataRow In Dt_List.Rows
                dr("StateName") = BaseClass.ComFun.GetProduceStateName(IsNull(dr("State"), Enum_ProduceState.AddNew))
                sumQty += IsNull(dr("CPRK_Qty"), 0)
                sumPB += IsNull(dr("Remain_qty"), 0)
                sumXD += IsNull(dr("CR_LuoSeBzCount"), 0)
                If IsNull(dr("ClientBzc"), "") <> "" Then
                    dr("ClientBzc") = dr("ClientBzc") & "#"
                End If
                If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
                    dr("BZ_No") = ""
                End If
                If IsNull(dr("IsFD"), False) = True AndAlso IsNull(dr("BzcMsg"), "") = "" Then
                    dr("BzcMsg") = "返定"
                Else
                    If IsNull(dr("BzcMsg"), "") = "" Then

                        dr("BzcMsg") = dr("ClientBzc") & dr("BZC_Name") & vbCrLf & "GY-" & Format(IsNull(dr("BZc_No"), ""), "000000") & dr("BZC_PF")
                    Else
                        dr("BzcMsg") = dr("BzcMsg") '.ToString.Replace(vbCrLf, "")
                    End If
                End If
            Next
            SumNum = sumQty
            SumZL = sumPB
            SumXiaDan = sumXD
            LF = Ln
            Dim dtHeader As New DataTable("T")
            dtHeader.Columns.Add("Date_FormTo")
            dtHeader.Columns.Add("Title")
            Dim drH As DataRow = dtHeader.NewRow
            drH("Date_FormTo") = FirstDate.ToString("yyyy-MM-dd") & "到" & LastDate.ToString("yyyy-MM-dd")
            drH("Title") = Title

            dtHeader.Rows.Add(drH)
            Dt_Header(1) = dtHeader

        End If
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        Me.DoOperator = _operator
        If Me.DoOperator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoWork()
        End If
    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao

    Public Const SQL_Report_Get_CPRK As String = "select p.GH,Remain_qty,isFD,BzcMsg,p.State,p.PB_User,ClientBzc,p.Date_KaiDan,p.Date_PeiBu,CR_LuoSeBzCount,CPRK_Qty,Client_No,Store_CPRK, C.Client_Name,BZ_No,BZ_Name ,BZC_No,BZC_Name,BZ_Spec,CPRK_User from T30000_Produce_Gd P left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join (select GH,sum(Qty) as Remain_qty from  T30002_CPRK group by Gh ) R on r.gh=p.gh "

    ''' <summary>
    ''' 按条件获取胚布入库单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CPRK_Report_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Report_Get_CPRK)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        If oList.OrderBy = "" Then
            sqlBuider.Append(" order by p.GH ")
        Else
            sqlBuider.Append(" order by " & oList.OrderBy)
        End If
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function



End Class


#End Region


