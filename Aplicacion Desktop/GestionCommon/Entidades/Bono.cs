using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Bono
    {
        public decimal IdCompra { get; set; }
        public decimal IdPlanMedico { get; set; }
        public string NombrePlanMedico { get; set; }
        public DateTime FechaImpresion { get; set; }
        public bool Habilitado { get; set; }
    }
}
