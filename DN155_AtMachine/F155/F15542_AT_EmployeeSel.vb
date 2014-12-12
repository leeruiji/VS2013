Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F15542_AT_EmployeeSel
    Dim selectedDept As String = ""
    Dim DtDepts As New DataTable
    Dim DtEmployee_Left As New DataTable
    Dim DtEmployee_Right As New DataTable
    ' Dim DtDept As New DataTable
    Dim groupDt As New DataTable
    Dim selectNode As TreeNode

    Public CanClosed As Boolean = False
    Public parent_Form As F15541_AT_ReleasePass_Msg

    'Dim DeptNodeMap_Left As New Dictionary(Of String, TreeNode)
    'Dim EmpNodeMap_Left As New Dictionary(Of String, TreeNode)
    'Dim DeptNodeMap_Right As New Dictionary(Of String, TreeNode)
    'Dim EmpNodeMap_Right As New Dictionary(Of String, TreeNode)
    '''' <summary>
    '''' 权限获取
    '''' </summary>
    ''''' <remarks></remarks>
    'Sub FormCheckRight()
    '    ID = 15540
    '    'Control_CheckRight(ID, ClassMain.Add, Cmd_SendAll)
    '    TSMI_AddDept.Enabled = Cmd_SendAll.Enabled
    '    Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    'End Sub

    Private Sub F15503_AT_EmployeeSel_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing

    End Sub

    Private Sub F99003_Department_Me_Load() Handles Me.Me_Load
        'FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        CB_shift.ComboBox.ValueMember = "ID"
        CB_shift.ComboBox.DisplayMember = "Name"
        Dim R As DtReturnMsg = Dao.Get_Shift_Moudel
        If R.IsOk Then
            CB_shift.ComboBox.DataSource = R.Dt
        End If
        Dim dr As DataRow = R.Dt.NewRow
        dr("Name") = "所有班次"
        dr("ID") = 0
        R.Dt.Rows.InsertAt(dr, 0)
        CB_shift.ComboBox.SelectedIndex = 0

        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "选择列表"
        Me_Refresh()


    End Sub

    Private Sub Me_Refresh()
        Dim msgEmployee As DtReturnMsg = Dao.EmployeeSel_GetByOption(GetFindOtions)
        If msgEmployee.IsOk Then
            DtEmployee_Left = msgEmployee.Dt

            DtEmployee_Right = DtEmployee_Left.Clone
        End If

        Dim msgDept As DtReturnMsg = Department_GetDeptAll()
        If msgDept.IsOk Then
            DtDepts = msgDept.Dt
            CreateTreeiew_Left(DtDepts)
            CreateTreeiew_Right(DtDepts)
        End If
    End Sub





    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption



        If CB_shift.ComboBox.SelectedItem IsNot Nothing AndAlso CB_shift.ComboBox.SelectedValue <> 0 Then
            fo.DB_Field = "Employee_ShiftMoudel"
            fo.Value = CB_shift.ComboBox.SelectedValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        Return oList
    End Function

#Region "生成树形菜单"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Sub CreateTreeiew_Left(ByVal dt As DataTable)
        Dim root As New TreeNode
        root.Name = "D0"
        root.Text = "部门"
        root.ImageIndex = 0
        root.Tag = Enum_HR.Department
        root.Expand()
        For Each dr In dt.Select(" len (Dept_No)=4 ")
            Dim item As New TreeNode
            Dim nId As String = dr("Dept_No")
            Dim nName As String = dr("Dept_Name")
            item.Name = nId
            item.Text = nName
            item.Tag = Enum_HR.Department
            If nId = selectedDept Then
                selectNode = item
            End If
            CreateEmployeeNode(nId, item, False)
            '   DeptNodeMap_Left.Add(item.Name, item)
            root.Nodes.Add(item)
            For Each dr2 In dt.Select(" len (Dept_No)>=7 and substring (Dept_No,1,4)='" & nId & "'")
                CreateTreeItems(dr2("Dept_No"), dr2("Dept_Name"), item)
            Next
        Next

        TV_Left.Nodes.Clear()

        TV_Left.Nodes.Add(root)
        TV_Left.SelectedNode = selectNode
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Sub CreateTreeiew_Right(ByVal dt As DataTable)
        Dim root As New TreeNode
        root.Name = "D0"
        root.Text = "部门"
        root.ImageIndex = 0
        root.Tag = Enum_HR.Department
        root.Expand()
        For Each dr In dt.Select(" len (Dept_No)=4 ")
            Dim item As New TreeNode
            Dim nId As String = dr("Dept_No")
            Dim nName As String = dr("Dept_Name")
            item.Name = nId
            item.Text = nName
            item.Tag = Enum_HR.Department
            If nId = selectedDept Then
                selectNode = item
            End If
            CreateEmployeeNode(nId, item, True)
            '  DeptNodeMap_Right.Add(item.Name, item)
            root.Nodes.Add(item)
            For Each dr2 In dt.Select(" len (Dept_No)>=7 and substring (Dept_No,1,4)='" & nId & "'")
                CreateTreeItems(dr2("Dept_No"), dr2("Dept_Name"), item, True)
            Next
        Next

        TV_Right.Nodes.Clear()

        TV_Right.Nodes.Add(root)
        TV_Right.SelectedNode = selectNode
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="nodeName"></param>
    ''' <param name="nodeText"></param>
    ''' <param name="parentItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTreeItems(ByVal nodeName As String, ByVal nodeText As String, ByVal parentItem As TreeNode, Optional ByVal isRight As Boolean = False) As TreeNode

        Dim MParentID As String = nodeName.Substring(0, nodeName.Length - 3)
        If MParentID.Length = parentItem.Name.Length Then
            If MParentID = parentItem.Name Then
                Dim item As TreeNode = New TreeNode
                item.Name = nodeName
                item.Text = nodeText
                item.Tag = Enum_HR.Department

                If nodeName = selectedDept Then
                    selectNode = item
                End If
                If nodeName = selectedDept Then
                    item.Checked = True
                    item.Expand()
                End If

                parentItem.Nodes.Add(item)
                'If isRight Then
                '    DeptNodeMap_Right.Add(item.Name, item)

                'Else
                '    DeptNodeMap_Left.Add(item.Name, item)

                'End If
                CreateEmployeeNode(nodeName, item, isRight)
                Return item
            Else
                Return parentItem
            End If
        Else
            If MParentID.Length > parentItem.Name.Length Then
                Return parentItem
            Else
                Return CreateTreeItems(nodeName, nodeText, parentItem.Parent)
            End If
        End If
    End Function

    Protected Sub CreateEmployeeNode(ByVal name As String, ByVal parentItem As TreeNode, ByVal isRight As Boolean)
        Dim dtEmployee As DataTable
        If isRight Then
            dtEmployee = DtEmployee_Right
        Else
            dtEmployee = DtEmployee_Left
        End If
        Dim drsE As DataRow()
        If dtEmployee Is Nothing OrElse dtEmployee.Rows.Count = 0 Then
            Exit Sub
        End If
        drsE = dtEmployee.Select("Employee_Dept='" & name & "'")



        For Each dr In drsE

            Dim eNode As New TreeNode
            eNode.Name = dr("Employee_No")
            eNode.Text = dr("Employee_Name")
            eNode.ImageIndex = 2
            eNode.Tag = Enum_HR.Employee
            If eNode.Name = selectedDept Then
                selectNode = eNode
            End If
            'If isRight Then
            '    EmpNodeMap_Right.Add(eNode.Name, eNode)
            'Else
            '    EmpNodeMap_Left.Add(eNode.Name, eNode)
            'End If
            parentItem.Nodes.Add(eNode)
        Next
        If drsE.Length > 0 Then
            parentItem.ExpandAll()
        End If
    End Sub

    'Private Sub AddEmployee(ByVal parentItem As TreeNode, ByVal name As String, ByVal text As String, ByVal isRight As Boolean)
    '    Dim eNode As New TreeNode()
    '    eNode.Tag = Enum_HR.Employee
    '    eNode.Name = name
    '    eNode.Text = text
    '    eNode.ImageIndex = 2
    '    parentItem.Nodes.Add(eNode)
    '    If isRight Then
    '        EmpNodeMap_Left.Add(eNode.Name, eNode)
    '    Else
    '        EmpNodeMap_Right.Add(eNode.Name, eNode)
    '    End If
    'End Sub
#End Region

#Region "树形菜单事件"

    Private Sub TreeView_Dept_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TV_Left.DragDrop

    End Sub
    Private Sub TreeView_Dept_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TV_Left.NodeMouseClick
        If e.Node Is Nothing Then
            Exit Sub
        End If
        Dim nodeName As String = e.Node.Name

        If Not DtDepts Is Nothing Then
            Try
                If e.Node.Name = "D0" Then


                Else

                End If

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
    Private Sub TreeView_Dept_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TV_Left.NodeMouseDoubleClick
        AddAndRemoveNode(False, e)
    End Sub


    Private Sub TV_Right_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TV_Right.NodeMouseDoubleClick
        AddAndRemoveNode(True, e)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="isRightToLeft"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddAndRemoveNode(ByVal isRightToLeft As Boolean, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        If e.Node Is Nothing Then
            Exit Sub
        End If
        Dim dtTarget As DataTable
        Dim dtSource As DataTable
        'Dim eMap_Target As Dictionary(Of String, TreeNode)
        'Dim dMap_Target As Dictionary(Of String, TreeNode)
        'Dim eMap_Source As Dictionary(Of String, TreeNode)
        'Dim dMap_Source As Dictionary(Of String, TreeNode)
        If isRightToLeft Then
            dtTarget = DtEmployee_Left
            dtSource = DtEmployee_Right

            'eMap_Target = EmpNodeMap_Left
            'dMap_Target = DeptNodeMap_Left

            'eMap_Source = EmpNodeMap_Right
            'dMap_Source = DeptNodeMap_Right
        Else
            dtTarget = DtEmployee_Right
            dtSource = DtEmployee_Left

            'eMap_Target = EmpNodeMap_Right
            'dMap_Target = DeptNodeMap_Right

            'eMap_Source = EmpNodeMap_Left
            'dMap_Source = DeptNodeMap_Left
        End If
        If e.Node.Tag IsNot Nothing AndAlso e.Node.Tag = Enum_HR.Employee Then
            Dim newDr As DataRow = dtTarget.NewRow
            Dim ds As DataRow() = dtSource.Select("Employee_No ='" & e.Node.Name & "'")
            Dim dr As DataRow
            If ds.Length > 0 Then
                dr = ds(0)
            Else
                Exit Sub
            End If
            newDr("Employee_No") = dr("Employee_No")
            newDr("Employee_Name") = dr("Employee_Name")
            newDr("ID") = dr("ID")
            newDr("Employee_Card") = dr("Employee_Card")
            newDr("Employee_Dept") = dr("Employee_Dept")
            newDr("Dept_Name") = dr("Dept_Name")
            dtTarget.Rows.Add(newDr)

            dtTarget.AcceptChanges()
            dtSource.AcceptChanges()


            'AddEmployee(dMap_Target(dr("Employee_Dept")), dr("Employee_No"), dr("Employee_Name"), isRightToLeft)
            'dMap_Target(dr("Employee_Dept")).ExpandAll()
            'eMap_Source(dr("Employee_No")).Remove()
            'eMap_Source.Remove(dr("Employee_No"))
            dr.Delete()
        ElseIf e.Node.Tag IsNot Nothing AndAlso e.Node.Tag = Enum_HR.Department Then
            Dim newDr As DataRow = dtTarget.NewRow
            Dim ds As DataRow() = dtSource.Select("Employee_Dept like '" & e.Node.Name & "%'")
            For Each dr As DataRow In ds
                newDr = dtTarget.NewRow
                newDr("Employee_No") = dr("Employee_No")
                newDr("Employee_Name") = dr("Employee_Name")
                newDr("ID") = dr("ID")
                newDr("Employee_Card") = dr("Employee_Card")
                newDr("Employee_Dept") = dr("Employee_Dept")
                newDr("Dept_Name") = dr("Dept_Name")
                dtTarget.Rows.Add(newDr)

                'AddEmployee(dMap_Target(dr("Employee_Dept")), dr("Employee_No"), dr("Employee_Name"), isRightToLeft)
                'dMap_Target(dr("Employee_Dept")).ExpandAll()
                'eMap_Source(dr("Employee_No")).Remove()
                'eMap_Source.Remove(dr("Employee_No"))
                dr.Delete()
            Next
            dtTarget.AcceptChanges()
            dtSource.AcceptChanges()
        End If


        CreateTreeiew_Right(Me.DtDepts)
        CreateTreeiew_Left(Me.DtDepts)
    End Sub

#End Region

#Region "工具栏事件"
    ''''==========================部门===========================








    Protected Function CheckForm() As Boolean

        Return True
    End Function
    ''' <summary>
    ''' 刷新页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Reflesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        F99003_Department_Me_Load()
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



#Region "数据库交互"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="condition"></param>
    ''' <param name="sortstr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewDataTable(ByVal dt As DataTable, ByVal condition As String, ByVal sortstr As String) As DataTable
        Dim newdt As New DataTable()
        newdt = dt.Clone()
        Dim dr As DataRow() = dt.Select(condition, sortstr)
        For i As Integer = 0 To dr.Length - 1
            newdt.ImportRow(DirectCast(dr(i), DataRow))
        Next
        Return newdt
        '返回的查询结果
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function Department_GetDeptAll() As DtReturnMsg
        Dim sql As String = "select * from T15000_Department order by Dept_No"
        Return PClass.PClass.SqlStrToDt(sql)

    End Function

    Protected Function Department_GetDeptById(ByVal id As String) As DtReturnMsg
        Dim sql As String = "select * from T15000_Department where Dept_No='" & id & "' order by Dept_No"
        Return PClass.PClass.SqlStrToDt(sql)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Department_GetNewDeptID(ByVal parentId As String) As String
        Try
            Dim sql As String
            Dim msg As New MsgReturn
            If parentId.Length >= 4 Then
                sql = "select top 1 Dept_No  from T15000_Department where Dept_No like '" & parentId & "%' order by Dept_No desc"
            Else
                parentId = "D"
                sql = "select top 1 Dept_No  from T15000_Department where len( Dept_No)=4  order by Dept_No desc"
            End If

            msg = SqlStrToOneStr(sql)

            If msg.IsOk Then
                Dim s As String = ""
                Dim i As Integer
                If msg.Msg.Length = parentId.Length Then
                    i = 1
                Else
                    i = Integer.Parse(msg.Msg.Substring(msg.Msg.Length - 3, 3))
                End If





                i = i + 1
                If i < 10 Then
                    s = "00" & i
                ElseIf i > 10 AndAlso i < 100 Then
                    s = "0" & i
                End If
                Return parentId & s

            Else
                Return ""

            End If
        Catch ex As Exception
            DebugToLog(ex)
            Return ""
        End Try
    End Function



#Region "增删改"

#End Region


#End Region
#Region "发送名单"

    Private Sub Cmd_SendAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SendAll.Click
        LastForm.ReturnId = "1"
        If parent_Form IsNot Nothing Then
            'parentForm.Send()
        End If

    End Sub

    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        LastForm.ReturnId = "2"
        LastForm.ReturnObj = DtEmployee_Right
        Me.Close()
    End Sub
#End Region



    Private Sub CB_shift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_shift.SelectedIndexChanged
        Me_Refresh()
    End Sub
End Class

Partial Class Dao
 
   
    Public Const SQL_Get_Employee As String = " select E.ID, E.Employee_No,E.Employee_Name,E.Employee_Card,E.Employee_Dept,D.Dept_Name from T15001_Employee E left join T15000_Department D on E.Employee_Dept=D.Dept_No "
    ''' <summary>
    ''' 获取班次
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Get_Shift_Moudel() As DtReturnMsg
        Return SqlStrToDt("Select * from T15515_Shift_Moudel")

    End Function


    ''' <summary>
    ''' 按条件获取采购单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EmployeeSel_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Get_Employee)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(" and isnull(E.Employee_Card,'')<>'' and isnull(E.Employee_CardEndDate,'')='' ")
        sqlBuider.Append("  order by E.Employee_Dept ,E.ID")
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function











End Class

