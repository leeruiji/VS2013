Imports System.Text
<System.ComponentModel.ToolboxItem(False)> _
Public Class GH_BillLogItem
    Public GH_BillLog As GH_BillLog
    Public LDt As DataTable
    Sub ShowLog()
        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("select * from T30007_AllStateLog where GH=@BillID")
        If CB_Show.Checked = False Then
            sqlBuider.AppendLine(" and State_New<>State_Old  ")
        End If
        sqlBuider.AppendLine("order by Line")
        Dim P As New Dictionary(Of String, Object)
        P.Add("BillType", GH_BillLog.BillType)
        P.Add("BillID", GH_BillLog.BillID)
        Dim R As PClass.PClass.DtReturnMsg = PClass.PClass.SqlStrToDt(sqlBuider.ToString, P)
        R.Dt.Columns.Add("Old_Name", GetType(String))
        R.Dt.Columns.Add("New_Name", GetType(String))
        For Each dr As DataRow In R.Dt.Rows
            dr("Old_Name") = BaseClass.ComFun.GetProduceStateName(dr("State_Old"))
            dr("New_Name") = BaseClass.ComFun.GetProduceStateName(dr("State_New"))
        Next
        LDt = R.Dt
        FG1.DtToFG(R.Dt)
        If R.Dt.Rows.Count > 0 Then
            FG1.RowSel = R.Dt.Rows.Count
            FG1.Row = R.Dt.Rows.Count
            GH_BillLog.TB_Value.Text = FG1.Item(R.Dt.Rows.Count, "Change_User")
        Else
            GH_BillLog.TB_Value.Text = ""
        End If
    End Sub

    Private Sub CB_Show_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Show.CheckedChanged
        ShowLog()
    End Sub
End Class
