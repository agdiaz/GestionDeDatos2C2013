using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionDAL;

namespace GestionDomain
{
    public class PlanMedicoDomain : EntidadBaseDomain<PlanMedico, FiltroPlanMedico>
    {
        public PlanMedicoDomain(IEntidadDAL<PlanMedico, FiltroPlanMedico> dal)
        :base(dal)
        {

        }
    }
}
