Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass

Public Class F25001_Produce_Msg
    Dim ProduceID As String = ""
    Dim dtList As DataTable
    Dim dtTable As DataTable

    Dim Dt_Supplier As DataTable
    Dim emp As BaseClass.Emplyee

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        ProduceID = initID
        Me.Mode = Mode
    End Sub

    Private Sub F20001_Produce_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name Then
                    SendKeys.SendWait("{TAB}")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub



    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Dim ID As Integer = 25000
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub


    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = "生产单"
        Fg1.IniFormat()

        emp = BaseClass.Emplyee.GetInstance
        CB_ChuNa.DataSource = Emplyee.GetAllEmployee.Copy
        CB_FuHe.DataSource = Emplyee.GetAllEmployee.Copy
        CB_JiZhang.DataSource = Emplyee.GetAllEmployee.Copy
        CB_KuaiJi.DataSource = Emplyee.GetAllEmployee.Copy
        CB_YanShou.DataSource = Emplyee.GetAllEmployee.Copy
        CB_Operator.DataSource = Emplyee.GetAllEmployee.Copy
        Dt_Supplier = BaseClass.ClientSupplier.GetAllSupplier
        Me_Refresh()
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                GetNewID()
                CB_Operator.SelectedValue = PClass.PClass.User_Id
                CB_Operator.SelectedText = PClass.PClass.User_Name
                CB_ChuNa.SelectedIndex = -1
                CB_FuHe.SelectedIndex = -1
                CB_JiZhang.SelectedIndex = -1
                CB_YanShou.SelectedIndex = -1
                CB_KuaiJi.SelectedIndex = -1
                LabelTitle.Text = "新建" & Me.Ch_Name
            Case Mode_Enum.Modify
                TB_ID.ReadOnly = True
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select
        Fg1.RowSel = 1
        Dim T As New Threading.Thread(AddressOf Get_ComboxList)
        T.Start()

    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Produce_GetById(ProduceID)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            SetForm(msgTable.Dt)
        End If
        Dim msg As DtReturnMsg = Produce_GetListById(ProduceID)
        If msg.IsOk Then
            dtList = msg.Dt
            If dtList.Rows.Count > 0 Then
                Fg1.DtToFG(dtList)
            Else
                Fg1.DtToFG(dtList)
                AddRow()
            End If
        End If
        CaculateSumAmount()
    End Sub

#Region "表单信息"



    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtTable.Clone
        If Not dt Is Nothing AndAlso Not TB_ID.Text = "" Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("Produce_ID") = TB_ID.Text
            dr("Produce_Date") = DP_Date.Value.ToString("yyyy-MM-dd")
            dr("Project") = TB_Project.Text
            dr("SumProductQty") = TB_SumProductQty.Text
            dr("SumQty") = TB_SumQTY.Text

            dr("Operator") = CB_Operator.Text
            dr("JiZhang") = CB_JiZhang.Text
            dr("FuHe") = CB_FuHe.Text
            dr("ChuNa") = CB_ChuNa.Text
            dr("KuaiJi") = CB_KuaiJi.Text
            dr("YanShou") = CB_YanShou.Text
            dr("Remark") = TB_Remark.Text
            dt.Rows.Add(dr)
            For Each R As DataRow In dtList.Rows
                R.Item("Produce_id") = TB_ID.Text
            Next
        End If

        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If
        If dt.Rows.Count = 1 Then
            TB_ID.Text = IsNull(dt.Rows(0)("Produce_ID"), "")
            If Not dt.Rows(0)("Produce_Date") Is DBNull.Value Then
                DP_Date.Value = dt.Rows(0)("Produce_Date")
            End If
            TB_Project.Text = IsNull(dt.Rows(0)("Project"), "")

            TB_SumQTY.Text = FormatNum(IsNull(dt.Rows(0)("SumQty"), 0))
            TB_SumProductQty.Text = FormatNum(IsNull(dt.Rows(0)("SumProductQty"), 0))
            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
            CB_Operator.Tag = IsNull(dt.Rows(0)("Operator"), "")
            CB_Operator.Text = IsNull(dt.Rows(0)("Operator"), "")
            CB_JiZhang.Text = IsNull(dt.Rows(0)("JiZhang"), "")
            CB_FuHe.Text = IsNull(dt.Rows(0)("FuHe"), "")
            CB_ChuNa.Text = IsNull(dt.Rows(0)("ChuNa"), "")
            CB_KuaiJi.Text = IsNull(dt.Rows(0)("KuaiJi"), "")
            CB_YanShou.Text = IsNull(dt.Rows(0)("YanShou"), "")
        Else

        End If
    End Sub

    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        If Fg1.Rows.Count <= 1 Then
            Exit Sub
        End If



        Dim sunQty As Double = 0
        Dim SumProductQty As Double = 0
        Dim amount As Double = 0
        Dim qty As Double = 0
        Dim Product_qty As Double = 0
        Dim piece As Double = 0
        Dim Product_piece As Double = 0
        Dim Goods_Spec As Double = 0
        Dim Product_Spec As Double = 0
        Dim SP() As String

        For i As Integer = 1 To Fg1.Rows.Count - 1
            piece = Val(Fg1.Item(i, "piece"))
            If Fg1.Item(i, "Goods_Spec") Is Nothing Then
                Goods_Spec = 0
            Else
                Dim s As String = IsNull(Fg1.Item(i, "Goods_Spec"), "")
                SP = s.Split("×")
                If SP.Length = 2 Then
                    Goods_Spec = FormatNum(Val(SP(0)) * Val(SP(1)))
                Else
                    Goods_Spec = 0
                End If
            End If
            qty = FormatNum(Goods_Spec * piece)
            Fg1.Item(i, "QTY") = qty

            Product_piece = Val(Fg1.Item(i, "Product_piece"))
            If Fg1.Item(i, "Product_Spec") Is Nothing Then
                Product_Spec = 0
            Else
                Dim s As String = IsNull(Fg1.Item(i, "Product_Spec"), "")
                SP = s.Split("×")
                If SP.Length = 2 Then
                    Product_Spec = FormatNum(Val(SP(0)) * Val(SP(1)))
                Else
                    Product_Spec = 0
                End If
            End If
            Product_qty = FormatNum(Product_Spec * Product_piece)
            Fg1.Item(i, "Product_QTY") = FormatNum(Product_qty)
            Fg1.Item(i, "loss") = FormatNum(qty - Product_qty)
            sunQty = sunQty + qty
            SumProductQty = SumProductQty + Product_qty
        Next
        TB_SumProductQty.Text = FormatNum(SumProductQty)
        TB_SumQTY.Text = FormatNum(sunQty)
    End Sub

#End Region

#Region "表单事件"








    'Private Sub TB_NoteNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TB_NoteNo.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Fg1.Focus()
    '        If Fg1.Rows.Count < 1 Then
    '            AddRow()
    '        End If
    '        TB_Discount.Focus()
    '    End If
    'End Sub


#End Region

#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        Fg1.FinishEditing(True)
        If Mode = Mode_Enum.Add Then
            ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveProduce)
        Else
            ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveProduce)
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveProduce()
        If CheckForm() Then
            dtList.AcceptChanges()
            Dim R As DtListReturnMsg
            If Me.Mode = Mode_Enum.Add Then
                If ProduceID = TB_ID.Text Then GetNewID()
                R = Produce_Add(GetForm(), dtList)

            Else
                R = Produce_Save(GetForm(), dtList)
            End If
            If R.IsOk Then
                LastForm.ReturnId = TB_ID.Text
                ShowOk(R.Msg, True)
            Else
                ShowErrMsg(R.Msg)
            End If
        End If

    End Sub
    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        TB_ID.Text = TB_ID.Text.Trim
        If TB_ID.Text = "" Then
            TB_ID.Focus()
            ShowMsg(Ch_Name & "单号不能为空", Me.Title)
            Return False
        End If
        If TB_Project.Text = "'" Then
            TB_Project.Focus()
            ShowMsg("项目名称不能为空", Me.Title)
            Return False
        End If

        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Fg1.Item(i, "Goods_No") Is Nothing OrElse Fg1.Item(i, "Goods_No").ToString = "" Then
                    Fg1.Rows.Remove(i)
                End If
                If Fg1.Item(i, "Goods_Name") Is Nothing OrElse Fg1.Item(i, "Goods_Name").ToString = "" Then
                    Fg1.Rows.Remove(i)
                End If
                If Fg1.Item(i, "Qty") Is Nothing OrElse Val(Fg1.Item(i, "Qty")) = 0 Then
                    Fg1.Rows.Remove(i)
                End If
            Catch ex As Exception
            End Try
        Next
        If dtList.Rows.Count <= 0 Then
            Btn_GoodsSel.Visible = False
            ShowMsg("列表不能为空", Me.Title)
            Exit Function
        End If
        Return True
    End Function





    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelProduce)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelProduce()
        Dim msg As MsgReturn = Produce_Del(TB_ID.Text)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg, Me.Title)
        End If
    End Sub
    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddRow.Click
        AddRow()
    End Sub

    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow()
        Fg1.Rows.Add()
        Fg1.ReAddIndex()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Fg1.FinishEditing(True)
        Dim i As Integer = Fg1.RowSel
        If i > 0 AndAlso Fg1.Rows.Count > 1 Then
            Try
                Fg1.Rows.Remove(i)
            Catch ex As Exception
            End Try
            If Fg1.Rows.Count < 2 Then
                Btn_GoodsSel.Visible = False
            Else
                Fg1.ReAddIndex()
            End If
        End If
    End Sub
#End Region

#Region "FG 事件"

    Private Sub Fg1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Fg1.AfterScroll
        ShowGoodsSelBtn()
    End Sub

    Private Sub Fg1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg1.Click
        If Fg1.RowSel > 0 Then
            If Fg1.Cols("Goods_Name").Index = Fg1.ColSel Then
                ShowGoodsSel()
            End If
        End If
    End Sub
    Dim lastKey As Keys

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "Goods_No", "Goods_Unit", "Goods_Name"
                e.ToCol = Fg1.Cols("Batch_No").Index
            Case "Batch_No" '批号
                e.ToCol = Fg1.Cols("Goods_Thick").Index
            Case "Goods_Thick" '厚度
                e.ToCol = Fg1.Cols("Goods_Spec").Index
            Case "Goods_Spec" '规格
                e.ToCol = Fg1.Cols("piece").Index
            Case "piece" '切片数
                e.ToCol = Fg1.Cols("Product_Spec").Index
            Case "Product_Spec" '成品规格
                e.ToCol = Fg1.Cols("Product_piece").Index
            Case "Product_piece" '成品片数
                e.ToCol = Fg1.Cols("ListRemark").Index
            Case "ListRemark"
                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("Goods_No").Index
        End Select
    End Sub
    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Row < 0 Then
            Exit Sub
        End If
        If lastKey = Keys.Enter Then
            lastKey = 0
            Select Case Fg1.Cols(e.Col).Name
                Case "Goods_No"
                    If Fg2.RowSel > 0 Then
                        Fg1.Item(Fg1.RowSel, "Goods_No") = Fg2.Item(Fg2.RowSel, "Goods_No")
                    End If
                    SetGoodsByID(Fg1.Item(Fg1.RowSel, "Goods_No"))
                Case "Goods_Thick" '厚度
                    Dt_Goods_Thick_Add(Val(Fg1.Item(e.Row, e.Col)))
                    Fg1.GotoNextCell(e.Col)
                Case "Goods_Spec" '规格
                    Dim S As String = Check_Spec("规格", Fg1.Item(e.Row, e.Col), AddressOf FG1_Goods_Spec_Enter)
                    If S <> "" Then
                        Fg1.Item(e.Row, e.Col) = S
                        Fg1.GotoNextCell(e.Col)
                    End If
                Case "Product_Spec" '成品规格
                    Dim S As String = Check_Spec("成品规格", Fg1.Item(e.Row, e.Col), AddressOf FG1_Product_Spec_Enter)
                    If S <> "" Then
                        Fg1.Item(e.Row, e.Col) = S
                        Fg1.GotoNextCell(e.Col)
                    End If
                Case Else
                    Fg1.GotoNextCell(e.Col)
            End Select
        End If
        CaculateSumAmount()
    End Sub

    Function Check_Spec(ByVal Name As String, ByVal Spec As String, ByVal Handle As PClass.ConfirmBox.DeReturn) As String
        Dim s As String = Spec 'Fg1.Item(e.Row, e.Col)
        Dim SP() As String
        If s.IndexOf("×") = -1 Then
            If ListBox_Show.Items.Count > 0 Then
                s = ListBox_Show.SelectedValue
                SP = s.Split("×")
            Else
                ShowErrMsg(Name & "[" & s & "]格式不正确!应为数字×数字", Handle)
                Return ""
            End If
        Else
            SP = s.Split("×")
        End If
        If SP.Length <> 2 OrElse Val(SP(0)) = 0 OrElse Val(SP(1)) = 0 Then
            ShowErrMsg(Name & "[" & s & "]格式不正确!应为数字×数字", Handle)
            Return ""
        End If
        If Val(SP(0)) > 80 Then
            SP(0) = Format(Val(SP(0)) / 1000, "0.###")
        End If
        If Val(SP(1)) > 80 Then
            SP(1) = Format(Val(SP(1)) / 1000, "0.###")
        End If
        s = SP(0) & "×" & SP(1)
        Dt_Goods_Spec_Add(s)
        Return s
    End Function

    Sub FG1_Product_Spec_Enter()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Product_Spec").Index)
    End Sub
    Sub FG1_Goods_Spec_Enter()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Goods_Spec").Index)
    End Sub
    Sub FG1_Goods_No_Enter()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Goods_No").Index)
    End Sub

    Private Sub Fg1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Enter
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
            lastKey = 0
            Fg1.StartEditing()
        End If
        ShowGoodsSelBtn()
    End Sub

    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.EnterCell
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
            lastKey = 0
            Fg1.StartEditing()

        End If
        ShowGoodsSelBtn()
    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing = False Then
            If e.KeyCode = Keys.Enter Then
                If Fg1.ColSel < Fg1.Cols("Qty").Index Then
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Qty").Index)
                Else
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("ListRemark").Index)
                End If
            ElseIf e.KeyCode = Keys.Add AndAlso Fg1.Cols(Fg1.ColSel).Name = "Goods_No" Then
                ShowGoodsSel()
            End If
        End If
    End Sub

    Private Sub Fg1_KeyDownEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles Fg1.KeyDownEdit
        lastKey = e.KeyCode
        If lastKey = Keys.Add AndAlso Fg1.Cols("Goods_No").Index = e.Col AndAlso Fg1.CanEditing Then
            ShowGoodsSel()
        End If
        If (lastKey = Keys.Down OrElse lastKey = Keys.Up) AndAlso (Fg1.Cols("Goods_Spec").Index = e.Col OrElse Fg1.Cols("Product_Spec").Index = e.Col OrElse Fg1.Cols("Goods_Thick").Index = e.Col) AndAlso Fg1.CanEditing Then
            ListBox_KeyDown(lastKey)
            e.Handled = True
        End If
        If (lastKey = Keys.Down OrElse lastKey = Keys.Up) AndAlso (Fg1.Cols("Goods_No").Index = e.Col) AndAlso Fg1.CanEditing Then
            FG2_KeyDown(lastKey)
            e.Handled = True
        End If
    End Sub

    Private Sub Fg1_KeyPressEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyPressEditEventArgs) Handles Fg1.KeyPressEdit
        If (Fg1.Cols("Goods_Spec").Index = e.Col OrElse Fg1.Cols("Product_Spec").Index = e.Col) And e.Row > 0 Then
            TimerCombox.Start()
            Dim s As String
            Dim M As String = "0123456789." & Chr(8)
            If Fg1.Editor.Text Is Nothing Then
                s = ""
            Else
                s = Fg1.Editor.Text
            End If
            If s.ToString.IndexOf("×") >= 0 Then
                If M.IndexOf(e.KeyChar) = -1 Then
                    e.KeyChar = ""
                    e.Handled = True
                End If
            Else
                If s = "" Then
                    If M.IndexOf(e.KeyChar) = -1 Then
                        e.Handled = True
                    End If
                Else
                    If e.KeyChar <> "×" AndAlso M.IndexOf(e.KeyChar) = -1 Then
                        SendKeys.SendWait("×")
                        e.Handled = True
                    End If
                End If
            End If
        ElseIf Fg1.Cols("Goods_Thick").Index = e.Col And e.Row > 0 Then
            TimerCombox.Start()
        ElseIf Fg1.Cols("Goods_No").Index = e.Col And e.Row > 0 Then
            TimerGoods.Start()
        End If
    End Sub






#Region "规格和厚度列表"

    Dim Dt_Goods_Spec As New DataTable
    Dim Dt_Goods_Thick As New DataTable
    Private Sub Get_ComboxList()
        Get_Goods_Spec()
        Get_Goods_Thick()
        Get_Goods()
    End Sub


    Private Sub Get_Goods_Spec()
        Dim r As DtReturnMsg = Goods.GetGoods_Spec_DT()
        If r.IsOk = True Then
            Dt_Goods_Spec = r.Dt
        End If
    End Sub
    Private Sub Get_Goods_Thick()
        Dim r As DtReturnMsg = Goods.GetGoods_Thick_DT()
        If r.IsOk = True Then
            Dt_Goods_Thick = r.Dt
        End If
    End Sub

    Sub Dt_Goods_Spec_Add(ByVal s As String)
        Dim R() As DataRow = Dt_Goods_Spec.Select("col='" & s & "'")
        If R.Length = 0 Then
            Dim Row As DataRow = Dt_Goods_Spec.NewRow
            Row(0) = s
            Dt_Goods_Spec.Rows.Add(Row)
            Dt_Goods_Spec.AcceptChanges()
        End If
    End Sub

    Sub Dt_Goods_Thick_Add(ByVal s As Double)
        If s = 0 Then Exit Sub
        Dim R() As DataRow = Dt_Goods_Thick.Select("col='" & s & "'")
        If R.Length = 0 Then
            Dim Row As DataRow = Dt_Goods_Thick.NewRow
            Row(0) = s
            Dt_Goods_Thick.Rows.Add(Row)
            Dt_Goods_Thick.AcceptChanges()
        End If
    End Sub


    Private Sub Fg1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.LostFocus
        If ListBox_Show.Visible = True OrElse Fg2.Visible Then TimerFGLostFocus.Start()
    End Sub

    Private Sub Fg1_LeaveEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.LeaveEdit
        If ListBox_Show.Visible = True OrElse Fg2.Visible Then TimerFGLostFocus.Start()
    End Sub
    Private Sub TimerFGLostFocus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFGLostFocus.Tick
        TimerFGLostFocus.Enabled = False
        If ListBox_Show.Visible = True AndAlso (ListBox_Show.Focused = False AndAlso (Fg1.Editor Is Nothing OrElse Fg1.Editor.Focused = False)) Then ListBox_Show.Visible = False
        If Fg2.Visible = True AndAlso (Fg2.Focused = False AndAlso (Fg1.Editor Is Nothing OrElse Fg1.Editor.Focused = False)) Then Fg2.Visible = False
    End Sub

    Private Sub TimerCombox_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCombox.Tick
        TimerCombox.Enabled = False
        If ListBox_Show.Visible = True Then ListBox_Refresh()
    End Sub
    Sub ListBox_Refresh()
        If Fg1.Editor Is Nothing Then
            Exit Sub
        End If
        Try
            Select Case ListBox_Show.AccessibleDescription
                Case "Goods_Spec", "Product_Spec"
                    Dt_Goods_Spec.DefaultView.RowFilter = "col like '" & Fg1.Editor.Text & "%' and col<>''"
                    Dt_Goods_Spec.DefaultView.Sort = "col"
                    ListBox_Show.DataSource = Dt_Goods_Spec.DefaultView
                Case "Goods_Thick"
                    Dt_Goods_Thick.DefaultView.RowFilter = "col like '" & Fg1.Editor.Text & "%' and col<>''"
                    Dt_Goods_Spec.DefaultView.Sort = "col"
                    ListBox_Show.DataSource = Dt_Goods_Thick.DefaultView
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Sub ListBox_KeyDown(ByVal Key As Keys)
        Select Case Key
            Case Keys.Down
                If ListBox_Show.SelectedIndex < ListBox_Show.Items.Count - 1 Then
                    ListBox_Show.SelectedIndex = ListBox_Show.SelectedIndex + 1
                End If
                ListBox_Show.Focus()
            Case Keys.Down
                If ListBox_Show.SelectedIndex > 0 Then
                    ListBox_Show.SelectedIndex = ListBox_Show.SelectedIndex - 1
                End If
                ListBox_Show.Focus()
        End Select
    End Sub
    Private Sub ListBox_Show_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox_Show.KeyDown
        If e.KeyCode = Keys.Enter Then
            ListBox_Show_Click(sender, New System.EventArgs)
        End If
    End Sub
    Private Sub ListBox_Show_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox_Show.Click
        If Fg1.ColSel = ListBox_Show.Tag AndAlso Fg1.RowSel = ListBox_Show.AccessibleName Then
            Fg1.Item(Fg1.RowSel, Fg1.ColSel) = Trim(ListBox_Show.Text)
            Fg1.Focus()
            lastKey = Keys.Enter
            Fg1_AfterEdit(Fg1, New C1.Win.C1FlexGrid.RowColEventArgs(Fg1.RowSel, Fg1.ColSel))
        End If
    End Sub
#End Region

#Region "商品资料"
    Dim Dt_Goods As New DataTable

    Private Sub Get_Goods()
        Dim r As DtReturnMsg = Goods.Goods_GetMiniDt()
        If r.IsOk = True Then
            Dt_Goods = r.Dt
        End If
    End Sub


    Private Sub TimerGoods_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGoods.Tick
        TimerGoods.Enabled = False
        If Fg2.Visible = True Then FG2_Refresh()
    End Sub
    Sub FG2_Refresh()
        If Fg1.Editor Is Nothing Then
            Exit Sub
        End If
        Try
            Dt_Goods.DefaultView.RowFilter = "Goods_No like '" & Fg1.Editor.Text & "%' and Goods_No<>'' or Goods_Name  like '" & Fg1.Editor.Text & "%' or Goods_FindHelper  like '" & Fg1.Editor.Text & "%'"
            '  Dt_Goods.DefaultView.Sort = "Goods_No"
            Fg2.DataSource = Dt_Goods.DefaultView
        Catch ex As Exception

        End Try

    End Sub
    Sub FG2_KeyDown(ByVal Key As Keys)
        Select Case Key
            Case Keys.Down
                If Fg2.RowSel < Fg2.Rows.Count - 1 Then
                    Fg2.RowSel = Fg2.RowSel + 1
                    Fg2.Row = Fg2.Row + 1
                End If
                Fg2.Focus()
            Case Keys.Down
                If Fg2.RowSel > 1 Then
                    Fg2.RowSel = Fg2.RowSel - 1
                    Fg2.Row = Fg2.Row - 1
                End If
                Fg2.Focus()
        End Select
    End Sub
    Private Sub Fg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Fg2_Click(sender, New System.EventArgs)
        End If
    End Sub
    Private Sub Fg2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.Click
        If Fg1.ColSel = Fg2.Tag AndAlso Fg1.RowSel = Fg2.AccessibleName Then
            Fg1.Item(Fg1.RowSel, "Goods_No") = Fg2.Item(Fg2.RowSel, "Goods_No")
            Fg1.Focus()
            lastKey = Keys.Enter
            Fg1_AfterEdit(Fg1, New C1.Win.C1FlexGrid.RowColEventArgs(Fg1.RowSel, Fg1.Cols("Goods_No").Index))
        End If
    End Sub
#End Region

#Region "商品选择"

    Protected Sub ShowGoodsSelBtn()
        If Fg1.ColSel > 0 AndAlso Fg1.RowSel > 0 AndAlso Fg1.CanEditing Then
            Dim C As C1.Win.C1FlexGrid.Column = Fg1.Cols(Fg1.ColSel)
            Dim R As C1.Win.C1FlexGrid.Row = Fg1.Rows(Fg1.RowSel)
            Select Case Fg1.Cols(Fg1.ColSel).Name
                Case "Goods_No", "Goods_Name"
                    Btn_GoodsSel.Left = Fg1.Left + C.Left + C.WidthDisplay - Btn_GoodsSel.Width + 1
                    Btn_GoodsSel.Top = Fg1.Top + R.Top + Fg1.ScrollPosition.Y + 1
                    Btn_GoodsSel.Height = R.HeightDisplay
                    Btn_GoodsSel.Visible = True
                    ListBox_Show.Visible = False


                    Fg2.AccessibleDescription = Fg1.Cols(Fg1.ColSel).Name
                    FG2_Refresh()
                    Fg2.Visible = True
                    Fg2.Tag = Fg1.ColSel
                    Fg2.AccessibleName = Fg1.RowSel
                    Fg2.Left = Fg1.Left + C.Left + PanelFG.Left + GB_List.Left
                    Fg2.Top = Fg1.Top + R.Top + R.HeightDisplay + Fg1.ScrollPosition.Y + 2 + PanelFG.Top + GB_List.Top





                Case "Product_Spec", "Goods_Spec", "Goods_Thick"
                    ListBox_Show.AccessibleDescription = Fg1.Cols(Fg1.ColSel).Name
                    ListBox_Refresh()
                    ListBox_Show.Visible = True
                    ListBox_Show.Tag = Fg1.ColSel
                    ListBox_Show.AccessibleName = Fg1.RowSel


                    ListBox_Show.Left = Fg1.Left + C.Left + PanelFG.Left + GB_List.Left
                    ListBox_Show.Top = Fg1.Top + R.Top + R.HeightDisplay + Fg1.ScrollPosition.Y + 2 + PanelFG.Top + GB_List.Top
                    ListBox_Show.Width = C.WidthDisplay
                    Btn_GoodsSel.Visible = False
                    Fg2.Visible = False
                Case Else
                    Btn_GoodsSel.Visible = False
                    ListBox_Show.Visible = False
                    Fg2.Visible = False
            End Select
        Else
            Btn_GoodsSel.Visible = False
            ListBox_Show.Visible = False
            Fg2.Visible = False
            If Fg1.RowSel > 0 Then
                Fg1.Select(Fg1.Rows.Count - 1, 1)
            End If
        End If
    End Sub

    Private Sub Btn_GoodsSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_GoodsSel.Click
        ShowGoodsSel()
    End Sub

    Protected Sub ShowGoodsSel()
        Dim F As BaseForm = LoadFormIDToChild(10000, Me)
        If F Is Nothing Then Exit Sub
        Fg1.RowSel = Fg1.RowSel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoods
        VF.Show()
    End Sub

    Protected Sub SetGoods()
        Dim T As New Threading.Thread(AddressOf Get_Goods)
        T.Start()
        If Not Me.ReturnObj Is Nothing AndAlso Fg1.CanEditing AndAlso Fg1.RowSel > 0 Then
            Dim dr As DataRow = ReturnObj
            Fg1.Item(Fg1.RowSel, "Goods_No") = IsNull(dr("Goods_No"), "")
            Fg1.Item(Fg1.RowSel, "Goods_Name") = IsNull(dr("Goods_Name"), "")
            Fg1.Item(Fg1.RowSel, "Goods_Unit") = IsNull(dr("Goods_Unit"), "")
            Fg1.Item(Fg1.RowSel, "DPrice") = IsNull(dr("Goods_Price"), 0)
            Fg1.GotoNextCell("Goods_No")
        Else
            Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Goods_No").Index)
        End If
    End Sub

    Protected Sub SetGoodsByID(ByVal goodsId As String)
        Dim msg As DtReturnMsg = BaseClass.Goods.Goods_GetById(goodsId)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            Dim dr As DataRow = msg.Dt.Rows(0)
            Fg1.Item(Fg1.RowSel, "Goods_No") = IsNull(dr("Goods_No"), "")
            Fg1.Item(Fg1.RowSel, "Goods_Name") = IsNull(dr("Goods_Name"), "")
            Fg1.Item(Fg1.RowSel, "Goods_Unit") = IsNull(dr("Goods_Unit"), "")
            Fg1.GotoNextCell("Goods_No")
        Else
            ShowErrMsg("没有找到" & Fg1.Cols("Goods_No").Caption & "[" & goodsId & "]!", AddressOf FG1_Goods_No_Enter)
        End If
    End Sub
#End Region


#End Region

#Region "获取新单号"
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If Mode = Mode_Enum.Add Then
            ShowConfirm("是否获取新单号?", AddressOf GetNewID)
        Else
            ShowErrMsg("非新增状态不能修改单号!")
        End If
    End Sub

    Sub GetNewID()
        If Mode = Mode_Enum.Add Then
            Dim msg As RetrunNewIdMsg = Produce_GetNewId(DP_Date.Value)
            If msg.IsOk Then
                DP_Date.MinDate = msg.MaxDate.AddDays(1)
                DP_Date.Value = msg.NewIdDate
                ProduceID = msg.NewID
                TB_ID.Text = ProduceID
                If msg.IsTheDate = False Then
                    ShowErrMsg(msg.RetrunMsg)
                End If
            Else
                ShowErrMsg(msg.RetrunMsg)
            End If
        End If
    End Sub
    Private Sub DP_Date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DP_Date.ValueChanged
        GetNewID()
    End Sub
#End Region










    Private Sub TB_SumQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_SumProductQty.TextChanged

    End Sub
End Class
