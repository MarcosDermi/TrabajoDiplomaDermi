
using System;
using System.Collections.Generic;

namespace BE
{
    public class BEJornadaLaboral
    {
        public DayOfWeek Dia { get; set; }
        public List<BEFranja> Franjas { get; set; } = new List<BEFranja>();

    }
}
