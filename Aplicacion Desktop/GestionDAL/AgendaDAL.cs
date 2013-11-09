using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionConector;
using System.Data.SqlClient;
using GestionDAL.Builder;
using GestionCommon.Entidades;
using GestionCommon.Filtros;

namespace GestionDAL
{
    public class AgendaDAL : EntidadBaseDAL<Agenda, FiltroAgenda>
    {
        //private SqlServerConector _conector;

        public AgendaDAL(ILog log)
            :base(new SqlServerConector(log), new AgendaBuilder(), "Agenda")
        {
            //_conector = new SqlServerConector(log);
        }

        public void AsociarAgendaProfesional(decimal idProfesional, DateTime fechaDesde, DateTime fechaHasta)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdProfesional = new SqlParameter("@p_id_rol", System.Data.SqlDbType.Decimal, 18, "p_id_rol");
            pIdProfesional.Value = idProfesional;
            parametros.Add(pIdProfesional);

            SqlParameter pFechaDesde = new SqlParameter("@p_fecha_desde", System.Data.SqlDbType.DateTime, 8, "p_fecha_desde");
            pFechaDesde.Value = fechaDesde;
            parametros.Add(pFechaDesde);

            SqlParameter pFechaHasta = new SqlParameter("@p_fecha_hasta", System.Data.SqlDbType.DateTime, 8, "p_fecha_hasta");
            pFechaHasta.Value = fechaHasta;
            parametros.Add(pFechaHasta);

            _connector.RealizarConsultaAlmacenada("[TOP_4].sp_asociar_agenda_profesional", parametros);
        }


        public void AsociarDiaAAgenda(decimal idAgenda, decimal idDiaAgenda)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdAgenda = new SqlParameter("@p_id_agenda", System.Data.SqlDbType.Decimal, 18, "p_id_agenda");
            pIdAgenda.Value = idAgenda;
            parametros.Add(pIdAgenda);

            SqlParameter pIdDiaAgenda = new SqlParameter("@p_id_dia_agenda", System.Data.SqlDbType.Decimal, 18, "p_id_dia_agenda");
            pIdDiaAgenda.Value = idDiaAgenda;
            parametros.Add(pIdDiaAgenda);

            _connector.RealizarConsultaAlmacenada("[TOP_4].sp_asociar_diaagenda_agenda", parametros);
        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroAgenda entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Agenda entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Agenda entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Value = entidad.Id;
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

            SqlParameter pIdProfesional = new SqlParameter("@p_id_profesional", System.Data.SqlDbType.Decimal, 18, "p_id_profesional");
            pIdProfesional.Value = entidad.IdProfesional;
            parametros.Add(pIdProfesional);

            SqlParameter pFechaDesde = new SqlParameter("@p_fecha_desde", System.Data.SqlDbType.DateTime, 8, "p_fecha_desde");
            pFechaDesde.Value = entidad.FechaDesde;
            parametros.Add(pFechaDesde);

            SqlParameter pFechaHasta = new SqlParameter("@p_fecha_hasta", System.Data.SqlDbType.DateTime, 8, "p_fecha_hasta");
            pFechaHasta.Value = entidad.FechaHasta;
            parametros.Add(pFechaHasta);

            return parametros;
        }
    }
}
