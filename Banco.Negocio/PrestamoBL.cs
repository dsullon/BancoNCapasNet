using Banco.Data;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Banco.Negocio
{
    public static class PrestamoBL
    {
        // TODO: 
        public static List<Prestamo> Listar()
        {
            var listado = new List<Prestamo>();

            return listado;
        }

        public static bool Insertar(Prestamo prestamo)
        {
            var exito = false;
            using(var transaccion = new TransactionScope())
            {
                var prestamoBD = new PrestamoDB();
                var detalleBD = new DetallePrestamoDB();

                prestamo.Numero = prestamoBD.NumeroPrestamo();
                prestamo.Fecha = DateTime.Today;
                
                int idPrestamo = prestamoBD.Insertar(prestamo);
                exito = idPrestamo > 0;
                if (exito)
                {
                    int cuota = 1;
                    int numeroCuotas = prestamo.Cuotas;
                    var montoCuota = prestamo.Importe / numeroCuotas;
                    var importeInteres = montoCuota * (prestamo.Tasa / 100);
                    DetallePrestamo detalle;
                    while (cuota <= numeroCuotas)
                    {
                        detalle = new DetallePrestamo()
                        {
                            IdPrestamo = idPrestamo,
                            NumeroCuota = cuota,
                            ImporteCuota = montoCuota,
                            ImporteInteres = importeInteres,
                            Estado = "P"
                        };
                        detalleBD.Insertar(detalle);
                        cuota++;
                    }
                    transaccion.Complete();
                } 
            }

            return exito;
        }
    }
}
