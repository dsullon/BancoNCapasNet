namespace Banco.Entidades
{
    public class DetallePrestamo
    {
        public int NumeroCuota { get; set; }
        public decimal ImporteCuota { get; set; }
        public decimal ImporteInteres { get; set; }
        public string Estado { get; set; }
        public int IdPrestamo { get; set; }
    }
}