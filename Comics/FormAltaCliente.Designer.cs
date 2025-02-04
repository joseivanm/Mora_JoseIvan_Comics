namespace Comics
{
    partial class FormAltaCliente
    {
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDireccion;
        private Label lblEmail;
        private Label lblNif;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDireccion;
        private TextBox txtEmail;

        private Button btnGuardar;
        private Button btnCancelar;
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
            lblNombre = new Label();
            lblApellido = new Label();
            lblDireccion = new Label();
            lblEmail = new Label();
            lblNif = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDireccion = new TextBox();
            txtEmail = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtNIF = new TextBox();
            txtTel = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(20, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.Location = new Point(20, 100);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(100, 23);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido:";
            // 
            // lblDireccion
            // 
            lblDireccion.Location = new Point(20, 140);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(100, 23);
            lblDireccion.TabIndex = 6;
            lblDireccion.Text = "Dirección:";
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(20, 180);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // lblNif
            // 
            lblNif.Location = new Point(20, 220);
            lblNif.Name = "lblNif";
            lblNif.Size = new Size(59, 23);
            lblNif.TabIndex = 10;
            lblNif.Text = "NIF:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 60);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(180, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(120, 100);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(180, 23);
            txtApellido.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(120, 140);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(180, 23);
            txtDireccion.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 180);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 23);
            txtEmail.TabIndex = 9;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(76, 305);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(176, 305);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNIF
            // 
            txtNIF.Location = new Point(120, 217);
            txtNIF.Name = "txtNIF";
            txtNIF.Size = new Size(180, 23);
            txtNIF.TabIndex = 14;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(120, 257);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(180, 23);
            txtTel.TabIndex = 16;
            // 
            // label1
            // 
            label1.Location = new Point(20, 260);
            label1.Name = "label1";
            label1.Size = new Size(59, 23);
            label1.TabIndex = 15;
            label1.Text = "Telefono:";
            // 
            // FormAltaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 358);
            Controls.Add(txtTel);
            Controls.Add(label1);
            Controls.Add(txtNIF);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblNif);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "FormAltaCliente";
            Text = "Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNIF;
        private TextBox txtTel;
        private Label label1;
    }
}