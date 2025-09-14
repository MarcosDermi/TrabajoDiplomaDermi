using ABSTRACCION.Contracts;
using BE.ClasesMultiLenguaje;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLObserver
    {

        static IList<IdiomaObserver> Observadores = new List<IdiomaObserver>();  //creo lista de observadores
        public void agregarObservador(IdiomaObserver Observer)    //se agregan observadores
        {
            Observadores.Add(Observer);
        }

        public void eliminarObservador(IdiomaObserver Observer)  //se eliminan observadores
        {
            Observadores.Remove(Observer);
        }

        /*
          Al realizar de un cambio de idioma, guardar lista de traducciones... en algun lado, puede ser en la sesion..
        Pero.. que no se ejecute constantemente.. 
        */


        public void notificarObeservadores(Idioma Idioma)   //se notifica a los observadores
        {
            foreach (var observer in Observadores)
            {
                observer.CambiarIdioma(Idioma);
            }
        }

        public void cambiarIdioma(Idioma Idioma)    //Cambio de idioma
        {
            var Sesion = BLLSingletonSesion.Instancia;

            if (Sesion != null)
            {
                Sesion.CambiarIdioma(Idioma);
                notificarObeservadores(Idioma);
            }
        }
    }
}
