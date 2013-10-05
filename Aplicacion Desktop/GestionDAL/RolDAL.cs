using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionDAL.Builder;
using GestionConector;

namespace GestionDAL
{
    public class RolDAL : EntidadBaseDAL<Rol>
    {
        public RolDAL(ILog log)
            :base(new SqlServerConector(log), new RolBuilder(), "Rol")
        {
        }

        public override IList<Rol> ObtenerTodos()
        {
            IList<Rol> lista = new List<Rol>();
            lista.Add(new Rol() { IdRol = 0, Nombre = "Administrador", Habilitado = true });
            lista.Add(new Rol() { IdRol = 1, Nombre = "Afiliado", Habilitado = true });
            lista.Add(new Rol() { IdRol = 2, Nombre = "Profesional", Habilitado = true });

            return lista;
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(Rol entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(Rol entidad)
        {
            throw new NotImplementedException();
        }
    }
}
