using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class CancelacionBuilder : IBuilder<Cancelacion>
    {
        #region Miembros de IBuilder<Cancelacion>

        public Cancelacion Build(System.Data.DataRow row)
        {
            Cancelacion c = new Cancelacion();
            c.Fecha = Convert.ToDateTime(row["fecha"]);
            c.Habilitado = Convert.ToBoolean(row["habilitado"]);
            c.IdTipoCancelacion = Convert.ToDecimal(row["id_tipo_cancelacion"]);
            c.IdTurno = Convert.ToDecimal(row["id_turno"]);

            return c;
        }

        #endregion
    }
}
