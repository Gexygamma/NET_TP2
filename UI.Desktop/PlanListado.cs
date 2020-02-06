using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;

namespace UI.Desktop
{
    public class PlanListado : Listado<PlanEditor>
    {
        private readonly PlanLogic PlanLogic;

        public PlanListado() : base()
        {
            PlanLogic = new PlanLogic();
        }

        protected override void EstablecerPropiedades()
        {
            dataGridView.Columns["ID"].HeaderText = "ID";
            dataGridView.Columns["ID"].Width = 50;
            dataGridView.Columns["descPlan"].HeaderText = "Plan";
            dataGridView.Columns["descPlan"].Width = 100;
            dataGridView.Columns["descEspecialidad"].HeaderText = "Especialidad";
            dataGridView.Columns["descEspecialidad"].Width = 250;
        }

        protected override void ActualizarListado()
        {
            dataGridView.DataSource = PlanLogic.GetAllTable();
        }
    }
}
