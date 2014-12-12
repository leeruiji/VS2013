Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F10051_Work_Msg
    Dim ImagArray As Byte()
    Dim Work_Id As Integer = 0

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


        Me.Work_Id = goodsID
        Me.Mode = Mode

    End Sub

    Private Sub F10001_BZ_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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

        Control_CheckRight(10030, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(10030, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load


        Dim msgStep As DtReturnMsg = BaseClass.ComFun.Productive_GetList()
        If msgStep.IsOk Then
            CB_Dept.DataSource = msgStep.Dt
            CB_Dept.DisplayMember = "Dept_Name"
            CB_Dept.ValueMember = "Dept_No"
        End If

        Dim Dt As DataTable = BaseClass.ComFun.GH_GetStateTable()
        Dt.Rows(0).Delete()
        Dt.AcceptChanges()
        CB_Process.DataSource = Dt
        CB_Process.DisplayMember = "StateName"
        CB_Process.ValueMember = "State"



        FormCheckRight()
        '  GetSupplierList()
        Me_Refresh()

        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            If CheckRight(10030, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            Work_Id = 0
            TB_ID.Text = Dao.Work_GetNewID()

        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Work_GetById(Work_Id)
        If msg.IsOk Then
            dtTable = msg.Dt
            SetForm(msg.Dt)
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
            If Mode <> Mode_Enum.Add Then dr("ID") = Work_Id
            dt.Rows(0)("Work_No") = TB_ID.Text
            dt.Rows(0)("Work_Name") = TB_Name.Text
            dt.Rows(0)("Remark") = TB_Remark.Text

            dt.Rows(0)("Dept_No") = CB_Dept.SelectedValue
            dt.Rows(0)("Dept_Name") = CB_Dept.Text
            dt.Rows(0)("Process") = CB_Process.SelectedValue
            dt.Rows(0)("Correction") = CB_Correction.Checked

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
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("Work_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("Work_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")


            CB_Dept.SelectedValue = dt.Rows(0)("Dept_No")
            CB_Process.SelectedValue = dt.Rows(0)("Process")
            CB_Correction.Checked = IsNull(dt.Rows(0)("Correction"), False)

            TB_UPD_USER.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))
            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Value = dt.Rows(0)("UPD_DATE")
            End If

        Else
            TB_ID.Text = Me.Work_Id
            TB_Name.Text = ""
            TB_UPD_USER.Text = ""
            TB_Founder.Tag = PClass.PClass.User_ID
            TB_Founder.Text = PClass.PClass.User_Name
        End If

    End Sub



#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存加工内容[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Work_Add(GetForm())
        Else
            R = Dao.Work_Save(GetForm())
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            Me.Close()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_ID.Text = "" Then
            ShowErrMsg("编号不能为空")
            TB_ID.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("加工内容不能为空")
            TB_Name.Focus()
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除加工内容[" & TB_ID.Text & "]?", AddressOf DelGoods)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoods()
        Dim msg As MsgReturn = Dao.Work_Del(Work_Id)
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








    Private Sub PanelMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelMain.Paint

    End Sub
End Class


Partial Class Dao
    Public Const Work_Bill_NAME As String = "加工内容"

#Region "加工内容"
    Public Const SQL_Work_NameCheckDuplicate = "select count(*) from T10022_Work where Work_No=@Work_No and id<>@id"


    Public Const SQL_Work_Get As String = "select * from T10022_Work "

    Public Const SQL_Work_GetByID As String = "select top 1 * from T10022_Work where ID=@ID"

    Public Const SQL_Work_GetByNo As String = "select * from T10022_Work where Work_No=@Work_No"

    Public Const SQL_Work_GetByID_ExceptImage As String = "select ID,Work_No,Work_Name,Work_Remark,Founder,Found_Date,Upd_User,Upd_Date from T10022_Work where ID=@ID"

    Public Const SQL_Work_DelByid As String = "Delete from  T10022_Work where ID=@ID "

    Public Const SQL_Work_OrderBy As String = " order by  Work_No "

    '  Public Const SQL_Work_GeList_ByIDWithName = "select P.*,WL_Name,WL_No,WL_Spec from T10005_WorkList  P left join T10001_WL W on P.WL_ID=W.ID where  P.ID=@ID "


    Public Const SQL_Work_InsertNewID = "if exists (select * from T10022_Work where Work_No= @Work_No)" & vbCrLf & _
                                            "select -1" & vbCrLf & _
                                            "else" & vbCrLf & _
                                            "begin" & vbCrLf & _
                                            "insert into T10022_Work(Work_No)Values(@Work_No)" & vbCrLf & _
                                            "select @@IDENTITY" & vbCrLf & _
                                            "end"
#End Region

    ''' <summary>
    ''' 获取所有加工内容信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Work_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "编号"
        fo.DB_Field = "Work_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "加工内容"
        fo.DB_Field = "Work_Name"
        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取加工内容信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_Work_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_Work_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取加工内容信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_GetById(ByVal sId As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Work_GetByID, "@Id", sId)
    End Function


    ''' <summary>
    ''' 增加一个加工内容
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_Add(ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim _No As String = dtTable.Rows(0)("Work_No")
        Dim IsInsert As Boolean = False
        Dim ID As Integer = 0
        Try
            Dim newIdMsg As MsgReturn = SqlStrToOneStr(SQL_Work_InsertNewID, "@Work_No", _No)
            If newIdMsg.IsOk Then
                If Val(newIdMsg.Msg) = -1 Then
                    R.IsOk = False
                    R.Msg = Work_Bill_NAME & "编号[" & dtTable.Rows(0)("Work_No") & "]已经存在!"
                    Return R
                Else
                    ID = Val(newIdMsg.Msg)
                    dtTable.Rows(0)("ID") = ID
                End If
            End If
            paraMap.Add("ID", ID)
            sqlMap.Add("Table", SQL_Work_GetByID)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then

                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & Work_Bill_NAME & "[" & dtTable.Rows(0)("Work_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Work_Bill_NAME & "[" & dtTable.Rows(0)("Work_Name") & "]已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Work_Bill_NAME & "[" & dtTable.Rows(0)("Work_Name") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function



    ''' <summary>
    '''修改一个加工内容
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_Save(ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ID As Integer = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ID)
        Try
            sqlMap.Add("Table", SQL_Work_GetByID)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then

                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))

                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & Work_Bill_NAME & "[" & dtTable.Rows(0)("Work_Name") & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & Work_Bill_NAME & "[" & dtTable.Rows(0)("Work_Name") & "]不存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & Work_Bill_NAME & "[" & dtTable.Rows(0)("Work_Name") & "]修改错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="Work_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_NameCheckDuplicate(ByVal Work_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("Work_No", Work_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_Work_NameCheckDuplicate, P)
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
    Public Shared Function Work_Del(ByVal BZId As String)
        Return RunSQL(SQL_Work_DelByid, "@ID", BZId)
    End Function

    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Work_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", "T10022_Work")
        paraMap.Add("@Id_Str", "")
        paraMap.Add("@Field", "Work_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return Format(Val(msgID.Msg), "000")
        Else
            Return ""
        End If
    End Function



    'Public Shared Function Work_GetList_ByID(ByVal _ID As Integer) As DtReturnMsg
    '    Dim R As New DtReturnMsg
    '    Dim sql As String = SQL_Work_GeList_ByIDWithName
    '    Dim para As New Dictionary(Of String, Object)
    '    para.Add("@ID", _ID)
    '    R = PClass.PClass.SqlStrToDt(sql, para)
    '    Return R
    'End Function






End Class