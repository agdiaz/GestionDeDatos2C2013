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
    public class BonoFarmaciaDAL : EntidadBaseDAL<BonoFarmacia, BonoFarmacia>
    {
        public BonoFarmaciaDAL(ILog log)
            :base(new SqlServerConector(log), new BonoFarmaciaBuilder(), "BonoFarmacia")
        {
            
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(BonoFarmacia entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(BonoFarmacia entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(BonoFarmacia entidad)
        {
            throw new NotImplementedException();
        }

        public BonoFarmacia Validar(decimal idBono, DateTime fecha, decimal nroPrincipal)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdBono = new SqlParameter("@p_id_bono", System.Data.SqlDbType.Decimal, 18, "p_id_bono");
            pIdBono.Value = idBono;
            parametros.Add(pIdBono);

            SqlParameter pNroPrincipal = new SqlParameter("@p_nro_principal", System.Data.SqlDbType.Decimal, 18, "p_nro_principal");
            pNroPrincipal.Value = nroPrincipal;
            parametros.Add(pNroPrincipal);

            SqlParameter pFecha = new SqlParameter("@p_fecha", System.Data.SqlDbType.DateTime, 8, "p_fecha");
            pFecha.Value = fecha;
            parametros.Add(pFecha);

            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_BonoFarmacia_validar]", parametros);
            return this._builder.Build(ds.Tables[0].Rows[0]);
        }
    }
}
