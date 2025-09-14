using BE;
using System.Collections.Generic;

namespace ABSTRACCION.Contracts
{
    public interface IDigitoVerificadorService
    {
        string CalcularDVUsuario(BEUsuario usuario);
        string GenerarSHA(string cadena);
        string CalcularDVSistema(List<BEUsuario> usuarios);
    }
}
