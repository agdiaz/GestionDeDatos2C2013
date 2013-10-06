using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class AfiliadoCambioPlan
    {
        public decimal IdAfiliado { get; set; }
        public decimal IdPlan { get; set; }
        public DateTime Fecha { get; set; }
        public bool Habilitado { get; set; }
    }
}
