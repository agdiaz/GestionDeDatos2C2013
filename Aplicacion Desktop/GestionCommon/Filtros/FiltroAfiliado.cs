using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Filtros
{
    public class FiltroAfiliado
    {
        public decimal NroAfiliado { get; set; }
        public decimal IdPlanMedico { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Documento { get; set; }
    }
}
