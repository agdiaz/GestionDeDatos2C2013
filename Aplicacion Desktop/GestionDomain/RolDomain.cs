using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionDomain.Resultados;
using GestionCommon.Filtros;
using System.Data.SqlClient;
using System.Data;

namespace GestionDomain
{
    public class RolDomain
    {
        private RolDAL _dal;
        private EntidadBaseDomain<Rol, FiltroRol> _domain;

        public RolDomain(ILog log)
        {
            _dal = new RolDAL(log);
            _domain = new EntidadBaseDomain<Rol, FiltroRol>(_dal);
        }

        public IResultado<Rol> Obtener(decimal id)
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
            resultado.Retorno = new Rol() { Habilitado = true, Id = -1, Nombre = "No identificado"};
            
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
                decimal id = _domain.Crear(nuevoRol);
                nuevoRol.Id = id;

                foreach (Funcionalidad func in funcionalidades)
                {
                    _dal.AsociarRolFuncionalidad(nuevoRol.Id, func.IdFuncionalidad);
                }

                resultado.Retorno = nuevoRol;
            }
            catch (SqlException ex)
            {
                resultado.Correcto = false;
                if (ex.Errors.Count > 0)
                {
                    // Violación de constraint UNIQUE
                    if (ex.Class == 14 && (ex.Number == 2627 || ex.Number == 50000))
                    {
                        resultado.Mensajes.Add("No se permite valores repetidos para el campo nombre.");
                    }
                }
                resultado.Mensajes.Add(ex.Message);
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
                _dal.LimpiarFuncionalidades(rolModificado.Id);

                foreach (Funcionalidad func in funcionalidades)
                {
                    _dal.AsociarRolFuncionalidad(rolModificado.Id, func.IdFuncionalidad);
                }

            }
            catch (SqlException ex)
            {
                resultado.Correcto = false;
                if (ex.Errors.Count > 0)
                {
                    // Violación de constraint UNIQUE
                    if (ex.Class == 14 && (ex.Number == 2627 || ex.Number == 50000))
                    {
                        resultado.Mensajes.Add("No se permite valores repetidos para el campo Nombre.");
                    }
                }
                resultado.Mensajes.Add(ex.Message);
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
                _domain.Borrar(rolBorrado.Id);
                return new Resultado<bool>(true);
            }
            catch (Exception ex)
            {
                return new Resultado<bool>(ex.Message);
            }
        }

        public IResultado<IList<Rol>> Filtrar(FiltroRol filtro)
        {
            Resultado<IList<Rol>> resultado = new Resultado<IList<Rol>>();
            try
            {
                resultado.Retorno = _domain.Filtrar(filtro);
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
