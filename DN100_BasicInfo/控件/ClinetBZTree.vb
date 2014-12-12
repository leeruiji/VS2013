Imports PClass.PClass.DtReturnMsg
Imports PClass.PClass
Imports System.Data
Imports PClass.BaseForm

<System.ComponentModel.ToolboxItem(False)> _
Public Class ClinetBZTree
    Dim pForm As PClass.BaseForm
    Dim ClientDt As DataTable
    Dim SelectedClientID As Integer
    Public Const RootID As Integer = -1

#Region "事件"
    ''' <summary>
    ''' 单击选择
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="name"></param>
    ''' <remarks></remarks>
    Public Event SelectedEvent(ByVal id As String, ByVal name As String)

    ''' <summary>
    ''' 单击选择
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="name"></param>
    ''' <remarks></remarks>
    Public Event DbClickEvent(ByVal id As String, ByVal name As String)
#End Region

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal _SelectedClientID As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.SelectedClientID = _SelectedClientID

    End Sub


    Private Sub ClinetBZTree_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CreateTree()
    End Sub

    ''' <summary>
    ''' 生成树
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateTree()
        Me.TreeView1.Nodes.Clear()
        Dim root As New TreeNode
        root.Name = RootID
        root.Tag = RootID
        root.Text = "所有客户"
        Me.TreeView1.Nodes.Add(root)
        Dim msg As DtReturnMsg = ClinetBZTree_GetClient()

        Dim node As TreeNode
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            For Each dr As DataRow In msg.Dt.Rows
                node = New TreeNode
                node.Name = dr("ID")
                node.Tag = dr("ID")
                node.Text = dr("Client_Name")
                root.Nodes.Add(node)
                If Me.SelectedClientID = node.Name Then
                    Me.TreeView1.SelectedNode = node
                End If

            Next
            If Me.TreeView1.SelectedNode Is Nothing Then
                Me.TreeView1.SelectedNode = root.Nodes(0)
            End If

        End If

    End Sub

#Region "数据交互"
    ''' <summary>
    ''' 获取客户列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ClinetBZTree_GetClient() As DtReturnMsg
        Dim sql As String = " select ID,Client_No,Client_Name from T10110_Client where isnull( Disable,0) =0"
        Return PClass.PClass.SqlStrToDt(sql)
    End Function



#End Region

#Region "树形菜单事件"
    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        RaiseEvent SelectedEvent(e.Node.Name, e.Node.Text)
    End Sub
    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
        If TreeView1.SelectedNode Is Nothing Then
            Exit Sub
        End If
        RaiseEvent DbClickEvent(TreeView1.SelectedNode.Name, TreeView1.SelectedNode.Text)
    End Sub

#End Region



End Class
