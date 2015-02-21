namespace Aplicacion.Inventario
{
    partial class FrmSelActivos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cboBuscar = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.dgvActivos = new System.Windows.Forms.DataGridView();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.dtcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtPropiedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtValCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDepreciacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtValLibros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivos)).BeginInit();
            this.SuspendLayout();
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
            this.btnExit.Location = new System.Drawing.Point(900, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 166;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(924, 45);
            this.lblTituloPrinc.TabIndex = 165;
            this.lblTituloPrinc.Text = " SAE >> Buscar Activo ";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloPrinc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseDown);
            this.lblTituloPrinc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseMove);
            this.lblTituloPrinc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseUp);
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 536);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(924, 2);
            this.lblMargenInf.TabIndex = 164;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(926, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 538);
            this.lblMargenIzq.TabIndex = 163;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 538);
            this.lblMargenDer.TabIndex = 162;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(924, 2);
            this.lblMargenTop.TabIndex = 167;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Open Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(320, 66);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(415, 31);
            this.txtBuscar.TabIndex = 185;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cboBuscar
            // 
            this.cboBuscar.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuscar.FormattingEnabled = true;
            this.cboBuscar.Items.AddRange(new object[] {
            "Codigo",
            "Nombre",
            "Propiedad",
            "Area"});
            this.cboBuscar.Location = new System.Drawing.Point(193, 66);
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.Size = new System.Drawing.Size(121, 30);
            this.cboBuscar.TabIndex = 184;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(94, 70);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(93, 22);
            this.Label1.TabIndex = 183;
            this.Label1.Text = "Buscar Por";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Open Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Crimson;
            this.lblMensaje.Location = new System.Drawing.Point(285, 303);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(358, 37);
            this.lblMensaje.TabIndex = 189;
            this.lblMensaje.Text = "No hay Datos Para Mostrar";
            this.lblMensaje.Visible = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Maroon;
            this.Label2.Location = new System.Drawing.Point(336, 511);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(256, 20);
            this.Label2.TabIndex = 188;
            this.Label2.Text = "Click o Doble Click Para Seleccionar ";
            // 
            // dgvActivos
            // 
            this.dgvActivos.AllowUserToAddRows = false;
            this.dgvActivos.AllowUserToDeleteRows = false;
            this.dgvActivos.AllowUserToResizeColumns = false;
            this.dgvActivos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvActivos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvActivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvActivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvActivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(140)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActivos.ColumnHeadersHeight = 30;
            this.dgvActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvActivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtcodigo,
            this.dtNombre,
            this.dtPropiedad,
            this.dtArea,
            this.dtValCom,
            this.dtDepreciacion,
            this.dtValLibros});
            this.dgvActivos.EnableHeadersVisualStyles = false;
            this.dgvActivos.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvActivos.Location = new System.Drawing.Point(10, 126);
            this.dgvActivos.MultiSelect = false;
            this.dgvActivos.Name = "dgvActivos";
            this.dgvActivos.ReadOnly = true;
            this.dgvActivos.RowHeadersVisible = false;
            this.dgvActivos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvActivos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActivos.Size = new System.Drawing.Size(908, 381);
            this.dgvActivos.TabIndex = 187;
            this.dgvActivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivos_CellContentClick);
            this.dgvActivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivos_CellDoubleClick);
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.Crimson;
            this.lblRegistro.Location = new System.Drawing.Point(269, 100);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(266, 22);
            this.lblRegistro.TabIndex = 223;
            this.lblRegistro.Text = "Cerca de 0  registros Encontrados";
            // 
            // dtcodigo
            // 
            this.dtcodigo.DataPropertyName = "codigo";
            this.dtcodigo.HeaderText = "Codigo";
            this.dtcodigo.MinimumWidth = 50;
            this.dtcodigo.Name = "dtcodigo";
            this.dtcodigo.ReadOnly = true;
            this.dtcodigo.ToolTipText = "Codigo";
            this.dtcodigo.Width = 90;
            // 
            // dtNombre
            // 
            this.dtNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtNombre.DataPropertyName = "nombre";
            this.dtNombre.HeaderText = "Nombre";
            this.dtNombre.MinimumWidth = 200;
            this.dtNombre.Name = "dtNombre";
            this.dtNombre.ReadOnly = true;
            this.dtNombre.ToolTipText = "Nombre";
            this.dtNombre.Width = 200;
            // 
            // dtPropiedad
            // 
            this.dtPropiedad.DataPropertyName = "propiedad";
            this.dtPropiedad.HeaderText = "Propiedad";
            this.dtPropiedad.Name = "dtPropiedad";
            this.dtPropiedad.ReadOnly = true;
            this.dtPropiedad.ToolTipText = "Propiedad";
            // 
            // dtArea
            // 
            this.dtArea.DataPropertyName = "area";
            this.dtArea.HeaderText = "Area";
            this.dtArea.Name = "dtArea";
            this.dtArea.ReadOnly = true;
            this.dtArea.Width = 145;
            // 
            // dtValCom
            // 
            this.dtValCom.DataPropertyName = "valComercial";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dtValCom.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtValCom.HeaderText = "Val. Comercial";
            this.dtValCom.MinimumWidth = 100;
            this.dtValCom.Name = "dtValCom";
            this.dtValCom.ReadOnly = true;
            this.dtValCom.ToolTipText = "Valor Comercial";
            this.dtValCom.Width = 130;
            // 
            // dtDepreciacion
            // 
            this.dtDepreciacion.DataPropertyName = "depAjustada";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.dtDepreciacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtDepreciacion.HeaderText = "Depreciacion";
            this.dtDepreciacion.Name = "dtDepreciacion";
            this.dtDepreciacion.ReadOnly = true;
            this.dtDepreciacion.Width = 110;
            // 
            // dtValLibros
            // 
            this.dtValLibros.DataPropertyName = "valLibros";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dtValLibros.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtValLibros.HeaderText = "Val Libros";
            this.dtValLibros.MinimumWidth = 100;
            this.dtValLibros.Name = "dtValLibros";
            this.dtValLibros.ReadOnly = true;
            this.dtValLibros.Width = 120;
            // 
            // FrmSelActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(928, 538);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dgvActivos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.cboBuscar);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSelActivos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSelActivos";
            this.Load += new System.EventHandler(this.FrmSelActivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cboBuscar;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DataGridView dgvActivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtPropiedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtValCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDepreciacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtValLibros;
    }
}