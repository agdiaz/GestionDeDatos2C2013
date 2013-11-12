using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class TurnoDisponible
    {
        public DateTime HoraDesde { get; set; }
        public DateTime HoraHasta { get; set; }
        public bool Disponible { get; set; }
    }
}
