using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;

namespace UI.Desktop
{
    public class EspecialidadListado : Listado<EspecialidadEditor>
    {
        private readonly EspecialidadLogic EspecialidadLogic;

        public EspecialidadListado() : base()
        {
            EspecialidadLogic = new EspecialidadLogic();
        }

        protected override void EstablecerPropiedades()
        {
            Text = "Listado de Especialidades";
            dataGridView.Columns["ID"].HeaderText = "ID";
            dataGridView.Columns["ID"].Width = 50;
            dataGridView.Columns["desc"].HeaderText = "Descripción";
            dataGridView.Columns["desc"].Width = 250;
        }

        protected override void ActualizarListado()
        {
            dataGridView.DataSource = EspecialidadLogic.GetAllTable();
        }
    }
}
