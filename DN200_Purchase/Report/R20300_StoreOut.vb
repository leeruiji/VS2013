Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R20300_StoreOut
    Inherits CReport
    Dim comletedCount As Integer = 0
    Protected fileName_Ohter As String = "R20300_StoreOut_Other.grf"
    Protected fileName_TuiLiao As String = "R20310_StoreOut_LingLiao.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal ID As String, ByVal DoOperator As OperatorType, ByVal _Type As Enum_StoreOut_Type)
        Select Case _Type
            Case Enum_StoreOut_Type.Other
                Me.ReportFile = fileName_Ohter
            Case Enum_StoreOut_Type.LingLiao
                Me.ReportFile = fileName_TuiLiao
            Case Else
                Me.ReportFile = fileName_Ohter


        End Select
        Dim R As DtReturnMsg = Dao.StoreOut_SelListById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        R = Dao.StoreOut_SelById(ID)
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
    Public Shared Function StoreOut_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_StoreOut_SelByid, "@ID", sId)
    End Function


End Class


#End Region

