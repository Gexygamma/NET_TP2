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
    public partial class Especialidades : ApplicationPage
    {
        private EspecialidadLogic _EspecialidadLogic;
        private EspecialidadLogic EspecialidadLogic
        {
            get
            {
                if (_EspecialidadLogic == null) _EspecialidadLogic = new EspecialidadLogic();
                return _EspecialidadLogic;
            }
        }

        private Especialidad EspecialidadActual { get; set; }


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
            EspecialidadActual = EspecialidadLogic.GetOne(id);
            txtdescEspecialidad.Text = EspecialidadActual.Descripcion;

        }

        private void EnableForm(bool enable)
        {
            txtdescEspecialidad.Enabled = enable;
            

        }

        private void ClearForm()
        {
            txtdescEspecialidad.Text = string.Empty;
        }
    
        private void LoadGrid()
        {
            GridView.DataSource = EspecialidadLogic.GetAll();
            GridView.DataBind();
        }

        private void LoadEntity(Especialidad Especialidad)
        {
            Especialidad.Descripcion = txtdescEspecialidad.Text;
 
        }

        private void SaveEntity(Especialidad Especialidad)
        {
            EspecialidadLogic.Save(Especialidad);
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
                    EspecialidadActual = new Especialidad();
                    EspecialidadActual.ID = SelectedID;
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    LoadEntity(EspecialidadActual);
                    SaveEntity(EspecialidadActual);
                    LoadGrid();
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual = new Especialidad();
                    EspecialidadActual.ID = SelectedID;
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    LoadEntity(EspecialidadActual);
                    SaveEntity(EspecialidadActual);
                    LoadGrid();
                    break;
                case ModoForm.Alta:
                    EspecialidadActual = new Especialidad();
                    LoadEntity(EspecialidadActual);
                    SaveEntity(EspecialidadActual);
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
