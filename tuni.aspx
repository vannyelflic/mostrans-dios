<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="tuni.aspx.vb" Inherits="tuni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
      function JS_click(a,b,c)
      {
<%--          sessionStorage.setItem("A", a);
          sessionStorage.setItem("B", b);
          sessionStorage.setItem("C", c);

          var tmp = '<%= VB_click() %>';--%>

           var someValueToPass = a + '~' + b + '~' + c ;
          __doPostBack('CustomPostBack', someValueToPass);
          alert('Antrian ' + c + ' sudah diupdate!');
      }
      </script>

                <div id="mydiv1" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Batalkan Penundaan - Inbound</b>
</div>


    <div id="mydiv" style="text-align:center;font-family:arial;font-size:16px;color:rgb(47,43,43)">
<%--        <br />
        <b>Batalkan Penundaan - Inbound</b>--%>

<!---        <div style="margin-left:-650px;margin-top:15px;position:fixed;left:50%;">
            <div style="
                border-radius: 15px;
                border: 2px solid rgb(232, 233, 237);
                background-color: rgb(232, 233, 237);
                padding: 20px; 
                width: 1250px;text-align:center;
                ">
    -->



             <asp:PlaceHolder runat="server" ID="myplc"></asp:PlaceHolder>

       <!--    </div>
        </div> -->
    
    </div>



</asp:Content>

