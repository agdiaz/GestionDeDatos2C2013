using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class PlanMedico
    {
        public decimal IdPlan { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioBonoFarmacia { get; set; }
        public decimal PrecioBonoConsulta { get; set; }
        public bool Habilitado { get; set; }
    }
}
