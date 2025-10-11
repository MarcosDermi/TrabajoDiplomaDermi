using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class DALCategorias
    {
        Datos oDatos;
        Hashtable Hdatos;

        public DALCategorias()
        {
            oDatos = new Datos();
        }

        public DataTable ObtenerCategorias()
        {
            return oDatos.Leer("ObtenerCategorias", null);
        }

        public DataTable ObtenerSubcategorias()
        {
            return oDatos.Leer("ObtenerSubcategorias", null);
        }

        public DataTable ObtenerSubcategoriasPorCategoria(int CategoriaID)
        {
            Hdatos = new Hashtable();
            Hdatos.Add("@CategoriaId", CategoriaID);
            return oDatos.Leer("ObtenerSubcategoriasPorCategoria", Hdatos);
        }
    }

}
