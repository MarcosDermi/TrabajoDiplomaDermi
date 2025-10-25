namespace BE
{
    public class BEMedioDePago
    {
        public int IDMedioPago { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }
    }

    public enum MedioDePagoEnum
    {
        Efectivo = 1,
        Credito = 2,
        Debito = 3
    }
}
