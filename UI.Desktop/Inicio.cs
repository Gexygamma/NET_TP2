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

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComisionListado formComisiones = new ComisionListado();
            formComisiones.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursoListado formCursos = new CursoListado();
            formCursos.ShowDialog();
        }

        private void inscribirseACursadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inscripcion formInscripcion = new Inscripcion(PersonaLogueada);
            formInscripcion.ShowDialog();
        }

        private void modificarDatosPersonalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioEditor formUsuarioEditor = new UsuarioEditor(UsuarioLogueado);
            formUsuarioEditor.ShowDialog();

            UsuarioLogic usuarioLogic = new UsuarioLogic();
            PersonaLogic personaLogic = new PersonaLogic();
            UsuarioLogueado = usuarioLogic.GetOne(UsuarioLogueado.ID);
            PersonaLogueada = personaLogic.GetOne(UsuarioLogueado.IdPersona);
            PersonalizarPantalla();
        }

        private void estadoAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstadoAcademico formEstadoAcademico = new EstadoAcademico(PersonaLogueada);
            formEstadoAcademico.ShowDialog();
        }

        private void reporteDeCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCursos formReporteCursos = new ReporteCursos();
            formReporteCursos.ShowDialog();
        }

        #region nuke
        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (PersonaLogueada.TipoPersona == TipoPersona.Admin && e.KeyCode == Keys.End)
            {
                DialogResult result = MessageBox.Show("Está a punto de nukear la base de datos. ¿Está seguro?", "Nuke DB",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    result = MessageBox.Show("¿Seguro seguro?", "Nuke DB",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        Util.Nuke.TruncarBaseDatos();
                        MessageBox.Show("rip", ":'(");
                        Dispose();
                    }
                }
            }
        }
        #endregion
    }
}
