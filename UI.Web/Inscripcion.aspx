<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripcion.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 276px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Materia</td>
            <td>Comisión</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlMateria" runat="server" OnSelectedIndexChanged="ddlMateria_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlComision" runat="server" OnSelectedIndexChanged="ddlComision_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="btnCancelar" runat="server" Height="25px" OnClick="btnCancelar_Click" Text="Cancelar" Width="75px" />
            </td>
            <td>
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
