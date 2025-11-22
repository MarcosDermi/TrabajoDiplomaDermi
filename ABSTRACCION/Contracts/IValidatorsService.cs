using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ABSTRACCION.Contracts
{
    public interface IValidatorsService
    {
        bool PassValidator(string Contraseña);
        bool validarPassword(string password);
        bool validarUsuario(string user);
        bool validarMail(string mail);
        bool validarNombreOApellido(string nombre);
        bool validarDni(string dni);
        bool validarTelefono(string telefono);
        bool validarPrecio(string precio);
        bool validarDuracion(string duracion);
        bool validarBuffer(string buffer);
        bool validarDescripcion(string descripcion);
        bool validarComboBox(ComboBox combo);
        bool validarDataGridView(DataGridView dgv);
        bool validarListaServicios(IList<BEServicio> lista);
        bool validarFechaHora(DateTime fechaHora);
        bool validarDataTable(DataTable dt);
        bool validarEntero(string entero);
        bool validarDecimal(string decimalString);
        bool validarTexto(string texto);
        bool validarListaString(IList<string> lista);
        bool validarListaEnteros(IList<int> lista);
        bool validarListaProfesionales(IList<BEProfesional> lista);
        bool validarListaServiciosCheckedListBox(CheckedListBox clb);
        bool validarListaProfesionalesCheckedListBox(CheckedListBox clb);
        bool validarListaStringCheckedListBox(CheckedListBox clb);
        bool validarListaEnterosCheckedListBox(CheckedListBox clb);
        List<BEUsuario> ObtenerUsuariosYMailsRegistrados();
    }
}
