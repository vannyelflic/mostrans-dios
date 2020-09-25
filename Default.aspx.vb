
Partial Class _Default
    Inherits System.Web.UI.Page


    Dim MySql As New mysql
    Dim MyChef As New MyChef
    Dim mydata As New Data.DataSet


    Private Sub cmdLetMeIn_ServerClick(sender As Object, e As EventArgs) Handles cmdLetMeIn.ServerClick
        Dim CompID As String = Convert.ToString(Guid.NewGuid())

        Dim uniq As HttpCookie = New HttpCookie("webSiteUnique")
        uniq.Value = CompID
        Response.Cookies.Add(uniq)

        'Dim MySound As HttpCookie = New HttpCookie("webSound") With {
        '    .Value = "Y"
        '}


        If txtPass.Value <> "" And txtUserName.Value <> "" Then
            Dim myusername As String = MySql.bersih(txtUserName.Value)
            Dim mypass As String = MySql.bersih(txtPass.Value)
            mydata = MyChef.WLogin(myusername, mypass)
            If mydata.Tables(0).Rows.Count > 0 Then
                Session("gUserName") = myusername
                Session("gEncrUserName") = MySql.EEncryp(myusername)
                Session("gKodeDC") = mydata.Tables(0).Rows(0).Item("RDC")
                javamessage("Login berhasil")

                Dim RndStr As String = MySql.ERndSTr
                MyChef.iplanp(MySql.EEncryp(RndStr), MySql.EEncryp(CompID), MySql.EEncryp(Session("gEncrUserName")))

                Response.Redirect("main.aspx?ix=" & RndStr)
            Else
                javamessage("Login gagal")
            End If
        Else
            javamessage("Login gagal")
        End If


    End Sub

    Sub javamessage(ByVal mymessage As String)

        ' Define the name and type of the client scripts on the page.
        Dim csname1 As String = "PopupScript"
        Dim csname2 As String = "ButtonClickScript"
        Dim cstype As Type = Me.GetType()
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        ' Check to see if the startup script is already registered.
        If (Not cs.IsStartupScriptRegistered(cstype, csname1)) Then

            Dim cstext1 As String = ""

            'If strNomorPO = "" And (nilaiAdaHutang > 0 And (strTanggalBayar = "" Or strKeteranganBayar = "")) Then
            '    cstext1 = "alert('Nomor PO dan Tanggal/Keterangan Bayar tidak boleh kosong');"
            'ElseIf strNomorPO = "" Then
            '    cstext1 = "alert('Nomor PO tidak boleh kosong');"
            'Else
            '    cstext1 = "alert('Tanggal/Keterangan Bayar tidak boleh kosong');"
            'End If

            cstext1 = "alert('" & mymessage & "');"

            cs.RegisterStartupScript(cstype, csname1, cstext1, True)
        End If
        ' Check to see if the client script is already registered.
        If (Not cs.IsClientScriptBlockRegistered(cstype, csname2)) Then
            Dim cstext2 As New StringBuilder()
            cstext2.Append("<script type=""text/javascript""> function DoClick() {")
            cstext2.Append("Form1.Message.value='Text from client script.'} </")
            cstext2.Append("script>")
            cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), False)
        End If

    End Sub


End Class
