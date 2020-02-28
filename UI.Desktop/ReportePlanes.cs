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
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
            Inicializar();
        }

        public void Inicializar()
        {
            PlanLogic planLogic = new PlanLogic();
            cbPlan.DataSource = planLogic.GetAll();
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "ID";
            cbPlan.SelectedIndex = -1;
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cbPlan.SelectedIndex != -1)
            {
                MateriaLogic materialogic = new MateriaLogic();
                int idPlan = int.Parse(cbPlan.SelectedValue.ToString());
                dgvReporte.DataSource = materialogic.GetAllPlan(idPlan);

            }
        }
    }
}
