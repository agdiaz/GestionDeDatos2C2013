using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionDAL.Builder;
using GestionConector;
using System.Data.SqlClient;

namespace GestionDAL
{
    public class RolDAL : EntidadBaseDAL<Rol>
    {
        public RolDAL(ILog log)
            :base(new SqlServerConector(log), new RolBuilder(), "Rol")
        {
        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Rol entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Rol entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;

            SqlParameter pActivo = new SqlParameter("@p_Activo", System.Data.SqlDbType.Bit, 1, "p_Activo");
            pActivo.Value = entidad.Activo;

            return parametros;

        }

        public void AsociarRolFuncionalidad(decimal idRol, decimal idFuncionalidad)
        {
            throw new NotImplementedException();
        }

        public void LimpiarFuncionalidades(decimal idRol)
        {
            throw new NotImplementedException();
        }

    }
}
