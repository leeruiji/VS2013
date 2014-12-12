Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15612_Attendance_Change
    Public LU As UserDay
    Dim isloaded As Boolean = False
    Dim IsLock As Boolean = False

    Sub Ver_ini()
        IsLock = LU.IsLock
        ComboBox_Data.Visible = Not IsLock
        LabelBC.Visible = IsLock
        TB_Depart.Text = LU.PF.TB_Depart.TextBox.Text
        TB_Employee_No.Text = LU.PF.TB_Employee_No.TextBox.Text
        TB_Employee_Name.Text = LU.PF.TB_Employee_Name.TextBox.Text
        TB_User_Date.Text = LU.User_Date.ToString("yyyy年MM月dd日")
        If IsLock Then
            LabelBC.Text = LU.BC

            Cmd_Auto.Enabled = False
            Cmd_Ok.Enabled = False
        Else
            Dim s As String = LU.ComboBox_Data.SelectedIndex
            ComboBox_Data.ValueMember = "Line"
            ComboBox_Data.DisplayMember = "shift_name"
            ComboBox_Data.DataSource = LU.ComboBox_Data.DataSource
            ComboBox_Data.ValueMember = "Line"
            ComboBox_Data.DisplayMember = "shift_name"
            ComboBox_Data.SelectedIndex = s

        End If

        LB_MX.ValueMember = "Card_Date"
        LB_MX.DisplayMember = "Card_Date"
        LB_MX.DataSource = LU.PD
        LB_MX.ValueMember = "Card_Date"
        LB_MX.DisplayMember = "Card_Date"


        TB_Up_Time.Text = LU.Up_Time
        TB_Down_Time.Text = LU.Down_Time
        TB_Remark.Text = LU.Remark

        TB_Remark_Mx.Text = LU.Remark_Mx

        TB_CD.Text = LU.CD
        TB_ZT.Text = LU.ZT

        CB_CQ.Checked = (LU.CQ = 1)
        CB_QQ.Checked = (LU.QQ = 1)
        CB_XX.Checked = (LU.XX = 1)
        CB_Is_Auto.Checked = LU.Is_Auto
    End Sub

    Private Sub F15612_Attendance_Change_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        Ver_ini()
        isloaded = True
    End Sub

    Sub Set_Endable(ByVal T As Boolean)
        TB_Up_Time.ReadOnly = Not T
        TB_Down_Time.ReadOnly = Not T
        TB_CD.ReadOnly = Not T
        TB_ZT.ReadOnly = Not T

        TB_Remark.BackColor = TB_CD.BackColor
        TB_Remark.ReadOnly = Not T


        TB_Remark_Mx.ReadOnly = Not T

        CB_CQ.Enabled = T
        CB_QQ.Enabled = T
        CB_XX.Enabled = T

    End Sub

    Private Sub CB_Is_Auto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Is_Auto.CheckedChanged
        LU.Is_Auto = CB_Is_Auto.Checked
        If CB_Is_Auto.Checked Then
            Cmd_Auto.Text = "手动分析"
            LabelState.Text = "当前是:自动分析"
            LB_MX.ContextMenuStrip = Nothing
            If isloaded Then
                ComboBox_Data_SelectedValueChanged(ComboBox_Data, New EventArgs)
            End If
        Else
            LB_MX.ContextMenuStrip = ContextMenuStrip1
            Cmd_Auto.Text = "自动分析"
            LabelState.Text = "当前是:手动分析"
        End If
        Set_Endable(Not CB_Is_Auto.Checked AndAlso Not IsLock)
    End Sub

    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        Close()
    End Sub

    Private Sub Cmd_Auto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Auto.Click
        CB_Is_Auto.Checked = Not CB_Is_Auto.Checked
        LU.Is_Auto = CB_Is_Auto.Checked
    End Sub

    Private Sub ToolStripMenuItem_Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Up.Click
        If LB_MX.SelectedIndex = -1 Then
            Exit Sub
        End If
        TB_Up_Time.Text = CDate(LB_MX.SelectedValue).ToString("HH:mm")
    End Sub

    Private Sub ToolStripMenuItem_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Down.Click
        If LB_MX.SelectedIndex = -1 Then
            Exit Sub
        End If
        TB_Down_Time.Text = CDate(LB_MX.SelectedValue).ToString("HH:mm")
    End Sub



    Private Sub ComboBox_Data_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox_Data.SelectedValueChanged
        LU.ComboBox_Data.SelectedIndex = ComboBox_Data.SelectedIndex
        If CB_Is_Auto.Checked Then
            Ver_ini()
        End If
    End Sub

    Private Sub TB_Remark_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Remark.TextChanged
        TB_Remark.ForeColor = BaseClass.Emplyee.RemarkToColor(TB_Remark.Text)
    End Sub



    Private Sub LB_Remark_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LB_Remark1.DoubleClick, LB_Remark2.DoubleClick, LB_Remark3.DoubleClick, LB_Remark4.DoubleClick, LB_Remark5.DoubleClick, LB_Remark6.DoubleClick, LB_Remark7.DoubleClick, LB_Remark8.DoubleClick
        If CB_Is_Auto.Checked = False Then
            TB_Remark.Text = TB_Remark.Text & TryCast(sender, Label).Text.Substring(0, 1)
        End If
    End Sub

    Private Sub Cmd_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Ok.Click
        LU.Is_Auto = CB_Is_Auto.Checked

        LU.Up_Time = TB_Up_Time.Text
        LU.Down_Time = TB_Down_Time.Text
        LU.Remark = TB_Remark.Text

        LU.Remark_Mx = TB_Remark_Mx.Text

        LU.CD = TB_CD.Text
        LU.ZT = TB_ZT.Text
        LU.CQ = IIf(CB_CQ.Checked, 1, 0)
        LU.QQ = IIf(CB_QQ.Checked, 1, 0)
        LU.XX = IIf(CB_XX.Checked, 1, 0)

        LU.ShowRemark()
        Close()
    End Sub
End Class
