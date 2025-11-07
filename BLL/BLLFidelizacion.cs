using System.Data;
using DAL;

public class BLLFidelizacion
{
    private readonly DALFidelizacion oDal = new DALFidelizacion();

    public DataTable ObtenerPorCliente(int ClienteID)
    {
        return oDal.ObtenerFidelizacionPorCliente(ClienteID);
    }

    public void ActualizarPuntos(int ClienteID, int Puntos)
    {
        oDal.ActualizarPuntos(ClienteID, Puntos);
    }

    public void CanjearPuntos(int ClienteID, string Recompensa, int PuntosUsados)
    {
        oDal.RegistrarCanje(ClienteID, Recompensa, PuntosUsados);
    }

    public DataTable ObtenerHistorialCanjes(int ClienteID)
    {
        return oDal.ObtenerHistorialCanjes(ClienteID);
    }

    // NUEVOS MÉTODOS

    public void RegistrarDescuentoPendiente(int ClienteID, decimal PorcentajeDescuento, int PuntosCanjeados)
    {
        oDal.RegistrarDescuentoPendiente(ClienteID, PorcentajeDescuento, PuntosCanjeados);
    }

    public DataTable ObtenerDescuentoPendiente(int ClienteID)
    {
        return oDal.ObtenerDescuentoPendiente(ClienteID);
    }

    public void MarcarDescuentoUsado(int DescuentoID)
    {
        oDal.MarcarDescuentoUsado(DescuentoID);
    }

    public void ActualizarPuntosPorEmail(string EmailCliente, int Puntos)
    {
        oDal.ActualizarPuntosPorEmail(EmailCliente, Puntos);
    }
}