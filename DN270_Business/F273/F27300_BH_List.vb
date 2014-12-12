Option Compare Text
Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports PClass
Imports BaseClass
Imports PClass.CReport

Public Class F27300_BH_List
    Private WithEvents R As New R27300_BH_List
    Dim isLoaded As Boolean = False
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()

    End Sub

    Private Sub Form_Me_Load() Handles MyBase.Me_Load
        FormCheckRight()
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

        R.SetOption(CB_WL.Text)
        R.Start()
    End Sub


#Region "控件事件"
   
    Private Sub R_LoadFileCompleted() Handles R.LoadFileCompleted
        GR.Refresh()
    End Sub

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        Me.Me_Refresh()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

#End Region


#Region "双击行,调出单的明细"
    Private Sub GR_DblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GR.DblClick
        Dim BH_No As String = GR.GetSelRowCellText(3)
        Dim ID As Integer = 20304
        ShowGoodsTypeSel(ID, BH_No)
    End Sub


    Protected Sub ShowGoodsTypeSel(ByVal id As Integer, ByVal BH_No As String)

        Dim F As BaseForm = LoadModifyFormByID(id)
        If F Is Nothing Then Exit Sub
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = BH_No
            .P_F_RS_ID2 = ""
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Me_Refresh
        VF.Show()

    End Sub





#End Region

    Private Sub Cmd_WL_Click(sender As Object, e As EventArgs) Handles Cmd_WL.Click
        ShowGoodsSel()
    End Sub


    Protected Sub ShowGoodsSel()
        Dim F As BaseForm = LoadFormIDToChild(10004, Me)
        If F Is Nothing Then Exit Sub
        With F
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
            .P_F_RS_ID4 = ""
            .IsSel = True
        End With
        ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf SetGoods
        VF.Show()
    End Sub

    Private Sub SetGoods()
        If Me.ReturnObj Is Nothing Then
            Exit Sub
        End If
        Dim dr As DataRow = TryCast(Me.ReturnObj, DataRow)
        CB_WL.Tag = IsNull(dr("ID"), "")
        CB_WL.Text = IsNull(dr("WL_No"), "")
    End Sub

    Private Sub Cmd_Preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        R.Start(OperatorType.Preview)
    End Sub

End Class

