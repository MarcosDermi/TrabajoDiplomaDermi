using DAL;
using SERVICES;
using System;
using System.Collections;
using System.Data;

namespace BLL
{
    public class BLLCategorias
    {
        DALCategorias oDALCategorias;

        public BLLCategorias()
        {
            oDALCategorias = new DALCategorias();
        }

        public DataTable ObtenerCategorias()
        {
            return oDALCategorias.ObtenerCategorias();
        }

        public DataTable ObtenerSubcategorias()
        {
            return oDALCategorias.ObtenerSubcategorias();
        }

        public DataTable ObtenerSubcategoriasPorCategoria(int CategoriaID)
        {
            return oDALCategorias.ObtenerSubcategoriasPorCategoria(CategoriaID);
        }
    }
}
