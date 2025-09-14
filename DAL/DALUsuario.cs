using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALUsuario
    {
        public DALUsuario() 
        {
            Datos oDatos = new Datos();
            Hashtable hDatos = new Hashtable();
        }

        Datos oDatos;
        Hashtable hDatos;

        public bool ValidarLogin(BEUsuario oUsuario)
        {
            return false;
        }

        public bool Guardar(BEUsuario oUsuario)
        {
            oDatos = new Datos();
            string stpNombre;

            if (oUsuario.Id==0)
            {
                stpNombre = "AltaUsuario";
                hDatos = new Hashtable();
                hDatos.Add("@Usuario", oUsuario.Usuario);
                hDatos.Add("@Nombre", oUsuario.Nombre);
                hDatos.Add("@Apellido", oUsuario.Apellido);
                hDatos.Add("@Mail", oUsuario.Mail);
                hDatos.Add("@FechaNac", oUsuario.FechaNac);
                hDatos.Add("@DNI", oUsuario.DNI);
                hDatos.Add("@isAdmin", false);
                hDatos.Add("@Clave", oUsuario.Clave);
                hDatos.Add("@deleted", 0);
                hDatos.Add("@DV", oUsuario.DV);

                oDatos.Escribir(stpNombre, hDatos);

                stpNombre = "AltaUsuarioHistorial";

                return oDatos.Escribir(stpNombre, hDatos);
            }
            else
            {
                stpNombre = "ModificarUsuario";
                hDatos = new Hashtable();
                hDatos.Add("@Usuario", oUsuario.Usuario);
                hDatos.Add("@Nombre", oUsuario.Nombre);
                hDatos.Add("@Apellido", oUsuario.Apellido);
                hDatos.Add("@Mail", oUsuario.Mail);
                hDatos.Add("@FechaNac", oUsuario.FechaNac);
                hDatos.Add("@DNI", oUsuario.DNI);
                hDatos.Add("@isAdmin", oUsuario.isAdmin);
                hDatos.Add("@Id", oUsuario.Id);

                oDatos.Escribir(stpNombre, hDatos);

                hDatos.Remove("@Id");
                //hDatos.Add("@UsuarioID", oUsuario.Id);
                hDatos.Add("@Clave", oUsuario.Clave);
                hDatos.Add("@deleted", 0);
                hDatos.Add("@DV", oUsuario.DV);
                stpNombre = "AltaUsuarioHistorial";

                return oDatos.Escribir(stpNombre, hDatos);
            }
            
           
        }

        public bool Baja(BEUsuario oUsuario)
        {
            oDatos = new Datos();
            string stpNombre;

            if (oUsuario.Id!=0)
            {
                stpNombre = "BajaUsuario";
                hDatos=new Hashtable();
                hDatos.Add("Id", oUsuario.Id);

                return oDatos.Escribir(stpNombre, hDatos);
            }
            else
            {
                return false;
            }
        }

        public List<BEUsuario> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            List<BEUsuario> lstUsuarios = new List<BEUsuario>();

            string stpNombre;
            oDatos = new Datos();
            hDatos = new Hashtable();

            if (!EsControlCambio)
            {
                stpNombre = "ObtenerAllUsuarios";
            }
            else
            {
                stpNombre = "ObtenerAllUsuarioHistorial";
                hDatos.Add("@Id", iIdUsuario);
            }

            DataTable oDt = oDatos.Leer(stpNombre, hDatos);

            if (oDt.Rows.Count > 0)
            {
                foreach (DataRow row in oDt.Rows)
                {
                    BEUsuario oUsuario = new BEUsuario();
                    oUsuario.Id = Convert.ToInt32(row["Id"]);
                    oUsuario.Usuario = row["Usuario"].ToString();
                    oUsuario.Nombre = row["Nombre"].ToString();
                    oUsuario.Apellido = row["Apellido"].ToString();
                    oUsuario.Mail = row["Mail"].ToString();
                    oUsuario.FechaNac = Convert.ToDateTime(row["FechaNac"]);
                    oUsuario.DNI = Convert.ToInt32(row["DNI"]);
                    oUsuario.isAdmin = Convert.ToBoolean(row["isAdmin"]);
                    oUsuario.Clave = row["Clave"].ToString();
                    oUsuario.DV = row["DV"]?.ToString() ?? "";

                    lstUsuarios.Add(oUsuario);
                }
            }
            else
            {
                lstUsuarios = null;
            }

            return lstUsuarios;
        }

        public BEUsuario ListarObjeto(BEUsuario oBeUsuario)
        {
            string stpNombre = "ListarUsuario";
            hDatos = new Hashtable();
            hDatos.Add("@Usuario", oBeUsuario.Usuario);
            BEUsuario oUsuario = new BEUsuario();

            oDatos = new Datos();
            DataTable oDt = oDatos.Leer(stpNombre, hDatos);

            if (oDt.Rows.Count > 0)
            {
                foreach (DataRow row in oDt.Rows)
                {
                    oUsuario.Id = Convert.ToInt32(row["Id"]);
                    oUsuario.Usuario = row["Usuario"].ToString();
                    oUsuario.Nombre = row["Nombre"].ToString();
                    oUsuario.Apellido = row["Apellido"].ToString();
                    oUsuario.Mail = row["Mail"].ToString();
                    oUsuario.FechaNac = Convert.ToDateTime(row["FechaNac"]);
                    oUsuario.DNI = Convert.ToInt32(row["DNI"]);
                    oUsuario.isAdmin = Convert.ToBoolean(row["isAdmin"]);
                    oUsuario.Clave = row["Clave"].ToString();
                    oUsuario.DV = row["DV"]?.ToString() ?? "";
                }
            }
            else
            {
                oUsuario = null;
            }

            return oUsuario;
        }

        public void GuardarPermisos(BEUsuario oUsuario)
        {

            try
            {
                var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["TD"].ConnectionString);
                cnn.Open();

                var cmd = new SqlCommand();
                cmd.Connection = cnn;

                cmd.CommandText = $@"delete from UsuariosPermisos where UsuarioID = @id;";
                cmd.Parameters.Add(new SqlParameter("id", oUsuario.Id));
                cmd.ExecuteNonQuery();

                foreach (var item in oUsuario.Permisos)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    cmd.CommandText = $@"insert into UsuariosPermisos (UsuarioID,PermisoID) values (@UsuarioID,@PermisoID) ";
                    cmd.Parameters.Add(new SqlParameter("UsuarioID", oUsuario.Id));
                    cmd.Parameters.Add(new SqlParameter("PermisoID", item.Id));

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
