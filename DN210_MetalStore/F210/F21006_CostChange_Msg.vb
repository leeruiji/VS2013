Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F21006_CostChange_Msg
    Dim Dt_CostChange As DataTable
    Dim LId As String = ""
    Dim goodsId As String = ""

    Dim PID As String = ""
    Dim PID_Date As Date = #1/1/1999#

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal goodsID As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.goodsId = goodsID
        Btn_ChoseWl.Enabled = False

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
        ID = 21005
        Control_CheckRight(ID, ClassMain.Add, Cmd_Modify)

    End Sub



    Private Sub FormLoad() Handles Me.Me_Load
        If PID = "" AndAlso P_F_RS_ID <> "" Then
            PID = P_F_RS_ID
        End If
        FormCheckRight()
        If Me.Mode = Mode_Enum.Add Then
            If Me.goodsId <> "" Then
                Dim msgGoods As DtReturnMsg = Dao.MetalWL_GetByID(goodsId)
                If msgGoods.IsOk = True Then
                    Me.ReturnObj = msgGoods.Dt.Rows(0)
                    SetGoods()
                End If
            Else

            End If

            GetNewID()
        ElseIf Mode = Mode_Enum.Modify Then
            Dim msg As DtReturnMsg = Dao.CostChange_GetByID(PID)
            If msg.IsOk Then
                Setform(msg.Dt)
            End If
            Cmd_Modify.Enabled = False
            TB_ID.ReadOnly = True
            DTP_sDate.Enabled = False
            TB_Cost_New.ReadOnly = True
            TB_Remark.ReadOnly = True
            Btn_ChoseWl.Enabled = False
        End If



    End Sub





#Region "获取新单号"
    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.CostChange, PID)
    End Sub
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If TB_WL_ID.ReadOnly OrElse TB_WL_ID.Enabled = False Then
            ShowErrMsg("非新增状态不能修改单号!")
        Else
            ShowConfirm("是否获取新单号?", AddressOf ReGetNewID)
        End If
    End Sub

    Sub ReGetNewID()
        If TB_WL_ID.Text <> LId OrElse LId = "" Then
            ComFun.DelBillNewID(BillType.CostChange, PID)
            PID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> PID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.MetalCostChange, DTP_sDate.Value, PID)
                If R.IsOk Then
                    PID_Date = R.NewIdDate
                    DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                    DTP_sDate.Value = R.NewIdDate
                    PID = R.NewID
                    TB_ID.Text = PID.Replace("-", "")
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
#Region "表单信息"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub Setform(ByVal dt As DataTable)
        If dt IsNot Nothing Then
            Try
                Dim dr As DataRow = dt.Rows(0)
                TB_ID.Text = dr("ID")
                DTP_sDate.Value = dr("Audit_Date")
                TB_WL_ID.Text = dr("WL_NO")
                TB_WL_ID.Tag = dr("WL_ID")
                TB_Name.Text = dr("WL_Name")
                TB_Name.Tag = dr("WL_Type_ID")
                TB_Cost_Old.Text = IsNull(dr("Cost_Old"), 0)
                TB_Cost_New.Text = IsNull(dr("Cost_New"), 0)
                TB_Price.Text = IsNull(dr("Wl_Price"), 0)
                TB_Qty.Text = IsNull(dr("Wl_Qty"), 0)
                TB_Unit.Text = IsNull(dr("WL_Unit"), "")
                TB_Spec.Text = IsNull(dr("WL_Spec"), "")
                TB_Remark.Text = IsNull(dr("Remark"), "")
            Catch ex As Exception
                ShowErrMsg("打开成本价调整单是发生错误：" & ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetForm() As DataTable
        Dim dt As New DataTable("T")
        dt.Columns.Add("ID", GetType(String))
        dt.Columns.Add("WL_ID", GetType(String))
        dt.Columns.Add("Cost_Old", GetType(Double))
        dt.Columns.Add("Cost_New", GetType(Double))
        dt.Columns.Add("WL_Qty", GetType(Double))
        dt.Columns.Add("Audit_Date", GetType(Date))
        dt.Columns.Add("Audit_User", GetType(String))
        dt.Columns.Add("Remark", GetType(String))
        'dt.Columns.Add("WL_Qty", GetType(Double))

        Dim dr As DataRow = dt.NewRow
        dr("ID") = TB_ID.Text
        dr("WL_ID") = TB_WL_ID.Tag
        dr("WL_Qty") = TB_Qty.Text
        dr("Cost_Old") = TB_Cost_Old.Text
        dr("Cost_New") = TB_Cost_New.Text
        dr("Audit_User") = PClass.PClass.User_Name
        ' dr("Audit_Date") = DTP_sDate.Value.Date
        dr("Remark") = TB_Remark.Text
        '   dr("WL_Qty") = TB_Qty.Text
        dt.Rows.Add(dr)
        Return dt
    End Function

#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("成本价调整单审核后将不能修改，确定要调整成本价?", AddressOf Save)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Save()
        Dim dt As DataTable = GetForm()
        Dim msg As MsgReturn = Dao.CostChange_Save(dt)
        If msg.IsOk Then
            Me.LastForm.ReturnId = TB_Cost_New.Text
            Me.LastForm.ReturnMsg = TB_ID.Text
            '  ShowOk("成本价调整成功", True)

            Me.Close()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

    Protected Function CheckForm() As Boolean

        If TB_ID.Text = "" Then
            ShowErrMsg("成本价调整单单号不能为空!")
            TB_ID.Focus()
            Return False
        End If

        If TB_WL_ID.Text = "" Then
            ShowErrMsg("物料编号不能为空!")
            TB_WL_ID.Focus()
            Return False
        End If

        If Val(TB_Cost_New.Text) <= 0 OrElse Val(TB_Cost_New.Text) = Val(TB_Cost_Old.Text) Then
            ShowErrMsg("新成本价不能小于0，或空并且不能与旧成本价相同!")
            TB_WL_ID.Focus()
            Return False
        End If
        If TB_Name.Text = "" Then
            ShowErrMsg("物料名称不能为空!")
            TB_Name.Focus()
            Return False
        End If

        Return True
    End Function




    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub







#End Region
#Region "双击获取新编号"
    Private Sub Label_ID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If Mode = Mode_Enum.Add Then
            ' TB_ID.Text = WL_GetNewID(startNo)
            TB_Name.Focus()
        End If
    End Sub
#End Region


#Region "选择物料"

    ''' <summary>
    ''' 打开物料选择窗口
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_ChoseWl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseWl.Click
        Dim F As New F21002_Metal_Sel()
        If F Is Nothing Then Exit Sub



        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = TB_WL_ID.Tag
            .P_F_RS_ID4 = TB_Name.Tag
            .IsSel = True
        End With

        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoods
        VF.Show()
    End Sub

    Private Sub SetGoods()
        If Not Me.ReturnObj Is Nothing Then
            Dim dr As DataRow = ReturnObj
            TB_WL_ID.Text = dr("WL_NO")
            TB_WL_ID.Tag = dr("ID")
            TB_Name.Text = dr("WL_Name")
            TB_Name.Tag = dr("WL_Type_ID")
            TB_Cost_Old.Text = IsNull(dr("WL_Cost"), 0)
            TB_Price.Text = IsNull(dr("Wl_Price"), 0)
            TB_Qty.Text = IsNull(dr("Wl_Qty"), 0)
            TB_Unit.Text = IsNull(dr("WL_Unit"), "")
            TB_Spec.Text = IsNull(dr("WL_Spec"), "")
            TB_Cost_New.Focus()
        End If
    End Sub
#End Region



End Class


Class Dao
#Region "常量"
    Public Const BillName As String = "成本价调整单"

    ''' <summary>
    ''' 获取指定的成本调整单
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Const SQL_CostChange_GetBYID = "select * from T21005_CostChange "
    Private Const SQL_CostChange_GetBYID_WithName = "select P.*,WL_No,WL_Name,WL_Unit,WL_Spec,WL_Price,WL_Type_ID from T21005_CostChange P left join T21001_Metal W on P.WL_ID=W.ID where P.ID=@ID"
#End Region

    ''' <summary>
    '''  获取指定的成本调整单
    ''' </summary>
    ''' <param name="_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Shared Function MetalWL_GetByID(ByVal _id As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_CostChange_GetBYID, "@ID", _id)
    End Function

    Public Shared Function CostChange_GetByID(ByVal _id As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_CostChange_GetBYID_WithName, "@ID", _id)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CostChange_Save(ByVal dt As DataTable) As MsgReturn
        Dim pa As New Dictionary(Of String, Object)

        Dim dr As DataRow = dt.Rows(0)
        pa.Add("ID", dr("ID"))
        pa.Add("WL_ID", dr("WL_ID"))
        pa.Add("Cost_Old", dr("Cost_Old"))
        pa.Add("Cost_New", dr("Cost_New"))
        pa.Add("Audit_User", dr("Audit_User"))
        ' pa.Add("Audit_Date", GetDate)
        pa.Add("WL_Qty", dr("WL_Qty"))
        pa.Add("Remark", dr("Remark"))



        Dim sqlbuider As New StringBuilder
        sqlbuider.AppendLine("insert into T21005_CostChange (ID,WL_ID,Cost_Old,Cost_New,Audit_User,Audit_Date,WL_Qty,Remark) values(")
        sqlbuider.Append("@ID,@WL_ID,@Cost_Old,@Cost_New,@Audit_User,getDate(),@WL_Qty,@Remark)")




        sqlbuider.AppendLine("insert into T21003_Store_Detail (BillType,ID,BillName,sDate,Audited_Date,WL_ID,Price,Cost,Store_ID,StoreInorOut,QTY,Supplier_Id,ClientTpye) values(")
        sqlbuider.Append(10013)
        sqlbuider.Append(",@ID,'")

        sqlbuider.Append(BillName)
        sqlbuider.Append("',getDate(),getDate(),@WL_ID,@Cost_Old,@Cost_Old,-1,-1,@WL_Qty,-1,'Store')")



        sqlbuider.AppendLine("insert into T21003_Store_Detail (BillType,ID,BillName,sDate,Audited_Date,WL_ID,Price,Cost,Store_ID,StoreInorOut,QTY,Supplier_Id,ClientTpye) values(")
        sqlbuider.Append(10013)
        sqlbuider.Append(",@ID,'")

        sqlbuider.Append(BillName)
        sqlbuider.Append("',getDate(),getDate(),@WL_ID,@Cost_New,@Cost_New,-1,1,@WL_Qty,-1,'Store')")



        sqlbuider.AppendLine(" update T21001_Metal set WL_Cost= ")
        sqlbuider.Append("@Cost_New")
        sqlbuider.Append(" where ID=")
        sqlbuider.Append("@WL_ID")

        'sqlbuider.AppendLine("  insert into T10013_Operate_Log(BillID,BillType,Operate,Operate_User) values(@ID,10013,'调价',@Audit_User)")


        Try


            Return PClass.PClass.RunSQL(sqlbuider.ToString, pa)
        Catch ex As Exception
            Dim msg As New MsgReturn
            msg.IsOk = False
            msg.Msg = "成本价调整发生错误：" & ex.Message
            Return msg
        End Try
    End Function

End Class