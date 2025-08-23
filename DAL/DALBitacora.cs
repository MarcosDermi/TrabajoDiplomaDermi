using BE;
using SERVICES;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALBitacora
    {
        public DALBitacora()
        {
            Datos oDatos = new Datos();
            Hashtable hDatos = new Hashtable();
        }

        Datos oDatos;
        Hashtable hDatos;

        public void GuardarBitacora(Bitacora oBitacora)
        {
            try
            {
                string stpNombre = "GuardarBitacora";
                oDatos = new Datos();

                hDatos = new Hashtable();
                hDatos.Add("@Detalle", oBitacora.Detalle);
                hDatos.Add("@UsuarioID", oBitacora.UsuarioResponsable.Id);
                hDatos.Add("@Fecha", oBitacora.Fecha);
                hDatos.Add("@BitacoraTipoID", Convert.ToInt32(oBitacora.BitacoraEnum));

                oDatos.Escribir(stpNombre, hDatos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable BuscarBitacoraPorFiltrosVarios(string sUsuario, DateTime? dtFechaDesde, DateTime? dtFechaHasta, int? TipoBitacoraEnum)
        {
            try
            {
                string stpNombre = "BuscarBitacora";
                oDatos = new Datos();

                hDatos = new Hashtable();
                hDatos.Add("@NombreUsuario", sUsuario);
                hDatos.Add("@FechaDesde", dtFechaDesde);
                hDatos.Add("@FechaHasta", dtFechaHasta);
                hDatos.Add("@BitacoraTipoID", TipoBitacoraEnum);

                var oDtBitacoras = oDatos.Leer(stpNombre, hDatos);

                return oDtBitacoras;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
