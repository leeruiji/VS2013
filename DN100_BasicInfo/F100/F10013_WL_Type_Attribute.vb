Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F10013_WL_Type_Attribute
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <ReProjects></ReProjects>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Delete)
    End Sub
    Private Sub Form_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name & "列表"
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()

        Dim msg As DtReturnMsg = Dao.Attribute_GetAll()
        If msg.IsOk Then
            FG1.DtToFG(msg.Dt)
            FG1.SortByLastOrder()
            FG1.RowSetForce("ID", ReturnId)
        End If
    End Sub

    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub

#Region "控件事件"


    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <ReProjects></ReProjects>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim F As New F10014_WL_Type_Attribute_Msg(0)
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <ReProjects></ReProjects>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        ModifyReProject()
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <ReProjects></ReProjects>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If Me.IsSel Then
            ReturnReProject()
        Else
            ModifyReProject()
        End If
    End Sub

    Protected Sub ReturnReProject()
        Me.LastForm.ReturnId = FG1.SelectItem("ID")
        Me.LastForm.ReturnObj = FG1.SelectItem
        Me.Close()
    End Sub

    Sub ModifyReProject()
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的物料属性")
            Exit Sub
        End If
        Dim F As New F10014_WL_Type_Attribute_Msg(FG1.SelectItem("ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Delete.Click
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的物料属性")
            Exit Sub
        End If
        ShowConfirm("是否删除物料属性名称 [" & FG1.SelectItem("Attribute_Name") & "]?", AddressOf DelAttribute)
    End Sub


    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <ReProjects></ReProjects>
    Protected Sub DelAttribute()
        Dim msg As MsgReturn = Dao.Attribute_Delete(FG1.SelectItem("ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg("物料属性名称[" & FG1.SelectItem("Attribute_Name") & "]删除错误！")
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me_Refresh()
    End Sub

End Class


Partial Friend Class Dao

#Region "SQL"

    Private Const SQL_GetAll_Attribute As String = "select * from T10013_WL_Type_Attribute order by ID "
    Private Const SQL_Attribute_Delete As String = "DELETE FROM T10013_WL_Type_Attribute where ID=@ID "

#End Region

    ''' <summary>
    ''' 获取所有信息
    ''' </summary>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function Attribute_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetAll_Attribute)
    End Function


    ''' <summary>
    ''' 删除
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <ReProjects></ReProjects>
    Public Shared Function Attribute_Delete(ByVal Id As Integer) As MsgReturn
        Return RunSQL(SQL_Attribute_Delete, "@ID", Id)
    End Function

End Class

