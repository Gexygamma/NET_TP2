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

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                UsuarioLogueado = loginForm.UsuarioLogueado;
                lblTest.Text = string.Format("Bienvenido {0} {1}!", UsuarioLogueado.Nombre, UsuarioLogueado.Apellido);
            }
            else
            {
                Dispose();
            }
        }
    }
}
