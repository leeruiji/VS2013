Imports System.Data
Imports PClass.PClass
<System.ComponentModel.ToolboxItem(False)> _
Public Class UserDay
    Public PF As F15611_Attendance_Msg
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
    Public IsLock As Boolean = False
    Public Shift_Line As Integer = 0

    Private Sub UserDay_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Dim F As New F15612_Attendance_Change
        With F
            .LU = Me
        End With
        PF.F_RS_ID = ""
        PF.ReturnId = ""
        PF.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, PF)
        AddHandler VF.ClosedX, AddressOf DoubleClickRetrun
        VF.Show()
    End Sub

    Sub DoubleClickRetrun()

    End Sub




    Sub SetDate(ByVal D As Date)
        NowDay = D.Day
        LabelDay.Text = NowDay & "号"
        User_Date = D
    End Sub

    Public Up_Time As String = ""     '上班时间
    Public Down_Time As String = ""    '下班时间
    Public Remark As String = ""
    Public Remark_Mx As String = "" '√正常出勤▲请假★带薪假期●迟到■早退×旷工 ○上班无打卡 □下班无打卡
    Public CD As Integer = -1   '迟到分钟 0为没有迟到 -1为没有打卡
    Public ZT As Integer = -1   '早退分钟 0为没有早退 -1为没有打卡
    Public QQ As Integer = 0    '缺勤
    Public XX As Integer = 0    '休息
    Public CQ As Integer = 0    '出勤

    Public JB As Integer = 0    '加班
    Public BC As String = ""    '班次


    Public IsNew As Boolean = False '创建的时候不分析

    Private Sub Ini_Var()
        Up_Time = ""
        Down_Time = ""
        Remark = ""
        Remark_Mx = ""

        BC = "" '班次

        CD = -1 '迟到
        ZT = -1 '早退
        QQ = 0 '缺勤
        XX = 0 '休息
        CQ = 0 '出勤

        JB = 0
    End Sub


    Public Sub ComboBox_Data_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox_Data.SelectedValueChanged
        If IsNew Then
            Exit Sub
        End If
        If IsSel Then
            PF.ComboxSel(Me)
        End If
        If Is_Auto = False Then
            Exit Sub
        End If
        If ComboBox_Data.SelectedIndex >= 0 Then '没有选择班次
            If PF.Dt_At_Data IsNot Nothing Then '打卡表为空
                Dim R As DataRow = TryCast(ComboBox_Data.SelectedItem, DataRowView).Row
                Ini_Var()
                If LD Is Nothing OrElse LD.Equals(PF.Dt_At_Data) = False Then
                    LD = PF.Dt_At_Data
                    '获取当日的打卡记录
                    PD = DtRunSQLtoDt(LD, "Card_Date >= '" & User_Date.ToString("yyyy-MM-dd") & "' and Card_Date<='" & User_Date.AddDays(1).ToString("yyyy-MM-dd") & " 11:59:59.999' ", "Card_Date")
                End If
                Shift_Line = R("Line")
                BC = R("shift_id")
                If R("IsRest") = True Then
                    Remark = "★"
                    Remark_Mx = "休息"
                    CD = 0 '迟到
                    ZT = 0 '早退
                    XX = 1 '休息
                ElseIf IsLeave OrElse LLD Is Nothing OrElse LLD.Equals(PF.Dt_At_Leave) = False Then '请假
                    If LLD Is Nothing OrElse LLD.Equals(PF.Dt_At_Leave) = False Then
                        Dim LR() As DataRow = PF.Dt_At_Leave.Select("Employee_Date='" & User_Date.ToString("yyyy-MM-dd") & "'", "LE_ID desc")
                        If LR.Length > 0 Then
                            IsLeave = True
                            If LR(0)("Is_CQ") Then '带薪假期
                                Is_CQ = True
                            Else
                                Is_CQ = False
                            End If
                        Else
                            IsLeave = False
                        End If
                        LLD = PF.Dt_At_Data
                    End If
                    If IsLeave Then
                        If Is_CQ Then
                            Remark = "★"
                            Remark_Mx = "请假(带薪假期)"
                            CQ = 1
                            CD = 0 '迟到
                            ZT = 0 '早退
                        Else
                            Remark = "▲"
                            Remark_Mx = "请假"
                            CD = 0 '迟到
                            ZT = 0 '早退
                        End If


                    ElseIf R("No_CheckTime") = True Then '免打卡
                        CD = 0 '迟到
                        ZT = 0 '早退
                        CQ = 1 '出勤
                        Up_Time = R("UP_Time")
                        Down_Time = R("Down_Time")
                        Remark = "√"
                        Remark_Mx = "正常出勤"
                    Else '非休息的情况


                        ''''获取正常上班时间的大卡记录
                        Dim UpTime As Date = CDate(User_Date.ToString("yyyy-MM-dd") & " " & R("UP_Time"))
                        Dim DownTime As Date = CDate(User_Date.ToString("yyyy-MM-dd") & " " & R("Down_Time"))
                        If R("NextDay") Then
                            DownTime.AddDays(1)
                        End If
                        Dim SQL As String = "Card_Date >=  '" & UpTime.AddMinutes(-R("ZD_Max")).ToString("yyyy-MM-dd HH:mm") & "' and Card_Date<='" & DownTime.AddMinutes(R("CZ_Max")).ToString("yyyy-MM-dd HH:mm") & ":59.999'"
                        Dim Rows() As DataRow = PD.Select(SQL, "Card_Date")

                        Select Case Rows.Length
                            Case 0 '一次打卡都没有
                                Remark = "×"
                                Remark_Mx = "旷工,没有打卡"
                                QQ = 1 '缺勤
                            Case 1 '可能上班或下班没有打卡

                                Dim CDD As Date = CDate(Rows(0)("Card_Date"))
                                CD = DateDiff(DateInterval.Minute, UpTime, CDD) '迟到时长
                                ZT = DateDiff(DateInterval.Minute, CDD, DownTime) '早退时长

                                If Math.Abs(CD) <= Math.Abs(ZT) Then '上班打卡
                                    Up_Time = CDD.ToString("HH:mm")
                                    ZT = -1
                                    If R("ZT_Max") > 0 Then '无下班时间当旷工
                                        If (CD > R("CD_Max") AndAlso R("CD_Max") > 0) Then
                                            Remark = "×●□"
                                            Remark_Mx = "旷工,严重迟到并下班无打卡"
                                            QQ = 1 '缺勤
                                        Else
                                            If CD > R("CD_Min") Then
                                                Remark = "×●□"
                                                Remark_Mx = "旷工,迟到" & CD & "分钟并下班无打卡"
                                                CQ = 1 '出勤
                                            Else
                                                Remark = "×□"
                                                Remark_Mx = "旷工,下班无打卡"
                                                CQ = 1 '出勤
                                            End If
                                        End If
                                    Else
                                        If (CD > R("CD_Max") AndAlso R("CD_Max") > 0) Then
                                            Remark = "×●□"
                                            Remark_Mx = "旷工,严重迟到并下班无打卡"
                                            QQ = 1 '缺勤
                                        Else
                                            If CD > R("CD_Min") Then
                                                Remark = "●□"
                                                Remark_Mx = "迟到" & CD & "分钟并下班无打卡"
                                                CQ = 1 '出勤
                                            Else
                                                Remark = "□"
                                                Remark_Mx = "下班无打卡"
                                                CQ = 1 '出勤
                                            End If
                                        End If
                                    End If
                                Else '下班打卡
                                    Down_Time = CDD.ToString("HH:mm")
                                    CD = -1
                                    If R("CD_Max") > 0 Then '无上班时间当旷工
                                        If (ZT > R("ZT_Max") AndAlso R("ZT_Max") > 0) Then
                                            Remark = "×○■"
                                            Remark_Mx = "旷工,严重早退并上班无打卡"
                                            QQ = 1 '缺勤
                                        Else
                                            If ZT > R("ZT_Min") Then
                                                Remark = "×○■"
                                                Remark_Mx = "旷工,早退" & ZT & "分钟并上班无打卡"
                                                CQ = 1 '出勤
                                            Else
                                                Remark = "×○"
                                                Remark_Mx = "旷工,上班无打卡"
                                                CQ = 1 '出勤
                                            End If
                                        End If
                                    Else
                                        If (ZT > R("ZT_Max") AndAlso R("ZT_Max") > 0) Then
                                            Remark = "×○■"
                                            Remark_Mx = "旷工,严重早退并上班无打卡"
                                            QQ = 1 '缺勤
                                        Else
                                            If CD > R("ZT_Min") Then
                                                Remark = "○■"
                                                Remark_Mx = "早退" & ZT & "分钟并上班无打卡"
                                                CQ = 1 '出勤
                                            Else
                                                Remark = "○"
                                                Remark_Mx = "上班无打卡"
                                                CQ = 1 '出勤
                                            End If
                                        End If
                                    End If
                                End If


                            Case Else '2次卡或以上



                                Dim CDD As Date = CDate(Rows(0)("Card_Date"))
                                Up_Time = CDD.ToString("HH:mm")
                                CD = DateDiff(DateInterval.Minute, UpTime, CDD) '迟到时长


                                Dim ZTD As Date = CDate(Rows(Rows.Length - 1)("Card_Date"))
                                Down_Time = ZTD.ToString("HH:mm")
                                ZT = DateDiff(DateInterval.Minute, ZTD, DownTime) '早退时长


                                If CD <= R("CD_Min") AndAlso ZT <= R("ZT_Min") Then '正常出勤
                                    CD = 0
                                    ZT = 0
                                    Remark = "√"
                                    Remark_Mx = "正常出勤"
                                    CQ = 1 '出勤

                                ElseIf (CD > R("CD_Max") AndAlso R("CD_Max") > 0) Then '大于迟到时间 当旷工
                                    If (ZT > R("ZT_Max") AndAlso R("ZT_Max") > 0) Then '既然大于迟到时间 又 大于早退时间 当旷工
                                        Remark = "×●■"
                                        Remark_Mx = "旷工 严重迟到和早退"
                                        QQ = 1 '缺勤
                                    Else
                                        If ZT <= R("ZT_Min") Then
                                            Remark = "×●"
                                            Remark_Mx = "旷工 严重迟到"
                                            QQ = 1 '缺勤
                                            CD = 0
                                        Else
                                            Remark = "×●■"
                                            Remark_Mx = "旷工 早退" & ZT & "分钟并严重迟到"
                                            QQ = 1 '缺勤
                                        End If
                                    End If
                                ElseIf (ZT > R("ZT_Max") AndAlso R("ZT_Max") > 0) Then '大于早退时间 当旷工
                                    If CD <= R("CD_Min") Then
                                        Remark = "×●"
                                        Remark_Mx = "旷工 严重早退"
                                        QQ = 1 '缺勤
                                        ZT = 0
                                    Else
                                        Remark = "×●■"
                                        Remark_Mx = "旷工 迟到" & CD & "分钟并严重早退"
                                        QQ = 1 '缺勤
                                    End If
                                Else
                                    If CD > R("CD_Min") Then
                                        Remark = "●"
                                        Remark_Mx = "迟到" & CD & "分钟"
                                        CQ = 1 '出勤
                                    End If
                                    If ZT > R("ZT_Min") Then '早退
                                        Remark = Remark & "■"
                                        If Remark_Mx = "" Then
                                            Remark_Mx = "早退" & ZT & "分钟"
                                        Else
                                            Remark_Mx = Remark_Mx & "和早退" & ZT & "分钟"
                                        End If
                                        CQ = 1 '出勤
                                    End If
                                End If
                        End Select
                    End If '非休息的情况

                End If
            End If '打卡表为空
        End If '没有选择班次
        ShowRemark()
    End Sub

    Public Sub ShowRemark()
        LabelState.Text = Remark
        LabelState.ForeColor = BaseClass.Emplyee.RemarkToColor(Remark)
        ToolTip1.SetToolTip(Me, Remark_Mx)
        ToolTip1.SetToolTip(LabelState, Remark_Mx)
        LabelState.Tag = Remark_Mx
    End Sub

    Public IsSel As Boolean = False
    Private Sub UserDay_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PF.UserDayClick(Me, System.Windows.Forms.Control.ModifierKeys)
        End If
    End Sub

    Public Sub ShowSelColor()
        If IsSel Then
            Me.BackColor = Color.Orange
        Else
            Me.BackColor = Color.White
        End If
    End Sub

End Class
