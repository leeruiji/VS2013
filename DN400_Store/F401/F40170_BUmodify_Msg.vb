Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F40170_BUmodify_Msg

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
        'Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
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
    'Public Nohide As Boolean = False
    'Protected Sub Me_Refresh()
    '    Static T As Threading.Thread
    '    If T IsNot Nothing Then
    '        If T.IsAlive Then
    '            Try
    '                T.Abort()
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    End If
    '    T = New Threading.Thread(AddressOf GetForm)
    '    FG1.Visible = False
    '    ' T.Start(GetFindOtions)
    '    If Nohide = False Then Me.ShowLoading(MeIsLoad)
    'End Sub

    Protected Sub Me_Refresh()
        'Dim msg As DtReturnMsg = Dao.BU_GetById(TB_GH.Text)
        'If msg.IsOk Then
        '    FG1.DtToFG(msg.Dt)
        'End If
    End Sub

#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim RS As DtReturnMsg = Dao.BU_GetCPList(Fg2.Item(Fg2.RowSel, "ID"))

        DtoldStore = RS.Dt
        If Not DtNewStore Is Nothing Then
            DtNewStore.Clear()
        End If
        DtNewStore = DtoldStore.Clone
        Dim dr As DataRow
        'For i As Integer = 1 To Fg2.Rows.Count - 1
        dr = DtNewStore.NewRow()
        dr("ID") = Fg2.Item(Fg2.RowSel, "ID")
        dr("StoreNo") = Fg2.Item(Fg2.RowSel, "StoreNo")
        dr("Qty") = Fg2.Item(Fg2.RowSel, "Qty")
        'dr("BZType") = Fg2.Item(i, "BZType")
        DtNewStore.Rows.Add(dr)
        ' Next

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


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowConfirm("是否保存单号 [" & TB_GH.Text & "] 的修改?", AddressOf Save_BU)
    End Sub

    Protected Sub Save_BU()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        Dim RS As DtReturnMsg = Dao.BU_GetBy(Fg2.Item(Fg2.RowSel, "ID"))
        DtoldStore = RS.Dt
        R = Dao.BU_Save(Dt, Fg2.Item(Fg2.RowSel, "ID"), selMap)
        If R.IsOk Then
            LastForm.ReturnId = Fg2.Item(Fg2.RowSel, "ID")
            LastForm.ReturnObj = Dt
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_StoreNo.Text = "" Then
            ShowErrMsg("仓位不能为空")
            Return False
        End If
        Return True
    End Function



    Dim idList As List(Of String)
    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        If Fg2.RowSel > 0 Then
            ShowConfirm("是否销数单号 [" & Fg2.Item(Fg2.RowSel, "ID") & "]?", AddressOf Save_BU)
        Else
            ShowErrMsg("您没有选择仓位!")
        End If

        'End If

    End Sub

    Protected Sub Del_BU()
        Dim Dt As DataTable = GetForm()
        Dim msg As MsgReturn
        For Each _ID As String In idList
            msg = Dao.Del_BU_GetById(_ID, True, FG1.SelectItem)
            If msg.IsOk Then
                ShowOk("销数成功！")
                Me_Refresh()
            Else
                ShowErrMsg(msg.Msg)
            End If
        Next
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FG1.AddRow()
    End Sub

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        CheckForm()
        If CheckForm() = True Then
            If TB_GH.Text = "" Then
                Dim msg As DtReturnMsg = Dao.BU_GetByNo(TB_StoreNo.Text)
                If msg.IsOk Then
                    Fg2.DtToSetFG(msg.Dt)
                    'DtoldStore = msg.Dt
                    Me.Me_Refresh()
                Else
                    ShowErrMsg("找不到仓位！")
                End If
            Else
                Dim msg As DtReturnMsg = Dao.BU_GetById(TB_GH.Text, TB_StoreNo.Text)
                If msg.IsOk Then
                    Fg2.DtToSetFG(msg.Dt)
                    'DtoldStore = msg.Dt
                    Me.Me_Refresh()
                Else
                    ShowErrMsg("找不到仓位！")
                End If
            End If
        End If

    End Sub

    Private Sub Fg2_SelectRowChange(ByVal Row As System.Int32) Handles Fg2.SelectRowChange
        Dim msg As DtReturnMsg = Dao.BU_GetByFG(Fg2.Item(Fg2.RowSel, "ID"))
        If msg.IsOk Then
            FG1.DtToSetFG(msg.Dt)
        End If
    End Sub

    Dim selMap As New Dictionary(Of String, String)
    Private Sub FG1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.Click
        If FG1.Item(FG1.RowSel, "StoreNo") <> "" Then
            Dim sql As String = ""
            If FG1.Item(FG1.RowSel, "IsChecked") Then
                sql = "update T40101_PBRK_List set GH='GY110110110',State=1,CK_Date='" & Today & "'  where Line='" & FG1.Item(FG1.RowSel, "Line") & "' "
                selMap.Add(FG1.Item(FG1.RowSel, "Line"), sql)
            Else
                selMap.Remove(FG1.Item(FG1.RowSel, "Line"))
            End If
        Else
            Exit Sub
        End If
    End Sub
End Class
Partial Class Dao
    Public Const BU_DB_Name As String = "单号"
    Public Const SQL_GetBU As String = "select * from T40520_PB_StoreNo  where ID=@ID"
    Public Const SQL_GetBUByid As String = "select * from T40520_PB_StoreNo  where StoreNo=@StoreNo"
    Public Const SQL_GetBUByNo As String = "select * from T40520_PB_StoreNo  where ID=@ID and StoreNo=@StoreNo"
    Public Const SQL_GetBUByFG As String = "select P.Line,P.CK_Date,P.GH,P.ID ,P.ZL ,BZ.BZ_Name ,BZ.BZ_No ,S.StoreNo  from T40101_PBRK_List P left join T40100_PBRK_Table T ON T.ID =P.ID LEFT JOIN T10002_BZ BZ ON BZ.ID =T.BZ_ID LEFT JOIN T40520_PB_StoreNo S ON S.ID =P.GH  WHERE  S.ID=@ID"

    Public Const SQL_DelBUByid As String = "delete  from T40520_PB_StoreNo  where ID=@ID and StoreNo=@StoreNo"

    ''' <summary>
    ''' FG1
    ''' </summary>
    ''' <param name="_Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BU_GetByFG(ByVal _Id As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetBUByFG, "@ID", _Id)
    End Function
    ''' <summary>
    ''' 库存信息
    ''' </summary>
    ''' <param name="_Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BU_GetById(ByVal _Id As String, ByVal _StoreNo As String) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _Id)
        p.Add("StoreNo", _StoreNo)
        Return PClass.PClass.SqlStrToDt(SQL_GetBUByNo, p)
    End Function

    ''' <summary>
    ''' 库存信息2
    ''' </summary>
    ''' <param name="_StoreNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BU_GetByNo(ByVal _StoreNo As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetBUByid, "@StoreNo", _StoreNo)
    End Function
    ''' <summary>
    ''' 库存信息3
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BU_GetBy(ByVal _ID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetBU, "@ID", _ID)
    End Function

    ''' <summary>
    ''' 删除库存信息
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Del_BU_GetById(ByVal _ID As String, ByVal IsChecked As Boolean, ByVal drNStore As DataRow)

        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _ID)
        p.Add("IsChecked", IsChecked)
        p.Add("StoreNo", drNStore("StoreNo"))
        'Dim sql As New StringBuilder
        ''For Each drNStore As DataRow In dtTable.Rows
        'sql.AppendLine("insert into T40530_KC_Log  (StoreNo,ID,Qty,BZType) values ('" & drNStore("StoreNo") & "','" & drNStore("ID") & "','" & drNStore("Qty") * -1 & "','" & drNStore("BZType") & "')  ")
        ''Next
        'RunSQL(sql.ToString)
        Return RunSQL(SQL_DelBUByid, p, True)
    End Function
    ''' <summary>
    '''保存
    ''' </summary>
    ''' <returns></returns>
    ''' <LCProjects></LCProjects>
    Public Shared Function BU_Save(ByVal dtTable As DataTable, ByVal _ID As String, ByVal selMap As Dictionary(Of String, String)) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        'Dim p As New Dictionary(Of String, Object)
        'p.Add("ID", _ID)
        Dim BillTypeName As String = BU_DB_Name
        sqlMap.Add("Table", SQL_GetBU)
        paraMap.Add("ID", _ID)
        'paraMap.Add("ID", dtTable.Rows(0)("ID"))
        'paraMap.Add("LC_Line", dtTable.Rows(0)("LC_Line"))
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count > 0 Then
                    DvUpdateToDt(dtTable, H.DtList("Table"), New List(Of String))
                    Dim sql As New StringBuilder
                    For Each key As String In selMap.Keys
                        sql.AppendLine(selMap.Item(key))
                    Next
                    If H.UpdateAll(True, sql.ToString).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理

                        R.Msg = "" & BillTypeName & "[" & _ID & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & BillTypeName & "[" & _ID & "]修改失败!" & H.Msg
                        R.IsOk = False
                    End If
                    'ElseIf H.DtList("Table").Rows.Count = 0 Then
                    '    DvToDt(dtTable, H.DtList("Table"), New List(Of String))
                    '    Dim sql As New StringBuilder
                    '    For Each drNStore As DataRow In dtTable.Rows
                    '        'For Each drOStore As DataRow In DT.Rows
                    '        sql.AppendLine("insert into T40530_KC_Log  (StoreNo,ID,Qty,BZType) values ('" & drNStore("StoreNo") & "','" & drNStore("ID") & "','" & drNStore("Qty") & "',0)  ")
                    '        'Next
                    '    Next
                    '    ' RunSQL(sql.ToString)
                    '    If H.UpdateAll(True, sql.ToString).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理

                    '        R.Msg = "" & BillTypeName & "[" & _ID & "]修改成功!"
                    '        R.IsOk = True
                    '    Else
                    '        R.Msg = "" & BillTypeName & "[" & _ID & "]修改失败!" & H.Msg
                    '        R.IsOk = False
                    '    End If
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
    Public Shared Function BU_GetCPList(ByVal _ID As String) As DtReturnMsg
        Return SqlStrToDt("select * from T40530_KC_Log where ID=@ID", "ID", _ID)
    End Function
End Class
