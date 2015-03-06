namespace Aplicacion.Inventario
{
    partial class FrmInventario
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
            this.menuPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.lblAreas = new System.Windows.Forms.Label();
            this.lblCerrar = new System.Windows.Forms.Label();
            this.lblActivos = new System.Windows.Forms.Label();
            this.lblDocumentos = new System.Windows.Forms.Label();
            this.lblParametros = new System.Windows.Forms.Label();
            this.lblGrupos = new System.Windows.Forms.Label();
            this.lblTerceros = new System.Windows.Forms.Label();
            this.lblTraslados = new System.Windows.Forms.Label();
            this.lblTituloPrinc = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.menuPrincipal.ColumnCount = 3;
            this.menuPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuPrincipal.Controls.Add(this.lblAreas, 1, 0);
            this.menuPrincipal.Controls.Add(this.lblCerrar, 2, 2);
            this.menuPrincipal.Controls.Add(this.lblActivos, 0, 0);
            this.menuPrincipal.Controls.Add(this.lblDocumentos, 2, 0);
            this.menuPrincipal.Controls.Add(this.lblParametros, 0, 1);
            this.menuPrincipal.Controls.Add(this.lblGrupos, 1, 1);
            this.menuPrincipal.Controls.Add(this.lblTerceros, 0, 2);
            this.menuPrincipal.Controls.Add(this.lblTraslados, 2, 1);
            this.menuPrincipal.Location = new System.Drawing.Point(57, 88);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.RowCount = 3;
            this.menuPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.menuPrincipal.Size = new System.Drawing.Size(696, 353);
            this.menuPrincipal.TabIndex = 169;
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
            this.lblAreas.Location = new System.Drawing.Point(240, 8);
            this.lblAreas.Margin = new System.Windows.Forms.Padding(8);
            this.lblAreas.Name = "lblAreas";
            this.lblAreas.Size = new System.Drawing.Size(216, 100);
            this.lblAreas.TabIndex = 132;
            this.lblAreas.Text = "Areas";
            this.lblAreas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblAreas, "Gestion de Areas");
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
            this.lblCerrar.Location = new System.Drawing.Point(472, 242);
            this.lblCerrar.Margin = new System.Windows.Forms.Padding(8);
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Size = new System.Drawing.Size(216, 100);
            this.lblCerrar.TabIndex = 132;
            this.lblCerrar.Text = "Cerrar";
            this.lblCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblCerrar, "Cerrar");
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
            this.lblActivos.Size = new System.Drawing.Size(216, 100);
            this.lblActivos.TabIndex = 132;
            this.lblActivos.Text = "Activos";
            this.lblActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblActivos, "Gestion de Activos");
            this.lblActivos.Click += new System.EventHandler(this.lblActivos_Click);
            // 
            // lblDocumentos
            // 
            this.lblDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumentos.BackColor = System.Drawing.Color.Transparent;
            this.lblDocumentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDocumentos.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentos.ForeColor = System.Drawing.Color.White;
            this.lblDocumentos.Image = global::Aplicacion.Properties.Resources.contabilida;
            this.lblDocumentos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDocumentos.Location = new System.Drawing.Point(472, 8);
            this.lblDocumentos.Margin = new System.Windows.Forms.Padding(8);
            this.lblDocumentos.Name = "lblDocumentos";
            this.lblDocumentos.Size = new System.Drawing.Size(216, 100);
            this.lblDocumentos.TabIndex = 133;
            this.lblDocumentos.Text = "Documentos";
            this.lblDocumentos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblDocumentos, "Generar Documentos Contables");
            this.lblDocumentos.Click += new System.EventHandler(this.lblDocumentos_Click);
            // 
            // lblParametros
            // 
            this.lblParametros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParametros.BackColor = System.Drawing.Color.Transparent;
            this.lblParametros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblParametros.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametros.ForeColor = System.Drawing.Color.White;
            this.lblParametros.Image = global::Aplicacion.Properties.Resources.parametros;
            this.lblParametros.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblParametros.Location = new System.Drawing.Point(8, 125);
            this.lblParametros.Margin = new System.Windows.Forms.Padding(8);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(216, 100);
            this.lblParametros.TabIndex = 132;
            this.lblParametros.Text = "Parametros";
            this.lblParametros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblParametros, "Parametros");
            this.lblParametros.Click += new System.EventHandler(this.lblParametros_Click);
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
            this.lblGrupos.Location = new System.Drawing.Point(240, 125);
            this.lblGrupos.Margin = new System.Windows.Forms.Padding(8);
            this.lblGrupos.Name = "lblGrupos";
            this.lblGrupos.Size = new System.Drawing.Size(216, 100);
            this.lblGrupos.TabIndex = 134;
            this.lblGrupos.Text = "Grupos y Subgrupos";
            this.lblGrupos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblGrupos, "Grupos y Subgrupos");
            this.lblGrupos.Click += new System.EventHandler(this.lblGrupos_Click);
            // 
            // lblTerceros
            // 
            this.lblTerceros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTerceros.BackColor = System.Drawing.Color.Transparent;
            this.lblTerceros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTerceros.Enabled = false;
            this.lblTerceros.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerceros.ForeColor = System.Drawing.Color.White;
            this.lblTerceros.Image = global::Aplicacion.Properties.Resources.terceros;
            this.lblTerceros.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTerceros.Location = new System.Drawing.Point(8, 242);
            this.lblTerceros.Margin = new System.Windows.Forms.Padding(8);
            this.lblTerceros.Name = "lblTerceros";
            this.lblTerceros.Size = new System.Drawing.Size(216, 100);
            this.lblTerceros.TabIndex = 132;
            this.lblTerceros.Text = "Terceros";
            this.lblTerceros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblTerceros, "Gestion de Terceros");
            this.lblTerceros.Click += new System.EventHandler(this.lblTerceros_Click);
            // 
            // lblTraslados
            // 
            this.lblTraslados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTraslados.BackColor = System.Drawing.Color.Transparent;
            this.lblTraslados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTraslados.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraslados.ForeColor = System.Drawing.Color.White;
            this.lblTraslados.Image = global::Aplicacion.Properties.Resources.traslados;
            this.lblTraslados.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTraslados.Location = new System.Drawing.Point(472, 125);
            this.lblTraslados.Margin = new System.Windows.Forms.Padding(8);
            this.lblTraslados.Name = "lblTraslados";
            this.lblTraslados.Size = new System.Drawing.Size(216, 100);
            this.lblTraslados.TabIndex = 132;
            this.lblTraslados.Text = "Traslados";
            this.lblTraslados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.lblTraslados, "Traslados");
            this.lblTraslados.Click += new System.EventHandler(this.lblTraslados_Click);
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
            this.lblTituloPrinc.TabIndex = 168;
            this.lblTituloPrinc.Text = "Procesos Basicos de Activos Fijos";
            this.lblTituloPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            this.ClientSize = new System.Drawing.Size(810, 455);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.lblTituloPrinc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInventario";
            this.menuPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDocumentos;
        private System.Windows.Forms.TableLayoutPanel menuPrincipal;
        private System.Windows.Forms.Label lblTerceros;
        private System.Windows.Forms.Label lblTraslados;
        private System.Windows.Forms.Label lblAreas;
        private System.Windows.Forms.Label lblParametros;
        private System.Windows.Forms.Label lblCerrar;
        private System.Windows.Forms.Label lblActivos;
        private System.Windows.Forms.Label lblTituloPrinc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblGrupos;

    }
}