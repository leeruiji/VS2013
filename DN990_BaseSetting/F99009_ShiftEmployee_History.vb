Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F99009_ShiftEmployee_History


    Private Sub F99009_ShiftEmployee_History_Me_Load() Handles Me.Me_Load
        DP_Start.Value = New Date(Today.Year, 1, 1)
        DP_End.Value = New Date(Today.Year, 12, 31)
        Me_Refresh()
       
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Employee_ShiftChange(P_F_RS_ID, DP_Start.Value.Date, DP_End.Value.Date)
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
        End If


    End Sub







    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me_Refresh()
    End Sub
End Class
Partial Class Dao

    ''' <summary>
    ''' 班次更换信息
    ''' </summary>
    ''' <param name="Employee_ID"></param> 
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Employee_ShiftChange(ByVal Employee_ID As String, ByVal DP_Start As DateTime, ByVal DP_End As DateTime) As DtReturnMsg
        Dim sql As String = "SELECT E.Employee_Name, S.Name,R.Name as ShangName, H.sDate, H.Remark FROM T15004_EmployeeShift_History H LEFT OUTER JOIN T15001_Employee E ON H.Employee_ID = E.ID LEFT OUTER JOIN T15517_Real_Shift S ON H.Shift_Id = S.ID LEFT OUTER JOIN T15517_Real_Shift R ON H.ShangShift_Id = R.ID where H.Employee_ID=@Employee_ID and sDate between @DP_Start and @DP_End  "
        Dim p As New Dictionary(Of String, Object)
        p.Add("Employee_ID", Employee_ID)
        p.Add("DP_Start", DP_Start)
        p.Add("DP_End", DP_End)
        Return PClass.PClass.SqlStrToDt(sql, p)

    End Function














End Class