using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public class DetallePrestamoDB
    {
        public int Insertar(DetallePrestamo detalle)
        {
            int filas = 0;
            using(var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                var query = "INSERT INTO DetallePrestamo(IdPrestamo, NumeroCuota, " +
                                "ImporteCuota, ImporteInteres, Estado)" +
                            "VALUES(@IdPrestamo, @NumeroCuota, @ImporteCuota, " +
                                "@ImporteInteres, @Estado)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdPrestamo", detalle.IdPrestamo);
                    comando.Parameters.AddWithValue("@NumeroCuota", detalle.NumeroCuota);
                    comando.Parameters.AddWithValue("@ImporteCuota", detalle.ImporteCuota);
                    comando.Parameters.AddWithValue("@ImporteInteres", detalle.ImporteInteres);
                    comando.Parameters.AddWithValue("@Estado", detalle.Estado);
                    filas = comando.ExecuteNonQuery();
                }
            }

            return filas;
        }
    }
}
