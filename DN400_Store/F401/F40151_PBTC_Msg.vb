Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport


Public Class F40151_PBTC_Msg
    Dim dtList As DataTable
    Dim dtTable As DataTable
    Dim DtChePai As DataTable
    Dim State As Enum_PBTC = Enum_PBTC.New_PBTC

    Dim NewStoreList As New List(Of String)
    Dim NewStore_Dt As DataTable
    Dim NowStore_Dt As DataTable
    Dim OldStoreList As New List(Of String)
    Dim OldStore_Dt As DataTable
    Dim NewStore As String = ""
    Dim OldStore As String = ""
    Dim LId As String = ""
    Dim PID As String = ""
    Dim PID_Date As Date = #1/1/1999#

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

    'Private Sub F20001_PBTC_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Try
    '            If Me.ActiveControl.Name <> Fg1.Name AndAlso ActiveControl.Parent.Name <> Fg1.Name Then
    '                SendKeys.SendWait("{TAB}")
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub


    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 40150
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub

    Private Sub Form_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        ComFun.DelBillNewID(BillType.PBTC, PID)
    End Sub

    Private Sub F10101_PBTC_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name

        Fg1.IniFormat()
        Fg1.IniColsSize()
        Fg2.IniFormat()
        Fg2.IniColsSize()
        Fg3.IniFormat()
        Fg3.IniColsSize()
        Fg4.IniFormat()
        Fg4.IniColsSize()

        Me_Refresh()
        Select Case Mode
            Case Mode_Enum.Add
                DTP_sDate.Value = GetTime().AddHours(-8).Date
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub

                TB_ZhiDan.Text = User_Display
                LabelTitle.Text = "新建" & Me.Ch_Name
                TB_ZhiDan.Text = PClass.PClass.User_Display

            Case Mode_Enum.Look, Mode_Enum.Modify
                TB_ID.ReadOnly = True
                LabelTitle.Text = "查看" & Me.Ch_Name

        End Select
    End Sub

    Protected Sub Me_Refresh()
        Dim msgTable As DtReturnMsg = Dao.PBTC_GetById(Bill_ID)
        If msgTable.IsOk Then
            dtTable = msgTable.Dt
            SetForm(msgTable.Dt)
        End If
        If Mode = Mode_Enum.Add Then
            GetNewID()
            GroupBox4.Visible = False
            SplitContainer1.Visible = True
            CaculateSumAmount()
        Else
            LabelState.Text = "已生效"
            GroupBox4.Visible = True
            SplitContainer1.Visible = False
            Cmd_Modify.Visible = False
            GroupBox4.BringToFront()
            Dim R As DtReturnMsg = Dao.PBTC_GetListById(Bill_ID)
            If R.IsOk Then
                Fg4.DtToSetFG(R.Dt)
            Else
                ShowErrMsg(R.Msg, True)
                Exit Sub
            End If

        End If
    End Sub

#Region "表单信息"




    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtTable.Clone
        If Not dt Is Nothing AndAlso Not TB_ID.Text = "" Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dr("ID") = TB_ID.Text
            dr("sDate") = DTP_sDate.Value.ToString("yyyy-MM-dd")


          '  dr("SumQty") = Val(TB_Now_Qty.Text)
            ' dr("SumPWeight") = Val(TB_PWeight.Text)

            GetControlValue(dr, TB_Remark)
            GetControlValue(dr, TB_ZhiDan)
            dt.Rows.Add(dr)
            dtTable = dt


            Dim StoreList_New As New List(Of String)
            Dim StoreList_Old As New List(Of String)
            NewStore_Dt.DefaultView.Sort = "StoreNo_New,sID"

            dr("Old_CangWei") = BaseClass.ComFun.DtToString(NewStore_Dt.DefaultView.ToTable("T", True, "StoreNo"), "StoreNo", "|")
            dr("CangWei") = BaseClass.ComFun.DtToString(NewStore_Dt.DefaultView.ToTable("T", True, "StoreNo_New"), "StoreNo_New", "|")
            dtList = NewStore_Dt.DefaultView.ToTable("T").Copy
            NewStore_Dt = dtList
            Dim sumQty As Integer = 0
            If dtList.Columns.Contains("ID") = False Then dtList.Columns.Add("ID")
            For Each Row As DataRow In dtList.Rows
                Row("ID") = TB_ID.Text
                sumQty = sumQty + Row("Qty")
            Next
            dr("SumQty") = sumQty
        End If

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

        If dt.Rows.Count = 1 Then
            Dim Dr As DataRow = dt.Rows(0)
            TB_ID.Text = IsNull(Dr("ID"), "")
            If Not Dr("sDate") Is DBNull.Value Then
                DTP_sDate.Value = Dr("sDate")
            End If
            SetControlValue(Dr, TB_Remark)
            SetControlValue(Dr, TB_CangWei)
            SetControlValue(Dr, TB_Old_CangWei)
            SetControlValue(Dr, TB_ZhiDan)
        Else
        End If
    End Sub
    Sub LockForm(ByVal Lock As Boolean)
        TB_ID.ReadOnly = Lock
        DTP_sDate.Enabled = Not Lock
        TB_Remark.ReadOnly = Lock
        Cmd_Modify.Visible = Not Lock
        Fg1.IniColsSize()
        Fg1.FG_ColResize()
    End Sub

    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        Dim s As Double = 0
        Dim N As Double = 0
        For i As Integer = 1 To Fg1.Rows.Count - 1
            s = s + Val(Fg1.Item(i, "Qty"))
            N = N + 1
        Next
        TB_Old_Qty.Text = s
        'TB_Old_PWeight.Text = s
        N = 0
        s = 0
        For i As Integer = 1 To Fg2.Rows.Count - 1
            s = s + Val(Fg2.Item(i, "Qty"))
            N = N + 1
        Next
        TB_Now_Qty.Text = s
        '  TB_Now_PWeight.Text = s
        N = 0
        s = 0
        For i As Integer = 1 To Fg3.Rows.Count - 1
            s = s + Val(Fg3.Item(i, "Qty"))
            N = N + 1
        Next
        TB_New_Qty.Text = s
        '  TB_New_PWeight.Text = s
    End Sub


#End Region

#Region "工具栏按钮"

    ''' <summary>
    ''' 保存按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        If CheckForm() Then
            If Mode = Mode_Enum.Add Then
                ShowConfirm("是否保存新" & Ch_Name & "?", AddressOf SavePBTC)
            Else
                ShowConfirm("是否保存" & Ch_Name & "[" & TB_ID.Text & "] 的修改?", AddressOf SavePBTC)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SavePBTC(Optional ByVal Audit As Boolean = False)
        'SetStoreNoList(True)

        Dim R As DtListReturnMsg
        '    dtList = FGToDtList()
        If Me.Mode = Mode_Enum.Add Then
            R = Dao.PBTC_Add(GetForm(), dtList)
        Else
            Exit Sub
        End If
        If R.IsOk Then
            LastForm.ReturnId = TB_ID.Text

            ShowOk(R.Msg, True)
        Else
            ShowErrMsg(R.Msg)
        End If
    End Sub
    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        'FG_Adjust()
        CaculateSumAmount()
        TB_ID.Text = TB_ID.Text.Trim
        If TB_ID.Text = "" Then
            ShowErrMsg(Ch_Name & "单号不能为空!", AddressOf TB_ID.Focus)
            Return False
        End If
        If Mode = Mode_Enum.Add AndAlso Dao.PBTC_CheckID(TB_ID.Text) Then
            ShowErrMsg(Ch_Name & "单号[" & TB_ID.Text & "]已经存在!", AddressOf TB_ID.Focus)
            Return False
        End If


        If NewStore_Dt.Rows.Count <= 0 Then
            ShowErrMsg("列表不能为空!")
            Return False
        End If


        Me.Refresh()
        Return True
    End Function


    'Sub FG_Adjust()
    '    DtListToFg(FGToDtList())
    'End Sub


    'Private Sub Cmd_Adjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Adjust.Click
    '    FG_Adjust()
    'End Sub


    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub






#End Region

#Region "报表事件"

    'Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Preview.Click
    '    Print(OperatorType.Preview)
    'End Sub

    'Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Print.Click
    '    Print(OperatorType.Print)
    'End Sub

    'Protected Sub Print(ByVal DoOperator As OperatorType)
    '    'If Me.Mode = Mode_Enum.Add Then
    '    '    Exit Sub
    '    'End If
    '    'Dim R As New R40001_PBTC
    '    'R.Start(TB_ID.Text, DoOperator)
    'End Sub

#End Region

#Region "选择仓位"


#Region "调入仓位"

    Private Sub Cmd_NewStoreNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_NewStoreNo.Click
        Dim F As New F40500_Store_Map(cStore_Area.Enum_SelType.Cell, NewStoreList)
        With F
            .Mode = Mode_Enum.Add
            .IsSel = True
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.MaximizeBox = True
        AddHandler VF.ClosedX, AddressOf GetNewStoreNo
        VF.Show()
    End Sub



    Private Sub Cmd_NewStoreNo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NewStore = sender.Text
        ShowConfirm("是否删除仓位[" & sender.Text & "]", AddressOf NewStore_Del)
    End Sub

    Sub NewStore_Del()
        NewStoreList.Remove(NewStore)
        Dim Rows() As DataRow
        'If NewStore_Dt IsNot Nothing Then



        '    Rows = NewStore_Dt.Select("StoreNo_New='" & NewStore & "'")
        '    For i As Integer = Rows.Length - 1 To 0 Step -1
        '        Dim Row As DataRow = Rows(i)
        '        If NewStoreList.Contains(Row("StoreNo_New")) = False Then
        '            Dim Rows_Old() As DataRow = OldStore_Dt.Select("sLine=" & Row("sLine"))
        '            If Rows_Old.Length > 0 Then
        '                Rows_Old(0)("IsSel") = 0
        '            End If
        '            Row.Delete()
        '        End If
        '        NewStore_Dt.AcceptChanges()
        '    Next
        'End If
        Rows = NowStore_Dt.Select("StoreNo='" & NewStore & "'")
        For i As Integer = Rows.Length - 1 To 0 Step -1
            Rows(i).Delete()
        Next
        ReFresh_NewStoreNo()
        NewStoreNo_All_Click(NewStoreNo_All, New EventArgs)
        FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", OldStore, True)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetNewStoreNo()
        If Not Me.ReturnObj Is Nothing Then
            Try
                Dim sNoList As List(Of String) = Me.ReturnObj
                '检查仓位是否已经存在
                If OldStoreList IsNot Nothing Then
                    For Each S As String In OldStoreList
                        If sNoList.Contains(S) Then
                            sNoList.Remove(S)
                        End If
                    Next
                End If
                NewStoreList = sNoList
                'CaculateSumAmount()
                ReFresh_NewStoreNo()
                FG2_Refresh()
                NewStoreNo_All_Click(NewStoreNo_All, New EventArgs)
                FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", OldStore, True)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub ReFresh_NewStoreNo()
        NewStoreList.Sort()
        Dim i As Integer = 1
        For Each _sNo As String In NewStoreList
            If ToolStrip_StoreNo_New.Items.ContainsKey("NewStoreNo" & i) = False Then
                Dim T As New System.Windows.Forms.ToolStripButton
                T.DisplayStyle = ToolStripItemDisplayStyle.Text
                T.Name = "NewStoreNo" & i
                T.ForeColor = Color.Blue
                T.ToolTipText = "双击移除仓位" & _sNo
                T.DoubleClickEnabled = True
                ToolStrip_StoreNo_New.Items.Add(T)
                ToolStrip_StoreNo_New.Tag = i
                AddHandler T.DoubleClick, AddressOf Cmd_NewStoreNo_DoubleClick
                AddHandler T.Click, AddressOf NewStoreNo_All_Click
            End If
            ToolStrip_StoreNo_New.Items("NewStoreNo" & i).Visible = True
            ToolStrip_StoreNo_New.Items("NewStoreNo" & i).Text = _sNo
            i = i + 1
        Next
        For j As Integer = ToolStrip_StoreNo_New.Tag To i Step -1
            RemoveHandler ToolStrip_StoreNo_New.Items("NewStoreNo" & j).DoubleClick, AddressOf Cmd_NewStoreNo_DoubleClick
            RemoveHandler ToolStrip_StoreNo_New.Items("NewStoreNo" & j).Click, AddressOf NewStoreNo_All_Click
            ToolStrip_StoreNo_New.Items.RemoveByKey("NewStoreNo" & j)
        Next
        ToolStrip_StoreNo_New.Tag = i - 1

    End Sub

    Private Sub NewStoreNo_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewStoreNo_All.Click
        For j As Integer = 1 To ToolStrip_StoreNo_New.Tag
            CType(ToolStrip_StoreNo_New.Items("NewStoreNo" & j), ToolStripButton).Checked = False
        Next
        If NewStoreNo_All.Text <> sender.text Then NewStoreNo_All.Checked = False
        sender.Checked = True
        NewStore = sender.text
        FG_ChangeStore(Fg2, NowStore_Dt, "StoreNo", sender.text)
        FG_ChangeStore(Fg3, NewStore_Dt, "StoreNo_New", sender.text)
    End Sub


    Sub FG2_Refresh()
        If NewStoreList.Count > 0 Then
            Dim R As DtReturnMsg = Dao.PBTC_GetByStoreNo(NewStoreList)
            If R.IsOk Then
                NowStore_Dt = R.Dt
                'If NewStore_Dt IsNot Nothing Then
                '    For Each Row As DataRow In NewStore_Dt.Rows
                '        If NewStoreList.Contains(Row("StoreNo_New")) = False Then
                '            Dim Rows() As DataRow = OldStore_Dt.Select("sLine=" & Row("sLine"))
                '            If Rows.Length > 0 Then
                '                Rows(0)("IsSel") = 0
                '            End If
                '            Row.Delete()
                '        End If
                '    Next
                '    NewStore_Dt.AcceptChanges()
                '  End If
            End If
        Else
            NowStore_Dt = Nothing
        End If
    End Sub

    Private Sub TB_StoreNo_New_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_StoreNo_New.KeyPress
        If e.KeyChar = vbCr Then
            TB_StoreNo_New.Text = StrConv(TB_StoreNo_New.Text, vbNarrow)
            e.Handled = True
            If OldStoreList.Contains(TB_StoreNo_New.Text) Then
                ShowErrMsg("仓位" & TB_StoreNo_Old.Text & "在调出仓位列表中!", AddressOf TB_StoreNo_New.Focus)
                TB_StoreNo_New.SelectAll()
                Exit Sub
            End If
            If NewStoreList.Contains(TB_StoreNo_New.Text) Then
                NewStoreNo_All_Click(ToolStrip_StoreNo_New.Items("NewStoreNo" & ToolStrip_StoreNo_New.Tag), New EventArgs)
                TB_StoreNo_New.Text = ""
                Exit Sub
            End If
            If CheckStoreNo(TB_StoreNo_New.Text) Then
                NewStoreList.Add(TB_StoreNo_New.Text.ToUpper)
                ReFresh_NewStoreNo()
                FG2_Refresh()
                NewStoreNo_All_Click(ToolStrip_StoreNo_New.Items("NewStoreNo" & ToolStrip_StoreNo_New.Tag), New EventArgs)
                TB_StoreNo_New.Text = ""

            Else
                ShowErrMsg("没有找到仓位" & TB_StoreNo_New.Text, AddressOf TB_StoreNo_New.Focus)
                TB_StoreNo_New.SelectAll()
            End If
        End If
    End Sub
#End Region

#Region "调出仓位"

    Private Sub Cmd_OldStoreNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_OldStoreNo.Click
        Dim F As New F40500_Store_Map(cStore_Area.Enum_SelType.Cell, OldStoreList)
        With F
            .Mode = Mode_Enum.Add
            .IsSel = True
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.MaximizeBox = True
        AddHandler VF.ClosedX, AddressOf GetOldStoreNo
        VF.Show()
    End Sub



    Private Sub Cmd_OldStoreNo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OldStore = sender.Text
        ShowConfirm("是否删除仓位[" & sender.Text & "]", AddressOf OldStore_Del)
    End Sub

    Sub OldStore_Del()
        OldStoreList.Remove(OldStore)
        If OldStore_Dt Is Nothing Then
            Exit Sub
        End If
        Dim Rows() As DataRow = OldStore_Dt.Select("StoreNo='" & OldStore & "'")
        For i As Integer = Rows.Length - 1 To 0 Step -1
            Rows(i).Delete()
        Next
        ReFresh_OldStoreNo()
        OldStoreNo_All_Click(OldStoreNo_All, New EventArgs)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetOldStoreNo()
        If Not Me.ReturnObj Is Nothing Then
            Try
                Dim sNoList As List(Of String) = Me.ReturnObj
                '检查仓位是否已经存在
                If NewStoreList IsNot Nothing Then
                    For Each S As String In NewStoreList
                        If sNoList.Contains(S) Then
                            sNoList.Remove(S)
                        End If
                    Next
                End If
                OldStoreList = sNoList
                'CaculateSumAmount()
                ReFresh_OldStoreNo()
                FG1_Refresh()
                OldStoreNo_All_Click(OldStoreNo_All, New EventArgs)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub ReFresh_OldStoreNo()
        OldStoreList.Sort()
        Dim i As Integer = 1
        For Each _sNo As String In OldStoreList
            If ToolStrip_StoreNo_Old.Items.ContainsKey("OldStoreNo" & i) = False Then
                Dim T As New System.Windows.Forms.ToolStripButton
                T.DisplayStyle = ToolStripItemDisplayStyle.Text
                T.Name = "OldStoreNo" & i
                T.ForeColor = Color.Blue
                T.ToolTipText = "双击移除仓位" & _sNo
                T.DoubleClickEnabled = True
                ToolStrip_StoreNo_Old.Items.Add(T)
                ToolStrip_StoreNo_Old.Tag = i
                AddHandler T.DoubleClick, AddressOf Cmd_OldStoreNo_DoubleClick
                AddHandler T.Click, AddressOf OldStoreNo_All_Click
            End If
            ToolStrip_StoreNo_Old.Items("OldStoreNo" & i).Visible = True
            ToolStrip_StoreNo_Old.Items("OldStoreNo" & i).Text = _sNo
            i = i + 1
        Next
        For j As Integer = ToolStrip_StoreNo_Old.Tag To i Step -1
            RemoveHandler ToolStrip_StoreNo_Old.Items("OldStoreNo" & j).DoubleClick, AddressOf Cmd_OldStoreNo_DoubleClick
            RemoveHandler ToolStrip_StoreNo_Old.Items("OldStoreNo" & j).Click, AddressOf OldStoreNo_All_Click
            ToolStrip_StoreNo_Old.Items.RemoveByKey("OldStoreNo" & j)
        Next
        ToolStrip_StoreNo_Old.Tag = i - 1
    End Sub

    Private Sub OldStoreNo_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OldStoreNo_All.Click
        For j As Integer = 1 To ToolStrip_StoreNo_Old.Tag
            CType(ToolStrip_StoreNo_Old.Items("OldStoreNo" & j), ToolStripButton).Checked = False
        Next
        If OldStoreNo_All.Text <> sender.text Then OldStoreNo_All.Checked = False
        sender.Checked = True
        OldStore = sender.text
        FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", sender.text, True)
    End Sub


    Sub FG1_Refresh()
        If OldStoreList.Count > 0 Then
            Dim R As DtReturnMsg = Dao.PBTC_GetByStoreNo(OldStoreList)
            If R.IsOk Then
                If NewStore_Dt IsNot Nothing Then
                    For Each Row As DataRow In R.Dt.Rows
                        If NewStore_Dt.Select("sLine=" & Row("sLine")).Length > 0 Then
                            Row("IsSel") = 1
                        End If
                    Next
                End If
                OldStore_Dt = R.Dt
            End If
        Else
            OldStore_Dt = Nothing
        End If
    End Sub


    Sub FG_ChangeStore(ByVal FG As FG, ByVal Dt As DataTable, ByVal Field As String, ByVal Store As String, Optional ByVal IsSearchNo As Boolean = False)
        If Dt IsNot Nothing Then
            FG.Redraw = False
            Dim SearchNo As String = ""
            If TB_SearchNo.Text <> "" AndAlso IsSearchNo Then
                SearchNo = " and sID like '%" & TB_SearchNo.Text & "%'"
            End If
            If Store = "全部" Then
                FG.DtToSetFG(DtRunSQLtoDt(Dt, " IsSel=0" & SearchNo))
            Else
                FG.DtToSetFG(DtRunSQLtoDt(Dt, Field & "='" & Store & "' and IsSel=0" & SearchNo))
            End If
            FG.Redraw = True
        Else
            FG.Rows.Count = 1
        End If
        CaculateSumAmount()
    End Sub

    Private Sub TB_StoreNo_Old_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_StoreNo_Old.KeyPress
        If e.KeyChar = vbCr Then
            e.Handled = True
            TB_StoreNo_Old.Text = StrConv(TB_StoreNo_Old.Text, vbNarrow)

            If NewStoreList.Contains(TB_StoreNo_Old.Text) Then
                ShowErrMsg("仓位" & TB_StoreNo_Old.Text & "在调入仓位列表中!", AddressOf TB_StoreNo_Old.Focus)
                TB_StoreNo_Old.SelectAll()
                Exit Sub
            End If
            If OldStoreList.Contains(TB_StoreNo_Old.Text) Then
                OldStoreNo_All_Click(ToolStrip_StoreNo_Old.Items("OldStoreNo" & ToolStrip_StoreNo_Old.Tag), New EventArgs)
                TB_StoreNo_Old.Text = ""
                Exit Sub
            End If
            If CheckStoreNo(TB_StoreNo_Old.Text) Then
                OldStoreList.Add(TB_StoreNo_Old.Text.ToUpper)
                ReFresh_OldStoreNo()
                FG1_Refresh()
                OldStoreNo_All_Click(ToolStrip_StoreNo_Old.Items("OldStoreNo" & ToolStrip_StoreNo_Old.Tag), New EventArgs)
                TB_StoreNo_Old.Text = ""
            Else
                ShowErrMsg("没有找到仓位" & TB_StoreNo_Old.Text, AddressOf TB_StoreNo_Old.Focus)
                TB_StoreNo_Old.SelectAll()
            End If
        End If
    End Sub
#End Region






    'Sub FG2_Refresh()
    '    If StoreNo <> "" Then
    '        Dim L As New List(Of String)
    '        L.Add(StoreNo)
    '        Dim R As DtReturnMsg = Dao.PBTC_GetByStoreNo(L)
    '        If R.IsOk Then
    '            Fg2.DtToSetFG(R.Dt)
    '        End If
    '    Else
    '        Fg2.Rows.Count = 1
    '    End If
    'End Sub

    'Sub ReFresh_StoreNo()
    '    FG2_Refresh()
    'End Sub

    'Private Sub TB_StoreNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = vbCr Then
    '        e.Handled = True
    '        If CheckStoreNo(TB_StoreNo.Text) Then
    '            StoreNo = TB_StoreNo.Text.ToUpper
    '            LB_StoreNo.Text = StoreNo
    '            ReFresh_StoreNo()
    '            TB_StoreNo.Text = ""
    '        Else
    '            ShowErrMsg("没有找到仓位" & TB_StoreNo.Text, AddressOf TB_StoreNo.Focus)
    '            TB_StoreNo.SelectAll()
    '        End If
    '    End If
    'End Sub


    'Private Sub Cmd_StoreNoSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim L As New List(Of String)
    '    If StoreNo <> "" Then
    '        L.Add(StoreNo)
    '    End If
    '    Dim F As New F40500_Store_Map(cStore_Area.Enum_SelType.Cell, L)
    '    With F
    '        .Mode = Mode_Enum.Add
    '        .IsSel = True
    '        .P_F_RS_ID = ""
    '        .P_F_RS_ID2 = ""
    '    End With
    '    F_RS_ID = ""
    '    Me.ReturnId = ""
    '    Me.ReturnObj = Nothing
    '    Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
    '    VF.MaximizeBox = True
    '    AddHandler VF.ClosedX, AddressOf GetStoreNo
    '    VF.Show()
    'End Sub


    'Protected Sub GetStoreNo()
    '    If Not Me.ReturnObj Is Nothing Then
    '        Try
    '            Dim sNoList As List(Of String) = Me.ReturnObj
    '            If sNoList.Count > 0 Then
    '                StoreNo = sNoList(sNoList.Count - 1)
    '                LB_StoreNo.Text = StoreNo
    '            End If

    '            ReFresh_StoreNo()
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Protected Function CheckStoreNo(ByVal _storeNO) As Boolean
        Dim msg As DtReturnMsg = ComFun.StoreMap_CheckStoreNo(_storeNO)
        If msg.IsOk AndAlso msg.Dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "FG"

    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        Cmd_RowAdd_Click(sender, e)
    End Sub
    Private Sub Cmd_RowAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RowAdd.Click
        ShowInput("请输入调出数量", AddressOf OutQty)
    End Sub

    Sub OutQty(ByVal s As String)
        If Fg1.Selection.TopRow > 0 Then
            Dim NS As String = ""
            Dim OQty As String = ""
            If NewStore = "" OrElse NewStore = "全部" Then
                If NewStoreList.Count = 0 Then
                    ShowErrMsg("请选择一个调入仓位!", AddressOf TB_StoreNo_New.Focus)
                    Exit Sub
                Else
                    NS = NewStoreList(0)
                End If
            Else
                NS = NewStore
            End If

            If Val(s) = 0 Then
                ShowErrMsg("请输入需要调出的数量!")
                Exit Sub
            ElseIf Val(s) > Fg1.Item(Fg1.RowSel, "Qty") Then
                ShowErrMsg("输入数量大于仓位[" & Fg1.Item(Fg1.RowSel, "StoreNo") & "]原有数量[" & Fg1.Item(Fg1.RowSel, "Qty") & "]")
                Exit Sub
            Else

                OQty = Val(s)
            End If


            If NewStore_Dt Is Nothing Then
                NewStore_Dt = OldStore_Dt.Clone
                NewStore_Dt.Columns.Add("StoreNo_New")
            End If

            Dim Row As DataRow

            For i As Integer = Fg1.Selection.TopRow To Fg1.Selection.BottomRow
                Dim expression As String
                expression = "sID='" & Fg1.Item(i, "sID") & "'" & " and StoreNo='" & Fg1.Item(i, "StoreNo") & "'"
                Dim Dr() As DataRow = OldStore_Dt.Select(expression)
                If Dr.Length > 0 Then
                    Dim Dr_New() As DataRow = NewStore_Dt.Select(expression & " and StoreNO_New ='" & NS & "'")
                    If Dr_New.Length > 0 Then
                        Dr_New(0)("Qty") = Dr_New(0)("Qty") + OQty
                        Dr_New(0)("IsSel") = 0
                    Else
                        Row = NewStore_Dt.NewRow
                        For Each C As DataColumn In OldStore_Dt.Columns
                            Row(C.ColumnName) = Dr(0)(C.ColumnName)
                        Next
                        Row("StoreNo_New") = NS
                        Row("Qty") = OQty
                        NewStore_Dt.Rows.Add(Row)
                    End If
                    Dr(0)("Qty") = Dr(0)("Qty") - OQty
                    If Dr(0)("Qty") = 0 Then
                        Dr(0).Delete()
                    End If
                End If
            Next
            OldStore_Dt.AcceptChanges()
            NewStore_Dt.AcceptChanges()

            FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", OldStore, True)
            FG_ChangeStore(Fg3, NewStore_Dt, "StoreNo_New", NewStore)

        End If
    End Sub


    Private Sub Cmd_RowDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RowDel.Click
        If Fg3.Selection.TopRow > 0 Then
            
            For i As Integer = Fg3.Selection.TopRow To Fg3.Selection.BottomRow
                Dim expression As String
                expression = "sID='" & Fg3.Item(i, "sID") & "'" & " and StoreNo='" & Fg3.Item(i, "StoreNo") & "'"
                Dim Dr() As DataRow = NewStore_Dt.Select(expression)
                If Dr.Length > 0 Then
                    Dim Dr_Old() As DataRow = OldStore_Dt.Select(expression)
                    If Dr_Old.Length > 0 Then
                        Dr_Old(0)("Qty") = Dr_Old(0)("Qty") + Dr(0)("Qty")
                        Dr_Old(0)("IsSel") = 0
                    End If
                    Dr(0).Delete()
                End If
            Next
            OldStore_Dt.AcceptChanges()
            NewStore_Dt.AcceptChanges()

            FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", OldStore, True)
            FG_ChangeStore(Fg3, NewStore_Dt, "StoreNo_New", NewStore)

        End If
    End Sub
    Private Sub Fg3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg3.DoubleClick
        Cmd_RowDel_Click(sender, e)
    End Sub
#End Region

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
            ComFun.DelBillNewID(BillType.PurchaseReturn, PID)
            PID_Date = #1/1/1999#
            GetNewID()
        End If
    End Sub

    Sub GetNewID()
        If TB_ID.ReadOnly = False Then
            If DTP_sDate.Value <> PID_Date Then
                Dim R As RetrunNewIdMsg = ComFun.GetBillNewID(BillType.PBTC, DTP_sDate.Value, PID)
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




    Private Sub Cmd_SearchNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SearchNo.Click
        FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", OldStore, True)
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        TB_SearchNo.Text = ""
        FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", OldStore, True)
    End Sub

    Private Sub TB_SearchNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_SearchNo.TextChanged
        FG_ChangeStore(Fg1, OldStore_Dt, "StoreNo", OldStore, True)
    End Sub

 

  

End Class

Public Enum Enum_PBTC
    New_PBTC = 0
    ShenHe = 1
    XiaoZhang = 2
End Enum
Partial Class Dao

#Region "仓位调整单信息"


    '===================仓位调整单信息==============
    Public Const SQL_PBTC_Get_WithName = "select  P.* from T40150_PBTC_Table P "


    Public Const SQL_PBTC_GetPBTCByid As String = "select top 1 * from T40150_PBTC_Table  where ID=@ID"





    Public Const SQL_PBTC_CheckID As String = "select count(*) from T40150_PBTC_Table  where ID=@ID"


    ''' <summary>
    ''' table
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBTC_SelByid As String = "select top 1 * from T40150_PBTC_Table  where ID=@ID"
    ''' <summary>
    ''' list
    ''' </summary>
    ''' <remarks></remarks>
    Public Const SQL_PBTC_SelListByid As String = "select  * from T40151_PBTC_List  where ID=@ID"

    Public Const SQL_PBTC_OrderBy As String = " order by sDate "


#End Region
#Region "仓位调整单"


    Public Const SQL_PBTC_GetStateByID As String = "select top 1 ID,State,State_User from T40150_PBTC_Table  where ID=@ID"

    Private Const PBTC_DB_NAME As String = "仓位调整单"

    'Public Const SQL_PBTC_GetByStoreNo = "select P.StoreNo,P.ID as sID,P.Line as sLine,BZ_Name,BZ_No" & vbCrLf & _
    '",(Select top 1 Client_Name from T10110_Client C where P.Client_Id=C.ID) as Client_Name" & vbCrLf & _
    '",RK_Date,ZL,ShaPi,Color,0 as IsSel from T40510_PB_Stock P" & _
    '      "             left join T10002_BZ BZ on  BZ_Id=BZ.ID  "
    Public Const SQL_PBTC_GetByStoreNo = "select P.BZType, P.StoreNo,P.ID as sID,P.Qty,B.BZ_Name,B.BZ_No,0 as IsSel,Client_Name,R.ShaPi from T40520_PB_StoreNo P left join T40100_PBRK_Table R on  P.ID=R.ID left join T10002_BZ B on R.BZ_ID=B.ID Left join T10110_Client C On C.ID=R.Client_ID "
    'Public Const SQL_PBTC_GetByStoreNo = "select StoreNo,ID as sID,Qty,0 as IsSel from T40520_PB_StoreNo"

    Public Const SQL_PBTC_GetList = "select L.StoreNo,L.StoreNo_New,sID,Qty,BZ_Name,BZ_No" & vbCrLf & _
            ",(Select top 1 Client_Name from T10110_Client C where T.Client_Id=C.ID) as Client_Name" & vbCrLf & _
            ",Audited_Date RK_Date,ZL,P.ShaPi,Color,0 as IsSel from T40151_PBTC_List L" & vbCrLf & _
            "left join T40101_PBRK_List P On P.Line=L.sLine" & vbCrLf & _
            "left join T40100_PBRK_Table T On T.Id=L.sID" & _
            "             left join T10002_BZ BZ on  BZ_Id=BZ.ID  where l.ID=@ID"

    Public Const SQL_PBTC_Add = "select * Into #L from T40151_PBTC_List where ID=@ID" & vbCrLf & _
    "update T40101_PBRK_List" & vbCrLf & _
           "set StoreNo=(select top 1 StoreNo_New from #L P where Id=@ID and T40101_PBRK_List.Line=p.sline)" & vbCrLf & _
           "where exists (select 1 from #L L where  T40101_PBRK_List.Line=L.sLine)" & vbCrLf & _
            "update T40150_PBTC_Table" & vbCrLf & _
           "set SumWeight=(select Sum(Isnull(ZL,0))from #L L left join T40101_PBRK_List p On  P.id=L.sid and P.line=L.sLine )" & vbCrLf & _
           "where  id=@ID" & vbCrLf & _
           "declare @sID varchar(20)" & vbCrLf & _
            "declare @LastID varchar(20)" & vbCrLf & _
            "declare @Store varchar(20)" & vbCrLf & _
            "declare @I int" & vbCrLf & _
            "declare @MsgTmp varchar(200)" & vbCrLf & _
            "declare @GHX varchar(20)" & vbCrLf & _
            "set @I=0" & vbCrLf & _
            "set @sID=''" & vbCrLf & _
            "set @LastID=''" & vbCrLf & _
            "set @MsgTmp=''" & vbCrLf & _
            "declare my_cursor cursor for  " & vbCrLf & _
            "select distinct id,StoreNo,GH from T40101_PBRK_List L," & vbCrLf & _
            "(select distinct sid from #L ) C" & vbCrLf & _
            "where l.id=c.sid  order by id,StoreNo,GH" & vbCrLf & _
            "Open my_cursor" & vbCrLf & _
            "fetch my_cursor into @sID,@Store,@GHX" & vbCrLf & _
            "while @@fetch_status=0" & vbCrLf & _
            "begin--循环" & vbCrLf & _
            "	if(@GHX='') set @MsgTmp=@MsgTmp+@Store +'|'" & vbCrLf & _
            "	set @LastID=@sID" & vbCrLf & _
            "	fetch my_cursor into @sID,@Store,@GHX" & vbCrLf & _
            "	if @LastID<>@sID or @@fetch_status<>0" & vbCrLf & _
            "	begin" & vbCrLf & _
            "		if len(@MsgTmp)>0  set @MsgTmp=left(@MsgTmp,len(@MsgTmp)-1)" & vbCrLf & _
            "		update T40100_PBRK_Table set CangWei=@MsgTmp" & vbCrLf & _
            "		where id=@LastID" & vbCrLf & _
            "		set @MsgTmp=''" & vbCrLf & _
            "	end" & vbCrLf & _
            "end--循环" & vbCrLf & _
            "close my_cursor" & vbCrLf & _
            "deallocate my_cursor"

    ''' <summary>
    ''' 获取对仓位调整单信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBTC_GetById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBTC_GetPBTCByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取对仓位调整单列表信息
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBTC_GetListById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_PBTC_GetList, "@ID", sId)
    End Function





    ''' <summary>
    ''' 获取查询条件集合
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBTC_GetConditionNames() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "请选择"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "仓位调整单号"
        fo.DB_Field = "P.ID"
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "调出仓位"
        fo.DB_Field = "Old_CangWei"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "调入仓位"
        fo.Field_Operator = Enum_Operator.Operator_Like_Both
        fo.DB_Field = "CangWei"
        foList.Add(fo)

        Return foList
    End Function

    ''' <summary>
    ''' 按条件获取仓位调整单列表
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBTC_GetByOption(ByVal oList As OptionList) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder
        sqlBuider.Append(SQL_PBTC_Get_WithName)
        sqlBuider.Append("  WHERE 1=1  ")
        sqlBuider.Append(BaseClass.OptionClass.OptionClass_BuidSqlConditon(oList.FoList, paraMap))
        sqlBuider.Append(SQL_PBTC_OrderBy)
        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    ''' <summary>
    ''' 获取仓位的内容
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBTC_GetByStoreNo(ByVal oList As List(Of String)) As DtReturnMsg
        Dim paraMap As New Dictionary(Of String, Object)
        Dim sqlBuider As New StringBuilder("")

        Dim i As Integer = 0
        For Each StoreNo As String In oList
            sqlBuider.AppendLine(SQL_PBTC_GetByStoreNo)
            sqlBuider.Append("  WHERE P.StoreNo = @StoreNo")
            sqlBuider.AppendLine(i)
            paraMap.Add("StoreNo" & i, StoreNo)
            sqlBuider.AppendLine("union all")
            i = i + 1
        Next

        If sqlBuider.Length > 0 Then
            i = "union all".Length + 4
            sqlBuider.Remove(sqlBuider.Length - i, i)

        End If

        Return PClass.PClass.SqlStrToDt(sqlBuider.ToString, paraMap)
    End Function

    Public Shared Function PBTC_CheckID(ByVal PBTC_ID As String) As Boolean
        Dim R As MsgReturn = SqlStrToOneStr(SQL_PBTC_CheckID, "@ID", PBTC_ID)
        If R.IsOk Then
            If Val(R.Msg) = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtTable"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PBTC_Add(ByVal dtTable As DataTable, ByVal dtList As DataTable) As DtListReturnMsg
        Dim msg As New DtListReturnMsg
        Dim sqlMap As New Dictionary(Of String, String)
        Dim paraMap As New Dictionary(Of String, Object)
        Dim Bill_ID As String = dtTable.Rows(0)("ID")
        paraMap.Add("ID", Bill_ID)
        Try
            sqlMap.Add("Table", SQL_PBTC_SelByid)
            sqlMap.Add("List", SQL_PBTC_SelListByid)

            msg = SqlStrToDt(sqlMap, paraMap)
            If msg.DtList("Table").Rows.Count = 0 Then
                DvToDt(dtTable, msg.DtList("Table"), New List(Of String), True)
                DvToDt(dtList, msg.DtList("List"), New List(Of String), True)
                Dim sqlbuider As New StringBuilder
                sqlbuider.AppendLine("declare @storeNoStr varchar(50)")
                For Each dr As DataRow In dtList.Rows
                    sqlbuider.AppendLine("update T40520_PB_StoreNo set Qty=Qty-" & dr("Qty") & " where StoreNo='" & dr("StoreNo") & "' and ID='" & dr("sID") & "'")
                    sqlbuider.AppendLine("insert into  T40521_PB_Detail (BillType,StoreNo,ID,BillName,InQty,sDate )  values('40150','" & dr("StoreNo") & " ','" & dr("sID") & "','调仓单'," & -1 * dr("Qty") & ",getDate())")
                    sqlbuider.AppendLine("insert into  T40521_PB_Detail (BillType,StoreNo,ID,BillName,InQty ,sDate)  values('40150','" & dr("StoreNo_New") & " ','" & dr("sID") & "','调仓单'," & dr("Qty") & ",getDate())")
                    sqlbuider.AppendLine("if ((select count(*) from T40520_PB_StoreNo where StoreNo='" & dr("StoreNo_New") & "' and ID= '" & dr("sID") & "')>0)   ")
                    sqlbuider.AppendLine("update T40520_PB_StoreNo set Qty=Qty+" & dr("Qty") & " where StoreNo='" & dr("StoreNo_New") & "' and ID='" & dr("sID") & "'")
                    sqlbuider.AppendLine(" else ")
                    sqlbuider.AppendLine("insert into  T40520_PB_StoreNo (StoreNo,ID,Qty,BZType)  values('" & dr("StoreNo_New") & " ','" & dr("sID") & "','" & dr("Qty") & "'," & IsNull(dr("BZType"), 0) & ")")
                Next
                sqlbuider.AppendLine(" delete from T40520_PB_StoreNo where Qty=0 ")
                For Each dr As DataRow In dtList.Rows
                    If IsNull(dr("BZType"), 0) = 1 Then
                        sqlbuider.AppendLine("delete from T30002_CPRK  where GH='" & dr("sID") & "'")
                        sqlbuider.AppendLine("insert into T30002_CPRK (StoreNo,GH,Qty ) select StoreNo,ID,Qty from T40520_PB_StoreNo where ID='" & dr("sID") & "'")

                        sqlbuider.AppendLine("set @storeNoStr=''")
                        sqlbuider.AppendLine("select @storeNoStr=@storeNoStr +'|'+StoreNo  from T30002_CPRK where  GH='" & dr("sID") & "'")
                        sqlbuider.AppendLine("set @storeNoStr=RIGHT (@storeNoStr,len(@storeNoStr))")
                        sqlbuider.AppendLine("update T30000_Produce_Gd set Store_CPRK =@storeNoStr  where  GH='" & dr("sID") & "'")
                    End If
                Next
                sqlbuider.AppendLine(" delete from T30002_CPRK where Qty=0 ")
                Dim i As Integer = 0
                For Each dr As DataRow In dtList.Rows
                    sqlbuider.AppendLine("declare @Str" & i & " varchar(200)")
                    sqlbuider.AppendLine("set @Str" & i & "=''")
                    sqlbuider.AppendLine("select  @Str" & i & "=@Str" & i & "+'|'+StoreNo from T40520_PB_StoreNo where ID='" & dr("sID") & "'")
                    sqlbuider.AppendLine("set @Str" & i & "=  substring(@Str" & i & ",2,len(@Str" & i & "))")
                    sqlbuider.AppendLine("update T40100_PBRK_Table set CangWei=@Str" & i & " where ID='" & dr("sID") & "'")
                    i = i + 1
                Next

                Dim TmSQL As String = "insert into Bill_Barcode (No_ID,NO_Type)values('" & Bill_ID & "'," & BillType.PBTC & ")" '& vbCrLf & SQL_PBTC_Add
                sqlbuider.AppendLine(TmSQL)
                DtToUpDate(msg, sqlbuider.ToString, paraMap)
                msg.Msg = "" & PBTC_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加成功!"
                msg.IsOk = True
            Else
                msg.IsOk = False
                msg.Msg = "" & PBTC_DB_NAME & "[" & dtTable.Rows(0)("ID") & "[已经存在!,请双击编号文本框,获取新编号!"
            End If
            Return msg
        Catch ex As Exception
            msg.IsOk = False
            msg.Msg = "" & PBTC_DB_NAME & "[" & dtTable.Rows(0)("ID") & "]添加错误!"
            DebugToLog(ex)
            Return msg
        Finally
        End Try
    End Function







#End Region
End Class

