
Partial Class lcdoutbound
    Inherits System.Web.UI.Page

    Dim mychef As New MyChef
    Dim mysql As New Mysql
    Public Shared mychefi As New MyChef
    Public myix As String
    Public mydisplaycheck As String

    Private Sub lcdinbound_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim CompID As String = ""
        Try
            CompID = Request.Cookies("webSiteUnique").Value
        Catch ex As Exception
            Response.Redirect("default.aspx")
        Finally
        End Try

        If Request.QueryString("ix") Is Nothing Then
            Response.Redirect("default.aspx")
        ElseIf IsDBNull(Request.QueryString("ix")) Then
            Response.Redirect("default.aspx")
        Else
            myix = Request.QueryString("ix")
        End If

        Dim mydata As Data.DataSet = mychef.XXLogin(CompID, myix)
        If mydata.Tables(0).Rows.Count = 0 Then
            Response.Redirect("default.aspx")
        Else
            Session("gEncrUserName") = mydata.Tables(0).Rows(0).Item("manp01")
            Session("gKodeDC") = mydata.Tables(0).Rows(0).Item("rdc")
            Session("gUserName") = mysql.EDecrypt(mydata.Tables(0).Rows(0).Item("manp01"))
        End If


        If mylabelinfo.Text = "" Then
            If Session("gEncrUserName") Is Nothing Then
                Response.Redirect("default.aspx")
            Else
                mylabelinfo.Text = Session("gEncrUserName")
                Dim mydat As New Data.DataSet
                mydat = mychef.XLogin(mylabelinfo.Text)
                If mydat.Tables(0).Rows.Count > 0 Then
                    mylabelinfo1.Text = mydat.Tables(0).Rows(0).Item("rdc")
                End If
            End If
        End If

        MENU0000.HRef = "main.aspx?ix=" & myix

        Dim mystr As String = mychef.WiMonitoring(mylabelinfo1.Text)
        mystr = ""



    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function Getdata(ByVal nama As String, ByVal strupdate As String) As String
        Dim NSTR As String
        Try
            If strupdate = "true" Then
                Dim mystr = mychefi.updateplano(nama)
            End If

            Dim data = mychefi.WoMonitoring(nama)
            NSTR = data
        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function GetdataXX(ByVal nama As String, ByVal strupdate As String, ByVal npage As String) As String
        Dim NSTR As String
        Try
            If strupdate = "true" Then
                Dim mystr = mychefi.updateplano(nama)
            End If

            Dim data = mychefi.WoMonitoringXX(nama, npage)
            NSTR = data
        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function


    <System.Web.Services.WebMethod()>
    Public Shared Function GetdataX(ByVal nama As String, ByVal listpick As String, ByVal jenis As String) As String
        Dim NSTR As String
        Try
            Dim data As Data.DataSet = mychefi.qplano(nama, listpick)
            NSTR = ""

            If jenis = "ARRIVAL" Then
                'ARRIVAL
                'dateplan
                'dateactual
                If Not IsDBNull(data.Tables(0).Rows(0).Item("dateplan")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("dateplan"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("dateactual")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("dateactual"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("dateactual")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("dateactual") > data.Tables(0).Rows(0).Item("dateplan") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If
            ElseIf jenis = "KONSOL" Then

                'KONSOL
                'plankonsol
                'actualkonsol
                If Not IsDBNull(data.Tables(0).Rows(0).Item("plankonsol")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("plankonsol"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("actualkonsol")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("actualkonsol"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("actualkonsol")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("actualkonsol") > data.Tables(0).Rows(0).Item("plankonsol") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If

            ElseIf jenis = "SPLANLOAD" Then
                'SPLANLOAD
                'splanload
                'sactualload
                If Not IsDBNull(data.Tables(0).Rows(0).Item("splanload")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("splanload"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("sactualload")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("sactualload"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("sactualload")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("sactualload") > data.Tables(0).Rows(0).Item("splanload") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If


            ElseIf jenis = "FPLANLOAD" Then
                'FPLANLOAD
                'fplanload
                'factualload
                If Not IsDBNull(data.Tables(0).Rows(0).Item("fplanload")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("fplanload"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("factualload")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("factualload"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("factualload")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("factualload") > data.Tables(0).Rows(0).Item("fplanload") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If

            ElseIf jenis = "SPLAN_SJ" Then
                'SPLAN_SJ
                'splan_sj
                'sactual_sj
                If Not IsDBNull(data.Tables(0).Rows(0).Item("splan_sj")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("splan_sj"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("sactual_sj")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("sactual_sj"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("sactual_sj")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("sactual_sj") > data.Tables(0).Rows(0).Item("splan_sj") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If

            ElseIf jenis = "FPLAN_SJ" Then
                'FPLAN_SJ
                'fplan_sj
                'factual_sj
                If Not IsDBNull(data.Tables(0).Rows(0).Item("fplan_sj")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("fplan_sj"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("factual_sj")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("factual_sj"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("factual_sj")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("factual_sj") > data.Tables(0).Rows(0).Item("fplan_sj") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If

            ElseIf jenis = "PLANPICKING" Then
                'PLANPICKING
                'planpicking
                'actualpicking
                If Not IsDBNull(data.Tables(0).Rows(0).Item("planpicking")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("planpicking"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("actualpicking")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("actualpicking"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("actualpicking")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("actualpicking") > data.Tables(0).Rows(0).Item("planpicking") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If

            ElseIf jenis = "PLANPACKING" Then
                'PLANPACKING
                'planpacking
                'actualpacking
                If Not IsDBNull(data.Tables(0).Rows(0).Item("planpacking")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("planpacking"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If Not IsDBNull(data.Tables(0).Rows(0).Item("actualpacking")) Then
                    NSTR = NSTR & Format(data.Tables(0).Rows(0).Item("actualpacking"), "HH:mm") & "~"
                Else
                    NSTR = NSTR & "~"
                End If
                If IsDBNull(data.Tables(0).Rows(0).Item("actualpacking")) Then
                    NSTR = NSTR & "W"
                ElseIf data.Tables(0).Rows(0).Item("actualpacking") > data.Tables(0).Rows(0).Item("planpacking") Then
                    NSTR = NSTR & "R"
                Else
                    NSTR = NSTR & "G"
                End If
            End If

        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function

    Private Sub lcdoutbound_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim aUser As String = mysql.EDecrypt(mylabelinfo.Text)
        If UCase(aUser) = "ADMIN" Then
            mydisplaycheck = "block"
        Else
            mydisplaycheck = "none"
        End If
    End Sub
End Class
