using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class RolBuilder : IBuilder<Rol>
    {
        #region Miembros de IBuilder<Rol>

        public Rol Build(System.Data.DataRow row)
        {
            return new Rol();
        }

        #endregion
    }
}
