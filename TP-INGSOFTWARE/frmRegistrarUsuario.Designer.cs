namespace TP_INGSOFTWARE
{
    partial class frmRegistrarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarUsuario));
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtClaveConfirmada = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.chkMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblIdiomaIS = new System.Windows.Forms.Label();
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegistrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.btnRegistrarse.Location = new System.Drawing.Point(116, 586);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(219, 39);
            this.btnRegistrarse.TabIndex = 10;
            this.btnRegistrarse.Tag = "registrarse";
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.OnbtnRegistrarseClick);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtNombre.Location = new System.Drawing.Point(116, 169);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(219, 24);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Tag = "Ingrese nombre";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.SystemColors.Window;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtClave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtClave.Location = new System.Drawing.Point(116, 429);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '•';
            this.txtClave.Size = new System.Drawing.Size(219, 24);
            this.txtClave.TabIndex = 7;
            this.txtClave.Tag = "Ingrese una contraseña";
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            this.txtClave.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtClave.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // txtMail
            // 
            this.txtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtMail.Location = new System.Drawing.Point(116, 276);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(219, 24);
            this.txtMail.TabIndex = 4;
            this.txtMail.Tag = "Ingrese su mail";
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtClaveConfirmada
            // 
            this.txtClaveConfirmada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClaveConfirmada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtClaveConfirmada.Location = new System.Drawing.Point(116, 479);
            this.txtClaveConfirmada.Margin = new System.Windows.Forms.Padding(4);
            this.txtClaveConfirmada.Name = "txtClaveConfirmada";
            this.txtClaveConfirmada.PasswordChar = '•';
            this.txtClaveConfirmada.Size = new System.Drawing.Size(219, 24);
            this.txtClaveConfirmada.TabIndex = 8;
            this.txtClaveConfirmada.Tag = "Repita la contraseña";
            this.txtClaveConfirmada.Enter += new System.EventHandler(this.txtConfirmarContraseña_Enter);
            this.txtClaveConfirmada.Leave += new System.EventHandler(this.txtConfirmarContraseña_Leave);
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dtpFechaNac.Location = new System.Drawing.Point(116, 337);
            this.dtpFechaNac.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(219, 24);
            this.dtpFechaNac.TabIndex = 5;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFechaNac.ForeColor = System.Drawing.Color.LightGray;
            this.lblFechaNac.Location = new System.Drawing.Point(142, 309);
            this.lblFechaNac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(0, 18);
            this.lblFechaNac.TabIndex = 15;
            this.lblFechaNac.Tag = "Fecha de nacimiento";
            // 
            // chkMostrarContraseña
            // 
            this.chkMostrarContraseña.AutoSize = true;
            this.chkMostrarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.chkMostrarContraseña.ForeColor = System.Drawing.Color.LightGray;
            this.chkMostrarContraseña.Location = new System.Drawing.Point(116, 527);
            this.chkMostrarContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.chkMostrarContraseña.Name = "chkMostrarContraseña";
            this.chkMostrarContraseña.Size = new System.Drawing.Size(157, 22);
            this.chkMostrarContraseña.TabIndex = 9;
            this.chkMostrarContraseña.Tag = "mostrar contraseña";
            this.chkMostrarContraseña.Text = "Mostrar contraseña";
            this.chkMostrarContraseña.UseVisualStyleBackColor = true;
            this.chkMostrarContraseña.CheckedChanged += new System.EventHandler(this.chkMostrarContraseña_CheckedChanged);
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtApellido.Location = new System.Drawing.Point(116, 220);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(219, 24);
            this.txtApellido.TabIndex = 3;
            this.txtApellido.Tag = "Ingrese su apellido";
            this.txtApellido.Enter += new System.EventHandler(this.txtApellido_Enter);
            this.txtApellido.Leave += new System.EventHandler(this.txtApellido_Leave);
            // 
            // txtDNI
            // 
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDNI.Location = new System.Drawing.Point(116, 383);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(4);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(219, 24);
            this.txtDNI.TabIndex = 6;
            this.txtDNI.Tag = "Ingrese su DNI";
            this.txtDNI.Enter += new System.EventHandler(this.txtDNI_Enter);
            this.txtDNI.Leave += new System.EventHandler(this.txtDNI_Leave);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtUsuario.Location = new System.Drawing.Point(116, 112);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(219, 24);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Tag = "Ingrese nombre de usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // lblIdiomaIS
            // 
            this.lblIdiomaIS.AutoSize = true;
            this.lblIdiomaIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblIdiomaIS.ForeColor = System.Drawing.Color.LightGray;
            this.lblIdiomaIS.Location = new System.Drawing.Point(9, 9);
            this.lblIdiomaIS.Name = "lblIdiomaIS";
            this.lblIdiomaIS.Size = new System.Drawing.Size(48, 16);
            this.lblIdiomaIS.TabIndex = 17;
            this.lblIdiomaIS.Tag = "Idioma";
            this.lblIdiomaIS.Text = "Idioma";
            // 
            // cbIdioma
            // 
            this.cbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdioma.DropDownWidth = 80;
            this.cbIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.4F);
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Location = new System.Drawing.Point(12, 28);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(82, 21);
            this.cbIdioma.TabIndex = 1;
            this.cbIdioma.SelectedIndexChanged += new System.EventHandler(this.cbIdioma_SelectedIndexChanged);
            // 
            // frmRegistrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(442, 699);
            this.Controls.Add(this.lblIdiomaIS);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.chkMostrarContraseña);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.txtClaveConfirmada);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.btnRegistrarse);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRegistrarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRegistrarUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtClaveConfirmada;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.CheckBox chkMostrarContraseña;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblIdiomaIS;
        private System.Windows.Forms.ComboBox cbIdioma;
    }
}