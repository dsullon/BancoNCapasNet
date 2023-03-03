using Banco.Entidades;
using Banco.Negocio;
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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void cargarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            dgvDatos.Rows.Clear();
            var listado = ClienteBL.Listar();
            foreach (var cliente in listado)
            {
                dgvDatos.Rows.Add(cliente.ID, cliente.RazonSocial, cliente.Telefono, cliente.Email);
            }
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoCliente = new Cliente();
            var frm = new frmClienteEdit(nuevoCliente);
            
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var resultado = ClienteBL.Insertar(nuevoCliente);
                if (resultado)
                {
                    MessageBox.Show("Datos registrados", "Sistemas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                } else
                {
                    MessageBox.Show("No se ha podido registrar los datos", "Sistemas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
