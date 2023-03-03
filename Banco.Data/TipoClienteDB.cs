using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public class TipoClienteDB
    {
        public List<TipoCliente> Listar()
        {
            var listado = new List<TipoCliente>();
            using(var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using(var comando = new SqlCommand("SELECT * FROM TipoCliente", conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if(lector != null && lector.HasRows)
                        {
                            TipoCliente tipo;
                            while (lector.Read())
                            {
                                tipo = new TipoCliente()
                                {
                                    ID = int.Parse(lector["ID"].ToString()),
                                    Nombre = lector["Nombre"].ToString()
                                };
                                listado.Add(tipo);
                            }
                        }
                    }
                }
            }

            return listado;
        }
    }
}
