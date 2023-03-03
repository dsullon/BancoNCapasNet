using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.AppWin
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void abrirClientes(object sender, EventArgs e)
        {
            var frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
