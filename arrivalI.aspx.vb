
Partial Class arrivalI
    Inherits System.Web.UI.Page

    Public mysql As New mysql
    Public mychef As New MyChef
    Public mydata As Data.DataSet

    Private Sub arrivalI_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Not IsPostBack Then

            mydata = mychef.WMExp

            cboExpedisi.Items.Clear()
            cboExpedisi.Items.Add("")
            For i = 0 To mydata.Tables(0).Rows.Count - 1
                With cboExpedisi
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
            Next

            mydata = mychef.WMKend

            cbojeniskend.Items.Clear()
            cbojeniskend.Items.Add("")
            For i = 0 To mydata.Tables(0).Rows.Count - 1
                With cbojeniskend
                    .Items.Add(mydata.Tables(0).Rows(i).Item(1))
                    .Items(.Items.Count - 1).Value = mydata.Tables(0).Rows(i).Item(0)
                End With
            Next

            mydata.Clear()

            cboExpedisi.Visible = True
            txtExpedisi.Visible = False

        End If
    End Sub

    Private Sub btnsimpan_ServerClick(sender As Object, e As EventArgs) Handles btnsimpan.ServerClick
        Dim mydc As String = Session("gKodeDC")
        Dim myerr As String = ""
        Dim blanjut As Boolean = True
        txtnomorkend.Value = txtnomorkend.Value.Trim.ToUpper
        txtnamadriver.Value = txtnamadriver.Value.Trim

        If (cboExpedisi.Value = "" And cboExpedisi.Visible) Or
           (txtExpedisi.Value = "" And txtExpedisi.Visible) Or
            cbojeniskend.Value = "" Or txtnomorkend.Value = "" Or txtnamadriver.Value = "" Then
            lblerror.InnerText = "Penyimpanan data" & vbCrLf & "gagal." & vbCrLf & "Data tidak" & vbCrLf & "lengkap"
            blanjut = False
        End If
        If InStr(1, txtnomorkend.Value, "  ", CompareMethod.Text) <> 0 Then
            lblerror.InnerText = "Format no kendaraan tidak tepat"
            blanjut = False
        End If
        Dim mydim
        mydim = Split(txtnomorkend.Value, " ")
        If mydim.length <> 3 Then
            lblerror.InnerText = "Format no kendaraan tidak tepat"
            blanjut = False
        End If

        If blanjut Then

            If Not cboExpedisi.Visible Then
                cboExpedisi.Value = ""
            End If
            If Not txtExpedisi.Visible Then
                txtExpedisi.Value = ""
            End If

            Dim myseq = mychef.WSEQ(mydc)
            myerr = mychef.Wi(mydc, myseq, cboExpedisi.Value, cbojeniskend.Value, mysql.bersihU(txtnomorkend.Value), mysql.bersihU(txtnamadriver.Value), Session("gUserName"), cboantrian.Value, mysql.bersih(txtExpedisi.Value))
            If Mid(myerr, 1, 1) = "0" Then
                lblerror.InnerText = Mid(myerr, 2) & ". Nomor Antrian " & myseq
                cboExpedisi.Value = ""
                cbojeniskend.Value = ""
                txtnomorkend.Value = ""
                txtnamadriver.Value = ""

                If txtExpedisi.Visible Then
                    Response.Redirect("arrivali.aspx?ix=" & Request.QueryString("ix"))
                End If

            Else
                lblerror.InnerText = Mid(myerr, 2)
            End If
        End If
    End Sub

    Private Sub BtnAdd_ServerClick(sender As Object, e As EventArgs) Handles BtnAdd.ServerClick

        Dim mytrue As Boolean = cboExpedisi.Visible
        cboExpedisi.Visible = Not mytrue
        txtExpedisi.Visible = mytrue
        If BtnAdd.Value = "Tambah Ekspedisi" Then
            BtnAdd.Value = "Pilih Ekspedisi"
        Else
            BtnAdd.Value = "Tambah Ekspedisi"
            txtExpedisi.Value = ""
        End If

    End Sub
End Class

