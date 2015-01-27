namespace Aplicacion.Inventario
{
    partial class FrmSelCentroCostos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cboBuscar = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvCentro = new System.Windows.Forms.DataGridView();
            this.dtNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtPresupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentro)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Maroon;
            this.Label2.Location = new System.Drawing.Point(204, 529);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(256, 20);
            this.Label2.TabIndex = 204;
            this.Label2.Text = "Click o Doble Click Para Seleccionar ";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Open Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Crimson;
            this.lblMensaje.Location = new System.Drawing.Point(131, 308);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(403, 37);
            this.lblMensaje.TabIndex = 203;
            this.lblMensaje.Text = "No Existen Datos Para Mostrar";
            this.lblMensaje.Visible = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.lblRegistro);
            this.GroupBox3.Controls.Add(this.cboBuscar);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.txtBuscar);
            this.GroupBox3.Location = new System.Drawing.Point(12, 48);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(640, 75);
            this.GroupBox3.TabIndex = 201;
            this.GroupBox3.TabStop = false;
            // 
            // cboBuscar
            // 
            this.cboBuscar.DropDownWidth = 133;
            this.cboBuscar.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuscar.FormattingEnabled = true;
            this.cboBuscar.ItemHeight = 22;
            this.cboBuscar.Items.AddRange(new object[] {
            "Codigo",
            "Nombre"});
            this.cboBuscar.Location = new System.Drawing.Point(122, 17);
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.Size = new System.Drawing.Size(133, 30);
            this.cboBuscar.TabIndex = 0;
            this.cboBuscar.SelectedIndexChanged += new System.EventHandler(this.cboBuscar_SelectedIndexChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(23, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(93, 22);
            this.Label5.TabIndex = 73;
            this.Label5.Text = "Buscar Por";
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Open Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(261, 17);
            this.txtBuscar.MaxLength = 100;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(335, 31);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvCentro
            // 
            this.dgvCentro.AllowUserToAddRows = false;
            this.dgvCentro.AllowUserToDeleteRows = false;
            this.dgvCentro.AllowUserToResizeColumns = false;
            this.dgvCentro.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvCentro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCentro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCentro.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCentro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCentro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCentro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(140)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Open Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCentro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCentro.ColumnHeadersHeight = 30;
            this.dgvCentro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCentro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtNombre,
            this.dtCodigo,
            this.dtNivel,
            this.dtPresupuesto});
            this.dgvCentro.EnableHeadersVisualStyles = false;
            this.dgvCentro.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvCentro.Location = new System.Drawing.Point(12, 128);
            this.dgvCentro.MultiSelect = false;
            this.dgvCentro.Name = "dgvCentro";
            this.dgvCentro.ReadOnly = true;
            this.dgvCentro.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCentro.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCentro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCentro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCentro.Size = new System.Drawing.Size(640, 397);
            this.dgvCentro.StandardTab = true;
            this.dgvCentro.TabIndex = 200;
            this.dgvCentro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCentro_CellContentClick);
            this.dgvCentro.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCentro_CellDoubleClick);
            // 
            // dtNombre
            // 
            this.dtNombre.DataPropertyName = "Nombre";
            this.dtNombre.HeaderText = "Nombre Centro De Costos";
            this.dtNombre.MaxInputLength = 300;
            this.dtNombre.MinimumWidth = 350;
            this.dtNombre.Name = "dtNombre";
            this.dtNombre.ReadOnly = true;
            this.dtNombre.Width = 383;
            // 
            // dtCodigo
            // 
            this.dtCodigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dtCodigo.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtCodigo.HeaderText = "Codigo";
            this.dtCodigo.MinimumWidth = 123;
            this.dtCodigo.Name = "dtCodigo";
            this.dtCodigo.ReadOnly = true;
            this.dtCodigo.Width = 130;
            // 
            // dtNivel
            // 
            this.dtNivel.DataPropertyName = "Nivel";
            this.dtNivel.HeaderText = "Nivel";
            this.dtNivel.Name = "dtNivel";
            this.dtNivel.ReadOnly = true;
            this.dtNivel.Width = 110;
            // 
            // dtPresupuesto
            // 
            this.dtPresupuesto.DataPropertyName = "Presupuesto";
            this.dtPresupuesto.HeaderText = "Presupuesto";
            this.dtPresupuesto.Name = "dtPresupuesto";
            this.dtPresupuesto.ReadOnly = true;
            this.dtPresupuesto.Visible = false;
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(661, 45);
            this.lblTituloPrinc.TabIndex = 207;
            this.lblTituloPrinc.Text = " SAE >> Seleccionar  Centro de Costos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(663, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 556);
            this.lblMargenIzq.TabIndex = 206;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 556);
            this.lblMargenDer.TabIndex = 205;
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
            this.btnExit.Location = new System.Drawing.Point(637, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 209;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(661, 2);
            this.lblMargenTop.TabIndex = 210;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 554);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(661, 2);
            this.lblMargenInf.TabIndex = 208;
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.Crimson;
            this.lblRegistro.Location = new System.Drawing.Point(170, 49);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(266, 22);
            this.lblRegistro.TabIndex = 223;
            this.lblRegistro.Text = "Cerca de 0  registros Encontrados";
            // 
            // FrmSelCentroCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(665, 556);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.dgvCentro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSelCentroCostos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSelCentroCostos";
            this.Load += new System.EventHandler(this.FrmSelCentroCostos_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCentro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtNivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtPresupuesto;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.ComboBox cboBuscar;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvCentro;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.Label Label2;
    }
}