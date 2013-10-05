using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using System.Data.SqlClient;
using GestionConector;
using GestionDAL.Builder;
using GestionCommon.Helpers;

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
            throw new NotImplementedException();
        }

        public bool ObtenerSegunNombreUsuario(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
