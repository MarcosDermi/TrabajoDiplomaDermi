namespace UI.Interfaces.Sesion.Servicios
{
    partial class frmGestionarServiciosServicioEdit
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkLstProfesional = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuffer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCrearInsumo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarInsumoAgregado = new System.Windows.Forms.Button();
            this.btnAgregarInsumo = new System.Windows.Forms.Button();
            this.dgvInsumosServicio = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumosServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtBuffer);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtDuracion);
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(518, 151);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos generales:";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.chkLstProfesional);
            this.groupBox5.Location = new System.Drawing.Point(332, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 120);
            this.groupBox5.TabIndex = 53;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Asignar a profesional:";
            // 
            // chkLstProfesional
            // 
            this.chkLstProfesional.FormattingEnabled = true;
            this.chkLstProfesional.Location = new System.Drawing.Point(6, 27);
            this.chkLstProfesional.Name = "chkLstProfesional";
            this.chkLstProfesional.Size = new System.Drawing.Size(137, 84);
            this.chkLstProfesional.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Precio:";
            // 
            // txtBuffer
            // 
            this.txtBuffer.Location = new System.Drawing.Point(201, 87);
            this.txtBuffer.Name = "txtBuffer";
            this.txtBuffer.Size = new System.Drawing.Size(71, 21);
            this.txtBuffer.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Buffer(Minutos):";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(201, 40);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(71, 21);
            this.txtDuracion.TabIndex = 53;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(18, 87);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(77, 21);
            this.txtPrecio.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Duracion(Minutos):";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(18, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(127, 21);
            this.txtNombre.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Nombre:";
            // 
            // btnCrearInsumo
            // 
            this.btnCrearInsumo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCrearInsumo.Location = new System.Drawing.Point(153, 408);
            this.btnCrearInsumo.Name = "btnCrearInsumo";
            this.btnCrearInsumo.Size = new System.Drawing.Size(231, 47);
            this.btnCrearInsumo.TabIndex = 48;
            this.btnCrearInsumo.Text = "Guardar";
            this.btnCrearInsumo.UseVisualStyleBackColor = false;
            this.btnCrearInsumo.Click += new System.EventHandler(this.btnCrearInsumo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarInsumoAgregado);
            this.groupBox2.Controls.Add(this.btnAgregarInsumo);
            this.groupBox2.Controls.Add(this.dgvInsumosServicio);
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 230);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Insumos:";
            // 
            // btnEliminarInsumoAgregado
            // 
            this.btnEliminarInsumoAgregado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminarInsumoAgregado.Location = new System.Drawing.Point(15, 194);
            this.btnEliminarInsumoAgregado.Name = "btnEliminarInsumoAgregado";
            this.btnEliminarInsumoAgregado.Size = new System.Drawing.Size(112, 30);
            this.btnEliminarInsumoAgregado.TabIndex = 53;
            this.btnEliminarInsumoAgregado.Text = "Eliminar Insumo";
            this.btnEliminarInsumoAgregado.UseVisualStyleBackColor = false;
            this.btnEliminarInsumoAgregado.Click += new System.EventHandler(this.btnEliminarInsumoAgregado_Click);
            // 
            // btnAgregarInsumo
            // 
            this.btnAgregarInsumo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarInsumo.Location = new System.Drawing.Point(394, 20);
            this.btnAgregarInsumo.Name = "btnAgregarInsumo";
            this.btnAgregarInsumo.Size = new System.Drawing.Size(112, 30);
            this.btnAgregarInsumo.TabIndex = 52;
            this.btnAgregarInsumo.Text = "Agregar insumo";
            this.btnAgregarInsumo.UseVisualStyleBackColor = false;
            this.btnAgregarInsumo.Click += new System.EventHandler(this.btnAgregarInsumo_Click);
            // 
            // dgvInsumosServicio
            // 
            this.dgvInsumosServicio.AllowUserToAddRows = false;
            this.dgvInsumosServicio.AllowUserToDeleteRows = false;
            this.dgvInsumosServicio.AllowUserToResizeRows = false;
            this.dgvInsumosServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInsumosServicio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvInsumosServicio.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInsumosServicio.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumosServicio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsumosServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsumosServicio.Location = new System.Drawing.Point(15, 56);
            this.dgvInsumosServicio.MultiSelect = false;
            this.dgvInsumosServicio.Name = "dgvInsumosServicio";
            this.dgvInsumosServicio.ReadOnly = true;
            this.dgvInsumosServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumosServicio.Size = new System.Drawing.Size(493, 135);
            this.dgvInsumosServicio.TabIndex = 0;
            // 
            // frmGestionarServiciosServicioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(532, 467);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCrearInsumo);
            this.Name = "frmGestionarServiciosServicioEdit";
            this.Text = "Crear Servicio";
            this.Load += new System.EventHandler(this.frmGestionarServiciosServicioEdit_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumosServicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnCrearInsumo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox chkLstProfesional;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBuffer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminarInsumoAgregado;
        private System.Windows.Forms.Button btnAgregarInsumo;
        private System.Windows.Forms.DataGridView dgvInsumosServicio;
    }
}