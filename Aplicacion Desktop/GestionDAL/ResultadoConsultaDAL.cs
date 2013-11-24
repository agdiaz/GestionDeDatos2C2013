using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;
using System.Data.SqlClient;
using System.Data;

namespace GestionDAL
{
    public class ResultadoTurnoDAL : EntidadBaseDAL<ResultadoTurno, ResultadoTurno>
    {
        public ResultadoTurnoDAL(ILog log)
            :base(new SqlServerConector(log), new ResultadoTurnoBuilder(), "ResultadoTurno")    
        {

        }
        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(ResultadoTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(ResultadoTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(ResultadoTurno entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = ParameterDirection.Output;
            parametros.Add(pId); 

            SqlParameter pIdTurno = new SqlParameter("@p_id_turno", System.Data.SqlDbType.Decimal, 18, "p_id_turno");
            pIdTurno.Value = entidad.IdTurno;
            parametros.Add(pIdTurno);

            SqlParameter pSintoma = new SqlParameter("@p_sintoma", System.Data.SqlDbType.VarChar, 255, "p_sintoma");
            pSintoma.Value = entidad.Sintoma;
            parametros.Add(pSintoma);

            SqlParameter pDiagnostico = new SqlParameter("@p_diagnostico", System.Data.SqlDbType.VarChar, 255, "p_diagnostico");
            pDiagnostico.Value = entidad.Diagnostico;
            parametros.Add(pDiagnostico);

            SqlParameter pFecha = new SqlParameter("@p_fecha_diagnostico", System.Data.SqlDbType.DateTime, 8, "p_fecha_diagnostico");
            pFecha.Value = entidad.FechaDiagnostico;
            parametros.Add(pFecha);
            
            return parametros;
        }

        public FechaTurno ObtenerFechasParaTurnos(decimal idProfesional, DateTime hoy)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdProfesional = new SqlParameter("@p_id_profesional", System.Data.SqlDbType.Decimal, 18, "p_id_profesional");
            pIdProfesional.Value = idProfesional;
            parametros.Add(pIdProfesional);

            SqlParameter pFecha = new SqlParameter("@p_fecha_hoy", System.Data.SqlDbType.DateTime, 8, "p_fecha_hoy");
            pFecha.Value = hoy;
            parametros.Add(pFecha);

            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_dias_disponibles_profesional]", parametros);

            return new FechaTurno()
            {
                FechaDesde = Convert.ToDateTime(ds.Tables[0].Rows[0]["fecha_desde"]),
                FechaHasta = Convert.ToDateTime(ds.Tables[0].Rows[0]["fecha_hasta"]),
            };
        }

        public IList<TurnoDisponible> ObtenerHorasParaTurno(decimal idProfesional, DateTime hoy)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdProfesional = new SqlParameter("@p_id_profesional", System.Data.SqlDbType.Decimal, 18, "p_id_profesional");
            pIdProfesional.Value = idProfesional;
            parametros.Add(pIdProfesional);

            SqlParameter pFecha = new SqlParameter("@p_fecha", System.Data.SqlDbType.DateTime, 8, "p_fecha");
            pFecha.Value = hoy;
            parametros.Add(pFecha);

            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_turnos_existentes_por_dia]", parametros);

            IList<TurnoDisponible> lista = new List<TurnoDisponible>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TurnoDisponible turno = new TurnoDisponible();
                turno.Disponible = Convert.ToBoolean(dr["disponible"]);
                turno.HoraDesde = TimeSpan.Parse((dr["horaInicio"].ToString()));
                turno.HoraHasta = TimeSpan.Parse(dr["horaFin"].ToString());
                turno.IdTurno = dr["id_turno"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["id_turno"]);
                turno.IdAfiliado = dr["id_afiliado"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["id_afiliado"]);
                turno.NombreAfiliado = dr["nombre_afiliado"].ToString(); 
                turno.IdResultadoTurno = dr["id_resultado_turno"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["id_resultado_turno"]);
                if (dr["fecha_llegada"] != DBNull.Value)
                    turno.FechaLLegada = Convert.ToDateTime(dr["fecha_llegada"]);
                lista.Add(turno);
            }

            return lista;
        }

        public void RegistrarTurnoNoCorrecto(Turno t, DateTime fecha)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pIdTurno = new SqlParameter("@p_id_turno", SqlDbType.Decimal, 18, "p_id_turno");
            pIdTurno.Value = t.IdTurno;
            parametros.Add(pIdTurno);

            SqlParameter pFechaLLegada = new SqlParameter("@p_fecha_llegada", SqlDbType.DateTime, 8, "p_fecha_llegada");
            pFechaLLegada.Value = fecha;
            parametros.Add(pFechaLLegada);

            _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_Turno_registrar_turno_no_correcto]", parametros);
        }
    }
}
