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
        public string NombrePlanMedico { get; set; }
        public bool Habilitado { get; set; }

        public override string ToString()
        {
            return string.Format("Bono consulta - Plan: {0}", NombrePlanMedico);
        }
    }
}
