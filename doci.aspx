<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="doci.aspx.vb" Inherits="doci" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src='https://code.responsivevoice.org/responsivevoice.js'></script>

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

                function planQ(a,b,c) {
        $.ajax({
            type: "POST",
            url: "main.aspx/Getdata01",
            data: '{a: "' + a + '", b: "' + b + '", c: "' + c + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess01,
            failure: function (response) {
                alert(response.d);
            }
        });
    }

        function OnSuccess01(response) {
        alert("Panggilan berhasil diteruskan ke server")
            };


      </script>

            <div id="mydiv1" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Dokumen Check - Inbound</b>
</div>

    <div id="mydiv" style="text-align:center;font-family:arial;font-size:16px;color:rgb(47,43,43)">
    <%--    <br />
        <b>Dokumen Check - Inbound</b>--%>

        <!--<div style="margin-left:-650px;margin-top:15px;position:fixed;left:50%;">
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
    <!--
    <div style="margin-left:0px;margin-top:400px;position:fixed;">
    <iframe src="https://responsivevoice.org/text-to-speech-languages/teks-berbicara-dalam-bahasa-indonesia/" 
        width="800" height="800" scrolling="yes"></iframe> 
    </div>
        -->
</asp:Content>

