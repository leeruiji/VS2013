Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F30205_TZPB_Msg

    Dim dtList As DataTable
    Dim dtListB As DataTable
    Dim CP_GH As String = ""

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

    'Private Sub F20001_PBRK_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
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
        ID = 30200
        Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)

    End Sub

    Private Sub F30201_CPZL_Msg_AfterLoad() Handles Me.AfterLoad

    End Sub

    Private Sub Form_Msg_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name


        Fg1.Rows.Count = 1
        Fg2.Rows.Count = 1
        Fg3.Rows.Count = 1
        Fg1.IniFormat()
        Fg2.IniFormat()
        Fg3.IniFormat()
        'CB_ChePai.DataSource = Emplyee.GetAllEmployee.Copy
        Select Case Mode
            Case Mode_Enum.Add
                If CheckRight(ID, ClassMain.Add) = False Then Me.ShowErrMsg("没有权限添加!", True) : Exit Sub
                LabelTitle.Text = Me.Ch_Name
                'Btn_Preview.Enabled = False
                'Btn_Print.Enabled = False
                Fg2.Rows.Count = 1
                Fg1.Rows.Count = 1
                CaculateSumAmount()
            Case Mode_Enum.Modify
                If Bill_ID <> "" Then
                    Get_GH(Bill_ID)
                End If

                LabelTitle.Text = Me.Ch_Name

        End Select
    End Sub







#Region "表单信息"




    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetList() As DataTable
        Dim dt As New DataTable("T")
        dt.Columns.Add("LineA", GetType(Integer))
        dt.Columns.Add("LineB", GetType(Integer))
        dt.Columns.Add("GHA", GetType(String))
        dt.Columns.Add("GHB", GetType(String))
        If Not TB_GH.Tag = "" Then
            dt.Clear()
            For i As Integer = 1 To Fg2.Rows.Count - 1
                Dim dr As DataRow = dt.NewRow
                dr("LineA") = Fg2.Item(i, "LineA")
                dr("LineB") = Fg2.Item(i, "LineB")
                dr("GHA") = TB_GH.Tag
                dr("GHB") = TB_GH_B.Tag
                dt.Rows.Add(dr)
            Next
            Return dt
        Else
            Return Nothing
        End If
    End Function





    ''' <summary>
    ''' FG合计
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateSumAmount()
        Dim ZlA As Double = 0
        Dim ZlB As Double = 0
        For i As Integer = 1 To Fg1.Rows.Count - 1
            ZlA = ZlA + Val(Fg1.Item(i, "PB"))
        Next
        For i As Integer = 1 To Fg3.Rows.Count - 1
            ZlB = ZlB + Val(Fg3.Item(i, "PB"))
        Next

        For i As Integer = 1 To Fg2.Rows.Count - 1
            ZlB = ZlB + Val(Fg2.Item(i, "PBA"))
            ZlA = ZlA + Val(Fg2.Item(i, "PBB"))
        Next

        TB_TZA.Text = FormatZL(ZlA)
        TB_TZB.Text = FormatZL(ZlB)
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
            CaculateSumAmount()
            IsPrint = False
            Dim S As String = ""
            S = "是否保存?"
            ShowConfirm(S, AddressOf SavePBRK)
        End If
    End Sub

    Sub DoNothing()

    End Sub

    Dim IsPrint As Boolean = False
    Sub SaveAndPrint()
        IsPrint = True
        SavePBRK()
    End Sub

    ''' <summary>
    ''' 保存修改
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SavePBRK()
        Dim R As MsgReturn
        Dim Dt As DataTable = GetList()
        R = Dao.TZPB_Save(TB_GH.Tag, TB_GH_B.Tag, Dt)
        If R.IsOk Then
            LastForm.ReturnId = TB_GH.Text
            ShowOk("胚重交换成功!", True)
        Else
            If R.Msg.StartsWith("2") Then
                Dim ID() As String = R.Msg.Split(";")(1).Split(",")
                Dim sErr As New StringBuilder("")
                sErr.AppendLine("保存成品重量录入失败,原因:重量为")
                For i As Integer = 0 To ID.Length - 1
                    If ID(i) <> "" Then
                        Dim Row() As DataRow = Dt.Select("Line=" & ID(i))
                        If Row.Length > 0 Then
                            sErr.Append(Row(0)("ZL"))
                            sErr.Append(",")
                            For j As Integer = 1 To Fg2.Rows.Count - 1
                                If Fg2.Item(j, "Line") = ID(i) Then
                                    Fg2.Rows.Remove(j)
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                Next
                sErr.AppendLine("已经被配布,系统自动删除这几条布!")
                ShowErrMsg(sErr.ToString)
                If TB_GH.Text <> "" Then Get_GH(TB_GH.Text)
            Else
                ShowErrMsg(R.Msg.Substring(1))
            End If
        End If
    End Sub


    ''' <summary>
    ''' 验证信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean

        CaculateSumAmount()
        If TB_GH.Tag = "" Then
            ShowErrMsg(Ch_Name & "缸号A不能为空!", AddressOf TB_GH.Focus)
            Return False
        End If
        If TB_GH_B.Tag = "" Then
            ShowErrMsg(Ch_Name & "缸号B不能为空!", AddressOf TB_GH_B.Focus)
            Return False
        End If
        If Fg2.Rows.Count <= 1 Then
            ShowErrMsg("成品列表不能为空!")
            Return False
        End If


        For i As Integer = 1 To Fg2.Rows.Count - 1
            If Fg2.Item(i, "PBA") = 0 OrElse Fg2.Item(i, "PBB") = 0 Then
                ShowErrMsg("交换的胚布不是一一对应!")
                Return False
            End If
        Next

        Me.Refresh()
        Return True
    End Function

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 减行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RemoveRow.Click
        Dim i As Integer = Fg2.RowSel
        If i > 0 AndAlso Fg2.Rows.Count > 1 Then

            If Fg2.Item(i, "PBA") <> 0 Then
                Fg1.AddRow()
                Dim j As Integer = Fg1.Rows.Count - 1
                Fg1.Item(j, "ID") = Fg2.Item(i, "IDA")
                Fg1.Item(j, "PB") = Fg2.Item(i, "PBA")
                Fg1.Item(j, "Line") = Fg2.Item(i, "LineA")
            End If
            If Fg2.Item(i, "PBB") <> 0 Then
                Fg3.AddRow()
                Dim j As Integer = Fg3.Rows.Count - 1
                Fg3.Item(j, "ID") = Fg2.Item(i, "IDB")
                Fg3.Item(j, "PB") = Fg2.Item(i, "PBB")
                Fg3.Item(j, "Line") = Fg2.Item(i, "LineB")

            End If

            Fg2.RemoveRow()
            CaculateSumAmount()

        End If

    End Sub
#End Region





#Region "报表事件"

    '    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If Fg3.RowSel > 0 Then
    '            Print_CP_GH = Fg3.Item(Fg3.RowSel, "CP_GH")
    '        Else
    '            Exit Sub
    '        End If
    '        Print(OperatorType.Preview)
    '    End Sub

    '    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If Fg3.RowSel > 0 Then
    '            Print_CP_GH = Fg3.Item(Fg3.RowSel, "CP_GH")
    '        Else
    '            Exit Sub
    '        End If
    '        Print(OperatorType.Print)
    '    End Sub



    '    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '        If CP_GH = "" Then
    '            Print_CP_GH = Fg2.Item(Fg2.RowSel, "CP_GH")
    '        Else
    '            Print_CP_GH = CP_GH
    '        End If
    '        Print(OperatorType.Preview)
    '    End Sub

    '    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If CP_GH = "" Then
    '            Print_CP_GH = Fg2.Item(Fg2.RowSel, "CP_GH")
    '        Else
    '            Print_CP_GH = CP_GH
    '        End If
    '        Print(OperatorType.Print)
    '    End Sub

    '    Dim Print_CP_GH As String = ""
    '    Protected Sub Print(ByVal DoOperator As OperatorType)
    '        If Me.Mode = Mode_Enum.Add Then
    '            Exit Sub
    '        End If
    '        If TB_GH.Tag = "" Then
    '            Exit Sub
    '        End If
    '        Dim R As New R30200_CPZL
    '        R.Start(TB_GH.Tag, Print_CP_GH, DoOperator)
    '    End Sub
    '    Private Sub Cmd_PreViewTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If CP_GH = "" Then
    '            Print_CP_GH = Fg2.Item(Fg2.RowSel, "CP_GH")
    '        Else
    '            Print_CP_GH = CP_GH
    '        End If
    '        PrintTM(OperatorType.Preview)
    '    End Sub
    '    Protected Sub PrintTM(ByVal DoOperator As OperatorType)
    '        If Me.Mode = Mode_Enum.Add Then
    '            Exit Sub
    '        End If
    '        If TB_GH.Tag = "" Then
    '            Exit Sub
    '        End If
    '        Dim R As New R10010_GoodsBarcode
    '        R.Start(TB_GH.Tag, Print_CP_GH, DoOperator)
    '    End Sub
#End Region




#Region "选缸号"


    Private Sub TB_GH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH.KeyPress
        If TB_GH.ReadOnly = False AndAlso e.KeyChar = vbCr Then
            Get_GH(TB_GH.Text)
        End If
    End Sub

    Private Sub TB_GH_B_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GH_B.KeyPress
        If TB_GH_B.ReadOnly = False AndAlso e.KeyChar = vbCr Then
            Get_GH_B(TB_GH_B.Text)
        End If
    End Sub

    Sub Get_GH(ByVal ID As String)
        CP_GH = ""
        ID = ComFun.FixGH(ID)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(ID)
        If Mr.IsOk = False Then
            ShowErrMsg(Mr.Msg)
            Exit Sub
        End If
        ID = Mr.Msg
        Dim R As DtReturnMsg = Dao.CPZL_GetGH_ByID(ID)
        If R.IsOk = False Then
            ShowErrMsg("查询缸号失败!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            ShowErrMsg("缸号[" & ID & "不存在]!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)

        If IsNull(Dr("IsTP"), False) Then
            ShowErrMsg("缸号[" & ID & "]是退胚缸不能操作!", AddressOf TB_GH.Focus)
            Exit Sub
        End If


        If IsNull(Dr("State"), 0) > Enum_ProduceState.PeiBu AndAlso IsNull(Dr("State"), 0) < Enum_ProduceState.SongHuo Then

        Else
            ShowErrMsg("缸号[" & ID & "]当前状态不能交换胚布重量!", AddressOf TB_GH.Focus)
            Exit Sub
        End If



        '赋值

        TB_Client_Name.Text = IsNull(Dr("Client_Name"), "")
        TB_CR_LuoSeBzCount.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)

        TB_GH.Text = IsNull(Dr("GH"), "")
        TB_BZ_No.Text = IsNull(Dr("BZ_No"), "")
        TB_BZ_No.Tag = IsNull(Dr("BZ_Id"), 0)
        TB_BZ_Name.Text = IsNull(Dr("BZ_Name"), "")
        TB_ProcessType.Text = IsNull(Dr("ProcessType"), "")
        TB_PWeight.Text = IsNull(Dr("PB_ZLSum"), 0)
        BZC_No.Text = IsNull(Dr("BZC_No"), "")
        BZC_Name.Text = IsNull(Dr("BZC_Name"), "")
        DTP_Date_KaiDan.Value = IsNull(Dr("Date_KaiDan"), "1999-1-1")
        LB_State.Text = ComFun.GetProduceStateName(IsNull(Dr("State"), 0))
        Dim RDt As DtReturnMsg = Dao.PBRK_GetListByGH(TB_GH.Text)
        If RDt.IsOk Then
            dtList = RDt.Dt
            Fg1.DtToSetFG(RDt.Dt)
        End If
        TB_GH_B.ReadOnly = False
        TB_GH.Tag = TB_GH.Text
    End Sub

    Sub Get_GH_B(ByVal ID As String)
        CP_GH = ""
        ID = ComFun.FixGH(ID)
        Dim Mr As MsgReturn = ComFun.GetGHForTM(ID)
        If Mr.IsOk = False Then
            ShowErrMsg(Mr.Msg)
            Exit Sub
        End If
        ID = Mr.Msg
        Dim R As DtReturnMsg = Dao.CPZL_GetGH_ByID(ID)
        If R.IsOk = False Then
            ShowErrMsg("查询缸号失败!", AddressOf TB_GH.Focus)
            Exit Sub
        End If
        If R.Dt.Rows.Count = 0 Then
            ShowErrMsg("缸号[" & ID & "不存在]!", AddressOf TB_GH_B.Focus)
            Exit Sub
        End If
        Dim Dr As DataRow = R.Dt.Rows(0)
        If IsNull(Dr("State"), 0) > Enum_ProduceState.PeiBu AndAlso IsNull(Dr("State"), 0) < Enum_ProduceState.SongHuo Then

        Else
            ShowErrMsg("缸号[" & ID & "]当前状态不能交换胚布重量!", AddressOf TB_GH.Focus)
            Exit Sub
        End If

        '检查布种编号是否一致
        If IsNull(Dr("BZ_No"), "") <> TB_BZ_No.Text Then
            ShowErrMsg("缸号[" & ID & "]胚布的布种编号和缸号A[" & TB_GH.Tag & "]的布种编号不一致,不能交换胚布重量!")
            Exit Sub
        End If

        '赋值

        TB_Client_Name_B.Text = IsNull(Dr("Client_Name"), "")
        TB_CR_LuoSeBzCount_B.Text = IsNull(Dr("CR_LuoSeBzCount"), 0)
        TB_GH_B.Text = IsNull(Dr("GH"), "")
        TB_ProcessType_B.Text = IsNull(Dr("ProcessType"), "")
        TB_PWeight_B.Text = IsNull(Dr("PB_ZLSum"), 0)
        BZC_No_B.Text = IsNull(Dr("BZC_No"), "")
        BZC_Name_B.Text = IsNull(Dr("BZC_Name"), "")
        DTP_Date_KaiDan_B.Value = IsNull(Dr("Date_KaiDan"), "1999-1-1")
        Dim RDt As DtReturnMsg = Dao.PBRK_GetListByGH(TB_GH_B.Text)
        If RDt.IsOk Then
            dtListB = RDt.Dt
            Fg3.DtToSetFG(RDt.Dt)
        End If
        TB_GH.ReadOnly = True
        TB_GH_B.Tag = TB_GH_B.Text
        CaculateSumAmount()
    End Sub
#End Region






#Region "FG交换重量"

    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        FGInputFG2(Fg1, "A", "B")
    End Sub

    Private Sub Fg3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg3.DoubleClick
        FGInputFG2(Fg3, "B", "A")
    End Sub


    ''' <summary>
    ''' '从左边的FG剪切到FG2
    ''' </summary>
    ''' <param name="FG"></param>
    ''' <param name="aString"></param>
    ''' <param name="bString"></param>
    ''' <remarks></remarks>
    Sub FGInputFG2(ByVal FG As PClass.FG, ByVal aString As String, ByVal bString As String)
        If Fg1.RowSel < 1 Then
            ShowErrMsg("请选择一行!")
            Exit Sub
        End If
        Dim aId As String = FG.Item(FG.RowSel, "ID")
        Dim aLine As Integer = FG.Item(FG.RowSel, "Line")
        Dim aPb As Double = FG.Item(FG.RowSel, "PB")
        '同ID但是没有总量
        PBFindFG(aString, bString, aId, aLine, aPb)
        FG.RemoveRow()
        FG.ReAddIndex()
        Fg2.ReAddIndex()
        CaculateSumAmount()
    End Sub



    Private Sub PBFindFG(ByVal aString As String, ByVal bString As String, ByVal aId As String, ByVal aLine As Integer, ByVal aPb As Double)
        Dim i As Integer
        For i = 1 To Fg2.Rows.Count - 1 '
            If Fg2.Item(i, "ID" & bString) = aId AndAlso Fg2.Item(i, "PB" & aString) = 0 Then
                Exit For
            End If
        Next
        If i > Fg2.Rows.Count - 1 Then '没有找到
            For i = 1 To Fg2.Rows.Count - 1 '同ID但是有重量
                If Fg2.Item(i, "ID" & aString) <> Fg2.Item(i, "ID" & bString) AndAlso Fg2.Item(i, "ID" & bString) = aId Then
                    Exit For
                End If
            Next
            If i > Fg2.Rows.Count - 1 Then '没有找到
                For i = 1 To Fg2.Rows.Count - 1 '查找空行
                    If Fg2.Item(i, "PB" & aString) = 0 Then
                        Exit For
                    End If
                Next
                If i > Fg2.Rows.Count - 1 Then '没有找到
                    Fg2.AddRow()
                    Dim j As Integer = Fg2.Rows.Count - 1
                    Fg2.Item(j, "ID" & aString) = aId
                    Fg2.Item(j, "Line" & aString) = aLine
                    Fg2.Item(j, "PB" & aString) = aPb

                    Fg2.Item(j, "ID" & bString) = ""
                    Fg2.Item(j, "Line" & bString) = 0
                    Fg2.Item(j, "PB" & bString) = 0
                Else
                    Fg2.Item(i, "ID" & aString) = aId
                    Fg2.Item(i, "Line" & aString) = aLine
                    Fg2.Item(i, "PB" & aString) = aPb
                End If
            Else
                Dim aId2 As String = Fg2.Item(i, "ID" & aString)
                Dim aLine2 As Integer = Fg2.Item(i, "Line" & aString)
                Dim aPb2 As Double = Fg2.Item(i, "PB" & aString)

                Fg2.Item(i, "ID" & aString) = aId
                Fg2.Item(i, "Line" & aString) = aLine
                Fg2.Item(i, "PB" & aString) = aPb

                PBFindFG(aString, bString, aId2, aLine2, aPb2)
            End If
        Else '找到匹配的
            Fg2.Item(i, "ID" & aString) = aId
            Fg2.Item(i, "Line" & aString) = aLine
            Fg2.Item(i, "PB" & aString) = aPb

        End If

    End Sub



#End Region




    Private Sub Label_ID_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_ID.DoubleClick
        If TB_GH.Text = "" Then
            Exit Sub
        End If
        Dim F As New F30001_Produce_Gd_Msg(TB_GH.Text)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = TB_GH.Text
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        VF.Show()
    End Sub


    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        Btn_RemoveRow_Click(Fg2, New EventArgs)
    End Sub
End Class


Partial Class Dao
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ghA"></param>
    ''' <param name="ghB"></param>
    ''' <param name="dtList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TZPB_Save(ByVal ghA As String, ByVal ghB As String, ByVal dtList As DataTable) As MsgReturn
        Dim R As New MsgReturn
        Dim sql As New Dictionary(Of String, String)
        Dim p As New Dictionary(Of String, Object)
        sql.Add("A", "select ID,Line,GH,CP_GH,CP_Line from T40101_PBRK_List where GH=@GHA")
        sql.Add("B", "select ID,Line,GH,CP_GH,CP_Line from T40101_PBRK_List where GH=@GHB")
        p.Add("GHA", ghA)
        p.Add("GHB", ghB)
        Using H As New DtHelper(sql, p)
            If H.IsOk = True Then
                For Each Dr As DataRow In dtList.Rows
                    Dim RowsA() As DataRow = H.DtList("A").Select("GH='" & ghA & "' and Line=" & Dr("LineA"))
                    If RowsA.Length <= 0 Then
                        R.Msg = "配布调整失败!没有找到[" & ghA & "]"
                        Return R
                    End If
                    Dim RowsB() As DataRow = H.DtList("B").Select("GH='" & ghB & "' and Line=" & Dr("LineB"))
                    If RowsB.Length <= 0 Then
                        R.Msg = "配布调整失败!没有找到[" & ghB & "]"
                        Return R
                    End If

                    Dim CP_GH As String = IsNull(RowsB(0)("CP_GH"), "")
                    Dim CP_Line As Integer = IsNull(RowsB(0)("CP_Line"), 0)
                    RowsB(0)("CP_GH") = RowsA(0)("CP_GH")
                    RowsB(0)("CP_Line") = RowsA(0)("CP_Line")
                    RowsB(0)("GH") = ghA

                    RowsA(0)("CP_GH") = CP_GH
                    RowsA(0)("CP_Line") = IIf(CP_Line = 0, DBNull.Value, CP_Line)
                    RowsA(0)("GH") = ghB
                Next
            Else
                R.Msg = "配布调整失败!" & H.Msg
                Return R
            End If
            Dim SQLA As New Dictionary(Of String, String)
            SQLA.Add("", "update T30000_Produce_Gd set PB_ZLSum=(select sum(PB) from T40101_PBRK_List where GH=@GHA) where GH=@GHA" & vbCrLf & "update T30000_Produce_Gd set PB_ZLSum=(select sum(PB) from T40101_PBRK_List where GH=@GHB) where GH=@GHB")
            Return H.UpdateAll(True, SQLA, p)
        End Using
    End Function
End Class