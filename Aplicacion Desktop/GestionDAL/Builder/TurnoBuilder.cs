using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class TurnoBuilder : IBuilder<Turno>
    {
        #region Miembros de IBuilder<Turno>

        public Turno Build(System.Data.DataRow row)
        {
            Turno turno = new Turno();

            turno.IdTurno = Convert.ToDecimal(row["id_turno"]);
            turno.IdAfiliado = Convert.ToDecimal(row["id_afiliado"]);
            turno.IdProfesional = Convert.ToDecimal(row["id_profesional"]);
            turno.Habilitado = Convert.ToBoolean(row["habilitado"]);

            return turno;
        }

        #endregion
    }
}
