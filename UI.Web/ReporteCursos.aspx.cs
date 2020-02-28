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
    public partial class ReporteCursos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlMateria.SelectedIndex != -1)
            {
                ComisionLogic comisionLogic = new ComisionLogic();
                int idMateria = int.Parse(ddlMateria.SelectedValue.ToString());
                ddlComision.DataSource= comisionLogic.GetAllMateria(idMateria);
                ddlComision.DataTextField = "Descripcion";
                ddlComision.DataValueField = "ID";
                ddlComision.DataBind();
                ddlComision.SelectedIndex = -1;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ddlMateria.SelectedValue != string.Empty && ddlComision.SelectedValue != string.Empty)
            {
                CursoLogic cursologic = new CursoLogic();
                InscripcionLogic inscripcionLogic = new InscripcionLogic();
                int idMateria = int.Parse(ddlMateria.SelectedValue.ToString());
                int idComision = int.Parse(ddlComision.SelectedValue.ToString());
                Curso cursoActual = cursologic.GetLatestOneMateriaComision(idMateria, idComision);
                GridView1.DataSource = inscripcionLogic.GetAllCursoTable(cursoActual.ID);
                GridView1.DataBind();
            }
        }
    }
}