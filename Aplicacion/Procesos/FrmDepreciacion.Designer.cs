namespace Aplicacion.Procesos
{
    partial class FrmDepreciacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.dtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDepreciacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDepAcum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtLibros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCtaGastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCtaDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtanio = new System.Windows.Forms.TextBox();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDepreciar = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.dgvContable = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(702, 2);
            this.lblMargenTop.TabIndex = 176;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 573);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(702, 2);
            this.lblMargenInf.TabIndex = 177;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(704, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 575);
            this.lblMargenIzq.TabIndex = 175;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 575);
            this.lblMargenDer.TabIndex = 174;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(247)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Jokerman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(443, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 179;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(130)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(702, 45);
            this.lblTituloPrinc.TabIndex = 178;
            this.lblTituloPrinc.Text = " SAE  >> Depreciación de Activos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtCodigo,
            this.dtYear,
            this.dtDepreciacion,
            this.dtDepAcum,
            this.dtLibros,
            this.dtCtaGastos,
            this.dtCtaDep});
            this.dgvDatos.Location = new System.Drawing.Point(12, 228);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(682, 156);
            this.dgvDatos.TabIndex = 180;
            // 
            // dtCodigo
            // 
            this.dtCodigo.HeaderText = "Codigo";
            this.dtCodigo.Name = "dtCodigo";
            this.dtCodigo.ReadOnly = true;
            // 
            // dtYear
            // 
            this.dtYear.HeaderText = "Periodo";
            this.dtYear.Name = "dtYear";
            this.dtYear.ReadOnly = true;
            // 
            // dtDepreciacion
            // 
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.dtDepreciacion.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtDepreciacion.HeaderText = "Depreciación Mensual";
            this.dtDepreciacion.MinimumWidth = 150;
            this.dtDepreciacion.Name = "dtDepreciacion";
            this.dtDepreciacion.ReadOnly = true;
            this.dtDepreciacion.Width = 150;
            // 
            // dtDepAcum
            // 
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.dtDepAcum.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtDepAcum.HeaderText = "Depreciación Acumulada ";
            this.dtDepAcum.MinimumWidth = 150;
            this.dtDepAcum.Name = "dtDepAcum";
            this.dtDepAcum.ReadOnly = true;
            this.dtDepAcum.Width = 150;
            // 
            // dtLibros
            // 
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.dtLibros.DefaultCellStyle = dataGridViewCellStyle15;
            this.dtLibros.HeaderText = "Valor en Libros";
            this.dtLibros.Name = "dtLibros";
            this.dtLibros.ReadOnly = true;
            // 
            // dtCtaGastos
            // 
            this.dtCtaGastos.HeaderText = "Cta Gastos";
            this.dtCtaGastos.Name = "dtCtaGastos";
            this.dtCtaGastos.ReadOnly = true;
            // 
            // dtCtaDep
            // 
            this.dtCtaDep.HeaderText = "Cta Depreciacion";
            this.dtCtaDep.Name = "dtCtaDep";
            this.dtCtaDep.ReadOnly = true;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.ForeColor = System.Drawing.Color.Crimson;
            this.lblPeriodo.Location = new System.Drawing.Point(351, 29);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(70, 22);
            this.lblPeriodo.TabIndex = 184;
            this.lblPeriodo.Text = "00/0000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.lblPeriodo);
            this.groupBox1.Controls.Add(this.txtanio);
            this.groupBox1.Controls.Add(this.cboPeriodo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 170);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione";
            // 
            // txtanio
            // 
            this.txtanio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtanio.Location = new System.Drawing.Point(197, 93);
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
            this.cboPeriodo.Location = new System.Drawing.Point(103, 92);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(69, 34);
            this.cboPeriodo.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 26);
            this.label4.TabIndex = 220;
            this.label4.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 26);
            this.label5.TabIndex = 220;
            this.label5.Text = "Periodo a Depreciar";
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(130)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblDepreciar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 507);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(702, 66);
            this.FlowLayoutPanel1.TabIndex = 224;
            // 
            // lblDepreciar
            // 
            this.lblDepreciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDepreciar.Enabled = false;
            this.lblDepreciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDepreciar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepreciar.ForeColor = System.Drawing.Color.White;
            this.lblDepreciar.Image = global::Aplicacion.Properties.Resources.Apply;
            this.lblDepreciar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDepreciar.Location = new System.Drawing.Point(130, 0);
            this.lblDepreciar.Margin = new System.Windows.Forms.Padding(130, 0, 3, 0);
            this.lblDepreciar.Name = "lblDepreciar";
            this.lblDepreciar.Size = new System.Drawing.Size(70, 64);
            this.lblDepreciar.TabIndex = 1;
            this.lblDepreciar.Text = "&Depreciar";
            this.lblDepreciar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblDepreciar, "Iniciar Depreciación");
            this.lblDepreciar.Click += new System.EventHandler(this.lblDepreciar_Click);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(218, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(70, 64);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // dgvContable
            // 
            this.dgvContable.AllowUserToAddRows = false;
            this.dgvContable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.sumat});
            this.dgvContable.Location = new System.Drawing.Point(12, 390);
            this.dgvContable.Name = "dgvContable";
            this.dgvContable.Size = new System.Drawing.Size(526, 111);
            this.dgvContable.TabIndex = 225;
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "ctaGastos";
            this.codigo.HeaderText = "Column1";
            this.codigo.Name = "codigo";
            // 
            // sumat
            // 
            this.sumat.DataPropertyName = "suma";
            this.sumat.HeaderText = "Column1";
            this.sumat.Name = "sumat";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(326, 126);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(105, 28);
            this.txtNumero.TabIndex = 223;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 100;
            // 
            // FrmDepreciacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(706, 575);
            this.Controls.Add(this.dgvContable);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDepreciacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmDepreciacion";
            this.Load += new System.EventHandler(this.FrmDepreciacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtanio;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblDepreciar;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDepreciacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDepAcum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCtaGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCtaDep;
        private System.Windows.Forms.DataGridView dgvContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumat;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}