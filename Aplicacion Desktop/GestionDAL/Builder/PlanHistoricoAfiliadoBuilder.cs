using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class PlanHistoricoAfiliadoBuilder : IBuilder<PlanHistoricoAfiliado>
    {
        #region Miembros de IBuilder<PlanHistoricoAfiliado>

        public PlanHistoricoAfiliado Build(System.Data.DataRow row)
        {
            PlanHistoricoAfiliado planHistoricoAfiliado = new PlanHistoricoAfiliado();
            planHistoricoAfiliado.IdPlanHistoricoAfiliado = Convert.ToDecimal(row["id_plan_historico_afiliado"]);
            planHistoricoAfiliado.IdPlan = Convert.ToDecimal(row["id_plan"]);
            planHistoricoAfiliado.IdAfiliado = Convert.ToDecimal(row["id_afiliado"]);
            planHistoricoAfiliado.Fecha = Convert.ToDateTime(row["fecha"]);
            planHistoricoAfiliado.Habilitado = Convert.ToBoolean(row["habilitado"]);
            return planHistoricoAfiliado;
        }

        #endregion
    }
}
