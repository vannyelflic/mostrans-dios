
Partial Class wsi1
    Inherits System.Web.UI.Page

    Dim mychef As New MyChef

    Private Sub wsi1_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbl01.Text = mychef.wsi1
    End Sub
End Class
