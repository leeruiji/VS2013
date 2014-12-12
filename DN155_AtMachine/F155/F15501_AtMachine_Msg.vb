Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F15501_AtMachine_Msg
    Dim dtAt As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = ""
    End Sub

    Public Sub New(ByVal jID As String)
        Bill_ID = jID

        Me.Mode = Mode
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
      

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15500
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F15501_At_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            Bill_ID = ""
            TB_Founder.Text = PClass.PClass.User_Name
            TB_Founder.Tag = PClass.PClass.User_ID
        End If
        TB_ID.Text = Bill_ID
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = At_GetById(Bill_ID)
        If msg.IsOk Then
            dtAt = msg.Dt
            SetForm(msg.Dt)
        End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtAt.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("At_ID") = TB_ID.Text
            dr("At_Name") = TB_Name.Text

            dr("AT_IP") = TB_IP.Text
            dr("AT_Port") = TB_Port.Text
            dr("AT_Remark") = TB_Remark.Text

            dr("At_FindHelper") = StrGetPinYin(TB_Name.Text)

            dr("Founder") = TB_Founder.Tag
            dr("Found_Date") = DP_Found_Date.Value

            dr("UPD_USER") = PClass.PClass.User_ID
            dr("UPD_DATE") = DP_UPD_DATE.Value

            dt.Rows.Add(dr)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("At_ID"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("At_Name"), "")

            TB_IP.Text = IsNull(dt.Rows(0)("AT_IP"), "")
            TB_Port.Text = IsNull(dt.Rows(0)("AT_Port"), 0)
            TB_Remark.Text = IsNull(dt.Rows(0)("At_Remark"), "")


            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = BaseClass.ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))
            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If
            DP_Found_Date.Text = IsNull(dt.Rows(0)("Found_Date"), "")

            TB_UPD_USER.Text = BaseClass.ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Text = dt.Rows(0)("UPD_DATE")
            End If




        End If

    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then ShowConfirm("是否保存机具 [" & TB_Name.Text & "] 的修改?", AddressOf SaveAt)
    End Sub

    Protected Sub SaveAt()

        Dim R As MsgReturn

        If Me.Mode = Mode_Enum.Add Then
            R = At_Add(GetForm())
        Else
            R = At_Save(GetForm())
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_ID.Text = "" Then
            ShowErrMsg("机具编号不能为空")
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowErrMsg("机具名称不能为空")
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除机具 [" & TB_Name.Text & "]?", AddressOf DelAt)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelAt()
        Dim msg As MsgReturn = At_Del(TB_ID.Text)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region



    Private Sub Cmd_GetTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GetTime.Click
        Try
            ShowOk(GetAtMachineTime(TB_IP.Text, TB_Port.Text, TB_ID.Text))
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

    Private Sub Cmd_SetTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetTime.Click
        Try
            ShowOk(SetAtMachineTime(TB_IP.Text, TB_Port.Text, TB_ID.Text))
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

    Private Sub Cmd_DataIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DataIn.Click
        PClass.PClass.CaptureFromImageToPicture(Me, Pic_From)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Pic_From.BringToFront()
        Pic_From.Visible = True
        Tool_Top.Visible = False
        Me.Refresh()
        LabelMsg.Text = "开始获取数据"
        N = 0
        BW.RunWorkerAsync()
    End Sub


    Private Sub Cmd_DataSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CaptureFromImageToPicture(Me, Pic_From)
        LabelMsg.BringToFront()
        ProgressBar1.BringToFront()
        Pic_From.BringToFront()
        Pic_From.Visible = True
        Tool_Top.Visible = False
        LabelMsg.Text = "开始发送名单"
        N = 1
        BW.RunWorkerAsync()
    End Sub

#Region "BW"
    Dim N As Integer = 0
    Private Sub BW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        Dim StartTime As Date = DateTime.Now   '获得开始时间 
        Try
            Dim s As String = ""
            Select Case N
                Case 0
                    s = LoadAtMachineCard(TB_IP.Text, TB_Port.Text, TB_ID.Text, BW)
                Case 1
                    s = SendAtMachineName(TB_IP.Text, TB_Port.Text, TB_ID.Text, BW)
            End Select

            MsgBox(s & vbCrLf & "共用时间:" & Now.Subtract(StartTime).TotalSeconds & "秒", MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception
            FileClose(1)
            MsgBox(ex.ToString)
            Pic_From.Visible = False
            Tool_Top.Visible = True
        End Try
    End Sub

    Private Sub BW_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW.ProgressChanged
        ProgressBar1.Value = 1
        LabelMsg.Text = e.UserState.ToString
    End Sub

    Private Sub BW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW.RunWorkerCompleted
        LabelMsg.Text = "加载数据完毕!"
        Pic_From.Visible = False
        Tool_Top.Visible = True
    End Sub
#End Region



    ''' <summary>
    ''' 正常界面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetClockNormalMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetClockNormalMessage.Click
        Try
            Dim R As MsgReturn = SetClockNormalMessage(TB_IP.Text, TB_Port.Text, TB_ID.Text, TB_SetClockNormalMessage.Text)
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 启动界面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetFirstWindowDispString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetFirstWindowDispString.Click
        Try
            Dim R As MsgReturn = SetFirstWindowDispString(TB_IP.Text, TB_Port.Text, TB_ID.Text, TB_SetFirstWindowDispString.Text)
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 管理卡
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetManagerCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetManagerCard.Click
        Try
            Dim R As MsgReturn = SetManagerCard(TB_IP.Text, TB_Port.Text, TB_ID.Text, TB_ManagerCard.Text)
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

#Region "模式设置"
    ''' <summary>
    ''' 打卡间隔
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetRepeatClockerTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetRepeatClockerTime.Click
        Try
            Dim R As MsgReturn = SetRepeatClockerTime(TB_IP.Text, TB_Port.Text, TB_ID.Text, CInt(ND_RepeatClockerTime.Value))
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

#Region "工作模式"

    Private Sub Cmd_ReadMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReadMode.Click
        Try
            Dim Mode As Integer
            Dim ExtraMode As Integer
            Dim SystemMode As Integer
            Dim RingMode As Integer
            Dim R As MsgReturn = ReadClockMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, Mode, ExtraMode, SystemMode, RingMode)
            If R.IsOk Then
                Dim M As New ModeChange
                M.Mode = Mode
                SetMode(M)
                GB_Mode.Enabled = True
                Cmd_SetMode.Enabled = True
                Cmd_SetModeDefault.Enabled = True

                R = ReadRepeatClockerTime(TB_IP.Text, TB_Port.Text, TB_ID.Text, 0)
                If R.IsOk Then
                    ND_RepeatClockerTime.Value = CDec(Val(R.Msg))
                    PL_RepeatClockerTime.Enabled = True
                Else
                    ShowErrMsg(R.Msg)
                End If
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub
    Private Sub SetMode(ByVal M As ModeChange)
        CB_Mode_210.DataSource = System.Enum.GetNames(GetType(ModeChange.Enum_Mode_210))
        CB_Mode_210.Text = System.Enum.GetName(GetType(ModeChange.Enum_Mode_210), M.Mode_210)

        CB_Mode_3.Checked = M.Mode_3
        CB_Mode_54.DataSource = System.Enum.GetNames(GetType(ModeChange.Enum_Mode_54))
        CB_Mode_54.Text = System.Enum.GetName(GetType(ModeChange.Enum_Mode_54), M.Mode_54)
        CB_Mode_6.Checked = M.Mode_6
        CB_Mode_7.Checked = M.Mode_7
    End Sub

    Private Sub Cmd_SetMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetMode.Click
        Try
            Dim M As New ModeChange
            M.Mode = 0
            M.Mode_210 = System.Enum.Parse(GetType(ModeChange.Enum_Mode_210), CB_Mode_210.Text)
            M.Mode_54 = System.Enum.Parse(GetType(ModeChange.Enum_Mode_54), CB_Mode_54.Text)
            M.Mode_3 = CB_Mode_3.Checked
            M.Mode_6 = CB_Mode_6.Checked
            M.Mode_7 = CB_Mode_7.Checked
            Dim R As MsgReturn = SetClockMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, M.Mode)
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub

    Private Sub Cmd_SetModeDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetModeDefault.Click
        SetMode(New ModeChange With {.Mode = 113})
    End Sub

#End Region


#Region "扩展模式"
    Private Sub Cmd_ReadExtraMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReadExtraMode.Click
        Try
            Dim Mode As Integer
            Dim ExtraMode As Integer
            Dim SystemMode As Integer
            Dim RingMode As Integer
            Dim R As MsgReturn = ReadClockMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, Mode, ExtraMode, SystemMode, RingMode)
            If R.IsOk Then
                Dim M As New ModeChange
                M.ExtraMode = ExtraMode
                SetExtraMode(M)
                GB_ExtraMode.Enabled = True
                Cmd_SetExtraMode.Enabled = True
                Cmd_SetExtraModeDefault.Enabled = True
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub
    Private Sub SetExtraMode(ByVal M As ModeChange)
        CB_ExtraMode_765.DataSource = System.Enum.GetNames(GetType(ModeChange.Enum_ExtraMode_765))
        CB_ExtraMode_765.Text = System.Enum.GetName(GetType(ModeChange.Enum_ExtraMode_765), M.ExtraMode_765)

        CB_ExtraMode_0.Checked = M.ExtraMode_0
        CB_ExtraMode_1.Checked = M.ExtraMode_1
        CB_ExtraMode_2.Checked = M.ExtraMode_2
        CB_ExtraMode_3.Checked = M.ExtraMode_3
        CB_ExtraMode_4.Checked = M.ExtraMode_4
    End Sub
    Private Sub Cmd_SetExtraModeDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetExtraModeDefault.Click
        SetMode(New ModeChange With {.ExtraMode = 17})
    End Sub

    Private Sub Cmd_SetExtraMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetExtraMode.Click
        Try
            Dim M As New ModeChange
            M.ExtraMode = 0
            M.ExtraMode_765 = System.Enum.Parse(GetType(ModeChange.Enum_ExtraMode_765), CB_ExtraMode_765.Text)
            M.ExtraMode_0 = CB_ExtraMode_0.Checked
            M.ExtraMode_1 = CB_ExtraMode_1.Checked
            M.ExtraMode_2 = CB_ExtraMode_2.Checked
            M.ExtraMode_3 = CB_ExtraMode_3.Checked
            M.ExtraMode_4 = CB_ExtraMode_4.Checked

            Dim R As MsgReturn = SetClockExtraMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, M.ExtraMode)
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub
#End Region


#Region "系统模式"
    Private Sub Cmd_ReadSystemMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReadSystemMode.Click
        Try
            Dim Mode As Integer
            Dim ExtraMode As Integer
            Dim SystemMode As Integer
            Dim RingMode As Integer
            Dim R As MsgReturn = ReadClockMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, Mode, ExtraMode, SystemMode, RingMode)
            If R.IsOk Then
                Dim M As New ModeChange
                M.SystemMode = SystemMode
                SetSystemMode(M)
                GB_SystemMode.Enabled = True
                Cmd_SetSystemMode.Enabled = True
                Cmd_SetSystemModeDefault.Enabled = True
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub
    Private Sub SetSystemMode(ByVal M As ModeChange)
        CB_SystemMode_0.Checked = M.SystemMode_0
        CB_SystemMode_1.Checked = M.SystemMode_1
        CB_SystemMode_2.Checked = M.SystemMode_2
        CB_SystemMode_3.Checked = M.SystemMode_3
        CB_SystemMode_4.Checked = M.SystemMode_4
        CB_SystemMode_5.Checked = M.SystemMode_5
        CB_SystemMode_6.Checked = M.SystemMode_6
        CB_SystemMode_7.Checked = M.SystemMode_7
    End Sub
    Private Sub Cmd_SetSystemModeDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetSystemModeDefault.Click
        SetMode(New ModeChange With {.SystemMode = 103})
    End Sub

    Private Sub Cmd_SetSystemMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetSystemMode.Click
        Try
            Dim M As New ModeChange
            M.SystemMode = 0
            M.SystemMode_0 = CB_SystemMode_0.Checked
            M.SystemMode_1 = CB_SystemMode_1.Checked
            M.SystemMode_2 = CB_SystemMode_2.Checked
            M.SystemMode_3 = CB_SystemMode_3.Checked
            M.SystemMode_4 = CB_SystemMode_4.Checked
            M.SystemMode_5 = CB_SystemMode_5.Checked
            M.SystemMode_6 = CB_SystemMode_6.Checked
            M.SystemMode_7 = CB_SystemMode_7.Checked
            Dim R As MsgReturn = SetClockSystemMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, M.SystemMode)
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub
#End Region

#Region "响铃模式"
    Private Sub Cmd_ReadRingMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReadRingMode.Click
        Try
            Dim Mode As Integer
            Dim ExtraMode As Integer
            Dim SystemMode As Integer
            Dim RingMode As Integer
            Dim R As MsgReturn = ReadClockMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, Mode, ExtraMode, SystemMode, RingMode)
            If R.IsOk Then
                Dim M As New ModeChange
                M.RingMode = RingMode
                SetRingMode(M)
                GB_RingMode.Enabled = True
                Cmd_SetRingMode.Enabled = True
                Cmd_SetRingModeDefault.Enabled = True
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub
    Private Sub SetRingMode(ByVal M As ModeChange)
        CB_RingMode_0.Checked = M.RingMode_0
        CB_RingMode_1.Checked = M.RingMode_1
        CB_RingMode_2.Checked = M.RingMode_2
        CB_RingMode_3.Checked = M.RingMode_3
        CB_RingMode_4.Checked = M.RingMode_4
        CB_RingMode_5.Checked = M.RingMode_5
        CB_RingMode_76.DataSource = System.Enum.GetNames(GetType(ModeChange.Enum_RingMode_76))
        CB_RingMode_76.Text = System.Enum.GetName(GetType(ModeChange.Enum_RingMode_76), M.RingMode_76)
    End Sub
    Private Sub Cmd_SetRingModeDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetRingModeDefault.Click
        SetMode(New ModeChange With {.RingMode = 31})
    End Sub

    Private Sub Cmd_SetRingMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetRingMode.Click
        Try
            Dim M As New ModeChange
            M.RingMode = 0
            M.RingMode_0 = CB_RingMode_0.Checked
            M.RingMode_1 = CB_RingMode_1.Checked
            M.RingMode_2 = CB_RingMode_2.Checked
            M.RingMode_3 = CB_RingMode_3.Checked
            M.RingMode_4 = CB_RingMode_4.Checked
            M.RingMode_5 = CB_RingMode_5.Checked
            M.RingMode_76 = System.Enum.Parse(GetType(ModeChange.Enum_RingMode_76), CB_RingMode_76.Text)
            Dim R As MsgReturn = SetClockRingMode(TB_IP.Text, TB_Port.Text, TB_ID.Text, M.RingMode)
            If R.IsOk Then
                ShowOk(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        Catch ex As Exception
            ShowErrMsg(ex.ToString)
        End Try
    End Sub
#End Region

#End Region









End Class
