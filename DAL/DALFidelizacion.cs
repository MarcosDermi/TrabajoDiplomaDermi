using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DALFidelizacion
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALFidelizacion()
        {
            oDatos = new Datos();
        }

        /// <summary>
        /// Obtiene los datos de fidelización de un cliente (puntos acumulados).
        /// </summary>
        public DataTable ObtenerFidelizacionPorCliente(int ClienteID, string EmailCliente)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", ClienteID);
            Hdatos.Add("@EmailCliente", EmailCliente);
            return oDatos.Leer("Fidelizacion_S_PorCliente", Hdatos);
        }

        /// <summary>
        /// Actualiza o inserta puntos acumulados al cliente.
        /// </summary>
        public void ActualizarPuntos(int ClienteID, int Puntos)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", ClienteID);
            Hdatos.Add("@Puntos", Puntos);
            oDatos.Escribir("Fidelizacion_U_AgregarPuntos", Hdatos);
        }

        /// <summary>
        /// Registra un canje tradicional (historial).
        /// </summary>
        public void RegistrarCanje(int ClienteID, string Recompensa, int PuntosUsados)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", ClienteID);
            Hdatos.Add("@Recompensa", Recompensa);
            Hdatos.Add("@PuntosUsados", PuntosUsados);
            oDatos.Escribir("Fidelizacion_I_Canje", Hdatos);
        }

        /// <summary>
        /// Registra un descuento pendiente a partir de puntos canjeados.
        /// </summary>
        public void RegistrarDescuentoPendiente(int ClienteID, decimal PorcentajeDescuento, int PuntosCanjeados)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", ClienteID);
            Hdatos.Add("@PorcentajeDescuento", PorcentajeDescuento);
            Hdatos.Add("@PuntosCanjeados", PuntosCanjeados);
            oDatos.Escribir("Fidelizacion_I_RegistrarDescuentoPendiente", Hdatos);
        }

        /// <summary>
        /// Obtiene el descuento pendiente del cliente (para aplicar en la próxima reserva).
        /// </summary>
        public DataTable ObtenerDescuentoPendiente(int ClienteID)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", ClienteID);
            return oDatos.Leer("Fidelizacion_S_DescuentoPendiente", Hdatos);
        }

        /// <summary>
        /// Marca el descuento como utilizado (una vez aplicada la reserva).
        /// </summary>
        public void MarcarDescuentoUsado(int DescuentoID)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@DescuentoID", DescuentoID);
            oDatos.Escribir("Fidelizacion_U_Descuento_Usado", Hdatos);
        }

        /// <summary>
        /// Devuelve el historial de canjes de un cliente.
        /// </summary>
        public DataTable ObtenerHistorialCanjes(int ClienteID)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", ClienteID);
            return oDatos.Leer("Fidelizacion_S_HistorialCanjes", Hdatos);
        }

        public void ActualizarPuntosPorEmail(string EmailCliente, int Puntos)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@EmailCliente", EmailCliente);
            Hdatos.Add("@Puntos", Puntos);
            oDatos.Escribir("Fidelizacion_U_AgregarPuntosPorEmail", Hdatos);
        }

        public void RegistrarNuevaFidelizacion(BEReserva oBEReserva)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", oBEReserva.Cliente.Id == 0 ? null : oBEReserva.Cliente.Id.ToString());
            Hdatos.Add("@Email", oBEReserva.Cliente.Mail);
            oDatos.Escribir("Fidelizacion_I_RegistrarNuevaFidelizacion", Hdatos);
        }

        public void ActualizarFidelizacionConClienteID(int ClienteID, string EmailCliente)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@ClienteID", ClienteID);
            Hdatos.Add("@EmailCliente", EmailCliente);
            oDatos.Escribir("Fidelizacion_U_ActualizarFidelizacion", Hdatos);
        }
    }
}
