Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R20910_JXC

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R20910_JXC.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As OptionList
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False

    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal dt As DataTable, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        Dt_List = dt
        Dt_Header(1) = New DataTable("T")
        Me.DoOperator = _operator
        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoWork()
        End If


    End Sub

    Sub SetOption(ByVal Olist As OptionList)
        Me.OList = Olist
        Ln = Ln + 1
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.JXC_Get(OList)
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
            End If
        Else
            Me.DoOperator = _operator
            Me.DoWork()
        End If
    End Sub
End Class
#Region "数据库交换"

Partial Friend Class Dao
    Public Const SQL_JXC_GET = " select  BillType, s.ID,BillName, sDate,WL_ID,Cost,Price,Store_ID,StoreInorOut, Supplier_Id, ClientTpye, ClientBill, Order_ID,QTY*StoreInorOut as QTY,Price*QTY*StoreInorOut as Amount, WL_No,WL_Name,WL_Unit,WL_Spec from T10050_Store_Detail  S left join T10001_WL W on S.WL_ID=W.ID  "

    Public Const SQL_JXC_GetBillType = " select distinct(BillType),BillName from T10050_Store_Detail order by BillType"
    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JXC_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品编号"
        fo.DB_Field = "WL_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品名称"
        fo.DB_Field = "WL_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "规格"
        fo.DB_Field = "WL_Spec"
        foList.Add(fo)

        Return foList
    End Function



    Public Shared Function JXC_Get(ByVal oList As OptionList) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_JXC_GET)
        sqlBuider.Append(" where billType>10000  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" order by sDate")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function


End Class


#End Region


