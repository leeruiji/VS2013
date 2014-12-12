Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R99003_Employee_Room
    Inherits CReport

    Dim comletedCount As Integer = 0

    Protected Const Report_File As String = "R99003_Employee_Room.grf"

    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(0)

    End Sub





#Region "数据库交换"

    Sub Start(ByVal oList As List(Of FindOption), ByVal DoOperator As OperatorType)



        Me.ReportFile = Report_File
        Dim msg As DtReturnMsg = Dao.Employee_GetRoom(oList)
        If msg.IsOk Then
            Me.Dt_List = msg.Dt
        Else
            Me.Dt_List = New DataTable("T")

        End If



        Me.Dt_Header(0) = New DataTable
        Me.DoOperator = DoOperator
        Me.DoWork()

        '   MsgBox("加载报表信息错误")

    End Sub

    Dim arr As Byte()
#End Region

    Public Enum Enum_PrintStyle
        Manager
        Normal
        Security

    End Enum






End Class

Partial Class Dao
    ''' <summary>
    ''' 获取员工信息
    ''' </summary>
    ''' <param name="oList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Employee_GetRoom(ByVal oList As List(Of FindOption)) As DtReturnMsg
        Dim paraMad As New Dictionary(Of String, Object)
        Dim sql As New StringBuilder
        sql.Append("  select TE.* ,Job.Job_Name ,(case when len(Employee_Dept)=7 then ")
        sql.Append(" (select top 1 Dept_Name from T15000_Department D where left(TE.Employee_Dept,4)=D.Dept_No) ")
        sql.Append(" else TD.Dept_Name end) as Dept_Name, ")
        sql.Append(" (case when len(Employee_Dept)=7 then ")
        sql.Append(" TD.Dept_Name else '' end )GroupName ")
        sql.Append(",isnull(Room_Note,'') as Room_Note,isnull(Room_Floor,'') as Room_Floor ")
        sql.Append(" from (select  ID,Employee_No,Employee_Name,Employee_Room ,Employee_Dept,Employee_Job,Employee_FileType,Employee_QuitDate,Employee_QuitType from T15001_Employee where Employee_Room<>'' ")
        sql.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList, paraMad))
        sql.Append(" ) TE left join T15000_Department TD on TE.Employee_Dept=TD.Dept_No  ")
        sql.Append(" left join T15004_Room Ro on TE.Employee_Room=Ro.Room_No  ")
        sql.Append(" left join T15003_Job Job on Job.ID=Employee_Job  order by Room_Floor, TE.Employee_Room,Employee_Dept,GroupName, Employee_Job ")
        Dim Dtr As DtReturnMsg = PClass.PClass.SqlStrToDt(sql.ToString, paraMad)
        If Dtr.IsOk Then
            For Each r As DataRow In Dtr.Dt.Rows
                If r("Employee_FileType") <> F990031_Employee_Msg.EMPLOYEE_FILE_TYPE_LIZHI Then
                    r("Employee_QuitDate") = DBNull.Value
                    r("Employee_QuitType") = ""
                End If
            Next
        End If
        Return Dtr
    End Function
End Class