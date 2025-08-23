using System.Collections.Generic;
using BE.ClasesMultiLenguaje;



namespace SERVICES
{
    public static class Observer
    {
        
        static IList<IdiomaObserver> Observadores = new List<IdiomaObserver>();  //creo lista de observadores
        public static void agregarObservador(IdiomaObserver Observer)    //se agregan observadores
        {
            Observadores.Add(Observer);
        }

        public static void eliminarObservador(IdiomaObserver Observer)  //se eliminan observadores
        {
            Observadores.Remove(Observer);
        }

        /*
          Al realizar de un cambio de idioma, guardar lista de traducciones... en algun lado, puede ser en la sesion..
        Pero.. que no se ejecute constantemente.. 
        */
         

        public static void notificarObeservadores(Idioma Idioma)   //se notifica a los observadores
        {
            foreach (var observer in Observadores)
            {
                observer.CambiarIdioma(Idioma);
            }
        }

        public static void cambiarIdioma(Idioma Idioma)    //Cambio de idioma
        {
            if (SingletonSesion.instancia != null)
            {
                //_session.Usuario.Idioma = Idioma;
                SingletonSesion.instancia.idioma = Idioma;
                
                notificarObeservadores(Idioma);
            }
        }
        
    }
}

