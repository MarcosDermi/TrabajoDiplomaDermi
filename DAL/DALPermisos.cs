using ABSTRACCION;
using BE;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALPermisos:IGestor<BEComponente>
    {
        public DALPermisos() 
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

        public bool GuardarComponente(BEComponente oPadre, bool bEsFamilia)
        {
            try
            {
                string stpNombre = "GuardarComponente";
                oDatos = new Datos();

                hDatos = new Hashtable();
                hDatos.Add("@Nombre", oPadre.Nombre);

                if (bEsFamilia) 
                { hDatos.Add("@Permiso", DBNull.Value); } 
                else { hDatos.Add("@Permiso", oPadre.Permiso.ToString()); }


                return oDatos.Escribir(stpNombre, hDatos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GuardarFamilia(BEFamilia oComponente)
        {

            try
            {
                foreach (var hijo in oComponente.Hijos)
                {
                    if (hijo.Contiene(oComponente))
                    {
                        throw new InvalidOperationException($"GuardarFamilia falló: el hijo con ID {hijo.Id} contiene al padre con ID {oComponente.Id}. Se detectó recursividad.");
                    }
                }

                string stpNombre = "BorrarPermisosPermiso_X_IdPadre";
                oDatos = new Datos();

                hDatos = new Hashtable();
                hDatos.Add("@Id", oComponente.Id);

                bool bEscribir = oDatos.Escribir(stpNombre, hDatos);

                if (bEscribir) { 
                foreach (var oHijos in oComponente.Hijos)
                {

                    string stpNombre2 = "AgregarRelacionPermiso";

                    hDatos = new Hashtable();
                    hDatos.Add("@IdPermisoPadre", oComponente.Id);
                    hDatos.Add("@IdPermisoHijo", oHijos.Id);

                    bEscribir = oDatos.Escribir(stpNombre2, hDatos);
                }
                }
                else
                {
                    throw new ArgumentException("Error Inesperado");
                }

            }
            catch (ArgumentException e)
            {

                throw e;
            }
            catch (InvalidOperationException e)
            {

                throw e;
            }
        }

        public IList<BEPatente> GetAllPatentes()
        {

            string stpNombre = "GetAllPatentes";

            oDatos = new Datos();
            DataTable oDt = oDatos.Leer(stpNombre, null);

            var oLstPatentes = new List<BEPatente>();

            foreach(var oDr in oDt.AsEnumerable())
            {

                var oComponente = new BEPatente();
                oComponente.Id = Convert.ToInt32(oDr["PermisoID"]);
                oComponente.Nombre = oDr["Nombre"].ToString();
                oComponente.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso),oDr["Permiso"].ToString());

                oLstPatentes.Add(oComponente);

            }

            return oLstPatentes;
        }

        public IList<BEFamilia> GetAllFamilias()
        {

            string stpNombre = "GetAllFamilias";

            oDatos = new Datos();
            DataTable oDt = oDatos.Leer(stpNombre, null);

            var oLstFamilias = new List<BEFamilia>();

            foreach (var oDr in oDt.AsEnumerable())
            {

                var oFamilia = new BEFamilia();
                oFamilia.Id = Convert.ToInt32(oDr["PermisoID"]);
                oFamilia.Nombre = oDr["Nombre"].ToString();

                oLstFamilias.Add(oFamilia);

            }

            return oLstFamilias;
        }

        public IList<BEComponente> GetAll(string familia)
        {

            var where = "is NULL";

            if (!String.IsNullOrEmpty(familia))
            {
                where = familia;
            }

            var cs = new SqlConnectionStringBuilder();
            cs.IntegratedSecurity = true;
            cs.DataSource = ".";
            cs.InitialCatalog = "DB_IngSoft";
            var cnn = new SqlConnection(cs.ConnectionString);
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;

            var sql = $@"with recursivo as (
                        select sp2.IdPermisoPadre, sp2.IdPermisoHijo  from PermisosPermisos SP2
                        where sp2.IdPermisoPadre {where} --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.IdPermisoPadre, sp.IdPermisoHijo from PermisosPermisos sp 
                        inner join recursivo r on r.IdPermisoHijo = sp.IdPermisoPadre
                        )
                        select r.IdPermisoPadre,r.IdPermisoHijo,p.PermisoID,p.Nombre, p.Permiso
                        from recursivo r 
                        inner join Permisos p on r.IdPermisoHijo = p.PermisoID 
						
                        ";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<BEComponente>();

            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["IdPermisoPadre"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("IdPermisoPadre"));
                }

                var id = reader.GetInt32(reader.GetOrdinal("PermisoID"));
                var nombre = reader.GetString(reader.GetOrdinal("Nombre"));

                var permiso = string.Empty;
                if (reader["Permiso"] != DBNull.Value)
                    permiso = reader.GetString(reader.GetOrdinal("Permiso"));


                BEComponente c;

                if (string.IsNullOrEmpty(permiso))//usamos este campo para identificar. Solo las patentes van a tener un permiso del sistema relacionado
                    c = new BEFamilia();

                else
                    c = new BEPatente();

                c.Id = id;
                c.Nombre = nombre;
                if (!string.IsNullOrEmpty(permiso))
                    c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);

                var padre = GetComponente(id_padre, lista);

                if (padre == null)
                {
                    lista.Add(c);
                }
                else
                {
                    padre.AgregarHijo(c);
                }

            }
            reader.Close();
            cnn.Close();


            return lista;
        }

        private BEComponente GetComponente(int iId, IList<BEComponente> lstComponentes)
        {
            BEComponente oComponente = lstComponentes != null? lstComponentes.Where(x => x.Id.Equals(iId)).FirstOrDefault() : null;

            if (oComponente == null && lstComponentes != null)
            { 
                foreach(var _oComponente in lstComponentes)
                {
                    var L = GetComponente(iId, _oComponente.Hijos);
                    if (L != null && L.Id == iId) return L;
                    else
                        if (L != null)
                        return GetComponente(iId, L.Hijos);
                }
            }

            return oComponente;

        }

        public Array GetAllPermisos()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }

        public void FillUserComponents(BEUsuario oUsuario)
        {

            var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString);
            cnn.Open();

            var cmd2 = new SqlCommand();
            cmd2.Connection = cnn;
            cmd2.CommandText = $@"select p.* from UsuariosPermisos up inner join Permisos p on up.PermisoID = p.PermisoID where UsuarioID = @id;";
            cmd2.Parameters.AddWithValue("id", oUsuario.Id);

            var reader = cmd2.ExecuteReader();
            oUsuario.Permisos.Clear();
            while (reader.Read())
            {

                var idp = reader.GetInt32(reader.GetOrdinal("PermisoID"));
                var nombrep = reader.GetString(reader.GetOrdinal("Nombre"));

                var permisop = String.Empty;
                if (reader["permiso"] != DBNull.Value)
                    permisop = reader.GetString(reader.GetOrdinal("Permiso"));

                BEComponente c1;
                if (!String.IsNullOrEmpty(permisop))
                {
                    c1 = new BEPatente();
                    c1.Id = idp;
                    c1.Nombre = nombrep;
                    c1.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permisop);
                    oUsuario.Permisos.Add(c1);
                }
                else
                {
                    c1 = new BEFamilia();
                    c1.Id = idp;
                    c1.Nombre = nombrep;

                    var f = GetAll("=" + idp);

                    foreach (var familia in f)
                    {
                        c1.AgregarHijo(familia);
                    }
                    oUsuario.Permisos.Add(c1);
                }



            }
            reader.Close();

        }

        public void FillFamilyComponents(BEFamilia oFamilia)
        {
            oFamilia.VaciarHijos();
            foreach (var item in GetAll("=" + oFamilia.Id))
            {
                oFamilia.AgregarHijo(item);
            }
        }




        public bool Guardar(BEComponente Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BEComponente Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEComponente> ListarTodo(bool EsControlCambio, int iIdUsuario)
        {
            throw new NotImplementedException();
        }

        public BEComponente ListarObjeto(BEComponente Objeto)
        {
            throw new NotImplementedException();
        }

        //public IList<BEComponente> GetAll(string sFamilia)
        //{
        //    var sWhere = "is NULL";

        //    if (!String.IsNullOrEmpty(sFamilia))
        //    {
        //        sWhere = sFamilia;
        //    }

        //    List<BEComponente> lstPermisos = new List<BEComponente>();

        //    hDatos = new Hashtable();
        //    hDatos.Add("@Familia", sFamilia);

        //    string stpNombre = "ObtenerAllPermisos";

        //    oDatos = new Datos();
        //    DataTable oDt = oDatos.Leer(stpNombre, hDatos);

        //    if (oDt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in oDt.Rows)
        //        {
        //            int id_padre = 0;

        //            if (row["id_permiso_padre"] != DBNull.Value)
        //            {
        //                id_padre = Convert.ToInt32(row["id_permiso_padre"]);
        //            }

        //            var id = Convert.ToInt32(row["id"]);
        //            var nombre = row["nombre"].ToString();
        //            var Patente = Convert.ToBoolean(row["es_patente"]);

        //            BEComponente oComponente;

        //            if (Patente) oComponente = new BEFamilia();
        //            else oComponente = new BEPatente();

        //            oComponente.Id = id;
        //            oComponente.Nombre = nombre;

        //            var oPadre = GetComponente(id_padre, lstPermisos);

        //            if (oPadre == null) { lstPermisos.Add(oComponente); }
        //            else { oPadre.AgregarHijo(oComponente); }

        //        }
        //    }
        //    else
        //    {
        //        lstPermisos = null;
        //    }

        //    return lstPermisos;
        //}

        public List<BEComponente> GetFamilias()
        {
            List<BEComponente> olstPermisos = new List<BEComponente>();

            string stpNombre = "ObtenerFamiliasPermisos";

            oDatos = new Datos();
            DataTable oDt = oDatos.Leer(stpNombre, hDatos);

            if (oDt.Rows.Count > 0)
            {
                foreach (DataRow row in oDt.Rows)
                {
                    var oPermiso = new BEFamilia()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nombre = row["Nombre"].ToString(),
                        es_patente = Convert.ToBoolean(row["EsPatente"])
                    };

                    olstPermisos.Add(oPermiso);
                }
            }

            return olstPermisos;
        }
    }
}
