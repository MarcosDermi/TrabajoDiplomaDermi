namespace UI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucCalendario = new UI.ProyectoDiploma.CalendarioReservas();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpTurnoSeleccionado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.grpTurnoSeleccionado.Controls.Add(this.button3);
            this.grpTurnoSeleccionado.Controls.Add(this.button2);
            this.grpTurnoSeleccionado.Controls.Add(this.dataGridView1);
            this.grpTurnoSeleccionado.Location = new System.Drawing.Point(727, 193);
            this.grpTurnoSeleccionado.Name = "grpTurnoSeleccionado";
            this.grpTurnoSeleccionado.Size = new System.Drawing.Size(351, 362);
            this.grpTurnoSeleccionado.TabIndex = 36;
            this.grpTurnoSeleccionado.TabStop = false;
            this.grpTurnoSeleccionado.Text = "Detalle turno:";
            this.grpTurnoSeleccionado.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(339, 175);
            this.dataGridView1.TabIndex = 0;
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
            this.groupBox4.Location = new System.Drawing.Point(17, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(483, 34);
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
            this.btnMesAnterior.Location = new System.Drawing.Point(17, 159);
            this.btnMesAnterior.Name = "btnMesAnterior";
            this.btnMesAnterior.Size = new System.Drawing.Size(32, 27);
            this.btnMesAnterior.TabIndex = 34;
            this.btnMesAnterior.Text = "<";
            this.btnMesAnterior.UseVisualStyleBackColor = true;
            this.btnMesAnterior.Click += new System.EventHandler(this.btnMesAnterior_Click);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(67, 164);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(11, 13);
            this.lblMes.TabIndex = 32;
            this.lblMes.Text = "-";
            // 
            // btnMesSiguiente
            // 
            this.btnMesSiguiente.Location = new System.Drawing.Point(162, 159);
            this.btnMesSiguiente.Name = "btnMesSiguiente";
            this.btnMesSiguiente.Size = new System.Drawing.Size(32, 27);
            this.btnMesSiguiente.TabIndex = 33;
            this.btnMesSiguiente.Text = ">";
            this.btnMesSiguiente.UseVisualStyleBackColor = true;
            this.btnMesSiguiente.Click += new System.EventHandler(this.btnMesSiguiente_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewHorarios);
            this.groupBox3.Location = new System.Drawing.Point(512, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 362);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Horarios:";
            // 
            // dataGridViewHorarios
            // 
            this.dataGridViewHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHorarios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHorarios.Location = new System.Drawing.Point(14, 20);
            this.dataGridViewHorarios.Name = "dataGridViewHorarios";
            this.dataGridViewHorarios.Size = new System.Drawing.Size(189, 336);
            this.dataGridViewHorarios.TabIndex = 24;
            this.dataGridViewHorarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorarios_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 104);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros Busqueda:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(95)))), ((int)(((byte)(170)))));
            this.button1.Location = new System.Drawing.Point(248, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 33);
            this.button1.TabIndex = 25;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Apellido:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 22;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(211, 21);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucCalendario);
            this.groupBox1.Location = new System.Drawing.Point(17, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 333);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // ucCalendario
            // 
            this.ucCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCalendario.Location = new System.Drawing.Point(3, 17);
            this.ucCalendario.Name = "ucCalendario";
            this.ucCalendario.Size = new System.Drawing.Size(477, 313);
            this.ucCalendario.TabIndex = 0;
            this.ucCalendario.Load += new System.EventHandler(this.ucCalendario_Load);
            this.ucCalendario.Click += new System.EventHandler(this.ucCalendario_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(95)))), ((int)(((byte)(170)))));
            this.button2.Location = new System.Drawing.Point(32, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 33);
            this.button2.TabIndex = 26;
            this.button2.Text = "Atendido";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.IndianRed;
            this.button3.Location = new System.Drawing.Point(199, 277);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 33);
            this.button3.TabIndex = 27;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // frmAgendaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 620);
            this.Controls.Add(this.grpTurnoSeleccionado);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnMesAnterior);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.btnMesSiguiente);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmAgendaTurnos";
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.frmAgendaTurnos_Load);
            this.grpTurnoSeleccionado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private ProyectoDiploma.CalendarioReservas ucCalendario;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}