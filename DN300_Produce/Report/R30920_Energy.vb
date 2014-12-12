Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30920_Energy

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R30920_Energy.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(0)
        
    End Sub

    Sub SetOption(ByVal startDate As Date)

    End Sub

    Sub Start(ByVal Excelout As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If

        Dim msg As DtReturnMsg = Dao.Energy_Get(StartDate, EndDate)
        If msg.IsOk Then
            Dt_List = msg.Dt
            Me.DoOperator = _operator
            If _operator = OperatorType.LoadFile Then
                Me.LoadReport()
            Else
                Me.DoWork()
            End If
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
    Public Shared Function Energy_GetConditionNames() As List(Of FindOption)
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


    Public Shared Function Energy_Get(ByVal StartDate As Date, ByVal EndDate As Date) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)

        para.Add("@StartDate", StartDate)
        para.Add("@EndDate", EndDate)

        Dim sqlBuider As New StringBuilder()
        sqlBuider.Append("select  E.*,SUM(SumPWeight) AS SumPWeight ,SUM(SumQty) AS  SumQty from ")
        sqlBuider.AppendLine("(select * from  T30920_Energy where sDate between @StartDate and @EndDate)E ")
        sqlBuider.AppendLine(" left join (select SumPWeight,SumQty ,BZSH_Date,State from  T40000_BZSH_Table where  State >=1 and BZSH_Date between @StartDate and @EndDate)  B ")
        sqlBuider.AppendLine("  on B.BZSH_Date =e.sDate   ")
        sqlBuider.AppendLine(" group by sDate,YM ,RB_CL,RB_Water,RB_Gas, RB_RL,RB_ZJ,DX_CL,DX_Elec,DX_Coal,LuoSe,IsAudited")
        sqlBuider.AppendLine(" order by sDate desc")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class


#End Region


