using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class BonoConsultaBuilder : IBuilder<BonoConsulta>
    {
        #region Miembros de IBuilder<BonoConsulta>

        public BonoConsulta Build(System.Data.DataRow row)
        {
            BonoConsulta bc = new BonoConsulta();
            bc.IdCompra = Convert.ToDecimal(row["id_compra"]);
            bc.IdPlanMedico = Convert.ToDecimal(row["id_plan_medico"]);
            bc.IdTurno = Convert.ToDecimal(row["id_turno"]);
            bc.Habilitado = Convert.ToBoolean(row["habilitado"]);

            return bc;
        }

        #endregion
    }
}
