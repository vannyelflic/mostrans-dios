
Partial Class tuni
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

                Dim a As String = VB_click(myvp(0), myvp(1), myvp(2))
            End If
        End If


        mydata = mychef.top3tunda(Session("gKodeDC"))



        Dim myhtml As New StringBuilder
        myhtml.Append(" <p><table id='mytable' cellspacing='0' width='100%'> ")
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
            myhtml.Append("<td colspan='5' Style='text-align: center'>")
            myhtml.Append("</td>")
            myhtml.Append("<td Style='text-align: center'>")
            myhtml.Append("<input style='width:200px' type = 'button' id='btnbataltunda" & i & "' name='btnbataltunda" & i & "' value='Batalkan Penundaan' runat='server' onclick='JS_click(" & Chr(34) & "BATALTUNDA" & Chr(34) & "," & Chr(34) & Session("gKodeDC") & Chr(34) & "," & Chr(34) & mydata.Tables(0).Rows(i).Item("noantrian") & Chr(34) & ")' />")
            myhtml.Append("</td>")
            myhtml.Append("<td colspan='3'>&nbsp;</td>")
            myhtml.Append("</tr>")
        Next
        myhtml.Append(" </table></p>")

        myplc.Controls.Add(New Literal() With {
          .Text = myhtml.ToString()
         })

    End Sub

    Public Function VB_click(ByVal a As String, ByVal b As String, ByVal c As String) As String
        Dim myempty As String = mychef.mybtn01(a, b, c, Session("gUserName"), "")
        VB_click = ""
    End Function

End Class
