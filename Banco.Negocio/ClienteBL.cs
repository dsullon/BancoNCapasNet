using Banco.Data;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public static class ClienteBL
    {
        public static List<Cliente> Listar()
        {
            var clienteDB = new ClienteDB();
            return clienteDB.Listar();
        }

        public static bool Insertar(Cliente cliente)
        {
            var clienteDB = new ClienteDB();
            return clienteDB.Insertar(cliente) > 0;
        }
    }
}
