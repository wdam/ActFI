namespace Aplicacion.Inventario
{
    partial class FrmTraslados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTraslados));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.smsError = new System.Windows.Forms.ErrorProvider(this.components);
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.gbTraslado = new System.Windows.Forms.GroupBox();
            this.txtNitResp = new System.Windows.Forms.TextBox();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.txtNuevoRespon = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).BeginInit();
            this.FlowLayoutPanel1.SuspendLayout();
            this.gbTraslado.SuspendLayout();
            this.gbDatos.SuspendLayout();
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
            this.btnExit.Location = new System.Drawing.Point(486, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 201;
            this.btnExit.Text = "X";
            this.toolTip1.SetToolTip(this.btnExit, "Esc Para Salir");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // 
            // lblGuardar
            // 
            this.lblGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // 
            // lblCancelar
            // 
            this.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSalir.Location = new System.Drawing.Point(243, 0);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(58, 64);
            this.lblSalir.TabIndex = 5;
            this.lblSalir.Text = "&Salir";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblSalir, "Salir ");
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(125, 35);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(156, 29);
            this.txtCodigo.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtCodigo, "Ingrese el Codigo, y Presione Enter");
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.DoubleClick += new System.EventHandler(this.txtCodigo_DoubleClick);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // smsError
            // 
            this.smsError.ContainerControl = this;
            this.smsError.Icon = ((System.Drawing.Icon)(resources.GetObject("smsError.Icon")));
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(150)))), ((int)(((byte)(30)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblNuevo);
            this.FlowLayoutPanel1.Controls.Add(this.lblGuardar);
            this.FlowLayoutPanel1.Controls.Add(this.lblCancelar);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Controls.Add(this.lblOperacion);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 397);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(510, 66);
            this.FlowLayoutPanel1.TabIndex = 200;
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacion.Location = new System.Drawing.Point(307, 0);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(70, 20);
            this.lblOperacion.TabIndex = 9;
            this.lblOperacion.Text = "Consulta";
            // 
            // gbTraslado
            // 
            this.gbTraslado.Controls.Add(this.txtNitResp);
            this.gbTraslado.Controls.Add(this.cboArea);
            this.gbTraslado.Controls.Add(this.txtNuevoRespon);
            this.gbTraslado.Controls.Add(this.Label3);
            this.gbTraslado.Controls.Add(this.Label6);
            this.gbTraslado.Enabled = false;
            this.gbTraslado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTraslado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(97)))), ((int)(((byte)(117)))));
            this.gbTraslado.Location = new System.Drawing.Point(13, 271);
            this.gbTraslado.Name = "gbTraslado";
            this.gbTraslado.Size = new System.Drawing.Size(488, 116);
            this.gbTraslado.TabIndex = 198;
            this.gbTraslado.TabStop = false;
            this.gbTraslado.Text = "Trasladar A";
            // 
            // txtNitResp
            // 
            this.txtNitResp.Location = new System.Drawing.Point(113, 73);
            this.txtNitResp.Name = "txtNitResp";
            this.txtNitResp.Size = new System.Drawing.Size(100, 29);
            this.txtNitResp.TabIndex = 5;
            this.txtNitResp.TextChanged += new System.EventHandler(this.txtNitResp_TextChanged);
            this.txtNitResp.DoubleClick += new System.EventHandler(this.txtNitResp_DoubleClick);
            // 
            // cboArea
            // 
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(83, 36);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(310, 29);
            this.cboArea.TabIndex = 4;
            // 
            // txtNuevoRespon
            // 
            this.txtNuevoRespon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.txtNuevoRespon.Enabled = false;
            this.txtNuevoRespon.Location = new System.Drawing.Point(216, 73);
            this.txtNuevoRespon.Name = "txtNuevoRespon";
            this.txtNuevoRespon.Size = new System.Drawing.Size(260, 29);
            this.txtNuevoRespon.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(12, 77);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(98, 21);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Responsable";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(12, 40);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 21);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Area";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.dateTimePicker1);
            this.gbDatos.Controls.Add(this.txtDescripcion);
            this.gbDatos.Controls.Add(this.txtArea);
            this.gbDatos.Controls.Add(this.txtResponsable);
            this.gbDatos.Controls.Add(this.txtCodigo);
            this.gbDatos.Controls.Add(this.Label10);
            this.gbDatos.Controls.Add(this.Label5);
            this.gbDatos.Controls.Add(this.Label4);
            this.gbDatos.Controls.Add(this.Label1);
            this.gbDatos.Enabled = false;
            this.gbDatos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(97)))), ((int)(((byte)(117)))));
            this.gbDatos.Location = new System.Drawing.Point(13, 47);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(488, 220);
            this.gbDatos.TabIndex = 199;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos Actuales";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(125, 71);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(329, 65);
            this.txtDescripcion.TabIndex = 12;
            // 
            // txtArea
            // 
            this.txtArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.txtArea.Enabled = false;
            this.txtArea.Location = new System.Drawing.Point(125, 143);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(329, 29);
            this.txtArea.TabIndex = 4;
            // 
            // txtResponsable
            // 
            this.txtResponsable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.txtResponsable.Enabled = false;
            this.txtResponsable.Location = new System.Drawing.Point(125, 178);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.ReadOnly = true;
            this.txtResponsable.Size = new System.Drawing.Size(329, 29);
            this.txtResponsable.TabIndex = 3;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(12, 93);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(91, 21);
            this.Label10.TabIndex = 0;
            this.Label10.Text = "Descripcion";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(12, 181);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(98, 21);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Responsable";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(12, 147);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(42, 21);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Area";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(12, 39);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(107, 21);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Código Activo";
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(512, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 465);
            this.lblMargenIzq.TabIndex = 204;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 465);
            this.lblMargenDer.TabIndex = 203;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(510, 2);
            this.lblMargenTop.TabIndex = 202;
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(150)))), ((int)(((byte)(30)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(510, 40);
            this.lblTituloPrinc.TabIndex = 205;
            this.lblTituloPrinc.Text = " SAE >> Traslados";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 463);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(510, 2);
            this.lblMargenInf.TabIndex = 206;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(293, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(161, 29);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // FrmTraslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(514, 465);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.gbTraslado);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblMargenDer);
            this.Controls.Add(this.lblMargenIzq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTraslados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTraslados";
            this.Load += new System.EventHandler(this.FrmTraslados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.smsError)).EndInit();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.gbTraslado.ResumeLayout(false);
            this.gbTraslado.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider smsError;
        internal System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblGuardar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.GroupBox gbTraslado;
        private System.Windows.Forms.TextBox txtNuevoRespon;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.TextBox txtNitResp;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}