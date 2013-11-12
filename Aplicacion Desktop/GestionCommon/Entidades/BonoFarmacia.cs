using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;

namespace GestionCommon.Entidades
{
    public class BonoFarmacia : Bono
    {
        public decimal IdBonoFarmacia { get; set; }
        public decimal IdReceta { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public override string ToString()
        {
            return string.Format("Bono farmacia - Plan: {0} (Venc. {1})", NombrePlanMedico, FechaHelper.Format(FechaVencimiento, FechaHelper.DateFormat));  
        }
    }
}
