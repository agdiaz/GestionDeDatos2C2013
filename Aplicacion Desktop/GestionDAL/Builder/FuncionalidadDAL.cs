using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionConector;

namespace GestionDAL.Builder
{
    public class FuncionalidadDAL : EntidadBaseDAL<Funcionalidad>
    {
        public FuncionalidadDAL(ILog log)
            :base( new SqlServerConector(log), new FuncionalidadBuilder(), "Funcionalidad")
        {

        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Funcionalidad> ObtenerFuncionalidades(int idRol)
        {
            throw new NotImplementedException();
        }
    }
}
