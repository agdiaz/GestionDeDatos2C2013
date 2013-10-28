using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using System.Data.SqlClient;
using GestionConector;
using GestionDAL.Builder;
using GestionCommon.Helpers;
using GestionCommon.Filtros;

namespace GestionDAL
{
    public class PlanMedicoDAL : EntidadBaseDAL<PlanMedico, FiltroPlanMedico>
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

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroPlanMedico filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var pDescripcion = new SqlParameter("@p_descripcion", System.Data.SqlDbType.VarChar, 255, "p_descripcion");
            pDescripcion.Value = filtro.Nombre;
            parametros.Add(pDescripcion);

            var pFarmacia = new SqlParameter("@p_precio_farmacia", System.Data.SqlDbType.Decimal, 18, "p_precio_farmacia");
            pFarmacia.Value = filtro.BonoFarmacia;
            parametros.Add(pFarmacia);

            var pConsulta = new SqlParameter("@p_precio_consulta", System.Data.SqlDbType.Decimal, 18, "p_precio_consulta");
            pConsulta.Value = filtro.BonoConsulta;
            parametros.Add(pConsulta);

            return parametros;
        }
    }
}
