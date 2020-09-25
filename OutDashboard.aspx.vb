
Partial Class OutDashboard
    Inherits System.Web.UI.Page

    Dim mychef As New MyChef
    Dim mysql As New Mysql
    Public Shared mychefi As New MyChef

    Public stringCompleteLine As String = "[0,0,0]"
    Public p1, p2, p3, p4, p5, p6, p7, a1, a2, a3, a4, a5, a6, a7 As String
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
            Session("gUserName") = mysql.EDecrypt(mydata.Tables(0).Rows(0).Item("manp01"))
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


        mydata = mychef.Graphpieo(mylabelinfo1.Text)
        If mydata.Tables(0).Rows.Count = 0 Then
            p1 = 0
            p2 = 0
            p3 = 0
            p4 = 0
            p5 = 0
            p6 = 0
            p7 = 0
            a1 = 0
            a2 = 0
            a3 = 0
            a4 = 0
            a5 = 0
            a6 = 0
            a7 = 0
        Else
            p1 = mydata.Tables(0).Rows(0).Item("jactual")
            a1 = mydata.Tables(0).Rows(0).Item("jplan") - mydata.Tables(0).Rows(0).Item("jactual")
            p2 = mydata.Tables(0).Rows(1).Item("jactual")
            a2 = mydata.Tables(0).Rows(1).Item("jplan") - mydata.Tables(0).Rows(1).Item("jactual")
            p3 = mydata.Tables(0).Rows(2).Item("jactual")
            a3 = mydata.Tables(0).Rows(2).Item("jplan") - mydata.Tables(0).Rows(2).Item("jactual")
            p4 = mydata.Tables(0).Rows(3).Item("jactual")
            a4 = mydata.Tables(0).Rows(3).Item("jplan") - mydata.Tables(0).Rows(3).Item("jactual")
            p5 = mydata.Tables(0).Rows(4).Item("jactual")
            a5 = mydata.Tables(0).Rows(4).Item("jplan") - mydata.Tables(0).Rows(4).Item("jactual")
            p6 = mydata.Tables(0).Rows(5).Item("jactual")
            a6 = mydata.Tables(0).Rows(5).Item("jplan") - mydata.Tables(0).Rows(5).Item("jactual")
            p7 = mydata.Tables(0).Rows(6).Item("jactual")
            a7 = mydata.Tables(0).Rows(6).Item("jplan") - mydata.Tables(0).Rows(6).Item("jactual")
        End If


        stringCompleteLine = mychef.Graphlinecompleteo(mylabelinfo1.Text)

        MENU0000.HRef = "main.aspx?ix=" & myix


        'Dim sb As New System.Text.StringBuilder()
        'sb.Append("<script type = 'text/javascript'>")
        'sb.Append("window.onload=function(){")
        'sb.Append("drawpie('donutchart1'," & p1 & " ," & a1 & " , 'Complete', 'Outstanding');")
        'sb.Append("drawpie('donutchart2'," & p2 & " ," & a2 & " , 'Hit', 'No Hit');")
        'sb.Append("drawpie('donutchart3'," & p3 & " ," & a3 & " , 'Hit', 'No Hit');")
        'sb.Append("drawpie('donutchart4'," & p4 & " ," & a4 & " , 'Hit', 'No Hit');")
        'sb.Append("drawpie('donutchart5'," & p5 & " ," & a5 & " , 'Hit', 'No Hit');")
        'sb.Append("drawpie('donutchart6'," & p6 & " ," & a6 & " , 'Hit', 'No Hit');")
        'sb.Append("drawpie('donutchart7'," & p7 & " ," & a7 & " , 'Hit', 'No Hit');")

        'sb.Append("};")
        'sb.Append("</script>")
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "draw_pie", sb.ToString())

    End Sub



End Class
