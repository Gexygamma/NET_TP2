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
    public partial class Inscripcion : Form
    {

        private readonly CursoLogic CursoLogic;
        

        public Inscripcion()
        {
            InitializeComponent();
            CursoLogic = new CursoLogic();
            cbMateria.DataSource = CursoLogic.GetAllTable(1);
            cbMateria.DisplayMember = "descMateria";
            cbMateria.ValueMember = "ID";
            cbMateria.SelectedIndex = -1;
            

        }

        private void cbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMateria.SelectedIndex != -1)
            {
                //cbComision.DataSource = CursoLogic.GetAllComision(idMateria);
                cbComision.SelectedIndex = -1;
            }
            else
            {
                cbComision.DataSource = new List<Comision>();
            }
        }

        public override void MapearADatos()
        { 
            //aqui iria la clase inscripcion
        }

            private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MapearADatos();
            //save de clase inscripcion
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
