Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F10014_WL_Type_Attribute_Msg
    Dim dtAttribute As DataTable
    Dim Pid As Integer

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal jID As Integer)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Pid = jID
        Me.Mode = Mode
    End Sub

    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <ReProjects></ReProjects>
    Sub FormCheckRight()
        ID = 10013
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        If Mode <> Mode_Enum.Add AndAlso Val(Bill_ID) = 0 Then
            Bill_ID = Val(Me.F_RS_ID)
        End If
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)


        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"
        If Val(Bill_ID) = 0 AndAlso Val(Me.P_F_RS_ID) <> 0 Then
            Bill_ID = P_F_RS_ID
        End If
        Me_Refresh()
        If Mode = Mode_Enum.Add Then
            Cmd_Del.Visible = False
            'If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub

        End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.GetAttribute(Pid)
        If msg.IsOk Then
            dtAttribute = msg.Dt
            SetForm(msg.Dt)
        End If


    End Sub



#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <ReProjects></ReProjects>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtAttribute.Clone
        If dt IsNot Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("Attribute_Name") = TB_Attribute_Name.Text
            dr("Remark") = TB_Remark.Text
            dt.Rows.Add(dr)
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <ReProjects></ReProjects>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            TB_Attribute_Name.Text = IsNull(dt.Rows(0)("Attribute_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
        End If
    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存属性[" & TB_Attribute_Name.Text & "]?", AddressOf SaveAttribute)
            Else

                ShowConfirm("是否保存属性[" & TB_Attribute_Name.Text & "] 的修改?", AddressOf SaveAttribute)
            End If
        End If

    End Sub

    Protected Sub SaveAttribute()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.Attribute_Add(Dt)
        Else
            R = Dao.Attribute_Save(Dt, Pid)
        End If
        If R.IsOk Then
            LastForm.ReturnId = Pid
            LastForm.ReturnObj = Dt
            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_Attribute_Name.Text = "" Then
            ShowErrMsg("物料属性名称不能为空！")
            Return False
        Else
            Dim msg As DtReturnMsg = Dao.GetAttributeName(TB_Attribute_Name.Text)
            If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
                ShowErrMsg("物料属性名称不能重复！")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

#End Region

End Class
Partial Friend Class Dao
    Public Const Attribute_DB_Name As String = "物料属性名称"
    Private Const SQL_GetAttribute As String = " Select * From T10013_WL_Type_Attribute Where ID=@ID"
    Private Const SQL_GetAttribute_Name As String = " select * from T10013_WL_Type_Attribute where Attribute_Name=@Attribute_Name"

    ''' <summary>
    ''' 获取备注信息
    ''' </summary>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function GetAttribute(ByVal ID As Integer) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetAttribute, "@ID", ID)
    End Function

    ''' <summary>
    ''' 检查名称是否重复
    ''' </summary>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function GetAttributeName(ByVal Attribute_Name As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetAttribute_Name, "@Attribute_Name", Attribute_Name)
    End Function


    ''' <summary>
    ''' 增加
    ''' </summary>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function Attribute_Add(ByVal dtTable As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BillTypeName As String = Attribute_DB_Name
        sqlMap.Add("Table", SQL_GetAttribute)
        paraMap.Add("ID", 0)
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 0 Then

                    DvToDt(dtTable, H.DtList("Table"), New List(Of String), True)
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("Attribute_Name") & "]添加成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("Attribute_Name") & "]添加失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]已经存在!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]添加错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using
    End Function

    ''' <summary>
    '''修改一个备注
    ''' </summary>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function Attribute_Save(ByVal dtTable As DataTable, ByVal ID As Integer) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BillTypeName As String = Attribute_DB_Name
        sqlMap.Add("Table", SQL_GetReProject)
        paraMap.Add("ID", ID)
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 1 Then

                    DvUpdateToDt(dtTable, H.DtList("Table"), New List(Of String))
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("Attribute_Name") & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("Attribute_Name") & "]修改失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("Attribute_Name") & "]已经存在!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("Attribute_Name") & "]修改错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using
    End Function
End Class