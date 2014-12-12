Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F10061_PF
    Private WithEvents R As New R10061_PF
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()


        'Control_CheckRight(ID, ClassMain.Print, Cmd_Print)
    End Sub

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub




    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
        Ch_Name = GetBillTypeName(ID)
        Me.Title = "打板统计表"


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
        'If CK_Date.Checked Then
        '    R.SetOption(DP_End.Value.Date, DP_End.Value.Date)
        'Else
        R.SetOption(DP_Start.Value.Date, DP_End.Value.Date)
        'End If

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

    'Private Sub CK_Date_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If CK_Date.Checked Then
    '        Label_C.Visible = False
    '        Label_D.Visible = False
    '        DP_Start.Visible = False
    '    Else
    '        Label_C.Visible = True
    '        Label_D.Visible = True
    '        DP_Start.Visible = True
    '    End If
    'End Sub

#End Region



    '#Region "双击行,调出单的明细"


    '    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
    '        Dim Danhao As String = GR.GetSelRowCellText(1)
    '        Dim ID As Integer
    '        If Danhao.StartsWith("D") Then
    '            ID = 20320
    '        Else
    '            ID = 20310
    '        End If

    '        ShowGoodsTypeSel(ID, Danhao)


    '    End Sub
    '#End Region

    '#Region "选择分类"
    '    Dim TypeID As String = ""
    '    Dim TypeName As String = ""
    '    Protected Sub ShowGoodsTypeSel(ByVal id As Integer, ByVal Danhao As String)

    '        Dim F As BaseForm = LoadModifyFormByID(id)
    '        If F Is Nothing Then Exit Sub
    '        With F
    '            .Mode = Mode_Enum.Modify
    '            .P_F_RS_ID = Danhao
    '            .P_F_RS_ID2 = ""
    '            '.IsSel = True
    '        End With
    '        ReturnId = ""
    '        Me.ReturnObj = Nothing
    '        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
    '        AddHandler VF.ClosedX, AddressOf Me_Refresh
    '        VF.Show()

    '    End Sub
    '#End Region



    '#Region "商品选择"





    '#End Region

#Region "打印预览报表"

    Private Sub Cmd_Preview_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Preview.Click
        R.Start(OperatorType.Preview)
    End Sub
#End Region

#Region "打印预览报表"

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        R.Start(OperatorType.Print)
    End Sub
#End Region
End Class

