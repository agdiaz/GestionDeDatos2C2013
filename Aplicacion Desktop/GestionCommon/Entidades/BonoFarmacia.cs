using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class BonoFarmacia
    {
        public decimal IdCompra { get; set; }
        public decimal IdPlan { get; set; }
        public decimal IdReceta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Habilitado { get; set; }
    }
}
