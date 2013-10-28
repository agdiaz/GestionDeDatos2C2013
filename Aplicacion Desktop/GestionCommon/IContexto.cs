using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionCommon.Entidades;

namespace GestionCommon
{
    public interface IContexto
    {
        string LogPath { get; }
        ILog Logger { get; }
        DateTime FechaActual {get;}
        Usuario UsuarioActual { get; }
        Rol RolActual { get; }

        void RegistrarUsuario(Usuario usuario);

        void RegistrarRol(Rol rol);
    }
}
