using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class MainMenu : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Usuarios":
                    Response.Redirect("~/Usuarios.aspx");
                    break;
                case "Especialidades":
                    Response.Redirect("~/Especialidades.aspx");
                    break;
                case "Planes":
                    Response.Redirect("~/Planes.aspx");
                    break;
                case "Materias":
                    Response.Redirect("~/Materias.aspx");
                    break;
                case "Cursos":
                    Response.Redirect("~/Cursos.aspx");
                    break;
                case "Comisiones":
                    Response.Redirect("~/Comisiones.aspx");
                    break;
            }
        }
    }
}