namespace TP_INGSOFTWARE
{
    partial class frmGestionPermisos
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
            this.grpPatentes = new System.Windows.Forms.GroupBox();
            this.cmdAgregarPatente = new System.Windows.Forms.Button();
            this.cboPatentes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.cmdAgregarFamilia = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFamilias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.treeConfigurarFamilia = new System.Windows.Forms.TreeView();
            this.grpPatentes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPatentes
            // 
            this.grpPatentes.Controls.Add(this.cmdAgregarPatente);
            this.grpPatentes.Controls.Add(this.cboPatentes);
            this.grpPatentes.Controls.Add(this.label2);
            this.grpPatentes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grpPatentes.Location = new System.Drawing.Point(12, 15);
            this.grpPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Name = "grpPatentes";
            this.grpPatentes.Padding = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Size = new System.Drawing.Size(299, 148);
            this.grpPatentes.TabIndex = 19;
            this.grpPatentes.TabStop = false;
            this.grpPatentes.Text = "Patentes";
            // 
            // cmdAgregarPatente
            // 
            this.cmdAgregarPatente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdAgregarPatente.Location = new System.Drawing.Point(12, 84);
            this.cmdAgregarPatente.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAgregarPatente.Name = "cmdAgregarPatente";
            this.cmdAgregarPatente.Size = new System.Drawing.Size(118, 37);
            this.cmdAgregarPatente.TabIndex = 8;
            this.cmdAgregarPatente.Text = "Agregar >";
            this.cmdAgregarPatente.UseVisualStyleBackColor = true;
            this.cmdAgregarPatente.Click += new System.EventHandler(this.CmdAgregarPatente_Click);
            // 
            // cboPatentes
            // 
            this.cboPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatentes.FormattingEnabled = true;
            this.cboPatentes.Location = new System.Drawing.Point(12, 45);
            this.cboPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.cboPatentes.Name = "cboPatentes";
            this.cboPatentes.Size = new System.Drawing.Size(272, 26);
            this.cboPatentes.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Todas las patentes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdSeleccionar);
            this.groupBox2.Controls.Add(this.cmdAgregarFamilia);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.cboFamilias);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(12, 221);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(299, 264);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Familias";
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdSeleccionar.Location = new System.Drawing.Point(16, 73);
            this.cmdSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(114, 28);
            this.cmdSeleccionar.TabIndex = 11;
            this.cmdSeleccionar.Text = "Configurar";
            this.cmdSeleccionar.UseVisualStyleBackColor = true;
            this.cmdSeleccionar.Click += new System.EventHandler(this.CmdSeleccionar_Click);
            // 
            // cmdAgregarFamilia
            // 
            this.cmdAgregarFamilia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdAgregarFamilia.Location = new System.Drawing.Point(136, 73);
            this.cmdAgregarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.cmdAgregarFamilia.Name = "cmdAgregarFamilia";
            this.cmdAgregarFamilia.Size = new System.Drawing.Size(97, 28);
            this.cmdAgregarFamilia.TabIndex = 10;
            this.cmdAgregarFamilia.Text = "Agregar >";
            this.cmdAgregarFamilia.UseVisualStyleBackColor = true;
            this.cmdAgregarFamilia.Click += new System.EventHandler(this.CmdAgregarFamilia_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtNombreFamilia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(18, 114);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(271, 123);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nueva";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(12, 77);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(12, 43);
            this.txtNombreFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(202, 25);
            this.txtNombreFamilia.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nombre";
            // 
            // cboFamilias
            // 
            this.cboFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilias.FormattingEnabled = true;
            this.cboFamilias.Location = new System.Drawing.Point(18, 45);
            this.cboFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.cboFamilias.Name = "cboFamilias";
            this.cboFamilias.Size = new System.Drawing.Size(272, 26);
            this.cboFamilias.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Todas las familias";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Button2);
            this.groupBox4.Controls.Add(this.treeConfigurarFamilia);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Location = new System.Drawing.Point(318, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(338, 483);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configurar Familia";
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ForeColor = System.Drawing.Color.SeaGreen;
            this.Button2.Location = new System.Drawing.Point(12, 434);
            this.Button2.Margin = new System.Windows.Forms.Padding(2);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(306, 36);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Guardar familia";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // treeConfigurarFamilia
            // 
            this.treeConfigurarFamilia.Location = new System.Drawing.Point(12, 25);
            this.treeConfigurarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.treeConfigurarFamilia.Name = "treeConfigurarFamilia";
            this.treeConfigurarFamilia.Size = new System.Drawing.Size(305, 402);
            this.treeConfigurarFamilia.TabIndex = 0;
            // 
            // frmGestionPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(700, 517);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpPatentes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGestionPermisos";
            this.Text = "Gestion de permisos";
            this.Load += new System.EventHandler(this.frmGestionPermisos_Load);
            this.grpPatentes.ResumeLayout(false);
            this.grpPatentes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPatentes;
        private System.Windows.Forms.Button cmdAgregarPatente;
        private System.Windows.Forms.ComboBox cboPatentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdSeleccionar;
        private System.Windows.Forms.Button cmdAgregarFamilia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFamilias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.TreeView treeConfigurarFamilia;
    }
}