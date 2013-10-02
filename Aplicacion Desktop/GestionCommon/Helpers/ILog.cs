using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Helpers
{
    public interface ILog
    {
        void Iniciar();
        void Log(string mensaje);
        void Log(Exception ex);
        void Finalizar();
    }
}
