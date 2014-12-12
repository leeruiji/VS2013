<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F21006_CostChange_Msg
    Inherits Global.PClass.BaseForm

    'UserControl 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Tool_Top = New System.Windows.Forms.ToolStrip
        Me.Cmd_Modify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Cmd_Exit = New System.Windows.Forms.ToolStripButton
        Me.PanelMain = New System.Windows.Forms.Panel
        Me.TB_Unit = New System.Windows.Forms.TextBox
        Me.DTP_sDate = New System.Windows.Forms.DateTimePicker
        Me.Btn_ChoseWl = New System.Windows.Forms.Button
        Me.TB_Price = New System.Windows.Forms.TextBox
        Me.TB_Remark = New System.Windows.Forms.TextBox
        Me.TB_Spec = New System.Windows.Forms.TextBox
        Me.TB_Qty = New System.Windows.Forms.TextBox
        Me.TB_Cost_New = New System.Windows.Forms.TextBox
        Me.TB_Cost_Old = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB_WL_ID = New System.Windows.Forms.TextBox
        Me.TB_ID = New System.Windows.Forms.TextBox
        Me.TB_Name = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label_ID = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.LB_FullName = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LB_Contact = New System.Windows.Forms.Label
        Me.LB_Area = New System.Windows.Forms.Label
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.Tool_Top.SuspendLayout()
        Me.PanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tool_Top
        '
        Me.Tool_Top.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Tool_Top.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Modify, Me.ToolStripSeparator5, Me.Cmd_Exit})
        Me.Tool_Top.Location = New System.Drawing.Point(0, 0)
        Me.Tool_Top.MinimumSize = New System.Drawing.Size(0, 40)
        Me.Tool_Top.Name = "Tool_Top"
        Me.Tool_Top.Size = New System.Drawing.Size(577, 40)
        Me.Tool_Top.TabIndex = 10
        Me.Tool_Top.Text = "ToolStrip2"
        '
        'Cmd_Modify
        '
        Me.Cmd_Modify.AccessibleDescription = "修改按钮"
        Me.Cmd_Modify.AccessibleName = ""
        Me.Cmd_Modify.Image = Global.DN210_MetalStore.My.Resources.Resources.Modify
        Me.Cmd_Modify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Modify.Name = "Cmd_Modify"
        Me.Cmd_Modify.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Modify.Text = "审核"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 40)
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Image = Global.DN210_MetalStore.My.Resources.Resources.Close
        Me.Cmd_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(57, 37)
        Me.Cmd_Exit.Text = "关闭"
        '
        'PanelMain
        '
        Me.PanelMain.Controls.Add(Me.TB_Unit)
        Me.PanelMain.Controls.Add(Me.DTP_sDate)
        Me.PanelMain.Controls.Add(Me.Btn_ChoseWl)
        Me.PanelMain.Controls.Add(Me.TB_Price)
        Me.PanelMain.Controls.Add(Me.TB_Remark)
        Me.PanelMain.Controls.Add(Me.TB_Spec)
        Me.PanelMain.Controls.Add(Me.TB_Qty)
        Me.PanelMain.Controls.Add(Me.TB_Cost_New)
        Me.PanelMain.Controls.Add(Me.TB_Cost_Old)
        Me.PanelMain.Controls.Add(Me.Label8)
        Me.PanelMain.Controls.Add(Me.TB_WL_ID)
        Me.PanelMain.Controls.Add(Me.TB_ID)
        Me.PanelMain.Controls.Add(Me.TB_Name)
        Me.PanelMain.Controls.Add(Me.Label1)
        Me.PanelMain.Controls.Add(Me.Label24)
        Me.PanelMain.Controls.Add(Me.Label7)
        Me.PanelMain.Controls.Add(Me.Label3)
        Me.PanelMain.Controls.Add(Me.Label_ID)
        Me.PanelMain.Controls.Add(Me.Label2)
        Me.PanelMain.Controls.Add(Me.Label19)
        Me.PanelMain.Controls.Add(Me.LB_FullName)
        Me.PanelMain.Controls.Add(Me.Label4)
        Me.PanelMain.Controls.Add(Me.LB_Contact)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 40)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Padding = New System.Windows.Forms.Padding(2)
        Me.PanelMain.Size = New System.Drawing.Size(577, 343)
        Me.PanelMain.TabIndex = 12
        '
        'TB_Unit
        '
        Me.TB_Unit.Location = New System.Drawing.Point(102, 155)
        Me.TB_Unit.Name = "TB_Unit"
        Me.TB_Unit.ReadOnly = True
        Me.TB_Unit.Size = New System.Drawing.Size(145, 23)
        Me.TB_Unit.TabIndex = 94
        '
        'DTP_sDate
        '
        Me.DTP_sDate.CustomFormat = "yyyy年MM月dd日"
        Me.DTP_sDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_sDate.Location = New System.Drawing.Point(363, 17)
        Me.DTP_sDate.Name = "DTP_sDate"
        Me.DTP_sDate.Size = New System.Drawing.Size(156, 23)
        Me.DTP_sDate.TabIndex = 1
        '
        'Btn_ChoseWl
        '
        Me.Btn_ChoseWl.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_ChoseWl.Location = New System.Drawing.Point(244, 63)
        Me.Btn_ChoseWl.Name = "Btn_ChoseWl"
        Me.Btn_ChoseWl.Size = New System.Drawing.Size(24, 23)
        Me.Btn_ChoseWl.TabIndex = 93
        Me.Btn_ChoseWl.Text = "..."
        Me.Btn_ChoseWl.UseVisualStyleBackColor = True
        '
        'TB_Price
        '
        Me.TB_Price.Location = New System.Drawing.Point(364, 197)
        Me.TB_Price.Name = "TB_Price"
        Me.TB_Price.ReadOnly = True
        Me.TB_Price.Size = New System.Drawing.Size(155, 23)
        Me.TB_Price.TabIndex = 9
        '
        'TB_Remark
        '
        Me.TB_Remark.Location = New System.Drawing.Point(102, 249)
        Me.TB_Remark.Name = "TB_Remark"
        Me.TB_Remark.Size = New System.Drawing.Size(417, 23)
        Me.TB_Remark.TabIndex = 10
        '
        'TB_Spec
        '
        Me.TB_Spec.Location = New System.Drawing.Point(365, 155)
        Me.TB_Spec.Name = "TB_Spec"
        Me.TB_Spec.ReadOnly = True
        Me.TB_Spec.Size = New System.Drawing.Size(154, 23)
        Me.TB_Spec.TabIndex = 7
        '
        'TB_Qty
        '
        Me.TB_Qty.Location = New System.Drawing.Point(102, 197)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.ReadOnly = True
        Me.TB_Qty.Size = New System.Drawing.Size(145, 23)
        Me.TB_Qty.TabIndex = 8
        '
        'TB_Cost_New
        '
        Me.TB_Cost_New.Location = New System.Drawing.Point(363, 110)
        Me.TB_Cost_New.Name = "TB_Cost_New"
        Me.TB_Cost_New.Size = New System.Drawing.Size(156, 23)
        Me.TB_Cost_New.TabIndex = 0
        '
        'TB_Cost_Old
        '
        Me.TB_Cost_Old.Location = New System.Drawing.Point(102, 110)
        Me.TB_Cost_Old.Name = "TB_Cost_Old"
        Me.TB_Cost_Old.ReadOnly = True
        Me.TB_Cost_Old.Size = New System.Drawing.Size(145, 23)
        Me.TB_Cost_Old.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(294, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "材质规格:"
        '
        'TB_WL_ID
        '
        Me.TB_WL_ID.Location = New System.Drawing.Point(102, 63)
        Me.TB_WL_ID.Name = "TB_WL_ID"
        Me.TB_WL_ID.ReadOnly = True
        Me.TB_WL_ID.Size = New System.Drawing.Size(145, 23)
        Me.TB_WL_ID.TabIndex = 3
        '
        'TB_ID
        '
        Me.TB_ID.Location = New System.Drawing.Point(102, 21)
        Me.TB_ID.Name = "TB_ID"
        Me.TB_ID.Size = New System.Drawing.Size(146, 23)
        Me.TB_ID.TabIndex = 2
        '
        'TB_Name
        '
        Me.TB_Name.Location = New System.Drawing.Point(363, 63)
        Me.TB_Name.Name = "TB_Name"
        Me.TB_Name.ReadOnly = True
        Me.TB_Name.Size = New System.Drawing.Size(156, 23)
        Me.TB_Name.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(293, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "新成本价:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(16, 200)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 14)
        Me.Label24.TabIndex = 88
        Me.Label24.Text = "开单时结存:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "旧成本价:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(293, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "开单日期:"
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.ForeColor = System.Drawing.Color.Blue
        Me.Label_ID.Location = New System.Drawing.Point(58, 67)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.Size = New System.Drawing.Size(42, 14)
        Me.Label_ID.TabIndex = 91
        Me.Label_ID.Text = "编号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "单号:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(58, 255)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 14)
        Me.Label19.TabIndex = 87
        Me.Label19.Text = "备注:"
        '
        'LB_FullName
        '
        Me.LB_FullName.AutoSize = True
        Me.LB_FullName.Location = New System.Drawing.Point(321, 67)
        Me.LB_FullName.Name = "LB_FullName"
        Me.LB_FullName.Size = New System.Drawing.Size(42, 14)
        Me.LB_FullName.TabIndex = 86
        Me.LB_FullName.Text = "名称:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(293, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "参考售价:"
        '
        'LB_Contact
        '
        Me.LB_Contact.AutoSize = True
        Me.LB_Contact.Location = New System.Drawing.Point(51, 159)
        Me.LB_Contact.Name = "LB_Contact"
        Me.LB_Contact.Size = New System.Drawing.Size(49, 14)
        Me.LB_Contact.TabIndex = 84
        Me.LB_Contact.Text = "单 位:"
        '
        'LB_Area
        '
        Me.LB_Area.AutoSize = True
        Me.LB_Area.Location = New System.Drawing.Point(265, 34)
        Me.LB_Area.Name = "LB_Area"
        Me.LB_Area.Size = New System.Drawing.Size(70, 14)
        Me.LB_Area.TabIndex = 7
        Me.LB_Area.Text = "默认仓库:"
        Me.LB_Area.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel1.Text = "从"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(95, 1, 95, 2)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(17, 27)
        Me.ToolStripLabel2.Text = "到"
        '
        'DN100_BasicInfo_100141
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.Tool_Top)
        Me.Controls.Add(Me.LB_Area)
        Me.Name = "DN100_BasicInfo_100141"
        Me.Size = New System.Drawing.Size(577, 383)
        Me.Title = "成本价调整单"
        Me.Tool_Top.ResumeLayout(False)
        Me.Tool_Top.PerformLayout()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tool_Top As System.Windows.Forms.ToolStrip
    Friend WithEvents Cmd_Modify As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelMain As System.Windows.Forms.Panel
    Friend WithEvents LB_Area As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Btn_ChoseWl As System.Windows.Forms.Button
    Friend WithEvents TB_Price As System.Windows.Forms.TextBox
    Friend WithEvents TB_Remark As System.Windows.Forms.TextBox
    Friend WithEvents TB_Spec As System.Windows.Forms.TextBox
    Friend WithEvents TB_Qty As System.Windows.Forms.TextBox
    Friend WithEvents TB_Cost_New As System.Windows.Forms.TextBox
    Friend WithEvents TB_Cost_Old As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB_WL_ID As System.Windows.Forms.TextBox
    Friend WithEvents TB_ID As System.Windows.Forms.TextBox
    Friend WithEvents TB_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label_ID As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LB_FullName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LB_Contact As System.Windows.Forms.Label
    Friend WithEvents DTP_sDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TB_Unit As System.Windows.Forms.TextBox

End Class
