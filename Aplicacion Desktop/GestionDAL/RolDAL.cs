using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionDAL.Builder;
using GestionConector;

namespace GestionDAL
{
    public class RolDAL : EntidadBaseDAL<Rol>
    {
        public RolDAL(ILog log)
            :base(new SqlServerConector(log), new RolBuilder(), "Rol")
        {
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Rol entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(Rol entidad)
        {
            throw new NotImplementedException();
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
