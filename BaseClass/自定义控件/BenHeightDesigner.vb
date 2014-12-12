Imports System.Windows.Forms.Design

Public Class BenHeightDesigner
    Inherits System.Windows.Forms.Design.ControlDesigner
    Public Sub New()
    End Sub


    Public Overrides ReadOnly Property SelectionRules() As SelectionRules
        Get
            '不允许调整控件的高度，具体说明详见MSDN。
            Try
                If CObj(Me.Control).AutoFixSize Then
                    Return SelectionRules.Visible Or SelectionRules.Moveable Or SelectionRules.LeftSizeable Or SelectionRules.RightSizeable
                Else
                    Return SelectionRules.Visible Or SelectionRules.Moveable Or Windows.Forms.Design.SelectionRules.AllSizeable
                End If
            Catch ex As Exception
                Return SelectionRules.Visible Or SelectionRules.Moveable Or Windows.Forms.Design.SelectionRules.AllSizeable
            End Try
        End Get
    End Property
End Class

