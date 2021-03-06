﻿namespace Aplicacion.Inventario
{
    partial class FrmAreaResp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAreaResp));
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblEditar = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.gbArea = new System.Windows.Forms.GroupBox();
            this.txtNombreResp = new System.Windows.Forms.TextBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtNomArea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.dtcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smsError = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1.SuspendLayout();
            this.gbArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).BeginInit();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(120)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblNuevo);
            this.FlowLayoutPanel1.Controls.Add(this.lblGuardar);
            this.FlowLayoutPanel1.Controls.Add(this.lblCancelar);
            this.FlowLayoutPanel1.Controls.Add(this.lblEditar);
            this.FlowLayoutPanel1.Controls.Add(this.lblBuscar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Controls.Add(this.lblEstado);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 455);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(622, 66);
            this.FlowLayoutPanel1.TabIndex = 184;
            // 
            // lblNuevo
            // 
            this.lblNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.toolTip1.SetToolTip(this.lblNuevo, "Nuevo Registro");
            this.lblNuevo.Click += new System.EventHandler(this.lblNuevo_Click);
            this.lblNuevo.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblNuevo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblGuardar
            // 
            this.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGuardar.Enabled = false;
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
            this.toolTip1.SetToolTip(this.lblGuardar, "Guardar Registro");
            this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.lblGuardar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblGuardar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblCancelar
            // 
            this.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancelar.Enabled = false;
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
            this.toolTip1.SetToolTip(this.lblCancelar, "Cancelar Operacion");
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            this.lblCancelar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblEditar
            // 
            this.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditar.ForeColor = System.Drawing.Color.White;
            this.lblEditar.Image = global::Aplicacion.Properties.Resources.Refresh;
            this.lblEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEditar.Location = new System.Drawing.Point(243, 0);
            this.lblEditar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(58, 64);
            this.lblEditar.TabIndex = 3;
            this.lblEditar.Text = "&Editar";
            this.lblEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblEditar, "Modificar Registro");
            this.lblEditar.Click += new System.EventHandler(this.lblEditar_Click);
            this.lblEditar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblEditar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.toolTip1.SetToolTip(this.lblBuscar, "Buscar Registro");
            this.lblBuscar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblBuscar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(395, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(58, 64);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            this.lblSalir.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblSalir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(459, 43);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(61, 21);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Estado";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Jokerman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(597, 4);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 185;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(130)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(622, 45);
            this.lblTituloPrinc.TabIndex = 183;
            this.lblTituloPrinc.Text = " SAE  >> Areas ";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloPrinc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseDown);
            this.lblTituloPrinc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseMove);
            this.lblTituloPrinc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseUp);
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(624, 2);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 521);
            this.lblMargenIzq.TabIndex = 182;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 2);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 521);
            this.lblMargenDer.TabIndex = 181;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(0, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(626, 2);
            this.lblMargenTop.TabIndex = 180;
            // 
            // gbArea
            // 
            this.gbArea.Controls.Add(this.txtNombreResp);
            this.gbArea.Controls.Add(this.txtNit);
            this.gbArea.Controls.Add(this.txtNomArea);
            this.gbArea.Controls.Add(this.label2);
            this.gbArea.Controls.Add(this.txtCodigo);
            this.gbArea.Controls.Add(this.Label5);
            this.gbArea.Controls.Add(this.Label1);
            this.gbArea.Enabled = false;
            this.gbArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(97)))), ((int)(((byte)(117)))));
            this.gbArea.Location = new System.Drawing.Point(14, 55);
            this.gbArea.Name = "gbArea";
            this.gbArea.Size = new System.Drawing.Size(599, 144);
            this.gbArea.TabIndex = 186;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "Crear y Editar Areas";
            // 
            // txtNombreResp
            // 
            this.txtNombreResp.BackColor = System.Drawing.Color.White;
            this.txtNombreResp.Enabled = false;
            this.txtNombreResp.Location = new System.Drawing.Point(243, 103);
            this.txtNombreResp.MaxLength = 100;
            this.txtNombreResp.Name = "txtNombreResp";
            this.txtNombreResp.Size = new System.Drawing.Size(321, 29);
            this.txtNombreResp.TabIndex = 3;
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(121, 103);
            this.txtNit.MaxLength = 100;
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(118, 29);
            this.txtNit.TabIndex = 3;
            this.txtNit.TextChanged += new System.EventHandler(this.txtNit_TextChanged);
            this.txtNit.DoubleClick += new System.EventHandler(this.txtNit_DoubleClick);
            // 
            // txtNomArea
            // 
            this.txtNomArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomArea.Location = new System.Drawing.Point(121, 65);
            this.txtNomArea.MaxLength = 60;
            this.txtNomArea.Name = "txtNomArea";
            this.txtNomArea.Size = new System.Drawing.Size(443, 29);
            this.txtNomArea.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Responsable";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(121, 30);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(68, 29);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Text = "0000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(44, 68);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(73, 22);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Nombre";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(54, 33);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 22);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codigo";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Crimson;
            this.lblMensaje.Location = new System.Drawing.Point(90, 325);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(403, 33);
            this.lblMensaje.TabIndex = 201;
            this.lblMensaje.Text = "No Existen Areas Creada.. Verifique";
            this.lblMensaje.Visible = false;
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvArea.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArea.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvArea.BackgroundColor = System.Drawing.Color.White;
            this.dgvArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArea.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvArea.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(140)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArea.ColumnHeadersHeight = 30;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtcodigo,
            this.dtNombre,
            this.dtResponsable});
            this.dgvArea.EnableHeadersVisualStyles = false;
            this.dgvArea.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvArea.Location = new System.Drawing.Point(14, 205);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.ReadOnly = true;
            this.dgvArea.RowHeadersVisible = false;
            this.dgvArea.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvArea.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArea.Size = new System.Drawing.Size(599, 242);
            this.dgvArea.TabIndex = 200;
            this.dgvArea.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArea_CellContentClick);
            // 
            // dtcodigo
            // 
            this.dtcodigo.DataPropertyName = "codigo";
            this.dtcodigo.HeaderText = "Codigo";
            this.dtcodigo.MinimumWidth = 50;
            this.dtcodigo.Name = "dtcodigo";
            this.dtcodigo.ReadOnly = true;
            this.dtcodigo.Width = 90;
            // 
            // dtNombre
            // 
            this.dtNombre.DataPropertyName = "nombre";
            this.dtNombre.HeaderText = "Nombre";
            this.dtNombre.MinimumWidth = 200;
            this.dtNombre.Name = "dtNombre";
            this.dtNombre.ReadOnly = true;
            this.dtNombre.Width = 250;
            // 
            // dtResponsable
            // 
            this.dtResponsable.DataPropertyName = "responsable";
            this.dtResponsable.HeaderText = "Responsable";
            this.dtResponsable.MinimumWidth = 255;
            this.dtResponsable.Name = "dtResponsable";
            this.dtResponsable.ReadOnly = true;
            this.dtResponsable.Width = 255;
            // 
            // smsError
            // 
            this.smsError.ContainerControl = this;
            this.smsError.Icon = ((System.Drawing.Icon)(resources.GetObject("smsError.Icon")));
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 521);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(622, 2);
            this.lblMargenInf.TabIndex = 202;
            // 
            // FrmAreaResp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(626, 523);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.dgvArea);
            this.Controls.Add(this.gbArea);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAreaResp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAreaResp";
            this.Load += new System.EventHandler(this.FrmAreaResp_Load);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.gbArea.ResumeLayout(false);
            this.gbArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Label lblNuevo;
        internal System.Windows.Forms.Label lblGuardar;
        internal System.Windows.Forms.Label lblCancelar;
        internal System.Windows.Forms.Label lblEditar;
        internal System.Windows.Forms.Label lblBuscar;
        internal System.Windows.Forms.Label lblSalir;
        internal System.Windows.Forms.Label lblEstado;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Label lblTituloPrinc;
        internal System.Windows.Forms.Label lblMargenIzq;
        internal System.Windows.Forms.Label lblMargenDer;
        internal System.Windows.Forms.Label lblMargenTop;
        internal System.Windows.Forms.GroupBox gbArea;
        internal System.Windows.Forms.TextBox txtNomArea;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblMensaje;
        internal System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.ErrorProvider smsError;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label lblMargenInf;
        internal System.Windows.Forms.TextBox txtNit;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtNombreResp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtResponsable;
    }
}