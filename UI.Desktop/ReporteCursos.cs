using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ReporteCursos : Form
    {
        public ReporteCursos()
        {
            InitializeComponent();
        }

        private void ReporteCursos_Load(object sender, EventArgs e)
        {
            MateriaLogic materiaLogic = new MateriaLogic();
            cbMateria.DataSource = materiaLogic.GetAll();
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";
            cbMateria.SelectedIndex = -1;

            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";
        }

        private void cbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMateria.SelectedIndex != -1)
            {
                ComisionLogic comisionLogic = new ComisionLogic();
                Materia materiaActual = (Materia)cbMateria.SelectedItem;
                cbComision.DataSource = comisionLogic.GetAllMateria(materiaActual.ID);
                cbComision.SelectedIndex = -1;
            }
            else
            {
                cbComision.DataSource = new List<Comision>();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cbMateria.SelectedIndex != -1 && cbComision.SelectedIndex != -1)
            {
                CursoLogic cursoLogic = new CursoLogic();
                InscripcionLogic inscripcionLogic = new InscripcionLogic();

                Materia materiaActual = (Materia)cbMateria.SelectedItem;
                Comision comisionActual = (Comision)cbComision.SelectedItem;
                Curso cursoActual = cursoLogic.GetLatestOneMateriaComision(materiaActual.ID, comisionActual.ID);
                dataGridView.DataSource = inscripcionLogic.GetAllCursoTable(cursoActual.ID);

                EstablecerPropiedades();
            }
        }

        private void EstablecerPropiedades()
        {
            dataGridView.Columns["ID"].Visible = false;
            dataGridView.Columns["alumnoLegajo"].HeaderText = "Legajo";
            dataGridView.Columns["alumnoLegajo"].Width = 80;
            dataGridView.Columns["alumnoLegajo"].ReadOnly = true;
            dataGridView.Columns["alumnoNombre"].HeaderText = "Nombre";
            dataGridView.Columns["alumnoNombre"].Width = 200;
            dataGridView.Columns["alumnoNombre"].ReadOnly = true;
            dataGridView.Columns["condicion"].HeaderText = "Condición";
            dataGridView.Columns["condicion"].Width = 80;
            dataGridView.Columns["nota"].HeaderText = "Nota";
            dataGridView.Columns["nota"].Width = 80;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            InscripcionLogic inscripcionLogic = new InscripcionLogic();

            int id = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;
            AlumnoInscripcion inscripcion = inscripcionLogic.GetOne(id);

            var contenidoCelda = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (e.ColumnIndex == 3) // Columna 3 es condicion.
            {
                inscripcion.Condicion = (string)contenidoCelda;
            }
            else if (e.ColumnIndex == 4) // Columna 4 es nota.
            {
                inscripcion.Nota = (int)contenidoCelda;
            }

            inscripcion.State = BusinessEntity.States.Modified;
            inscripcionLogic.Save(inscripcion);
        }
    }
}
