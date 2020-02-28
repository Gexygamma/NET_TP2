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
        private int SelectedID
        {
            get
            {
                return ViewState["SelectedID"] != null ?
                    (int)ViewState["SelectedID"] : 0;
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected => SelectedID != 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            MateriaLogic materiaLogic = new MateriaLogic();
            ddlMateria.DataSource = materiaLogic.GetAll();
            ddlMateria.DataTextField = "Descripcion";
            ddlMateria.DataValueField = "ID";
            ddlMateria.DataBind();
            ddlMateria.SelectedIndex = -1;
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

        public void LoadForm(int idinscripcion)
        {
            InscripcionLogic inscripcionLogic = new InscripcionLogic();
            AlumnoInscripcion inscripcionActual = inscripcionLogic.GetOne(idinscripcion);
            txtNota.Text = inscripcionActual.Nota.ToString();
            txtCondicion.Text = inscripcionActual.Condicion;
        }

        public void LoadEntity(AlumnoInscripcion inscripcion)
        {
            inscripcion.Condicion = txtCondicion.Text;
            inscripcion.Nota = int.Parse(txtNota.Text);
            inscripcion.State = BusinessEntity.States.Modified;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            InscripcionLogic inscripcionLogic = new InscripcionLogic();
            AlumnoInscripcion inscripcionActual = inscripcionLogic.GetOne(SelectedID);
            LoadEntity(inscripcionActual);
            inscripcionLogic.Save(inscripcionActual);
            LoadGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelEdicion.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelEdicion.Visible = true;
            SelectedID = (int)GridView1.SelectedValue;
            

        }
    }
}