using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class TurnoDisponible
    {
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }
        public bool Disponible { get; set; }
        public string NombreAfiliado { get; set; }
        public bool ConDiagnostico { get { return IdResultadoTurno > 0; } }
        public DateTime? FechaLLegada { get; set; }
        
        public decimal IdResultadoTurno { get; set; }
        public decimal IdTurno { get; set; }
        public decimal IdAfiliado { get; set; }

    }
}
