<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="callq.aspx.vb" Inherits="callq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <style>
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

.switch input {display:none;}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}
</style>



    <script src='https://code.responsivevoice.org/responsivevoice.js'></script>

    <script type="text/javascript">

        //var myrun;
        var myrun = true

    window.onload = function () {
        ShowCurrentTime()
        //myrun = setInterval(function () { ShowCurrentTime() }, 15000);
        setInterval(function () { ShowCurrentTime() }, 20000);
    };

        function ShowCurrentTime() {
            if (myrun)
            {
                $.ajax({
                    type: "POST",
                    url: "callq.aspx/Getdata",
                    data: '{nama: "<%= Request.QueryString("ux")  %>"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
    }


   function OnSuccess(response) {

       myrun = false;
       //clearInterval(myrun);

        var data = response.d;
        var ndata = data.split("|");
        var len = ndata.length;
        var res = "";
       
        for (var i = 0; i < len; i++) {
             ndata1 = ndata[i].split("~");
            res = res + ndata1[0] + "<br/><br/>";
         }
         document.getElementById("mylbl").innerHTML = res; 

       if (document.getElementById("mycheck").checked == true) {
           for (var j = 0; j < len; j++) {
               ndata1 = ndata[j].split("~");
               if (ndata1[1] == "")
               {
                   responsiveVoice.speak(ndata1[0]);
                   //setTimeout(function(){responsiveVoice.speak(ndata1[0])}, 5000);
                   //wait(1500);
               }
               else
               {
                   responsiveVoice.speak(ndata1[0], ndata1[1]);
                   //setTimeout(function(){responsiveVoice.speak(ndata1[0], ndata1[1]}, 5000);
                    //wait(1500);
               };
               ShowCurrentTime01(ndata1[2]);               
           }
       }

       myrun = true;
       //myrun = setInterval(function () { ShowCurrentTime() }, 15000);
   }


   function ShowCurrentTime01(a) {
        $.ajax({
            type: "POST",
            url: "callq.aspx/Getdata01",
            data: '{nama: "' + a + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess01,
            failure: function (response) {
                alert(response.d);
            }
        });
    }

        function OnSuccess01(response) { }


      </script>

            <div id="mydiv1" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Layanan Panggilan</b> 
</div>

            <div id="mydiv2" style="font-family:arial;font-size:24px;color:rgb(47,43,43);position:absolute;left:170px;top:30px;">
                    <label class="switch">
  <input type="checkbox" id="mycheck">
  <span class="slider round"></span>
</label>
</div>

    <br /><br />
    <table>
        <tr>
            <td>
                <img src="images/MegaPhone.png" />
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>

                <label style="font-size:30px" id="mylbl"></label>
            </td>
        </tr>
        </table>



        <!--
    <div style="margin-left:0px;margin-top:400px;position:fixed;">
    <iframe src="https://responsivevoice.org/text-to-speech-languages/teks-berbicara-dalam-bahasa-indonesia/" 
        width="800" height="800" scrolling="yes"></iframe> 
    </div>
        -->
</asp:Content>

