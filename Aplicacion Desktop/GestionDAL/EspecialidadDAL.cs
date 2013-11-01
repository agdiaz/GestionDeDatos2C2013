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
    public class EspecialidadDAL : EntidadBaseDAL<Especialidad, FiltroEspecialidad>
    {
        public EspecialidadDAL(ILog log)
            : base(new SqlServerConector(log), new EspecialidadBuilder(), "Especialidad")
        {

        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(FiltroEspecialidad entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pIdTipoEspecialidad = new SqlParameter("@p_id_tipo_especialidad", System.Data.SqlDbType.Decimal, 18, "p_id_tipo_especialidad");
            pIdTipoEspecialidad.Value = entidad.IdTipoEspecialidad;
            parametros.Add(pIdTipoEspecialidad);
            return parametros;
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Especialidad entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(Especialidad entidad)
        {
            throw new NotImplementedException();
        }
    }
}
