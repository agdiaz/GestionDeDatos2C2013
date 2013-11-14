using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionConector;
using GestionDAL.Builder;
using GestionCommon.Helpers;
using System.Data.SqlClient;

namespace GestionDAL
{
    public class TurnoDAL : EntidadBaseDAL<Turno, FiltroTurno>
    {
        public TurnoDAL(ILog log)
            : base(new SqlServerConector(log), new TurnoBuilder(), "Turno")
        {

        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(FiltroTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Turno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Turno entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId= new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

            SqlParameter pIdAfiliado = new SqlParameter("@p_id_afiliado", System.Data.SqlDbType.Decimal, 18, "p_id_afiliado");
            pIdAfiliado.Value = entidad.IdAfiliado;
            parametros.Add(pIdAfiliado);

            SqlParameter pIdProfesional = new SqlParameter("@p_id_profesional", System.Data.SqlDbType.Decimal, 18, "p_id_profesional");
            pIdProfesional.Value = entidad.IdProfesional;
            parametros.Add(pIdProfesional);

            SqlParameter pFechaTurno = new SqlParameter("@p_fecha_turno", System.Data.SqlDbType.DateTime, 8, "p_fecha_turno");
            pFechaTurno.Value = entidad.HoraInicio;
            parametros.Add(pFechaTurno);

            return parametros;
        }
    }
}
