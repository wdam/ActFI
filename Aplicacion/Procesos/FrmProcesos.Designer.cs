namespace Aplicacion.Procesos
{
    partial class FrmProcesos
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
            this.lblAreas = new System.Windows.Forms.Label();
            this.lblParametros = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblCerrar = new System.Windows.Forms.Label();
            this.lblActivos = new System.Windows.Forms.Label();
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
            this.lblTituloPrinc.Text = "Procesos";
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
            this.TableLayoutPanel1.Controls.Add(this.lblAreas, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.lblParametros, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.lblCerrar, 2, 2);
            this.TableLayoutPanel1.Controls.Add(this.lblActivos, 0, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(57, 96);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(699, 353);
            this.TableLayoutPanel1.TabIndex = 171;
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
            this.lblAreas.Location = new System.Drawing.Point(241, 8);
            this.lblAreas.Margin = new System.Windows.Forms.Padding(8);
            this.lblAreas.Name = "lblAreas";
            this.lblAreas.Size = new System.Drawing.Size(217, 100);
            this.lblAreas.TabIndex = 132;
            this.lblAreas.Text = "Avaluos y Salvamentos";
            this.lblAreas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblParametros
            // 
            this.lblParametros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParametros.BackColor = System.Drawing.Color.Transparent;
            this.lblParametros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblParametros.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametros.ForeColor = System.Drawing.Color.White;
            this.lblParametros.Image = global::Aplicacion.Properties.Resources.money;
            this.lblParametros.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblParametros.Location = new System.Drawing.Point(474, 8);
            this.lblParametros.Margin = new System.Windows.Forms.Padding(8);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(217, 100);
            this.lblParametros.TabIndex = 132;
            this.lblParametros.Text = "Venta de Activos";
            this.lblParametros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.Label2.Location = new System.Drawing.Point(8, 125);
            this.Label2.Margin = new System.Windows.Forms.Padding(8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(217, 100);
            this.Label2.TabIndex = 132;
            this.Label2.Text = "Registro de Fallas";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.lblCerrar.Location = new System.Drawing.Point(474, 242);
            this.lblCerrar.Margin = new System.Windows.Forms.Padding(8);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(217, 100);
            this.lblCerrar.TabIndex = 132;
            this.lblCerrar.Text = "Cerrar";
            this.lblCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // lblActivos
            // 
            this.lblActivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActivos.BackColor = System.Drawing.Color.Transparent;
            this.lblActivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblActivos.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivos.ForeColor = System.Drawing.Color.White;
            this.lblActivos.Image = global::Aplicacion.Properties.Resources.inventario2;
            this.lblActivos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblActivos.Location = new System.Drawing.Point(8, 8);
            this.lblActivos.Margin = new System.Windows.Forms.Padding(8);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(217, 100);
            this.lblActivos.TabIndex = 132;
            this.lblActivos.Text = "Gravamenes y Tipo";
            this.lblActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FrmProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(810, 455);
            this.Controls.Add(this.lblTituloPrinc);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProcesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProcesos";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblTituloPrinc;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label lblAreas;
        internal System.Windows.Forms.Label lblParametros;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblCerrar;
        internal System.Windows.Forms.Label lblActivos;

    }
}