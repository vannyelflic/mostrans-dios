<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="arrivalo.aspx.vb" Inherits="arrivalo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <div id="mydiv1" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Kedatangan Kendaraan - Outbound</b>
</div>

    <div id="mydiv" style="text-align:center;font-family:arial;font-size:24px;color:rgb(47,43,43)">
        <%--<br />
        <b>Kedatangan Kendaraan - Outbound</b>--%>

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
                <td style="text-align:right">List Picking No</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <input type="text" id="TxtListPick" name="txtListPick" maxlength="20" placeholder="List Picking No" style="width:150px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Expedisi</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <select id="cboExpedisi" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Jenis Kendaraan</td>
                <td>&nbsp;</td>
                <td style="text-align:left">
                      <select id="cbojeniskend" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
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

