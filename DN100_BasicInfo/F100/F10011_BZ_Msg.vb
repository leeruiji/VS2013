Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F10011_BZ_Msg
    Private ClientID As String = ""
    Private ClientName As String = ""
    Private BZID As String = "0"
    Private startNo As String = ""
    Private State As Enum_BZ_State = Enum_BZ_State.isUsed


    Dim dtGoods As DataTable

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        BZID = F_RS_ID
        ClientID = F_RS_ID2
        ClientName = F_RS_ID2
        startNo = F_RS_ID3
        If startNo = "" Then
            startNo = ClientID
        End If
    End Sub

    Public Sub New(ByVal _ClientID As String, ByVal _ClientName As String, ByVal startNo As String, ByVal _BZID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.ClientID = _ClientID
        Me.ClientName = _ClientName
        Me.startNo = startNo
        Me.BZID = _BZID
        Me.Mode = Mode
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
        ID = 10010
        Control_CheckRight(10010, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(10010, ClassMain.Del, Cmd_Del)

        Control_CheckRight(10010, ClassMain.DelGroup, Cmd_Remove)
        Control_CheckRight(10010, ClassMain.AddGroup, Cmd_Add)
        Control_CheckRight(10010, ClassMain.Combine, Cmd_Combine)
        CB_BZ_FG.Visible = Cmd_Add.Tag OrElse Cmd_Combine.Tag
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load
        FormCheckRight()
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            If CheckRight(10010, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            BZID = 0
            '   TB_ID.Text = BZ_GetNewID(startNo)
            TB_Founder.Text = PClass.PClass.User_Display
            TB_Founder.Tag = PClass.PClass.User_ID
            Cmd_Del.Visible = False
            Cmd_UnDisable.Visible = False
            Cmd_Disable.Visible = False
            Cmd_Modify.Visible = True
            GroupBox1.Visible = False
            Me.Width = 560
        Else
            GroupBox1.Visible = True
            CB_BZ_FG.SearchType = BaseClass.cSearchType.ENum_SearchType.Client
            CB_BZ_FG.SearchID = TB_GoodsType.Tag
            FG1.Rows.Count = 1
            Me.Width = 958
            GetGroup()
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = BZ_GetById(BZID)
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
            If Mode <> Mode_Enum.Add Then dt.Rows(0)("ID") = BZID
            dt.Rows(0)("BZ_Type_ID") = TB_GoodsType.Tag

            dt.Rows(0)("Client_ID") = TB_GoodsType.Tag
            dt.Rows(0)("BZ_No") = TB_ID.Text
            dt.Rows(0)("BZ_Name") = TB_Name.Text
            If TB_CP_No.Text = "" Then
                dt.Rows(0)("CP_No") = DBNull.Value
            Else
                dt.Rows(0)("CP_No") = TB_CP_No.Text
            End If
            If TB_CP_Name.Text = "" Then
                dt.Rows(0)("CP_Name") = DBNull.Value
            Else
                dt.Rows(0)("CP_Name") = TB_CP_Name.Text
            End If
            dt.Rows(0)("BZ_FindHelper") = StrGetPinYin(TB_Name.Text)
            'If Not CB_Store.SelectedValue Is Nothing Then
            '    dt.Rows(0)("BZ_StoreID") = CB_Store.SelectedValue
            'End If

            '   dt.Rows(0)("BZ_Unit") = TB_Unit.Text

            'If Not CB_Supplier.SelectedValue Is Nothing Then
            '    dt.Rows(0)("BZ_Supplier") = CB_Supplier.SelectedValue
            'End If

            dt.Rows(0)("BZ_Spec") = TB_Spec.Text
            dt.Rows(0)("BZ_Remark") = TB_Remark.Text
            '  dt.Rows(0)("BZ_Area_Name") = TB_Area.Text
            '   dt.Rows(0)("BZ_Thick") = Val(TB_Thick.Text)
            '   dt.Rows(0)("BZ_Cost") = Val(TB_Cost.Text)
            '   dt.Rows(0)("BZ_Price") = Val(TB_Price.Text)


            dt.Rows(0)("Founder") = TB_Founder.Tag
            dt.Rows(0)("Found_Date") = DP_Found_Date.Value


            dt.Rows(0)("UPD_USER") = PClass.PClass.User_ID
            dt.Rows(0)("UPD_DATE") = Today



        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        Dim islock As Boolean = False
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_GoodsType.Text = IsNull(dt.Rows(0)("Client_Name"), "")
            TB_GoodsType.Tag = IsNull(dt.Rows(0)("Client_ID"), "")
            TB_ID.Text = IsNull(dt.Rows(0)("BZ_No"), "")
            TB_CP_No.Text = IsNull(dt.Rows(0)("CP_No"), "")
            TB_CP_Name.Text = IsNull(dt.Rows(0)("CP_Name"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("BZ_Name"), "")

            ''If Not dt.Rows(0)("BZ_Store_ID") Is DBNull.Value Then
            ''    CB_Store.SelectedValue = dt.Rows(0)("BZ_StoreID")
            ''End If

            'TB_Unit.Text = IsNull(dt.Rows(0)("BZ_Unit"), "")

            'If Not dt.Rows(0)("BZ_Supplier") Is DBNull.Value Then
            '    CB_Supplier.SelectedValue = dt.Rows(0)("BZ_Supplier")
            'End If
            TB_Spec.Text = IsNull(dt.Rows(0)("BZ_Spec"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("BZ_Remark"), "")
            ' TB_Area.Text = IsNull(dt.Rows(0)("BZ_Area_Name"), "")
            'TB_Thick.Text = IsNull(dt.Rows(0)("BZ_Thick"), "")
            ' TB_Cost.Text = IsNull(dt.Rows(0)("BZ_Cost"), "")
            'TB_Price.Text = IsNull(dt.Rows(0)("BZ_Price"), "")



            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))
            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If


            TB_UPD_USER.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Value = dt.Rows(0)("UPD_DATE")
            End If

            State = IsNull(dt.Rows(0)("BZ_State"), 0)

            Select Case State

                Case Enum_BZ_State.isUsed
                    LB_State.Text = "在用"
                    Cmd_Modify.Enabled = True
                    Cmd_Del.Enabled = True
                    Cmd_Disable.Enabled = True
                    Cmd_UnDisable.Enabled = False
                    islock = False

                Case Enum_BZ_State.Disable
                    LB_State.Text = "禁用"

                    Cmd_Modify.Enabled = False
                    Cmd_Del.Enabled = False
                    Cmd_Disable.Enabled = False
                    Cmd_UnDisable.Enabled = True
                    islock = True
            End Select

        Else
            TB_GoodsType.Text = Me.ClientName
            TB_GoodsType.Tag = Me.ClientID
            TB_ID.Text = ""
            TB_Name.Text = ""
            TB_Founder.Tag = ""
            TB_Founder.Text = ""
            TB_UPD_USER.Text = ""
            LB_State.Visible = False
            Lb1.Visible = False
            islock = False
        End If

        LockForm(islock)


    End Sub


    Private Sub lockForm(ByVal lock As Boolean)
        Btn_ChoseParent.Enabled = Not lock
        TB_Spec.Enabled = Not lock
        TB_ID.Enabled = Not lock
        TB_CP_No.Enabled = Not lock
        TB_Name.Enabled = Not lock
        TB_CP_Name.Enabled = Not lock
        TB_Remark.Enabled = Not lock
        DP_UPD_DATE.Enabled = Not lock
        DP_Found_Date.Enabled = Not lock
        GroupBox1.Enabled = Not lock
    End Sub

#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存布类[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save(Optional ByVal disable As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = BZ_Add(Dt)
        Else
            R = BZ_Save(Dt)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            LastForm.ReturnObj = Dt
            If disable Then
                Set_Disable()
            Else
                ShowOk(R.Msg, True)
            End If
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_GoodsType.Text = "" Then
            ShowErrMsg("布类分类不能为空")
            TB_GoodsType.Focus()
            Return False
        End If
        If TB_ID.Text = "" Then
            ShowErrMsg("布类编号不能为空")
            TB_ID.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("布类名称不能为空")
            TB_Name.Focus()
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除布类[" & TB_ID.Text & "]?", AddressOf DelGoods)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()
        Dim msg As MsgReturn = BZ_Del(BZID)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Btn_ChoseParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseParent.Click
        Dim F As New F10012_ClientBZ_Sel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = 10010
            .P_F_RS_ID2 = ""
            .SelectedClientID = Me.TB_GoodsType.Tag
        End With
        '   F.ClinetBZTree1.TreeView1.SetParent(Me)
        '    F.GoodsTypeTree1.SetRootID(GoodsTypeTree.NODE_BZ)
        F_RS_ID = ""
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
                TB_ID.Text = BZ_GetNewID(ReturnMsg)
                TB_Name.Focus()
            End If
        End If
    End Sub
#End Region

#Region "双击获取新编号"

    Private Sub Label_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If Mode = Mode_Enum.Add Then
            TB_ID.Text = BZ_GetNewID(startNo)
            TB_Name.Focus()
        End If
    End Sub

#End Region

#Region "合并布种"
    Private Sub Cmd_Combin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Combine.Click
        If Mode = Mode_Enum.Add OrElse Val(BZID) = 0 Then
            ShowErrMsg("布种为保存不能合并。")
            Exit Sub
        End If
        If Val(CB_BZ_FG.IDValue) = 0 Then
            ShowErrMsg("请选择你要合并的布种。", AddressOf CB_BZ_FG.Focus)
            Exit Sub
        End If
        If Val(CB_BZ_FG.IDValue) = Val(BZID) Then
            ShowErrMsg("不能选择自己。", AddressOf CB_BZ_FG.Focus)
            Exit Sub
        End If
        ShowConfirm("是否把[" & selNo & "][" & CB_BZ_FG.Text & "]的数据合并到[ " & TB_ID.Text & "][" & TB_Name.Text & "],并删除[" & selNo & "][" & CB_BZ_FG.Text & "]?", AddressOf CombineBZ)
    End Sub

    Private Sub CombineBZ()
        Dim msg As MsgReturn = Dao.BZ_Combin(BZID, CB_BZ_FG.IDValue)
        If msg.IsOk Then
            ShowOk("合并成功。")
            CB_BZ_FG.SetSearchEmpty()
            CB_BZ_FG.Text = ""
            CB_BZ_FG.IDValue = 0
        End If
    End Sub

    Dim selNo As String = ""
    Private Sub CB_BZ_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ_FG.Col_Sel
        selNo = Col_No
    End Sub
#End Region

    Sub GetGroup()
        Dim R As DtReturnMsg = Dao.BZ_Group_Get(BZID)
        If R.IsOk Then
            FG1.DtToFG(R.Dt)
        End If
    End Sub

    Private Sub Btn_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        If CB_BZ_FG.IDAsInt = 0 Then
            ShowErrMsg("请选择一个要关联布种!")
            Exit Sub
        End If
        If CB_BZ_FG.IDAsInt = BZID Then
            ShowErrMsg("请选择一个要关联自己!")
            Exit Sub
        End If
        ShowConfirm("是否关联布种[" & CB_BZ_FG.NameValue & "]", AddressOf AddGroup)
    End Sub
    Sub AddGroup()
        Dim R As MsgReturn = Dao.BZ_Group_Add(BZID, CB_BZ_FG.IDAsInt)
        If R.IsOk Then
            ShowOk("关联布种成功!")
            GetGroup()
            CB_BZ_FG.SetSearchEmpty()
            CB_BZ_FG.Text = ""
            CB_BZ_FG.Focus()
        Else
            ShowErrMsg("关联布种失败!", AddressOf CB_BZ_FG.Focus)
        End If
    End Sub

    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Remove.Click
        If FG1.RowSel <= 0 Then
            ShowErrMsg("请选择一个要取消关联布种!")
            Exit Sub
        End If
        ShowConfirm("取消关联布种[" & FG1.Item(FG1.RowSel, "BZ_No") & "]", AddressOf DelGroup)
    End Sub
    Sub DelGroup()
        Dim R As MsgReturn = Dao.BZ_Group_Del(FG1.Item(FG1.RowSel, "BZ_ID"))
        If R.IsOk Then
            ShowOk("取消关联布种成功!")
            GetGroup()
        Else
            ShowErrMsg("取消关联布种失败!")
        End If
    End Sub

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        GetGroup()
    End Sub


    Private Sub Cmd_UnDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnDisable.Click
        ShowConfirm("是否启用布种［" & TB_Name.Text & "］？", AddressOf Set_UnDisable)
    End Sub

    Private Sub Cmd_Disable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Disable.Click
        ShowConfirm("是否禁用布种［" & TB_Name.Text & "］？", AddressOf Set_Disable_Save)
    End Sub




    Private Sub Set_UnDisable()
        Dim msg As MsgReturn = Dao.Set_BZ_State(BZID, Enum_BZ_State.isUsed)
        If msg.IsOk Then
            ShowOk("布种［" & TB_Name.Text & "］启用成功")
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowOk("布种［" & TB_Name.Text & "］启用失败")
        End If

    End Sub


    Private Sub Set_Disable_Save()
        Save(True)
    End Sub


    Private Sub Set_Disable()
        Dim msg As MsgReturn = Dao.Set_BZ_State(BZID, Enum_BZ_State.Disable)
        If msg.IsOk Then
            ShowOk("布种［" & TB_Name.Text & "］禁用成功", True)
        Else
            ShowOk("布种［" & TB_Name.Text & "］禁用失败")
        End If

    End Sub


End Class
Partial Class Dao

    Public Const Sql_Set_State As String = "Update  T10002_BZ Set BZ_State=@BZ_State Where ID=@ID      "

    Public Shared Function Set_BZ_State(ByVal ID As Integer, ByVal State As Enum_BZ_State) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", ID)
        p.Add("BZ_State", State)
        Return PClass.PClass.RunSQL(Sql_Set_State, p)
    End Function



    Public Shared Function BZ_Group_Get(ByVal BZ_ID As Integer) As DtReturnMsg
        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("declare @Group_ID bigint")
        sqlBuider.AppendLine("select @Group_ID=Group_ID from T10002_BZ_Group where BZ_ID=@BZ_ID")
        sqlBuider.AppendLine("select BZ_No,BZ_Name,BZ_ID from T10002_BZ_Group G,T10002_BZ B where G.BZ_ID=B.ID and Group_ID=@Group_ID and B.ID<>@BZ_ID order by BZ_No")
        Return SqlStrToDt(sqlBuider.ToString, "BZ_ID", BZ_ID)
    End Function


    Public Shared Function BZ_Group_Add(ByVal BZ_ID As Integer, ByVal BZ_ID2 As Integer) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZ_ID", BZ_ID)
        P.Add("BZ_ID2", BZ_ID2)
        Dim sqlBuider As New StringBuilder()
        sqlBuider.AppendLine("declare @Group_ID int")
        sqlBuider.AppendLine("select @Group_ID=Group_ID from T10002_BZ_Group where BZ_ID=@BZ_ID")
        sqlBuider.AppendLine("declare @Group_ID2 int")
        sqlBuider.AppendLine("select @Group_ID2=Group_ID from T10002_BZ_Group where BZ_ID=@BZ_ID2")
        sqlBuider.AppendLine("if(@Group_ID is null)")
        sqlBuider.AppendLine("	begin")
        sqlBuider.AppendLine("	if(@Group_ID2 is null) ")
        sqlBuider.AppendLine("		begin")
        sqlBuider.AppendLine("		set @Group_ID2=isnull((select top 1 Group_ID from T10002_BZ_Group order by Group_ID desc),0)+1")
        sqlBuider.AppendLine("		insert into T10002_BZ_Group(BZ_ID,Group_ID)values(@BZ_ID2,@Group_ID2)")
        sqlBuider.AppendLine("		end")
        sqlBuider.AppendLine("	insert into T10002_BZ_Group(BZ_ID,Group_ID)values(@BZ_ID,@Group_ID2)")
        sqlBuider.AppendLine("	end")
        sqlBuider.AppendLine("else")
        sqlBuider.AppendLine("if(@Group_ID2 is null)")
        sqlBuider.AppendLine("insert into T10002_BZ_Group(BZ_ID,Group_ID)values(@BZ_ID2,@Group_ID)")
        sqlBuider.AppendLine("else")
        sqlBuider.AppendLine("update T10002_BZ_Group set Group_ID=@Group_ID where  Group_ID=@Group_ID2")
        Return RunSQL(sqlBuider.ToString, P)
    End Function

    Public Shared Function BZ_Group_Del(ByVal BZ_ID As Integer) As MsgReturn
        Dim P As New Dictionary(Of String, Object)
        P.Add("BZ_ID", BZ_ID)
        Return RunSQL("delete T10002_BZ_Group where BZ_ID=@BZ_ID", P)
    End Function

    ''' <summary>
    ''' 合并两个布种
    ''' </summary>
    ''' <param name="newID"></param>
    ''' <param name="oldID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZ_Combin(ByVal newID As Long, ByVal oldID As Long) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("NewID", newID)
        p.Add("OldID", oldID)
        Return SqlStrToOneStr("P10002_Combin_BZ", p, True)
    End Function

End Class