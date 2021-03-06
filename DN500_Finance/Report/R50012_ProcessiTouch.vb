﻿Imports System.Data
Imports PClass
Imports BaseClass
Imports PClass.PClass
Imports System.Text
Public Class R50012_ProcessiTouch
    Inherits CReport
    Dim comletedCount As Integer = 0

    Protected fileName As String = "R50012_ProcessiTouchPrice.grf"
    Dim FirstDate As Date
    Dim LastDate As Date


    Sub New()
        ReDim Dt_Header(1)

    End Sub


    Sub Start(ByVal ID As String, ByVal Comfirm As String, ByVal DoOperator As OperatorType)

        Me.ReportFile = fileName



        Dim R As DtReturnMsg = Dao.ProcessiTouch_SelByWL(ID, Comfirm)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_List = R.Dt

        R = Dao.ProcessiTouch_SelById(ID)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        Dt_Header(1) = R.Dt

        Me.DoOperator = DoOperator
        Me.DoWork()
    End Sub



    Sub StartList(ByVal ID As String, ByVal DoOperator As OperatorType, Optional ByVal UnComfirm As Boolean = False)

        Me.ReportFile = fileName


        Dim R As DtReturnMsg = Dao.ProcessiTouch_SelListById(ID, UnComfirm)
        If R.IsOk = False Then
            MsgBox(R.Msg)
            Exit Sub
        End If
        'For Each dr As DataRow In R.Dt.Rows
        '    If IsNull(dr("SGGY_No"), "").ToString.Contains("#") = False Then
        '        dr("SGGY_No") = ""
        '    End If
        'Next
        Dt_List = R.Dt

        R = Dao.ProcessiTouch_GetById(ID)
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
    Public Shared Function ProcessiTouch_SelById(ByVal sId As String) As DtReturnMsg
        Return PClass.PClass.SqlStrToDt(SQL_ProcessiTouch_SelListByid, "@ID", sId)
    End Function

    ''' <summary>
    ''' 获取已确认的
    ''' </summary>
    ''' <param name="sId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProcessiTouch_SelByWL(ByVal sId As String, Optional ByVal Confirm As String = "") As DtReturnMsg
        SQlConfirm = Confirm
        Dim SQL_Get_Comfirm_PSG_ID As String = " select L.*,SGGY_No,SGGY_Name,WL.WL_Spec ,WL.WL_Name +'/'+WL.WL_No AS WL,YL.Qty     " & _
                                                          "  from  T50013_SGPrice_List L   left join T10035_SGGY SG on L.SG_ID=SG.ID  " & _
                                                          "  left join T10036_SGGYList YL ON YL.ID =SG .ID AND YL.Color ='杂色'  LEFT JOIN T10001_WL WL ON WL.ID =YL.WL_ID " & _
                                                          " where L.ID=@ID and L.IsComfirm=1 and IsLastPrice=1 order by L.ID ,L.Line "

        Return PClass.PClass.SqlStrToDt(SQL_Get_Comfirm_PSG_ID, "@ID", sId)
    End Function
End Class


#End Region