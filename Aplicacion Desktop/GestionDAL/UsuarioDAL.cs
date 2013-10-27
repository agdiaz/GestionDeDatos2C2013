using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using System.Data.SqlClient;
using GestionConector;
using GestionDAL.Builder;
using GestionCommon.Helpers;
using System.Data;

namespace GestionDAL
{
    public class UsuarioDAL : EntidadBaseDAL<Usuario>
    {
        public UsuarioDAL(ILog log)
        :base(new SqlServerConector(log), new UsuarioBuilder(), "Usuario")
        {

        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public int RealizarIdentificacion(string nombre, byte[] hashPassword)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            
            var pUsername = new SqlParameter("@userName", SqlDbType.Int, 4, "userName");
            pUsername.Value = nombre;
            parametros.Add(pUsername);

            var pPasswordHash = new SqlParameter("@passwordHash", SqlDbType.VarBinary, 4, "passwordHash");
            pPasswordHash.Value = hashPassword;
            parametros.Add(pPasswordHash);

            int resultado = -1;
            var pResultado = new SqlParameter("@resultado", SqlDbType.Int, 4, "resultado");
            pResultado.Direction = ParameterDirection.Output;
            pResultado.Value = resultado;
            parametros.Add(pResultado);

            //Ejecuto el stored procedure
            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[realizar_identificacion]", parametros);

            return resultado;
        }

        public bool ObtenerSegunNombreUsuario(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
