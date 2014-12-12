Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R20011_Purchase
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected Const fileName As String = "R20011_Purchase.grf"
    Protected Const fileNameNoPrice As String = "R20012_Purchase.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New(ByVal isPrice As Boolean)
        ReDim Dt_Header(1)
        If isPrice Then
            ReportFile = fileName
        Else
            ReportFile = fileNameNoPrice
        End If
    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType)
        Dim R As DtReturnMsg = Dao.Purchase_ListByID(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        R = Dao.Purchase_TableSelById(ID)
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

    Private Const SQL_Purchase__Table As String = "  SELECT  T.ID,T.Upd_User,T.sDate ,S.Supplier_FullName ,S.Supplier_Addr ,S.Supplier_Fax ,S.Supplier_Tel1,S.Supplier_Mobile  FROM  " & _
                                                            "  T20010_PurchaseAsk_Table T Left join T10100_Supplier S ON T.Supplier_ID =S.ID " & _
                                                            "   Where T.ID=@ID "


    Private Const SQL_Purchase_List As String = "Select  WL.WL_Name,WL.WL_Spec,WL.WL_Unit,L.Price,L.Qty,L.Amount,L.LRemark,L.eDate  from T20011_PurchaseAsk_List L Left join T10001_WL WL ON  L.WL_ID=WL.ID  Where L.ID=@ID    "



    ''' <summary>
    ''' 获取对采购单表头信息-打印用
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_TableSelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Purchase__Table, "@ID", sId)
    End Function


    ''' <summary>
    ''' 获取对采购单列表信息-打印用
    ''' </summary>
    ''' <param name="sID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_ListByID(ByVal sID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Purchase_List, "@ID", sID)
    End Function




End Class


#End Region

