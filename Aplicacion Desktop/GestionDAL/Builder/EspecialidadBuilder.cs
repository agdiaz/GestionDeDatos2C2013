using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class EspecialidadBuilder : IBuilder<Especialidad>
    {
        #region Miembros de IBuilder<Especialidad>

        public Especialidad Build(System.Data.DataRow row)
        {
            Especialidad especialidad = new Especialidad();
            especialidad.IdEspecialidad = Convert.ToDecimal(row["id_especialidad"]);
            especialidad.Nombre = Convert.ToString(row["nombre"]);
            especialidad.TipoEspecialidad = Convert.ToDecimal(row["decimal"]);
            return especialidad;
        }

        #endregion
    }
}
