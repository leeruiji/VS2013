Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F40204_PBStore_Msg
    Private WithEvents R As New R40204_PBStore
    Dim isLoaded As Boolean = False
    Dim Excelout As Boolean = False
    Dim dtTable As DataTable
    Dim dtList As DataTable
    Dim LId As String = ""
    'Dim Bill_Id As String = ""
    Dim PID As String = ""
    Dim Bill_Id_Date As Date = #1/1/1999#
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.Print, Cmd_Preview)

    End Sub


    Public Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal initID As String)
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Bill_ID = initID
        Me.Mode = Mode
    End Sub




    Private Sub Form_Me_Load() Handles MyBase.Me_Load

        ID = 40203
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        If Bill_ID = "" AndAlso P_F_RS_ID <> "" Then
            Bill_ID = P_F_RS_ID
        End If

        DP_Start.DateTimePickerControl.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        DP_Start.DateTimePickerControl.Format = DateTimePickerFormat.Custom
        DP_Start.DateTimePickerControl.Value = GetTime.AddHours(-12)


        Dp_End.DateTimePickerControl.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Dp_End.DateTimePickerControl.Format = DateTimePickerFormat.Custom
        Dp_End.DateTimePickerControl.Value = GetTime()
        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try

        Me_Refresh()
        isLoaded = True

    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.PB_GetById(Bill_ID)
        If msgTable.IsOk Then

            If Mode = Mode_Enum.Modify AndAlso msgTable.Dt.Rows.Count = 0 Then
                ShowErrMsg("没有找到" & Dao.PBStore_DB_NAME & "[" & Bill_ID & "]", True)
                Exit Sub
            End If
            dtTable = msgTable.Dt
            SetForm(dtTable)
        End If
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加" & Dao.PBStore_DB_NAME & "!", True) : Exit Sub
                R.Start(DP_Start.DateTimePickerControl.Value, Dp_End.DateTimePickerControl.Value)
                LabelTitle.Text = "新建" & Me.Ch_Name
                DTP_sDate.Value = GetDate()
                GetNewID()
            Case Mode_Enum.Modify
                LabelTitle.Text = "查看" & Me.Ch_Name
                R.Start(Bill_ID)
                LId = TB_ID.Text

        End Select
        dtTable.AcceptChanges()
    End Sub

#Region "获取新单号"
    Private Sub Label_ID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.Click
        If TB_ID.ReadOnly OrElse TB_ID.Enabled = False Then
            ShowErrMsg("非新增状态不能修改单号!")
        Else
            ShowConfirm("是否获取新单号?", AddressOf ReGetNewID)
        End If
    End Sub

    Sub ReGetNewID()
        If TB_ID.Text <> LId OrElse LId = "" Then
            ComFun.DelBillNewID(BillType.Applique, Bill_ID)
            Bill_Id_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> Bill_Id_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.PBStore, DTP_sDate.Value, Bill_ID)
                If R.IsOk Then
                    Bill_Id_Date = R.NewIdDate
                    DTP_sDate.MinDate = R.MaxDate.AddDays(1)
                    DTP_sDate.Value = R.NewIdDate
                    Bill_ID = R.NewID
                    TB_ID.Text = Bill_ID.Replace("-", "")
                    If R.IsTheDate = False Then
                        ShowErrMsg(R.RetrunMsg)
                    End If
                Else
                    ShowErrMsg(R.RetrunMsg)
                End If
            End If
        End If
    End Sub

    Private Sub DTP_sDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        GetNewID()
    End Sub

#End Region


#Region "控件事件"

    'Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
    '    GR.Refresh()
    'End Sub

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me_Refresh()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"




    ''' <summary>
    '''自动搜索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TB_ConditionValue1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me_Refresh()
    End Sub


    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList
        Dim oList As New OptionList
        Dim fo As New FindOption
        Dim sqlbuider As New StringBuilder("")
        Dim goodsCount As Integer = 0
        fo = New FindOption
        fo.DB_Field = "sDate"
        fo.Value = DP_Start.Value.Date
        fo.Value2 = Dp_End.Value.Date
        fo.Field_Operator = Enum_Operator.Operator_Between
        oList.FoList.Add(fo)


        fo = New FindOption
        fo.DB_Field = "Old_PB"
        fo.Value = 0
        fo.Field_Operator = Enum_Operator.Operator_More
        oList.FoList.Add(fo)


        Return oList
    End Function

#End Region

#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        'Dim GH As String = GR.GetSelRowCellText(0)
        'If GR.SelRowNo >= 0 Then
        '    Dim F As New F30001_Produce_Gd_Msg(GH)
        '    With F
        '        .Mode = Mode_Enum.Modify
        '        .P_F_RS_ID = ""
        '        .P_F_RS_ID2 = ""
        '    End With
        '    F_RS_ID = ""
        '    Me.ReturnId = ""
        '    Me.ReturnObj = Nothing
        '    Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        '    VF.Show()
        'End If
    End Sub
#End Region
#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        Dim ID As String = IIf(Mode = Mode_Enum.Add, TB_ID.Text, LId)
        dt = dtTable
        Dim dr As DataRow = dt.Rows(0)
        dr("ID") = TB_ID.Text

        dr("sTime") = DP_Start.DateTimePickerControl.Value
        dr("eTime") = Dp_End.DateTimePickerControl.Value
        dr("sDate") = DTP_sDate.Value
        dr("sUser") = TB_sUser.Text
        dt.AcceptChanges()


        Dim Msgdt As DtReturnMsg = Dao.GetStoreNo(DP_Start.DateTimePickerControl.Value, Dp_End.DateTimePickerControl.Value)
        If Msgdt.IsOk Then
            If Msgdt.Dt.Columns.Contains("ID") = False Then Msgdt.Dt.Columns.Add("ID", GetType(String))
            For Each drS As DataRow In Msgdt.Dt.Rows
                drS("ID") = TB_ID.Text
            Next
            dtList = Msgdt.Dt
        End If
        dtList.AcceptChanges()
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If dt Is Nothing Then
            Exit Sub
        End If

        Dim Dr As DataRow
        If dt.Rows.Count = 0 Then
            Dr = dt.NewRow

            Dr("ID") = TB_ID.Text
            Dr("sUser") = User_Name

            Dr("sDate") = ServerTime.Date
            Dr("sTime") = DP_Start.DateTimePickerControl.Value
            Dr("eTime") = Dp_End.DateTimePickerControl.Value
            dt.Rows.Add(Dr)
            dt.AcceptChanges()
            LockForm(True)
        Else
            Dr = dt.Rows(0)
            LockForm(False)
        End If

        TB_ID.Text = IsNull(Dr("ID"), "")
        DP_Start.DateTimePickerControl.Value = Dr("sTime")
        Dp_End.DateTimePickerControl.Value = Dr("eTime")
        TB_sUser.Text = Dr("sUser")

    End Sub

    Private Sub LockForm(ByVal LOCK As Boolean)
        Cmd_Preview.Enabled = Not LOCK
        Cmd_Print.Enabled = Not LOCK
        TB_ID.ReadOnly = Not LOCK
        DP_Start.Enabled = LOCK
        Dp_End.Enabled = LOCK
        DTP_sDate.Enabled = LOCK
        Btn_Search.Enabled = LOCK
        Cmd_Save.Enabled = LOCK
    End Sub

    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub



#End Region

#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        R.Start(TB_ID.Text, OperatorType.Preview)
    End Sub


    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        R.Start(TB_ID.Text, OperatorType.Print)
    End Sub


#End Region

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        ShowConfirm("是否保存库存快照?", "保存", "保存并打印", "取消", AddressOf Savepbstore_NoPrint, AddressOf Savepbstore_Print, AddressOf DoNothing)
    End Sub



    Private Sub Savepbstore_NoPrint()
        SavePBStore(False)
    End Sub

    Private Sub Savepbstore_Print()
        SavePBStore(True)
    End Sub

    Private Sub DoNothing()

    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SavePBStore(Optional ByVal isPrint As Boolean = False)
        Dim Rm As MsgReturn
        Dim Dt As DataTable = GetForm()

        Rm = Dao.PBStore_Add(Dt, dtList)

        If Rm.IsOk Then
            LId = TB_ID.Text
            LastForm.ReturnId = TB_ID.Text
            Mode = Mode_Enum.Modify
            If isPrint Then
                'Dim msg As MsgReturn = Dao.Applique_Audited(TB_ID.Text, True)
                'If msg.IsOk Then
                '    Bill_ID = TB_ID.Text
                '    Me_Refresh()
                '    ShowOk(msg.Msg)
                'Else
                '    ShowErrMsg("保存成功,但" & msg.Msg)
                'End If
                R.Start(TB_ID.Text, OperatorType.Print)

            End If
            If TB_ID.Text = Bill_ID.Replace("-", "") Then Bill_ID = ""
            ShowOk(Rm.Msg, True)
        Else
            ShowErrMsg(Rm.Msg)
        End If
    End Sub








End Class

Partial Class Dao

    Public Const PBStore_DB_NAME As String = "仓位对照单"
    Public Const SQL_GetPB As String = "  Select * from  T40204_PBStore_Table Where ID=@ID"

    Public Const SQL_GetStoreQty_byStore As String = " Select s.StoreNo,S.ID as  inID,S.BZ_ID,BZ_No ,b.BZ_Name ,s.InStore,S.OStore,isnull(p.Qty ,0)As Qty  " & vbCrLf & _
   " from  (" & vbCrLf & _
   " select D.StoreNo,D.ID ,T.BZ_ID, SUM(case when D.InQty>0 then D.InQty else 0 end)As InStore ," & vbCrLf & _
   " SUM(case when D.InQty<0 then D.InQty else 0 end)As OStore From T40521_PB_Detail D " & vbCrLf & _
   "  Left join  T40100_PBRK_Table  T On D.ID=T.ID " & vbCrLf & _
   "   Where D.sDate Between @sDate1 and @sDate2 And " & vbCrLf & _
   "   T.State=1  Group by D.StoreNo ,D.ID ,T .BZ_ID" & vbCrLf & _
   "   )S  Left join   " & vbCrLf & _
   "   (Select StoreNo,ID,SUM(Qty)as Qty from  T40520_PB_StoreNo Group by StoreNo,ID )" & vbCrLf & _
   "    P ON S.StoreNo=p.StoreNo and S.ID=P.ID" & vbCrLf & _
   "    LEFT JOIN T10002_BZ b ON s.BZ_ID=b.ID " & vbCrLf & _
   "    order by s.StoreNo "


    Public Const SQL_GetStoreList As String = "Select * from T40205_PBStore_List Where ID=@ID"

    ''' <summary>
    ''' 获取对照表表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PB_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_GetPB, "@ID", sId)
    End Function


    ''' <summary>
    ''' 获取仓位信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStoreNo(ByVal sTime As Date, ByVal eTime As Date) As DtReturnMsg
        Dim p As New Dictionary(Of String, Object)
        p.Add("@sDate1", sTime)
        p.Add("@sDate2", eTime)
        Return PClass.PClass.SqlStrToDt(SQL_GetStoreQty_byStore, p)
    End Function



    ''' <summary>
    ''' 添加日报表
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBStore_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As MsgReturn
        Dim msg As New DtListReturnMsg
        Dim R As New MsgReturn
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim AppliqueId As String = dtTable.Rows(0)("ID")
        Dim IsInsert As Boolean = False
        paraMap.Add("ID", AppliqueId)
        Try
            sqlMap.Add("Table", SQL_GetPB)
            sqlMap.Add("List", SQL_GetStoreList)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & AppliqueId & "'," & BillType.Applique & ")"
                DtToUpDate(msg, TmSQL)
                R.Msg = "" & PBStore_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                R.IsOk = True
            Else
                R.IsOk = False
                R.Msg = "" & PBStore_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]已经存在!请双击编号文本框,获取新编号!"
            End If
            Return R
        Catch ex As Exception
            R.IsOk = False
            R.Msg = "" & PBStore_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return R
        Finally
        End Try
    End Function













End Class


