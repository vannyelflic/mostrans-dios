﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lcdoutbound.aspx.vb" Inherits="lcdoutbound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PT. Enseval Putera Megatrading Tbk.</title>
    <link rel="icon" href="images/epm.png" />

    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>

<style>

table {
    border-collapse: collapse;
    border-spacing: 0;
    width: 100%;
    height: 100%;
    border: 1px solid rgb(128, 128, 128);
    margin:0;
    padding:0;
    table-layout: auto;
    white-space: nowrap;
}

.uprightTbl * {
    border-collapse: collapse;
    padding: 0;
    margin: 0;
}

th {
    text-align: left;
    padding: 5px;
    margin:0px;
    width:1%;
    white-space:nowrap;
    text-align: center; font-size: 18px; background-color:rgb(11, 101, 54); /*:rgb(43, 143, 146);*/
    color:white;
    font-family:Arial;
}

td {
    text-align: left;
    padding: 5px;
    margin:0px;
    width:1%;
    white-space:nowrap;
    text-align: center; font-size: 16px; background-color:rgb(232, 233, 237);
    color:rgb(20, 18, 18);
    font-family:Arial;
}


tr:nth-child(even){background-color: #f2f2f2}

@font-face {
  font-family: 'Arial, Verdana';
  src: url('Volkhov-Bold.ttf');
}

table{
    width:100%;
    height:100%;
    border:1px solid white;
}
table td{
    white-space: nowrap;
    font-size: 18px;
    border:1px solid white;
    padding-top:10px;
    padding-bottom:10px;
}
table th{
    white-space: nowrap;
    font-size: 18px;
    border:1px solid white;
    padding-top:10px;
    padding-bottom:10px;
}
table tr{
    white-space: nowrap;
    font-size: 18px;
    border:1px solid white;
}

</style>

<script type = "text/javascript">

    window.onload = function () {
        document.getElementById('myTable').style.width = (screen.availWidth-2) + 'px'; 
        ShowCurrentTime()
        setInterval(function () { ShowCurrentTime() }, 60000);
    };

    

    function ShowCurrentTime() {

        var a = parseInt(document.getElementById('lblpage').innerText) + 1;

        $.ajax({
            type: "POST",
            url: "lcdoutbound.aspx/GetdataXX",
            data: '{nama: "' + document.getElementById('mylabelinfo1').innerText + '", strupdate: "' + document.getElementById('chkUpdate').checked + '", npage: "' + a + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });
    }


    function OnSuccess(response) {

        var table = document.getElementById('myTable');
      
        var data = response.d;

        var xxdata = data.split("`");

        var ndatapage = xxdata[1].split("~");

        document.getElementById('lblpage').innerText = ndatapage[0]
        document.getElementById('lbltpage').innerText = ndatapage[1]

        var ndata = xxdata[0].split("|");
        var len = ndata.length;
        var n1, n2, n3, n4, n5, n6, n7, n8, n9, n11;
        var res;

        
            for (var i = 0; i < len; i++) {

                wdata = ndata[i].split("^");
                wdata1 = wdata[1];
                ndata1 = wdata[0].split("~");
                ndata2 = wdata[1].split("~");
                n1 = "<b>" + ndata1[0] + "</b>";
                n2 = "<b>" + ndata1[1] + "</b>";
                n3 = "<b>" + ndata1[2] + "</b>";

                //alert(ndata1[0]);

                if (ndata1[0] == "&nbsp;") { n4 = "&nbsp;" }
                else {
                    if (ndata1[3] == "" || ndata1[3] == "Z") {
                        if (ndata2[2] == "W") { n4 = "<b><img src='images/truckempty.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[0] + "<br/>" + factl("ACTL " + ndata2[1]) + "</div></b>"; }
                        else if (ndata2[2] == "R") { n4 = "<b><img src='images/trucknotok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[0] + "<br/>ACTL " + ndata2[1] + "</div></b>"; }
                        else { n4 = "<b><img src='images/truckok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[0] + "<br/>ACTL " + ndata2[1] + "</div></b>"; }
                    }
                    else if (ndata1[3] == "N") { n4 = "<b><img src='images/redtruck.png' /></br><div style='font-size:14px'>PLAN " + ndata2[0] + "<br/>ACTL " + ndata1[10] + "</div></b>"; }
                    else { n4 = "<b><img src='images/greentruck.png' /></br><div style='font-size:14px'>PLAN " + ndata2[0] + "<br/>ACTL " + ndata1[10] + "</div></b>"; }
                }

                if (ndata1[0] == "&nbsp;") { n5 = "&nbsp;" }
                else {
                    if (ndata1[4] == "" || ndata1[4] == "Z") {
                        if (ndata2[5] == "W") { n5 = "<b><img src='images/truckempty.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[3] + "<br/>" + factl("ACTL " + ndata2[4]) + "</div></b>"; }
                        else if (ndata2[5] == "R") { n5 = "<b><img src='images/trucknotok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[3] + "<br/>ACTL " + ndata2[4] + "</div></b>"; }
                        else { n5 = "<b><img src='images/truckok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[3] + "<br/>ACTL " + ndata2[4] + "</div></b>"; }
                    }
                    else if (ndata1[4] == "N") { n5 = "<b><img src='images/redtruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[3] + "<br/>ACTL " + ndata1[11] + "</div></b>"; }
                    else { n5 = "<b><img src='images/greentruck.png' /></br><div style='font-size:14px'>PLAN " + ndata2[3] + "<br/>ACTL " + ndata1[11] + "</div></b>"; }
                }

                if (ndata1[0] == "&nbsp;") { n6 = "&nbsp;" }
                else {
                    if (ndata1[5] == "" || ndata1[5] == "Z") {
                        if (ndata2[8] == "W") { n6 = "<b><img src='images/truckempty.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[6] + "<br/>" + factl("ACTL " + ndata2[7]) + "</div></b>"; }
                        else if (ndata2[8] == "R") { n6 = "<b><img src='images/trucknotok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[6] + "<br/>ACTL " + ndata2[7] + "</div></b>"; }
                        else { n6 = "<b><img src='images/truckok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[6] + "<br/>ACTL " + ndata2[7] + "</div></b>"; }
                    }
                    else if (ndata1[5] == "N") { n6 = "<b><img src='images/redtruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[6] + "<br/>ACTL " + ndata1[12] + "</div></b>"; }
                    else { n6 = "<b><img src='images/greentruck.png' /></br><div style='font-size:14px'>PLAN " + ndata2[6] + "<br/>ACTL " + ndata1[12] + "</div></b>"; }
                }

                if (ndata1[0] == "&nbsp;") { n7 = "&nbsp;" }
                else {
                    if (ndata1[6] == "" || ndata1[6] == "Z") {
                        if (ndata2[11] == "W") { n7 = "<b><img src='images/truckempty.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[9] + "<br/>" + factl("ACTL " + ndata2[10]) + "</div></b>"; }
                        else if (ndata2[11] == "R") { n7 = "<b><img src='images/trucknotok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[9] + "<br/>ACTL " + ndata2[10] + "</div></b>"; }
                        else { n7 = "<b><img src='images/truckok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[9] + "<br/>ACTL " + ndata2[10] + "</div></b>"; }
                    }
                    else if (ndata1[6] == "N") { n7 = "<b><img src='images/redtruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[9] + "<br/>ACTL " + ndata1[13] + "</div></b>"; }
                    else { n7 = "<b><img src='images/greentruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[9] + "<br/>ACTL " + ndata1[13] + "</div></b>"; }
                }

                if (ndata1[0] == "&nbsp;") { n8 = "&nbsp;" }
                else {
                    if (ndata1[7] == "" || ndata1[7] == "Z") {
                        if (ndata2[14] == "W") { n8 = "<b><img src='images/truckempty.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[12] + "<br/>" + factl("ACTL " + ndata2[13]) + "</div></b>"; }
                        else if (ndata2[14] == "R") { n8 = "<b><img src='images/trucknotok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[12] + "<br/>ACTL " + ndata2[13] + "</div></b>"; }
                        else { n8 = "<b><img src='images/truckok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[12] + "<br/>ACTL " + ndata2[13] + "</div></b>"; }
                    }
                    else if (ndata1[7] == "N") { n8 = "<b><img src='images/redtruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[12] + "<br/>ACTL " + ndata1[14] + "</div></b>"; }
                    else { n8 = "<b><img src='images/greentruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[12] + "<br/>ACTL " + ndata1[14] + "</div></b>"; }
                }

                if (ndata1[0] == "&nbsp;") { n9 = "&nbsp;" }
                else {
                    if (ndata1[8] == "" || ndata1[8] == "Z") {
                        if (ndata2[17] == "W") { n9 = "<b><img src='images/truckempty.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[15] + "<br/>" + factl("ACTL " + ndata2[16]) + "</div></b>"; }
                        else if (ndata2[17] == "R") { n9 = "<b><img src='images/trucknotok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[15] + "<br/>ACTL " + ndata2[16] + "</div></b>"; }
                        else { n9 = "<b><img src='images/truckok.png' /></br><div style='font-size:14px;color:darkgrey'>PLAN " + ndata2[15] + "<br/>ACTL " + ndata2[16] + "</div></b>"; }
                    }
                    else if (ndata1[8] == "N") { n9 = "<b><img src='images/redtruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[15] + "<br/>ACTL " + ndata1[15] + "</div></b>"; }
                    else { n9 = "<b><img src='images/greentruck.png'  /></br><div style='font-size:14px'>PLAN " + ndata2[15] + "<br/>ACTL " + ndata1[15] + "</div></b>"; }
                }

                n11 = "<b>" + ndata1[9] + "</b>";

                res = String.fromCharCode(65 + i);

                document.getElementById(res + "01").innerHTML = n1;
                document.getElementById(res + "02").innerHTML = n2;
                document.getElementById(res + "03").innerHTML = n3;
                document.getElementById(res + "04").innerHTML = n4;
                document.getElementById(res + "05").innerHTML = n5;
                document.getElementById(res + "06").innerHTML = n6;
                document.getElementById(res + "07").innerHTML = n7;
                document.getElementById(res + "08").innerHTML = n8;
                document.getElementById(res + "09").innerHTML = n9;

                document.getElementById(res + "11").innerHTML = n11;

        }
    }

    function factl(a) {
        //alert(a);
        if (a == "ACTL ") { return "&nbsp;"; } { return a; };
    }

</script> 


</head>
<body>

            <img src="images/Mostrans2.png" style="width:150px ; height:105px" />

<div id="mydiv" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:45px;">
        <b>Outbound Monitoring</b>
</div>

<form runat="server">
<div id="mydiv1" style="font-family:arial;font-size:12px;color:rgb(47,43,43);position:absolute;right:420px;top:53px;">
        <a id="MENU0000" runat="server" href="main.aspx?ix=<%=myix%>">Main Menu</a><br />
        <div style="font-size:16px"><b>Halaman <label id="lblpage">0</label> dari <label id="lbltpage">0</label></b></div><br />
    <a style="display:<%=mydisplaycheck %>">
        <input type="checkbox" id="chkUpdate" value="Update"/> Update Data
        </a>
</div>
</form>

    <asp:label runat="server" ID="mylabelinfo" Width="0" Height="0" ForeColor="white"></asp:label>
    <asp:label runat="server" ID="mylabelinfo1" Width="0" Height="0" ForeColor="white"></asp:label>

        <div style="position:absolute;right:30px;top:27px;font-family:arial;color:rgb(20, 18, 18)">
                        <div style="font-size:14px">
                        Regional Distribution Center<br />
                        <b>PT. Enseval Putera Megatrading Tbk.</b><br /></div><div style="font-size:12px">
                        Rawagelam, Kawasan Industri Pulogadung, Jakarta Timur<br />
                            
                            <a href="#"><img src="images/if_social_media-38_3456228.png" style="width:20px;height:20px"" /></a>
                            <a href="#"><img src="images/if_social_media-09_3456209.png" style="width:20px;height:20px"" /></a>
                            <a href="#"><img src="images/if_social_media-17_3456201.png" style="width:20px;height:20px"" /></a>
                            <a href="#"><img src="images/if_social_media-44_3456223.png" style="width:20px;height:20px"" /></a>
                            <a href="mailto:bbayuaji@enseval.com"><img src="images/if_social_media-08_3456210.png" style="width:20px;height:20px"" /></a>
                            </div>
        </div>

<%--    <img src="images/greentruck.png" />--%>

        <div style="position:absolute;left:1px;top:120px;">
            <table id="myTable" >
                <tr>
                    <th rowspan="2">List<br />Picking No</th>
                    <th rowspan="2">Destination</th>
                    <th rowspan="2">Dock Door /<br />Staging Line</th>
                    <th rowspan="2">Vehicle<br />No</th>
                    <th rowspan="2">Arrival</th>
                    <th rowspan="2">Consol</th>
                    <th colspan="2">Loading</th>
                    <th colspan="2">Surat Jalan</th>
                </tr>
                <tr>
                    <th>Start</th>
                    <th>Finish</th>
                    <th>Start</th>
                    <th>Finish</th>
                </tr>
                <tr>
                    <td id="A01">&nbsp;</td>
                    <td id="A02">&nbsp;</td>
                    <td id="A03">&nbsp;</td>
                    <td id="A11">&nbsp;</td>
                    <td id="A04">&nbsp;</td>
                    <td id="A05">&nbsp;</td>
                    <td id="A06">&nbsp;</td>
                    <td id="A07">&nbsp;</td>
                    <td id="A08">&nbsp;</td>
                    <td id="A09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="B01">&nbsp;</td>
                    <td id="B02">&nbsp;</td>
                    <td id="B03">&nbsp;</td>
                    <td id="B11">&nbsp;</td>
                    <td id="B04">&nbsp;</td>
                    <td id="B05">&nbsp;</td>
                    <td id="B06">&nbsp;</td>
                    <td id="B07">&nbsp;</td>
                    <td id="B08">&nbsp;</td>
                    <td id="B09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="C01">&nbsp;</td>
                    <td id="C02">&nbsp;</td>
                    <td id="C03">&nbsp;</td>
                    <td id="C11">&nbsp;</td>
                    <td id="C04">&nbsp;</td>
                    <td id="C05">&nbsp;</td>
                    <td id="C06">&nbsp;</td>
                    <td id="C07">&nbsp;</td>
                    <td id="C08">&nbsp;</td>
                    <td id="C09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="D01">&nbsp;</td>
                    <td id="D02">&nbsp;</td>
                    <td id="D03">&nbsp;</td>
                    <td id="D11">&nbsp;</td>
                    <td id="D04">&nbsp;</td>
                    <td id="D05">&nbsp;</td>
                    <td id="D06">&nbsp;</td>
                    <td id="D07">&nbsp;</td>
                    <td id="D08">&nbsp;</td>
                    <td id="D09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="E01">&nbsp;</td>
                    <td id="E02">&nbsp;</td>
                    <td id="E03">&nbsp;</td>
                    <td id="E11">&nbsp;</td>
                    <td id="E04">&nbsp;</td>
                    <td id="E05">&nbsp;</td>
                    <td id="E06">&nbsp;</td>
                    <td id="E07">&nbsp;</td>
                    <td id="E08">&nbsp;</td>
                    <td id="E09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="F01">&nbsp;</td>
                    <td id="F02">&nbsp;</td>
                    <td id="F03">&nbsp;</td>
                    <td id="F11">&nbsp;</td>
                    <td id="F04">&nbsp;</td>
                    <td id="F05">&nbsp;</td>
                    <td id="F06">&nbsp;</td>
                    <td id="F07">&nbsp;</td>
                    <td id="F08">&nbsp;</td>
                    <td id="F09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="G01">&nbsp;</td>
                    <td id="G02">&nbsp;</td>
                    <td id="G03">&nbsp;</td>
                    <td id="G11">&nbsp;</td>
                    <td id="G04">&nbsp;</td>
                    <td id="G05">&nbsp;</td>
                    <td id="G06">&nbsp;</td>
                    <td id="G07">&nbsp;</td>
                    <td id="G08">&nbsp;</td>
                    <td id="G09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="H01">&nbsp;</td>
                    <td id="H02">&nbsp;</td>
                    <td id="H03">&nbsp;</td>
                    <td id="H11">&nbsp;</td>
                    <td id="H04">&nbsp;</td>
                    <td id="H05">&nbsp;</td>
                    <td id="H06">&nbsp;</td>
                    <td id="H07">&nbsp;</td>
                    <td id="H08">&nbsp;</td>
                    <td id="H09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="I01">&nbsp;</td>
                    <td id="I02">&nbsp;</td>
                    <td id="I03">&nbsp;</td>
                    <td id="I11">&nbsp;</td>
                    <td id="I04">&nbsp;</td>
                    <td id="I05">&nbsp;</td>
                    <td id="I06">&nbsp;</td>
                    <td id="I07">&nbsp;</td>
                    <td id="I08">&nbsp;</td>
                    <td id="I09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="J01">&nbsp;</td>
                    <td id="J02">&nbsp;</td>
                    <td id="J03">&nbsp;</td>
                    <td id="J11">&nbsp;</td>
                    <td id="J04">&nbsp;</td>
                    <td id="J05">&nbsp;</td>
                    <td id="J06">&nbsp;</td>
                    <td id="J07">&nbsp;</td>
                    <td id="J08">&nbsp;</td>
                    <td id="J09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="K01">&nbsp;</td>
                    <td id="K02">&nbsp;</td>
                    <td id="K03">&nbsp;</td>
                    <td id="K11">&nbsp;</td>
                    <td id="K04">&nbsp;</td>
                    <td id="K05">&nbsp;</td>
                    <td id="K06">&nbsp;</td>
                    <td id="K07">&nbsp;</td>
                    <td id="K08">&nbsp;</td>
                    <td id="K09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="L01">&nbsp;</td>
                    <td id="L02">&nbsp;</td>
                    <td id="L03">&nbsp;</td>
                    <td id="L11">&nbsp;</td>
                    <td id="L04">&nbsp;</td>
                    <td id="L05">&nbsp;</td>
                    <td id="L06">&nbsp;</td>
                    <td id="L07">&nbsp;</td>
                    <td id="L08">&nbsp;</td>
                    <td id="L09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="M01">&nbsp;</td>
                    <td id="M02">&nbsp;</td>
                    <td id="M03">&nbsp;</td>
                    <td id="M11">&nbsp;</td>
                    <td id="M04">&nbsp;</td>
                    <td id="M05">&nbsp;</td>
                    <td id="M06">&nbsp;</td>
                    <td id="M07">&nbsp;</td>
                    <td id="M08">&nbsp;</td>
                    <td id="M09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="N01">&nbsp;</td>
                    <td id="N02">&nbsp;</td>
                    <td id="N03">&nbsp;</td>
                    <td id="N11">&nbsp;</td>
                    <td id="N04">&nbsp;</td>
                    <td id="N05">&nbsp;</td>
                    <td id="N06">&nbsp;</td>
                    <td id="N07">&nbsp;</td>
                    <td id="N08">&nbsp;</td>
                    <td id="N09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="O01">&nbsp;</td>
                    <td id="O02">&nbsp;</td>
                    <td id="O03">&nbsp;</td>
                    <td id="O11">&nbsp;</td>
                    <td id="O04">&nbsp;</td>
                    <td id="O05">&nbsp;</td>
                    <td id="O06">&nbsp;</td>
                    <td id="O07">&nbsp;</td>
                    <td id="O08">&nbsp;</td>
                    <td id="O09">&nbsp;</td>
                </tr>




            </table>
        </div>




</body>
</html>