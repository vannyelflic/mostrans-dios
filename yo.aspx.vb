
Partial Class yo
    Inherits System.Web.UI.Page

    Dim myix As String = ""
    Dim mysql As New Mysql
    Dim mychef As New MyChef

    Private Sub yo_Init(sender As Object, e As EventArgs) Handles Me.Init
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

        Dim mydata As Data.DataSet = MyChef.XXLogin(CompID, myix)
        Dim myattr As String = "        "
        If mydata.Tables(0).Rows.Count = 0 Then
            Response.Redirect("default.aspx")
        Else
            Session("gEncrUserName") = mydata.Tables(0).Rows(0).Item("manp01")
            Session("gKodeDC") = mydata.Tables(0).Rows(0).Item("rdc")
            Session("gUserName") = Mysql.EDecrypt(mydata.Tables(0).Rows(0).Item("manp01"))
            myattr = Mysql.EDecrypt(mydata.Tables(0).Rows(0).Item("attribute1"))
        End If

        '001 Admin team digital  A001 Wn2w4rWU0d0cs6nXJELpYw==     I001 Ju32i8fVU4ExKoJP8Xi0Zg==
        '002 admin team rdc      A002 juWmRZ7Mt0G1gngSWkn9Rg==     I002 dqEJ7gWST1NSwlNUWNzWqQ==
        '003 security            A003 PRQlEOnfUsUUFsckMAHJag==     I003 eRrTvuxw9VQbDfCHTQIH/g==
        If myattr.Substring(1, 3) <> "001" Then
            Response.Redirect("default.aspx")
        End If

        If Not IsPostBack Then

            'For i = 0 To 30
            '    myid.InnerText = myid.InnerText & "<br/>"
            'Next
            mydata = mychef.listu
            For i = 0 To mydata.Tables(0).Rows.Count - 1
                myid.InnerText = myid.InnerText & mysql.EDecrypt(mydata.Tables(0).Rows(i).Item(0)) & ", "
                myid.InnerText = myid.InnerText & mysql.EDecrypt(mydata.Tables(0).Rows(i).Item(1)) & ", "
                myid.InnerText = myid.InnerText & mysql.EDecrypt(mydata.Tables(0).Rows(i).Item(2)) & ", "
                myid.InnerText = myid.InnerText & mydata.Tables(0).Rows(i).Item(3) & ", "
            Next
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = mysql.EEncryp(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = mysql.EDecrypt(TextBox1.Text)
    End Sub
End Class
