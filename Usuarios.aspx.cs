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

        private PersonaLogic _personaLogic;
        private PersonaLogic PersonaLogic
        {
            get
            {
                if (_personaLogic == null) _personaLogic = new PersonaLogic();
                return _personaLogic;
            }
        }

        private PlanLogic _planLogic;
        private PlanLogic PlanLogic
        {
            get
            {
                if (_planLogic == null) _planLogic = new PlanLogic();
                return _planLogic;
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
            PersonaActual = PersonaLogic.GetOne(UsuarioActual.IdPersona);

            txtNombreUsuario.Text = UsuarioActual.NombreUsuario;
            txtClave.Text = UsuarioActual.Clave;
            txtRepetirClave.Text = UsuarioActual.Clave;
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            ddlTipoUsuario.SelectedIndex = (int)PersonaActual.TipoPersona;

            txtNombre.Text = PersonaActual.Nombre;
            txtApellido.Text = PersonaActual.Apellido;
            txtDireccion.Text = PersonaActual.Direccion;
            txtEmail.Text = PersonaActual.Email;
            txtTelefono.Text = PersonaActual.Telefono;
            cldFechaNacimiento.SelectedDate = PersonaActual.FechaNacimiento;


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

            txtDireccion.Enabled = enable;
            txtTelefono.Enabled = enable;
            cldFechaNacimiento.Enabled = enable;
            ddlTipoUsuario.Enabled = enable;

        }

        private void ClearForm()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            chkHabilitado.Checked = false;
            txtNombreUsuario.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cldFechaNacimiento.SelectedDate = DateTime.Now;
            ddlTipoUsuario.SelectedIndex = -1;
        }

        private void LoadGrid()
        {
            GridView.DataSource = UsuarioLogic.GetAllTable();
            GridView.DataBind();
        }

        private void LoadEntity(Usuario usuario, Persona persona)
        {
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Email = txtEmail.Text;
            usuario.Clave = txtClave.Text;
            usuario.Habilitado = chkHabilitado.Checked;
            persona.IdPlan = int.Parse(ddlPlan.SelectedItem.Value);

            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Email = txtEmail.Text;
            persona.Direccion = txtDireccion.Text;
            persona.Telefono = txtTelefono.Text;
            persona.FechaNacimiento = cldFechaNacimiento.SelectedDate;
            persona.TipoPersona = (TipoPersona)ddlTipoUsuario.SelectedIndex;
        }

        private void SaveEntity(Usuario usuario,Persona persona)
        {
            UsuarioLogic.Save(usuario, persona);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
            ddlPlan.DataSource = PlanLogic.GetAll();
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataBind();
            ddlPlan.SelectedIndex = -1;
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
                    UsuarioActual = UsuarioLogic.GetOne(SelectedID);
                    PersonaActual = PersonaLogic.GetOne(UsuarioActual.IdPersona);
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    LoadEntity(UsuarioActual, PersonaActual);
                    SaveEntity(UsuarioActual, PersonaActual);
                    LoadGrid();
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual = UsuarioLogic.GetOne(SelectedID);
                    PersonaActual = PersonaLogic.GetOne(UsuarioActual.IdPersona);
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    PersonaActual.State = BusinessEntity.States.Modified;
                    LoadEntity(UsuarioActual, PersonaActual);
                    SaveEntity(UsuarioActual, PersonaActual);
                    LoadGrid();
                    break;
                case ModoForm.Alta:
                    UsuarioActual = new Usuario();
                    PersonaActual = new Persona();
                    LoadEntity(UsuarioActual, PersonaActual);
                    SaveEntity(UsuarioActual, PersonaActual);
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
