using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;

namespace UI.Desktop
{
    public class MateriaListado : Listado<MateriaEditor>
    {
        private readonly MateriaLogic MateriaLogic;

        public MateriaListado() : base()
        {
            MateriaLogic = new MateriaLogic();
        }

        protected override void EstablecerPropiedades()
        {
            Text = "Listado de Materias";
            dataGridView.Columns["ID"].HeaderText = "ID";
            dataGridView.Columns["ID"].Width = 50;
            dataGridView.Columns["descMateria"].HeaderText = "Materia";
            dataGridView.Columns["descMateria"].Width = 200;
            dataGridView.Columns["hsSemanales"].HeaderText = "Hs Semanales";
            dataGridView.Columns["hsSemanales"].Width = 100;
            dataGridView.Columns["hsTotales"].HeaderText = "Hs Totales";
            dataGridView.Columns["hsTotales"].Width = 100;
            dataGridView.Columns["descPlan"].HeaderText = "Plan";
            dataGridView.Columns["descPlan"].Width = 100;
        }

        protected override void ActualizarListado()
        {
            dataGridView.DataSource = MateriaLogic.GetAllTable();
        }
    }
}
