
Partial Class suni
    Inherits System.Web.UI.Page

    Public mysql As New mysql
    Public mychef As New MyChef
    Public mydata As Data.DataSet

    Private Sub doci_Init(sender As Object, e As EventArgs) Handles Me.Init
    End Sub

    Private Sub doci_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.ClientScript.GetPostBackEventReference(Me, String.Empty)


        If Me.IsPostBack Then
            Dim eventTarget As String
            Dim eventArgument As String

            If Me.Request("__EVENTTARGET") Is Nothing Then
                eventTarget = String.Empty
            Else
                eventTarget = Me.Request("__EVENTTARGET")
            End If

            If Me.Request("__EVENTARGUMENT") Is Nothing Then
                eventArgument = String.Empty
            Else
                eventArgument = Me.Request("__EVENTARGUMENT")
            End If

            If eventTarget = "CustomPostBack" Then
                Dim valuePassed As String = eventArgument
                Dim myvp = Split(valuePassed, "~")

                Dim a As String = VB_click(myvp(0), myvp(1), myvp(2), myvp(3))
            End If
        End If

        Dim mypetugas As String = ""
        mydata = mychef.Petugas(Session("gKodeDC"))
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            mypetugas = mypetugas & "<option value='" & mydata.Tables(0).Rows(i).Item("dc_petugas") & "'>" & mydata.Tables(0).Rows(i).Item("dc_petugas") & "</option>"
        Next

        mydata = mychef.top3sunload(Session("gKodeDC"))


        Dim myhtml As New StringBuilder
        myhtml.Append("<p> <table id='mytable' cellspacing='0' width='100%'> ")
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            myhtml.Append("<tr>")
            myhtml.Append("<td Style='text-align: left'>No. Antrian</td><td Style='color:red; text-align: left'>" & mydata.Tables(0).Rows(i).Item("noantrian") & "</td>")
            myhtml.Append("<td Style='text-align: left'>Nama Ekspedisi</td><td Style='text-align: left'>" & mydata.Tables(0).Rows(i).Item("expname") & "</td>")
            myhtml.Append("<td Style='text-align: left'>Jenis Kendaraan</td><td Style='text-align: left'>" & mydata.Tables(0).Rows(i).Item("jeniskend") & "</td>")
            myhtml.Append("</tr>")
            myhtml.Append("<tr>")
            myhtml.Append("<td Style='text-align: left'>No. Kendaraan</td><td Style='text-align: left'>" & mydata.Tables(0).Rows(i).Item("nokend") & "</td>")
            myhtml.Append("<td Style='text-align: left'>Waktu Kedatangan</td><td Style='text-align: left'>" & Format(mydata.Tables(0).Rows(i).Item("kedatangan"), "dd-MMM-yy HH-mm") & "</td>")
            myhtml.Append("<td Style='text-align: left'>Jenis Antrian</td><td Style='text-align: left'>" & mydata.Tables(0).Rows(i).Item("tipeantrian") & "</td>")
            myhtml.Append("</tr>")
            myhtml.Append("<tr>")
            myhtml.Append("<td colspan='2' Style='text-align: center'>")
            myhtml.Append("<td Style='text-align: right'>Checker : </td>")

            myhtml.Append("<td Style='text-align: left'>")
            myhtml.Append("<select id='mysel_" & mydata.Tables(0).Rows(i).Item("noantrian") & "'>")
            myhtml.Append(mypetugas & "</select>")
            myhtml.Append("</td>")

            myhtml.Append("<td Style='text-align: center'>")
            If i = 0 Then
                If Session("gSound") = "Y" Then
                    myhtml.Append("<input onclick='responsiveVoice.speak(" & Chr(34) & "Attention Please. Driver with name : " & mydata.Tables(0).Rows(i).Item("namadriver").ToString.ToLower & ". Queue Number : " & mydata.Tables(0).Rows(i).Item("noantrian") & ", Expedition : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", Vehicle Number : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", please immediately enter the gate for unloading process" & Chr(34) & ");' type='button' value='🔊 Call' style='width:100px' /> &nbsp; ")
                    myhtml.Append("<input onclick='responsiveVoice.speak(" & Chr(34) & "Panggilan untuk Pengemudi dengan nama : " & mydata.Tables(0).Rows(i).Item("namadriver").ToString.ToLower & ". Nomor Antrian : " & mydata.Tables(0).Rows(i).Item("noantrian") & ", Ekspedisi : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", Nomor Kendaraan : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", dipersilahkan segera memasuki gerbang untuk melakukan proses Bongkar Barang" & Chr(34) & "," & Chr(34) & "Indonesian Female" & Chr(34) & ");' type='button' value='🔊 Panggil' style='width:100px' />")
                Else
                    myhtml.Append("<input onclick='planQ(" & Chr(34) & "Attention Please. Driver with name : " & mydata.Tables(0).Rows(i).Item("namadriver").ToString.ToLower & ". Queue Number : " & mydata.Tables(0).Rows(i).Item("noantrian") & ", Expedition : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", Vehicle Number : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", please immediately enter the gate for unloading process" & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Session("gKodeDC") & Chr(34) & ");' type='button' value='🔊 Call' style='width:100px' /> &nbsp; ")
                    myhtml.Append("<input onclick='planQ(" & Chr(34) & "Panggilan untuk Pengemudi dengan nama : " & mydata.Tables(0).Rows(i).Item("namadriver").ToString.ToLower & ". Nomor Antrian : " & mydata.Tables(0).Rows(i).Item("noantrian") & ", Ekspedisi : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", Nomor Kendaraan : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", dipersilahkan segera memasuki gerbang untuk melakukan proses Bongkar Barang" & Chr(34) & "," & Chr(34) & "Indonesian Female" & Chr(34) & "," & Chr(34) & Session("gKodeDC") & Chr(34) & ");' type='button' value='🔊 Panggil' style='width:100px' />")
                End If
            Else
                    myhtml.Append("&nbsp;")
            End If
            myhtml.Append("</td>")
            myhtml.Append("</td>")
            myhtml.Append("<td Style='text-align: center'>")
            If i = 0 Then
                myhtml.Append("<input style='width:200px' type = 'button' id='btnsuni" & i & "' name='btnsuni" & i & "' value='Start Unloading' runat='server' onclick='JS_click(" & Chr(34) & "STARTUNLOAD" & Chr(34) & "," & Chr(34) & Session("gKodeDC") & Chr(34) & "," & Chr(34) & mydata.Tables(0).Rows(i).Item("noantrian") & Chr(34) & ")' />")
            Else
                myhtml.Append("&nbsp;")
            End If
            myhtml.Append("</td>")
            myhtml.Append("<td colspan='6'>&nbsp;</td>")
            myhtml.Append("</tr>")
        Next
        myhtml.Append(" </table></p>")

        myplc.Controls.Add(New Literal() With {
          .Text = myhtml.ToString()
         })

    End Sub

    Public Function VB_click(ByVal a As String, ByVal b As String, ByVal c As String, ByVal d As String) As String
        Dim myempty As String = mychef.mybtn01(a, b, c, Session("gUserName"), d)
        VB_click = ""
    End Function

End Class
