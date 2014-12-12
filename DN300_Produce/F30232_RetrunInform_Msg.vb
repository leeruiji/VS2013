Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30232_RetrunInform_Msg
    Dim LId As String = ""
    'Dim Bill_Id As String = ""
    Dim PID As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    '   Dim StoreDt As DataTable
    Dim State As Enum_State = Enum_State.AddNew
    Dim IsBidings As Boolean = False
    Dim Payment As Boolean = False

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = initID
        Me.Mode = Mode
    End Sub

    Private Sub Me_AfterLoad() Handles Me.AfterLoad
       
    End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        Control_CheckRight(ID, ClassMain.Audited, Cmd_Audit)
        Control_CheckRight(ID, ClassMain.UnAudit, Cmd_UnAudit)
        Control_CheckRight(ID, ClassMain.SetInValid, Cmd_SetInValid)
        Control_CheckRight(ID, ClassMain.SetValid, Cmd_SetValid)
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.Inform, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        ID = 30231
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name
        CB_HSBM.DisplayMember = "Dept_Name"
        CB_HSBM.ValueMember = "Dept_No"
        CB_HSBM.DataSource = Dao.GetDep().Dt

        CB_ZRBM.DisplayMember = "Dept_Name"
        CB_ZRBM.ValueMember = "Dept_No"
        CB_ZRBM.DataSource = Dao.GetDep().Dt.Copy


        If Bill_ID = "" AndAlso P_F_RS_ID <> "" Then
            Bill_ID = P_F_RS_ID
        End If
        Me_Refresh()

    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.InForm_GetById(Bill_ID)
        If msgTable.IsOk Then
            If IsBidings Then
                DvUpdateToDt(msgTable.Dt, dtTable, New List(Of String))
            Else
                dtTable = msgTable.Dt
            End If
            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Dao.InForm_DB_NAME & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.InForm_DB_NAME & "!", True) : Exit Sub       
                LabelTitle.Text = "新建" & Me.Ch_Name
                Cmd_Preview.Enabled = False
                Cmd_Print.Enabled = False
                DTP_sDate.Value = GetDate()
                GetNewID()
            Case Mode_Enum.Modify
                Cmd_Preview.Enabled = True
                Cmd_Print.Enabled = True
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select

        dtTable.AcceptChanges()
     


    End Sub



#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        Dim ID As String = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt = dtTable.Clone
        Dim dr As DataRow = dt.NewRow
        dr("ID") = ID
        dr("GH") = TB_GH.Text
        dr("PS") = Val(TB_PS.Text)
        dr("ZL") = Val(TB_ZL.Text)
        dr("CH") = TB_CH.Text
        dr("FBWZ") = TB_FBWZ.Text
        dr("HSBM") = CB_HSBM.Text
        dr("ZRBM") = TB_Dept.Text
        dr("JJR") = TB_JJR.Text
        dr("Remark") = TB_Remark.Text
        dr("sDate") = DTP_sDate.Value
        dr("State") = State
        dr("sUser") = User_Name
        dr("Banci") = RB_morning.Checked
        dt.Rows.Add(dr)
        dt.AcceptChanges()
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
        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow

            Dr("Remark") = ""
            Dr("ID") = ""
            Dr("sDate") = ServerTime.Date
            Dr("sUser") = User_Name
            'Dr("Payed") = Dr("SumZL") - Dr("UnPayed")

            Cmd_Audit.Visible = Cmd_Audit.Tag
            Cmd_Audit.Enabled = True
            Cmd_UnAudit.Visible = False
            Cmd_UnAudit.Enabled = False

            Cmd_SetValid.Visible = False
            Cmd_SetValid.Enabled = False
            Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
            Cmd_SetInValid.Enabled = False
            Cmd_Del.Visible = False
            'Cmd_Payment.Visible = False
            Cmd_UnPayment.Visible = False

            'LabelPayment.Visible = False
            LabelState.Text = "新建"
            LabelState.ForeColor = Color.Black
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(False)
        Else
            Dr = dt.Rows(0)
            State = Dr("State")
            Cmd_Del.Visible = False
            Select Case State
                Case Enum_State.AddNew '新建
                    LabelState.Text = "新建"
                    LabelState.ForeColor = Color.Black
                    Cmd_Modify.Enabled = Cmd_Modify.Tag

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = True
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False

                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = True
                    Cmd_Del.Visible = Cmd_Del.Tag
                    LockForm(False)
                Case Enum_State.Invoid '作废
                    LabelState.Text = "已作废"
                    LabelState.ForeColor = Color.Red
                    Cmd_Modify.Enabled = False

                    Cmd_Audit.Visible = Cmd_Audit.Tag
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = False
                    Cmd_UnAudit.Enabled = False



                    Cmd_SetValid.Visible = Cmd_SetValid.Tag
                    Cmd_SetValid.Enabled = True
                    Cmd_SetInValid.Visible = False
                    Cmd_SetInValid.Enabled = False
                    LockForm(True)
                Case Enum_State.Audited '审核

                    LabelState.Text = "已审核"
                    LabelState.ForeColor = Color.Blue
                    Cmd_Modify.Enabled = False

                    Cmd_Audit.Visible = False
                    Cmd_Audit.Enabled = False
                    Cmd_UnAudit.Visible = Cmd_UnAudit.Tag
                    Cmd_UnAudit.Enabled = True



                    Cmd_SetValid.Visible = False
                    Cmd_SetValid.Enabled = False
                    Cmd_SetInValid.Visible = Cmd_SetInValid.Tag
                    Cmd_SetInValid.Enabled = False
                    LockForm(True)
            End Select
        End If
        If IsNull(dt.Rows(0)("Banci"), False) = True Then
            RB_morning.Checked = True
        Else
            RB_even.Checked = True
        End If
        TB_ID.Text = IsNull(dt.Rows(0)("ID"), "")
        TB_Client.Text = IsNull(dt.Rows(0)("Client_Name"), "")
        TB_BZ_Name.Text = IsNull(dt.Rows(0)("BZ_Name"), "")
        TB_BZC_Name.Text = IsNull(dt.Rows(0)("BZC_Name"), "")
        TB_BZC_No.Text = IsNull(dt.Rows(0)("BZC_No"), "")
        TB_GH.Text = IsNull(dt.Rows(0)("GH"), "")
        TB_PS.Text = IsNull(dt.Rows(0)("PS"), "")
        TB_ZL.Text = IsNull(dt.Rows(0)("ZL"), "")
        TB_CH.Text = IsNull(dt.Rows(0)("CH"), "")
        TB_FBWZ.Text = IsNull(dt.Rows(0)("FBWZ"), "")
        CB_HSBM.Text = IsNull(dt.Rows(0)("HSBM"), "")
        TB_Dept.Text = IsNull(dt.Rows(0)("ZRBM"), "")
        TB_JJR.Text = IsNull(dt.Rows(0)("JJR"), "")
        TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
        DTP_sDate.Value = IsNull(dt.Rows(0)("sDate"), ServerTime.Date)




    End Sub

    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        TB_GH.ReadOnly = Lock
        TB_PS.ReadOnly = Lock
        TB_ZL.ReadOnly = Lock
        TB_CH.ReadOnly = Lock
        TB_FBWZ.ReadOnly = Lock
        CB_HSBM.Enabled = Not Lock
        CB_ZRBM.Enabled = Not Lock
        TB_JJR.ReadOnly = Lock
        TB_Remark.ReadOnly = Lock
    End Sub


#Region "获取新单号"
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If TB_ID.ReadOnly OrElse TB_ID.Enabled = False Then
            ShowErrMsg("非新增状态不能修改单号!")
        Else
            ShowConfirm("是否获取新单号?", AddressOf ReGetNewID)
        End If
    End Sub

    Sub ReGetNewID()
        If TB_ID.Text <> LId OrElse LId = "" Then
            ComFun.DelBillNewID(BillType.Inform, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.Inform, DTP_sDate.Value, Bill_ID)
                If R.IsOk Then
                    Bill_Id_Date = R.NewIdDate
                    DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                    DTP_sDate.Value = R.NewIdDate
                    Bill_ID = R.NewID
                    TB_ID.Text = Bill_ID.Replace("-", "")
                    If R.IsTheDate = False Then
                        ShowErrMsg(R.RetrunMsg)
                    End If
                Else
                    ShowErrMsg(R.RetrunMsg)
                End If
            End If
        End If
    End Sub

    Private Sub DTP_sDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP_sDate.Validated
        GetNewID()
    End Sub

#End Region

#End Region

#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click

        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveInForm)
            Else
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveInForm)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveInForm(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Audit Then
            Dt.Rows(0).Item("State_User") = User_Display
        End If
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.InForm_Add(Dt, dtList)
        Else
            R = Dao.InForm_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If Audit Then
                Dim msg As MsgReturn = Dao.InForm_Audited(TB_ID.Text, True)
                If msg.IsOk Then
                    Bill_ID = TB_ID.Text
                    Me_Refresh()
                    ShowOk(msg.Msg)
                Else
                    ShowErrMsg("保存成功,但" & msg.Msg)
                End If
                Exit Sub
            End If
            If TB_ID.Text = Bill_ID.Replace("-", "") Then Bill_ID = ""
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean

        TB_ID.Text = TB_ID.Text.Trim
        TB_ID.Text = TB_ID.Text.Replace("'", "")
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If

        If TB_GH.Text = "" Then
            ShowErrMsg(Ch_Name & "缸号不能为空!", AddressOf TB_GH.Focus)
            Return False
        End If

        Me.Refresh()
        Return True
    End Function

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "报表事件"

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        Print(OperatorType.Preview)
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Print(OperatorType.Print)
    End Sub

    Protected Sub Print(ByVal DoOperator As OperatorType)
        If Me.Mode = Mode_Enum.Add Then
            Exit Sub
        End If
        Dim R As New R30231_RetrunInform
        R.Start(TB_ID.Text, DoOperator)
    End Sub

#End Region

  
    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelReturnInform)
    End Sub

    ''' <summary>
    ''' 删除日报表
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelReturnInform()
        Dim msg As MsgReturn = Dao.InForm_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_SetInValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetInValid.Click
        ShowConfirm("是否作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf RetrunInformInValid)
    End Sub


    Sub RetrunInformInValid()
        Dim msg As MsgReturn = Dao.InForm_InValid(TB_ID.Text, True)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    ''' <summary>
    ''' 反作废
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_SetValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetValid.Click
        ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf RetrunInformValid)
    End Sub

    ''' <summary>
    ''' 作废
    ''' </summary>
    ''' <remarks></remarks>
    Sub RetrunInformValid()
        Dim msg As MsgReturn = Dao.InForm_InValid(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            LastForm.ReturnId = TB_ID.Text
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub




    ''' <summary>
    ''' 审核状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Audit.Click

        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Shenhe)
            Else
               
                ShowConfirm("是否保存并审核" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Shenhe)
            End If
        End If

    End Sub
    Protected Sub Shenhe()
        SaveInForm(True)
    End Sub

    Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnAudit.Click
        ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    End Sub

    Protected Sub UnAudit()
        Dim msg As MsgReturn = Dao.InForm_Audited(TB_ID.Text, False)
        If msg.IsOk Then
            Me_Refresh()
            Me.LastForm.ReturnId = TB_ID.Text
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub



    Private Sub TB_GH_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_GH.Leave
        Dim MSG As DtReturnMsg = Dao.GetZL_ByGH(TB_GH.Text)
        If MSG.IsOk AndAlso MSG.Dt.Rows.Count > 0 Then
            SetZL(MSG.Dt.Rows(0))
        End If
    End Sub




    Private Sub SetZL(ByVal DR As DataRow)
        If DR Is Nothing Then
            Exit Sub
        End If
        TB_Client.Text = DR("Client_Name")
        TB_BZ_Name.Text = DR("BZ_Name")
        TB_BZC_Name.Text = DR("BZC_Name")
        TB_BZC_No.Text = DR("BZC_No")
    End Sub



 
    Private Sub TB_PS_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_PS.Leave
        TB_PS.Text = Val(TB_PS.Text)
    End Sub

    Private Sub TB_ZL_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_ZL.Leave
        TB_ZL.Text = Val(TB_ZL.Text)
    End Sub

    Private Sub Cmd_ChooseRemark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChooseRemark.Click
        ShowRemarkList()
    End Sub

    Protected Sub ShowRemarkList()
        Dim f As PClass.BaseForm = LoadFormIDToChild(10072, Me)
        If f Is Nothing Then Exit Sub
        f.P_F_RS_ID = TB_Remark.Text
        f.P_F_RS_ID2 = "/"

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        '  VF.Width = 800
        '  VF.Height = 400
        AddHandler VF.ClosedX, AddressOf setRemark
        VF.Show()
    End Sub

    Sub setRemark()
        If Me.ReturnMsg = "" Then
            Exit Sub
        End If

        Me.TB_Remark.Text = Me.ReturnMsg

        Me.ReturnMsg = ""
    End Sub






    Private Sub Cmd_ChooseDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ChooseDept.Click
        ShowDeptList()
    End Sub
    Protected Sub ShowDeptList()
        Dim f As PClass.BaseForm = LoadFormIDToChild(10080, Me)
        If f Is Nothing Then Exit Sub
        f.P_F_RS_ID = TB_Dept.Text
        f.P_F_RS_ID2 = "/"

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(f, Me)
        '  VF.Width = 800
        '  VF.Height = 400
        AddHandler VF.ClosedX, AddressOf setDepartment
        VF.Show()
    End Sub
    Sub setDepartment()
        If Me.ReturnMsg = "" Then
            Exit Sub
        End If

        Me.TB_Dept.Text = Me.ReturnMsg

        Me.ReturnMsg = ""
    End Sub
End Class

Partial Friend Class Dao
#Region "常量"
    Protected Friend Const InForm_DB_NAME As String = "回修通知单"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InForm_DelByid As String = "Delete from T30231_RetrunInform  where ID=@ID and State=0"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InForm_GetByid As String = "select top 1 * from T30231_RetrunInform  where ID=@ID"

    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_InForm_GetByidGH As String = " select T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No ,RI.* from  T30231_RetrunInform RI left join " & _
                                                  "  (select P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=RI.GH where RI.ID=@ID"

    Private Const SQL_Get_byGH As String = " select P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID Where P.GH=@GH  "

    Private Const SQL_Get_Dept As String = "   select Dept_No,Dept_Name From T15000_Department WHere LEN(Dept_No)=4                      "

    '    ''' <summary>
    '    ''' 获取单头
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    'Private Const SQL_InForm_SelByid As String = "select  * from T30225_BBSQ_Table  where ID=@ID"

    '    Private Const SQL_InForm_SelByid As String = "select BL.*,T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No,BT.Reason,BT.YFCS,BT.YFCS_ZG,BT.YFCS_Date,BT.CFCS,BT.CFCS_ZG,BT.CFCS_Date,BT.CBPS,BT.Reason_ZG,BT.Reason_Date from T30226_BBSQ_List BL left join T30225_BBSQ_Table BT ON BL.ID=BT.ID left join (select P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=BL.GH where BL.ID=@ID"

    '    ''' <summary>
    '    ''' 获取单头 用于作废和审核
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Const SQL_InForm_GetStateByid As String = "select top 1 ID,State,State_User from T30225_BBSQ_Table  where ID=@ID"
    '    ''' <summary>
    '    ''' 获取单体
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Const SQL_InForm_GetListByid As String = "select * from T30226_BBSQ_List  where ID=@ID "
    '    ''' <summary>
    '    ''' 获取单体,用于显示
    '    ''' </summary>
    '    ''' <remarks></remarks>0
    '    Private Const SQL_InForm_SelListByid As String = "select BL.*,T.Client_Name,T.BZ_Name,T.BZC_Name,T.BZC_No from T30226_BBSQ_List BL left join (select P.GH,P.Client_ID,P.BZ_ID,P.BZC_ID,BZ_Name,BZC_Name,BZC_No,Client_Name from  T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID ) T on T.GH=BL.GH where BL.ID=@ID"

    '    'Private Const SQL_InForm_SelListByid As String = " select * from T30226_BBSQ_List BL  left join T10002_BZ BZ on BL.BZ_ID=BZ.ID where ID=@ID "
    '    ''' 检查ID的重复性
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Const SQL_InForm_CheckID As String = "select * from T30225_BBSQ_Table  where ID=@ID"
    '    ''' <summary>
    '    ''' 检查ID的重复性
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Private Const SQL_InForm_CheckIsModify As String = "select count(*) from T30226_BBSQ_List  where @ID=ID and Line=@Line"
    '    ''' <summary>
    '    ''' 获取补布申请单信息
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public Const SQL_BBInForm_GetByID_WithName As String = "select P.*,C.Client_Name,BZ.BZ_Name,BZC.BZC_Name,BZC.BZC_No,l.ZL from T30000_Produce_Gd P  left join T10110_Client C on P.Client_ID=C.ID left join T10002_BZ BZ on P.BZ_ID=BZ.ID left join T10003_BZC BZC on P.BZC_ID=BZC.ID left join T40101_PBRK_List L on p.GH=L.GH   where P.GH=@GH  "


#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对日报表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InForm_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_InForm_GetByidGH, "@ID", sId)
    End Function



    ''' <summary>
    ''' 添加回修通知单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InForm_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim InFormId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", InFormId)
        Try
            sqlMap.Add("Table", SQL_InForm_GetByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & InFormId & "'," & BillType.Inform & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & InForm_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & InForm_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & InForm_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改回修通知单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InForm_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim InFormId As String = dtTable.Rows(0)("ID")
        dtTable.Rows(0)("ID") = LID
        paraMap.Add("ID", LID)
        Try
            sqlMap.Add("Table", SQL_InForm_GetByid)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Audited Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & InForm_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被审核不能再修改!"
                    Return R
                End If
                If msg.DtList("Table").Rows(0)("State") = Enum_State.Invoid Then
                    msg.DaList("Table").Dispose()
                    msg.DaList("List").Dispose()
                    msg.Cnn.Dispose()
                    R.IsOk = False
                    R.Msg = "" & InForm_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经被作废不能再修改!"
                    Return R
                End If
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                Dim TmSQL As String = "Update Bill_Barcode set No_ID='" & InFormId & "' where No_ID='" & LID & "' and NO_Type=" & BillType.Inform
                If LID <> InFormId Then
                    DtToUpDate(msg, "Update T30231_RetrunInform set id='" & InFormId & "' where id='" & LID & "'" & vbCrLf & TmSQL)
                    dtTable.Rows(0)("ID") = InFormId
                    R.Msg = "" & InForm_DB_NAME & "[" & LID & "]已经修改为[" & InFormId & "]!"
                Else
                    DtToUpDate(msg)
                    R.Msg = "" & InForm_DB_NAME & "[" & LID & "]修改成功!"
                End If
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & InForm_DB_NAME & "[" & LID & "]不存在"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & InForm_DB_NAME & "[" & LID & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 删除回修通知单
    ''' </summary>
    ''' <param name="InFormId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InForm_Del(ByVal InFormId As String)
        Return RunSQL(SQL_InForm_DelByid, "@ID", InFormId)
    End Function

    ''' <summary>
    ''' 作废回修通知单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsFei">作废还是反作废</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InForm_InValid(ByVal _ID As String, ByVal IsFei As Boolean) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        Dim OStr As String
        Dim State As Enum_State = Enum_State.AddNew
        If IsFei Then
            OStr = "作废"
            State = Enum_State.Invoid
        Else
            OStr = "反作废"
        End If
        paraMap.Add("ID", _ID)
        Try
            sqlMap.Add("Table", SQL_InForm_GetByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                If msg.DtList("Table").Rows(0)("State") <> Enum_State.Audited Then
                    If msg.DtList("Table").Rows(0)("State") <> State Then
                        msg.DtList("Table").Rows(0)("State") = State
                        msg.DtList("Table").Rows(0)("State_User") = User_Display
                        DtToUpDate(msg)
                        R.IsOk = True
                        R.Msg = "" & InForm_DB_NAME & "[" & _ID & "]" & OStr & "成功!"
                    Else
                        R.IsOk = False
                        R.Msg = "" & InForm_DB_NAME & "[" & _ID & "]已经被" & OStr & "!不能再" & OStr & "!"
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & InForm_DB_NAME & "[" & _ID & "]已经被审核,不能" & OStr & "!"
                End If
            Else
                R.IsOk = False
                R.Msg = "" & InForm_DB_NAME & "[" & _ID & "]不存在,不能" & OStr & "!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & InForm_DB_NAME & "[" & _ID & "]" & OStr & "错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function
    ''' <summary>
    ''' 审核回修通知单
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <param name="IsAudited">审核还是反审核</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function InForm_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
        Dim R As MsgReturn
        Dim s As String = IIf(IsAudited, "审核", "反审核")
        Dim state As Integer = IIf(IsAudited, 1, 0)

        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("ID", _ID)
        paraMap.Add("IsAudited", IsAudited)
        paraMap.Add("State_User", User_Display)

        '判断状态
        Dim msg As DtReturnMsg = SqlStrToDt("select state from  T30231_RetrunInform where ID=@ID  ", "ID", _ID)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 AndAlso IsNull(msg.Dt.Rows(0)("State"), False) = state Then
            R = New MsgReturn
            R.Msg = InForm_DB_NAME & s & "失败！[" & _ID & "]已被" & s
            Return R
        End If

        R = SqlStrToOneStr("Update T30231_RetrunInform set State=@IsAudited,State_User=@State_User where ID=@ID  ", paraMap)

        If R.IsOk Then
            R.Msg = InForm_DB_NAME & s & "成功！"
        Else
            R.Msg = InForm_DB_NAME & s & "失败！" & R.Msg

        End If

        Return R
    End Function

   
    ''' <summary>
    ''' 按缸号获取数据
    ''' </summary>
    ''' <param name="GH"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetZL_ByGH(ByVal GH As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Get_byGH, "@GH", GH)
    End Function


    ''' <summary>
    ''' 按缸号获取数据
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDep() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Get_Dept)
    End Function



#End Region
End Class