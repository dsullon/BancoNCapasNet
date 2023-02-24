using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public static class UtilDB
    {
        public static string CadenaConexion()
        {
            string cadenaConexion = @"Server = localhost; DataBase = BancoBD; User = APPData; Password = Data";

            return cadenaConexion;
        }
    }
}