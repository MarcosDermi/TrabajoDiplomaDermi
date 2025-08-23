using BE;
using ABSTRACCION;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVICES;
using System.Security.Cryptography;
using System.ComponentModel;

namespace BLL
{
    public class BLLUsuario : IGestor<BEUsuario>
    {
        public BLLUsuario() 
        {
            oDatos = new Datos();
            oValidators = new Validators();
            oDALUsuario = new DALUsuario();
            oHashCrypto = new HashCrypto();
            oBLLPermisos = new BLLPermisos();
            oBLLBitacora = new BLLBitacora();
            oBLLDV = new BLLDV();
        }

        Datos oDatos;
        Validators oValidators;
        DALUsuario oDALUsuario;
        HashCrypto oHashCrypto;
        BEUsuario oBEUsuario;
        BLLPermisos oBLLPermisos;
        BLLBitacora oBLLBitacora;
        BLLDV oBLLDV;


        public bool Guardar(BEUsuario oUsuario)
        {

            if (!oValidators.validarNombreOApellido(oUsuario.Nombre))
            {
                throw new Exception("Su nombre o apellido no debe contener caracteres especiales");
            }


            if (!oValidators.validarNombreOApellido(oUsuario.Apellido))
            {
                throw new Exception("Su apellido no debe contener caracteres especiales");
            }

            if (!oValidators.validarDni(oUsuario.DNI.ToString()))
            {
                throw new Exception("El dni ingresado no contiene caracteres invalidos");
            }


            //Agrego esta validacion asi todo esto mismo nos sirve para MODIFICAR..

            if (oUsuario.Id==0)
            {
                if (!oValidators.validarPassword(oUsuario.Clave))
                {
                    throw new Exception("Su contraseña debe contener:\n\t•Minimo 8 caracteres\n\t•Minimo 1 Mayuscula\n\t•Minimo 1 numero");
                }
                else
                {
                    oUsuario.Clave = oHashCrypto.ConvertToHashMD5(oUsuario.Clave);
                }
            }

            if (!oValidators.validarUsuario(oUsuario.Usuario))
            {
                throw new Exception("Su usuario solo puede contener texto alfanumerico o simple");
            }

            if (!oValidators.validarMail(oUsuario.Mail))
            {
                throw new Exception("Ingrese un mail valido");
            }

            //dps de todas las validaciones, encriptamos la pass para finalmente guardar.

           

            if (oDALUsuario.Guardar(oUsuario))
            {
                if (oBLLDV.ActualizarDVSistema()) return true; else { return false; } ;
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

        public BEUsuario ListarObjeto(BEUsuario Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEUsuario> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            return oDALUsuario.ListarTodo(EsControlCambio, iIdUsuario);
        }

        public LoginResult Login(string oUsuarioName, string oClave)
        {
            if (SingletonSesion.instancia.IsLogged())
            {
                throw new Exception("Ya existe una sesion iniciada");
            } 

            oBEUsuario = new BEUsuario();
            oBEUsuario.Usuario=oUsuarioName;

            oBEUsuario = oDALUsuario.ListarObjeto(oBEUsuario);

            if (oBEUsuario == null) throw new LoginException(LoginResult.InvalidUsername);

            if (!oHashCrypto.ConvertToHashMD5(oClave).Equals(oBEUsuario.Clave)) throw new LoginException(LoginResult.InvalidPassword);

            else 
            {
                oBLLPermisos = new BLLPermisos();
                oBLLPermisos.FillUserComponents(oBEUsuario);
                SingletonSesion.instancia.Login(oBEUsuario);

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
            if (!SingletonSesion.instancia.IsLogged())
                throw new Exception("No hay sesión iniciada"); //doble validación, anulo en boton en formulario y valido en la bll


            SingletonSesion.instancia.Logout();
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




    }
}
