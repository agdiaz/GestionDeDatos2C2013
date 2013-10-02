using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Atributos
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class Visible : System.Attribute
    {
        public bool EsVisible { get; set; }

        public Visible()
        {
            EsVisible = true;
        }
    }
}
