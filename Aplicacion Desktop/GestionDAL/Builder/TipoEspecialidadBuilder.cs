using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using System.Data;

namespace GestionDAL.Builder
{
    public class TipoEspecialidadBuilder : IBuilder<TipoEspecialidad>
    {
        #region Miembros de IBuilder<TipoEspecialidad>

        public TipoEspecialidad Build(DataRow row)
        {
            return new TipoEspecialidad 
            {
                Id = Convert.ToDecimal(row["id_especilidad"]),
                Nombre = Convert.ToString(row["nombre"])
            };
        }

        #endregion
    }
}
