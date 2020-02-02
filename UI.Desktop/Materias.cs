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
    public partial class Materias : Form
    {
        private readonly MateriaLogic MateriaLogic;

        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            MateriaLogic = new MateriaLogic();
           
        }

        private void ActualizarListado()
        {
            dgvMaterias.DataSource = MateriaLogic.GetConsultaMaterias();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            ActualizarListado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarListado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MateriaEditor formMateria = new MateriaEditor(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            ActualizarListado();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataRowView fila = (DataRowView)dgvMaterias.SelectedRows[0].DataBoundItem;
            int ID = Int32.Parse(fila[0].ToString());
            MateriaEditor formMateria= new MateriaEditor(ApplicationForm.ModoForm.Modificacion, ID);
            formMateria.ShowDialog();
            ActualizarListado();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataRowView fila = (DataRowView)dgvMaterias.SelectedRows[0].DataBoundItem;
            int ID = Int32.Parse(fila[0].ToString());
            MateriaEditor formMateria = new MateriaEditor(ApplicationForm.ModoForm.Baja, ID);
            formMateria.ShowDialog();
            ActualizarListado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
