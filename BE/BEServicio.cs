
namespace BE
{
    public class BEServicio
    {
        public int ServicioID { get; set; }
        public string Nombre { get; set; }
        public int DuracionMin { get; set; }
        public int BufferMin { get; set; }
        public decimal Precio { get; set; }

        public enum Acciones
        {
            Confirmado = 1,
            Atendido = 2,
            Cancelado = 3
        }
    }
}
