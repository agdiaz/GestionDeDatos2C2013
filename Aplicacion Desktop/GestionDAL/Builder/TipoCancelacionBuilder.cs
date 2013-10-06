using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class TipoCancelacionBuilder : IBuilder<TipoCancelacion>
    {
        #region Miembros de IBuilder<TipoCancelacion>

        public TipoCancelacion Build(System.Data.DataRow row)
        {
            TipoCancelacion tipoCancelacion = new TipoCancelacion();
            tipoCancelacion.IdTipoCancelacion = Convert.ToDecimal(row["id_tipo_cancelacion"]);
            tipoCancelacion.Nombre = Convert.ToString(row["nombre"]);
            tipoCancelacion.Categoria = Convert.ToString(row["categoria"]);
            return tipoCancelacion;
        }

        #endregion
    }
}
