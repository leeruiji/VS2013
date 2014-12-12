Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass

Public Class F30003_AddBZ
    Dim LId As String = ""

    Dim Dt_Bzc As DataTable
    Dim Dt_Bz_Link As DataTable
    Dim DtPF As DataTable
    Dim DtPFList As DataTable
    Dim TD As Date = GetDate()
    Dim FG_SEL As String = "FG1"

    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal goodsID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.Bill_ID = Val(goodsID)
        Me.Mode = Mode
    End Sub
    Private Sub Me_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown

    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 30000
        '   Control_CheckRight(10020, ClassMain.Modify, Cmd_Modify)
      
    End Sub




    Private Sub FormLoad() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & " - 增加布种"

        Fg1.Cols("BZ_No").Editor = CB_BZ_FG


        FormCheckRight()
        Fg1.Rows.Count = 1

        Me_Refresh()



        LId = TB_BZC_No.Text

    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.BZC_GetById(Bill_ID)
        If msg.IsOk Then
            Dt_Bzc = msg.Dt
            SetForm(msg.Dt)
        End If
   
        Dim msg1 As DtReturnMsg = Dao.BZC_Bz_Link_GetById(Bill_ID)
        If msg1.IsOk Then
            Dt_Bz_Link = msg1.Dt
            Fg1.DtToSetFG(Dt_Bz_Link)
        End If

    End Sub






#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        'Dim dt As DataTable
        'dt = Dt_Bzc.Clone
        'If Not dt Is Nothing Then
        '    dt.Clear()
        '    Dim dr As DataRow = dt.NewRow
        '    dt.Rows.Add(dr)
        '    If Mode <> Mode_Enum.Add Then dt.Rows(0)("ID") = Bzc_Id
        '    dt.Rows(0)("BZC_No") = StrConv(TB_BZC_No.Text, vbNarrow)
        '    dt.Rows(0)("BZC_Name") = TB_Name.Text
        '    dt.Rows(0)("BZC_Remark") = TB_Remark.Text
        '    dt.Rows(0)("Client_id") = Tb_Client_id.Tag
        '    dt.Rows(0)("Qian_ChuLi") = TB_Qian_ChuLi.Text
        '    dt.Rows(0)("BZ_Id") = TB_BZ_ID.Tag
        '    dt.Rows(0)("Client_Bzc") = StrConv(TB_Client_Bzc.Text, vbNarrow)
        '    dt.Rows(0)("BZC_FindHelper") = StrGetPinYin(TB_Name.Text)

        '    dt.Rows(0)("Found_Date") = Format(DP_Found_Date.Value, "yyyy-MM-dd")
        '    dt.Rows(0)("UPD_USER") = PClass.PClass.User_Id
        '    dt.Rows(0)("UPD_DATE") = Today
        '    dt.Rows(0)("RanSe") = CB_RanSe.Text

        'End If



        Dt_Bz_Link = Dt_Bz_Link.Clone
        For i As Integer = 1 To Fg1.Rows.Count - 1
            If Dt_Bz_Link.Select("BZ_Id='" & Fg1.Item(i, "BZ_Id") & "'").Length = 0 Then
                Dim Dr As DataRow = Dt_Bz_Link.NewRow
                Dr("BZC_ID") = Bill_ID
                Dr("BZ_Id") = Fg1.Item(i, "BZ_Id")
                Dr("Client_Bzc") = Fg1.Item(i, "Client_Bzc")
                If Fg1.Item(i, "PF_ID") IsNot Nothing AndAlso Val(Fg1.Item(i, "PF_ID")) <> 0 Then
                    Dr("PF_ID") = Fg1.Item(i, "PF_ID")
                End If
                Dt_Bz_Link.Rows.Add(Dr)
            End If
        Next
        Dt_Bz_Link.AcceptChanges()


        Return Dt_Bz_Link
    End Function


    Dim BZC As String
    Dim BZ_ID As Integer
    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TB_BZC_No.Text = IsNull(dt.Rows(0)("BZC_No"), "")

            TB_Name.Text = IsNull(dt.Rows(0)("BZC_Name"), "")
            TB_Remark.Text = IsNull(dt.Rows(0)("BZC_Remark"), "")
            TB_Qian_ChuLi.Text = IsNull(dt.Rows(0)("Qian_ChuLi"), "")
            CB_Client.IDValue = IsNull(dt.Rows(0)("Client_id"), 0)
            CB_Client.Text = CB_Client.GetByTextBoxTag()

            CB_Client.IDValue = IsNull(dt.Rows(0)("Client_id"), "0")
            CB_Client.Text = CB_Client.GetByTextBoxTag()

            CB_BZ_FG.SearchID = IsNull(dt.Rows(0)("Client_id"), 0)
            CB_BZ_FG.SearchType = cSearchType.ENum_SearchType.Client

            CB_BZ.SearchID = IsNull(dt.Rows(0)("Client_id"), 0)
            CB_BZ.SearchType = cSearchType.ENum_SearchType.Client

            CB_BZ.IDValue = IsNull(dt.Rows(0)("BZ_Id"), "0")
            CB_BZ.Text = CB_BZ.GetByTextBoxTag()
            TB_BZ_Name.Text = CB_BZ.NameValue


            TB_Client_Bzc.Text = IsNull(dt.Rows(0)("Client_Bzc"), "")
            BZ_ID = dt.Rows(0)("BZ_Id")
            BZC = TB_Client_Bzc.Text
            If IsNull(dt.Rows(0)("PF_Count"), 0) > 0 Then
                TB_BZC_No.ReadOnly = True
            End If



            CB_RanSe.Text = IsNull(dt.Rows(0)("RanSe"), "")
        Else
            TB_BZC_No.Text = Me.Bill_ID
            TB_Name.Text = ""

        End If
    End Sub

#End Region

#Region "工具栏,按钮"



    Private Sub Btn_AddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddRow.Click
        Fg1.AddRow()
    End Sub

    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Fg1.RemoveRow()
    End Sub



    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then ShowConfirm("是否保存颜色[" & TB_Name.Text & "] 的修改?", AddressOf Save)
    End Sub

    Protected Sub Save()
        Dim R As MsgReturn
        Dim BZC_New As String
        Dim Bz_Id_New As Integer
        If BZC <> TB_Client_Bzc.Text OrElse CB_BZ.IDValue <> BZ_ID Then
            BZC_New = TB_Client_Bzc.Text
            Bz_Id_New = CB_BZ.IDValue
        Else
            BZC_New = ""
            Bz_Id_New = 0
        End If

        GetForm()
        R = Dao.BZC_Save(Val(Bill_ID), TB_Name.Text, Dt_Bz_Link, Bz_Id_New, BZC_New)

        If R.IsOk Then
            LId = TB_BZC_No.Text
            If Fg1.Rows.Count > 1 Then
                LastForm.ReturnId = Fg1.Item(Fg1.Rows.Count - 1, "BZ_ID")
            Else
                LastForm.ReturnId = CB_BZ.IDAsInt
            End If
            Mode = Mode_Enum.Modify
            If TB_BZC_No.Text = Bill_ID.Replace("-", "") Then Bill_ID = ""
            Me.Close()
            '        ShowConfirm(R.Msg & ",是否继续编辑?", AddressOf ReFreshBzcNo, AddressOf Me.Close)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub


    Protected Function CheckForm() As Boolean
        Dim msg As String = ""


        For i As Integer = Fg1.Rows.Count - 1 To 1 Step -1
            Try
                If Fg1.Item(i, "BZ_Id") Is Nothing OrElse Fg1.Item(i, "BZ_Id").ToString = "" Then
                    Fg1.Rows.Remove(i)
                ElseIf Fg1.Item(i, "Bz_Name") Is Nothing OrElse Fg1.Item(i, "Bz_Name").ToString = "" Then
                    Fg1.Rows.Remove(i)
                End If
            Catch ex As Exception
            End Try
        Next
        Me.Refresh()
        Return True
    End Function








    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub




#End Region

#Region "FG1事件"

    Private Sub CB_BZ_FG_GetSearchEvent(ByRef Col_No As String, ByRef ID As String, ByVal Cancel As Boolean) Handles CB_BZ_FG.GetSearchEvent
        CB_BZ_FG.IDValue = Fg1.Item(Fg1.RowSel, "BZ_ID")
    End Sub

    Private Sub Fg1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.GotFocus
        FG_SEL = "FG1"
    End Sub

    Private Sub Fg1_NextCell(ByVal e As PClass.FG.NextCellEventArgs) Handles Fg1.NextCell
        Select Case e.Col
            Case "BZ_No"
                e.ToCol = Fg1.Cols("Client_Bzc").Index
            Case "Client_Bzc"
                If e.Row + 2 > Fg1.Rows.Count Then
                    Fg1.AddRow()
                End If
                e.ToRow = e.Row + 1
                e.ToCol = Fg1.Cols("BZ_No").Index
        End Select
    End Sub

    Private Sub Fg1_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Fg1.AfterEdit
        If e.Col = Fg1.Cols("BZ_No").Index Then
            If Fg1.LastKey = Keys.Enter Then
                ' Fg1.Item(e.Row, "BZ_Name") = ""
                CB_BZ_FG.Col_SelOne()
                If Fg1.Item(e.Row, "BZ_Name") = "" Then
                    ShowErrMsg("请输入一个布种编号!", AddressOf FG_BZ_No)
                End If
            Else
                '非正当离开时候清空
                If Fg1.LastText <> IsNull(Fg1.Item(e.Row, "BZ_No"), "") AndAlso IsSelect = False Then Fg1.Item(e.Row, "BZ_Name") = ""
                IsSelect = False
            End If
        Else
            If Fg1.LastKey = Keys.Enter Then Fg1.GotoNextCell()
        End If
    End Sub

    Dim IsSelect As Boolean
    Private Sub CB_BZ_FG_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ_FG.Col_Sel
        IsSelect = True
        Fg1.Item(Fg1.RowSel, "BZ_Name") = Col_Name
        Fg1.Item(Fg1.RowSel, "BZ_ID") = ID
        Fg1.GotoNextCell("BZ_No")
    End Sub
    Sub FG_BZ_No()
        Fg1.StartEditing(Fg1.RowSel, Fg1.Cols("BZ_No").Index)
    End Sub

#End Region



#Region "客户和布种"

    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel

        If CB_BZ.SearchID <> ID Then
            CB_BZ.Text = ""
            CB_BZ.SetSearchEmpty()
            TB_BZ_Name.Text = ""
        End If
        CB_BZ.Enabled = True
        CB_BZ.SearchID = ID
        CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
        CB_BZ_FG.SearchID = ID
        CB_BZ_FG.SearchType = cSearchType.ENum_SearchType.Client
    End Sub
    Private Sub CB_BZ_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ.Col_Sel
        TB_BZ_Name.Text = Col_Name
    End Sub

#End Region
End Class

Partial Class Dao

#Region "布种色号"


#Region "常量"
    Public Const SQL_BZC_Link_Bz_GetByID_Save As String = "select * from T10009_BzcLinkBz where BZC_ID=@BZC_ID"

    Public Const SQL_BZC_Link_Bz_GetByID As String = "select C.*,b.Bz_No,b.Bz_Name from T10009_BzcLinkBz C left join T10002_BZ B on b.ID=c.BZ_ID where BZC_ID=@BZC_ID  "


    Public Const SQL_BZC_GetByID As String = "select * from T10003_BZC C where ID=@BZC_ID"
#End Region

    ''' <summary>
    ''' 获取布种色号信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZC_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZC_GetByID, "@BZC_ID", sId)
    End Function

    ''' <summary>
    ''' 获取客户色号列表
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZC_Bz_Link_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_BZC_Link_Bz_GetByID, "@BZC_ID", sId)
    End Function
    ''' <summary>
    '''修改一个布种色号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BZC_Save(ByVal BZC_ID As Integer, ByVal BZC_Name As String, ByVal Dt_Bz_Link As DataTable, ByVal BZ_ID As Integer, ByVal Client_Bzc As String) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim returnMsg As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim gId As String = ""

        gId = BZC_ID

        paraMap.Add("@BZC_ID", gId)
        If BZ_ID <> 0 Then
            sqlMap.Add("Bzc", "select ID,BZ_ID,Client_Bzc from T10003_BZC where id=@BZC_ID")
        End If


        sqlMap.Add("Bz_Link", SQL_BZC_Link_Bz_GetByID_Save)
        msg = SqlStrToDt(sqlMap, paraMap)
        Try
            If msg.IsOk Then
                If BZ_ID <> 0 Then
                    msg.DtList("Bzc").Rows(0)("BZ_ID") = BZ_ID
                    msg.DtList("Bzc").Rows(0)("Client_Bzc") = Client_Bzc
                End If



                DvToDt(Dt_Bz_Link, msg.DtList("Bz_Link"), New List(Of String))
                DtToUpDate(msg)
                returnMsg.IsOk = True
                returnMsg.Msg = "布种色号[" & BZC_Name & "]修改成功!"
            Else
                returnMsg.IsOk = False
                returnMsg.Msg = "布种色号[" & BZC_Name & "]不已经存在!"
            End If
        Catch ex As Exception
            DebugToLog(ex)
            returnMsg.IsOk = False
            returnMsg.Msg = "修改布种色号分类失败!"
        End Try
        Return returnMsg
    End Function



#End Region
End Class