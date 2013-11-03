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
using System.Data;

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

        public IList<Especialidad> ObtenerPorProfesional(Profesional profesional)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>(1);

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Value = profesional.IdProfesional;
            parametros.Add(pId);

            IList<Especialidad> lista = new List<Especialidad>();

            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_Especialidad_select_by_profesional]", parametros);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(_builder.Build(row));
            }

            return lista;
        }
    }
}
