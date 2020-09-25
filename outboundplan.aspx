<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="outboundplan.aspx.vb" Inherits="outboundplan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script  type="text/javascript">
    $(document).ready(function () {
        var table = $('#mytable').DataTable({
            scrollY: "300px",
            scrollX: "800px",
            scrollCollapse: true,
            paging: true,
            bProcessing: true, // shows 'processing' label
            bStateSave: true, // presumably saves state for reloads
            fixedColumns: {
                leftColumns: 1
            }
        });
    });  



        function fnExcelReport(namatable) {
            var tab_text = "<table border='2px'><tr bgcolor='yellow'>";
            var textRange; var j = 0;
            tab = document.getElementById(namatable); // id of table

            for (j = 0 ; j < tab.rows.length ; j++) {
                tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
                //tab_text=tab_text+"</tr>";
            }

            tab_text = tab_text + "</table>";
            tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
            tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
            tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

            var ua = window.navigator.userAgent;
            var msie = ua.indexOf("MSIE ");

            if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
            {
                txtArea1.document.open("txt/html", "replace");
                txtArea1.document.write(tab_text);
                txtArea1.document.close();
                txtArea1.focus();
                sa = txtArea1.document.execCommand("SaveAs", true, "Say Thanks to Sumit.xls");
            }
            else                 //other browser not tested on IE 11
                sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));

            return (sa);
        }



</script>

    <div id="mydiv11" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Perencanaan - Outbound</b>
</div>


   <div id="mydiv" style="text-align:center;font-family:arial;font-size:24px;color:rgb(47,43,43)">
<%--        <br />
        <b>Perencanaan - Outbound</b>--%>

        <div id="mydiv1" style="font-size:12px;text-align:left;">

            <input style="width:100px" type='button' data-book-id='|||||||||' data-target='#formModalNew' data-toggle='modal' value="Add New" />
&nbsp;
            <input style="width:100px" type="button" value="Cabang" onclick="fnExcelReport('mytablecabang')" />
            <input style="width:100px" type="button" value="Ekspedisi" onclick="fnExcelReport('mytableexpedisi')" />
            <input style="width:100px" type="button" value="Kendaraan" onclick="fnExcelReport('mytablekendaraan')" />
            <input style="width:170px" type="button" value="Download Template" onclick="fnExcelReport('mytabletemplate')" />
            <input style="width:150px" type="button" value="Download Data" onclick="fnExcelReport('mytable')" />
    
&nbsp;
&nbsp;
            
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <input style="width:150px" id="btnimptemp" type="button" value="Upload Template" runat="server" />
            <div style="color:red"><asp:Label ID="myuploaderror" runat="server"></asp:Label></div>

            <br />
            Data dari tanggal : 
            <input type="date" ID="txtdatefrom" ClientIDMode="Static" runat="server" width="100px"/> s/d 
            <input type="date" ID="txtdateto" ClientIDMode="Static" runat="server" width="100px"/>
            <input id="mygo" style="width:75px" type="button" value="Go" runat="server"/>

        <asp:PlaceHolder runat="server" ID="myplc"></asp:PlaceHolder>

        </div>

    </div>

    <div id="formModalNew" tabindex="-1" role="dialog" aria-hidden="true"style="display: none; ">
        <table style="position: fixed; top:80px ; left:60px; background-color: ButtonFace; border: 5px; border-radius: 15px; padding: 20px; box-shadow: 5px 5px 5px gray;">
            <tr><td>

                <table>
            <tr>
                <td colspan="1" style="font-size:16px">List Picking No</td>
                <td colspan="1"><asp:TextBox ID="txtListPicking" ClientIDMode="Static" runat="server" style="width:150px;font-family:arial;font-size:16px;color:rgb(47,43,43)"></asp:TextBox>  </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Cabang Tujuan</td>
                <td colspan="1">
                    <select id="cboCabang" ClientIDMode="Static" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Nama Ekspedisi</td>
                <td colspan="1">
                    <select id="cboExpedisi" ClientIDMode="Static" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Jenis Kendaraan</td>
                <td colspan="1">
                     <select id="cbojeniskend" ClientIDMode="Static" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
           </tr>
                 </table>

            </td><td>

                <table>

            <tr>
                <td colspan="2" style="text-align:center;font-size:16px"">Rencana</td>
            </tr>
            <tr>
                <td>Kedatangan</td>
                <td>Picking</td>
            </tr>
            <tr>
                <td><input type="datetime-local" ID="txtidKedatangan" ClientIDMode="Static" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ID="txtplanpicking" ClientIDMode="Static" runat="server" width="100px"/></td>
            </tr>
            <tr>
                <td>Packing</td>
                <td>Consol</td>
            </tr>
            <tr>
                <td><input type="datetime-local" ID="txtplanpacking" ClientIDMode="Static" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ID="txtidKonsol" ClientIDMode="Static" runat="server" width="100px"/></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;font-size:16px">Plan Loading</td>
            </tr>
            <tr>
                <td>Start</td>
                <td>Finish</td>
            </tr>
            <tr>
                <td><input type="datetime-local"  ID="txtsLoading" ClientIDMode="Static" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ID="txtfLoading" ClientIDMode="Static" runat="server" width="100px"/></td>
            </tr>

            <tr>
                <td colspan="2" style="text-align:center;font-size:16px">Plan Surat Jalan</td>
            </tr>
            <tr>
                <td>Start</td>
                <td>Finish</td>
            </tr>
            <tr>
                <td><input type="datetime-local"  ID="txtsSuratJalan" ClientIDMode="Static" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ID="txtfSuratJalan" ClientIDMode="Static" runat="server" width="100px"/></td>
            </tr>

                </table>
            </td></tr>
           <tr><td colspan="2" style="text-align: center;">
               
               <button ID="btnInsert" style="width:100px" runat="server">Insert</button> &nbsp;&nbsp;
               <button ID="btnCancel" style="width:100px" runat="server">Cancel</button>
               </td>
           </tr>
       </table>
    </div>



        <div id="formModalEdit" tabindex="-1" role="dialog" aria-hidden="true"style="display: none; ">
        <table style="position: fixed; top:80px ; left:60px; background-color: ButtonFace; border: 5px; border-radius: 15px; padding: 20px; box-shadow: 5px 5px 5px gray;">
            <tr><td>

                <table>
            <tr>
                <td colspan="1" style="font-size:16px">List Picking No</td>
                <td colspan="1" style="font-size:16px">
                    <asp:TextBox ID="txtListPicking1" ClientIDMode="Static" runat="server" style="width:150px;font-family:arial;font-size:16px;color:black;background-color:lightgray"></asp:TextBox>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Cabang Tujuan</td>
                <td colspan="1">
                    <select id="cboCabang1" ClientIDMode="Static" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Nama Ekspedisi</td>
                <td colspan="1">
                    <select id="cboExpedisi1" ClientIDMode="Static" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Jenis Kendaraan</td>
                <td colspan="1">
                     <select id="cbojeniskend1" ClientIDMode="Static" style="width:300px;font-family:arial;font-size:16px;color:rgb(47,43,43)" runat="server">
                      </select>
                </td>
           </tr>
                 </table>

            </td><td>

                <table>

            <tr>
                <td colspan="2" style="text-align:center;font-size:16px"">Rencana</td>
            </tr>
            <tr>
                <td>Kedatangan</td>
                <td>Picking</td>
            </tr>
            <tr>
                <td><input type="datetime-local" ClientIDMode="Static" ID="txtidKedatangan1" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ClientIDMode="Static" ID="txtplanpicking1" runat="server" width="100px"/></td>
            </tr>
            <tr>
                <td>Packing</td>
                <td>Consol</td>
            </tr>
            <tr>
                <td><input type="datetime-local" ClientIDMode="Static" ID="txtplanpacking1" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ClientIDMode="Static" ID="txtidKonsol1" runat="server" width="100px"/></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;font-size:16px">Plan Loading</td>
            </tr>
            <tr>
                <td>Start</td>
                <td>Finish</td>
            </tr>
            <tr>
                <td><input type="datetime-local"  ClientIDMode="Static" ID="txtsLoading1" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ClientIDMode="Static" ID="txtfLoading1" runat="server" width="100px"/></td>
            </tr>

            <tr>
                <td colspan="2" style="text-align:center;font-size:16px">Plan Surat Jalan</td>
            </tr>
            <tr>
                <td>Start</td>
                <td>Finish</td>
            </tr>
            <tr>
                <td><input type="datetime-local"  ClientIDMode="Static" ID="txtsSuratJalan1" runat="server" width="100px"/></td>
                <td><input type="datetime-local"  ClientIDMode="Static" ID="txtfSuratJalan1" runat="server" width="100px"/></td>
            </tr>

                </table>
            </td></tr>
           <tr><td colspan="2" style="text-align: center;">
               
               <button ID="btnSave1" style="width:100px" runat="server">Save</button> &nbsp;&nbsp;
               <button ID="btnCancel1" style="width:100px" runat="server">Cancel</button>
               </td>
           </tr>
       </table>
    </div>



            <div id="formModalDelete" tabindex="-1" role="dialog" aria-hidden="true"style="display: none; ">
        <table style="position: fixed; top:80px ; left:60px; background-color: ButtonFace; border: 5px; border-radius: 15px; padding: 20px; box-shadow: 5px 5px 5px gray;">
            <tr><td>

                <table>
            <tr>
                <td colspan="1" style="font-size:16px">List Picking No</td>
                <td colspan="1" style="font-size:16px">
                    <asp:TextBox ID="txtListPicking2" ClientIDMode="Static" runat="server" style="width:150px;font-family:arial;font-size:16px;color:black;background-color:lightgray"></asp:TextBox>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Cabang Tujuan</td>
                <td colspan="1">
                    <asp:Label id="cboCabang2" ClientIDMode="Static" style="color:black;font-size:18px" runat="server"></asp:Label>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Nama Ekspedisi</td>
                <td colspan="1">
                    <asp:Label id="cboExpedisi2" ClientIDMode="Static" style="color:black;font-size:18px" runat="server"></asp:Label>
                </td>
            </tr><tr>
                <td colspan="1" style="font-size:16px">Jenis Kendaraan</td>
                <td colspan="1">
                    <asp:Label id="cbojeniskend2" ClientIDMode="Static" style="color:black;font-size:18px" runat="server"></asp:Label>
                </td>
           </tr>
                 </table>

            </td><td>

                <table>

            <tr>
                <td colspan="2" style="text-align:center;font-size:16px"">Rencana</td>
            </tr>
            <tr>
                <td>Kedatangan</td>
                <td>Picking</td>
            </tr>
            <tr><td>
                    <asp:Label id="txtidKedatangan2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
                </td><td>
                    <asp:Label id="txtplanpicking2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Packing</td>
                <td>Consol</td>
            </tr>
            <tr><td>
                    <asp:Label id="txtplanpacking2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
                </td><td>
                    <asp:Label id="txtidKonsol2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;font-size:16px">Plan Loading</td>
            </tr>
            <tr>
                <td>Start</td>
                <td>Finish</td>
            </tr>
            <tr><td>
                    <asp:Label id="txtsLoading2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
                </td><td>
                    <asp:Label id="txtfLoading2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
            </td></tr>

            <tr>
                <td colspan="2" style="text-align:center;font-size:16px">Plan Surat Jalan</td>
            </tr>
            <tr>
                <td>Start</td>
                <td>Finish</td>
            </tr>
            <tr><td>
                    <asp:Label id="txtsSuratJalan2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
                </td><td>
                    <asp:Label id="txtfSuratJalan2" ClientIDMode="Static" style="color:black" runat="server"></asp:Label>
            </td></tr>

                </table>
            <table>
           <tr><td colspan="2" style="text-align: center;">
               
               <button ID="btnDelete2" style="width:100px" runat="server">Delete</button> &nbsp;&nbsp;
               <button ID="btnCancel2" style="width:100px" runat="server">Cancel</button>
               </td>
           </tr>
       </table>
    </div>

    <div id="templatebarang" style="display: none">
        <asp:PlaceHolder ID="plcTemplate" runat="server"></asp:PlaceHolder>
    </div>

    <script type="text/javascript">

        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });


        $('#formModalNew').on('show.bs.modal', function (e) {
            var bookId = $(e.relatedTarget).data('book-id');
            var arrString = []

            arrString = bookId.split("|")

            //var type = JSON.parse("[" + arrString[2] + "]");
            //console.log(arrString[1])

            $(e.currentTarget).find("#<%=txtListPicking.ClientID%>").val(arrString[0]);
            $(e.currentTarget).find("#<%=cboCabang.ClientID%>").val(arrString[1]);
            $(e.currentTarget).find("#<%=cboExpedisi.ClientID%>").val(arrString[2]);
            $(e.currentTarget).find("#<%=cbojeniskend.ClientID%>").val(arrString[3]);
            $(e.currentTarget).find("#<%=txtidKedatangan.ClientID%>").val(arrString[4]);
            $(e.currentTarget).find("#<%=txtidKonsol.ClientID%>").val(arrString[5]);
            $(e.currentTarget).find("#<%=txtsLoading.ClientID%>").val(arrString[6]);
            $(e.currentTarget).find("#<%=txtfLoading.ClientID%>").val(arrString[7]);
            $(e.currentTarget).find("#<%=txtsSuratJalan.ClientID%>").val(arrString[8]);
            $(e.currentTarget).find("#<%=txtfSuratJalan.ClientID%>").val(arrString[9]);
            $(e.currentTarget).find("#<%=txtplanpicking.ClientID%>").val(arrString[10]);
            $(e.currentTarget).find("#<%=txtplanpicking.ClientID%>").val(arrString[11]);

        });


        $('#formModalEdit').on('show.bs.modal', function (e) {
            var bookId = $(e.relatedTarget).data('book-id');
            var arrString = []

            arrString = bookId.split("|")

            //var type = JSON.parse("[" + arrString[2] + "]");
            //console.log(arrString[1])

            $(e.currentTarget).find("#<%=txtListPicking1.ClientID%>").val(arrString[0]);
            $(e.currentTarget).find("#<%=cboCabang1.ClientID%>").val(arrString[1]);
            $(e.currentTarget).find("#<%=cboExpedisi1.ClientID%>").val(arrString[2]);
            $(e.currentTarget).find("#<%=cbojeniskend1.ClientID%>").val(arrString[3]);
            $(e.currentTarget).find("#<%=txtidKedatangan1.ClientID%>").val(arrString[4]);
            $(e.currentTarget).find("#<%=txtidKonsol1.ClientID%>").val(arrString[5]);
            $(e.currentTarget).find("#<%=txtsLoading1.ClientID%>").val(arrString[6]);
            $(e.currentTarget).find("#<%=txtfLoading1.ClientID%>").val(arrString[7]);
            $(e.currentTarget).find("#<%=txtsSuratJalan1.ClientID%>").val(arrString[8]);
            $(e.currentTarget).find("#<%=txtfSuratJalan1.ClientID%>").val(arrString[9]);
            $(e.currentTarget).find("#<%=txtplanpicking1.ClientID%>").val(arrString[10]);
            $(e.currentTarget).find("#<%=txtplanpacking1.ClientID%>").val(arrString[11]);

            document.getElementById("txtListPicking1").onkeydown = function () { return false; }

        });

        $('#formModalDelete').on('show.bs.modal', function (e) {
            var bookId = $(e.relatedTarget).data('book-id');
            var arrString = []

            arrString = bookId.split("|")

            //var type = JSON.parse("[" + arrString[2] + "]");
            //console.log(arrString[1])

            $(e.currentTarget).find("#<%=txtListPicking2.ClientID%>").val(arrString[0]);
            $(e.currentTarget).find("#<%=cboCabang2.ClientID%>").text(arrString[1]);
            $(e.currentTarget).find("#<%=cboExpedisi2.ClientID%>").text(arrString[2]);
            $(e.currentTarget).find("#<%=cbojeniskend2.ClientID%>").text(arrString[3]);
            $(e.currentTarget).find("#<%=txtidKedatangan2.ClientID%>").text(arrString[4]);
            $(e.currentTarget).find("#<%=txtidKonsol2.ClientID%>").text(arrString[5]);
            $(e.currentTarget).find("#<%=txtsLoading2.ClientID%>").text(arrString[6]);
            $(e.currentTarget).find("#<%=txtfLoading2.ClientID%>").text(arrString[7]);
            $(e.currentTarget).find("#<%=txtsSuratJalan2.ClientID%>").text(arrString[8]);
            $(e.currentTarget).find("#<%=txtfSuratJalan2.ClientID%>").text(arrString[9]);
            $(e.currentTarget).find("#<%=txtplanpicking2.ClientID%>").text(arrString[10]);
            $(e.currentTarget).find("#<%=txtplanpacking2.ClientID%>").text(arrString[11]);

            document.getElementById("txtListPicking2").onkeydown = function () { return false; }

        });


    </script>


</asp:Content>


