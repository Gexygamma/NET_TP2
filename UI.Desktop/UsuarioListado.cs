using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Desktop
{
    public class UsuarioListado : Listado<UsuarioEditor>
    {
        private readonly UsuarioLogic UsuarioLogic;

        public UsuarioListado() : base()
        {
            UsuarioLogic = new UsuarioLogic();
        }

        protected override void EstablecerPropiedades()
        {
            Text = "Listado de Usuarios";
            dataGridView.Columns["ID"].HeaderText = "ID";
            dataGridView.Columns["ID"].Width = 50;
            dataGridView.Columns["nombre"].HeaderText = "Nombre";
            dataGridView.Columns["nombre"].Width = 100;
            dataGridView.Columns["apellido"].HeaderText = "Apellido";
            dataGridView.Columns["apellido"].Width = 100;
            dataGridView.Columns["nombreUsuario"].HeaderText = "Usuario";
            dataGridView.Columns["nombreUsuario"].Width = 100;
            dataGridView.Columns["email"].HeaderText = "E-Mail";
            dataGridView.Columns["email"].Width = 150;
            dataGridView.Columns["tipo"].HeaderText = "Tipo";
            dataGridView.Columns["tipo"].Width = 100;
            dataGridView.Columns["habilitado"].HeaderText = "Habilitado";
            dataGridView.Columns["habilitado"].Width = 80;
        }

        protected override void ActualizarListado()
        {
            dataGridView.DataSource = UsuarioLogic.GetAllTable();
        }
    }
}
