using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;
using System.Data.SqlClient;

namespace GestionDAL
{
    public class BonoConsultaDAL : EntidadBaseDAL<BonoConsulta, BonoConsulta>
    {
        public BonoConsultaDAL(ILog log)
            :base(new SqlServerConector(log), new BonoConsultaBuilder(), "BonoConsulta")
        {

        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(BonoConsulta entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(BonoConsulta entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(BonoConsulta entidad)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarLlegada(decimal idBono, decimal idTurno, DateTime fecha)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdBono = new SqlParameter("@p_id_bono", System.Data.SqlDbType.Decimal, 18, "p_id_bono");
            pIdBono.Value = idBono;
            parametros.Add(pIdBono);

            SqlParameter pFecha = new SqlParameter("@p_fecha", System.Data.SqlDbType.DateTime, 8, "p_fecha");
            pFecha.Value = fecha;
            parametros.Add(pFecha);

            _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_BonoConsulta_registrar_llegada]", parametros);
            return true;
        }

        public BonoConsulta Validar(decimal idBono, decimal nroPrincipal, decimal idPlan)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdBono = new SqlParameter("@p_id_bono", System.Data.SqlDbType.Decimal, 18, "p_id_bono");
            pIdBono.Value = idBono;
            parametros.Add(pIdBono);

            SqlParameter pNroPrincipal = new SqlParameter("@p_nro_principal", System.Data.SqlDbType.Decimal, 18, "p_nro_principal");
            pNroPrincipal.Value = pNroPrincipal;
            parametros.Add(pNroPrincipal);

            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_BonoConsulta_validar]", parametros);
            return this._builder.Build(ds.Tables[0].Rows[0]);
        }
    }
}
