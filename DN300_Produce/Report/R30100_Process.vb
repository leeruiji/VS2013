Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30100_Process

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R30100_Process.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False


    Sub New(ByVal ExcelOut As Boolean)

        ReDim Dt_Header(1)

        If ExcelOut Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If


    End Sub

    Sub SetOption(ByVal startDate As Date)

    End Sub

    Sub Start(ByVal dt As DataTable, ByVal _operator As OperatorType)
        For Each R As DataRow In dt.Rows
            R("BZC") = IsNull(R("BZC"), "").ToString.Replace(vbCrLf, "")
        Next

        ReportFile = Me.fileName
        Dt_List = dt
        LF = Ln
        Dt_Header(1) = New DataTable("T")
        Me.DoOperator = _operator
        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else
            Me.DoWork()
        End If

    End Sub



    Sub Start_JiaJi(ByVal dt As DataTable, ByVal _operator As OperatorType)
        For Each R As DataRow In dt.Rows
            R("BZC") = IsNull(R("BZC"), "").ToString.Replace(vbCrLf, "")
        Next
        Dt_List = dt
        LF = Ln
        Dt_Header(1) = New DataTable("T")
        ReportFile = "R30101_Process_JiaJi.grf"
        Me.DoOperator = _operator
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
    ''' 获取表头结构
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Process_GetEmpty_PrintDt() As DataTable
        Dim dt As New DataTable("T")
        dt.Columns.Add("Date_KaiDan", GetType(Date))
        dt.Columns.Add("Client_Name", GetType(String))
        dt.Columns.Add("JiaJi", GetType(String))
        dt.Columns.Add("Contract", GetType(String))
        dt.Columns.Add("BZ", GetType(String))
        dt.Columns.Add("BZC", GetType(String))
        dt.Columns.Add("GH", GetType(String))
        dt.Columns.Add("CR_LuoSeBzCount", GetType(Integer))
        dt.Columns.Add("PeiBu", GetType(String))
        dt.Columns.Add("SongBu", GetType(String))
        dt.Columns.Add("YuDing", GetType(String))
        dt.Columns.Add("RanSeGH", GetType(String))
        dt.Columns.Add("ChuGang", GetType(String))
        dt.Columns.Add("BanCheng", GetType(String))
        dt.Columns.Add("TuoShui", GetType(String))
        dt.Columns.Add("ZhongJian", GetType(String))
        dt.Columns.Add("KaiFu", GetType(String))
        dt.Columns.Add("DingXIng", GetType(String))
        dt.Columns.Add("ChengJian", GetType(String))
        dt.Columns.Add("Date_JiaoHuo", GetType(Date))
        dt.Columns.Add("Remark", GetType(String))
        Return dt
    End Function



    Public Shared Function Process_Get(ByVal _Date As Date) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)

        para.Add("@Date", _Date)


        Dim sqlBuider As New StringBuilder()
        sqlBuider.Append("select G.Client_ID,G.BZ_ID,BZC_ID,Client_Name,ClientBZC,BZC_PF")
        sqlBuider.Append(" ,BZ_No,BZ_Name as BZ")
        sqlBuider.Append(",BZC_No,BZC_Name as BZC")
        sqlBuider.Append(",GH,Contract,CR_LuoSeBzCount,Remark from T30000_Produce_Gd G")
        sqlBuider.Append(" left join T10002_BZ BZ on G.BZ_ID=BZ.ID ")
        sqlBuider.Append("left join T10003_BZC BZC on G.BZC_ID=BZC.ID ")
        sqlBuider.Append(" left join T10110_Client C on G.Client_ID=C.ID  ")
        sqlBuider.Append("  where Date_LuoSe=@Date")
        sqlBuider.Append(" order by G.Client_ID,G.BZ_ID,BZC_ID,GH ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region


