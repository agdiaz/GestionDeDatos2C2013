using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class DiaAgenda
    {
        public decimal IdDiaAgenda { get; set; }
        public decimal NroDiaSemana { get; set; }
        public string NombreDiaSemana { get; set; }
        public int HoraDesde { get; set; }
        public int HoraHasta { get; set; }
    }
}
