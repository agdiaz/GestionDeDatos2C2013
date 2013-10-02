using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;

namespace GestionCommon
{
    public class Contexto : IContexto
    {
        private ILog _logger;
        private string _logPath;
        private DateTime _fechaActual;

        public Contexto(string path, DateTime fechaActual)
        {
            _logPath = path;
            _logger = new FileLog(path);

            _fechaActual = fechaActual;
        }

        #region IContexto

        public ILog Logger
        {
            get
            {
                return _logger;
            }
        }
        
        public string LogPath
        {
            get
            {
                return _logPath;
            }
        }

        public DateTime FechaActual
        {
            get
            {
                return _fechaActual;
            }
        }

        #endregion
    }
}
