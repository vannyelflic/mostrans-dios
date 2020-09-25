
Partial Class docko
    Inherits System.Web.UI.Page

    Public mysql As New Mysql
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

                Dim a As String = VB_click(myvp(0), myvp(1), myvp(2))
            End If
        End If


        mydata = mychef.arrivalo(Session("gKodeDC"))



        Dim myhtml As New StringBuilder
        myhtml.Append("<p> <table id='mytable' cellspacing='0' width='100%' > ")
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            myhtml.Append("<tr>")
            myhtml.Append("<td Style='text-align: left'>List Picking No</td><td Style='color:red; text-align: left'>" & mydata.Tables(0).Rows(i).Item("listpick") & "</td>")
            myhtml.Append("<td Style='text-align: left'>Nama Ekspedisi</td><td Style='text-align: left; '>" & mydata.Tables(0).Rows(i).Item("expname") & "</td>")
            myhtml.Append("<td Style='text-align: left'>Jenis Kendaraan</td><td Style='text-align: left; '>" & mydata.Tables(0).Rows(i).Item("jeniskend") & "</td>")
            myhtml.Append("</tr>")
            myhtml.Append("<tr>")
            myhtml.Append("<td Style='text-align: left'>No. Kendaraan</td><td Style='text-align: left; '>" & mydata.Tables(0).Rows(i).Item("nokend") & "</td>")
            myhtml.Append("<td Style='text-align: left'>Waktu Kedatangan</td><td Style='text-align: left; '>" & Format(mydata.Tables(0).Rows(i).Item("kedatangan"), "dd-MMM-yy HH-mm") & "</td>")
            myhtml.Append("<td colspan='2' Style='text-align: left'>Dock Door &nbsp;&nbsp; ")
            If mydata.Tables(0).Rows(i).Item("dock_no") = "" Then
                myhtml.Append("<input type='text' id='dock_" & mydata.Tables(0).Rows(i).Item("listpick") & "' maxlength='4' placeholder='Dock No' style='width:80px;font-family:arial;font-size:18px;color:rgb(47,43,43)' runat='server'>")
                myhtml.Append("<input type='text' id='stage_" & mydata.Tables(0).Rows(i).Item("listpick") & "' maxlength='1' placeholder='Staging Line' style='width:150px;font-family:arial;font-size:18px;color:rgb(47,43,43)' runat='server'>")
            Else
                myhtml.Append(mydata.Tables(0).Rows(i).Item("dock_no") & "&nbsp;&nbsp;")
                myhtml.Append(mydata.Tables(0).Rows(i).Item("staging_line"))
            End If
            myhtml.Append("</td>")
            'myhtml.Append("</tr>")
            'myhtml.Append("<tr>")
            'myhtml.Append("<td colspan='4' Style='text-align: center'>")
            'myhtml.Append("<td Style='text-align: left'>Staging Line</td><td Style='text-align: left; '>")
            'If mydata.Tables(0).Rows(i).Item("dock_no") = "" Then
            '    myhtml.Append("<input type='text' id='stage_" & mydata.Tables(0).Rows(i).Item("listpick") & "' maxlength='20' placeholder='Staging Line' style='width:200px;font-family:arial;font-size:16px;color:rgb(47,43,43)' runat='server'>")
            'Else
            '    myhtml.Append(mydata.Tables(0).Rows(i).Item("staging_line"))
            'End If
            'myhtml.Append("</td>"),
            'myhtml.Append("</tr>")
            myhtml.Append("<tr>")
            myhtml.Append("<td colspan='3' Style='text-align: center'>")
            myhtml.Append("</td>")
            myhtml.Append("<td Style='text-align: center'>")
            If mydata.Tables(0).Rows(i).Item("dock_no") <> "" Then
                If Session("gSound") = "Y" Then
                    myhtml.Append("<input onclick='responsiveVoice.speak(" & Chr(34) & "Attention Please, . List Picking Number : " & mydata.Tables(0).Rows(i).Item("listpick") & ", . Expedition : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", . Vehicle Number : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", . please immediately enter the gate, . and join Dock Door " & mydata.Tables(0).Rows(i).Item("dock_no") & ", . for loading process" & Chr(34) & ");' type='button' value='🔊 Call' style='width:100px' /> &nbsp; ")
                    myhtml.Append("<input onclick='responsiveVoice.speak(" & Chr(34) & "Panggilan, . untuk Nomor List Picking : " & mydata.Tables(0).Rows(i).Item("listpick") & ", . Ekspedisi : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", . Nomor Kendaraan : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", . dipersilahkan segera memasuki gerbang, . dan menuju ke Pintu Dock " & mydata.Tables(0).Rows(i).Item("dock_no") & ", . untuk melakukan proses Muat Barang" & Chr(34) & "," & Chr(34) & "Indonesian Female" & Chr(34) & ");' type='button' value='🔊 Panggil' style='width:100px' />")
                Else
                    myhtml.Append("<input onclick='planQ(" & Chr(34) & "Attention Please, . List Picking Number : " & mydata.Tables(0).Rows(i).Item("listpick") & ", . Expedition : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", . Vehicle Number : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", . please immediately enter the gate, . and join Dock Door " & mydata.Tables(0).Rows(i).Item("dock_no") & ", . for loading process" & Chr(34) & "," & Chr(34) & Chr(34) & "," & Chr(34) & Session("gKodeDC") & Chr(34) & ");' type='button' value='🔊 Call' style='width:100px' /> &nbsp; ")
                    myhtml.Append("<input onclick='planQ(" & Chr(34) & "Panggilan, . untuk Nomor List Picking : " & mydata.Tables(0).Rows(i).Item("listpick") & ", . Ekspedisi : " & mydata.Tables(0).Rows(i).Item("expnamespell").ToString.ToLower & ", . Nomor Kendaraan : " & mydata.Tables(0).Rows(i).Item("nokend").ToString.Replace(" ", "") & ", . dipersilahkan segera memasuki gerbang, . dan menuju ke Pintu Dock " & mydata.Tables(0).Rows(i).Item("dock_no") & ", . untuk melakukan proses Muat Barang" & Chr(34) & "," & Chr(34) & "Indonesian Female" & Chr(34) & "," & Chr(34) & Session("gKodeDC") & Chr(34) & ");' type='button' value='🔊 Panggil' style='width:100px' />")
                End If
            End If
            myhtml.Append("</td>")
            myhtml.Append("<td Style='text-align: center'>&nbsp;")
            myhtml.Append("</td>")
            myhtml.Append("<td Style='text-align: center'>")
            If mydata.Tables(0).Rows(i).Item("dock_no") = "" Then
                myhtml.Append("<input style='width:200px' type = 'button' id='btnsave" & i & "' name='btnsave" & i & "' value='Simpan' runat='server'  onclick='JS_click(" & Chr(34) & mydata.Tables(0).Rows(i).Item("listpick") & Chr(34) & ")' />")
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

    Public Function VB_click(ByVal a As String, ByVal b As String, ByVal c As String) As String
        Dim myempty As String = mychef.mybtn02(a, b, c)
        VB_click = ""
    End Function

End Class
