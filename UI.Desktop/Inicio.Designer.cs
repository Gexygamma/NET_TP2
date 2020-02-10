namespace UI.Desktop
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSistema = new System.Windows.Forms.ToolStripDropDownButton();
            this.modificarDatosPersonalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddAdministrador = new System.Windows.Forms.ToolStripDropDownButton();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddAlumno = new System.Windows.Forms.ToolStripDropDownButton();
            this.inscribirseACursadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeCursadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddProfesor = new System.Windows.Forms.ToolStripDropDownButton();
            this.reporteDeCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDePlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(12, 25);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(128, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "No hay usuario logueado.";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSistema,
            this.ddAdministrador,
            this.ddAlumno,
            this.ddProfesor});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSistema
            // 
            this.toolStripSistema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarDatosPersonalesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripSistema.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSistema.Image")));
            this.toolStripSistema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSistema.Name = "toolStripSistema";
            this.toolStripSistema.ShowDropDownArrow = false;
            this.toolStripSistema.Size = new System.Drawing.Size(52, 22);
            this.toolStripSistema.Text = "Sistema";
            // 
            // modificarDatosPersonalesToolStripMenuItem
            // 
            this.modificarDatosPersonalesToolStripMenuItem.Name = "modificarDatosPersonalesToolStripMenuItem";
            this.modificarDatosPersonalesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.modificarDatosPersonalesToolStripMenuItem.Text = "Modificar datos personales";
            this.modificarDatosPersonalesToolStripMenuItem.Click += new System.EventHandler(this.modificarDatosPersonalesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ddAdministrador
            // 
            this.ddAdministrador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddAdministrador.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.planesToolStripMenuItem,
            this.materiasToolStripMenuItem,
            this.especialidadesToolStripMenuItem,
            this.comisionesToolStripMenuItem,
            this.cursosToolStripMenuItem});
            this.ddAdministrador.Image = ((System.Drawing.Image)(resources.GetObject("ddAdministrador.Image")));
            this.ddAdministrador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddAdministrador.Name = "ddAdministrador";
            this.ddAdministrador.ShowDropDownArrow = false;
            this.ddAdministrador.Size = new System.Drawing.Size(87, 22);
            this.ddAdministrador.Text = "Administrador";
            this.ddAdministrador.Visible = false;
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios...";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.planesToolStripMenuItem.Text = "Planes...";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            this.materiasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.materiasToolStripMenuItem.Text = "Materias...";
            this.materiasToolStripMenuItem.Click += new System.EventHandler(this.materiasToolStripMenuItem_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.especialidadesToolStripMenuItem.Text = "Especialidades...";
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.especialidadesToolStripMenuItem_Click);
            // 
            // comisionesToolStripMenuItem
            // 
            this.comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            this.comisionesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.comisionesToolStripMenuItem.Text = "Comisiones...";
            this.comisionesToolStripMenuItem.Click += new System.EventHandler(this.comisionesToolStripMenuItem_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cursosToolStripMenuItem.Text = "Cursos...";
            this.cursosToolStripMenuItem.Click += new System.EventHandler(this.cursosToolStripMenuItem_Click);
            // 
            // ddAlumno
            // 
            this.ddAlumno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddAlumno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscribirseACursadoToolStripMenuItem,
            this.reporteDeCursadoToolStripMenuItem});
            this.ddAlumno.Image = ((System.Drawing.Image)(resources.GetObject("ddAlumno.Image")));
            this.ddAlumno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddAlumno.Name = "ddAlumno";
            this.ddAlumno.ShowDropDownArrow = false;
            this.ddAlumno.Size = new System.Drawing.Size(54, 22);
            this.ddAlumno.Text = "Alumno";
            this.ddAlumno.Visible = false;
            // 
            // inscribirseACursadoToolStripMenuItem
            // 
            this.inscribirseACursadoToolStripMenuItem.Name = "inscribirseACursadoToolStripMenuItem";
            this.inscribirseACursadoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.inscribirseACursadoToolStripMenuItem.Text = "Inscribirse a cursado";
            this.inscribirseACursadoToolStripMenuItem.Click += new System.EventHandler(this.inscribirseACursadoToolStripMenuItem_Click);
            // 
            // reporteDeCursadoToolStripMenuItem
            // 
            this.reporteDeCursadoToolStripMenuItem.Name = "reporteDeCursadoToolStripMenuItem";
            this.reporteDeCursadoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.reporteDeCursadoToolStripMenuItem.Text = "Reporte de cursado";
            // 
            // ddProfesor
            // 
            this.ddProfesor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddProfesor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeCursosToolStripMenuItem,
            this.reporteDePlanesToolStripMenuItem,
            this.registroDeNotasToolStripMenuItem});
            this.ddProfesor.Image = ((System.Drawing.Image)(resources.GetObject("ddProfesor.Image")));
            this.ddProfesor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddProfesor.Name = "ddProfesor";
            this.ddProfesor.ShowDropDownArrow = false;
            this.ddProfesor.Size = new System.Drawing.Size(55, 22);
            this.ddProfesor.Text = "Profesor";
            this.ddProfesor.Visible = false;
            // 
            // reporteDeCursosToolStripMenuItem
            // 
            this.reporteDeCursosToolStripMenuItem.Name = "reporteDeCursosToolStripMenuItem";
            this.reporteDeCursosToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.reporteDeCursosToolStripMenuItem.Text = "Reporte de cursos";
            // 
            // reporteDePlanesToolStripMenuItem
            // 
            this.reporteDePlanesToolStripMenuItem.Name = "reporteDePlanesToolStripMenuItem";
            this.reporteDePlanesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.reporteDePlanesToolStripMenuItem.Text = "Reporte de planes";
            // 
            // registroDeNotasToolStripMenuItem
            // 
            this.registroDeNotasToolStripMenuItem.Name = "registroDeNotasToolStripMenuItem";
            this.registroDeNotasToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.registroDeNotasToolStripMenuItem.Text = "Registro de notas";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblVersion.Location = new System.Drawing.Point(751, 428);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(37, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "v4.2.0";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.lblWelcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión Académico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Inicio_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inicio_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSistema;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripDropDownButton ddAdministrador;
        private System.Windows.Forms.ToolStripDropDownButton ddAlumno;
        private System.Windows.Forms.ToolStripDropDownButton ddProfesor;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscribirseACursadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDePlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarDatosPersonalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reporteDeCursadoToolStripMenuItem;
    }
}