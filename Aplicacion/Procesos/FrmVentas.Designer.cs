namespace Aplicacion.Procesos
{
    partial class FrmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblpdf = new System.Windows.Forms.Label();
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.lblMargenIzq = new System.Windows.Forms.Label();
            this.lblMargenDer = new System.Windows.Forms.Label();
            this.lblMargenInf = new System.Windows.Forms.Label();
            this.lblMargenTop = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtValLibros = new System.Windows.Forms.TextBox();
            this.txtDepreciacion = new System.Windows.Forms.TextBox();
            this.txtValCompra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbVenta = new System.Windows.Forms.GroupBox();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.txtValVenta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.gbVenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.FlowLayoutPanel1.Controls.Add(this.lblNuevo);
            this.FlowLayoutPanel1.Controls.Add(this.lblGuardar);
            this.FlowLayoutPanel1.Controls.Add(this.lblCancelar);
            this.FlowLayoutPanel1.Controls.Add(this.lblpdf);
            this.FlowLayoutPanel1.Controls.Add(this.lblSalir);
            this.FlowLayoutPanel1.Controls.Add(this.lblOperacion);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(2, 385);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(590, 66);
            this.FlowLayoutPanel1.TabIndex = 171;
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
            this.toolTip1.SetToolTip(this.lblNuevo, "Nueva Venta");
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
            this.lblGuardar.Location = new System.Drawing.Point(91, 0);
            this.lblGuardar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(58, 64);
            this.lblGuardar.TabIndex = 1;
            this.lblGuardar.Text = "&Guardar";
            this.lblGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.lblCancelar.Location = new System.Drawing.Point(167, 0);
            this.lblCancelar.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(58, 64);
            this.lblCancelar.TabIndex = 2;
            this.lblCancelar.Text = "&Cancelar";
            this.lblCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblCancelar, "Cancelar Venta");
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            this.lblCancelar.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblpdf
            // 
            this.lblpdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblpdf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpdf.ForeColor = System.Drawing.Color.White;
            this.lblpdf.Image = global::Aplicacion.Properties.Resources.exportar;
            this.lblpdf.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblpdf.Location = new System.Drawing.Point(243, 0);
            this.lblpdf.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lblpdf.Name = "lblpdf";
            this.lblpdf.Size = new System.Drawing.Size(58, 64);
            this.lblpdf.TabIndex = 6;
            this.lblpdf.Text = "&Pdf";
            this.lblpdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblpdf, "Imprimir Recibo");
            this.lblpdf.MouseLeave += new System.EventHandler(this.QuitarColorFondo);
            this.lblpdf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColocarColorFondo);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.Color.White;
            this.lblSalir.Image = global::Aplicacion.Properties.Resources.exit1;
            this.lblSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSalir.Location = new System.Drawing.Point(319, 0);
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
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacion.Location = new System.Drawing.Point(383, 0);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(70, 20);
            this.lblOperacion.TabIndex = 8;
            this.lblOperacion.Text = "Consulta";
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
            this.btnExit.Location = new System.Drawing.Point(566, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 26);
            this.btnExit.TabIndex = 170;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.lblTituloPrinc.Location = new System.Drawing.Point(2, 2);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(590, 45);
            this.lblTituloPrinc.TabIndex = 169;
            this.lblTituloPrinc.Text = " SAE  >> Venta de Activos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloPrinc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseDown);
            this.lblTituloPrinc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseMove);
            this.lblTituloPrinc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTituloPrinc_MouseUp);
            // 
            // lblMargenIzq
            // 
            this.lblMargenIzq.BackColor = System.Drawing.Color.Black;
            this.lblMargenIzq.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMargenIzq.Location = new System.Drawing.Point(592, 0);
            this.lblMargenIzq.Name = "lblMargenIzq";
            this.lblMargenIzq.Size = new System.Drawing.Size(2, 453);
            this.lblMargenIzq.TabIndex = 168;
            // 
            // lblMargenDer
            // 
            this.lblMargenDer.BackColor = System.Drawing.Color.Black;
            this.lblMargenDer.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMargenDer.Location = new System.Drawing.Point(0, 0);
            this.lblMargenDer.Name = "lblMargenDer";
            this.lblMargenDer.Size = new System.Drawing.Size(2, 453);
            this.lblMargenDer.TabIndex = 167;
            // 
            // lblMargenInf
            // 
            this.lblMargenInf.BackColor = System.Drawing.Color.Black;
            this.lblMargenInf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMargenInf.Location = new System.Drawing.Point(2, 451);
            this.lblMargenInf.Name = "lblMargenInf";
            this.lblMargenInf.Size = new System.Drawing.Size(590, 2);
            this.lblMargenInf.TabIndex = 173;
            // 
            // lblMargenTop
            // 
            this.lblMargenTop.BackColor = System.Drawing.Color.Black;
            this.lblMargenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMargenTop.Location = new System.Drawing.Point(2, 0);
            this.lblMargenTop.Name = "lblMargenTop";
            this.lblMargenTop.Size = new System.Drawing.Size(590, 2);
            this.lblMargenTop.TabIndex = 172;
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.Color.White;
            this.gbDatos.Controls.Add(this.txtDescripcion);
            this.gbDatos.Controls.Add(this.dateTimePicker1);
            this.gbDatos.Controls.Add(this.txtValLibros);
            this.gbDatos.Controls.Add(this.txtDepreciacion);
            this.gbDatos.Controls.Add(this.txtValCompra);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.label7);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.lblBuscar);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.txtCodigo);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Enabled = false;
            this.gbDatos.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.Color.Crimson;
            this.gbDatos.Location = new System.Drawing.Point(10, 49);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(574, 186);
            this.gbDatos.TabIndex = 174;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Activo";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(132, 66);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(429, 64);
            this.txtDescripcion.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(434, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 29);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // txtValLibros
            // 
            this.txtValLibros.BackColor = System.Drawing.Color.White;
            this.txtValLibros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValLibros.Enabled = false;
            this.txtValLibros.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValLibros.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtValLibros.Location = new System.Drawing.Point(446, 161);
            this.txtValLibros.Name = "txtValLibros";
            this.txtValLibros.ReadOnly = true;
            this.txtValLibros.Size = new System.Drawing.Size(107, 22);
            this.txtValLibros.TabIndex = 4;
            this.txtValLibros.Text = "0";
            this.txtValLibros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDepreciacion
            // 
            this.txtDepreciacion.BackColor = System.Drawing.Color.White;
            this.txtDepreciacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDepreciacion.Enabled = false;
            this.txtDepreciacion.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepreciacion.ForeColor = System.Drawing.Color.Crimson;
            this.txtDepreciacion.Location = new System.Drawing.Point(231, 161);
            this.txtDepreciacion.Name = "txtDepreciacion";
            this.txtDepreciacion.ReadOnly = true;
            this.txtDepreciacion.Size = new System.Drawing.Size(120, 22);
            this.txtDepreciacion.TabIndex = 4;
            this.txtDepreciacion.Text = "0";
            this.txtDepreciacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValCompra
            // 
            this.txtValCompra.BackColor = System.Drawing.Color.White;
            this.txtValCompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValCompra.Enabled = false;
            this.txtValCompra.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(169)))));
            this.txtValCompra.Location = new System.Drawing.Point(21, 161);
            this.txtValCompra.Name = "txtValCompra";
            this.txtValCompra.ReadOnly = true;
            this.txtValCompra.Size = new System.Drawing.Size(120, 22);
            this.txtValCompra.TabIndex = 4;
            this.txtValCompra.Text = "0";
            this.txtValCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(310, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fecha de venta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(440, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Valor en Libros";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(190, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Depreciación Acumulada";
            // 
            // lblBuscar
            // 
            this.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBuscar.Image = ((System.Drawing.Image)(resources.GetObject("lblBuscar.Image")));
            this.lblBuscar.Location = new System.Drawing.Point(229, 32);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(24, 24);
            this.lblBuscar.TabIndex = 3;
            this.toolTip1.SetToolTip(this.lblBuscar, "Buscar Activo");
            this.lblBuscar.Click += new System.EventHandler(this.lblBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Valor Adquisición";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(94, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(134, 29);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // gbVenta
            // 
            this.gbVenta.BackColor = System.Drawing.Color.White;
            this.gbVenta.Controls.Add(this.txtUtilidad);
            this.gbVenta.Controls.Add(this.txtValVenta);
            this.gbVenta.Controls.Add(this.label9);
            this.gbVenta.Controls.Add(this.label8);
            this.gbVenta.Enabled = false;
            this.gbVenta.Location = new System.Drawing.Point(10, 236);
            this.gbVenta.Name = "gbVenta";
            this.gbVenta.Size = new System.Drawing.Size(574, 129);
            this.gbVenta.TabIndex = 175;
            this.gbVenta.TabStop = false;
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.BackColor = System.Drawing.Color.White;
            this.txtUtilidad.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUtilidad.Location = new System.Drawing.Point(389, 94);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.ReadOnly = true;
            this.txtUtilidad.Size = new System.Drawing.Size(172, 29);
            this.txtUtilidad.TabIndex = 1;
            this.txtUtilidad.TextChanged += new System.EventHandler(this.txtUtilidad_TextChanged);
            // 
            // txtValVenta
            // 
            this.txtValVenta.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValVenta.Location = new System.Drawing.Point(121, 16);
            this.txtValVenta.Name = "txtValVenta";
            this.txtValVenta.Size = new System.Drawing.Size(172, 29);
            this.txtValVenta.TabIndex = 0;
            this.txtValVenta.TextChanged += new System.EventHandler(this.txtValVenta_TextChanged);
            this.txtValVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValVenta_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(237, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "Utilidad o Perdida";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(17, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Valor Venta";
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(594, 453);
            this.Controls.Add(this.gbVenta);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.lblMargenTop);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.lblMargenInf);
            this.Controls.Add(this.lblMargenIzq);
            this.Controls.Add(this.lblMargenDer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVentas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.FlowLayoutPanel1.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbVenta.ResumeLayout(false);
            this.gbVenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblGuardar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblpdf;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.Label lblMargenIzq;
        private System.Windows.Forms.Label lblMargenDer;
        private System.Windows.Forms.Label lblMargenInf;
        private System.Windows.Forms.Label lblMargenTop;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtValCompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValLibros;
        private System.Windows.Forms.TextBox txtDepreciacion;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbVenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValVenta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUtilidad;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}