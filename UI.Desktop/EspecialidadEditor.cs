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
    public partial class EspecialidadEditor : ApplicationForm
    {
        private readonly EspecialidadLogic EspecialidadLogic;

        private Especialidad EspecialidadActual { get; set; }

        public EspecialidadEditor(ModoForm modo)
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
            }

            EspecialidadLogic = new EspecialidadLogic();
        }

        public EspecialidadEditor(ModoForm modo, int id) : this(modo)
        {
            EspecialidadActual = EspecialidadLogic.GetOne(id);
            MapearDeDatos();
        }

        public EspecialidadEditor() : this(ModoForm.Alta) { }

        public override void MapearDeDatos()
        {
            txtDescripcion.Text = EspecialidadActual.Descripcion;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = txtDescripcion.Text;
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Consulta:
                    EspecialidadActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Baja:
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            try
            {
                EspecialidadLogic.Save(EspecialidadActual);
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
                if (string.IsNullOrEmpty(txtDescripcion.Text))
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
