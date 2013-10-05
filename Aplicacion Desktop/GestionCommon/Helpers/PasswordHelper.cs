using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using GestionCommon.Enums;

namespace GestionCommon.Helpers
{
    public static class PasswordHelper
    {
        public static byte[] GetSHA256Value(string texto)
        {
            HashAlgorithm algoritmo = new SHA256Managed();
            byte[] textoBytes = new ASCIIEncoding().GetBytes(texto);
            byte[] hashValue = algoritmo.ComputeHash(textoBytes);
            return hashValue;
        }

        public static bool IdentificacionExitosa(IdentificacionUsuario res)
        {
            return res.CompareTo(IdentificacionUsuario.UsuarioIdentificado) == 0;
        }
        public static string Mensaje(IdentificacionUsuario res)
        {
            switch (res)
            {
                case IdentificacionUsuario.UsuarioIdentificado:
                    return "Usuario identificado correctamente";
                case IdentificacionUsuario.UsuarioBloqueado:
                    return "El usuario ha sido bloqueado por reiterados intentos erróneos de login";
                case IdentificacionUsuario.UsuarioInvalido:
                    return "El usuario, el rol o la contraseña son inválidos";
                default:
                    return "Error";
            }
        }
    }
}
