namespace UI.Interfaces.Sesion.Calendario
{
    partial class frmAgendaTurnos
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
            this.label1 = new System.Windows.Forms.Label();
            this.grpTurnoSeleccionado = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.btnAtendido = new System.Windows.Forms.Button();
            this.dgvDetalleTurno = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMesAnterior = new System.Windows.Forms.Button();
            this.lblMes = new System.Windows.Forms.Label();
            this.btnMesSiguiente = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewHorarios = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucCalendario = new UI.ProyectoDiploma.CalendarioReservas();
            this.grpTurnoSeleccionado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTurno)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(95)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Agenda de Turnos";
            // 
            // grpTurnoSeleccionado
            // 
            this.grpTurnoSeleccionado.Controls.Add(this.label4);
            this.grpTurnoSeleccionado.Controls.Add(this.lblMontoTotal);
            this.grpTurnoSeleccionado.Controls.Add(this.btnCancelarTurno);
            this.grpTurnoSeleccionado.Controls.Add(this.btnAtendido);
            this.grpTurnoSeleccionado.Controls.Add(this.dgvDetalleTurno);
            this.grpTurnoSeleccionado.Location = new System.Drawing.Point(725, 85);
            this.grpTurnoSeleccionado.Name = "grpTurnoSeleccionado";
            this.grpTurnoSeleccionado.Size = new System.Drawing.Size(163, 364);
            this.grpTurnoSeleccionado.TabIndex = 36;
            this.grpTurnoSeleccionado.TabStop = false;
            this.grpTurnoSeleccionado.Text = "Detalle turno:";
            this.grpTurnoSeleccionado.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Monto total:";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Location = new System.Drawing.Point(14, 229);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(11, 13);
            this.lblMontoTotal.TabIndex = 28;
            this.lblMontoTotal.Text = "-";
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelarTurno.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarTurno.ForeColor = System.Drawing.Color.IndianRed;
            this.btnCancelarTurno.Location = new System.Drawing.Point(17, 322);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(119, 33);
            this.btnCancelarTurno.TabIndex = 4;
            this.btnCancelarTurno.Text = "Cancelar";
            this.btnCancelarTurno.UseVisualStyleBackColor = false;
            this.btnCancelarTurno.Click += new System.EventHandler(this.btnCancelarTurno_Click);
            // 
            // btnAtendido
            // 
            this.btnAtendido.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtendido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(95)))), ((int)(((byte)(170)))));
            this.btnAtendido.Location = new System.Drawing.Point(6, 283);
            this.btnAtendido.Name = "btnAtendido";
            this.btnAtendido.Size = new System.Drawing.Size(145, 33);
            this.btnAtendido.TabIndex = 3;
            this.btnAtendido.Text = "Atendido";
            this.btnAtendido.UseVisualStyleBackColor = true;
            this.btnAtendido.Click += new System.EventHandler(this.btnAtendido_Click);
            // 
            // dgvDetalleTurno
            // 
            this.dgvDetalleTurno.AllowUserToAddRows = false;
            this.dgvDetalleTurno.AllowUserToDeleteRows = false;
            this.dgvDetalleTurno.AllowUserToResizeColumns = false;
            this.dgvDetalleTurno.AllowUserToResizeRows = false;
            this.dgvDetalleTurno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleTurno.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalleTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleTurno.Enabled = false;
            this.dgvDetalleTurno.Location = new System.Drawing.Point(6, 20);
            this.dgvDetalleTurno.Name = "dgvDetalleTurno";
            this.dgvDetalleTurno.Size = new System.Drawing.Size(145, 175);
            this.dgvDetalleTurno.TabIndex = 0;
            this.dgvDetalleTurno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleTurno_CellContentClick);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(15, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(483, 37);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Domingo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(426, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Sabado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Viernes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Jueves";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Miercoles";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Martes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Lunes";
            // 
            // btnMesAnterior
            // 
            this.btnMesAnterior.Location = new System.Drawing.Point(15, 51);
            this.btnMesAnterior.Name = "btnMesAnterior";
            this.btnMesAnterior.Size = new System.Drawing.Size(32, 30);
            this.btnMesAnterior.TabIndex = 5;
            this.btnMesAnterior.Text = "<";
            this.btnMesAnterior.UseVisualStyleBackColor = true;
            this.btnMesAnterior.Click += new System.EventHandler(this.btnMesAnterior_Click);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(65, 56);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(11, 13);
            this.lblMes.TabIndex = 32;
            this.lblMes.Text = "-";
            // 
            // btnMesSiguiente
            // 
            this.btnMesSiguiente.Location = new System.Drawing.Point(160, 51);
            this.btnMesSiguiente.Name = "btnMesSiguiente";
            this.btnMesSiguiente.Size = new System.Drawing.Size(32, 30);
            this.btnMesSiguiente.TabIndex = 6;
            this.btnMesSiguiente.Text = ">";
            this.btnMesSiguiente.UseVisualStyleBackColor = true;
            this.btnMesSiguiente.Click += new System.EventHandler(this.btnMesSiguiente_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewHorarios);
            this.groupBox3.Location = new System.Drawing.Point(510, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 365);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Horarios:";
            // 
            // dataGridViewHorarios
            // 
            this.dataGridViewHorarios.AllowUserToAddRows = false;
            this.dataGridViewHorarios.AllowUserToDeleteRows = false;
            this.dataGridViewHorarios.AllowUserToResizeColumns = false;
            this.dataGridViewHorarios.AllowUserToResizeRows = false;
            this.dataGridViewHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHorarios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHorarios.Location = new System.Drawing.Point(14, 20);
            this.dataGridViewHorarios.Name = "dataGridViewHorarios";
            this.dataGridViewHorarios.Size = new System.Drawing.Size(189, 336);
            this.dataGridViewHorarios.TabIndex = 2;
            this.dataGridViewHorarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorarios_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucCalendario);
            this.groupBox1.Location = new System.Drawing.Point(15, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 336);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // ucCalendario
            // 
            this.ucCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCalendario.Location = new System.Drawing.Point(3, 17);
            this.ucCalendario.Name = "ucCalendario";
            this.ucCalendario.Size = new System.Drawing.Size(477, 316);
            this.ucCalendario.TabIndex = 1;
            this.ucCalendario.Load += new System.EventHandler(this.ucCalendario_Load);
            this.ucCalendario.Click += new System.EventHandler(this.ucCalendario_Click);
            // 
            // frmAgendaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 462);
            this.Controls.Add(this.grpTurnoSeleccionado);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnMesAnterior);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.btnMesSiguiente);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmAgendaTurnos";
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.frmAgendaTurnos_Load);
            this.grpTurnoSeleccionado.ResumeLayout(false);
            this.grpTurnoSeleccionado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTurno)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTurnoSeleccionado;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMesAnterior;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Button btnMesSiguiente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewHorarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private ProyectoDiploma.CalendarioReservas ucCalendario;
        private System.Windows.Forms.DataGridView dgvDetalleTurno;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.Button btnAtendido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMontoTotal;
    }
}