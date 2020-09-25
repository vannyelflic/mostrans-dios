<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lcdinbound.aspx.vb" Inherits="lcdinbound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PT. Enseval Putera Megatrading Tbk.</title>
    <link rel="icon" href="images/epm.png">

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
        $.ajax({
            type: "POST",
            url: "lcdinbound.aspx/Getdata",
            data: '{nama: "' + document.getElementById('mylabelinfo1').innerText + '"}',
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
        var ndata = data.split("|");
        var len = ndata.length;
        var n1, n2, n3, n4, n5, n6, n7, n8, n9, n16, n16a;
        var res;

        for (var i = 0; i < len; i++) {
             ndata1 = ndata[i].split("~");
             n1 = "<b>" + ndata1[0] + "</b>";
             n2 = "<b>" + ndata1[1] + "</b>";
             n3 = "<b>" + ndata1[2] + "</b>";
             n4 = "<b>" + ndata1[3] + "</b>";
             n5 = "<b>" + ndata1[4] + "</b>";
             n6 = "<b>" + ndata1[5] + "</b>";
             n7 = "<b>" + ndata1[6] + "</b>";
             n8 = "<b>" + ndata1[7] + "</b>";
             n9 = "<b>" + ndata1[8] + "</b>";

            n16a = ndata1[9];

            if (n16a == '')
            {
                n16 = "<b>&nbsp;</b>";
            }
            else
            {
                n16 = "<b>" + n16a + "</b>";
            };  

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

            document.getElementById(res + "05A").innerHTML = n16; 

        }
    }
</script> 


</head>
<body>

            <img src="images/Mostrans2.png" style="width:150px ; height:105px" />

<div id="mydiv" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:45px;">
        <b>Inbound Monitoring</b>
</div>
<div id="mydiv1" style="font-family:arial;font-size:12px;color:rgb(47,43,43);position:absolute;right:420px;top:53px;">
        <a id="MENU0000" runat="server" href="main.aspx?ix=<%=myix%>">Main Menu</a>
</div>

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

        <div style="position:absolute;left:1px;top:120px;">
            <table id="myTable" >
                <tr>
                    <th rowspan="2">Queue Number</th>
                    <th rowspan="2">Expedition</th>
                    <th rowspan="2">Vehicle Type</th>
                    <th rowspan="2">Vehicle Number</th>
                    <th rowspan="2">Arrival Time</th>
                    <th colspan="3">Unloading</th>
                    <th rowspan="2">Information</th>
                    <th rowspan="2">Status</th>
                </tr>
                <tr>
                    <th>PIC</th>
                    <th>Start</th>
                    <th>Finish</th>
                </tr>
                <tr>
                    <td id="A01">&nbsp;</td>
                    <td id="A02">&nbsp;</td>
                    <td id="A03">&nbsp;</td>
                    <td id="A04">&nbsp;</td>
                    <td id="A05">&nbsp;</td>
                    <td id="A05A">&nbsp;</td>
                    <td id="A06">&nbsp;</td>
                    <td id="A07">&nbsp;</td>
                    <td id="A08">&nbsp;</td>
                    <td id="A09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="B01">&nbsp;</td>
                    <td id="B02">&nbsp;</td>
                    <td id="B03">&nbsp;</td>
                    <td id="B04">&nbsp;</td>
                    <td id="B05">&nbsp;</td>
                    <td id="B05A">&nbsp;</td>
                    <td id="B06">&nbsp;</td>
                    <td id="B07">&nbsp;</td>
                    <td id="B08">&nbsp;</td>
                    <td id="B09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="C01">&nbsp;</td>
                    <td id="C02">&nbsp;</td>
                    <td id="C03">&nbsp;</td>
                    <td id="C04">&nbsp;</td>
                    <td id="C05">&nbsp;</td>
                    <td id="C05A">&nbsp;</td>
                    <td id="C06">&nbsp;</td>
                    <td id="C07">&nbsp;</td>
                    <td id="C08">&nbsp;</td>
                    <td id="C09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="D01">&nbsp;</td>
                    <td id="D02">&nbsp;</td>
                    <td id="D03">&nbsp;</td>
                    <td id="D04">&nbsp;</td>
                    <td id="D05">&nbsp;</td>
                    <td id="D05A">&nbsp;</td>
                    <td id="D06">&nbsp;</td>
                    <td id="D07">&nbsp;</td>
                    <td id="D08">&nbsp;</td>
                    <td id="D09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="E01">&nbsp;</td>
                    <td id="E02">&nbsp;</td>
                    <td id="E03">&nbsp;</td>
                    <td id="E04">&nbsp;</td>
                    <td id="E05">&nbsp;</td>
                    <td id="E05A">&nbsp;</td>
                    <td id="E06">&nbsp;</td>
                    <td id="E07">&nbsp;</td>
                    <td id="E08">&nbsp;</td>
                    <td id="E09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="F01">&nbsp;</td>
                    <td id="F02">&nbsp;</td>
                    <td id="F03">&nbsp;</td>
                    <td id="F04">&nbsp;</td>
                    <td id="F05">&nbsp;</td>
                    <td id="F05A">&nbsp;</td>
                    <td id="F06">&nbsp;</td>
                    <td id="F07">&nbsp;</td>
                    <td id="F08">&nbsp;</td>
                    <td id="F09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="G01">&nbsp;</td>
                    <td id="G02">&nbsp;</td>
                    <td id="G03">&nbsp;</td>
                    <td id="G04">&nbsp;</td>
                    <td id="G05">&nbsp;</td>
                    <td id="G05A">&nbsp;</td>
                    <td id="G06">&nbsp;</td>
                    <td id="G07">&nbsp;</td>
                    <td id="G08">&nbsp;</td>
                    <td id="G09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="H01">&nbsp;</td>
                    <td id="H02">&nbsp;</td>
                    <td id="H03">&nbsp;</td>
                    <td id="H04">&nbsp;</td>
                    <td id="H05">&nbsp;</td>
                    <td id="H05A">&nbsp;</td>
                    <td id="H06">&nbsp;</td>
                    <td id="H07">&nbsp;</td>
                    <td id="H08">&nbsp;</td>
                    <td id="H09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="I01">&nbsp;</td>
                    <td id="I02">&nbsp;</td>
                    <td id="I03">&nbsp;</td>
                    <td id="I04">&nbsp;</td>
                    <td id="I05">&nbsp;</td>
                    <td id="I05A">&nbsp;</td>
                    <td id="I06">&nbsp;</td>
                    <td id="I07">&nbsp;</td>
                    <td id="I08">&nbsp;</td>
                    <td id="I09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="J01">&nbsp;</td>
                    <td id="J02">&nbsp;</td>
                    <td id="J03">&nbsp;</td>
                    <td id="J04">&nbsp;</td>
                    <td id="J05">&nbsp;</td>
                    <td id="J05A">&nbsp;</td>
                    <td id="J06">&nbsp;</td>
                    <td id="J07">&nbsp;</td>
                    <td id="J08">&nbsp;</td>
                    <td id="J09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="K01">&nbsp;</td>
                    <td id="K02">&nbsp;</td>
                    <td id="K03">&nbsp;</td>
                    <td id="K04">&nbsp;</td>
                    <td id="K05">&nbsp;</td>
                    <td id="K05A">&nbsp;</td>
                    <td id="K06">&nbsp;</td>
                    <td id="K07">&nbsp;</td>
                    <td id="K08">&nbsp;</td>
                    <td id="K09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="L01">&nbsp;</td>
                    <td id="L02">&nbsp;</td>
                    <td id="L03">&nbsp;</td>
                    <td id="L04">&nbsp;</td>
                    <td id="L05">&nbsp;</td>
                    <td id="L05A">&nbsp;</td>
                    <td id="L06">&nbsp;</td>
                    <td id="L07">&nbsp;</td>
                    <td id="L08">&nbsp;</td>
                    <td id="L09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="M01">&nbsp;</td>
                    <td id="M02">&nbsp;</td>
                    <td id="M03">&nbsp;</td>
                    <td id="M04">&nbsp;</td>
                    <td id="M05">&nbsp;</td>
                    <td id="M05A">&nbsp;</td>
                    <td id="M06">&nbsp;</td>
                    <td id="M07">&nbsp;</td>
                    <td id="M08">&nbsp;</td>
                    <td id="M09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="N01">&nbsp;</td>
                    <td id="N02">&nbsp;</td>
                    <td id="N03">&nbsp;</td>
                    <td id="N04">&nbsp;</td>
                    <td id="N05">&nbsp;</td>
                    <td id="N05A">&nbsp;</td>
                    <td id="N06">&nbsp;</td>
                    <td id="N07">&nbsp;</td>
                    <td id="N08">&nbsp;</td>
                    <td id="N09">&nbsp;</td>
                </tr>
                <tr>
                    <td id="O01">&nbsp;</td>
                    <td id="O02">&nbsp;</td>
                    <td id="O03">&nbsp;</td>
                    <td id="O04">&nbsp;</td>
                    <td id="O05">&nbsp;</td>
                    <td id="O05A">&nbsp;</td>
                    <td id="O06">&nbsp;</td>
                    <td id="O07">&nbsp;</td>
                    <td id="O08">&nbsp;</td>
                    <td id="O09">&nbsp;</td>
                </tr>




            </table>
        </div>



</body>
</html>
