using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionDAL.Builder;
using GestionConector;
using System.Data.SqlClient;
using GestionCommon.Filtros;

namespace GestionDAL
{
    public class RolDAL : EntidadBaseDAL<Rol, FiltroRol>
    {
        public RolDAL(ILog log)
            :base(new SqlServerConector(log), new RolBuilder(), "Rol")
        {
        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Rol entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Value = entidad.Id;
            parametros.Add(pId);

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pActivo = new SqlParameter("@p_activo", System.Data.SqlDbType.Bit, 1, "p_activo");
            pActivo.Value = entidad.Activo;
            parametros.Add(pActivo);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Rol entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Value = entidad.Id;
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pActivo = new SqlParameter("@p_activo", System.Data.SqlDbType.Bit, 1, "p_activo");
            pActivo.Value = entidad.Activo;
            parametros.Add(pActivo);

            return parametros;

        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroRol filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = filtro.Nombre;
            parametros.Add(pNombre);

            
            SqlParameter pIdFuncionalidad = new SqlParameter("@p_id_funcionalidad", System.Data.SqlDbType.Decimal, 18, "p_id_funcionalidad");
            if (filtro.IdFuncionalidad.HasValue)
                pIdFuncionalidad.Value = filtro.IdFuncionalidad.Value;
            parametros.Add(pIdFuncionalidad);

            return parametros;
        }

        public void AsociarRolFuncionalidad(decimal idRol, decimal idFuncionalidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlParameter pIdRol = new SqlParameter("@p_id_rol", System.Data.SqlDbType.Decimal, 18, "p_id_rol");
            pIdRol.Value = idRol;
            parametros.Add(pIdRol);

            SqlParameter pIdFuncionalidad = new SqlParameter("@p_id_funcionalidad", System.Data.SqlDbType.Decimal, 18, "p_id_funcionalidad");
            pIdFuncionalidad.Value = idFuncionalidad;
            parametros.Add(pIdFuncionalidad);

            _connector.RealizarConsultaAlmacenada("[TOP_4].sp_asociar_rol_funcionalidad", parametros);
        }

        public void LimpiarFuncionalidades(decimal idRol)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pIdRol = new SqlParameter("@p_id_rol", System.Data.SqlDbType.Decimal, 18, "p_id_rol");
            pIdRol.Value = idRol;
            parametros.Add(pIdRol);

            _connector.RealizarConsultaAlmacenada("[TOP_4].sp_limpiar_funcionalidades", parametros);
        }

    }
}
