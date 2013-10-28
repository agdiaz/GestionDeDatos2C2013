using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using System.Data.SqlClient;
using GestionConector;
using GestionDAL.Builder;
using GestionCommon.Helpers;

namespace GestionDAL
{
    public class PlanMedicoDAL : EntidadBaseDAL<PlanMedico, PlanMedico>
    {
        public PlanMedicoDAL(ILog log)
        :base(new SqlServerConector(log), new PlanBuilder(), "PlanMedico")
        {

        }

        protected override IList<SqlParameter> GenerarParametrosModificar(PlanMedico entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(PlanMedico entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(PlanMedico entidad)
        {
            throw new NotImplementedException();
        }
    }
}
