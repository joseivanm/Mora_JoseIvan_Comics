namespace Comics
{
    partial class FormOperacion
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
            gbTipoOperacion = new GroupBox();
            rbCompra = new RadioButton();
            rbVenta = new RadioButton();
            gbCliente = new GroupBox();
            btnAddClientes = new Button();
            lblCliente = new Label();
            cmbClientes = new ComboBox();
            gbComics = new GroupBox();
            btnLoadComics = new Button();
            label1 = new Label();
            cmbComics = new ComboBox();
            lblComic = new Label();
            cmbEditorial = new ComboBox();
            btnAddComic = new Button();
            dgvOperacion = new DataGridView();
            Comic = new DataGridViewTextBoxColumn();
            ComicId = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Descuento = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            btnRemoveComic = new Button();
            gbTotales = new GroupBox();
            lblSubtotal = new Label();
            txtSubtotal = new TextBox();
            lblIVA = new Label();
            txtIVA = new TextBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            btnVenta = new Button();
            groupBox1 = new GroupBox();
            rbCliente = new RadioButton();
            label2 = new Label();
            cmbNombreComicAdd = new ComboBox();
            btnCargarComicsAdd = new Button();
            txtEmpleadoNif = new TextBox();
            label19 = new Label();
            cmbMetodoPagoAdd = new ComboBox();
            texboxCantidad = new TextBox();
            label17 = new Label();
            cmbEditoriales = new ComboBox();
            label3 = new Label();
            txtPrecioCompra = new TextBox();
            label16 = new Label();
            label15 = new Label();
            btnCreateComic = new Button();
            label13 = new Label();
            groupBox2 = new GroupBox();
            label18 = new Label();
            cmbMetodoPago = new ComboBox();
            label20 = new Label();
            label21 = new Label();
            groupBox3 = new GroupBox();
            txtEmpleado = new TextBox();
            gbTipoOperacion.SuspendLayout();
            gbCliente.SuspendLayout();
            gbComics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOperacion).BeginInit();
            gbTotales.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // gbTipoOperacion
            // 
            gbTipoOperacion.Controls.Add(rbCompra);
            gbTipoOperacion.Controls.Add(rbVenta);
            gbTipoOperacion.Location = new Point(30, 20);
            gbTipoOperacion.Name = "gbTipoOperacion";
            gbTipoOperacion.Size = new Size(200, 70);
            gbTipoOperacion.TabIndex = 0;
            gbTipoOperacion.TabStop = false;
            gbTipoOperacion.Text = "Tipo de Operación";
            // 
            // rbCompra
            // 
            rbCompra.AutoSize = true;
            rbCompra.Location = new Point(10, 30);
            rbCompra.Name = "rbCompra";
            rbCompra.Size = new Size(68, 19);
            rbCompra.TabIndex = 0;
            rbCompra.Text = "Compra";
            rbCompra.CheckedChanged += rbCompra_CheckedChanged;
            // 
            // rbVenta
            // 
            rbVenta.AutoSize = true;
            rbVenta.Location = new Point(100, 30);
            rbVenta.Name = "rbVenta";
            rbVenta.Size = new Size(54, 19);
            rbVenta.TabIndex = 1;
            rbVenta.Text = "Venta";
            rbVenta.CheckedChanged += rbVenta_CheckedChanged;
            // 
            // gbCliente
            // 
            gbCliente.Controls.Add(btnAddClientes);
            gbCliente.Controls.Add(lblCliente);
            gbCliente.Controls.Add(cmbClientes);
            gbCliente.Location = new Point(1, 120);
            gbCliente.Name = "gbCliente";
            gbCliente.Size = new Size(229, 90);
            gbCliente.TabIndex = 1;
            gbCliente.TabStop = false;
            gbCliente.Text = "Cliente";
            // 
            // btnAddClientes
            // 
            btnAddClientes.Location = new Point(65, 61);
            btnAddClientes.Name = "btnAddClientes";
            btnAddClientes.Size = new Size(106, 23);
            btnAddClientes.TabIndex = 8;
            btnAddClientes.Text = "Añadir Cliente";
            btnAddClientes.Click += btnAddClientes_Click;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(6, 29);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // cmbClientes
            // 
            cmbClientes.Location = new Point(54, 25);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(131, 23);
            cmbClientes.TabIndex = 1;
            // 
            // gbComics
            // 
            gbComics.Controls.Add(btnLoadComics);
            gbComics.Controls.Add(label1);
            gbComics.Controls.Add(cmbComics);
            gbComics.Controls.Add(lblComic);
            gbComics.Controls.Add(cmbEditorial);
            gbComics.Controls.Add(btnAddComic);
            gbComics.Location = new Point(12, 268);
            gbComics.Name = "gbComics";
            gbComics.Size = new Size(930, 80);
            gbComics.TabIndex = 2;
            gbComics.TabStop = false;
            gbComics.Text = "Detalles del Cómic";
            // 
            // btnLoadComics
            // 
            btnLoadComics.Location = new Point(344, 46);
            btnLoadComics.Name = "btnLoadComics";
            btnLoadComics.Size = new Size(160, 23);
            btnLoadComics.TabIndex = 7;
            btnLoadComics.Text = "Cargar Comics";
            btnLoadComics.Click += btnLoadComics_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(571, 51);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 6;
            label1.Text = "Comics:";
            // 
            // cmbComics
            // 
            cmbComics.Location = new Point(627, 48);
            cmbComics.Name = "cmbComics";
            cmbComics.Size = new Size(200, 23);
            cmbComics.TabIndex = 5;
            // 
            // lblComic
            // 
            lblComic.AutoSize = true;
            lblComic.Location = new Point(132, 50);
            lblComic.Name = "lblComic";
            lblComic.Size = new Size(53, 15);
            lblComic.TabIndex = 0;
            lblComic.Text = "Editorial:";
            // 
            // cmbEditorial
            // 
            cmbEditorial.Location = new Point(191, 47);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(142, 23);
            cmbEditorial.TabIndex = 1;
            // 
            // btnAddComic
            // 
            btnAddComic.Location = new Point(849, 47);
            btnAddComic.Name = "btnAddComic";
            btnAddComic.Size = new Size(75, 23);
            btnAddComic.TabIndex = 4;
            btnAddComic.Text = "Añadir Cómic";
            btnAddComic.Click += btnAddComic_Click;
            // 
            // dgvOperacion
            // 
            dgvOperacion.AllowUserToAddRows = false;
            dgvOperacion.Columns.AddRange(new DataGridViewColumn[] { Comic, ComicId, Cantidad, Precio, Descuento, Subtotal, Stock });
            dgvOperacion.Location = new Point(12, 354);
            dgvOperacion.Name = "dgvOperacion";
            dgvOperacion.Size = new Size(644, 250);
            dgvOperacion.TabIndex = 3;
            // 
            // Comic
            // 
            Comic.HeaderText = "Cómic";
            Comic.Name = "Comic";
            Comic.ReadOnly = true;
            // 
            // ComicId
            // 
            ComicId.HeaderText = "ComicId";
            ComicId.Name = "ComicId";
            ComicId.Visible = false;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
            // 
            // Descuento
            // 
            Descuento.HeaderText = "Descuento (%)";
            Descuento.Name = "Descuento";
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.Name = "Subtotal";
            Subtotal.ReadOnly = true;
            // 
            // Stock
            // 
            Stock.HeaderText = "Stock";
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            // 
            // btnRemoveComic
            // 
            btnRemoveComic.Location = new Point(12, 621);
            btnRemoveComic.Name = "btnRemoveComic";
            btnRemoveComic.Size = new Size(75, 23);
            btnRemoveComic.TabIndex = 4;
            btnRemoveComic.Text = "Eliminar Cómic";
            btnRemoveComic.Click += btnRemoveComic_Click;
            // 
            // gbTotales
            // 
            gbTotales.Controls.Add(lblSubtotal);
            gbTotales.Controls.Add(txtSubtotal);
            gbTotales.Controls.Add(lblIVA);
            gbTotales.Controls.Add(txtIVA);
            gbTotales.Controls.Add(lblTotal);
            gbTotales.Controls.Add(txtTotal);
            gbTotales.Location = new Point(662, 510);
            gbTotales.Name = "gbTotales";
            gbTotales.Size = new Size(280, 120);
            gbTotales.TabIndex = 5;
            gbTotales.TabStop = false;
            gbTotales.Text = "Totales";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(10, 30);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(54, 15);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Enabled = false;
            txtSubtotal.Location = new Point(100, 25);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(150, 23);
            txtSubtotal.TabIndex = 1;
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Location = new Point(10, 60);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(60, 15);
            lblIVA.TabIndex = 2;
            lblIVA.Text = "IVA (21%):";
            // 
            // txtIVA
            // 
            txtIVA.Enabled = false;
            txtIVA.Location = new Point(100, 55);
            txtIVA.Name = "txtIVA";
            txtIVA.ReadOnly = true;
            txtIVA.Size = new Size(150, 23);
            txtIVA.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(10, 90);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(35, 15);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Location = new Point(100, 85);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(150, 23);
            txtTotal.TabIndex = 5;
            // 
            // btnVenta
            // 
            btnVenta.Location = new Point(493, 621);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new Size(163, 23);
            btnVenta.TabIndex = 6;
            btnVenta.Text = "Completar Venta";
            btnVenta.Click += btnVenta_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbCliente);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbNombreComicAdd);
            groupBox1.Controls.Add(btnCargarComicsAdd);
            groupBox1.Controls.Add(txtEmpleadoNif);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(cmbMetodoPagoAdd);
            groupBox1.Controls.Add(texboxCantidad);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(cmbEditoriales);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPrecioCompra);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(btnCreateComic);
            groupBox1.Controls.Add(label13);
            groupBox1.Location = new Point(258, 44);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(678, 172);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear Comic";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // rbCliente
            // 
            rbCliente.AutoSize = true;
            rbCliente.Enabled = false;
            rbCliente.Location = new Point(385, 122);
            rbCliente.Name = "rbCliente";
            rbCliente.Size = new Size(34, 19);
            rbCliente.TabIndex = 2;
            rbCliente.Text = "Si";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(286, 122);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 25;
            label2.Text = "Compra Cliente:";
            // 
            // cmbNombreComicAdd
            // 
            cmbNombreComicAdd.Enabled = false;
            cmbNombreComicAdd.Location = new Point(70, 59);
            cmbNombreComicAdd.Name = "cmbNombreComicAdd";
            cmbNombreComicAdd.Size = new Size(200, 23);
            cmbNombreComicAdd.TabIndex = 24;
            // 
            // btnCargarComicsAdd
            // 
            btnCargarComicsAdd.Enabled = false;
            btnCargarComicsAdd.Location = new Point(70, 137);
            btnCargarComicsAdd.Name = "btnCargarComicsAdd";
            btnCargarComicsAdd.Size = new Size(200, 23);
            btnCargarComicsAdd.TabIndex = 23;
            btnCargarComicsAdd.Text = "Listar Comics Editorial";
            btnCargarComicsAdd.Click += btnCargarComicsAdd_Click;
            // 
            // txtEmpleadoNif
            // 
            txtEmpleadoNif.Enabled = false;
            txtEmpleadoNif.Location = new Point(385, 28);
            txtEmpleadoNif.Name = "txtEmpleadoNif";
            txtEmpleadoNif.ReadOnly = true;
            txtEmpleadoNif.Size = new Size(200, 23);
            txtEmpleadoNif.TabIndex = 7;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(297, 62);
            label19.Name = "label19";
            label19.Size = new Size(82, 15);
            label19.TabIndex = 2;
            label19.Text = "Metodo Pago:";
            // 
            // cmbMetodoPagoAdd
            // 
            cmbMetodoPagoAdd.Enabled = false;
            cmbMetodoPagoAdd.Location = new Point(385, 59);
            cmbMetodoPagoAdd.Name = "cmbMetodoPagoAdd";
            cmbMetodoPagoAdd.Size = new Size(200, 23);
            cmbMetodoPagoAdd.TabIndex = 2;
            // 
            // texboxCantidad
            // 
            texboxCantidad.Enabled = false;
            texboxCantidad.Location = new Point(70, 28);
            texboxCantidad.Name = "texboxCantidad";
            texboxCantidad.Size = new Size(200, 23);
            texboxCantidad.TabIndex = 22;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(11, 31);
            label17.Name = "label17";
            label17.Size = new Size(58, 15);
            label17.TabIndex = 21;
            label17.Text = "Cantidad:";
            // 
            // cmbEditoriales
            // 
            cmbEditoriales.Enabled = false;
            cmbEditoriales.Location = new Point(70, 90);
            cmbEditoriales.Name = "cmbEditoriales";
            cmbEditoriales.Size = new Size(200, 23);
            cmbEditoriales.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 31);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 18;
            label3.Text = "Tienda:";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.Enabled = false;
            txtPrecioCompra.Location = new Point(385, 90);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(200, 23);
            txtPrecioCompra.TabIndex = 15;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(290, 90);
            label16.Name = "label16";
            label16.Size = new Size(89, 15);
            label16.TabIndex = 11;
            label16.Text = "Precio Compra:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(11, 93);
            label15.Name = "label15";
            label15.Size = new Size(53, 15);
            label15.TabIndex = 10;
            label15.Text = "Editorial:";
            // 
            // btnCreateComic
            // 
            btnCreateComic.Enabled = false;
            btnCreateComic.Location = new Point(566, 137);
            btnCreateComic.Name = "btnCreateComic";
            btnCreateComic.Size = new Size(106, 23);
            btnCreateComic.TabIndex = 8;
            btnCreateComic.Text = "Añadir Comic";
            btnCreateComic.Click += btnCreateComic_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(11, 62);
            label13.Name = "label13";
            label13.Size = new Size(54, 15);
            label13.TabIndex = 0;
            label13.Text = "Nombre:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(cmbMetodoPago);
            groupBox2.Location = new Point(662, 450);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(280, 54);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Metodo de pago";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 29);
            label18.Name = "label18";
            label18.Size = new Size(82, 15);
            label18.TabIndex = 0;
            label18.Text = "Metodo Pago:";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.Location = new Point(100, 25);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(158, 23);
            cmbMetodoPago.TabIndex = 1;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F);
            label20.Location = new Point(409, 244);
            label20.Name = "label20";
            label20.Size = new Size(97, 21);
            label20.TabIndex = 10;
            label20.Text = "Venta Comic";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F);
            label21.Location = new Point(501, 20);
            label21.Name = "label21";
            label21.Size = new Size(114, 21);
            label21.TabIndex = 11;
            label21.Text = "Compra Comic";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtEmpleado);
            groupBox3.Location = new Point(18, 216);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 55);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Empleado";
            // 
            // txtEmpleado
            // 
            txtEmpleado.Enabled = false;
            txtEmpleado.Location = new Point(24, 22);
            txtEmpleado.Name = "txtEmpleado";
            txtEmpleado.ReadOnly = true;
            txtEmpleado.Size = new Size(150, 23);
            txtEmpleado.TabIndex = 6;
            // 
            // FormOperacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 650);
            Controls.Add(groupBox3);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gbTipoOperacion);
            Controls.Add(gbCliente);
            Controls.Add(gbComics);
            Controls.Add(dgvOperacion);
            Controls.Add(btnRemoveComic);
            Controls.Add(gbTotales);
            Controls.Add(btnVenta);
            Name = "FormOperacion";
            Text = "Operación de Cómics";
            gbTipoOperacion.ResumeLayout(false);
            gbTipoOperacion.PerformLayout();
            gbCliente.ResumeLayout(false);
            gbCliente.PerformLayout();
            gbComics.ResumeLayout(false);
            gbComics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOperacion).EndInit();
            gbTotales.ResumeLayout(false);
            gbTotales.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }





        #endregion

        private Label label1;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxNIF;
        private TextBox textBoxDireccion;
        private TextBox textBoxPass;
        private TextBox textBoxEmail;
        private DateTimePicker dtAlta;
        private Button btnImg;
        private Button btnAddEmp;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private ErrorProvider errorProvider3;
        private ErrorProvider errorProvider4;
        private ErrorProvider errorProvider5;
        private ErrorProvider errorProvider6;
        private ErrorProvider errorProvider7;
        private Label label9;
        private ComboBox cboxTienda;
        private Label lbTitle;
        private Label label10;
        private Label lbActivo;
        private Label lbID;
        private Label label12;
        private DateTimePicker dtBaja;
        private Label label11;
        private GroupBox gbTipoOperacion;
        private RadioButton rbCompra;
        private RadioButton rbVenta;
        private GroupBox gbCliente;
        private Label lblCliente;
        private ComboBox cmbClientes;
        private GroupBox gbComics;
        private Label lblComic;
        private ComboBox cmbEditorial;
        private Button btnAddComic;
        private DataGridView dgvOperacion;
        private Button btnRemoveComic;
        private GroupBox gbTotales;
        private Label lblSubtotal;
        private TextBox txtSubtotal;
        private Label lblIVA;
        private TextBox txtIVA;
        private Label lblTotal;
        private TextBox txtTotal;
        private Button btnVenta;
        private ComboBox cmbComics;
        private Button btnLoadComics;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Button btnAddClientes;
        private GroupBox groupBox1;
        private TextBox txtPrecioCompra;
        private TextBox txtNombreComic;
        private Label label16;
        private Label label15;
        private Button btnCreateComic;
        private Label label13;
        private ComboBox cmbEditoriales;
        private TextBox texboxCantidad;
        private Label label17;
        private GroupBox groupBox2;
        private Label label18;
        private ComboBox cmbMetodoPago;
        private Label label19;
        private ComboBox cmbMetodoPagoAdd;
        private Label label20;
        private Label label21;
        private GroupBox groupBox3;
        private TextBox txtEmpleado;
        private TextBox txtEmpleadoNif;
        private Button btnCargarComicsAdd;
        private ComboBox cmbNombreComicAdd;
        private DataGridViewTextBoxColumn Comic;
        private DataGridViewTextBoxColumn ComicId;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Descuento;
        private DataGridViewTextBoxColumn Subtotal;
        private DataGridViewTextBoxColumn Stock;
        private RadioButton rbCliente;
        private Label label2;
    }
}