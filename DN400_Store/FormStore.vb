Public Class FormStore


    Public Sub ShowMsg()
        Dim x As Integer
        Dim y As Integer

        If MousePosition.X + Me.Width > Screen.PrimaryScreen.WorkingArea.Width Then
            x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        Else
            x = MousePosition.X
        End If
        If MousePosition.Y + Me.Height > Screen.PrimaryScreen.WorkingArea.Height Then
            y = MousePosition.Y - Me.Height - 10
        Else
            y = MousePosition.Y + 5
        End If
        Me.Top = y
        Me.Left = x
        Me.Visible = True
        Me.Activate()

    End Sub



    Private Sub FormStore_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Hide()
    End Sub
End Class