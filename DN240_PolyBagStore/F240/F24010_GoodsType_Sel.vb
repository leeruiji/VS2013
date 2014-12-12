Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F24010_GoodsType_Sel
    Dim GoodsTypeID As String = ""
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
        GoodsTypeID = jID
        ' Me.GoodsTypeTree1.SetParent(Me.LastForm
        Me.Mode = Mode

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 24000
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F10003_GoodsType_Sel_Load() Handles Me.Me_Load

        FormCheckRight()
        If GoodsTypeID = "" AndAlso Me.P_F_RS_ID <> "" Then
            GoodsTypeID = P_F_RS_ID
        End If
        '  Me.GoodsTypeTree1.SetRootID(Me.GoodsTypeID)
        Me.GoodsTypeTree1.Me_Refresh()
    End Sub




#Region "事件"

#End Region

#Region "工具栏按钮"


    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click

        If Me.GoodsTypeTree1.TV_GoodsType.SelectedNode Is Nothing Then


            Me.ShowErrMsg("请选择一个分类")

            Exit Sub
        End If
        Dim F As New F24011_GoodsType_Msg(GoodsTypeTree1.TV_GoodsType.SelectedNode.Name, GoodsTypeTree1.TV_GoodsType.SelectedNode.Text, "")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ID
            .P_F_RS_ID2 = ""
        End With

        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F)
        AddHandler VF.ClosedX, AddressOf GoodsTypeTree1.Me_Refresh
        VF.Show()
    End Sub

    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If Me.GoodsTypeTree1.TV_GoodsType.SelectedNode Is Nothing OrElse Me.GoodsTypeTree1.TV_GoodsType.SelectedNode.Parent Is Nothing Then


            Me.ShowErrMsg("请选择一个分类")

            Exit Sub
        End If
        Dim F As New F24011_GoodsType_Msg(GoodsTypeTree1.TV_GoodsType.SelectedNode.Name, GoodsTypeTree1.TV_GoodsType.SelectedNode.Text, GoodsTypeTree1.TV_GoodsType.SelectedNode.Name)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ID
            .P_F_RS_ID2 = ""
        End With

        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F)
        AddHandler VF.ClosedX, AddressOf GoodsTypeTree1.Me_Refresh
        VF.Show()
    End Sub





    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click

        If Me.GoodsTypeTree1.TV_GoodsType.SelectedNode Is Nothing OrElse Me.GoodsTypeTree1.TV_GoodsType.SelectedNode.Parent Is Nothing Then


            Me.ShowErrMsg("请选择一个分类")

            Exit Sub
        End If

        ShowConfirm("是否删除 [" & Me.GoodsTypeTree1.TV_GoodsType.SelectedNode.Text & "]?", AddressOf DelGoodsType)


    End Sub


    Protected Sub DelGoodsType()
        Dim msg As MsgReturn = Dao.GoodsType_Del(GoodsTypeTree1.TV_GoodsType.SelectedNode.Name)
        If msg.IsOk Then
            Me.GoodsTypeTree1.Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)
        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    Private Sub Btn_Choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Choose.Click
        If Me.GoodsTypeTree1.TV_GoodsType.SelectedNode Is Nothing Then
            ShowErrMsg("请选择一个分类!")
            Exit Sub

        End If
        Me.LastForm.ReturnId = Me.GoodsTypeTree1.TV_GoodsType.SelectedNode.Name
        Me.LastForm.ReturnObj = Me.GoodsTypeTree1.TV_GoodsType.SelectedNode.Text
        Me.LastForm.ReturnMsg = Me.GoodsTypeTree1.TV_GoodsType.SelectedNode.Tag
        Me.Close()
    End Sub
#End Region


#Region "树形菜单事件"
    Protected Sub GoodsType_TV1_DBClick(ByVal id As String, ByVal name As String, ByVal prefix As String) Handles GoodsTypeTree1.DbClickEvent
        Me.LastForm.ReturnId = id
        Me.LastForm.ReturnObj = name
        Me.LastForm.ReturnMsg = prefix
        Me.Close()
    End Sub
#End Region


End Class
