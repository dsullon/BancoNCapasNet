using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data
{
    public class PrestamoDB
    {
        // TODO: 
        public List<Prestamo> Listar()
        {
            var listado = new List<Prestamo> ();

            return listado;
        }

        public string NumeroPrestamo()
        {
            int numero = 0;
            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT ISNULL(MAX(NUMERO),0) FROM Prestamo", conexion))
                {
                    numero = int.Parse(comando.ExecuteScalar().ToString());
                    numero++;
                }
            }
            return numero.ToString().PadLeft(10, char.Parse("0"));
        }

        public int Insertar(Prestamo prestamo)
        {
            int nuevoId = 0;

            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                var query = "INSERT INTO Prestamo (Numero, Fecha, IdCliente, Importe, " +
                                "TasaInteres, Cuotas, FechaDeposito)" +
                            "VALUES (@Numero, @Fecha, @IdCliente, @Importe, " +
                                "@Tasa, @Cuotas, @FechaDeposito);" +
                            "SELECT ISNULL(@@IDENTITY,0);";
                using(var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Numero", prestamo.Numero);
                    comando.Parameters.AddWithValue("@Fecha", prestamo.Fecha);
                    comando.Parameters.AddWithValue("@IdCliente", prestamo.IdCliente);
                    comando.Parameters.AddWithValue("@Importe", prestamo.Importe);
                    comando.Parameters.AddWithValue("@Tasa", prestamo.Tasa);
                    comando.Parameters.AddWithValue("@Cuotas", prestamo.Cuotas);
                    comando.Parameters.AddWithValue("@FechaDeposito", prestamo.FechaDeposito);

                    nuevoId = int.Parse(comando.ExecuteScalar().ToString());
                }
            }
            return nuevoId;
        }
    }
}
