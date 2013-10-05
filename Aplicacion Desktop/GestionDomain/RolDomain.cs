using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionDomain.Resultados;

namespace GestionDomain
{
    public class RolDomain
    {
        private RolDAL _dal;
        private EntidadBaseDomain<Rol> _domain;

        public RolDomain(ILog log)
        {
            _dal = new RolDAL(log);
            _domain = new EntidadBaseDomain<Rol>(_dal);
        }

        public IResultado<Rol> Obtener(int id)
        {
            Resultado<Rol> resultado = new Resultado<Rol>();
            if (id > 0)
            {
                try
                {
                    resultado.Retorno = _domain.Obtener(id);
                }
                catch (Exception ex)
                {
                    resultado.Mensajes.Add(ex.Message);
                    resultado.Correcto = false;
                }
            }
            else
            {
                resultado.Retorno = this.ObtenerRolGenerico().Retorno;
            }
            return resultado;
        }
        public IResultado<Rol> ObtenerRolGenerico()
        {
            Resultado<Rol> resultado = new Resultado<Rol>();
            resultado.Retorno = new Rol() { Habilitado = true, IdRol = -1, Nombre = "No identificado"};
            
            return resultado;
        }
    }
}
