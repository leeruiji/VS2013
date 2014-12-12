Imports PClass.PClass
Imports System.Data
Imports System.Text
Imports BaseClass

Public Class F30006_Produce_TP

    Dim isloaded As Boolean = False
    Dim ZL As Double
    Dim Num As Double


    ''' <summary>
    ''' 权限获取
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormCheckRight()
        ID = 30000
        Control_CheckRight(ID, ClassMain.FD, Cmd_TB)
    End Sub




    Private Sub CB_Client_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_Client.Col_Sel
        If CB_BZ.SearchID <> ID Then
            CB_BZ.Text = ""
            CB_BZ.SetSearchEmpty()
        End If
        CB_BZ.Enabled = True
        CB_BZ.SearchID = ID
        CB_BZ.SearchType = cSearchType.ENum_SearchType.Client
        TB_ClientName.Text = Col_Name
    End Sub


    Private Sub CB_BZ_Col_Sel(ByVal Col_No As String, ByVal Col_Name As String, ByVal ID As String) Handles CB_BZ.Col_Sel
        TB_BZName.Text = Col_Name
    End Sub

    Private Sub Cmd_TB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_TB.Click

        Dim F As New F30001_Produce_Gd_Msg("")
        With F
            .Mode = Mode_Enum.Add
            .GHType = Enum_GH_Type.TP
            .P_F_RS_ID2 = CB_BZ.IDAsInt
            .P_F_RS_ID3 = CB_Client.IDAsInt
            .P_F_RS_ID4 = CB_Client.NoValue
            .P_F_RS_ID5 = CB_Client.NameValue
            .P_F_RS_Obj = TB_Color.Text
        End With
        F_RS_ID = ""
        Me.ReturnId = ""
        Me.ReturnObj = Nothing
        Dim VF As PClass.ViewForm = PClass.PClass.LoadChildForm(F, Me)
        AddHandler VF.ClosedX, AddressOf Edit_Retrun
        VF.Show()

    End Sub
    Sub Edit_Retrun()
        LastForm.ReturnId = Me.ReturnId
        LastForm.ReturnMsg = Me.ReturnMsg
        LastForm.ReturnObj = Me.ReturnObj
        Me.Close()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
End Class


Partial Class Dao
    'Public Shared Function Produce_GetCGGH(ByVal GH As String) As MsgReturn
    '    Dim R As DtReturnMsg
    '    If IsNumeric(GH.Substring(GH.Length - 1)) Then
    '        R = SqlStrToDt("Select Top 1  GH from T30000_Produce_Gd where GH Like @GH order by GH Desc", "GH", GH & "%")
    '    Else
    '        R = SqlStrToDt("Select Top 1  GH from T30000_Produce_Gd where GH Like @GH order by GH Desc", "GH", GH.Substring(0, GH.Length - 1) & "%")
    '    End If
    '    Produce_GetCGGH = New MsgReturn
    '    If R.IsOk AndAlso R.Dt.Rows.Count > 0 Then
    '        Dim s As String = R.Dt.Rows(0)("GH").ToString.ToUpper
    '        If IsNumeric(s.Substring(s.Length - 1)) OrElse s.Substring(s.Length - 1) = "R" Then
    '            s = s & "B"
    '        Else
    '            s = s.Substring(0, s.Length - 1) & Chr(Asc(s.Substring(s.Length - 1)) + 1)
    '        End If
    '        Produce_GetCGGH.IsOk = True
    '        Produce_GetCGGH.Msg = s
    '    Else
    '        Produce_GetCGGH.IsOk = False
    '        Produce_GetCGGH.Msg = "缸号[" & GH & "]不存在!"
    '    End If
    'End Function

    'Public Shared Function Produce_GetPBList(ByVal GH As String) As DtReturnMsg
    '    Return SqlStrToDt("select ID,Line,PB from T40101_PBRK_List where GH=@GH", "GH", GH)

    'End Function



End Class