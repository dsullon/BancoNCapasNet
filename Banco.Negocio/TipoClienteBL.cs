using Banco.Data;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public static class TipoClienteBL
    {
        public static List<TipoCliente> Listar()
        {
            var tipoClienteBD = new TipoClienteDB();
            return tipoClienteBD.Listar();
        }
    }
}
