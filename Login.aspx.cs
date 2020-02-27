using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Login : Page
    {
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuarioLogueado = Autentificacion.AutentificarUsuario(txtUsuario.Text, txtClave.Text);
            if (usuarioLogueado == null)
            {
                Response.Write("<script>alert('Usuario y/o contraseña incorrectos. Por favor intente nuevamente.')</script>");
            }
            else if (!usuarioLogueado.Habilitado)
            {
                Response.Write("<script>alert('Usuario deshabilitado. Comuníquese con un administrador.')</script>");
            }
            else
            {
                PersonaLogic personaLogic = new PersonaLogic();
                Persona personaLogueada = personaLogic.GetOne(usuarioLogueado.IdPersona);
                Session.Add("UsuarioLogueado", usuarioLogueado);
                Session.Add("PersonaLogueada", personaLogueada);
                Response.Redirect("~/MainMenu.aspx");
            }
        }

        protected void lnkOlvidoContraseña_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Pongase en contacto con el administrador para recuperar su contraseña.')</script>");
        }
    }
}