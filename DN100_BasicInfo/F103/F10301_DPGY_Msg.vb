Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F10301_DPGY_Msg
    Dim ImagArray As Byte()
    Dim DPGY_Id As Integer = 0

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


        Me.DPGY_Id = goodsID
        Me.Mode = Mode

    End Sub

    Private Sub F10036_BZ_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        ID = 10300
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub FormLoad() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        '  GetSupplierList()

        Me_Refresh()


        If Mode = Mode_Enum.Add Then

            Cmd_Del.Visible = False
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            DPGY_Id = 0
            TB_ID.Text = Dao.DPGY_GetNewID()

        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.DPGY_GetById(DPGY_Id)
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
            If Mode <> Mode_Enum.Add Then dr("ID") = DPGY_Id
            dt.Rows(0)("DPGY_No") = TB_ID.Text
            dt.Rows(0)("DPGY_Name") = TB_Name.Text

            dt.Rows(0)("DPGY_Color") = CB_DPGY_Color.Text

            dt.Rows(0)("DPGY_JS") = TB_DPGY_JS.Text
            dt.Rows(0)("DPGY_WD") = TB_DPGY_WD.Text
            dt.Rows(0)("DPGY_SCW") = TB_DPGY_SCW.Text
            dt.Rows(0)("DPGY_XCW") = TB_DPGY_XCW.Text
            dt.Rows(0)("DPGY_FS") = TB_DPGY_FS.Text
            dt.Rows(0)("DPGY_YS") = CB_DPGY_YS.Text
            dt.Rows(0)("DPGY_Remark") = TB_Remark.Text
            dt.Rows(0)("Founder") = TB_Founder.Tag
            dt.Rows(0)("Found_Date") = DP_Found_Date.Value
            dt.Rows(0)("UPD_USER") = PClass.PClass.User_ID
            dt.Rows(0)("UPD_DATE") = Today


            dt.Rows(0)("Client_ID") = Val(CB_Client.IDValue)
            dt.Rows(0)("BZ_ID") = Val(CB_BZ.IDValue)

        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("DPGY_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("DPGY_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("DPGY_Remark"), "")
            TB_DPGY_FS.Text = IsNull(dt.Rows(0)("DPGY_FS"), "")
            CB_DPGY_YS.Text = IsNull(dt.Rows(0)("DPGY_YS"), "")
            TB_DPGY_JS.Text = IsNull(dt.Rows(0)("DPGY_JS"), "")

            TB_DPGY_WD.Text = IsNull(dt.Rows(0)("DPGY_WD"), "")
            TB_DPGY_SCW.Text = IsNull(dt.Rows(0)("DPGY_SCW"), "")
            TB_DPGY_XCW.Text = IsNull(dt.Rows(0)("DPGY_XCW"), "")

            CB_DPGY_Color.Text = IsNull(dt.Rows(0)("DPGY_Color"), "")
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


            CB_Client.IDValue = IsNull(dt.Rows(0)("Client_id"), "0")
            CB_Client.Text = CB_Client.GetByTextBoxTag()

            CB_BZ.SearchID = IsNull(dt.Rows(0)("Client_id"), 0)
            CB_BZ.SearchType = cSearchType.ENum_SearchType.Client

            CB_BZ.IDValue = IsNull(dt.Rows(0)("BZ_Id"), "0")
            CB_BZ.Text = CB_BZ.GetByTextBoxTag()


            CB_BZ.Enabled = True
        Else
            TB_ID.Text = Me.DPGY_Id
            TB_Name.Text = ""
            TB_UPD_USER.Text = ""
            TB_Founder.Tag = PClass.PClass.User_ID
            TB_Founder.Text = PClass.PClass.User_Name
        End If

    End Sub



#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存工艺[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.DPGY_Add(GetForm())
        Else
            R = Dao.DPGY_Save(GetForm())
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
            ShowErrMsg("工艺编号不能为空")
            TB_ID.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("工艺名称不能为空")
            TB_Name.Focus()
            Return False
        End If

        Me.Refresh()
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
        Dim msg As MsgReturn = Dao.DPGY_Del(DPGY_Id)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub





#End Region










    Private Sub CB_Client_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel
        If CB_BZ.SearchID <> ID Then
            CB_BZ.Text = ""
            CB_BZ.SetSearchEmpty()
        End If
        CB_BZ.Enabled = True
        CB_BZ.SearchID = ID
        CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
    End Sub
End Class


Partial Class Dao
    Public Const DPGY_Bill_NAME As String = "定胚工艺"

#Region "工艺"
    Public Const SQL_DPGY_NameCheckDuplicate = "select count(*) from " & OptionClass.Table_DPGY & " where DPGY_No=@DPGY_No and id<>@id"


    Public Const SQL_DPGY_Get As String = "select *,(Select BZ_Name from T10002_BZ BZ where BZ.ID=BZ_ID) BZ_Name,(Select Client_Name from T10110_Client Client where Client.ID=Client_ID) Client_Name from " & OptionClass.Table_DPGY & " P "

    Public Const SQL_DPGY_GetByID As String = "select top 1 * from " & OptionClass.Table_DPGY & " where ID=@ID"
    Public Const SQL_DPGY_GetListByID As String = "select * from " & OptionClass.Table_DPGYList & " where ID=@ID"
    Public Const SQL_DPGY_GetByNo As String = "select * from " & OptionClass.Table_DPGY & " where DPGY_No=@DPGY_No"

    Public Const SQL_DPGY_GetByID_ExceptImage As String = "select ID,DPGY_No,DPGY_Name,DPGY_Remark,Founder,Found_Date,Upd_User,Upd_Date,DPGY_Color,DPGY_Feel from " & OptionClass.Table_DPGY & " where ID=@ID"

    Public Const SQL_DPGY_DelByid As String = "Delete from  " & OptionClass.Table_DPGY & " where ID=@ID "

    Public Const SQL_DPGY_OrderBy As String = " order by  DPGY_No "

    '  Public Const SQL_DPGY_GeList_ByIDWithName = "select P.*,WL_Name,WL_No,WL_Spec from " & OptionClass.Table_DPGYList & "  P left join T10036_WL W on P.WL_ID=W.ID where  P.ID=@ID "


    Public Const SQL_DPGY_InsertNewID = "if exists (select * from " & OptionClass.Table_DPGY & " where DPGY_No= @DPGY_No)" & vbCrLf & _
                                            "select -1" & vbCrLf & _
                                            "else" & vbCrLf & _
                                            "begin" & vbCrLf & _
                                            "insert into " & OptionClass.Table_DPGY & "(DPGY_No)Values(@DPGY_No)" & vbCrLf & _
                                            "select @@IDENTITY" & vbCrLf & _
                                            "end"
#End Region

    ''' <summary>
    ''' 获取所有工艺信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DPGY_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_DPGY_Get)
    End Function

    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DPGY_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "工艺编号"
        fo.DB_Field = "DPGY_No"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "工艺名称"
        fo.DB_Field = "DPGY_Name"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "颜色"
        fo.DB_Field = "DPGY_Color"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "风速"
        fo.DB_Field = "DPGY_FS"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "机速"
        fo.DB_Field = "DPGY_JS"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "温度"
        fo.DB_Field = "DPGY_WD"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "上超位"
        fo.DB_Field = "DPGY_SCW"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "下超位"
        fo.DB_Field = "DPGY_XCW"
        foList.Add(fo)


        fo = New FindOption
        fo.Field = "压缩"
        fo.DB_Field = "DPGY_YS"



        foList.Add(fo)
        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取工艺信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DPGY_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_DPGY_Get)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_DPGY_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取工艺信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DPGY_GetById(ByVal sId As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_DPGY_GetByID, "@Id", sId)
    End Function


    ''' <summary>
    ''' 增加一个工艺
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DPGY_Add(ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim _No As String = dtTable.Rows(0)("DPGY_No")
        Dim IsInsert As Boolean = False
        Dim ID As Integer = 0
        Try
            Dim newIdMsg As MsgReturn = SqlStrToOneStr(SQL_DPGY_InsertNewID, "@DPGY_No", _No)
            If newIdMsg.IsOk Then
                If Val(newIdMsg.Msg) = -1 Then
                    R.IsOk = False
                    R.Msg = DPGY_Bill_NAME & "编号[" & dtTable.Rows(0)("DPGY_No") & "]已经存在!"
                    Return R
                Else
                    ID = Val(newIdMsg.Msg)
                    dtTable.Rows(0)("ID") = ID
   
                End If
            End If
            paraMap.Add("ID", ID)
            sqlMap.Add("Table", SQL_DPGY_GetByID)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))
                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & DPGY_Bill_NAME & "[" & dtTable.Rows(0)("DPGY_Name") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & DPGY_Bill_NAME & "[" & dtTable.Rows(0)("DPGY_Name") & "]已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & DPGY_Bill_NAME & "[" & dtTable.Rows(0)("DPGY_Name") & "]添加错误!"
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
    Public Shared Function DPGY_Save(ByVal dtTable As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim ID As Integer = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ID)
        Try
            sqlMap.Add("Table", SQL_DPGY_GetByID)


            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                DvUpdateToDt(dtTable, msg.DtList("Table"), New List(Of String))

                '  Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & PuchaseId & "'," & BillType.Purchase & ")"
                DtToUpDate(msg)
                R.Msg = "" & DPGY_Bill_NAME & "[" & dtTable.Rows(0)("DPGY_Name") & "]修改成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & DPGY_Bill_NAME & "[" & dtTable.Rows(0)("DPGY_Name") & "]不存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & DPGY_Bill_NAME & "[" & dtTable.Rows(0)("DPGY_Name") & "]修改错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 检查布类编号的是否重复
    ''' </summary>
    ''' <param name="DPGY_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DPGY_NameCheckDuplicate(ByVal DPGY_No As String, ByVal ID As Integer) As Boolean
        Dim P As New Dictionary(Of String, Object)
        P.Add("DPGY_No", DPGY_No)
        P.Add("ID", ID)
        Dim r As MsgReturn = SqlStrToOneStr(SQL_DPGY_NameCheckDuplicate, P)
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
    Public Shared Function DPGY_Del(ByVal BZId As String)
        Return RunSQL(SQL_DPGY_DelByid, "@ID", BZId)
    End Function

    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DPGY_GetNewID() As String
        Dim paraMap As New Dictionary(Of String, Object)
        paraMap.Add("@DB_Str", OptionClass.Table_DPGY)
        paraMap.Add("@Id_Str", "")
        paraMap.Add("@Field", "DPGY_No")
        paraMap.Add("@Zero", "3")
        Dim msgID As MsgReturn = SqlStrToOneStr("GetTableID_NoDate", paraMap, True)
        If msgID.IsOk Then
            Return Format(Val(msgID.Msg), "000")
        Else
            Return ""
        End If
    End Function



    'Public Shared Function DPGY_GetList_ByID(ByVal _ID As Integer) As DtReturnMsg
    '    Dim R As New DtReturnMsg
    '    Dim sql As String = SQL_DPGY_GeList_ByIDWithName
    '    Dim para As New Dictionary(Of String, Object)
    '    para.Add("@ID", _ID)
    '    R = PClass.PClass.SqlStrToDt(sql, para)
    '    Return R
    'End Function






End Class