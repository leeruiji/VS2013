Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30900_LuoSe_DaySummary

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R30900_LuoSe_DaySummary.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)



    End Sub

    Sub SetOption(ByVal startDate As Date)
     
    End Sub

    Sub Start(ByVal Excelout As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal Client_id As Integer, ByVal BZ_id As Integer, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)


        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If

        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.LuoSe_DaySummary_Get(StartDate, EndDate, Client_id, BZ_id)
            If msg.IsOk Then
                If IsLoaded = False Then
                    dtGoods = msg.Dt
                    IsLoaded = True
                Else
                    If dtGoods.Rows.Count < msg.Dt.Rows.Count Then
                        dtGoods = msg.Dt
                    End If
                End If
                msg.Dt.Columns.Add("spec")
                For Each R As DataRow In msg.Dt.Rows
                    If IsNull(R("BZ_No"), "").ToString.Contains("#") Then
                        R("BZ") = R("BZ_No") & R("BZ")
                    End If
                    If IsNull(R("ClientBZC"), "") <> "" Then
                        R("BZC") = R("ClientBZC") & "#" & IsNull(R("BZC") & Format(IsNull(R("BZC_No"), 0), "GY000000") & IsNull(R("BZC_PF"), ""), "")
                    Else
                        R("BZC") = IsNull(R("BZC") & Format(IsNull(R("BZC_No"), 0), "GY000000") & IsNull(R("BZC_PF"), ""), "")
                    End If

                    Dim spec As String = ""
                    If IsNull(R("CR_ShiYong"), "") <> "" Then
                        spec = spec & "*" & R("CR_ShiYong")
                    End If
                    If IsNull(R("CR_BianDuiBian"), "") <> "" Then
                        spec = spec & "*" & R("CR_BianDuiBian")
                    End If
                    If IsNull(R("CR_KeZhong"), "") <> "" Then
                        spec = spec & "*" & R("CR_KeZhong")
                    End If
                    If spec.StartsWith("*") Then
                        spec = spec.Substring(1)
                    End If
                    R("spec") = spec
                Next

                Dt_List = msg.Dt
                LF = Ln
                Dim T As New DataTable("T")
                T.Columns.Add("Date_LuoSe")
                T.Rows.Add()
                If StartDate = EndDate Then
                    T.Rows(0)("Date_LuoSe") = StartDate
                Else
                    T.Rows(0)("Date_LuoSe") = StartDate.ToString("yyyy-MM-dd") & "到" & EndDate.ToString("yyyy-MM-dd")
                End If

                Dt_Header(1) = T
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
    Public Shared Function LuoSe_DaySummary_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品编号"
        fo.DB_Field = "WL_NO"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "商品名称"
        fo.DB_Field = "WL_Name"
        foList.Add(fo)



        Return foList
    End Function


    Public Shared Function LuoSe_DaySummary_Get(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Client_ID As Integer, ByVal BZ_ID As Integer) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)

        para.Add("@StartDate", StartDate)
        para.Add("@EndDate", EndDate)
        para.Add("@Client_ID", Client_ID)
        para.Add("@BZ_ID", BZ_ID)

        Dim sqlBuider As New StringBuilder()
        sqlBuider.Append("select G.Client_ID,G.ProcessType,G.BZ_ID,BZC_ID,Client_Name,ClientBZC,BZC_PF")
        sqlBuider.Append(" ,BZ_No,BZ_Name as BZ")
        sqlBuider.Append(",BZC_No,BZC_Name as BZC")
        sqlBuider.Append(",CR_ShiYong,CR_BianDuiBian,CR_KeZhong")
        sqlBuider.Append(",GH,Contract,CR_LuoSeBzCount,Remark,CR_BianDuiBian,CR_ShiYong,CR_BianDuiBian from T30000_Produce_Gd G")
        sqlBuider.Append(" left join T10002_BZ BZ on G.BZ_ID=BZ.ID ")
        sqlBuider.Append("left join T10003_BZC BZC on G.BZC_ID=BZC.ID ")
        sqlBuider.Append(" left join T10110_Client C on G.Client_ID=C.ID  ")
        sqlBuider.Append("  where State>0 and  Date_LuoSe between @StartDate and @EndDate ")
        If Client_ID > 0 Then
            sqlBuider.Append("  And G.Client_ID=@Client_ID ")
        End If
        If BZ_ID > 0 Then
            sqlBuider.Append("  And G.BZ_ID=@BZ_ID ")
        End If


        sqlBuider.Append(" order by G.Client_ID,G.BZ_ID,BZC_ID,GH ")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region


