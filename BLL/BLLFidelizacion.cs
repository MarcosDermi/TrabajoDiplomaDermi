using BE;
using DAL;
using System.Collections.Generic;
using System.Data;

public class BLLFidelizacion
{
    private readonly DALFidelizacion oDal = new DALFidelizacion();

    public DataTable ObtenerPorCliente(int ClienteID, string EmailCliente)
    {
        return oDal.ObtenerFidelizacionPorCliente(ClienteID, EmailCliente);
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

    public void ProcesarPuntosDeAsistencia(BEReserva oReserva, int iIdUsuario)
    {
        BLLFidelizacion oFid = new BLLFidelizacion();
        var puntosGanados = CalcularPuntosPorReserva(oReserva.Servicios);

        if (iIdUsuario != 0)
        {
            oFid.ActualizarPuntos(iIdUsuario, puntosGanados);
        }
        else
        {
            oFid.ActualizarPuntosPorEmail(oReserva.Cliente.Mail, puntosGanados);
        }
    }

    private int CalcularPuntosPorReserva(List<BEServicio> oLstServicios)
    {
        int puntosTotales = 0;
        var dCantServicios = oLstServicios.Count;

        puntosTotales = dCantServicios * 2;

        return puntosTotales;
    }
}