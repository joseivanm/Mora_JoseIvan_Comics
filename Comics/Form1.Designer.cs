namespace Comics
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btListarOperaciones = new Button();
            btVerDetalles = new Button();
            btCargarDetallesOperacion = new Button();
            txtLocalId = new TextBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFinal = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            label7 = new Label();
            label5 = new Label();
            txtOperacionId = new TextBox();
            label6 = new Label();
            textBoxEditorialId = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            menuStrip1 = new MenuStrip();
            empleadosToolStripMenuItem = new ToolStripMenuItem();
            altaEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            modificarEmpleadoToolStripMenuItem = new ToolStripMenuItem();
            bajaDeEmpleadoToolStripMenuItem = new ToolStripMenuItem();
            comicsToolStripMenuItem = new ToolStripMenuItem();
            altaComicToolStripMenuItem = new ToolStripMenuItem();
            modificarComicToolStripMenuItem = new ToolStripMenuItem();
            bajaDeComicToolStripMenuItem = new ToolStripMenuItem();
            operacionToolStripMenuItem = new ToolStripMenuItem();
            nuevaToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            estadisticasToolStripMenuItem = new ToolStripMenuItem();
            totalOperacionesPorEmpleoToolStripMenuItem = new ToolStripMenuItem();
            comicsPorEditorialToolStripMenuItem = new ToolStripMenuItem();
            informesToolStripMenuItem = new ToolStripMenuItem();
            operacionToolStripMenuItem1 = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            picUser = new PictureBox();
            toolStrip1 = new ToolStrip();
            nOrden = new ToolStripLabel();
            bsComic = new ToolStripLabel();
            impFactura = new ToolStripLabel();
            lbUsuario = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btListarOperaciones
            // 
            btListarOperaciones.AccessibleName = "btListarOperaciones";
            btListarOperaciones.Location = new Point(730, 239);
            btListarOperaciones.Name = "btListarOperaciones";
            btListarOperaciones.Size = new Size(120, 23);
            btListarOperaciones.TabIndex = 17;
            btListarOperaciones.Text = "Listar Operaciones";
            btListarOperaciones.UseVisualStyleBackColor = true;
            btListarOperaciones.Visible = false;
            btListarOperaciones.Click += btListarOperaciones_Click;
            // 
            // btVerDetalles
            // 
            btVerDetalles.AccessibleName = "btVerDetalles";
            btVerDetalles.Location = new Point(1038, 252);
            btVerDetalles.Name = "btVerDetalles";
            btVerDetalles.Size = new Size(120, 23);
            btVerDetalles.TabIndex = 19;
            btVerDetalles.Text = "Ver Detalles";
            btVerDetalles.UseVisualStyleBackColor = true;
            btVerDetalles.Visible = false;
            btVerDetalles.Click += btVerDetalles_Click;
            // 
            // btCargarDetallesOperacion
            // 
            btCargarDetallesOperacion.AccessibleName = "btCargarDetallesOperacion";
            btCargarDetallesOperacion.Location = new Point(1052, 198);
            btCargarDetallesOperacion.Name = "btCargarDetallesOperacion";
            btCargarDetallesOperacion.Size = new Size(120, 23);
            btCargarDetallesOperacion.TabIndex = 20;
            btCargarDetallesOperacion.Text = "Detalles Operacion";
            btCargarDetallesOperacion.UseVisualStyleBackColor = true;
            btCargarDetallesOperacion.Visible = false;
            btCargarDetallesOperacion.Click += btCargarDetallesOperacion_Click;
            // 
            // txtLocalId
            // 
            txtLocalId.AccessibleName = "txtLocalId";
            txtLocalId.Location = new Point(695, 203);
            txtLocalId.Name = "txtLocalId";
            txtLocalId.Size = new Size(139, 23);
            txtLocalId.TabIndex = 21;
            txtLocalId.Visible = false;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(695, 97);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(139, 23);
            dtpFechaInicio.TabIndex = 22;
            dtpFechaInicio.Visible = false;
            // 
            // dtpFechaFinal
            // 
            dtpFechaFinal.Location = new Point(695, 141);
            dtpFechaFinal.Name = "dtpFechaFinal";
            dtpFechaFinal.Size = new Size(139, 23);
            dtpFechaFinal.TabIndex = 23;
            dtpFechaFinal.Visible = false;
            // 
            // label3
            // 
            label3.AccessibleName = "lb7";
            label3.AutoSize = true;
            label3.Location = new Point(695, 24);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 25;
            label3.Text = "Fecha desde";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AccessibleName = "lb7";
            label4.AutoSize = true;
            label4.Location = new Point(712, 123);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 26;
            label4.Text = "Fecha Hasta";
            label4.Visible = false;
            // 
            // label7
            // 
            label7.AccessibleName = "lb7";
            label7.AutoSize = true;
            label7.Location = new Point(734, 176);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 24;
            label7.Text = "ID Local";
            label7.Visible = false;
            // 
            // label5
            // 
            label5.AccessibleName = "lb7";
            label5.AutoSize = true;
            label5.Location = new Point(843, 189);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 27;
            label5.Text = "ID Operación";
            label5.Visible = false;
            // 
            // txtOperacionId
            // 
            txtOperacionId.AccessibleName = "txtLocalId";
            txtOperacionId.Location = new Point(931, 181);
            txtOperacionId.Name = "txtOperacionId";
            txtOperacionId.Size = new Size(85, 23);
            txtOperacionId.TabIndex = 28;
            txtOperacionId.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(855, 235);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 29;
            label6.Text = "ID Editorial";
            label6.Visible = false;
            // 
            // textBoxEditorialId
            // 
            textBoxEditorialId.AccessibleName = "textBoxEditorialId";
            textBoxEditorialId.Location = new Point(931, 252);
            textBoxEditorialId.Name = "textBoxEditorialId";
            textBoxEditorialId.Size = new Size(88, 23);
            textBoxEditorialId.TabIndex = 30;
            textBoxEditorialId.Visible = false;
            // 
            // label9
            // 
            label9.AccessibleName = "lb7";
            label9.AutoSize = true;
            label9.Location = new Point(287, 34);
            label9.Name = "label9";
            label9.Size = new Size(105, 15);
            label9.TabIndex = 32;
            label9.Text = "Listas Operaciones";
            // 
            // label10
            // 
            label10.AccessibleName = "lb7";
            label10.AutoSize = true;
            label10.Location = new Point(931, 147);
            label10.Name = "label10";
            label10.Size = new Size(95, 15);
            label10.TabIndex = 33;
            label10.Text = "Datos Operacion";
            label10.Visible = false;
            // 
            // label11
            // 
            label11.AccessibleName = "lb7";
            label11.AutoSize = true;
            label11.Location = new Point(931, 215);
            label11.Name = "label11";
            label11.Size = new Size(99, 15);
            label11.TabIndex = 34;
            label11.Text = "Obtener Stock <2";
            label11.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { empleadosToolStripMenuItem, comicsToolStripMenuItem, operacionToolStripMenuItem, estadisticasToolStripMenuItem, informesToolStripMenuItem, acercaDeToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 35;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // empleadosToolStripMenuItem
            // 
            empleadosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altaEmpleadosToolStripMenuItem, modificarEmpleadoToolStripMenuItem, bajaDeEmpleadoToolStripMenuItem });
            empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            empleadosToolStripMenuItem.Size = new Size(77, 20);
            empleadosToolStripMenuItem.Text = "Empleados";
            // 
            // altaEmpleadosToolStripMenuItem
            // 
            altaEmpleadosToolStripMenuItem.Name = "altaEmpleadosToolStripMenuItem";
            altaEmpleadosToolStripMenuItem.Size = new Size(181, 22);
            altaEmpleadosToolStripMenuItem.Text = "Alta empleado";
            altaEmpleadosToolStripMenuItem.Click += altaEmpleadosToolStripMenuItem_Click;
            // 
            // modificarEmpleadoToolStripMenuItem
            // 
            modificarEmpleadoToolStripMenuItem.Name = "modificarEmpleadoToolStripMenuItem";
            modificarEmpleadoToolStripMenuItem.Size = new Size(181, 22);
            modificarEmpleadoToolStripMenuItem.Text = "Modificar Empleado";
            modificarEmpleadoToolStripMenuItem.Click += modificarEmpleadoToolStripMenuItem_Click;
            // 
            // bajaDeEmpleadoToolStripMenuItem
            // 
            bajaDeEmpleadoToolStripMenuItem.Name = "bajaDeEmpleadoToolStripMenuItem";
            bajaDeEmpleadoToolStripMenuItem.Size = new Size(181, 22);
            bajaDeEmpleadoToolStripMenuItem.Text = "Baja de Empleado";
            bajaDeEmpleadoToolStripMenuItem.Click += modificarEmpleadoToolStripMenuItem_Click;
            // 
            // comicsToolStripMenuItem
            // 
            comicsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { altaComicToolStripMenuItem, modificarComicToolStripMenuItem, bajaDeComicToolStripMenuItem });
            comicsToolStripMenuItem.Name = "comicsToolStripMenuItem";
            comicsToolStripMenuItem.Size = new Size(59, 20);
            comicsToolStripMenuItem.Text = "Comics";
            // 
            // altaComicToolStripMenuItem
            // 
            altaComicToolStripMenuItem.Name = "altaComicToolStripMenuItem";
            altaComicToolStripMenuItem.Size = new Size(163, 22);
            altaComicToolStripMenuItem.Text = "Alta Comic";
            // 
            // modificarComicToolStripMenuItem
            // 
            modificarComicToolStripMenuItem.Name = "modificarComicToolStripMenuItem";
            modificarComicToolStripMenuItem.Size = new Size(163, 22);
            modificarComicToolStripMenuItem.Text = "Modificar Comic";
            // 
            // bajaDeComicToolStripMenuItem
            // 
            bajaDeComicToolStripMenuItem.Name = "bajaDeComicToolStripMenuItem";
            bajaDeComicToolStripMenuItem.Size = new Size(163, 22);
            bajaDeComicToolStripMenuItem.Text = "Baja de comic";
            // 
            // operacionToolStripMenuItem
            // 
            operacionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaToolStripMenuItem, modificarToolStripMenuItem });
            operacionToolStripMenuItem.Name = "operacionToolStripMenuItem";
            operacionToolStripMenuItem.Size = new Size(74, 20);
            operacionToolStripMenuItem.Text = "Operacion";
            // 
            // nuevaToolStripMenuItem
            // 
            nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            nuevaToolStripMenuItem.Size = new Size(180, 22);
            nuevaToolStripMenuItem.Text = "Nueva";
            nuevaToolStripMenuItem.Click += nuevaToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(180, 22);
            modificarToolStripMenuItem.Text = "Modificar";
            // 
            // estadisticasToolStripMenuItem
            // 
            estadisticasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { totalOperacionesPorEmpleoToolStripMenuItem, comicsPorEditorialToolStripMenuItem });
            estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            estadisticasToolStripMenuItem.Size = new Size(79, 20);
            estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // totalOperacionesPorEmpleoToolStripMenuItem
            // 
            totalOperacionesPorEmpleoToolStripMenuItem.Name = "totalOperacionesPorEmpleoToolStripMenuItem";
            totalOperacionesPorEmpleoToolStripMenuItem.Size = new Size(245, 22);
            totalOperacionesPorEmpleoToolStripMenuItem.Text = "Total Operaciones por Empleado";
            // 
            // comicsPorEditorialToolStripMenuItem
            // 
            comicsPorEditorialToolStripMenuItem.Name = "comicsPorEditorialToolStripMenuItem";
            comicsPorEditorialToolStripMenuItem.Size = new Size(245, 22);
            comicsPorEditorialToolStripMenuItem.Text = "Comics por editorial";
            // 
            // informesToolStripMenuItem
            // 
            informesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { operacionToolStripMenuItem1 });
            informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            informesToolStripMenuItem.Size = new Size(66, 20);
            informesToolStripMenuItem.Text = "Informes";
            // 
            // operacionToolStripMenuItem1
            // 
            operacionToolStripMenuItem1.Name = "operacionToolStripMenuItem1";
            operacionToolStripMenuItem1.Size = new Size(129, 22);
            operacionToolStripMenuItem1.Text = "Operacion";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(71, 20);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(41, 20);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // picUser
            // 
            picUser.Image = (Image)resources.GetObject("picUser.Image");
            picUser.Location = new Point(1131, 52);
            picUser.Name = "picUser";
            picUser.Size = new Size(133, 93);
            picUser.SizeMode = PictureBoxSizeMode.Zoom;
            picUser.TabIndex = 42;
            picUser.TabStop = false;
            picUser.Click += picUser_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { nOrden, bsComic, impFactura });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1264, 25);
            toolStrip1.TabIndex = 43;
            toolStrip1.Text = "toolStrip1";
            // 
            // nOrden
            // 
            nOrden.AccessibleName = "nOrden";
            nOrden.Name = "nOrden";
            nOrden.Size = new Size(77, 22);
            nOrden.Text = "Nueva Orden";
            // 
            // bsComic
            // 
            bsComic.AccessibleDescription = "bsComic";
            bsComic.Name = "bsComic";
            bsComic.Size = new Size(80, 22);
            bsComic.Text = "Buscar Comic";
            // 
            // impFactura
            // 
            impFactura.AccessibleDescription = "impFactura";
            impFactura.Name = "impFactura";
            impFactura.Size = new Size(95, 22);
            impFactura.Text = "Imprimir Factura";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Location = new Point(1088, 52);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(47, 15);
            lbUsuario.TabIndex = 41;
            lbUsuario.Text = "Usuario";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 861);
            Controls.Add(toolStrip1);
            Controls.Add(picUser);
            Controls.Add(lbUsuario);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(textBoxEditorialId);
            Controls.Add(label6);
            Controls.Add(txtOperacionId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(dtpFechaFinal);
            Controls.Add(dtpFechaInicio);
            Controls.Add(txtLocalId);
            Controls.Add(btCargarDetallesOperacion);
            Controls.Add(btVerDetalles);
            Controls.Add(btListarOperaciones);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load_1;
            Click += Form1_Click;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btListarOperaciones;
        private Button btVerDetalles;
        private Button btCargarDetallesOperacion;
        private TextBox txtLocalId;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFinal;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label5;
        private TextBox txtOperacionId;
        private Label label6;
        private TextBox textBoxEditorialId;
        private Label label9;
        private Label label10;
        private Label label11;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem empleadosToolStripMenuItem;
        private ToolStripMenuItem altaEmpleadosToolStripMenuItem;
        private ToolStripMenuItem modificarEmpleadoToolStripMenuItem;
        private ToolStripMenuItem bajaDeEmpleadoToolStripMenuItem;
        private ToolStripMenuItem comicsToolStripMenuItem;
        private ToolStripMenuItem altaComicToolStripMenuItem;
        private ToolStripMenuItem modificarComicToolStripMenuItem;
        private ToolStripMenuItem bajaDeComicToolStripMenuItem;
        private ToolStripMenuItem operacionToolStripMenuItem;
        private ToolStripMenuItem nuevaToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem estadisticasToolStripMenuItem;
        private ToolStripMenuItem totalOperacionesPorEmpleoToolStripMenuItem;
        private ToolStripMenuItem comicsPorEditorialToolStripMenuItem;
        private ToolStripMenuItem informesToolStripMenuItem;
        private ToolStripMenuItem operacionToolStripMenuItem1;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private PictureBox picUser;
        private ToolStrip toolStrip1;
        private ToolStripLabel nOrden;
        private ToolStripLabel bsComic;
        private ToolStripLabel impFactura;
        private Label lbUsuario;
    }
}
