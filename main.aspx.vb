
Partial Class main
    Inherits System.Web.UI.Page

    Public Shared mychefi As New MyChef
    Public Shared mysqli As New Mysql

    Private Sub main_Init(sender As Object, e As EventArgs) Handles Me.Init


        If mylabelinfo.Text = "" Then
            If Session("gEncrUserName") Is Nothing Then
                Response.Redirect("default.aspx")
            Else
                mylabelinfo.Text = Session("gEncrUserName")
            End If
        End If
    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function Getdata(ByVal ix As String, ByVal flg As String) As String
        Dim NSTR As String
        Try
            Dim data = mychefi.Implanp(mysqli.EEncryp(ix), flg)
            NSTR = data

            'Dim cookieCode As HttpCookie = New HttpCookie("webSound", flg)
            'Response.SetCookie(cookieCode)

        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function Getdata01(ByVal a As String, ByVal b As String, ByVal c As String) As String
        Dim NSTR As String = ""
        Try
            Dim data = mychefi.Implanq(a, b, c)
        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function


End Class
