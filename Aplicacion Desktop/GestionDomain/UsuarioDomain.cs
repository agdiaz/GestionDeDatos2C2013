using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionDAL;
using GestionCommon.Helpers;
using GestionDomain.Resultados;
using GestionCommon.Enums;

namespace GestionDomain
{
    public class UsuarioDomain 
    {
        private UsuarioDAL _dal;
        private EntidadBaseDomain<Usuario> _domain;

        public UsuarioDomain(ILog log)
        {
            _dal = new UsuarioDAL(log);
            _domain = new EntidadBaseDomain<Usuario>(_dal);
        }

        public IResultado<Usuario> Obtener(int id)
        {
            Resultado<Usuario> resultado = new Resultado<Usuario>();
            
            if (id > 0)
            {
                try
                {
                    resultado.Retorno = _domain.Obtener(id);
                }
                catch (Exception ex)
                {
                    resultado.Correcto = false;
                    resultado.Mensajes.Add(ex.Message);
                }
            }
            else
            {
                resultado.Retorno = ObtenerUsuarioGenerico().Retorno;
            }

            return resultado;
        }

        public IResultado<Usuario> ObtenerUsuarioGenerico()
        {
            Usuario u = new Usuario() { Habilitado = true, IdUsuario = -1, Nombre = "Sin identificar"};

            return new Resultado<Usuario>() { Correcto = true, Retorno = u};
        }

        public IResultado<IdentificacionUsuario> RealizarIdentificacion(string nombre, string password)
        {
            Resultado<IdentificacionUsuario> resultado = new Resultado<IdentificacionUsuario>();

            try
            {
                byte[] hashPassword = PasswordHelper.GetSHA256Value(password);
                IdentificacionUsuario identificacion;

                int codigoRetorno = _dal.RealizarIdentificacion(nombre, hashPassword);
                switch (codigoRetorno)
                {
                    case -2:
                        identificacion = IdentificacionUsuario.UsuarioInvalido;
                        break;
                    case -1:
                        identificacion = IdentificacionUsuario.UsuarioBloqueado;
                        break;
                    case 0:
                        identificacion = IdentificacionUsuario.UsuarioIdentificado;
                        break;
                    default:
                        identificacion = IdentificacionUsuario.UsuarioInvalido;
                        break;
                }
                resultado.Retorno = identificacion;

            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<Usuario> ObtenerSegunNombreUsuario(string nombre)
        {
            Resultado<Usuario> resultado = new Resultado<Usuario>();

            try
            {
                resultado.Correcto = _dal.ObtenerSegunNombreUsuario(nombre);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }
    }
}
