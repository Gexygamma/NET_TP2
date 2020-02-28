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
    public partial class Cursos : ApplicationPage
    {
        private CursoLogic _CursoLogic;
        private CursoLogic CursoLogic
        {
            get
            {
                if (_CursoLogic == null) _CursoLogic = new CursoLogic();
                return _CursoLogic;
            }
        }

        private MateriaLogic _MateriaLogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_MateriaLogic == null) _MateriaLogic = new MateriaLogic();
                return _MateriaLogic;
            }
        }

        private ComisionLogic _ComisionLogic;
        private ComisionLogic ComisionLogic
        {
            get
            {
                if (_ComisionLogic == null) _ComisionLogic = new ComisionLogic();
                return _ComisionLogic;
            }
        }

        private PlanLogic _PlanLogic;
        private PlanLogic PlanLogic
        {
            get
            {
                if (_PlanLogic == null) _PlanLogic = new PlanLogic();
                return _PlanLogic;
            }
        }

        private DocenteCursoLogic _DocenteCursoLogic;
        private DocenteCursoLogic DocenteCursoLogic
        {
            get
            {
                if (_DocenteCursoLogic == null) _DocenteCursoLogic = new DocenteCursoLogic();
                return _DocenteCursoLogic;
            }
        }

        private Curso CursoActual { get; set; }
      
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

        private void LoadForm(int id)
        {
            CursoActual = CursoLogic.GetOne(id);
            Materia materia = MateriaLogic.GetOne(CursoActual.IdMateria);
            ddlPlan.SelectedValue = materia.IdPlan.ToString();
            ddlMateria.SelectedValue = materia.ID.ToString();
            ddlComision.SelectedValue = CursoActual.IdComision.ToString();
            txtAnioCalendario.Text = CursoActual.AñoCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();
            ddlDocenteAuxiliar.SelectedValue = DocenteCursoLogic.GetOneCurso(CursoActual, TipoCargo.Auxiliar).ID.ToString();
            ddlDocenteTitular.SelectedValue = DocenteCursoLogic.GetOneCurso(CursoActual, TipoCargo.Titular).ID.ToString();
        }

        private void EnableForm(bool enable)
        {
            ddlComision.Enabled = enable;
            ddlPlan.Enabled = enable;
            ddlMateria.Enabled = enable;
            txtAnioCalendario.Enabled = enable;
            txtCupo.Enabled = enable;
            ddlDocenteAuxiliar.Enabled = enable;
            ddlDocenteTitular.Enabled = enable;
        }

        private void ClearForm()
        {
            ddlMateria.Text = string.Empty;
            txtAnioCalendario.Text = string.Empty;
            txtCupo.Text = string.Empty;
            ddlComision.Text = string.Empty;
        }

        private void LoadGrid()
        {
            GridView.DataSource = CursoLogic.GetAllTable();
            GridView.DataBind();
        }

        private void LoadEntity(Curso Curso)
        {
            Curso.IdMateria = int.Parse(ddlMateria.SelectedValue.ToString());
            Curso.IdComision = int.Parse(ddlComision.SelectedValue.ToString());
            Curso.AñoCalendario = int.Parse(txtAnioCalendario.Text);
            Curso.Cupo = int.Parse(txtCupo.Text);
        }

        private void SaveEntity(Curso Curso)
        {
            // CursoLogic.Save(Curso);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
            if (!IsPostBack)
            {
                PlanLogic planLogic = new PlanLogic();
                ddlPlan.DataSource = planLogic.GetAll();
                ddlPlan.DataTextField = "Descripcion";
                ddlPlan.DataValueField = "ID";
                ddlPlan.DataBind();
                ddlPlan.SelectedIndex = -1;
                PersonaLogic personaLogic = new PersonaLogic();
                ddlDocenteTitular.DataSource = personaLogic.GetAllDocentes();
                ddlDocenteTitular.DataTextField = "NombreCompleto";
                ddlDocenteTitular.DataValueField = "ID";
                ddlDocenteTitular.DataBind();
                ddlDocenteTitular.SelectedIndex = -1;
            }
        }

        protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPlan.SelectedIndex != -1)
            {
                int idplan = int.Parse(ddlPlan.SelectedValue.ToString());
                ddlMateria.DataSource = MateriaLogic.GetAllPlan(idplan);
                ddlComision.DataSource = ComisionLogic.GetAllPlan(idplan);
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)GridView.SelectedValue;
        }

        protected void btnEditarLink_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                btnAceptarLink.Visible = true;
                btnCancelarLink.Visible = true;
                formPanel.Visible = true;
                Modo = ModoForm.Modificacion;
                LoadForm(SelectedID);
            }
        }

        protected void btnAceptarLink_Click(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case ModoForm.Baja:
                    CursoActual = new Curso();
                    CursoActual.ID = SelectedID;
                    CursoActual.State = BusinessEntity.States.Deleted;
                    LoadEntity(CursoActual);
                    SaveEntity(CursoActual);
                    LoadGrid();
                    break;
                case ModoForm.Modificacion:
                    CursoActual = new Curso();
                    CursoActual.ID = SelectedID;
                    CursoActual.State = BusinessEntity.States.Modified;
                    LoadEntity(CursoActual);
                    SaveEntity(CursoActual);
                    LoadGrid();
                    break;
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    LoadEntity(CursoActual);
                    SaveEntity(CursoActual);
                    LoadGrid();
                    break;
                default:
                    break;
            }
            formPanel.Visible = false;
        }

        protected void btnEliminarLink_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                btnAceptarLink.Visible = true;
                btnCancelarLink.Visible = true;
                formPanel.Visible = true;
                Modo = ModoForm.Baja;
                EnableForm(false);
                LoadForm(SelectedID);

            }
        }

        protected void btnNuevoLink_Click(object sender, EventArgs e)
        {
            btnAceptarLink.Visible = true;
            btnCancelarLink.Visible = true;
            formPanel.Visible = true;
            Modo = ModoForm.Alta;
            ClearForm();
            EnableForm(true);

        }

        protected void btnCancelarLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx");
        }

        
    }
}
