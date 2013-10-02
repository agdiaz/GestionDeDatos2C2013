using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades.Ejemplo;
using GestionConector;
using GestionDAL.Builder.Ejemplo;
using GestionCommon.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace GestionDAL.Ejemplo
{
    public class EntidadEjemploDAL : EntidadBaseDAL<EntidadEjemplo>
    {
        public EntidadEjemploDAL(ILog log)
        :base(new SqlServerConector(log), new EntidadEjemploBuilder(), "Ejemplo")
        {

        }
        protected override IList<SqlParameter> GenerarParametrosModificar(EntidadEjemplo entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_Id", SqlDbType.Int, 4, "p_Id"));
            parametros.Add(new SqlParameter("@p_propiedadInt", SqlDbType.Int, 4, "p_propiedadInt"));
            parametros.Add(new SqlParameter("@p_propiedadString", SqlDbType.VarChar, 50, "p_propiedadString"));
            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(EntidadEjemplo entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_propiedadInt", SqlDbType.Int, 4, "p_propiedadInt"));
            parametros.Add(new SqlParameter("@p_propiedadString", SqlDbType.VarChar, 50, "p_propiedadString"));
            return parametros;
        }
    }
}
