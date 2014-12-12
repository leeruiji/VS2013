Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10012_ClientBZ_Sel
    Public SelectedClientID As String = ""
    Dim dtGoodsType As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        '  Me.GoodsTypeTree1.SetParent(Me.LastForm)
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal jID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        SelectedClientID = jID
        ' Me.GoodsTypeTree1.SetParent(Me.LastForm
        Me.Mode = Mode

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(Val(P_F_RS_ID), ClassMain.Add, Cmd_Add)
        Control_CheckRight(Val(P_F_RS_ID), ClassMain.Modify, Cmd_Modify)
        '  Control_CheckRight(Val(P_F_RS_ID), ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F10003_GoodsType_Sel_Load() Handles Me.Me_Load

        FormCheckRight()
      


    End Sub

  



#Region "工具栏按钮"


    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click

        Dim F As PClass.BaseForm = PClass.PClass.LoadFormIDToChild(10111, Me)
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = Val(P_F_RS_ID)
            .P_F_RS_ID2 = ""
        End With

        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F)
        AddHandler VF.ClosedX, AddressOf Me.ClinetBZTree1.CreateTree
        VF.Show()
    End Sub

    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If Me.ClinetBZTree1.TreeView1.SelectedNode Is Nothing OrElse Me.ClinetBZTree1.TreeView1.SelectedNode.Parent Is Nothing Then


            Me.ShowErrMsg("请选择一个客户")

            Exit Sub
        End If
        Dim F As PClass.BaseForm = PClass.PClass.LoadFormIDToChild(10111, Me)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = Val(ClinetBZTree1.TreeView1.SelectedNode.Name)
            .P_F_RS_ID2 = ""
        End With

        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F)
        AddHandler VF.ClosedX, AddressOf Me.ClinetBZTree1.CreateTree
        VF.Show()
    End Sub





    'Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click

    '    If Me.ClinetBZTree1.TreeView1.SelectedNode Is Nothing OrElse Me.ClinetBZTree1.TreeView1.SelectedNode.Parent Is Nothing Then


    '        Me.ShowErrMsg("请选择一个分类")

    '        Exit Sub
    '    End If

    '    ShowConfirm("是否删除 [" & Me.ClinetBZTree1.TreeView1.SelectedNode.Text & "]?", AddressOf DelClient)


    'End Sub


    'Protected Sub DelClient()
    '    Dim msg As MsgReturn = GoodsType_Del(ClinetBZTree1.TreeView1.SelectedNode.Name)
    '    If msg.IsOk Then
    '        Me.ClinetBZTree1.CreateTree()
    '    End If

    'End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    Private Sub Btn_Choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Choose.Click
        If Me.ClinetBZTree1.TreeView1.SelectedNode Is Nothing OrElse Me.ClinetBZTree1.TreeView1.SelectedNode.Parent Is Nothing Then
            ShowErrMsg("请选择一个客户!")
            Exit Sub

        End If
        Me.LastForm.ReturnId = Me.ClinetBZTree1.TreeView1.SelectedNode.Name
        Me.LastForm.ReturnObj = Me.ClinetBZTree1.TreeView1.SelectedNode.Text
        Me.LastForm.ReturnMsg = Me.ClinetBZTree1.TreeView1.SelectedNode.Tag
        Me.Close()
    End Sub
#End Region


#Region "树形菜单事件"
    Protected Sub GoodsType_TV1_DBClick(ByVal id As String, ByVal name As String) Handles ClinetBZTree1.DbClickEvent
        Me.LastForm.ReturnId = id
        Me.LastForm.ReturnObj = name
        Me.LastForm.ReturnMsg = name
        Me.Close()
    End Sub
#End Region


End Class
