
Partial Class lcdinbound
    Inherits System.Web.UI.Page

    Dim mychef As New MyChef
    Public Shared mychefi As New MyChef
    Dim mysql As New Mysql
    Public myix As String

    Private Sub lcdinbound_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim CompID As String = ""
        Try
            CompID = Request.Cookies("webSiteUnique").Value
        Catch ex As Exception
            Response.Redirect("default.aspx")
        Finally
        End Try

        If Request.QueryString("ix") Is Nothing Then
            Response.Redirect("default.aspx")
        ElseIf IsDBNull(Request.QueryString("ix")) Then
            Response.Redirect("default.aspx")
        Else
            myix = Request.QueryString("ix")
        End If

        Dim mydata As Data.DataSet = mychef.XXLogin(CompID, myix)
        If mydata.Tables(0).Rows.Count = 0 Then
            Response.Redirect("default.aspx")
        Else
            Session("gEncrUserName") = mydata.Tables(0).Rows(0).Item("manp01")
            Session("gKodeDC") = mydata.Tables(0).Rows(0).Item("rdc")
            Session("gUserName") = Mysql.EDecrypt(mydata.Tables(0).Rows(0).Item("manp01"))
        End If


        If mylabelinfo.Text = "" Then
            If Session("gEncrUserName") Is Nothing Then
                Response.Redirect("default.aspx")
            Else
                mylabelinfo.Text = Session("gEncrUserName")
                Dim mydat As New Data.DataSet
                mydat = mychef.XLogin(mylabelinfo.Text)
                If mydat.Tables(0).Rows.Count > 0 Then
                    mylabelinfo1.Text = mydat.Tables(0).Rows(0).Item("rdc")
                End If
            End If
        End If

        MENU0000.HRef = "main.aspx?ix=" & myix

        Dim mystr As String = mychef.WiMonitoring(mylabelinfo1.Text)
        mystr = ""

    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function Getdata(ByVal nama As String) As String
        Dim NSTR As String
        Try
            Dim data = mychefi.WiMonitoring(nama)
            NSTR = data
        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function

End Class
