Imports System.Windows.Forms
<System.ComponentModel.EditorBrowsable(False)> _
<System.ComponentModel.ToolboxItem(False)> _
Public Class SearchItem
    Protected Shadows WithEvents DropDownItem1 As ToolStripDropDown
    Private dataGridViewHost As ToolStripControlHost

    Public Index As Integer = 0
    Public LastText As String = ""
    Public Child As New SearchCol
    Public SearchOK As Boolean = False


    Private _IsIgnoreTime As Boolean = False
    ''' <summary>
    ''' 忽略时间
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsIgnoreTime() As Boolean
        Get
            Return _IsIgnoreTime
        End Get
        Set(ByVal value As Boolean)
            _IsIgnoreTime = value
            If _IsIgnoreTime Then

            Else
                Me.Image = My.Resources.search
            End If
        End Set
    End Property


    ''' <summary>
    ''' 如果是是条件名称Combobox点击时候获取数据,如果否条件值Combobox下拉时候才获取数据
    ''' </summary>
    ''' <remarks></remarks>
    Private _IsNameChangeToData As Boolean = False
    ''' <summary>
    ''' 如果是是条件名称Combobox点击时候获取数据,如果否条件值Combobox下拉时候才获取数据
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsNameChangeToData() As Boolean
        Get
            Return _IsNameChangeToData
        End Get
        Set(ByVal value As Boolean)
            _IsNameChangeToData = value
        End Set
    End Property




    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。


        dataGridViewHost = New ToolStripControlHost(Child)

        Child.ParentCol = Me
        DropDownItem1 = New ToolStripDropDown()
        DropDownItem1.Padding = New Padding(1)
        DropDownItem1.Width = Me.Width
        DropDownItem1.Items.Add(dataGridViewHost)
        'Me.DropDownItems.Add(dataGridViewHost)
        Me.DropDown = DropDownItem1

    End Sub




    Private Sub SearchItem_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DropDownOpened
        Child.WhileShowMe()
    End Sub

    Private Sub SearchItem_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DropDownClosed
        Child.WhileHideMe()
    End Sub


End Class
