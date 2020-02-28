using Business.Entities;
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
            Persona PersonaActual = (Persona)Session["PersonaLogueada"];
            if (PersonaActual != null)
            {
                switch (PersonaActual.TipoPersona)
                {
                    case TipoPersona.Alumno:
                        menuAlumno.Visible = true;
                        break;
                    case TipoPersona.Profesor:
                        menuProfesor.Visible = true;
                        break;
                    case TipoPersona.Admin:
                        menuAdmin.Visible = true;
                        break;
                }
            }
        }

        protected void menuAdmin_MenuItemClick(object sender, MenuEventArgs e)
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


        protected void menuAlumno_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Inscripcion":
                    Response.Redirect("~/Inscripcion.aspx");
                    break;
                case "EstadoAcademico":
                    Response.Redirect("~/EstadoAcademico.aspx");
                    break;
            }
        }

        protected void menuProfesor_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "ReporteCursos":
                    Response.Redirect("~/ReporteCursos.aspx");
                    break;
                case "ReportePlanes":
                    Response.Redirect("~/ReportePlanes.aspx");
                    break;
            }
        }
    }
}