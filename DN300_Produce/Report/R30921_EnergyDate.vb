Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R30921_EnergyDate
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R30921_EnergyDate.grf"

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

    Sub Start(ByVal Excelout As Boolean, ByVal Dt As DataTable, Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If Excelout Then
            Me.SetCanExcelOut()
        Else
            Me.SetCanNotExcelOut()
        End If
        Dim msg As DtReturnMsg = Dao.Energy_GetMonth(Dt.Rows(0)("YM"))
        If msg.IsOk Then
            Dt_Header(1) = msg.Dt
            Dt_List = Dt
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





    Public Shared Function Energy_GetMonth(ByVal YM As Integer) As DtReturnMsg
        Dim r As New DtReturnMsg
        r.IsOk = False
        Dim para As New Dictionary(Of String, Object)

        para.Add("@YM", YM)


        Dim sqlBuider As New StringBuilder()
        sqlBuider.Append("select YM as SYM,sum(RB_CL)as SRB_CL,sum(RB_Water)as SRB_Water,sum(RB_Gas)as SRB_Gas," & _
                         "sum(RB_RL)as SRB_RL,sum(RB_ZJ)as SRB_ZJ,sum(DX_CL)as SDX_CL,sum(DX_Elec)as SDX_Elec," & _
                         "sum(DX_Coal)as SDX_Coal,sum(LuoSe)as SLuoSe from T30920_Energy where YM = @YM group by YM")

        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)

    End Function

End Class



#End Region


