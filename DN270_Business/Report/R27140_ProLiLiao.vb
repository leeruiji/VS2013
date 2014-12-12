Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R27140_ProLiLiao
    Inherits CReport
    Protected fileName As String = "R27140_ProLiLiao.grf"
    Dim LastDate As Date

    Sub New()
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType)
        Dim R As DtReturnMsg = Dao.ProLiLiaoList_SelById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        R = Dao.ProLiLiaoTable_ByID(ID)
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

    Private Const SQL_ProLiLiaoList_Byid As String = "Select L.*,C.Client_Name from T27141_ProLiLiao_List L Left join T10110_Client C oN L.Client_ID=C.ID Where L.ID=@ID"

    Private Const SQL_ProLiLiaoTable_ByID As String = " Select * from T27140_ProLiLiao_Table Where ID=@ID                                    "

    ''' <summary>
    ''' 获取对客户订单信息-打印用
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiaoList_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProLiLiaoList_Byid, "@ID", sId)
    End Function


    ''' <summary>
    ''' 获取表头信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProLiLiaoTable_ByID(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProLiLiaoTable_ByID, "@ID", sId)
    End Function






End Class


#End Region
