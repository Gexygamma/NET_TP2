<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server">
     <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false"
         SelectedRowStyle-BackColor="Black" 
         SelectedRowStyle-ForeColor="White"
         DataKeyNames="ID">
      <Columns>
          <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
          <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
          <asp:BoundField HeaderText="Email" DataField="Email" />
          <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
          <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
      </Columns>
    </asp:GridView>
    </asp:Panel>
<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="btnEditarLink" runat="server">Editar</asp:LinkButton>
    <asp:LinkButton ID="btnEliminarLink" runat="server">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="btnNuevoLink" runat="server">Nuevo</asp:LinkButton>
</asp:Panel>
<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
    <asp:CheckBox ID="ckbHabilitado" runat="server"></asp:CheckBox>
    <br />
    <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
    <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
    <br />
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="btnAceptarLink" runat="server">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="btnCancelarLink" runat="server">Cancelar</asp:LinkButton>
</asp:Panel>
</asp:Panel>
</asp:Content>
