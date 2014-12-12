Imports PClass.PClass
Imports System.Data
Imports System.Text
Public Class F15517_Real_Shift
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        '  Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub
    Private Sub F10100_At_Me_Load() Handles MyBase.Me_Load
        Dim D As Date = GetDate()
        MP_Start.Value = New Date(D.Year, 1, 1)
        MP_End.Value = New Date(D.Year, 12, 1)
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name & "列表"
        Me_Refresh()
    End Sub

    Protected Sub Me_Refresh()
        Dim msg As DtReturnMsg = Dao.Real_Shift_Get_ALL()
        If msg.IsOk Then
            NoRefresh = True
            FG1.DtToFG(msg.Dt)
            FG1.RowSetForce("Name", ReturnId)
            NoRefresh = False
            Mx_Refresh()
        End If
    End Sub

    Dim NoRefresh As Boolean = False
    Protected Sub Mx_Refresh()
        If FG1.RowSel > 0 Then
            If MP_Start.Value > MP_End.Value Then
                Dim D As Date = MP_Start.Value
                MP_Start.Value = MP_End.Value
                MP_End.Value = D
            End If


            Dim msg As DtReturnMsg = Dao.Real_Shift_Get_Month(FG1.Item(FG1.RowSel, "ID"), MP_Start.Value, MP_End.Value)
            If msg.IsOk Then
                Fg2.DtToFG(msg.Dt)

            End If
        Else
            Fg2.DtToFG(New DataTable)
        End If
    End Sub



    Sub DoRetrun()
        If ReturnId <> "" Then
            Mx_Refresh()
        End If
    End Sub
 






#Region "添加修改模板"
    ''' <summary>
    ''' 添加模板
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Mode = Mode_Enum.Add
        ShowReal_Shift()
    End Sub

    Sub ShowReal_Shift()
        If CB_Shift_Moudel.DataSource Is Nothing Then
            Dim R As DtReturnMsg = Dao.Shift_Moduel_Get_ALL
            CB_Shift_Moudel.ValueMember = "ID"
            CB_Shift_Moudel.DisplayMember = "Name"
            CB_Shift_Moudel.DataSource = R.Dt
        End If
        If Mode = Mode_Enum.Add Then
            TB_Moduel_Name.Text = ""
            TB_Remark.Text = ""
        Else
            Dim R As DtReturnMsg = Dao.Real_Shift_Get(FG1.Item(FG1.RowSel, "ID"))
            If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
                TB_Remark.Text = IsNull(R.Dt.Rows(0)("Remark"), "")
                Try
                    TB_Moduel_Name.Tag = R.Dt.Rows(0)("ID")
                    TB_Moduel_Name.Text = R.Dt.Rows(0)("Name")
                    CB_Shift_Moudel.SelectedValue = R.Dt.Rows(0)("Shift_Moudel_ID")
                Catch ex As Exception
                End Try
            Else
                ShowErrMsg("修改实际班次失败,可能你选择的班次不存在!")
                Exit Sub
            End If
        End If
        CaptureFromImageToPicture(Me, PanelAdd)
        BaseClass.ComFun.Col_Center(GroupAdd)
        PanelAdd.BringToFront()
        PanelAdd.Visible = True
        TB_Moduel_Name.Focus()
    End Sub

    Private Sub Fg2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        Cmd_ModifyMonth_Click(sender, e)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If FG1.RowSel > 0 Then
            Mode = Mode_Enum.Modify
            ShowReal_Shift()
        Else
            ShowErrMsg("请在左边列表选择一个模板!")
        End If
    End Sub

    Private Sub Cmd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_OK.Click
        If CB_Shift_Moudel.SelectedIndex < 0 Then
            ShowErrMsg("请选择一个继承班次模板?", AddressOf CB_Shift_Moudel.Focus)
            Exit Sub
        End If
        If TB_Moduel_Name.Text = "" Then
            ShowErrMsg("请输入一个班次模板名称?", AddressOf TB_Moduel_Name.Focus)
            Exit Sub
        End If
        Dim R As MsgReturn
        If Mode = Mode_Enum.Add Then
            R = Dao.Real_Shift_Add(TB_Moduel_Name.Text, TB_Remark.Text, CB_Shift_Moudel.SelectedValue)
        Else
            R = Dao.Real_Shift_Save(TB_Moduel_Name.Tag, TB_Moduel_Name.Text, TB_Remark.Text, CB_Shift_Moudel.SelectedValue)
        End If

        If R.IsOk Then
            ShowOk(R.Msg)
            ReturnId = TB_Moduel_Name.Text
            Me_Refresh()
            HideAdd()
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        HideAdd()
    End Sub
    Sub HideAdd()
        PanelAdd.Visible = False
    End Sub


    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        Cmd_Modify_Click(sender, e)
    End Sub


    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Del.Click
        'If FG1.RowSel <= 0 Then
        '    ShowErrMsg("请选择一个要修改的实际班次模板")
        '    Exit Sub
        'End If
        'ShowConfirm("是否删除实际班次模板 [" & FG1.SelectItem("Name") & "]?", AddressOf DelAt)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub DelAt()
        Dim msg As MsgReturn = Dao.Real_Shift_Del(FG1.SelectItem("ID"))
        If msg.IsOk Then
            Me_Refresh()
        Else
            ShowErrMsg(msg.Msg)
        End If
    End Sub

#End Region


#Region "控件事件"

    Private Sub MP_Start_ValueChange(ByVal Value As Date) Handles MP_Start.ValueChange
        Mx_Refresh()
    End Sub

    Private Sub MP_End_ValueChange(ByVal Value As Date) Handles MP_End.ValueChange
        Mx_Refresh()
    End Sub


    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Mx_Refresh()
    End Sub

    Private Sub FG1_RowColChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.RowColChange
        If NoRefresh = False Then Mx_Refresh()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

#End Region

#Region "排班"
    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Me_Refresh()
    End Sub
    Private Sub Cmd_AddMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AddMonth.Click
        If FG1.RowSel > 0 Then
            Dim F As New F15518_Real_Shift_Msg()
            With F
                .Mode = Mode_Enum.Add
                .P_F_RS_ID = FG1.Item(FG1.RowSel, "ID")
                .P_F_RS_ID2 = ""
            End With
            F_RS_ID = ""
            Me.ReturnId = ""
            Me.ReturnObj = Nothing
            Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
            AddHandler VF.ClosedX, AddressOf DoRetrun
            VF.Show()
        Else
            ShowErrMsg("请在左边列表选在一个实际班次模板!")
        End If


    End Sub

    Private Sub Cmd_ModifyMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ModifyMonth.Click
        If FG1.RowSel > 0 Then
            If Fg2.RowSel > 0 Then


                Dim F As New F15518_Real_Shift_Msg()
                With F
                    .Mode = Mode_Enum.Modify
                    .P_F_RS_ID = Fg2.Item(Fg2.RowSel, "ID")
                    .P_F_RS_ID2 = Format(Fg2.Item(Fg2.RowSel, "sMonth"), "yyyy-MM-dd")
                End With
                F_RS_ID = ""
                Me.ReturnId = ""
                Me.ReturnObj = Nothing
                Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
                AddHandler VF.ClosedX, AddressOf DoRetrun
                VF.Show()
            Else
                ShowErrMsg("请在右边列表选在一个月份!")
            End If
        Else
            ShowErrMsg("请在左边列表选在一个实际班次模板!")
        End If

    End Sub
#End Region










End Class

Partial Class Dao
#Region "SQL"
    Public Const SQL_Real_Shift_Get_ALL = "Select P.*,M.Name as Moudel_Name from T15517_Real_Shift P left join T15515_Shift_Moudel M On P.Shift_Moudel_id=M.id"

    Public Const SQL_Real_Shift_Get_Month = "Select * from T15518_Real_Shift_Month where ID=@ID and sMonth between @StartDate and @EndDate order by ID,sMonth"


#End Region

#Region "查询"
    Public Shared Function Real_Shift_Get_ALL() As DtReturnMsg
        Return SqlStrToDt(SQL_Real_Shift_Get_ALL)
    End Function

    Public Shared Function Real_Shift_Get(ByVal ID As Integer) As DtReturnMsg
        Return SqlStrToDt(SQL_Real_Shift_Get, "ID", ID)
    End Function

    Public Shared Function Real_ShiftGetBYName(ByVal _Name As String) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("Name", _Name)

        Dim R As DtReturnMsg = SqlStrToDt(SQL_Real_Shift_GetByName, P)
        Return R
    End Function

    ''' <summary>
    ''' 添加实际班次模板
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="Remark"></param>
    ''' <param name="Shift_Moudel_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Real_Shift_Add(ByVal Name As String, ByVal Remark As String, ByVal Shift_Moudel_ID As Integer) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        paraMap.Add("Name", Name)
        Try
            sqlMap.Add("Table", SQL_Real_Shift_GetByName)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                Dim Dr As DataRow = msg.DtList("Table").NewRow
                Dr("Name") = Name
                Dr("Remark") = Remark
                Dr("Shift_Moudel_ID") = Shift_Moudel_ID
                msg.DtList("Table").Rows.Add(Dr)
                DtToUpDate(msg)
                R.Msg = "实际班次模板[" & Name & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "实际班次模板[" & Name & "]已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "实际班次模板[" & Name & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    ''' <summary>
    ''' 修改实际班次模板
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="Remark"></param>
    ''' <param name="Shift_Moudel_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Real_Shift_Save(ByVal ID As Integer, ByVal Name As String, ByVal Remark As String, ByVal Shift_Moudel_ID As Integer) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", ID)
        Dim Rt As DtReturnMsg = Real_ShiftGetBYName(Name)
        If Rt.IsOk AndAlso Rt.Dt.Rows.Count > 0 AndAlso Rt.Dt.Rows(0)("ID") <> ID Then
            R.IsOk = False
            R.Msg = "实际班次模板[" & Name & "]已经存在!"
            Return R
        End If
        Try
            sqlMap.Add("Table", SQL_Real_Shift_Get)
            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 1 Then
                Dim Dr As DataRow = msg.DtList("Table").Rows(0)
                Dr("Name") = Name
                Dr("Remark") = Remark
                Dr("Shift_Moudel_ID") = Shift_Moudel_ID
                DtToUpDate(msg)
                R.Msg = "实际班次模板[" & Name & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "实际班次模板[" & Name & "]不已经存在!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "实际班次模板[" & Name & "]修改错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function


    Public Shared Function Real_Shift_Get_Month(ByVal ID As String, ByVal StartDate As Date, ByVal EndDate As Date) As DtReturnMsg
        Dim P As New Dictionary(Of String, Object)
        P.Add("ID", ID)
        P.Add("StartDate", StartDate)
        P.Add("EndDate", EndDate)
        Return SqlStrToDt(SQL_Real_Shift_Get_Month, P)
    End Function


#End Region

End Class


