namespace UI.Interfaces.Sesion.Promociones
{
    partial class frmGestionarPromociones
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBorrarCampos = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnModificarPromocion = new System.Windows.Forms.Button();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarPromocion = new System.Windows.Forms.Button();
            this.btnCrearPromocion = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvPromociones = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCantRegistros = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkIncluirInactivos = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaHastaBusqueda = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreBusqueda = new System.Windows.Forms.TextBox();
            this.dtpFechaDesdeBusqueda = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(95)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gestion de Promociones";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 502);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBorrarCampos);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.btnModificarPromocion);
            this.groupBox2.Controls.Add(this.chkActivo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDescuento);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFechaHasta);
            this.groupBox2.Controls.Add(this.dtpFechaDesde);
            this.groupBox2.Controls.Add(this.btnEliminarPromocion);
            this.groupBox2.Controls.Add(this.btnCrearPromocion);
            this.groupBox2.Location = new System.Drawing.Point(632, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 359);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // btnBorrarCampos
            // 
            this.btnBorrarCampos.BackColor = System.Drawing.Color.Ivory;
            this.btnBorrarCampos.Location = new System.Drawing.Point(32, 236);
            this.btnBorrarCampos.Name = "btnBorrarCampos";
            this.btnBorrarCampos.Size = new System.Drawing.Size(110, 25);
            this.btnBorrarCampos.TabIndex = 11;
            this.btnBorrarCampos.Text = "🗑️ Borrar campos";
            this.btnBorrarCampos.UseVisualStyleBackColor = false;
            this.btnBorrarCampos.Click += new System.EventHandler(this.btnBorrarCampos_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Id:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(202, 46);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(30, 21);
            this.txtID.TabIndex = 14;
            this.txtID.TabStop = false;
            // 
            // btnModificarPromocion
            // 
            this.btnModificarPromocion.BackColor = System.Drawing.Color.Khaki;
            this.btnModificarPromocion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnModificarPromocion.Location = new System.Drawing.Point(30, 298);
            this.btnModificarPromocion.Name = "btnModificarPromocion";
            this.btnModificarPromocion.Size = new System.Drawing.Size(202, 25);
            this.btnModificarPromocion.TabIndex = 13;
            this.btnModificarPromocion.Text = "Modificar";
            this.btnModificarPromocion.UseVisualStyleBackColor = false;
            this.btnModificarPromocion.Click += new System.EventHandler(this.btnModificarPromocion_Click);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(144, 101);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 8;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Descuento(%):";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(30, 101);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(54, 21);
            this.txtDescuento.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(32, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 21);
            this.txtNombre.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Desde:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(32, 197);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 21);
            this.dtpFechaHasta.TabIndex = 10;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(32, 157);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(200, 21);
            this.dtpFechaDesde.TabIndex = 9;
            // 
            // btnEliminarPromocion
            // 
            this.btnEliminarPromocion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(55)))), ((int)(((byte)(62)))));
            this.btnEliminarPromocion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminarPromocion.Location = new System.Drawing.Point(30, 327);
            this.btnEliminarPromocion.Name = "btnEliminarPromocion";
            this.btnEliminarPromocion.Size = new System.Drawing.Size(202, 25);
            this.btnEliminarPromocion.TabIndex = 14;
            this.btnEliminarPromocion.Text = "Eliminar";
            this.btnEliminarPromocion.UseVisualStyleBackColor = false;
            this.btnEliminarPromocion.Click += new System.EventHandler(this.btnEliminarPromocion_Click);
            // 
            // btnCrearPromocion
            // 
            this.btnCrearPromocion.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCrearPromocion.Location = new System.Drawing.Point(30, 267);
            this.btnCrearPromocion.Name = "btnCrearPromocion";
            this.btnCrearPromocion.Size = new System.Drawing.Size(202, 25);
            this.btnCrearPromocion.TabIndex = 12;
            this.btnCrearPromocion.Text = "Crear";
            this.btnCrearPromocion.UseVisualStyleBackColor = false;
            this.btnCrearPromocion.Click += new System.EventHandler(this.btnCrearPromocion_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvPromociones);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Location = new System.Drawing.Point(20, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(606, 382);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Resultados Busqueda:";
            // 
            // dgvPromociones
            // 
            this.dgvPromociones.AllowUserToAddRows = false;
            this.dgvPromociones.AllowUserToDeleteRows = false;
            this.dgvPromociones.AllowUserToResizeRows = false;
            this.dgvPromociones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPromociones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPromociones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPromociones.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPromociones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPromociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromociones.Location = new System.Drawing.Point(15, 21);
            this.dgvPromociones.MultiSelect = false;
            this.dgvPromociones.Name = "dgvPromociones";
            this.dgvPromociones.ReadOnly = true;
            this.dgvPromociones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromociones.Size = new System.Drawing.Size(585, 302);
            this.dgvPromociones.TabIndex = 0;
            this.dgvPromociones.TabStop = false;
            this.dgvPromociones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPromociones_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCantRegistros);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(15, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 42);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lblCantRegistros
            // 
            this.lblCantRegistros.AutoSize = true;
            this.lblCantRegistros.Location = new System.Drawing.Point(133, 17);
            this.lblCantRegistros.Name = "lblCantRegistros";
            this.lblCantRegistros.Size = new System.Drawing.Size(11, 13);
            this.lblCantRegistros.TabIndex = 10;
            this.lblCantRegistros.Text = "-";
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
            this.groupBox4.Controls.Add(this.chkIncluirInactivos);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.dtpFechaHastaBusqueda);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtNombreBusqueda);
            this.groupBox4.Controls.Add(this.dtpFechaDesdeBusqueda);
            this.groupBox4.Controls.Add(this.btnBuscar);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(20, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(867, 78);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtrar:";
            // 
            // chkIncluirInactivos
            // 
            this.chkIncluirInactivos.AutoSize = true;
            this.chkIncluirInactivos.Location = new System.Drawing.Point(24, 55);
            this.chkIncluirInactivos.Name = "chkIncluirInactivos";
            this.chkIncluirInactivos.Size = new System.Drawing.Size(100, 17);
            this.chkIncluirInactivos.TabIndex = 4;
            this.chkIncluirInactivos.Text = "Incluir inactivas";
            this.chkIncluirInactivos.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(405, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Hasta:";
            // 
            // dtpFechaHastaBusqueda
            // 
            this.dtpFechaHastaBusqueda.Location = new System.Drawing.Point(408, 32);
            this.dtpFechaHastaBusqueda.Name = "dtpFechaHastaBusqueda";
            this.dtpFechaHastaBusqueda.Size = new System.Drawing.Size(214, 21);
            this.dtpFechaHastaBusqueda.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Desde:";
            // 
            // txtNombreBusqueda
            // 
            this.txtNombreBusqueda.Location = new System.Drawing.Point(24, 32);
            this.txtNombreBusqueda.Name = "txtNombreBusqueda";
            this.txtNombreBusqueda.Size = new System.Drawing.Size(132, 21);
            this.txtNombreBusqueda.TabIndex = 1;
            // 
            // dtpFechaDesdeBusqueda
            // 
            this.dtpFechaDesdeBusqueda.Location = new System.Drawing.Point(171, 32);
            this.dtpFechaDesdeBusqueda.Name = "dtpFechaDesdeBusqueda";
            this.dtpFechaDesdeBusqueda.Size = new System.Drawing.Size(214, 21);
            this.dtpFechaDesdeBusqueda.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(95)))), ((int)(((byte)(170)))));
            this.btnBuscar.Location = new System.Drawing.Point(644, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(200, 36);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nombre:";
            // 
            // frmGestionarPromociones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGestionarPromociones";
            this.Text = "Promociones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromociones)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvPromociones;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCantRegistros;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEliminarPromocion;
        private System.Windows.Forms.Button btnCrearPromocion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaBusqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreBusqueda;
        private System.Windows.Forms.DateTimePicker dtpFechaDesdeBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.CheckBox chkIncluirInactivos;
        private System.Windows.Forms.Button btnModificarPromocion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnBorrarCampos;
    }
}