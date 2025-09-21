using System.Collections.Generic;
using System.Data;

namespace ABSTRACCION
{
    public interface IGestor<T>
    {
        bool Guardar(T Objeto);

        bool Baja(T Objeto);

        List<T> ListarTodo(bool EsControlCambio, int iIdUsuario);

        DataTable GetAll();

        T GetOne(int iId);
    }
}
