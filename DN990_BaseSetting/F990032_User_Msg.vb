Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F990032_User_Msg
    Dim userID As String = ""
    Dim eId As String = ""
    Dim isShowEmployee As Boolean = True
    Dim dtUser As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal uId As String, ByVal _eId As String, Optional ByVal _isShowEmployee As Boolean = True)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.userID = uId
        Me.eId = _eId
        isShowEmployee = _isShowEmployee
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 15000
        Control_CheckRight(ID, ClassMain.User & ClassMain.Modify, Cmd_SaveUser)
        Control_CheckRight(ID, ClassMain.User & ClassMain.Del, Cmd_DelUser)

    
    End Sub
    Private Sub F990032_User_Msg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        FormCheckRight()
        Dim msgGroup As DtReturnMsg = Group_GetAll()
        If msgGroup.IsOk Then
            ComboBox_UserGroup.DataSource = msgGroup.Dt
        End If
        Dim msg As DtReturnMsg = User_GetById(userID)
        If Not msg.IsOk Then
            ShowErrMsg(msg.Msg)
            Exit Sub
        Else

            SetUserInfo(msg.Dt)
            dtUser = msg.Dt
        End If
        If Me.Mode = Mode_Enum.Add Then
            TextBox_UserID.Text = User_GetNewID()
            Tb_EmployeeID_ForUser.Text = eId
            TB_UserDept.Tag = Me.P_F_RS_ID
            TB_UserDept.Text = Me.P_F_RS_ID2
            TB_Display.Text = P_F_RS_ID3
            TextBox_UserName.Text = P_F_RS_ID3
        End If
        If isShowEmployee = False Then
            Cmd_LookEmployee.Visible = False
        End If
    End Sub

#Region "工具栏事件"


    Private Sub Btn_SaveUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SaveUser.Click
        If CheckForm_User() Then ShowConfirm("是否保存用户[" & TextBox_UserName.Text & "]?", AddressOf SaveUser)
    End Sub

    Protected Sub SaveUser()

        If Me.Mode = Mode_Enum.Add Then
            Dim msg As DtReturnMsg = User_GetByName(TextBox_UserName.Text)
            Dim msgE As DtReturnMsg = User_GetByEmployeeId(Tb_EmployeeID_ForUser.Tag)
            If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                ShowErrMsg("用户名[" & TextBox_UserName.Text & "]已经被使用")
                Exit Sub
            End If
            User_AddSave()
        Else
            User_ModifySave()
            'selectedDept = TextBox_UserID.Text
        End If
        Me.Close()
        ' ReLoad()
        '  Label_Mode.Tag = -1
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_DelUser.Click
        ShowConfirm("是否删除用户 [" & TextBox_UserName.Text & "]?", AddressOf DelUser)
    End Sub

    Protected Sub DelUser()
        Dim msg As MsgReturn = User_Delete(TextBox_UserID.Text)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg)
        Else
            Me.Close()
        End If

    End Sub

    Protected Function CheckForm_User() As Boolean
        If TextBox_UserID.Text = "" Then
            ShowErrMsg("用户编号不能为空")
            TextBox_UserID.Focus()
            Return False
        End If
        If TextBox_UserName.Text = "" Then
            ShowErrMsg("用户名称不能为空")
            TextBox_UserName.Focus()
            Return False
        End If
        If Tb_EmployeeID_ForUser.Text = "" Then
            ShowErrMsg("员工编号不能为空")
            Tb_EmployeeID_ForUser.Focus()
            Return False
        End If
        If Mode = Mode_Enum.Add Then
            Dim isUserRegist As Boolean = User_CheckExist(Tb_EmployeeID_ForUser.Text)
            If isUserRegist > 0 Then
                ShowErrMsg("员工编号已经被注册!")
                Tb_EmployeeID_ForUser.Focus()
                Return False
            End If
        ElseIf Mode = Mode_Enum.Modify AndAlso Tb_EmployeeID_ForUser.Text <> IsNull(dtUser.Rows(0)("Employee_No"), "") Then

            Dim isUserRegist As Integer = User_CheckExist(Tb_EmployeeID_ForUser.Text)
            If isUserRegist > 0 Then
                ShowErrMsg("员工编号已经被注册!")
                Tb_EmployeeID_ForUser.Focus()
                Return False
            End If


        End If

        If TB_Display.Text = "" Then
            ShowErrMsg("显示名称不能为空")
            TB_Display.Focus()
            Return False
        End If


        If TextBox_Psw.Text = "" Then
            ShowErrMsg("用户密码不能为空")
            TextBox_Psw.Focus()
            Return False
        End If

        If Not TextBox_Psw.Text = TextBox_ComfirmPsw.Text Then
            ShowErrMsg("两次输入的密码不一致")
            TextBox_Psw.Focus()
            Return False
        End If

        Return True
    End Function




    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TextBox_Psw_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_Psw.TextChanged
        Label_ComfirmPsw.Visible = True
        TextBox_ComfirmPsw.Visible = True
        TextBox_ComfirmPsw.Text = ""
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub




#End Region

#Region "用户详细信息"

    ''' <summary>
    ''' 用户表单赋值
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub SetUserInfo(ByRef dt As DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Exit Sub
        End If
        Tb_EmployeeID_ForUser.Text = IsNull(dt.Rows(0)("Employee_No"), "")
        TextBox_UserID.Text = IsNull(dt.Rows(0)("User_ID"), "")
        TextBox_UserName.Text = IsNull(dt.Rows(0)("User_Name"), "")
        TB_Display.Text = IsNull(dt.Rows(0)("User_Display"), "")
        TB_UserDept.Text = IsNull(dt.Rows(0)("Dept_Name"), "")
        TB_UserDept.Tag = IsNull(dt.Rows(0)("User_Dept"), "")
        TextBox_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
        ComboBox_UserGroup.SelectedValue = IsNull(dt.Rows(0)("Group_ID"), 0)
        TextBox_Psw.Text = DeDes(IsNull(dt.Rows(0)("User_Password"), ""), StrToMD5(TextBox_UserName.Text.ToUpper.Trim))
        TextBox_ComfirmPsw.Text = TextBox_Psw.Text
        CB_Invalid.Checked = IsNull(dt.Rows(0)("Invalid"), False)
    End Sub

    ''' <summary>
    ''' 用户表单赋值
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub GetUserInfo(ByRef dt As DataTable)
        dt.Rows(0)("Employee_No") = Tb_EmployeeID_ForUser.Text
        dt.Rows(0)("User_ID") = TextBox_UserID.Text
        dt.Rows(0)("User_Dept") = TB_UserDept.Tag
        dt.Rows(0)("User_Name") = TextBox_UserName.Text
        dt.Rows(0)("User_Display") = TB_Display.Text
        dt.Rows(0)("User_Password") = EnDes(TextBox_Psw.Text, StrToMD5(TextBox_UserName.Text.ToUpper.Trim))
        dt.Rows(0)("Remark") = TextBox_Remark.Text
        If ComboBox_UserGroup.SelectedValue Is Nothing Then
            dt.Rows(0)("Group_ID") = DBNull.Value
        Else
            dt.Rows(0)("Group_ID") = ComboBox_UserGroup.SelectedValue
        End If
        dt.Rows(0)("Invalid") = CB_Invalid.Checked
    End Sub
#End Region

#Region "数据库交互"





#Region "增删改"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function User_AddSave() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim Employee_Dept As String = ""
        Try

            sql = "select top 1 * from User_Info where User_ID=@User_ID  order by User_ID"
            dt = SqlStrToDt(sql, Cnn, Da, "User_ID", Employee_Dept).Dt
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
                GetUserInfo(dt)
                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("用户:[" & TextBox_UserID.Text & "] 已经存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("新增用户:[" & TextBox_UserID.Text & "] 错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function User_ModifySave() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim userId As String = TextBox_UserID.Text
        Try

            sql = "select top 1 * from User_Info where User_ID=@User_ID order by User_ID"
            dt = SqlStrToDt(sql, Cnn, Da, "User_ID", userId).Dt
            If dt.Rows.Count = 1 Then

                GetUserInfo(dt)
                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("用户:[" & TextBox_UserID.Text & "]不存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("用户:[" & TextBox_UserID.Text & "] 修改错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function
    Protected Function User_Delete(ByVal id As String) As MsgReturn
        Dim sql As String = "Delete  from User_Info where User_ID='" & id & "' "
        Return PClass.PClass.RunSQL(sql)
    End Function


#End Region


#End Region


    Private Sub Cmd_LookEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_LookEmployee.Click
        If Tb_EmployeeID_ForUser.Text.Trim.Length > 0 Then
            ShowEmployeeMsg(Tb_EmployeeID_ForUser.Text, Mode_Enum.Look)
        Else
            ShowErrMsg("用户没有与员工信息关联!")
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowEmployeeMsg(ByVal employeeId As String, ByVal mode As Mode_Enum)
        Dim F As New F990031_Employee_Msg(employeeId)
        With F
            .Mode = mode
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        'AddHandler VF.ClosedX, AddressOf EmployeeReturn
        VF.Show()
    End Sub

 
    ''' <summary>
    ''' 选择部门
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_ChoseDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseDeptForUser.Click

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
            Me.TB_UserDept.Text = Me.ReturnObj
            Me.TB_UserDept.Tag = Me.ReturnId

        End If
    End Sub

    Private Sub F990031_Employee_Msg_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        If TB_UserDept.Tag Is Nothing Then
            Me.LastForm.ReturnId = ""
        Else
            Me.LastForm.ReturnId = TB_UserDept.Tag
        End If

        Me.LastForm.ReturnMsg = TextBox_UserID.Text
    End Sub
End Class


