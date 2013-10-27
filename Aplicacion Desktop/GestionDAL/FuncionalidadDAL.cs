using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;
using System.Data.SqlClient;
using System.Data;

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
            IList<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pIdRol = new SqlParameter("@p_id_rol", System.Data.SqlDbType.Decimal, 18, "p_id_rol");
            pIdRol.Value = idRol;
            parametros.Add(pIdRol);


            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_Funcionalidad_select_by_rol]",  parametros);

            List<Funcionalidad> retorno = new List<Funcionalidad>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retorno.Add(this._builder.Build(row));
            }

            return retorno;
        }
    }
}
