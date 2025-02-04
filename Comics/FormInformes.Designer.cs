namespace Comics
{
    partial class FormInformes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.Windows.Forms.Label lblBuscarOperacion;
        private System.Windows.Forms.Label lblOperacionID;
        private System.Windows.Forms.TextBox textBoxOperacionID;
        private System.Windows.Forms.Label lblMedioDePago;
        private System.Windows.Forms.TextBox textBoxMedioDePago;
        private System.Windows.Forms.Label lblTipoOperacion;
        private System.Windows.Forms.Label lblFechaOperacion;
        private System.Windows.Forms.DataGridView dataGridViewResultados;
        private System.Windows.Forms.Button btnCargar;

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
            lblBuscarOperacion = new Label();
            lblOperacionID = new Label();
            textBoxOperacionID = new TextBox();
            lblMedioDePago = new Label();
            textBoxMedioDePago = new TextBox();
            lblTipoOperacion = new Label();
            lblFechaOperacion = new Label();
            dataGridViewResultados = new DataGridView();
            btnCargar = new Button();
            rbCompra = new RadioButton();
            rbVenta = new RadioButton();
            dtOperacion = new DateTimePicker();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultados).BeginInit();
            SuspendLayout();
            // 
            // lblBuscarOperacion
            // 
            lblBuscarOperacion.AutoSize = true;
            lblBuscarOperacion.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblBuscarOperacion.Location = new Point(10, 10);
            lblBuscarOperacion.Name = "lblBuscarOperacion";
            lblBuscarOperacion.Size = new Size(147, 19);
            lblBuscarOperacion.TabIndex = 0;
            lblBuscarOperacion.Text = "Buscar Operación";
            // 
            // lblOperacionID
            // 
            lblOperacionID.AutoSize = true;
            lblOperacionID.Location = new Point(10, 50);
            lblOperacionID.Name = "lblOperacionID";
            lblOperacionID.Size = new Size(79, 15);
            lblOperacionID.TabIndex = 1;
            lblOperacionID.Text = "Operacion ID:";
            // 
            // textBoxOperacionID
            // 
            textBoxOperacionID.Location = new Point(100, 50);
            textBoxOperacionID.Name = "textBoxOperacionID";
            textBoxOperacionID.Size = new Size(150, 23);
            textBoxOperacionID.TabIndex = 2;
            textBoxOperacionID.TextChanged += FiltrarOperaciones;
            // 
            // lblMedioDePago
            // 
            lblMedioDePago.AutoSize = true;
            lblMedioDePago.Location = new Point(260, 50);
            lblMedioDePago.Name = "lblMedioDePago";
            lblMedioDePago.Size = new Size(90, 15);
            lblMedioDePago.TabIndex = 3;
            lblMedioDePago.Text = "Medio de Pago:";
            // 
            // textBoxMedioDePago
            // 
            textBoxMedioDePago.Location = new Point(370, 50);
            textBoxMedioDePago.Name = "textBoxMedioDePago";
            textBoxMedioDePago.Size = new Size(150, 23);
            textBoxMedioDePago.TabIndex = 4;
            textBoxMedioDePago.TextChanged += FiltrarOperaciones;
            // 
            // lblTipoOperacion
            // 
            lblTipoOperacion.AutoSize = true;
            lblTipoOperacion.Location = new Point(530, 50);
            lblTipoOperacion.Name = "lblTipoOperacion";
            lblTipoOperacion.Size = new Size(107, 15);
            lblTipoOperacion.TabIndex = 5;
            lblTipoOperacion.Text = "Tipo de Operación:";
            // 
            // lblFechaOperacion
            // 
            lblFechaOperacion.AutoSize = true;
            lblFechaOperacion.Location = new Point(10, 90);
            lblFechaOperacion.Name = "lblFechaOperacion";
            lblFechaOperacion.Size = new Size(115, 15);
            lblFechaOperacion.TabIndex = 7;
            lblFechaOperacion.Text = "Fecha de Operación:";
            // 
            // dataGridViewResultados
            // 
            dataGridViewResultados.AllowUserToAddRows = false;
            dataGridViewResultados.AllowUserToDeleteRows = false;
            dataGridViewResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResultados.Location = new Point(10, 130);
            dataGridViewResultados.Name = "dataGridViewResultados";
            dataGridViewResultados.ReadOnly = true;
            dataGridViewResultados.Size = new Size(871, 400);
            dataGridViewResultados.TabIndex = 9;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(690, 90);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(100, 23);
            btnCargar.TabIndex = 10;
            btnCargar.Text = "Cargar Factura";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // rbCompra
            // 
            rbCompra.AutoSize = true;
            rbCompra.Location = new Point(656, 51);
            rbCompra.Name = "rbCompra";
            rbCompra.Size = new Size(68, 19);
            rbCompra.TabIndex = 11;
            rbCompra.TabStop = true;
            rbCompra.Text = "Compra";
            rbCompra.UseVisualStyleBackColor = true;
            rbCompra.CheckedChanged += FiltrarOperaciones;
            // 
            // rbVenta
            // 
            rbVenta.AutoSize = true;
            rbVenta.Location = new Point(730, 51);
            rbVenta.Name = "rbVenta";
            rbVenta.Size = new Size(54, 19);
            rbVenta.TabIndex = 12;
            rbVenta.TabStop = true;
            rbVenta.Text = "Venta";
            rbVenta.UseVisualStyleBackColor = true;
            rbVenta.CheckedChanged += FiltrarOperaciones;
            // 
            // dtOperacion
            // 
            dtOperacion.Enabled = false;
            dtOperacion.Location = new Point(131, 88);
            dtOperacion.Name = "dtOperacion";
            dtOperacion.Size = new Size(219, 23);
            dtOperacion.TabIndex = 13;
            dtOperacion.ValueChanged += FiltrarOperaciones;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(371, 93);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(112, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Busqueda Fecha";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // FormInformes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 600);
            Controls.Add(checkBox1);
            Controls.Add(dtOperacion);
            Controls.Add(rbVenta);
            Controls.Add(rbCompra);
            Controls.Add(btnCargar);
            Controls.Add(dataGridViewResultados);
            Controls.Add(lblBuscarOperacion);
            Controls.Add(lblOperacionID);
            Controls.Add(textBoxOperacionID);
            Controls.Add(lblMedioDePago);
            Controls.Add(textBoxMedioDePago);
            Controls.Add(lblTipoOperacion);
            Controls.Add(lblFechaOperacion);
            Name = "FormInformes";
            Text = "Buscar Operaciones";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbCompra;
        private RadioButton rbVenta;
        private DateTimePicker dtOperacion;
        private CheckBox checkBox1;
    }
}