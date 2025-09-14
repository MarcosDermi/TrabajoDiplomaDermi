using BE;
using DAL;
using ABSTRACCION.Contracts;
using SERVICES;
using System.Collections.Generic;

namespace BLL
{
    public class BLLDV
    {
        private readonly IDigitoVerificadorService _DigitoVerificadorService;

        public BLLDV(IDigitoVerificadorService digitoVerificadorService)
        {
            _DigitoVerificadorService = digitoVerificadorService;
            oDALDV = new DALDV();
        }


        DALDV oDALDV;

        // Métodos de alto nivel para gestión de DV
        public bool ValidarIntegridadUsuario(BEUsuario usuario)
        {
            if (usuario == null) return false;

            string dvCalculado = _DigitoVerificadorService.CalcularDVUsuario(usuario);
            return dvCalculado.Equals(usuario.DV);
        }

        public bool ValidarIntegridadSistema()
        {
            var usuarios = ListarUsuariosConDV();
            if (usuarios == null || usuarios.Count == 0) return true;

            string dvCalculado = _DigitoVerificadorService.CalcularDVSistema(usuarios);
            string dvAlmacenado = ObtenerDVSistema();

            return dvCalculado.Equals(dvAlmacenado);
        }

        public bool ActualizarDVSistema()
        {
            var usuarios = oDALDV.ListarUsuariosConDV();
            if (usuarios == null || usuarios.Count == 0) return false;

            string dvCalculado = _DigitoVerificadorService.CalcularDVSistema(usuarios);
            return oDALDV.ActualizarDVSistema(dvCalculado);
        }

        public bool RecalcularTodosLosDV()
        {
            var usuarios = oDALDV.ListarUsuariosConDV();
            if (usuarios == null || usuarios.Count == 0) return false;

            bool todosActualizados = true;

            foreach (var usuario in usuarios)
            {
                usuario.DV = _DigitoVerificadorService.CalcularDVUsuario(usuario);
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

            usuario.DV = _DigitoVerificadorService.CalcularDVUsuario(usuario);
            return oDALDV.ActualizarDVUsuario(usuario);
        }

        public bool RepararUsuariosCorruptos()
        {
            var usuariosCorruptos = oDALDV.ListarUsuariosCorruptos();

            foreach (var usuario in usuariosCorruptos)
            {
                string dvCalculado = _DigitoVerificadorService.CalcularDVUsuario(usuario);

                if (!dvCalculado.Equals(usuario.DV))
                {
                    usuariosCorruptos.Add(usuario);
                }
            }

            if (usuariosCorruptos == null || usuariosCorruptos.Count == 0) return true;

            int reparados = 0;
            int errores = 0;

            foreach (var usuario in usuariosCorruptos)
            {
                try
                {
                    usuario.DV = _DigitoVerificadorService.CalcularDVUsuario(usuario);
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
            var oLstUsuariosCorruptos = oDALDV.ListarUsuariosCorruptos();

            foreach (var usuario in oLstUsuariosCorruptos)
            {
                string dvCalculado = _DigitoVerificadorService.CalcularDVUsuario(usuario);

                if (!dvCalculado.Equals(usuario.DV))
                {
                    oLstUsuariosCorruptos.Add(usuario);
                }
            }
            return oLstUsuariosCorruptos;
        }

        public string ObtenerDVSistema()
        {
            return oDALDV.ObtenerDVSistema();
        }

        public Dictionary<string, object> ObtenerEstadisticasDV()
        {
            var todosLosUsuarios = ListarUsuariosConDV();
            var usuariosCorruptos = ListarUsuariosCorruptos();

            foreach (var usuario in usuariosCorruptos)
            {
                string dvCalculado = _DigitoVerificadorService.CalcularDVUsuario(usuario);

                if (!dvCalculado.Equals(usuario.DV))
                {
                    usuariosCorruptos.Add(usuario);
                }
            }

            var estadisticas = new Dictionary<string, object>();
            estadisticas["TotalUsuarios"] = todosLosUsuarios.Count;
            estadisticas["UsuariosCorruptos"] = usuariosCorruptos.Count;
            estadisticas["PorcentajeCorrupcion"] = todosLosUsuarios.Count > 0 ?
                (usuariosCorruptos.Count * 100.0 / todosLosUsuarios.Count) : 0;
            estadisticas["SistemaIntegro"] = ValidarIntegridadSistema();

            return estadisticas;
        }

        public string CalcularDVUsuario(BEUsuario usuario)
        {
            return _DigitoVerificadorService.CalcularDVUsuario(usuario);
        }

    }
}