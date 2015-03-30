namespace Aplicacion.Informes
{
    partial class FrminfAreas
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblGenerar = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTodProp = new System.Windows.Forms.RadioButton();
            this.rbLeasing = new System.Windows.Forms.RadioButton();
            this.rbArrendado = new System.Windows.Forms.RadioButton();
            this.rbPropio = new System.Windows.Forms.RadioButton();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbUnico = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGenerar
            // 
            this.lblGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGenerar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerar.ForeColor = System.Drawing.Color.White;
            this.lblGenerar.Image = global::Aplicacion.Properties.Resources.pdf;
            this.lblGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGenerar.Location = new System.Drawing.Point(180, 0);
            this.lblGenerar.Margin = new System.Windows.Forms.Padding(180, 0, 3, 0);
            this.lblGenerar.Name = "lblGenerar";
            this.lblGenerar.Size = new System.Drawing.Size(70, 64);
            this.lblGenerar.TabIndex = 1;
            this.lblGenerar.Text = "&Generar";
            this.lblGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblGenerar, "Generar Informe");
            this.lblGenerar.Click += new System.EventHandler(this.lblGenerar_Click);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(268, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(70, 64);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Jokerman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(515, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 231;
            this.btnExit.Text = "X";
            this.toolTip1.SetToolTip(this.btnExit, "ESC");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTodProp);
            this.groupBox2.Controls.Add(this.rbLeasing);
            this.groupBox2.Controls.Add(this.rbArrendado);
            this.groupBox2.Controls.Add(this.rbPropio);
            this.groupBox2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox2.Location = new System.Drawing.Point(17, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 69);
            this.groupBox2.TabIndex = 235;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Propiedad";
            // 
            // rbTodProp
            // 
            this.rbTodProp.AutoSize = true;
            this.rbTodProp.Checked = true;
            this.rbTodProp.ForeColor = System.Drawing.Color.Black;
            this.rbTodProp.Location = new System.Drawing.Point(421, 28);
            this.rbTodProp.Name = "rbTodProp";
            this.rbTodProp.Size = new System.Drawing.Size(75, 26);
            this.rbTodProp.TabIndex = 0;
            this.rbTodProp.TabStop = true;
            this.rbTodProp.Text = "Todos";
            this.rbTodProp.UseVisualStyleBackColor = true;
            this.rbTodProp.CheckedChanged += new System.EventHandler(this.rbTodPro_CheckedChanged);
            // 
            // rbLeasing
            // 
            this.rbLeasing.AutoSize = true;
            this.rbLeasing.ForeColor = System.Drawing.Color.Black;
            this.rbLeasing.Location = new System.Drawing.Point(296, 28);
            this.rbLeasing.Name = "rbLeasing";
            this.rbLeasing.Size = new System.Drawing.Size(85, 26);
            this.rbLeasing.TabIndex = 0;
            this.rbLeasing.Text = "Leasing";
            this.rbLeasing.UseVisualStyleBackColor = true;
            this.rbLeasing.CheckedChanged += new System.EventHandler(this.rbLeasing_CheckedChanged);
            // 
            // rbArrendado
            // 
            this.rbArrendado.AutoSize = true;
            this.rbArrendado.ForeColor = System.Drawing.Color.Black;
            this.rbArrendado.Location = new System.Drawing.Point(146, 28);
            this.rbArrendado.Name = "rbArrendado";
            this.rbArrendado.Size = new System.Drawing.Size(110, 26);
            this.rbArrendado.TabIndex = 0;
            this.rbArrendado.Text = "Arrendado";
            this.rbArrendado.UseVisualStyleBackColor = true;
            this.rbArrendado.CheckedChanged += new System.EventHandler(this.rbArrendado_CheckedChanged);
            // 
            // rbPropio
            // 
            this.rbPropio.AutoSize = true;
            this.rbPropio.ForeColor = System.Drawing.Color.Black;
            this.rbPropio.Location = new System.Drawing.Point(27, 28);
            this.rbPropio.Name = "rbPropio";
            this.rbPropio.Size = new System.Drawing.Size(79, 26);
            this.rbPropio.TabIndex = 0;
            this.rbPropio.Text = "Propio";
            this.rbPropio.UseVisualStyleBackColor = true;
            this.rbPropio.CheckedChanged += new System.EventHandler(this.rbPropio_CheckedChanged);
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblGenerar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 298);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(540, 66);
            this.FlowLayoutPanel1.TabIndex = 234;
            // 
            // rbUnico
            // 
            this.rbUnico.AutoSize = true;
            this.rbUnico.ForeColor = System.Drawing.Color.Black;
            this.rbUnico.Location = new System.Drawing.Point(34, 63);
            this.rbUnico.Name = "rbUnico";
            this.rbUnico.Size = new System.Drawing.Size(137, 26);
            this.rbUnico.TabIndex = 1;
            this.rbUnico.Text = "Una Especifica";
            this.rbUnico.UseVisualStyleBackColor = true;
            this.rbUnico.CheckedChanged += new System.EventHandler(this.rbUnico_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.ForeColor = System.Drawing.Color.Black;
            this.rbTodos.Location = new System.Drawing.Point(34, 29);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(74, 26);
            this.rbTodos.TabIndex = 0;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todas";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboArea);
            this.groupBox1.Controls.Add(this.rbUnico);
            this.groupBox1.Controls.Add(this.rbTodos);
            this.groupBox1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.groupBox1.Location = new System.Drawing.Point(17, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 108);
            this.groupBox1.TabIndex = 233;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ubicación";
            // 
            // cboArea
            // 
            this.cboArea.Enabled = false;
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(174, 62);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(297, 30);
            this.cboArea.TabIndex = 2;
            this.cboArea.SelectedIndexChanged += new System.EventHandler(this.cboArea_SelectedIndexChanged);
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 364);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(540, 2);
            this.lblMargenInf.TabIndex = 232;
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(540, 45);
            this.lblTituloPrinc.TabIndex = 230;
            this.lblTituloPrinc.Text = " SAE  >> Informe por Ubicación";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(542, 2);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 364);
            this.lblMargenIzq.TabIndex = 229;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 2);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 364);
            this.lblMargenDer.TabIndex = 228;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(0, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(544, 2);
            this.lblMargenTop.TabIndex = 227;
            // 
            // FrminfAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(544, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrminfAreas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrminfAreas";
            this.Load += new System.EventHandler(this.FrminfAreas_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblGenerar;
        private System.Windows.Forms.Label lblSalir;
        internal System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbUnico;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label lblMargenInf;
        internal System.Windows.Forms.Label lblTituloPrinc;
        internal System.Windows.Forms.Label lblMargenIzq;
        internal System.Windows.Forms.Label lblMargenDer;
        internal System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.RadioButton rbTodProp;
        private System.Windows.Forms.RadioButton rbLeasing;
        private System.Windows.Forms.RadioButton rbArrendado;
        private System.Windows.Forms.RadioButton rbPropio;
    }
}