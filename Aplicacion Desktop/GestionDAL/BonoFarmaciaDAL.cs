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
    public class BonoFarmaciaDAL : EntidadBaseDAL<BonoFarmacia, BonoFarmacia>
    {
        public BonoFarmaciaDAL(ILog log)
            :base(new SqlServerConector(log), new BonoFarmaciaBuilder(), "BonoFarmacia")
        {
            
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(BonoFarmacia entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(BonoFarmacia entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(BonoFarmacia entidad)
        {
            throw new NotImplementedException();
        }
    }
}
