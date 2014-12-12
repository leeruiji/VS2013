Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F10071_ReProject_Msg
    Dim dtReProject As DataTable
    Dim Dt_Bz_Link As DataTable
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
        ID = 10070
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        If Mode <> Mode_Enum.Add AndAlso Val(Bill_ID) = 0 Then
            Bill_ID = Val(Me.F_RS_ID)
        End If
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        CB_ReProject_Type.DisplayMember = "Field"
        CB_ReProject_Type.ValueMember = "DB_Field"
        CB_ReProject_Type.DataSource = Dao.ReProject_Type


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
        Dim msg As DtReturnMsg = Dao.GetReProject(Pid)
        If msg.IsOk Then
            dtReProject = msg.Dt
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
        dt = dtReProject.Clone
        If dt IsNot Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("ReProject_Name") = TB_ReProject_Name.Text
            dr("ReProject_Type") = CB_ReProject_Type.Text
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
            TB_ReProject_Name.Text = IsNull(dt.Rows(0)("ReProject_Name"), "")
            CB_ReProject_Type.Text = IsNull(dt.Rows(0)("ReProject_Type"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
        End If
    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存备注[" & TB_ReProject_Name.Text & "]?", AddressOf SaveReProject)
            Else

                ShowConfirm("是否保存备注[" & TB_ReProject_Name.Text & "] 的修改?", AddressOf SaveReProject)
            End If
        End If

    End Sub

    Protected Sub SaveReProject()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetForm()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.ReProject_Add(Dt)
        Else
            R = Dao.ReProject_Save(Dt, Pid)
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
        If TB_ReProject_Name.Text = "" Then
            Return False
        End If

        If CB_ReProject_Type.Text = "" Then
            Return False
        End If
        Return True
    End Function

    'Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
    '    ShowConfirm("是否删除客户 [" & TB_Name.Text & "]?", AddressOf DelReProjectt)
    'End Sub
    '''' <summary>
    '''' 
    '''' </summary>
    '''' <ReProjects></ReProjects>
    'Protected Sub DelReProjectt()
    '    Dim msg As MsgReturn = Dao.ReProjectt_Disable(Bill_ID)
    '    If msg.IsOk Then
    '        LastForm.ReturnId = "0"
    '        Me.Close()
    '    Else
    '        ShowErrMsg(msg.Msg)
    '    End If
    'End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

#End Region

End Class
Partial Friend Class Dao
    Public Const ReProject_DB_Name As String = "回修项目"
    Private Const SQL_GetReProject As String = " Select ID,ReProject_Name,ReProject_Type,Remark From T10025_ReProjet Where ID=@ID"



    ''' <summary>
    ''' 获取所属项目
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReProject_Type() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption

        fo = New FindOption
        fo.Field = "回修项目"
        fo.DB_Field = "ReProject_Type"
        fo.Value = "回修项目"
        fo.Field_Operator = Enum_Operator.Operator_Equal
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "漏验项目"
        fo.DB_Field = "ReProject_Type"
        fo.Value = "漏验项目"
        fo.Field_Operator = Enum_Operator.Operator_Equal
        foList.Add(fo)
        Return foList
    End Function


    ''' <summary>
    ''' 获取备注信息
    ''' </summary>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function GetReProject(ByVal ID As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetReProject, "@ID", ID)
    End Function


    ''' <summary>
    ''' 增加一个备注
    ''' </summary>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function ReProject_Add(ByVal dtTable As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BillTypeName As String = ReProject_DB_Name
        sqlMap.Add("Table", SQL_GetReProject)
        paraMap.Add("ID", 0)
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 0 Then

                    DvToDt(dtTable, H.DtList("Table"), New List(Of String), True)
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]添加成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]添加失败!" & H.Msg
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
    Public Shared Function ReProject_Save(ByVal dtTable As DataTable, ByVal ID As Integer) As MsgReturn
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim BillTypeName As String = ReProject_DB_Name
        sqlMap.Add("Table", SQL_GetReProject)
        paraMap.Add("ID", ID)
        Using H As New DtHelper(sqlMap, paraMap)
            If H.IsOk Then
                If H.DtList("Table").Rows.Count = 1 Then

                    DvUpdateToDt(dtTable, H.DtList("Table"), New List(Of String))
                    If H.UpdateAll(True).IsOk Then '更新多个Dt中的内容到数据库 同时运行Sql语句,使用事务处理
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]修改成功!"
                        R.IsOk = True
                    Else
                        R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]修改失败!" & H.Msg
                        R.IsOk = False
                    End If
                Else
                    R.IsOk = False
                    R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]已经存在!"
                End If
                Return R
            Else
                R.IsOk = False
                R.Msg = "" & BillTypeName & "[" & dtTable.Rows(0)("ReProject_Name") & "]修改错误!"
                DebugToLog(New Exception(R.Msg))
                Return R
            End If
        End Using
    End Function
End Class