Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.Windows.Forms

Friend Class FormColList
    Public Sub New(ByVal SelectText As String)
        InitializeComponent()
        Dim Types As Type() = Reflection.Assembly.GetAssembly(GetType(ComBoListCtrl)).GetTypes
        Dim S As String = ""
        Dim Index As Integer = 0
        For Each oType As Type In Types
            If oType.BaseType Is GetType(ComBoListCtrl) Then
                Try
                    S = System.Activator.CreateInstance(oType).ComboName()
                Catch ex As Exception
                    S = ""
                End Try
                ListBox1.Items.Add(oType.Name.ToString() & " - " & S)
                If oType.Name.ToString = SelectText Then
                    Index = ListBox1.Items.Count - 1
                End If
            End If
        Next
        ListBox1.SelectedIndex = Index
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


End Class

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Friend Class ColListDialogEditor
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


        Dim C As New FormColList(value)
        If edSvc.ShowDialog(C) = DialogResult.OK Then
            Return C.ListBox1.Text.Split(" - ")(0)
        End If

        ' If OK was not pressed, return the original value
        Return value

    End Function
End Class