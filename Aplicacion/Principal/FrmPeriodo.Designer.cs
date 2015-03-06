namespace Aplicacion.Principal
{
    partial class FrmPeriodo
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
         this.lblTituloPrinc = new System.Windows.Forms.Label();
         this.lblMargenTop = new System.Windows.Forms.Label();
         this.lblMargenInf = new System.Windows.Forms.Label();
         this.btnExit = new System.Windows.Forms.Button();
         this.lblImagen = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.txtanio = new System.Windows.Forms.TextBox();
         this.cboPeriodo = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.lblPeriodo = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
         this.lblAplicar = new System.Windows.Forms.Label();
         this.lblSalir = new System.Windows.Forms.Label();
         this.lblMargenIzq = new System.Windows.Forms.Label();
         this.lblMargenDer = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.FlowLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // lblTituloPrinc
         // 
         this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
         this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
         this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(94)))), ((int)(((byte)(117)))));
         this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
         this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
         this.lblTituloPrinc.Name = "lblTituloPrinc";
         this.lblTituloPrinc.Size = new System.Drawing.Size(437, 40);
         this.lblTituloPrinc.TabIndex = 213;
         this.lblTituloPrinc.Text = " SAE >> Abrir Periodo";
         this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblTituloPrinc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseDown);
         this.lblTituloPrinc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseMove);
         this.lblTituloPrinc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseUp);
         // 
         // lblMargenTop
         // 
         this.lblMargenTop.BackColor = System.Drawing.Color.Black;
         this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
         this.lblMargenTop.Name = "lblMargenTop";
         this.lblMargenTop.Size = new System.Drawing.Size(437, 2);
         this.lblMargenTop.TabIndex = 214;
         // 
         // lblMargenInf
         // 
         this.lblMargenInf.BackColor = System.Drawing.Color.Black;
         this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.lblMargenInf.Location = new System.Drawing.Point(2, 262);
         this.lblMargenInf.Name = "lblMargenInf";
         this.lblMargenInf.Size = new System.Drawing.Size(437, 2);
         this.lblMargenInf.TabIndex = 215;
         // 
         // btnExit
         // 
         this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
         this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnExit.FlatAppearance.BorderSize = 0;
         this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
         this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
         this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnExit.Font = new System.Drawing.Font("Jokerman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnExit.ForeColor = System.Drawing.Color.Black;
         this.btnExit.Location = new System.Drawing.Point(413, 3);
         this.btnExit.Margin = new System.Windows.Forms.Padding(0);
         this.btnExit.Name = "btnExit";
         this.btnExit.Size = new System.Drawing.Size(24, 26);
         this.btnExit.TabIndex = 216;
         this.btnExit.Text = "X";
         this.btnExit.UseVisualStyleBackColor = false;
         this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
         // 
         // lblImagen
         // 
         this.lblImagen.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblImagen.ForeColor = System.Drawing.Color.White;
         this.lblImagen.Image = global::Aplicacion.Properties.Resources.calendario;
         this.lblImagen.Location = new System.Drawing.Point(319, 20);
         this.lblImagen.Name = "lblImagen";
         this.lblImagen.Size = new System.Drawing.Size(92, 82);
         this.lblImagen.TabIndex = 219;
         this.lblImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.txtanio);
         this.groupBox1.Controls.Add(this.cboPeriodo);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.lblPeriodo);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.lblImagen);
         this.groupBox1.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(12, 49);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(417, 143);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Periodo (Mes / Año)";
         // 
         // txtanio
         // 
         this.txtanio.BackColor = System.Drawing.Color.WhiteSmoke;
         this.txtanio.Location = new System.Drawing.Point(252, 96);
         this.txtanio.Name = "txtanio";
         this.txtanio.ReadOnly = true;
         this.txtanio.Size = new System.Drawing.Size(65, 33);
         this.txtanio.TabIndex = 222;
         this.txtanio.Text = "2014";
         this.txtanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // cboPeriodo
         // 
         this.cboPeriodo.FormattingEnabled = true;
         this.cboPeriodo.Location = new System.Drawing.Point(158, 95);
         this.cboPeriodo.Name = "cboPeriodo";
         this.cboPeriodo.Size = new System.Drawing.Size(69, 34);
         this.cboPeriodo.TabIndex = 0;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label4.Location = new System.Drawing.Point(230, 99);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(19, 26);
         this.label4.TabIndex = 220;
         this.label4.Text = "/";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(21, 99);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(135, 26);
         this.label2.TabIndex = 220;
         this.label2.Text = "Abrir Periodo";
         // 
         // lblPeriodo
         // 
         this.lblPeriodo.AutoSize = true;
         this.lblPeriodo.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
         this.lblPeriodo.Location = new System.Drawing.Point(169, 41);
         this.lblPeriodo.Name = "lblPeriodo";
         this.lblPeriodo.Size = new System.Drawing.Size(85, 26);
         this.lblPeriodo.TabIndex = 220;
         this.lblPeriodo.Text = "00/0000";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(21, 41);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(146, 26);
         this.label1.TabIndex = 220;
         this.label1.Text = "Periodo Actual";
         // 
         // FlowLayoutPanel1
         // 
         this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(94)))), ((int)(((byte)(117)))));
         this.FlowLayoutPanel1.Controls.Add(this.lblAplicar);
         this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
         this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 196);
         this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
         this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
         this.FlowLayoutPanel1.Size = new System.Drawing.Size(437, 66);
         this.FlowLayoutPanel1.TabIndex = 221;
         // 
         // lblAplicar
         // 
         this.lblAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
         this.lblAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.lblAplicar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAplicar.ForeColor = System.Drawing.Color.White;
         this.lblAplicar.Image = global::Aplicacion.Properties.Resources.Apply;
         this.lblAplicar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.lblAplicar.Location = new System.Drawing.Point(150, 0);
         this.lblAplicar.Margin = new System.Windows.Forms.Padding(150, 0, 3, 0);
         this.lblAplicar.Name = "lblAplicar";
         this.lblAplicar.Size = new System.Drawing.Size(58, 64);
         this.lblAplicar.TabIndex = 1;
         this.lblAplicar.Text = "&Aplicar";
         this.lblAplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.lblAplicar.Click += new System.EventHandler(this.lblAplicar_Click);
         // 
         // lblSalir
         // 
         this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
         this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSalir.ForeColor = System.Drawing.Color.White;
         this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
         this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
         this.lblSalir.Location = new System.Drawing.Point(226, 0);
         this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
         this.lblSalir.Name = "lblSalir";
         this.lblSalir.Size = new System.Drawing.Size(58, 64);
         this.lblSalir.TabIndex = 5;
         this.lblSalir.Text = "&Salir";
         this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
         this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
         // 
         // lblMargenIzq
         // 
         this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
         this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
         this.lblMargenIzq.Location = new System.Drawing.Point(439, 0);
         this.lblMargenIzq.Name = "lblMargenIzq";
         this.lblMargenIzq.Size = new System.Drawing.Size(2, 264);
         this.lblMargenIzq.TabIndex = 212;
         // 
         // lblMargenDer
         // 
         this.lblMargenDer.BackColor = System.Drawing.Color.Black;
         this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
         this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
         this.lblMargenDer.Name = "lblMargenDer";
         this.lblMargenDer.Size = new System.Drawing.Size(2, 264);
         this.lblMargenDer.TabIndex = 211;
         // 
         // FrmPeriodo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
         this.CancelButton = this.btnExit;
         this.ClientSize = new System.Drawing.Size(441, 264);
         this.Controls.Add(this.FlowLayoutPanel1);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnExit);
         this.Controls.Add(this.lblMargenInf);
         this.Controls.Add(this.lblTituloPrinc);
         this.Controls.Add(this.lblMargenTop);
         this.Controls.Add(this.lblMargenDer);
         this.Controls.Add(this.lblMargenIzq);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "FrmPeriodo";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "FrmPeriodo";
         this.Load += new System.EventHandler(this.FrmPeriodo_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.FlowLayoutPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.Label lblMargenTop;
        internal System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtanio;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblAplicar;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenDer;
    }
}