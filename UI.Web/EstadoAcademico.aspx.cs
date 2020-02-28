using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
namespace UI.Web
{
    public partial class EstadoAcademico : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Persona PersonaActual = (Persona)Session["PersonaLogueada"];
            InscripcionLogic inscripcionLogic = new InscripcionLogic();
            gvEstadoAcademico.DataSource = inscripcionLogic.GetAllAlumnoTable(PersonaActual.ID);
            gvEstadoAcademico.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }
    }
}