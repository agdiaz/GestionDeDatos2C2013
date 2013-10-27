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
            
            var pUsername = new SqlParameter("@userName", SqlDbType.VarChar, 255, "userName");
            pUsername.Value = nombre;
            parametros.Add(pUsername);

            var pPasswordHash = new SqlParameter("@passwordHash", SqlDbType.VarBinary, 32, "passwordHash");
            pPasswordHash.Value = hashPassword;
            parametros.Add(pPasswordHash);

            int resultado = -1;
            var pResultado = new SqlParameter("@resultado", SqlDbType.Int, 4, "resultado");
            pResultado.Direction = ParameterDirection.Output;
            pResultado.Value = resultado;
            parametros.Add(pResultado);

            //Ejecuto el stored procedure
            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[realizar_identificacion]", parametros);

            return (int)pResultado.Value;
        }

        public bool ObtenerSegunNombreUsuario(string nombre)
        {
            return false;
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var pNombre = new SqlParameter("@p_nombre", SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = nombre;

            var ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_Usuario_select_by_name]", parametros);

            return this._builder.Build(ds.Tables[0].Rows[0]);
        }

        public IList<Rol> ObtenerRoles(string nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            var pUsuario = new SqlParameter("@p_usuario_nombre", SqlDbType.VarChar, 255, "p_usuario_nombre");
            pUsuario.Value = nombre;
            parametros.Add(pUsuario);

            //Ejecuto el stored procedure
            DataSet ds = _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_usuario_select_roles]", parametros);

            var roles = new List<Rol>();
            IBuilder<Rol> rolBuilder = new Builder.RolBuilder();
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                roles.Add(rolBuilder.Build(fila));
            }

            return roles;
        }
    }
}
