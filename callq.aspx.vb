
Partial Class callq
    Inherits System.Web.UI.Page

    Public mysql As New Mysql
    Public mychef As New MyChef
    Public Shared mychefi As New MyChef
    Public mydata As Data.DataSet

    <System.Web.Services.WebMethod()>
    Public Shared Function Getdata(ByVal nama As String) As String
        Dim NSTR As String
        Try
            Dim data = mychefi.Wplanq(nama)
            NSTR = data
        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function Getdata01(ByVal nama As String) As String
        Dim NSTR As String
        Try
            Dim data = mychefi.Wplanq01(nama)
            NSTR = data
        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function


End Class
