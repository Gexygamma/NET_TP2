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
using Business.Logic;

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
                PersonaLogic personaLogic = new PersonaLogic();
                PersonaLogueada = personaLogic.GetOne(UsuarioLogueado.IdPersona);
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
            lblTest.Text = string.Format("Bienvenido {0} {1}!", PersonaLogueada.Nombre, PersonaLogueada.Apellido);
            switch (PersonaLogueada.TipoPersona)
            {
                case TipoPersona.Alumno:
                    ddAlumno.Visible = true;
                    ddProfesor.Visible = false;
                    ddAdministrador.Visible = false;
                    break;
                case TipoPersona.Profesor:
                    ddAlumno.Visible = false;
                    ddProfesor.Visible = true;
                    ddAdministrador.Visible = false;
                    break;
                case TipoPersona.Admin:
                    ddAlumno.Visible = false;
                    ddProfesor.Visible = false;
                    ddAdministrador.Visible = true;
                    break;
                default:
                    ddAlumno.Visible = false;
                    ddProfesor.Visible = false;
                    ddAdministrador.Visible = false;
                    break;
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            InvocarLogin();
            PersonalizarPantalla();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioLogueado = null;
            PersonaLogueada = null;
            ddAlumno.Visible = false;
            ddProfesor.Visible = false;
            ddAdministrador.Visible = false;
            InvocarLogin();
            PersonalizarPantalla();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
