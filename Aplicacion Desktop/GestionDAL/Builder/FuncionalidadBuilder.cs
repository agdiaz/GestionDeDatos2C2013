using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class FuncionalidadBuilder : IBuilder<Funcionalidad>
    {
        #region Miembros de IBuilder<Funcionalidad>

        public Funcionalidad Build(System.Data.DataRow row)
        {
            return new Funcionalidad();
        }

        #endregion
    }
}
