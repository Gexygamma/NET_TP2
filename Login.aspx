<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblBienvenida" runat="server" Text="¡Bienvenido al Sistema!"
                        Font-Bold="True" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" />
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblClave" runat="server" Text="Clave" />
                </td>
                <td>
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:LinkButton ID="lnkOlvidoContraseña" runat="server" OnClick="lnkOlvidoContraseña_Click"
                        Font-Italic="True" Font-Size="Small">Olvidé mi contraseña</asp:LinkButton>
                </td>
                <td>
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
