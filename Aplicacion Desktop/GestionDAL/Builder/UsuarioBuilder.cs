using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class UsuarioBuilder : IBuilder<Usuario>
    {
        #region Miembros de IBuilder<Usuario>

        public Usuario Build(System.Data.DataRow row)
        {
            Usuario u = new Usuario();
            u.IdUsuario = (decimal)row["id_usuario"];
            u.Username = row["username"].ToString();
            u.Habilitado = Convert.ToBoolean(row["habilitado"]);
            return new Usuario();
        }

        #endregion
    }
}
