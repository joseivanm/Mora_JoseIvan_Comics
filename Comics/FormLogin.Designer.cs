namespace Comics
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            foto = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(104, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 80);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(100, 110);
            label1.Name = "label1";
            label1.Size = new Size(135, 43);
            label1.TabIndex = 1;
            label1.Text = "LOG IN";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(30, 160);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Location = new Point(30, 188);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 1);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Location = new Point(30, 300);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 1);
            panel2.TabIndex = 6;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(30, 260);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkBlue;
            button1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(30, 330);
            button1.Name = "button1";
            button1.Size = new Size(236, 37);
            button1.TabIndex = 7;
            button1.Text = "Log In";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkBlue;
            label2.Location = new Point(175, 310);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 8;
            label2.Text = "Clear Fields";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(120, 380);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 9;
            label3.Text = "Exit";
            label3.Click += label3_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(60, 260);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(166, 23);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(60, 165);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(166, 23);
            txtUserName.TabIndex = 11;
            // 
            // foto
            // 
            foto.Location = new Point(185, 380);
            foto.Name = "foto";
            foto.Size = new Size(100, 25);
            foto.TabIndex = 12;
            foto.Text = "Añadir Foto";
            foto.UseVisualStyleBackColor = true;
            foto.Visible = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(292, 447);
            Controls.Add(foto);
            Controls.Add(txtUserName);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(pictureBox3);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLogin";
            Text = "Inicio de Sesión";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox3;
        private Button button1;
        private Label label2;
        private Label label3;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Button foto;
    }
}
