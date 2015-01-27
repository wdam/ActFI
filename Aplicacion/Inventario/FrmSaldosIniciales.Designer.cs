namespace Aplicacion.Inventario
{
    partial class FrmSaldosIniciales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblEditar = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblpdf = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.dtItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvalUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDepreciacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbGeneral.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
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
            this.btnExit.Location = new System.Drawing.Point(762, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 220;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
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
            this.lblTituloPrinc.Size = new System.Drawing.Size(786, 45);
            this.lblTituloPrinc.TabIndex = 219;
            this.lblTituloPrinc.Text = " SAE >> Saldos Iniciales  de Activos Fijos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(788, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 559);
            this.lblMargenIzq.TabIndex = 218;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 559);
            this.lblMargenDer.TabIndex = 217;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(786, 2);
            this.lblMargenTop.TabIndex = 221;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 557);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(786, 2);
            this.lblMargenInf.TabIndex = 222;
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.textBox5);
            this.gbGeneral.Controls.Add(this.maskedTextBox1);
            this.gbGeneral.Controls.Add(this.textBox2);
            this.gbGeneral.Controls.Add(this.textBox4);
            this.gbGeneral.Controls.Add(this.textBox6);
            this.gbGeneral.Controls.Add(this.textBox3);
            this.gbGeneral.Controls.Add(this.textBox1);
            this.gbGeneral.Controls.Add(this.label5);
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.label1);
            this.gbGeneral.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGeneral.ForeColor = System.Drawing.Color.Crimson;
            this.gbGeneral.Location = new System.Drawing.Point(12, 51);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(766, 131);
            this.gbGeneral.TabIndex = 223;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "Informacion General";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(326, 60);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(31, 26);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "00";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox1.Location = new System.Drawing.Point(356, 60);
            this.maskedTextBox1.Mask = "/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(85, 26);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.Text = "000000";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(356, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(350, 26);
            this.textBox2.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(56, 95);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(122, 26);
            this.textBox4.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(184, 95);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(355, 26);
            this.textBox6.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(98, 63);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(99, 26);
            this.textBox3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(184, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(267, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Concepto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(267, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Numero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Documento";
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblNuevo);
            this.FlowLayoutPanel1.Controls.Add(this.lblGuardar);
            this.FlowLayoutPanel1.Controls.Add(this.lblCancelar);
            this.FlowLayoutPanel1.Controls.Add(this.lblEditar);
            this.FlowLayoutPanel1.Controls.Add(this.lblBuscar);
            this.FlowLayoutPanel1.Controls.Add(this.lblpdf);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Controls.Add(this.lblOperacion);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 491);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(786, 66);
            this.FlowLayoutPanel1.TabIndex = 224;
            // 
            // lblNuevo
            // 
            this.lblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNuevo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevo.ForeColor = System.Drawing.Color.White;
            this.lblNuevo.Image = global::Aplicacion.Properties.Resources.nuevo;
            this.lblNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNuevo.Location = new System.Drawing.Point(15, 0);
            this.lblNuevo.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblNuevo.Name = "lblNuevo";
            this.lblNuevo.Size = new System.Drawing.Size(58, 64);
            this.lblNuevo.TabIndex = 0;
            this.lblNuevo.Text = "&Nuevo";
            this.lblNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblGuardar
            // 
            this.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGuardar.Enabled = false;
            this.lblGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuardar.ForeColor = System.Drawing.Color.White;
            this.lblGuardar.Image = global::Aplicacion.Properties.Resources.guardar;
            this.lblGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGuardar.Location = new System.Drawing.Point(91, 0);
            this.lblGuardar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(58, 64);
            this.lblGuardar.TabIndex = 1;
            this.lblGuardar.Text = "&Guardar";
            this.lblGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCancelar
            // 
            this.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancelar.Enabled = false;
            this.lblCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelar.ForeColor = System.Drawing.Color.White;
            this.lblCancelar.Image = global::Aplicacion.Properties.Resources.Cancel;
            this.lblCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCancelar.Location = new System.Drawing.Point(167, 0);
            this.lblCancelar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(58, 64);
            this.lblCancelar.TabIndex = 2;
            this.lblCancelar.Text = "&Cancelar";
            this.lblCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblEditar
            // 
            this.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditar.ForeColor = System.Drawing.Color.White;
            this.lblEditar.Image = global::Aplicacion.Properties.Resources.editar;
            this.lblEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEditar.Location = new System.Drawing.Point(243, 0);
            this.lblEditar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(58, 64);
            this.lblEditar.TabIndex = 3;
            this.lblEditar.Text = "&Editar";
            this.lblEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Image = global::Aplicacion.Properties.Resources.buscar;
            this.lblBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblBuscar.Location = new System.Drawing.Point(319, 0);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(58, 64);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "&Buscar";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblpdf
            // 
            this.lblpdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblpdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpdf.ForeColor = System.Drawing.Color.White;
            this.lblpdf.Image = global::Aplicacion.Properties.Resources.exportar;
            this.lblpdf.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblpdf.Location = new System.Drawing.Point(395, 0);
            this.lblpdf.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblpdf.Name = "lblpdf";
            this.lblpdf.Size = new System.Drawing.Size(58, 64);
            this.lblpdf.TabIndex = 6;
            this.lblpdf.Text = "&Pdf";
            this.lblpdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(471, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(58, 64);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacion.Location = new System.Drawing.Point(535, 0);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(70, 20);
            this.lblOperacion.TabIndex = 8;
            this.lblOperacion.Text = "Consulta";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(169)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeight = 30;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtItem,
            this.dtCodigo,
            this.dtDescripcion,
            this.dtCantidad,
            this.dtvalUnitario,
            this.dtTotal,
            this.dtDepreciacion});
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.GridColor = System.Drawing.Color.Black;
            this.dgvItems.Location = new System.Drawing.Point(12, 186);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvItems.Size = new System.Drawing.Size(766, 297);
            this.dgvItems.TabIndex = 225;
            this.dgvItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItems_CellBeginEdit);
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);
            this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            // 
            // dtItem
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtItem.HeaderText = "Item";
            this.dtItem.Name = "dtItem";
            this.dtItem.ReadOnly = true;
            this.dtItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtItem.Width = 50;
            // 
            // dtCodigo
            // 
            this.dtCodigo.HeaderText = "Codigo";
            this.dtCodigo.Name = "dtCodigo";
            // 
            // dtDescripcion
            // 
            this.dtDescripcion.HeaderText = "Descripción";
            this.dtDescripcion.MinimumWidth = 190;
            this.dtDescripcion.Name = "dtDescripcion";
            this.dtDescripcion.ReadOnly = true;
            this.dtDescripcion.Width = 190;
            // 
            // dtCantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.dtCantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtCantidad.HeaderText = "Cantidad";
            this.dtCantidad.MinimumWidth = 85;
            this.dtCantidad.Name = "dtCantidad";
            this.dtCantidad.Width = 85;
            // 
            // dtvalUnitario
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.dtvalUnitario.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtvalUnitario.HeaderText = "V. Unitario";
            this.dtvalUnitario.MinimumWidth = 110;
            this.dtvalUnitario.Name = "dtvalUnitario";
            this.dtvalUnitario.Width = 110;
            // 
            // dtTotal
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.dtTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtTotal.HeaderText = "V. Total";
            this.dtTotal.Name = "dtTotal";
            this.dtTotal.ReadOnly = true;
            // 
            // dtDepreciacion
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.dtDepreciacion.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtDepreciacion.HeaderText = "Depreciación";
            this.dtDepreciacion.MinimumWidth = 115;
            this.dtDepreciacion.Name = "dtDepreciacion";
            this.dtDepreciacion.Width = 115;
            // 
            // FrmSaldosIniciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(790, 559);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSaldosIniciales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSaldosIniciales";
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblGuardar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblEditar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblpdf;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvalUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDepreciacion;
    }
}