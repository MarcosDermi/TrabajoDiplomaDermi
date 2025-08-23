using System.Collections.Generic;

namespace BE
{
    public class BEFamilia : BEComponente
    {
        private List<BEComponente> _hijos = new List<BEComponente>();

        public override IList<BEComponente> Hijos => _hijos;

        public override void VaciarHijos()
        {
            _hijos.Clear();
        }
    }
}
