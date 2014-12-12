Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F40205_KUCUN_Msg

    Dim DtoldStore As DataTable
    Dim DtNewStore As DataTable
    Dim KU_ID As String
    Dim LuoseQty As Integer = 0
    Dim DTList As DataTable
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
        Control_CheckRight(ID, ClassMain.Del, Cmd_Mod)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        KU_ID = P_F_RS_ID
        LuoseQty = Val(P_F_RS_ID2)
        Fg1.Cols("ID").Editor = CB_DH
        Me_Refresh()
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
        Try

     
            Dim R As DtReturnMsg = Dao.KU_GetCPList(KU_ID.Substring(0, 11))
            If R.IsOk Then

                DTList = BaseClass.ComFun.GetNewDataTable(R.Dt, "GH='" & KU_ID & "'")
                If DTList.Rows.Count = 0 Then
                    DTList = R.Dt
                End If
                Fg1.DtToSetFG(DTList)
                For i As Integer = 1 To R.Dt.Rows.Count
                    Fg1.Item(i, "GH") = KU_ID
                Next
                Dim K As DtReturnMsg = Dao.KU_GetDH(KU_ID.Substring(0, 11))
                If K.IsOk Then
                    CB_DH.DisplayMember = "ID"
                    CB_DH.ValueMember = "ID"
                    CB_DH.DataSource = K.Dt
                End If
                Fg1.Item(Fg1.RowSel, "ID") = CB_DH.Text
            Else
                ShowErrMsg("获取配布记录失败。", True)
            End If
        Catch ex As Exception

        End Try
        'Dim msg As DtReturnMsg = Dao.BU_GetById(TB_GH.Text)
        'If msg.IsOk Then
        '    FG1.DtToFG(msg.Dt)
        'End If
    End Sub

#Region "表单信息"
    Protected Function CheckForm() As Boolean
        Dim qty As Integer
        For i As Integer = 1 To Fg1.Rows.Count - 1

            If IsNull(Fg1.Item(i, "ID"), "") = "" OrElse Val(Fg1.Item(i, "Qty")) = 0 Then
                Continue For
            End If
       
            qty = qty + Val(Fg1.Item(i, "Qty"))
         
        Next
        If qty <> LuoseQty Then
            ShowErrMsg("取消条数[" & qty & "]与落色条数[" & LuoseQty & "]不符,不能保存")
            Return False
        End If
        Return True
    End Function
 
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        'Dim RS As DtReturnMsg = Dao.KU_GetCPList(0)

        'DtoldStore = RS.Dt
        If Not DtNewStore Is Nothing Then
            DtNewStore.Clear()
        End If
        DtNewStore = DTList.Clone
        Dim dr As DataRow
        For i As Integer = 1 To Fg1.Rows.Count - 1
            dr = DtNewStore.NewRow()
            If IsNull(Fg1.Item(i, "ID"), "") = "" OrElse Val(Fg1.Item(i, "Qty")) = 0 Then
                Continue For
            End If
            dr("GH") = Fg1.Item(i, "GH")
            dr("ID") = Fg1.Item(i, "ID")
            dr("StoreNo") = Fg1.Item(i, "StoreNo")
            dr("InQty") = Fg1.Item(i, "Qty")
            'dr("BZType") = Fg1.Item(i, "BZType")
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




    Protected Sub Save_BU()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        'Dim RS As DtReturnMsg = Dao.BU_GetBy(Fg1.Item(Fg1.RowSel, "ID"))
        'DtoldStore = RS.Dt
        R = Dao.KU_Save(Dt)
        If R.IsOk Then
            ' ShowOk("取消配布成功！")
            Me.Close()
        Else
            'ShowErrMsg("取消配布失败！")
            Me.Close()
        End If
    End Sub
 



    Dim idList As List(Of String)
    'Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
    '    If Fg1.RowSel > 0 Then
    '        ShowConfirm("是否销数单号 [" & Fg1.Item(Fg1.RowSel, "ID") & "]?", AddressOf Save_BU)
    '    Else
    '        ShowErrMsg("您没有选择仓位!")
    '    End If

    '    'End If

    'End Sub

    'Protected Sub Del_BU()
    '    Dim Dt As DataTable = GetForm()
    '    Dim msg As MsgReturn
    '    For Each _ID As String In idList
    '        msg = Dao.Del_BU_GetById(_ID, True, Fg1.SelectItem)
    '        If msg.IsOk Then
    '            ShowOk("销数成功！")
    '            Me_Refresh()
    '        Else
    '            ShowErrMsg(msg.Msg)
    '        End If
    '    Next
    'End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Fg1.AddRow()
    End Sub

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CheckForm()
        'If CheckForm() = True Then
        '    If TB_GH.Text = "" Then
        '        Dim msg As DtReturnMsg = Dao.BU_GetByNo(TB_StoreNo.Text)
        '        If msg.IsOk Then
        '            Fg2.DtToSetFG(msg.Dt)
        '            DtoldStore = msg.Dt
        '            Me.Me_Refresh()
        '        Else
        '            ShowErrMsg("找不到仓位！")
        '        End If
        '    Else
        '        Dim msg As DtReturnMsg = Dao.BU_GetById(TB_GH.Text, TB_StoreNo.Text)
        '        If msg.IsOk Then
        '            Fg2.DtToSetFG(msg.Dt)
        '            DtoldStore = msg.Dt
        '            Me.Me_Refresh()
        '        Else
        '            ShowErrMsg("找不到仓位！")
        '        End If
        '    End If
        'End If

    End Sub

    'Private Sub Fg2_SelectRowChange(ByVal Row As System.Int32) Handles Fg1.SelectRowChange
    '    Dim msg As DtReturnMsg = Dao.BU_GetByFG(Fg1.Item(Fg1.RowSel, "ID"))
    '    If msg.IsOk Then
    '        Fg1.DtToSetFG(msg.Dt)
    '    End If
    'End Sub

    Dim selMap As New Dictionary(Of String, String)
    Private Sub FG1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Fg1.Item(Fg1.RowSel, "StoreNo") <> "" Then
            Dim sql As String = ""
            If Fg1.Item(Fg1.RowSel, "IsChecked") Then
                sql = "update T40101_PBRK_List set GH='GY110110110',State=1,CK_Date='" & Today & "'  where Line='" & Fg1.Item(Fg1.RowSel, "Line") & "' "
                selMap.Add(Fg1.Item(Fg1.RowSel, "Line"), sql)
            Else
                selMap.Remove(Fg1.Item(Fg1.RowSel, "Line"))
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Cmd_Mod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Mod.Click
        Fg1.FinishEditing()
        If CheckForm() Then
            ShowInput("请填写取消原因", AddressOf Reason)
        End If

    End Sub
    Sub Reason(ByVal reason As String)
        If reason Is Nothing Then

        Else
            Dim Dt As DataTable = GetForm()
            Dim F As New F40201_SCPB_Msg("")
            With F
                .Mode = Mode_Enum.Add
                .P_F_RS_ID = reason
                .P_F_RS_ID2 = Me.KU_ID
                .P_F_RS_Obj = Dt
                .ID = Me.ID
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            AddHandler VF.ClosedX, AddressOf Edit_Retrun
            VF.Show()
            'Save_BU()
        End If
        Me.Close()
    End Sub
    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            ' Me_Refresh()
        End If
    End Sub


    Private Sub Cmd_Add_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Fg1.AddRow()
        Fg1.Item(Fg1.RowSel, "GH") = KU_ID
    End Sub

    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub
End Class
Partial Class Dao
    Public Const KU_DB_Name As String = "单号"
    Public Const SQL_GetKU As String = "select * from T40520_PB_StoreNo  where ID=@ID"
    Public Const SQL_GetKUByid As String = "select * from T40520_PB_StoreNo  where StoreNo=@StoreNo"
    Public Const SQL_GetKUByNo As String = "select * from T40520_PB_StoreNo  where ID=@ID and StoreNo=@StoreNo"
    Public Const SQL_GetKUByFG As String = "select P.Line,P.CK_Date,P.GH,P.ID ,P.ZL ,BZ.BZ_Name ,BZ.BZ_No ,S.StoreNo  from T40101_PBRK_List P left join T40100_PBRK_Table T ON T.ID =P.ID LEFT JOIN T10002_BZ BZ ON BZ.ID =T.BZ_ID LEFT JOIN T40520_PB_StoreNo S ON S.ID =P.GH  WHERE  S.ID=@ID"

    Public Const SQL_DelKUByid As String = "delete  from T40520_PB_StoreNo  where ID=@ID and StoreNo=@StoreNo"

    ''' <summary>
    ''' FG1
    ''' </summary>
    ''' <param name="_Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KU_GetByFG(ByVal _Id As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetKUByFG, "@ID", _Id)
    End Function
    ''' <summary>
    ''' 库存信息
    ''' </summary>
    ''' <param name="_Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KU_GetById(ByVal _Id As String, ByVal _StoreNo As String) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _Id)
        p.Add("StoreNo", _StoreNo)
        Return PClass.PClass.SqlStrToDt(SQL_GetKUByNo, p)
    End Function

    ''' <summary>
    ''' 库存信息2
    ''' </summary>
    ''' <param name="_StoreNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KU_GetByNo(ByVal _StoreNo As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetKUByid, "@StoreNo", _StoreNo)
    End Function
    ''' <summary>
    ''' 库存信息3
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KU_GetBy(ByVal _ID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetKU, "@ID", _ID)
    End Function

    ''' <summary>
    ''' 删除库存信息
    ''' </summary>
    ''' <param name="_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Del_KU_GetById(ByVal _ID As String, ByVal IsChecked As Boolean, ByVal drNStore As DataRow)

        Dim p As New Dictionary(Of String, Object)
        p.Add("ID", _ID)
        p.Add("IsChecked", IsChecked)
        p.Add("StoreNo", drNStore("StoreNo"))
        'Dim sql As New StringBuilder
        ''For Each drNStore As DataRow In dtTable.Rows
        'sql.AppendLine("insert into T40530_KC_Log  (StoreNo,ID,Qty,BZType) values ('" & drNStore("StoreNo") & "','" & drNStore("ID") & "','" & drNStore("Qty") * -1 & "','" & drNStore("BZType") & "')  ")
        ''Next
        'RunSQL(sql.ToString)
        Return RunSQL(SQL_DelKUByid, p, True)
    End Function
    ''' <summary>
    '''保存
    ''' </summary>
    ''' <returns></returns>
    ''' <LCProjects></LCProjects>
    Public Shared Function KU_Save(ByVal dtTable As DataTable) As MsgReturn

        Dim TmSQL As New System.Text.StringBuilder("")
        TmSQL.AppendLine("")

        For Each drStore As DataRow In dtTable.Rows
            TmSQL.AppendLine("insert into T40520_PB_StoreNo  (StoreNo,ID,Qty,BZType) values ('" & drStore("StoreNo") & "','" & drStore("ID") & "','" & drStore("InQty") & "',0) ")
            TmSQL.AppendLine("insert into T40521_PB_Detail  (StoreNo,ID,GH,InQty,BillType,BillName) values ('" & drStore("StoreNo") & "','" & drStore("ID") & "','" & drStore("GH") & "','" & drStore("InQty") & "','" & "40200" & "','" & "取消配布" & "') ")

        Next
        Return RunSQL(TmSQL.ToString)
    End Function
    Public Shared Function KU_GetCPList(ByVal _GH As String) As DtReturnMsg
        Return SqlStrToDt("select * from T40521_PB_Detail where GH like @GH +'%' and billType =40200 and inQty<0", "GH", _GH)
    End Function
    Public Shared Function KU_GetDH(ByVal _GH As String) As DtReturnMsg
        Return SqlStrToDt("select ID from T40521_PB_Detail where GH =@GH", "GH", _GH)
    End Function
End Class
