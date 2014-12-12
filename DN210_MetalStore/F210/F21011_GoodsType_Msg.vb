Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F21011_GoodsType_Msg
    Dim goodsTypeId As String = ""
    Dim dtGoodType As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal pTypeId As String, ByVal pName As String, ByVal gTypeId As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        goodsTypeId = gTypeId
        TB_Parent.Text = pName
        TB_Parent.Tag = pTypeId
        Me.Mode = Mode

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 21000
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub T10002_GoodsType_Msg_Load() Handles Me.Me_Load
        FormCheckRight()

        Me_Refresh()

        If Mode = Mode_Enum.Add Then
            If CheckRight(Val(P_F_RS_ID), ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
            TB_ID.Text = Dao.GoodsType_GetNewID(TB_Parent.Tag)
            '  TB_UPD_User.Text = PClass.PClass.User_Display
            '  TB_UPD_User.Tag = PClass.PClass.User_Id
        End If

    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.GoodsType_GetById(goodsTypeId)
        If msg.IsOk Then
            dtGoodType = msg.Dt
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
        dt = dtGoodType.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("GoodsType_ID") = TB_ID.Text
            dr("GoodsType_Name") = TB_Name.Text
            dr("GoodsType_StartNo") = TB_StartNum.Text
            dr("GoodsType_Remark") = TB_Remark.Text
            dr("UPD_User") = PClass.PClass.User_Id
            dr("UPD_Date") = Today

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
            TB_ID.Text = IsNull(dt.Rows(0)("GoodsType_ID"), "")
            TB_ID.Tag = IsNull(dt.Rows(0)("GoodsType_ID"), "")
            TB_Name.Text = IsNull(dt.Rows(0)("GoodsType_Name"), "")
            TB_StartNum.Text = IsNull(dt.Rows(0)("GoodsType_StartNo"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("GoodsType_Remark"), "")

            TB_UPD_User.Tag = IsNull(dt.Rows(0)("UPD_User"), "")
            TB_UPD_User.Text = UserIDtoDisplayName(IsNull(dt.Rows(0)("UPD_User"), ""))
            If Not dt.Rows(0)("UPD_DATE") Is DBNull.Value Then
                DP_UPD_User.Value = dt.Rows(0)("UPD_DATE")
            End If

        End If

    End Sub

#End Region


#Region "工具栏按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then
            If TB_ID.Text <> TB_ID.Tag Then
                ShowConfirm("分类编号已经被改变,分类编号的改变将会同步改变物料的分类编号,继续保存?", AddressOf Save)
            Else
                ShowConfirm("是否保存商品分类 [" & TB_Name.Text & "] 的修改?", AddressOf Save)
            End If

        End If

    End Sub

    Protected Sub Save()
        If Me.Mode = Mode_Enum.Add Then
            Dao.GoodsType_Add(GetForm())
        Else
            Dao.GoodsType_Save(TB_ID.Tag, GetForm())

        End If
        Me.Close()
    End Sub
    Protected Function CheckForm() As Boolean
        If TB_Parent.Text = "" Then
            ShowErrMsg("上一层分类不能为空")
            TB_Parent.Focus()
            Return False
        End If

        If TB_ID.Text = "" Then
            ShowErrMsg("分类编号不能为空")
            TB_ID.Focus()
            Return False
        End If

        If TB_Name.Text = "" Then
            ShowErrMsg("分类名称不能为空")
            TB_Name.Focus()
            Return False
        End If
        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        ShowConfirm("是否删除 [" & TB_Name.Text & "]?", AddressOf DelGoodsType)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelGoodsType()
        Dim msg As MsgReturn = Dao.GoodsType_Del(TB_ID.Text)
        If msg.IsOk Then
            Me.Close()
        Else
            ShowErrMsg(msg.Msg)

        End If

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub


    Private Sub Btn_ChoseParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ChoseParent.Click
        Dim F As New F21010_GoodsType_Sel
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        If Me.TB_ID.Text.Length >= 5 Then


            F.GoodsTypeTree1.SetRootID(Me.TB_ID.Text.Substring(0, 5))
        End If
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetParent
        VF.Show()
    End Sub


    Protected Sub SetParent()
        If Not ReturnId = "" OrElse Not ReturnObj Is Nothing Then
            Me.TB_Parent.Text = Me.ReturnObj
            Me.TB_Parent.Tag = Me.ReturnId
            TB_ID.Tag = TB_ID.Text
            TB_ID.Text = Dao.GoodsType_GetNewID(TB_Parent.Tag)

        End If
    End Sub

#End Region



End Class

Partial Class Dao
#Region "商品分类"



    '===================商品分类==============
    Public Const SQL_GoodsType_GetAll As String = "select * from T21000_GoodsType order by GoodsType_ID"

    'Public Const SQL_GoodsType_GetChildrenBYParentID As String = "select * from T21000_GoodsType order by GoodsType_ID"


    Public Const SQL_GoodsType_GetByID As String = "select * from T21000_GoodsType where GoodsType_ID=@GoodsType_ID"

    Public Const SQL_GoodsType_Del As String = "Delete from T21000_GoodsType where GoodsType_ID=@GoodsType_ID"


    Public Const SQL_GoodsType_CheckDel = "SELECT(SELECT Count(*)" & vbCrLf & _
                                    "FROM T21000_GoodsType" & vbCrLf & _
                                    "WHERE (GoodsType_ID LIKE @GoodsType_ID + '%' and GoodsType_ID<>@GoodsType_ID))" & vbCrLf & _
                                    "+(select Count(*) from T21001_Metal where WL_Type_ID=@GoodsType_ID)"
#End Region

#Region "分类"
    ''' <summary>
    ''' 获取所有分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GoodsType_GetChildrenByParentID(ByVal parentID As String) As DtReturnMsg
        If Not parentID Is Nothing OrElse Not parentID = "" Then
            Dim sql As String = "select * from T21000_GoodsType where GoodsType_ID like '" & parentID & "%'  order by GoodsType_ID"
            Return PClass.PClass.SqlStrToDt(sql)
        Else
            Return New DtReturnMsg
        End If

    End Function

    ''' <summary>
    ''' 获取所有分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GoodsType_GetAll() As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GoodsType_GetAll)
    End Function

    ''' <summary>
    ''' 获取分类信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GoodsType_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GoodsType_GetByID, "@GoodsType_ID", sId)
    End Function
    ''' <summary>
    ''' 定父节点下增加一个分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GoodsType_Add(ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim sql As String
        Dim returnMsg As New MsgReturn

        sql = SQL_GoodsType_GetByID
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "新增分类失败!"
            Return returnMsg

        End If
        gId = dt.Rows(0)("GoodsType_ID")
        Try
            Dim msg As DtReturnMsg = SqlStrToDt(sql, Cnn, Da, "@GoodsType_ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 0 Then

                DvToDt(dt, msg.Dt, New List(Of String), True)
                DtToUpDate(msg.Dt, Cnn, Da)
                returnMsg.IsOk = True
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "]新增成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "]已存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "新增分类失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function



    ''' <summary>
    '''修改一个分类
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GoodsType_Save(ByVal oGid As String, ByVal dt As DataTable) As MsgReturn
        Dim Cnn As New SqlClient.SqlConnection
        Dim Da As New SqlClient.SqlDataAdapter
        Dim gId As String = ""
        Dim sql As String
        Dim newID As String = ""
        Dim returnMsg As New MsgReturn

        sql = SQL_GoodsType_GetByID
        If dt.Rows.Count <> 1 Then
            returnMsg.IsOk = False
            returnMsg.Msg = "修改分类失败!"
            Return returnMsg

        End If
        gId = oGid '
        newID = dt.Rows(0)("GoodsType_ID")
        Try
            '  Dim dth As New DtHelper

            Dim msg As DtReturnMsg = SqlStrToDt(sql, Cnn, Da, "@GoodsType_ID", gId)
            If msg.IsOk AndAlso msg.Dt.Rows.Count = 1 Then
                DvToDt(dt, msg.Dt, New List(Of String))
                If gId <> newID Then
                    sql = "update T21000_GoodsType set GoodsType_ID =replace( GoodsType_ID,'" & oGid & "','" & newID & "') where GoodsType_ID like '" & oGid & "%' " & _
                          "update T21001_Metal set WL_Type_ID= replace( WL_Type_ID,'" & oGid & "','" & newID & "') where WL_Type_ID like '" & oGid & "%' "
                    DtToUpDate(msg.Dt, Cnn, Da, sql)
                Else
                    DtToUpDate(msg.Dt, Cnn, Da)
                End If

                returnMsg.IsOk = True
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "保存成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "分类[" & dt.Rows(0)("GoodsType_Name") & "不存在!"
            End If


        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改分类失败!"
        Finally
            Da.Dispose()
            Cnn.Dispose()
        End Try
        Return returnMsg
    End Function

    ''' <summary>
    ''' 删除一个分类
    ''' </summary>
    ''' <param name="GoodsType_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GoodsType_Del(ByVal GoodsType_ID As String) As MsgReturn
        If Val(SqlStrToOneStr(SQL_GoodsType_CheckDel, "GoodsType_ID", GoodsType_ID).Msg) > 0 Then
            Dim R As New MsgReturn
            R.IsOk = False
            R.Msg = "分类删除失败,分类下还有子分类或物料"
            Return R
        End If
        Return RunSQL(SQL_GoodsType_Del, "@GoodsType_ID", GoodsType_ID)
    End Function
    ''' <summary>
    ''' 生成新的分类ID 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GoodsType_GetNewID(ByVal parentId As String) As String
        Try
            Dim sql As String
            Dim msg As New MsgReturn
            If parentId.Length >= 5 Then
                sql = "select top 1 GoodsType_ID  from T21000_GoodsType where GoodsType_ID like '" & parentId & "%'  and len(GoodsType_ID)>" & parentId.Length & " order by len(GoodsType_ID) asc,GoodsType_ID desc"
            Else
                parentId = "GT"
                sql = "select top 1 GoodsType_ID  from T21000_GoodsType where len( GoodsType_ID)=5  order by GoodsType_ID desc"
            End If

            msg = SqlStrToOneStr(sql)
            Dim j As Integer = 3
            If msg.IsOk Then
                Dim s As String = ""
                Dim i As Integer
                If msg.Msg.Length = parentId.Length OrElse msg.Msg.Length = 0 Then
                    i = 1
                Else
                    i = Integer.Parse(msg.Msg.Substring(msg.Msg.Length - j)) + 1
                End If
                s = Space(j).Replace(" ", 0) & i
                s = s.Substring(s.Length - j)
                Return parentId & s
            Else
                Return ""

            End If
        Catch ex As Exception
            DebugToLog(ex)
            Return ""
        End Try
    End Function

#End Region
End Class
