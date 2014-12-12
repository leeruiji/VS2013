Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport


Public Class F30000_Produce_Gd
    Public Const BillName As String = Dao.Produce_Gd_Name
    Dim selectedGoodsType As String = ""
    Dim selectNode As TreeNode
    Dim nodeMap As New Dictionary(Of String, Object)
    Dim dtProduce As DataTable

    Private Sub F30000_Produce_Gd_AfterLoad() Handles Me.AfterLoad
        FG1.FG_ColResize()
        SumFG1.AddSum()
    End Sub

    Private Sub F10000_Produce_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter AndAlso IsSel = True Then
            Me_Refresh()
        End If

    End Sub

    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If e.KeyChar = vbCr Then
            Dim R As MsgReturn = ComFun.GetGHForTM(TB_GH.TextBox.Text)
            If R.IsOk Then
                ModifyProduce(R.Msg)
            Else
                ShowErrMsg(R.Msg)
            End If
        End If
    End Sub

    Private Sub F10000_Produce_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                If TB_GH.Focused = False AndAlso DP_Start.Focused = False AndAlso Dp_End.Focused = False AndAlso TB_GH.Focused = False AndAlso TSC_Client.Focused = False AndAlso TSC_BZ.Focused = False AndAlso TSC_BZC.Focused = False Then
                    If e.KeyChar = Chr(System.Windows.Forms.Keys.Back) Then
                        If TB_GH.Text.Length > 0 Then
                            TB_GH.Text = TB_GH.Text.Substring(0, TB_GH.Text.Length - 1)
                        End If
                    Else
                    End If
                    TB_GH.Focus()
                End If
        End Select
    End Sub
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)
        Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
        Control_CheckRight(ID, ClassMain.FD, Cmd_FD)
        Control_CheckRight(ID, ClassMain.TP, Cmd_TP)
        Dim isShowPrice As Boolean = PClass.PClass.CheckRight(ID, ClassMain.ShowPrice)
        FG1.Cols("SumAmount").Visible = isShowPrice

        If CheckRight(ID, ClassMain.CanExcelOut) Then
            FG1.SetCanExcelOut()
        Else
            FG1.SetCanNotExcelOut()
        End If

    End Sub

    Private Sub F30000_Produce_Gd_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"
        '    Dim folist As List(Of FindOption) = Produce_GetConditionNames()

        DP_Start.Value = Today
        DP_End.Value = Today

        'TB_ConditionValue1.ComboBox.DisplayMember = "ConditionValue"
        'TB_ConditionValue1.ComboBox.ValueMember = "ConditionValue"

        'CB_ConditionName2.ComboBox.DisplayMember = ".Field"
        'CB_ConditionName2.ComboBox.ValueMember = ".DB_Field"
        'CB_ConditionValue2.ComboBox.DisplayMember = "ConditionValue"
        'CB_ConditionValue2.ComboBox.ValueMember = "ConditionValue"
        'CB_ConditionName2.ComboBox.DataSource = Produce_GetConditionNames()

        Me_Refresh()

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
        FG1.Visible = False
        Me.ShowLoading(MeIsLoad)
        T.Start(GetFindOtions)

    End Sub


    Sub SetData(ByVal msg As DtReturnMsg)
        If msg.IsOk Then
            msg.Dt.Columns.Add("StateName", GetType(String))

            If SelectRetrun Then
                dtProduce = TryCast(FG1.DataSource, DataTable)
                If dtProduce Is Nothing Then
                    dtProduce = msg.Dt
                Else
                    BaseClass.ComFun.DtReFreshRow(dtProduce, msg.Dt, "GH", ReturnId)
                End If
            Else
                dtProduce = msg.Dt
            End If
            If SelectRetrun Then
                SelectRetrun = False
            Else
                FG1.DtToFG(dtProduce)
            End If
            SumFG1.ReSum()
            Dim sumQty As Integer = 0
            Dim sumZL As Double = 0

            For Each dr As DataRow In Me.dtProduce.Rows
                sumQty += IsNull(dr("CR_LuoSeBzCount"), 0)
                sumZL += IsNull(dr("CR_LuoSeBzZL"), 0)

                If IsNull(dr("ClientBzc"), "") <> "" Then
                    dr("ClientBzc") = dr("ClientBzc") & "#"
                End If
                If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
                    dr("BZ_No") = ""
                End If
                If IsNull(dr("IsFD"), False) = True AndAlso IsNull(dr("BzcMsg"), "") = "" Then
                    dr("BzcMsg") = "返定"
                Else
                    If IsNull(dr("BzcMsg"), "") = "" Then

                        dr("BzcMsg") = dr("ClientBzc") & dr("BZC_Name") & "GY-" & Format(IsNull(dr("BZc_No"), ""), "000000") & dr("BZC_PF")
                    Else
                        dr("BzcMsg") = dr("BzcMsg").ToString.Replace(vbCrLf, "")
                    End If
                End If

                dr("StateName") = BaseClass.ComFun.GetProduceStateName(IsNull(dr("State"), Enum_ProduceState.AddNew))
            Next
            LB_Luose_Qty.Text = sumQty
            LB_LuoSe_ZL.Text = sumZL
            '  ConvertState()
            FG1.SortByLastOrder()
            FG1.RowSetForce("GH", ReturnId)
        Else
            FG1.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
    End Sub


    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.ProduceGd_GetByOption(oList)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)
#End Region



    Protected Sub ConvertState()
        If Me.dtProduce Is Nothing OrElse Me.dtProduce.Rows.Count <= 0 Then
            Exit Sub
        End If
        For Each dr In Me.dtProduce.Rows
            dr("StateName") = BaseClass.ComFun.GetProduceStateName(IsNull(dr("State"), Enum_ProduceState.AddNew))
        Next
    End Sub
    Public SelectRetrun As Boolean = False
    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            SelectRetrun = True
            Me_Refresh()
        End If
    End Sub


#Region "控件事件"

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        AddProduce()
    End Sub

    Protected Sub AddProduce()

        Dim F As New F30001_Produce_Gd_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)

        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        ModifyProduce()
    End Sub

    Protected Sub ModifyProduce(Optional ByVal GH As String = "")
        If GH = "" Then
            If FG1.RowSel <= 0 Then
                ShowMsg("请选择一个要修改的" & BillName, "")
                Exit Sub
            End If
            GH = FG1.SelectItem("GH")
        End If
        Dim F As New F30001_Produce_Gd_Msg(GH)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnGoods()
        Else
            ModifyProduce()
        End If

    End Sub

    Protected Sub ReturnGoods()
        Me.LastForm.ReturnId = FG1.SelectItem("GH")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If FG1.RowSel <= 0 Then
            ShowMsg("请选择一个要删除的" & BillName, "")
            Exit Sub
        End If
        ShowConfirm("是否删除" & BillName & " [" & FG1.Item(FG1.RowSel, "GH") & "]?", AddressOf DelProduce)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelProduce()

        Dim msg As MsgReturn = Dao.ProduceGd_Del(FG1.SelectItem("GH"))
        If msg.IsOk Then
            ReturnId = FG1.SelectItem("GH")

            Edit_Retrun()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub



#End Region

    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles TSC_Client.Col_Sel
        If TSC_BZ.SearchID <> ID Then
            TSC_BZ.Text = ""
            TSC_BZ.IDValue = 0

            TSC_BZC.Text = ""
            TSC_BZC.IDValue = 0
        End If
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZ.SearchID = ID

        TSC_BZC.SearchType = cSearchType.ENum_SearchType.Client
        TSC_BZC.SearchID = ID
    End Sub

    Private Sub TSC_Client_SetEmpty() Handles TSC_Client.SetEmpty
        TSC_Client.IDValue = 0
        TSC_BZ.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZ.SearchID = 0


        TSC_BZC.SearchType = cSearchType.ENum_SearchType.ALL
        TSC_BZC.SearchID = 0
    End Sub



#Region "FG事件"

    Private Sub FG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FG1.KeyDown

        If e.KeyCode = Keys.Enter Then

            If FG1.RowSel <= 0 Then
                ShowMsg("请选择一个" & BillName, "")
                Exit Sub
            End If

            If IsSel Then
                ReturnGoods()
            Else
                ModifyProduce()
            End If
        End If
    End Sub

    Private Sub FG1_SelectRowChange(ByVal Row As Integer) Handles FG1.SelectRowChange
        If FG1.SelectItem Is Nothing Then
            Exit Sub
        End If
        If IsNull(FG1.SelectItem("State"), Enum_ProduceState.AddNew) = Enum_ProduceState.AddNew Then
            Cmd_Del.Enabled = True

        Else
            Cmd_Del.Enabled = False
        End If
    End Sub
#End Region


#Region "搜索工具栏"


    ''' <summary>
    ''' 点击查询
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me_Refresh()
    End Sub



    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption

        fo = New FindOption
        fo.DB_Field = "Date_Kaidan"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = Dp_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)

        If Val(TSC_Client.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "P.Client_ID"
            fo.Value = TSC_Client.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Val(TSC_BZC.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "P.BZC_ID"
            fo.Value = TSC_BZC.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If Val(TSC_BZ.IDValue) <> 0 Then
            fo = New FindOption
            fo.DB_Field = "P.BZ_ID"
            fo.Value = TSC_BZ.IDValue
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        If SelectRetrun Then
            fo = New FindOption
            fo.DB_Field = "GH"
            fo.Value = Me.ReturnId
            fo.Field_Operator = Enum_Operator.Operator_Equal
            oList.FoList.Add(fo)
        End If

        Return oList
    End Function
#End Region

#Region "报表事件"

    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一张运转单!")
            Exit Sub
        End If
        Dim R As New R30000_ProduceGd(CheckRight(ID, ClassMain.CanExcelOut))
        R.Start(FG1.SelectItem("GH"), DoOperator)
        '  R.Start(Dt_Produce, DoOperator)
    End Sub

#End Region



    Private Sub Cmd_FD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FD.Click
        Dim F As New F30005_Produce_FD
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
#Region "退胚"
    Private Sub Cmd_TB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_TP.Click
        Dim F As New F30006_Produce_TP
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
#End Region

End Class


Partial Class Dao



    ''' <summary>
    ''' 按条件获取运转单
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProduceGd_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_ProduceGd_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_ProduceGd_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function





End Class