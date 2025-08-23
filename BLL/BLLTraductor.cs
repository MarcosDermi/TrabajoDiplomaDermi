using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE.ClasesMultiLenguaje;

namespace BLL
{
    public class BLLTraductor
    {
        DALTraductor oDALTraductor;
        public BLLTraductor()
        {
            oDALTraductor=new DALTraductor();
        }

        public Idioma ObtenerIdiomaBase()
        {
            try
            {
                return oDALTraductor.ObtenerIdiomaBase();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            

        }

        public List<Palabra> obtenerPalabrasSinTraducir(int idioma)
        {
            try
            {
                return oDALTraductor.obtenerPalabrasSinTraducir(idioma);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            

        }
        public DataTable traerTablaxIdioma(int id)
        {

            try
            {
                return oDALTraductor.traerTablaxIdioma(id);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            

        }
        public List<Idioma> ObtenerIdiomas()
        {
            try
            {
                return oDALTraductor.ObtenerIdiomas();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
           
        }
        public Dictionary<string, Traduccion> obtenertraducciones(Idioma Idioma)
        {
            try
            {
                return oDALTraductor.obtenertraducciones(Idioma);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            
        }

        public List<string> obtenerIdiomaOriginal()
        {
            try
            {
                return oDALTraductor.obtenerIdiomaOriginal();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }

        public List<Palabra> obtenerPalabras()
        {
            try
            {
                return oDALTraductor.obtenerPalabras();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
           
        }
        public Idioma TraerIdioma(string idioma)
        {
            try
            {
                return oDALTraductor.TrarIdioma(idioma);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            
        }

        public bool CrearIdioma(Idioma Oidioma)
        {
            try
            {
                return oDALTraductor.CrearIdioma(Oidioma);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            
        }

        public bool IdiomaExistente(string idioma)
        {
            try
            {
                return oDALTraductor.idiomaExistente(idioma);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
           
        }

        public bool TraduccionExistente(int id_idioma, int id_palabra)
        {
            try
            {
                return oDALTraductor.TraduccionExistente(id_idioma, id_palabra);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
           
        }

        public Palabra TraerPalbra(string palabra)
        {
            try
            {
                return oDALTraductor.TraerPalbra(palabra);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
           
        }

        public bool CrearTraduccion(int ID_idioma, Traduccion Otraduccion)
        {
            try
            {
                return oDALTraductor.CrearTraduccion(ID_idioma, Otraduccion);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
           
        }
    }
}
