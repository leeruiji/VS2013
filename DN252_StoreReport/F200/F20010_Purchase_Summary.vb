Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F20010_Purchase_Summary
    Private WithEvents R As New R20010_Purchase_Summary
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Print, Btn_ExcelOut)
        Control_CheckRight(ID, ClassMain.Print, Btn_PrePrint)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        DP_Start.Value = New Date(Now.Year, Now.Month, 1).Date
        DP_End.Value = Today
        CB_ConditionName1.ComboBox.DisplayMember = "Field"
        CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        CB_ConditionName1.ComboBox.DataSource = R.GetConditionNames()
        CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        CB_ConditionValue2.ComboBox.DisplayMember = "col"
        CB_ConditionValue2.ComboBox.ValueMember = "col"
        CB_ConditionName2.ComboBox.DataSource = R.GetConditionNames()
        TB_Goods_Name.Tag = ""
        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        Me_Refresh()
        Dim T As New Threading.Thread(AddressOf Get_Goods)
        T.Start()
    End Sub

    Protected Sub Me_Refresh()
        R.Start(GetFindOtions)
    End Sub




#Region "控件事件"
    Private Sub Btn_ExcelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExcelOut.Click
        R.ExportXLS()
    End Sub
    Private Sub Btn_PrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PrePrint.Click
        R.PrintPreview()
    End Sub
    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"
    'Private Sub CB_ConditionName1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName1.SelectedIndexChanged
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName1.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue1.ComboBox.DataSource = msg.Dt
    '    End If
    'End Sub

    Private Sub CB_ConditionValue2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_ConditionValue2.DropDown
        Dim oList As OptionList = GetFindOtions()
        Dim msg As DataTable = R.GetConditionDt(CB_ConditionName2.ComboBox.SelectedValue)
        CB_ConditionValue2.ComboBox.DataSource = msg
    End Sub



    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_ConditionValue1.TextChanged
        Me_Refresh()
    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim sqlbuider As New StringBuilder("")
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "Purchase_Date"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)
        If Not CB_ConditionName1.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName1.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName1.ComboBox.SelectedValue
            fo.Value = TB_ConditionValue1.Text
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If Not CB_ConditionName2.ComboBox.SelectedValue Is Nothing AndAlso Not CB_ConditionName2.ComboBox.SelectedValue = "" Then
            fo = New FindOption
            fo.DB_Field = CB_ConditionName2.ComboBox.SelectedValue
            fo.Value = CB_ConditionValue2.ComboBox.Text
            fo.Field_Operator = Enum_Operator.Operator_Like
            oList.FoList.Add(fo)
        End If

        If TB_Goods_Name.Tag <> "" Then
            fo = New FindOption
            fo.DB_Field = "Goods_No"
            fo.Value = TB_Goods_Name.Tag
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub






#Region "商品选择"

    Private Sub TB_Goods_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_Goods_Name.KeyPress
        If e.KeyChar = vbCrLf Then
            Fg2_Click(sender, New System.EventArgs)
            Me_Refresh()
        End If
    End Sub

    Private Sub TB_Goods_Name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Goods_Name.TextChanged
        FG2_Refresh()
    End Sub

    Private Sub TB_Goods_Name_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Goods_Name.GotFocus
        FG2_Refresh()
        Fg2.Visible = True
    End Sub
    Private Sub TB_Goods_Name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Goods_Name.LostFocus
        TimerGoods.Enabled = True
    End Sub

    Dim Dt_Goods As New DataTable

    Private Sub Get_Goods()
        Dim r As DtReturnMsg = Goods.Goods_GetMiniDt()
        If r.IsOk = True Then
            Dt_Goods = r.Dt
        End If
    End Sub


    Private Sub TimerGoods_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGoods.Tick
        TimerGoods.Enabled = False
        If Fg2.Focused = False And TB_Goods_Name.Focused = False Then Fg2.Visible = False
    End Sub
    Sub FG2_Refresh()
        Try
            Dt_Goods.DefaultView.RowFilter = "Goods_No like '" & TB_Goods_Name.Text & "%' and Goods_No<>'' or Goods_Name  like '" & TB_Goods_Name.Text & "%' or Goods_FindHelper  like '" & TB_Goods_Name.Text & "%'"
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
        TB_Goods_Name.Text = Fg2.Item(Fg2.RowSel, "Goods_Name")
        TB_Goods_Name.Tag = Fg2.Item(Fg2.RowSel, "Goods_No")
        Fg2.Visible = False
    End Sub

#End Region
#End Region






    

End Class
