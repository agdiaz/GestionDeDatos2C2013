using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Atributos
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Descripcion : System.Attribute
    {
        public string DescripcionAMostrar { get; set; }

        public Descripcion(string desc)
        {
            DescripcionAMostrar = desc;
        }
    }
}
