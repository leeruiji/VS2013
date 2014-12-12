Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Imports PClass.CReport

Public Class F40202_CancelPB_Log
    Dim dtProduce As DataTable

    Dim gh As String = ""






    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
  

    End Sub
    Private Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal GH As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        Me.gh = GH
    End Sub

    Private Sub F10100_SCPB_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        Ch_Name = "取消配布记录" 'GetBillTypeName(ID)
        'Dao.Balance_DB_NAME = Ch_Name
        Me.Title = Ch_Name ' & "列表"

        FG1.IniFormat()

        Me_Refresh()
    End Sub
#Region "刷新FG"

    Public Nohide As Boolean = False
    Protected Sub Me_Refresh()
        Static T As Threading.Thread
        If T IsNot Nothing Then
            If T.IsAlive Then
                Try
                    T.Abort()
                Catch ex As Exception
                End Try
            End If
        End If
        T = New Threading.Thread(AddressOf GetData)
        FG1.Visible = False
        T.Start(GetFindOtions)
        If Nohide = False Then Me.ShowLoading(MeIsLoad)
    End Sub


    Sub SetData(ByVal msg As DtReturnMsg)
        If msg.IsOk Then
            dtProduce = msg.Dt
            ' Me.dtProduce.Columns.Add("StateName", GetType(String))



            FG1.DtToFG(dtProduce)
            FG1.RowSetForce("GH", ReturnId)
        Else
            FG1.Rows.Count = 1
        End If
        FG1.Visible = True
        Me.HideLoading()
        Nohide = False
    End Sub

    Protected Sub GetData(ByVal oList As OptionList)
        Dim msg As DtReturnMsg = Dao.SCPB_GetLog(gh)
        Me.Invoke(New DSetData(AddressOf SetData), msg)
    End Sub
    Private Delegate Sub DSetData(ByVal msg As DtReturnMsg)

#End Region




#Region "控件事件"


    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me_Refresh()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim F As New F40201_SCPB_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的生产胚布单")
            Exit Sub
        End If
        Dim F As New F40201_SCPB_Msg(FG1.SelectItem("SCPB_ID"))
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub

    ''' <summary>
    ''' 双击行.进入修改页面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FG1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FG1.DoubleClick
        If FG1.RowSel < 0 Then
            ShowErrMsg("请选择一个要修改的生产胚布单")
            Exit Sub
        End If

        ModifySCPB(FG1.SelectItem("GH"))
    End Sub

    Sub ModifySCPB(ByVal GH As String)
        Dim F As New F40201_SCPB_Msg(GH)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()
    End Sub
    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Me_Refresh()
        End If
    End Sub



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
#End Region

#Region "搜索工具栏"
    'Private Sub CB_ConditionName1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_ConditionName1.SelectedIndexChanged
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName1.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue1.ComboBox.DataSource = msg.Dt

    '    End If
    'End Sub

    'Private Sub CB_ConditionName2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim oList As OptionList = GetFindOtions()
    '    Dim msg As DtReturnMsg = OptionClass.OptionClass_GetConditionValues("(" & oList.Sql & ")Con", CB_ConditionName2.ComboBox.SelectedValue, "")
    '    If msg.IsOk Then
    '        CB_ConditionValue2.ComboBox.DataSource = msg.Dt
    '    End If
    'End Sub




    ''' <summary>
    ''' 生成搜索条件
    ''' </summary>
    ''' <remarks></remarks>
    Protected Function GetFindOtions() As OptionList

        Dim oList As New OptionList
        Dim fo As New FindOption
        '   oList.Sql = SQL_SCPB_Get_Sel
        Dim sqlbuider As New StringBuilder(Dao.SQL_PBRK_Get_Sel)
        Dim goodsCount As Integer = 0

      

      


        'If TB_GH.Text <> "" Then
        '    fo = New FindOption
        '    fo.DB_Field = "GH"


        '    fo.Value = TB_GH.Text
        '    fo.Field_Operator = Enum_Operator.Operator_Like_Both
        '    oList.FoList.Add(fo)
        'End If



        Return oList
    End Function

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Me_Refresh()
    End Sub


#End Region
    '#Region "报表事件"

    '    Private Sub Btn_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Print(OperatorType.Preview)
    '    End Sub

    '    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Print(OperatorType.Print)
    '    End Sub

    '    Protected Sub Print(ByVal DoOperator As OperatorType)
    '        If FG1.RowSel < 0 Then
    '            ShowErrMsg("请选择一张出货单!")
    '            Exit Sub
    '        End If
    '        ' Dim R As New R40001_SCPB
    '        ' R.Start(FG1.Item(FG1.RowSel, "SCPB_ID"), DoOperator)
    '    End Sub

    '#End Region



End Class


Partial Friend Class Dao

    Public Shared Function SCPB_GetLog(ByVal gh As String) As DtReturnMsg
        Return SqlStrToDt("Select * from T30006_GHStateLog where GH=@GH and newState=1", "GH", gh)
    End Function
End Class

