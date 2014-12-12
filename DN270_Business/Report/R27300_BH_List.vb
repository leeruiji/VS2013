Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R27300_BH_List

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R27300_BH_List.grf"

    Dim WL_No As String



    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal WL_No As String)
        Me.WL_No = WL_No

    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        Dim List As New DataTable
        Dim msg As DtReturnMsg = Dao.BHWL_Get(WL_No)
        If msg.IsOk Then
            List = msg.Dt
        End If
        Dt_Header(1) = New DataTable("T")
        Dt_List = List
        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoWork()
        End If
    End Sub

End Class
#Region "数据库交换"

Partial Friend Class Dao


    ''' <summary>
    ''' 获取备份物料
    ''' </summary>
    ''' <param name="WL_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BHWL_Get(ByVal WL_No As String) As DtReturnMsg
        Dim P As New StringBuilder
        P.AppendLine(" SELECT T.ClientOrder_ID,L.Qty ,T.ID,T.UPD_USER ,L.WL_ID,WL.WL_No, WL.WL_Name  FROM T20301_StoreOut_List L Left join T20300_StoreOut_Table T ON L.ID=T.ID ")
        P.AppendLine(" Left join T10001_WL WL ON L.WL_ID =WL.ID")
        P.AppendLine("Where T.State >0 AND T.isDelivery =0")
        If WL_No <> "" Then
            P.AppendLine("AND  WL_No =@WL_No")
        End If
        P.AppendLine("Order by WL_No")
        Return PClass.PClass.SqlStrToDt(P.ToString, "@WL_No", WL_No)
    End Function


End Class


#End Region

