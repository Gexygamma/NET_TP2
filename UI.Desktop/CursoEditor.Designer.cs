namespace UI.Desktop
{
    partial class CursoEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarAuxiliar = new System.Windows.Forms.Button();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblDocenteAuxiliar = new System.Windows.Forms.Label();
            this.cbDocenteAuxiliar = new System.Windows.Forms.ComboBox();
            this.cbDocenteTitular = new System.Windows.Forms.ComboBox();
            this.lblDocenteTitular = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.lblAnioCalendario = new System.Windows.Forms.Label();
            this.lblComision = new System.Windows.Forms.Label();
            this.lblMateria = new System.Windows.Forms.Label();
            this.nCupo = new System.Windows.Forms.NumericUpDown();
            this.nAnioCalendario = new System.Windows.Forms.NumericUpDown();
            this.cbComision = new System.Windows.Forms.ComboBox();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAnioCalendario)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnEliminarAuxiliar);
            this.groupBox1.Controls.Add(this.cbPlan);
            this.groupBox1.Controls.Add(this.lblPlan);
            this.groupBox1.Controls.Add(this.lblDocenteAuxiliar);
            this.groupBox1.Controls.Add(this.cbDocenteAuxiliar);
            this.groupBox1.Controls.Add(this.cbDocenteTitular);
            this.groupBox1.Controls.Add(this.lblDocenteTitular);
            this.groupBox1.Controls.Add(this.lblCupo);
            this.groupBox1.Controls.Add(this.lblAnioCalendario);
            this.groupBox1.Controls.Add(this.lblComision);
            this.groupBox1.Controls.Add(this.lblMateria);
            this.groupBox1.Controls.Add(this.nCupo);
            this.groupBox1.Controls.Add(this.nAnioCalendario);
            this.groupBox1.Controls.Add(this.cbComision);
            this.groupBox1.Controls.Add(this.cbMateria);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Curso";
            // 
            // btnEliminarAuxiliar
            // 
            this.btnEliminarAuxiliar.Location = new System.Drawing.Point(226, 128);
            this.btnEliminarAuxiliar.Name = "btnEliminarAuxiliar";
            this.btnEliminarAuxiliar.Size = new System.Drawing.Size(52, 21);
            this.btnEliminarAuxiliar.TabIndex = 13;
            this.btnEliminarAuxiliar.Text = "Eliminar";
            this.btnEliminarAuxiliar.UseVisualStyleBackColor = true;
            this.btnEliminarAuxiliar.Click += new System.EventHandler(this.btnEliminarAuxiliar_Click);
            // 
            // cbPlan
            // 
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Location = new System.Drawing.Point(98, 20);
            this.cbPlan.Name = "cbPlan";
            this.cbPlan.Size = new System.Drawing.Size(180, 21);
            this.cbPlan.TabIndex = 0;
            this.cbPlan.SelectedIndexChanged += new System.EventHandler(this.cbPlan_SelectedIndexChanged);
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(6, 23);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 12;
            this.lblPlan.Text = "Plan";
            // 
            // lblDocenteAuxiliar
            // 
            this.lblDocenteAuxiliar.AutoSize = true;
            this.lblDocenteAuxiliar.Location = new System.Drawing.Point(6, 131);
            this.lblDocenteAuxiliar.Name = "lblDocenteAuxiliar";
            this.lblDocenteAuxiliar.Size = new System.Drawing.Size(84, 13);
            this.lblDocenteAuxiliar.TabIndex = 11;
            this.lblDocenteAuxiliar.Text = "Docente Auxiliar";
            // 
            // cbDocenteAuxiliar
            // 
            this.cbDocenteAuxiliar.FormattingEnabled = true;
            this.cbDocenteAuxiliar.Location = new System.Drawing.Point(98, 128);
            this.cbDocenteAuxiliar.Name = "cbDocenteAuxiliar";
            this.cbDocenteAuxiliar.Size = new System.Drawing.Size(122, 21);
            this.cbDocenteAuxiliar.TabIndex = 4;
            this.cbDocenteAuxiliar.SelectedIndexChanged += new System.EventHandler(this.cbDocenteAuxiliar_SelectedIndexChanged);
            // 
            // cbDocenteTitular
            // 
            this.cbDocenteTitular.FormattingEnabled = true;
            this.cbDocenteTitular.Location = new System.Drawing.Point(98, 101);
            this.cbDocenteTitular.Name = "cbDocenteTitular";
            this.cbDocenteTitular.Size = new System.Drawing.Size(180, 21);
            this.cbDocenteTitular.TabIndex = 3;
            // 
            // lblDocenteTitular
            // 
            this.lblDocenteTitular.AutoSize = true;
            this.lblDocenteTitular.Location = new System.Drawing.Point(6, 104);
            this.lblDocenteTitular.Name = "lblDocenteTitular";
            this.lblDocenteTitular.Size = new System.Drawing.Size(80, 13);
            this.lblDocenteTitular.TabIndex = 8;
            this.lblDocenteTitular.Text = "Docente Titular";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(6, 183);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(32, 13);
            this.lblCupo.TabIndex = 7;
            this.lblCupo.Text = "Cupo";
            // 
            // lblAnioCalendario
            // 
            this.lblAnioCalendario.AutoSize = true;
            this.lblAnioCalendario.Location = new System.Drawing.Point(6, 157);
            this.lblAnioCalendario.Name = "lblAnioCalendario";
            this.lblAnioCalendario.Size = new System.Drawing.Size(79, 13);
            this.lblAnioCalendario.TabIndex = 6;
            this.lblAnioCalendario.Text = "Año Calendario";
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(6, 77);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(49, 13);
            this.lblComision.TabIndex = 5;
            this.lblComision.Text = "Comisión";
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(6, 50);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(42, 13);
            this.lblMateria.TabIndex = 4;
            this.lblMateria.Text = "Materia";
            // 
            // nCupo
            // 
            this.nCupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nCupo.Location = new System.Drawing.Point(191, 181);
            this.nCupo.Name = "nCupo";
            this.nCupo.Size = new System.Drawing.Size(87, 20);
            this.nCupo.TabIndex = 6;
            this.nCupo.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nAnioCalendario
            // 
            this.nAnioCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nAnioCalendario.Location = new System.Drawing.Point(191, 155);
            this.nAnioCalendario.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nAnioCalendario.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.nAnioCalendario.Name = "nAnioCalendario";
            this.nAnioCalendario.Size = new System.Drawing.Size(87, 20);
            this.nAnioCalendario.TabIndex = 5;
            this.nAnioCalendario.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // cbComision
            // 
            this.cbComision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(98, 74);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(180, 21);
            this.cbComision.TabIndex = 2;
            // 
            // cbMateria
            // 
            this.cbMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(98, 47);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(180, 21);
            this.cbMateria.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Location = new System.Drawing.Point(222, 239);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(141, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CursoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 274);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CursoEditor";
            this.Text = "Edición de Curso";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAnioCalendario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.NumericUpDown nCupo;
        private System.Windows.Forms.NumericUpDown nAnioCalendario;
        private System.Windows.Forms.ComboBox cbComision;
        private System.Windows.Forms.ComboBox cbMateria;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Label lblAnioCalendario;
        private System.Windows.Forms.Label lblDocenteAuxiliar;
        private System.Windows.Forms.ComboBox cbDocenteAuxiliar;
        private System.Windows.Forms.ComboBox cbDocenteTitular;
        private System.Windows.Forms.Label lblDocenteTitular;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Button btnEliminarAuxiliar;
    }
}