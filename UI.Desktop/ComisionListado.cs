using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;

namespace UI.Desktop
{
    public class ComisionListado : Listado<ComisionEditor>
    {
        private readonly ComisionLogic ComisionLogic;

        public ComisionListado() : base()
        {
            ComisionLogic = new ComisionLogic();
        }

        protected override void EstablecerPropiedades()
        {
            dataGridView.Columns["ID"].HeaderText = "ID";
            dataGridView.Columns["ID"].Width = 50;
            dataGridView.Columns["descComision"].HeaderText = "Comisión";
            dataGridView.Columns["descComision"].Width = 100;
            dataGridView.Columns["anio"].HeaderText = "Año de Espec.";
            dataGridView.Columns["anio"].Width = 100;
            dataGridView.Columns["descPlan"].HeaderText = "Plan";
            dataGridView.Columns["descPlan"].Width = 100;
        }

        protected override void ActualizarListado()
        {
            dataGridView.DataSource = ComisionLogic.GetAllTable();
        }
    }
}
