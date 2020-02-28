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
        private MateriaLogic MateriaLogic { get; set; }
        private ComisionLogic ComisionLogic { get; set; }

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
            txtdescMateria.Text = MateriaLogic.GetOne(CursoActual.IdMateria).Descripcion;
            txtdescComision.Text = ComisionLogic.GetOne(CursoActual.IdComision).Descripcion;
            txtAnioCalendario.Text = CursoActual.AñoCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();
        }

        private void EnableForm(bool enable)
        {
            txtdescMateria.Enabled = enable;
            txtdescComision.Enabled = enable;
            txtAnioCalendario.Enabled = enable;
            txtCupo.Enabled = enable;

        }

        private void ClearForm()
        {
            txtdescComision.Text = string.Empty;
            txtAnioCalendario.Text = string.Empty;
            txtCupo.Text = string.Empty;
            txtdescMateria.Text = string.Empty;
        }

        private void LoadGrid()
        {
            GridView.DataSource = CursoLogic.GetAllTable();
            GridView.DataBind();
        }

        private void LoadEntity(Curso Curso)
        {
            //Curso.IdMateria = txtdescMateria.Text;
            // Curso.IdComision = txtdescComision.Text;
            Curso.AñoCalendario = int.Parse(txtAnioCalendario.Text);
            Curso.Cupo = int.Parse(txtCupo.Text);
 
        }

        private void SaveEntity(Curso Curso)
        {
          //  CursoLogic.Save(Curso);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
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
