using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using BE;

namespace DAL
{
    public class DALDV
    {
        public DALDV()
        {
            oDatos = new Datos();
            hDatos = new Hashtable();
        }

        Datos oDatos;
        Hashtable hDatos;

        public string ObtenerDVSistema()
        {
            oDatos = new Datos();
            string stpNombre = "BuscarDVSistema";
            DataTable oDt = oDatos.Leer(stpNombre, null);

            if (oDt.Rows.Count > 0)
            {
                return oDt.Rows[0]["DV"].ToString();
            }
            return "";
        }

        public bool ActualizarDVSistema(string dv)
        {
            oDatos = new Datos();
            string stpNombre = "ActualizarDVSistema";
            hDatos = new Hashtable();
            hDatos.Add("@DV", dv);

            return oDatos.Escribir(stpNombre, hDatos);
        }

        public List<BEUsuario> ListarUsuariosConDV()
        {
            List<BEUsuario> lstUsuarios = new List<BEUsuario>();

            string stpNombre = "ObtenerAllUsuarios";

            oDatos = new Datos();
            DataTable oDt = oDatos.Leer(stpNombre, null);

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

            return lstUsuarios;
        }

        public bool ActualizarDVUsuario(BEUsuario usuario)
        {
            oDatos = new Datos();
            string stpNombre = "ActualizarDVUsuario";
            hDatos = new Hashtable();
            hDatos.Add("@Id", usuario.Id);
            hDatos.Add("@DV", usuario.DV);

            return oDatos.Escribir(stpNombre, hDatos);
        }

        public bool ActualizarDVUsuario(int idUsuario, string dv)
        {
            oDatos = new Datos();
            string stpNombre = "ActualizarDVUsuario";
            hDatos = new Hashtable();
            hDatos.Add("@Id", idUsuario);
            hDatos.Add("@DV", dv);

            return oDatos.Escribir(stpNombre, hDatos);
        }

        public List<BEUsuario> ListarUsuariosCorruptos()
        {
            var todosLosUsuarios = ListarUsuariosConDV();
            var usuariosCorruptos = new List<BEUsuario>();

       

            return usuariosCorruptos;
        }
    }
} 