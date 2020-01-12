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
            this.lblTest = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSistema = new System.Windows.Forms.ToolStripDropDownButton();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion = new System.Windows.Forms.Label();
            this.ddAdministrador = new System.Windows.Forms.ToolStripDropDownButton();
            this.ddAlumno = new System.Windows.Forms.ToolStripDropDownButton();
            this.ddProfesor = new System.Windows.Forms.ToolStripDropDownButton();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscribirseACursadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDePlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(12, 25);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(128, 13);
            this.lblTest.TabIndex = 0;
            this.lblTest.Text = "No hay usuario logueado.";
            // 
            // toolStrip
            // 
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
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripSistema.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSistema.Image")));
            this.toolStripSistema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSistema.Name = "toolStripSistema";
            this.toolStripSistema.ShowDropDownArrow = false;
            this.toolStripSistema.Size = new System.Drawing.Size(52, 22);
            this.toolStripSistema.Text = "Sistema";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
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
            // ddAdministrador
            // 
            this.ddAdministrador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddAdministrador.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.ddAdministrador.Image = ((System.Drawing.Image)(resources.GetObject("ddAdministrador.Image")));
            this.ddAdministrador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddAdministrador.Name = "ddAdministrador";
            this.ddAdministrador.ShowDropDownArrow = false;
            this.ddAdministrador.Size = new System.Drawing.Size(87, 22);
            this.ddAdministrador.Text = "Administrador";
            this.ddAdministrador.Visible = false;
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
            this.ddAlumno.Size = new System.Drawing.Size(54, 22);
            this.ddAlumno.Text = "Alumno";
            this.ddAlumno.Visible = false;
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
            this.ddProfesor.Size = new System.Drawing.Size(55, 22);
            this.ddProfesor.Text = "Profesor";
            this.ddProfesor.Visible = false;
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios...";
            // 
            // inscribirseACursadoToolStripMenuItem
            // 
            this.inscribirseACursadoToolStripMenuItem.Name = "inscribirseACursadoToolStripMenuItem";
            this.inscribirseACursadoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.inscribirseACursadoToolStripMenuItem.Text = "Inscribirse a cursado";
            // 
            // registroDeNotasToolStripMenuItem
            // 
            this.registroDeNotasToolStripMenuItem.Name = "registroDeNotasToolStripMenuItem";
            this.registroDeNotasToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.registroDeNotasToolStripMenuItem.Text = "Registro de notas";
            // 
            // reporteDeCursosToolStripMenuItem
            // 
            this.reporteDeCursosToolStripMenuItem.Name = "reporteDeCursosToolStripMenuItem";
            this.reporteDeCursosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reporteDeCursosToolStripMenuItem.Text = "Reporte de cursos";
            // 
            // reporteDePlanesToolStripMenuItem
            // 
            this.reporteDePlanesToolStripMenuItem.Name = "reporteDePlanesToolStripMenuItem";
            this.reporteDePlanesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reporteDePlanesToolStripMenuItem.Text = "Reporte de planes";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.lblTest);
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

        private System.Windows.Forms.Label lblTest;
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
    }
}