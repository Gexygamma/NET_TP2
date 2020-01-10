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
using Util;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario UsuarioActual { get; set; }

        public UsuarioDesktop(ModoForm modo)
        {
            InitializeComponent();
            Modo = modo;

            switch (Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public UsuarioDesktop(ModoForm modo, int id) : this(modo)
        {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(id);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            txtID.Text = UsuarioActual.ID.ToString();
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtEmail.Text = UsuarioActual.Email;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            txtClave.Text = UsuarioActual.Clave;
            txtConfirmarClave.Text = UsuarioActual.Clave;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Clave = txtClave.Text;
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
            bool textoNoVacios = !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text) &&
                !string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtClave.Text) &&
                !string.IsNullOrEmpty(txtConfirmarClave.Text);

            return textoNoVacios &&
                Validacion.ValidarEmail(txtEmail.Text) &&
                Validacion.ValidarClave(txtClave.Text, txtConfirmarClave.Text);
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
    }
}