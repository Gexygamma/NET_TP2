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
    public partial class PlanEditor : ApplicationForm
    {
        private readonly PlanLogic PlanLogic;
        private readonly EspecialidadLogic EspecialidadLogic;

        private Plan PlanActual { get; set; }

        public PlanEditor(ModoForm modo)
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
                cbEspecialidad.Enabled = false;
            }

            PlanLogic = new PlanLogic();
            EspecialidadLogic = new EspecialidadLogic();

            cbEspecialidad.DataSource = EspecialidadLogic.GetAll();
            cbEspecialidad.DisplayMember = "Descripcion";
            cbEspecialidad.ValueMember = "ID";
            cbEspecialidad.SelectedIndex = -1;
        }

        public PlanEditor(ModoForm modo, int ID) : this(modo)
        {
            PlanActual = PlanLogic.GetOne(ID);
            MapearDeDatos();
        }

        public PlanEditor() : this(ModoForm.Alta) { }

        public override void MapearDeDatos()
        {
            txtDescripcion.Text = PlanActual.Descripcion;
            cbEspecialidad.SelectedIndex = cbEspecialidad.FindStringExact(EspecialidadLogic.GetOne(PlanActual.IdEspecialidad).Descripcion);
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                PlanActual.IdEspecialidad = ((Especialidad)cbEspecialidad.SelectedItem).ID;
                PlanActual.Descripcion = txtDescripcion.Text;
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            try
            {
                PlanLogic.Save(PlanActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo != ModoForm.Consulta)
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text) || cbEspecialidad.SelectedIndex == -1)
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
            }        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
