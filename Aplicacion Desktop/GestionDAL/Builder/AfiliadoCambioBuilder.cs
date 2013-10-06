using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class AfiliadoCambioBuilder : IBuilder<AfiliadoCambioPlan>
    {
        #region Miembros de IBuilder<AfiliadoCambioPlan>

        public AfiliadoCambioPlan Build(System.Data.DataRow row)
        {
            AfiliadoCambioPlan a_cambio = new AfiliadoCambioPlan();
            a_cambio.Fecha = Convert.ToDateTime(row["fecha"]);
            a_cambio.IdAfiliado = Convert.ToDecimal(row["id_afiliado"]);
            a_cambio.IdPlanMedico = Convert.ToDecimal(row["id_plan_medico"]);
            a_cambio.Habilitado = Convert.ToBoolean(row["habilitado"]);

            return a_cambio;
        }

        #endregion
    }
}
