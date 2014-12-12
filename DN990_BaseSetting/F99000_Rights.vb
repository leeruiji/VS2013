Imports System.Data
Imports PClass.PClass
Imports System.Text

Public Class F99000_Rights
#Region "-----窗体事件-----"
    Dim Dt_Ini_Menu As New DataTable("Menu")
    Dim Dt_Ini_Model As New DataTable("Model")
    Dim Dt_Ini_Form As New DataTable("Form")
    Dim Dt_Ini_Control As New DataTable("Control")

    Dim Dt_Menu As New DataTable
    Dim Dt_Model As New DataTable
    Dim Dt_Form As New DataTable
    Dim Dt_Control As New DataTable
    Dim Dt_Group As New DataTable
    Dim DT_Right As DataTable
    Dim Dt_ALL As New DataTable("T")

    Dim IsShowAll As Boolean = False


    Sub Ini_Dt()
        Dt_ALL.Columns.Add("Menu_id")
        Dt_ALL.Columns.Add("Control_Name")
        Dt_ALL.Columns.Add("Right_Show", GetType(Byte))
        Dt_ALL.Columns.Add("Right_Open", GetType(Byte))

        Dt_Ini_Menu.Columns.Add("Menu_id")
        Dt_Ini_Menu.Columns.Add("Show_Name")
        Dt_Ini_Menu.Columns.Add("Right_Show", GetType(Byte))

        For Each MenuId As String In HashMenu.Keys
            Dim Menu As MainMenuXTpye = HashMenu(MenuId)
            Dim Dr As DataRow = Dt_Ini_Menu.NewRow
            Dr("Menu_id") = Menu.ID
            Dr("Show_Name") = Menu.Caption
            Dr("Right_Show") = 0
            Dt_Ini_Menu.Rows.Add(Dr)
        Next
        Dt_Ini_Menu.AcceptChanges()


        Dt_Ini_Model.Columns.Add("Menu_id")
        Dt_Ini_Model.Columns.Add("Show_Name")
        Dt_Ini_Model.Columns.Add("Right_Show", GetType(Byte))

        For Each ModuleId As String In HashModule.Keys
            Dim ModuleX As MainModuleTpye = HashModule(ModuleId)
            Dim Dr As DataRow = Dt_Ini_Model.NewRow
            Dr("Menu_id") = ModuleX.ID
            Dr("Show_Name") = ModuleX.Caption
            Dr("Right_Show") = 0
            Dt_Ini_Model.Rows.Add(Dr)
        Next
        Dt_Ini_Model.AcceptChanges()


        Dt_Ini_Form.Columns.Add("Menu_id")
        Dt_Ini_Form.Columns.Add("Show_Name")
        Dt_Ini_Form.Columns.Add("Right_Show", GetType(Byte))
        Dt_Ini_Form.Columns.Add("Right_Open", GetType(Byte))

        Dt_Ini_Control.Columns.Add("Menu_id")
        Dt_Ini_Control.Columns.Add("Show_Name")
        Dt_Ini_Control.Columns.Add("Form_Name")
        Dt_Ini_Control.Columns.Add("Control_Name")
        Dt_Ini_Control.Columns.Add("Right_Show", GetType(Byte))
        Dt_Ini_Control.Columns.Add("Right_Open", GetType(Byte))

        For Each DllId As String In HashDll.Keys
            Dim DllX As DLLTpye = HashDll(DllId)
            If DllX.IsShow Then
                Dim Dr As DataRow = Dt_Ini_Form.NewRow
                Dr("Menu_id") = DllX.ID
                Dr("Show_Name") = DllX.Caption
                Dr("Right_Show") = 0
                Dr("Right_Open") = 0
                Dt_Ini_Form.Rows.Add(Dr)
                For Each b As RightTpye In DllX.Right
                    Dim Drx As DataRow = Dt_Ini_Control.NewRow
                    Drx("Menu_id") = DllX.ID
                    Drx("Form_Name") = DllX.Caption
                    Drx("Control_Name") = b.RightName
                    Drx("Show_Name") = b.RightShow
                    Drx("Right_Show") = 0
                    Drx("Right_Open") = 0
                    Dt_Ini_Control.Rows.Add(Drx)
                Next
            End If
        Next
        Dt_Ini_Form.AcceptChanges()
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Button_Group_Save)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
    End Sub


    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        FG_Control.Rows.Count = 1
        Ini_Dt()
        UserGroupList_Load()

        FGX = FG_Menu

    End Sub
#End Region

#Region "-----程序处理事件-----"


#Region "用户组"
    Private Sub Group_Save()
        FG_Group.Focus()
        Dim Dt As DataTable = Dt_ALL.Copy
        If Not Dt_Menu.GetChanges Is Nothing Then
            For Each a As DataRow In Dt_Menu.GetChanges.Rows
                Dim Dr As DataRow = Dt.NewRow
                If a.Item("Right_Show") = 1 Then
                    Dr.Item("Right_Show") = 1
                Else
                    Dr.Item("Right_Show") = 0
                End If
                Dr("Right_Open") = 1
                Dr("Menu_id") = a.Item("Menu_id")
                Dr("Control_Name") = ""
                Dt.Rows.Add(Dr)
            Next
        End If
        If Not Dt_Model.GetChanges Is Nothing Then
            For Each a As DataRow In Dt_Model.GetChanges.Rows
                Dim Dr As DataRow = Dt.NewRow
                If a.Item("Right_Show") = 1 Then
                    Dr.Item("Right_Show") = 1
                Else
                    Dr.Item("Right_Show") = 0
                End If
                Dr("Right_Open") = 1
                Dr("Menu_id") = a.Item("Menu_id")
                Dr("Control_Name") = ""
                Dt.Rows.Add(Dr)
            Next
        End If
        If Not Dt_Form.GetChanges Is Nothing Then
            For Each a As DataRow In Dt_Form.GetChanges.Rows
                Dim Dr As DataRow = Dt.NewRow
                If a.Item("Right_Show") = 1 Then
                    Dr.Item("Right_Show") = 1
                Else
                    Dr.Item("Right_Show") = 0
                End If
                If a.Item("Right_Open") = 1 Then
                    Dr.Item("Right_Open") = 1
                Else
                    Dr.Item("Right_Open") = 0
                End If
                Dr("Menu_id") = a.Item("Menu_id")
                Dr("Control_Name") = ""
                Dt.Rows.Add(Dr)
            Next
        End If
        If Not Dt_Control.GetChanges Is Nothing Then
            For Each a As DataRow In Dt_Control.GetChanges.Rows
                Dim Dr As DataRow = Dt.NewRow
                If a.Item("Right_Show") = 1 Then
                    Dr.Item("Right_Show") = 1
                Else
                    Dr.Item("Right_Show") = 0
                End If
                If a.Item("Right_Open") = 1 Then
                    Dr.Item("Right_Open") = 1
                Else
                    Dr.Item("Right_Open") = 0
                End If
                Dr("Menu_id") = a.Item("Menu_id")
                Dr("Control_Name") = a.Item("Control_Name")
                Dt.Rows.Add(Dr)
            Next
        End If
        Dt.AcceptChanges()
        Dt_Group.AcceptChanges()
        Dim R As MsgReturn = Right_Save(FG_Group.Item(FG_Group_Last_Select, "Group_ID"), _
                       FG_Group.Item(FG_Group_Last_Select, "Group_Name"), _
                        FG_Group.Item(FG_Group_Last_Select, "Group_IsAllow"), Dt)
        Me.ShowOk(R.Msg, False)
        If R.IsOk = True Then Group_Load()
    End Sub

    Private Sub Group_Change()
        If Right_GetChange() = True AndAlso Not Dt_Group Is Nothing AndAlso FG_Group_Last_Select > 0 And CheckRight(ID, ClassMain.Modify) Then

            ShowConfirm("用户组[" & FG_Group.Item(FG_Group_Last_Select, "Group_Name") & "]的权限没有保存,是否保存?", AddressOf Group_Save, AddressOf Group_Load)
        Else
            Group_Load()
        End If
    End Sub



    Private Sub Group_Load(Optional ByVal GroupID As Integer = 0)
        If FG_Group.RowSel <= 0 AndAlso Dt_Group.Rows.Count > 0 Then
            FG_Group.RowSel = 1
        Else
            If FG_Group.RowSel > 0 Then
                FG_Group_Last_Select = FG_Group.RowSel
                Dim R As DtReturnMsg = Right_GetByID(FG_Group.SelectItem("Group_Id"))
                If R.IsOk = True Then
                    DT_Right = R.Dt
                    Dt_Menu = Dt_Ini_Menu.Copy
                    For Each Row As DataRow In Dt_Menu.Rows
                        Dim Rx As DataRow = Row
                        Dim V As DataRow = DtRunSQLtoGetFirstRow(DT_Right, "Menu_id='" & Rx("Menu_id") & "'")
                        If Not V Is Nothing Then
                            Row("Right_Show") = V("Right_Show")
                        End If
                    Next
                    Dt_Menu.AcceptChanges()
                    Dt_Model = Dt_Ini_Model.Copy
                    For Each Row As DataRow In Dt_Model.Rows
                        Dim Rx As DataRow = Row
                        Dim V As DataRow = DtRunSQLtoGetFirstRow(DT_Right, "Menu_id='" & Rx("Menu_id") & "'")
                        If Not V Is Nothing Then
                            Row("Right_Show") = V("Right_Show")
                        End If
                    Next
                    Dt_Model.AcceptChanges()
                    Dt_Form = Dt_Ini_Form.Copy
                    For Each Row As DataRow In Dt_Form.Rows
                        Dim Rx As DataRow = Row
                        Dim V As DataRow = DtRunSQLtoGetFirstRow(DT_Right, "Menu_id='" & Rx("Menu_id") & "' and Control_Name=''")
                        If Not V Is Nothing Then
                            Row("Right_Show") = V("Right_Show")
                            Row("Right_Open") = V("Right_Open")
                        End If
                    Next
                    Dt_Form.AcceptChanges()
                    Dt_Control = Dt_Ini_Control.Copy
                    For Each Row As DataRow In Dt_Control.Rows
                        Dim Rx As DataRow = Row
                        Dim V As DataRow = DtRunSQLtoGetFirstRow(DT_Right, "Menu_id='" & Rx("Menu_id") & "' and Control_Name='" & Rx("Control_Name") & "'")
                        If Not V Is Nothing Then
                            Row("Right_Show") = V("Right_Show")
                            Row("Right_Open") = V("Right_Open")
                        End If
                    Next
                    Dt_Control.AcceptChanges()
                    Show_Menu()
                Else
                    ShowErrMsg(R.Msg)
                    FG_Group_Last_Select = 0
                End If
            End If
        End If
    End Sub


    Dim FG_Group_Last_Select As Integer = 0


    Private Sub FG_Group_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG_Group.SelChange
        If FG_Group_Last_Select > -1 AndAlso FG_Group.RowSel <> FG_Group_Last_Select Then
            Group_Change()
        Else
            Group_Load()
        End If
    End Sub

    Private Function Right_GetChange() As Boolean
        If Not Dt_Menu.GetChanges Is Nothing OrElse Not Dt_Model.GetChanges Is Nothing OrElse Not Dt_Form.GetChanges Is Nothing OrElse Not Dt_Control.GetChanges Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region "-----其他-----"

    Sub Show_Menu()
        FG_Menu.DataSource = Dt_Menu.DefaultView
        If FG_Menu.Rows.Count > 0 AndAlso FG_Menu.RowSel <= 0 Then
            FG_Menu.RowSel = 1
        End If
    End Sub

    Private Sub FG_Model_SelectRowChange(ByVal Row As Integer) Handles FG_Model.SelectRowChange
        If IsShowAll Then
            Dt_Form.DefaultView.RowFilter = ""
        Else
            Dim s As New StringBuilder
            For Each Item As C1.Win.C1FlexGrid.Row In FG_Model.Rows
                If Item.Selected Then
                    s.Append(IIf(s.Length > 0, "or ", ""))
                    s.Append("Menu_id like '" & Item.Item("Menu_id") & "%' ")
                End If

            Next
            If s.Length = 0 Then s.Append("1<>1")
            Dt_Form.DefaultView.RowFilter = s.ToString
        End If
        FG_Form.DataSource = Dt_Form.DefaultView
        If CReFresh Then
            Dim i As Integer = FG_Form.RowSel
            FG_Form.RowSel = 0
            If i > -1 Then FG_Form.RowSel = i
        Else
            FG_Form.Row = 0
        End If
        If FG_Form.Rows.Count > 1 AndAlso FG_Form.RowSel <= 1 Then
            FG_Form.RowSel = 1
        End If
    End Sub

    Private Sub FG_Menu_SelectRowChange(ByVal Row As Integer) Handles FG_Menu.SelectRowChange
        If IsShowAll Then
            Dt_Model.DefaultView.RowFilter = ""
        Else
            Dim s As New StringBuilder
            For Each Item As C1.Win.C1FlexGrid.Row In FG_Menu.Rows
                If Item.Selected = True Then
                    s.Append(IIf(s.Length > 0, "or ", ""))
                    s.Append("Menu_id like '" & Item.DataSource("Menu_id") & "%' ")
                End If
            Next
            If s.Length = 0 Then s.Append("1<>1")
            Dt_Model.DefaultView.RowFilter = s.ToString
        End If
        FG_Model.DataSource = Dt_Model.DefaultView
        If CReFresh Then
            Dim i As Integer = FG_Model.RowSel
            FG_Model.RowSel = 0
            If i > -1 Then FG_Model.RowSel = i
        Else
            FG_Model.Row = 0
        End If
        If FG_Model.Rows.Count > 1 AndAlso FG_Model.RowSel <= 1 Then
            FG_Model.RowSel = 1
        End If
    End Sub


    Private Sub FG_Form_SelectRowChange(ByVal Row As Integer) Handles FG_Form.SelectRowChange
        If IsShowAll Then
            Dt_Control.DefaultView.RowFilter = ""
        Else
            Dim s As New StringBuilder
            For Each Item As C1.Win.C1FlexGrid.Row In FG_Form.Rows
                If Item.Selected Then
                    s.Append(IIf(s.Length > 0, "or ", ""))
                    s.Append("Menu_id = '" & Item.Item("Menu_id") & "' ")
                End If
            Next
            If s.Length = 0 Then s.Append("1<>1")
            Dt_Control.DefaultView.RowFilter = s.ToString
        End If
        FG_Control.DataSource = Dt_Control.DefaultView
        If CReFresh Then
            Dim i As Integer = FG_Control.RowSel
            FG_Control.RowSel = 0
            If i > -1 Then FG_Control.RowSel = i
        End If
        CReFresh = False

        If FG_Control.Rows.Count > 1 AndAlso FG_Control.RowSel = 1 Then
            FG_Control.RowSel = 1
        End If
    End Sub

#End Region


#End Region

#Region "-----导航栏事件-----"
    '添加用户组
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        TextBox1.Text = ""
        CheckBox1.Checked = True
        Group_IsAdd = True
        ShowGroup()
    End Sub


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        Group_Save()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除用户组[" & FG_Group.Item(FG_Group_Last_Select, "Group_Name") & "]?", AddressOf Group_Del)

    End Sub

    Sub Group_Del()
        Dim R As MsgReturn = UserGroup_Del(FG_Group.Item(FG_Group_Last_Select, "Group_Id"))
        If R.IsOk Then
            ShowOk(R.Msg)
            UserGroupList_Load()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub

    Dim CReFresh As Boolean = False
    Private Sub Cmd_ShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowAll.Click
        IsShowAll = Cmd_ShowAll.Checked
        If IsShowAll Then
            FG_Control.Cols("Form_Name").Visible = True
        Else
            FG_Control.Cols("Form_Name").Visible = False
        End If

        CReFresh = True
        FG_Menu.RowSel = 0
        Show_Menu()

    End Sub



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


#End Region

#Region "-----用户组窗口处理-----"
    Dim Group_IsAdd As Boolean = False
    Sub ShowGroup()
        CaptureFromImageToPicture(Me, Panel_UserGroup)
        Panel_UserGroup.BringToFront()
        GroupBox_UserGroup.Height = 268
        GroupBox_UserGroup.Left = Panel_UserGroup.Width / 2 - GroupBox_UserGroup.Width / 2
        GroupBox_UserGroup.Top = Panel_UserGroup.Height / 2 - GroupBox_UserGroup.Height / 2
        GroupBox_UserGroup.Visible = True
        GroupBox_UserGroup.BringToFront()
        Panel_UserGroup.Visible = True
    End Sub

    Sub HideGroup()
        Panel_UserGroup.Visible = False
        Panel_UserGroup.SendToBack()
    End Sub
    Private Sub FG_Group_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG_Group.DoubleClick
        If FG_Group.RowSel > 0 Then
            Group_IsAdd = False
            TextBox1.Text = FG_Group.Item(FG_Group.RowSel, "Group_Name")
            CheckBox1.Checked = FG_Group.Item(FG_Group.RowSel, "Group_IsAllow")
            Group_ID = FG_Group.Item(FG_Group.RowSel, "Group_ID")
            ShowGroup()
        End If
       
    End Sub


    Private Sub Button_Group_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Group_Save.Click
        If TextBox1.Text = "" Then ShowErrMsg("用户组名称不能为空!") : Exit Sub
        If Group_IsAdd Then
            Dim M As MsgReturn = UserGroup_Add(TextBox1.Text, CheckBox1.Checked)
            If M.IsOk Then
                HideGroup()
                ShowOk(M.Msg)
                UserGroupList_Load()
            Else
                ShowErrMsg(M.Msg)
            End If
        Else
            Dim M As MsgReturn = UserGroup_Modify(Group_ID, TextBox1.Text, CheckBox1.Checked)
            If M.IsOk Then
                HideGroup()
                ShowOk(M.Msg)
                UserGroupList_Load()
            Else
                ShowErrMsg(M.Msg)
            End If
        End If
    End Sub
    Private Sub Button_Group_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Group_Exit.Click
        HideGroup()
    End Sub
#End Region


#Region "-----数据库交换-----"

#Region "用户组"


    ''' <summary>
    ''' 用户组添加
    ''' </summary>
    ''' <param name="Group_Name">用户名称</param>
    ''' <param name="Group_IsAllow">是否启用</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UserGroup_Add(ByVal Group_Name As String, ByVal Group_IsAllow As Boolean) As MsgReturn
        Dim DtR As DtReturnMsg
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim R As New MsgReturn
        Try
            DtR = SqlStrToDt(SQL_99000_UserGroup_Add, Cnn, Da)
            Dim Dr As DataRow = DtR.Dt.NewRow
            Dr("Group_Name") = Group_Name
            Dr("Group_IsAllow") = Group_IsAllow
            DtR.Dt.Rows.Add(Dr)
            DtToUpDate(DtR.Dt, Cnn, Da)
            R.IsOk = True
            R.Msg = "用户组添加成功!"
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "用户组添加失败!" & ex.ToString
            Return R
        End Try
    End Function

    ''' <summary>
    ''' 用户组修改
    ''' </summary>
    ''' <param name="Group_Name">用户名称</param>
    ''' <param name="Group_IsAllow">是否启用</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UserGroup_Modify(ByVal Group_ID As String, ByVal Group_Name As String, ByVal Group_IsAllow As Boolean) As MsgReturn
        Dim DtR As DtReturnMsg
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim R As New MsgReturn
        Try
            DtR = SqlStrToDt(SQL_99000_UserGroup_SaveAndDel, Cnn, Da, "Group_ID", Group_ID)
            If DtR.Dt.Rows.Count = 0 Then
                R.IsOk = False
                R.Msg = "用户组保存失败!用户组已经被删除!"
                Return R
            End If
            Dim Dr As DataRow = DtR.Dt.Rows(0)
            Dr("Group_Name") = Group_Name
            Dr("Group_IsAllow") = Group_IsAllow
            DtToUpDate(DtR.Dt, Cnn, Da)
            R.IsOk = True
            R.Msg = "用户组保存成功!"
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "用户组保存失败!" & ex.ToString
            Return R
        End Try
    End Function

    ''' <summary>
    ''' 用户组删除
    ''' </summary>
    ''' <param name="Group_ID">用户组ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UserGroup_Del(ByVal Group_ID As String) As MsgReturn
        Dim DtR As DtReturnMsg
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim R As New MsgReturn
        Try
            DtR = SqlStrToDt(SQL_99000_UserGroup_SaveAndDel, Cnn, Da, "Group_ID", Group_ID)
            If DtR.Dt.Rows.Count = 0 Then
                R.IsOk = False
                R.Msg = "用户组已经被删除!"
                Return R
            End If
            DtR.Dt.Rows(0).Delete()
            DtToUpDate(DtR.Dt, Cnn, Da)
            R.IsOk = True
            R.Msg = "用户组删除成功!"
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "用户组删除失败!" & ex.ToString
            Return R
        End Try

    End Function

    ''' <summary>
    ''' 用户组获取
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UserGroupList_Load()
        If FG_Group.SqlToFG(SQL_99000_UserGroupList_Load).IsOk = False Then
            Me.ShowErrMsg("加载错误")
            Exit Sub
        End If
        Group_Load()
    End Sub
#End Region


#Region "权限"

    Public Function Right_GetByID(ByVal Group_ID As Integer) As DtReturnMsg
        Try
            Return SqlStrToDt(SQL_99000_Right_GetByID, "@Group_ID", Group_ID)
        Catch ex As Exception
            DebugToLog(ex)
            Return New DtReturnMsg With {.Msg = ex.ToString}
        End Try
    End Function


    ''' <summary>
    ''' 权限保存
    ''' </summary>
    ''' <param name="Group_ID"></param>
    ''' <param name="GroupName"></param>
    ''' <param name="IsAllow"></param>
    ''' <param name="Dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Right_Save(ByVal Group_ID As Integer, ByVal GroupName As String, ByVal IsAllow As Boolean, ByVal Dt As DataTable) As MsgReturn
        Dim T As DtReturnMsg
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim R As New MsgReturn
        Try
            T = SqlStrToDt(SQL_99000_Right_Save, Cnn, Da, "Group_ID", Group_ID)
            If T.Dt.Rows.Count = 0 Then
                R.IsOk = False
                R.Msg = "保存失败!用户已经被删除!"
                Return R
            Else
                Dim S As New StringBuilder()
                For Each Row As DataRow In Dt.Rows
                    T.Dt.Rows(0).Item("Group_Name") = GroupName
                    T.Dt.Rows(0).Item("Group_IsAllow") = IsAllow
                    S.AppendLine("if exists(select * from " & SQL_99000_Right_Save_Table_Name & " where Group_ID=@G and control_Name='" & Row("control_Name") & "' and Menu_id='" & Row("Menu_id") & "') ")
                    S.AppendLine("update " & SQL_99000_Right_Save_Table_Name & " set Right_Show=" & Row("Right_Show") & ",Right_Open=" & Row("Right_Open") & "")
                    S.AppendLine("where Group_ID=@G and control_Name='" & Row("control_Name") & "' and Menu_id='" & Row("Menu_id") & "'")
                    S.AppendLine("else insert into " & SQL_99000_Right_Save_Table_Name & " (Group_ID,control_Name,Menu_id,Right_Show,Right_Open)")
                    S.AppendLine("values(@G,'" & Row("control_Name") & "','" & Row("Menu_id") & "'," & Row("Right_Show") & "," & Row("Right_Open") & ")")
                Next
                S.AppendLine("Print 'Ok'")
                DtToUpDate(T.Dt, Cnn, Da, S.ToString, "@G", Group_ID)
                PClass.PClass.DT_Form_Ritht_IsLoad = False
                Get_Form_RightAsync()
                R.IsOk = True
                R.Msg = "保存用户组[" & GroupName & "]权限成功!"
                Return R
            End If
        Catch ex As Exception
            DebugToLog(ex)
            R.IsOk = False
            R.Msg = "保存失败!" & ex.Message
            Return R
        End Try
    End Function
#End Region


#End Region


 
 
 
#Region "当期有焦点的FG"
    Dim FGX As PClass.FG = FG_Menu

    Private Sub FG_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG_Menu.Click
        FGX = FG_Menu
    End Sub

    Private Sub FG_Model_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG_Model.Click
        FGX = FG_Model
    End Sub

    Private Sub FG_Form_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG_Form.Click
        FGX = FG_Form
    End Sub

    Private Sub FG_Control_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG_Control.Click
        FGX = FG_Control
    End Sub
#End Region
#Region "全选"

    Private Sub ToolStripButton_SelALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_SelALL.Click
        For i As Integer = 1 To FGX.Rows.Count - 1
            FGX.Item(i, "Right_Show") = True
        Next
    End Sub

    Private Sub ToolStripButton_SelNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_SelNone.Click
        For i As Integer = 1 To FGX.Rows.Count - 1
            FGX.Item(i, "Right_Show") = False
        Next
    End Sub

    Private Sub ToolStripButton_NSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_NSel.Click
        For i As Integer = 1 To FGX.Rows.Count - 1
            If FGX.Item(i, "Right_Show") = 1 Then
                FGX.Item(i, "Right_Show") = False
            Else
                FGX.Item(i, "Right_Show") = True
            End If
        Next
    End Sub
#End Region

    Dim CopyGroup As Integer
    Private Sub ToolStripButton_CopyVi_RL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_CopyVi_RL.Click
        CopyGroup = FG_Group.SelectItem("Group_Id")
        ToolStripButton_PasteVi_RL.Enabled = True
    End Sub

    
    Private Sub ToolStripButton_PasteVi_RL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_PasteVi_RL.Click
        Copy_Load(CopyGroup)
    End Sub


    Private Sub Copy_Load(ByVal GroupID As Integer)

        Dim R As DtReturnMsg = Right_GetByID(GroupID)
        If R.IsOk = True Then
            For Each Row As DataRow In Dt_Menu.Rows
                Dim Rx As DataRow = Row
                Dim V As DataRow = DtRunSQLtoGetFirstRow(R.Dt, "Menu_id='" & Rx("Menu_id") & "'")
                If Not V Is Nothing Then
                    Row("Right_Show") = V("Right_Show")
                Else
                    Row("Right_Show") = False
                End If
            Next
            For Each Row As DataRow In Dt_Model.Rows
                Dim Rx As DataRow = Row
                Dim V As DataRow = DtRunSQLtoGetFirstRow(R.Dt, "Menu_id='" & Rx("Menu_id") & "'")
                If Not V Is Nothing Then
                    Row("Right_Show") = V("Right_Show")
                Else
                    Row("Right_Show") = False
                End If
            Next
            For Each Row As DataRow In Dt_Form.Rows
                Dim Rx As DataRow = Row
                Dim V As DataRow = DtRunSQLtoGetFirstRow(R.Dt, "Menu_id='" & Rx("Menu_id") & "' and Control_Name=''")
                If Not V Is Nothing Then
                    Row("Right_Show") = V("Right_Show")
                    Row("Right_Open") = V("Right_Open")
                Else
                    Row("Right_Show") = False
                    Row("Right_Open") = False
                End If
            Next
            For Each Row As DataRow In Dt_Control.Rows
                Dim Rx As DataRow = Row
                Dim V As DataRow = DtRunSQLtoGetFirstRow(R.Dt, "Menu_id='" & Rx("Menu_id") & "' and Control_Name='" & Rx("Control_Name") & "'")
                If Not V Is Nothing Then
                    Row("Right_Show") = V("Right_Show")
                    Row("Right_Open") = V("Right_Open")
                Else
                    Row("Right_Show") = False
                    Row("Right_Open") = False
                End If
            Next
            Show_Menu()
        Else
            ShowErrMsg(R.Msg)
            FG_Group_Last_Select = 0
        End If

    End Sub

End Class
