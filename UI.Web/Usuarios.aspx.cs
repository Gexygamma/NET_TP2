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
    public partial class Usuarios : ApplicationPage
    {
        private UsuarioLogic _usuarioLogic;
        private UsuarioLogic UsuarioLogic
        {
            get
            {
                if (_usuarioLogic == null) _usuarioLogic = new UsuarioLogic();
                return _usuarioLogic;
            }
        }
        
        private Usuario UsuarioActual { get; set; }
        private Persona PersonaActual { get; set; } // TODO: Agregar controles para los atributos de persona.

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
            UsuarioActual = UsuarioLogic.GetOne(id);
            txtNombreUsuario.Text = UsuarioActual.NombreUsuario;
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtEmail.Text = UsuarioActual.Email;
            ckbHabilitado.Checked = UsuarioActual.Habilitado;
        }

        private void EnableForm(bool enable)
        {
            txtNombreUsuario.Enabled = enable;
            txtNombre.Enabled = enable;
            txtApellido.Enabled = enable;
            txtClave.Visible = enable;
            lblClave.Visible = enable;
            txtEmail.Enabled = enable;
            txtRepetirClave.Visible = enable;
            lblRepetirClave.Visible = enable;
        }

        private void ClearForm()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ckbHabilitado.Checked = false;
            txtNombreUsuario.Text = string.Empty;
        }

        private void LoadGrid()
        {
            GridView.DataSource = UsuarioLogic.GetAll();
            GridView.DataBind();
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Email = txtEmail.Text;
            usuario.Clave = txtClave.Text;
            usuario.Habilitado = ckbHabilitado.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            //UsuarioLogic.Save(usuario, persona);
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
                    UsuarioActual = new Usuario();
                    UsuarioActual.ID = SelectedID;
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    LoadEntity(UsuarioActual);
                    SaveEntity(UsuarioActual);
                    LoadGrid();
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual = new Usuario();
                    UsuarioActual.ID = SelectedID;
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    LoadEntity(UsuarioActual);
                    SaveEntity(UsuarioActual);
                    LoadGrid();
                    break;
                case ModoForm.Alta:
                    UsuarioActual = new Usuario();
                    LoadEntity(UsuarioActual);
                    SaveEntity(UsuarioActual);
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
                formPanel.Visible = true;
                Modo = ModoForm.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }

        protected void btnNuevoLink_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            Modo = ModoForm.Alta;
            ClearForm();
            EnableForm(true);
        }
    }
}
