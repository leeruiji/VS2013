Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R50000_InnerPrice
    Inherits CReport
    Dim comletedCount As Integer = 0

    Protected fileName As String = "R50000_InnerPrice.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal ID As String, ByVal Comfirm As String, ByVal DoOperator As OperatorType)
        Me.ReportFile = fileName
        Dim R As DtReturnMsg = Dao.InnerPrice_SelByWL(ID, Comfirm)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        Else
            If Not R.Dt.Columns.Contains("Ranse") Then
                R.Dt.Columns.Add("Ranse", GetType(String))
            End If
            For Each dr As DataRow In R.Dt.Rows

            Next
        End If
        Dt_List = R.Dt

        R = Dao.InnerPrice_SelByClient(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_Header(1) = R.Dt

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub
End Class
#Region "数据库交换"

Partial Friend Class Dao
    Private Shared SQL_Get_NoComfirm_BZC_ID As String = "select W.WL_Name+'/'+W.WL_Spec AS WL, W.Wl_Price*p.Qty*1000 as Price,P.Qty,Z.BZ_Name,BZC_Name+'/GY-'+right('000000'+CAST(BZC_No as Varchar(20)),6)AS BZC,L.Ds_Ding" & _
                                                       "     FROM (SELECT BZC_ID,BZ_ID,Ds_Ding" & _
                                                              "  FROM T50001_Price_List" & _
                                                           " WHERE " & SQlConfirm & "  ID = @ID and islastPrice=1) L left join (SELECT BZC_ID ,ID from T10010_BZC_PF WHERE IsOK=1) C ON C.BZC_ID=L.BZC_ID LEFT OUTER JOIN" & _
                                                               " (SELECT WL_ID, BZC_ID,Qty,ID " & _
                                                              "FROM T10011_BZC_PFList where WL_ID>0)" & _
                                                             "  P ON P.ID = C.ID LEFT OUTER JOIN " & _
                                                                " T10001_WL W ON W.ID = P.WL_ID LEFT OUTER JOIN" & _
                                                                 " T10003_BZC B ON B.ID = L.BZC_ID LEFT OUTER JOIN" & _
                                                                    " T10002_BZ Z ON Z.ID = L.BZ_ID order by BZC_No"

    Public Shared SQlConfirm As String = ""

    Private Const SQL_Get_Price As String = "select T.ID,Client_Name,sDate from T50000_Price_Table T left join T10110_Client C on  T.Client_ID=C.ID WHERE T.ID=@ID"

    ''' <summary>
    ''' 获取未确认的色号
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InnerPrice_SelByWL(ByVal sId As String, Optional ByVal Confirm As String = "") As DtReturnMsg
        SQlConfirm = Confirm
        Dim SQL_Get_Comfirm_BZC_ID As String = "select W.WL_Name+'/'+W.WL_Spec AS WL, W.Wl_Price*p.Qty*1000 as Price,P.Qty,Z.BZ_No+'/'+Z.BZ_Name as BZ_Name,BZC_Name+'/GY-'+right('000000'+CAST(BZC_No as Varchar(20)),6) +'/'+Ranse AS BZC,L.Ds_Ding,Line" & _
                                                      "     FROM (SELECT BZC_ID,BZ_ID,Ds_Ding" & _
                                                             "  FROM T50001_Price_List" & _
                                                          " WHERE " & SQlConfirm & "  ID = @ID  and islastPrice=1) L left join (SELECT BZC_ID ,ID from T10010_BZC_PF WHERE IsOK=1) C ON C.BZC_ID=L.BZC_ID LEFT OUTER JOIN" & _
                                                              " (SELECT WL_ID, BZC_ID,Qty,ID,Line " & _
                                                             "FROM T10011_BZC_PFList where WL_ID>0)" & _
                                                            "  P ON P.ID = C.ID LEFT OUTER JOIN " & _
                                                               " T10001_WL W ON W.ID = P.WL_ID LEFT OUTER JOIN" & _
                                                                " T10003_BZC B ON B.ID = L.BZC_ID LEFT OUTER JOIN" & _
                                                                   " T10002_BZ Z ON Z.ID = L.BZ_ID order by BZC_No,Line"

        Return PClass.PClass.SqlStrToDt(SQL_Get_Comfirm_BZC_ID, "@ID", sId)
    End Function


    ''' <summary>
    ''' 获取客户
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InnerPrice_SelByClient(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Get_Price, "@ID", sId)
    End Function








End Class


#End Region
