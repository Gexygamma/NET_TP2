<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="UI.Web.MainMenu" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server" >
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="bodyContent" runat="server">
    
    <div >
        <asp:Menu runat="server" ID="menu" Orientation="Vertical" RenderingMode="Table" Width="100%" OnMenuItemClick="menu_MenuItemClick">
                <Items>
                    <asp:MenuItem Text="Usuarios" Value="Usuario"></asp:MenuItem>
                    <asp:MenuItem Text="Cursos" Value="Cursos"></asp:MenuItem>
                    <asp:MenuItem Text="Especialidades" Value="Especialidades"></asp:MenuItem>
                    <asp:MenuItem Text="Planes" Value="Planes"></asp:MenuItem>
                    <asp:MenuItem Text="Materias" Value="Materias"></asp:MenuItem>
                    <asp:MenuItem Text="Comisiones" Value="Comisiones"></asp:MenuItem>
                </Items>
                <StaticMenuItemStyle HorizontalPadding="32px" VerticalPadding="8px" ForeColor="Black" BorderStyle="Double" BorderWidth="1px" BorderColor="ActiveBorder"/>
            </asp:Menu>
    </div>
    
</asp:Content>
