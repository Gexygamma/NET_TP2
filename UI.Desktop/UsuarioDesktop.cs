using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            this.MapearDeDatos();
        }

        public Usuario UsuarioActual { get; set; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            switch (Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        public override bool Validar()
        {
            bool textoNoVacios = !string.IsNullOrEmpty(this.txtNombre.Text) &&
                !string.IsNullOrEmpty(this.txtApellido.Text) &&
                !string.IsNullOrEmpty(this.txtEmail.Text) &&
                !string.IsNullOrEmpty(this.txtUsuario.Text) &&
                !string.IsNullOrEmpty(this.txtClave.Text) &&
                !string.IsNullOrEmpty(this.txtConfirmarClave.Text);
            bool claveCoincide = string.Compare(this.txtClave.Text, this.txtConfirmarClave.Text) == 0;
            if (textoNoVacios && claveCoincide)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(this.txtEmail.Text);
                    return addr.Address == this.txtEmail.Text;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}