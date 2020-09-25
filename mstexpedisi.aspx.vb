
Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Partial Class mstexpedisi
    Inherits System.Web.UI.Page

    Public mychef As New MyChef
    Public mysql As New Mysql
    Dim mydata As Data.DataSet


    Sub MyRefresh()

        Dim myhtml As New StringBuilder
        myhtml.Clear()
        myplc.Controls.Clear()


        myhtml.Append(" <table id='mytable' class='stripe row-border order-column' cellspacing='0' width='100%'> ")
        myhtml.Append("   <thead>")
        myhtml.Append("<tr>")
        myhtml.Append("<th >Kode Ekspedisi</th>")
        myhtml.Append("<th ></th>")
        myhtml.Append("<th >Nama Ekspedisi</th>")
        myhtml.Append("<th >Spelling Nama Expedisi</th>")
        myhtml.Append("<th >Email</th>")
        myhtml.Append("<th >No WA</th>")
        myhtml.Append("<th >User ID</th>")
        myhtml.Append("<th >Password</th>")
        myhtml.Append("</tr>")
        myhtml.Append("   </thead>")
        myhtml.Append("   <tbody>")
        Dim mydata As Data.DataSet

        mydata = mychef.Mstexpedisi
        Dim Temps As String = ""
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            myhtml.Append("<tr>")
            With mydata.Tables(0).Rows(i)

                Temps = .Item("expcode") & "|" & .Item("expname") & "|" & .Item("expnamespell") & "|" & .Item("email") &
                    .Item("hpWA") & "|" & .Item("UserID")

                myhtml.Append("<td>" & .Item("expcode") & "</td>")
                myhtml.Append("<td><button type='button' class='button2xx' data-book-id='" & Temps & "' data-target='#formModalEdit' data-toggle='modal' style='font-size:16px'>&#9997;</button></td>")
                myhtml.Append("<td>" & .Item("expname") & "</td>")
                myhtml.Append("<td>" & .Item("expnamespell") & "</td>")
                myhtml.Append("<td>" & .Item("email") & "</td>")
                myhtml.Append("<td>" & .Item("hpWA") & "</td>")
                myhtml.Append("<td>" & .Item("userID") & "</td>")
                myhtml.Append("<td>" & .Item("userPass") & "</td>")

            End With
            myhtml.Append("</tr>")
        Next
        myhtml.Append("   </tbody>")
        myhtml.Append(" </table>")

        myplc.Controls.Add(New Literal() With {
          .Text = myhtml.ToString()
         })



    End Sub

    Private Sub mstexpedisi_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("gUserName") Is Nothing Then
            Response.Redirect("default.aspx")
        ElseIf IsDBNull(Session("gUserName")) Then
            Response.Redirect("default.aspx")
        End If

    End Sub

    Private Sub mstexpedisi_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MyRefresh()
        End If

    End Sub
End Class
