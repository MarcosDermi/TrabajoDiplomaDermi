namespace UI.Interfaces.Sesion.Servicios
{
    partial class frmGestionarServicios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInsumosServicios = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblCantRegistrosServiciosInsumos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvServiciosProfesional = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCantRegistrosServicios = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkVerServicios = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProfesional = new System.Windows.Forms.ComboBox();
            this.btnEliminarServicio = new System.Windows.Forms.Button();
            this.btnModificarServicio = new System.Windows.Forms.Button();
            this.btnCrearServicio = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumosServicios)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosProfesional)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(95)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Gestion de Servicios";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnEliminarServicio);
            this.groupBox1.Controls.Add(this.btnModificarServicio);
            this.groupBox1.Controls.Add(this.btnCrearServicio);
            this.groupBox1.Location = new System.Drawing.Point(10, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1064, 557);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvInsumosServicios);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Location = new System.Drawing.Point(412, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 382);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Insumos:";
            // 
            // dgvInsumosServicios
            // 
            this.dgvInsumosServicios.AllowUserToAddRows = false;
            this.dgvInsumosServicios.AllowUserToDeleteRows = false;
            this.dgvInsumosServicios.AllowUserToResizeRows = false;
            this.dgvInsumosServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInsumosServicios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvInsumosServicios.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInsumosServicios.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumosServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsumosServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsumosServicios.Location = new System.Drawing.Point(15, 21);
            this.dgvInsumosServicios.MultiSelect = false;
            this.dgvInsumosServicios.Name = "dgvInsumosServicios";
            this.dgvInsumosServicios.ReadOnly = true;
            this.dgvInsumosServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumosServicios.Size = new System.Drawing.Size(350, 302);
            this.dgvInsumosServicios.TabIndex = 0;
            this.dgvInsumosServicios.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblCantRegistrosServiciosInsumos);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(15, 329);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(350, 42);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // lblCantRegistrosServiciosInsumos
            // 
            this.lblCantRegistrosServiciosInsumos.AutoSize = true;
            this.lblCantRegistrosServiciosInsumos.Location = new System.Drawing.Point(133, 17);
            this.lblCantRegistrosServiciosInsumos.Name = "lblCantRegistrosServiciosInsumos";
            this.lblCantRegistrosServiciosInsumos.Size = new System.Drawing.Size(11, 13);
            this.lblCantRegistrosServiciosInsumos.TabIndex = 10;
            this.lblCantRegistrosServiciosInsumos.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad de registros:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvServiciosProfesional);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Location = new System.Drawing.Point(20, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(386, 382);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Servicios:";
            // 
            // dgvServiciosProfesional
            // 
            this.dgvServiciosProfesional.AllowUserToAddRows = false;
            this.dgvServiciosProfesional.AllowUserToDeleteRows = false;
            this.dgvServiciosProfesional.AllowUserToResizeRows = false;
            this.dgvServiciosProfesional.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosProfesional.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvServiciosProfesional.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvServiciosProfesional.CausesValidation = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosProfesional.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiciosProfesional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiciosProfesional.Location = new System.Drawing.Point(15, 21);
            this.dgvServiciosProfesional.MultiSelect = false;
            this.dgvServiciosProfesional.Name = "dgvServiciosProfesional";
            this.dgvServiciosProfesional.ReadOnly = true;
            this.dgvServiciosProfesional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosProfesional.Size = new System.Drawing.Size(350, 302);
            this.dgvServiciosProfesional.TabIndex = 0;
            this.dgvServiciosProfesional.TabStop = false;
            this.dgvServiciosProfesional.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosProfesional_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCantRegistrosServicios);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(15, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 42);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lblCantRegistrosServicios
            // 
            this.lblCantRegistrosServicios.AutoSize = true;
            this.lblCantRegistrosServicios.Location = new System.Drawing.Point(133, 17);
            this.lblCantRegistrosServicios.Name = "lblCantRegistrosServicios";
            this.lblCantRegistrosServicios.Size = new System.Drawing.Size(11, 13);
            this.lblCantRegistrosServicios.TabIndex = 10;
            this.lblCantRegistrosServicios.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Cantidad de registros:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkVerServicios);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cmbProfesional);
            this.groupBox4.Location = new System.Drawing.Point(20, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(386, 78);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtrar:";
            // 
            // chkVerServicios
            // 
            this.chkVerServicios.AutoSize = true;
            this.chkVerServicios.Location = new System.Drawing.Point(90, 50);
            this.chkVerServicios.Name = "chkVerServicios";
            this.chkVerServicios.Size = new System.Drawing.Size(157, 17);
            this.chkVerServicios.TabIndex = 2;
            this.chkVerServicios.Text = "Mostrar todos los servicios.";
            this.chkVerServicios.UseVisualStyleBackColor = true;
            this.chkVerServicios.CheckedChanged += new System.EventHandler(this.chkVerServicios_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Profesional:";
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesional.FormattingEnabled = true;
            this.cmbProfesional.Location = new System.Drawing.Point(90, 21);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Size = new System.Drawing.Size(156, 21);
            this.cmbProfesional.TabIndex = 1;
            this.cmbProfesional.SelectedIndexChanged += new System.EventHandler(this.cmbProfesional_SelectedIndexChanged);
            // 
            // btnEliminarServicio
            // 
            this.btnEliminarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(55)))), ((int)(((byte)(62)))));
            this.btnEliminarServicio.Enabled = false;
            this.btnEliminarServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminarServicio.Location = new System.Drawing.Point(615, 70);
            this.btnEliminarServicio.Name = "btnEliminarServicio";
            this.btnEliminarServicio.Size = new System.Drawing.Size(171, 25);
            this.btnEliminarServicio.TabIndex = 5;
            this.btnEliminarServicio.Text = "Eliminar";
            this.btnEliminarServicio.UseVisualStyleBackColor = false;
            this.btnEliminarServicio.Click += new System.EventHandler(this.btnEliminarServicio_Click);
            // 
            // btnModificarServicio
            // 
            this.btnModificarServicio.BackColor = System.Drawing.Color.Khaki;
            this.btnModificarServicio.Enabled = false;
            this.btnModificarServicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnModificarServicio.Location = new System.Drawing.Point(436, 70);
            this.btnModificarServicio.Name = "btnModificarServicio";
            this.btnModificarServicio.Size = new System.Drawing.Size(173, 25);
            this.btnModificarServicio.TabIndex = 4;
            this.btnModificarServicio.Text = "Modificar";
            this.btnModificarServicio.UseVisualStyleBackColor = false;
            this.btnModificarServicio.Click += new System.EventHandler(this.btnModificarServicio_Click);
            // 
            // btnCrearServicio
            // 
            this.btnCrearServicio.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCrearServicio.Location = new System.Drawing.Point(436, 37);
            this.btnCrearServicio.Name = "btnCrearServicio";
            this.btnCrearServicio.Size = new System.Drawing.Size(350, 25);
            this.btnCrearServicio.TabIndex = 3;
            this.btnCrearServicio.Text = "Crear";
            this.btnCrearServicio.UseVisualStyleBackColor = false;
            this.btnCrearServicio.Click += new System.EventHandler(this.btnCrearInsumo_Click);
            // 
            // frmGestionarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 620);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGestionarServicios";
            this.Text = "Gestionar Servicios";
            this.Load += new System.EventHandler(this.frmGestionarServicios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumosServicios)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosProfesional)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminarServicio;
        private System.Windows.Forms.Button btnModificarServicio;
        private System.Windows.Forms.Button btnCrearServicio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCantRegistrosServicios;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvServiciosProfesional;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvInsumosServicios;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblCantRegistrosServiciosInsumos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkVerServicios;
    }
}