﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        public Usuario UsuarioLogueado { get; set; }

        public Login()
        {
            InitializeComponent();
            UsuarioLogueado = null;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogueado = Autentificacion.AutentificarUsuario(txtNombreUsuario.Text, txtClave.Text);
            if (UsuarioLogueado == null)
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos. Por favor intente nuevamente.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!UsuarioLogueado.Habilitado)
            {
                MessageBox.Show("Usuario deshabilitado. Comuníquese con un administrador.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void lnkOlvideContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Pongase en contacto con el administrador para recuperar su contraseña.",
                "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
