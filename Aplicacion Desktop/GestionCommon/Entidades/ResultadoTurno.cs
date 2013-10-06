using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class ResultadoTurno
    {
        public decimal IdResultadoTurno { get; set; }
        public decimal IdTurno { get; set; }
        public string Diagnostico { get; set; }
        public string Sintoma { get; set; }
        public DateTime FechaDiagnostico { get; set; }
    }
}
