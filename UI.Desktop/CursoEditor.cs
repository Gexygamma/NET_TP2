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
    public partial class CursoEditor : ApplicationForm
    {
        private readonly CursoLogic CursoLogic;
        private readonly MateriaLogic MateriaLogic;
        private readonly ComisionLogic ComisionLogic;

        private Curso CursoActual;

        public CursoEditor(ModoForm modo)
        {
            InitializeComponent();

            Modo = modo;

            switch (Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    btnConfirmar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnConfirmar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnConfirmar.Text = "Cerrar";
                    btnCancelar.Visible = false;
                    break;
            }

            if (modo == ModoForm.Baja || modo == ModoForm.Consulta)
            {
                cbComision.Enabled = false;
                cbMateria.Enabled = false;
                nCupo.Enabled = false;
                nAnioCalendario.Enabled = false;
            }

            CursoLogic = new CursoLogic();
            MateriaLogic = new MateriaLogic();
            ComisionLogic = new ComisionLogic();

            cbMateria.DataSource = MateriaLogic.GetAll();
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";
            cbMateria.SelectedIndex = -1;

            //cbComision.DataSource = ComisionLogic.GetAll();
            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";
            //cbComision.SelectedIndex = -1;
        }

        public CursoEditor(ModoForm modo, int id) : this(modo)
        {
            CursoActual = CursoLogic.GetOne(id);
            MapearDeDatos();
        }

        public CursoEditor() : this(ModoForm.Alta) { }

        public override void MapearDeDatos()
        {
            cbMateria.SelectedValue = MateriaLogic.GetOne(CursoActual.IdMateria).ID;
            cbComision.SelectedValue = ComisionLogic.GetOne(CursoActual.IdComision).ID;
            nAnioCalendario.Value = CursoActual.AñoCalendario;
            nCupo.Value = CursoActual.Cupo;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                CursoActual = new Curso();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoActual.IdMateria = ((Materia)cbMateria.SelectedItem).ID;
                CursoActual.IdComision = ((Comision)cbComision.SelectedItem).ID;
                CursoActual.AñoCalendario = int.Parse(nAnioCalendario.Text);
                CursoActual.Cupo = int.Parse(nCupo.Text);
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic.Save(CursoActual);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Modo != ModoForm.Consulta)
            {
                if (cbMateria.SelectedIndex == -1 || cbComision.SelectedIndex == -1 ||
                    string.IsNullOrEmpty(nAnioCalendario.Text) || string.IsNullOrEmpty(nCupo.Text))
                {
                    MessageBox.Show("Algunos campos están vacios. Por favor rellene con la información solicitada.");
                }
                else
                {
                    GuardarCambios();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMateria.SelectedIndex != -1)
            {
                Materia materia = (Materia)cbMateria.SelectedItem;
                cbComision.DataSource = ComisionLogic.GetAllPlan(materia.IdPlan);
                cbComision.SelectedIndex = -1;
            }
            else
            {
                cbComision.DataSource = new List<Comision>();
            }
            
        }
    }
}
