using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using System.Data.SqlClient;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;

namespace GestionDAL
{
    public class CancelacionDAL : EntidadBaseDAL<Cancelacion, Cancelacion>
    {
        public CancelacionDAL(ILog log)
            :base(new SqlServerConector(log), new CancelacionBuilder(), "Cancelacion")
        {

        }
        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(Cancelacion entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Cancelacion entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(Cancelacion entidad)
        {
            throw new NotImplementedException();
        }

        public Cancelacion RegistrarCancelacion(Cancelacion c)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlParameter pIdTipoCancelacion = new SqlParameter("@p_id_tipo_cancelacion", System.Data.SqlDbType.Decimal, 18, "p_id_tipo_cancelacion");
            pIdTipoCancelacion.Value = c.IdTipoCancelacion;
            parametros.Add(pIdTipoCancelacion);

            SqlParameter pIdTurno = new SqlParameter("@p_id_turno", System.Data.SqlDbType.Decimal, 18, "p_id_turno");
            pIdTurno.Value = c.IdTurno;
            parametros.Add(pIdTurno);

            SqlParameter pFecha = new SqlParameter("@p_fecha", System.Data.SqlDbType.DateTime, 8, "p_fecha");
            pFecha.Value = c.Fecha;
            parametros.Add(pFecha);

            SqlParameter pCanceladoPor = new SqlParameter("@p_cancelado_por", System.Data.SqlDbType.Char, 1, "p_cancelado_por");
            pCanceladoPor.Value = c.CanceladoPor;
            parametros.Add(pCanceladoPor);

            SqlParameter pMotivo = new SqlParameter("@p_motivo", System.Data.SqlDbType.VarChar, 255, "p_motivo");
            pMotivo.Value = c.Motivo;
            parametros.Add(pMotivo);

            _connector.RealizarConsultaAlmacenada("TOP_4.sp_cancelacion", parametros);
            return c;
        }
    }
}
