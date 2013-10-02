using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class EntidadBase
    {
        public int Id { get; set; }
        public static string NombreEntidad { get; set; }

        public EntidadBase()
        { }

        public EntidadBase(string nombreEntidad)
        {
            NombreEntidad = nombreEntidad;
        }
    }
}
