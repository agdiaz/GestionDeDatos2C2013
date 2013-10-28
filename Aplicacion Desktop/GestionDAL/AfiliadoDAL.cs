using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using System.Data.SqlClient;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;

namespace GestionDAL
{
    public class AfiliadoDAL : EntidadBaseDAL<Afiliado, FiltroAfiliado>
    {
        public AfiliadoDAL(ILog log)
            : base(new SqlServerConector(log), new AfiliadoBuilder(), "Afiliado")
        {

        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroAfiliado filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            var pNumeroAfiliado = new SqlParameter("@p_numero_afiliado", System.Data.SqlDbType.Decimal, 18, "p_numero_afiliado");
            pNumeroAfiliado.Value = filtro.NroAfiliado;
            parametros.Add(pNumeroAfiliado);

            var pIdPlanMedico = new SqlParameter("@p_id_plan_medico", System.Data.SqlDbType.Decimal, 18, "p_id_plan_medico");
            pIdPlanMedico.Value = filtro.IdPlanMedico;
            parametros.Add(pIdPlanMedico);

            var pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.Int, 4, "p_tipo_documento");
            pTipoDocumento.Value = filtro.IdTipoDocumento;
            parametros.Add(pTipoDocumento);

            var pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = filtro.Nombre;
            parametros.Add(pNombre);

            var pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            pApellido.Value = filtro.Apellido;
            parametros.Add(pApellido);

            var pDocumento = new SqlParameter("@p_documento", System.Data.SqlDbType.Decimal, 18, "p_documento");
            pApellido.Value = filtro.Documento;
            parametros.Add(pApellido);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Afiliado entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Afiliado entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            return parametros;
        }
    }
}
