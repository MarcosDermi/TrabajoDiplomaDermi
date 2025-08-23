using System;
using System.Collections;
using System.Collections.Generic;
using ABSTRACCION;

namespace BE
{
    public abstract class BEComponente
    {
        #region Propiedades

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool es_patente { get; set; }
        public TipoPermiso Permiso { get; set; }
        public abstract IList<BEComponente> Hijos { get; }


        public virtual void AgregarHijo(BEComponente hijo)
        {

                if (Contiene(hijo)) throw new InvalidOperationException($"El componente con ID {hijo.Id} ya existe en la jerarquía. Se evita una referencia circular.");

                Hijos.Add(hijo);
        }

        public bool Contiene(BEComponente componente)
        {
            if (this.Id == componente.Id) return true;

            foreach (var hijo in Hijos)
            {
                if (hijo.Contiene(componente))
                    return true;
            }

            return false;
        }

        public abstract void VaciarHijos();
        
        public override string ToString()
        {
                return Nombre;
        }
        #endregion

    }
}
