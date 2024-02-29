namespace FinalProgramacion2023.Windows
{
    partial class frmCuadrilatero
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            cboRelleno = new ComboBox();
            label4 = new Label();
            btnCancelar = new Button();
            btnOK = new Button();
            txtLadoB = new TextBox();
            label2 = new Label();
            txtLadoA = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(47, 192);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(325, 171);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = " Bordes ";
            // 
            // cboRelleno
            // 
            cboRelleno.FormattingEnabled = true;
            cboRelleno.Location = new Point(115, 153);
            cboRelleno.Margin = new Padding(3, 4, 3, 4);
            cboRelleno.Name = "cboRelleno";
            cboRelleno.Size = new Size(138, 28);
            cboRelleno.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 157);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 14;
            label4.Text = "Relleno:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(286, 403);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 81);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(43, 403);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(86, 81);
            btnOK.TabIndex = 13;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtLadoB
            // 
            txtLadoB.Location = new Point(115, 68);
            txtLadoB.Margin = new Padding(3, 4, 3, 4);
            txtLadoB.Name = "txtLadoB";
            txtLadoB.Size = new Size(114, 27);
            txtLadoB.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 72);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 7;
            label2.Text = "Lado B;";
            // 
            // txtLadoA
            // 
            txtLadoA.Location = new Point(115, 29);
            txtLadoA.Margin = new Padding(3, 4, 3, 4);
            txtLadoA.Name = "txtLadoA";
            txtLadoA.Size = new Size(114, 27);
            txtLadoA.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 33);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 8;
            label1.Text = "Lado A:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmCuadrilatero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 535);
            Controls.Add(groupBox1);
            Controls.Add(cboRelleno);
            Controls.Add(label4);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtLadoB);
            Controls.Add(label2);
            Controls.Add(txtLadoA);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmCuadrilatero";
            Text = "frmCuadrilatero";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cboRelleno;
        private Label label4;
        private Button btnCancelar;
        private Button btnOK;
        private TextBox txtLadoB;
        private Label label2;
        private TextBox txtLadoA;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}