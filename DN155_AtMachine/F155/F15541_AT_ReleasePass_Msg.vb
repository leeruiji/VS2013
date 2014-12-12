Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F15541_AT_ReleasePass_Msg
    Dim LId As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    'Dim Bill_Id As String = ""
    Dim State As Enum_State = Enum_State.AddNew
    Dim IsBidings As Boolean = False
   

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Bill_ID = ""
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_Id = initID
        Me.Mode = Mode
    End Sub

    'Private Sub Me_AfterLoad() Handles Me.AfterLoad
    '    If Fg1.Rows.Count > 1 Then
    '        Fg1.RowSel = 1
    '        Fg1.Row = 1
    '        Fg1.Select(1, Fg1.Cols("WL_No").Index, 1, Fg1.Cols("WL_No").Index)
    '    End If
    'End Sub

    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
        
     
    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.ReleasePass, Bill_ID)
    End Sub

    Private Sub Form_Load() Handles Me.Me_Load
        ID = 15540
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        DTP_sDate.Value = GetDate()
        DP_Start.Value = GetTime()
        DP_End.Value = GetTime()
        If Bill_ID = "" AndAlso P_F_RS_ID <> "" Then
            Bill_ID = P_F_RS_ID
        End If

        Fg1.IniFormat()
        Me_Refresh()
        '    Dim T As New Threading.Thread(AddressOf GetDtMsg)
        '   T.Start()
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.ReleasePass_GetById(Bill_ID)
        If msgTable.IsOk Then
           
            dtTable = msgTable.Dt
        End If
        If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
            ShowErrMsg("没有找到" & Dao.ReleasePass_DB_NAME & "[" & Bill_ID & "]", True)
            Exit Sub
        End If
        SetForm(dtTable)

        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.ReleasePass_DB_NAME & "!", True) : Exit Sub
                Dim msg As DtReturnMsg = Dao.ReleasePass_SelListById(0)
                If msg.IsOk Then dtList = msg.Dt
                Fg1.Rows.Count = 1
                Fg1.ReAddIndex()
                Fg1.CanEditing = False
                LabelTitle.Text = "新建" & Me.Ch_Name
                ' 'Cmd_Preview.Enabled = False
                ' Cmd_Print.Enabled = False
                DTP_sDate.Value = GetDate()
                GetNewID()
            Case Mode_Enum.Modify
                ' Cmd_Preview.Enabled = True
                ' Cmd_Print.Enabled = True
                DTP_ReleaseDay.Enabled = False
                Dim msg As DtReturnMsg = Dao.ReleasePass_SelListById(Bill_ID)
                If msg.IsOk Then
                    dtList = msg.Dt
                    Fg1.DtToFG(msg.Dt)
                    Fg1.RowSetForce("Employee_ID", CInt(P_F_RS_ID3))
                End If
                LId = TB_ID.Text
                LabelTitle.Text = "修改" & Me.Ch_Name
        End Select

        dtTable.AcceptChanges()
        dtList.AcceptChanges()



    End Sub

    'Sub GetDtMsg()
    '    StoreDt = ComFun.GetStoreDt()
    '    CB_Store.DataSource = StoreDt
    'End Sub



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
        dr("ID") = TB_ID.Text
        dr("Remark") = TB_Remark.Text
        dr("sDate") = DTP_sDate.Value.Date
        dr("sRelease") = DTP_ReleaseDay.Value.Date
        dt.Rows.Add(dr)
        dt.AcceptChanges()
        dtList = dtList.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = dtList.NewRow
            dr("ID") = ID
            dr("Employee_ID") = Fg1.Item(i, "Employee_ID")
            dr("StartTime") = Fg1.Item(i, "StartTime")
            dr("EndTime") = Fg1.Item(i, "EndTime")
           
            dtList.Rows.Add(dr)
        Next
        dtList.AcceptChanges()
        Return dt
    End Function
#End Region

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If

       
        If dt.Rows.Count = 1 Then
            TB_ID.Text = IsNull(dt.Rows(0)("ID"), "")
            DTP_sDate.Value = dt.Rows(0)("sDate")
            DTP_ReleaseDay.Value = IsNull(dt.Rows(0)("sRelease"), GetDate)
        End If
    End Sub

  



#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SaveReleasePass)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改?", AddressOf SaveReleasePass)
                Else
                    ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SaveReleasePass)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SaveReleasePass(Optional ByVal Audit As Boolean = False)
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
       
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.ReleasePass_Add(Dt, dtList)
        Else
            R = Dao.ReleasePass_Save(LId, Dt, dtList)
        End If
        If R.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            'If Audit Then
            '    Dim msg As MsgReturn = Dao.ReleasePass_Audited(TB_ID.Text, True)
            '    If msg.IsOk Then
            '        Bill_Id = TB_ID.Text
            '        Me_Refresh()
            '        ShowOk(msg.Msg)
            '    Else
            '        ShowErrMsg("保存成功,但" & msg.Msg)
            '    End If
            '    Exit Sub
            'End If
            'If TB_ID.Text = Bill_Id.Replace("-", "") Then Bill_Id = ""
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
        If (Mode = Mode_Enum.Add Or (Mode = Mode_Enum.Modify And LId <> TB_ID.Text)) AndAlso Dao.ReleasePass_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If


        'For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
        '    Try
        '        If Val(Fg1.Item(i, "Qty")) < 0 Then
        '            Fg1.Item(i, "Qty") = -Val(Fg1.Item(i, "Qty"))
        '        End If
        '        If Val(Fg1.Item(i, "Qty")) = 0 OrElse Val(Fg1.Item(i, "Amount")) = 0 OrElse Val(Fg1.Item(i, "WL_ID")) = 0 Then
        '            Fg1.RemoveItem(i)
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next





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

#Region "FG 事件"


    'Private Sub CB_WL_Spec_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_WL_Spec.SelectionChangeCommitted
    '    Dim Dr As DataRow = CB_WL_Spec.SelectedItem.row
    '    Me.ReturnObj = Dr
    '    SetGoods
    'End Sub
    'Private Sub Fg1_SetupEditor(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.SetupEditor
    '    If e.Col = Fg1.Cols("WL_Spec").Index Then
    '        Dim T As String = Fg1.Item(Fg1.RowSel, "WL_Name")
    '        If T <> "" Then
    '            CB_WL_Spec.DataSource = BaseClass.ComFun.WL_GetByName(T).Dt
    '            CB_WL_Spec.DisplayMember = "WL_Spec"
    '            CB_WL_Spec.ValueMember = "ID"
    '            If CB_WL_Spec.Items.Count > 0 Then CB_WL_Spec.SelectedValue = Fg1.Item(Fg1.RowSel, "WL_ID")
    '        Else
    '            CB_WL_Spec.DataSource = Nothing
    '        End If
    '    End If
    'End Sub


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
        If e.Row < 0 Then
            Exit Sub
        End If
        If Fg1.LastKey = Keys.Enter Then
            Fg1.LastKey = 0
            Select Case Fg1.Cols(e.Col).Name
                Case "WL_No"

                Case "Price", "Qty"
                    Fg1.Item(e.Row, e.Col) = Val(Fg1.Item(e.Row, e.Col))

                    Fg1.GotoNextCell(e.Col)
                Case Else
                    Fg1.GotoNextCell(e.Col)
            End Select
        Else
            If Fg1.Cols(e.Col).Name = "WL_No" Then
                If Fg1.LastText <> Fg1.Item(Fg1.RowSel, Fg1.Cols(e.Col).Index) Then
                    Fg1.Item(Fg1.RowSel, "WL_ID") = 0
                    Fg1.Item(Fg1.RowSel, "WL_Name") = ""
                    Fg1.Item(Fg1.RowSel, "WL_Unit") = ""
                    Fg1.Item(Fg1.RowSel, "WL_Spec") = ""
                End If
            End If
        End If
    End Sub

    ''' <summary>
    '''增行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddRow()
    End Sub

    ''' <summary>
    ''' 增行
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub AddRow()
        Fg1.AddRow()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Fg1.RemoveRow()
    End Sub
    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "Price"
                e.ToCol = Fg1.Cols("Qty").Index
            Case "Qty", "LRemark"

                If e.Row + 2 > Fg1.Rows.Count Then
                    AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("WL_No").Index

            Case Else
                e.ToCol = Fg1.Cols("Price").Index
        End Select
    End Sub



    Private Sub Fg1_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.EnterCell
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.Cols(Fg1.ColSel).AllowEditing AndAlso Fg1.CanEditing Then
            Fg1.LastKey = 0
            Fg1.StartEditing()
        End If

    End Sub

    Private Sub Fg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Fg1.KeyDown
        If Fg1.RowSel < 0 Then
            Exit Sub
        End If
        If Fg1.CanEditing = True Then
            If e.KeyCode = Keys.Enter Then
                If Fg1.ColSel < Fg1.Cols("Qty").Index Then
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("Qty").Index)
                Else
                    Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("LRemark").Index)
                End If
            ElseIf e.KeyCode = Keys.Add AndAlso Fg1.Cols(Fg1.ColSel).Name = "WL_No" Then

            End If
        End If
    End Sub


#End Region







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
            ComFun.DelBillNewID(BillType.ReleasePass, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.ReleasePass, DTP_sDate.Value, Bill_ID)
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




#Region "审核状态"
    ''' <summary>
    ''' 审核状态
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Audit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并审核新" & Ch_Name & "?", AddressOf Shenhe)
            Else
                If CheckIsModify() Then
                    ShowConfirm(Ch_Name & "[" & TB_ID.Text & "] 已经被其他人修改过,是否覆盖别人的修改并且审核?", AddressOf Shenhe)
                Else
                    ShowConfirm("是否保存并审核" & Ch_Name & "[" & TB_ID.Text & "] ?", AddressOf Shenhe)
                End If
            End If
        End If
    End Sub
    Protected Sub Shenhe()
        SaveReleasePass(True)
    End Sub

    'Private Sub Cmd_UnAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShowConfirm("是否反审" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf UnAudit)
    'End Sub

    'Protected Sub UnAudit()
    '    Dim msg As MsgReturn = Dao.ReleasePass_Audited(TB_ID.Text, False)
    '    If msg.IsOk Then
    '        Me_Refresh()
    '        Me.LastForm.ReturnId = TB_ID.Text
    '        ShowOk(msg.Msg)
    '    Else
    '        ShowErrMsg(msg.Msg)
    '    End If
    'End Sub

    ''' <summary>
    ''' 删除按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf DelReleasePass)
    End Sub

    ''' <summary>
    ''' 删除采购单
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelReleasePass()
        Dim msg As MsgReturn = Dao.ReleasePass_Del(TB_ID.Text)
        If msg.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub


  

  

    '''' <summary>
    '''' 反作废
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    ''Private Sub Cmd_SetValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SetValid.Click
    '    ShowConfirm("是否反作废" & Ch_Name & " [" & TB_ID.Text & "]?", AddressOf ReleasePassValid)
    'End Sub

    '''' <summary>
    '''' 作废
    '''' </summary>
    ''''' <remarks></remarks>
    'Sub ReleasePassValid()
    '    Dim msg As MsgReturn = Dao.ReleasePass_InValid(TB_ID.Text, False)
    '    If msg.IsOk Then
    '        Me_Refresh()
    '        LastForm.ReturnId = TB_ID.Text
    '    Else
    '        ShowErrMsg(msg.Msg)
    '    End If
    'End Sub


#End Region


#Region "检查其他人有没有修改过"
    Private LastLine As Integer = 0
    Private Function CheckIsModify() As Boolean
        If Mode <> Mode_Enum.Add Then
            Return Dao.ReleasePass_CheckIsModify(LId, LastLine)
        End If
    End Function

#End Region



    Dim VF As PClass.ViewForm
    Dim F As F15542_AT_EmployeeSel
    Private Sub Cmd_Employee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Employee.Click
        If DP_Start.Value = DP_End.Value Then
            ShowErrMsg("放行时间未设置")
            Exit Sub
        End If



        Dim F = New F15542_AT_EmployeeSel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .parent_Form = Me
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        If VF Is Nothing OrElse VF.IsDisposed = True Then
            VF = PClass.PClass.LoadChildForm(F, Me)
        Else
            Me.VForm.ShowShadow()
        End If

        AddHandler VF.ClosedX, AddressOf getlist
        VF.Show()
    End Sub


    Private Sub getlist()
        If ReturnObj Is Nothing Then
            Exit Sub
        End If
        Dim Addlist As DataTable = dtList.Clone
        If dtList Is Nothing Then
            dtList = Dataswap(ReturnObj, dtList)

        Else
            Addlist = Dataswap(ReturnObj, Addlist)
            Dim R As DtReturnMsg = CheckTable(Addlist, dtList)
            If R.IsOk Then
                dtList.Merge(R.Dt)
            End If
        End If
        Fg1.DtToFG(dtList)
        Fg1.ReAddIndex()

    End Sub

    ''' <summary>
    '''数据交换
    ''' </summary>
    ''' <remarks></remarks>

    Private Function Dataswap(ByVal ob As Object, ByVal dt As DataTable) As DataTable
        Dim Dob As DataTable = TryCast(ob, DataTable)
        Dim S As Date
        Dim e As Date
        If DP_Start.Value < DP_End.Value Then
            S = CDate(DTP_ReleaseDay.Value.Date & " " & DP_Start.Value.ToString("HH:mm"))
            e = CDate(DTP_ReleaseDay.Value.Date & " " & DP_End.Value.ToString("HH:mm"))
        Else
            S = CDate(DTP_ReleaseDay.Value.Date & " " & DP_Start.Value.ToString("HH:mm"))
            e = CDate(DTP_ReleaseDay.Value.Date.AddDays(1) & " " & DP_End.Value.ToString("HH:mm"))
        End If
   

        For Each row As DataRow In Dob.Rows
            If row.RowState = DataRowState.Deleted Then
                Continue For
            End If
            Dim dtrow As DataRow = dt.NewRow
            dtrow("Dept_Name") = row("Dept_Name")
            dtrow("Employee_Name") = row("Employee_Name")
            dtrow("StartTime") = s
            dtrow("EndTime") = e
            dtrow("Employee_ID") = row("ID")
            dt.Rows.Add(dtrow)
        Next

        Return dt

    End Function





    ''' <summary>
    ''' 将两个表相同数据去除
    ''' </summary>
    ''' <remarks></remarks>

    Private Function CheckTable(ByVal dl As DataTable, ByVal dlist As DataTable) As DtReturnMsg
        Dim R As New DtReturnMsg
        If dl Is Nothing OrElse dlist Is Nothing Then
            R.IsOk = False
        End If
        Dim check As Boolean = False
        Dim dt As DataTable = dl.Clone
        For Each dr As DataRow In dl.Rows
            For i As Integer = 0 To dlist.Rows.Count - 1
                If dr("Employee_ID") = dlist.Rows(i)("Employee_ID") Then
                    check = True
                    Exit For

                End If

            Next
            If check = False Then
                dt.ImportRow(dr)
            End If
            check = False
        Next
        R.Dt = dt
        R.IsOk = True
        Return R
    End Function


    Private Sub Cmd_Dellist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Dellist.Click
        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Fg1.RemoveRow()
        Next
    End Sub

   
    Private Sub TSM_De_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_De.Click
        For i As Integer = Fg1.Selection.BottomRow To Fg1.Selection.TopRow Step -1
            Fg1.Rows.Remove(i)
        Next
    End Sub
End Class




Partial Friend Class Dao
#Region "常量"
    Protected Friend Const ReleasePass_DB_NAME As String = "放行条"
    ''' <summary>
    ''' 删除单据
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ReleasePass_DelByid As String = "Delete from T15540_AT_ReleasePass  where ID=@ID "
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ReleasePass_GetByid As String = "select top 1 * from T15540_AT_ReleasePass where ID=@ID"
    ''' <summary>
    ''' 获取单头
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ReleasePass_SelByid As String = "select T.*,C.Supplier_Name From (Select top 1 * from T20000_Puchase_Table where ID=@ID)  T left join T10100_Supplier C on C.ID=T.Supplier_ID"


    ''' <summary>
    ''' 获取单头 用于作废和审核
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ReleasePass_GetStateByid As String = "select top 1 ID,State,State_User from T20000_Puchase_Table  where ID=@ID"
    ''' <summary>
    ''' 获取单体
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ReleasePass_GetListByid As String = "select * from T15541_AT_ReleasePass_List  where ID=@ID "
    ''' <summary>
    ''' 获取单体,用于显示
    ''' </summary>
    ''' <remarks></remarks>0
    Private Const SQL_ReleasePass_SelListByid As String = "select L.ID,L.Employee_ID ,L.StartTime,L.EndTime,E.Employee_Name,D.Dept_Name from T15541_AT_ReleasePass_List L left join T15001_Employee E ON L.Employee_ID=E.ID left join  T15000_Department D on E.Employee_Dept=D.Dept_No where L.ID=@ID ORDER BY D.Dept_Name"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ReleasePass_CheckID As String = "select count(*) from T20000_Puchase_Table  where ID=@ID"
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SQL_ReleasePass_CheckIsModify As String = "select count(*) from T20001_Puchase_List  where @ID=ID and Line=@Line"
#End Region


#Region "单一张单内容查询"
    ''' <summary>
    ''' 获取对采购单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReleasePass_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ReleasePass_GetByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对采购单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReleasePass_SelListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ReleasePass_SelListByid, "@ID", sId)
    End Function
#End Region



#Region "添加修改删除"

    ''' <summary>
    ''' 检查其他人有没有修改过
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReleasePass_CheckIsModify(ByVal ID As String, ByVal Line As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("Line", Line)
        Dim R As MsgReturn = SqlStrToOneStr(SQL_ReleasePass_CheckIsModify, P)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' 检查ID的重复性
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReleasePass_CheckID(ByVal ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_ReleasePass_CheckID, "@ID", ID)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 添加采购单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReleasePass_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ReleasePassId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ReleasePassId)
        Try
            sqlMap.Add("Table", SQL_ReleasePass_GetByid)
            sqlMap.Add("List", SQL_ReleasePass_GetListByid)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                R.Msg = "" & ReleasePass_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ReleasePass_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & ReleasePass_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function

    ''' <summary>
    ''' 修改采购单
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReleasePass_Save(ByVal LID As String, ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim R As New MsgReturn
        Dim ReleasePassId As String = dtTable.Rows(0)("ID")
        paraMap.Add("ID", ReleasePassId)
        Try
            sqlMap.Add("Table", SQL_ReleasePass_GetByid)
            sqlMap.Add("List", SQL_ReleasePass_GetListByid)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DtToUpDate(msg)
                R.Msg = "" & ReleasePass_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & ReleasePass_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]不存在"
            End If
            Return R
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & ReleasePass_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]修改错误"
            DebugToLog(ex)
            Return R
        Finally

        End Try
    End Function


    '''' <summary>
    '''' 审核采购单
    '''' </summary>
    '''' <param name="_ID"></param>
    '''' <param name="IsAudited">审核还是反审核</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function ReleasePass_Audited(ByVal _ID As String, ByVal IsAudited As Boolean) As MsgReturn
    '    Dim paraMap As New Dictionary(Of String, Object)
    '    paraMap.Add("ID", _ID)
    '    paraMap.Add("IsAudited", IsAudited)
    '    paraMap.Add("State_User", User_Display)
    '    Dim R As MsgReturn = SqlStrToOneStr("P20000_Puchase_Audited", paraMap, True)
    '    If R.IsOk Then
    '        If R.Msg.StartsWith("1") Then
    '            R.IsOk = True
    '        Else
    '            R.IsOk = False
    '        End If
    '        R.Msg = R.Msg.Substring(1)
    '    End If
    '    Return R
    'End Function
#End Region


    ''' <summary>
    ''' 删除放行条
    ''' </summary>
    ''' <param name="ReleasePassId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReleasePass_Del(ByVal ReleasePassId As String)
        Return RunSQL(SQL_ReleasePass_DelByid, "@ID", ReleasePassId)
    End Function







End Class