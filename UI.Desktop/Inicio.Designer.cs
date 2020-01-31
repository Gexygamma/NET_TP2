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
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddAdministrador = new System.Windows.Forms.ToolStripDropDownButton();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddAlumno = new System.Windows.Forms.ToolStripDropDownButton();
            this.inscribirseACursadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddProfesor = new System.Windows.Forms.ToolStripDropDownButton();
            this.reporteDeCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDePlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion = new System.Windows.Forms.Label();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(16, 31);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(171, 17);
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
            this.toolStrip.Size = new System.Drawing.Size(1067, 27);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSistema
            // 
            this.toolStripSistema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripSistema.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSistema.Image")));
            this.toolStripSistema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSistema.Name = "toolStripSistema";
            this.toolStripSistema.ShowDropDownArrow = false;
            this.toolStripSistema.Size = new System.Drawing.Size(65, 24);
            this.toolStripSistema.Text = "Sistema";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ddAdministrador
            // 
            this.ddAdministrador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddAdministrador.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.planesToolStripMenuItem});
            this.ddAdministrador.Image = ((System.Drawing.Image)(resources.GetObject("ddAdministrador.Image")));
            this.ddAdministrador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddAdministrador.Name = "ddAdministrador";
            this.ddAdministrador.ShowDropDownArrow = false;
            this.ddAdministrador.Size = new System.Drawing.Size(108, 24);
            this.ddAdministrador.Text = "Administrador";
            this.ddAdministrador.Visible = false;
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios...";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // ddAlumno
            // 
            this.ddAlumno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddAlumno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscribirseACursadoToolStripMenuItem,
            this.registroDeNotasToolStripMenuItem});
            this.ddAlumno.Image = ((System.Drawing.Image)(resources.GetObject("ddAlumno.Image")));
            this.ddAlumno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddAlumno.Name = "ddAlumno";
            this.ddAlumno.ShowDropDownArrow = false;
            this.ddAlumno.Size = new System.Drawing.Size(65, 24);
            this.ddAlumno.Text = "Alumno";
            this.ddAlumno.Visible = false;
            // 
            // inscribirseACursadoToolStripMenuItem
            // 
            this.inscribirseACursadoToolStripMenuItem.Name = "inscribirseACursadoToolStripMenuItem";
            this.inscribirseACursadoToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.inscribirseACursadoToolStripMenuItem.Text = "Inscribirse a cursado";
            // 
            // registroDeNotasToolStripMenuItem
            // 
            this.registroDeNotasToolStripMenuItem.Name = "registroDeNotasToolStripMenuItem";
            this.registroDeNotasToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.registroDeNotasToolStripMenuItem.Text = "Registro de notas";
            // 
            // ddProfesor
            // 
            this.ddProfesor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddProfesor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeCursosToolStripMenuItem,
            this.reporteDePlanesToolStripMenuItem});
            this.ddProfesor.Image = ((System.Drawing.Image)(resources.GetObject("ddProfesor.Image")));
            this.ddProfesor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddProfesor.Name = "ddProfesor";
            this.ddProfesor.ShowDropDownArrow = false;
            this.ddProfesor.Size = new System.Drawing.Size(68, 24);
            this.ddProfesor.Text = "Profesor";
            this.ddProfesor.Visible = false;
            // 
            // reporteDeCursosToolStripMenuItem
            // 
            this.reporteDeCursosToolStripMenuItem.Name = "reporteDeCursosToolStripMenuItem";
            this.reporteDeCursosToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.reporteDeCursosToolStripMenuItem.Text = "Reporte de cursos";
            // 
            // reporteDePlanesToolStripMenuItem
            // 
            this.reporteDePlanesToolStripMenuItem.Name = "reporteDePlanesToolStripMenuItem";
            this.reporteDePlanesToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.reporteDePlanesToolStripMenuItem.Text = "Reporte de planes";
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblVersion.Location = new System.Drawing.Point(1001, 527);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(47, 17);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "v4.2.0";
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.lblWelcome);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión Académico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Inicio_Shown);
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
        private System.Windows.Forms.ToolStripMenuItem registroDeNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDePlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
    }
}