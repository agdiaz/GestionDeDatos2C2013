using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class CompraBuilder : IBuilder<Compra>
    {
        #region Miembros de IBuilder<Compra>

        public Compra Build(System.Data.DataRow row)
        {
            Compra compra = new Compra();
            compra.IdAfiliado = Convert.ToDecimal(row["id_afiliado"]);
            compra.IdCompra = Convert.ToDecimal(row["id_compra"]);
            compra.Habilitado = Convert.ToBoolean(row["habilitado"]);
            return compra;
        }

        #endregion
    }
}
