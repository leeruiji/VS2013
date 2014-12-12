Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R20321_DXLingLiao
    Inherits CReport
    Dim comletedCount As Integer = 0

    Protected fileName As String = "R20321_StoreOut_DXLingLiao.grf"
    Dim FirstDate As Date
    Dim LastDate As Date
    Dim BType As BillType = BillType.DXLingLiao

    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal dtTable As DataTable, ByVal DoOperator As OperatorType, Optional ByVal isFirst As Boolean = True)
        Me.ReportFile = fileName

        Dim id As String = dtTable.Rows(0)("StrId")
        Dim R As DtReturnMsg = Dao.DXLingLiao_GetByid(id)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt
        Dt_List = R.Dt
        Dt_Header(1) = dtTable
        Me.DoOperator = DoOperator
        Me.DoWork()

    End Sub

  

End Class
#Region "数据库交换"

Partial Friend Class Dao

    Public Shared Function DXLingLiao_GetByid(ByVal id As String) As DtReturnMsg
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append("SELECT L.sPercent ,SUM(L.Qty) AS Qty, L.WL_Unit_LL, WL.WL_Spec, WL.WL_Name FROM T20311_LingLiao_List ")
        sqlBuider.Append("L LEFT OUTER JOIN T10001_WL WL ON WL.ID = L.WL_ID ")
        sqlBuider.Append(" WHERE (L.ID IN (")
        sqlBuider.Append(id)
        sqlBuider.Append("))GROUP BY L.sPercent, L.WL_Unit_LL, WL.WL_Spec, WL.WL_Name")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString)
    End Function




End Class


#End Region
