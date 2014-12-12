Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport
<System.ComponentModel.ToolboxItem(False)> _
Public Class PeiBuList
    Dim LastForm As PClass.BaseForm
    Dim ReturnId As String
    Dim ReturnObj As Object
    Public IsLoaded As Boolean = False
    Public IsEdited As Boolean = False
    Dim DtGh As DataTable
    Dim DtPB As DataTable

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal _lastForm As PClass.BaseForm)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.LastForm = _lastForm
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub


    Public Sub New(ByVal _gh As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal _dtGh As DataTable, ByVal _lastForm As PClass.BaseForm)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.LastForm = _lastForm
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    ''' <summary>
    ''' 初始化表单数据
    ''' </summary>
    ''' <param name="_lastForm"></param>
    ''' <remarks></remarks>
    Public Sub iniForm(ByVal _dtGh As DataTable, ByVal _lastForm As PClass.BaseForm)
        Me.LastForm = _lastForm
        Me.DtGh = _dtGh
    End Sub

    Private Sub PeiBuList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Fg1.IniFormat()
        Timer1.Start()
    End Sub

    ''' <summary>
    ''' 加载配布信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadData(ByVal sumZl As Double, ByVal sumQty As Integer)
        TB_YPZL.Text = sumZl
        TB_YPQty.Text = sumQty
        If Me.DtGh IsNot Nothing Then
            Dim msg As DtReturnMsg = Dao.Produce_GetPBListAll(DtGh.Rows(0)("GH"))
            If msg IsNot Nothing AndAlso msg.IsOk = True Then
                Me.DtPB = msg.Dt
                SetForm()
            End If
        End If
        IsLoaded = True
    End Sub





#Region "表单信息"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SetForm()
        If IsLoaded = False Then
            TB_PB_User.Text = IsNull(DtGh.Rows(0)("PB_User"), "")
            TB_PB_Notice.Text = IsNull(DtGh.Rows(0)("PB_Notice"), "")
        End If
        If IsNull(DtGh.Rows(0)("State"), 0) > Enum_ProduceState.PeiBu Then
            LockForm(True)
        Else
            LockForm(False)
        End If
        Fg1.DtToFG(DtPB)
        If DtPB.Select("old_PB>0").Length > 0 Then
            Fg1.Cols("Old_PB").Visible = True
        Else
            Fg1.Cols("Old_PB").Visible = False
        End If
        Fg1.IniColsSize()
        Fg1.FG_ColResize()


        '    CaculateForm()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetForm() As DataTable
        DtGh.Rows(0)("PB_User") = TB_PB_User.Text
        DtGh.Rows(0)("PB_Notice") = TB_PB_Notice.Text
        DtGh.Rows(0)("PB_CountSum") = Val(TB_YPQty.Text)
        DtGh.Rows(0)("PB_ZLSum") = Val(TB_YPZL.Text)
        If DtGh.Rows(0)("State") = Enum_ProduceState.XiaDan Then
            DtGh.Rows(0)("State") = Enum_ProduceState.PeiBu
        End If
        'Dim dt As DataTable = DtPB.Clone
        'Dim dr As DataRow
        'For i As Integer = 1 To Fg1.Rows.Count - 1
        '    dr = dt.NewRow
        '    dr("StoreNo") = Fg1.Item(i, "StoreNo")
        '    dr("ID") = Fg1.Item(i, "ID")
        '    dr("Line") = Fg1.Item(i, "Line")
        '    dr("Client_ID") = DtGh.Rows(0)("Client_ID")
        '    dr("BZ_ID") = Fg1.Item(i, "BZ_ID")
        '    dr("ZhiChang_ID") = Fg1.Item(i, "ZhiChang_ID")
        '    dr("ZL") = Fg1.Item(i, "ZL")
        '    dr("RK_Date") = Fg1.Item(i, "RK_Date")
        '    dr("ShaPi") = Fg1.Item(i, "ShaPi")
        '    dr("Machine") = Fg1.Item(i, "Machine")
        '    dr("Color") = Fg1.Item(i, "Color")
        '    dr("GH") = DtGh.Rows(0)("GH")
        '    dt.Rows.Add(dr)
        'Next
        Return DtGh
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function CheckForm() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' 计算配布条数和重量
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CaculateForm()
        Dim qty As Integer = 0
        Dim zl As Double = 0
        For i As Integer = 1 To Fg1.Rows.Count - 1
            qty = qty + 1
            zl = zl + Val(Fg1.Item(i, "ZL"))
        Next
        TB_YPQty.Text = qty
        TB_YPZL.Text = zl
    End Sub

    Protected Sub LockForm(ByVal lock As Boolean)
        TB_PB_User.ReadOnly = lock
        TB_PB_Notice.ReadOnly = lock
        Cmd_GoodsSel.Enabled = Not lock
        Cmd_RemoveRow.Enabled = Not lock
    End Sub

#End Region

#Region "表头修改"
    Private Sub TB_PB_User_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_PB_User.TextChanged, TB_PB_Notice.TextChanged, TB_YPQty.TextChanged, TB_YPZL.TextChanged
        If IsLoaded Then
            IsEdited = True
        End If

    End Sub

#End Region


#Region "查看仓位，配布"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_GoodsSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GoodsSel.Click

        PeiBu()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PeiBu()
        Me.LastForm.ShowErrMsg("此功能暂时未开放，如有问题请联系系统管理员。")
        Exit Sub
        If Me.DtGh Is Nothing Then
            Exit Sub
        End If

        Dim F As PClass.BaseForm = PClass.PClass.LoadFormIDToChild(40502, Me.LastForm)
        With F
            .Mode = PClass.BaseForm.Mode_Enum.Add
            .P_F_RS_ID3 = DtGh.Rows(0)("GH")
            .P_F_RS_ID = DtGh.Rows(0)("Client_ID")
            .P_F_RS_ID2 = DtGh.Rows(0)("BZ_ID")
            .P_F_RS_ID4 = IsNull(DtGh.Rows(0)("ShaPi"), "")
            .P_F_RS_ID5 = 1
            .P_F_RS_Obj = DtPB
        End With

        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me.LastForm)
        VF.MaximizeBox = True

        AddHandler VF.ClosedX, AddressOf GetInfoFromStore

        VF.Show()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub GetInfoFromStore()
        Dim dt As DataTable = TryCast(Me.LastForm.ReturnObj, DataTable)

        If dt Is Nothing Then

            If LastForm.ReturnId = "0" Then
                Fg1.Rows.Count = 0
            Else
                Exit Sub
            End If


        Else
            DtPB = dt
            SetForm()
            IsEdited = True
        End If

    End Sub

#End Region

#Region "保存配布信息"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SavePB() As Boolean
        '  CaculateForm()
        If CheckForm() Then

            Dim dt As DataTable = GetForm()
            Dim msg As MsgReturn = Dao.PB_Update(DtGh.Rows(0)("GH"), DtGh.Rows(0)("State"), Val(TB_YPZL.Text), Val(TB_YPQty.Text), dt)
            If msg.IsOk Then
                IsEdited = False
                Return True
            Else
                LastForm.ShowErrMsg(msg.Msg)
                Return False
            End If

        End If
    End Function

#End Region

#Region "FG事件"
    ''' <summary>
    ''' 删除一行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_RemoveRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_RemoveRow.Click
        If Fg1.RowSel < 1 Then

            LastForm.ShowErrMsg("请选择您要删除的行！")
        Else
            Try
                Fg1.RemoveItem(Fg1.RowSel)
            Catch ex As Exception
                DebugToLog(ex)
            End Try

        End If
    End Sub
#End Region


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        SumFG1.AddSum()
        SumFG1.ReSum()
    End Sub
End Class

Partial Class Dao

#Region "常量"

    Public Const SQL_PB_GetByGh_PeiBcCompleted As String = "select P.*,Z.ZhiChang_Name from T30001_Produce_PB P left join T10120_ZhiChang Z on P.ZhiChang_ID=Z.ID where isnull(GH,'')=@GH "

    Public Const SQL_PB_GetByGh As String = "select P.*,Z.ZhiChang_Name from T40520_PB_StoreNo P left join (select ID,GH from  T40100_PBRK_Table t T40101_PBRK_List L where T.ID=L.ID ) R on P.ID=R.ID left join T10120_ZhiChang Z on P.ZhiChang_ID=Z.ID where isnull(R.GH,'')=@GH "


#End Region

  

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Gh"></param>
    ''' <param name="State"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PB_Update(ByVal _Gh As String, ByVal State As Enum_ProduceState, ByVal PBZL As Double, ByVal PBCount As Integer, ByVal dt As DataTable) As MsgReturn
        Dim sqlBuider As New StringBuilder
        sqlBuider.AppendLine(" update T30000_Produce_Gd set state =" & State & ",UPD_User=@UPD_User,UPD_Date=GetDate(), PB_ZLSum=" & PBZL & " ,PB_CountSum=" & PBCount & " where GH='" & _Gh & "'")
        If State = Enum_ProduceState.PeiBu Then
            '  sqlBuider.AppendLine(" update T40510_PB_Stock set GH='' where GH='" & _Gh & "'")
            sqlBuider.AppendLine(" update T40101_PBRK_List set GH='' where GH='" & _Gh & "'")
        Else
            Dim R As New MsgReturn
            R.Msg = "不能再配布了！"
        End If
        'For Each dr As DataRow In dt.Rows

        '    sqlBuider.AppendLine(" if (select isnull(GH,'') from T40510_PB_Stock where line=" & dr("Line") & " and isnull(GH,'')='') is null ")
        '    sqlBuider.AppendLine(" RAISERROR ( '第%d行已被使用!', 16,   1,   " & dr("Line") & ")   else ")
        '    sqlBuider.AppendLine(" update T40510_PB_Stock set GH='" & _Gh & "' where line=" & dr("Line") & " ")
        'Next
        Return PClass.PClass.RunSQL(sqlBuider.ToString, "UPD_User", User_Name)
    End Function
    Public Shared Function Produce_GetPBListAll(ByVal GH As String) As DtReturnMsg
        Return SqlStrToDt("select *,(Select Audited_Date from T40100_PBRK_Table l where l.ID=T40101_PBRK_List.ID) RK_Date from T40101_PBRK_List where GH=@GH", "GH", GH)

    End Function

End Class
