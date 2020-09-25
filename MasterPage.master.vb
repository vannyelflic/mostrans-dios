
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Public myix As String
    Dim mychef As New MyChef
    Dim mysql As New Mysql
    Private Sub MasterPage_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Request.QueryString("ix") Is Nothing Then
            Response.Redirect("default.aspx")
        ElseIf IsDBNull(Request.QueryString("ix")) Then
            Response.Redirect("default.aspx")
        Else
            myix = Request.QueryString("ix")
        End If
        Dim CompID As String = ""
        Try
            CompID = Request.Cookies("webSiteUnique").Value
        Catch ex As Exception
            Response.Redirect("default.aspx")
        Finally
        End Try

        MyIXText.Text = myix
        Dim mydata As Data.DataSet = mychef.XXLogin(CompID, myix)
        Dim myattr As String = "        "
        If mydata.Tables(0).Rows.Count = 0 Then
            Response.Redirect("default.aspx")
        Else
            Session("gEncrUserName") = mydata.Tables(0).Rows(0).Item("manp01")
            Session("gKodeDC") = mydata.Tables(0).Rows(0).Item("rdc")
            Session("gUserName") = mysql.EDecrypt(mydata.Tables(0).Rows(0).Item("manp01"))
            myattr = mysql.EDecrypt(mydata.Tables(0).Rows(0).Item("attribute1"))

            If mydata.Tables(0).Rows(0).Item("attribute6") = "Y" Then
                imgsound.Src = "images/sound.png"
                Session("gSound") = "Y"
            Else
                imgsound.Src = "images/soundoff.png"
                Session("gSound") = "N"
            End If

        End If


        ' Menu0301.HRef = "arrivali.aspx?ix=" & myix
        Menu0101.HRef = "lcdinbound.aspx?ix=" & myix
        Menu0102.HRef = "lcdoutbound.aspx?ix=" & myix
        Menu0103.HRef = "prosesdata.aspx?ix=" & myix & "&ux=" & Session("gKodeDC")
        Menu0201.HRef = "outboundplan.aspx?ix=" & myix
        Menu0210.HRef = "mstexpedisi.aspx?ix=" & myix
        Menu0301.HRef = "arrivali.aspx?ix=" & myix
        Menu0302.HRef = "arrivalo.aspx?ix=" & myix
        Menu0401.HRef = "doci.aspx?ix=" & myix
        Menu0402.HRef = "tuni.aspx?ix=" & myix
        Menu0403.HRef = "suni.aspx?ix=" & myix
        Menu0404.HRef = "funi.aspx?ix=" & myix
        Menu0501.HRef = "docko.aspx?ix=" & myix
        Menu0601.HRef = "OutDashboard.aspx?ix=" & myix
        Menu9500.HRef = "callq.aspx?ix=" & myix & "&ux=" & Session("gKodeDC")

        '001 Admin team digital  A001 Wn2w4rWU0d0cs6nXJELpYw==     I001 Ju32i8fVU4ExKoJP8Xi0Zg==
        '002 admin team rdc      A002 juWmRZ7Mt0G1gngSWkn9Rg==     I002 dqEJ7gWST1NSwlNUWNzWqQ==
        '003 security            A003 PRQlEOnfUsUUFsckMAHJag==     I003 eRrTvuxw9VQbDfCHTQIH/g==
        '  Supervisor            A004 5c9LmsbZGoOuu8CaXU5Naw==     I004 HizD9a8qI8A8vz9g2yy4Vw==
        If myattr.Substring(1, 3) = "003" Then
            'Menu0100.Visible = False
            Menu0200.Visible = False
            Menu0400.Visible = False
            Menu0500.Visible = False
            Menu0600.Visible = False
            Menu9500.Visible = False
            Menu0103.Visible = False
        ElseIf myattr.Substring(1, 3) = "002" Then
            Menu0300.Visible = False
        ElseIf myattr.Substring(1, 3) = "004" Then
            Menu0200.Visible = False
            Menu0302.Visible = False
            Menu0500.Visible = False
            Menu9500.Visible = False
            Menu0103.Visible = False
        End If


        infologin.InnerText = UCase(Session("gUserName")) & " | " & Session("gKodeDC") & " | " & Now.ToString("dd-MMM-yyyy HH:mm:ss")

    End Sub


End Class

