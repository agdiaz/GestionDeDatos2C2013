using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionCommon.Helpers;
using GestionDomain.Resultados;

namespace GestionDomain
{
    public class TipoEspecialidadDomain
    {
        private TipoEspecialidadDAL _dal;
        private EntidadBaseDomain<TipoEspecialidad, FiltroTipoEspecialidad> _domain;

        public TipoEspecialidadDomain(ILog log)
        {
            _dal = new TipoEspecialidadDAL(log);
            _domain = new EntidadBaseDomain<TipoEspecialidad, FiltroTipoEspecialidad>(_dal);
        }

        public IResultado<IList<TipoEspecialidad>> ObtenerTodos()
        {
            Resultado<IList<TipoEspecialidad>> resultado = new Resultado<IList<TipoEspecialidad>>();

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

        public IResultado<IList<TipoEspecialidad>> Filtrar(FiltroTipoEspecialidad filtro)
        {
            Resultado<IList<TipoEspecialidad>> resultado = new Resultado<IList<TipoEspecialidad>>();
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

        public IResultado<TipoEspecialidad> Crear(TipoEspecialidad especialidad)
        {
            Resultado<TipoEspecialidad> resultado = new Resultado<TipoEspecialidad>();

            try
            {
                resultado.Retorno = _domain.Crear(especialidad);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<TipoEspecialidad> Modificar(TipoEspecialidad especialidad)
        {
            Resultado<TipoEspecialidad> resultado = new Resultado<TipoEspecialidad>();

            try
            {
                resultado.Retorno = _domain.Modificar(especialidad);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<bool> Borrar(TipoEspecialidad especialidad)
        {
            Resultado<bool> resultado = new Resultado<bool>();
            try
            {
                _domain.Borrar(especialidad.Id);
                resultado.Retorno = true;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
                throw;
            }

            return resultado;
        }
    }
}
