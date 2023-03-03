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
    public partial class frmClienteEdit : Form
    {
        Cliente _cliente;
        public frmClienteEdit(Cliente cliente)
        {
            InitializeComponent();
            this._cliente = cliente;
        }

        private void aceptarDatos(object sender, EventArgs e)
        {
            asignarDatos();
            this.DialogResult = DialogResult.OK;
        }

        private void cargarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        void cargarDatos()
        {
            var listadoTipoDocumento = TipoDocumentoBL.Listar();
            cboTipoDocumento.DataSource = listadoTipoDocumento;
            cboTipoDocumento.DisplayMember = "Nombre";
            cboTipoDocumento.ValueMember = "ID";

            var listadoTipoCliente = TipoClienteBL.Listar();
            cboTipoCliente.DataSource = listadoTipoCliente;
            cboTipoCliente.DisplayMember = "Nombre";
            cboTipoCliente.ValueMember = "ID";
        }

        void asignarDatos()
        {
            this._cliente.Nombres = txtNombre.Text;
            this._cliente.Apellidos = txtApellidos.Text;
            this._cliente.IdTipoDocumento = int.Parse(cboTipoDocumento.SelectedValue.ToString());
            this._cliente.NumeroDocumento = txtNumeroDocumento.Text;
            this._cliente.IdTipoCliente = int.Parse(cboTipoCliente.SelectedValue.ToString());
            this._cliente.Direccion = txtDireccion.Text;
            this._cliente.Referencia = txtReferencia.Text;
            this._cliente.Telefono = txtTelefono.Text;
            this._cliente.Email = txtEmail.Text;
        }
    }
}
