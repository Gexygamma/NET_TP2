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
    public partial class Usuarios : Form
    {
        private readonly UsuarioLogic UsuarioLogic;
        
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;

            UsuarioLogic = new UsuarioLogic();
        }

        public void ActualizarListado()
        {
            dgvUsuarios.DataSource = UsuarioLogic.GetAll();
            if (dgvUsuarios.RowCount > 0)
            {
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarListado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarListado();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioEditor formUsuario = new UsuarioEditor(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            ActualizarListado();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

            UsuarioEditor formUsuario = new UsuarioEditor(ApplicationForm.ModoForm.Modificacion, ID);
            formUsuario.ShowDialog();
            ActualizarListado();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

            UsuarioEditor formUsuario = new UsuarioEditor(ApplicationForm.ModoForm.Baja, ID);
            formUsuario.ShowDialog();
            ActualizarListado();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
