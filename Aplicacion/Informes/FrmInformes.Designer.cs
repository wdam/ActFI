namespace Aplicacion.Informes
{
    partial class FrmInformes
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGrupos = new System.Windows.Forms.Label();
            this.lblTraslados = new System.Windows.Forms.Label();
            this.lblAreas = new System.Windows.Forms.Label();
            this.lblCerrar = new System.Windows.Forms.Label();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblMovimientos = new System.Windows.Forms.Label();
            this.lblDepreciacion = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloPrinc
            // 
            this.lblTituloPrinc.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloPrinc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrinc.Font = new System.Drawing.Font("Open Sans", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPrinc.ForeColor = System.Drawing.Color.White;
            this.lblTituloPrinc.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPrinc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblTituloPrinc.Name = "lblTituloPrinc";
            this.lblTituloPrinc.Size = new System.Drawing.Size(810, 40);
            this.lblTituloPrinc.TabIndex = 170;
            this.lblTituloPrinc.Text = "Informes ";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 3;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.Controls.Add(this.lblGrupos, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.lblTraslados, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.lblAreas, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.lblCerrar, 2, 2);
            this.TableLayoutPanel1.Controls.Add(this.lblHistorial, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.lblMovimientos, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.lblDepreciacion, 2, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(42, 96);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(726, 353);
            this.TableLayoutPanel1.TabIndex = 171;
            // 
            // lblGrupos
            // 
            this.lblGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrupos.BackColor = System.Drawing.Color.Transparent;
            this.lblGrupos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGrupos.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupos.ForeColor = System.Drawing.Color.White;
            this.lblGrupos.Image = global::Aplicacion.Properties.Resources.grupo;
            this.lblGrupos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGrupos.Location = new System.Drawing.Point(492, 125);
            this.lblGrupos.Margin = new System.Windows.Forms.Padding(8);
            this.lblGrupos.Name = "lblGrupos";
            this.lblGrupos.Size = new System.Drawing.Size(226, 100);
            this.lblGrupos.TabIndex = 132;
            this.lblGrupos.Text = "Grupos y Subgrupos";
            this.lblGrupos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblGrupos.Click += new System.EventHandler(this.lblGrupos_Click);
            // 
            // lblTraslados
            // 
            this.lblTraslados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTraslados.BackColor = System.Drawing.Color.Transparent;
            this.lblTraslados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTraslados.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraslados.ForeColor = System.Drawing.Color.White;
            this.lblTraslados.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTraslados.Location = new System.Drawing.Point(250, 125);
            this.lblTraslados.Margin = new System.Windows.Forms.Padding(8);
            this.lblTraslados.Name = "lblTraslados";
            this.lblTraslados.Size = new System.Drawing.Size(226, 100);
            this.lblTraslados.TabIndex = 132;
            this.lblTraslados.Text = "Centro de Costo";
            this.lblTraslados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTraslados.Visible = false;
            // 
            // lblAreas
            // 
            this.lblAreas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreas.BackColor = System.Drawing.Color.Transparent;
            this.lblAreas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAreas.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreas.ForeColor = System.Drawing.Color.White;
            this.lblAreas.Image = global::Aplicacion.Properties.Resources.Area;
            this.lblAreas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAreas.Location = new System.Drawing.Point(250, 8);
            this.lblAreas.Margin = new System.Windows.Forms.Padding(8);
            this.lblAreas.Name = "lblAreas";
            this.lblAreas.Size = new System.Drawing.Size(226, 100);
            this.lblAreas.TabIndex = 132;
            this.lblAreas.Text = "Ubicacion";
            this.lblAreas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAreas.Click += new System.EventHandler(this.lblAreas_Click);
            // 
            // lblCerrar
            // 
            this.lblCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCerrar.BackColor = System.Drawing.Color.Transparent;
            this.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrar.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrar.ForeColor = System.Drawing.Color.White;
            this.lblCerrar.Image = global::Aplicacion.Properties.Resources.Atras;
            this.lblCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCerrar.Location = new System.Drawing.Point(492, 242);
            this.lblCerrar.Margin = new System.Windows.Forms.Padding(8);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(226, 100);
            this.lblCerrar.TabIndex = 132;
            this.lblCerrar.Text = "Cerrar";
            this.lblCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // lblHistorial
            // 
            this.lblHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHistorial.BackColor = System.Drawing.Color.Transparent;
            this.lblHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHistorial.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorial.ForeColor = System.Drawing.Color.White;
            this.lblHistorial.Image = global::Aplicacion.Properties.Resources.traslados;
            this.lblHistorial.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblHistorial.Location = new System.Drawing.Point(8, 8);
            this.lblHistorial.Margin = new System.Windows.Forms.Padding(8);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(226, 100);
            this.lblHistorial.TabIndex = 133;
            this.lblHistorial.Text = "Historial de Activos";
            this.lblHistorial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblHistorial.Click += new System.EventHandler(this.lblHistorial_Click);
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label2.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label2.Location = new System.Drawing.Point(8, 242);
            this.Label2.Margin = new System.Windows.Forms.Padding(8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(226, 100);
            this.Label2.TabIndex = 132;
            this.Label2.Text = "Mejoras y Reparaciones";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Label2.Visible = false;
            // 
            // lblMovimientos
            // 
            this.lblMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMovimientos.BackColor = System.Drawing.Color.Transparent;
            this.lblMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMovimientos.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovimientos.ForeColor = System.Drawing.Color.White;
            this.lblMovimientos.Image = global::Aplicacion.Properties.Resources.movimientos;
            this.lblMovimientos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMovimientos.Location = new System.Drawing.Point(8, 125);
            this.lblMovimientos.Margin = new System.Windows.Forms.Padding(8);
            this.lblMovimientos.Name = "lblMovimientos";
            this.lblMovimientos.Size = new System.Drawing.Size(226, 100);
            this.lblMovimientos.TabIndex = 132;
            this.lblMovimientos.Text = "Movimientos";
            this.lblMovimientos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblMovimientos.Click += new System.EventHandler(this.lblMovimientos_Click);
            // 
            // lblDepreciacion
            // 
            this.lblDepreciacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDepreciacion.BackColor = System.Drawing.Color.Transparent;
            this.lblDepreciacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDepreciacion.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepreciacion.ForeColor = System.Drawing.Color.White;
            this.lblDepreciacion.Image = global::Aplicacion.Properties.Resources.depreciacion;
            this.lblDepreciacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDepreciacion.Location = new System.Drawing.Point(492, 8);
            this.lblDepreciacion.Margin = new System.Windows.Forms.Padding(8);
            this.lblDepreciacion.Name = "lblDepreciacion";
            this.lblDepreciacion.Size = new System.Drawing.Size(226, 100);
            this.lblDepreciacion.TabIndex = 132;
            this.lblDepreciacion.Text = "Depreciación";
            this.lblDepreciacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblDepreciacion.Click += new System.EventHandler(this.lblDepreciacion_Click);
            // 
            // FrmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(810, 455);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInformes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInformes";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblTituloPrinc;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label lblGrupos;
        internal System.Windows.Forms.Label lblTraslados;
        internal System.Windows.Forms.Label lblAreas;
        internal System.Windows.Forms.Label lblDepreciacion;
        internal System.Windows.Forms.Label lblCerrar;
        internal System.Windows.Forms.Label lblHistorial;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblMovimientos;
    }
}