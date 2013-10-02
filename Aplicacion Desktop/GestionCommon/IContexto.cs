using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;

namespace GestionCommon
{
    public interface IContexto
    {
        string LogPath { get; }
        ILog Logger { get; }
        DateTime FechaActual {get;}
    }
}
