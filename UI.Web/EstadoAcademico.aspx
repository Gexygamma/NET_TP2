<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <asp:GridView ID="gvEstadoAcademico" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="descMateria" HeaderText="Materia" />
            <asp:BoundField DataField="descComision" HeaderText="Comisión" />
            <asp:BoundField DataField="anioCalendario" HeaderText="Año Calendario" />
            <asp:BoundField DataField="condicion" HeaderText="Condición" />
            <asp:BoundField DataField="nota" HeaderText="Nota" />
        </Columns>
</asp:GridView>
<asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
</asp:Content>
