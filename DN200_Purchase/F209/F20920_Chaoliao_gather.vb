Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F20920_Chaoliao_gather
    Private WithEvents R As New R20920_Chaoliao_gather
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

        Control_CheckRight(ID, ClassMain.ReportRemark, Cmd_Remark)
    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = Ch_Name
        CB_Reason.ComboBox.ValueMember = "DB_Field"
        CB_Reason.ComboBox.DisplayMember = "Field"
        CB_Reason.ComboBox.DataSource = Purchase_GetCondition()

        DP_Start.Value = New Date(Today.Year, Today.Month, 1)
        DP_End.Value = Today
        Try
            GR.Report = R.Report
        Catch ex As Exception
            Me.Close()
            Exit Sub
        End Try
        Me_Refresh()
        isLoaded = True
        ' Dim T As New Threading.Thread(AddressOf Get_Goods)
        '  T.Start()

    End Sub

    Protected Sub Me_Refresh()

        If CK_Date.Checked Then
            R.SetOption(DP_End.Value.Date, DP_End.Value.Date, CK_HaveRL.Checked, CB_Reason.Text, Val(CB_Times.Text), CK_Check30.Checked)
        Else
            R.SetOption(DP_Start.Value.Date, DP_End.Value.Date, CK_HaveRL.Checked, CB_Reason.Text, Val(CB_Times.Text), CK_Check30.Checked)
        End If

        R.Start()
    End Sub




#Region "控件事件"
    'Private Sub Btn_ExcelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExcelOut.Click
    '    R.ExportXLS()
    'End Sub
    'Private Sub Btn_PrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PrePrint.Click
    '    R.PrintPreview()
    'End Sub
    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub

    'Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
    '    Me_Refresh()
    'End Sub
    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub CK_Date_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_Date.CheckStateChanged
        If CK_Date.Checked Then
            Label_C.Visible = False
            Label_D.Visible = False
            DP_Start.Visible = False
        Else
            Label_C.Visible = True
            Label_D.Visible = True
            DP_Start.Visible = True
        End If
    End Sub

#End Region

    ''' <summary>
    ''' 获取单据合集
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Purchase_GetCondition() As List(Of FindOption)
        Dim foList As New List(Of FindOption)
        Dim fo As New FindOption
        fo.Field = "全部"
        fo.DB_Field = ""
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "染部领料"
        fo.DB_Field = 20321
        foList.Add(fo)

        fo = New FindOption
        fo.Field = "定型领料"
        fo.DB_Field = 20320
        foList.Add(fo)

        Return foList
    End Function






#Region "双击行,调出单的明细"


    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim Danhao As String = GR.GetSelRowCellText(1)
        Dim ID As Integer
        If Danhao.StartsWith("D") Then
            ID = 20320
        Else
            ID = 20310
        End If

        ShowGoodsTypeSel(ID, Danhao)


    End Sub
#End Region

#Region "选择分类"
    Dim TypeID As String = ""
    Dim TypeName As String = ""
    Protected Sub ShowGoodsTypeSel(ByVal id As Integer, ByVal Danhao As String)

        Dim F As BaseForm = LoadModifyFormByID(id)
        If F Is Nothing Then Exit Sub
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = Danhao
            .P_F_RS_ID2 = ""
            '.IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()

    End Sub
#End Region



#Region "商品选择"





#End Region

#Region "打印预览报表"
    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        R.Start(OperatorType.Preview)
    End Sub
#End Region


    Private Sub Cmd_Remark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Remark.Click

        Dim Danhao As String = GR.GetSelRowCellText(1)
        If IsNull(Danhao, "") = "" Then
            ShowErrMsg("没有要添加备注的单号")
            Exit Sub
        End If

        ShowInput("请输入备注:", AddressOf SetRemar)

    End Sub

    Private Sub SetRemar(ByVal s As String)
        Dim Danhao As String = GR.GetSelRowCellText(1)
        Dim Msg As MsgReturn = Dao.Update_Remark(s, Danhao)
        If Msg.IsOk Then
            ShowOk("单号［" & Danhao & "］添加成功")
            Me_Refresh()
        Else
            ShowOk("单号［" & Danhao & "］添加失败")
        End If
    End Sub

End Class

Partial Friend Class Dao
    Public Const SQL_UpRemark_ByID As String = " Update T20310_Lingliao_Table Set ReportRemark=@ReportRemark Where ID=@ID "

    ''' <summary>
    ''' 更新备注
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Update_Remark(ByVal Remark As String, ByVal ID As String) As MsgReturn
        Dim p As New Dictionary(Of String, Object)
        p.Add("ReportRemark", Remark)
        p.Add("ID", ID)
        Return PClass.PClass.RunSQL(SQL_UpRemark_ByID, p)
    End Function




End Class