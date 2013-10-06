using System;
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
    public class FuncionalidadDAL : EntidadBaseDAL<Funcionalidad>
    {
        public FuncionalidadDAL(ILog log)
            :base( new SqlServerConector(log), new FuncionalidadBuilder(), "Funcionalidad")
        {

        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Funcionalidad entidad)
        {
            throw new NotImplementedException();
        }

        public IList<Funcionalidad> ObtenerFuncionalidades(decimal idRol)
        {
            throw new NotImplementedException();
        }
    }
}
