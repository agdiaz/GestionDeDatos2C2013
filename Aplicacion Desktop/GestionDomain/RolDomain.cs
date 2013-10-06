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

        public IResultado<IList<Rol>> ObtenerTodos()
        {
            Resultado<IList<Rol>> resultado = new Resultado<IList<Rol>>();
            try
            {
                resultado.Retorno = _domain.ObtenerTodos();
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<Rol> Alta(Rol nuevoRol, IList<Funcionalidad> funcionalidades)
        {
            Resultado<Rol> resultado = new Resultado<Rol>();
            try
            {
                Rol creado = _domain.Crear(nuevoRol);
                nuevoRol.IdRol = creado.IdRol;

                foreach (Funcionalidad func in funcionalidades)
                {
                    _dal.AsociarRolFuncionalidad(nuevoRol.IdRol, func.IdFuncionalidad);
                }

                resultado.Retorno = nuevoRol;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<Rol> Modificar(Rol rolModificado, IList<Funcionalidad> funcionalidades)
        {
            Resultado<Rol> resultado = new Resultado<Rol>();

            try
            {
                _domain.Modificar(rolModificado);
                _dal.LimpiarFuncionalidades(rolModificado.IdRol);

                foreach (Funcionalidad func in funcionalidades)
                {
                    _dal.AsociarRolFuncionalidad(rolModificado.IdRol, func.IdFuncionalidad);
                }

            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<bool> Borrar(Rol rolBorrado)
        {
            try
            {
                _domain.Borrar(rolBorrado.IdRol);
                return new Resultado<bool>(true);
            }
            catch (Exception ex)
            {
                return new Resultado<bool>(ex.Message);
            }
        }
    }
}
