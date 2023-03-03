using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public class TipoDocumentoDB
    {
        public List<TipoDocumento> Listar()
        {
            var listado = new List<TipoDocumento>();
            using(var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using(var comando = new SqlCommand("SELECT * FROM TipoDocumento", conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if(lector != null && lector.HasRows)
                        {
                            TipoDocumento tipo;
                            while(lector.Read())
                            {
                                tipo = new TipoDocumento()
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
