Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R50000_Price_Client
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R50000_Price_Client.grf"
    Protected fileName_CK As String = "R50000_Price_Client_CK.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub StartList(ByVal ClientID As Integer, ByVal Client_Name As String, ByVal sDate As Date, ByVal eDate As Date, ByVal CK As Boolean)
        If CK = True Then
            Me.ReportFile = fileName_CK
        Else
            Me.ReportFile = fileName
        End If
        Dim R As DtReturnMsg = Dao.Client_List(ClientID, sDate, eDate)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        Dim dt As New DataTable
        dt.Columns.Add("Client_Name", GetType(String))
        dt.Columns.Add("sDate", GetType(Date))
        dt.Columns.Add("eDate", GetType(Date))
        Dim dr As DataRow = dt.NewRow
        dt.Rows.Add(dr)
        dr("Client_Name") = Client_Name
        dr("sDate") = sDate
        dr("eDate") = eDate
        Dt_Header(1) = dt
        Me.DoOperator = OperatorType.Preview
        Me.DoWork()
    End Sub



End Class
#Region "数据库交换"


Partial Friend Class Dao
    Public Const Sql_Clent_List As String = "Select A.BZC_ID,BZC_Name,BZC_No,A.BZ_ID,BZ_Name,BZ_No,Price,Price_Time ,BZC_Name+'/GY-'+right('000000'+CAST(BZC_No as Varchar(20)),6)AS BZC,PFa.Amount,Ds_Ding from" & vbCrLf & _
                                          " (select BZC_ID ,BZ_ID,max(Price)as Price,Price_Time,Ds_Ding from T50000_Price_Table T Left join  T50001_Price_List L ON T.ID=L.ID Where Client_id=@Client_id And isComfirm=1 and sDate between @sDate1 and @sDate2 Group by BZC_ID,BZ_ID,Price_Time ,Ds_Ding  having Price_Time=max(Price_Time) )A " & vbCrLf & _
                                             "Left join T10003_BZC Z ON Z.ID=A.BZC_ID Left join T10002_BZ BZ ON A.BZ_ID=BZ.ID" & SQL_PF_Price & " Order by A.BZC_ID"




    Public Const SQL_PF_Price As String = "  LEFT OUTER JOIN (SELECT  SUM(W.WL_Price * Li.Qty*1000) AS Amount, Li.BZC_ID" & vbCrLf & _
                                           "         FROM " & SQL_PF & " AS PF LEFT OUTER JOIN" & vbCrLf & _
                                            "               T10011_BZC_PFList AS Li ON PF.ID = Li.ID LEFT OUTER JOIN" & vbCrLf & _
                                          "               T10001_WL AS W ON W.ID = Li.WL_ID" & vbCrLf & _
                                          "         WHERE (Li.WL_ID > 0  ) " & vbCrLf & _
                                           "         GROUP BY Li.BZC_ID) AS PFa ON PFa.BZC_ID = A.BZC_ID"


    ''' <summary>
    ''' 获取对采购单信息-打印用
    ''' </summary>
    ''' <param name="Clinet_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Client_List(ByVal Clinet_ID As Integer, ByVal sDate As Date, ByVal eDate As Date) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("Client_id", Clinet_ID)
        p.Add("sDate1", sDate)
        p.Add("sDate2", eDate)
        Return PClass.PClass.SqlStrToDt(Sql_Clent_List, p)
    End Function


End Class


#End Region