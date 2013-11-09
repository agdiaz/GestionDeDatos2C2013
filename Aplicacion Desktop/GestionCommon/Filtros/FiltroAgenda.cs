using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Filtros
{
    public class FiltroAgenda
    {
        public decimal IdProfesional { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public bool Habilitado { get; set; }
    }
}
