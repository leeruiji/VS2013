Option Compare Text
Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text

Public Class R15630_Attendance_Detailed

    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName As String = "R15630_Attendance_Detailed.grf"
    Protected fileName1 As String = "R15631_Attendance_Detailed.grf"
    Dim msg As DataTable
    'Dim FirstDate As Date
    'Dim LastDate As Date
    'Dim Employee_ID As Integer
    'Dim Dept_No As String
    'Dim LF As Integer = 0
    'Dim Ln As Integer = 0
    'Dim JobLeve As String = ""

    Dim IsLoaded As Boolean = False


    Sub New()
        ReportFile = Me.fileName
        ReDim Dt_Header(1)
    End Sub

    Sub SetOption(ByVal dt As DataTable)
        'FirstDate = startDate
        'LastDate = endDate
        'Me.Employee_ID = Employee_ID
        'Me.Dept_No = Dept_No
        'Me.JobLeve = JobLeve
        'Ln = Ln + 1
        Me.msg = dt
    End Sub

    Sub Start(Optional ByVal _operator As OperatorType = OperatorType.LoadFile, Optional ByVal fileChoose As Boolean = True)
        'If _operator = OperatorType.LoadFile OrElse LF <> Ln Then
        '    Dim msg As DtReturnMsg = Dao.Attendance_Data_Get(FirstDate, LastDate, Employee_ID, Dept_No, JobLeve)
        ''    If msg.IsOk Then
        If fileChoose Then
            ReportFile = fileName
        Else
            ReportFile = fileName1
        End If

        Dt_List = msg
        '        LF = Ln


        Dt_Header(1) = New DataTable("T")
        Me.DoOperator = _operator
        If _operator = OperatorType.LoadFile Then
            Me.LoadReport()
        Else

            Me.DoWork()
        End If
          

        'End If
    End Sub


End Class
#Region "数据库交换"

Partial Friend Class Dao







End Class


#End Region



