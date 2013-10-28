using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionCommon.Entidades;

namespace GestionCommon
{
    public class Contexto : IContexto
    {
        private ILog _logger;
        private string _logPath;
        private DateTime _fechaActual;
        private Usuario _usuario;
        private Rol _rol;
        
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

        public Usuario UsuarioActual
        {
            get { return _usuario; }
        }

        public Rol RolActual
        {
            get { return _rol; }
        }

        #endregion

        public void RegistrarUsuario(Usuario usuario)
        {
            this._usuario = usuario;
        }

        public void RegistrarRol(Rol rol)
        {
            this._rol = rol;
        }
    }
}
