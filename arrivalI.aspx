<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="arrivalI.aspx.vb" Inherits="arrivalI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div id="mydiv1" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Kedatangan Kendaraan - Inbound</b>
</div>

    <div id="mydiv" style="text-align:center;font-family:arial;font-size:24px;color:rgb(47,43,43)">
<%--        <br />
        <b>Kedatangan Kendaraan - Inbound</b>--%>

        <div style="margin-left:-350px;margin-top:15px;position:fixed;left:50%;">
            <div style="
                border-radius: 15px;
                border: 2px solid rgb(232, 233, 237);
                background-color: rgb(232, 233, 237);
                padding: 20px; 
                width: 700px;text-align:center;
                ">

        <table style="width:698px;font-family:arial;font-size:16px;color:rgb(47,43,43)">
            <tr>
                <td style="text-align:right">Expedisi</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <select id="cboExpedisi" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                      
                    <input type="text" id="txtExpedisi" name="txtExpedisi" maxlength="100" placeholdeR="Nama Ekspedisi" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server" />

                </td>
                <td style="text-align: left">
                    <input type="button" id="BtnAdd" name="BtnAdd" value="Tambah Ekspedisi" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Jenis Kendaraan</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <select id="cbojeniskend" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
                <td rowspan="5" style="text-align:left"><b>Catatan :</b><br /><br />Simpan data<br />setelah menerima<br />dokumen dari<br />Expedisi
                      
                    

                </td>
            </tr>
            <tr>
                <td style="text-align:right">Nomor Kendaraan</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <input type="text" id="txtnomorkend" name="txtnomorkend" maxlength="20" placeholdeR="Nomor Kendaraan" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Nama Driver</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <input type="text" id="txtnamadriver" name="txtnamadriver" maxlength="100" placeholder="Nama Driver" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Antrian</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <select name="cbojeniskend" id="cboantrian" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                        <option value="Q">Queue</option>
                        <option value="N">Non Queue</option>
                      </select>
                </td>
            </tr>
            <tr><td colspan="1">
            <input type="button" id="btnsimpan" name="btnsimpan" value="Simpan" runat="server" />
                </td>
                <td colspan="2"><label id="lblerror" style="color:red" runat="server"></label>
                </td>
            </tr>
        </table>

</div></div>

    </div>


</asp:Content>

