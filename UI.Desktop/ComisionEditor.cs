using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionEditor : ApplicationForm
    {
        private readonly ComisionLogic ComisionLogic;
        private readonly PlanLogic PlanLogic;

        private Comision ComisionActual { get; set; }

        public ComisionEditor(ModoForm modo)
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
                nAnioEspecialidad.Enabled = false;
                cbPlan.Enabled = false;
            }

            ComisionLogic = new ComisionLogic();
            PlanLogic = new PlanLogic();

            cbPlan.DataSource = PlanLogic.GetAll();
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "ID";
            cbPlan.SelectedIndex = -1;
        }

        public ComisionEditor(ModoForm modo, int id) : this(modo)
        {
            ComisionActual = ComisionLogic.GetOne(id);
            MapearDeDatos();
        }

        public ComisionEditor() : this(ModoForm.Alta) { }

        public override void MapearDeDatos()
        {
            txtDescripcion.Text = ComisionActual.Descripcion;
            nAnioEspecialidad.Text = ComisionActual.AñoEspecialidad.ToString();
            cbPlan.SelectedValue = PlanLogic.GetOne(ComisionActual.IdPlan).ID;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ComisionActual = new Comision();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                ComisionActual.Descripcion = txtDescripcion.Text;
                ComisionActual.AñoEspecialidad = int.Parse(nAnioEspecialidad.Text);
                ComisionActual.IdPlan = ((Plan)cbPlan.SelectedItem).ID;
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic.Save(ComisionActual);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Modo != ModoForm.Consulta)
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(nAnioEspecialidad.Text) ||
                    cbPlan.SelectedIndex == -1)
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
    }
}
