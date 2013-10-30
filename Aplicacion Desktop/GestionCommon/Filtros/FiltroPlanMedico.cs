using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Filtros
{
    public class FiltroPlanMedico
    {
        public string Nombre { get; set; }
        public decimal? BonoFarmacia { get; set; }
        public decimal? BonoConsulta { get; set; }

        public FiltroPlanMedico()
        {
            this.BonoFarmacia = null;
            this.BonoConsulta = null;
        }
    }
}
