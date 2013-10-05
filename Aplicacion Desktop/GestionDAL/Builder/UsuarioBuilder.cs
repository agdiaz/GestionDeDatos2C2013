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
            return new Usuario();
        }

        #endregion
    }
}
