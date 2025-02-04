namespace Comics
{
    partial class FormEmpleado
    {
        private System.Windows.Forms.Label lblBuscarEmpleado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label lblNIF;
        private System.Windows.Forms.TextBox textBoxNIF;
        private System.Windows.Forms.DataGridView dataGridViewResultados;
        private System.Windows.Forms.Button btnEditar;
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
            lblBuscarEmpleado = new Label();
            lblNombre = new Label();
            textBoxNombre = new TextBox();
            lblApellido = new Label();
            textBoxApellido = new TextBox();
            lblNIF = new Label();
            textBoxNIF = new TextBox();
            dataGridViewResultados = new DataGridView();
            btnEditar = new Button();
            btnBorrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultados).BeginInit();
            SuspendLayout();
            // 
            // lblBuscarEmpleado
            // 
            lblBuscarEmpleado.AutoSize = true;
            lblBuscarEmpleado.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblBuscarEmpleado.Location = new Point(10, 10);
            lblBuscarEmpleado.Name = "lblBuscarEmpleado";
            lblBuscarEmpleado.Size = new Size(145, 19);
            lblBuscarEmpleado.TabIndex = 0;
            lblBuscarEmpleado.Text = "Buscar Empleado";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(10, 50);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(70, 50);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(150, 23);
            textBoxNombre.TabIndex = 2;
            textBoxNombre.TextChanged += FiltrarEmpleados;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(230, 50);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido:";
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(290, 50);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(150, 23);
            textBoxApellido.TabIndex = 4;
            textBoxApellido.TextChanged += FiltrarEmpleados;
            // 
            // lblNIF
            // 
            lblNIF.AutoSize = true;
            lblNIF.Location = new Point(450, 50);
            lblNIF.Name = "lblNIF";
            lblNIF.Size = new Size(28, 15);
            lblNIF.TabIndex = 5;
            lblNIF.Text = "NIF:";
            // 
            // textBoxNIF
            // 
            textBoxNIF.Location = new Point(490, 50);
            textBoxNIF.Name = "textBoxNIF";
            textBoxNIF.Size = new Size(150, 23);
            textBoxNIF.TabIndex = 6;
            textBoxNIF.TextChanged += FiltrarEmpleados;
            // 
            // dataGridViewResultados
            // 
            dataGridViewResultados.AllowUserToAddRows = false;
            dataGridViewResultados.AllowUserToDeleteRows = false;
            dataGridViewResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResultados.Location = new Point(10, 90);
            dataGridViewResultados.Name = "dataGridViewResultados";
            dataGridViewResultados.ReadOnly = true;
            dataGridViewResultados.Size = new Size(780, 400);
            dataGridViewResultados.TabIndex = 7;
            dataGridViewResultados.CellDoubleClick += dataGridViewResultados_CellDoubleClick;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(688, 21);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 23);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(688, 50);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(100, 23);
            btnBorrar.TabIndex = 9;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // 
            // FormEmpleadoMR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 500);
            Controls.Add(btnBorrar);
            Controls.Add(lblBuscarEmpleado);
            Controls.Add(lblNombre);
            Controls.Add(textBoxNombre);
            Controls.Add(lblApellido);
            Controls.Add(textBoxApellido);
            Controls.Add(lblNIF);
            Controls.Add(textBoxNIF);
            Controls.Add(dataGridViewResultados);
            Controls.Add(btnEditar);
            Name = "FormEmpleadoMR";
            Text = "Buscar y Editar Empleado";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBorrar;
    }
}