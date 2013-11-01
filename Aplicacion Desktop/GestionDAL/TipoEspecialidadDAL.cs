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
    public class TipoEspecialidadDAL : EntidadBaseDAL<TipoEspecialidad, FiltroTipoEspecialidad>
    {
        public TipoEspecialidadDAL(ILog log)
            : base(new SqlServerConector(log), new TipoEspecialidadBuilder(), "TipoEspecialidad")
        {

        }
        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(FiltroTipoEspecialidad entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            return parametros;
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(TipoEspecialidad entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(TipoEspecialidad entidad)
        {
            throw new NotImplementedException();
        }
    }
}
