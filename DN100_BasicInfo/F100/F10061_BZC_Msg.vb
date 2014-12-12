Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass

Public Class F10061_BZC_Msg
    Dim LId As String = ""
    Dim PID As String = ""
    Dim Bzc_Id As Integer = 0
    Dim Dt_Bzc As DataTable
    Dim Dt_Bz_Link As DataTable
    Dim DtPF As DataTable
    Dim DtPFList As DataTable
    Dim TD As Date = GetDate()
    Dim FG_SEL As String = "FG1"

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal goodsID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Bzc_Id = Val(goodsID)
        Me.Mode = Mode
    End Sub
    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name AndAlso Me.ActiveControl.Name <> Fg2.Name AndAlso ActiveControl.Parent.Name <> Fg2.Name AndAlso Me.ActiveControl.Name <> Fg3.Name AndAlso ActiveControl.Parent.Name <> Fg3.Name Then
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

        Control_CheckRight(10020, ClassMain.Modify, Cmd_Modify)
        ' Control_CheckRight(10020, ClassMain.Del, Cmd_Del)
        ToolStripButton_CopyVi_RL.Visible = Cmd_Modify.Visible
    End Sub


    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        Dao.DelNewBzc_No(PID)
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load

        Fg1.Cols("BZ_No").Editor = CB_BZ_FG

        FormCheckRight()
        Fg1.Rows.Count = 1
        Fg3.IniColsSize()
        Fg2.IniColsSize()
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            'FG2_HideAll()
            ToolStripButton_CopyVi_RL.Enabled = False
            If CheckRight(10020, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            Bzc_Id = 0
            GetNewID()
            CB_BZ.Enabled = False
            Fg3.Cols("UpdQty").Visible = False
            Cmd_CopyPF.Enabled = False
            Fg2.Rows.Count = 1
            Fg3.Rows.Count = 1
            DP_Found_Date.Value = GetDate()

        Else
            LId = TB_BZC_No.Text
            ToolStripButton_CopyVi_RL.Enabled = True
            'TB_ID.ReadOnly = True
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.BZC_GetById(Bzc_Id)
        If msg.IsOk Then
            Dt_Bzc = msg.Dt
            SetForm(msg.Dt)
        End If
        If Mode = Mode_Enum.Add Then
            Dim T As New Threading.Thread(AddressOf GetDateTable)
            T.Start()
        Else
            Dim msg1 As DtReturnMsg = Dao.BZC_Bz_Link_GetById(Bzc_Id)
            If msg1.IsOk Then
                Dt_Bz_Link = msg1.Dt
                Fg1.DtToSetFG(Dt_Bz_Link)
            End If
            GetPF()
            If Fg2.RowSel > 0 Then
                GetPFLIst()
            Else
                Fg3.Rows.Count = 1
            End If
        End If
    End Sub

    Public Sub GetPF()
        Dim msg2 As DtReturnMsg = Dao.BZCPF_GetPFListByBZCID(Bzc_Id)
        If msg2.IsOk Then
            DtPF = msg2.Dt
        End If
        MeIsLoad = False
        Fg2.DtToSetFG(DtPF)
        If ReturnId <> "" Then Fg2.RowSetForce("PF_Name", ReturnId)
        If Fg2.Rows.Count > 1 AndAlso Fg2.RowSel <= 0 Then
            Fg2.Row = 1
            Fg2.RowSel = 1
        End If
        MeIsLoad = True
        GetPFLIst()
    End Sub

    Protected Sub GetPFLIst()
        If Fg2.RowSel >= Fg2.Rows.Fixed Then
            Dim msg3 As DtReturnMsg = Dao.BZCPF_GeList_ByID(Fg2.Item(Fg2.RowSel, "ID"), Bzc_Id)
            If msg3.IsOk Then
                DtPFList = msg3.Dt
            End If
            Fg3.DtToSetFG(DtPFList)
            If Fg2.Item(Fg2.RowSel, "IsCheck") = True Then
                Fg3.Cols("UpdQty").Visible = True
            Else
                Fg3.Cols("UpdQty").Visible = False
            End If
        End If
    End Sub


    Sub GetDateTable()
        Dim msg1 As DtReturnMsg = Dao.BZC_Bz_Link_GetById(Bzc_Id)
        If msg1.IsOk Then
            Dt_Bz_Link = msg1.Dt
        End If

        'Dim msg2 As DtReturnMsg = BZC_BZC_PF_GetById(Bzc_Id)
        'If msg2.IsOk Then
        '    DtPF = msg2.Dt
        'End If
    End Sub


#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = Dt_Bzc.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
            If Mode <> Mode_Enum.Add Then dt.Rows(0)("ID") = Bzc_Id
            dt.Rows(0)("BZC_No") = StrConv(TB_BZC_No.Text, vbNarrow)
            dt.Rows(0)("BZC_Name") = TB_Name.Text
            dt.Rows(0)("BZC_Remark") = TB_Remark.Text
            dt.Rows(0)("Client_id") = CB_Client.IDValue
            dt.Rows(0)("Qian_ChuLi") = TB_Qian_ChuLi.Text
            dt.Rows(0)("BZ_Id") = CB_BZ.IDValue
            dt.Rows(0)("Client_Bzc") = StrConv(TB_Client_Bzc.Text, vbNarrow)
            dt.Rows(0)("BZC_FindHelper") = StrGetPinYin(TB_Name.Text)

            dt.Rows(0)("Found_Date") = Format(DP_Found_Date.Value, "yyyy-MM-dd")
            dt.Rows(0)("UPD_USER") = PClass.PClass.User_Id
            dt.Rows(0)("UPD_DATE") = Today
            dt.Rows(0)("RanSe") = CB_RanSe.Text

        End If



        Dt_Bz_Link = Dt_Bz_Link.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Dt_Bz_Link.Select("BZ_Id='" & Fg1.Item(i, "BZ_Id") & "'").Length = 0 Then
                Dim Dr As DataRow = Dt_Bz_Link.NewRow
                Dr("BZC_ID") = Bzc_Id
                Dr("BZ_Id") = Fg1.Item(i, "BZ_Id")
                Dr("Client_Bzc") = Fg1.Item(i, "Client_Bzc")
                If Fg1.Item(i, "PF_ID") IsNot Nothing AndAlso Val(Fg1.Item(i, "PF_ID")) <> 0 Then
                    Dr("PF_ID") = Fg1.Item(i, "PF_ID")
                End If
                Dt_Bz_Link.Rows.Add(Dr)
            End If
        Next
        Dt_Bz_Link.AcceptChanges()


        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_BZC_No.Text = IsNull(dt.Rows(0)("BZC_No"), "")

            TB_Name.Text = IsNull(dt.Rows(0)("BZC_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("BZC_Remark"), "")
            TB_Qian_ChuLi.Text = IsNull(dt.Rows(0)("Qian_ChuLi"), "")


            CB_Client.IDValue = IsNull(dt.Rows(0)("Client_id"), "0")
            CB_Client.Text = CB_Client.GetByTextBoxTag()
            Label_Client_Name.Text = CB_Client.NameValue


            CB_BZ_FG.SearchID = IsNull(dt.Rows(0)("Client_id"), 0)
            CB_BZ_FG.SearchType = cSearchType.ENum_SearchType.Client

            CB_BZ.SearchID = IsNull(dt.Rows(0)("Client_id"), 0)
            CB_BZ.SearchType = cSearchType.ENum_SearchType.Client

            CB_BZ.IDValue = IsNull(dt.Rows(0)("BZ_Id"), "0")
            CB_BZ.Text = CB_BZ.GetByTextBoxTag()
            TB_BZ_Name.Text = CB_BZ.NameValue

            TB_Client_Bzc.Text = IsNull(dt.Rows(0)("Client_Bzc"), "")
            If IsNull(dt.Rows(0)("PF_Count"), 0) > 0 Then
                TB_BZC_No.ReadOnly = True
            End If


            TB_UPD_USER.Text = PClass.PClass.UserIDtoDisplayName(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Value = dt.Rows(0)("UPD_DATE")
            End If
            CB_RanSe.Text = IsNull(dt.Rows(0)("RanSe"), "")
        Else
            TB_BZC_No.Text = Me.Bzc_Id
            TB_Name.Text = ""
            TB_UPD_USER.Text = ""
        End If
    End Sub

#End Region

#Region "工具栏,按钮"



    Private Sub Btn_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddRow.Click
        If Val(CB_Client.IDValue) = 0 Then
            ShowErrMsg("请选一个客户", AddressOf CB_Client.Focus)
        Else
            Fg1.AddRow()
        End If
    End Sub

    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub



    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存颜色[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.BZC_Add(GetForm(), Dt_Bz_Link)
        Else
            R = Dao.BZC_Save(GetForm(), Dt_Bz_Link)
        End If
        If R.IsOk Then
            LId = TB_BZC_No.Text
            LastForm.ReturnId = TB_BZC_No.Text
            Mode = Mode_Enum.Modify
            If TB_BZC_No.Text = PID.Replace("-", "") Then PID = ""
            ShowConfirm(R.Msg & ",是否继续编辑?", AddressOf ReFreshBzcNo, AddressOf Me.Close)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub

    Sub ReFreshBzcNo()
        If Bzc_Id = "0" Then
            Dim r As DtReturnMsg = Dao.BZC_GetByNo(TB_BZC_No.Text)
            If r.IsOk Then
                If r.Dt.Rows.Count > 0 Then
                    Bzc_Id = r.Dt.Rows(0)(0)
                Else
                    ShowErrMsg("没有找到色号[" & TB_BZC_No.Text & "]", True)
                End If
            Else
                ShowErrMsg(r.Msg, True)
            End If
        End If
        Me_Refresh()
    End Sub

    Protected Function CheckForm() As Boolean
        Dim msg As String = ""
        If TB_BZC_No.Text = "" Then
            ShowErrMsg("色号编号不能为空", AddressOf TB_BZC_No.Focus)
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("色号名称不能为空", AddressOf TB_Name.Focus)
            Return False
        End If
        If Val(CB_BZ.IDValue) = 0 Then
            ShowErrMsg("布种编号不能为空", AddressOf CB_BZ.Focus)
            Return False
        End If
        'If TB_Client_Bzc.Text = "" Then
        '    ShowErrMsg("布行色号不能为空", AddressOf TB_Client_Bzc.Focus)
        '    Return False
        'End If
        If Val(CB_Client.IDValue) = 0 Then
            ShowErrMsg("客户编号不能为空", AddressOf CB_Client.Focus)
            Return False
        End If
        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Fg1.Item(i, "BZ_Id") Is Nothing OrElse Fg1.Item(i, "BZ_Id").ToString = "" Then
                    Fg1.Rows.Remove(i)
                ElseIf Fg1.Item(i, "Bz_Name") Is Nothing OrElse Fg1.Item(i, "Bz_Name").ToString = "" Then
                    Fg1.Rows.Remove(i)
                End If
            Catch ex As Exception
            End Try
        Next
        'For i As Integer = Fg3.Rows.Count - 1 To 1 Step -1
        '    If Fg3.Item(i, "WL_ID") Is Nothing OrElse Fg3.Item(i, "WL_ID").ToString = "" Then
        '        Try
        '            Fg3.Rows.Remove(i)
        '        Catch ex As Exception
        '        End Try
        '    ElseIf Fg3.Item(i, "WL_Name") Is Nothing OrElse Fg3.Item(i, "WL_Name").ToString = "" Then
        '        Try
        '            Fg3.Rows.Remove(i)
        '        Catch ex As Exception
        '        End Try
        '    End If
        'Next
        'Dim H As Integer = 0
        'For i As Integer = Fg2.Cols.Count - 1 To 3 Step -1
        '    If Fg2.Cols(i).Visible = True Then
        '        If Fg2.Item(3, i) Is Nothing OrElse Fg2.Item(3, i).ToString = "" Then
        '            If H > 0 Then
        '                For j As Integer = i To H
        '                    Fg2.Item(1, j) = Fg2.Item(1, j + 1)
        '                    Fg2.Item(2, j) = Fg2.Item(2, j + 1)
        '                    Fg2.Item(3, j) = Fg2.Item(3, j + 1)
        '                    For k As Integer = 1 To Fg3.Rows.Count - 1
        '                        Fg3.Item(k, j) = Fg3.Item(k, j + 1)
        '                    Next
        '                Next
        '            Else
        '                H = i
        '            End If
        '            Fg2.Cols(H).Visible = False
        '            Fg3.Cols(H).Visible = False
        '            H = i
        '        Else
        '            If H = 0 Then
        '                H = i
        '            End If
        '        End If
        '    End If
        'Next
        Me.Refresh()
        Return True
    End Function






    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowConfirm("是否删除色号[" & TB_BZC_No.Text & "]?", AddressOf DelBZC)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelBZC()
        Dim msg As MsgReturn = Dao.BZC_Del(Bzc_Id)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub



    Private Sub ToolStripButton_CopyVi_RL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_CopyVi_RL.Click
        Me.ShowConfirm("是否复制一个新的色号?", AddressOf Bzc_Copy)

    End Sub

    Sub Bzc_Copy()
        If CheckRight(10020, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
        Mode = Mode_Enum.Add
        GetNewID()
        TB_BZC_No.Text = Bzc_Id
        TB_BZC_No.ReadOnly = False
        Cmd_CopyPF.Enabled = False
        ToolStripButton_CopyVi_RL.Enabled = False
        Fg2.Rows.Count = 1
        Fg3.Rows.Count = 1
    End Sub



#End Region

#Region "FG1事件"

    Private Sub Fg1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.GotFocus
        FG_SEL = "FG1"
    End Sub

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "BZ_No"
                e.ToCol = Fg1.Cols("Client_Bzc").Index
            Case "Client_Bzc"
                If e.Row + 2 > Fg1.Rows.Count Then
                    Fg1.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("BZ_No").Index
        End Select
    End Sub


    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Col = Fg1.Cols("BZ_No").Index Then
            If Fg1.LastKey = Keys.Enter Then
                ' Fg1.Item(e.Row, "BZ_Name") = ""
                CB_BZ_FG.Col_SelOne()
                If Fg1.Item(e.Row, "BZ_Name") = "" Then
                    ShowErrMsg("请输入一个布种编号!", AddressOf FG_BZ_No)
                End If
            Else
                '非正当离开时候清空
                If Fg1.LastText <> IsNull(Fg1.Item(e.Row, "BZ_No"), "") AndAlso IsBZSelect = False Then Fg1.Item(e.Row, "BZ_Name") = ""
                IsBZSelect = False
            End If
        Else
            If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell()
        End If
    End Sub
#Region "BZ选择"
    Dim IsBZSelect As Boolean
    Private Sub CB_BZ_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ_FG.Col_Sel
        IsBZSelect = True
        Fg1.Item(Fg1.RowSel, "BZ_Name") = Col_Name
        Fg1.Item(Fg1.RowSel, "BZ_ID") = ID
        Fg1.GotoNextCell("BZ_No")
    End Sub
    Private Sub CB_BZ_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_BZ_FG.GetSearchEvent
        CB_BZ_FG.IDValue = Fg1.Item(Fg1.RowSel, "BZ_ID")
    End Sub

    Sub FG_BZ_No()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("BZ_No").Index)
    End Sub
#End Region
 

#End Region

#Region "FG2事件"

    Private Sub Fg2_SelectRowChange(ByVal Row As Integer) Handles Fg2.SelectRowChange
        If MeIsLoad Then GetPFLIst()
    End Sub

    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If Fg2.Item(Fg2.RowSel, "ID") Is Nothing AndAlso Fg2.Item(Fg2.RowSel, "ID") = "" Then
            Exit Sub
        End If
        Dim _pfID As Integer = Val(Fg2.Item(Fg2.RowSel, "ID"))
        ModifyPF(_pfID)
    End Sub

    Private Sub Fg3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg3.DoubleClick
        Fg2_DoubleClick(Fg2, e)
    End Sub
#End Region

#Region "双击获取新编号"
    'Private Sub Label_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
    '    If Mode = Mode_Enum.Add Then
    '        TB_ID.Text = Dao.GetNewBzc_No()
    '        TB_Name.Focus()
    '    End If
    'End Sub
#End Region

#Region "获取新单号"
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If TB_BZC_No.ReadOnly Then
            ShowConfirm("是否获取新色号?", AddressOf GetNewID)
        Else
            ShowErrMsg("非新增状态不能修改色号!")
        End If
    End Sub

    Sub GetNewID()
        If TB_BZC_No.ReadOnly = False Then
            Dim R As RetrunNewIdMsg = Dao.GetNewBzc_No(PID)
            If R.IsOk Then
                PID = R.NewID
                TB_BZC_No.Text = PID.Replace("-", "")
            Else
                ShowErrMsg(R.RetrunMsg)
            End If
        End If
    End Sub



#End Region



#Region "新增，修改配方（色板）"
    Private Sub Cmd_PF_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PF_Add.Click
        If Me.Mode = Mode_Enum.Add Then
            ShowErrMsg("请先保存色号资料！")
            Exit Sub
        End If
        AddPF()
    End Sub

    Protected Sub AddPF()
        Dim F As New F10022_BZC_PF(Bzc_Id)
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

    Protected Sub ModifyPF(ByVal _PFID As Integer)
        Dim F As New F10022_BZC_PF(_PFID, Bzc_Id)
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

    Public Sub Edit_Retrun()
        LastForm.ReturnId = TB_BZC_No.Text
        Me.Me_Refresh()
    End Sub


    ''' <summary>
    ''' 复制当前选择的色板
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_CopyPF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CopyPF.Click
        If Fg2.RowSel <= 0 Then Exit Sub
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If Fg2.Item(Fg2.RowSel, "ID") Is Nothing AndAlso Fg2.Item(Fg2.RowSel, "ID") = "" Then
            Exit Sub
        End If
        Dim _pfID As Integer = Val(Fg2.Item(Fg2.RowSel, "ID"))
        Dim F As New F10022_BZC_PF(_pfID, Bzc_Id, True)
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

    Private Sub Cmd_PF_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_PF_Remove.Click
        If Fg2.RowSel > 0 Then
            ShowConfirm("确定要删除色板[" & Fg2.Item(Fg2.RowSel, "PF_Name") & "]?", AddressOf DELPF)
        End If
    End Sub
    Protected Sub DELPF()
        Dim msg As MsgReturn = Dao.BZCPF_Del(Fg2.Item(Fg2.RowSel, "ID"), Me.Bzc_Id)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg)
        Else
            GetPF()
        End If
    End Sub
#End Region

#Region "客户和布种"

    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel
        Label_Client_Name.Text = Col_Name
        If CB_BZ.SearchID <> ID Then
            CB_BZ.Text = ""
            CB_BZ.SetSearchEmpty()
            TB_BZ_Name.Text = ""
        End If
        CB_BZ.Enabled = True
        CB_BZ.SearchID = ID
        CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
        CB_BZ_FG.SearchID = ID
        CB_BZ_FG.SearchType = cSearchType.ENum_SearchType.Client
    End Sub
    Private Sub CB_BZ_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ.Col_Sel
        TB_BZ_Name.Text = Col_Name
    End Sub

#End Region

 
 

    Private Sub Cmd_ClientChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ClientChoose.Click
        If Fg2.RowSel < 1 Then
            ShowErrMsg("请选择一个配方")
        End If
        Fg2.Item(Fg2.RowSel, "IsOK") = Not Fg2.Item(Fg2.RowSel, "IsOK")
        For i As Integer = 1 To Fg2.Rows.Count - 1
            If i <> Fg2.RowSel Then
                Fg2.Item(i, "IsOK") = False
            End If
        Next
        Dim R As MsgReturn = BZC_PF_UpDate(Bzc_Id, Fg2.Item(Fg2.RowSel, "ID"), Fg2.Item(Fg2.RowSel, "IsOK"))
        LastForm.ReturnId = TB_BZC_No.Text
    End Sub
  





End Class

Partial Class Dao
    '    '#Region "常量"
    '    '    ''' <summary>
    '    '    ''' 获取编号
    '    '    ''' </summary>
    '    '    ''' <remarks></remarks>
    '    '    Public Const SQL_BZCPF_GetPFID = "declare @A Varchar(20)" & vbCrLf & _
    '    '       "if exists (select * from  T10010_BZC_PF where BZC_ID=@BZC_ID and PF_Name=@PF_Name)" & vbCrLf & _
    '    '       "set @A=0" & vbCrLf & _
    '    '       "else" & vbCrLf & _
    '    '       "begin" & vbCrLf & _
    '    '       "insert into T10010_BZC_PF (BZC_ID,PF_Name)values(@BZC_ID,@PF_Name)" & vbCrLf & _
    '    '       "set @A=@@identity" & vbCrLf & _
    '    '       "end" & vbCrLf & _
    '    '       "select @A"


    '    '    Public Const BZCPF_DB_NAME As String = "色板"

    '    '    Public Const SQL_BZCPF_GetByID = "select * from T10010_BZC_PF where  BZC_ID= @BZC_ID and ID=@ID  "

    '    '    Public Const SQL_BZCPF_GeList_ByIDWithName = "select P.*,WL_Name,WL_No,WL_Spec from T10011_BZC_PFList  P left join T10001_WL W on P.WL_ID=W.ID where BZC_ID= @BZC_ID and P.ID=@ID "

    '    '    Public Const SQL_BZCPF_GeList_ByID = "select * from T10011_BZC_PFList where  BZC_ID= @BZC_ID and ID=@ID "



    '    '    Public Const SQL_BZCPF_GetPFListByBZCID = "select * from T10010_BZC_PF where BZC_ID= @BZC_ID  "

    '    '    Public Const SQL_BZCPF_GetPF_List_ByBZCID = "select   L.*,W.WL_No ,W.WL_Name,W.WL_Unit,W.WL_Spec from  T10011_BZC_PFList L  left join T10001_WL W on L.WL_ID=W.ID where L.ID=@PFID"

    '    '    Public Const SQL_BZCPF_Del = "delete from T10010_BZC_PF where  BZC_ID= @BZC_ID  and  ID=@ID and IsCheck=0 "

    '    '#End Region


    '    ''' <summary>
    '    ''' 获取无日期编号
    '    ''' </summary>
    '    ''' <param name="LastNo">上次日期</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function GetNewBzc_No(ByVal LastNo As String) As RetrunNewIdMsg
    '        Dim R As New RetrunNewIdMsg
    '        Dim BillStart As String = ""
    '        Dim BillLong As Integer = 6
    '        Dim P As New Dictionary(Of String, Object)

    '        DelNewBzc_No(LastNo)


    '        R.IsTheDate = True
    '        R.RetrunMsg = "获取单号成功"

    '        Dim MR As MsgReturn = SqlStrToOneStr("GetNewBzc_No")
    '        If MR.IsOk = True Then
    '            R.IsOk = True
    '            R.NewID = "-" & MR.Msg
    '        Else
    '            R.IsOk = False
    '            R.RetrunMsg = "获取单号失败"
    '        End If
    '        Return R
    '    End Function


    '    Public Shared Sub DelNewBzc_No(ByVal LastNo As String)
    '        If LastNo <> "" Then
    '            Dim P As New Dictionary(Of String, Object)
    '            Dim s() As String = LastNo.Split("-")
    '            If s.Length > 1 Then '检查旧的单号是否存在
    '                Dim BillTable As String = "T10003_BZC"
    '                Dim Mr1 As MsgReturn = SqlStrToOneStr("select count(*) from " & BillTable & " where id=@id", "@ID", LastNo.Replace("-", ""))
    '                If Mr1.IsOk Then
    '                    P.Add("@Type", "10003")

    '                    Try
    '                        P.Add("@sDate", "2011-1-1")
    '                        P.Add("@sIndex", Val(s(1)))
    '                        RunSQL("update Bill_Index set sIndex=sIndex-1 where Type=@Type and sDate=@sDate and sIndex=@sIndex", P)
    '                    Catch ex As Exception
    '                    End Try
    '                End If
    '            End If
    '        End If
    '    End Sub

    '    Public Shared Function BZCPF_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
    '        Dim R As New MsgReturn
    '        Dim msg As New DtListReturnMsg
    '        Dim sqlMap As New Dictionary(Of String, String)
    '        Dim paraMap As New Dictionary(Of String, Object)


    '        Dim BZCID As String = Val(dtTable.Rows(0)("BZC_ID"))
    '        Dim PFID As String = BZCPF_GetPFID(BZCID, dtTable.Rows(0)("PF_Name"))
    '        If PFID = 0 Then
    '            R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]已经存在!请检查后重新保存"
    '            Return R
    '        Else
    '            dtTable.Rows(0)("ID") = PFID
    '            For Each row As DataRow In dtList.Rows
    '                row("ID") = PFID
    '            Next
    '        End If
    '        paraMap.Add("ID", PFID)
    '        paraMap.Add("BZC_ID", BZCID)
    '        Try
    '            sqlMap.Add("Table", SQL_BZCPF_GetByID)
    '            sqlMap.Add("List", SQL_BZCPF_GeList_ByID)
    '            msg = SqlStrToDt(sqlMap, paraMap)
    '            If msg.DtList("Table").Rows.Count = 1 Then
    '                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
    '                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
    '                DtToUpDate(msg)
    '                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加成功!"
    '                R.IsOk = True
    '            Else
    '                R.IsOk = False
    '                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加错误!"
    '            End If
    '            Return R
    '        Catch ex As Exception
    '            Try
    '                RunSQL(SQL_BZCPF_Del, paraMap)
    '            Catch ex1 As Exception
    '            End Try
    '            R.IsOk = False
    '            R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加错误!"
    '            DebugToLog(ex)
    '            Return R
    '        Finally
    '        End Try

    '    End Function

    '    Public Shared Function BZCPF_GetPFID(ByVal BZC_ID As String, ByVal PF_Name As String) As Integer
    '        Dim R As New MsgReturn
    '        Dim para As New Dictionary(Of String, Object)
    '        para.Add("@BZC_ID", BZC_ID)
    '        para.Add("@PF_Name", PF_Name)
    '        R = PClass.PClass.SqlStrToOneStr(SQL_BZCPF_GetPFID, para)
    '        If R.IsOk Then
    '            Return Val(R.Msg)
    '        Else
    '            Return 0
    '        End If
    '    End Function


    '    Public Shared Function BZCPF_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
    '        Dim R As New MsgReturn


    '        Dim msg As New DtListReturnMsg
    '        Dim sqlMap As New Dictionary(Of String, String)
    '        Dim paraMap As New Dictionary(Of String, Object)
    '        Dim PFID As String = Val(dtTable.Rows(0)("ID"))
    '        Dim BZCID As String = Val(dtTable.Rows(0)("BZC_ID"))
    '        paraMap.Add("ID", PFID)
    '        paraMap.Add("BZC_ID", BZCID)
    '        Try
    '            sqlMap.Add("Table", SQL_BZCPF_GetByID)
    '            sqlMap.Add("List", SQL_BZCPF_GeList_ByID)


    '            msg = SqlStrToDt(sqlMap, paraMap)
    '            If msg.DtList("Table").Rows.Count = 1 Then

    '                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
    '                DvToDt(dtList, msg.DtList("List"), New List(Of String))
    '                DtToUpDate(msg)
    '                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]修改成功!"
    '                R.IsOk = True
    '            Else
    '                R.IsOk = False
    '                R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]不存在!"
    '            End If
    '            Return R
    '        Catch ex As Exception
    '            R.IsOk = False
    '            R.Msg = "" & BZCPF_DB_NAME & "[" & dtTable.Rows(0)("PF_Name") & "]添加错误!"
    '            DebugToLog(ex)
    '            Return R
    '        Finally
    '        End Try

    '    End Function



    '    Public Shared Function BZCPF_GetTable_ByID(ByVal _ID As Integer, ByVal _BZC_ID As Integer) As DtReturnMsg
    '        Dim R As New DtReturnMsg
    '        Dim sql As String = SQL_BZCPF_GetByID
    '        Dim para As New Dictionary(Of String, Object)
    '        para.Add("@ID", _ID)
    '        para.Add("@BZC_ID", _BZC_ID)


    '        R = PClass.PClass.SqlStrToDt(sql, para)
    '        Return R
    '    End Function


    '    Public Shared Function BZCPF_GeList_ByID(ByVal _ID As Integer, ByVal _BZC_ID As Integer) As DtReturnMsg
    '        Dim R As New DtReturnMsg
    '        Dim sql As String = SQL_BZCPF_GeList_ByIDWithName


    '        Dim para As New Dictionary(Of String, Object)
    '        para.Add("@ID", _ID)
    '        para.Add("@BZC_ID", _BZC_ID)


    '        R = PClass.PClass.SqlStrToDt(sql, para)
    '        Return R
    '    End Function




    '    ''' <summary>
    '    ''' 获取默认色板配方
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZCPF_GetPF_List_ByBZCID(ByVal _PFID As Integer)
    '        Return PClass.PClass.SqlStrToDt(SQL_BZCPF_GetPF_List_ByBZCID, "@PFID", _PFID)
    '    End Function


    '    ''' <summary>
    '    ''' 
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZCPF_GetPFListByBZCID(ByVal _BZCID As Integer)
    '        Return PClass.PClass.SqlStrToDt(SQL_BZCPF_GetPFListByBZCID, "@BZC_ID", _BZCID)
    '    End Function


    '    Public Shared Function BZCPF_CheckName(ByVal _ID As Integer, ByVal _BZC_ID As Integer, ByVal _PFName As String)
    '        Dim sql As String = "select 1 from T10010_BZC_PF where BZC_ID=@BZC_ID and  PF_Name=@PF_Name and ID<>@ID"
    '        Dim R As New MsgReturn
    '        Dim para As New Dictionary(Of String, Object)
    '        para.Add("@ID", _ID)
    '        para.Add("@BZC_ID", _BZC_ID)
    '        para.Add("@PF_Name", _PFName)
    '        Dim msg As DtReturnMsg = PClass.PClass.SqlStrToDt(sql, para)
    '        If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
    '            R.IsOk = True
    '        Else
    '            R.IsOk = False
    '            R.Msg = "色板名称[" & _PFName & "]已经存在！"
    '        End If
    '        Return R
    '    End Function

    '    Public Shared Function BZCPF_Del(ByVal _ID As Integer, ByVal _BZC_ID As Integer) As MsgReturn
    '        Dim R As New MsgReturn
    '        Dim sql As String = SQL_BZCPF_Del


    '        Dim para As New Dictionary(Of String, Object)
    '        para.Add("@ID", _ID)
    '        para.Add("@BZC_ID", _BZC_ID)


    '        R = PClass.PClass.RunSQL(sql, para)
    '        Return R
    '    End Function



    '    ''' <summary>
    '    ''' 审核入库单
    '    ''' </summary>
    '    ''' <param name="_ID"></param>
    '    ''' <param name="IsAudited">审核还是反审核</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZCPF_Audited(ByVal BZC_ID As Integer, ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
    '        Dim paraMap As New Dictionary(Of String, Object)
    '        paraMap.Add("BZC_ID", BZC_ID)
    '        paraMap.Add("ID", _ID)
    '        paraMap.Add("IsAudited", IsAudited)
    '        paraMap.Add("State_User", User_Display)
    '        Dim R As MsgReturn = SqlStrToOneStr("P10010_BZC_PF_Audited", paraMap, True)
    '        If R.IsOk Then
    '            If R.Msg.StartsWith("1") Then
    '                R.IsOk = True
    '            Else
    '                R.IsOk = False
    '            End If
    '            R.Msg = R.Msg.Substring(1)
    '        End If
    '        Return R
    '    End Function

    '#Region "布种色号"

    '    ''' <summary>
    '    ''' 获取所有布种色号信息
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_GetAll() As DtReturnMsg

    '        Return PClass.PClass.SqlStrToDt(SQL_BZC_Get)
    '    End Function

    '    ''' <summary>
    '    ''' 获取查询条件集合
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_GetConditionNames() As List(Of FindOption)
    '        Dim foList As New List(Of FindOption)
    '        Dim fo As New FindOption
    '        fo.Field = "请选择"
    '        fo.DB_Field = ""
    '        foList.Add(fo)

    '        fo = New FindOption
    '        fo.Field = "色号"
    '        fo.DB_Field = "BZC_No"
    '        fo.Field_Operator = Enum_Operator.Operator_Like
    '        foList.Add(fo)

    '        fo = New FindOption
    '        fo.Field = "颜色"
    '        fo.DB_Field = "BZC_Name"
    '        fo.Field_Operator = Enum_Operator.Operator_Like_Both
    '        foList.Add(fo)
    '        Return foList
    '    End Function

    '    ''' <summary>
    '    ''' 按条件获取布种色号信息
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_GetByOption(ByVal oList As OptionList) As DtReturnMsg
    '        Dim paraMap As New Dictionary(Of String, Object)
    '        Dim sqlBuider As New StringBuilder
    '        sqlBuider.Append(SQL_BZC_Get)
    '        sqlBuider.Append("  WHERE 1=1  ")
    '        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
    '        sqlBuider.Append(SQL_BZC_OrderBy)
    '        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    '    End Function

    '    ''' <summary>
    '    ''' 获取布种色号信息
    '    ''' </summary>
    '    ''' <param name="sId"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_GetById(ByVal sId As String) As DtReturnMsg
    '        Return PClass.PClass.SqlStrToDt(SQL_BZC_GetByID, "@BZC_ID", sId)
    '    End Function

    '    ''' <summary>
    '    ''' 获取客户色号列表
    '    ''' </summary>
    '    ''' <param name="sId"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_Bz_Link_GetById(ByVal sId As String) As DtReturnMsg
    '        Return PClass.PClass.SqlStrToDt(SQL_BZC_Link_Bz_GetByID, "@BZC_ID", sId)
    '    End Function

    '    ''' <summary>
    '    ''' 获取色号配方列表
    '    ''' </summary>
    '    ''' <param name="sId"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_BZC_PF_GetById(ByVal sId As String) As DtReturnMsg
    '        Return PClass.PClass.SqlStrToDt(SQL_BZC_PF_GetByID, "@BZC_ID", sId)
    '    End Function



    '    ''' <summary>
    '    ''' 增加一个布种色号
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_Add(ByVal Dt_Bzc As DataTable, ByVal Dt_Bz_Link As DataTable) As MsgReturn
    '        Dim msg As New DtListReturnMsg
    '        Dim returnMsg As New MsgReturn
    '        Dim sqlMap As New Dictionary(Of String, String)
    '        Dim paraMap As New Dictionary(Of String, Object)
    '        If Dt_Bzc.Rows.Count <> 1 Then '检查参数
    '            returnMsg.IsOk = False
    '            returnMsg.Msg = "添加布种色号失败!"
    '            Return returnMsg
    '        End If
    '        paraMap.Add("@BZC_No", Dt_Bzc.Rows(0)("BZC_No"))
    '        paraMap.Add("@BZC_Name", Dt_Bzc.Rows(0)("BZC_Name"))
    '        Dim V As MsgReturn = SqlStrToOneStr(SQL_BZC_GetAutoID, paraMap)
    '        If V.IsOk = False Then
    '            V.Msg = "添加布种色号失败!" & V.Msg
    '            Return V
    '        Else
    '            If Val(V.Msg) = 0 Then
    '                V.IsOk = False
    '                V.Msg = "色号[" & Dt_Bzc.Rows(0)("BZC_No") & "]已经存在!"
    '                Return V
    '            End If
    '        End If
    '        Dim ID As Integer = Val(V.Msg)
    '        paraMap.Clear()
    '        paraMap.Add("@BZC_ID", ID)
    '        sqlMap.Add("BZC", SQL_BZC_GetByID)
    '        sqlMap.Add("Bz_Link", SQL_BZC_Link_Bz_GetByID_Save)
    '        sqlMap.Add("Bzc_PF", SQL_BZC_PF_GetByID_Save)
    '        msg = SqlStrToDt(sqlMap, paraMap)
    '        If msg.IsOk Then
    '            If msg.DtList("BZC").Rows.Count = 1 Then
    '                Dim SK As New List(Of String)
    '                SK.Add("ID")
    '                SK.Add("PF_Count")
    '                DvUpdateToDt(Dt_Bzc, msg.DtList("BZC"), SK)
    '                For Each R As DataRow In Dt_Bz_Link.Rows
    '                    R.Item("BZC_ID") = ID
    '                Next

    '                DvToDt(Dt_Bz_Link, msg.DtList("Bz_Link"), New List(Of String))
    '                DvToDt(Dt_Bzc_PF, msg.DtList("Bzc_PF"), New List(Of String))
    '                Try
    '                    DtToUpDate(msg)
    '                    returnMsg.IsOk = True
    '                    returnMsg.Msg = "布种色号[" & Dt_Bzc.Rows(0)("BZC_Name") & "]添加成功!"
    '                Catch ex As Exception
    '                    BZC_Del(ID)
    '                    returnMsg.IsOk = False
    '                    returnMsg.Msg = "添加布种色号失败!"
    '                End Try

    '            Else
    '                returnMsg.IsOk = False
    '                returnMsg.Msg = "添加布种色号失败!"
    '            End If
    '        Else
    '            BZC_Del(ID)
    '            returnMsg.IsOk = False
    '            returnMsg.Msg = "添加布种色号失败!"
    '        End If
    '        Return returnMsg
    '    End Function



    '    ''' <summary>
    '    '''修改一个布种色号
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_Save(ByVal Dt_Bzc As DataTable, ByVal Dt_Bz_Link As DataTable) As MsgReturn
    '        Dim msg As New DtListReturnMsg
    '        Dim returnMsg As New MsgReturn
    '        Dim sqlMap As New Dictionary(Of String, String)
    '        Dim paraMap As New Dictionary(Of String, Object)
    '        Dim gId As String = ""
    '        If Dt_Bzc.Rows.Count <> 1 Then '检查参数
    '            returnMsg.IsOk = False
    '            returnMsg.Msg = "修改布种色号失败!"
    '            Return returnMsg
    '        End If
    '        gId = Dt_Bzc.Rows(0)("ID")
    '        If BZC_NameCheckDuplicate(Dt_Bzc.Rows(0)("BZC_No"), gId) Then
    '            returnMsg.Msg = "布种色号[" & Dt_Bzc.Rows(0)("BZC_No") & "]已存在!"
    '            Return returnMsg
    '        End If
    '        paraMap.Add("@BZC_ID", gId)
    '        sqlMap.Add("BZC", SQL_BZC_GetByID)
    '        sqlMap.Add("Bz_Link", SQL_BZC_Link_Bz_GetByID_Save)
    '        msg = SqlStrToDt(sqlMap, paraMap)
    '        Try
    '            If msg.IsOk AndAlso msg.DtList("BZC").Rows.Count > 0 Then
    '                Dim SK As New List(Of String)
    '                SK.Add("PF_Count")
    '                SK.Add("PF_ID")
    '                DvUpdateToDt(Dt_Bzc, msg.DtList("BZC"), SK)
    '                DvToDt(Dt_Bz_Link, msg.DtList("Bz_Link"), New List(Of String))
    '                DtToUpDate(msg)
    '                returnMsg.IsOk = True
    '                returnMsg.Msg = "布种色号[" & Dt_Bzc.Rows(0)("BZC_Name") & "]修改成功!"
    '            Else
    '                returnMsg.IsOk = False
    '                returnMsg.Msg = "布种色号[" & Dt_Bzc.Rows(0)("BZC_Name") & "]不已经存在!"
    '            End If
    '        Catch ex As Exception
    '            DebugToLog(ex)
    '            returnMsg.IsOk = False
    '            returnMsg.Msg = "修改布种色号分类失败!"
    '        End Try
    '        Return returnMsg
    '    End Function





    '    ''' <summary>
    '    ''' 检查布类编号的是否重复
    '    ''' </summary>
    '    ''' <param name="BZC_No"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_NameCheckDuplicate(ByVal BZC_No As String, ByVal ID As Integer) As Boolean
    '        Dim P As New Dictionary(Of String, Object)
    '        P.Add("BZC_No", BZC_No)
    '        P.Add("ID", ID)
    '        Dim r As MsgReturn = SqlStrToOneStr(SQL_BZC_NameCheckDuplicate, P)
    '        If r.IsOk Then
    '            If Val(r.Msg) > 0 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Else
    '            Return True
    '        End If
    '    End Function

    '    ''' <summary>
    '    ''' 
    '    ''' </summary>
    '    ''' <param name="BZId"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_CheckGH(ByVal BZC_ID As String) As MsgReturn
    '        Return SqlStrToOneStr(SQL_BZC_CheckGH, "@BZC_ID", BZC_ID)
    '    End Function



    '    ''' <summary>
    '    ''' 
    '    ''' </summary>
    '    ''' <param name="BZId"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_Del(ByVal BZC_ID As String) As MsgReturn
    '        Dim R As MsgReturn = BZC_CheckGH(BZC_ID)
    '        If R.IsOk AndAlso Val(R.Msg) > 0 Then
    '            R.IsOk = False
    '            R.Msg = "本色号已经被其他缸号应该不能删除!"
    '            Return R
    '        Else
    '            Return RunSQL(SQL_BZC_DelByid, "@BZC_ID", BZC_ID)
    '        End If
    '    End Function


    ''' <summary>
    ''' 按条件获取布种色号信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SeBZC_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Get_BZC)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_BZC_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    '    ''' <summary>
    '    ''' 转换
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Shared Function BZC_NoToText(ByVal BZC_No As String) As String
    '        Dim s As String = "000000" & BZC_No
    '        Return "GY-" & s.Substring(s.Length - 6)
    '    End Function


    '    Public Shared Function BZC_GetByNo(ByVal BZC_No As String) As DtReturnMsg
    '        Return SqlStrToDt(SQL_BZC_GetByNo, "@BZC_No", BZC_No)
    '    End Function


End Class