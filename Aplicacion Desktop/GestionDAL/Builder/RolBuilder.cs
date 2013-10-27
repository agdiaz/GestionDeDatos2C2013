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
            Rol rol = new Rol();
            rol.IdRol = Convert.ToDecimal(row["id_rol"]);
            rol.Nombre = Convert.ToString(row["nombre"]);
            rol.Habilitado = Convert.ToBoolean(row["habilitado"]);
            rol.Activo = Convert.ToBoolean(row["activo"]);
            return rol;
        }

        #endregion
    }
}
