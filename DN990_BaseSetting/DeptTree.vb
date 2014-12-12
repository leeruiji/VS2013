Imports System.Data
Imports PClass.PClass
Imports BaseClass
<System.ComponentModel.ToolboxItem(False)> _
Public Class DeptTree
    Dim selectedDept As String = ""
    Dim DtDepts As New DataTable
    Dim DtEmployee As New DataTable
    Dim DtDept As New DataTable
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, TreeNode)




#Region "生成树形菜单"



    Public Sub LoadData()
        Dim msgEmployee As DtReturnMsg = Employee_GetEmployeeAll()
        If msgEmployee.IsOk Then
            DtEmployee = msgEmployee.Dt
            DtEmployee.Columns.Add("IsChecked", GetType(Boolean))
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
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Protected Sub CreateTreeView(ByVal dt As DataTable)
        nodeMap.Clear()
        Dim root As New TreeNode

        root.Name = "D0"
        root.Text = "部门"
        root.ImageIndex = 0
        If selectedDept = root.Name Then
            selectNode = root
        End If
        nodeMap.Add(root.Name, root)
        root.Tag = Enum_HR.Department
        root.Expand()

        For Each dr In dt.Select(" len (Dept_No)=4 ")
            Dim nId As String = dr("Dept_No")
            Dim nName As String = dr("Dept_Name")

            Dim item As TreeNode = root.Nodes.Add(nName)

            item.Name = nId
            item.Text = nName
            item.Tag = Enum_HR.Department
            If nId = selectedDept Then
                selectNode = item
            End If

            CreateEmployeeNode(nId, item)

            nodeMap.Add(item.Name, item)

            For Each dr2 In dt.Select(" len (Dept_No)>=7 and substring (Dept_No,1,4)='" & nId & "'")
                CreateTreeItems(dr2("Dept_No"), dr2("Dept_Name"), item)
            Next
        Next

        TreeView_Dept.Nodes.Clear()

        TreeView_Dept.Nodes.Add(root)
        TreeView_Dept.SelectedNode = selectNode
        If Not selectNode Is Nothing Then
            '     ChooseNode(selectNode)
        End If

    End Sub



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


            CreateEmployeeNode(nodeName, item)


            Return item
        Else
            Return Nothing

        End If

    End Function

    Protected Sub CreateEmployeeNode(ByVal name As String, ByVal parentItem As TreeNode)
        Dim drsE As DataRow() = DtEmployee.Select("DeptID='" & name & "'")

        For Each dr In drsE

            Dim eNode As New TreeNode
            eNode.Name = dr("Employee_No")
            eNode.Text = dr("Employee_Name")
            eNode.ImageIndex = 2
            eNode.Tag = Enum_HR.Employee
            If eNode.Name = selectedDept Then
                selectNode = eNode
            End If
            parentItem.Nodes.Add(eNode)
        Next
    End Sub

#End Region



#Region "树形菜单事件"
    Dim ci As Boolean = False
    ''' <summary>
    ''' 选择员工
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TreeView_Dept_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Dept.AfterCheck


        ci = True
        If e.Node.Tag = Enum_HR.Department Then
            For Each node As TreeNode In e.Node.Nodes
                node.Checked = e.Node.Checked
            Next
        ElseIf e.Node.Tag = Enum_HR.Employee Then
            Dim dr = DtEmployee.Select("Employee_No='" & e.Node.Name & "'")(0)
            dr("IsChecked") = e.Node.Checked
        End If

        ci = False
    End Sub
#End Region

    ''' <summary>
    ''' 获取选择的员工
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCheckedEmployee() As DataTable
        Return BaseClass.ComFun.GetNewDataTable(DtEmployee, "IsChecked=1", "Employee_No")
    End Function


End Class
