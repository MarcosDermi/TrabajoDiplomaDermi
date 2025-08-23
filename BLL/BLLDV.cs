using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using SERVICES;

namespace BLL
{
    public class BLLDV
    {
        public BLLDV()
        {
            oDALDV = new DALDV();
        }

        DALDV oDALDV;

        // Métodos de alto nivel para gestión de DV
        public bool ValidarIntegridadUsuario(BEUsuario usuario)
        {
            return oDALDV.ValidarIntegridadUsuario(usuario);
        }

        public bool ValidarIntegridadSistema()
        {
            return oDALDV.ValidarIntegridadSistema();
        }

        public bool ActualizarDVSistema()
        {
            var usuarios = oDALDV.ListarUsuariosConDV();
            if (usuarios == null || usuarios.Count == 0) return false;
            
            string dvCalculado = DigitoVerificadorService.CalcularDVSistema(usuarios);
            return oDALDV.ActualizarDVSistema(dvCalculado);
        }

        public bool RecalcularTodosLosDV()
        {
            var usuarios = oDALDV.ListarUsuariosConDV();
            if (usuarios == null || usuarios.Count == 0) return false;
            
            bool todosActualizados = true;
            
            foreach (var usuario in usuarios)
            {
                usuario.DV = DigitoVerificadorService.CalcularDVUsuario(usuario);
                if (!oDALDV.ActualizarDVUsuario(usuario))
                {
                    todosActualizados = false;
                }
            }
            
            // Actualizar DV del sistema
            if (todosActualizados)
            {
                ActualizarDVSistema();
            }
            
            return todosActualizados;
        }

        public bool RepararUsuario(BEUsuario usuario)
        {
            if (usuario == null) return false;
            
            usuario.DV = DigitoVerificadorService.CalcularDVUsuario(usuario);
            return oDALDV.ActualizarDVUsuario(usuario);
        }

        public bool RepararUsuariosCorruptos()
        {
            var usuariosCorruptos = oDALDV.ListarUsuariosCorruptos();
            if (usuariosCorruptos == null || usuariosCorruptos.Count == 0) return true;
            
            int reparados = 0;
            int errores = 0;
            
            foreach (var usuario in usuariosCorruptos)
            {
                try
                {
                    usuario.DV = DigitoVerificadorService.CalcularDVUsuario(usuario);
                    if (oDALDV.ActualizarDVUsuario(usuario))
                    {
                        reparados++;
                    }
                    else
                    {
                        errores++;
                    }
                }
                catch
                {
                    errores++;
                }
            }
            
            // Actualizar DV del sistema
            ActualizarDVSistema();
            
            return errores == 0;
        }

        public List<BEUsuario> ListarUsuariosConDV()
        {
            return oDALDV.ListarUsuariosConDV();
        }

        public List<BEUsuario> ListarUsuariosCorruptos()
        {
            return oDALDV.ListarUsuariosCorruptos();
        }

        public string ObtenerDVSistema()
        {
            return oDALDV.ObtenerDVSistema();
        }

        public Dictionary<string, object> ObtenerEstadisticasDV()
        {
            return oDALDV.ObtenerEstadisticasDV();
        }

        public string CalcularDVUsuario(BEUsuario usuario)
        {
            return DigitoVerificadorService.CalcularDVUsuario(usuario);
        }

       
        

       
    }
} 