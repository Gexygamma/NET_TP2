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
    public abstract partial class Listado<AF> : Form where AF : ApplicationForm, new()
    {
        public Listado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Actualiza los contenidos del dataGridView.
        /// </summary>
        protected abstract void ActualizarListado();

        /// <summary>
        /// Establece las propiedades del dataGridView, como el encabezado y tamaño de las columnas.
        /// </summary>
        protected abstract void EstablecerPropiedades();

        private void HabilitarBotones()
        {
            if (dataGridView.RowCount > 0)
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

        private void Especialidades_Load(object sender, EventArgs e)
        {
            ActualizarListado();
            EstablecerPropiedades();
            HabilitarBotones();

            if (!dataGridView.Columns.Contains("ID"))
            {
                chkMostrarID.Visible = false;
                chkMostrarID.Enabled = false;
                chkMostrarID.Checked = false;
            }
            else
            {
                dataGridView.Columns["ID"].Visible = chkMostrarID.Checked;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarListado();
            EstablecerPropiedades();
            HabilitarBotones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AF form = (AF)Activator.CreateInstance(typeof(AF), ApplicationForm.ModoForm.Alta);
            form.ShowDialog();
            ActualizarListado();
            HabilitarBotones();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            int ID = Int32.Parse(row["ID"].ToString());

            AF form = (AF)Activator.CreateInstance(typeof(AF), ApplicationForm.ModoForm.Modificacion, ID);
            form.ShowDialog();
            ActualizarListado();
            HabilitarBotones();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            int ID = Int32.Parse(row["ID"].ToString());

            AF form = (AF)Activator.CreateInstance(typeof(AF), ApplicationForm.ModoForm.Baja, ID);
            form.ShowDialog();
            ActualizarListado();
            HabilitarBotones();
        }

        private void chkMostrarID_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView.Columns["ID"].Visible = chkMostrarID.Checked;
        }
    }
}
