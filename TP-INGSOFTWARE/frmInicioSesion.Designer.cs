namespace TP_INGSOFTWARE
{
    partial class frmInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioSesion));
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.chkMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.lblIdiomaIS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciarSesion.Location = new System.Drawing.Point(203, 330);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(273, 41);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Tag = "Iniciar sesión";
            this.btnIniciarSesion.Text = "Iniciar sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            this.btnIniciarSesion.Enter += new System.EventHandler(this.btnIniciarSesion_Enter);
            this.btnIniciarSesion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnIniciarSesion_KeyDown);
            this.btnIniciarSesion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnIniciarSesion_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Location = new System.Drawing.Point(203, 208);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(270, 24);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Tag = "Ingrese nombre de usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // chkMostrarContraseña
            // 
            this.chkMostrarContraseña.AutoSize = true;
            this.chkMostrarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkMostrarContraseña.ForeColor = System.Drawing.Color.LightGray;
            this.chkMostrarContraseña.Location = new System.Drawing.Point(203, 295);
            this.chkMostrarContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.chkMostrarContraseña.Name = "chkMostrarContraseña";
            this.chkMostrarContraseña.Size = new System.Drawing.Size(117, 17);
            this.chkMostrarContraseña.TabIndex = 3;
            this.chkMostrarContraseña.Tag = "mostrar contraseña";
            this.chkMostrarContraseña.Text = "Mostrar contraseña";
            this.chkMostrarContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMostrarContraseña.UseVisualStyleBackColor = true;
            this.chkMostrarContraseña.CheckedChanged += new System.EventHandler(this.chkMostrarContraseña_CheckedChanged);
            this.chkMostrarContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkMostrarContraseña_KeyPress);
            // 
            // txtClave
            // 
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Location = new System.Drawing.Point(203, 262);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '•';
            this.txtClave.Size = new System.Drawing.Size(270, 24);
            this.txtClave.TabIndex = 2;
            this.txtClave.Tag = "Ingrese una contraseña";
            this.txtClave.Enter += new System.EventHandler(this.txtClave_Enter);
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            this.txtClave.Leave += new System.EventHandler(this.txtClave_Leave);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarse.Location = new System.Drawing.Point(203, 423);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(273, 41);
            this.btnRegistrarse.TabIndex = 5;
            this.btnRegistrarse.Tag = "Registrarse";
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.OnBtnRegistrarseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(327, 389);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "O";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(100, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(485, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cbIdioma
            // 
            this.cbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdioma.DropDownWidth = 80;
            this.cbIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.4F);
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Location = new System.Drawing.Point(69, 207);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(82, 21);
            this.cbIdioma.TabIndex = 6;
            this.cbIdioma.SelectedIndexChanged += new System.EventHandler(this.cbIdioma_SelectedIndexChanged);
            // 
            // lblIdiomaIS
            // 
            this.lblIdiomaIS.AutoSize = true;
            this.lblIdiomaIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblIdiomaIS.ForeColor = System.Drawing.Color.LightGray;
            this.lblIdiomaIS.Location = new System.Drawing.Point(66, 188);
            this.lblIdiomaIS.Name = "lblIdiomaIS";
            this.lblIdiomaIS.Size = new System.Drawing.Size(51, 16);
            this.lblIdiomaIS.TabIndex = 9;
            this.lblIdiomaIS.Tag = "Idioma";
            this.lblIdiomaIS.Text = "Idioma:";
            // 
            // frmInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(656, 544);
            this.Controls.Add(this.lblIdiomaIS);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.chkMostrarContraseña);
            this.Controls.Add(this.txtClave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmInicioSesion_Load);
            this.Enter += new System.EventHandler(this.frmInicioSesion_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkMostrarContraseña;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Label lblIdiomaIS;
    }
}