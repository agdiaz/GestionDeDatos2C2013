using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDomain.Resultados
{
    public interface IResultado<T>
    {
        bool Correcto { get; }
        T Retorno { get; }
        IList<string> Mensajes { get; }
    }
}
