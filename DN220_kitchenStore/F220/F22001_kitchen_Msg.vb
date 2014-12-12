Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F22001_kitchen_Msg
    Dim goodsTypeID As String = ""
    Dim goodsTypeName As String = ""
    Dim goodsId As Integer
    Dim startNo As String = ""
    Dim dtGoods As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal goodsTypeID As String, ByVal goodsTypeName As String, ByVal startNo As String, ByVal goodsID As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.goodsTypeID = goodsTypeID
        Me.goodsTypeName = goodsTypeName
        Me.startNo = startNo
        Me.goodsId = goodsID
        Me.Mode = Mode

    End Sub

    Public Sub New(ByVal goodsID As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.goodsId = goodsID
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub F22001_Metal_Msg_AfterLoad() Handles Me.AfterLoad
        If CB_Unit.SelectedIndex = -1 Then
            CB_Unit.SelectedIndex = 0
        End If


    End Sub


    Private Sub Me_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 22000
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_Disable)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_Enable)
        'Control_CheckRight(ID, ClassMain.ReNew, Cmd_ReNew)
        If CheckRight(ID, ClassMain.ShowPrice) = False Then
            SplitContainer1.Panel2Collapsed = True
        Else
            SplitContainer1.Panel2Collapsed = False
        End If
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load
        FormCheckRight()

        ' Supplier_List1.Set_TextBox(TB_Supplier, CB_Unit_LL)
        '  GetSupplierList()
        Me_Refresh()

        If Mode = Mode_Enum.Add Then
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            goodsId = 0
            'Dim msg As DtReturnMsg = Dao.GoodsType_GetById(Me.goodsTypeID)
            'If msg.IsOk Then
            '    TB_Percent.Text = IsNull(msg.Dt.Rows(0)("GoodsType_Percent"), 1)
            'End If
            TB_ID.Text = Dao.WL_GetNewID(startNo)

            Cmd_Del.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.WL_GetById(goodsId)
        If msg.IsOk Then
            dtGoods = msg.Dt
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
        dt = dtGoods.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
            If Mode <> Mode_Enum.Add Then dt.Rows(0)("ID") = goodsId
            dt.Rows(0)("WL_Type_ID") = TB_GoodsType.Tag
            dt.Rows(0)("WL_No") = TB_ID.Text
            dt.Rows(0)("WL_Name") = TB_Name.Text.Trim
            dt.Rows(0)("WL_FindHelper") = StrGetPinYin(TB_Name.Text)
            'If Not CB_Store.SelectedValue Is Nothing Then
            '    dt.Rows(0)("WL_StoreID") = CB_Store.SelectedValue
            'End If
            dt.Rows(0)("WL_Unit") = CB_Unit.Text.Trim

            'If Not CB_Supplier.SelectedValue Is Nothing Then
            '   dt.Rows(0)("WL_Supplier") = Val(CB_Supplier.IDValue)
            'End If
            dt.Rows(0)("WL_Spec") = TB_Spec.Text.Trim
            dt.Rows(0)("WL_Remark") = TB_Remark.Text
            'dt.Rows(0)("WL_Percent") = Val(TB_Percent.Text)
            'dt.Rows(0)("IsZJ") = CB_IsZJ.Checked
            'dt.Rows(0)("WL_Thick") = Val(TB_Thick.Text)
            'dt.Rows(0)("WL_Cost") = Val(TB_Cost.Text)
            ' dt.Rows(0)("WL_Price") = Val(TB_Price.Text)
            If Mode = Mode_Enum.Add Then
                dt.Rows(0)("Founder") = User_Display
                dt.Rows(0)("Found_Date") = GetDate()
            End If
            dt.Rows(0)("UPD_USER") = PClass.PClass.User_Id
            dt.Rows(0)("UPD_DATE") = Today
            dt.Rows(0)("WL_Cost") = Val(TB_Cost.Text.Trim)
            dt.Rows(0)("WL_Price") = Val(TB_Price.Text.Trim)
            dt.Rows(0)("WL_Price") = Val(TB_Price.Text.Trim)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_GoodsType.Text = IsNull(dt.Rows(0)("GoodsType_Name"), "")
            TB_GoodsType.Tag = IsNull(dt.Rows(0)("WL_Type_ID"), "")
            TB_ID.Text = IsNull(dt.Rows(0)("WL_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("WL_Name"), "")
            ''If Not dt.Rows(0)("WL_Store_ID") Is DBNull.Value Then
            ''    CB_Store.SelectedValue = dt.Rows(0)("WL_StoreID")
            ''End If
            CB_Unit.Text = IsNull(dt.Rows(0)("WL_Unit"), "")

            'If Not dt.Rows(0)("WL_Supplier") Is DBNull.Value Then
            '    CB_Supplier.SelectedValue = dt.Rows(0)("WL_Supplier")
            'End If
            TB_Spec.Text = IsNull(dt.Rows(0)("WL_Spec"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("WL_Remark"), "")
            '   TB_Percent.Text = IsNull(dt.Rows(0)("WL_Percent"), "")

            TB_Qty.Text = Format(IsNull(dt.Rows(0)("WL_Qty"), 0), FormatSharp("num"))
            TB_Cost.Text = Format(IsNull(dt.Rows(0)("WL_Cost"), 0), FormatSharp("price"))
            TB_Price.Text = Format(IsNull(dt.Rows(0)("WL_Price"), 0), FormatSharp("price"))

            '   CB_IsZJ.Checked = IsNull(dt.Rows(0)("IsZJ"), False)


            '  CB_Supplier.IDValue = IsNull(dt.Rows(0)("WL_Supplier"), 0)
            '   CB_Supplier.Text = CB_Supplier.GetByTextBoxTag
            If IsNull(dt.Rows(0)("WL_NewID"), 0) <> 0 Then
                LabelChange.Text = "本物料已经被替换了,双击这里显示被替换的物料!"
                LabelChange.Tag = dt.Rows(0)("WL_NewID")
                LabelChange.Visible = True
                'Cmd_ReNew.Visible = False
            Else
                LabelChange.Text = ""
                LabelChange.Tag = 0
                LabelChange.Visible = False
                'Cmd_ReNew.Visible = True
            End If



            If IsNull(dt.Rows(0)("WL_Disable"), False) Then
                Label_State.Text = "禁用"
                Label_State.ForeColor = Color.Red
                Cmd_Del.Visible = Cmd_Del.Tag
                Cmd_Enable.Visible = Cmd_Enable.Tag
                Cmd_Disable.Visible = False
                Cmd_Modify.Visible = False
                PanelMain.Enabled = False
            Else
                Label_State.Text = "启用"
                Cmd_Del.Visible = False
                Label_State.ForeColor = Color.Blue
                Cmd_Enable.Visible = False
                Cmd_Disable.Visible = Cmd_Disable.Tag
                Cmd_Modify.Visible = Cmd_Modify.Tag
                PanelMain.Enabled = True
            End If



        Else
            TB_GoodsType.Text = Me.goodsTypeName
            TB_GoodsType.Tag = Me.goodsTypeID
            TB_ID.Text = ""
            TB_Name.Text = ""
            Label_State.Text = "启用"
            Label_State.ForeColor = Color.Blue
            Cmd_Enable.Visible = False
            Cmd_Disable.Visible = False
        End If
        If Val(TB_Qty.Text) = 0 Then
            TB_Qty.Text = 0
            TB_Cost.ReadOnly = False
        End If
    End Sub




#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存物料[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save(Optional ByVal Disable As Boolean = False)
        Dim r As MsgReturn
        Dim Dt As DataTable = GetForm()
        Dt.Rows(0).Item("WL_Disable") = Disable
        If Me.Mode = Mode_Enum.Add Then
            r = Dao.WL_Add(Dt)
        Else
            r = Dao.WL_Save(Dt)
        End If
        If Disable Then
            r.Msg = r.Msg.Replace("保存", "禁用")
        End If
        If r.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            LastForm.ReturnObj = Dt
            If goodsId = 0 Then
                ShowConfirm(r.Msg & "是否继续添加?", AddressOf Me_Refresh, AddressOf Me.Close)
            Else
                ShowConfirm(r.Msg & "是否继续关闭窗口?", AddressOf Me.Close, AddressOf Me_Refresh)
            End If
        Else
            ShowErrMsg(r.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_GoodsType.Text = "" Then
            ShowErrMsg("物料分类不能为空")
            TB_GoodsType.Focus()
            Return False
        End If
        If TB_ID.Text = "" Then
            ShowErrMsg("物料编号不能为空")
            TB_ID.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("物料名称不能为空")
            TB_Name.Focus()
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除物料[" & TB_ID.Text & "]?", AddressOf DelGoods)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()
        Dim msg As MsgReturn = Dao.WL_Del(goodsId)
        If msg.IsOk Then
            LastForm.ReturnId = "0"
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Btn_ChoseParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseParent.Click
        Dim F As New F22010_GoodsType_Sel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = 10000
            .P_F_RS_ID2 = ""
        End With
        F.GoodsTypeTree1.SetParent(Me)
        F.GoodsTypeTree1.SetRootID(GoodsTypeTree.NODE_kitchen)
        F_RS_ID = 10000
        Me.ReturnId = ""
        Me.ReturnMsg = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetParent
        VF.Show()
    End Sub


    Protected Sub SetParent()
        If Not ReturnId = "" OrElse Not ReturnObj Is Nothing Then
            Me.TB_GoodsType.Text = Me.ReturnObj
            Me.TB_GoodsType.Tag = Me.ReturnId
            If Me.Mode = Mode_Enum.Add Then
                TB_ID.Text = Dao.WL_GetNewID(ReturnMsg)
                TB_Name.Focus()
            End If

        End If
    End Sub



    Private Sub Cmd_Enable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Enable.Click
        Dim msg As MsgReturn = Dao.WL_Endable(goodsId)

        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
        Me_Refresh()
    End Sub

    Private Sub Cmd_Disable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Disable.Click
        If CheckForm() Then ShowConfirm("是否禁用物料[" & TB_Name.Text & "]?", AddressOf WL_Disable)
    End Sub


    Sub WL_Disable()
        Save(True)
    End Sub
#End Region
#Region "双击获取新编号"
    Private Sub Label_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If Mode = Mode_Enum.Add Then
            TB_ID.Text = Dao.WL_GetNewID(startNo)
            TB_Name.Focus()
        End If
    End Sub
#End Region

    Private Sub Cmd_ReNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowConfirm("是否把[" & TB_Name.Text & "]更改新物料?   ", AddressOf ReNew)
    End Sub


    Sub ReNew()
        Dim R As DtReturnMsg = Dao.WL_ReNew(goodsId, Dao.WL_GetNewID(startNo))
        If R.IsOk = True AndAlso R.Dt.Rows.Count > 0 Then
            If R.Dt.Rows(0)(1) = 1 Then
                goodsId = R.Dt.Rows(0)(0)
                ShowOk("更改成功!")
                Me_Refresh()
            Else
                ShowErrMsg(R.Dt.Rows(0)(2).ToString.Replace("%Name%", TB_Name.Text))
            End If
        Else
            ShowErrMsg("更改失败!")
        End If
    End Sub

    Private Sub LabelChange_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelChange.Click
        If LabelChange.Tag <> 0 Then
            Dim F As New F22001_kitchen_Msg(LabelChange.Tag)
            With F
                .Mode = Mode_Enum.Modify
                .P_F_RS_ID = 10000
                .P_F_RS_ID2 = ""
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            AddHandler VF.ClosedX, AddressOf Me.Close
            VF.Show()
        End If

    End Sub
End Class
