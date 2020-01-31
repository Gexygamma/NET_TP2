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
            int ID = ((Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID;

            PlanEditor formPlan = new PlanEditor(ApplicationForm.ModoForm.Modificacion, ID);
            formPlan.ShowDialog();
            ActualizarListado();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Plan)dgvPlanes.SelectedRows[0].DataBoundItem).ID;

            PlanEditor formPlan = new PlanEditor(ApplicationForm.ModoForm.Baja, ID);
            formPlan.ShowDialog();
            ActualizarListado();
        }
    }
}
