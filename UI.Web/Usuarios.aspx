<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<%@ Register TagPrefix="My" TagName="ActualizarBtnUserControl" Src="~/ActualizarBtnUserControl.ascx" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Usuario" DataField="nombreUsuario" />
                <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                <asp:BoundField HeaderText="Email" DataField="email" />
                <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                <asp:BoundField HeaderText="Habilitado" DataField="habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Yellow" />
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
                <td class="auto-style1">Nombre de Usuario</td>
                <td>
                    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Tipo de usuario</td>
                <td>
                    <asp:DropDownList ID="ddlTipoUsuario" runat="server">
                        <asp:ListItem Value="0"> Alumno </asp:ListItem>
                        <asp:ListItem Value="1"> Profesor </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Habilitado</td>
                <td>
                    <asp:CheckBox ID="chkHabilitado" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Apellido</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Dirección</td>
                <td>
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Teléfono</td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Fecha de Nacimiento</td>
                <td>
                    <asp:Calendar ID="cldFechaNacimiento"  runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Plan</td>
                <td>
                    <asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList>
                </td>
            </tr>
            
        </table>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="btnAceptarLink" runat="server" OnClick="btnAceptarLink_Click" Visible="False">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="btnCancelarLink" runat="server" OnClick="btnCancelarLink_Click" Visible="False">Cancelar</asp:LinkButton>
        </asp:Panel>
           
    </asp:Panel>
    
</asp:Content>
