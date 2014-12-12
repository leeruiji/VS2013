Imports PClass.PClass.DtReturnMsg
Imports PClass.PClass
Imports System.Data
Imports PClass.BaseForm

<System.ComponentModel.ToolboxItem(False)> _
Public Class GoodsTypeTree
    Dim pForm As PClass.BaseForm
    Dim DtgoodsType As New DataTable
    Dim goodsTypeID As String = ""
    Public selectedType As String = ""
    Dim selectedNode As TreeNode
    Protected Const ROOT_FREFIX = "GT"
    Dim rootId As String = ROOT_FREFIX


    ''' <summary>
    ''' 分类
    ''' </summary>
    ''' <remarks></remarks>
    '''Public Const NODE_BZ = "GT001"
    ''' <summary>
    ''' 分类
    ''' </summary>
    ''' <remarks></remarks>
    '''Public Const NODE_BZC = "GT002"

    ''' <summary>
    ''' 分类
    ''' </summary>
    ''' <remarks></remarks>
    Public Const NODE_WL = "GT001"


    Public nodeMap As New Dictionary(Of String, TreeNode)

    Public Event SelectedEvent(ByVal id As String, ByVal name As String)

    Public Event DbClickEvent(ByVal id As String, ByVal name As String, ByVal prefix As String)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="goodsTypeID"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal goodsTypeID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.goodsTypeID = goodsTypeID
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="goodsTypeID"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal rootID As String, ByVal goodsTypeID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.goodsTypeID = goodsTypeID
        Me.rootId = rootID
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pForm"></param>
    ''' <remarks></remarks>
    Public Sub SetParent(ByVal pForm As PClass.BaseForm)
        Me.pForm = pForm
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="rootID"></param>
    ''' <remarks></remarks>
    Public Sub SetRootID(ByVal rootID As String)
        Me.rootId = rootID
    End Sub

    Private Sub GoodsTypeTree_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' CreateTree()

    End Sub

    Public Sub Me_Refresh()
        CreateTree()
    End Sub

    Public Sub SelectNode(ByVal TypeId As String)
        If nodeMap.ContainsKey(TypeId) Then
            Dim node As TreeNode = nodeMap(TypeId)
            TV_GoodsType.SelectedNode = node
        Else
            selectedType = TypeId
            Me_Refresh()
        End If
    End Sub

#Region "生成树形菜单"

    Protected Sub CreateTree()
        Dim msg As DtReturnMsg = GoodsType_GetChildrenByParentID(Me.rootId)
        If msg.IsOk Then
            DtgoodsType = msg.Dt
            TV_GoodsType.Nodes.Clear()

            nodeMap.Clear()
            Dim root As New TreeNode
            If Me.rootId = ROOT_FREFIX Then

                root.Name = ROOT_FREFIX
                root.Text = "商品分类"
                root.Tag = ROOT_FREFIX
                TV_GoodsType.Nodes.Add(root)
                nodeMap.Add(root.Name, root)
            Else

            End If
            If root.Name = selectedType Then

                selectedNode = root
            End If

            Dim item As TreeNode
            '  For Each dr In msg.Dt.Rows
            Dim dr As DataRow
            For i = 0 To msg.Dt.Rows.Count - 1
                dr = msg.Dt.Rows(i)

                item = New TreeNode
                item.Name = dr("GoodsType_ID")
                item.Text = dr("GoodsType_Name")
                item.Tag = dr("GoodsType_StartNo")
                If i = 0 AndAlso Not Me.rootId = ROOT_FREFIX Then
                    TV_GoodsType.Nodes.Add(item)
                    nodeMap.Add(item.Name, item)

                ElseIf AddToParentNode(item) Then
                    nodeMap.Add(item.Name, item)
                End If
                If item.Name = selectedType Then
                    selectedNode = item
                End If
            Next
        End If
        TV_GoodsType.ExpandAll()
        If Not selectedNode Is Nothing Then
            selectedNode.Checked = True
            TV_GoodsType.SelectedNode = selectedNode
        End If

    End Sub

    ''' <summary>
    ''' 如果节点有父节点,则把节点加入到父节点下面
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Protected Function AddToParentNode(ByVal item As TreeNode) As Boolean
        Try


            Dim pName As String = item.Name.Substring(0, item.Name.Length - 3)
            If nodeMap.ContainsKey(pName) Then
                nodeMap(pName).Nodes.Add(item)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            DebugToLog(ex)
            Return False
        End Try
    End Function
#End Region

#Region "Node To Dt"

#End Region

#Region "事件"
    Private Sub TV_GoodsType_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TV_GoodsType.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim node As System.Windows.Forms.TreeNode = TV_GoodsType.GetNodeAt(e.X, e.Y)
            If node IsNot Nothing Then
                TV_GoodsType.SelectedNode = node
            End If
        End If
    End Sub
    Private Sub TV_GoodsType_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV_GoodsType.AfterSelect
        selectedType = TV_GoodsType.SelectedNode.Name
        selectedNode = TV_GoodsType.SelectedNode
        RaiseEvent SelectedEvent(TV_GoodsType.SelectedNode.Name, TV_GoodsType.SelectedNode.Text)
    End Sub


    Private Sub TV_GoodsType_DBClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TV_GoodsType.DoubleClick
        If TV_GoodsType.SelectedNode Is Nothing OrElse TV_GoodsType.SelectedNode.Parent Is Nothing Then
            If Not pForm Is Nothing Then
                pForm.ShowErrMsg("请选择一个分类")
            End If
            Exit Sub
        End If
        RaiseEvent DbClickEvent(TV_GoodsType.SelectedNode.Name, TV_GoodsType.SelectedNode.Text, TV_GoodsType.SelectedNode.Tag)
    End Sub


#End Region
#Region "右键菜单"



    ''' <summary>
    ''' 新增分类
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TSMI_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ADD.Click
        If TV_GoodsType.SelectedNode Is Nothing Then

            If Not pForm Is Nothing Then
                pForm.ShowErrMsg("请选择一个分类")
            End If
            Exit Sub
        End If
        Dim F As New F10002_GoodsType_Msg(TV_GoodsType.SelectedNode.Name, TV_GoodsType.SelectedNode.Text, "")
        With F
            .Mode = Mode_Enum.Add
            If pForm Is Nothing Then
                .P_F_RS_ID = ""
            Else
                .P_F_RS_ID = pForm.ID
            End If
            .P_F_RS_ID2 = ""
        End With

        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub



    Private Sub TSMI_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Save.Click
        If TV_GoodsType.SelectedNode Is Nothing OrElse TV_GoodsType.SelectedNode.Name = "GT" Then

            If Not pForm Is Nothing Then
                pForm.ShowErrMsg("请选择一个分类")
            End If
            Exit Sub
        End If
        Dim F As F10002_GoodsType_Msg
        If TV_GoodsType.SelectedNode.Name.Length <= 5 Then
            F = New F10002_GoodsType_Msg("GT", "商品分类", TV_GoodsType.SelectedNode.Name)
        Else
            F = New F10002_GoodsType_Msg(TV_GoodsType.SelectedNode.Parent.Name, TV_GoodsType.SelectedNode.Parent.Text, TV_GoodsType.SelectedNode.Name)
        End If

        With F
            .Mode = Mode_Enum.Modify

            If pForm Is Nothing Then
                .P_F_RS_ID = ""
            Else
                .P_F_RS_ID = pForm.P_F_RS_ID
            End If
            .P_F_RS_ID2 = ""
        End With

        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub

    Private Sub TSMI_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_Del.Click
        If TV_GoodsType.SelectedNode Is Nothing OrElse TV_GoodsType.SelectedNode.Parent Is Nothing Then

            If Not pForm Is Nothing Then
                pForm.ShowErrMsg("请选择一个分类")
            End If
            Exit Sub
        End If
        If Not pForm Is Nothing Then
            pForm.ShowConfirm("是否删除 [" & TV_GoodsType.SelectedNode.Text & "]?", AddressOf DelGoodsType)
        Else
            DelGoodsType()
        End If
    End Sub

    Protected Sub DelGoodsType()
        Dim msg As MsgReturn = GoodsType_Del(TV_GoodsType.SelectedNode.Name)
        If msg.IsOk Then
            Me.Me_Refresh()
        Else
            pForm.ShowErrMsg(msg.Msg)
        End If

    End Sub
#End Region





End Class
