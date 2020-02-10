using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;

namespace UI.Desktop
{
    public class CursoListado : Listado<CursoEditor>
    {
        private readonly CursoLogic CursoLogic;

        public CursoListado()
        {
            CursoLogic = new CursoLogic();
        }

        protected override void EstablecerPropiedades()
        {
            Text = "Listado de Cursos";
            dataGridView.Columns["ID"].HeaderText = "ID";
            dataGridView.Columns["ID"].Width = 50;
            dataGridView.Columns["descMateria"].HeaderText = "Materia";
            dataGridView.Columns["descMateria"].Width = 200;
            dataGridView.Columns["descComision"].HeaderText = "Comisión";
            dataGridView.Columns["descComision"].Width = 100;
            dataGridView.Columns["anioCalendario"].HeaderText = "Año";
            dataGridView.Columns["anioCalendario"].Width = 50;
            dataGridView.Columns["cupo"].HeaderText = "Cupo";
            dataGridView.Columns["cupo"].Width = 50;
        }

        protected override void ActualizarListado()
        {
            dataGridView.DataSource = CursoLogic.GetAllTable();
        }
    }
}
