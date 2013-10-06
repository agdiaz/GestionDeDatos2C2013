using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class PlanBuilder : IBuilder<PlanMedico>
    {
        #region Miembros de IBuilder<Plan>

        public PlanMedico Build(System.Data.DataRow row)
        {
            PlanMedico plan = new PlanMedico();
            plan.IdPlan = Convert.ToDecimal(row["id_plan"]);
            plan.Descripcion = Convert.ToString(row["descripcion"]);
            plan.PrecioBonoConsulta = Convert.ToDecimal(row["precio_bono_consulta"]);
            plan.PrecioBonoFarmacia = Convert.ToDecimal(row["precio_bono_farmacia"]);
            plan.Habilitado = Convert.ToBoolean(row["habilitado"]);
            return plan;
        }

        #endregion
    }
}
