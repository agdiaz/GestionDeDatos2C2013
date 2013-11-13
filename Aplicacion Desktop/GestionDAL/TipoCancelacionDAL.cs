using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;

namespace GestionDAL
{
    public class TipoCancelacionDAL : EntidadBaseDAL<TipoCancelacion, TipoCancelacion>
    {
        public TipoCancelacionDAL(ILog log)
            :base(new SqlServerConector(log), new TipoCancelacionBuilder(), "TipoCancelacion")
        {

        }
        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(TipoCancelacion entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(TipoCancelacion entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(TipoCancelacion entidad)
        {
            throw new NotImplementedException();
        }
    }
}
