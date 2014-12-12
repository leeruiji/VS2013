Option Compare Text
Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R15605_PBB_Mx

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R15605_PBB_Mx.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim Employee_ID As Integer
    Dim Dept_No As String
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim JobLeve As String = ""

    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal Employee_ID As Integer, ByVal Dept_No As String, ByVal JobLeve As String)
        FirstDate = startDate
        LastDate = endDate
        Me.Employee_ID = Employee_ID
        Me.Dept_No = Dept_No
        Me.JobLeve = JobLeve
        Ln = Ln + 1
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.PBB_Mx_Get(FirstDate, LastDate, Employee_ID, Dept_No, JobLeve)
            If msg.IsOk Then
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

    Private Sub R15610_Attendance_Data_BeforePostRecord() Handles Me.BeforePostRecord

        Report.FieldByDBName("Title").AsString = FirstDate.Date.ToString("yyyy年MM月考勤表")

        Select Case Date.DaysInMonth(FirstDate.Date.Year, FirstDate.Date.Month)
            Case 28
                Report.ColumnByName("D29").Visible = False
                Report.ColumnByName("D30").Visible = False
                Report.ColumnByName("D31").Visible = False
            Case 29
                Report.ColumnByName("D29").Visible = True
                Report.ColumnByName("D30").Visible = False
                Report.ColumnByName("D31").Visible = False
            Case 30
                Report.ColumnByName("D29").Visible = True
                Report.ColumnByName("D30").Visible = True
                Report.ColumnByName("D31").Visible = False
            Case 31
                Report.ColumnByName("D29").Visible = True
                Report.ColumnByName("D30").Visible = True
                Report.ColumnByName("D31").Visible = True
        End Select


    End Sub
End Class
#Region "数据库交换"

Partial Friend Class Dao





    Public Shared Function PBB_Mx_Get(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Employee_ID As Integer, ByVal Dept_No As String, Optional ByVal JobLeve As String = "") As DtReturnMsg

        Dim TD As Date = StartDate
        Dim SQLWhere As New StringBuilder("")
        ' SQLWhere.AppendFormat(" where User_Date between '{0}' and '{1}' ", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd 23:59:59"))

        Dim sqlBuider As New StringBuilder("")
        sqlBuider.AppendLine("select U.ID,Employee_Name,Employee_No" & vbCrLf)
        sqlBuider.AppendLine(",(case when len(Employee_Dept)=7 then ")
        sqlBuider.AppendLine(" (select top 1 Dept_Name from T15000_Department D where left(Employee_Dept,4)=D.Dept_No) ")
        sqlBuider.AppendLine(" else TD.Dept_Name end) as Dept_Name, ")
        sqlBuider.AppendLine(" (case when len(Employee_Dept)=7 then ")
        sqlBuider.AppendLine(" TD.Dept_Name else '' end )GroupName ")
        sqlBuider.AppendLine(",Employee_ShiftMoudel,Employee_ShiftMoudel_Name from ")
        sqlBuider.AppendLine("T15001_Employee U ")
        sqlBuider.AppendLine(" left join T15000_Department TD on U.Employee_Dept=TD.Dept_No  ")

        If JobLeve <> "" Then '用户等级
            sqlBuider.AppendLine(" left join T15003_Job J on U.Employee_Job=J.ID")
        End If



        sqlBuider.AppendLine(" where (Employee_FileType <> '离职' or (Employee_FileType = '离职' and isnull(Employee_QuitDate,'2099-1-1')>='" & StartDate.ToString("yyyy-MM-dd") & "')) ")
        If Dept_No <> "" Then
            sqlBuider.Append(" and U.Employee_Dept like '")
            sqlBuider.Append(Dept_No)
            sqlBuider.Append("%'")
        End If

        If Employee_ID <> 0 Then '用户等级
            sqlBuider.Append(" and U.id=")
            sqlBuider.Append(Employee_ID)
        End If

        If JobLeve <> "" Then
            sqlBuider.Append(" and J.Job_Grade ")
            sqlBuider.Append(JobLeve)
        End If


        sqlBuider.AppendLine(" order by Dept_No,Employee_Name")

        Dim R As DtReturnMsg = PClass.PClass.SqlStrToDt(sqlBuider.ToString)
        If R.IsOk = False Then
            Return R
        End If


        Dim SQL As New List(Of String)
        SQL.Add("select M.ID as ShiftMoudel,sDate,s.Shift_ID from T15518_Real_Shift_Month M,T15519_Real_Shift_Day D,T15510_AT_Shifts s where M.ID=D.ID and M.sMonth=d.sMonth and M.sMonth=@sMonth and d.Shift_ID=s.Line  ")
        SQL.Add("select Employee_ID,sDate,s.Shift_ID from T15605_Personal_Shift p,T15510_AT_Shifts s where sMonth =@sMonth and  p.Shift_ID=s.Line")
        Dim P As New Dictionary(Of String, Object)
        P.Add("sMonth", StartDate.ToString("yyyy-MM-dd"))
        Dim LDt As List(Of DataTable) = PClass.PClass.SqlStrToDtList(SQL, P)

        If LDt Is Nothing Then
            Return R
        End If
        Dim Dt As DataTable = R.Dt
        Dim Dt2 As DataTable = LDt.Item(0)
        Dim Dt3 As DataTable = LDt.Item(1)
        Do Until TD > EndDate
            Dt.Columns.Add("D" & TD.ToString("dd"))
            TD = TD.AddDays(1)
        Loop
        TD = StartDate
        For Each Row As DataRow In Dt.Rows
            Dim Rows1() As DataRow = Dt2.Select("ShiftMoudel=" & IsNull(Row("Employee_ShiftMoudel"), 0))
            Dim Rows2() As DataRow = Dt3.Select("Employee_ID=" & IsNull(Row("ID"), 0))
 
            For Each RD As DataRow In Rows1
                TD = RD("sDate")
                Row("D" & TD.ToString("dd")) = RD("Shift_ID")
            Next
            For Each RD As DataRow In Rows2
                TD = RD("sDate")
                Row("D" & TD.ToString("dd")) = RD("Shift_ID")
            Next
        Next



        Return R

    End Function

End Class


#End Region


