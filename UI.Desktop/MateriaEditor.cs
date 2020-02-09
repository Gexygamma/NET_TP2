using Business.Entities;
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
    public partial class MateriaEditor : ApplicationForm
    {
        private readonly MateriaLogic MateriaLogic;
        private readonly PlanLogic PlanLogic;
        
        private Materia MateriaActual { get; set; }

        public MateriaEditor(ModoForm modo)
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
                txtDescripcion.Enabled = false;
                cbPlan.Enabled = false;
                nHsSemanales.Enabled = false;
                nHsTotales.Enabled = false;
            }

            MateriaLogic = new MateriaLogic();
            PlanLogic = new PlanLogic();

            cbPlan.DataSource = PlanLogic.GetAll();
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "ID";
            cbPlan.SelectedIndex = -1;
        }

        public MateriaEditor(ModoForm modo, int ID):this(modo)
        {
            MateriaActual = MateriaLogic.GetOne(ID);
            MapearDeDatos();
        }

        public MateriaEditor() : this(ModoForm.Alta) { }

        public override void MapearDeDatos()
        {
            txtDescripcion.Text = MateriaActual.Descripcion;
            cbPlan.SelectedIndex = cbPlan.FindStringExact( PlanLogic.GetOne(MateriaActual.IdPlan).Descripcion);
            nHsSemanales.Value = MateriaActual.HsSemanales;
            nHsTotales.Value = MateriaActual.HsTotales;
        }

        public override void MapearADatos()
        {
            if(Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia();
            }

            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.IdPlan = ((Plan)cbPlan.SelectedItem).ID;
                MateriaActual.HsSemanales = (int)nHsSemanales.Value;
                MateriaActual.HsTotales = (int) nHsTotales.Value;
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    MateriaActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic.Save(MateriaActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo != ModoForm.Consulta)
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text) || cbPlan.SelectedIndex == -1 || 
                    nHsSemanales.Value <= 0 || nHsTotales.Value <= 0)
                {
                    MessageBox.Show("Algunos campos están vacios. Por favor rellene con la información solicitada.");
                }
                else if (nHsSemanales.Value > nHsTotales.Value)
                {
                    MessageBox.Show("Las horas totales deben ser menos que las horas semanales. Por favor corrija e intente de nuevo.");
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
    }
}
