Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F99008_CardHistory


    Private Sub F99005_Supplier_Me_Load() Handles Me.Me_Load
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = CardHistory_GetByID(P_F_RS_ID)
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
End Class
