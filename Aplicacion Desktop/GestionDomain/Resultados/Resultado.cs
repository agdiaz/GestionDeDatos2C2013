using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDomain.Resultados
{
    public class Resultado : IResultado 
    {
        public bool Correcto { get; set; }
        public IList<string> Mensajes { get; set; }

        public Resultado()
        {
            Mensajes = new List<string>();
        }
    }
}
