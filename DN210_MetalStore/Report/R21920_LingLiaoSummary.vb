Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R21920_LingLiaoSummary

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R21920_LingLiaoSummary.grf"

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


    'Sub Start(ByVal dt As DataTable, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
    '    Dt_List = dt
    '    Dt_Header(1) = New DataTable("T")
    '    Me.DoOperator = _operator
    '    If _operator = OperatorType.LoadFile Then
    '        Me.LoadReport()
    '    Else
    '        Me.DoWork()
    '    End If


    'End Sub

    Sub SetOption(ByVal Olist As OptionList)
        Me.OList = Olist
        Ln = Ln + 1
    End Sub

    Sub Start(ByVal startDate As Date, ByVal endDate As Date, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.LingLiaoSummary_Get(OList)
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
                Dt_Header(1).Columns.Add("FirstDate", GetType(Date))
                Dt_Header(1).Columns.Add("LastDate", GetType(Date))
                Dt_Header(1).Rows.Add(Dt_Header(1).NewRow)
                Dt_Header(1).Rows(0)("FirstDate") = startDate
                Dt_Header(1).Rows(0)("LastDate") = endDate
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
 
    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LingLiao_GetConditionNames() As List(Of FindOption)
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



    Public Shared Function LingLiaoSummary_Get(ByVal oList As OptionList) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(" select T.*,DisplayName from (")
        sqlBuider.Append("select Dept_No, WL_ID ,M.WL_No,WL_Name, Sum(Qty) as SumQty , sum(Amount) as SumAmount from  T21300_StoreOut_Table T ,T21301_StoreOut_List L,T21001_Metal M ")
        sqlBuider.Append("  where T.ID=L.ID and T.StoreOutType=1 and T.State=1  and L.WL_ID=M.ID ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" group by Dept_No, WL_ID,M.WL_No,WL_Name ) T   ")
        sqlBuider.Append(" left join V15000_Dept V on T.Dept_No=V.Dept_No ")

        sqlBuider.Append(" order by T.Dept_No ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function


End Class


#End Region


