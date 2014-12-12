Option Compare Text
Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R15600_At_Data_Mx

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R15600_At_Data_Mx.grf"

    Dim FirstDate As Date
    Dim LastDate As Date
    Dim LF As Integer = 0
    Dim Ln As Integer = 0
    Dim OList As List(Of FindOption)
    Public dtGoods As DataTable
    Dim IsLoaded As Boolean = False
    Dim JobLeve As String
    Dim NoCard As Boolean '='只显示没打卡的

    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal startDate As Date, ByVal endDate As Date, ByVal JobLeve As String, ByVal Olist As List(Of FindOption), ByVal NoCard As Boolean)
        FirstDate = startDate
        LastDate = endDate
        Me.OList = Olist
        Me.JobLeve = JobLeve
        Me.NoCard = NoCard
        Ln = Ln + 1
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile)
        If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
            Dim msg As DtReturnMsg = Dao.At_Data_Mx_Get(FirstDate, LastDate, JobLeve, OList, NoCard)
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





    Public Shared Function At_Data_Mx_Get(ByVal startDate As Date, ByVal endDate As Date, ByVal JobLeve As String, ByVal Olist As List(Of FindOption), ByVal NoCard As Boolean) As DtReturnMsg

        Dim RD As DtReturnMsg = SqlStrToDt("select  Dept_No,(case when len(Dept_No)=7 then (select top 1 Dept_Name from T15000_Department D where left(TD.Dept_No,4)=D.Dept_No)else TD.Dept_Name end) as Dept_Name,(case when len(Dept_No)=7 then TD.Dept_Name else '' end )GroupName from T15000_Department TD")
        If RD.IsOk = False Then
            Return RD
        End If


        Dim para As New Dictionary(Of String, Object)
        para.Add("@StartDate", startDate)
        para.Add("@EndDate", endDate)


        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("select Employee_Name,Employee_No,Employee_Dept,E.ID from T15001_Employee E")
        If JobLeve <> "" Then '用户等级
            sqlBuider.AppendLine(" left join T15003_Job J on E.Employee_Job=J.ID")
        End If
        sqlBuider.AppendLine("where  ")
        sqlBuider.AppendLine(" (Employee_FileType <> '离职' or (Employee_FileType = '离职' and isnull(Employee_QuitDate,'2099-1-1')>=@startDate)) ")

        If Olist.Count > 0 Then
            sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(Olist, para))
        End If
        If JobLeve <> "" Then
            sqlBuider.Append(" and J.Job_Grade ")
            sqlBuider.Append(JobLeve)
        End If
        sqlBuider.Append(" order by Employee_Dept,Employee_Name ")
        Dim R As DtReturnMsg = PClass.PClass.SqlStrToDt(sqlBuider.ToString, para)
        If R.IsOk Then
            Dim rr As DtReturnMsg = PClass.PClass.SqlStrToDt("select Card_ID, Card_Date,User_ID from T15502_At_Data  with(index(IX_T15502_At_Data_Card)) where  Card_Date between @StartDate and @EndDate and IsHandle = 1", para)
            If rr.IsOk Then
                Dim Rt As New DtReturnMsg
                Rt.Dt = R.Dt.Clone
                Rt.Dt.Columns.Add("Card_Date", GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 1, GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 2, GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 3, GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 4, GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 5, GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 6, GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 7, GetType(DateTime))
                Rt.Dt.Columns.Add("Card_Date" & 8, GetType(DateTime))
                Rt.Dt.Columns.Add("Dept_Name")
                Rt.Dt.Columns.Add("Group_Name")
                Dim Dt As DataTable = Rt.Dt
                Dim LastName As String = ".. .."
                Dim MaxTime As Integer = 6
                Dim Dr As DataRow
                'Dim LastDate As DateTime
                'Dim LastTime As DateTime
                Dim LastGroup As String = ""
                Dim LastDptName As String = ""
                Dim LastDptNo As String = ""
                Dim Nmax As Integer = 0
                For Each Row As DataRow In R.Dt.Rows
                    Dim D As Date = startDate
                    If IsDBNull(Row("Employee_Name")) = False Then
                        Do While D <= endDate.Date
                            Dim Rows() As DataRow = rr.Dt.Select("Card_Date >= '" & D.Date.ToString("yyyy-MM-dd") & "' and Card_Date <'" & D.Date.AddDays(1) & "' and User_ID=" & Row("ID"))
                            Nmax = 1
                            If LastDptNo <> Row("Employee_Dept") Then
                                Dim Drow() As DataRow = RD.Dt.Select("Dept_No='" & Row("Employee_Dept") & "'")
                                If Drow.Length = 0 Then
                                    LastGroup = ""
                                    LastDptName = ""
                                Else
                                    LastDptNo = Row("Employee_Dept")
                                    LastDptName = Drow(0)("GroupName")
                                    LastGroup = IsNull(Drow(0)("Dept_Name"), "")
                                End If
                            End If
                            Dr = Dt.NewRow
                            Dr("Employee_Dept") = Row("Employee_Dept")
                            Dr("Employee_No") = Row("Employee_No")
                            Dr("Employee_Name") = Row("Employee_Name")
                            Dr("Dept_Name") = Row("Employee_Dept")
                            Dr("Dept_Name") = LastGroup
                            Dr("Group_Name") = LastDptName
                            Dr("Card_Date") = D.Date
                            Nmax = 1
                            If Rows.Length > 0 Then
                                For Each Rowx As DataRow In Rows
                                    Dr("Card_Date" & Nmax) = Rowx("Card_Date")
                                    Nmax = Nmax + 1
                                    If Nmax > 8 Then Exit For
                                Next
                            End If
                            If NoCard Then
                                If Rows.Length = 0 Then
                                    Dt.Rows.Add(Dr)
                                End If
                            Else
                                Dt.Rows.Add(Dr)
                            End If






                    'If Row("Employee_Name") <> LastName OrElse LastDate <> CDate(Row("Card_Date")).Date Then
                    '    If LastDptNo <> Row("Employee_Dept") Then
                    'Dim Drow() As DataRow = Rd.Dt.Select("Dept_No='" & Row("Employee_Dept") & "'")
                    '        If Drow.Length = 0 Then
                    '            LastGroup = ""
                    '            LastDptName = ""
                    '        Else
                    '            LastDptNo = Row("Employee_Dept")
                    '            LastDptName = Drow(0)("GroupName")
                    '            LastGroup = IsNull(Drow(0)("Dept_Name"), "")
                    '        End If
                    '    End If
                    '    Nmax = 1
                    '    Dr = Dt.NewRow
                    '    Dr("Employee_Dept") = Row("Employee_Dept")
                    '    Dr("Employee_No") = Row("Employee_No")
                    '    Dr("Employee_Name") = Row("Employee_Name")
                    '    Dr("Dept_Name") = LastGroup
                    '    Dr("Group_Name") = LastDptName

                    '    Dr("Card_Date") = CDate(Row("Card_Date")).Date
                    '    Dr("Card_Date1") = Row("Card_Date")
                    '    Dt.Rows.Add(Dr)
                    '    LastName = Row("Employee_Name")
                    '    LastTime = CDate(Row("Card_Date"))
                    '    LastDate = LastTime.Date
                    'Else
                    '    If LastTime.ToString("yyyyMMddHHmm") <> CDate(Row("Card_Date")).ToString("yyyyMMddHHmm") Then
                    '        Nmax = Nmax + 1
                    '        If Nmax > MaxTime Then
                    '            MaxTime = MaxTime + 1
                    '            Dt.Columns.Add("Card_Date" & MaxTime, GetType(DateTime))
                    '        End If
                    '        Dr("Card_Date" & Nmax) = Row("Card_Date")
                    '        LastTime = CDate(Row("Card_Date"))
                    '    End If
                    'End If
                    D = D.AddDays(1)
                        Loop
                    End If
                Next

                Rt.IsOk = True
                Return Rt
            Else
                Return rr
            End If

        Else
            Return R
        End If
    End Function

End Class


#End Region


