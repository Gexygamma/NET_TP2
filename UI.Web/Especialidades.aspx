﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<%@ Register TagPrefix="My" TagName="ActualizarBtnUserControl" Src="~/ActualizarBtnUserControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style1 {
            width: 150px;
        }
        .auto-style2 {
            width: 100%;
            height: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged" Width="219px">
            <Columns>
                <asp:BoundField DataField="Descripcion" FooterText="Especialidad" />
                <asp:CommandField ShowSelectButton="True" />
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
        <table class="auto-style2">
            <tr>
                <td class="auto-style1" id="lbldescEspecialidad">Descripción</td>
                <td>
                    <asp:TextBox ID="txtdescEspecialidad" runat="server"></asp:TextBox>
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
