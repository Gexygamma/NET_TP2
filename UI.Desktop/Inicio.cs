using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Inicio : Form
    {
        Usuario UsuarioLogueado;
        Persona PersonaLogueada;

        public Inicio()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoca un formulario modal de logueo de usuario.
        /// </summary>
        private void InvocarLogin()
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                UsuarioLogueado = loginForm.UsuarioLogueado;
            }
            else
            {
                Dispose();
            }
        }

        /// <summary>
        /// Modifica la pantalla dependiendo del tipo de usuario actualmente logueado.
        /// </summary>
        private void PersonalizarPantalla()
        {
            lblTest.Text = string.Format("Bienvenido {0} {1}!", UsuarioLogueado.Nombre, UsuarioLogueado.Apellido);
            // TODO: Hacer un switch case que muestre los menúes correspondientes a cada tipo de usuario.
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            InvocarLogin();
            PersonalizarPantalla();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioLogueado = null;
            InvocarLogin();
            PersonalizarPantalla();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
