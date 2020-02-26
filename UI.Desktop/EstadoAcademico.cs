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
    public partial class EstadoAcademico : Form
    {
        private Persona PersonaActual { get; set; }

        public EstadoAcademico(Persona persona)
        {
            InitializeComponent();
            PersonaActual = persona;
        }

        private void EstadoAcademico_Load(object sender, EventArgs e)
        {
            InscripcionLogic inscripcionLogic = new InscripcionLogic();
            dataGridView.DataSource = inscripcionLogic.GetAllAlumnoTable(PersonaActual.ID);
            dataGridView.Columns["descMateria"].HeaderText = "Materia";
            dataGridView.Columns["descMateria"].Width = 200;
            dataGridView.Columns["descComision"].HeaderText = "Comisión";
            dataGridView.Columns["descComision"].Width = 80;
            dataGridView.Columns["anioCalendario"].HeaderText = "Año";
            dataGridView.Columns["anioCalendario"].Width = 80;
            dataGridView.Columns["condicion"].HeaderText = "Condición";
            dataGridView.Columns["condicion"].Width = 80;
            dataGridView.Columns["nota"].HeaderText = "Nota";
            dataGridView.Columns["nota"].Width = 80;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
