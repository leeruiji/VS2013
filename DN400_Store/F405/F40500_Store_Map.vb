Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F40500_Store_Map


    Dim dtWL As DataTable
    Dim dtList As DataTable
    Dim SelType As cStore_Area.Enum_SelType
    Dim selectedCellList As New List(Of String)
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal _SelType As cStore_Area.Enum_SelType, ByVal _selectedCellList As List(Of String))

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        Me.SelType = _SelType
        Me.selectedCellList = _selectedCellList
        Me.Mode = Mode
        Me.Title = "仓位选择"
    End Sub



    Private Sub F10201_Quality_Msg_Form_KeyDown(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs) Handles Me.Form_KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                SendKeys.SendWait("{TAB}")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Sub FormCheckRight()

    End Sub

    Private Sub F40500_Store_Map_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name
        For C As Integer = 65 To 90
            CheckedListBox1.Items.Add(Chr(C))
        Next
        Fg_CheckedCell.Rows.Count = 1
        LabelNormal.ForeColor = Cs.Color_Normal
        LabelSel.ForeColor = Cs.Color_Sel
        LabelEmpty.ForeColor = Cs.Color_Empty
        LabelCell.ForeColor = Cs.Color_Cell
        LabelCellA.ForeColor = Cs.Color_CellA
        LabelPost.ForeColor = Cs.Color_Post
        LabelDisable.ForeColor = Cs.Color_Disable
        LabelPassage.ForeColor = Cs.Color_Passage

        CB_Floor.DataSource = cStore_Area.Get_Area_Dt
        CB_Sel.SelectedIndex = 0
        CB_Floor.DisplayMember = "FloorName"
        CB_Floor.ValueMember = "Floor"
        If IsSel Then
            TabControl2.SelectedIndex = 1
        End If
        '初始化已选择的仓位
        Dim i As Integer = 1
        For Each _sNo As String In Me.selectedCellList
            If _sNo <> "" Then
                Fg_CheckedCell.AddRow()
                Fg_CheckedCell.Item(i, "sNo") = _sNo
                Cs.Select_List.Add(_sNo)
                i = i + 1
            End If
        Next
        If Cs.Select_List.Count > 0 Then Cs.ShowSelList()
        Timer1.Start()
        If IsSel Then
            Cmd_Choose.Text = "选择"
        Else
            Cmd_Choose.Text = "关闭"
        End If
    End Sub


#Region "表单信息"
    ''' <summary>
    ''' 获取表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        Dim dt As DataTable
        dt = dtWL.Clone
        If Not dt Is Nothing Then
            dt.Clear()
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)

            'dt.Rows(0)("Remark_ID") = TB_ID.Text

            'dt.Rows(0)("Remark") = TB_Remark.Text
            'dt.Rows(0)("Remark2") = TB_Remark2.Text
            'dt.Rows(0)("Remark_Type") = RemarkType

        End If
        Return dt
    End Function

    ''' <summary>
    ''' 设置表单内容
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm(ByVal dt As DataTable)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            'TB_ID.Text = IsNull(dt.Rows(0)("Remark_ID"), "")

            'TB_Remark.Text = IsNull(dt.Rows(0)("Remark"), "")
            'TB_Remark2.Text = IsNull(dt.Rows(0)("Remark2"), "")
        End If
    End Sub




#End Region

#Region "工具栏,按钮"


    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' If CheckForm() Then ShowConfirm("是否保存备注[" & TB_ID.Text & "] 的修改?", AddressOf Save)
    End Sub


    Protected Function CheckForm() As Boolean
        'If TB_ID.Text = "" Then
        '    ShowErrMsg("备注编号不能为空")
        '    TB_ID.Focus()
        '    Return False
        'End If


        Return True
    End Function




    Private Sub Cmd_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  ShowConfirm("是否删除备注[" & TB_ID.Text & "]?", AddressOf DelWL)
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cs.Save()
    End Sub


#End Region


#Region "控件事件"
    Dim Cs As New cStore_Area



   
    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged

        If TabControl2.SelectedIndex = 0 Then
            FG2ReFresh()
        End If

    End Sub
    Sub FG2ReFresh()
        Dim R As DtReturnMsg = Dao.Store_GetStoreHZ(TB_No.Text)
        If R.IsOk Then
            Fg2.DtToFG(R.Dt)
            Fg2.AutoSizeCols(1, Fg2.Cols.Count - 1, 10)
        End If
    End Sub




    Private Sub Cmd_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LabelXY.Text = "" Then Exit Sub
        Dim S() As String = LabelXY.Text.Split(",")
        Dim dr As DataRow = Cs.GetCellRow(S(0), S(1))
        dr("State") = CB_State.SelectedIndex
        dr("Qty") = TB_Qty.Text
        dr("MaxQty") = TB_MaxQty.Text
        dr("sNo") = TB_No.Text
        Cs.DG_ReFresh(DG)
    End Sub


    Private Sub LabelEmpty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    LabelNormal.Click, LabelSel.Click, LabelEmpty.Click, LabelCell.Click, LabelCellA.Click, LabelPost.Click, LabelDisable.Click, LabelPassage.Click
        Dim L As Label = TryCast(sender, Label)
        Using C As New ColorDialog
            C.Color = L.ForeColor
            If C.ShowDialog = Windows.Forms.DialogResult.OK Then
                L.ForeColor = C.Color
                Select Case L.Name
                    Case LabelNormal.Name
                        Cs.Color_Normal = L.ForeColor
                    Case LabelSel.Name
                        Cs.Color_Sel = L.ForeColor
                    Case LabelEmpty.Name
                        Cs.Color_Empty = L.ForeColor
                    Case LabelCell.Name
                        Cs.Color_Cell = L.ForeColor
                    Case LabelCellA.Name
                        Cs.Color_CellA = L.ForeColor
                    Case LabelPost.Name
                        Cs.Color_Post = L.ForeColor
                    Case LabelDisable.Name
                        Cs.Color_Disable = L.ForeColor
                    Case LabelPassage.Name
                        Cs.Color_Passage = L.ForeColor
                End Select
                Cs.DG_ReFresh(DG)
            End If
        End Using
    End Sub
#End Region
#Region "选择仓位"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DG_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellDoubleClick
        Dim dr As DataRow = Cs.GetCellRow(e.ColumnIndex, e.RowIndex)
        If dr("State") = cStore_Area.Enum_State.Normal Then
            AddStore(dr("sNo"))
        Else
            Exit Sub
        End If
    End Sub

    Sub AddStore(ByVal _sNo As String)
        For i = 1 To Fg_CheckedCell.Rows.Count - 1
            If Fg_CheckedCell.Item(i, "sNo") = _sNo Then
                Exit Sub
            End If
        Next
        Fg_CheckedCell.AddRow()
        Fg_CheckedCell.Item(Fg_CheckedCell.Rows.Count - 1, "sNo") = _sNo
        If IsSel Then
            TabControl2.SelectedIndex = 1
        End If
        Cs.Select_List.Add(_sNo)
        Cs.ShowSelList()
    End Sub



    ''' <summary>
    ''' 双击删除选择
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Fg_CheckedCell_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg_CheckedCell.DoubleClick
        If Fg_CheckedCell.RowSel >= Fg_CheckedCell.Rows.Fixed Then
            Cs.Select_List.Remove(Fg_CheckedCell.Item(Fg_CheckedCell.RowSel, "sNo"))
            Fg_CheckedCell.RemoveRow()
            Cs.ShowSelList()
        End If
    End Sub

    Private Sub Cmd_Choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Choose.Click
        Dim sNoList As New List(Of String)
        Dim _sNo As String = ""
        For i As Integer = 1 To Fg_CheckedCell.Rows.Count - 1
            _sNo = Fg_CheckedCell.Item(i, "sNo")
            If _sNo <> "" Then
                sNoList.Add(_sNo)
            End If
        Next
        Me.LastForm.ReturnObj = sNoList
        Me.Close()
    End Sub
#End Region


#Region "DG"
    Private Sub DG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        Dim dr As DataRow = Cs.GetCellRow(e.ColumnIndex, e.RowIndex)
        CB_State.SelectedIndex = dr("State")
        TB_Qty.Text = dr("Qty")
        TB_MaxQty.Text = dr("MaxQty")
        TB_No.Text = dr("sNo")
        LabelXY.Text = e.ColumnIndex & "," & e.RowIndex

        If TabControl2.SelectedIndex = 0 Then
            FG2ReFresh()
        End If
    End Sub


    Private Sub DG_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellMouseEnter
        If DG.Item(e.ColumnIndex, e.RowIndex).AccessibilityObject.Bounds.Right < DG.Width Then
            DG.Item(e.ColumnIndex, e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub DG_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellMouseLeave
        DG.Item(e.ColumnIndex, e.RowIndex).Selected = False
    End Sub



    Private Sub DG_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DG.RowPrePaint
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
    End Sub



#End Region

    Private Sub CB_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Floor.SelectedIndexChanged
        If CB_Floor.Text.Length <> 2 Then Exit Sub
        Cs.Floor = CB_Floor.SelectedIndex + 1
        Cs.GetFormDt()
        If Cs.Cell.Rows.Count = 0 Then

        Else
            Cs.DG_Show(DG)
        End If
        


    End Sub


    Private Sub CB_Client_SetEmpty() Handles CB_Client.SetEmpty
        TB_ClientName.Text = ""
        CB_Client.IDAsInt = 0
        CB_BZ.SetSearchEmpty()
    End Sub
    Private Sub Client_List1_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel
        TB_ClientName.Text = Col_Name
        If CB_BZ.SearchID <> ID Then
            CB_BZ.Text = ""
            CB_BZ.SetSearchEmpty()
            TB_BZ_Name.Text = ""
        End If
        CB_BZ.Enabled = True
        CB_BZ.SearchID = ID
        CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
    End Sub
    Private Sub CB_BZ_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ.Col_Sel
        TB_BZ_Name.Text = Col_Name
    End Sub
    Private Sub CB_BZ_SetEmpty() Handles CB_BZ.SetEmpty
        CB_BZ.IDAsInt = 0
        TB_BZ_Name.Text = ""
    End Sub




    Private Sub Cmd_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Find.Click
        Store_Find()
    End Sub
    Private Sub Store_Find()

        Dim isShhowASll As Boolean
        If CK_showKC.Checked = False Then
            isShhowASll = True
        Else
            isShhowASll = False
        End If

        If Val(CB_BZ.IDValue) <> 0 Then
            Dim R As DtReturnMsg = Dao.Store_Find(Val(CB_Client.IDValue), Val(CB_BZ.IDValue), isShhowASll)
            If R.IsOk Then
                Fg1.DtToFG(R.Dt)
                TabControl1.SelectedIndex = 1
            End If
        ElseIf Val(CB_Client.IDValue) <> 0 Then
            Dim R As DtReturnMsg = Dao.Store_Find(Val(CB_Client.IDValue), isShhowASll)
            If R.IsOk Then
                Fg1.DtToFG(R.Dt)
                TabControl1.SelectedIndex = 1
            End If
        Else
            Dim R As DtReturnMsg = Dao.Store_Find(isShhowASll)
            If R.IsOk Then
                Fg1.DtToFG(R.Dt)
                TabControl1.SelectedIndex = 1
            End If
        End If

    End Sub


    Private Sub Cmd_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Refresh.Click
        CB_Floor_SelectedIndexChanged(CB_Floor, New System.EventArgs)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me_Refresh()
    End Sub


    Private Sub Fg1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.DoubleClick
        If Fg1.RowSel > 0 Then
            If Fg1.ColSel = Fg1.Cols("ID").Index Then
                Dim F As New F40101_PBRK_Msg(Fg1.Item(Fg1.RowSel, "ID"))
                With F
                    .Mode = Mode_Enum.Modify
                    .P_F_RS_ID = ""
                    .P_F_RS_ID2 = ""
                End With
                F_RS_ID = ""
                Me.ReturnId = ""
                Me.ReturnObj = Nothing
                Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
                AddHandler VF.ClosedX, AddressOf Me_Refresh
                VF.Show()
            Else
                AddStore(Fg1.Item(Fg1.RowSel, "StoreNo"))
                TabControl2.SelectedIndex = 1
            End If
        End If
    End Sub


    Private Sub Fg2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        If Fg2.RowSel < 0 Then
            Exit Sub
        End If
        Dim F As New F40101_PBRK_Msg(Fg2.Item(Fg2.RowSel, "ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()
    End Sub

    Sub Me_Refresh()
        If Cs.GetDifference Then
            If Cs.Cell.Rows.Count = 0 Then
            Else
                Cs.DG_Show(DG)
            End If

        End If
    End Sub

    Private Sub Cmd_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Report.Click
        Dim dtlist As New DataTable
        Dim isShhowASll As Boolean
        If CK_showKC.Checked = False Then
            isShhowASll = True
        Else
            isShhowASll = False
        End If

        If Val(CB_BZ.IDValue) <> 0 Then
            Dim R As DtReturnMsg = Dao.Store_Find(Val(CB_Client.IDValue), Val(CB_BZ.IDValue), isShhowASll)
            If R.IsOk Then
                dtlist = R.Dt
                TabControl1.SelectedIndex = 1
            End If
        ElseIf Val(CB_Client.IDValue) <> 0 Then
            Dim R As DtReturnMsg = Dao.Store_Find(Val(CB_Client.IDValue), isShhowASll)
            If R.IsOk Then
                dtlist = R.Dt
                TabControl1.SelectedIndex = 1
            End If
        Else
            Dim R As DtReturnMsg = Dao.Store_Find(isShhowASll)
            If R.IsOk Then
                dtlist = R.Dt
                TabControl1.SelectedIndex = 1
            End If
        End If

        Dim Re As New R40500_Store_Map
        Re.Start(PClass.CReport.OperatorType.Preview, dtlist)

    End Sub






    Private Sub TB_GHSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_GHSearch.KeyPress
        If e.KeyChar = vbCr Then
            Dim R As MsgReturn = ComFun.GetGHForTM(TB_GHSearch.Text)
            Dim dt As DtReturnMsg
            If R.IsOk Then
                dt = Dao.BZ_GetByGH(R.Msg)
                CB_Client.IDAsInt = Val(dt.Dt.Rows(0)("Client_ID"))
                CB_Client.Text = CB_Client.GetByTextBoxTag
                CB_BZ.IDAsInt = Val(dt.Dt.Rows(0)("BZ_ID"))
                CB_BZ.Text = CB_BZ.GetByTextBoxTag
                Store_Find()
            Else
                ShowErrMsg(R.Msg)
            End If
        End If
    End Sub




#Region "标签打印"

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim cStart As Integer = Val(TextBox1.Text)
        Dim cEnd As Integer = Val(TextBox2.Text)
        For Each s As String In CheckedListBox1.CheckedItems
            For j As Integer = cStart To cEnd
                If RadioButton1.Checked Then
                    ListBox1.Items.Add(s & CB_Floor.SelectedValue & j.ToString("00") & ";左")
                ElseIf RadioButton2.Checked Then

                    ListBox1.Items.Add(s & CB_Floor.SelectedValue & j.ToString("00") & ";右")
                ElseIf RadioButton3.Checked Then
                    If j Mod 2 = 1 Then
                        ListBox1.Items.Add(s & CB_Floor.SelectedValue & j.ToString("00") & ";左")
                    Else
                        ListBox1.Items.Add(s & CB_Floor.SelectedValue & j.ToString("00") & ";右")
                    End If
                ElseIf RadioButton4.Checked Then
                    If j Mod 2 = 0 Then
                        ListBox1.Items.Add(s & CB_Floor.SelectedValue & j.ToString("00") & ";左")
                    Else
                        ListBox1.Items.Add(s & CB_Floor.SelectedValue & j.ToString("00") & ";右")
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        sPrint(PClass.CReport.OperatorType.Print)
    End Sub

    Private Sub CmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPreview.Click
        sPrint(PClass.CReport.OperatorType.Preview)
    End Sub

    Sub sPrint(ByVal DoOperator As PClass.CReport.OperatorType)
        Dim LDt As New DataTable("L")
        LDt.Columns.Add("T")
        Dim RDt As New DataTable("L")
        RDt.Columns.Add("T")
        Dim SP() As String
        Dim Dr As DataRow
        For Each s As String In ListBox1.Items
            SP = s.Split(";")
            If SP(1) = "左" Then
                Dr = LDt.NewRow
                Dr("T") = SP(0)
                LDt.Rows.Add(Dr)
            Else
                Dr = RDt.NewRow
                Dr("T") = SP(0)
                RDt.Rows.Add(Dr)
            End If
        Next

        If LDt.Rows.Count > 0 Then
            Dim L As New R40501_StoreNo_Left
            L.Start(LDt, DoOperator)
        End If
        If RDt.Rows.Count > 0 Then
            Dim R As New R40502_StoreNo_Right
            R.Start(RDt, DoOperator)
        End If
    End Sub
#End Region


  
End Class


Partial Class Dao
    Public Const SQL_Store_GetStoreHZ = "select C.Client_Name,b.BZ_Name,P.BZ_ID,b.BZ_No,Qty,Sum(ZL)ZL,Color,IsFG,l.ShaPi,s.ID as ID from T40520_PB_StoreNo s left join T40100_PBRK_Table P  on p.ID=S.ID left join T40101_PBRK_List L  on L.ID=p.ID left join T10110_Client C On C.ID=Client_ID left join T10002_BZ B On B.ID=p.BZ_ID where s.StoreNo=@StoreNo group by C.Client_Name,B.BZ_Name,P.BZ_ID,B.BZ_No,Qty,Color,l.ShaPi,s.ID,IsFG"



    Public Const SQL_Store_Find_Select As String = " select Gh, Client_Name,BZ_Name,BZC_Name,t.Qty,ShaPi,IsFG,ZL,BZ_No,T. ID ,m. SNo  as StoreNO" & vbCrLf & _
   " from T40500_Store_Map M left join (" & vbCrLf & _
   "  select '' as GH, Client_Name,BZ_Name,'' as BZC_Name, S.Qty,ShaPi,IsFG," & vbCrLf & _
   " 0 as ZL,BZ_No,s.StoreNo,s.ID as ID from T40520_PB_StoreNo s," & vbCrLf & _
   " T40100_PBRK_Table R , " & vbCrLf & _
   " T10110_Client C , " & vbCrLf & _
   "  T10002_BZ B  " & vbCrLf & _
     "where R.ID=s.ID  and  C.ID=R.Client_ID and B.ID=BZ_ID  "
    '"group by ZhiChang_ID,ShaPi,Client_Name,BZ_No,BZ_Name,s.StoreNo,s.ID,IsFG  ) t " & vbCrLf & _
    '"ON T.StoreNo=m.sno  Where M.SNo<>''  order by StoreNo " & vbCrLf
                  
    Public Const SQL_Store_Find_Select_CP As String = "union all" & vbCrLf & _
   " select R.GH,  Client_Name,BZ_Name,BZC_Name, P.Qty , ShaPi,IsFG," & vbCrLf & _
   " 0 as ZL,BZ_No,P .StoreNo,'' as ID from T30002_CPRK P," & vbCrLf & _
   " T30000_Produce_Gd R  ," & vbCrLf & _
   " T10110_Client C, " & vbCrLf & _
   " T10002_BZ B  ,T10003_BZC BZC " & vbCrLf & _
   "where R.State<90 and R.GH=P.GH  and  C.ID=R.Client_ID and B.ID=R.BZ_ID and R.BZC_ID=BZC.ID "


    Public Const SQL_Store_Find_WhereClient = "and R.Client_Id=@Client_Id" & vbCrLf

    Public Const SQL_Store_Find_WhereClientBZ = "and R.Client_Id=@Client_Id and BZ_ID=@BZ_ID" & vbCrLf


    Public Const SQL_Store_Find_Order As String = " ) t ON T.StoreNo=m.sno  Where M.SNo<>'' "

    Public Const SQL_Store_Find_ShowY = " and  isnull(T.qty,0)>0 "

    'Public Const SQL_Store_orderby = " order by T.StoreNo "
    Public Const SQL_Store_orderby = "order by TFloor,Y,X,Floor"

    Public Shared Function Store_GetStoreHZ(ByVal StoreNo As String) As DtReturnMsg
        Return SqlStrToDt(SQL_Store_GetStoreHZ, "StoreNo", StoreNo)
    End Function

    Public Shared Function Store_Find(ByVal isShhowASll As Boolean) As DtReturnMsg
        Dim SqlString As String = SQL_Store_Find_Select & SQL_Store_Find_Select_CP & SQL_Store_Find_Order
        If isShhowASll = False Then
            SqlString = SqlString & SQL_Store_Find_ShowY & SQL_Store_orderby
        Else
            SqlString = SqlString & SQL_Store_orderby
        End If

        Return SqlStrToDt(SqlString)
    End Function


    Public Shared Function Store_Find(ByVal Client_Id As Integer, ByVal isShhowASll As Boolean) As DtReturnMsg
        Dim SqlString As String = SQL_Store_Find_Select & SQL_Store_Find_WhereClient & SQL_Store_Find_Select_CP & SQL_Store_Find_WhereClient & SQL_Store_Find_Order
        If isShhowASll = False Then
            SqlString = SqlString & SQL_Store_Find_ShowY & SQL_Store_orderby
        Else
            SqlString = SqlString & SQL_Store_orderby
        End If

        Return SqlStrToDt(SqlString, "Client_Id", Client_Id)
    End Function

    Public Shared Function Store_Find(ByVal Client_Id As Integer, ByVal BZ_ID As Integer, ByVal isShhowASll As Boolean) As DtReturnMsg
        Dim SqlString As String = SQL_Store_Find_Select & SQL_Store_Find_WhereClientBZ & SQL_Store_Find_Select_CP & SQL_Store_Find_WhereClientBZ & SQL_Store_Find_Order

        If isShhowASll = False Then
            SqlString = SqlString & SQL_Store_Find_ShowY & SQL_Store_orderby
        Else
            SqlString = SqlString & SQL_Store_orderby
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("Client_Id", Client_Id)
        p.Add("BZ_ID", BZ_ID)
        Return SqlStrToDt(SqlString, p)
    End Function
End Class