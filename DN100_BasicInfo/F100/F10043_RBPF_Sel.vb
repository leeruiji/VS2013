Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass
Public Class F10043_RBPF_Sel
    Dim BzcID As Integer

    Dim dtGoods As DataTable

    Private Sub F10020_BZC_AfterLoad() Handles Me.AfterLoad
     
    End Sub




    Private Sub F10000_BZC_Form_KeyPress(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs) Handles Me.Form_KeyPress
        Select Case e.KeyChar
            Case vbCr
            Case Else
                
        End Select
    End Sub
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    Public Sub New(ByVal _id As Integer)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.BzcID = _id
    End Sub
    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        'Control_CheckRight(ID, ClassMain.Add, Cmd_Add)
        'Control_CheckRight(ID, ClassMain.Modify, Cmd_Modify)
        'Control_CheckRight(ID, ClassMain.Del, Cmd_Del)
    End Sub

    Private Sub F10020_BZC_Me_Closing(ByVal sender As Object, ByRef e As System.ComponentModel.CancelEventArgs) Handles Me.Me_Closing
        Me.MeIsLoad = False
    End Sub


    Private Sub F10000_BZC_Me_Load() Handles Me.Me_Load
        FormCheckRight()
        '    Dim folist As List(Of FindOption) = BZC_GetConditionNames()

        Fg2.IniColsSize()
        Fg3.IniColsSize()
        Search()
      
    End Sub

    Protected Sub Search()
        GetPF()
    End Sub


    Private Sub Edit_Retrun()
        If ReturnId <> "" Then
            Search()
        End If
    End Sub



#Region "数据库交互"

#End Region

#Region "控件事件"

    Private Sub Btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Refresh.Click
        Search()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        AddGoods()
    End Sub

    Protected Sub AddGoods()
        '   If Fg2.RowSel > 1 Then
        Me.LastForm.ReturnId = -1
        Me.Close()
        ' End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cmd_Modify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Modify.Click
        SelPF()
    End Sub

    Protected Sub SelPF()
        If Fg2.RowSel >= 1 Then
            Me.LastForm.ReturnId = Fg2.Item(Fg2.RowSel, "ID")
            Me.Close()
        End If
        
    End Sub





    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub



#End Region





#Region "FG事件"
    Dim SelectedPFID As Integer = 0
    Public Sub GetPF()
        If BzcID > 0 Then
            Dim msg2 As DtReturnMsg = Dao.BZCPF_GetPFListByBZCID(BzcID)
            If msg2.IsOk Then
                MeIsLoad = False
                Fg2.DtToSetFG(msg2.Dt)
                MeIsLoad = True
                If SelectedPFID <> 0 AndAlso Fg2.Rows.Count > 1 Then
                    Fg2.RowSetForce(Fg2.Cols("ID").Index, SelectedPFID)
                End If
                If msg2.Dt.Rows.Count = 0 Then
                    Fg3.Rows.Count = 1
                Else
                    If Fg2.Rows.Count > 1 AndAlso Fg2.RowSel <= 0 Then
                        Fg2.Row = 1
                        Fg2.RowSel = 1
                    End If
                    MeIsLoad = True
                    GetPFLIst()
                End If

            End If
        End If
        MeIsLoad = True
    End Sub

    Protected Sub GetPFLIst()
        If Fg2.RowSel >= Fg2.Rows.Fixed Then
            Dim msg3 As DtReturnMsg = Dao.BZCPF_GeList_ByID(Fg2.Item(Fg2.RowSel, "ID"), BzcID)
            If msg3.IsOk Then
                Fg3.DtToSetFG(msg3.Dt)
                If Fg2.Item(Fg2.RowSel, "IsCheck") = True Then
                    Fg3.Cols("UpdQty").Visible = True
                Else
                    Fg3.Cols("UpdQty").Visible = False
                End If
            End If
        Else
            If Fg2.RowSel <= 0 AndAlso Fg2.Rows.Count > 1 Then
                Fg2.RowSel = 1
            End If
        End If

    End Sub

    'Private Sub Fg2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.Click
    '    GetPFLIst()
    'End Sub


    'Private Sub Fg1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Click
    '    GetPF()
    'End Sub


 


    Private Sub Fg2_SelectRowChange(ByVal Row As Integer) Handles Fg2.SelectRowChange
        If Me.MeIsLoad Then GetPFLIst()
    End Sub

    Private Sub Fg2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg2.DoubleClick
        SelPF()
    End Sub
    Protected Sub ModifyPF(ByVal _PFID As Integer, ByVal _BZC_ID As Integer)
        Dim F As New F10022_BZC_PF(_PFID, _BZC_ID)
        With F
            .Mode = Mode_Enum.Modify
            .P_F_RS_ID = ""
            .P_F_RS_ID2 = ""
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        SelectedPFID = _PFID
        AddHandler VF.ClosedX, AddressOf GetPF
        VF.Show()
    End Sub



    Private Sub Fg3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg3.DoubleClick
        Dim _BZC_ID As Integer = BzcID
        Dim _PFID As Integer = Val(Fg2.Item(Fg2.RowSel, "ID"))
        ModifyPF(_PFID, _BZC_ID)
    End Sub
  
#End Region

End Class
