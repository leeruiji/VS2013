Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass

Public Class F10041_RBPF_Msg
    Dim LId As String = ""
    Dim PID As String = ""
    Dim Bzc_Id As Integer = 0
    Dim Dt_Bzc As DataTable
    Dim Dt_Bz_Link As DataTable
    Dim DtRBPF As DataTable
    Dim DT_Nfei As DataTable
    Dim DtRBPFList As DataTable
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
        Control_CheckRight(10040, ClassMain.Modify, Cmd_Modify)
    End Sub


    Private Sub FormLoad() Handles Me.Me_Load
        Fg1.Cols("BZ_No").Editor = CB_BZ_FG
        Fg1.Cols("PF_Name").Editor = CB_FG_PFList
        Cmd_ShowInvoid.Checked = My.Settings.InvoidShow
        FormCheckRight()
        Fg1.Rows.Count = 1
        Fg3.IniColsSize()
        Fg2.IniColsSize()
        Me_Refresh()

        LId = TB_BZC_No.Text
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
            GetRBPF()
            Dim msg1 As DtReturnMsg = Dao.BZC_Bz_Link_GetById(Bzc_Id)
            If msg1.IsOk Then
                Dt_Bz_Link = msg1.Dt
                Fg1.DtToSetFG(Dt_Bz_Link)
                For i As Integer = 1 To Fg1.Rows.Count - 1
                    If Fg1.Item(i, "PF_ID") IsNot Nothing Then
                        Dim R() As DataRow = DtRBPF.Select("ID=" & Val(Fg1.Item(i, "PF_ID")))
                        If R.Length > 0 Then
                            Fg1.Item(i, "PF_Name") = R(0)("PF_Name")
                        End If
                    End If
                Next

            End If
            If Fg2.RowSel > 0 Then
                GetRBPFLIst()
            Else
                Fg3.Rows.Count = 1
            End If
        End If
    End Sub

    Public Sub GetRBPF()
        Dim msg2 As DtReturnMsg = Dao.RBPF_GetRBPFListByBZCID(Bzc_Id, Cmd_ShowInvoid.Checked)
        If msg2.IsOk Then
            msg2.Dt.Columns.Add("isFei", GetType(Boolean))
            For Each dr As DataRow In msg2.Dt.Rows
                If IsNull(dr("State"), Enum_State.AddNew) = Enum_State.Invoid Then
                    dr("isFei") = True
                Else
                    dr("isFei") = False
                End If
            Next
            DtRBPF = msg2.Dt
            DT_Nfei = DataTableSelect(msg2.Dt, "isFei=False")
        End If
        MeIsLoad = False
        Fg2.DtToSetFG(DtRBPF)
        If ReturnId <> "" Then Fg2.RowSetForce("PF_Name", ReturnId.ToString)
        If Fg2.Rows.Count > 1 AndAlso Fg2.RowSel <= 0 Then
            Fg2.Row = 1
            Fg2.RowSel = 1
        End If
        CB_FG_PFList.DataSource = DT_Nfei.Copy
        CB_FG_PFList.ValueMember = "ID"
        CB_FG_PFList.DisplayMember = "PF_Name"
        CB_PFList.DataSource = DT_Nfei.Copy
        CB_PFList.ValueMember = "ID"
        CB_PFList.DisplayMember = "PF_Name"
        If Dt_Bzc.Rows.Count > 0 Then
            CB_PFList.SelectedValue = Dt_Bzc.Rows(0)("PF_ID")
        End If
        MeIsLoad = True
        GetRBPFLIst()
    End Sub

    Private Function DataTableSelect(ByVal dt As DataTable, ByVal Col As String) As DataTable
        Dim dtTemp As DataTable = dt.Clone
        Dim dr() As DataRow = dt.Select(Col)
        For Each d As DataRow In dr
            dtTemp.ImportRow(d)
        Next
        Return dtTemp
    End Function


    Dim MapGY As New Dictionary(Of String, C1.Win.C1FlexGrid.Node)
    Protected Sub GetRBPFLIst()
        If Fg2.RowSel >= Fg2.Rows.Fixed Then
            Dim msg3 As DtReturnMsg = Dao.RBPF_PF_GetList(Bzc_Id, Fg2.Item(Fg2.RowSel, "ID"))
            If msg3.IsOk Then
                DtRBPFList = msg3.Dt
            End If
            CreateTreeiew(DtRBPFList, Fg3, MapGY, Me, "DyingStep")
        End If
    End Sub


    Sub GetDateTable()
        Dim msg1 As DtReturnMsg = Dao.BZC_Bz_Link_GetById(Bzc_Id)
        If msg1.IsOk Then
            Dt_Bz_Link = msg1.Dt
        End If

        'Dim msg2 As DtReturnMsg = BZC_BZC_RBPF_GetById(Bzc_Id)
        'If msg2.IsOk Then
        '    DtRBPF = msg2.Dt
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
            'dt.Rows(0)("BZC_No") = StrConv(TB_BZC_No.Text, vbNarrow)
            dt.Rows(0)("BZC_Name") = TB_Name.Text
            'dt.Rows(0)("BZC_Remark") = TB_Remark.Text
            ' dt.Rows(0)("Client_id") = Tb_Client_id.Tag
            'dt.Rows(0)("Qian_ChuLi") = TB_Qian_ChuLi.Text
            dt.Rows(0)("BZ_Id") = CB_BZ.IDValue
            dt.Rows(0)("Client_Bzc") = StrConv(TB_Client_Bzc.Text, vbNarrow)
            If CB_PFList.SelectedValue IsNot Nothing Then dt.Rows(0)("PF_ID") = CB_PFList.SelectedValue
            'dt.Rows(0)("BZC_FindHelper") = StrGetPinYin(TB_Name.Text)

            'dt.Rows(0)("Found_Date") = Format(DP_Found_Date.Value, "yyyy-MM-dd")
            'dt.Rows(0)("UPD_USER") = PClass.PClass.User_Id
            'dt.Rows(0)("UPD_DATE") = Today
            'dt.Rows(0)("RanSe") = CB_RanSe.Text

        End If
        Dt_Bz_Link = Dt_Bz_Link.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Dt_Bz_Link.Select("BZ_Id='" & Fg1.Item(i, "BZ_Id") & "'").Length = 0 Then
                Dim Dr As DataRow = Dt_Bz_Link.NewRow
                Dr("BZC_ID") = Bzc_Id
                Dr("BZ_Id") = Fg1.Item(i, "BZ_Id")
                Dr("Client_Bzc") = Fg1.Item(i, "Client_Bzc")
                If Fg1.Item(i, "PF_ID") IsNot Nothing AndAlso Val(Fg1.Item(i, "PF_ID")) <> 0 Then Dr("PF_ID") = Fg1.Item(i, "PF_ID")
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

            TB_UPD_USER.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
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
        Fg1.AddRow()
    End Sub

    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub



    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存颜色[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn

        R = Dao.BZC_MiniSave(GetForm(), Dt_Bz_Link)

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

        If Val(CB_BZ.IDValue) = 0 Then
            ShowErrMsg("布种编号不能为空", AddressOf CB_BZ.Focus)
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

        Me.Refresh()
        Return True
    End Function

    Private Sub Cmd_ShowInvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ShowInvoid.Click
        GetRBPF()
        My.Settings.InvoidShow = Cmd_ShowInvoid.Checked
        My.Settings.Save()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

#End Region

#Region "FG1事件"
    Private Sub CB_FG_PFList_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_FG_PFList.SelectionChangeCommitted
        Fg1.Item(Fg1.RowSel, "PF_ID") = CB_FG_PFList.SelectedValue
    End Sub

    Private Sub CB_BZ_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_BZ_FG.GetSearchEvent
        CB_BZ_FG.IDValue = Fg1.Item(Fg1.RowSel, "BZ_ID")
    End Sub

    Private Sub Fg1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.GotFocus
        FG_SEL = "FG1"
    End Sub

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "BZ_No"
                e.ToCol = Fg1.Cols("Client_Bzc").Index
            Case "Client_Bzc"
                e.ToCol = Fg1.Cols("PF_Name").Index
            Case "PF_Name"
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
                If Fg1.LastText <> IsNull(Fg1.Item(e.Row, "BZ_No"), "") AndAlso IsSelect = False Then Fg1.Item(e.Row, "BZ_Name") = ""
                IsSelect = False
            End If
        Else
            If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell()
        End If
    End Sub


    Dim IsSelect As Boolean
    Private Sub CB_BZ_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ_FG.Col_Sel
        IsSelect = True
        Fg1.Item(Fg1.RowSel, "BZ_Name") = Col_Name
        Fg1.Item(Fg1.RowSel, "BZ_ID") = ID
        Fg1.GotoNextCell("BZ_No")
    End Sub
    Sub FG_BZ_No()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("BZ_No").Index)
    End Sub

#End Region

#Region "FG2事件"

    Private Sub Fg2_SelectRowChange(ByVal Row As Integer) Handles Fg2.SelectRowChange
        If MeIsLoad Then GetRBPFLIst()
    End Sub

    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If Fg2.Item(Fg2.RowSel, "ID") Is Nothing AndAlso Fg2.Item(Fg2.RowSel, "ID") = "" Then
            Exit Sub
        End If
        Dim _RBPFID As Integer = Val(Fg2.Item(Fg2.RowSel, "ID"))
        ModifyRBPF(_RBPFID)
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



#Region "新增，修改染部配方"
    Private Sub Cmd_RBPF_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RBPF_Add.Click
        If Me.Mode = Mode_Enum.Add Then
            ShowErrMsg("请先保存色号资料！")
            Exit Sub
        End If
        AddRBPF()
    End Sub

    Protected Sub AddRBPF()
        Dim F As New F10042_RBPF_PF(Bzc_Id)
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

    Protected Sub ModifyRBPF(ByVal _RBPFID As Integer)
        Dim F As New F10042_RBPF_PF(_RBPFID, Bzc_Id)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_Obj = CheckPF()
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
    ''' 复制当前选择的染部配方
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_CopyRBPF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CopyRBPF.Click
        If Fg2.RowSel <= 0 Then Exit Sub
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        If Fg2.Item(Fg2.RowSel, "ID") Is Nothing AndAlso Fg2.Item(Fg2.RowSel, "ID") = "" Then
            Exit Sub
        End If
        Dim _RBPFID As Integer = Val(Fg2.Item(Fg2.RowSel, "ID"))
        Dim F As New F10042_RBPF_PF(_RBPFID, Bzc_Id, True)
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

    Private Sub Cmd_RBPF_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RBPF_Remove.Click
        If Fg2.RowSel > 0 Then
            If Dao.RBPF_GetState_ByID(Fg2.Item(Fg2.RowSel, "ID"), Me.Bzc_Id) = False Then
                ShowErrMsg("［" & Fg2.Item(Fg2.RowSel, "PF_Name") & "］未作废不能删除")
                Exit Sub
            End If
            ShowConfirm("确定要删除染部配方[" & Fg2.Item(Fg2.RowSel, "PF_Name") & "]?", AddressOf DELRBPF)
        End If
    End Sub
    Protected Sub DELRBPF()
        Dim msg As MsgReturn = Dao.RBPF_Del(Fg2.Item(Fg2.RowSel, "ID"), Me.Bzc_Id)
        If msg.IsOk = False Then
            ShowErrMsg(msg.Msg)
        Else
            LastForm.ReturnId = TB_BZC_No.Text
            Fg3.Rows.Count = 1
            GetRBPF()
        End If
    End Sub
#End Region

#Region "客户色号"

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

    ''' <summary>
    ''' 配方ID检查
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckPF() As List(Of String)
        Dim Bn_list As New List(Of String)
        If Val(Fg2.Item(Fg2.RowSel, "ID")) = IsNull(Dt_Bzc.Rows(0)("PF_ID"), 0) Then
            Bn_list.Add(Dt_Bzc.Rows(0)("BZ_Name"))
        End If
        For Each dr As DataRow In Dt_Bz_Link.Rows
            If Val(Fg2.Item(Fg2.RowSel, "ID")) = IsNull(dr("PF_ID"), 0) Then
                Bn_list.Add(dr("BZ_Name"))
            End If
        Next
        Return Bn_list
    End Function

End Class

Partial Class Dao

#Region "常量"
    ''' <summary>
    ''' 获取编号
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_RBPF_GetRBPFID = "declare @A Varchar(20)" & vbCrLf & _
       "if exists (select * from  T10012_RB_PF where BZC_ID=@BZC_ID and RBPF_Name=@RBPF_Name)" & vbCrLf & _
       "set @A=0" & vbCrLf & _
       "else" & vbCrLf & _
       "begin" & vbCrLf & _
       "insert into T10012_RB_PF (BZC_ID,RBPF_Name)values(@BZC_ID,@RBPF_Name)" & vbCrLf & _
       "set @A=@@identity" & vbCrLf & _
       "end" & vbCrLf & _
       "select @A"


    Public Const RBPF_DB_NAME As String = "染部配方"

    Public Const SQL_RBPF_GetByID = "select * from T10012_RB_PF where  BZC_ID= @BZC_ID and ID=@ID  "


    Public Const SQL_RBPF_GeList_ByID = "select * from T10013_RB_PFList where  BZC_ID= @BZC_ID and ID=@ID "

    Public Const SQL_RBPF_State = "Select  Top 1 ISNULL(State,0)AS State from T10012_RB_PF where  BZC_ID= @BZC_ID and ID=@ID   "

    Public Const SQL_RBPF_GetRBPFListByBZCID = "select * from T10012_RB_PF where BZC_ID= @BZC_ID  "

    Public Const SQL_RBPF_Del = "delete from T10012_RB_PF where  BZC_ID= @BZC_ID  and  ID=@ID --and IsCheck=0 "

#End Region



    Public Shared Function RBPF_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)


        Dim BZCID As String = Val(dtTable.Rows(0)("BZC_ID"))
        Dim RBPFID As String = RBPF_GetRBPFID(BZCID, dtTable.Rows(0)("RBPF_Name"))
        If RBPFID = 0 Then
            R.Msg = "" & RBPF_DB_NAME & "[" & dtTable.Rows(0)("RBPF_Name") & "]已经存在!请检查后重新保存"
            Return R
        Else
            dtTable.Rows(0)("ID") = RBPFID
            For Each row As DataRow In dtList.Rows
                row("ID") = RBPFID
            Next
        End If
        paraMap.Add("ID", RBPFID)
        paraMap.Add("BZC_ID", BZCID)
        Try
            sqlMap.Add("Table", SQL_RBPF_GetByID)
            sqlMap.Add("List", SQL_RBPF_GeList_ByID)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                DtToUpDate(msg)
                R.Msg = "" & RBPF_DB_NAME & "[" & dtTable.Rows(0)("RBPF_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & RBPF_DB_NAME & "[" & dtTable.Rows(0)("RBPF_Name") & "]添加错误!"
            End If
            Return R
        Catch ex As Exception
            Try
                RunSQL(SQL_RBPF_Del, paraMap)
            Catch ex1 As Exception
            End Try
            R.IsOk = False
            R.Msg = "" & RBPF_DB_NAME & "[" & dtTable.Rows(0)("RBPF_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try

    End Function

    Public Shared Function RBPF_GetRBPFID(ByVal BZC_ID As String, ByVal RBPF_Name As String) As Integer
        Dim R As New MsgReturn
        Dim para As New Dictionary(Of String, Object)
        para.Add("@BZC_ID", BZC_ID)
        para.Add("@RBPF_Name", RBPF_Name)
        R = PClass.PClass.SqlStrToOneStr(SQL_RBPF_GetRBPFID, para)
        If R.IsOk Then
            Return Val(R.Msg)
        Else
            Return 0
        End If
    End Function


    Public Shared Function RBPF_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim R As New MsgReturn


        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim RBPFID As String = Val(dtTable.Rows(0)("ID"))
        Dim BZCID As String = Val(dtTable.Rows(0)("BZC_ID"))
        paraMap.Add("ID", RBPFID)
        paraMap.Add("BZC_ID", BZCID)
        Try
            sqlMap.Add("Table", SQL_RBPF_GetByID)
            sqlMap.Add("List", SQL_RBPF_GeList_ByID)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then

                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                R.Msg = "" & RBPF_DB_NAME & "[" & dtTable.Rows(0)("RBPF_Name") & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & RBPF_DB_NAME & "[" & dtTable.Rows(0)("RBPF_Name") & "]不存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & RBPF_DB_NAME & "[" & dtTable.Rows(0)("RBPF_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try

    End Function



    Public Shared Function RBPF_GetTable_ByID(ByVal _ID As Integer, ByVal _BZC_ID As Integer) As DtReturnMsg
        Dim R As New DtReturnMsg
        Dim sql As String = SQL_RBPF_State
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        para.Add("@BZC_ID", _BZC_ID)


        R = PClass.PClass.SqlStrToDt(sql, para)
        Return R
    End Function


    Public Shared Function RBPF_GetState_ByID(ByVal _ID As Integer, ByVal _BZC_ID As Integer) As Boolean
        Dim R As New DtReturnMsg
        Dim sql As String = SQL_RBPF_State
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        para.Add("@BZC_ID", _BZC_ID)
        R = PClass.PClass.SqlStrToDt(sql, para)
        If R.IsOk And R.Dt.Rows.Count > 0 Then
            If R.Dt.Rows(0)("State") = -1 Then
                Return True
            End If
        End If
        Return False
    End Function






    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RBPF_GetRBPFListByBZCID(ByVal _BZCID As Integer, ByVal isInvoid As Boolean) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("BZC_ID", _BZCID)
        Dim SQL_GetRBPF_ByID = SQL_RBPF_GetRBPFListByBZCID
        If isInvoid = False Then
            SQL_GetRBPF_ByID = SQL_RBPF_GetRBPFListByBZCID & " and  isnull(State,0)=0 "
        End If

        Return PClass.PClass.SqlStrToDt(SQL_GetRBPF_ByID, p)
    End Function


    Public Shared Function RBPF_CheckName(ByVal _ID As Integer, ByVal _BZC_ID As Integer, ByVal _RBPFName As String)
        Dim sql As String = "select 1 from T10012_RB_PF where BZC_ID=@BZC_ID and  RBPF_Name=@RBPF_Name and ID<>@ID"
        Dim R As New MsgReturn
        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        para.Add("@BZC_ID", _BZC_ID)
        para.Add("@RBPF_Name", _RBPFName)
        Dim msg As DtReturnMsg = PClass.PClass.SqlStrToDt(sql, para)
        If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then
            R.IsOk = True
        Else
            R.IsOk = False
            R.Msg = "染部配方名称[" & _RBPFName & "]已经存在！"
        End If
        Return R
    End Function

    Public Shared Function RBPF_Del(ByVal _ID As Integer, ByVal _BZC_ID As Integer) As MsgReturn
        Dim R As New MsgReturn
        Dim sql As String = SQL_RBPF_Del


        Dim para As New Dictionary(Of String, Object)
        para.Add("@ID", _ID)
        para.Add("@BZC_ID", _BZC_ID)


        R = PClass.PClass.RunSQL(sql, para)
        Return R
    End Function



    ''' <summary>
    ''' 审核入库单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RBPF_Audited(ByVal BZC_ID As Integer, ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("BZC_ID", BZC_ID)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)
        Dim R As MsgReturn = SqlStrToOneStr("P10010_BZC_RBPF_Audited", paraMap, True)
        If R.IsOk Then
            If R.Msg.StartsWith("1") Then
                R.IsOk = True
            Else
                R.IsOk = False
            End If
            R.Msg = R.Msg.Substring(1)
        End If
        Return R
    End Function



    Public Const SQL_BZC_MiniGetByID As String = "select ID,BZ_ID,Client_Bzc,PF_ID from T10003_BZC C where ID=@BZC_ID"


    ''' <summary>
    '''修改一个布种色号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZC_MiniSave(ByVal Dt_Bzc As DataTable, ByVal Dt_Bz_Link As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim gId As String = ""
        If Dt_Bzc.Rows.Count <> 1 Then '检查参数
            returnMsg.IsOk = False
            returnMsg.Msg = "修改布种色号失败!"
            Return returnMsg
        End If
        gId = Dt_Bzc.Rows(0)("ID")

        paraMap.Add("@BZC_ID", gId)
        sqlMap.Add("BZC", SQL_BZC_MiniGetByID)
        sqlMap.Add("Bz_Link", SQL_BZC_Link_Bz_GetByID_Save)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk AndAlso msg.DtList("BZC").Rows.Count > 0 Then
                Dim SK As New List(Of String)
                SK.Add("ID")
                DvUpdateToDt(Dt_Bzc, msg.DtList("BZC"), SK)
                DvToDt(Dt_Bz_Link, msg.DtList("Bz_Link"), New List(Of String))
                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = "布种色号[" & Dt_Bzc.Rows(0)("BZC_Name") & "]修改成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "布种色号[" & Dt_Bzc.Rows(0)("BZC_Name") & "]不已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改布种色号分类失败!"
        End Try
        Return returnMsg
    End Function



End Class