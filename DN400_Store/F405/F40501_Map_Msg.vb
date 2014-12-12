Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F40501_Map_Msg
    Dim RemarkID As String = ""

    Dim dtWL As DataTable
    Dim dtList As DataTable
    Dim RemarkType As Enum_RemarkType

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal RemarkID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.RemarkID = RemarkID
        Me.Mode = Mode

    End Sub

    Sub FormCheckRight()

    End Sub

    Private Sub F40500_Store_Map_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        LabelNormal.ForeColor = Cs.Color_Normal
        LabelSel.ForeColor = Cs.Color_Sel
        LabelEmpty.ForeColor = Cs.Color_Empty
        LabelCell.ForeColor = Cs.Color_Cell
        LabelCellA.ForeColor = Cs.Color_CellA
        LabelPost.ForeColor = Cs.Color_Post
        LabelDisable.ForeColor = Cs.Color_Disable
        LabelPassage.ForeColor = Cs.Color_Passage


        CB_Floor.DataSource = cStore_Area.Get_Area_Dt
        CB_Floor.DisplayMember = "FloorName"
        CB_Floor.ValueMember = "Floor"
    End Sub


#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtWL.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)

            'dt.Rows(0)("Remark_ID") = TB_ID.Text

            'dt.Rows(0)("Remark") = TB_Remark.Text
            'dt.Rows(0)("Remark2") = TB_Remark2.Text
            'dt.Rows(0)("Remark_Type") = RemarkType

        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            'TB_ID.Text = IsNull(dt.Rows(0)("Remark_ID"), "")

            'TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
            'TB_Remark2.Text = IsNull(dt.Rows(0)("Remark2"), "")
        End If
    End Sub




#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' If CheckForm() Then ShowConfirm("是否保存备注[" & TB_ID.Text & "] 的修改?", AddressOf Save)
    End Sub


    Protected Function CheckForm() As Boolean
        'If TB_ID.Text = "" Then
        '    ShowErrMsg("备注编号不能为空")
        '    TB_ID.Focus()
        '    Return False
        'End If


        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  ShowConfirm("是否删除备注[" & TB_ID.Text & "]?", AddressOf DelWL)
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        Cs.Save()
    End Sub


#End Region


#Region "控件事件"
    Dim Cs As New cStore_Area
    Private Sub Cmd_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Set.Click
        Cs.Floor = CB_Floor.SelectedValue
        Cs.SetRowCol(Val(TB_Row.Text), Val(Tb_Col.Text), Val(TB_RowHeight.Text), Val(TB_ColWidth.Text), Val(TB_sMaxQty.Text))
        Cs.DG_Ini(DG)
    End Sub


    Private Sub Cmd_AddPRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddPRow.Click
        Cs.SetPassageRow(DG.SelectedCells(0).RowIndex, Val(TB_Passage_Height.Text))
        Cs.DG_Show(DG)
    End Sub

    Private Sub Add_PCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_PCol.Click
        Cs.SetPassageCol(DG.SelectedCells(0).ColumnIndex, Val(TB_Passage_Width.Text))
        Cs.DG_Show(DG)
    End Sub

    Private Sub Cmd_AddPJRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddPJRow.Click
        Cs.SetPassageJRow(Val(TB_Passage_Height.Text), Val(TB_JStart.Text), Val(TB_JStep.Text))
        Cs.DG_Show(DG)
    End Sub
    Private Sub Add_PJCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_PJCol.Click
        Cs.SetPassageJCol(Val(TB_Passage_Width.Text), Val(TB_JStart.Text), Val(TB_JStep.Text))
        Cs.DG_Show(DG)
    End Sub


    Private Sub Cmd_AutoAddNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AutoAddNo.Click
        Cs.AutoAddNo(Val(TB_NoStart.Text))
        Cs.DG_Show(DG)
    End Sub

    Private Sub Cmd_Quick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Quick.Click
        Cs.Floor = CB_Floor.SelectedValue
        Cs.SetRowCol(Val(TB_Row.Text), Val(Tb_Col.Text), Val(TB_RowHeight.Text), Val(TB_ColWidth.Text), Val(TB_sMaxQty.Text))
        Cs.SetPassageJRow(Val(TB_Passage_Width.Text), Val(TB_JStart.Text), Val(TB_JStep.Text))
        Cs.AutoAddNo(Val(TB_NoStart.Text))
        Cs.DG_Show(DG)
    End Sub

    Private Sub DG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        Dim dr As DataRow = Cs.GetCellRow(e.ColumnIndex, e.RowIndex)
        CB_State.SelectedIndex = dr("State")
        TB_Qty.Text = dr("Qty")
        TB_MaxQty.Text = dr("MaxQty")
        TB_No.Text = dr("sNo")
        LabelXY.Text = e.ColumnIndex & "," & e.RowIndex
    End Sub




    Private Sub Cmd_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Edit.Click
        If LabelXY.Text = "" Then Exit Sub
        Dim S() As String = LabelXY.Text.Split(",")
        Dim dr As DataRow = Cs.GetCellRow(S(0), S(1))
        dr("State") = CB_State.SelectedIndex
        dr("Qty") = TB_Qty.Text
        dr("MaxQty") = TB_MaxQty.Text
        dr("sNo") = TB_No.Text
        Cs.DG_ReFresh(DG)
    End Sub


    Private Sub LabelEmpty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    LabelNormal.Click, LabelSel.Click, LabelEmpty.Click, LabelCell.Click, LabelCellA.Click, LabelPost.Click, LabelDisable.Click, LabelPassage.Click
        Dim L As Label = TryCast(sender, Label)
        Using C As New ColorDialog
            C.Color = L.ForeColor
            If C.ShowDialog = Windows.Forms.DialogResult.OK Then
                L.ForeColor = C.Color
                Select Case L.Name
                    Case LabelNormal.Name
                        Cs.Color_Normal = L.ForeColor
                    Case LabelSel.Name
                        Cs.Color_Sel = L.ForeColor
                    Case LabelEmpty.Name
                        Cs.Color_Empty = L.ForeColor
                    Case LabelCell.Name
                        Cs.Color_Cell = L.ForeColor
                    Case LabelCellA.Name
                        Cs.Color_CellA = L.ForeColor
                    Case LabelPost.Name
                        Cs.Color_Post = L.ForeColor
                    Case LabelDisable.Name
                        Cs.Color_Disable = L.ForeColor
                    Case LabelPassage.Name
                        Cs.Color_Passage = L.ForeColor
                End Select
                Cs.DG_ReFresh(DG)
            End If
        End Using
    End Sub
#End Region





    Private Sub CB_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Floor.SelectedIndexChanged
        If CB_Floor.Text.Length <> 2 Then Exit Sub
        Cs.Floor = CB_Floor.SelectedIndex + 1
        Cs.GetFormDt()
        If Cs.Cell.Rows.Count = 0 Then
            Cs.Floor = CB_Floor.SelectedIndex + 1
            Cs.SetRowCol(Val(TB_Row.Text), Val(Tb_Col.Text), Val(TB_RowHeight.Text), Val(TB_ColWidth.Text), Val(TB_sMaxQty.Text))
            Cs.SetPassageJCol(Val(TB_Passage_Width.Text), Val(TB_JStart.Text), Val(TB_JStep.Text))
            Cs.AutoAddNo(Val(TB_NoStart.Text))
            Cs.DG_Show(DG)
        Else
            Cs.DG_Show(DG)
        End If
    End Sub


    Dim DGCell As System.Windows.Forms.DataGridViewCellEventArgs
    Private Sub DG_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellMouseEnter
        DGCell = e
    End Sub

    Private Sub DG_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellMouseLeave
        If DGCell IsNot Nothing Then
            If DGCell.RowIndex = e.RowIndex AndAlso DGCell.ColumnIndex = e.ColumnIndex Then
                DGCell = Nothing
            End If
        End If

    End Sub

    Private Sub DG_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DG.MouseClick
        If DGCell IsNot Nothing Then
            Timer1.Start()
        End If
    End Sub

 
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Timer1.Stop()
        ' FS.ShowMsg()
    End Sub

    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        Cs.SetAddRow()
        Cs.DG_Show(DG)
    End Sub
End Class
