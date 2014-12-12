Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F40160_KCmodify_Msg

    Dim DtoldStore As DataTable
    Dim DtNewStore As DataTable

    'Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
    '    If keyData = Keys.Enter Then
    '        keyData = Keys.Tab
    '    End If
    '    Return MyBase.ProcessDialogKey(keyData)
    'End Function






    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal jID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        'Bill_ID = jID
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 40160
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        'If Mode <> Mode_Enum.Add AndAlso Val(Bill_ID) = 0 Then
        '    Bill_ID = Val(Me.F_RS_ID)
        'End If
        'FormCheckRight()
        'Ch_Name = GetBillTypeName(ID)
        ''Dao.Balance_DB_NAME = Ch_Name
        'Me.Title = Ch_Name
        'Me_Refresh()
        'If Mode = Mode_Enum.Add Then
        '    Cmd_Del.Visible = False
        '    If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
        '    '   TB_ID.Text = Dao.Supplier_GetNewID()
        '    Bill_ID = 0
        '    'TB_Founder.Text = PClass.PClass.User_Name
        '    'TB_Founder.Tag = PClass.PClass.User_ID
        'End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.KC_GetById(TB_GH.Text)
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
        End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim RS As DtReturnMsg = Dao.KC_GetCPList(TB_GH.Text)

        DtoldStore = RS.Dt
        If Not DtNewStore Is Nothing Then
            DtNewStore.Clear()
        End If
        DtNewStore = DtoldStore.Clone
        Dim dr As DataRow
        For i As Integer = 1 To FG1.Rows.Count - 1
            dr = DtNewStore.NewRow()
            dr("ID") = TB_GH.Text
            dr("StoreNo") = FG1.Item(i, "StoreNo")
            dr("Qty") = FG1.Item(i, "Qty")
            'dr("BZType") = FG1.Item(i, "BZType")
            DtNewStore.Rows.Add(dr)
        Next

        Return DtNewStore
    End Function

    '''' <summary>
    '''' 设置表单内容
    '''' </summary>
    '''' <remarks></remarks>
    'Protected Sub SetForm(ByVal dt As DataTable)
    '    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
    '        TB_GH.Text = IsNull(dt.Rows(0)("Supplier_No"), "")
    '        TB_Name.Text = IsNull(dt.Rows(0)("Supplier_Name"), "")

    '        TB_Area.Text = IsNull(dt.Rows(0)("Supplier_Area_Name"), "")
    '        TB_FullName.Text = IsNull(dt.Rows(0)("Supplier_FullName"), "")

    '        TB_Bank.Text = IsNull(dt.Rows(0)("Supplier_Bank"), "")
    '        TB_BankAccount.Text = IsNull(dt.Rows(0)("Supplier_Account"), "")

    '        TB_Contact.Text = IsNull(dt.Rows(0)("Supplier_Contact"), "")
    '        TB_Mobile.Text = IsNull(dt.Rows(0)("Supplier_Mobile"), "")

    '        TB_Tel1.Text = IsNull(dt.Rows(0)("Supplier_Tel1"), "")
    '        TB_Tel2.Text = IsNull(dt.Rows(0)("Supplier_Tel2"), "")

    '        TB_Fax.Text = IsNull(dt.Rows(0)("Supplier_Fax"), "")
    '        TB_WebSite.Text = IsNull(dt.Rows(0)("Supplier_WebSite"), "")

    '        TB_Email.Text = IsNull(dt.Rows(0)("Supplier_EMail"), "")
    '        TB_Address.Text = IsNull(dt.Rows(0)("Supplier_Addr"), "")

    '        TB_Remark.Text = IsNull(dt.Rows(0)("Supplier_Remark"), "")


    '        TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
    '        TB_Founder.Text = BaseClass.ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))
    '        If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
    '            DP_Found_Date.Text = dt.Rows(0)("Found_Date")
    '        End If
    '        DP_Found_Date.Text = IsNull(dt.Rows(0)("Found_Date"), "")

    '        TB_UPD_USER.Text = BaseClass.ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
    '        TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
    '        If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
    '            DP_UPD_DATE.Text = dt.Rows(0)("UPD_DATE")
    '        End If
    '    End If
    'End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存单号 [" & TB_GH.Text & "] 的修改?", AddressOf Save_KC)
    End Sub

    Protected Sub Save_KC()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        Dim RS As DtReturnMsg = Dao.KC_GetById(TB_GH.Text)
        DtoldStore = RS.Dt
        R = Dao.KC_Save(Dt, TB_GH.Text, DtoldStore)
        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            LastForm.ReturnObj = Dt
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_GH.Text = "" Then
            ShowErrMsg("单号不能为空")
            Return False
        End If

        'If TB_Name.Text = "" Then
        '    ShowErrMsg("供应商名称不能为空")
        '    Return False
        'End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除单号 [" & TB_GH.Text & "]?", AddressOf Del_KC)
    End Sub

    Protected Sub Del_KC()
        Dim Dt As DataTable = GetForm()
        Dim msg As MsgReturn = Dao.Del_KC_GetById(TB_GH.Text, FG1.Item(FG1.RowSel, "StoreNo"), FG1.SelectItem)
        If msg.IsOk Then
            ShowOk("删除成功！")
            Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        FG1.AddRow()
    End Sub

    Private Sub Cmd_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Search.Click
        Dim msg As DtReturnMsg = Dao.KC_GetById(TB_GH.Text)
        If msg.IsOk Then
            FG1.DtToSetFG(msg.Dt)
            DtoldStore = msg.Dt
            Me.Me_Refresh()
        Else
            ShowErrMsg("找不到单号！")
        End If
    End Sub
End Class
Partial Class Dao
    Public Const KC_DB_Name As String = "单号"
    Public Const SQL_GetKC As String = "select * from T40520_PB_StoreNo  where ID=@ID"
    Public Const SQL_GetKCByid As String = "select * from T40520_PB_StoreNo  where ID=@ID"
    Public Const SQL_DelKCByid As String = "delete  from T40520_PB_StoreNo  where ID=@ID and StoreNo=@StoreNo"

    ''' <summary>
    ''' 库存信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KC_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetKCByid, "@ID", sId)
    End Function
    ''' <summary>
    ''' 删除库存信息
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Del_KC_GetById(ByVal _ID As String, ByVal _StoreNo As String, ByVal drNStore As DataRow)
        Dim sql As New StringBuilder
        'For Each drNStore As DataRow In dtTable.Rows
        sql.AppendLine("insert into T40530_KC_Log  (StoreNo,ID,Qty,BZType) values ('" & drNStore("StoreNo") & "','" & drNStore("ID") & "','" & drNStore("Qty") * -1 & "','" & drNStore("BZType") & "')  ")
        'Next
        RunSQL(sql.ToString)
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _ID)
        p.Add("StoreNo", _StoreNo)
        Return RunSQL(SQL_DelKCByid, p)
    End Function
    ''' <summary>
    '''保存
    ''' </summary>
    ''' <returns></returns>
    ''' <LCProjects></LCProjects>
    Public Shared Function KC_Save(ByVal dtTable As DataTable, ByVal _ID As String, ByVal DT As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        'Dim p As New Dictionary(Of String, Object)
        'p.Add("ID", _ID)
        Dim BillTypeName As String = KC_DB_Name
        sqlMap.Add("Table", SQL_GetKC)
        paraMap.Add("ID", _ID)
        'paraMap.Add("ID", dtTable.Rows(0)("ID"))
        'paraMap.Add("LC_Line", dtTable.Rows(0)("LC_Line"))
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count > 0 Then
                    DvUpdateToDt(dtTable, H.DtList("Table"), New List(Of String))
                    Dim sql As New StringBuilder
                    For Each drNStore As DataRow In dtTable.Rows
                        For Each drOStore As DataRow In DT.Rows
                            sql.AppendLine("insert into T40530_KC_Log  (StoreNo,ID,Qty,BZType) values ('" & drNStore("StoreNo") & "','" & drNStore("ID") & "','" & drNStore("Qty") - drOStore("Qty") & "','" & drOStore("BZType") & "')  ")
                        Next
                    Next
                    If H.UpdateAll(True, sql.ToString).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理

                        R.Msg = "" & BillTypeName & "[" & _ID & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & BillTypeName & "[" & _ID & "]修改失败!" & H.Msg
                        R.IsOk = False
                    End If
                ElseIf H.DtList("Table").Rows.Count = 0 Then
                    DvToDt(dtTable, H.DtList("Table"), New List(Of String))
                    Dim sql As New StringBuilder
                    For Each drNStore As DataRow In dtTable.Rows
                        'For Each drOStore As DataRow In DT.Rows
                        sql.AppendLine("insert into T40530_KC_Log  (StoreNo,ID,Qty,BZType) values ('" & drNStore("StoreNo") & "','" & drNStore("ID") & "','" & drNStore("Qty") & "',0)  ")
                        'Next
                    Next
                    ' RunSQL(sql.ToString)
                    If H.UpdateAll(True, sql.ToString).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理

                        R.Msg = "" & BillTypeName & "[" & _ID & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & BillTypeName & "[" & _ID & "]修改失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & BillTypeName & "[" & _ID & "]已经存在!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & BillTypeName & "[" & _ID & "]修改错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using
    End Function
    Public Shared Function KC_GetCPList(ByVal _ID As String) As DtReturnMsg
        Return SqlStrToDt("select * from T40530_KC_Log where ID=@ID", "ID", _ID)
    End Function
End Class
