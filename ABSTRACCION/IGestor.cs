using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSTRACCION
{
    public interface IGestor<T>
    {
        bool Guardar(T Objeto);

        bool Baja(T Objeto);

        List<T> ListarTodo(bool EsControlCambio, int iIdUsuario);

        T ListarObjeto(T Objeto);
    }
}
