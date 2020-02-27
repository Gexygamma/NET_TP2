<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<%@ Register TagPrefix="My" TagName="ActualizarBtnUserControl" Src="~/ActualizarBtnUserControl.ascx" %>
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
                <asp:BoundField DataField="descMateria" HeaderText="Materia" />
                <asp:BoundField HeaderText="Comision" DataField="descComision" />
                <asp:BoundField HeaderText="Año Calendario" DataField="anioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="btnNuevoLink" runat="server" OnClick="btnNuevoLink_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="btnEditarLink" runat="server" OnClick="btnEditarLink_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="btnEliminarLink" runat="server" OnClick="btnEliminarLink_Click">Eliminar</asp:LinkButton>
        <My:ActualizarBtnUserControl runat="server" ID="ActualizarBtnUserControl"  />
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">Materia</td>
                <td>
                    <asp:TextBox ID="txtdescMateria" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Comisión</td>
                <td>
                    <asp:TextBox ID="txtdescComision" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Año Calendario</td>
                <td>
                    <asp:TextBox ID="txtAnioCalendario" TextMode="Number" runat="server" min="1900" max="3000" step="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Cupo</td>
                <td>
                    <asp:TextBox ID="txtCupo" TextMode="Number" runat="server" min="0" max="100" step="1"></asp:TextBox>
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
