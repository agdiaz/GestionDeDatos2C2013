using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades.Ejemplo;

namespace GestionDAL.Builder.Ejemplo
{
    public class EntidadEjemploBuilder : IBuilder<EntidadEjemplo>
    {
        #region IBuilder<EntidadEjemplo>

        public EntidadEjemplo Build(System.Data.DataRow row)
        {
            return new EntidadEjemplo()
            {
                Id = Convert.ToInt32(row["Id"]),
                PropiedadInt = Convert.ToInt32(row["PropiedadInt"]),
                PropiedadString = row["PropiedadString"].ToString()
            };
        }

        #endregion
    }
}
