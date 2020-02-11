using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Util;

namespace UI.Web
{
    public partial class Login : Page
    {
        public Usuario UsuarioLogueado { get; set; }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogueado = Autentificacion.AutentificarUsuario(txtUsuario.Text, txtClave.Text);
            if (UsuarioLogueado == null)
            {
                Response.Write("<script>alert('Usuario y/o contraseña incorrectos. Por favor intente nuevamente.')</script>");
            }
            else if (!UsuarioLogueado.Habilitado)
            {
                Response.Write("<script>alert('Usuario deshabilitado. Comuníquese con un administrador.')</script>");
            }
            else
            {
                Response.Write("<script>alert('Credenciales válidas. Imagínese que se logueo con éxito.')</script>");
            }
        }

        protected void lnkOlvidoContraseña_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Pongase en contacto con el administrador para recuperar su contraseña.')</script>");
        }
    }
}