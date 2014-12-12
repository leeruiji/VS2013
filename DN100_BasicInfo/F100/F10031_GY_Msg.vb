Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F10031_GY_Msg
    Dim ImagArray As Byte()
    Dim GY_Id As Integer = 0

    Dim dtTable As DataTable
    Dim dtList As DataTable
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal goodsID As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()


        Me.GY_Id = goodsID
        Me.Mode = Mode

    End Sub

    Private Sub F10001_BZ_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        Control_CheckRight(10030, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(10030, ClassMain.Del, Cmd_Del)
        Control_CheckRight(10030, ClassMain.Lock, Cmd_Lock)
        Control_CheckRight(10030, ClassMain.Unlock, Cmd_UnLock)
        Control_CheckRight(10030, ClassMain.Invoid, Cmd_Invoid)
        Control_CheckRight(10030, ClassMain.UnInvoid, Cmd_UnInvoid)
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load

        Fg1.Cols("WL_No").Editor = CB_WL_FG
        Fg1.IniColsSize()

        Dim msgStep As DtReturnMsg = BaseClass.ComFun.Remark_GetList(Enum_RemarkType.Dying_Step)
        If msgStep.IsOk Then
            CB_DyingStep.DataSource = msgStep.Dt
            CB_DyingStep.DisplayMember = "Remark"
            CB_DyingStep.ValueMember = "Remark"

        End If
        Fg1.Cols("DyingStep").Editor = CB_DyingStep
        FormCheckRight()
        '  GetSupplierList()
        Me_Refresh()

        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            If CheckRight(10030, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            GY_Id = 0
            TB_ID.Text = Dao.GY_GetNewID()

        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.GY_GetById(GY_Id)
        If msg.IsOk Then
            dtTable = msg.Dt
            SetForm(msg.Dt)
        End If
        Dim msgList As DtReturnMsg = ComFun.GY_GetList_ByID(GY_Id)
        If msgList.IsOk Then
            dtList = msgList.Dt
            Fg1.DtToSetFG(dtList)
        End If
    End Sub

    '#Region "Combobox"

    '    Protected Sub GetSupplierList()
    '        Dim msg As DtReturnMsg = Supplier_GetAll()
    '        If msg.IsOk Then
    '            CB_Supplier.DataSource = msg.Dt
    '        End If
    '    End Sub

    '#End Region

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtTable.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
            If Mode <> Mode_Enum.Add Then dr("ID") = GY_Id
            dt.Rows(0)("GY_No") = TB_ID.Text
            dt.Rows(0)("GY_Name") = TB_Name.Text
            If Not PB_Image.ImageLocation Is Nothing AndAlso Not ImagArray Is Nothing AndAlso ImagArray.Length > 1 Then

                dt.Rows(0)("GY_Image") = ImagArray
            End If
            dt.Rows(0)("GY_Remark") = TB_Remark.Text
            dt.Rows(0)("Founder") = TB_Founder.Tag
            dt.Rows(0)("Found_Date") = DP_Found_Date.Value
            dt.Rows(0)("UPD_USER") = PClass.PClass.User_ID
            dt.Rows(0)("UPD_DATE") = Today
            dt.Rows(0)("State") = Enum_State.AddNew
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        Dim State As Enum_State
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("GY_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("GY_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("GY_Remark"), "")
            TB_UPD_USER.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))
            State = IsNull(dt.Rows(0)("State"), Enum_State.AddNew)
            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Value = dt.Rows(0)("UPD_DATE")
            End If
            If Not dt.Rows(0)("GY_Image") Is DBNull.Value Then
                ImagArray = dt.Rows(0)("GY_Image")
                Using io As New IO.MemoryStream(ImagArray)
                    Dim bmp As New Bitmap(io)
                    PB_Image.Image = bmp
                End Using
            Else
                PB_Image.Image = Nothing
            End If

            Select Case State
                Case Enum_State.AddNew
                    LB_State.Text = ""
                    Cmd_Modify.Enabled = True
                    Cmd_Lock.Enabled = True
                    Cmd_UnLock.Enabled = False
                    Cmd_Invoid.Enabled = True
                    Cmd_UnInvoid.Enabled = False
                    lockForm(True)
                Case Enum_State.Audited
                    LB_State.Text = "锁定"
                    Cmd_Modify.Enabled = False
                    Cmd_Lock.Enabled = False
                    Cmd_UnLock.Enabled = True
                    Cmd_Invoid.Enabled = False
                    Cmd_UnInvoid.Enabled = False
                    lockForm(False)
                Case Enum_State.Invoid
                    LB_State.Text = "作废"
                    Cmd_Modify.Enabled = False
                    Cmd_Lock.Enabled = False
                    Cmd_UnLock.Enabled = False
                    Cmd_Invoid.Enabled = False
                    Cmd_UnInvoid.Enabled = True
                    lockForm(False)
            End Select

        Else
            TB_ID.Text = Me.GY_Id
            TB_Name.Text = ""
            TB_UPD_USER.Text = ""
            TB_Founder.Tag = PClass.PClass.User_ID
            TB_Founder.Text = PClass.PClass.User_Name
            LB_State.Visible = False
            State = Enum_State.AddNew
            Cmd_Modify.Enabled = True
            Cmd_Lock.Enabled = False
            Cmd_UnLock.Enabled = False
            Cmd_Invoid.Enabled = False
            Cmd_UnInvoid.Enabled = False
        End If

    End Sub

    Private Sub lockForm(ByVal lock As Boolean)
        LB_State.Visible = Not lock
        TB_ID.Enabled = lock
        TB_Name.Enabled = lock
        TB_Remark.Enabled = lock
        Fg1.EditFormat = lock
        Btn_ChooseImage.Enabled = lock
        Cmd_Clear.Enabled = lock
    End Sub



    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetList()
        Dim dt As DataTable = dtList.Clone
        Dim dr As DataRow
        For i = 1 To Fg1.Rows.Count - 1
            If Val(Fg1.Item(i, "WL_ID")) = 0 AndAlso Fg1.Item(i, "DyingStep") = "" Then
                Continue For
            End If
            dr = dt.NewRow
            dr("ID") = GY_Id
            dr("Qty") = Val(Fg1.Item(i, "Qty"))
            dr("WL_ID") = Val(Fg1.Item(i, "WL_ID"))
            dr("DyingStep") = Fg1.Item(i, "DyingStep")
            dt.Rows.Add(dr)
        Next
        dtList = dt
    End Sub
#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存工艺[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save(Optional ByVal islock As Boolean = False)
        Dim R As MsgReturn
        GetList()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.GY_Add(GetForm(), dtList)
        Else
            R = Dao.GY_Save(GetForm(), dtList)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            If islock AndAlso Mode = Mode_Enum.Modify Then
                Dim msg As MsgReturn = Dao.GY_SetState_ByID(GY_Id, Enum_State.Audited, "锁定", TB_Name.Text)
                If msg.IsOk Then
                    LastForm.ReturnId = Me.TB_ID.Text
                    Bill_ID = TB_ID.Text
                    Mode = Mode_Enum.Modify
                    Me_Refresh()
                    ShowOk(msg.Msg)
                Else
                    ShowErrMsg("保存成功,但" & msg.Msg)
                End If
                Exit Sub
            End If
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        Fg1.FinishEditing(False)
        If TB_ID.Text = "" Then
            ShowErrMsg("工艺编号不能为空")
            TB_ID.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("工艺名称不能为空")
            TB_Name.Focus()
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除工艺[" & TB_ID.Text & "]?", AddressOf DelGoods)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()
        Dim msg As MsgReturn = Dao.GY_Del(GY_Id)
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





#End Region

#Region "选择图片"
    '===================
    ''' <summary>
    ''' 打开文件选择框
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_ChooseImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChooseImage.Click
        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PB_Image.ImageLocation = OpenFileDialog1.FileName
            Using io As New IO.FileStream(PB_Image.ImageLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                ReDim ImagArray(io.Length - 1)
                io.Read(ImagArray, 0, io.Length)

                Try
                    Dim bmp As New Bitmap(io)
                    PB_Image.Image = bmp
                Catch ex As Exception
                    ShowErrMsg("你选择的不是图片文件!")
                End Try


            End Using

        End If
    End Sub
#End Region

#Region "FG事件"
#Region "WL选择"

    Dim IsWLSelect As Boolean
    Private Sub CB_WL_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_WL_FG.Col_Sel
        IsWLSelect = True
        FG1.Item(FG1.RowSel, "WL_Name") = Col_Name
        FG1.Item(FG1.RowSel, "WL_ID") = ID
        FG1.GotoNextCell("WL_No")
    End Sub
    Private Sub CB_WL_FG_SetEmpty() Handles CB_WL_FG.SetEmpty
        FG1.Item(FG1.RowSel, "WL_ID") = 0
        FG1.Item(FG1.RowSel, "WL_No") = ""
        FG1.Item(FG1.RowSel, "WL_Name") = ""
        FG1.Item(FG1.RowSel, "Qty") = 0
    End Sub
    Private Sub CB_WL_FG_Col_SelRow(ByVal Dr As System.Data.DataRow) Handles CB_WL_FG.Col_SelRow
        FG1.Item(FG1.RowSel, "WL_Spec") = Dr("WL_Spec")

    End Sub
    Private Sub CB_WL_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_WL_FG.GetSearchEvent
        CB_WL_FG.IDValue = FG1.Item(FG1.RowSel, "WL_ID")
    End Sub

    Sub FG_WL_No()
        FG1.StartEditing(FG1.RowSel, FG1.Cols("WL_No").Index)
    End Sub
#End Region

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Col = Fg1.Cols("WL_No").Index Then
            If Fg1.LastKey = Keys.Enter Then
                CB_WL_FG.Col_SelOne()
                If Fg1.Item(e.Row, "WL_Name") = "" Then
                    ShowErrMsg("请输入一个物料编号!", AddressOf FG_WL_No)
                End If
            Else
                If Fg1.LastText <> IsNull(Fg1.Item(e.Row, "WL_No"), "") AndAlso IsWLSelect = False Then
                    Fg1.Item(Fg1.RowSel, "WL_ID") = 0
                    Fg1.Item(Fg1.RowSel, "WL_Name") = ""
                    Fg1.Item(Fg1.RowSel, "WL_Spec") = ""
                End If
                IsWLSelect = False
            End If
        Else
            If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell()
        End If
    End Sub


    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        If e.Col = "Qty" Then
            If e.Row + 2 > Fg1.Rows.Count And Cmd_AddRow.Enabled Then
                Fg1.Cols("DyingStep").AllowEditing = False
                Fg1.Rows.Add()
                Fg1.ReAddIndex()
                Fg1.Cols("DyingStep").AllowEditing = True
            End If
            If e.Row + 2 > Fg1.Rows.Count Then
                e.ToCol = Fg1.Cols("Qty").Index
            Else
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("WL_No").Index
            End If
        ElseIf e.Col = "WL_No" Then
            e.ToCol = Fg1.Cols("Qty").Index

        End If
    End Sub
#End Region
    Private Sub PB_Image_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Image.DoubleClick
        Dim F As New F10032_GY_Image(PB_Image.Image)

        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetImage
        VF.Show()
    End Sub

    Protected Sub SetImage()
        If ReturnId.Length > 0 Then
            PB_Image.ImageLocation = ReturnId
        End If
    End Sub

    Private Sub Cmd_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddRow.Click
        Fg1.AddRow()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        PB_Image.ImageLocation = ""

        ReDim ImagArray(0)



        PB_Image.Image = Nothing


    End Sub

#Region "状态设置"
    Private Sub Cmd_Lock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Lock.Click
        Fg1.FinishEditing(False)
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存并锁定新" & Ch_Name & "[" & TB_Name.Text & "]?", AddressOf lock)
            Else
               
                ShowConfirm("是否保存并锁定" & Ch_Name & "[" & TB_Name.Text & "] ?", AddressOf lock)
            End If
        End If
    End Sub

    Private Sub Cmd_UnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnLock.Click
        ShowConfirm("是否反锁定［" & TB_Name.Text & "］", AddressOf UnLock)
    End Sub

    Private Sub Cmd_Invoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Invoid.Click
        ShowConfirm("是否作废［" & TB_Name.Text & "］", AddressOf Invoice)
    End Sub

    Private Sub Cmd_UnInvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_UnInvoid.Click
        ShowConfirm("是否反作废［" & TB_Name.Text & "］", AddressOf UnInvoice)
    End Sub


    Private Sub lock()
        Save(True)
    End Sub


    Private Sub UnLock()
        SetState(Enum_State.AddNew, "解锁")
    End Sub


    Private Sub Invoice()
        SetState(Enum_State.Invoid, "作废")
    End Sub

    Private Sub UnInvoice()
        SetState(Enum_State.AddNew, "反作废")
    End Sub

    Private Sub SetState(ByVal State As Enum_State, ByVal StateName As String)
        Dim msg As MsgReturn = Dao.GY_SetState_ByID(GY_Id, State, StateName, TB_Name.Text)
        If msg.IsOk Then
            LastForm.ReturnId = Me.TB_ID.Text
            Bill_ID = TB_ID.Text
            Mode = Mode_Enum.Modify
            Me_Refresh()
            ShowOk(msg.Msg)
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

#End Region

End Class




Partial Class Dao
    Public Const GY_Bill_NAME As String = "染色工艺"

#Region "工艺"
    Public Const SQL_GY_NameCheckDuplicate = "select count(*) from T10004_GY where GY_No=@GY_No and id<>@id"


    Public Const SQL_GY_Get As String = "select ID,GY_No,GY_Name,GY_Remark,Founder,Found_Date,Upd_User,Upd_Date ,isnull(State,0) as State, case State when 1 then 1 else 0 end  as isLock, case State when -1 then 1 else 0 end as isInvoid   from T10004_GY "

    Public Const SQL_GY_GetByID As String = "select top 1 * from T10004_GY where ID=@ID"
    Public Const SQL_GY_GetListByID As String = "select * from T10005_GYList where ID=@ID"
    Public Const SQL_GY_GetByNo As String = "select * from T10004_GY where GY_No=@GY_No"

    Public Const SQL_GY_GetByID_ExceptImage As String = "select ID,GY_No,GY_Name,GY_Remark,Founder,Found_Date,Upd_User,Upd_Date from T10004_GY where ID=@ID"

    Public Const SQL_GY_DelByid As String = "Delete from  T10004_GY where ID=@ID "

    Public Const SQL_GY_OrderBy As String = " order by  GY_No "

    '  Public Const SQL_GY_GeList_ByIDWithName = "select P.*,WL_Name,WL_No,WL_Spec from T10005_GYList  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID "


    Public Const SQL_GY_InsertNewID = "if exists (select * from T10004_GY where GY_No= @GY_No)" & vbCrLf & _
                                            "select -1" & vbCrLf & _
                                            "else" & vbCrLf & _
                                            "begin" & vbCrLf & _
                                            "insert into T10004_GY(GY_No)Values(@GY_No)" & vbCrLf & _
                                            "select @@IDENTITY" & vbCrLf & _
                                            "end"


    Public Const SQL_Set_GYState = " Update T10004_GY Set State=@State Where ID=@ID  "


#End Region

    ''' <summary>
    ''' 获取所有工艺信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GY_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "工艺编号"
        fo.DB_Field = "GY_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "工艺名称"
        fo.DB_Field = "GY_Name"
        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取工艺信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_GY_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_GY_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取工艺信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_GetById(ByVal sId As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GY_GetByID, "@Id", sId)
    End Function


    ''' <summary>
    ''' 增加一个工艺
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_Add(ByVal dtTable As DataTable, ByVal DtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim _No As String = dtTable.Rows(0)("GY_No")
        Dim IsInsert As Boolean = False
        Dim ID As Integer = 0
        Try
            Dim newIdMsg As MsgReturn = SqlStrToOneStr(SQL_GY_InsertNewID, "@GY_No", _No)
            If newIdMsg.IsOk Then
                If Val(newIdMsg.Msg) = -1 Then
                    R.IsOk = False
                    R.Msg = GY_Bill_NAME & "编号[" & dtTable.Rows(0)("GY_No") & "]已经存在!"
                    Return R
                Else
                    ID = Val(newIdMsg.Msg)
                    dtTable.Rows(0)("ID") = ID
                    For Each dr As DataRow In DtList.Rows
                        dr("ID") = ID
                    Next
                End If
            End If
            paraMap.Add("ID", ID)
            sqlMap.Add("Table", SQL_GY_GetByID)
            sqlMap.Add("List", SQL_GY_GetListByID)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvToDt(DtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & GY_Bill_NAME & "[" & dtTable.Rows(0)("GY_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & GY_Bill_NAME & "[" & dtTable.Rows(0)("GY_Name") & "]已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & GY_Bill_NAME & "[" & dtTable.Rows(0)("GY_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function



    ''' <summary>
    '''修改一个工艺
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_Save(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ID As Integer = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ID)
        Try
            sqlMap.Add("Table", SQL_GY_GetByID)
            sqlMap.Add("List", SQL_GY_GetListByID)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvToDt(dtList, msg.DtList("List"), New List(Of String))
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))

                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & GY_Bill_NAME & "[" & dtTable.Rows(0)("GY_Name") & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & GY_Bill_NAME & "[" & dtTable.Rows(0)("GY_Name") & "]不存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & GY_Bill_NAME & "[" & dtTable.Rows(0)("GY_Name") & "]修改错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="GY_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_NameCheckDuplicate(ByVal GY_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("GY_No", GY_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_GY_NameCheckDuplicate, P)
        If r.IsOk Then
            If Val(r.Msg) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="BZId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_Del(ByVal BZId As String)
        Return RunSQL(SQL_GY_DelByid, "@ID", BZId)
    End Function

    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10004_GY")
        paraMap.Add("@Id_Str", "")
        paraMap.Add("@Field", "GY_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return Format(Val(msgID.Msg), "000")
        Else
            Return ""
        End If
    End Function



    ''' <summary>
    ''' 设置染色工艺状态
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GY_SetState_ByID(ByVal _ID As Integer, ByVal state As Enum_State, ByVal StateName As String, ByVal RZ As String) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _ID)
        p.Add("State", state)
        Dim msg As MsgReturn = PClass.PClass.RunSQL(SQL_Set_GYState, p)
        If msg.IsOk Then
            msg.Msg = "染色工艺［" & RZ & "］" & StateName & "成功"
        Else
            msg.Msg = "染色工艺［" & RZ & "］" & StateName & "失败"
        End If
        Return msg
    End Function

End Class