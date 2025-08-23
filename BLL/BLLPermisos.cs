using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPermisos
    {
        DALPermisos oDALPermisos;

        public BLLPermisos()
        {
            oDALPermisos = new DALPermisos();
        }


        public bool Existe(BEComponente oBEComponente, int iId)
        {
            bool bExiste = false;

            if (oBEComponente.Id.Equals(iId)) bExiste = true;
            else
            { 
                foreach (var oHijos in oBEComponente.Hijos)
                {

                    bExiste = Existe(oHijos, iId);
                    if (bExiste) return true;
                }
            }
            return bExiste;

        }

        public Array GetAllPermisos()
        {
            return oDALPermisos.GetAllPermisos();
        }

        public bool GuardarComponente(BEComponente oPadre, bool bEsFamilia)
        {
            return oDALPermisos.GuardarComponente(oPadre, bEsFamilia);
        }

        public void GuardarFamilia(BEFamilia oFamilia)
        {
            oDALPermisos.GuardarFamilia(oFamilia);
        }

        public IList<BEPatente> GetAllPatentes()
        {
            return oDALPermisos.GetAllPatentes();
        }

        public IList<BEFamilia> GetAllFamilias()
        {
            return oDALPermisos.GetAllFamilias();
        }

        public IList<BEComponente> GetAll(string sFamilia)
        {
            return oDALPermisos.GetAll(sFamilia);

        }

        public void FillUserComponents(BEUsuario oUsuario)
        {
            oDALPermisos.FillUserComponents(oUsuario);

        }

        public void FillFamilyComponents(BEFamilia oFamilia)
        {
            oDALPermisos.FillFamilyComponents(oFamilia);
        }


    }
}
