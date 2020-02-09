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
            this.lblCupo = new System.Windows.Forms.Label();
            this.lblAnioCalendario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.lblCupo);
            this.groupBox1.Controls.Add(this.lblAnioCalendario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblMateria);
            this.groupBox1.Controls.Add(this.nCupo);
            this.groupBox1.Controls.Add(this.nAnioCalendario);
            this.groupBox1.Controls.Add(this.cbComision);
            this.groupBox1.Controls.Add(this.cbMateria);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Curso";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(6, 104);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(32, 13);
            this.lblCupo.TabIndex = 7;
            this.lblCupo.Text = "Cupo";
            // 
            // lblAnioCalendario
            // 
            this.lblAnioCalendario.AutoSize = true;
            this.lblAnioCalendario.Location = new System.Drawing.Point(6, 78);
            this.lblAnioCalendario.Name = "lblAnioCalendario";
            this.lblAnioCalendario.Size = new System.Drawing.Size(79, 13);
            this.lblAnioCalendario.TabIndex = 6;
            this.lblAnioCalendario.Text = "Año Calendario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Comisión";
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(6, 23);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(42, 13);
            this.lblMateria.TabIndex = 4;
            this.lblMateria.Text = "Materia";
            // 
            // nCupo
            // 
            this.nCupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nCupo.Location = new System.Drawing.Point(191, 102);
            this.nCupo.Name = "nCupo";
            this.nCupo.Size = new System.Drawing.Size(87, 20);
            this.nCupo.TabIndex = 3;
            // 
            // nAnioCalendario
            // 
            this.nAnioCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nAnioCalendario.Location = new System.Drawing.Point(191, 76);
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
            this.nAnioCalendario.TabIndex = 2;
            this.nAnioCalendario.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // cbComision
            // 
            this.cbComision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(97, 48);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(180, 21);
            this.cbComision.TabIndex = 1;
            // 
            // cbMateria
            // 
            this.cbMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(97, 20);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(181, 21);
            this.cbMateria.TabIndex = 0;
            this.cbMateria.SelectedIndexChanged += new System.EventHandler(this.cbMateria_SelectedIndexChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Location = new System.Drawing.Point(222, 161);
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
            this.btnCancelar.Location = new System.Drawing.Point(141, 161);
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
            this.ClientSize = new System.Drawing.Size(309, 196);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Label lblAnioCalendario;
    }
}