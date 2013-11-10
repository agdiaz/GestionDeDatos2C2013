using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;

namespace GestionCommon.Entidades
{
    public class BonoFarmacia
    {
        public decimal IdCompra { get; set; }
        public decimal IdPlanMedico { get; set; }
        public string NombrePlanMedico { get; set; }
        public decimal IdReceta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Habilitado { get; set; }

        public override string ToString()
        {
            return string.Format("Bono farmacia - Plan: {0} (Venc. {1})", NombrePlanMedico, FechaHelper.Format(FechaVencimiento, FechaHelper.DateFormat));  
        }
    }
}
