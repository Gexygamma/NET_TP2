using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private readonly UsuarioLogic UsuarioLogic;
        private readonly PersonaLogic PersonaLogic;
        private readonly PlanLogic PlanLogic;

        private Usuario UsuarioActual { get; set; }
        private Persona PersonaActual { get; set; }

        public UsuarioDesktop(ModoForm modo)
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
                    btnConfirmar.Text = "Aceptar";
                    break;
            }

            if (Modo == ModoForm.Baja || Modo == ModoForm.Consulta)
            {
                txtNombreUsuario.ReadOnly = true;
                txtClave.ReadOnly = true;
                txtConfirmarClave.ReadOnly = true;
                cmbTipoUsuario.Enabled = false;
                chkHabilitado.Enabled = false;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                dtFechaNacimiento.Enabled = false;
                txtLegajo.ReadOnly = true;
                cmbPlan.Enabled = false;
            }

            UsuarioLogic = new UsuarioLogic();
            PersonaLogic = new PersonaLogic();
            PlanLogic = new PlanLogic();

            cmbPlan.DataSource = PlanLogic.GetAll();
            cmbPlan.DisplayMember = "Descripcion";
            cmbPlan.ValueMember = "ID";
            cmbPlan.SelectedIndex = -1;
        }

        public UsuarioDesktop(ModoForm modo, int id) : this(modo)
        {
            UsuarioActual = UsuarioLogic.GetOne(id);
            PersonaActual = PersonaLogic.GetOne(UsuarioActual.IdPersona);
            MapearDeDatos();
        }

        // Constructor usado solamente para dar de alta al primer usuario administrador.
        public UsuarioDesktop() : this(ModoForm.Alta)
        {
            cmbTipoUsuario.SelectedIndex = 2;
            cmbTipoUsuario.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            txtNombreUsuario.Text = UsuarioActual.NombreUsuario;
            txtClave.Text = UsuarioActual.Clave;
            txtConfirmarClave.Text = UsuarioActual.Clave;
            cmbTipoUsuario.SelectedIndex = (int)PersonaActual.TipoPersona;
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
                cmbPlan.SelectedIndex = -1;
            }
            else
            {
                txtLegajo.Text = PersonaActual.Legajo.ToString();
                cmbPlan.SelectedItem = PlanLogic.GetOne(PersonaActual.IdPlan);
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
                PersonaActual.TipoPersona = (TipoPersona)cmbTipoUsuario.SelectedIndex;
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
                    PersonaActual.IdPlan = ((Plan)cmbPlan.SelectedItem).ID;
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
            UsuarioActual.IdPersona = PersonaActual.ID;
            PersonaLogic.Save(PersonaActual);
            UsuarioLogic.Save(UsuarioActual);
           
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
                cmbTipoUsuario.SelectedIndex != -1;

            camposNoVacios2 = (TipoPersona)cmbTipoUsuario.SelectedIndex == TipoPersona.Admin ? 
                true : !string.IsNullOrEmpty(txtLegajo.Text) && cmbPlan.SelectedIndex != -1;

            return camposNoVacios1 && camposNoVacios2;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TipoPersona)cmbTipoUsuario.SelectedIndex == TipoPersona.Admin)
            {
                chkHabilitado.Checked = true;
                chkHabilitado.Enabled = false;
                txtLegajo.ReadOnly = true;
                cmbPlan.Enabled = false;
            }
            else
            {
                chkHabilitado.Enabled = true;
                txtLegajo.ReadOnly = false;
                cmbPlan.Enabled = true;
            }
        }
    }
}
