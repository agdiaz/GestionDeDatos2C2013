using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class AgendaBuilder : IBuilder<Agenda>
    {
        #region Miembros de IBuilder<Agenda>

        public Agenda Build(System.Data.DataRow row)
        {
            Agenda a = new Agenda();
            a.IdProfesional = Convert.ToDecimal(row["id_profesional"]);
            a.FechaDesde = Convert.ToDateTime(row["id_fecha_desde"]);
            a.FechaHasta = Convert.ToDateTime(row["id_fecha_hasta"]);
            a.Habilitado = Convert.ToBoolean(row["habilitado"]);

            return a;
        }

        #endregion
    }
}
