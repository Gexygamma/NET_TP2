﻿using Business.Entities;
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
    public partial class Inscripcion : Form
    {
        private readonly InscripcionLogic InscripcionLogic;
        private readonly CursoLogic CursoLogic;
        private readonly ComisionLogic ComisionLogic;
        private readonly MateriaLogic MateriaLogic;

        private Persona AlumnoActual;
        private AlumnoInscripcion InscripcionActual;

        public Inscripcion(Persona alumno)
        {
            InitializeComponent();

            AlumnoActual = alumno;

            InscripcionLogic = new InscripcionLogic();
            CursoLogic = new CursoLogic();
            ComisionLogic = new ComisionLogic();
            MateriaLogic = new MateriaLogic();

            cbMateria.DataSource = MateriaLogic.GetAllPlan(AlumnoActual.IdPlan);
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
                Materia materia = (Materia)cbMateria.SelectedItem;
                cbComision.DataSource = ComisionLogic.GetAllMateria(materia.ID);
                cbComision.SelectedIndex = -1;
            }
            else
            {
                cbComision.DataSource = new List<Comision>();
            }
        }

        public void MapearADatos(int idCurso)
        {
            InscripcionActual = new AlumnoInscripcion();
            InscripcionActual.IdAlumno = AlumnoActual.ID;
            InscripcionActual.IdCurso = idCurso;
            InscripcionActual.Condicion = "Libre";
        }

        public void GuardarCambios()
        {
            int idCurso= CursoLogic.GetLatestOneMateriaComision(((Materia)cbMateria.SelectedItem).ID,
                ((Comision)cbComision.SelectedItem).ID).ID;
            if (CursoLogic.ValidacionCurso(idCurso))
            {
                MapearADatos(idCurso);
                try
                {
                    InscripcionLogic.Save(InscripcionActual);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lamentablemente no hay cupo para el curso seleccionado");
            }
            

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbMateria.SelectedIndex == -1 || cbComision.SelectedIndex == -1)
            {
                MessageBox.Show("Algunos campos están vacios. Por favor rellene con la información solicitada.");
            }
            else
            {
                GuardarCambios();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
