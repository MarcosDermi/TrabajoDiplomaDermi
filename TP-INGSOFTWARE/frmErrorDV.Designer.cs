namespace TP_INGSOFTWARE
{
    partial class frmErrorDV
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
            this.dgvUsuariosCorruptos = new System.Windows.Forms.DataGridView();
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.lblUsuariosCorruptos = new System.Windows.Forms.Label();
            this.lblPorcentajeCorrupcion = new System.Windows.Forms.Label();
            this.lblEstadoSistema = new System.Windows.Forms.Label();
            this.btnRepararUsuario = new System.Windows.Forms.Button();
            this.btnRepararTodos = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminarUser = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosCorruptos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuariosCorruptos
            // 
            this.dgvUsuariosCorruptos.AllowUserToAddRows = false;
            this.dgvUsuariosCorruptos.AllowUserToDeleteRows = false;
            this.dgvUsuariosCorruptos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuariosCorruptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosCorruptos.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuariosCorruptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosCorruptos.Location = new System.Drawing.Point(16, 222);
            this.dgvUsuariosCorruptos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUsuariosCorruptos.MultiSelect = false;
            this.dgvUsuariosCorruptos.Name = "dgvUsuariosCorruptos";
            this.dgvUsuariosCorruptos.ReadOnly = true;
            this.dgvUsuariosCorruptos.RowHeadersWidth = 51;
            this.dgvUsuariosCorruptos.RowTemplate.Height = 24;
            this.dgvUsuariosCorruptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosCorruptos.Size = new System.Drawing.Size(1085, 329);
            this.dgvUsuariosCorruptos.TabIndex = 0;
            // 
            // lblTotalUsuarios
            // 
            this.lblTotalUsuarios.AutoSize = true;
            this.lblTotalUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUsuarios.Location = new System.Drawing.Point(8, 31);
            this.lblTotalUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalUsuarios.Name = "lblTotalUsuarios";
            this.lblTotalUsuarios.Size = new System.Drawing.Size(132, 18);
            this.lblTotalUsuarios.TabIndex = 1;
            this.lblTotalUsuarios.Text = "Total usuarios: -";
            // 
            // lblUsuariosCorruptos
            // 
            this.lblUsuariosCorruptos.AutoSize = true;
            this.lblUsuariosCorruptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuariosCorruptos.Location = new System.Drawing.Point(8, 62);
            this.lblUsuariosCorruptos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuariosCorruptos.Name = "lblUsuariosCorruptos";
            this.lblUsuariosCorruptos.Size = new System.Drawing.Size(170, 18);
            this.lblUsuariosCorruptos.TabIndex = 2;
            this.lblUsuariosCorruptos.Text = "Usuarios corruptos: -";
            // 
            // lblPorcentajeCorrupcion
            // 
            this.lblPorcentajeCorrupcion.AutoSize = true;
            this.lblPorcentajeCorrupcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeCorrupcion.Location = new System.Drawing.Point(8, 92);
            this.lblPorcentajeCorrupcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPorcentajeCorrupcion.Name = "lblPorcentajeCorrupcion";
            this.lblPorcentajeCorrupcion.Size = new System.Drawing.Size(214, 18);
            this.lblPorcentajeCorrupcion.TabIndex = 3;
            this.lblPorcentajeCorrupcion.Text = "Porcentaje de corrupción: -";
            // 
            // lblEstadoSistema
            // 
            this.lblEstadoSistema.AutoSize = true;
            this.lblEstadoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoSistema.Location = new System.Drawing.Point(8, 123);
            this.lblEstadoSistema.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstadoSistema.Name = "lblEstadoSistema";
            this.lblEstadoSistema.Size = new System.Drawing.Size(143, 18);
            this.lblEstadoSistema.TabIndex = 4;
            this.lblEstadoSistema.Text = "Estado Sistema: -";
            // 
            // btnRepararUsuario
            // 
            this.btnRepararUsuario.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRepararUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepararUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepararUsuario.ForeColor = System.Drawing.Color.White;
            this.btnRepararUsuario.Location = new System.Drawing.Point(87, 25);
            this.btnRepararUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btnRepararUsuario.Name = "btnRepararUsuario";
            this.btnRepararUsuario.Size = new System.Drawing.Size(200, 43);
            this.btnRepararUsuario.TabIndex = 5;
            this.btnRepararUsuario.Text = "Reparar Usuario";
            this.btnRepararUsuario.UseVisualStyleBackColor = false;
            this.btnRepararUsuario.Click += new System.EventHandler(this.btnRepararUsuario_Click);
            // 
            // btnRepararTodos
            // 
            this.btnRepararTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRepararTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepararTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepararTodos.ForeColor = System.Drawing.Color.White;
            this.btnRepararTodos.Location = new System.Drawing.Point(371, 25);
            this.btnRepararTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnRepararTodos.Name = "btnRepararTodos";
            this.btnRepararTodos.Size = new System.Drawing.Size(200, 43);
            this.btnRepararTodos.TabIndex = 6;
            this.btnRepararTodos.Text = "Reparar Todos";
            this.btnRepararTodos.UseVisualStyleBackColor = false;
            this.btnRepararTodos.Click += new System.EventHandler(this.btnRepararTodos_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(632, 23);
            this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(200, 43);
            this.btnRefrescar.TabIndex = 8;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1048, 23);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(200, 43);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalUsuarios);
            this.groupBox1.Controls.Add(this.lblUsuariosCorruptos);
            this.groupBox1.Controls.Add(this.lblPorcentajeCorrupcion);
            this.groupBox1.Controls.Add(this.lblEstadoSistema);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(400, 160);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estadísticas de Corrupción";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminarUser);
            this.groupBox2.Controls.Add(this.btnRepararUsuario);
            this.groupBox2.Controls.Add(this.btnRepararTodos);
            this.groupBox2.Controls.Add(this.btnRefrescar);
            this.groupBox2.Controls.Add(this.btnCerrar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(424, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(627, 141);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // btnEliminarUser
            // 
            this.btnEliminarUser.BackColor = System.Drawing.Color.Red;
            this.btnEliminarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUser.ForeColor = System.Drawing.Color.White;
            this.btnEliminarUser.Location = new System.Drawing.Point(228, 80);
            this.btnEliminarUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarUser.Name = "btnEliminarUser";
            this.btnEliminarUser.Size = new System.Drawing.Size(200, 43);
            this.btnEliminarUser.TabIndex = 12;
            this.btnEliminarUser.Text = "Eliminar Usuario";
            this.btnEliminarUser.UseVisualStyleBackColor = false;
            this.btnEliminarUser.Click += new System.EventHandler(this.btnEliminarUser_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 11);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(383, 31);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "Errores de Dígito Verificador";
            // 
            // frmErrorDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1117, 565);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvUsuariosCorruptos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmErrorDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Errores de Dígito Verificador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmErrorDV_FormClosing);
            this.Load += new System.EventHandler(this.frmErrorDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosCorruptos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuariosCorruptos;
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.Label lblUsuariosCorruptos;
        private System.Windows.Forms.Label lblPorcentajeCorrupcion;
        private System.Windows.Forms.Label lblEstadoSistema;
        private System.Windows.Forms.Button btnRepararUsuario;
        private System.Windows.Forms.Button btnRepararTodos;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnEliminarUser;
    }
}