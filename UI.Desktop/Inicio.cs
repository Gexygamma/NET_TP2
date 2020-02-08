﻿using System;
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
            if (PersonaLogueada != null)
            {
                lblWelcome.Text = string.Format("Bienvenido {0} {1}!", PersonaLogueada.Nombre, PersonaLogueada.Apellido);
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
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            PersonaLogic personaLogic = new PersonaLogic();
            if (personaLogic.CountAdmins() == 0)
            {
                DialogResult result = MessageBox.Show("¡Bienvenido al Sistema! No hay administradores cargados en la base de datos. ¿Desea crear uno?",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UsuarioEditor usuarioForm = new UsuarioEditor();
                usuarioForm.ShowDialog();
                
            }
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
            lblWelcome.Text = "No hay usuario logueado.";
            InvocarLogin();
            PersonalizarPantalla();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioListado formUsuarios = new UsuarioListado();
            formUsuarios.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanListado formPlanes = new PlanListado();
            formPlanes.ShowDialog();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriaListado formMaterias = new MateriaListado();
            formMaterias.ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadListado formEspecialidades = new EspecialidadListado();
            formEspecialidades.ShowDialog();
        }
    }
}
