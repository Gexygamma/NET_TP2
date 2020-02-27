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
    public partial class Materias : ApplicationPage
    {
        private MateriaLogic _MateriaLogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_MateriaLogic == null) _MateriaLogic = new MateriaLogic();
                return _MateriaLogic;
            }
        }
        private PlanLogic PlanLogic { get; set; }
        private Materia MateriaActual { get; set; }


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
            MateriaActual = MateriaLogic.GetOne(id);
            txtDescripcion.Text = MateriaActual.Descripcion;
            txtHsSemanales.Text = MateriaActual.HsSemanales.ToString();
            txtHsTotales.Text = MateriaActual.HsTotales.ToString();
            DropDownListPlan.Text = PlanLogic.GetOne(MateriaActual.IdPlan).Descripcion;
        }

        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
            txtHsSemanales.Enabled = enable;
            txtHsTotales.Enabled = enable;
            DropDownListPlan.Enabled = enable;
        }

        private void ClearForm()
        {
            txtHsSemanales.Text = string.Empty;
            txtHsTotales.Text = string.Empty;
            DropDownListPlan.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void LoadGrid()
        {
            GridView.DataSource = MateriaLogic.GetAllTable();
            GridView.DataBind();
        }

        private void LoadEntity(Materia Materia)
        {
            Materia.Descripcion = txtDescripcion.Text;
            Materia.HsSemanales = int.Parse(txtHsSemanales.Text);
            Materia.HsTotales =int.Parse( txtHsTotales.Text);
           // Materia.IdPlan = 

        }

        private void SaveEntity(Materia Materia)
        {
            MateriaLogic.Save(Materia);
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
                    MateriaActual = new Materia();
                    MateriaActual.ID = SelectedID;
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    LoadEntity(MateriaActual);
                    SaveEntity(MateriaActual);
                    LoadGrid();
                    break;
                case ModoForm.Modificacion:
                    MateriaActual = new Materia();
                    MateriaActual.ID = SelectedID;
                    MateriaActual.State = BusinessEntity.States.Modified;
                    LoadEntity(MateriaActual);
                    SaveEntity(MateriaActual);
                    LoadGrid();
                    break;
                case ModoForm.Alta:
                    MateriaActual = new Materia();
                    LoadEntity(MateriaActual);
                    SaveEntity(MateriaActual);
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
