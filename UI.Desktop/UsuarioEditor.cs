using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    public partial class UsuarioEditor : ApplicationForm
    {
        private readonly UsuarioLogic UsuarioLogic;
        private readonly PersonaLogic PersonaLogic;
        private readonly PlanLogic PlanLogic;

        private Usuario UsuarioActual { get; set; }
        private Persona PersonaActual { get; set; }

        public UsuarioEditor(ModoForm modo)
        {
            InitializeComponent();
            Modo = modo;

            switch (Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    btnConfirmar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnConfirmar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnConfirmar.Text = "Cerrar";
                    btnCancelar.Visible = false;
                    break;
            }

            if (Modo == ModoForm.Baja || Modo == ModoForm.Consulta)
            {
                txtNombreUsuario.Enabled = false;
                txtClave.Enabled = false;
                txtConfirmarClave.Enabled = false;
                cbTipoUsuario.Enabled = false;
                chkHabilitado.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDireccion.Enabled = false;
                txtEmail.Enabled = false;
                txtTelefono.Enabled = false;
                dtFechaNacimiento.Enabled = false;
                txtLegajo.Enabled = false;
                cbPlan.Enabled = false;
            }

            UsuarioLogic = new UsuarioLogic();
            PersonaLogic = new PersonaLogic();
            PlanLogic = new PlanLogic();

            cbPlan.DataSource = PlanLogic.GetAll();
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "ID";
            cbPlan.SelectedIndex = -1;
        }

        public UsuarioEditor(ModoForm modo, int id) : this(modo)
        {
            UsuarioActual = UsuarioLogic.GetOne(id);
            PersonaActual = PersonaLogic.GetOne(UsuarioActual.IdPersona);
            MapearDeDatos();
        }

        // Constructor usado solamente para dar de alta al primer usuario administrador.
        public UsuarioEditor() : this(ModoForm.Alta)
        {
            cbTipoUsuario.SelectedIndex = 2;
            cbTipoUsuario.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            txtNombreUsuario.Text = UsuarioActual.NombreUsuario;
            txtClave.Text = UsuarioActual.Clave;
            txtConfirmarClave.Text = UsuarioActual.Clave;
            cbTipoUsuario.SelectedIndex = (int)PersonaActual.TipoPersona;
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            txtNombre.Text = PersonaActual.Nombre;
            txtApellido.Text = PersonaActual.Apellido;
            txtDireccion.Text = PersonaActual.Direccion;
            txtEmail.Text = PersonaActual.Email;
            txtTelefono.Text = PersonaActual.Telefono;
            dtFechaNacimiento.Value = PersonaActual.FechaNacimiento;
            if (PersonaActual.TipoPersona == TipoPersona.Admin)
            {
                txtLegajo.Text = "";
                cbPlan.SelectedIndex = -1;
            }
            else
            {
                txtLegajo.Text = PersonaActual.Legajo.ToString();
                cbPlan.SelectedValue = PlanLogic.GetOne(PersonaActual.IdPlan).ID;
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                PersonaActual = new Persona();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                PersonaActual.Nombre = txtNombre.Text;
                PersonaActual.Apellido = txtApellido.Text;
                PersonaActual.Direccion = txtDireccion.Text;
                PersonaActual.Email = txtEmail.Text;
                PersonaActual.Telefono = txtTelefono.Text;
                PersonaActual.FechaNacimiento = dtFechaNacimiento.Value;
                PersonaActual.TipoPersona = (TipoPersona)cbTipoUsuario.SelectedIndex;
                UsuarioActual.NombreUsuario = txtNombreUsuario.Text;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.Email = txtEmail.Text;
                if (PersonaActual.TipoPersona == TipoPersona.Admin)
                {
                    PersonaActual.Legajo = 0;
                    PersonaActual.IdPlan = 1;
                    // Los administradores no tienen plan, pero en la bd la columna tiene
                    // el constrain not null, asi q lo igualo a 1 pero no lo muestro.
                }
                else
                {
                    PersonaActual.Legajo = Int32.Parse(txtLegajo.Text);
                    PersonaActual.IdPlan = ((Plan)cbPlan.SelectedItem).ID;
                }
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic.Save(UsuarioActual, PersonaActual);
        }

        public bool CamposNoVacios()
        {
            bool camposNoVacios1, camposNoVacios2;

            camposNoVacios1 = !string.IsNullOrEmpty(txtNombreUsuario.Text) &&
                !string.IsNullOrEmpty(txtClave.Text) &&
                !string.IsNullOrEmpty(txtConfirmarClave.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                cbTipoUsuario.SelectedIndex != -1;

            camposNoVacios2 = (TipoPersona)cbTipoUsuario.SelectedIndex == TipoPersona.Admin ||
                (!string.IsNullOrEmpty(txtLegajo.Text) && cbPlan.SelectedIndex != -1);

            return camposNoVacios1 && camposNoVacios2;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Modo != ModoForm.Consulta)
            {
                if (!CamposNoVacios())
                {
                    MessageBox.Show("Algunos campos están vacios. Por favor rellene con la información solicitada.");
                }
                else if (!Validacion.ValidarEmail(txtEmail.Text))
                {
                    MessageBox.Show("El email ingresado tiene un formato inválido. Por favor intente nuevamente.");
                }
                else if (!Validacion.ValidarClave(txtClave.Text, txtConfirmarClave.Text))
                {
                    MessageBox.Show("La contraseña ingresada no coincide o es muy corta. Por favor intente nuevamente.");
                }
                else
                {
                    GuardarCambios();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TipoPersona)cbTipoUsuario.SelectedIndex == TipoPersona.Admin)
            {
                chkHabilitado.Checked = true;
                chkHabilitado.Enabled = false;
                txtLegajo.Enabled = false;
                cbPlan.Enabled = false;
            }
            else
            {
                if (Modo != ModoForm.Baja && Modo != ModoForm.Consulta)
                {
                    chkHabilitado.Enabled = true;
                    txtLegajo.Enabled = true;
                    cbPlan.Enabled = true;
                }
            }
        }
    }
}
