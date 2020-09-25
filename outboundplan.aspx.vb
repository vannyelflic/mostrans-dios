
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Partial Class outboundplan
    Inherits System.Web.UI.Page

    Public mychef As New MyChef
    Public mysql As New Mysql
    Dim mydata As Data.DataSet

    Private Sub outboundplan_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtdatefrom.value = Format(Now.Date, "yyyy-MM-dd")
            txtdateto.value = Format(Now.Date, "yyyy-MM-dd")

            MyRefresh()
        End If
    End Sub

    Sub MyRefresh()
        Dim myhtml As New StringBuilder
        myhtml.Clear()
        myplc.Controls.Clear()


        myhtml.Append(" <table id='mytable' class='stripe row-border order-column' cellspacing='0' width='100%'> ")
        myhtml.Append("   <thead>")
        myhtml.Append("<tr>")
        myhtml.Append("<th rowspan='3'>List Picking No</th>")
        myhtml.Append("<th rowspan='3'></th>")
        myhtml.Append("<th rowspan='3'>Cabang</th>")
        myhtml.Append("<th colspan='7'>Ekspedisi</th>")
        myhtml.Append("<th rowspan='3'>Plan Picking</th>")
        myhtml.Append("<th rowspan='3'>Actual Picking</th>")
        myhtml.Append("<th rowspan='3'>Plan Packing</th>")
        myhtml.Append("<th rowspan='3'>Actual Packing</th>")
        myhtml.Append("<th rowspan='3'>Plan Consol</th>")
        myhtml.Append("<th rowspan='3'>Actual Consol</th>")
        myhtml.Append("<th rowspan='2' colspan='2'>Plan Loading</th>")
        myhtml.Append("<th rowspan='2' colspan='2'>Actual Loading</th>")
        myhtml.Append("<th rowspan='2' colspan='2'>Plan Surat Jalan</th>")
        myhtml.Append("<th rowspan='2' colspan='2'>Actual Surat Jalan</th>")
        myhtml.Append("</tr>")
        myhtml.Append("<tr>")
        myhtml.Append("<th rowspan='2'>Nama</th>")
        myhtml.Append("<th colspan='3'>Jam</th>")
        myhtml.Append("<th rowspan='2'>Type</th>")
        myhtml.Append("<th rowspan='2'>Kubikasi</th>")
        myhtml.Append("<th rowspan='2'>Tonase</th>")
        myhtml.Append("</tr>")
        myhtml.Append("<tr>")
        myhtml.Append("<th>" & Session("gKodeDC") & "</th>")
        myhtml.Append("<th>Actual</th>")
        myhtml.Append("<th></th>")
        myhtml.Append("<th>Start</th>")
        myhtml.Append("<th>Finish</th>")
        myhtml.Append("<th>Start</th>")
        myhtml.Append("<th>Finish</th>")
        myhtml.Append("<th>Start</th>")
        myhtml.Append("<th>Finish</th>")
        myhtml.Append("<th>Start</th>")
        myhtml.Append("<th>Finish</th>")
        myhtml.Append("</tr>")
        myhtml.Append("   </thead>")
        myhtml.Append("   <tbody>")
        Dim mydata As Data.DataSet

        Dim mytgl1, mytgl2 As String
        mytgl1 = txtdatefrom.value
        mytgl2 = txtdateto.value

        Dim expenddt As Date = Date.ParseExact(mytgl2, "yyyy-MM-dd",
                     System.Globalization.DateTimeFormatInfo.InvariantInfo)
        expenddt = expenddt.AddDays(1)
        mytgl2 = Format(expenddt, "yyyy-MM-dd")

        mydata = mychef.qplanodate(Session("gKodeDC"), mytgl1, mytgl2)
        Dim Temps As String = ""
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            myhtml.Append("<tr>")
            With mydata.Tables(0).Rows(i)


                Temps = .Item("listpick") & "|" & .Item("kodecabt") & "|" & .Item("expcode") & "|" & .Item("kodekend") &
                    "|" & Fdate1(.Item("dateplan")) & "|" & Fdate1(.Item("plankonsol")) & "|" & Fdate1(.Item("splanload")) &
                    "|" & Fdate1(.Item("fplanload")) & "|" & Fdate1(.Item("splan_sj")) & "|" & Fdate1(.Item("fplan_sj")) &
                    "|" & Fdate1(.Item("planpicking")) & "|" & Fdate1(.Item("planpacking"))

                myhtml.Append("<td>" & .Item("listpick") & "</td>")
                myhtml.Append("<td><button type='button' class='button2xx' data-book-id='" & Temps & "' data-target='#formModalEdit' data-toggle='modal' style='font-size:16px'>&#9997;</button></td>")
                myhtml.Append("<td>" & .Item("namacab") & "</td>")
                myhtml.Append("<td>" & .Item("expname") & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("dateplan")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("dateactual")) & "</td>")
                If Fdate(.Item("dateactual")) = "" Then

                    Temps = .Item("listpick") & "|" & .Item("namacab") & "|" & .Item("expname") & "|" & .Item("jeniskend") &
                    "|" & Fdate2(.Item("dateplan")) & "|" & Fdate2(.Item("plankonsol")) & "|" & Fdate2(.Item("splanload")) &
                    "|" & Fdate2(.Item("fplanload")) & "|" & Fdate2(.Item("splan_sj")) & "|" & Fdate2(.Item("fplan_sj")) &
                    "|" & Fdate2(.Item("planpicking")) & "|" & Fdate2(.Item("planpacking"))

                    myhtml.Append("<td><button type='button' class='button2xx' data-book-id='" & Temps & "' data-target='#formModalDelete' data-toggle='modal' style='font-size:16px'>&#10060;</button></td>")
                Else
                    myhtml.Append("<td>&nbsp;</td>")
                End If
                myhtml.Append("<td>" & .Item("jeniskend") & "</td>")
                myhtml.Append("<td>" & .Item("kubikasi") & "</td>")
                myhtml.Append("<td>" & .Item("tonase") & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("planpicking")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("actualpicking")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("planpacking")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("actualpacking")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("plankonsol")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("actualkonsol")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("splanload")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("fplanload")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("sactualload")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("factualload")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("splan_sj")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("fplan_sj")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("sactual_sj")) & "</td>")
                myhtml.Append("<td>" & Fdate(.Item("factual_sj")) & "</td>")
            End With
            myhtml.Append("</tr>")
        Next
        myhtml.Append("   </tbody>")
        myhtml.Append(" </table>")

        myplc.Controls.Add(New Literal() With {
          .Text = myhtml.ToString()
         })



        Dim myhtml1 As New StringBuilder
        myhtml1.Clear()
        myhtml1.Append("<Table id='mytablecabang'>")
        myhtml1.Append("<tr>")
        myhtml1.Append("<td>KODE CABANG</td>")
        myhtml1.Append("<td>NAMA CABANG</td>")
        myhtml1.Append("</tr>")
        mydata = mychef.WMCab
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            myhtml1.Append("<tr>")
            myhtml1.Append("<td>" & mydata.Tables(0).Rows(i).Item(0) & "</td>")
            myhtml1.Append("<td>" & mydata.Tables(0).Rows(i).Item(1) & "</td>")
            myhtml1.Append("</tr>")
        Next
        myhtml1.Append("</table>")

        myhtml1.Append("<Table id='mytableexpedisi'>")
        myhtml1.Append("<tr>")
        myhtml1.Append("<td>KODE EXPEDISI</td>")
        myhtml1.Append("<td>NAMA EXPEDISI</td>")
        myhtml1.Append("</tr>")
        mydata = mychef.WMExp
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            myhtml1.Append("<tr>")
            myhtml1.Append("<td>" & mydata.Tables(0).Rows(i).Item(0) & "</td>")
            myhtml1.Append("<td>" & mydata.Tables(0).Rows(i).Item(1) & "</td>")
            myhtml1.Append("</tr>")
        Next
        myhtml1.Append("</table>")

        myhtml1.Append("<Table id='mytablekendaraan'>")
        myhtml1.Append("<tr>")
        myhtml1.Append("<td>KODE KENDARAAN</td>")
        myhtml1.Append("<td>NAMA KENDARAAN</td>")
        myhtml1.Append("</tr>")
        mydata = mychef.WMKend
        For i = 0 To mydata.Tables(0).Rows.Count - 1
            myhtml1.Append("<tr>")
            myhtml1.Append("<td>" & mydata.Tables(0).Rows(i).Item(0) & "</td>")
            myhtml1.Append("<td>" & mydata.Tables(0).Rows(i).Item(1) & "</td>")
            myhtml1.Append("</tr>")
        Next
        myhtml1.Append("</table>")


        myhtml1.Append("<Table id='mytabletemplate'>")
        myhtml1.Append("<tr>")
        myhtml1.Append("<td>ASAL</td>")
        myhtml1.Append("<td>TUJUAN</td>")
        myhtml1.Append("<td>LIST PICKING</td>")
        myhtml1.Append("<td>KODE EXPEDISI</td>")
        myhtml1.Append("<td>KODE KENDARAAN</td>")
        myhtml1.Append("<td>RENCANA KEDATANGAN</td>")
        myhtml1.Append("<td>RENCANA PICKING</td>")
        myhtml1.Append("<td>RENCANA PACKING</td>")
        myhtml1.Append("<td>RENCANA CONSOL</td>")
        myhtml1.Append("<td>RENCANA START LOADING</td>")
        myhtml1.Append("<td>RENCANA FINISH LOADING</td>")
        myhtml1.Append("<td>RENCANA START SJ</td>")
        myhtml1.Append("<td>RENCANA FINISH SJ</td>")
        myhtml1.Append("<td>FLAG</td>")
        myhtml1.Append("</tr>")
        myhtml1.Append("<tr>")
        myhtml1.Append("<td colspan=13>Baris ke-3 adalah contoh data, gunakan mulai baris ke-4 dst untuk data sebenarnya dan kosongkan kolom FLAG</td>")
        myhtml1.Append("<td>CONTOH</td>")
        myhtml1.Append("</tr>")
        myhtml1.Append("<tr>")
        myhtml1.Append("<td>" & Session("gKodeDC") & "</td>")
        myhtml1.Append("<td>MDN</td>")
        myhtml1.Append("<td>176351</td>")
        myhtml1.Append("<td>X00023</td>")
        myhtml1.Append("<td>BU1243</td>")
        myhtml1.Append("<td>30-SEP-2018 10:30</td>")
        myhtml1.Append("<td>30-SEP-2018 10:45</td>")
        myhtml1.Append("<td>30-SEP-2018 11:45</td>")
        myhtml1.Append("<td>30-SEP-2018 13:20</td>")
        myhtml1.Append("<td>30-SEP-2018 13:40</td>")
        myhtml1.Append("<td>30-SEP-2018 14:20</td>")
        myhtml1.Append("<td>30-SEP-2018 14:40</td>")
        myhtml1.Append("<td>30-SEP-2018 14:55</td>")
        myhtml1.Append("<td>CONTOH</td>")
        myhtml1.Append("</tr>")
        myhtml1.Append("</table>")
        plcTemplate.Controls.Add(New Literal() With {
                    .Text = myhtml1.ToString()
                     })




    End Sub

    Private Sub outboundplan_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Session("gUserName") Is Nothing Then
            Response.Redirect("default.aspx")
        ElseIf IsDBNull(Session("gUserName")) Then
            Response.Redirect("default.aspx")
        End If

        If Not IsPostBack Then

            mydata = mychef.WMCab

            cboCabang.Items.Clear()
            cboCabang.Items.Add("")
            cboCabang1.Items.Clear()
            cboCabang1.Items.Add("")
            'cboCabang2.Items.Clear()
            'cboCabang2.Items.Add("")
            For i = 0 To mydata.Tables(0).Rows.Count - 1
                With cboCabang
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
                With cboCabang1
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
                'With cboCabang2
                '    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                '    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                'End With
            Next


            mydata = mychef.WMExp

            cboExpedisi.Items.Clear()
            cboExpedisi.Items.Add("")
            cboExpedisi1.Items.Clear()
            cboExpedisi1.Items.Add("")
            'cboExpedisi2.Items.Clear()
            'cboExpedisi2.Items.Add("")
            For i = 0 To mydata.Tables(0).Rows.Count - 1
                With cboExpedisi
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
                With cboExpedisi1
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
                'With cboExpedisi2
                '    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                '    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                'End With
            Next

            mydata = mychef.WMKend

            cbojeniskend.Items.Clear()
            cbojeniskend.Items.Add("")
            cbojeniskend1.Items.Clear()
            cbojeniskend1.Items.Add("")
            'cbojeniskend2.Items.Clear()
            'cbojeniskend2.Items.Add("")
            For i = 0 To mydata.Tables(0).Rows.Count - 1
                With cbojeniskend
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
                With cbojeniskend1
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
                'With cbojeniskend2
                '    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                '    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                'End With
            Next

            mydata.Clear()

        End If

    End Sub

    Private Sub BtnInsert_ServerClick(sender As Object, e As EventArgs) Handles btnInsert.ServerClick
        If txtListPicking.Text <> "" And cboCabang.Value <> "" And cboExpedisi.Value <> "" And cbojeniskend.Value <> "" And
            txtidKedatangan.value <> "" And txtidKonsol.value <> "" And txtsLoading.value <> "" And txtfLoading.value <> "" And
            txtsSuratJalan.value <> "" And txtfSuratJalan.value <> "" And
            txtplanpicking.value <> "" And txtplanpacking.value <> "" Then

            Dim MyInfo As String = mychef.iplano(mysql.bersih(txtListPicking.Text).Trim(), Session("gKodeDC"),
                    txtidKedatangan.value, cboCabang.Value, cboExpedisi.Value, cbojeniskend.Value,
                    txtidKonsol.value, txtsLoading.value, txtfLoading.value, txtsSuratJalan.value, txtfSuratJalan.value,
                    Session("gUserName"), txtplanpicking.value, txtplanpacking.value, "")
            If MyInfo.Substring(1, 1) = "1" Then
                Myalert(MyInfo.Substring(2))
            Else
                MyRefresh()
            End If
        Else
            Myalert("Data tidak lengkap")
        End If


    End Sub

    Function Fstring(ByVal a As Object) As String
        Dim b As String
        If a Is Nothing Then
            b = ""
        ElseIf IsDBNull(a) Then
            b = ""
        Else
            b = a.ToString
        End If
        Fstring = b
    End Function

    Function Fdate(ByVal a As Object) As String
        Dim b As String
        If a Is Nothing Then
            b = ""
        ElseIf IsDBNull(a) Then
            b = ""
        Else
            b = Format(a, "dd/MM HH:mm")
        End If
        Fdate = b
    End Function

    Function Fdate1(ByVal a As Object) As String
        Dim b As String
        If a Is Nothing Then
            b = ""
        ElseIf IsDBNull(a) Then
            b = ""
        Else
            b = Format(a, "yyyy-MM-dd HH:mm")
            b = b.Replace(" ", "T")
        End If
        Fdate1 = b
    End Function

    Function Fdate2(ByVal a As Object) As String
        Dim b As String
        If a Is Nothing Then
            b = ""
        ElseIf IsDBNull(a) Then
            b = ""
        Else
            b = Format(a, "dd-MMM-yyyy HH:mm")
        End If
        Fdate2 = b
    End Function

    Sub Myalert(ByVal a As String)
        Dim message As String = a
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    Private Sub btnSave1_ServerClick(sender As Object, e As EventArgs) Handles btnSave1.ServerClick

        If cboCabang1.Value <> "" And cboExpedisi1.Value <> "" And cbojeniskend1.Value <> "" And
            txtidKedatangan1.value <> "" And txtidKonsol1.value <> "" And txtsLoading1.value <> "" And txtfLoading1.value <> "" And
            txtsSuratJalan1.value <> "" And txtfSuratJalan1.value <> "" And
            txtplanpicking1.value <> "" And txtplanpacking1.value <> "" Then

            Dim MyInfo As String = mychef.uplano(mysql.bersih(txtListPicking1.Text).Trim(), Session("gKodeDC"),
                    txtidKedatangan1.value, cboCabang1.Value, cboExpedisi1.Value, cbojeniskend1.Value,
                    txtidKonsol1.value, txtsLoading1.value, txtfLoading1.value, txtsSuratJalan1.value, txtfSuratJalan1.value,
                    Session("gUserName"), txtplanpicking1.value, txtplanpacking1.value)
            If MyInfo.Substring(1, 1) = "1" Then
                Myalert(MyInfo.Substring(2))
            Else
                MyRefresh()
            End If
        Else
            Myalert("Data tidak lengkap")
        End If

    End Sub

    Private Sub btnDelete2_ServerClick(sender As Object, e As EventArgs) Handles btnDelete2.ServerClick
        Dim MyInfo As String = mychef.dplano(mysql.bersih(txtListPicking1.Text).Trim(), Session("gKodeDC"))
        If MyInfo.Substring(1, 1) = "1" Then
            Myalert(MyInfo.Substring(2))
        Else
            MyRefresh()
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


    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)

        Try

            Dim conStr As String = ""

            'Select Case Extension

            '    Case ".xl" 's"

            '        'Excel 97-03

            '        conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString

            '        Exit Select

            '    Case ".xls" 'x"

            'Excel 07

            conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString

            '        Exit Select

            'End Select

            conStr = String.Format(conStr, FilePath, isHDR)



            Dim connExcel As New OleDbConnection(conStr)
            Dim cmdExcel As New OleDbCommand()
            Dim oda As New OleDbDataAdapter()
            Dim dt As New DataTable()



            cmdExcel.Connection = connExcel



            'Get the name of First Sheet

            connExcel.Open()

            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
            connExcel.Close()



            'Read Data from First Sheet
            'dt.Columns(5).ToString()

            connExcel.Open()
            cmdExcel.CommandText = "SELECT * From [" & SheetName & "] where [ASAL]='" & Session("gKodeDC") & "'"
            oda.SelectCommand = cmdExcel
            oda.Fill(dt)
            connExcel.Close()

            Dim verror As Double = 0
            Dim verrorstr As String = ""

            Dim MyErr As String = ""
            If dt.Rows.Count > 0 Then
                ''Getetos.delete_etos_keranjang(Session("UsrIDx"))

                Dim vASAL As String
                Dim vTUJUAN As String
                Dim vLIST_PICKING As String
                Dim vKODE_EXPEDISI As String
                Dim vKODE_KENDARAAN As String
                Dim vRENCANA_KEDATANGAN As Date
                Dim vRENCANA_PICKING As Date
                Dim vRENCANA_PACKING As Date
                Dim vRENCANA_CONSOL As Date
                Dim vRENCANA_START_LOADING As Date
                Dim vRENCANA_FINISH_LOADING As Date
                Dim vRENCANA_START_SJ As Date
                Dim vRENCANA_FINISH_SJ As Date

                For i = 1 To dt.Rows.Count - 1

                    vASAL = dt.Rows(i).Item("ASAL")
                    vTUJUAN = dt.Rows(i).Item("TUJUAN")
                    vLIST_PICKING = dt.Rows(i).Item("LIST PICKING")
                    vKODE_EXPEDISI = dt.Rows(i).Item("KODE EXPEDISI")
                    vKODE_KENDARAAN = dt.Rows(i).Item("KODE KENDARAAN")
                    vRENCANA_KEDATANGAN = dt.Rows(i).Item("RENCANA KEDATANGAN")
                    vRENCANA_PICKING = dt.Rows(i).Item("RENCANA PICKING")
                    vRENCANA_PACKING = dt.Rows(i).Item("RENCANA PACKING")
                    vRENCANA_CONSOL = dt.Rows(i).Item("RENCANA CONSOL")
                    vRENCANA_START_LOADING = dt.Rows(i).Item("RENCANA START LOADING")
                    vRENCANA_FINISH_LOADING = dt.Rows(i).Item("RENCANA FINISH LOADING")
                    vRENCANA_START_SJ = dt.Rows(i).Item("RENCANA START SJ")
                    vRENCANA_FINISH_SJ = dt.Rows(i).Item("RENCANA FINISH SJ")

                    Dim mybatch As String = Now.ToString("yyMMddHHmmss" & Session("gUserName"))

                    verrorstr = mychef.iplano(mysql.bersih(vLIST_PICKING).Trim(), Session("gKodeDC"),
                    vRENCANA_KEDATANGAN.ToString("yyyy-MM-ddTHH:mm"), vTUJUAN, vKODE_EXPEDISI, vKODE_KENDARAAN,
                    vRENCANA_CONSOL.ToString("yyyy-MM-ddTHH:mm"), vRENCANA_START_LOADING.ToString("yyyy-MM-ddTHH:mm"), vRENCANA_FINISH_LOADING.ToString("yyyy-MM-ddTHH:mm"),
                    vRENCANA_START_SJ.ToString("yyyy-MM-ddTHH:mm"), vRENCANA_FINISH_SJ.ToString("yyyy-MM-ddTHH:mm"),
                    Session("gUserName"), vRENCANA_PICKING.ToString("yyyy-MM-ddTHH:mm"), vRENCANA_PACKING.ToString("yyyy-MM-ddTHH:mm"), mybatch)

                    If verrorstr.Substring(1, 1) = "1" Then
                        verror = verror + 1
                        MyErr = MyErr & "-br-" & verrorstr.Substring(2)

                    End If
                Next
                If verror = 0 Then
                    javamessage("Data order berhasil di upload!")
                    myuploaderror.Text = "Data order berhasil di upload!"
                Else
                    javamessage("Data order berhasil di upload, namun tidak sempurna!")
                    myuploaderror.Text = "Data order berhasil di upload, namun tidak sempurna!" & MyErr
                End If

            Else
                javamessage("Tidak ada data yang diupload!")
                myuploaderror.Text = "Tidak ada data yang diupload!"
            End If

        Catch ex As Exception
            javamessage("Proses upload order gagal!")
            myuploaderror.Text = "Proses upload order gagal!"

        End Try

    End Sub

    Private Sub btnimptemp_ServerClick(sender As Object, e As EventArgs) Handles btnimptemp.ServerClick

        myuploaderror.Text = ""

        Try

            If FileUpload1.HasFile Then

                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)

                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

                If UCase(Extension) = ".XLS" Or UCase(Extension) = ".XLSX" Then

                    Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")



                    Dim FilePath As String = Server.MapPath(FolderPath + Now.ToString("yyMMddHHmmss") + FileName)

                    FileUpload1.SaveAs(FilePath)

                    Import_To_Grid(FilePath, Extension, "Yes") 'rbHDR.SelectedItem.Text)
                Else
                    javamessage("FIle yang diupload harus file Excel")

                End If

            End If

        Catch ex As Exception
            javamessage("Proses upload order gagal!")
            myuploaderror.Text = "Proses upload order gagal!"

        End Try



    End Sub

    Private Sub mygo_ServerClick(sender As Object, e As EventArgs) Handles mygo.ServerClick
        If txtdatefrom.value <> "" And txtdatefrom.value <> "" Then
            MyRefresh()
        End If
    End Sub
End Class
