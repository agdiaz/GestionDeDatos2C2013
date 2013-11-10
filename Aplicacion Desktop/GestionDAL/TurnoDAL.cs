using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionConector;
using GestionDAL.Builder;
using GestionCommon.Helpers;

namespace GestionDAL
{
    public class TurnoDAL : EntidadBaseDAL<Turno, FiltroTurno>
    {
        public TurnoDAL(ILog log)
            : base(new SqlServerConector(log), new TurnoBuilder(), "Turno")
        {

        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(FiltroTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Turno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(Turno entidad)
        {
            throw new NotImplementedException();
        }
    }
}
