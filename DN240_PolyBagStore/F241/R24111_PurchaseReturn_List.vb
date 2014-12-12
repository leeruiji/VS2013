Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R24111_PurchaseReturn_List
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R20011_PurchaseReturn_List.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)
        ReportFile = fileName
    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType)
        Dim R As DtReturnMsg = Dao.PurchaseReturn_SelListById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        R = Dao.PurchaseReturn_SelById(ID)
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
    ''' <summary>
    ''' 获取对采购单信息-打印用
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PurchaseReturn_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PurchaseReturn_SelByid, "@ID", sId)
    End Function


End Class


#End Region
