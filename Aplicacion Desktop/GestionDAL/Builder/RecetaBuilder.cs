using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class RecetaBuilder : IBuilder<Receta>
    {

        #region Miembros de IBuilder<Receta>

        public Receta Build(System.Data.DataRow row)
        {
            Receta receta = new Receta();
            
            receta.Habilitado = Convert.ToBoolean(row["habilitado"]);
            receta.IdReceta = Convert.ToDecimal(row["id_receta"]);
            receta.IdResultadoTurno = Convert.ToDecimal(row["id_resultado_turno"]);

            return receta;
        }

        #endregion
    }
}
