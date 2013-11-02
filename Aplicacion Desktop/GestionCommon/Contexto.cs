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

        public Contexto(string path, DateTime fechaActual)
        {
            _logPath = path;
            _logger = new FileLog(path);
            _fechaActual = fechaActual;
            UsuarioActual = new Usuario();
            RolActual = new Rol();
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

        public Usuario UsuarioActual { get; private set; }

        public Rol RolActual { get; private set; }

        public bool SesionIniciada { get; private set; }

        public void RegistrarUsuario(Usuario usuario)
        {
            this.UsuarioActual = usuario;
            this.SesionIniciada = true;
        }
        public void RegistrarRol(Rol rol)
        {
            this.RolActual = rol;
        }

        public void DesregistrarUsuario()
        { 
            this.UsuarioActual = new Usuario();
            this.SesionIniciada = false;
        }
        public void DesregistrarRol()
        {
            this.RolActual = new Rol();
        }

        #endregion

        
    }
}
