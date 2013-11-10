using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionConector;
using GestionCommon.Helpers;
using System.Data.SqlClient;

namespace GestionDAL
{
    public class CompraDAL
    {
        private SqlServerConector _conector;

        public CompraDAL(ILog log)
        {
            _conector = new SqlServerConector(log);
        }
        public void CrearBonoConsulta(BonoConsulta bono)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdCompra = new SqlParameter("@p_id_compra", System.Data.SqlDbType.Decimal, 18, "p_id_compra");
            pIdCompra.Value = bono.IdCompra;
            parametros.Add(pIdCompra);

            SqlParameter pIdPlanMedico = new SqlParameter("@p_id_plan_medico", System.Data.SqlDbType.Decimal, 18, "p_id_plan_medico");
            pIdPlanMedico.Value = bono.IdPlanMedico;
            parametros.Add(pIdPlanMedico);

            SqlParameter pFechaImpresion = new SqlParameter("@p_fecha_impresion", System.Data.SqlDbType.DateTime, 8, "p_fecha_impresion");
            pFechaImpresion.Value = bono.FechaImpresion;
            parametros.Add(pFechaImpresion);

            _conector.RealizarConsultaAlmacenada("[TOP_4].[sp_Compra_bono_consulta]", parametros);
        }

        public void CrearBonoFarmacia(BonoFarmacia bono)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdCompra = new SqlParameter("@p_id_compra", System.Data.SqlDbType.Decimal, 18, "p_id_compra");
            pIdCompra.Value = bono.IdCompra;
            parametros.Add(pIdCompra);

            SqlParameter pIdPlanMedico = new SqlParameter("@p_id_plan_medico", System.Data.SqlDbType.Decimal, 18, "p_id_plan_medico");
            pIdPlanMedico.Value = bono.IdPlanMedico;
            parametros.Add(pIdPlanMedico);

            SqlParameter pFechaImpresion = new SqlParameter("@p_fecha_impresion", System.Data.SqlDbType.DateTime, 8, "p_fecha_impresion");
            pFechaImpresion.Value = bono.FechaImpresion;
            parametros.Add(pFechaImpresion);

            SqlParameter pFechaVencimiento = new SqlParameter("@p_fecha_vencimiento", System.Data.SqlDbType.DateTime, 8, "p_fecha_vencimiento");
            pFechaVencimiento.Value = bono.FechaVencimiento;
            parametros.Add(pFechaVencimiento);

            _conector.RealizarConsultaAlmacenada("[TOP_4].[sp_Compra_bono_farmacia]", parametros);
        }

        public decimal RegistrarCompra(Afiliado afiliado, DateTime fechaImpresion, decimal costo)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

            SqlParameter pIdAfiliado = new SqlParameter("@p_id_afiliado", System.Data.SqlDbType.Decimal, 18, "p_id_afiliado");
            pIdAfiliado.Value = afiliado.IdAfiliado;
            parametros.Add(pIdAfiliado);

            SqlParameter pFechaImpresion = new SqlParameter("@p_fecha_compra", System.Data.SqlDbType.DateTime, 8, "p_fecha_compra");
            pFechaImpresion.Value = fechaImpresion;
            parametros.Add(pFechaImpresion);

            SqlParameter pCosto = new SqlParameter("@p_costo", System.Data.SqlDbType.Decimal, 18, "p_costo");
            pCosto.Value = costo;
            parametros.Add(pCosto);

            _conector.RealizarConsultaAlmacenada("[TOP_4].[sp_Compra_registrar]", parametros);

            return ((Decimal)pId.Value);
        }
    }
}
