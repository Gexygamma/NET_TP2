﻿using System;
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

    public class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            StartPosition = FormStartPosition.CenterParent;
        }
        
        public ModoForm Modo { get; set; }

        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
    }
}
