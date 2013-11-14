using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class BonoConsulta : Bono
    {
        public decimal IdBonoConsulta { get; set; }
        public decimal? IdTurno { get; set; }
        
        public override string ToString()
        {
            return string.Format("Bono consulta - Plan: {0}", NombrePlanMedico);
        }
    }
}
