Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R50000_Price
    Inherits CReport
    Dim comletedCount As Integer = 0

    Protected fileName As String = "R50000_Price.grf"
    Protected fileName_CK As String = "R50000_Price_Ck.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType)

        Me.ReportFile = fileName



        Dim R As DtReturnMsg = Dao.Price_SelListById(ID, False)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        R = Dao.Price_SelById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_Header(1) = R.Dt

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub



    Sub StartList(ByVal ID As String, ByVal DoOperator As OperatorType, ByVal CK As Boolean, ByVal UnComfirm As Boolean)

        If CK = True Then
            Me.ReportFile = fileName_CK
        Else
            Me.ReportFile = fileName
        End If


        Dim R As DtReturnMsg = Dao.Price_SelListById(ID, UnComfirm)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        For Each dr As DataRow In R.Dt.Rows
            If IsNull(dr("BZ_No"), "").ToString.Contains("#") = False Then
                dr("BZ_No") = ""
            End If
        Next
        Dt_List = R.Dt

        R = Dao.Price_GetById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_Header(1) = R.Dt

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub



End Class
#Region "数据库交换"

Partial Friend Class Dao
    ''' <summary>
    ''' 获取对采购单信息-打印用
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Price_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_Price_SelByid, "@ID", sId)
    End Function


End Class


#End Region