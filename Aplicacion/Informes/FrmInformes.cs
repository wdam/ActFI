﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion.Informes
{
    public partial class FrmInformes : Form
    {
        public FrmInformes()
        {
            InitializeComponent();
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            FrmInfActivos frm = new FrmInfActivos();
            frm.ShowDialog();
        }
    }
}