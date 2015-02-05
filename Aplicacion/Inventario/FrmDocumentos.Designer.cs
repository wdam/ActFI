namespace Aplicacion.Inventario
{
    partial class FrmDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumentos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtNombreTer = new System.Windows.Forms.TextBox();
            this.txtDesctipo = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.txtPeriodo = new System.Windows.Forms.MaskedTextBox();
            this.txtNomCentro = new System.Windows.Forms.TextBox();
            this.txtCentro = new System.Windows.Forms.TextBox();
            this.txtVmto = new System.Windows.Forms.TextBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblPrint = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtDebito = new System.Windows.Forms.TextBox();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblEditar = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblNuevoDoc = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblEliminar = new System.Windows.Forms.Label();
            this.smsError = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.dtDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDebito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDvmto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtNit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCentro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMovimiento = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.gbMovimiento.SuspendLayout();
            this.FlowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Jokerman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1062, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 206;
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
            this.lblTituloPrinc.Size = new System.Drawing.Size(1086, 40);
            this.lblTituloPrinc.TabIndex = 209;
            this.lblTituloPrinc.Text = " SAE >> Generar Documentos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloPrinc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseDown);
            this.lblTituloPrinc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseMove);
            this.lblTituloPrinc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseUp);
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 645);
            this.lblMargenDer.TabIndex = 207;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(1088, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 645);
            this.lblMargenIzq.TabIndex = 208;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(1086, 2);
            this.lblMargenTop.TabIndex = 210;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 643);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(1086, 2);
            this.lblMargenInf.TabIndex = 211;
            // 
            // txtNit
            // 
            this.txtNit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNit.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNit.Location = new System.Drawing.Point(158, 129);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(136, 28);
            this.txtNit.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtNit, "Nit Tercero");
            this.txtNit.TextChanged += new System.EventHandler(this.txtNit_TextChanged);
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(252, 59);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(105, 28);
            this.txtNumero.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtNumero, "Numero de Documento");
            // 
            // txtNombreTer
            // 
            this.txtNombreTer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNombreTer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreTer.Enabled = false;
            this.txtNombreTer.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreTer.Location = new System.Drawing.Point(300, 129);
            this.txtNombreTer.Name = "txtNombreTer";
            this.txtNombreTer.ReadOnly = true;
            this.txtNombreTer.Size = new System.Drawing.Size(430, 28);
            this.txtNombreTer.TabIndex = 212;
            this.toolTip1.SetToolTip(this.txtNombreTer, "Nombre Tercero");
            // 
            // txtDesctipo
            // 
            this.txtDesctipo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDesctipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesctipo.Enabled = false;
            this.txtDesctipo.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesctipo.Location = new System.Drawing.Point(235, 24);
            this.txtDesctipo.Name = "txtDesctipo";
            this.txtDesctipo.ReadOnly = true;
            this.txtDesctipo.Size = new System.Drawing.Size(495, 28);
            this.txtDesctipo.TabIndex = 212;
            this.txtDesctipo.Text = "DOCUMENTO DE CONTABILIDAD";
            this.toolTip1.SetToolTip(this.txtDesctipo, "Descripción tipo de Documento");
            // 
            // txtDocumento
            // 
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(184, 24);
            this.txtDocumento.MaxLength = 2;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(46, 28);
            this.txtDocumento.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtDocumento, "Seleccione Tipo de Documento");
            this.txtDocumento.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            this.txtDocumento.DoubleClick += new System.EventHandler(this.txtDocumento_DoubleClick);
            // 
            // txtDia
            // 
            this.txtDia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDia.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia.Location = new System.Drawing.Point(433, 59);
            this.txtDia.MaxLength = 2;
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(36, 28);
            this.txtDia.TabIndex = 2;
            this.txtDia.Text = "00";
            this.txtDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtDia, "Dia");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 22);
            this.label1.TabIndex = 213;
            this.label1.Text = "Tipo de Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 22);
            this.label2.TabIndex = 213;
            this.label2.Text = "Nro de Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 22);
            this.label3.TabIndex = 213;
            this.label3.Text = "Centro de Costo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 22);
            this.label4.TabIndex = 213;
            this.label4.Text = "Nit / C.C. Tercero";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(375, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 22);
            this.label5.TabIndex = 213;
            this.label5.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(590, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 22);
            this.label6.TabIndex = 213;
            this.label6.Text = "Dias V/mto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(90)))));
            this.label7.Location = new System.Drawing.Point(30, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 26);
            this.label7.TabIndex = 213;
            this.label7.Text = "Debito $";
            // 
            // gbGeneral
            // 
            this.gbGeneral.BackColor = System.Drawing.Color.Transparent;
            this.gbGeneral.Controls.Add(this.txtFecha);
            this.gbGeneral.Controls.Add(this.txtPeriodo);
            this.gbGeneral.Controls.Add(this.txtNomCentro);
            this.gbGeneral.Controls.Add(this.txtNombreTer);
            this.gbGeneral.Controls.Add(this.label1);
            this.gbGeneral.Controls.Add(this.txtCentro);
            this.gbGeneral.Controls.Add(this.txtNit);
            this.gbGeneral.Controls.Add(this.txtDia);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.label6);
            this.gbGeneral.Controls.Add(this.txtVmto);
            this.gbGeneral.Controls.Add(this.txtNumero);
            this.gbGeneral.Controls.Add(this.txtDesctipo);
            this.gbGeneral.Controls.Add(this.txtDocumento);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.label5);
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Enabled = false;
            this.gbGeneral.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(32)))), ((int)(((byte)(90)))));
            this.gbGeneral.Location = new System.Drawing.Point(12, 48);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(742, 164);
            this.gbGeneral.TabIndex = 0;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "Datos Generales";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(468, 59);
            this.txtFecha.Mask = "/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(85, 28);
            this.txtFecha.TabIndex = 216;
            this.txtFecha.Text = "000000";
            this.toolTip1.SetToolTip(this.txtFecha, "Fecha");
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPeriodo.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.Location = new System.Drawing.Point(180, 63);
            this.txtPeriodo.Mask = "0000-00-";
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(70, 21);
            this.txtPeriodo.TabIndex = 215;
            this.txtPeriodo.Text = "201412";
            this.toolTip1.SetToolTip(this.txtPeriodo, "Periodo");
            // 
            // txtNomCentro
            // 
            this.txtNomCentro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNomCentro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomCentro.Enabled = false;
            this.txtNomCentro.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomCentro.Location = new System.Drawing.Point(281, 94);
            this.txtNomCentro.Name = "txtNomCentro";
            this.txtNomCentro.ReadOnly = true;
            this.txtNomCentro.Size = new System.Drawing.Size(449, 28);
            this.txtNomCentro.TabIndex = 212;
            this.toolTip1.SetToolTip(this.txtNomCentro, "Nombre Centro de Costo");
            // 
            // txtCentro
            // 
            this.txtCentro.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCentro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCentro.Enabled = false;
            this.txtCentro.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentro.Location = new System.Drawing.Point(153, 94);
            this.txtCentro.Name = "txtCentro";
            this.txtCentro.Size = new System.Drawing.Size(123, 28);
            this.txtCentro.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtCentro, "Codigo Centro de Costo");
            this.txtCentro.TextChanged += new System.EventHandler(this.txtCentro_TextChanged);
            // 
            // txtVmto
            // 
            this.txtVmto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVmto.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVmto.Location = new System.Drawing.Point(686, 59);
            this.txtVmto.Name = "txtVmto";
            this.txtVmto.Size = new System.Drawing.Size(44, 28);
            this.txtVmto.TabIndex = 3;
            this.txtVmto.Text = "0";
            this.txtVmto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtVmto, "Dias de Vencimiento");
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPeriodo.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.ForeColor = System.Drawing.Color.White;
            this.lblPeriodo.Image = global::Aplicacion.Properties.Resources.calendario;
            this.lblPeriodo.Location = new System.Drawing.Point(50, 41);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(92, 82);
            this.lblPeriodo.TabIndex = 218;
            this.lblPeriodo.Text = "07";
            this.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblPeriodo, "Abrir Periodo");
            this.lblPeriodo.Click += new System.EventHandler(this.lblPeriodo_Click);
            // 
            // lblPrint
            // 
            this.lblPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrint.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrint.ForeColor = System.Drawing.Color.White;
            this.lblPrint.Image = global::Aplicacion.Properties.Resources.Printer;
            this.lblPrint.Location = new System.Drawing.Point(178, 41);
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.Size = new System.Drawing.Size(92, 82);
            this.lblPrint.TabIndex = 218;
            this.lblPrint.Text = "Print";
            this.lblPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblPrint, "Imprimir Documento");
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 100;
            // 
            // txtDebito
            // 
            this.txtDebito.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDebito.Enabled = false;
            this.txtDebito.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(90)))));
            this.txtDebito.Location = new System.Drawing.Point(125, 27);
            this.txtDebito.Name = "txtDebito";
            this.txtDebito.ReadOnly = true;
            this.txtDebito.Size = new System.Drawing.Size(201, 29);
            this.txtDebito.TabIndex = 216;
            this.txtDebito.Text = "0";
            this.txtDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtDebito, "Debitos");
            // 
            // txtCredito
            // 
            this.txtCredito.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCredito.Enabled = false;
            this.txtCredito.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtCredito.Location = new System.Drawing.Point(497, 27);
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.ReadOnly = true;
            this.txtCredito.Size = new System.Drawing.Size(201, 29);
            this.txtCredito.TabIndex = 216;
            this.txtCredito.Text = "0";
            this.txtCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtCredito, "Creditos");
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDiferencia.Enabled = false;
            this.txtDiferencia.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferencia.ForeColor = System.Drawing.Color.Teal;
            this.txtDiferencia.Location = new System.Drawing.Point(804, 27);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(201, 29);
            this.txtDiferencia.TabIndex = 216;
            this.txtDiferencia.Text = "0";
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtDiferencia, "Diferencia");
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Enabled = false;
            this.txtObservaciones.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(170, 524);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(740, 45);
            this.txtObservaciones.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtObservaciones, "Observaciojes");
            // 
            // lblNuevo
            // 
            this.lblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNuevo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevo.ForeColor = System.Drawing.Color.White;
            this.lblNuevo.Image = global::Aplicacion.Properties.Resources.nuevo;
            this.lblNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNuevo.Location = new System.Drawing.Point(150, 0);
            this.lblNuevo.Margin = new System.Windows.Forms.Padding(150, 0, 3, 0);
            this.lblNuevo.Name = "lblNuevo";
            this.lblNuevo.Size = new System.Drawing.Size(58, 64);
            this.lblNuevo.TabIndex = 0;
            this.lblNuevo.Text = "&Nuevo";
            this.lblNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblNuevo, "Nuevo Registro");
            this.lblNuevo.Click += new System.EventHandler(this.lblNuevo_Click);
            this.lblNuevo.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblNuevo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
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
            this.lblGuardar.Location = new System.Drawing.Point(302, 0);
            this.lblGuardar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(58, 64);
            this.lblGuardar.TabIndex = 1;
            this.lblGuardar.Text = "&Guardar";
            this.lblGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblGuardar, "Guardar Registro");
            this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.lblGuardar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblGuardar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
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
            this.lblCancelar.Location = new System.Drawing.Point(378, 0);
            this.lblCancelar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(58, 64);
            this.lblCancelar.TabIndex = 2;
            this.lblCancelar.Text = "&Cancelar";
            this.lblCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblCancelar, "Cancelar Operacion");
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            this.lblCancelar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblEditar
            // 
            this.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditar.ForeColor = System.Drawing.Color.White;
            this.lblEditar.Image = global::Aplicacion.Properties.Resources.editar;
            this.lblEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEditar.Location = new System.Drawing.Point(454, 0);
            this.lblEditar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(58, 64);
            this.lblEditar.TabIndex = 3;
            this.lblEditar.Text = "&Editar";
            this.lblEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblEditar, "Editar Registro");
            this.lblEditar.Click += new System.EventHandler(this.lblEditar_Click);
            this.lblEditar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblEditar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Image = global::Aplicacion.Properties.Resources.buscar;
            this.lblBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblBuscar.Location = new System.Drawing.Point(606, 0);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(58, 64);
            this.lblBuscar.TabIndex = 4;
            this.lblBuscar.Text = "&Buscar";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblBuscar, "Buscar Registro");
            this.lblBuscar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblBuscar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblNuevoDoc
            // 
            this.lblNuevoDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNuevoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNuevoDoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoDoc.ForeColor = System.Drawing.Color.White;
            this.lblNuevoDoc.Image = global::Aplicacion.Properties.Resources.add;
            this.lblNuevoDoc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNuevoDoc.Location = new System.Drawing.Point(226, 0);
            this.lblNuevoDoc.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblNuevoDoc.Name = "lblNuevoDoc";
            this.lblNuevoDoc.Size = new System.Drawing.Size(58, 64);
            this.lblNuevoDoc.TabIndex = 6;
            this.lblNuevoDoc.Text = "&Nuevo+";
            this.lblNuevoDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblNuevoDoc, "Nuevo registro a partir de uno Existente");
            this.lblNuevoDoc.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblNuevoDoc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(682, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(58, 64);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir ");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            this.lblSalir.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblSalir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblEliminar
            // 
            this.lblEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEliminar.ForeColor = System.Drawing.Color.White;
            this.lblEliminar.Image = global::Aplicacion.Properties.Resources.eliminar;
            this.lblEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEliminar.Location = new System.Drawing.Point(530, 0);
            this.lblEliminar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblEliminar.Name = "lblEliminar";
            this.lblEliminar.Size = new System.Drawing.Size(58, 64);
            this.lblEliminar.TabIndex = 9;
            this.lblEliminar.Text = "&Eliminar";
            this.lblEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblEliminar, "Eliminar Registro");
            this.lblEliminar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblEliminar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // smsError
            // 
            this.smsError.ContainerControl = this;
            this.smsError.Icon = ((System.Drawing.Icon)(resources.GetObject("smsError.Icon")));
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDatos.ColumnHeadersHeight = 28;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtDescripcion,
            this.dtDebito,
            this.dtCredito,
            this.dtCuenta,
            this.dtBase,
            this.dtDvmto,
            this.dtFecha,
            this.dtNit,
            this.dtCentro,
            this.dtCheque});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.Location = new System.Drawing.Point(3, 69);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersVisible = false;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDatos.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDatos.Size = new System.Drawing.Size(1061, 200);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDatos_EditingControlShowing);
            // 
            // dtDescripcion
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dtDescripcion.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtDescripcion.HeaderText = "Descripción";
            this.dtDescripcion.MinimumWidth = 200;
            this.dtDescripcion.Name = "dtDescripcion";
            this.dtDescripcion.ToolTipText = "Descripción";
            this.dtDescripcion.Width = 240;
            // 
            // dtDebito
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0,00";
            this.dtDebito.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtDebito.HeaderText = "Debitos";
            this.dtDebito.Name = "dtDebito";
            this.dtDebito.ToolTipText = "Debitos";
            // 
            // dtCredito
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0,00";
            this.dtCredito.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtCredito.HeaderText = "Creditos";
            this.dtCredito.Name = "dtCredito";
            this.dtCredito.ToolTipText = "Creditos";
            // 
            // dtCuenta
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dtCuenta.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtCuenta.HeaderText = "Cuenta";
            this.dtCuenta.Name = "dtCuenta";
            this.dtCuenta.ToolTipText = "Cuenta Contable";
            // 
            // dtBase
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dtBase.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtBase.HeaderText = "Base";
            this.dtBase.MinimumWidth = 80;
            this.dtBase.Name = "dtBase";
            this.dtBase.ToolTipText = "Base";
            this.dtBase.Width = 80;
            // 
            // dtDvmto
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.dtDvmto.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtDvmto.HeaderText = "Dias V.";
            this.dtDvmto.MinimumWidth = 70;
            this.dtDvmto.Name = "dtDvmto";
            this.dtDvmto.ToolTipText = "Dias de Vencimiento";
            this.dtDvmto.Width = 70;
            // 
            // dtFecha
            // 
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = "00/00/0000";
            this.dtFecha.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtFecha.HeaderText = "Fecha";
            this.dtFecha.MinimumWidth = 90;
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.ToolTipText = "Fecha Vencimiento";
            this.dtFecha.Width = 90;
            // 
            // dtNit
            // 
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dtNit.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtNit.HeaderText = "Nit";
            this.dtNit.MinimumWidth = 95;
            this.dtNit.Name = "dtNit";
            this.dtNit.ToolTipText = "Nit Tercero";
            this.dtNit.Width = 95;
            // 
            // dtCentro
            // 
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.dtCentro.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtCentro.HeaderText = "Cto Costo";
            this.dtCentro.Name = "dtCentro";
            this.dtCentro.ToolTipText = "Centro de Costo";
            // 
            // dtCheque
            // 
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.dtCheque.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtCheque.HeaderText = "Cheque";
            this.dtCheque.Name = "dtCheque";
            this.dtCheque.ToolTipText = "Cheque";
            // 
            // gbMovimiento
            // 
            this.gbMovimiento.Controls.Add(this.txtDiferencia);
            this.gbMovimiento.Controls.Add(this.txtCredito);
            this.gbMovimiento.Controls.Add(this.txtDebito);
            this.gbMovimiento.Controls.Add(this.dgvDatos);
            this.gbMovimiento.Controls.Add(this.label9);
            this.gbMovimiento.Controls.Add(this.label10);
            this.gbMovimiento.Controls.Add(this.label8);
            this.gbMovimiento.Controls.Add(this.label7);
            this.gbMovimiento.Enabled = false;
            this.gbMovimiento.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(30)))), ((int)(((byte)(90)))));
            this.gbMovimiento.Location = new System.Drawing.Point(12, 213);
            this.gbMovimiento.Name = "gbMovimiento";
            this.gbMovimiento.Size = new System.Drawing.Size(1067, 272);
            this.gbMovimiento.TabIndex = 1;
            this.gbMovimiento.TabStop = false;
            this.gbMovimiento.Text = "Asiento Contable";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(357, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 25);
            this.label9.TabIndex = 213;
            this.label9.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(721, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 26);
            this.label10.TabIndex = 213;
            this.label10.Text = "=        $";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(396, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 26);
            this.label8.TabIndex = 213;
            this.label8.Text = "Credito $";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(26, 492);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 22);
            this.label11.TabIndex = 217;
            this.label11.Text = "Cuenta Contable";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(26, 524);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 22);
            this.label12.TabIndex = 217;
            this.label12.Text = "Observaciones";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
            this.lblCuenta.Location = new System.Drawing.Point(170, 492);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(64, 22);
            this.lblCuenta.TabIndex = 219;
            this.lblCuenta.Text = "Cuenta";
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblNuevo);
            this.FlowLayoutPanel1.Controls.Add(this.lblNuevoDoc);
            this.FlowLayoutPanel1.Controls.Add(this.lblGuardar);
            this.FlowLayoutPanel1.Controls.Add(this.lblCancelar);
            this.FlowLayoutPanel1.Controls.Add(this.lblEditar);
            this.FlowLayoutPanel1.Controls.Add(this.lblEliminar);
            this.FlowLayoutPanel1.Controls.Add(this.lblBuscar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Controls.Add(this.lblOperacion);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 577);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(1086, 66);
            this.FlowLayoutPanel1.TabIndex = 220;
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacion.Location = new System.Drawing.Point(746, 0);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(70, 20);
            this.lblOperacion.TabIndex = 8;
            this.lblOperacion.Text = "Consulta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPeriodo);
            this.groupBox1.Controls.Add(this.lblPrint);
            this.groupBox1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(761, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 164);
            this.groupBox1.TabIndex = 221;
            this.groupBox1.TabStop = false;
            // 
            // FrmDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1090, 645);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gbMovimiento);
            this.Controls.Add(this.gbGeneral);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenIzq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDocumentos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Documentos";
            this.Load += new System.EventHandler(this.FrmDocumentos_Load);
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.gbMovimiento.ResumeLayout(false);
            this.gbMovimiento.PerformLayout();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenTop;
        internal System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtNombreTer;
        private System.Windows.Forms.TextBox txtDesctipo;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider smsError;
        private System.Windows.Forms.MaskedTextBox txtPeriodo;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.TextBox txtVmto;
        private System.Windows.Forms.TextBox txtNomCentro;
        private System.Windows.Forms.TextBox txtCentro;
        private System.Windows.Forms.GroupBox gbMovimiento;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.TextBox txtCredito;
        private System.Windows.Forms.TextBox txtDebito;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblGuardar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblEditar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblNuevoDoc;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.Label lblEliminar;
        private System.Windows.Forms.Label lblPrint;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDebito;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDvmto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtNit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCentro;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtCheque;
    }
}