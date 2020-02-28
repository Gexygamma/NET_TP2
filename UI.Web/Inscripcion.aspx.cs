using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Inscripciones : Page
    {
        private Persona PersonaActual { get; set; }
        private AlumnoInscripcion InscripcionActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonaActual = (Persona)Session["PersonaLogueada"];
            if (!IsPostBack)
            {
                MateriaLogic materiaLogic = new MateriaLogic();
                ddlMateria.DataSource = materiaLogic.GetAll();
                ddlMateria.DataTextField = "Descripcion";
                ddlMateria.DataValueField = "ID";
                ddlMateria.DataBind();
                ddlMateria.SelectedIndex = -1;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        public void GuardarCambios()
        {
            CursoLogic cursoLogic = new CursoLogic();
            int idCurso = cursoLogic.GetLatestOneMateriaComision(int.Parse(ddlMateria.SelectedValue.ToString()),
                int.Parse(ddlComision.SelectedValue.ToString())).ID;
            if (cursoLogic.ValidacionCurso(idCurso))
            {
                InscripcionActual = new AlumnoInscripcion();
                LoadEntity(idCurso);
                try
                {
                    InscripcionLogic inscripcionLogic = new InscripcionLogic();
                    inscripcionLogic.Save(InscripcionActual);
                    Response.Write("<script>alert('Operación realizada exitosamente.')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write(string.Format("<script>alert('{0}')</script>", ex.Message));
                }
            }
            else
            {
                Response.Write("<script>alert('Lamentablemente no hay cupo para el curso seleccionado')</script>");
            }
        }

        private void LoadEntity(int idCurso)
        {
            InscripcionActual.IdCurso = idCurso;
            InscripcionActual.IdAlumno = PersonaActual.ID;
            InscripcionActual.Condicion = "Libre";
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ddlMateria.SelectedIndex == -1 || ddlComision.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Complete los campos.')</script>");
            }
            else
            {
                GuardarCambios();
            }
        }

        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMateria.SelectedIndex != -1)
            {
                ComisionLogic comisionLogic = new ComisionLogic();
                int idMateria = int.Parse(ddlMateria.SelectedValue.ToString());
                ddlComision.DataSource = comisionLogic.GetAllMateria(idMateria);
                ddlComision.DataTextField = "Descripcion";
                ddlComision.DataValueField = "ID";
                ddlComision.DataBind();
                ddlComision.SelectedIndex = -1;
            }
        }

        protected void ddlComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMateria.SelectedValue != string.Empty && ddlComision.SelectedValue != string.Empty)
            {
                CursoLogic cursologic = new CursoLogic();
                InscripcionLogic inscripcionLogic = new InscripcionLogic();
                int idMateria = int.Parse(ddlMateria.SelectedValue.ToString());
                int idComision = int.Parse(ddlComision.SelectedValue.ToString());
                Curso cursoActual = cursologic.GetLatestOneMateriaComision(idMateria, idComision);
            }
        }
    }
}