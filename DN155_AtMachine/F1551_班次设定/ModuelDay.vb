Imports System.Data
Imports PClass.PClass
<System.ComponentModel.ToolboxItem(False)> _
Public Class ModuelDay
    Public PF As iShift
    ''' <summary>
    ''' 上次查询的打卡表
    ''' </summary>
    ''' <remarks></remarks>
    Public LD As DataTable
    ''' <summary>
    ''' 上次查询的请假表
    ''' </summary>
    ''' <remarks></remarks>
    Public LLD As DataTable
    ''' <summary>
    ''' 当然的打卡表
    ''' </summary>
    ''' <remarks></remarks>
    Public PD As DataTable
    Public User_Date As Date
    Public NowDay As Integer
    Public IsLeave As Boolean = False
    Public Is_CQ As Boolean = False
    Public Is_Auto As Boolean = True
    Public Shift_Line As Integer = 0
    Public IsChanged As Boolean = False
    Public shiftId As Integer


    Sub DoubleClickRetrun()

    End Sub


    Sub SetDate(ByVal D As Date)
        NowDay = D.Day
        LabelDay.Text = NowDay & "号"
        User_Date = D
    End Sub

    Sub SetDate(ByVal D As Integer)
        NowDay = D
        LabelDay.Text = NowDay & "号"
    End Sub


    Public IsSel As Boolean = False
    Private Sub UserDay_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PF.ModuelDayClick(Me, System.Windows.Forms.Control.ModifierKeys)
        End If
    End Sub

    Public Sub ShowSelColor()
        If IsSel Then
            Me.BackColor = Color.Orange
        Else
            Me.BackColor = Color.White
        End If
    End Sub

    Private Sub ComboBox_Data_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Data.SelectedValueChanged
        IsChanged = True
        Shift_Line = CB_Data.SelectedValue
        If IsSel Then

            PF.ComboxSel(Me)
        End If
        If Is_Auto = False Then
            Exit Sub
        End If


        If shiftId = CB_Data.SelectedValue Then
            IsChanged = False
            LabelState.Text = ""
        Else
            LabelState.Text = "手动排班"

        End If
    End Sub





End Class
