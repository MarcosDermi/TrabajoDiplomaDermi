using System.Drawing;
using System.Windows.Forms;

namespace UI.Interfaces.Sesion.Profesionales
{
    partial class frmJornadasLaborales
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboProfesional;
        private System.Windows.Forms.Label lblProfesional;
        private System.Windows.Forms.DataGridView dgvJornadas;
        private System.Windows.Forms.DataGridView dgvFranjas;
        private System.Windows.Forms.Button btnAgregarJornada;
        private System.Windows.Forms.Button btnAgregarFranja;
        private System.Windows.Forms.Button btnEliminarFranja;
        private System.Windows.Forms.Label lblJornadas;
        private System.Windows.Forms.Label lblFranjas;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboProfesional = new System.Windows.Forms.ComboBox();
            this.lblProfesional = new System.Windows.Forms.Label();
            this.dgvJornadas = new System.Windows.Forms.DataGridView();
            this.dgvFranjas = new System.Windows.Forms.DataGridView();
            this.btnAgregarJornada = new System.Windows.Forms.Button();
            this.btnAgregarFranja = new System.Windows.Forms.Button();
            this.btnEliminarFranja = new System.Windows.Forms.Button();
            this.lblJornadas = new System.Windows.Forms.Label();
            this.lblFranjas = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJornadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFranjas)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProfesional
            // 
            this.cboProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfesional.Location = new System.Drawing.Point(110, 46);
            this.cboProfesional.Name = "cboProfesional";
            this.cboProfesional.Size = new System.Drawing.Size(220, 21);
            this.cboProfesional.TabIndex = 2;
            this.cboProfesional.SelectedIndexChanged += new System.EventHandler(this.cboProfesional_SelectedIndexChanged);
            // 
            // lblProfesional
            // 
            this.lblProfesional.AutoSize = true;
            this.lblProfesional.Location = new System.Drawing.Point(25, 50);
            this.lblProfesional.Name = "lblProfesional";
            this.lblProfesional.Size = new System.Drawing.Size(64, 13);
            this.lblProfesional.TabIndex = 1;
            this.lblProfesional.Text = "Profesional:";
            // 
            // dgvJornadas
            // 
            this.dgvJornadas.AllowUserToAddRows = false;
            this.dgvJornadas.AllowUserToDeleteRows = false;
            this.dgvJornadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJornadas.Location = new System.Drawing.Point(25, 110);
            this.dgvJornadas.MultiSelect = false;
            this.dgvJornadas.Name = "dgvJornadas";
            this.dgvJornadas.ReadOnly = true;
            this.dgvJornadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJornadas.Size = new System.Drawing.Size(340, 250);
            this.dgvJornadas.TabIndex = 6;
            this.dgvJornadas.SelectionChanged += new System.EventHandler(this.dgvJornadas_SelectionChanged);
            // 
            // dgvFranjas
            // 
            this.dgvFranjas.AllowUserToAddRows = false;
            this.dgvFranjas.AllowUserToDeleteRows = false;
            this.dgvFranjas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFranjas.Location = new System.Drawing.Point(390, 110);
            this.dgvFranjas.MultiSelect = false;
            this.dgvFranjas.Name = "dgvFranjas";
            this.dgvFranjas.ReadOnly = true;
            this.dgvFranjas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFranjas.Size = new System.Drawing.Size(350, 250);
            this.dgvFranjas.TabIndex = 8;
            this.dgvFranjas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFranjas_CellContentClick);
            // 
            // btnAgregarJornada
            // 
            this.btnAgregarJornada.Location = new System.Drawing.Point(25, 370);
            this.btnAgregarJornada.Name = "btnAgregarJornada";
            this.btnAgregarJornada.Size = new System.Drawing.Size(150, 35);
            this.btnAgregarJornada.TabIndex = 9;
            this.btnAgregarJornada.Text = "Modificar Jornadas";
            this.btnAgregarJornada.Click += new System.EventHandler(this.btnAgregarJornada_Click);
            // 
            // btnAgregarFranja
            // 
            this.btnAgregarFranja.Location = new System.Drawing.Point(390, 370);
            this.btnAgregarFranja.Name = "btnAgregarFranja";
            this.btnAgregarFranja.Size = new System.Drawing.Size(150, 35);
            this.btnAgregarFranja.TabIndex = 11;
            this.btnAgregarFranja.Text = "Agregar Franja";
            this.btnAgregarFranja.Click += new System.EventHandler(this.btnAgregarFranja_Click);
            // 
            // btnEliminarFranja
            // 
            this.btnEliminarFranja.Enabled = false;
            this.btnEliminarFranja.Location = new System.Drawing.Point(560, 370);
            this.btnEliminarFranja.Name = "btnEliminarFranja";
            this.btnEliminarFranja.Size = new System.Drawing.Size(150, 35);
            this.btnEliminarFranja.TabIndex = 12;
            this.btnEliminarFranja.Text = "Eliminar Franja";
            this.btnEliminarFranja.Click += new System.EventHandler(this.btnEliminarFranja_Click);
            // 
            // lblJornadas
            // 
            this.lblJornadas.AutoSize = true;
            this.lblJornadas.Location = new System.Drawing.Point(25, 90);
            this.lblJornadas.Name = "lblJornadas";
            this.lblJornadas.Size = new System.Drawing.Size(104, 13);
            this.lblJornadas.TabIndex = 5;
            this.lblJornadas.Text = "Jornadas Laborales:";
            // 
            // lblFranjas
            // 
            this.lblFranjas.AutoSize = true;
            this.lblFranjas.Location = new System.Drawing.Point(390, 90);
            this.lblFranjas.Name = "lblFranjas";
            this.lblFranjas.Size = new System.Drawing.Size(90, 13);
            this.lblFranjas.TabIndex = 7;
            this.lblFranjas.Text = "Franjas Horarias:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(377, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Jornadas Laborales y Franjas horarias";
            // 
            // frmJornadasLaborales
            // 
            this.ClientSize = new System.Drawing.Size(770, 430);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblProfesional);
            this.Controls.Add(this.cboProfesional);
            this.Controls.Add(this.lblJornadas);
            this.Controls.Add(this.dgvJornadas);
            this.Controls.Add(this.lblFranjas);
            this.Controls.Add(this.dgvFranjas);
            this.Controls.Add(this.btnAgregarJornada);
            this.Controls.Add(this.btnAgregarFranja);
            this.Controls.Add(this.btnEliminarFranja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmJornadasLaborales";
            this.Text = "Gestión de Jornadas y Franjas Horarias";
            this.Load += new System.EventHandler(this.frmFranjasHorarias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJornadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFranjas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
