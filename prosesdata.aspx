<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="prosesdata.aspx.vb" Inherits="prosesdata" %>

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


               <div id="mydiv1" style="font-family:arial;font-size:32px;color:rgb(47,43,43);position:absolute;left:250px;top:30px;">
        <b>Outbound (Proses Data)</b> 
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div id="mydiv2" style="font-family:arial;font-size:12px;color:rgb(47,43,43);position:absolute;left:140px;top:40px;">
<%--                    <label class="switch">--%>
  <asp:CheckBox ID="mycheck" name="mycheck" runat="server"/> Update Data<br />
                <asp:TextBox ID="txtInterval" runat="server" MaxLength="2" Width="30px" TextMode="Number">1</asp:TextBox> Interval (Menit)
<%--<span class="slider round"></span>
</label>--%>
</div>

    <br /><br />
    <table>
        <tr>
            <td>
                <img src="images/animation_processing.gif" />
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>

                <label style="font-size:30px" id="mylbl"></label>
            </td>
        </tr>
        </table>

    <asp:Timer ID="Timer1" runat="server" OnTick="TimerX_Tick"></asp:Timer>

    <asp:Label ID="lblinfo" runat="server" Text=""></asp:Label>

</asp:Content>

