Imports System.Data
Imports PClass.PClass
Imports DN990_BaseSetting.R99003_Card
Imports System.Text
Imports BaseClass

Public Class F990031_Employee_Msg
    '原始id
    Dim employeeID As String = ""
    Dim isLoaded As Boolean = False
    Dim Dt_Employee As DataTable

    Public Const EMPLOYEE_FILE_TYPE_ZHENGSHI = "正式"
    Public Const EMPLOYEE_FILE_TYPE_SHIYONG = "使用"
    Public Const EMPLOYEE_FILE_TYPE_LIZHI = "离职"
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    Public Sub New(ByVal employeeID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.employeeID = employeeID
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15000



        '  Control_CheckRight(ID, ClassMain.Employee & ClassMain.Add, Cmd_AddEmployee)

        Control_CheckRight(ID, ClassMain.Employee & ClassMain.Modify, Cmd_SaveEmployee)
        Control_CheckRight(ID, ClassMain.Employee & ClassMain.Del, Cmd_DelEmployee)
        Control_CheckRight(ID, ClassMain.Employee & ClassMain.Quit, Cmd_QuitEmployee)
        Control_CheckRight(ID, ClassMain.Employee & ClassMain.Print, Cmd_Print)
    End Sub

    Private Sub F990031_Employee_Msg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormCheckRight()
        Dim dtSheftMoudel As DataTable = ComFun.Sheft_GetSheftMoudel()
        If dtSheftMoudel IsNot Nothing Then
            dtSheftMoudel.Rows.InsertAt(dtSheftMoudel.NewRow, 0)
            CB_SheftModel.ValueMember = "ID"
            CB_SheftModel.DisplayMember = "Name"
            CB_SheftModel.DataSource = dtSheftMoudel
        End If
        Reload()

     
        isLoaded = True
    End Sub
    Protected Sub Reload()
        Dim dtRoomNo As DataTable
        Dim msgRoomNo As DtReturnMsg = Dao.Room_GetRoomNo()
        If msgRoomNo.IsOk Then
            dtRoomNo = msgRoomNo.Dt
            dtRoomNo.Rows.InsertAt(dtRoomNo.NewRow, 0)
            CB_Room.DataSource = dtRoomNo
        End If
        Dim msg As DtReturnMsg = Employee_GetById(employeeID)
        If msg.IsOk Then
            Dt_Employee = msg.Dt
            SetEmployeeInfo(Dt_Employee)
        End If

        If Me.Mode = Mode_Enum.Add Then
            TextBox_EmployeeID.Text = Employee_GetNewID()
            Cmd_Print.Enabled = False
            Cmd_CreateUser.Enabled = False
            Cmd_QuitEmployee.Enabled = False
            TextBox_EmployeeDept.Tag = Me.P_F_RS_ID
            TextBox_EmployeeDept.Text = Me.P_F_RS_ID2

            CB_EFileType.SelectedIndex = 0
            CB_ENation.SelectedIndex = 0
            CB_IsMarried.SelectedIndex = 0
            CB_Sex.SelectedIndex = 0
            CB_Education.SelectedIndex = 0

            DP_Birthdate.Value = GetDate()




        End If
        Cmd_Shift_Change.Enabled = False
    End Sub

#Region "工具栏事件"


    ''''==========================员工===========================
    ''' =====================================员工信息=========================
    Private Sub Btn_Save_E_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SaveEmployee.Click
        If CheckForm_Employee() Then
            If Me.Mode = Mode_Enum.Add Then
                Dim R As DtReturnMsg = Dao.Employee_GetDtByName(TextBox_EmpolyeeName.Text)
                If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                    If IsNull(R.Dt.Rows(0)("Employee_FileType"), "") = "离职" Then
                        Me.ShowConfirm("[" & TextBox_EmpolyeeName.Text & "]已存在，并于[" & IsNull(R.Dt.Rows(0)("Employee_QuitDate"), "") & "]已离职，录入新员工信息？", AddressOf SaveEmployee)
                    Else
                        Me.ShowConfirm("[" & TextBox_EmpolyeeName.Text & "]已存在，录入新员工信息？", AddressOf SaveEmployee)
                    End If
                Else

                    ShowConfirm("是否保存员工 [" & TextBox_EmpolyeeName.Text & "]?", AddressOf SaveEmployee)
                End If
            Else
                ShowConfirm("是否保存员工 [" & TextBox_EmpolyeeName.Text & "]?", AddressOf SaveEmployee)
            End If

        End If
    End Sub

    Protected Sub SaveEmployee()
        Dim B As Boolean
        If Me.Mode = Mode_Enum.Add Then


 
            B = Employee_AddSave()



        Else
            B = Employee_ModifySave()
            '   selectedDept = TextBox_EmployeeID.Text
        End If
        If B Then
            Me.Close()
            TextBox_EmployeeID.Tag = -1
        End If
    End Sub

    Private Sub Btn_Quit_E_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_QuitEmployee.Click

        If CheckForm_Employee() Then ShowConfirm("是否标记员工 [" & TextBox_EmpolyeeName.Text & "]离职?", AddressOf QuitEmployee)

    End Sub

    Protected Sub QuitEmployee()
        If Employee_GetById(TextBox_EmployeeID.Text).Dt.Rows.Count <= 0 Then
            ShowErrMsg("只能对现有员工标记离职!")
            Exit Sub
        ElseIf Dt_Employee.Rows(0)("Employee_FileType") = "离职" Then
            ShowErrMsg(TextBox_EmpolyeeName.Text & "已经离职!")
            Exit Sub
        End If
        If Mode = Mode_Enum.Modify Then


            CB_EFileType.SelectedIndex = 2
            '当该员工下有卡时，并且卡未过时，吧卡设置成过时
            If TB_EmployeeCard.Text <> "" AndAlso DP_CardEndDate.Checked = False Then
                DP_CardEndDate.Checked = True
                DP_CardEndDate.Value = GetTime()
            End If
            If Employee_ModifySave() Then
                User_UpdateStateByEmploeeID(TextBox_EmployeeID.Text, True)
                Reload()
                'If Not TB_EmployeeCard.Text = "" Then
                '    InsertCardHistory()
                'End If

            Else
                ShowErrMsg("员工 [" & TextBox_EmpolyeeName.Text & "]标记离职失败!")
            End If

        End If
    End Sub

    Private Function InsertCardHistory() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim Employee_Dept As String = TextBox_EmployeeID.Text
        Try

            sql = "select top 0 * from T15004_CardHistory "
            dt = SqlStrToDt(sql, Cnn, Da).Dt
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
                dt.Rows(0)("Employee_No") = TextBox_EmployeeID.Text
                dt.Rows(0)("Card") = TB_EmployeeCard.Text
                dt.Rows(0)("StartDate") = DP_CardStartDate.Value.Date
                dt.Rows(0)("EndDate") = Today
                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("员工卡:[" & TextBox_EmployeeID.Text & "] 已经存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("添加员工卡记录:[" & TextBox_EmployeeID.Text & "] 错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 根据员工信息生成一个用户
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_CreateUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CreateUser.Click
        If Me.CB_EFileType.SelectedIndex = 2 Then
            ShowErrMsg("已标记离职,不能注册用户!")
            Exit Sub
        End If
        If Me.Mode = Mode_Enum.Modify AndAlso CheckForm_Employee() Then
            If TB_USer_ID.Text = "" Then


                Dim msg As DtReturnMsg = User_GetByEmployeeId(TextBox_EmployeeID.Text)
                If Not msg.IsOk Then
                    ShowErrMsg(msg.Msg)
                    Exit Sub
                End If

                If msg.Dt.Rows.Count > 0 Then
                    ShowErrMsg("员工[" & TextBox_EmpolyeeName.Text & "] 已经注册用户!")

                Else
                    ShowUserMsg(TB_USer_ID.Text, TextBox_EmployeeID.Text, Mode_Enum.Add)
                End If

            Else
                ShowUserMsg(TB_USer_ID.Text, TextBox_EmployeeID.Text, Mode_Enum.Modify)

            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowUserMsg(ByVal User_ID As String, ByVal Employee_ID As String, ByVal mode As Mode_Enum)
        Dim F As New F990032_User_Msg(User_ID, Employee_ID, False)
        With F
            .Mode = mode
            .P_F_RS_ID = TextBox_EmployeeDept.Tag
            .P_F_RS_ID2 = TextBox_EmployeeDept.Text
            .P_F_RS_ID3 = TextBox_EmpolyeeName.Text
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetUser
        VF.Show()
    End Sub
    Protected Sub SetUser()
        Reload()
    End Sub

    Protected Function CheckForm_Employee() As Boolean
        If TextBox_EmpolyeeName.Text = "" Then
            ShowErrMsg("员工名称不能为空")
            TextBox_EmpolyeeName.Focus()
            Return False
        End If
        If TextBox_EmployeeDept.Text = "" Then
            ShowErrMsg("员工部门名称不能为空")
            TextBox_EmployeeDept.Focus()
            Return False
        End If

        If TextBox_EmployeeDept.Tag Is Nothing Then
            ShowErrMsg("员工部门不能为空")
            TextBox_EmployeeDept.Focus()
            Return False
        End If
        If Not CheckCard() Then
            Return False
        End If

        Return True
    End Function

    Private Sub Btn_Del_E_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DelEmployee.Click
        ShowConfirm("是否删除员工 [" & TextBox_EmpolyeeName.Text & "]?", AddressOf DelEmployee)
    End Sub

    Protected Sub DelEmployee()
        Dim msg As MsgReturn = Employee_Del(TextBox_EmployeeID.Text)
        If msg.IsOk Then

            '   selectedDept = "D0"
            '   ReLoad()
            Dim msgE As DtReturnMsg = Employee_GetById("Employee_No")
            Dim dtE As DataTable = msgE.Dt
            If dtE.Rows.Count > 0 Then
                dtE.Clear()
            End If
            dtE.Rows.Add(dtE.NewRow)

            SetEmployeeInfo(dtE)
            Me.Close()
        End If
    End Sub








    '=================表单按钮============
    ''' <summary>
    ''' 选择部门
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_ChoseDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseDept.Click

        Dim F As New F99004_Department_Sel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetDeptForEmployee
        VF.Show()
    End Sub


    Protected Sub SetDeptForEmployee()
        If Not ReturnId = "" OrElse Not ReturnObj Is Nothing Then
            Me.TextBox_EmployeeDept.Text = Me.ReturnObj
            Me.TextBox_EmployeeDept.Tag = Me.ReturnId

        End If
    End Sub



    ''' <summary>
    ''' 选择职位
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_ChoseJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseJob.Click

        Dim F As New F99005_Job(TextBox_EmployeeDept.Tag)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .IsSel = True
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetJob
        VF.Show()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetJob()
        Try
            If Not ReturnId = "" OrElse Not ReturnObj Is Nothing Then
                Me.TB_Job.Text = TryCast(Me.ReturnObj, DataRow)("Job_Name")
                Me.TB_Job.Tag = Me.ReturnId

            End If
        Catch ex As Exception
            ShowErrMsg("无法获取相关职位!")
        End Try
    End Sub


    '===================
    ''' <summary>
    ''' 打开文件选择框
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_ChooseImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChooseImage.Click
        OFD_EmP.Filter = "JPG图片|*.Jpg"
        OFD_EmP.FileName = ""
        If Me.OFD_EmP.ShowDialog() = DialogResult.OK Then
            Pb_Employee.ImageLocation = OFD_EmP.FileName
            Dim ImagArray As Byte()
            Try
                Using io As New IO.FileStream(Pb_Employee.ImageLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    ReDim ImagArray(io.Length - 1)
                    io.Read(ImagArray, 0, io.Length)
                    Dim bmp As New Bitmap(io)
                    Pb_Employee.Image = bmp
                    Pb_Employee.Tag = ImagArray
                End Using
            Catch ex As Exception
                ShowErrMsg("图片格式不正确!")
            End Try
        End If
    End Sub







    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_ClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ClearImage.Click
        Pb_Employee.Tag = Nothing
        Pb_Employee.Image = Nothing
    End Sub



#End Region
#Region "报表"
    Private Sub Btn_Print_Click(ByVal sender As ToolStripMenuItem, ByVal e As System.EventArgs) Handles Cmd_PrintManager.Click

        PreView(Enum_PrintStyle.Manager)
    End Sub

    Private Sub Btn_PrintNormal_Click(ByVal sender As ToolStripMenuItem, ByVal e As System.EventArgs) Handles Cmd_PrintNormal.Click
        PreView(Enum_PrintStyle.Normal)
    End Sub

    Private Sub Btn_PrintSecurity_Click(ByVal sender As ToolStripMenuItem, ByVal e As System.EventArgs) Handles Cmd_PrintBaoAn.Click

        PreView(Enum_PrintStyle.Security)
    End Sub

    Sub PreView(ByVal style As Enum_PrintStyle)
        If Me.Mode = Mode_Enum.Add Then
            ShowErrMsg("员工信息未保存不能打印!")
            Exit Sub
        End If
        If TextBox_EmployeeID.Text.Trim.Length > 0 Then
            Dim rptLoader As New R99003_Card()
            rptLoader.Start(TextBox_EmployeeID.Text, PClass.CReport.OperatorType.Preview, style)
        End If
    End Sub
#End Region

#Region "员工详细信息"

    ''' <summary>
    ''' 员工表单赋值
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub SetEmployeeInfo(ByRef dt As DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Exit Sub
        End If
        TextBox_EmployeeID.Tag = IsNull(dt.Rows(0)("ID"), 0)
        TextBox_EmployeeID.Text = IsNull(dt.Rows(0)("Employee_No"), "")
        TextBox_EmpolyeeName.Text = IsNull(dt.Rows(0)("Employee_Name"), "")
        TextBox_EmployeeDept.Tag = IsNull(dt.Rows(0)("Employee_Dept"), "")
        If Not IsNull(dt.Rows(0)("GroupName"), "") = "" Then
            TextBox_EmployeeDept.Text = IsNull(dt.Rows(0)("Dept_Name"), "") & "/" & IsNull(dt.Rows(0)("GroupName"), "")
        Else
            TextBox_EmployeeDept.Text = IsNull(dt.Rows(0)("Dept_Name"), "")
        End If

        If Not dt.Rows(0)("Employee_Birthdate") Is DBNull.Value Then
            DP_Birthdate.Value = dt.Rows(0)("Employee_Birthdate")
            CaculateAge(DP_Birthdate.Value)
        End If

        CB_Sex.Text = IsNull(dt.Rows(0)("Employee_Sex"), "")
        TextBox_IDCard.Text = IsNull(dt.Rows(0)("Employee_IDCard"), "")
        CB_ENation.Text = IsNull(dt.Rows(0)("Employee_Nation"), "")
        TB_JiGuan.Text = IsNull(dt.Rows(0)("Employee_JiGuan"), "")
        If IsNull(dt.Rows(0)("Employee_IsMarried"), False) = True Then
            CB_IsMarried.SelectedIndex = 1
        Else
            CB_IsMarried.SelectedIndex = 0
        End If

        CB_Education.Text = IsNull(dt.Rows(0)("Employee_Education"), "")
        CB_EFileType.Text = IsNull(dt.Rows(0)("Employee_FileType"), "")
        If CB_EFileType.Text = EMPLOYEE_FILE_TYPE_LIZHI Then
            LB_Quit.Visible = True
            DP_QuitDate.Visible = True
            Cmd_QuitEmployee.Enabled = False
            Cmd_QuitEmployee.Text = "已经离职"
        End If
        CB_QuitType.Text = IsNull(dt.Rows(0)("Employee_QuitType"), "")

        TextBox_EmployeeEmail.Text = IsNull(dt.Rows(0)("Employee_Email"), "")
        TextBox_EmployeePhone.Text = IsNull(dt.Rows(0)("Employee_Phone"), "")
        TB_MailNum.Text = IsNull(dt.Rows(0)("Employee_MailNum"), "")
        TB_Contact.Text = IsNull(dt.Rows(0)("Employee_Contact"), "")
        TB_ContactNum.Text = IsNull(dt.Rows(0)("Employee_ContactNum"), "")
        RichTextBox_JL.Text = IsNull(dt.Rows(0)("Employee_Note"), "")
        TB_Job.Text = IsNull(dt.Rows(0)("Job_Name"), "")
        TB_Job.Tag = IsNull(dt.Rows(0)("Employee_Job"), 0)
        If Not dt.Rows(0)("Employee_FirstDate") Is DBNull.Value Then
            DP_FirstDate.Value = dt.Rows(0)("Employee_FirstDate")
        End If

        If Not dt.Rows(0)("Employee_SignDate") Is DBNull.Value Then
            DP_SignDate.Value = dt.Rows(0)("Employee_SignDate")
        End If
        If Not dt.Rows(0)("Employee_SignLastDate") Is DBNull.Value Then
            DP_SignLastDate.Value = dt.Rows(0)("Employee_SignLastDate")
        End If
        If Not dt.Rows(0)("Employee_QuitDate") Is DBNull.Value Then
            DP_QuitDate.Value = dt.Rows(0)("Employee_QuitDate")
        End If
        TB_Hight.Text = IsNull(dt.Rows(0)("Employee_Hight"), "")
        TB_HuKu.Text = IsNull(dt.Rows(0)("Employee_HuKou"), "")
        '  TB_School.Text = IsNull(dt.Rows(0)("Employee_School"), "")
        If Not dt.Rows(0)("Employee_Picture") Is DBNull.Value Then
            Dim arr As Byte() = dt.Rows(0)("Employee_Picture")
            Using io As New IO.MemoryStream(arr, 0, arr.Length - 1)

                Dim bmp As New Bitmap(io)
                Pb_Employee.Tag = arr
                Pb_Employee.Image = bmp
            End Using
        Else
            Pb_Employee.Image = Nothing
            Pb_Employee.Tag = Nothing
        End If

        CB_Room.Text = IsNull(dt.Rows(0)("Employee_Room"), "")
        TB_Bed.Text = IsNull(dt.Rows(0)("Employee_Bed"), "")
        ''员工卡
        CKB_IsShuiKa.Checked = IsNull(dt.Rows(0)("Employee_IsShuiKa"), False)
        CB_SheftModel.SelectedValue = IsNull(dt.Rows(0)("Employee_ShiftMoudel"), 0)
        CB_SheftModel.Text = IsNull(dt.Rows(0)("Employee_ShiftMoudel_Name"), 0)
        TB_Shift_Remark.Text = IsNull(dt.Rows(0)("Employee_Shift_RemarK"), "")
        TB_EmployeeCard.Text = IsNull(dt.Rows(0)("Employee_Card"), "")
        If Not dt.Rows(0)("Employee_CardStartDate") Is DBNull.Value Then
            DP_CardStartDate.Value = dt.Rows(0)("Employee_CardStartDate")
        End If
        If Not dt.Rows(0)("Employee_CardEndDate") Is DBNull.Value Then
            DP_CardEndDate.Value = dt.Rows(0)("Employee_CardEndDate")

        Else
            DP_CardEndDate.Value = New Date(2099, 1, 1)
            DP_CardEndDate.Checked = False
        End If
        '班次生效日期

        If Not dt.Rows(0)("Employee_Shift_StartDate") Is DBNull.Value Then
            DTP_Shift_StartDate.Value = dt.Rows(0)("Employee_Shift_StartDate")

        Else
            DTP_Shift_StartDate.Value = Today
            '  DTP_Shift_StartDate.Checked = False
        End If
        If Not dt.Rows(0)("User_ID") Is DBNull.Value Then
            LB_User_ID.Visible = True
            '    TB_USer_ID.Visible = True
            Cmd_CreateUser.Text = "修改用户"
            TB_USer_ID.Text = dt.Rows(0)("User_ID")
        End If

        If Not dt.Rows(0)("User_Name") Is DBNull.Value Then
            LB_User_Name.Visible = True

            TB_User_Name.Text = dt.Rows(0)("User_Name")
        End If

        If Not dt.Rows(0)("User_DisPlay") Is DBNull.Value Then
            LB_User_Display.Visible = True
            TB_User_Display.Text = dt.Rows(0)("User_DisPlay")
        End If

    End Sub

    ''' <summary>
    ''' 员工表单赋值
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub GetEmployeeInfo(ByRef dt As DataTable)

        dt.Rows(0)("Employee_No") = TextBox_EmployeeID.Text
        dt.Rows(0)("Employee_Name") = TextBox_EmpolyeeName.Text
        dt.Rows(0)("Employee_Dept") = TextBox_EmployeeDept.Tag


        dt.Rows(0)("Employee_Birthdate") = DP_Birthdate.Value


        dt.Rows(0)("Employee_Sex") = CB_Sex.Text
        dt.Rows(0)("Employee_IDCard") = TextBox_IDCard.Text
        dt.Rows(0)("Employee_Nation") = CB_ENation.Text
        dt.Rows(0)("Employee_JiGuan") = TB_JiGuan.Text

        dt.Rows(0)("Employee_IsMarried") = IIf(CB_IsMarried.SelectedIndex = 1, True, False)


        dt.Rows(0)("Employee_Education") = CB_Education.Text
        dt.Rows(0)("Employee_FileType") = CB_EFileType.Text
        dt.Rows(0)("Employee_Email") = TextBox_EmployeeEmail.Text
        dt.Rows(0)("Employee_Phone") = TextBox_EmployeePhone.Text
        dt.Rows(0)("Employee_MailNum") = TB_MailNum.Text
        dt.Rows(0)("Employee_Contact") = TB_Contact.Text
        dt.Rows(0)("Employee_ContactNum") = TB_ContactNum.Text
        dt.Rows(0)("Employee_Note") = RichTextBox_JL.Text
        If TB_Job.Tag Is Nothing Then
            TB_Job.Tag = 0

        End If
        dt.Rows(0)("Employee_Job") = TB_Job.Tag

        dt.Rows(0)("Employee_FirstDate") = DP_FirstDate.Value.Date
        dt.Rows(0)("Employee_SignDate") = DP_SignDate.Value.Date
        dt.Rows(0)("Employee_SignLastDate") = DP_SignLastDate.Value.Date

        If CB_EFileType.Text = F990031_Employee_Msg.EMPLOYEE_FILE_TYPE_LIZHI Then
            dt.Rows(0)("Employee_QuitDate") = DP_QuitDate.Value.Date
            dt.Rows(0)("Employee_QuitType") = CB_QuitType.Text
        Else
            '状态不是离职是吧离职日期设置为null
            dt.Rows(0)("Employee_QuitDate") = DBNull.Value
        End If



        dt.Rows(0)("Employee_HuKou") = TB_HuKu.Text
        dt.Rows(0)("Employee_Hight") = Val(TB_Hight.Text)
        ' dt.Rows(0)("Employee_School") = TB_School.Text

        If Not Pb_Employee.Tag Is Nothing Then
            dt.Rows(0)("Employee_Picture") = Pb_Employee.Tag
        Else
            dt.Rows(0)("Employee_Picture") = DBNull.Value

        End If

        dt.Rows(0)("Employee_Room") = CB_Room.Text
        dt.Rows(0)("Employee_Bed") = TB_Bed.Text

        ''员工卡记录
        If Mode = Mode_Enum.Add Then

            dt.Rows(0)("Employee_Card") = TB_EmployeeCard.Text
            dt.Rows(0)("Employee_CardStartDate") = DP_CardStartDate.Value
        End If
        dt.Rows(0)("Employee_IsShuiKa") = CKB_IsShuiKa.Checked
        If DP_CardEndDate.Checked Then
            dt.Rows(0)("Employee_CardEndDate") = DP_CardEndDate.Value
        Else
            dt.Rows(0)("Employee_CardEndDate") = DBNull.Value
        End If
        ' If DTP_Shift_StartDate.Checked Then
        'dt.Rows(0)("Employee_Shift_StartDate") = DTP_Shift_StartDate.Value
        '   Else
        '   dt.Rows(0)("Employee_Shift_StartDate") = DBNull.Value
        '   End If

        dt.Rows(0)("Employee_FindHelper") = StrGetPinYin(TextBox_EmpolyeeName.Text)
        'If CB_SheftModel.SelectedValue IsNot Nothing Then
        '    dt.Rows(0)("Employee_ShiftMoudel") = CB_SheftModel.SelectedValue
        'End If
        'dt.Rows(0)("Employee_ShiftMoudel_Name") = CB_SheftModel.Text

    End Sub
#End Region

#Region "数据库交互"

#Region "检查卡号是否重复"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckCard() As Boolean
        If TB_EmployeeCard.Text = "" Then
            Return True
        End If
        Dim sqlStr As String = " select * from V15001_Employee where Employee_Card=@Employee_Card and Employee_No<>@Employee_No and Employee_CardEndDate is null"
        Dim p As New Dictionary(Of String, Object)
        p.Add("Employee_Card", TB_EmployeeCard.Text)

        p.Add("Employee_No", TextBox_EmployeeID.Text)
        Dim msg As DtReturnMsg = SqlStrToDt(sqlStr, p)
        Dim errMsg As New StringBuilder

        If msg.IsOk Then
            If msg.Dt.Rows.Count > 0 Then
                errMsg.AppendLine("员工卡[" & TextBox_EmployeeID.Text & "]已被其他员工【" & msg.Dt.Rows(0)("Employee_Name") & "】【" & msg.Dt.Rows(0)("Employee_No") & "】使用！")
                ShowErrMsg(errMsg.ToString, AddressOf TB_EmployeeCard.Focus)
                Return False
            Else
                Return True
            End If
        Else
            ShowErrMsg("检查卡号是发生错误！", AddressOf TB_EmployeeCard.Focus)
            Return False
        End If
    End Function


#End Region



#Region "增删改"



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Employee_AddSave() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim Employee_Dept As String = TextBox_EmployeeID.Text
        Try

            sql = "select top 1 * from T15001_Employee where Employee_No=@Employee_No order by Employee_No"
            dt = SqlStrToDt(sql, Cnn, Da, "Employee_No", Employee_Dept).Dt
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
                GetEmployeeInfo(dt)


                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("员工:[" & TextBox_EmployeeID.Text & "] 已经存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("添加员工:[" & TextBox_EmployeeID.Text & "] 错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function

    Public Function Employee_ModifySave() As Boolean


        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim eId As String = TextBox_EmployeeID.Tag
        paraMap.Add("@ID", eId)
        paraMap.Add("@Employee_No", Me.employeeID)
        paraMap.Add("@EmployeeID", TextBox_EmployeeID.Text)

        ' Dim SQL As String = ""
        'If Me.employeeID <> TextBox_EmployeeID.Text Then
        '    SQL = "Update T15004_CardHistory set Employee_No='" & TextBox_EmployeeID.Text & "' where Employee_No='" & Me.employeeID & "'"
        'End If


        If Val(SqlStrToOneStr("select Count(*) from V15001_Employee where ID<>@ID and Employee_No=@EmployeeID", paraMap).Msg) > 0 Then
            msg.IsOk = False
            ShowErrMsg("员工[" & TextBox_EmpolyeeName.Text & "]修改失败!" & "员工编号[" & TextBox_EmployeeID.Text & "]已存在")
            Return False
        End If




        Try
            sqlMap.Add("Employee", " select top 1 * from T15001_Employee where ID=@ID ")
            sqlMap.Add("User", "select top 1 * from User_Info where Employee_No=@Employee_No ")


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Employee").Rows.Count = 1 Then


                GetEmployeeInfo(msg.DtList("Employee"))

                If Not msg.DtList("User") Is Nothing And msg.DtList("User").Rows.Count > 0 Then
                    msg.DtList("User").Rows(0)("Employee_No") = TextBox_EmployeeID.Text
                End If
                '如果卡号跟原来不一样，则更新卡号，并将就卡号写入history
                If IsNull(msg.DtList("Employee").Rows(0)("Employee_Card"), "") <> "" AndAlso Not msg.DtList("Employee").Rows(0)("Employee_Card") = TB_EmployeeCard.Text Then
                    Dim InsertHistory As String = "insert into T15004_CardHistory (ID,Card,StartDate,EndDate) values (@ID,@Card,@StartDate,@EndDate)"

                    Dim pc As New Dictionary(Of String, Object)
                    pc.Add("ID", msg.DtList("Employee").Rows(0)("ID"))
                    pc.Add("Card", msg.DtList("Employee").Rows(0)("Employee_Card"))
                    pc.Add("StartDate", msg.DtList("Employee").Rows(0)("Employee_CardStartDate"))
                    pc.Add("EndDate", GetTime())
                    msg.DtList("Employee").Rows(0)("Employee_Card") = TB_EmployeeCard.Text
                    msg.DtList("Employee").Rows(0)("Employee_CardStartDate") = DP_CardStartDate.Value
                    DtToUpDate(msg, InsertHistory, pc)
                Else
                    If IsNull(msg.DtList("Employee").Rows(0)("Employee_Card"), "") = "" Then
                        msg.DtList("Employee").Rows(0)("Employee_Card") = TB_EmployeeCard.Text
                    End If
                    DtToUpDate(msg)
                End If
                '  If SQL = "" Then
                '   DtToUpDate(msg)
                'Else
                '    DtToUpDate(msg, SQL)
                'End If


                msg.Msg = "员工[" & TextBox_EmpolyeeName.Text & "]修改成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                ShowErrMsg("员工[" & TextBox_EmpolyeeName.Text & "]修改失败!")
            End If

            Return True
        Catch ex As Exception
            msg.IsOk = False
            ShowErrMsg("员工[" & TextBox_EmpolyeeName.Text & "]修改失败!")
            DebugToLog(ex)
            Return False
        Finally
        End Try
    End Function


#End Region


#End Region

#Region "员工卡记录"
    '''' <summary>
    '''' 设置卡后后,回车设置起效日期
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub TB_EployeeCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_EmployeeCard.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        DP_CardStartDate.Focus()
    '        DP_CardStartDate.Value = GetTime()
    '    End If
    'End Sub

    Private Sub Btn_CheckCardHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CheckCardHistory.Click

        Dim F As New F99008_CardHistory
        With F
            .Mode = Mode_Enum.Look
            .P_F_RS_ID = Dt_Employee.Rows(0)("ID")
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)

        VF.Show()
    End Sub
    ''' <summary>
    ''' 修改卡号时，卡结束时间打钩，并且赋值为当前日期
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_EmployeeCard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_EmployeeCard.TextChanged
        If isLoaded = True Then
            ''  DP_CardEndDate.Checked = True
            If Dt_Employee.Rows.Count = 0 Then
                DP_CardStartDate.Value = GetTime()
            Else
                If TB_EmployeeCard.Text = IsNull(Dt_Employee.Rows(0)("Employee_Card"), "") Then
                    'DP_CardEndDate.Checked = False
                    '   DP_CardEndDate.Enabled = True
                    DP_CardStartDate.Value = IsNull(Dt_Employee.Rows(0)("Employee_CardStartDate"), GetTime)
                Else
                    '  DP_CardStartDate.Focus()
                    DP_CardStartDate.Value = GetTime()
                    DP_CardEndDate.Checked = False
                    ' DP_CardEndDate.Enabled = False
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 结束员工卡有效日期是，打钩，并且当卡的当前结束日期是20990101是吧结束日期改为当前时间
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DP_CardEndDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DP_CardEndDate.ValueChanged
        If DP_CardEndDate.Checked = True And isLoaded = True Then
            If DP_CardEndDate.Value.Date = New Date(2099, 1, 1) Then
                DP_CardEndDate.Value = GetTime()
            End If
        End If
    End Sub
#End Region


#Region "离职"
    Private Sub CB_EFileType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_EFileType.SelectedIndexChanged
        If CB_EFileType.Text = EMPLOYEE_FILE_TYPE_LIZHI Then
            LB_Quit.Visible = True
            DP_QuitDate.Visible = True

            LB_QuitType.Visible = True
            CB_QuitType.Visible = True
        Else
            LB_Quit.Visible = False
            DP_QuitDate.Visible = False
            Cmd_QuitEmployee.Enabled = True
            Cmd_QuitEmployee.Text = "标记离职"

            LB_QuitType.Visible = False
            CB_QuitType.Visible = False
        End If
    End Sub
#End Region


#Region "身份证信息"


    Private Sub TextBox_IDCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_IDCard.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim msg As PClass.PClass.SFZRetrun = PClass.PClass.SFZ_Check(TextBox_IDCard.Text)
            If msg.IsOk Then
                CB_Sex.Text = msg.Sex
                DP_Birthdate.Value = msg.Birthdate
                TB_JiGuan.Text = msg.JiGuan
                If TB_HuKu.Text = "" Then
                    TB_HuKu.Text = TB_JiGuan.Text
                End If
                CaculateAge(msg.Birthdate)
            Else
                ShowErrMsg(msg.Msg)
            End If
        End If
    End Sub

    Protected Sub CaculateAge(ByVal birthdate As Date)
        Dim age As Integer = Today.Year - birthdate.Year
        If birthdate.AddYears(age) >= Today Then
            age = age - 1
        End If
        TB_Age.Text = age
    End Sub

    Private Sub DP_Birthdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DP_Birthdate.ValueChanged
        CaculateAge(DP_Birthdate.Value)
    End Sub

#End Region

#Region "换班记录"


    Private Sub Cmd_Shift_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Shift_Change.Click
        If Dt_Employee Is Nothing OrElse Dt_Employee.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim msg As MsgReturn = Dao.Employee_InsertShiftChange(Dt_Employee.Rows(0)("ID"), DTP_Shift_StartDate.Value.Date, IsNull(Dt_Employee.Rows(0)("Employee_ShiftMoudel"), 0), CB_SheftModel.SelectedValue, TB_Shift_Remark.Text)
        If msg.IsOk Then
            Dim MsgEmployee As MsgReturn = Dao.Employee_InsertShift(Dt_Employee.Rows(0)("ID"), CB_SheftModel.SelectedValue, CB_SheftModel.Text, DTP_Shift_StartDate.Value.Date, TB_Shift_Remark.Text)
            If MsgEmployee.IsOk Then
                ShowOk("班次更换成功")
            End If
        Else
            ShowErrMsg("班次更换失败,错误：" & msg.Msg)
        End If
    End Sub
    Private Sub CB_SheftModel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_SheftModel.TextChanged
        If CB_SheftModel.SelectedIndex > 0 AndAlso Dt_Employee.Rows.Count > 0 AndAlso CB_SheftModel.SelectedValue <> IsNull(Dt_Employee.Rows(0)("Employee_ShiftMoudel"), 0) Then
            Cmd_Shift_Change.Enabled = True
        Else
            Cmd_Shift_Change.Enabled = False
        End If

    End Sub
#End Region

    Private Sub F990031_Employee_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        If TextBox_EmployeeDept.Tag Is Nothing Then
            Me.LastForm.ReturnId = ""
        Else
            Me.LastForm.ReturnId = TextBox_EmployeeDept.Tag
        End If

        Me.LastForm.ReturnMsg = TextBox_EmployeeID.Text
    End Sub



    Private Sub Btn_PrintSecurity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PrintBaoAn.Click

    End Sub
    Private Sub Btn_PrintNormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PrintNormal.Click

    End Sub
    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PrintManager.Click

    End Sub

    Private Sub Btn_Shift_ChangeLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Shift_ChangeLog.Click
        Dim F As New F99009_ShiftEmployee_History
        With F
            .Mode = Mode_Enum.Look
            .P_F_RS_ID = Dt_Employee.Rows(0)("ID")
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)

        VF.Show()
    End Sub
End Class
Partial Class Dao

    ''' <summary>
    ''' 插入班次更换信息
    ''' </summary>
    ''' <param name="empID"></param>
    ''' <param name="startDate"></param>
    ''' <param name="Shift_ID"></param>
    ''' <param name="remark"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Employee_InsertShiftChange(ByVal empID As String, ByVal startDate As Date, ByVal ShangShift_Id As Integer, ByVal Shift_ID As Integer, ByVal remark As String) As MsgReturn
        Dim sql As String = "insert into T15004_EmployeeShift_History (Employee_ID,sDate,ShangShift_Id,Shift_ID,Remark) values (@Employee_ID,@sDate,@ShangShift_Id,@Shift_ID,@Remark)"
        Dim p As New Dictionary(Of String, Object)
        'Dim sMonth As Date = New Date(startDate.Year, startDate.Month, 1)
        'p.Add("sMonth", sMonth)
        p.Add("Employee_ID", empID)
        p.Add("sDate", startDate)
        p.Add("ShangShift_Id", ShangShift_Id)
        p.Add("Shift_ID", Shift_ID)
        p.Add("Remark", remark)

        Return RunSQL(sql, p)
    End Function



    ''' <summary>
    ''' 更改员工班次信息
    ''' </summary>
    ''' <param name="Employee_ShiftMoudel"></param>
    ''' <param name="Employee_ShiftMoudel_Name"></param>
    ''' <param name="Employee_Shift_StartDate"></param>
    ''' <param name="Employee_Shift_RemarK"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function Employee_InsertShift(ByVal id As Integer, ByVal Employee_ShiftMoudel As Integer, ByVal Employee_ShiftMoudel_Name As String, ByVal Employee_Shift_StartDate As Date, ByVal Employee_Shift_RemarK As String) As MsgReturn
        Dim sql As String = "UPDATE T15001_Employee set Employee_ShiftMoudel=@Employee_ShiftMoudel,Employee_ShiftMoudel_Name=@Employee_ShiftMoudel_Name,Employee_Shift_StartDate=@Employee_Shift_StartDate,Employee_Shift_RemarK=@Employee_Shift_RemarK  where ID=@id"
        Dim p As New Dictionary(Of String, Object)
        'Dim sMonth As Date = New Date(startDate.Year, startDate.Month, 1)
        p.Add("ID", id)
        p.Add("Employee_ShiftMoudel", Employee_ShiftMoudel)
        p.Add("Employee_ShiftMoudel_Name", Employee_ShiftMoudel_Name)
        p.Add("Employee_Shift_StartDate", Employee_Shift_StartDate)
        p.Add("Employee_Shift_RemarK", Employee_Shift_RemarK)
        Return RunSQL(sql, p)
    End Function


    ''' <summary>
    ''' 根据名称获取员工信息
    ''' </summary>
    ''' <param name="_Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Employee_GetDtByName(ByVal _Name As String) As DtReturnMsg

        Dim sql As String = "select * from V15001_Employee  where Employee_Name=@Name "
        Return SqlStrToDt(sql, "Name", _Name)
    End Function



End Class
