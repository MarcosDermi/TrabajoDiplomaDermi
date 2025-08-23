namespace TP_INGSOFTWARE
{
    partial class frmGestionIdiomas
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtNombreIdioma = new System.Windows.Forms.TextBox();
            this.txtTraduccion = new System.Windows.Forms.TextBox();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.btnCrearTraduccion = new System.Windows.Forms.Button();
            this.dgvTraducciones = new System.Windows.Forms.DataGridView();
            this.cbPalabras = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(20, 65);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Crear idioma";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNombreIdioma
            // 
            this.txtNombreIdioma.Location = new System.Drawing.Point(20, 22);
            this.txtNombreIdioma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreIdioma.Name = "txtNombreIdioma";
            this.txtNombreIdioma.Size = new System.Drawing.Size(217, 22);
            this.txtNombreIdioma.TabIndex = 4;
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.Location = new System.Drawing.Point(20, 87);
            this.txtTraduccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(217, 22);
            this.txtTraduccion.TabIndex = 5;
            // 
            // cmbIdioma
            // 
            this.cmbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Location = new System.Drawing.Point(20, 117);
            this.cmbIdioma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(217, 24);
            this.cmbIdioma.TabIndex = 6;
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);
            // 
            // btnCrearTraduccion
            // 
            this.btnCrearTraduccion.ForeColor = System.Drawing.Color.Black;
            this.btnCrearTraduccion.Location = new System.Drawing.Point(20, 133);
            this.btnCrearTraduccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrearTraduccion.Name = "btnCrearTraduccion";
            this.btnCrearTraduccion.Size = new System.Drawing.Size(219, 28);
            this.btnCrearTraduccion.TabIndex = 7;
            this.btnCrearTraduccion.Text = "Crear traduccion";
            this.btnCrearTraduccion.UseVisualStyleBackColor = true;
            this.btnCrearTraduccion.Click += new System.EventHandler(this.btnCrearTraduccion_Click);
            // 
            // dgvTraducciones
            // 
            this.dgvTraducciones.AllowUserToAddRows = false;
            this.dgvTraducciones.AllowUserToDeleteRows = false;
            this.dgvTraducciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTraducciones.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTraducciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraducciones.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvTraducciones.Location = new System.Drawing.Point(21, 21);
            this.dgvTraducciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTraducciones.MultiSelect = false;
            this.dgvTraducciones.Name = "dgvTraducciones";
            this.dgvTraducciones.ReadOnly = true;
            this.dgvTraducciones.RowHeadersWidth = 51;
            this.dgvTraducciones.RowTemplate.Height = 28;
            this.dgvTraducciones.Size = new System.Drawing.Size(543, 441);
            this.dgvTraducciones.TabIndex = 8;
            // 
            // cbPalabras
            // 
            this.cbPalabras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalabras.FormattingEnabled = true;
            this.cbPalabras.Location = new System.Drawing.Point(20, 39);
            this.cbPalabras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPalabras.Name = "cbPalabras";
            this.cbPalabras.Size = new System.Drawing.Size(217, 24);
            this.cbPalabras.TabIndex = 9;
            this.cbPalabras.SelectedIndexChanged += new System.EventHandler(this.cbPalabras_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreIdioma);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbIdioma);
            this.groupBox1.ForeColor = System.Drawing.Color.Cornsilk;
            this.groupBox1.Location = new System.Drawing.Point(27, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(249, 159);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Idiomas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTraducciones);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(304, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(579, 476);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Traducciones";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCrearTraduccion);
            this.groupBox3.Controls.Add(this.cbPalabras);
            this.groupBox3.Controls.Add(this.txtTraduccion);
            this.groupBox3.ForeColor = System.Drawing.Color.Cornsilk;
            this.groupBox3.Location = new System.Drawing.Point(27, 261);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(249, 186);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tags";
            // 
            // frmGestionIdiomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(904, 530);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmGestionIdiomas";
            this.Text = "Gestion de idiomas";
            this.Load += new System.EventHandler(this.frmGestionIdiomas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraducciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNombreIdioma;
        private System.Windows.Forms.TextBox txtTraduccion;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Button btnCrearTraduccion;
        private System.Windows.Forms.DataGridView dgvTraducciones;
        private System.Windows.Forms.ComboBox cbPalabras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}