using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class BonoFarmaciaBuilder : IBuilder<BonoFarmacia>
    {
        #region Miembros de IBuilder<BonoFarmacia>

        public BonoFarmacia Build(System.Data.DataRow row)
        {
            BonoFarmacia bf = new BonoFarmacia();
            bf.FechaVencimiento = Convert.ToDateTime(row["fecha_vencimiento"]);
            bf.Habilitado = Convert.ToBoolean(row["habilitado"]);
            bf.IdCompra = Convert.ToDecimal(row["id_compra"]);
            bf.IdPlanMedico = Convert.ToDecimal(row["id_plan_medico"]);
            bf.IdReceta = Convert.ToDecimal(row["id_receta"]);

            return bf;
        }

        #endregion
    }
}
