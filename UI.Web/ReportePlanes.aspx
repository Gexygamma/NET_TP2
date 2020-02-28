<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.ReportePlanes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">

        .auto-style1 {
            width: 1218px;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 692px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <br />
        <table __designer:mapid="37" class="auto-style2">
            <tr __designer:mapid="38">
                <td class="auto-style3" __designer:mapid="39">&nbsp;</td>
                <td class="auto-style1" __designer:mapid="39">&nbsp;</td>
                <td __designer:mapid="3a">
   <asp:Button  ID="generar" runat="server" Text="Generar PDF"></asp:Button>
                </td>
            </tr>  
            <tr __designer:mapid="38">
                <td class="auto-style3" __designer:mapid="39">Plan</td>
                <td class="auto-style1" __designer:mapid="39">&nbsp;</td>
                <td __designer:mapid="3a">
                    &nbsp;</td>
            </tr>  
            <tr __designer:mapid="38">
                <td class="auto-style3" __designer:mapid="39">
                    <asp:DropDownList ID="ddlPlan" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1" __designer:mapid="39">
                    &nbsp;</td>
                <td __designer:mapid="3a">
                    <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
                </td>
            </tr>  
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" Height="124px" Width="693px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
        <br />
   
<script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.debug.js" integrity="sha384-NaWTHo/8YCBYJ59830LTz/P4aQZK1sS0SneOgAvhsIl3zBu8r9RevNg5lHCHAuQ/" crossorigin="anonymous"></script>
<script src="https://unpkg.com/jspdf-autotable"></script>
<script>
var doc = new jsPDF();
var specialElementHandlers = {
  '#editor': function(element, renderer) {
    return true;
  }
};

    $('#bodyContent_generar').click(function () {
    doc.autoTable({ html: '#bodyContent_GridView1' })

  doc.save('ReportePlanes.pdf');
});</script>
</asp:Content>
