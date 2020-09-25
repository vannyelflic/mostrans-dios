<%@ Page Language="VB" AutoEventWireup="false" CodeFile="OutDashboard.aspx.vb" Inherits="OutDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PT. Enseval Putera Megatrading Tbk.</title>
    <link rel="icon" href="images/epm.png">


</head>
<body>

            <img src="images/Mostrans2.png" style="width:120px ; height:83px" />

<div id="mydiv" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Outbound Dashboard</b>
</div>
<div id="mydiv1" style="font-family:arial;font-size:12px;color:rgb(47,43,43);position:absolute;right:420px;top:35px;">
        <a id="MENU0000" runat="server" href="main.aspx?ix=<%=myix%>">Main Menu</a>
</div>

    <asp:label runat="server" ID="mylabelinfo" Width="0" Height="0" ForeColor="white"></asp:label>
    <asp:label runat="server" ID="mylabelinfo1" Width="0" Height="0" ForeColor="white"></asp:label>

        <div style="position:absolute;right:30px;top:10px;font-family:arial;color:rgb(20, 18, 18)">
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


        <div style="position:absolute;left:1px;top:87px;">

    
            <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

            <table>
                <tr>
                    <td valign="top">
                        <table>
                            <tr><td style="text-align:center; font-size: 18px; background-color:rgb(43, 143, 146); color: white">Complete Outbound
                            </td></tr>                                 
                            <tr><td align="center">                                 
                               <div id="chart_div" style="width: 800px; height: 350px"></div>
                             </td></tr>
                            <tr><td align="center">                                 
                                <div id="donutchart1" style="width: 350px; height: 150px;"></div>
                             </td></tr>
                         </table>
                     </td>
                    <td valign="top">
                        <table>
                            <tr><td style="text-align:center; font-size: 18px; background-color:rgb(43, 143, 146); color: white">On Time Arrival</td>
                                <td style="text-align:center; font-size: 18px; background-color:rgb(43, 143, 146); color: white">On Time Consolidation</td></tr>
                            <tr><td style="text-align:center;"><div id="donutchart2" style="width: 250px; height: 150px;"></div></td><td style="text-align:center;"><div id="donutchart3" style="width: 250px; height: 150px;"></div></td></tr>
                            <tr><td style="text-align:center; font-size: 18px; background-color:rgb(43, 143, 146); color: white">On Time Start Loading</td>
                                <td style="text-align:center; font-size: 18px; background-color:rgb(43, 143, 146); color: white">On Time Finish Loading</td></tr>
                            <tr><td style="text-align:center;"><div id="donutchart4" style="width: 250px; height: 150px;"></div></td><td style="text-align:center;"><div id="donutchart5" style="width: 250px; height: 150px;"></div></td></tr>
                            <tr><td style="text-align:center; font-size: 18px; background-color:rgb(43, 143, 146); color: white">On Time Start Surat Jalan</td>
                                <td style="text-align:center; font-size: 18px; background-color:rgb(43, 143, 146); color: white">On Time Finish Surat Jalan</td></tr>
                            <tr><td style="text-align:center;"><div id="donutchart6" style="width: 250px; height: 150px;"></div></td><td style="text-align:center;"><div id="donutchart7" style="width: 250px; height: 150px;"></div></td></tr>
                        </table>
                    </td>
                 </tr>
            </table>
            
              <script type="text/javascript">

                google.charts.load('current', {packages: ['corechart', 'line']});
                google.charts.setOnLoadCallback(drawLineColors);

                function drawLineColors() {
                      var data = new google.visualization.DataTable();
                      data.addColumn('number', 'X');
                      data.addColumn('number', 'Target');
                      data.addColumn('number', 'Actual');

                    data.addRows([
                          <%= stringCompleteLine %>
                      ]);

                      var options = {
                        hAxis: {
                          title: 'Time'
                        },
                        vAxis: {
                          title: 'List Picking'
                        },
                        colors: ['#097138','#a52714']
                      };

                      var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
                      chart.draw(data, options);
                    }
              </script>

              <script type="text/javascript">


                  drawpie('donutchart1',<%=p1%> ,<%=a1%> , 'Complete', 'Outstanding');
                  drawpie('donutchart2',<%=p2%> ,<%=a2%> ,'Hit', 'No Hit' );
                  drawpie('donutchart3',<%=p3%> ,<%=a3%> ,'Hit', 'No Hit' );
                  drawpie('donutchart4',<%=p4%> ,<%=a4%> ,'Hit', 'No Hit' );
                  drawpie('donutchart5',<%=p5%> ,<%=a5%> ,'Hit', 'No Hit' );
                  drawpie('donutchart6',<%=p6%> ,<%=a6%> ,'Hit', 'No Hit' );
                  drawpie('donutchart7',<%=p7%> ,<%=a7%> ,'Hit', 'No Hit' );

                  function drawpie(a, b, c, d, e) {
                      google.charts.load("current", { packages: ["corechart"] });
                      google.charts.setOnLoadCallback(drawChart);
                      function drawChart() {
                          var data = google.visualization.arrayToDataTable([
                              ['List Picking', 'Hit'],
                              [d, b],
                              [e, c]
                          ]);

                          var options = {
                              pieHole: 0.4,
                          };
                          //title: 'My Daily Activities',

                          var chart = new google.visualization.PieChart(document.getElementById(a));
                          chart.draw(data, options);
                      }
                  }
                </script>

        </div>



</body>
</html>
