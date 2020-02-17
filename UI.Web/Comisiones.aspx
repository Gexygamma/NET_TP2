<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style1 {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="descComision" HeaderText="Comision" />
                <asp:BoundField HeaderText="Año" DataField="anio" />
                <asp:BoundField HeaderText="Plan" DataField="descPlan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="btnEditarLink" runat="server" OnClick="btnEditarLink_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="btnEliminarLink" runat="server" OnClick="btnEliminarLink_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="btnNuevoLink" runat="server" OnClick="btnNuevoLink_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">Descripción</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Año</td>
                <td>
                    <asp:TextBox ID="txtAñoEspecialidad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Plan</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="btnAceptarLink" runat="server" OnClick="btnAceptarLink_Click" Visible="False">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="btnCancelarLink" runat="server" OnClick="btnCancelarLink_Click" Visible="False">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
