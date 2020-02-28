<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="UI.Web.MainMenu" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="bodyContent" runat="server">

    <div>
        <asp:Menu runat="server" ID="menuAdmin" Orientation="Vertical" RenderingMode="Table" Width="100%" OnMenuItemClick="menu_MenuItemClick"  Visible="false"> 
            <Items>
                <asp:MenuItem Text="Usuarios" Value="Usuarios"></asp:MenuItem>
                <asp:MenuItem Text="Especialidades" Value="Especialidades"></asp:MenuItem>
                <asp:MenuItem Text="Planes" Value="Planes"></asp:MenuItem>
                <asp:MenuItem Text="Materias" Value="Materias"></asp:MenuItem>
                <asp:MenuItem Text="Cursos" Value="Cursos"></asp:MenuItem>
                <asp:MenuItem Text="Comisiones" Value="Comisiones"></asp:MenuItem>
            </Items>
            <StaticMenuItemStyle HorizontalPadding="32px" VerticalPadding="8px" ForeColor="Black" BorderStyle="Double" BorderWidth="1px" BorderColor="ActiveBorder" />
        </asp:Menu>
    </div>
          <asp:Menu runat="server" ID="menuAlumno" Orientation="Vertical" RenderingMode="Table" Width="100%" OnMenuItemClick="menuAlumno_MenuItemClick"  Visible="false">
            <Items>
                <asp:MenuItem Text="Inscripción a Cursado" Value="Inscripcion"></asp:MenuItem>
                <asp:MenuItem Text="Estado Academico" Value="EstadoAcademico"></asp:MenuItem>
            </Items>
            <StaticMenuItemStyle HorizontalPadding="32px" VerticalPadding="8px" ForeColor="Black" BorderStyle="Double" BorderWidth="1px" BorderColor="ActiveBorder" />
        </asp:Menu>
        <div>
        <asp:Menu runat="server" ID="menuProfesor" Orientation="Vertical" RenderingMode="Table" Width="100%" OnMenuItemClick="menuProfesor_MenuItemClick" Visible="false">
            <Items>
                <asp:MenuItem Text="Reporte de cursos y Registro de Notas" Value="ReporteCursos"></asp:MenuItem>
                <asp:MenuItem Text="Reporte de Planes" Value="ReportePlanes"></asp:MenuItem>
            </Items>
            <StaticMenuItemStyle HorizontalPadding="32px" VerticalPadding="8px" ForeColor="Black" BorderStyle="Double" BorderWidth="1px" BorderColor="ActiveBorder" />
        </asp:Menu>
    </div>

</asp:Content>
