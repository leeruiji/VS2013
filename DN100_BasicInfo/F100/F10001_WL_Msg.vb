Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass

Public Class F10001_WL_Msg
    Dim goodsTypeID As String = ""
    Dim goodsTypeName As String = ""
    Dim goodsName As String = ""
    Dim goodsId As Integer
    Dim WL_No As String
    Dim startNo As String = ""
    Dim dtGoods As DataTable
    Dim dtAssemble As DataTable
    Dim IsAssemble As Boolean = False
    Dim IsRaw As Boolean = False

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        'ID = 19999
        'Me.P_F_RS_ID = ID
        'GoodsTypeTree1.SetParent(Me)
        'GoodsTypeTree1.SetRootID(GoodsTypeTree.NODE_WL)
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

    Private Sub F10001_WL_Msg_AfterLoad() Handles Me.AfterLoad
        If CB_Unit.SelectedIndex = -1 Then
            CB_Unit.SelectedIndex = 0
        End If
        If CB_Unit_LL.SelectedIndex = -1 Then
            CB_Unit_LL.SelectedIndex = 0
        End If

    End Sub


    Private Sub Me_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso Fg1.Rows.Count < 2 Then
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
        ID = 10000
        Control_CheckRight(10000, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(10000, ClassMain.Del, Cmd_Del)
        Control_CheckRight(10000, ClassMain.SetInValid, Cmd_Disable)
        Control_CheckRight(10000, ClassMain.SetValid, Cmd_Enable)
        Control_CheckRight(10000, ClassMain.ReNew, Cmd_ReNew)
        If CheckRight(10000, ClassMain.ShowPrice) = False Then
            SplitContainer1.Panel2Collapsed = True
        Else
            SplitContainer1.Panel2Collapsed = False
        End If

        TB_Price.Visible = CheckRight(10000, ClassMain.CkPrice)
        Label4.Visible = CheckRight(10000, ClassMain.CkPrice)

        Label6.Visible = CheckRight(10000, ClassMain.WL_DownQty)
        TB_DownQty.Visible = CheckRight(10000, ClassMain.WL_DownQty)

        'Label24.Visible = CheckRight(10000, ClassMain.WL_Qty)
        'TB_Qty.Visible = CheckRight(10000, ClassMain.WL_Qty)

    End Sub



    Private Sub FormLoad() Handles Me.Me_Load
        FormCheckRight()
        ' Supplier_List1.Set_TextBox(TB_Supplier, CB_Unit_LL)
        '  GetSupplierList()
        Me_Refresh()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(10000, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                Dim msg As DtReturnMsg = GoodsType_GetById(Me.goodsTypeID)
                If msg.IsOk Then
                    IsAssemble = msg.Dt.Rows(0)("IsAssemble")
                    IsRaw = msg.Dt.Rows(0)("IsRaw")
                    If IsAssemble Then
                        Dim dt_list As DtReturnMsg = WL_AssembleGetByWL_No("")
                        dtAssemble = dt_list.Dt
                        Fg1.DtToSetFG(dtAssemble)
                        dtAssemble.AcceptChanges()
                    End If
                End If
                Dim dt_table As DtReturnMsg = WL_GetById(0)
                If dt_table.IsOk Then
                    dtGoods = dt_table.Dt
                End If
                Cmd_Del.Visible = False
            Case Mode_Enum.Modify
                Dim dt_table As DtReturnMsg = WL_GetById(goodsId)
                If dt_table.IsOk Then
                    IsAssemble = dt_table.Dt.Rows(0)("IsAssemble")
                    IsRaw = dt_table.Dt.Rows(0)("IsRaw")
                    Dim WL_No As String = dt_table.Dt.Rows(0)("WL_No")
                    If IsAssemble Then
                        Dim dt_list As DtReturnMsg = WL_AssembleGetByWL_No(WL_No)
                        dtAssemble = dt_list.Dt
                        Fg1.DtToSetFG(dtAssemble)
                        dtAssemble.AcceptChanges()

                    End If
                    dtGoods = dt_table.Dt
                End If
        End Select
        If IsAssemble Then
            GB_Assemble.Visible = IsAssemble
            GB_Material.Visible = IsRaw
            LB_Coat.Visible = IsRaw
            TB_Coat.Visible = IsRaw
            LB_Inner.Visible = IsRaw
            TB_Inner.Visible = IsRaw
            Cmd_AddRow.Visible = IsAssemble
            Cmd_RemoveRow.Visible = IsAssemble
        Else
            GB_Assemble.Visible = IsAssemble
            Cmd_AddRow.Visible = IsAssemble
            Cmd_RemoveRow.Visible = IsAssemble
            GB_Material.Visible = Not IsRaw
            LB_Coat.Visible = Not IsRaw
            TB_Coat.Visible = Not IsRaw
            LB_Inner.Visible = Not IsRaw
            TB_Inner.Visible = Not IsRaw
        End If
        dtGoods.AcceptChanges()
        SetForm(dtGoods)
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
            dt.Rows(0)("WL_Name") = CB_Name.Text
            dt.Rows(0)("WL_Product") = TB_Product.Text
            dt.Rows(0)("WL_FindHelper") = StrGetPinYin(CB_Name.Text)
            'If Not CB_Store.SelectedValue Is Nothing Then
            '    dt.Rows(0)("WL_StoreID") = CB_Store.SelectedValue
            'End If
            dt.Rows(0)("WL_Unit") = CB_Unit.Text
            dt.Rows(0)("WL_Unit_LL") = CB_Unit_LL.Text
            'If Not CB_Supplier.SelectedValue Is Nothing Then
            dt.Rows(0)("WL_Supplier") = Val(CB_Supplier.IDValue)
            'End If
            dt.Rows(0)("WL_Spec") = TB_Spec.Text
            dt.Rows(0)("WL_Center") = TB_Center.Text
            dt.Rows(0)("WL_side") = TB_side.Text
            dt.Rows(0)("WL_material") = TB_material.Text.ToUpper
            dt.Rows(0)("WL_Remark") = TB_Remark.Text
            dt.Rows(0)("IsZJ") = CB_IsZJ.Checked
            dt.Rows(0)("IsEP") = CB_IsEP.Checked
            dt.Rows(0)("IsSGL") = CB_IsSGL.Checked
            '   dt.Rows(0)("WL_Thick") = Val(TB_Thick.Text)
            '   dt.Rows(0)("WL_Cost") = Val(TB_Cost.Text)
            '  dt.Rows(0)("WL_Price") = Val(TB_Price.Text)
            If Mode = Mode_Enum.Add Then
                dt.Rows(0)("Founder") = User_Display
                dt.Rows(0)("Found_Date") = GetDate()
            End If
            dt.Rows(0)("UPD_USER") = PClass.PClass.User_Id
            dt.Rows(0)("UPD_DATE") = Today
            dt.Rows(0)("WL_Cost") = Val(TB_Cost.Text)
            dt.Rows(0)("WL_Price") = Val(TB_Price.Text)
            dt.Rows(0)("WL_DownQty") = Val(TB_DownQty.Text)
            If Not IsRaw Then
                dt.Rows(0)("RWL_No") = TB_RID.Text
                dt.Rows(0)("RWL_Spec") = TB_RSpec.Text
                dt.Rows(0)("WL_Inner") = TB_Inner.Text
                dt.Rows(0)("WL_Coat") = TB_Coat.Text
            End If
        End If

        If IsAssemble Then
            dtAssemble = dtAssemble.Clone
            Dim drAssemble As DataRow = dt.Rows(0)
            For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
                Try
                    If IsNull(Fg1.Item(i, "Assemble_No"), "") = "" OrElse Val(IsNull(Fg1.Item(i, "Assemble_Amount"), "")) = 0 Then
                        Fg1.RemoveItem(i)
                    End If
                Catch ex As Exception
                End Try
            Next
            For i As Integer = 1 To Fg1.Rows.Count - 1
                drAssemble = dtAssemble.NewRow
                drAssemble("WL_No") = TB_ID.Text
                drAssemble("Assemble_No") = Fg1.Item(i, "Assemble_No")
                drAssemble("Assemble_Amount") = Val(Fg1.Item(i, "Assemble_Amount"))
                dtAssemble.Rows.Add(drAssemble)
            Next
            dtAssemble.AcceptChanges()
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            If Not IsRaw Then
                TB_RID.Text = IsNull(dt.Rows(0)("RWL_No"), "")
                TB_RSpec.Text = IsNull(dt.Rows(0)("RWL_Spec"), "")
                TB_Coat.Text = IsNull(dt.Rows(0)("WL_Coat"), "")
                TB_Inner.Text = IsNull(dt.Rows(0)("WL_Inner"), "")
            End If
            TB_GoodsType.Text = IsNull(dt.Rows(0)("GoodsType_Name"), "")
            TB_GoodsType.Tag = IsNull(dt.Rows(0)("WL_Type_ID"), "")
            TB_ID.Text = IsNull(dt.Rows(0)("WL_No"), "")
            CB_Name.Text = IsNull(dt.Rows(0)("WL_Name"), "")
            TB_Product.Text = IsNull(dt.Rows(0)("WL_Product"), "")
            ''If Not dt.Rows(0)("WL_Store_ID") Is DBNull.Value Then
            ''    CB_Store.SelectedValue = dt.Rows(0)("WL_StoreID")
            ''End If
            CB_Unit.Text = IsNull(dt.Rows(0)("WL_Unit"), "")
            CB_Unit_LL.Text = IsNull(dt.Rows(0)("WL_Unit_LL"), "")
            'If Not dt.Rows(0)("WL_Supplier") Is DBNull.Value Then
            '    CB_Supplier.SelectedValue = dt.Rows(0)("WL_Supplier")
            'End If
            TB_Spec.Text = IsNull(dt.Rows(0)("WL_Spec"), "")
            TB_material.Text = IsNull(dt.Rows(0)("WL_material"), "")
            TB_side.Text = IsNull(dt.Rows(0)("WL_side"), "")
            TB_Center.Text = IsNull(dt.Rows(0)("WL_Center"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("WL_Remark"), "")
            TB_Coat.Text = IsNull(dt.Rows(0)("WL_Coat"), "")
            TB_Inner.Text = IsNull(dt.Rows(0)("WL_Inner"), "")

            TB_Qty.Text = Format(IsNull(dt.Rows(0)("WL_Qty"), 0), FormatSharp("num"))
            TB_Cost.Text = Format(IsNull(dt.Rows(0)("WL_Cost"), 0), FormatSharp("price"))
            TB_Price.Text = Format(IsNull(dt.Rows(0)("WL_Price"), 0), FormatSharp("price"))
            TB_DownQty.Text = Format(IsNull(dt.Rows(0)("WL_DownQty"), 0), FormatSharp("num"))
            CB_IsZJ.Checked = IsNull(dt.Rows(0)("IsZJ"), False)
            CB_IsEP.Checked = IsNull(dt.Rows(0)("IsEP"), False)
            CB_IsSGL.Checked = IsNull(dt.Rows(0)("IsSGL"), False)

            CB_Supplier.IDValue = IsNull(dt.Rows(0)("WL_Supplier"), 0)
            CB_Supplier.Text = CB_Supplier.GetByTextBoxTag
            If IsNull(dt.Rows(0)("WL_NewID"), 0) <> 0 Then
                LabelChange.Text = "本化工材料已经被替换了,双击这里显示被替换的化工材料!"
                LabelChange.Tag = dt.Rows(0)("WL_NewID")
                LabelChange.Visible = True
                Cmd_ReNew.Visible = False
            Else
                LabelChange.Text = ""
                LabelChange.Tag = 0
                LabelChange.Visible = False
                Cmd_ReNew.Visible = True
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
            'TB_ID.Text = ""
            TB_ID.Text = WL_GetNewID(startNo)
            CB_Name.Text = ""
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


#Region "FG 事件"

    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click
        If Fg1.CanEditing = False Then Exit Sub
        If Fg1.Editor Is Nothing Then
            If Fg1.RowSel < 0 Then
                Exit Sub
            End If
            If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
                Fg1.LastKey = 0
                Fg1.StartEditing()
            End If
        End If
    End Sub
    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Row <= 0 Then
            Exit Sub
        End If
        Try

            If Fg1.LastKey = Keys.Enter Then
                Fg1.LastKey = 0
                Select Case Fg1.Cols(e.Col).Name
                    Case "Assemble_No"
                        GetWLByNo(Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index))
                    Case Else
                        Fg1.GotoNextCell(e.Col)
                End Select
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "Assemble_No"
                e.ToCol = Fg1.Cols("Assemble_Amount").Index
            Case "Assemble_Amount"
                If e.Row + 2 > Fg1.Rows.Count Then
                    Fg1.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("Assemble_No").Index
        End Select
    End Sub



    Private Sub Fg1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Enter
        'If Fg1.RowSel < 0 Then
        '    Exit Sub
        'End If
        'If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
        '    Fg1.LastKey = 0
        '    Fg1.StartEditing()
        'End If
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.EnterCell
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        'If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
        '    Fg1.LastKey = 0
        '    Fg1.StartEditing()
        'End If
        ShowGoodsSelCmd()
    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing = False Then
            If e.KeyCode = Keys.Enter Then
                If Fg1.ColSel < Fg1.Cols("Assemble_Amount").Index Then
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Assemble_Amount").Index)
                End If
            ElseIf e.KeyCode = Keys.Add AndAlso Fg1.Cols(Fg1.ColSel).Name = "Assemble_No" Then
                ShowGoodsSel()
            End If
        End If
    End Sub

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles Fg1.KeyDownEdit
        If e.KeyCode = Keys.Add AndAlso Fg1.Cols("Assemble_No").Index = e.Col AndAlso Fg1.CanEditing Then
            ShowGoodsSel()
        End If
    End Sub

#End Region

#Region "物料选择"
    Dim gType As String = ""
    Protected Sub ShowGoodsSelCmd()
        If Fg1.ColSel > 0 AndAlso Fg1.RowSel > 0 Then
            If Fg1.CanEditing Then
                Dim C As C1.Win.C1FlexGrid.Column = Fg1.Cols(Fg1.ColSel)
                Dim R As C1.Win.C1FlexGrid.Row = Fg1.Rows(Fg1.RowSel)
                Select Case Fg1.Cols(Fg1.ColSel).Name
                    Case "Assemble_No"
                        Cmd_GoodsSel.Left = Fg1.Left + C.Left + C.WidthDisplay - Cmd_GoodsSel.Width + Fg1.ScrollPosition.X + 1
                        Cmd_GoodsSel.Top = Fg1.Top + R.Top + Fg1.ScrollPosition.Y + 1
                        Cmd_GoodsSel.Height = R.HeightDisplay
                        Cmd_GoodsSel.Visible = True
                    Case Else
                        Cmd_GoodsSel.Visible = False
                End Select
            Else
                Cmd_GoodsSel.Visible = False
            End If
        Else
            Cmd_GoodsSel.Visible = False
        End If
    End Sub

    Private Sub Cmd_GoodsSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GoodsSel.Click
        ShowGoodsSel()
    End Sub
    Protected Sub ShowGoodsSel(Optional ByVal _no As String = "")
        If _no Is Nothing Then _no = ""
        If _no = "" Then _no = Fg1.Item(Fg1.RowSel, "Assemble_No")
        Dim F As BaseForm = LoadFormIDToChild(10004, Me)
        If F Is Nothing Then Exit Sub
        Fg1.RowSel = Fg1.RowSel
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = _no
            .P_F_RS_ID4 = gType
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoods
        VF.Show()
    End Sub

    Protected Sub SetGoods()
        If Not Me.ReturnObj Is Nothing AndAlso Fg1.CanEditing AndAlso Fg1.RowSel > 0 Then
            Dim dr As DataRow = ReturnObj
            Fg1.FinishEditing(True)
            Fg1.Item(Fg1.RowSel, "Assemble_No") = IsNull(dr("WL_No"), "")
            Fg1.GotoNextCell("Assemble_No")
        Else
            Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Assemble_No").Index)
        End If
        Me.ReturnObj = Nothing
    End Sub

    Protected Sub GetWLByNo(ByVal _No As String)
        Dim msg As DtReturnMsg = ComFun.WL_GetByNo(_No)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
            Me.ReturnObj = msg.Dt.Rows(0)
            SetGoods()
        Else
            ShowGoodsSel(_No)
        End If

    End Sub
#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存材料[" & CB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save(Optional ByVal Disable As Boolean = False)
        Dim r As MsgReturn
        Dim Dt As DataTable = GetForm()
        Dt.Rows(0).Item("WL_Disable") = Disable
        If Me.Mode = Mode_Enum.Add Then
            r = WL_Add(Dt, dtAssemble, IsAssemble)
        Else
            r = WL_Save(Dt, dtAssemble, IsAssemble)
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

        'If TB_GoodsType.Text = "" Then
        '    ShowErrMsg("材料分类不能为空")
        '    TB_GoodsType.Focus()
        '    Return False
        'Else
        'If Me.goodsTypeID = "GT001001" Then
        '    If CB_Name.Text = "" Then
        '        ShowErrMsg("材料名称不能为空！")
        '        CB_Name.Focus()
        '        Return False
        '    End If
        '    If CB_Supplier.Text = "" Then
        '        ShowErrMsg("供应商不能为空！")
        '        CB_Supplier.Focus()
        '        Return False
        '    End If
        '    Return True
        'Else
        If CB_Name.Text = "" Then
            ShowErrMsg("材料名称不能为空！")
            CB_Name.Focus()
            Return False
        End If
        If CB_Supplier.Text = "" Then
            ShowErrMsg("供应商不能为空！")
            CB_Supplier.Focus()
            Return False
        End If
        If TB_Spec.Text = "" Then
            ShowErrMsg("规格不能为空！")
            TB_Spec.Focus()
            Return False
        End If
        If TB_material.Text = "" Then
            ShowErrMsg("材质不能为空！")
            TB_material.Focus()
            Return False
        End If

        If Me.goodsTypeID <> "GT001002" AndAlso GB_Assemble.Visible = False Then
            If TB_Center.Text = "" Then
                ShowErrMsg("中心不能为空！")
                TB_Center.Focus()
                Return False
            End If
            If TB_side.Text = "" Then
                ShowErrMsg("边不能为空！")
                TB_side.Focus()
                Return False
            End If
        End If

        '检查毛坯料
        If GB_Material.Visible Then
            If TB_RID.Text = "" Then
                ShowErrMsg("毛坯料编号不能为空!")
                TB_RID.Focus()
                Return False
            Else
                If CheckRaw(TB_RID.Text) = False Then
                    ShowErrMsg("所选物料不属于毛坯料，请重新选择毛坯料！")
                    TB_RID.Focus()
                    Return False
                End If
            End If
        End If

        '检查组装件
        If GB_Assemble.Visible Then
            If Fg1.Rows.Count > 1 Then
                For i As Integer = 1 To Fg1.Rows.Count - 1
                    If CheckAssemble(Fg1.Item(i, "Assemble_No")) = False Then
                        ShowErrMsg("物料" & Fg1.Item(i, "Assemble_No") & "不能作为装配组件使用！")
                        Return False
                    End If
                Next
            Else
                ShowErrMsg("请填写装配组件！")
                Return False
            End If
        End If

        Return True
        'End If
        'If TB_ID.Text = "" Then
        '    ShowErrMsg("材料编号不能为空")
        '    TB_ID.Focus()
        '    Return False
        'End If


    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除化工材料[" & TB_ID.Text & "]?", AddressOf DelGoods)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()
        Dim msg As MsgReturn = WL_Del(goodsId)
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
        Dim F As New F10003_GoodsType_Sel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = 10000
            .P_F_RS_ID2 = ""
        End With
        F.GoodsTypeTree1.SetParent(Me)
        F.GoodsTypeTree1.SetRootID(GoodsTypeTree.NODE_WL)
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
                TB_ID.Text = WL_GetNewID(ReturnMsg)
                CB_Name.Focus()
            End If

        End If
    End Sub



    Private Sub Cmd_Enable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Enable.Click
        Dim msg As MsgReturn = WL_Endable(goodsId)

        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
        Me_Refresh()
    End Sub

    Private Sub Cmd_Disable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Disable.Click
        If CheckForm() Then ShowConfirm("是否禁用材料[" & CB_Name.Text & "]?", AddressOf WL_Disable)
    End Sub


    Sub WL_Disable()
        Save(True)
    End Sub
#End Region
#Region "双击获取新编号"
    Private Sub Label_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If Mode = Mode_Enum.Add Then
            TB_ID.Text = WL_GetNewID(startNo)
            CB_Name.Focus()
        End If
    End Sub
#End Region

    Private Sub Cmd_ReNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ReNew.Click
        Me.goodsTypeName = TB_GoodsType.Text
        Me.goodsName = CB_Name.Text
        Me.WL_No = TB_ID.Text
        Form_WL_View(Me.goodsTypeID, Me.goodsTypeName, Me.WL_No, Me.goodsName)
        'ShowConfirm("是否把[" & TB_Name.Text & "]更改新化工材料?   ", AddressOf ReNew)
    End Sub

    Protected Sub Form_WL_View(ByVal TypeID As String, ByVal TypeName As String, ByVal WL_No As String, ByVal goodsName As String)
        Dim WL_TypeID As String = TypeID
        Dim WL_TypeName As String = TypeName
        Dim WL_ID As String = WL_No
        Dim WL_Name As String = goodsName
        Dim F As New ChooseReNew_WL(WL_TypeID, WL_TypeName, WL_ID, WL_Name)
        F.ShowDialog()

    End Sub



    Sub ReNew()
        Dim R As MsgReturn = WL_ReNew(goodsId, WL_GetNewID(startNo))
        If R.IsOk = True Then

            goodsId = R.Msg
            ShowOk("更改成功!")
            Me_Refresh()

        Else
            ShowErrMsg("更改失败!")
        End If
    End Sub

    Private Sub LabelChange_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelChange.Click
        If LabelChange.Tag <> 0 Then
            Dim F As New F10001_WL_Msg(LabelChange.Tag)
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

    Private Sub Btn_CMaterial_Click(sender As Object, e As EventArgs) Handles Btn_CMaterial.Click
        Dim F As BaseForm = LoadFormIDToChild(10004, Me)
        If F Is Nothing Then Exit Sub
        Fg1.RowSel = Fg1.RowSel
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = gType
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetRaw
        VF.Show()
    End Sub

    Protected Sub SetRaw()
        If Not Me.ReturnObj Is Nothing Then
            Dim dr As DataRow = ReturnObj
            TB_RID.Text = IsNull(dr("WL_No"), "")
            TB_RSpec.Text = IsNull(dr("WL_Spec"), "")
        End If
        Me.ReturnObj = Nothing
    End Sub

    Private Sub Cmd_AddRow_Click(sender As Object, e As EventArgs) Handles Cmd_AddRow.Click
        Fg1.AddRow()
    End Sub

    Private Sub Cmd_RemoveRow_Click(sender As Object, e As EventArgs) Handles Cmd_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub

    ''' <summary>
    ''' 判断录入的是否是毛坯料
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckRaw(ByVal RWL_No As String) As Boolean
        Dim Re As Boolean = False
        Dim msg As DtReturnMsg = WL_RawGetByWL_No(RWL_No)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso msg.Dt.Rows(0)("IsRaw") Then
            Re = True
        End If
        Return Re
    End Function

    ''' <summary>
    ''' 判断录入的是否是组装件
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckAssemble(ByVal Assemble_No As String) As Boolean
        Dim Re As Boolean = False
        Dim msg As DtReturnMsg = AssembleGetByWL_No(Assemble_No)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso ((msg.Dt.Rows(0)("IsRaw") = False AndAlso msg.Dt.Rows(0)("IsAssemble") = False) OrElse msg.Dt.Rows(0)("IsHardware") = True) Then
            Re = True
        End If
        Return Re
    End Function
End Class
