Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports DN990_BaseSetting.R99003_Card
Imports BaseClass

Public Class F99003_Department
    Dim selectedDept As String = ""


    Dim DtDepts As New DataTable
    Dim DtEmployee As New DataTable
    Dim DtUser As New DataTable
    '  Dim DtDept As New DataTable
    Dim groupDt As New DataTable
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, TreeNode)

    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_AddDept)


        Control_CheckRight(ID, ClassMain.Modify, Cmd_SaveDept)
        Control_CheckRight(ID, ClassMain.Del, Cmd_DelDept)

        '  Control_CheckRight(ID, ClassMain.User & ClassMain.Add, Cmd_AddUser)
        'TSMI_AddUser.Enabled = Cmd_AddUser.Enabled
        'Cmd_CreateUser.Enabled = Cmd_AddUser.Enabled
        'Cmd_CreateUser.Visible = Cmd_AddUser.Enabled
        'Control_CheckRight(ID, ClassMain.User & ClassMain.Modify, Cmd_SaveUser)
        'Control_CheckRight(ID, ClassMain.User & ClassMain.Del, Cmd_DelUser)

        Control_CheckRight(ID, ClassMain.Employee & ClassMain.Add, Cmd_AddEmployee)
        'TSMI_AddEmployee.Enabled = Cmd_AddEmployee.Enabled
        'Control_CheckRight(ID, ClassMain.Employee & ClassMain.Modify, Cmd_SaveEmployee)
        'Control_CheckRight(ID, ClassMain.Employee & ClassMain.Del, Cmd_DelEmployee)
        'Control_CheckRight(ID, ClassMain.Employee & ClassMain.Quit, Cmd_QuitEmployee)
        'Control_CheckRight(ID, ClassMain.Employee & ClassMain.Print, Cmd_Print)
        TSMI_AddDept.Visible = Cmd_AddDept.Visible
        Control_CheckRight(ID, ClassMain.Employee & ClassMain.Add, TSMI_AddEmployee)
        Control_CheckRight(ID, ClassMain.Del, TSMI_Del)
        '   TSMI_AddEmployee.Visible = Cmd_AddEmployee.Visible
        TSMI_AddUser.Visible = False
        '  TSMI_Del.Visible = Cmd_DelDept.Visible
    End Sub

    Private Sub F99003_Department_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        'Dim msgGroup As DtReturnMsg = Group_GetAll()
        'If msgGroup.IsOk Then
        '    groupDt = msgGroup.Dt
        '    ComboBox_UserGroup.DataSource = groupDt
        'End If
        FG_Employee.IniColsSize()
        DP_FirstDateFrom.Value = New Date(Today.Year, 1, 1)
        DP_FirstDateTo.Value = Today

        DP_FirstDateFrom.Checked = False
        DP_FirstDateTo.Checked = False

        CB_ConditionName.DisplayMember = "Field"
        CB_ConditionName.ValueMember = "DB_Field"
        CB_ConditionName.DataSource = Employee_GetConditionNames()
        ReLoad()
        isLoaded = True

    End Sub

    Public Sub ReLoad()
        '    Me.CB_JiGuan.DataSource = GetConditionValues("T15001_Employee", "Employee_JiGuan", "").Dt  ' GetNewDataTable(DtEmployee, "distinct(Employee_JiGuan)", "Employee_JiGuan")
        '     CB_Job.DataSource = Job_GetAll.Dt
        Dim msgEmployee As DtReturnMsg = Employee_GetEmployeeAll()  '_GetByOption(New List(Of FindOption))
        If msgEmployee.IsOk Then
            DtEmployee = AddworkYear(msgEmployee.Dt)
            FG_Employee.DtToFG(DtEmployee)

        End If
        Dim msgUser As DtReturnMsg = User_GetAll()
        If msgUser.IsOk Then

            DtUser = msgUser.Dt
            FG_User.DtToFG(DtUser)
        End If


        Dim msgDept As DtReturnMsg = Department_GetDeptAll()
        If msgDept.IsOk Then
            DtDepts = msgDept.Dt
            Try
                CreateTreeView(DtDepts)
            Catch ex As Exception
                DebugToLog(ex)
            End Try
        End If
        If Not selectedEmployee = "" Then
            FG_Employee.RowSetForce("Employee_No", selectedEmployee)
        End If
        If Not selectedUser = "" Then
            FG_User.RowSetForce("User_ID", selectedUser)
        End If
    End Sub

    ''' <summary>
    '''  在员工工作表上增加工龄
    ''' </summary>
    ''' <remarks></remarks>
    Private Function AddworkYear(ByVal Employee As DataTable) As DataTable
        Employee.Columns.Add("WorkYear", GetType(String))
        Dim QDate As Date
        Dim Diff As Long
        Dim D As Date = GetDate()
        For Each dr As DataRow In Employee.Rows
            If dr("Employee_FileType") = "正式" Then
                QDate = D
            ElseIf dr("Employee_FileType") = "离职" Then
                QDate = IsNull(dr("Employee_QuitDate"), D)
            End If
            Diff = DateDiff(DateInterval.Month, dr("Employee_FirstDate"), QDate)
            If Diff > 0 Then
                dr("WorkYear") = MonthToYear(Diff)
            Else
                Diff = DateDiff(DateInterval.Day, dr("Employee_FirstDate"), QDate)
                dr("WorkYear") = DayStirng(Diff)
            End If
        Next
        Return Employee
    End Function




    ''' <summary>
    '''  月数到年数转换
    ''' </summary>
    ''' <remarks></remarks>
    Private Function MonthToYear(ByVal month As Long) As String
        Dim year As Integer = 0
        Dim ye As Integer = 0
        Dim S_year As String = ""
        Dim S_ye As String = ""
        year = month \ 12
        If year > 0 Then
            S_year = year & "年"
        End If
        ye = month Mod 12
        If ye > 0 Then
            S_ye = ye & "月"
        End If
        Return S_year & S_ye
    End Function

    ''' <summary>
    '''  在职不够一个月的，显示日期
    ''' </summary>
    ''' <remarks></remarks>
    Private Function DayStirng(ByVal day As Long) As String
        Return day & "日"
    End Function


#Region "生成树形菜单"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Sub CreateTreeView(ByVal dt As DataTable)
        nodeMap.Clear()
        Dim root As New TreeNode

        root.Name = "D"
        root.Text = "部门"
        root.ImageIndex = 0
        If selectedDept = root.Name Then
            selectNode = root
        End If
        nodeMap.Add(root.Name, root)
        root.Tag = Enum_HR.Department

        TreeView_Dept.Nodes.Clear()
        TreeView_Dept.Nodes.Add(root)
        '递归添加节点
        CreateChilds(root)
        root.Expand()
        'For Each dr In dt.Select(" len (Dept_No)=4 ", "NodeLevel,NodeIndex")
        '    Dim nId As String = dr("Dept_No")
        '    Dim nName As String = dr("Dept_Name")

        '    Dim item As TreeNode = root.Nodes.Add(nName)

        '    item.Name = nId
        '    item.Text = nName
        '    item.Tag = Enum_HR.Department
        '    If nId = selectedDept Then
        '        selectNode = item
        '    End If
        '    If RB_Employee.Checked Then
        '        CreateEmployeeNode(nId, item)
        '    Else
        '        CreateUserNode(nId, item)
        '    End If
        '    nodeMap.Add(item.Name, item)

        '    For Each dr2 In dt.Select(" len (Dept_No)>=7 and substring (Dept_No,1,4)='" & nId & "'", "NodeLevel,NodeIndex")
        '        CreateTreeItems(dr2("Dept_No"), dr2("Dept_Name"), item)
        '    Next
        'Next


        TreeView_Dept.SelectedNode = selectNode
        If Not selectNode Is Nothing Then
            ChooseNode(selectNode)
        End If

    End Sub

    Private Sub CreateChilds(ByVal parentItem As TreeNode)
        Dim drs As DataRow() = GetChildren(parentItem)
        Dim node As TreeNode
        For Each dr As DataRow In drs
            node = CreateTreeItems(dr("Dept_No"), dr("Dept_Name"), parentItem)
            CreateChilds(node)
        Next
    End Sub

    Private Function GetChildren(ByVal parentItem As TreeNode) As DataRow()
        Dim plen As Integer = parentItem.Level * 3 + 1
        Dim clen As Integer = (parentItem.Level + 1) * 3 + 1
        Return DtDepts.Select(" len (Dept_No)= " & clen & " and  Dept_No like '" & parentItem.Name & "%'", "NodeLevel,NodeIndex")
    End Function



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nodeName"></param>
    ''' <param name="nodeText"></param>
    ''' <param name="parentItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTreeItems(ByVal nodeName As String, ByVal nodeText As String, ByVal parentItem As TreeNode) As TreeNode

        Dim MParentID As String = nodeName.Substring(0, nodeName.Length - 3)
        Dim p As TreeNode

        If nodeMap.ContainsKey(MParentID) Then
            p = nodeMap.Item(MParentID)
        Else
            Return Nothing
        End If
        If Not p Is Nothing Then
            Dim item As TreeNode = New TreeNode
            item.Name = nodeName
            item.Text = nodeText
            item.Tag = Enum_HR.Department

            If nodeName = selectedDept Then
                selectNode = item

                item.Checked = True
                item.Expand()
            End If
            nodeMap.Add(item.Name, item)
            p.Nodes.Add(item)

            If RB_Employee.Checked Then
                CreateEmployeeNode(nodeName, item)
            Else
                CreateUserNode(nodeName, item)
            End If

            Return item
        Else
            Return Nothing

        End If

    End Function

    Protected Sub CreateEmployeeNode(ByVal name As String, ByVal parentItem As TreeNode)
        CreateEmployeeNode(name, parentItem, DtEmployee)
    End Sub


    Protected Sub CreateEmployeeNode(ByVal name As String, ByVal parentItem As TreeNode, ByVal dtE As DataTable)
        Dim drsE As DataRow()
        If RB_All.Checked Then
            drsE = dtE.Select("Employee_Dept='" & name & "'")
        ElseIf RB_LiZhi.Checked Then
            drsE = dtE.Select("Employee_Dept='" & name & "' and Employee_FileType='离职'")
        Else
            drsE = dtE.Select("Employee_Dept='" & name & "' and Employee_FileType<>'离职'")
        End If
        For i As Integer = parentItem.Nodes.Count - 1 To 0 Step -1 ' Each n As TreeNode In parentItem.Nodes
            If parentItem.Nodes(i).Tag = Enum_HR.Employee Then
                ' n.Remove()
                parentItem.Nodes.Remove(parentItem.Nodes(i))
            End If
        Next

        For i As Integer = drsE.Length - 1 To 0 Step -1 'Each dr In drsE

            Dim eNode As New TreeNode
            eNode.Name = drsE(i)("Employee_No")
            eNode.Text = drsE(i)("Employee_Name")
            eNode.ImageIndex = 2
            eNode.Tag = Enum_HR.Employee
            'If eNode.Name = selectedDept Then
            '    selectNode = eNode
            'End If
            parentItem.Nodes.Insert(0, eNode)
        Next
    End Sub
    Protected Sub CreateUserNode(ByVal name As String, ByVal parentItem As TreeNode)
        Dim drsE As DataRow() = DtUser.Select("User_Dept='" & name & "'")

        For Each dr In drsE

            Dim eNode As New TreeNode
            eNode.Name = dr("User_ID")
            eNode.Text = dr("User_Name")
            eNode.ImageIndex = 3
            eNode.Tag = Enum_HR.User
            If eNode.Name = selectedDept Then
                selectNode = eNode
            End If
            parentItem.Nodes.Add(eNode)
        Next
    End Sub
#End Region

#Region "树形菜单事件"
    ''' <summary>
    '''  树形菜单单击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeView_Dept_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView_Dept.NodeMouseClick
        Me.TreeView_Dept.SelectedNode = e.Node
        ChooseNode(e.Node, True)
        '  SetTabEnable()
    End Sub


    Protected Sub ChooseNode(ByRef thatNode As TreeNode, Optional ByVal isClicked As Boolean = False)
        Dim nodeName As String = thatNode.Name
        TabEmployeeAndUser.Visible = True
        If thatNode.Tag = Enum_HR.Employee Then
            nodeName = thatNode.Parent.Name
            Me.selectedDept = thatNode.Parent.Name
        ElseIf thatNode.Tag = Enum_HR.User Then
            nodeName = thatNode.Parent.Name
            ' TabEmployeeAndUser.SelectTab(1)
            Me.selectedDept = thatNode.Parent.Name

        ElseIf thatNode.Tag = Enum_HR.Department Then
            Me.selectedDept = thatNode.Name
            If Not DtDepts Is Nothing Then
                Try
                    Dim msg As DtReturnMsg = Employee_GetByOption(GetSearchOption.FoList)
                    If msg.IsOk Then
                        '    DtEmployee = msg.Dt
                        CreateEmployeeNode(thatNode.Name, thatNode, msg.Dt)
                        AddworkYear(msg.Dt)
                        FG_Employee.DtToFG(msg.Dt)
                    End If
                    If thatNode.Name = "D" Then
                        TextBox_DeptNo.Text = "D"
                        TextBox_DeptName.Text = "所有部门"
                        TextBox_DeptSup.Text = ""
                        CB_IsProductive.Visible = False
                        '  TextBox_ENumPrefix.Text = ""
                    Else
                        Dim dr As DataRow = DtDepts.Select("Dept_No='" & nodeName & "'")(0)
                        TextBox_DeptNo.Text = IsNull(dr("Dept_No"), "")
                        TextBox_DeptName.Text = IsNull(dr("Dept_Name"), "")
                        TextBox_DeptSup.Text = IsNull(dr("Dept_SupperVisor"), "")
                        CB_IsProductive.Checked = IsNull(dr("IsProductive"), False)
                        If TextBox_DeptNo.Text.Length = 4 Then
                            CB_IsProductive.Visible = True
                        Else
                            CB_IsProductive.Visible = False
                        End If
                    End If
                    '    Else




                    '    Dim newDt As DataTable = BaseClass.ComFun.GetNewDataTable(DtEmployee, "Employee_Dept like '" & nodeName & "%'", "Employee_Dept,Employee_No")
                    '  Dim drsE As DataRow() = DtEmployee.Select("Employee_Dept='" & nodeName & "'")
                    LB_ZaiZhi.Text = DtEmployee.Compute("count(Employee_No)", "Employee_FileType='正式' And Employee_Dept like'" & TextBox_DeptNo.Text & "%'")
                    LB_LiZhi.Text = DtEmployee.Compute("count(Employee_No)", "Employee_FileType='离职' And Employee_Dept like'" & TextBox_DeptNo.Text & "%'")
                    ' FG_Employee.DtToFG(DtEmployee)
                    '  Else
                    Dim newDtuSER As DataTable = BaseClass.ComFun.GetNewDataTable(DtUser, "User_Dept like '" & nodeName & "%'", "User_Dept,User_ID")
                    '  Dim drsE As DataRow() = DtEmployee.Select("Employee_Dept='" & nodeName & "'")
                    Label_ECount.Text = newDtuSER.Rows.Count
                    FG_User.DtToFG(newDtuSER)
                    '  End If
                    '  End If
                    If isClicked = False Then
                        Me.TreeView_Dept.SelectedNode.Expand()
                    End If

                Catch ex As Exception
                    TextBox_DeptNo.Text = "D"
                    TextBox_DeptName.Text = "所有部门"
                    TextBox_DeptSup.Text = ""
                    'TextBox_ENumPrefix.Text = ""
                End Try
            End If



        End If
    End Sub


#End Region

#Region "右键菜单"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TSMI_AddDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_AddDept.Click
        If Me.TreeView_Dept.SelectedNode Is Nothing Then
            ShowErrMsg("请选择一个部门")
        Else
            If Me.TreeView_Dept.SelectedNode.Tag = Enum_HR.Employee OrElse Me.TreeView_Dept.SelectedNode.Tag = Enum_HR.User Then
                Me.TreeView_Dept.SelectedNode = Me.TreeView_Dept.SelectedNode.Parent
            End If
            Me.selectedDept = Me.TreeView_Dept.SelectedNode.Name
            Label_Mode.Tag = Mode_Enum.Add
            TabEmployeeAndUser.Visible = False
            LB_LiZhi.Text = 0
            LB_ZaiZhi.Text = 0

            RB_Employee.Checked = True
            Label_Mode.Tag = Mode_Enum.Add

            TextBox_DeptNo.Text = Department_GetNewEmployee_Dept(TreeView_Dept.SelectedNode.Name)
            TextBox_DeptName.Text = ""
            TextBox_DeptSup.Text = ""
            If TextBox_DeptNo.Text.Length = 4 Then
                CB_IsProductive.Visible = True
            Else
                CB_IsProductive.Visible = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TSMI_AddEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_AddEmployee.Click

        If Me.TreeView_Dept.SelectedNode Is Nothing OrElse Me.TreeView_Dept.SelectedNode.Name.Length < 4 Then
            ShowErrMsg("请选择一个部门")
        Else
            If Me.TreeView_Dept.SelectedNode.Tag = Enum_HR.Employee OrElse Me.TreeView_Dept.SelectedNode.Tag = Enum_HR.User Then
                Me.TreeView_Dept.SelectedNode = Me.TreeView_Dept.SelectedNode.Parent
            End If
            Me.selectedDept = Me.TreeView_Dept.SelectedNode.Name
            RB_Employee.Checked = True

            ShowEmployeeMsg("", Mode_Enum.Add)
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
            If mode = Mode_Enum.Add Then
                .P_F_RS_ID = Me.TreeView_Dept.SelectedNode.Name
                .P_F_RS_ID2 = Me.TreeView_Dept.SelectedNode.Text
            End If
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf EmployeeReturn
        VF.Show()
    End Sub

    Protected Sub EmployeeReturn()
        If Me.ReturnId <> "" Then
            Try
                selectedDept = Me.ReturnId
                selectedEmployee = Me.ReturnMsg
                '   ReLoad()

                Dim node As TreeNode = nodeMap(selectedDept)
                TreeView_Dept.SelectedNode = node
                ChooseNode(node)
                FG_Employee.RowSetForce("Employee_No", selectedEmployee)
            Catch ex As Exception

            End Try


        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TSMI_AddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_AddUser.Click

        If Me.TreeView_Dept.SelectedNode Is Nothing OrElse Me.TreeView_Dept.SelectedNode.Name.Length < 4 OrElse Not Me.TreeView_Dept.SelectedNode.Tag = Enum_HR.Department Then
            ShowErrMsg("请选择一个部门")
        Else
            Me.selectNode = Me.TreeView_Dept.SelectedNode
            RB_Employee.Checked = False
            ShowUserMsg("", "", Mode_Enum.Add)
        End If

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowUserMsg(ByVal User_ID As String, ByVal EmployeeID As String, ByVal mode As Mode_Enum)
        Dim F As New F990032_User_Msg(User_ID, EmployeeID)
        With F
            .Mode = mode
            .P_F_RS_ID = Me.TreeView_Dept.SelectedNode.Name
            .P_F_RS_ID2 = Me.TreeView_Dept.SelectedNode.Text
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetUser
        VF.Show()
    End Sub
    Protected Sub SetUser()
        selectedDept = Me.ReturnId
        selectedUser = Me.ReturnMsg
        ReLoad()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TSMI_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Del.Click
        If Me.TreeView_Dept.SelectedNode Is Nothing Then
            Exit Sub
        Else
            Select Case Me.TreeView_Dept.SelectedNode.Tag
                Case Enum_HR.Department
                    If CheckRight(ID, ClassMain.Del) = False Then ShowErrMsg("你没有权限删除部门!") : Exit Sub
                    ShowConfirm("是否删除部门[" & TreeView_Dept.SelectedNode.Text & "]?", AddressOf DelDept)
                Case Enum_HR.Employee
                    If CheckRight(ID, ClassMain.Employee & ClassMain.Del) = False Then ShowErrMsg("你没有权限删除员工!") : Exit Sub
                    ShowConfirm("是否删除员工 [" & TreeView_Dept.SelectedNode.Text & "]?", AddressOf DelEmployee)
                Case Enum_HR.User
                    If CheckRight(ID, ClassMain.User & ClassMain.Del) = False Then ShowErrMsg("你没有权限删除用户!") : Exit Sub
                    ShowConfirm("是否删除用户 [" & TreeView_Dept.SelectedNode.Text & "]?", AddressOf DelUser)
            End Select
        End If

    End Sub

#End Region

#Region "工具栏事件"
    ''''==========================部门===========================

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SaveDept.Click

        If CheckForm() Then ShowConfirm("是否保存部门[" & TextBox_DeptNo.Text & "]?", AddressOf SaveDept)

    End Sub

    Protected Sub SaveDept()
        If Label_Mode.Tag = Mode_Enum.Add Then
            Department_AddSave()
        Else
            Department_ModifySave()
            selectedDept = TextBox_DeptNo.Text
        End If
        ReLoad()
        Label_Mode.Tag = -1
    End Sub

    Private Sub Btn_DelDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_DelDept.Click
        ShowConfirm("是否删除部门[" & TextBox_DeptName.Text & "]?", AddressOf DelDept)
    End Sub

    Protected Sub DelDept()
        Dim msg As MsgReturn = Dept_Delete(TextBox_DeptNo.Text)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg)
        Else
            selectedDept = "D0"
        End If
        ReLoad()
    End Sub

    Protected Function CheckForm() As Boolean
        If TextBox_DeptNo.Text = "" Then
            ShowErrMsg("部门编号不能为空")
            Return False
        End If
        If TextBox_DeptName.Text = "" Then
            ShowErrMsg("部门名称不能为空")
            Return False
        End If
        Return True
    End Function


    Protected Sub DelUser()
        Dim msg As MsgReturn = User_Delete(TreeView_Dept.SelectedNode.Name)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg)
        Else

        End If
        ReLoad()
    End Sub



    Protected Sub DelEmployee()
        Employee_Del(TreeView_Dept.SelectedNode.Name)
        Me.ReLoad()
    End Sub







    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddDept.Click
        TSMI_AddDept_Click(TSMI_AddDept, New System.EventArgs)
    End Sub


    Private Sub Cmd_AddEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddEmployee.Click
        TSMI_AddEmployee_Click(TSMI_AddEmployee, New System.EventArgs)
    End Sub

    Private Sub Cmd_AddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TSMI_AddUser_Click(TSMI_AddUser, New System.EventArgs)
    End Sub


#End Region

#Region "FG 事件"
    Dim selectedEmployee As String = ""

    Private Sub FG1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG_Employee.DoubleClick
        If FG_Employee.RowSel <= 0 Then
            ShowErrMsg("请选择一个员工")
        Else
            Try


                Dim id As String = FG_Employee.SelectItem()("Employee_No")
                ShowEmployeeMsg(id, Mode_Enum.Modify)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Dim selectedUser As String = ""

    Private Sub FG_User_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG_User.DoubleClick
        If FG_User.RowSel <= 0 Then
            ShowErrMsg("请选择一个用户")
        Else
            Try


                Dim id As String = FG_User.SelectItem()("User_ID")
                ShowUserMsg(id, "", Mode_Enum.Modify)
            Catch ex As Exception

            End Try
        End If
    End Sub

#End Region


#Region "单选事件"
    Private Sub RB_LiZhi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_LiZhi.CheckedChanged, RB_ZaiZhi.CheckedChanged, RB_All.CheckedChanged
        '  If RB_LiZhi.Checked Then
        If MeIsLoad Then
            ReloadEmployee()
        End If

        '  End If
    End Sub

    'Private Sub RB_ZAiZhi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_ZaiZhi.CheckedChanged
    '    If RB_ZaiZhi.Checked Then
    '        ReloadEmployee()
    '    End If
    'End Sub

    'Private Sub RB_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_All.CheckedChanged
    '    If RB_All.Checked Then
    '        ReloadEmployee()
    '    End If
    'End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RB_Employee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Employee.CheckedChanged
        If Me.isLoaded Then
            If Not TreeView_Dept.SelectedNode Is Nothing Then
                selectedDept = TreeView_Dept.SelectedNode.Name
            End If
            If RB_Employee.Checked Then
                TabEmployeeAndUser.SelectTab(0)
            Else
                TabEmployeeAndUser.SelectTab(1)
            End If
            ReLoad()
        End If
    End Sub
#End Region


#Region "数据库交互"





#Region "增删改"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Department_AddSave() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim Employee_Dept As String = ""
        Try

            sql = "select top 1 * from T15000_Department where Dept_No=@Dept_No order by Dept_No"
            dt = SqlStrToDt(sql, Cnn, Da, "Dept_No", Employee_Dept).Dt
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
                dt.Rows(0)("Dept_No") = TextBox_DeptNo.Text
                dt.Rows(0)("Dept_Name") = TextBox_DeptName.Text
                dt.Rows(0)("Dept_SupperVisor") = TextBox_DeptSup.Text
                dt.Rows(0)("NodeIndex") = Me.TreeView_Dept.SelectedNode.Nodes.Count + 1
                dt.Rows(0)("NodeLevel") = Me.TreeView_Dept.SelectedNode.Level + 1
                dt.Rows(0)("IsProductive") = CB_IsProductive.Checked

                '  dt.Rows(0)("Dept_ENumPrefix") = TextBox_ENumPrefix.Text
                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "] 已经存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "] 修改错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Department_ModifySave() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim Employee_Dept As String = TextBox_DeptNo.Text
        Try

            sql = "select top 1 * from T15000_Department where Dept_No=@Dept_No order by Dept_No"
            dt = SqlStrToDt(sql, Cnn, Da, "Dept_No", Employee_Dept).Dt
            If dt.Rows.Count = 1 Then

                dt.Rows(0)("Dept_No") = TextBox_DeptNo.Text
                dt.Rows(0)("Dept_Name") = TextBox_DeptName.Text
                dt.Rows(0)("Dept_SupperVisor") = TextBox_DeptSup.Text
                dt.Rows(0)("NodeIndex") = Me.TreeView_Dept.SelectedNode.Index
                dt.Rows(0)("NodeLevel") = Me.TreeView_Dept.SelectedNode.Level
                dt.Rows(0)("IsProductive") = CB_IsProductive.Checked
                '   dt.Rows(0)("Dept_ENumPrefix") = TextBox_ENumPrefix.Text
                DtToUpDate(dt, Cnn, Da)
            Else
                ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "]不存在")
            End If
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "] 修改错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function

    Protected Function Dept_Delete(ByVal id As String) As MsgReturn
        If Dao.Dept_HaveEmplyee(id) = False Then


            Dim sql As String = "Delete  from T15000_Department where Dept_No='" & id & "' "
            Return PClass.PClass.RunSQL(sql)
        Else
            Dim msg As New MsgReturn
            msg.Msg = "该部门下有员工，不能删除。"
            Return msg
        End If
    End Function


    Protected Function User_Delete(ByVal id As String) As MsgReturn
        Dim sql As String = "Delete  from User_Info where User_ID='" & id & "' "
        Return PClass.PClass.RunSQL(sql)
    End Function



#End Region


#End Region



#Region "部门员工列表搜索条件"
    Protected Sub ClearGBDeptEmployee()


        DP_FirstDateFrom.Value = New Date(today.Year, 1, 1)
        DP_FirstDateTo.Value = today()
        TB_AgeFrom.Text = ""
        TB_AgeTo.Text = ""
        TB_EmployeeNo_Search.Text = ""
        RB_ZaiZhi.Checked = True

    End Sub
    '  Dim dtFgEmployee As DataTable
    Private Sub Cmd_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Search.Click

        ReloadEmployee()

    End Sub

    Private Sub ReloadEmployee()
        Dim msg As DtReturnMsg = Employee_GetByOption(GetSearchOption.FoList)
        If msg.IsOk Then
            Me.DtEmployee = AddworkYear(msg.Dt)
            FG_Employee.DtToFG(msg.Dt)
        End If

        If DP_FirstDateFrom.Checked Then

        End If
    End Sub

    Protected Function GetSearchOption() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption


        If DP_FirstDateFrom.Checked AndAlso DP_FirstDateTo.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_FirstDate"
            fo.Value = DP_FirstDateFrom.Value.Date
            fo.Value2 = DP_FirstDateTo.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)
        ElseIf DP_FirstDateFrom.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_FirstDate"
            fo.Value = DP_FirstDateFrom.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            oList.FoList.Add(fo)
        ElseIf DP_FirstDateTo.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_FirstDate"
            fo.Value = DP_FirstDateTo.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_LessOrEqual
            oList.FoList.Add(fo)
        End If


        If DTP_FirstDateFrom.Checked AndAlso DTP_FirstDateTo.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_QuitDate"
            fo.Value = DTP_FirstDateFrom.Value.Date
            fo.Value2 = DTP_FirstDateTo.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)
        ElseIf DTP_FirstDateFrom.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_QuitDate"
            fo.Value = DTP_FirstDateFrom.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_MoreOrEqual
            oList.FoList.Add(fo)
        ElseIf DTP_FirstDateTo.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_QuitDate"
            fo.Value = DTP_FirstDateTo.Value.Date
            fo.Field_Operator = Enum_Operator.Operator_LessOrEqual
            oList.FoList.Add(fo)
        End If








        If CB_SearchByDept.Checked AndAlso Not Me.TreeView_Dept.SelectedNode Is Nothing Then
            fo = New FindOption
            fo.DB_Field = "Employee_Dept"
            fo.Value = Me.TreeView_Dept.SelectedNode.Name

            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If Not TB_AgeTo.Text = "" And Not TB_AgeFrom.Text = "" Then
            fo = New FindOption
            fo.DB_Field = "Employee_Birthdate"
            Dim serverDate As Date = PClass.PClass.GetDate
            fo.Value2 = New Date(serverDate.Year - Val(TB_AgeFrom.Text), serverDate.Month, serverDate.Day)
            Dim ageTo As Integer = 0
            If Val(TB_AgeTo.Text) = 0 Then
                ageTo = 99
            Else
                ageTo = Val(TB_AgeTo.Text)
            End If
            fo.Value = New Date(serverDate.Year - ageTo, serverDate.Month, serverDate.Day)

            fo.Field_Operator = Enum_Operator.Operator_Between
            oList.FoList.Add(fo)
        End If

        If TB_EmployeeNo_Search.Text <> "" Then


            fo = New FindOption
            fo.DB_Field = CB_ConditionName.SelectedValue
            fo.Value = TB_EmployeeNo_Search.Text
            fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If



        If RB_ZaiZhi.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_FileType"
            fo.Value = F990031_Employee_Msg.EMPLOYEE_FILE_TYPE_LIZHI

            fo.Field_Operator = Enum_Operator.Operator_UnEqual
            oList.FoList.Add(fo)
        ElseIf RB_LiZhi.Checked Then
            fo = New FindOption
            fo.DB_Field = "Employee_FileType"
            fo.Value = F990031_Employee_Msg.EMPLOYEE_FILE_TYPE_LIZHI

            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)


        End If


        Return oList
    End Function
#End Region

#Region "报表"


    Private Sub Cmd_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click

        If DtEmployee Is Nothing Then
            Exit Sub
        End If

        Dim rptLoader As New R99003_Employee_List()
        rptLoader.Start(DtEmployee, PClass.CReport.OperatorType.Preview)
    End Sub


    Private Sub Cmd_Preview_Detail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview_Detail.Click
        If FG_Employee.DataSource Is Nothing Then
            Exit Sub
        End If

        Dim rptLoader As New R99003_Employee_Detail()
        rptLoader.Start(FG_Employee.DataSource, PClass.CReport.OperatorType.Preview)
    End Sub


    Private Sub Cmd_Preview_Room_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview_Room.Click
        If FG_Employee.DataSource Is Nothing Then
            Exit Sub
        End If

        Dim rptLoader As New R99003_Employee_Room()
        rptLoader.Start(GetSearchOption.FoList, PClass.CReport.OperatorType.Preview)
    End Sub
#End Region


#Region "鼠标拖动节点"

    Private Sub LpTreeView_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles TreeView_Dept.ItemDrag

        If Not CheckRight(ID, ClassMain.DeptOrder) Then
            Exit Sub
        End If
        Dim tn As TreeNode = TryCast(e.Item, TreeNode)
        'add condition...
        '   Move   the   dragged   node   when   the   left   mouse   button   is   used. 
        '当按住鼠标左键拖动节点时移动节点。
        If e.Button = MouseButtons.Left AndAlso (tn.Parent IsNot Nothing) Then

            '加上条件:根结点不允许拖动
            DoDragDrop(e.Item, DragDropEffects.Move)
            '   Copy   the   dragged   node   when   the   right   mouse   button   is   used. 
            '当按住鼠标右键拖动节点时复制节点。
        ElseIf e.Button = MouseButtons.Right Then
            DoDragDrop(e.Item, DragDropEffects.Copy)
        End If
    End Sub

    '   Set   the   target   drop   effect   to   the   effect     
    '   specified   in   the   ItemDrag   event   handler.   
    Private Sub LpTreeView_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView_Dept.DragEnter
        e.Effect = e.AllowedEffect
    End Sub

    '   Select   the   node   under   the   mouse   pointer   to   indicate   the     
    '   expected   drop   location.   
    Private Sub LpTreeView_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView_Dept.DragOver
        '   Retrieve   the   client   coordinates   of   the   mouse   position.   
        Dim targetPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
        Me.TreeView_Dept.SelectedNode = Me.TreeView_Dept.GetNodeAt(targetPoint)
        '  Me.TreeView_Dept.SelectedNode.Expand()
        '  Me.TreeView_Dept.SelectedNode.PrevNode.PrevNode.EnsureVisible()
        'If targetPoint.Y < 50 Then
        '    Dim targetPointx As Point = Me.PointToClient(New Point(e.X, e.Y - 500))
        '    'TreeView_Dept.AutoScrollOffset = Me.TreeView_Dept.SelectedNode.Parent
        '    '    Dim P As New Point(TreeView_Dept.AutoScrollOffset.X, TreeView_Dept.AutoScrollOffset.Y - 15000)
        '    '    TreeView_Dept.AutoScrollOffset = P
        '    '    TreeView_Dept.
        'End If

        '  Select   the   node   at   the   mouse   position.   

    End Sub
    '*
    '         * 拖放行为完成
    '         

    Private Sub LpTreeView_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView_Dept.DragDrop
        '   Retrieve   the   client   coordinates   of   the   drop   location.
        '   取回落下时的客户端坐标
        Dim targetPoint As Point = Me.PointToClient(New Point(e.X, e.Y))

        '   Retrieve   the   node   at   the   drop   location. 
        '   取回落下时的节点
        Dim targetNode As TreeNode = Me.TreeView_Dept.GetNodeAt(targetPoint)
        targetNode.ToolTipText = targetNode.Text
        '提示文本
        '   Retrieve   the   node   that   was   dragged.
        '   取回被拖拽的节点
        Dim draggedNode As TreeNode = DirectCast(e.Data.GetData(GetType(TreeNode)), TreeNode)
        draggedNode.ToolTipText = draggedNode.Text
        draNode = draggedNode
        '提示文本
        '   Confirm   that   the   node   at   the   drop   location   is   not     
        '   the   dragged   node   or   a   descendant   of   the   dragged   node.
        '   确定落下的节点不是被拖拽节点本身或者被拖拽节点的子节点
        If Not draggedNode.Equals(targetNode) AndAlso Not ContainsNode(draggedNode, targetNode) Then
            If Not draggedNode.Tag = Enum_HR.Department OrElse Not draggedNode.Parent Is targetNode.Parent Then
                Exit Sub
            End If
            '   If   it   is   a   move   operation,   remove   the   node   from   its   current     
            '   location   and   add   it   to   the   node   at   the   drop   location.
            Dim sql As String = ""
            'sql语句。
            If e.Effect = DragDropEffects.Move Then
                '   draggedNode.Remove()
                ' targetNode.Parent.Nodes.Add(draggedNode)
                MoveNode(draggedNode, targetNode)
                '数据库操作(移动节点)
                '1.更新draggedNode节点对应数据库中的父ID为targetNode节点的ID

                If UpdateDeptNode() Then
                    Me.selectedDept = draNode.Name
                    CreateTreeView(DtDepts)

                End If
                '   If   it   is   a   copy   operation,   clone   the   dragged   node     
                '   and   add   it   to   the   node   at   the   drop   location.   
            ElseIf e.Effect = DragDropEffects.Copy Then
                '数据库操作(复制节点)
                '1.向数据库中插入一条新的节点记录，父ID为targetNode节点的ID
                'sql = ""; //暂无数据操作。
                targetNode.Nodes.Add(DirectCast(draggedNode.Clone(), TreeNode))
            End If

            '   Expand   the   node   at   the   location     
            '   to   show   the   dropped   node.   
            targetNode.Expand()
        End If
    End Sub

    '   Determine   whether   one   node   is   a   parent     
    '   or   ancestor   of   a   second   node.
    '   确定一个节点是否是父节点。
    Private Function ContainsNode(ByVal node1 As TreeNode, ByVal node2 As TreeNode) As Boolean
        '   Check   the   parent   node   of   the   second   node.   
        If node2.Parent Is Nothing Then
            Return False
        End If
        If node2.Parent.Equals(node1) Then
            Return True
        End If

        '   If   the   parent   node   is   not   null   or   equal   to   the   first   node,     
        '   call   the   ContainsNode   method   recursively   using   the   parent   of     
        '   the   second   node.   
        Return ContainsNode(node1, node2.Parent)
    End Function
    Dim draNode As TreeNode

    Protected Sub MoveNode(ByVal node As TreeNode, ByVal targetNode As TreeNode)
        Me.DtDepts.Select("Dept_No='" & node.Name & "'")(0)("NodeIndex") = targetNode.Index
        '  Me.DtDept.Select("Dept_ID='" & targetNode.Name)(0)("NodeIndex") = targetNode.Index - 1
        MoveDownNextNode(targetNode)
    End Sub
    Protected Sub MoveDownNextNode(ByVal nextNode As TreeNode)
        Me.DtDepts.Select("Dept_No='" & nextNode.Name & "'")(0)("NodeIndex") = nextNode.Index + 1
        If Not nextNode.NextNode Is Nothing AndAlso Not draNode Is nextNode.NextNode Then
            MoveDownNextNode(nextNode.NextNode)
        End If
    End Sub

    Protected Function UpdateDeptNode() As Boolean
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim sql As String
        Dim Employee_Dept As String = TextBox_DeptNo.Text
        Try
            DtDepts.AcceptChanges()
            sql = "select * from T15000_Department "
            dt = SqlStrToDt(sql, Cnn, Da).Dt
            PClass.PClass.DvUpdateToDt(Me.DtDepts, dt, New List(Of String))
            DtToUpDate(dt, Cnn, Da)
            Da.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            ShowErrMsg("部门:[" & TextBox_DeptNo.Text & "] 修改错误")
            DebugToLog(ex)
            Return False
        End Try
    End Function
#End Region



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click

        Me.Close()
    End Sub



    Private Sub TreeView_Dept_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView_Dept.NodeMouseDoubleClick
        If e.Node.Tag = Enum_HR.Employee Then
            ShowEmployeeMsg(e.Node.Name, Mode_Enum.Modify)
        ElseIf e.Node.Tag = Enum_HR.User Then
            ShowUserMsg(e.Node.Name, "", Mode_Enum.Modify)
        End If
    End Sub

End Class

Partial Class Dao

    Public Shared Function Dept_HaveEmplyee(ByVal dept_No As String) As Boolean
        Dim sql As String = "select count(*)  from T15001_Employee where Employee_Dept like  '" & dept_No & "%'"
        Dim msg As MsgReturn = SqlStrToOneStr(sql)
        If msg.IsOk AndAlso Val(msg.Msg) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
