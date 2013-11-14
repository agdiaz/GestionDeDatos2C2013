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
        public decimal CrearBonoConsulta(BonoConsulta bono)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

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

            return (decimal)pId.Value;
        }

        public decimal CrearBonoFarmacia(BonoFarmacia bono)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

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

            return (decimal)pId.Value;
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

        public decimal RegistrarReceta(Receta r)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pIdResultadoTurno = new SqlParameter("@p_id_resultado_turno", System.Data.SqlDbType.Decimal, 18, "p_id_resultado_turno");
            pIdResultadoTurno.Value = r.IdResultadoTurno;
            parametros.Add(pIdResultadoTurno);

            SqlParameter pIdBonoFarmacia = new SqlParameter("@p_id_bono_farmacia", System.Data.SqlDbType.Decimal, 18, "p_id_bono_farmacia");
            pIdBonoFarmacia.Value = r.IdBonoFarmacia;
            parametros.Add(pIdBonoFarmacia);

            SqlParameter pFecha = new SqlParameter("@p_fecha", System.Data.SqlDbType.DateTime, 8, "p_fecha");
            pFecha.Value = r.Fecha;
            parametros.Add(pFecha);

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

            _conector.RealizarConsultaAlmacenada("[TOP_4].[sp_Receta_insert]", parametros);
            return (decimal)pId.Value;
        }

        public bool RegistrarItemReceta(ItemReceta ir)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pIdReceta = new SqlParameter("@p_id_receta", System.Data.SqlDbType.Decimal, 18, "p_id_receta");
            pIdReceta.Value = ir.IdReceta;
            parametros.Add(pIdReceta);

            SqlParameter pIdMedicamento = new SqlParameter("@p_id_medicamento", System.Data.SqlDbType.Decimal, 18, "p_id_medicamento");
            pIdMedicamento.Value = ir.IdMedicamento;
            parametros.Add(pIdMedicamento);

            SqlParameter pCantidad = new SqlParameter("@p_cantidad", System.Data.SqlDbType.Int, 4, "p_cantidad");
            pCantidad.Value = ir.Cantidad;
            parametros.Add(pCantidad);

            _conector.RealizarConsultaAlmacenada("[TOP_4].[sp_ItemReceta_insert]", parametros);
            return true;
        }
    }
}
