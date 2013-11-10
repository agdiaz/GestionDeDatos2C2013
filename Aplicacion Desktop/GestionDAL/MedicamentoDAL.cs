using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using System.Data.SqlClient;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;

namespace GestionDAL
{
    public class MedicamentoDAL : EntidadBaseDAL<Medicamento, Medicamento>
    {
        public MedicamentoDAL(ILog log)
            : base(new SqlServerConector(log), new MedicamentoBuilder(), "Medicamento")
        {

        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(Medicamento entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            return parametros;
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Medicamento entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(Medicamento entidad)
        {
            throw new NotImplementedException();
        }
    }
}
