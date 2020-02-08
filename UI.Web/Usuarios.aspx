<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 135px;
        }
        .auto-style2 {
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server">
     <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False"
         SelectedRowStyle-BackColor="Black" 
         SelectedRowStyle-ForeColor="White"
         DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
      <Columns>
          <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
          <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
          <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
          <asp:BoundField HeaderText="Email" DataField="Email" />
          <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
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
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">Nombre de Usuario</td>
            <td>
                <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                Apellido</td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                Habilitado</td>
            <td>
                <asp:CheckBox ID="ckbHabilitado" runat="server" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td id="lblClave" class="auto-style2">
                <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td id="lblRepetirClave" class="auto-style2">
                <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="btnAceptarLink" runat="server" OnClick="btnAceptarLink_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="btnCancelarLink" runat="server">Cancelar</asp:LinkButton>
</asp:Panel>
</asp:Panel>
</asp:Content>
