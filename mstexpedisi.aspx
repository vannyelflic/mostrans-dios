<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="mstexpedisi.aspx.vb" Inherits="mstexpedisi" %>

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




</script>

    <div id="mydiv11" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Master Ekspedisi</b>
</div>

   <div id="mydiv" style="text-align:center;font-family:arial;font-size:24px;color:rgb(47,43,43)">
        <div id="mydiv1" style="font-size:12px;text-align:left;">
        <asp:PlaceHolder runat="server" ID="myplc"></asp:PlaceHolder>
        </div>
    </div>



        <div id="formModalEdit" tabindex="-1" role="dialog" aria-hidden="true"style="display: none; ">
        <table style="position: fixed; top:80px ; left:60px; background-color: ButtonFace; border: 5px; border-radius: 15px; padding: 20px; box-shadow: 5px 5px 5px gray;">
            <tr><td>

                <table>
                    <tr>
                        <td>Kode Expedisi</td>
                        <td><asp:TextBox ID="txtKode" ClientIDMode="Static" runat="server" MaxLength="20" style="width:100px"  ></asp:TextBox>
                    </tr>
                    <tr>
                        <td>Nama Expedisi</td>
                        <td><asp:TextBox ID="txtNama" ClientIDMode="Static" runat="server" MaxLength="100" style="width:100px"  ></asp:TextBox>
                    </tr>
                    <tr>
                        <td>Spelling Nama Expedisi</td>
                        <td><asp:TextBox ID="txtSpellingNama" ClientIDMode="Static" runat="server" MaxLength="200" style="width:100px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td><asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" MaxLength="100" style="width:100px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>No WA</td>
                        <td><asp:TextBox ID="txtNoWA" ClientIDMode="Static" runat="server" MaxLength="20" style="width:50px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>User ID</td>
                        <td><asp:TextBox ID="txtUserID" ClientIDMode="Static" runat="server" MaxLength="20" style="width:50px"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td><asp:TextBox ID="txtPassword" ClientIDMode="Static" runat="server" MaxLength="20" style="width:50px"  ></asp:TextBox>
                        </td>
                    </tr>


           <tr>
               <td>
               <button ID="btnSave1" style="width:100px" runat="server">Save</button>
                   </td><td>
               <button ID="btnCancel1" style="width:100px" runat="server">Cancel</button>
               </td>
           </tr>
       </table>

               </td>
           </tr>
       </table>

    </div>




    <script type="text/javascript">

        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });



        $('#formModalEdit').on('show.bs.modal', function (e) {
            var bookId = $(e.relatedTarget).data('book-id');
            var arrString = []

            arrString = bookId.split("|")


            .Item("expcode") & "|" & .Item("expname") & "|" & .Item("expnamespell") & "|" & .Item("email") &
                    .Item("hpWA") & "|" & .Item("UserID")

<%--            $(e.currentTarget).find("#<%=lblKodeExp.ClientID%>").val(arrString[0]);
            $(e.currentTarget).find("#<%=lblNamaExp.ClientID%>").val(arrString[1]);--%>
            $(e.currentTarget).find("#<%=txtSpellingNama.ClientID%>").val(arrString[2]);
            $(e.currentTarget).find("#<%=txtEmail.ClientID%>").val(arrString[3]);
            $(e.currentTarget).find("#<%=txtNoWA.ClientID%>").val(arrString[4]);
            $(e.currentTarget).find("#<%=txtUserID.ClientID%>").val(arrString[5]);
            $(e.currentTarget).find("#<%=txtPassword.ClientID%>").val('');



            document.getElementById("txtListPicking1").onkeydown = function () { return false; }

        });



    </script>


</asp:Content>


