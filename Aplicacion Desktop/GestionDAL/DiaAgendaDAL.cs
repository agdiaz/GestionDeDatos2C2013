using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionConector;
using GestionDAL.Builder;
using GestionCommon.Filtros;
using System.Data.SqlClient;
using GestionCommon.Helpers;

namespace GestionDAL
{
    public class DiaAgendaDAL : EntidadBaseDAL<DiaAgenda, FiltroDiaAgenda>
    {
        public DiaAgendaDAL(ILog log)
            :base(new SqlServerConector(log), new DiaAgendaBuilder(), "DiaAgenda")
        {
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroDiaAgenda entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosModificar(DiaAgenda entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(DiaAgenda entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Value = entidad.Id;
            parametros.Add(pId);

            SqlParameter pNroDiaSemana = new SqlParameter("@p_nro_dia_semana", System.Data.SqlDbType.Decimal, 18, "p_nro_dia_semana");
            pNroDiaSemana.Value = entidad.NroDiaSemana;
            parametros.Add(pNroDiaSemana);

            SqlParameter pNombreDiaSemana = new SqlParameter("@p_nombre_dia_semana", System.Data.SqlDbType.VarChar, 255, "p_nombre_dia_semana");
            pNombreDiaSemana.Value = entidad.NombreDiaSemana;
            parametros.Add(pNombreDiaSemana);

            SqlParameter pHoraDesde = new SqlParameter("@p_hora_desde", System.Data.SqlDbType.DateTime, 8, "p_hora_desde");
            pHoraDesde.Value = new DateTime(2013,1,1,entidad.HoraDesde,0,0);
            parametros.Add(pHoraDesde);

            SqlParameter pHoraHasta = new SqlParameter("@p_hora_hasta", System.Data.SqlDbType.DateTime, 8, "p_hora_hasta");
            pHoraHasta.Value = new DateTime(2013,1,1,entidad.HoraHasta,0,0);
            parametros.Add(pHoraHasta);

            return parametros;
        }
    }
}
