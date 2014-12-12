Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.Windows.Forms

Friend Class SumColListDialog
    Public ColForSumType As List(Of String)
    Dim Dt As DataTable
    Public FG As PClass.FG
    Public Sub New(ByVal ColForSumType As List(Of String), ByVal FG As PClass.FG, ByVal FGList As List(Of PClass.FG))
        InitializeComponent()
        Dim S As String = ""
        Dim Index As Integer = 0
        Me.FG = FG
        Me.ColForSumType = ColForSumType
        Dt = New DataTable("T")
        Dt.Columns.Add("Caption")
        Dt.Columns.Add("Name")
        Dt.Columns.Add("Format")
        Dt.Columns.Add("Width", GetType(Integer))
        Dt.Columns.Add("IsSum", GetType(Boolean))
        Dt.Columns.Add("Visable", GetType(Boolean))
        Dt.Columns.Add("TitelCenter", GetType(Boolean))
        Dt.Columns.Add("TextCenter", GetType(Boolean))
        Fg1.DtToFG(Dt)
        CB_FG.DataSource = FGList
        If FG Is Nothing Then
            FG = FGList(0)
        End If
        CB_FG.SelectedItem = FG
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_FG.SelectedIndexChanged
        Try
            GetColForSumType(False)
            FG = CB_FG.SelectedItem
            FG1LoadDT()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Function GetColForSumType(Optional ByVal IsClear As Boolean = True) As List(Of String)
        If IsClear Then ColForSumType.Clear()
        For Each row As DataRow In Dt.Rows
            Dim Col As C1.Win.C1FlexGrid.Column = FG.Cols(row("Name"))
            Col.Visible = row("Visable")
            Col.Format = row("Format")
            Col.Caption = row("Caption")
            Col.Width = PClass.PClass.Val(row("Width"))
            If row("TextCenter") = True Then
                Col.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            End If
            If row("TitelCenter") = True Then
                Col.TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            End If
            If row("IsSum") Then
                ColForSumType.Add(Col.Name)
            End If
        Next
        Return ColForSumType
    End Function

    Sub FG1LoadDT()
        Dt.Rows.Clear()
        Dt.AcceptChanges()
        For Each Col As C1.Win.C1FlexGrid.Column In FG.Cols
            If Col.Name <> "FG_Index" AndAlso Col.Name <> "" Then
                Dim Dr As DataRow = Dt.NewRow
                Dr("Name") = Col.Name
                Dr("Format") = Col.Format
                Dr("Caption") = Col.Caption
                Dr("Width") = Col.Width
                Dr("TextCenter") = Col.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                Dr("TitelCenter") = Col.TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                Dr("IsSum") = ColForSumType.Contains(Col.Name)
                Dr("Visable") = Col.Visible
                Dt.Rows.Add(Dr)
            End If
        Next
    End Sub






    Private Sub Fg1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fg1.Click
        If Fg1.RowSel < 1 Then
            Exit Sub
        End If

        If Fg1.ColSel >= Fg1.Cols("TitelCenter").Index Then
            Fg1.Item(Fg1.RowSel, Fg1.ColSel) = Not Fg1.Item(Fg1.RowSel, Fg1.ColSel)
        End If
    End Sub




End Class

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Friend Class SumColListDialogEditor
    Inherits System.Drawing.Design.UITypeEditor


    'Public Sub New()
    'End Sub

    Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        ' Indicates that this editor can display a Form-based interface.
        Return UITypeEditorEditStyle.Modal
    End Function

    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
        If edSvc Is Nothing Then
            Return Nothing
        End If

        Dim self As SumFG = TryCast(context.Instance, SumFG)
        Dim FGList As New List(Of PClass.FG)
        If (self.Site.Container.Components.Count > 0) Then
            For Each Col As Object In self.Site.Container.Components
                If TypeOf (Col) Is PClass.FG Then
                    FGList.Add(Col)
                End If
            Next
        End If

        If FGList.Count = 0 Then
            MsgBox("本界面没有FG,请选画一个FG", MsgBoxStyle.Exclamation, "合计列选择")
            Return value
        End If

        Dim C As New SumColListDialog(value, self.FG, FGList)
        If edSvc.ShowDialog(C) = DialogResult.OK Then
            If ReferenceEquals(self.FG, C.FG) = False Then
                self.FG = C.FG
            End If
            context.OnComponentChanged()
            Return C.GetColForSumType
        End If
        ' If OK was not pressed, return the original value
        Return value

    End Function
End Class
