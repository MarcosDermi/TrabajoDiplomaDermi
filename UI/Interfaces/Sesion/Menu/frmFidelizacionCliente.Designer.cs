namespace UI.Interfaces.Sesion.Menu
{
    partial class frmFidelizacionCliente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblPuntosTitulo = new System.Windows.Forms.Label();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.grpDescuento = new System.Windows.Forms.GroupBox();
            this.lblEquivalencia = new System.Windows.Forms.Label();
            this.lblPreviewDescuento = new System.Windows.Forms.Label();
            this.numPuntosCanje = new System.Windows.Forms.NumericUpDown();
            this.lblPuntosCanje = new System.Windows.Forms.Label();
            this.btnAplicarDescuento = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.grpDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntosCanje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(265, 25);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Mi Programa de Fidelización";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBienvenida.Location = new System.Drawing.Point(22, 50);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(358, 19);
            this.lblBienvenida.TabIndex = 5;
            this.lblBienvenida.Text = "Canjeá tus puntos por descuentos en tu próxima reserva.";
            // 
            // lblPuntosTitulo
            // 
            this.lblPuntosTitulo.AutoSize = true;
            this.lblPuntosTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPuntosTitulo.Location = new System.Drawing.Point(22, 80);
            this.lblPuntosTitulo.Name = "lblPuntosTitulo";
            this.lblPuntosTitulo.Size = new System.Drawing.Size(142, 19);
            this.lblPuntosTitulo.TabIndex = 4;
            this.lblPuntosTitulo.Text = "Puntos acumulados:";
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPuntos.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblPuntos.Location = new System.Drawing.Point(200, 75);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(23, 25);
            this.lblPuntos.TabIndex = 3;
            this.lblPuntos.Text = "0";
            // 
            // grpDescuento
            // 
            this.grpDescuento.Controls.Add(this.lblEquivalencia);
            this.grpDescuento.Controls.Add(this.lblPreviewDescuento);
            this.grpDescuento.Controls.Add(this.numPuntosCanje);
            this.grpDescuento.Controls.Add(this.lblPuntosCanje);
            this.grpDescuento.Controls.Add(this.btnAplicarDescuento);
            this.grpDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDescuento.Location = new System.Drawing.Point(25, 120);
            this.grpDescuento.Name = "grpDescuento";
            this.grpDescuento.Size = new System.Drawing.Size(580, 130);
            this.grpDescuento.TabIndex = 2;
            this.grpDescuento.TabStop = false;
            this.grpDescuento.Text = "Canjear puntos por descuento";
            // 
            // lblEquivalencia
            // 
            this.lblEquivalencia.AutoSize = true;
            this.lblEquivalencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEquivalencia.ForeColor = System.Drawing.Color.Gray;
            this.lblEquivalencia.Location = new System.Drawing.Point(150, 60);
            this.lblEquivalencia.Name = "lblEquivalencia";
            this.lblEquivalencia.Size = new System.Drawing.Size(193, 15);
            this.lblEquivalencia.TabIndex = 0;
            this.lblEquivalencia.Text = "Cada 10 puntos = 5% de descuento";
            // 
            // lblPreviewDescuento
            // 
            this.lblPreviewDescuento.AutoSize = true;
            this.lblPreviewDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreviewDescuento.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblPreviewDescuento.Location = new System.Drawing.Point(150, 85);
            this.lblPreviewDescuento.Name = "lblPreviewDescuento";
            this.lblPreviewDescuento.Size = new System.Drawing.Size(172, 19);
            this.lblPreviewDescuento.TabIndex = 1;
            this.lblPreviewDescuento.Text = "Descuento estimado: 5%";
            // 
            // numPuntosCanje
            // 
            this.numPuntosCanje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPuntosCanje.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPuntosCanje.Location = new System.Drawing.Point(150, 33);
            this.numPuntosCanje.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPuntosCanje.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPuntosCanje.Name = "numPuntosCanje";
            this.numPuntosCanje.Size = new System.Drawing.Size(120, 25);
            this.numPuntosCanje.TabIndex = 2;
            this.numPuntosCanje.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPuntosCanje.ValueChanged += new System.EventHandler(this.numPuntosCanje_ValueChanged);
            // 
            // lblPuntosCanje
            // 
            this.lblPuntosCanje.AutoSize = true;
            this.lblPuntosCanje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPuntosCanje.Location = new System.Drawing.Point(20, 35);
            this.lblPuntosCanje.Name = "lblPuntosCanje";
            this.lblPuntosCanje.Size = new System.Drawing.Size(113, 19);
            this.lblPuntosCanje.TabIndex = 3;
            this.lblPuntosCanje.Text = "Puntos a canjear:";
            // 
            // btnAplicarDescuento
            // 
            this.btnAplicarDescuento.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAplicarDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAplicarDescuento.ForeColor = System.Drawing.Color.White;
            this.btnAplicarDescuento.Location = new System.Drawing.Point(400, 50);
            this.btnAplicarDescuento.Name = "btnAplicarDescuento";
            this.btnAplicarDescuento.Size = new System.Drawing.Size(150, 35);
            this.btnAplicarDescuento.TabIndex = 4;
            this.btnAplicarDescuento.Text = "Aplicar descuento";
            this.btnAplicarDescuento.UseVisualStyleBackColor = false;
            this.btnAplicarDescuento.Click += new System.EventHandler(this.btnAplicarDescuento_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHistorial.Location = new System.Drawing.Point(25, 295);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(580, 200);
            this.dgvHistorial.TabIndex = 0;
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.Location = new System.Drawing.Point(22, 270);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(136, 19);
            this.lblHistorial.TabIndex = 1;
            this.lblHistorial.Text = "Historial de canjes:";
            // 
            // frmFidelizacionCliente
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(630, 520);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.grpDescuento);
            this.Controls.Add(this.lblPuntos);
            this.Controls.Add(this.lblPuntosTitulo);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmFidelizacionCliente";
            this.Text = "Programa de Fidelización";
            this.Load += new System.EventHandler(this.frmFidelizacionCliente_Load);
            this.grpDescuento.ResumeLayout(false);
            this.grpDescuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntosCanje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblPuntosTitulo;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.GroupBox grpDescuento;
        private System.Windows.Forms.Label lblEquivalencia;
        private System.Windows.Forms.Label lblPreviewDescuento;
        private System.Windows.Forms.NumericUpDown numPuntosCanje;
        private System.Windows.Forms.Label lblPuntosCanje;
        private System.Windows.Forms.Button btnAplicarDescuento;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblHistorial;
    }
}