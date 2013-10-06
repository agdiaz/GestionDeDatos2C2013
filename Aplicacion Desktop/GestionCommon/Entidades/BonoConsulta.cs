using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class BonoConsulta
    {
        public decimal IdCompra { get; set; }
        public decimal IdTurno { get; set; }
        public decimal IdPlanMedico { get; set; }
        public bool Habilitado { get; set; }
    }
}
