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
    public enum ModoForm { Alta, Baja, Modificacion, Consulta }

    public abstract class ApplicationForm : Form
    {
        public ModoForm Modo { get; set; }

        public abstract void MapearDeDatos();
        public abstract void MapearADatos();
        public abstract void GuardarCambios();
    }
}
