using BE;
using BLL;
using SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES
{
    public class AgendaService : IAgendaService
    {
        BLLProfesional oBLLProfesional;

        public AgendaService()
        {
            oBLLProfesional = new BLLProfesional();
        }

        

        public List<BETurnoTomado> ObtenerTurnosTomados(int iProfesionalID, DateTime dtFecha)
        {
            return oBLLProfesional.GetTurnosTomados(iProfesionalID, dtFecha);
        }

        public int ConfirmarReserva(BEReserva oReserva, int iIdUsuario)
        {
            var oBLLFidelizacion = new BLLFidelizacion();

            if (iIdUsuario != 0)
            {
                var dtDesc = oBLLFidelizacion.ObtenerDescuentoPendiente(iIdUsuario);

                if (dtDesc.Rows.Count > 0)
                {
                    var descuentoID = (int)dtDesc.Rows[0]["DescuentoID"];
                    var porcentaje = (decimal)dtDesc.Rows[0]["PorcentajeDescuento"];

                    oReserva.PrecioTotal = oReserva.PrecioTotal - (oReserva.PrecioTotal * (porcentaje / 100));

                    oBLLFidelizacion.MarcarDescuentoUsado(descuentoID);
                }
            }

            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ConfirmarReserva(oReserva);
        }

        public int DuracionTotalSeleccionadaMin(IEnumerable<int> serviciosSeleccionados)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.DuracionTotalSeleccionadaMin(serviciosSeleccionados);
        }

        public List<DateTime> CalcularSlotsDisponibles(int iProfesionalID, DateTime oDtFecha, IEnumerable<int> serviciosSeleccionados)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.CalcularSlotsDisponibles(iProfesionalID, oDtFecha, serviciosSeleccionados);
        }

        public List<DateTime> ObtenerFechasConReservas(int idProfesional, DateTime mes)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerFechasConReservas(idProfesional, mes);
        }

        public DataTable ObtenerReservaDiaPorFechayProfesional(int idProfesional, DateTime dtFecha)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerReservaDiaPorFechayProfesional(idProfesional, dtFecha);
        }

        public void ReservaAcciones(int idReserva, ReservaAcciones AccionEnum)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            oBLLAgenda.ReservaAcciones(idReserva, AccionEnum);
        }

        public BEReserva ObtenerReserva(int idReserva)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerReserva(idReserva);
        }

        public List<int> ObtenerIDsServiciosPorReservaID(int ReservaID)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerIDsServiciosPorReservaID(ReservaID);
        }

        public List<DateTime> ObtenerFechasConReservasCliente(string Mail, DateTime dtFecha)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerFechasConReservasCliente(Mail, dtFecha);
        }

        public List<BETurnoTomado> ListarReservasClientesPorFechayMail(string sMail, DateTime fecha)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ListarReservasClientesPorFechayMail(sMail, fecha);
        }

        public DataTable ObtenerReservaDiaPorFechayMail(string sMail, DateTime dtFecha)
        {
            BLLAgenda oBLLAgenda = new BLLAgenda();
            return oBLLAgenda.ObtenerReservaDiaPorFechayMail(sMail, dtFecha);
        }

        public void RegistrarMedioDePagoReserva(int IdReservaSeleccionada, MedioDePagoEnum MedioDePagoSeleccionado)
        {
            BLLMedioDePago oBLLMedioDePago = new BLLMedioDePago();
            oBLLMedioDePago.RegistrarMedioDePagoReserva(IdReservaSeleccionada, MedioDePagoSeleccionado);
        }
    }
}
