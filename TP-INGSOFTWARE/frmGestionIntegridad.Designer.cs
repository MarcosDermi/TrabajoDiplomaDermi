namespace TP_INGSOFTWARE
{
    partial class frmGestionIntegridad
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lblDVSistema = new System.Windows.Forms.Label();
            this.lblEstadoSistema = new System.Windows.Forms.Label();
            this.btnValidarIntegridad = new System.Windows.Forms.Button();
            this.btnRecalcularDV = new System.Windows.Forms.Button();
            this.btnActualizarDVSistema = new System.Windows.Forms.Button();
            this.btnValidarUsuarioSeleccionado = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(16, 148);
            this.dgvUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(1035, 391);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // lblDVSistema
            // 
            this.lblDVSistema.AutoSize = true;
            this.lblDVSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVSistema.Location = new System.Drawing.Point(8, 31);
            this.lblDVSistema.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDVSistema.Name = "lblDVSistema";
            this.lblDVSistema.Size = new System.Drawing.Size(112, 18);
            this.lblDVSistema.TabIndex = 1;
            this.lblDVSistema.Text = "DV Sistema: -";
            // 
            // lblEstadoSistema
            // 
            this.lblEstadoSistema.AutoSize = true;
            this.lblEstadoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoSistema.Location = new System.Drawing.Point(8, 62);
            this.lblEstadoSistema.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstadoSistema.Name = "lblEstadoSistema";
            this.lblEstadoSistema.Size = new System.Drawing.Size(77, 18);
            this.lblEstadoSistema.TabIndex = 2;
            this.lblEstadoSistema.Text = "Estado: -";
            // 
            // btnValidarIntegridad
            // 
            this.btnValidarIntegridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnValidarIntegridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidarIntegridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarIntegridad.ForeColor = System.Drawing.Color.White;
            this.btnValidarIntegridad.Location = new System.Drawing.Point(8, 23);
            this.btnValidarIntegridad.Margin = new System.Windows.Forms.Padding(4);
            this.btnValidarIntegridad.Name = "btnValidarIntegridad";
            this.btnValidarIntegridad.Size = new System.Drawing.Size(200, 43);
            this.btnValidarIntegridad.TabIndex = 3;
            this.btnValidarIntegridad.Text = "Validar Integridad";
            this.btnValidarIntegridad.UseVisualStyleBackColor = false;
            this.btnValidarIntegridad.Click += new System.EventHandler(this.btnValidarIntegridad_Click);
            // 
            // btnRecalcularDV
            // 
            this.btnRecalcularDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRecalcularDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcularDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecalcularDV.ForeColor = System.Drawing.Color.White;
            this.btnRecalcularDV.Location = new System.Drawing.Point(216, 23);
            this.btnRecalcularDV.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecalcularDV.Name = "btnRecalcularDV";
            this.btnRecalcularDV.Size = new System.Drawing.Size(200, 43);
            this.btnRecalcularDV.TabIndex = 4;
            this.btnRecalcularDV.Text = "Recalcular DV";
            this.btnRecalcularDV.UseVisualStyleBackColor = false;
            this.btnRecalcularDV.Click += new System.EventHandler(this.btnRecalcularDV_Click);
            // 
            // btnActualizarDVSistema
            // 
            this.btnActualizarDVSistema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnActualizarDVSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarDVSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarDVSistema.ForeColor = System.Drawing.Color.White;
            this.btnActualizarDVSistema.Location = new System.Drawing.Point(424, 23);
            this.btnActualizarDVSistema.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizarDVSistema.Name = "btnActualizarDVSistema";
            this.btnActualizarDVSistema.Size = new System.Drawing.Size(200, 43);
            this.btnActualizarDVSistema.TabIndex = 5;
            this.btnActualizarDVSistema.Text = "Actualizar DV Sistema";
            this.btnActualizarDVSistema.UseVisualStyleBackColor = false;
            this.btnActualizarDVSistema.Click += new System.EventHandler(this.btnActualizarDVSistema_Click);
            // 
            // btnValidarUsuarioSeleccionado
            // 
            this.btnValidarUsuarioSeleccionado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnValidarUsuarioSeleccionado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidarUsuarioSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidarUsuarioSeleccionado.ForeColor = System.Drawing.Color.White;
            this.btnValidarUsuarioSeleccionado.Location = new System.Drawing.Point(632, 23);
            this.btnValidarUsuarioSeleccionado.Margin = new System.Windows.Forms.Padding(4);
            this.btnValidarUsuarioSeleccionado.Name = "btnValidarUsuarioSeleccionado";
            this.btnValidarUsuarioSeleccionado.Size = new System.Drawing.Size(200, 43);
            this.btnValidarUsuarioSeleccionado.TabIndex = 6;
            this.btnValidarUsuarioSeleccionado.Text = "Validar Usuario";
            this.btnValidarUsuarioSeleccionado.UseVisualStyleBackColor = false;
            this.btnValidarUsuarioSeleccionado.Click += new System.EventHandler(this.btnValidarUsuarioSeleccionado_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(840, 23);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(200, 43);
            this.btnRefrescar.TabIndex = 7;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDVSistema);
            this.groupBox1.Controls.Add(this.lblEstadoSistema);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(400, 98);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado del Sistema";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnValidarIntegridad);
            this.groupBox2.Controls.Add(this.btnRecalcularDV);
            this.groupBox2.Controls.Add(this.btnActualizarDVSistema);
            this.groupBox2.Controls.Add(this.btnValidarUsuarioSeleccionado);
            this.groupBox2.Controls.Add(this.btnRefrescar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(424, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(627, 98);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 11);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(342, 31);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Gestión de Integridad DV";
            // 
            // frmGestionIntegridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvUsuarios);
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmGestionIntegridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Integridad DV";
            this.Load += new System.EventHandler(this.frmGestionIntegridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblDVSistema;
        private System.Windows.Forms.Label lblEstadoSistema;
        private System.Windows.Forms.Button btnValidarIntegridad;
        private System.Windows.Forms.Button btnRecalcularDV;
        private System.Windows.Forms.Button btnActualizarDVSistema;
        private System.Windows.Forms.Button btnValidarUsuarioSeleccionado;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTitulo;
    }
}