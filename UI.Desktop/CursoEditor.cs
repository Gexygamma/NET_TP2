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
        private readonly DocenteCursoLogic DocenteCursoLogic;
        private readonly PersonaLogic PersonaLogic;
        private readonly PlanLogic PlanLogic;
        private readonly CursoLogic CursoLogic;
        private readonly MateriaLogic MateriaLogic;
        private readonly ComisionLogic ComisionLogic;

        private Curso CursoActual;
        private DocenteCurso TitularActual;
        private DocenteCurso AuxiliarActual;

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
                cbPlan.Enabled = false;
                cbComision.Enabled = false;
                cbMateria.Enabled = false;
                cbDocenteTitular.Enabled = false;
                cbDocenteAuxiliar.Enabled = false;
                btnEliminarAuxiliar.Enabled = false;
                nCupo.Enabled = false;
                nAnioCalendario.Enabled = false;
            }

            DocenteCursoLogic = new DocenteCursoLogic();
            PersonaLogic = new PersonaLogic();
            PlanLogic = new PlanLogic();
            CursoLogic = new CursoLogic();
            MateriaLogic = new MateriaLogic();
            ComisionLogic = new ComisionLogic();

            cbPlan.DataSource = PlanLogic.GetAll();
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "ID";
            cbPlan.SelectedIndex = -1;

            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";

            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";

            cbDocenteTitular.DataSource = PersonaLogic.GetAllDocentes();
            cbDocenteTitular.DisplayMember = "Apellido";
            cbDocenteTitular.ValueMember = "ID";
            cbDocenteTitular.SelectedIndex = -1;

            cbDocenteAuxiliar.DataSource = PersonaLogic.GetAllDocentes();
            cbDocenteAuxiliar.DisplayMember = "Apellido";
            cbDocenteAuxiliar.ValueMember = "ID";
            cbDocenteAuxiliar.SelectedIndex = -1;
        }

        public CursoEditor(ModoForm modo, int id) : this(modo)
        {
            CursoActual = CursoLogic.GetOne(id);
            TitularActual = DocenteCursoLogic.GetOneCurso(CursoActual, TipoCargo.Titular);
            AuxiliarActual = DocenteCursoLogic.GetOneCurso(CursoActual, TipoCargo.Auxiliar);
            MapearDeDatos();
            if (modo == ModoForm.Baja || modo == ModoForm.Consulta)
                btnEliminarAuxiliar.Enabled = false;
        }

        public CursoEditor() : this(ModoForm.Alta) { }

        public override void MapearDeDatos()
        {
            Materia materia = MateriaLogic.GetOne(CursoActual.IdMateria);
            cbPlan.SelectedValue = PlanLogic.GetOne(materia.IdPlan).ID;
            cbMateria.SelectedValue = materia.ID;
            cbComision.SelectedValue = ComisionLogic.GetOne(CursoActual.IdComision).ID;
            cbDocenteTitular.SelectedValue = TitularActual.IdDocente;
            if (AuxiliarActual != null)
                cbDocenteAuxiliar.SelectedValue = AuxiliarActual.IdDocente;
            nAnioCalendario.Value = CursoActual.AñoCalendario;
            nCupo.Value = CursoActual.Cupo;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                CursoActual = new Curso();
                TitularActual = new DocenteCurso();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoActual.IdMateria = ((Materia)cbMateria.SelectedItem).ID;
                CursoActual.IdComision = ((Comision)cbComision.SelectedItem).ID;
                CursoActual.AñoCalendario = int.Parse(nAnioCalendario.Text);
                CursoActual.Cupo = int.Parse(nCupo.Text);
                TitularActual.IdCurso = CursoActual.ID;
                TitularActual.IdDocente = ((Persona)cbDocenteTitular.SelectedItem).ID;
                TitularActual.Cargo = TipoCargo.Titular;
                if (cbDocenteAuxiliar.SelectedIndex != -1)
                {
                    if (AuxiliarActual == null)
                    {
                        AuxiliarActual = new DocenteCurso();
                        AuxiliarActual.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        AuxiliarActual.State = BusinessEntity.States.Modified;
                    }
                    AuxiliarActual.IdCurso = CursoActual.ID;
                    AuxiliarActual.IdDocente = ((Persona)cbDocenteAuxiliar.SelectedItem).ID;
                    AuxiliarActual.Cargo = TipoCargo.Auxiliar;
                }
                else if (AuxiliarActual != null)
                {
                    AuxiliarActual.State = BusinessEntity.States.Deleted;
                }
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual.State = BusinessEntity.States.New;
                    TitularActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    TitularActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    TitularActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    TitularActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            try
            {
                CursoLogic.Save(CursoActual, TitularActual, AuxiliarActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Modo != ModoForm.Consulta)
            {
                if (cbMateria.SelectedIndex == -1 || cbComision.SelectedIndex == -1 || cbDocenteTitular.SelectedIndex == -1 ||
                    string.IsNullOrEmpty(nAnioCalendario.Text) || string.IsNullOrEmpty(nCupo.Text))
                {
                    MessageBox.Show("Algunos campos están vacios. Por favor rellene con la información solicitada.");
                }
                else if (cbDocenteAuxiliar.SelectedIndex != -1 && 
                    ((Persona)cbDocenteTitular.SelectedItem).ID == ((Persona)cbDocenteAuxiliar.SelectedItem).ID)
                {
                    MessageBox.Show("El titular y auxiliar no pueden ser la misma persona.");
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

        private void cbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPlan.SelectedIndex != -1)
            {
                Plan plan = (Plan)cbPlan.SelectedItem;
                cbMateria.DataSource = MateriaLogic.GetAllPlan(plan.ID);
                cbComision.DataSource = ComisionLogic.GetAllPlan(plan.ID);
            }
            else
            {
                cbMateria.DataSource = new List<Materia>();
                cbComision.DataSource = new List<Comision>();
            }
            cbMateria.SelectedIndex = -1;
            cbComision.SelectedIndex = -1;
        }

        private void btnEliminarAuxiliar_Click(object sender, EventArgs e)
        {
            cbDocenteAuxiliar.SelectedIndex = -1;
        }

        private void cbDocenteAuxiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEliminarAuxiliar.Enabled = cbDocenteAuxiliar.SelectedIndex != -1;
        }
    }
}
