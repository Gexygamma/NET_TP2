using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Planes : Form
    {
        private readonly PlanLogic PlanLogic;

        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
            PlanLogic = new PlanLogic();
        }

        private void ActualizarListado()
        {
            dgvPlanes.DataSource = PlanLogic.GetConsultaPlanes();
            if (dgvPlanes.RowCount > 0)
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

        private void Planes_Load(object sender, EventArgs e)
        {
            ActualizarListado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarListado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PlanEditor formPlan = new PlanEditor(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            ActualizarListado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataRowView fila = (DataRowView)dgvPlanes.SelectedRows[0].DataBoundItem;
            int  ID =Int32.Parse( fila[0].ToString());    
            PlanEditor formPlan = new PlanEditor(ApplicationForm.ModoForm.Modificacion,ID );
            formPlan.ShowDialog();
            ActualizarListado(); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataRowView fila = (DataRowView)dgvPlanes.SelectedRows[0].DataBoundItem;
            int ID = Int32.Parse(fila[0].ToString());
            PlanEditor formPlan = new PlanEditor(ApplicationForm.ModoForm.Baja, ID);
            formPlan.ShowDialog();
            ActualizarListado();
        }
    }
}
