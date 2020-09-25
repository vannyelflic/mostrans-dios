
Partial Class arrivalo
    Inherits System.Web.UI.Page

    Public mysql As New Mysql
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

        End If
    End Sub

    Private Sub btnsimpan_ServerClick(sender As Object, e As EventArgs) Handles btnsimpan.ServerClick
        Dim mydc As String = Session("gKodeDC")
        Dim myerr As String = ""
        If TxtListPick.value = "" Or cboExpedisi.Value = "" Or cbojeniskend.Value = "" Or txtnomorkend.Value = "" Or txtnamadriver.Value = "" Then
            lblerror.InnerText = "Penyimpanan data" & vbCrLf & "gagal." & vbCrLf & "Data tidak" & vbCrLf & "lengkap"
        Else
            myerr = mychef.Wwo(TxtListPick.Value, mydc, cboExpedisi.Value, cbojeniskend.Value)
            If myerr = "0" Then
                myerr = mychef.Wo(TxtListPick.Value, mydc, cboExpedisi.Value, cbojeniskend.Value, mysql.bersihU(txtnomorkend.Value), mysql.bersihU(txtnamadriver.Value), Session("gUserName"))
                If Mid(myerr, 1, 1) = "0" Then
                    lblerror.InnerText = "Data berhasil disimpan"
                    TxtListPick.Value = ""
                    cboExpedisi.Value = ""
                    cbojeniskend.Value = ""
                    txtnomorkend.Value = ""
                    txtnamadriver.Value = ""
                Else
                    lblerror.InnerText = Mid(myerr, 2)
                End If
            Else
                lblerror.InnerText = "Tidak ada jadwal Anda hari ini"
            End If
        End If
    End Sub
End Class
