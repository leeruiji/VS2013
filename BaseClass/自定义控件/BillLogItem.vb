<System.ComponentModel.ToolboxItem(False)> _
Public Class BillLogItem
    Public BillLog As BillLog
    Public LDt As DataTable
    Sub ShowLog()
        Dim P As New Dictionary(Of String, Object)
        P.Add("BillID", BillLog.BillID)
        Dim R As PClass.PClass.DtReturnMsg = PClass.PClass.SqlStrToDt("select * from T10080_BillStateLog where BillType=@BillType and ID=@BillID order by 1,2,3", P)
        LDt = R.Dt
        FG1.DtToFG(R.Dt)
        If R.Dt.Rows.Count > 0 Then
            FG1.RowSel = R.Dt.Rows.Count
            FG1.Row = R.Dt.Rows.Count
            BillLog.TB_Value.Text = FG1.Item(R.Dt.Rows.Count, "ChagneUser")
        Else
            BillLog.TB_Value.Text = ""
        End If
    End Sub




End Class
