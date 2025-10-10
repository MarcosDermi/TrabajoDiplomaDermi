using ABSTRACCION;
using ABSTRACCION.Contracts;
using BE;
using DAL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class BLLUsuario : IGestor<BEUsuario>
    {
        public BLLUsuario(IDigitoVerificadorService DigitoVerificadorService)
        {
            oDALUsuario = new DALUsuario();
            oHashCrypto = new HashCrypto();
            oBLLPermisos = new BLLPermisos();
            oBLLBitacora = new BLLBitacora();
            oBLLDV = new BLLDV(DigitoVerificadorService);
        }

        DALUsuario oDALUsuario;
        HashCrypto oHashCrypto;
        BEUsuario oBEUsuario;
        BLLPermisos oBLLPermisos;
        BLLBitacora oBLLBitacora;
        BLLDV oBLLDV;

        public bool Guardar(BEUsuario oUsuario)
        {

            if (oUsuario.Id == 0)
            {
                oUsuario.Clave = oHashCrypto.ConvertToHashMD5(oUsuario.Clave);
            }

            if (oDALUsuario.Guardar(oUsuario))
            {
                if (oBLLDV.ActualizarDVSistema()) return true; else { return false; };
            }
            else
            {
                return false;
            }
        }


        public bool Baja(BEUsuario oUsuario)
        {
            try
            {
                return oDALUsuario.Baja(oUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public BEUsuario GetOne(int iId)
        {
            throw new NotImplementedException();
        }

        public List<BEUsuario> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            return oDALUsuario.ListarTodo(EsControlCambio, iIdUsuario);
        }

        public LoginResult Login(string oUsuarioName, string oClave)
        {
            var Sesion = BLLSingletonSesion.Instancia;

            if (Sesion.IsLoggedIn())
            {
                throw new Exception("Ya existe una sesion iniciada");
            }

            oBEUsuario = new BEUsuario { Usuario = oUsuarioName };

            oBEUsuario = oDALUsuario.ListarObjeto(oBEUsuario);

            if (oBEUsuario == null) throw new LoginException(LoginResult.InvalidUsername);

            if (!oHashCrypto.ConvertToHashMD5(oClave).Equals(oBEUsuario.Clave)) throw new LoginException(LoginResult.InvalidPassword);

            else
            {
                oBLLPermisos = new BLLPermisos();
                oBLLPermisos.FillUserComponents(oBEUsuario);
                Sesion.Login(oBEUsuario);

                Bitacora oBitacora = new Bitacora()
                {
                    Detalle = TipoBitacoraEnum.AccesoUsuario.GetDescription(),
                    UsuarioResponsable = oBEUsuario,
                    Fecha = DateTime.Now,
                };

                oBLLBitacora.GuardarBitacora(oBitacora);

                return LoginResult.ValidUser;
            }
        }

        public void Logout()
        {
            var Sesion = BLLSingletonSesion.Instancia;
            if (!Sesion.IsLoggedIn())
                throw new Exception("No hay sesión iniciada"); //doble validación, anulo en boton en formulario y valido en la bll


            Sesion.Logout();
        }

        public void GuardarPermisos(BEUsuario oBEUsuario)
        {
            oDALUsuario.GuardarPermisos(oBEUsuario);
        }

        public bool GuardarConDV(BEUsuario oUsuario)
        {
            // Calcular DV antes de guardar
            oUsuario.DV = oBLLDV.CalcularDVUsuario(oUsuario);

            return Guardar(oUsuario);
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
