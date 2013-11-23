using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class DiaAgenda : EntidadBase
    {
        public decimal NroDiaSemana { get; set; }
        public string NombreDiaSemana { get; set; }
        public int HoraDesde { get; set; }
        public int MinutoDesde { get; set; }
        
        public int HoraHasta { get; set; }
        public int MinutoHasta { get; set; }
    }
}
