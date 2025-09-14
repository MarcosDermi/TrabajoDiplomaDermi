using BE;
using DAL;
using SERVICES;
using System;
using System.Collections.Generic;

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

        bool isInRole(BEComponente oComponente, TipoPermiso enumPermiso, bool bExiste)
        {
            if (oComponente.Permiso.Equals(enumPermiso)) bExiste = true;
            else
            {
                foreach (var oHijos in oComponente.Hijos)
                {
                    bExiste = isInRole(oHijos, enumPermiso, bExiste);
                    if (bExiste) return true;
                }
            }

            return bExiste;
        }

        public bool IsInRole(TipoPermiso enumPermiso)
        {
            var Sesion = BLLSingletonSesion.Instancia;

            bool bExiste = false;
            foreach (var oPermiso in Sesion.Usuario.Permisos)
            {
                if (oPermiso.Permiso.Equals(enumPermiso)) return true;
                else
                {
                    bExiste = isInRole(oPermiso, enumPermiso, bExiste);
                    if (bExiste) return true;
                }
            }

            return bExiste;
        }

    }
}
