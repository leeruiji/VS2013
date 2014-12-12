Public Class StripButton
    Inherits System.Windows.Forms.ToolStripButton

    Private _StoreNo As String
    Private _Qty As Integer '余条数
    Private _IQty As Integer  '入库条数
    Private _OQty As Integer  '配布条数
    Public Property Qty() As Integer
        Get
            Return _Qty
        End Get
        Set(ByVal value As Integer)
            _Qty = value
        End Set
    End Property


    Public Property IQty() As Integer
        Get
            Return _IQty
        End Get
        Set(ByVal value As Integer)
            _IQty = value
        End Set
    End Property


    Public Property OQty() As Integer
        Get
            Return _OQty
        End Get
        Set(ByVal value As Integer)
            _OQty = value
        End Set
    End Property


    Public Property StoreNo() As String
        Get
            Return _StoreNo
        End Get
        Set(ByVal value As String)
            _StoreNo = value
        End Set
    End Property







End Class
