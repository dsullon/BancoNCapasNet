using Banco.Data;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public static class TipoDocumentoBL
    {
        public static List<TipoDocumento> Listar()
        {
            var tipoDocumentoBD = new TipoDocumentoDB();
            return tipoDocumentoBD.Listar();
        }
    }
}
