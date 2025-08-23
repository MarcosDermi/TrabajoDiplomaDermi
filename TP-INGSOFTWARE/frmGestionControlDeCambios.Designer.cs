namespace TP_INGSOFTWARE
{
    partial class frmGestionControlDeCambios
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
            this.dgvControlCambios = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlCambios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvControlCambios
            // 
            this.dgvControlCambios.AllowUserToAddRows = false;
            this.dgvControlCambios.AllowUserToDeleteRows = false;
            this.dgvControlCambios.AllowUserToOrderColumns = true;
            this.dgvControlCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvControlCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvControlCambios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvControlCambios.BackgroundColor = System.Drawing.Color.White;
            this.dgvControlCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControlCambios.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvControlCambios.Location = new System.Drawing.Point(13, 69);
            this.dgvControlCambios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvControlCambios.MultiSelect = false;
            this.dgvControlCambios.Name = "dgvControlCambios";
            this.dgvControlCambios.ReadOnly = true;
            this.dgvControlCambios.Size = new System.Drawing.Size(599, 312);
            this.dgvControlCambios.TabIndex = 1;
            this.dgvControlCambios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvControlCambios_CellContentClick);
            // 
            // btnModificar
            // 
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.btnModificar.Location = new System.Drawing.Point(229, 394);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(146, 30);
            this.btnModificar.TabIndex = 41;
            this.btnModificar.Text = "Recuperar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(13, 41);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(167, 21);
            this.cmbUsuarios.TabIndex = 46;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cmbUsuarios.SelectedValueChanged += new System.EventHandler(this.cmbUsuarios_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 47;
            this.label2.Text = "Usuario:";
            // 
            // frmGestionControlDeCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(625, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgvControlCambios);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "frmGestionControlDeCambios";
            this.Text = "Control de cambios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlCambios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvControlCambios;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Label label2;
    }
}