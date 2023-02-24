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
    public partial class frmClienteEdit : Form
    {
        public frmClienteEdit()
        {
            InitializeComponent();
        }

        private void aceptarDatos(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
