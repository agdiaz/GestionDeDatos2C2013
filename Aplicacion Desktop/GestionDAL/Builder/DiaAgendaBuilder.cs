using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class DiaAgendaBuilder : IBuilder<DiaAgenda>
    {
        #region Miembros de IBuilder<DiaAgenda>

        public DiaAgenda Build(System.Data.DataRow row)
        {
            DiaAgenda diaAgenda = new DiaAgenda();
            diaAgenda.Id = Convert.ToDecimal(row["id_dia_agenda"]);
            diaAgenda.NroDiaSemana = Convert.ToDecimal(row["nro_dia_semana"]);
            diaAgenda.NombreDiaSemana = Convert.ToString(row["nombre_dia_semana"]);
            diaAgenda.HoraDesde = Convert.ToInt32(row["hora_desde"]);
            diaAgenda.HoraHasta = Convert.ToInt32(row["hora_hasta"]);
            return diaAgenda;
        }

        #endregion
    }
}
