Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10101_Supplier_Msg
    Dim dtSupplier As DataTable


    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            keyData = Keys.Tab
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function






    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal jID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = jID
        Me.Mode = Mode
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 10100
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        If Mode <> Mode_Enum.Add AndAlso Val(Bill_ID) = 0 Then
            Bill_ID = Val(Me.F_RS_ID)
        End If
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            TB_ID.Text = Dao.Supplier_GetNewID()
            Bill_ID = 0
            TB_Founder.Text = PClass.PClass.User_Name
            TB_Founder.Tag = PClass.PClass.User_ID
        End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Supplier_GetById(IsNothing(Bill_ID, 0))
        If msg.IsOk Then
            dtSupplier = msg.Dt
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
        dt = dtSupplier.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            If Mode <> Mode_Enum.Add Then dr("ID") = Bill_ID
            dr("Supplier_No") = TB_ID.Text
            dr("Supplier_Name") = TB_Name.Text
            dr("Supplier_Area_Name") = TB_Area.Text
            dr("Supplier_FullName") = TB_FullName.Text
            dr("Supplier_Bank") = TB_Bank.Text
            dr("Supplier_Account") = TB_BankAccount.Text
            dr("Supplier_Contact") = TB_Contact.Text
            dr("Supplier_Mobile") = TB_Mobile.Text
            dr("Supplier_Tel1") = TB_Tel1.Text
            dr("Supplier_Tel2") = TB_Tel2.Text
            dr("Supplier_Fax") = TB_Fax.Text
            dr("Supplier_WebSite") = TB_WebSite.Text
            dr("Supplier_EMail") = TB_Email.Text
            dr("Supplier_Addr") = TB_Address.Text
            dr("Supplier_Remark") = TB_Remark.Text
            dr("Founder") = TB_Founder.Tag
            dr("Found_Date") = DP_Found_Date.Value
            dr("Supplier_FindHelper") = StrGetPinYin(TB_Name.Text)
            dr("UPD_USER") = PClass.PClass.User_ID
            dr("UPD_DATE") = DP_UPD_DATE.Value
            dr("Disable") = CKB_Disable.Checked
            dt.Rows.Add(dr)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_ID.Text = IsNull(dt.Rows(0)("Supplier_No"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("Supplier_Name"), "")

            TB_Area.Text = IsNull(dt.Rows(0)("Supplier_Area_Name"), "")
            TB_FullName.Text = IsNull(dt.Rows(0)("Supplier_FullName"), "")

            TB_Bank.Text = IsNull(dt.Rows(0)("Supplier_Bank"), "")
            TB_BankAccount.Text = IsNull(dt.Rows(0)("Supplier_Account"), "")

            TB_Contact.Text = IsNull(dt.Rows(0)("Supplier_Contact"), "")
            TB_Mobile.Text = IsNull(dt.Rows(0)("Supplier_Mobile"), "")

            TB_Tel1.Text = IsNull(dt.Rows(0)("Supplier_Tel1"), "")
            TB_Tel2.Text = IsNull(dt.Rows(0)("Supplier_Tel2"), "")

            TB_Fax.Text = IsNull(dt.Rows(0)("Supplier_Fax"), "")
            TB_WebSite.Text = IsNull(dt.Rows(0)("Supplier_WebSite"), "")

            TB_Email.Text = IsNull(dt.Rows(0)("Supplier_EMail"), "")
            TB_Address.Text = IsNull(dt.Rows(0)("Supplier_Addr"), "")

            TB_Remark.Text = IsNull(dt.Rows(0)("Supplier_Remark"), "")


            TB_Founder.Tag = IsNull(dt.Rows(0)("Founder"), "")
            TB_Founder.Text = BaseClass.ComFun.User_GetNameByID(IsNull(dt.Rows(0)("Founder"), ""))
            If Not dt.Rows(0)("Found_Date") Is DBNull.Value Then
                DP_Found_Date.Text = dt.Rows(0)("Found_Date")
            End If
            DP_Found_Date.Text = IsNull(dt.Rows(0)("Found_Date"), "")

            TB_UPD_USER.Text = BaseClass.ComFun.User_GetNameByID(IsNull(dt.Rows(0)("UPD_User"), ""))
            TB_UPD_USER.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_DATE.Text = dt.Rows(0)("UPD_DATE")
            End If
            CKB_Disable.Checked = IsNull(dt.Rows(0)("Disable"), False)
        End If
    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存供应商 [" & TB_Name.Text & "] 的修改?", AddressOf SaveSupplier)
    End Sub

    Protected Sub SaveSupplier()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Supplier_Add(Dt)
        Else
            R = Dao.Supplier_Save(Dt)
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text
            LastForm.ReturnObj = Dt
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_ID.Text = "" Then
            ShowErrMsg("供应商编号不能为空")
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowErrMsg("供应商名称不能为空")
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除供应商 [" & TB_Name.Text & "]?", AddressOf DelSupplier)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelSupplier()
        Dim msg As MsgReturn = Dao.Supplier_Del(Bill_ID)
        If msg.IsOk Then
            LastForm.ReturnId = "0"
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region






#Region "双击获取新编号"

    Private Sub Label_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If Mode = Mode_Enum.Add Then
            TB_ID.Text = Dao.Supplier_GetNewID()
            TB_Name.Focus()
        End If
    End Sub

#End Region




End Class
