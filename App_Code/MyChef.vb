Imports System
Imports System.Web.Services
Imports Microsoft.VisualBasic

Public Class MyChef

    Dim StrSQL As String
    Dim GetData As New Mysql
    Dim GetOra As New Emosora

    <WebMethod(Description:="Proc a()")>
    Public Function WLogin(ByVal p_user As String, ByVal p_pass As String) As Data.DataSet

        Dim myusernameenc As String = GetData.EEncryp(p_user)
        Dim mypassenc As String = GetData.EEncryp(p_pass)

        '001 Admin team digital  A001 Wn2w4rWU0d0cs6nXJELpYw==     I001 Ju32i8fVU4ExKoJP8Xi0Zg==
        '002 admin team rdc      A002 juWmRZ7Mt0G1gngSWkn9Rg==     I002 dqEJ7gWST1NSwlNUWNzWqQ==
        '003 security            A003 PRQlEOnfUsUUFsckMAHJag==     I003 eRrTvuxw9VQbDfCHTQIH/g==

        StrSQL = "select * from dc_manp where manp01='" & myusernameenc & "' and manp02='" & mypassenc & "' "  'and shiftflag='A' "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        If dtSQL.Tables(0).Rows.Count > 0 Then
            Dim myaktif As String = GetData.EDecrypt(dtSQL.Tables(0).Rows(0).Item("attribute1"))
            If myaktif.Substring(0, 1) <> "A" Then
                StrSQL = "select * from dc_manp where 1=2"
                dtSQL = GetData.CreateDataSet(StrSQL)
            End If
        End If
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function WMCab() As Data.DataSet
        StrSQL = "select * from dc_cab order by namacab"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function WMExp() As Data.DataSet
        StrSQL = "select * from dc_expedisi order by expname"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function WMKend() As Data.DataSet
        StrSQL = "select * from dc_jeniskend order by jeniskend"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function WSEQ(ByVal mydc As String) As String
        Dim myyear As String = Now.ToString("ÿy")
        Dim nmonth As Integer = Asc("A") + Now.Month - 1
        Dim mymonth As String = Chr(nmonth)
        Dim myprd As String = Right(myyear, 1) & mymonth
        Dim myres As String = ""
        StrSQL = "select seq from dc_seq where kodedc='" & mydc & "' and prd='" & myprd & "'"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        If dtSQL.Tables(0).Rows.Count = 0 Then
            myres = myprd & "001"
            StrSQL = "insert into dc_seq (kodedc,prd,seq) values ('" & mydc & "','" & myprd & "',2)"
            GetData.ExecuteDataSQL(StrSQL)
        Else
            myres = myprd & Right("000" & dtSQL.Tables(0).Rows(0).Item(0).ToString.Trim, 3)
            StrSQL = "update dc_seq set seq=seq+1 where kodedc='" & mydc & "' and prd='" & myprd & "'"
            GetData.ExecuteDataSQL(StrSQL)
        End If
        WSEQ = myres
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function Wi(ByVal kodedc As String, ByVal noantrian As String, ByVal expcode As String, ByVal kodekend As String,
                       ByVal nokend As String, ByVal namadriver As String, ByVal pkedatangan As String, ByVal tpantrian As String, ByVal expname As String) As String
        Dim myerr As String = ""
        Dim Xexpcode As String = ""
        Try

            If expcode = "" Then
                StrSQL = "select top 1 mynum from dc_mstexpedisi"
                Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
                If dtSQL.Tables(0).Rows.Count = 0 Then
                    Xexpcode = "X00001"
                    StrSQL = "insert into dc_mstexpedisi (txtnum,mynum) values ('EXP',1)"
                    GetData.ExecuteDataSQL(StrSQL)
                Else
                    Xexpcode = "X" & ("0000" & (dtSQL.Tables(0).Rows(0).Item("mynum") + 1).ToString.Trim).Substring(("0000" & (dtSQL.Tables(0).Rows(0).Item("mynum") + 1).ToString.Trim).Length - 5, 5)
                    StrSQL = "update dc_mstexpedisi set mynum=mynum+1 where txtnum='EXP'"
                    GetData.ExecuteDataSQL(StrSQL)
                End If
                StrSQL = "insert into dc_expedisi (expcode,expname,expnamespell) values ('" & Xexpcode & "','" & expname.ToUpper & "','" & expname.ToLower & "')"
                GetData.ExecuteDataSQL(StrSQL)
            Else
                Xexpcode = expcode
            End If

            StrSQL = "insert into dc_kedatangani (kodedc,noantrian,expcode,kodekend,nokend,namadriver,kedatangan,pkedatangan,tpantrian,flagstatus) values " &
            "('" & kodedc & "','" & noantrian & "','" & Xexpcode & "','" & kodekend & "','" & nokend & "','" & namadriver & "'," &
            "getdate(),'" & pkedatangan & "','" & tpantrian & "','20')"
            GetData.ExecuteDataSQL(StrSQL)
        Catch ex As Exception
            myerr = "1" & ex.Message
        Finally
            myerr = "0Data berhasil disimpan"
        End Try
        Return myerr
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function Wo(ByVal listpick As String, ByVal kodedc As String, ByVal expcode As String, ByVal kodekend As String,
                       ByVal nokend As String, ByVal namadriver As String, ByVal pkedatangan As String) As String
        Dim myerr As String = ""
        Try
            StrSQL = "select 1 from dc_kedatangano where listpick='" & listpick & "' "
            Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
            If dtSQL.Tables(0).Rows.Count = 0 Then
                StrSQL = "insert into dc_kedatangano (listpick,kodecaba,expcode,kodekend,nokend,namadriver,kedatangan,pkedatangan) values " &
                "('" & listpick & "','" & kodedc & "','" & expcode & "','" & kodekend & "','" & nokend & "','" & namadriver & "'," &
                "getdate(),'" & pkedatangan & "')"
                GetData.ExecuteDataSQL(StrSQL)
                StrSQL = "update dc_plano set dateactual=getdate() where listpick='" & listpick & "'"
                GetData.ExecuteDataSQL(StrSQL)
            Else
                myerr = "1Data tidak berhasil disimpan"
            End If
        Catch ex As Exception
            myerr = "1" & ex.Message
        Finally
            If myerr = "" Then
                myerr = "0Data berhasil disimpan"
            End If
        End Try
        Return myerr
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function Wwo(ByVal listpick As String, ByVal kodedc As String, ByVal expcode As String, ByVal kodekend As String) As String
        Dim myerr As String = ""
        StrSQL = "select 1 from dc_plano where listpick='" & listpick & "' and kodecaba='" & kodedc & "' and " &
            " expcode='" & expcode & "' and kodekend='" & kodekend & "' and convert(DATE,dateplan)=convert(DATE,getdate()) and dateactual is null"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        If dtSQL.Tables(0).Rows.Count = 0 Then
            myerr = "1"
        Else
            myerr = "0"
        End If
        Return myerr
    End Function



    <WebMethod(Description:="Proc a()")>
    Public Function WiMonitoring(ByVal mydc As String) As String
        Dim mystr As String = ""
        Dim i As Integer
        Dim ic As Integer = 15
        StrSQL = "select top " & ic & " * from kedatangani_v where kodedc='" & mydc & "' and flgstatus<>'Cancel' and (datediff(minute,finunload,getdate())<11 or finunload is null) order by flagstatus,tpantrian,noantrian"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        With dtSQL.Tables(0)
            If .Rows.Count > 0 Then
                mystr = .Rows(0).Item(0) & "~" & .Rows(0).Item(1) & "~" &
                .Rows(0).Item(2) & "~" & .Rows(0).Item(3) & "~" &
                Format(.Rows(0).Item(4), "dd-MMM HH:mm") & "~"
                If IsDBNull(.Rows(0).Item(5)) Then
                    mystr = mystr & "~"
                Else
                    mystr = mystr & Format(.Rows(0).Item(5), "dd-MMM HH:mm") & "~"
                End If
                If IsDBNull(.Rows(0).Item(6)) Then
                    mystr = mystr & "~"
                Else
                    mystr = mystr & Format(.Rows(0).Item(6), "dd-MMM HH:mm") & "~"
                End If
                mystr = mystr & .Rows(0).Item(7) & "~" & .Rows(0).Item(8) & "~"
                If Not IsDBNull(.Rows(0).Item("dc_foto")) Then
                    mystr = mystr & "<img src='petugas\" & .Rows(0).Item("dc_foto") & "' style='width:35px;height:50px' />"
                End If
                For i = 1 To .Rows.Count - 1
                    mystr = mystr & "|" & .Rows(i).Item(0) & "~" & .Rows(i).Item(1) & "~" &
                .Rows(i).Item(2) & "~" & .Rows(i).Item(3) & "~" &
                Format(.Rows(i).Item(4), "dd-MMM HH:mm") & "~"
                    If IsDBNull(.Rows(i).Item(5)) Then
                            mystr = mystr & "~"
                        Else
                        mystr = mystr & Format(.Rows(i).Item(5), "dd-MMM HH:mm") & "~"
                    End If
                        If IsDBNull(.Rows(i).Item(6)) Then
                            mystr = mystr & "~"
                        Else
                        mystr = mystr & Format(.Rows(i).Item(6), "dd-MMM HH:mm") & "~"
                    End If
                    mystr = mystr & .Rows(i).Item(7) & "~" & .Rows(i).Item(8) & "~"
                    If Not IsDBNull(.Rows(i).Item("dc_foto")) Then
                        mystr = mystr & "<img src='petugas\" & .Rows(i).Item("dc_foto") & "' style='width:35px;height:50px' />"
                    End If
                Next
            End If
        End With
        For i = dtSQL.Tables(0).Rows.Count To ic - 1
            If i = 0 Then
                mystr = "&nbsp;~~~~~~~~~"
            Else
                mystr = mystr & "|&nbsp;~~~~~~~~~"
            End If
        Next
        Return mystr
    End Function



    <WebMethod(Description:="Proc a()")>
    Public Function Wplanq(ByVal mydc As String) As String
        Dim mystr As String = ""
        Dim i As Integer
        Dim ic As Integer = 1
        StrSQL = "select top " & ic & " attribute1,attribute2,attribute3,myseq from dc_kedatanganq where dc='" & mydc & "' and attribute4='N' " &
            " and datediff(minute,attribute3,getdate())<1100 order by attribute3"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        With dtSQL.Tables(0)
            If .Rows.Count > 0 Then
                mystr = .Rows(0).Item(0) & "~" & .Rows(0).Item(1) & "~" & .Rows(0).Item(3)
                For i = 1 To .Rows.Count - 1
                    mystr = mystr & "|" & .Rows(i).Item(0) & "~" & .Rows(i).Item(1) & "~" & .Rows(0).Item(3)
                Next
            End If
        End With
        Return mystr
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function Wplanq01(ByVal a As String) As String
        StrSQL = "update dc_kedatanganq set attribute4='Y' " &
            " where myseq=" + a
        GetData.ExecuteDataSQL(StrSQL)
        Return ""
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function WoMonitoring(ByVal mydc As String) As String
        Dim mystr As String = ""
        Dim i As Integer
        Dim ic As Integer = 9 '15 + 35
        Dim myCount As Integer
        StrSQL = "select count(1) from monitoro_v1 (readpast) where kodecaba='" & mydc & "'"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        myCount = dtSQL.Tables(0).Rows(0).Item(0)
        StrSQL = "select top " & ic & " * from monitoro_v1 (readpast) where kodecaba='" & mydc & "' order by dateplan"
        dtSQL = GetData.CreateDataSet(StrSQL)
        With dtSQL.Tables(0)
            If .Rows.Count > 0 Then
                mystr = .Rows(0).Item(3) & "~" &
                .Rows(0).Item(4) & "~" & .Rows(0).Item(5) & "~" &
                .Rows(0).Item(6) & "~" & .Rows(0).Item(7) & "~" &
                .Rows(0).Item(8) & "~" & .Rows(0).Item(9) & "~" &
                .Rows(0).Item(10) & "~" & .Rows(0).Item(11) & "~" & .Rows(0).Item(2) & "~" &
                .Rows(0).Item(12) & "~" & .Rows(0).Item(13) & "~" &
                .Rows(0).Item(14) & "~" & .Rows(0).Item(15) & "~" &
                .Rows(0).Item(16) & "~" & .Rows(0).Item(17) & "^" & GetdataX(.Rows(0).Item(0), .Rows(0).Item(3))
                ''& "~"
                ''If Not IsDBNull(.Rows(0).Item("dc_foto")) Then
                '' mystr = mystr & "<img src='petugas\" & .Rows(0).Item("dc_foto") & "' />"
                ''End If
                For i = 1 To .Rows.Count - 1
                    mystr = mystr & "|" & .Rows(i).Item(3) & "~" &
                .Rows(i).Item(4) & "~" & .Rows(i).Item(5) & "~" &
                .Rows(i).Item(6) & "~" & .Rows(i).Item(7) & "~" &
                .Rows(i).Item(8) & "~" & .Rows(i).Item(9) & "~" &
                .Rows(i).Item(10) & "~" & .Rows(i).Item(11) & "~" & .Rows(i).Item(2) & "~" &
                .Rows(i).Item(12) & "~" & .Rows(i).Item(13) & "~" &
                .Rows(i).Item(14) & "~" & .Rows(i).Item(15) & "~" &
                .Rows(i).Item(16) & "~" & .Rows(i).Item(17) & "^" & GetdataX(.Rows(i).Item(0), .Rows(i).Item(3))
                    ''& "~"
                    ''If Not IsDBNull(.Rows(i).Item("dc_foto")) Then
                    ''  mystr = mystr & "<img src='petugas\" & .Rows(i).Item("dc_foto") & "' />"
                    ''  End If
                Next
            End If
        End With
        For i = dtSQL.Tables(0).Rows.Count To ic - 1
            If i = 0 Then
                mystr = "&nbsp;~~~~~~~~~~~~~~~^~~~~~~~~~~~~~~~~~~~~~~~"
            Else
                mystr = mystr & "|&nbsp;~~~~~~~~~~~~~~~^~~~~~~~~~~~~~~~~~~~~~~~"
            End If
        Next
        Return mystr
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function WoMonitoringXX(ByVal mydc As String, ByVal mypage As Integer) As String
        Dim mystr As String = ""
        Dim i As Integer
        Dim ic As Integer = 9 '15 + 35
        Dim myCount As Integer
        Dim nminrowpage As Integer
        Dim nmaxrowpage As Integer
        Dim npage As Integer
        Dim ntotalpage As Integer
        StrSQL = "select a.*,row_number() over (order by a.dateplan) nourut from monitorox_v1  (readpast) a where a.kodecaba='" & mydc & "' order by a.dateplan"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        nminrowpage = ((mypage - 1) * ic) + 1
        myCount = dtSQL.Tables(0).Rows.Count
        If nminrowpage <= myCount Then
            nmaxrowpage = nminrowpage + ic - 1
            npage = mypage
        Else
            nminrowpage = 1
            nmaxrowpage = ic
            npage = 1
        End If

        ntotalpage = Math.Ceiling(myCount / ic)

        Dim ncountloop As Integer = 0

        With dtSQL.Tables(0)
            'If nminrowpage <= .Rows(0).Item("nourut") Then

            ncountloop = 0

            'mystr = .Rows(0).Item(3) & "~" &
            '    .Rows(0).Item(4) & "~" & .Rows(0).Item(5) & "~" &
            '    .Rows(0).Item(6) & "~" & .Rows(0).Item(7) & "~" &
            '    .Rows(0).Item(8) & "~" & .Rows(0).Item(9) & "~" &
            '    .Rows(0).Item(10) & "~" & .Rows(0).Item(11) & "~" & .Rows(0).Item(2) & "~" &
            '    .Rows(0).Item(12) & "~" & .Rows(0).Item(13) & "~" &
            '    .Rows(0).Item(14) & "~" & .Rows(0).Item(15) & "~" &
            '    .Rows(0).Item(16) & "~" & .Rows(0).Item(17) & "^" & GetdataX(.Rows(0).Item(0), .Rows(0).Item(3))


            ''& "~"
            ''If Not IsDBNull(.Rows(0).Item("dc_foto")) Then
            '' mystr = mystr & "<img src='petugas\" & .Rows(0).Item("dc_foto") & "' />"
            ''End If
            For i = (nminrowpage - 1) To .Rows.Count - 1


                If i = (nminrowpage - 1) Then
                    ncountloop = ncountloop + 1

                    mystr = .Rows(i).Item(3) & "~" &
                .Rows(i).Item(4) & "~" & .Rows(i).Item(5) & "~" &
                .Rows(i).Item(6) & "~" & .Rows(i).Item(7) & "~" &
                .Rows(i).Item(8) & "~" & .Rows(i).Item(9) & "~" &
                .Rows(i).Item(10) & "~" & .Rows(i).Item(11) & "~" & .Rows(i).Item(2) & "~" &
                .Rows(i).Item(12) & "~" & .Rows(i).Item(13) & "~" &
                .Rows(i).Item(14) & "~" & .Rows(i).Item(15) & "~" &
                .Rows(i).Item(16) & "~" & .Rows(i).Item(17) & "^" & GetdataX(.Rows(i).Item(0), .Rows(i).Item(3))

                ElseIf i < nmaxrowpage Then
                    ncountloop = ncountloop + 1
                    mystr = mystr & "|" & .Rows(i).Item(3) & "~" &
            .Rows(i).Item(4) & "~" & .Rows(i).Item(5) & "~" &
            .Rows(i).Item(6) & "~" & .Rows(i).Item(7) & "~" &
            .Rows(i).Item(8) & "~" & .Rows(i).Item(9) & "~" &
            .Rows(i).Item(10) & "~" & .Rows(i).Item(11) & "~" & .Rows(i).Item(2) & "~" &
            .Rows(i).Item(12) & "~" & .Rows(i).Item(13) & "~" &
            .Rows(i).Item(14) & "~" & .Rows(i).Item(15) & "~" &
            .Rows(i).Item(16) & "~" & .Rows(i).Item(17) & "^" & GetdataX(.Rows(i).Item(0), .Rows(i).Item(3))

                End If

                ''& "~"
                ''If Not IsDBNull(.Rows(i).Item("dc_foto")) Then
                ''  mystr = mystr & "<img src='petugas\" & .Rows(i).Item("dc_foto") & "' />"
                ''  End If
            Next
            'End If
        End With
        For i = ncountloop To ic
            If i = 0 Then
                mystr = "&nbsp;~~~~~~~~~~~~~~~^~~~~~~~~~~~~~~~~~~~~~~~"
            Else
                mystr = mystr & "|&nbsp;~~~~~~~~~~~~~~~^~~~~~~~~~~~~~~~~~~~~~~~"
            End If
        Next
        mystr = mystr & "`" & npage & "~" & ntotalpage
        Return mystr
    End Function


    Function GetdataX(ByVal nama As String, ByVal listpick As String) As String
        Dim NSTR As String
        Try
            Dim data As Data.DataSet = qplano(nama, listpick)
            NSTR = ""

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
                NSTR = NSTR & "W~"
            ElseIf data.Tables(0).Rows(0).Item("dateactual") > data.Tables(0).Rows(0).Item("dateplan") Then
                NSTR = NSTR & "R~"
            Else
                NSTR = NSTR & "G~"
            End If

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
                NSTR = NSTR & "W~"
            ElseIf data.Tables(0).Rows(0).Item("actualkonsol") > data.Tables(0).Rows(0).Item("plankonsol") Then
                NSTR = NSTR & "R~"
            Else
                NSTR = NSTR & "G~"
            End If

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
                NSTR = NSTR & "W~"
            ElseIf data.Tables(0).Rows(0).Item("sactualload") > data.Tables(0).Rows(0).Item("splanload") Then
                NSTR = NSTR & "R~"
            Else
                NSTR = NSTR & "G~"
            End If

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
                NSTR = NSTR & "W~"
            ElseIf data.Tables(0).Rows(0).Item("factualload") > data.Tables(0).Rows(0).Item("fplanload") Then
                NSTR = NSTR & "R~"
            Else
                NSTR = NSTR & "G~"
            End If

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
                NSTR = NSTR & "W~"
            ElseIf data.Tables(0).Rows(0).Item("sactual_sj") > data.Tables(0).Rows(0).Item("splan_sj") Then
                NSTR = NSTR & "R~"
            Else
                NSTR = NSTR & "G~"
            End If

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
                NSTR = NSTR & "W~"
            ElseIf data.Tables(0).Rows(0).Item("factual_sj") > data.Tables(0).Rows(0).Item("fplan_sj") Then
                NSTR = NSTR & "R~"
            Else
                NSTR = NSTR & "G~"
            End If

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
                NSTR = NSTR & "W~"
            ElseIf data.Tables(0).Rows(0).Item("actualpicking") > data.Tables(0).Rows(0).Item("planpicking") Then
                NSTR = NSTR & "R~"
            Else
                NSTR = NSTR & "G~"
            End If

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

        Catch ex As Exception
            NSTR = ""
        End Try
        Return NSTR
    End Function




    <WebMethod(Description:="Proc a()")>
    Public Function wsi1() As String
        StrSQL = "select * from dc_manp"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Dim MyStr As String = ""
        For i = 0 To dtSQL.Tables(0).Rows.Count - 1
            MyStr = MyStr & dtSQL.Tables(0).Rows(i).Item("manp01") & " | "
            MyStr = MyStr & GetData.EDecrypt(dtSQL.Tables(0).Rows(i).Item("manp01")) & " | "
            MyStr = MyStr & dtSQL.Tables(0).Rows(i).Item("manp02") & " | "
            MyStr = MyStr & GetData.EDecrypt(dtSQL.Tables(0).Rows(i).Item("manp02")) & vbCrLf
        Next
        Return MyStr
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function XLogin(ByVal p_user As String) As Data.DataSet

        StrSQL = "select * from dc_manp where manp01='" & p_user & "' "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL

    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function XXLogin(ByVal var1 As String, ByVal var2 As String) As Data.DataSet
        Dim mytgl As Date = Now

        StrSQL = "select attribute3,attribute6 from dc_kedatanganp where attribute2='" & GetData.EEncryp(var1) &
            "' and attribute1='" & GetData.EEncryp(var2) & "' and attribute4='" & GetData.EEncryp(mytgl.ToString("yyyy-MM-dd")) & "'"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        If dtSQL.Tables(0).Rows.Count = 0 Then
            StrSQL = "select manp01,rdc,attribute1,'Y' attribute6 from dc_manp where 1=2 "
        Else
            StrSQL = "select manp01,rdc,attribute1,'" & dtSQL.Tables(0).Rows(0).Item("attribute6") &
                "' attribute6 from dc_manp where manp01='" & GetData.EDecrypt(dtSQL.Tables(0).Rows(0).Item(0)) & "' "
        End If
        dtSQL = GetData.CreateDataSet(StrSQL)
        Return dtSQL

    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function top3arrival(ByVal p_kodedc As String) As Data.DataSet

        StrSQL = "select top 3 noantrian,expname,jeniskend,nokend,kedatangan, tipeantrian,expnamespell,namadriver " &
           " from kedatangani_v where flgstatus='Arrival' and kodedc='" & p_kodedc & "' " &
           " order by flagstatus, tpantrian, noantrian "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL

    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function arrivalo(ByVal p_kodedc As String) As Data.DataSet

        StrSQL = "select * from kedatangano_v where kodecaba='" & p_kodedc & "' order by kedatangan desc "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL

    End Function



    <WebMethod(Description:="Proc a()")>
    Public Function top3sunload(ByVal p_kodedc As String) As Data.DataSet

        StrSQL = "select top 3 noantrian,expname,jeniskend,nokend,kedatangan, tipeantrian,expnamespell,namadriver " &
           " from kedatangani_v where flgstatus='Waiting' and kodedc='" & p_kodedc & "' " &
           " order by flagstatus, tpantrian, noantrian "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL

    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function top3funload(ByVal p_kodedc As String, ByVal p_user As String) As Data.DataSet

        StrSQL = "select top 10 noantrian,expname,jeniskend,nokend,kedatangan, tipeantrian, namadriver, expnamespell " &
           " from kedatangani_v where flgstatus='Process' and kodedc='" & p_kodedc & "' and punload='" & p_user & "'" &
           " order by flagstatus, tpantrian, noantrian "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL

    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function mybtn01(ByVal mytp As String, ByVal myrdc As String, ByVal myantrian As String, ByVal myuser As String, ByVal petugas As String) As String
        If mytp = "TERIMA" Then
            StrSQL = "update dc_kedatangani Set flagstatus='15',pcheckdokumen='" & myuser & "',tcheckdokumen=getdate() where kodedc='" & myrdc & "' and noantrian='" & myantrian & "' and flagstatus='20'"
            GetData.ExecuteDataSQL(StrSQL)
        ElseIf mytp = "TUNDA" Then
            StrSQL = "update dc_kedatangani set flagstatus='90',pcheckdokumen='" & myuser & "',tcheckdokumen=getdate() where kodedc='" & myrdc & "' and noantrian='" & myantrian & "' and flagstatus='20'"
            GetData.ExecuteDataSQL(StrSQL)
        ElseIf mytp = "BATAL" Then
            StrSQL = "update dc_kedatangani set flagstatus='95',pcheckdokumen='" & myuser & "',tcheckdokumen=getdate() where kodedc='" & myrdc & "' and noantrian='" & myantrian & "' and flagstatus='20'"
            GetData.ExecuteDataSQL(StrSQL)
        ElseIf mytp = "BATALTUNDA" Then
            StrSQL = "update dc_kedatangani set flagstatus='20',pcheckdokumen='" & myuser & "',tcheckdokumen=getdate() where kodedc='" & myrdc & "' and noantrian='" & myantrian & "' and flagstatus='90'"
            GetData.ExecuteDataSQL(StrSQL)
        ElseIf mytp = "STARTUNLOAD" Then
            StrSQL = "update dc_kedatangani set flagstatus='10',punload='" & myuser & "',startunload=getdate(),dc_petugas='" & petugas & "' where kodedc='" & myrdc & "' and noantrian='" & myantrian & "' and flagstatus='15'"
            GetData.ExecuteDataSQL(StrSQL)
        ElseIf mytp = "FINISHUNLOAD" Then
            StrSQL = "update dc_kedatangani set flagstatus='05',finunload=getdate() where kodedc='" & myrdc & "' and noantrian='" & myantrian & "' and flagstatus='10' and punload='" & myuser & "'"
            GetData.ExecuteDataSQL(StrSQL)
        End If
        mybtn01 = ""
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function mybtn02(ByVal listpick As String, ByVal dock_no As String, ByVal staging_line As String) As String
        If dock_no <> "" And staging_line <> "" Then
            StrSQL = "update dc_kedatangano Set dock_no='" & dock_no & "',staging_line='" & staging_line & "' where listpick='" & listpick & "' and dock_no=''"
            GetData.ExecuteDataSQL(StrSQL)
        End If
        mybtn02 = ""
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function top3tunda(ByVal p_kodedc As String) As Data.DataSet

        StrSQL = "select top 3 noantrian,expname,jeniskend,nokend,kedatangan, tipeantrian " &
           " from kedatangani_v where flgstatus='Hold' and kodedc='" & p_kodedc & "' " &
           " order by flagstatus, tpantrian, noantrian "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL

    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function qplano(ByVal p_kodedc As String) As Data.DataSet
        StrSQL = "select a.* from dc_plano_v a  (readpast) where a.kodecaba='" & p_kodedc & "' order by a.dateplan desc"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function qplanodate(ByVal p_kodedc As String, ByVal p_date1 As String, ByVal p_date2 As String) As Data.DataSet
        StrSQL = "select a.* from dc_plano_v a  (readpast) where a.kodecaba='" & p_kodedc & "' and dateplan between '" & p_date1 & "' and '" & p_date2 & "' order by a.dateplan desc"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function iplano(ByVal listpick As String, ByVal kodecaba As String, ByVal dateplan As String, ByVal kodecabt As String,
                           ByVal expcode As String, ByVal kodekend As String, ByVal plankonsol As String,
                           ByVal splanload As String, ByVal fplanload As String, ByVal splan_sj As String,
                           ByVal fplan_sj As String, ByVal suser As String, ByVal planpicking As String, ByVal planpacking As String, ByVal upload_batch As String) As String
        Dim myerr As String = ""
        Try
            StrSQL = "insert into dc_plano (listpick,kodecaba,dateplan,kodecabt,expcode,kodekend,plankonsol,splanload," &
                "fplanload,splan_sj,fplan_sj,screated_by,screated_date,planpicking,planpacking,upload_batch) values " &
                "('" & listpick & "','" & kodecaba & "','" & sqldatetime(dateplan) & "','" & kodecabt & "','" &
                expcode & "','" & kodekend & "','" & sqldatetime(plankonsol) & "','" & sqldatetime(splanload) & "','" &
                sqldatetime(fplanload) & "','" & sqldatetime(splan_sj) & "','" & sqldatetime(fplan_sj) & "','" & suser & "',getdate(),'" & sqldatetime(planpicking) & "','" & sqldatetime(planpacking) &
                "','" & upload_batch & "')"
            GetData.ExecuteDataSQL(StrSQL)
        Catch ex As Exception
            myerr = "1" & ex.Message
        Finally
            myerr = "0Data berhasil disimpan"
        End Try
        Return myerr
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function uplano(ByVal listpick As String, ByVal kodecaba As String, ByVal dateplan As String, ByVal kodecabt As String,
                           ByVal expcode As String, ByVal kodekend As String, ByVal plankonsol As String,
                           ByVal splanload As String, ByVal fplanload As String, ByVal splan_sj As String,
                           ByVal fplan_sj As String, ByVal suser As String, ByVal planpicking As String, ByVal planpacking As String) As String
        Dim myerr As String = ""
        Try
            StrSQL = "update dc_plano set dateplan='" & sqldatetime(dateplan) & "',kodecabt='" & kodecabt & "',expcode='" & expcode & "',kodekend='" & kodekend & "',plankonsol='" & sqldatetime(plankonsol) & "',splanload='" & sqldatetime(splanload) & "'," &
                "fplanload='" & sqldatetime(fplanload) & "',splan_sj='" & sqldatetime(splan_sj) & "',fplan_sj='" & sqldatetime(fplan_sj) & "',supdated_by='" & suser & "',screated_date=getdate(),planpicking='" & sqldatetime(planpicking) & "',planpacking='" & sqldatetime(planpacking) & "' where listpick='" & listpick & "' and kodecaba='" & kodecaba & "' "

            GetData.ExecuteDataSQL(StrSQL)
        Catch ex As Exception
            myerr = "1" & ex.Message
        Finally
            myerr = "0Data berhasil disimpan"
        End Try
        Return myerr
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function dplano(ByVal listpick As String, ByVal kodecaba As String) As String
        Dim myerr As String = ""
        Try
            StrSQL = "delete dc_plano where listpick='" & listpick & "' and kodecaba='" & kodecaba & "' and dateactual is null "

            GetData.ExecuteDataSQL(StrSQL)
        Catch ex As Exception
            myerr = "1" & ex.Message
        Finally
            myerr = "0Data berhasil dihapus"
        End Try
        Return myerr
    End Function

    Function sqldatetime(ByVal a As String) As String
        Dim b As String = a.Replace("T", " ") & ":00"
        sqldatetime = b
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function Graphlinecompleteo(ByVal mydc As String) As String
        Dim my_str As String = "[0,0,0]"

        For i = 1 To 24

            StrSQL = "select kodecaba,sum(jplan) as jplan,sum(jactual) as jactual from dbo.graphlinecompleteo_v " &
                " where jam<=" & i & " and kodecaba='" & mydc & "' group by kodecaba "
            Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
            If dtSQL.Tables(0).Rows.Count = 0 Then
                my_str = my_str & ",[" & i & ",0,0]"
            Else
                my_str = my_str & ",[" & i & "," & dtSQL.Tables(0).Rows(0).Item(1) & "," & dtSQL.Tables(0).Rows(0).Item(2) & "]"
            End If
        Next

        Return my_str
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function Graphpieo(ByVal mydc As String) As Data.DataSet
        StrSQL = "select * from graphpieo_v where kodecaba='" & mydc & "' "
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function iplanp(ByVal a As String, ByVal b As String, ByVal c As String) As String
        Dim myerr As String = ""
        Dim mytgl As Date = Now
        Dim mydate As String = GetData.EEncryp(mytgl.ToString("yyyy-MM-dd"))
        Try
            StrSQL = "insert into dc_kedatanganp (attribute1,attribute2,attribute3,attribute4,attribute6) values ('" & a & "','" & b & "','" & c & "','" & mydate & "','Y')"
            GetData.ExecuteDataSQL(StrSQL)

            StrSQL = "select min(attribute5) from dc_kedatanganp where attribute4='" & mydate & "' "
            Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
            If dtSQL.Tables(0).Rows.Count > 0 Then
                StrSQL = "delete dc_kedatanganp where attribute5<" & dtSQL.Tables(0).Rows(0).Item(0)
                GetData.ExecuteDataSQL(StrSQL)
            End If
        Catch ex As Exception
            myerr = "1" & ex.Message
        Finally
            myerr = "0Data berhasil dihapus"
        End Try
        Return myerr
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function Implanp(ByVal a As String, ByVal b As String) As String

        StrSQL = "UPDATE dc_kedatanganp set attribute6='" & b & "' where attribute1='" & a & "'"
        GetData.ExecuteDataSQL(StrSQL)

        Return ""
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function Implanq(ByVal a As String, ByVal b As String, ByVal c As String) As String

        StrSQL = "insert into dc_kedatanganq (attribute1,attribute2,dc) values ('" & a & "','" & b & "','" & c & "')"
        GetData.ExecuteDataSQL(StrSQL)

        Return ""
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function listu() As Data.DataSet
        StrSQL = "select manp01,manp02,attribute1,rdc from dc_Manp"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function Petugas(ByVal dc As String) As Data.DataSet
        StrSQL = "select dc_petugas from dc_petugas where dc='" & dc & "' and dc_type='INBOUND' and dc_level=1 order by dc_petugas"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function updateplano(ByVal dc As String) As String
        Dim bproses As Boolean = True

        StrSQL = "select * from dc_logproses where dc='" & dc & "'"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        If dtSQL.Tables(0).Rows.Count = 0 Then
            StrSQL = "insert into dc_logproses values ('" & dc & "','1',getdate())"
            GetData.ExecuteDataSQL(StrSQL)
            bproses = True
        Else
            If dtSQL.Tables(0).Rows(0).Item("dc_status") = "0" Then
                StrSQL = "update dc_logproses set dc_status='1',dc_tgl=getdate() where dc='" & dc & "'"
                GetData.ExecuteDataSQL(StrSQL)
                bproses = True
            Else
                Dim mydiff As Double = DateDiff(DateInterval.Minute, dtSQL.Tables(0).Rows(0).Item("dc_tgl"), DateTime.Now)

                If mydiff > 5 Then
                    StrSQL = "update dc_logproses set dc_status='1',dc_tgl=getdate() where dc='" & dc & "'"
                    GetData.ExecuteDataSQL(StrSQL)
                    bproses = True
                Else
                    bproses = False
                End If
            End If
        End If

        If bproses Then
            StrSQL = "select listpick from plano_update_v where kodecaba='" & dc & "' /*and listpick='SEP-186578'*/"
            dtSQL = GetData.CreateDataSet(StrSQL)
            For i = 0 To dtSQL.Tables(0).Rows.Count - 1
                StrSQL = "select outbound_actual_f('" & dtSQL.Tables(0).Rows(i).Item(0) & "') from dual"
                Dim dtOra As Data.DataSet = GetOra.CreateDataSet(StrSQL)
                Dim mysplit As String = dtOra.Tables(0).Rows(0).Item(0)
                Dim mysplit1 = Split(mysplit, "~")
                StrSQL = "update dc_plano set actualpicking=" & mydatenull(mysplit1(0)) & ",actualpacking=" & mydatenull(mysplit1(1)) & ",actualkonsol=" & mydatenull(mysplit1(2)) & "," &
                "sactualload=" & mydatenull(mysplit1(3)) & ",factualload=" & mydatenull(mysplit1(4)) & ",sactual_sj=" & mydatenull(mysplit1(5)) & ",factual_sj=" & mydatenull(mysplit1(6)) & "" &
                " where listpick='" & dtSQL.Tables(0).Rows(i).Item(0) & "' and kodecaba='" & dc & "'"
                GetData.ExecuteDataSQL(StrSQL)
            Next
            StrSQL = "update dc_logproses set dc_status='0' where dc='" & dc & "'"
            GetData.ExecuteDataSQL(StrSQL)
        End If
        Return ""
    End Function

    Private Function mydatenull(mydate As String) As String
        Dim mystr As String = ""
        If mydate = "" Then
            mystr = "null"
        Else
            mystr = "'" & mydate & "'"
        End If
        Return (mystr)
    End Function


    <WebMethod(Description:="Proc a()")>
    Public Function qplano(ByVal dc As String, ByVal listpick As String) As Data.DataSet
        StrSQL = "select * from dc_plano where listpick='" & listpick & "' and kodecaba='" & dc & "'"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function

    <WebMethod(Description:="Proc a()")>
    Public Function Mstexpedisi() As Data.DataSet
        StrSQL = "select * from dc_expedisi order by expname"
        Dim dtSQL As Data.DataSet = GetData.CreateDataSet(StrSQL)
        Return dtSQL
    End Function



End Class
