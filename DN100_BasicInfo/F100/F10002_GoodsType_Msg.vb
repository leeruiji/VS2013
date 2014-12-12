Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10002_GoodsType_Msg
    Dim goodsTypeId As String = ""
    Dim dtGoodType As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal pTypeId As String, ByVal pName As String, ByVal gTypeId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        goodsTypeId = gTypeId
        TB_Parent.Text = pName
        TB_Parent.Tag = pTypeId
        Me.Mode = Mode

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(Val(P_F_RS_ID), ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(Val(P_F_RS_ID), ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub T10002_GoodsType_Msg_Load() Handles Me.Me_Load
        FormCheckRight()

        Me_Refresh()

        If Mode = Mode_Enum.Add Then
            If CheckRight(Val(P_F_RS_ID), ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            TB_ID.Text = GoodsType_GetNewID(TB_Parent.Tag)
            '  TB_UPD_User.Text = PClass.PClass.User_Display
            '  TB_UPD_User.Tag = PClass.PClass.User_Id
        End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = GoodsType_GetById(goodsTypeId)
        If msg.IsOk Then
            dtGoodType = msg.Dt
            SetForm(msg.Dt)
        End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtGoodType.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("GoodsType_ID") = TB_ID.Text
            dr("GoodsType_Name") = TB_Name.Text
            dr("GoodsType_StartNo") = TB_StartNum.Text
            dr("GoodsType_Remark") = TB_Remark.Text
            dr("UPD_User") = PClass.PClass.User_Id
            dr("UPD_Date") = Today
            dr("GoodsType_Percent") = Val(TB_Percent.Text)
            dr("IsAssemble") = CK_IsAssemble.Checked
            dr("IsRaw") = CK_IsRaw.Checked
            dt.Rows.Add(dr)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("GoodsType_ID"), "")
            TB_ID.Tag = IsNull(dt.Rows(0)("GoodsType_ID"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("GoodsType_Name"), "")
            TB_StartNum.Text = IsNull(dt.Rows(0)("GoodsType_StartNo"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("GoodsType_Remark"), "")
            TB_Percent.Text = IsNull(dt.Rows(0)("GoodsType_Percent"), 1)
            TB_UPD_User.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            TB_UPD_User.Text = UserIDtoDisplayName(IsNull(dt.Rows(0)("UPD_User"), ""))
            CK_IsAssemble.Checked = dt.Rows(0)("IsAssemble")
            CK_IsRaw.Checked = dt.Rows(0)("IsRaw")
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_User.Value = dt.Rows(0)("UPD_DATE")
            End If

        End If

    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存商品分类 [" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        If Me.Mode = Mode_Enum.Add Then
            GoodsType_Add(GetForm())
        Else
            GoodsType_Save(TB_ID.Tag, GetForm())
        End If
        Me.Close()
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_Parent.Text = "" Then
            ShowErrMsg("上一层分类不能为空")
            TB_Parent.Focus()
            Return False
        End If

        If TB_ID.Text = "" Then
            ShowErrMsg("分类编号不能为空")
            TB_ID.Focus()
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowErrMsg("分类名称不能为空")
            TB_Name.Focus()
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除 [" & TB_Name.Text & "]?", AddressOf DelGoodsType)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoodsType()
        Dim msg As MsgReturn = GoodsType_Del(TB_ID.Text)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    Private Sub Btn_ChoseParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseParent.Click
        Dim F As New F10003_GoodsType_Sel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        If Me.TB_ID.Text.Length >= 5 Then


            F.GoodsTypeTree1.SetRootID(Me.TB_ID.Text.Substring(0, 5))
        End If
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetParent
        VF.Show()

    End Sub


    Protected Sub SetParent()
        If Not ReturnId = "" OrElse Not ReturnObj Is Nothing Then
            Me.TB_Parent.Text = Me.ReturnObj
            Me.TB_Parent.Tag = Me.ReturnId
            TB_ID.Tag = TB_ID.Text
            TB_ID.Text = GoodsType_GetNewID(TB_Parent.Tag)
        End If
    End Sub

#End Region



End Class
