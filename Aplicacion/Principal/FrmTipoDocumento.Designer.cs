namespace Aplicacion.Principal
{
    partial class FrmTipoDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipoDocumento));
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblEditar = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.gbTipos = new System.Windows.Forms.GroupBox();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtInicial = new System.Windows.Forms.TextBox();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.lblPerActual = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPerInicio = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.smsError = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FlowLayoutPanel1.SuspendLayout();
            this.gbTipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).BeginInit();
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
            this.btnExit.Location = new System.Drawing.Point(510, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 233;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.lblTituloPrinc.Size = new System.Drawing.Size(536, 40);
            this.lblTituloPrinc.TabIndex = 232;
            this.lblTituloPrinc.Text = " SAE >> Tipos de Documentos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(94)))), ((int)(((byte)(117)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblNuevo);
            this.FlowLayoutPanel1.Controls.Add(this.lblGuardar);
            this.FlowLayoutPanel1.Controls.Add(this.lblCancelar);
            this.FlowLayoutPanel1.Controls.Add(this.lblEditar);
            this.FlowLayoutPanel1.Controls.Add(this.lblBuscar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Controls.Add(this.lblOperacion);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 222);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(536, 66);
            this.FlowLayoutPanel1.TabIndex = 234;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 290);
            this.lblMargenDer.TabIndex = 230;
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(538, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 290);
            this.lblMargenIzq.TabIndex = 231;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(536, 2);
            this.lblMargenTop.TabIndex = 235;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 288);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(536, 2);
            this.lblMargenInf.TabIndex = 236;
            // 
            // lblNuevo
            // 
            this.lblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNuevo.Enabled = false;
            this.lblNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNuevo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevo.ForeColor = System.Drawing.Color.White;
            this.lblNuevo.Image = global::Aplicacion.Properties.Resources.nuevo;
            this.lblNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNuevo.Location = new System.Drawing.Point(15, 0);
            this.lblNuevo.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblNuevo.Name = "lblNuevo";
            this.lblNuevo.Size = new System.Drawing.Size(58, 64);
            this.lblNuevo.TabIndex = 9;
            this.lblNuevo.Text = "&Nuevo";
            this.lblNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblNuevo, "Nuevo Registro");
            this.lblNuevo.Click += new System.EventHandler(this.lblNuevo_Click);
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
            this.lblGuardar.TabIndex = 10;
            this.lblGuardar.Text = "&Guardar";
            this.lblGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblGuardar, "Guardar Registro");
            this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
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
            this.lblCancelar.TabIndex = 11;
            this.lblCancelar.Text = "&Cancelar";
            this.lblCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblCancelar, "Cancelar Operacion");
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            // 
            // lblEditar
            // 
            this.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEditar.Enabled = false;
            this.lblEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditar.ForeColor = System.Drawing.Color.White;
            this.lblEditar.Image = global::Aplicacion.Properties.Resources.editar;
            this.lblEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEditar.Location = new System.Drawing.Point(243, 0);
            this.lblEditar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(58, 64);
            this.lblEditar.TabIndex = 12;
            this.lblEditar.Text = "&Editar";
            this.lblEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblEditar, "Editar Registro");
            this.lblEditar.Click += new System.EventHandler(this.lblEditar_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBuscar.Enabled = false;
            this.lblBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.White;
            this.lblBuscar.Image = global::Aplicacion.Properties.Resources.buscar;
            this.lblBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblBuscar.Location = new System.Drawing.Point(319, 0);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(58, 64);
            this.lblBuscar.TabIndex = 13;
            this.lblBuscar.Text = "&Buscar";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblBuscar, "Buscar Registro");
            this.lblBuscar.Click += new System.EventHandler(this.lblBuscar_Click);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(395, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(58, 64);
            this.lblSalir.TabIndex = 14;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacion.Location = new System.Drawing.Point(459, 44);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(70, 20);
            this.lblOperacion.TabIndex = 16;
            this.lblOperacion.Text = "Consulta";
            // 
            // gbTipos
            // 
            this.gbTipos.Controls.Add(this.cboGrupo);
            this.gbTipos.Controls.Add(this.Label12);
            this.gbTipos.Controls.Add(this.txtInicial);
            this.gbTipos.Controls.Add(this.txtActual);
            this.gbTipos.Controls.Add(this.Label11);
            this.gbTipos.Controls.Add(this.Label10);
            this.gbTipos.Controls.Add(this.Label9);
            this.gbTipos.Controls.Add(this.lblPerActual);
            this.gbTipos.Controls.Add(this.txtDescripcion);
            this.gbTipos.Controls.Add(this.lblPerInicio);
            this.gbTipos.Controls.Add(this.Label5);
            this.gbTipos.Controls.Add(this.txtTipo);
            this.gbTipos.Enabled = false;
            this.gbTipos.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipos.Location = new System.Drawing.Point(12, 45);
            this.gbTipos.Name = "gbTipos";
            this.gbTipos.Size = new System.Drawing.Size(516, 173);
            this.gbTipos.TabIndex = 237;
            this.gbTipos.TabStop = false;
            // 
            // cboGrupo
            // 
            this.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboGrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(193, 25);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(305, 29);
            this.cboGrupo.Sorted = true;
            this.cboGrupo.TabIndex = 25;
            this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboGrupo_SelectedIndexChanged);
            this.cboGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboGrupo_KeyPress);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label12.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(11, 28);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(176, 22);
            this.Label12.TabIndex = 24;
            this.Label12.Text = "Grupo de Documento";
            // 
            // txtInicial
            // 
            this.txtInicial.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtInicial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicial.Location = new System.Drawing.Point(150, 134);
            this.txtInicial.MaxLength = 6;
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(71, 29);
            this.txtInicial.TabIndex = 16;
            this.txtInicial.Text = "0";
            this.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInicial_KeyPress);
            this.txtInicial.Leave += new System.EventHandler(this.txtInicial_Leave);
            // 
            // txtActual
            // 
            this.txtActual.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActual.Location = new System.Drawing.Point(427, 134);
            this.txtActual.MaxLength = 6;
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(71, 29);
            this.txtActual.TabIndex = 17;
            this.txtActual.Text = "0";
            this.txtActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInicial_KeyPress);
            this.txtActual.Leave += new System.EventHandler(this.txtActual_Leave);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label11.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(11, 99);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(100, 22);
            this.Label11.TabIndex = 23;
            this.Label11.Text = "Descripción";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label10.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(288, 137);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(58, 22);
            this.Label10.TabIndex = 22;
            this.Label10.Text = "Actual";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label9.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(11, 62);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(170, 22);
            this.Label9.TabIndex = 21;
            this.Label9.Text = "Sigla del  Documento";
            // 
            // lblPerActual
            // 
            this.lblPerActual.AutoSize = true;
            this.lblPerActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPerActual.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerActual.ForeColor = System.Drawing.Color.Black;
            this.lblPerActual.Location = new System.Drawing.Point(353, 137);
            this.lblPerActual.Name = "lblPerActual";
            this.lblPerActual.Size = new System.Drawing.Size(70, 22);
            this.lblPerActual.TabIndex = 20;
            this.lblPerActual.Text = "00/0000";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(193, 96);
            this.txtDescripcion.MaxLength = 30;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(305, 29);
            this.txtDescripcion.TabIndex = 15;
            // 
            // lblPerInicio
            // 
            this.lblPerInicio.AutoSize = true;
            this.lblPerInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPerInicio.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerInicio.ForeColor = System.Drawing.Color.Black;
            this.lblPerInicio.Location = new System.Drawing.Point(76, 137);
            this.lblPerInicio.Name = "lblPerInicio";
            this.lblPerInicio.Size = new System.Drawing.Size(70, 22);
            this.lblPerInicio.TabIndex = 19;
            this.lblPerInicio.Text = "00/0000";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label5.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(14, 137);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(51, 22);
            this.Label5.TabIndex = 18;
            this.Label5.Text = "Inicio";
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(193, 59);
            this.txtTipo.MaxLength = 2;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(56, 29);
            this.txtTipo.TabIndex = 14;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Open Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Crimson;
            this.lblMensaje.Location = new System.Drawing.Point(71, 92);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(404, 74);
            this.lblMensaje.TabIndex = 202;
            this.lblMensaje.Text = "Usted NO Tiene Permisos para\r\n Realizar esta Operación";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.Visible = false;
            // 
            // smsError
            // 
            this.smsError.ContainerControl = this;
            this.smsError.Icon = ((System.Drawing.Icon)(resources.GetObject("smsError.Icon")));
            // 
            // FrmTipoDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(540, 290);
            this.Controls.Add(this.gbTipos);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTipoDocumento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTipoDocumentos";
            this.Load += new System.EventHandler(this.FrmTipoDocumento_Load);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.gbTipos.ResumeLayout(false);
            this.gbTipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenTop;
        internal System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblGuardar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblEditar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.GroupBox gbTipos;
        internal System.Windows.Forms.ComboBox cboGrupo;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtInicial;
        internal System.Windows.Forms.TextBox txtActual;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label lblPerActual;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Label lblPerInicio;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.ErrorProvider smsError;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}