Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport
Imports PClass


Public Class F40003_BZSH_ChangePrice
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        If CheckRight(ID, ClassMain.Price) Then
            Fg2.Cols("Price").Visible = True
            Fg2.Cols("Amount").Visible = True
            Fg2.Cols("Price_ZhiTong").Visible = True
            Fg2.Cols("Price_JiaoDai").Visible = True
            Fg2.Cols("Amount_ZhiTong").Visible = True
            Fg2.Cols("Amount_JiaoDai").Visible = True
            Fg2.Cols("Amount_GH").Visible = True
        Else
            Fg2.CanEditing = False
            Fg2.Cols("Price").Visible = False
            Fg2.Cols("Amount").Visible = False
            Fg2.Cols("Price_ZhiTong").Visible = False
            Fg2.Cols("Price_JiaoDai").Visible = False
            Fg2.Cols("Amount_ZhiTong").Visible = False
            Fg2.Cols("Amount_JiaoDai").Visible = False
            Fg2.Cols("Amount_GH").Visible = False
        End If

    End Sub

    Private Sub F40000_BZSH_AfterLoad() Handles Me.AfterLoad
        Fg2.FG_ColResize()
        SumFG1.AddSum()
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        Me.MeIsLoad = False
        Try
            My.Settings.Bookmark = Cmd_Bookmark.Checked
            If Cmd_Bookmark.Checked Then
                My.Settings.StarDate = DP_Start.Value.Date
                My.Settings.EndDate = Dp_End.Value.Date
                If Fg2.RowSel >= 1 Then
                    My.Settings.ROW = Fg2.RowSel
                Else
                    My.Settings.ROW = 0
                End If

                My.Settings.Client = TSC_Client.IDValue
            End If
            My.Settings.Save()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub F_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Fg2.IniFormat()
        Fg2.IniColsSize()
        Cmd_ShowALL.Checked = My.Settings.Showall
        isShow(Cmd_ShowALL.Checked)
        DP_Start.Value = Today
        Dp_End.Value = Today

        Cmd_Bookmark.Checked = My.Settings.Bookmark
        If Cmd_Bookmark.Checked Then
            DP_Start.Value = My.Settings.StarDate
            Dp_End.Value = My.Settings.EndDate
            TSC_Client.IDValue = My.Settings.Client
            TSC_Client.Text = TSC_Client.GetByTextBoxTag(My.Settings.Client)
        End If







        'CB_ConditionName1.ComboBox.DisplayMember = "Field"
        'CB_ConditionName1.ComboBox.ValueMember = "DB_Field"
        ''CB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        ''CB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"
        'CB_ConditionName1.ComboBox.DataSource = Dao.BZSH_GetConditionNames()
        'CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        'CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        'CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        'CB_ConditionName2.ComboBox.DataSource = Dao.BZSH_GetConditionNames()

        CB_Condition3.ComboBox.DisplayMember = "Field"
        CB_Condition3.ComboBox.ValueMember = "DB_Field"
        CB_Condition3.ComboBox.DataSource = Dao.BZSH_GetCondition3
        If Val(Me.P_F_RS_ID) <> 0 And Me.P_F_RS_ID2 <> "" Then
            DP_Start.Value = New Date(1999, 1, 1)
            TSC_Client.IDValue = Val(Me.P_F_RS_ID)
            TSC_Client.Text = P_F_RS_ID2
        End If
        Me_Refresh()
        isLoaded = True
    End Sub

#Region "刷新FG"
    Protected Sub Me_Refresh()
        Static T As Threading.Thread
        If T IsNot Nothing Then
            If T.IsAlive Then
                Try
                    T.Abort()
                Catch ex As Exception
                End Try
            End If
        End If
        T = New Threading.Thread(AddressOf GetData)
        T.IsBackground = True
        T.Start(GetFindOtions)
        Me.ShowLoading(MeIsLoad)
    End Sub


    Sub SetData(ByVal msg As DtReturnMsg)
        If msg.IsOk Then
            Dim sumQty As Integer = 0
            Dim sumZL As Double = 0
            For Each dr As DataRow In msg.Dt.Rows
                sumQty += IsNull(dr("Qty"), 0)
                sumZL += IsNull(dr("CWeight"), 0)
                If IsNull(dr("BZC_Name"), "") = "" Then
                    dr("BZC_Name") = IsNull(dr("BzcMsg"), "").ToString.Split(vbCrLf)(0)
                End If
                'If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
                '    dr("BZ_No") = ""
                'End If
                If IsNull(dr("CPName"), "") = "" Then
                    dr("CPName") = dr("BZ_Name")
                End If
            Next
            Fg2.Redraw = False
            Fg2.DtToSetFG(msg.Dt)
            SumFG1.ReSum()
            Fg2.AutoSizeCols(1, Fg2.Cols.Count, 0)
            Fg2.SortByLastOrder()
            LB_Luose_Qty.Text = FormatNum(sumQty)
            LB_LuoSe_ZL.Text = FormatZL(sumZL)
            If Cmd_Bookmark.Checked = True AndAlso Fg2.Rows.Count > My.Settings.ROW Then
                Fg2.Row = My.Settings.ROW
            End If
            Fg2.Redraw = True
        Else
            Fg1.Rows.Count = 1
        End If
        Fg1.Visible = True
        Me.HideLoading()
    End Sub

    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.BZSH_GetListByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)

#End Region


    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub

#Region "控件事件"
    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If TSC_BZ.SearchID <> ID Then
            TSC_BZ.Text = ""
            TSC_BZ.IDValue = 0
        End If
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZ.SearchID = ID
    End Sub

    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0
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

    'Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue2.ComboBox.DataSource = msg.Dt
    '    End If
    'End Sub


    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me_Refresh()
    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        '   oList.Sql = SQL_BZSH_Get_Sel
        Dim sqlbuider As New StringBuilder(SQL_BZSH_Get_Sel)
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "BZSH_Date"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = DP_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)


        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "T.Client_ID"
            fo.Value = TSC_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Tb_GH.TextBox.Text <> "" Then
            fo = New FindOption
            fo.DB_Field = "L.GH"
            fo.Value = Tb_GH.TextBox.Text
            fo.Field_Operator = Enum_Operator.Operator_Like_Both
            oList.FoList.Add(fo)
        End If


        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "L.BZ_ID"
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If CKB_ZeroOnly.Checked Then
            fo = New FindOption
            fo.DB_Field = "L.price"
            fo.Value = 0
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If


        If CB_Condition3.SelectedIndex > 0 Then
            fo = New FindOption
            fo.DB_Field = "State"
            fo.Value = CB_Condition3.ComboBox.SelectedValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If
        '   sqlbuider.Append(SQL_BZSH_OrderBy)
        oList.Sql = sqlbuider.ToString
        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub


#End Region

    Sub ReSum()
        Dim sumQty As Integer = 0
        Dim sumZL As Double = 0
        For i As Integer = 1 To Fg2.Rows.Count - 1

            sumQty += IsNull(Fg2.Item(i, "Qty"), 0)
            sumZL += IsNull(Fg2.Item(i, "CWeight"), 0)
        Next
        LB_Luose_Qty.Text = FormatNum(sumQty)
        LB_LuoSe_ZL.Text = FormatZL(sumZL)
    End Sub

    Private Sub AfterEditFormat(ByVal FG As PClass.FG, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs)
        Try
            Dim f As String = FG.Cols(e.Col).Format
            If f <> "" AndAlso (f.Contains("0") OrElse f.Contains("#")) Then
                FG.Item(e.Row, e.Col) = Val(FG.Item(e.Row, e.Col)).ToString(f)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg2_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg2.AfterEdit
        ' Dim IsUpdated As Boolean
        If e.Col = Fg2.Cols("Price").Index Then
            Dim P As Double = Val(StrConv(Fg2.Item(e.Row, "Price"), vbNarrow))
            Fg2.Item(e.Row, "Price") = P
            If UpdatePrcie(e.Row) Then
                For i As Integer = e.Row + 1 To Fg2.Rows.Count - 1
                    If Btn_Auto_BZC.Checked Then
                        If Fg2.Item(e.Row, "BZC_ID") = Fg2.Item(i, "BZC_ID") Then
                            If (Btn_Auto_BZ.Checked AndAlso Fg2.Item(e.Row, "BZ_ID") = Fg2.Item(i, "BZ_ID")) OrElse Btn_Auto_BZ.Checked = False Then
                                If Btn_Auto_JiaGongNeiRong.Checked AndAlso Btn_Auto_BZ.Checked AndAlso Fg2.Item(e.Row, "JiaGongNeiRong") = Fg2.Item(i, "JiaGongNeiRong") Then
                                    ReSetPric(i, e.Row, "Price", P)
                                End If
                            End If
                        End If
                    ElseIf Btn_Auto_BZ.Checked AndAlso Fg2.Item(e.Row, "BZ_ID") = Fg2.Item(i, "BZ_ID") Then
                        ReSetPric(i, e.Row, "Price", P)
                    End If
                Next
            Else
                ShowErrMsg("修改单价失败!")
                Fg2.Item(e.Row, "Price") = Fg2.LastText
            End If
                AfterEditFormat(Fg2, e)
            ElseIf e.Col = Fg2.Cols("Price_ZhiTong").Index Then
                Dim P As Double = Val(StrConv(Fg2.Item(e.Row, "Price_ZhiTong"), vbNarrow))
                Fg2.Item(e.Row, "Price_ZhiTong") = P
                If UpdatePrcie(e.Row) Then

                Else
                    ShowErrMsg("修改纸筒单价失败!")
                    Fg2.Item(e.Row, "Price_ZhiTong") = Fg2.LastText
                End If
                AfterEditFormat(Fg2, e)
            Else
                Exit Sub
            End If
            ReSum()

            If Fg2.LastKey = Keys.Enter Then
                Fg2.GotoNextCell()
            End If
    End Sub

    Function ReSetPric(ByVal i As Integer, ByVal NowRow As Integer, ByVal Field As String, ByVal Price As Double) As Boolean
        Dim LastPrice As Double = Val(IsNull(Fg2.Item(i, Field), 0))
        Fg2.Item(i, Field) = Price
        If UpdatePrcie(i) = False Then
            ShowErrMsg("修改单价失败!")
            Fg2.Item(NowRow, Field) = Fg2.LastText
            Return False
        Else
            Return True
        End If
    End Function




    Function UpdatePrcie(ByVal I As Integer) As Boolean
        Fg2.Item(I, "Amount") = Val(Fg2.Item(I, "PWeight")) * Val(Fg2.Item(I, "Price"))
        Fg2.Item(I, "Price_JiaoDai") = 2
        '纸筒
        Dim ZhiTong As Double = Val(Fg2.Item(I, "ZhiTong"))
        Dim Cost_ZhiTong As Double
        If ZhiTong > 0.6 Then
            Cost_ZhiTong = Val(Fg2.Item(I, "Price_ZhiTong")) * Val(Fg2.Item(I, "Qty"))
            Fg2.Item(I, "Amount_ZhiTong") = Cost_ZhiTong
        Else
            Fg2.Item(I, "Amount_ZhiTong") = 0
        End If
        Dim Cost_JiaoDai As Double
        '双胶袋
        If Fg2.Item(I, "JiaoDai") = "双" Then
            Cost_JiaoDai = Val(Fg2.Item(I, "Price_JiaoDai")) * Val(Fg2.Item(I, "Qty"))
            Fg2.Item(I, "Amount_JiaoDai") = Cost_JiaoDai
        Else
            Fg2.Item(I, "Amount_JiaoDai") = 0
        End If
        Fg2.Item(I, "Amount_GH") = Val(Fg2.Item(I, "Amount")) + Val(Fg2.Item(I, "Amount_ZhiTong")) + Val(Fg2.Item(I, "Amount_JiaoDai"))
        Return Dao.BZSH_UpdatePrice(Fg2.Item(I, "BZSH_ID"), Fg2.Item(I, "Line"), Fg2.Item(I, "Price"), _
                             Fg2.Item(I, "Price_ZhiTong"), Fg2.Item(I, "Amount"), Fg2.Item(I, "Price_JiaoDai"), _
                                Fg2.Item(I, "Amount_ZhiTong"), Fg2.Item(I, "Amount_JiaoDai"), Fg2.Item(I, "Amount_GH"))
    End Function



    Private Sub Fg2_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg2.NextCell
        Select Case e.Col
            Case "Price"
                If e.Row = Fg2.Rows.Count - 1 Then
                    Exit Sub
                End If
                e.ToCol = Fg2.Cols("Price").Index
                e.ToRow = e.Row + 1
                Do While e.ToRow < Fg2.Rows.Count AndAlso IsNull(Fg2.Item(e.ToRow, "Price"), 0) <> 0
                    e.ToRow = e.ToRow + 1
                Loop




            Case "Price_ZhiTong"
                If e.Row = Fg2.Rows.Count - 1 Then
                    Exit Sub
                End If
                e.ToCol = Fg2.Cols("Price_ZhiTong").Index
                e.ToRow = e.Row + 1

        End Select
    End Sub



    Private Sub Fg2_SelectRowChange(ByVal Row As Integer) Handles Fg2.SelectRowChange
        If Fg2.Row > 0 Then
            Label_BZC_No.Text = "GY-" & Fg2.Item(Row, "BZC_No") & "  " & Fg2.Item(Row, "BZC_Name")
            Label_Name.Text = BZCheck(Fg2.Item(Row, "BZ_No")) & "  " & Fg2.Item(Row, "CPName")
            Label_LastPrice.Text = "正在加载...."

        End If
        Timer1.Start()
    End Sub
    Private Function BZCheck(ByVal BZ As String) As String
        If BZ Is Nothing Then Return ""
        If BZ.EndsWith("#") Then
            Return BZ
        Else
            Return ""

        End If

    End Function




    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Dim T As New Threading.Thread(AddressOf FindLastPrice)
        T.Start()
    End Sub

    Sub FindLastPrice()
        Dim r As MsgReturn = Dao.BZSH_GetLastPrice(Fg2.Item(Fg2.RowSel, "BZC_ID"), Fg2.Item(Fg2.RowSel, "BZ_ID"))
        Dim dt As DtReturnMsg = Dao.Price_GetLastIDandprice(Fg2.Item(Fg2.RowSel, "BZC_ID"), Fg2.Item(Fg2.RowSel, "BZ_ID"))
        Dim d As New DSetPrice(AddressOf SetPrice)
        d(r.Msg)
        If dt.IsOk = True And dt.Dt.Rows.Count > 0 Then
            SetComfirmpriceAndId(IsNull(dt.Dt.Rows(0)("Price").ToString, ""), IsNull(dt.Dt.Rows(0)("id"), ""))
        Else
            Last_ComfirmPrice.Text = "没有找到"
            Label_LastId.Text = "没有找到"
        End If

    End Sub

    Sub SetPrice(ByVal Price As String)
        If Price = "" Then
            Label_LastPrice.Text = "没有找到"
        Else
            Label_LastPrice.Text = Price
        End If
    End Sub

    Sub SetComfirmpriceAndId(ByVal price As String, ByVal id As String)
        If price = "" Then
            Last_ComfirmPrice.Text = "没有找到"
        Else
            Last_ComfirmPrice.Text = price
        End If
        If id = "" Then
            Label_LastId.Text = "没有找到"
        Else
            Label_LastId.Text = id
        End If
    End Sub

    Delegate Sub DSetPrice(ByVal Price As String)

#Region "批量设置纸筒单价"

    Private Sub Cmd_SetZhiTong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetZhiTong.Click
        ShowGroup()
        Fg1.Rows.Count = 1
        Dim Z As Double = 0
        Dim P As Double = 0
        Dim j As Integer
        For i As Integer = 1 To Fg2.Rows.Count - 1
            Z = Val(Fg2.Item(i, "ZhiTong"))
            P = Val(Fg2.Item(i, "Price_ZhiTong"))

            For j = 1 To Fg1.Rows.Count - 1
                If Fg1.Item(j, "ZhiTong") = Z Then
                    If P <> 0 Then
                        Fg1.Item(j, "Price_ZhiTong") = P
                    End If
                    Exit For
                End If
            Next
            If j > Fg1.Rows.Count - 1 Then
                Dim k As Integer = 1
                For j = 1 To Fg1.Rows.Count - 1
                    If Fg1.Item(j, "ZhiTong") < Z Then
                        k = j + 1
                    End If
                Next
                Dim R As C1.Win.C1FlexGrid.Row = Fg1.AddItem("", k)
                R("ZhiTong") = Z
                R("Price_ZhiTong") = P
            End If
        Next
        Fg1.ReAddIndex()

    End Sub
    Sub ShowGroup()
        CaptureFromImageToPicture(Me, Panel2)
        Panel1.Enabled = False
        Panel2.BringToFront()
        GroupBox_P.Visible = False
        GroupBox_ZhiTong.Left = Panel1.Width / 2 - GroupBox_ZhiTong.Width / 2
        GroupBox_ZhiTong.Top = Panel1.Height / 2 - GroupBox_ZhiTong.Height / 2
        GroupBox_P.Left = Panel1.Width / 2 - GroupBox_ZhiTong.Width / 2
        GroupBox_P.Top = Panel1.Height / 2 - GroupBox_ZhiTong.Height / 2
        GroupBox_ZhiTong.Visible = True
        GroupBox_ZhiTong.BringToFront()
        Fg1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveDown
        Panel1.Visible = True
    End Sub

    Sub HideGroup()
        Panel1.Enabled = True
        Panel2.Visible = False
        Panel2.SendToBack()
    End Sub

    Private Sub Cmd_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Ok.Click
        GroupBox_ZhiTong.Visible = False
        GroupBox_P.Visible = True
        Panel2.Refresh()
        Dim Z As Double = 0
        Dim P As Double = 0
        If RadioButton1.Checked Then
            For i As Integer = 1 To Fg2.Rows.Count - 1
                Z = Val(Fg2.Item(i, "ZhiTong"))
                For j = 1 To Fg1.Rows.Count - 1
                    If Fg1.Item(j, "ZhiTong") = Z Then
                        Fg2.Item(i, "Price_ZhiTong") = Fg1.Item(j, "Price_ZhiTong")
                        UpdatePrcie(i)
                        ProgressBar1.Value = i * 100 / (Fg2.Rows.Count - 1)
                        ProgressBar1.Refresh()
                        Exit For
                    End If
                Next
            Next
        Else
            For i As Integer = 1 To Fg2.Rows.Count - 1
                Z = Val(Fg2.Item(i, "ZhiTong"))
                P = Val(Fg2.Item(i, "Price_ZhiTong"))
                For j = 1 To Fg1.Rows.Count - 1
                    If Fg1.Item(j, "ZhiTong") = Z Then
                        If P <> 0 Then
                            Fg2.Item(i, "Price_ZhiTong") = Fg1.Item(j, "Price_ZhiTong")
                            UpdatePrcie(i)
                            ProgressBar1.Value = i * 100 / (Fg2.Rows.Count - 1)
                            ProgressBar1.Refresh()
                        End If
                        Exit For
                    End If
                Next
            Next
        End If
        HideGroup()
    End Sub

    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        HideGroup()
    End Sub


#End Region

#Region "允许排序"
    Private Sub Cmd_CanSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CanSort.Click
        If Cmd_CanSort.Checked Then
            Fg2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn
        Else
            Fg2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        End If

    End Sub
#End Region


    Private Sub Label_LastId_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_LastId.DoubleClick
        Dim F As PClass.BaseForm = PClass.PClass.LoadModifyFormByID(50000)
        If F Is Nothing OrElse Label_LastId.Text = "没有找到" Then Exit Sub

        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = Label_LastId.Text
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnMsg = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf FindLastPrice
        VF.Show()
    End Sub


    Private Sub Cmd_ShowALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowALL.Click
        isShow(Cmd_ShowALL.Checked)
        My.Settings.Showall = Cmd_ShowALL.Checked
        My.Settings.Save()

    End Sub

    Private Sub isShow(ByVal isshow As Boolean)
        Fg2.Cols("BZSH_ID").Visible = isshow
        Fg2.Cols("GH").Visible = isshow
        Fg2.Cols("OrderBill").Visible = isshow
        Fg2.Cols("LuoSeDate").Visible = isshow
        Fg2.Cols("BZC_PF").Visible = isshow
        Fg2.Cols("BZ_No").Visible = isshow
        Fg2.Cols("CWeight").Visible = isshow
        Fg2.Cols("AddWeight").Visible = isshow
        Fg2.Cols("CSpec").Visible = isshow
        Fg2.Redraw = False
        Fg2.AutoSizeCols(1, Fg2.Cols.Count, 0)
        Fg2.Redraw = True
    End Sub





    Private Sub Btn_Auto_BZ_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Auto_BZ.CheckStateChanged
        Btn_Auto_JiaGongNeiRong.Visible = Btn_Auto_BZ.Checked
    End Sub


End Class

Partial Class Dao

    Public Const SQL_BZSH_GetList = "select L.* ,isnull(BZ.CP_No,BZ.BZ_No)as BZ_No,isnull(BZ.CP_Name,BZ.BZ_Name)as BZ_Name,BZC.BZC_No,BZC.BZC_Name from T40000_BZSH_table  T,T40001_BZSH_List  L left join T10002_BZ BZ on BZ.ID=L.BZ_ID left join T10003_BZC BZC on BZC.ID=L.BZC_ID where T.BZSH_ID=L.BZSH_ID and state<=2 and State>=0"
    Public Const BZSH_GetListByOption_OrderBy As String = " order by BZSH_Date,T.BZSH_ID,L.Line"

    ''' <summary>
    ''' 按条件获取送货单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZSH_GetListByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_BZSH_GetList)
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(BZSH_GetListByOption_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function


    Public Shared Function BZSH_UpdatePrice(ByVal BZSH_ID As String, ByVal Line As String, ByVal Price As Double, _
                                            ByVal Price_ZhiTong As Double, ByVal Amount As Double, ByVal Price_JiaoDai As Double, _
                                            ByVal Amount_ZhiTong As Double, ByVal Amount_JiaoDai As Double, ByVal Amount_GH As Double) As Boolean
        Dim p As New Dictionary(Of String, Object)
        p.Add("Line", Line)
        p.Add("BZSH_ID", BZSH_ID)
        p.Add("Price", Price)
        p.Add("Price_ZhiTong", Price_ZhiTong)
        p.Add("Amount", Amount)
        p.Add("Price_JiaoDai", Price_JiaoDai)
        p.Add("Amount_ZhiTong", Amount_ZhiTong)
        p.Add("Amount_JiaoDai", Amount_JiaoDai)
        p.Add("Amount_GH", Amount_GH)
        Return RunSQL("update T40001_BZSH_List set Price=@Price,Price_ZhiTong=@Price_ZhiTong,Amount=@Amount,Price_JiaoDai=@Price_JiaoDai," & _
                      "Amount_ZhiTong=@Amount_ZhiTong,Amount_JiaoDai=@Amount_JiaoDai,Amount_GH=@Amount_GH where  BZSH_ID=@BZSH_ID and Line=@Line" & vbCrLf & _
                      "update T40000_BZSH_table set SumAmount=Isnull((select sum(Amount_GH) from T40001_BZSH_List where BZSH_ID=@BZSH_ID),0) where BZSH_ID=@BZSH_ID", p).IsOk

    End Function

    Public Shared Function BZSH_GetLastPrice(ByVal BZC_ID As String, ByVal BZ_ID As String) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZ_ID", BZ_ID)
        P.Add("BZC_ID", BZC_ID)
        Return SqlStrToOneStr("select top 1  price  from T40001_BZSH_List where BZ_ID=@BZ_ID and BZC_ID=@BZC_ID and  price<>0  order by BZSH_ID desc ,line desc", P)
    End Function

    Public Shared Function Price_GetLastIDandprice(ByVal BZC_ID As String, ByVal BZ_ID As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZ_ID", BZ_ID)
        P.Add("BZC_ID", BZC_ID)
        Return SqlStrToDt("select top 1 ID, Price from T50001_Price_List where BZ_ID=@BZ_ID and BZC_ID=@BZC_ID and  IsComfirm=1 order by Price_Time desc", P)
    End Function




End Class