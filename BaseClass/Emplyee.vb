Imports PClass.PClass
Public Class Emplyee
    ''' <summary>
    ''' 单例模式
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared instance As Emplyee
    Private Const sql As String = "select ID,Employee_No,Employee_Name,Employee_Dept,Employee_Birthdate,Employee_Sex,Employee_IDCard from T15001_Employee order by Employee_No"
    Private Shared dt As DataTable
    Private Shared dt_Isload As Boolean = False
    Public Shared Function GetAllEmployee() As DataTable
        If dt_Isload = False Then
            Dim msg As DtReturnMsg = SqlStrToDt(sql)
            If msg.IsOk Then
                dt = msg.Dt
                dt_Isload = True
            Else

            End If
        End If
        Return dt
    End Function

    Public Shared Function GetEmployee_ByDept(ByVal Employee_dept As String) As DataTable
        ' If dt_Isload = False Then
        '   Dim msg As DtReturnMsg = SqlStrToDt("select  ID，Employee_No，Employee_Name，Employee_Dept，Employee_BirthdateEmployee_Sex，Employee_IDCard from T15001_Employee where Employee_dept like @Employee_dept+'%' order by Employee_No", "Employee_dept", Employee_dept)
        '  If msg.IsOk Then
        '  Return msg.Dt
        '
        '   Else
        '   Return Nothing
 
        Return ComFun.GetNewDataTable(dt, "Employee_dept like '" & Employee_dept & "%' ", "Employee_No")
    End Function

    ''' <summary>
    ''' 图片转换成颜色 √正常出勤 ▲请假 ★带薪假期 ●迟到 ■早退 ×旷工 ○上班无打卡 □下班无打卡
    ''' </summary>
    ''' <param name="Remark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemarkToColor(ByVal Remark As Char) As System.Drawing.Color
        Select Case Remark
            Case "√", "★"
                Return Drawing.Color.Blue
            Case "●", "■", "×", "○", "□", "▲"
                Return Drawing.Color.Red
            Case Else
                Return Drawing.Color.Black
        End Select
    End Function



    Private Sub New()
        Dim msg As DtReturnMsg = SqlStrToDt(sql)
        If msg.IsOk Then
            dt = msg.Dt
            dt_Isload = True
        Else

        End If
    End Sub

    Public Shared Function GetInstance() As Emplyee
        If instance Is Nothing Then
            instance = New Emplyee()
        End If
        Return instance
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="employeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEmployeeById(ByVal employeeId As String) As DataTable
        Return ComFun.GetNewDataTable(dt, "Employee_No ='" & employeeId & "'")
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="employeeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEmployeeNameById(ByVal employeeId As String) As String
        Try


            Dim dr() As DataRow = dt.Select("Employee_No ='" & employeeId & "'")
            If dr.Length = 1 Then
                Return dr(0)("Employee_Name")
            Else
                Return ""
            End If
        Catch ex As Exception
            DebugToLog(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateFromDb()
        Dim msg As DtReturnMsg = SqlStrToDt(sql)
        If msg.IsOk Then
            dt = msg.Dt
        Else

        End If
    End Sub



End Class
