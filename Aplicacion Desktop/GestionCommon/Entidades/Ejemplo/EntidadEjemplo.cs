using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades.Ejemplo
{
    public class EntidadEjemplo : EntidadBase
    {
        static EntidadEjemplo()
        {
            NombreEntidad = "Ejemplo";
        }
        public EntidadEjemplo()
            :base("Ejemplo")
        {
        
        }

        public int PropiedadInt { get; set; }
        public string PropiedadString { get; set; }
    }
}
