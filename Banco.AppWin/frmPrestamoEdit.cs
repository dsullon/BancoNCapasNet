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
    public partial class frmPrestamoEdit : Form
    {
        Prestamo _prestamo;
        public frmPrestamoEdit(Prestamo prestamo)
        {
            InitializeComponent();
            this._prestamo = prestamo;
        }

        private void cargarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        void cargarDatos()
        {
            var listadoCliente = ClienteBL.Listar();
            cboCliente.DataSource = listadoCliente;
            cboCliente.DisplayMember = "RazonSocial";
            cboCliente.ValueMember = "ID";
        }

        private void grabarDatos(object sender, EventArgs e)
        {
            asignarDatos();
            if(this._prestamo.ID == 0)
            {
                insertarRegistro();
            }
        }

        void insertarRegistro()
        {
            var resultado = PrestamoBL.Insertar(this._prestamo);
            if (resultado)
            {
                MessageBox.Show("Datos registrados", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumero.Text = this._prestamo.Numero;
                txtFecha.Text = this._prestamo.Fecha.ToShortDateString();
            }
            else
            {
                MessageBox.Show("No se ha podido registrar los datos", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void asignarDatos()
        {
            this._prestamo.IdCliente = int.Parse(cboCliente.SelectedValue.ToString());
            this._prestamo.FechaDeposito = dpFechaDeposito.Value;
            this._prestamo.Importe = decimal.Parse(txtImporte.Text);
            this._prestamo.Tasa = decimal.Parse(txtTasa.Text);
            this._prestamo.Cuotas = int.Parse(txtPlazo.Text);
        }
    }
}
