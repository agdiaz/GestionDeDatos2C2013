using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDomain.Resultados
{
    public interface IResultado
    {
        bool Correcto { get; }
        IList<string> Mensajes { get; }
    }
}
