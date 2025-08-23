using System.Collections.Generic;

namespace BE
{
    public class BEPatente: BEComponente
    {
        public override IList<BEComponente> Hijos { get { return new List<BEComponente>(); } }

        public override void VaciarHijos()
        {
        }
    }
}
