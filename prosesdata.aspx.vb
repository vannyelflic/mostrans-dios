
Partial Class prosesdata
    Inherits System.Web.UI.Page

    Public mysql As New Mysql
    Public mychef As New MyChef
    Public mydata As Data.DataSet


    Public Sub TimerX_TIck()
        If mycheck.Checked Then
            Dim mydc As String = Request.QueryString("ux")
            Dim mystr = mychef.updateplano(mydc)
        End If
        Timer1.Interval = 60000 * Val(txtInterval.Text)
        If Len(lblinfo.Text) > 1000 Then
            lblinfo.Text = "Waiting...." & vbCrLf
        Else
            lblinfo.Text = lblinfo.Text & "Waiting...." & vbCrLf
        End If
    End Sub

    Private Sub prosesdata_Init(sender As Object, e As EventArgs) Handles Me.Init
        Timer1.Interval = 60000 * Val(txtInterval.Text)
        Timer1.Enabled = True
    End Sub

    'Private Sub mycheck_CheckedChanged(sender As Object, e As EventArgs) Handles mycheck.CheckedChanged
    '    Dim myux As String = Request.QueryString("ux")
    '    Dim myix As String = Request.QueryString("ix")

    '    "prosesdata.aspx?ix=" & myix & "&ux=" & Session("gKodeDC")

    'End Sub
End Class
