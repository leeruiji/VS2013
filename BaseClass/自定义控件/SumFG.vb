Imports PClass.PClass
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.Globalization

''' <summary>
''' FG合计 辅助控件
''' </summary>
''' <remarks></remarks>
<Description("FG合计行控件")> _
<Designer(GetType(SumFGIDesigner))> _
Public Class SumFG
    Public MeIsLoad As Boolean = False
#Region "属性"
    Private WithEvents FG1 As PClass.FG
    ''' <summary>
    ''' 要绑定的FG
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks> 
    <Description("要绑定的")> _
    Public Property FG() As PClass.FG
        Get
            Return FG1
        End Get
        Set(ByVal value As PClass.FG)
            FG1 = value
            ReSetTitle()
        End Set
    End Property

    Private Sub ReSetTitle()
        If Me.DesignMode Then
            If Me.Controls.ContainsKey("LB_Sum") Then
                Me.Controls("LB_Sum").Text = FG1.Name & "的合计:" & ComFun.ListToString(ColForSum, ",")

            End If
        End If
    End Sub

#Region "自定义类"

    'Public Class ColForSumType
    '    Public Property ColList() As List(Of String)
    '        Get
    '            Return _ColList
    '        End Get
    '        Set(ByVal value As List(Of String))
    '            _ColList = value
    '        End Set
    '    End Property
    '    Overloads Function ToString() As String
    '        Return ComFun.ListToString(_ColList, ",")
    '    End Function
    'End Class


    '自定义类型转换器
    Public Class ColForSumTypeConverter
        Inherits TypeConverter
        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            Dim t As List(Of String) = DirectCast(value, List(Of String))
            If t IsNot Nothing Then
                Return ComFun.ListToString(t, ",")
            Else
                Return ""
            End If
        End Function
    End Class
#End Region

    Private _ColForSum As New List(Of String)

    ''' <summary>
    ''' 统计被绑定的FG的哪几个列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <TypeConverter(GetType(ColForSumTypeConverter))> _
    <Description("统计被绑定的FG的哪几个列"), EditorAttribute(GetType(SumColListDialogEditor), GetType(Drawing.Design.UITypeEditor)), Localizable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property ColForSum() As List(Of String)
        Get
            Return _ColForSum
        End Get
        Set(ByVal value As List(Of String))
            _ColForSum = value
            ReSetTitle()
        End Set
    End Property



#End Region

#Region "方法"
    Sub New()
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Dim LB As New Label
        Me.Controls.Add(LB)
        LB.Name = "LB_Sum"
        LB.Padding = New Padding(0)
        LB.Margin = New Padding(0)
        LB.Top = -1
        LB.Left = -1
        LB.Height = Me.Height + 2
        LB.Anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Bottom
        LB.BorderStyle = Windows.Forms.BorderStyle.None
        LB.TextAlign = ContentAlignment.MiddleLeft
        LB.SendToBack()
        LB.Width = Me.Width + 2
        LB.Text = "合计:"
    End Sub




    ''' <summary>
    ''' 重新计算合计列
    ''' </summary>
    ''' <remarks></remarks>
    Sub ReSum()
        If FG1 IsNot Nothing AndAlso MeIsLoad Then
            Dim dt As DataTable = FG1.DataSource

            If dt IsNot Nothing Then
                dt.AcceptChanges()
                For Each Col As String In _ColForSum
                    Dim d As Double = 0
                    For Each Row As DataRow In dt.Rows
                        d += IsNull(Row(Col), 0)
                    Next
                    If FG1.Cols(Col).Format <> "" Then
                        Me.Controls("LB_" & Col).Text = Format(d, FG1.Cols(Col).Format)
                    Else
                        Me.Controls("LB_" & Col).Text = d
                    End If
                Next
            Else
                For Each Col As String In _ColForSum
                    Dim d As Double = 0
                    For i As Integer = 1 To FG.Rows.Count - 1
                        Try
                            d += IsNull(FG.Item(i, Col), 0)
                        Catch ex As Exception

                        End Try
                    Next
                    If FG1.Cols(Col).Format <> "" Then
                        Me.Controls("LB_" & Col).Text = Format(d, FG1.Cols(Col).Format)
                    Else
                        Me.Controls("LB_" & Col).Text = d
                    End If
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' 自动添加合计列
    ''' </summary>
    ''' <remarks></remarks>
    Sub AddSum()
        For Each s As String In _ColForSum
            AddCol(s)
        Next
        MeIsLoad = True
        ReSum()
        ReSizeColAll()
    End Sub

    ''' <summary>
    ''' 去掉所有合计列
    ''' </summary>
    ''' <remarks></remarks>
    Sub RemoveAllCol()
        For Each Col As String In _ColForSum
            RemoveCol(Col)
        Next
        _ColForSum.Clear()
    End Sub

    ''' <summary>
    ''' 去掉合计列
    ''' </summary>
    ''' <param name="Col"></param>
    ''' <remarks></remarks>
    Sub RemoveCol(ByVal Col As String)
        If Me.Controls.ContainsKey("LB_" & Col) Then
            Dim LB As TextBox = Me.Controls("LB_" & Col)
            Me.Controls.Remove(LB)
            LB.Dispose()
        End If
    End Sub


    ''' <summary>
    ''' 手动调节某一个合计列
    ''' </summary>
    ''' <param name="Col"></param>
    ''' <remarks></remarks>
    Sub AddCol(ByVal Col As String)
        Dim LB As TextBox
        If FG1.Cols.Contains(Col) = False Then
            Exit Sub
        End If
        If Me.Controls.ContainsKey("LB_" & Col) Then
            LB = Me.Controls("LB_" & Col)
        Else
            LB = New TextBox
            Me.Controls.Add(LB)
        End If
        LB.AutoSize = False
        LB.Name = "LB_" & Col
        LB.Anchor = AnchorStyles.Top + AnchorStyles.Bottom
        LB.Padding = New Padding(0)
        LB.Margin = New Padding(0)
        LB.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        LB.Height = Me.Height
        LB.TextAlign = HorizontalAlignment.Center
        LB.ReadOnly = True
        LB.BackColor = Me.BackColor
        LB.ForeColor = Me.ForeColor
        LB.Font = Me.Font
        LB.Top = -1
        LB.Text = 0
        LB.BringToFront()
        If _ColForSum.Contains(Col) = False Then
            _ColForSum.Add(Col)
        End If
    End Sub

    ''' <summary>
    ''' 重新调整某个列位置和宽度
    ''' </summary>
    ''' <remarks></remarks>
    Sub ReSizeLable(ByVal Col As String)
        If Me.Controls.ContainsKey("LB_" & Col) Then
            Dim LB As TextBox
            LB = Me.Controls("LB_" & Col)
            LB.Left = FG1.Cols(Col).Left + FG1.ScrollPosition.X + 1
            LB.Width = FG1.Cols(Col).WidthDisplay + 1
            LB.Visible = FG1.Cols(Col).Visible
        End If
    End Sub

    ''' <summary>
    ''' 重新调整所有列位置和宽度
    ''' </summary>
    ''' <remarks></remarks>
    Sub ReSizeColAll()
        If FG1 IsNot Nothing Then
            For Each Col As String In _ColForSum
                ReSizeLable(Col)
            Next
        End If
    End Sub

#End Region



#Region "FG事件"
    Private Sub FG1_AfterDragColumn(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.DragRowColEventArgs) Handles FG1.AfterDragColumn
        If MeIsLoad Then ReSizeColAll()
    End Sub
    Private Sub FG1_AfterResizeColumn(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FG1.AfterResizeColumn
        If MeIsLoad Then ReSizeColAll()
    End Sub
    Private Sub FG1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles FG1.Resize
        If MeIsLoad Then ReSizeColAll()
    End Sub

    Private Sub FG1_AfterScroll(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles FG1.AfterScroll
        If MeIsLoad Then ReSizeColAll()
    End Sub
#End Region



End Class

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class SumFGIDesigner
    Inherits ControlDesigner

    Public Overrides Sub DoDefaultAction()
        ShowComponentName(Me, New EventArgs)
    End Sub

    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Dim verbs_ As New System.ComponentModel.Design.DesignerVerbCollection()
            Dim dv1 As New System.ComponentModel.Design.DesignerVerb("FG合计列选择....", New EventHandler(AddressOf Me.ShowComponentName))
            verbs_.Add(dv1)
            Return verbs_
        End Get
    End Property


    Private Sub ShowComponentName(ByVal sender As Object, ByVal e As EventArgs)

        If (Me.Component IsNot Nothing) Then
            Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(Component)("ColForSum")
            Dim ColForSum As List(Of String) = descriptor.GetValue(Component)

            Dim FGList As New List(Of PClass.FG)
            If (Component.Site.Container.Components.Count > 0) Then
                For Each Col As Object In Component.Site.Container.Components
                    If TypeOf (Col) Is PClass.FG Then
                        FGList.Add(Col)
                    End If
                Next
            End If

            If FGList.Count = 0 Then
                MsgBox("本界面没有FG,请选画一个FG", MsgBoxStyle.Exclamation, "合计列选择")
                Exit Sub
            End If

            Dim C As New SumColListDialog(ColForSum, TypeDescriptor.GetProperties(Component)("FG").GetValue(Component), FGList)
            If C.ShowDialog = DialogResult.OK Then
                If ReferenceEquals(TypeDescriptor.GetProperties(Component)("FG").GetValue(Component), C.FG) = False Then
                    TypeDescriptor.GetProperties(Component)("FG").SetValue(Component, C.FG)
                End If
                TypeDescriptor.GetProperties(Component)("ColForSum").SetValue(Component, C.GetColForSumType)
                TryCast(Me.Component.Site.GetService(GetType(System.ComponentModel.Design.DesignerActionUIService)), System.ComponentModel.Design.DesignerActionUIService).Refresh(Me.Component)
            End If
        End If
    End Sub


End Class


