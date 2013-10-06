using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class ResultadoTurnoBuilder : IBuilder<ResultadoTurno>
    {
        #region Miembros de IBuilder<ResultadoTurno>

        public ResultadoTurno Build(System.Data.DataRow row)
        {
            ResultadoTurno resultadoTurno = new ResultadoTurno();

            resultadoTurno.Diagnostico = Convert.ToString(row["diagnostico"]);
            resultadoTurno.FechaDiagnostico = Convert.ToDateTime(row["fecha_diagnostico"]);
            resultadoTurno.IdResultadoTurno = Convert.ToDecimal(row["id_resultado_turno"]);
            resultadoTurno.IdTurno = Convert.ToDecimal(row["id_turno"]);
            resultadoTurno.Sintoma = Convert.ToString(row["sintoma"]);

            return resultadoTurno;
        }

        #endregion
    }
}
